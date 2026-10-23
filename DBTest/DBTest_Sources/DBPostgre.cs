using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;

namespace DBTest
{
    public static class DBPostgre
    {
        public const string CLASSNAME = "DBPostgre";

        private static string dbName = "";
        private static NpgsqlConnection connection;


        // initDB - Will close any existing connection, and connect 
        // under the input string. Only one DB connected at a time 
        // per engine.
        public static bool initDB(string dbNameString, string connectString)
        {
            const string location = CLASSNAME + ".initDB";
            bool retVal = false;
            try
            {
                if (connectString == null || connectString.Length == 0)
                {
                    L.err(location, "Input connection string was null or empty.");
                    return retVal;
                }
                if (dbNameString != null && dbNameString.Length > 0)
                {
                    dbName = dbNameString;
                }

                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection = null;

                connection = new NpgsqlConnection(connectString);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    retVal = true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool dispose()
        {
            const string location = CLASSNAME + ".dispose";
            try
            {
                if (connection != null) connection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return false;
        }

        public static int countTable(string tableName)
        {
            const string location = CLASSNAME + ".countTable";
            int retVal = -1;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (tableName == null || tableName.Length == 0)
                {
                    L.err(location, "Input table name was null or empty.");
                    return retVal;
                }

                string sql = "SELECT COUNT(*) FROM " + tableName + ";";

                connection.Open();
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        retVal = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool createTestTable(bool dropFirst)
        {
            const string location = CLASSNAME + ".createTestTable";
            bool retVal = false;
            try
            {
                //L.l(location, (dropFirst ? "Recreating" : "Creating") + " TestTable in db.");

                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }

                string sql =
                    (!dropFirst ? "" : "DROP TABLE IF EXISTS TestTable;") +
                    "CREATE TABLE IF NOT EXISTS TestTable" +
                    "(" +
                        "TestId bigserial NOT NULL," +
                        "CDT timestamp with time zone NOT NULL DEFAULT now()," +
                        "FID1 bigint," +
                        "FID2 bigint," +
                        "FID3 bigint," +
                        "Label character varying(40)," +
                        "UnitNum character varying(40)," +
                        "SerialNum character varying(40)," +
                        "MfrId bigint," +
                        "MfrLocId integer," +
                        "MachineId integer," +
                        "Lot integer," +
                        "MfrDate timestamp with time zone," +
                        "InstDate timestamp with time zone," +
                        "InstAddr1 character varying(40)," +
                        "InstAddr2 character varying(40)," +
                        "InstCity character varying(20)," +
                        "InstCounty character varying(20)," +
                        "InstProvince character varying(20)," +
                        "InstState character varying(20)," +
                        "InstCountry character varying(20)," +
                        "LastChecked timestamp with time zone," +
                        "LastModified timestamp with time zone," +
                        "LastReplaced timestamp with time zone," +
                        "LastTechId bigint," +
                        "BillingDate timestamp without time zone," +
                        "LastBillingDate timestamp without time zone," +
                        "Due real," +
                        "PastDue real," +
                        "LastDue real," +
                        "Something double precision," +
                        "IsActive boolean," +
                        "IsOnline boolean," +
                        "LastOffline timestamp with time zone," +
                        "FailedMessages bigint," +
                        "LastActionCode character varying(4)," +
                        "LastAction character varying(40)," +
                        "NextActionCode character varying(4)," +
                        "NextTechId bigint," +
                        "CntActionsTaken integer," +
                        "LastNote text" +
                    ");";

                connection.Open();
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        retVal = true;
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

                //L.l(location, "Finished " + (dropFirst ? "recreating" : "creating") +
                //" TestTable in db with result (" + retVal + ").");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // dynamicSQL - Parameterless query as text in query.sql
        public static bool dynamicSQL(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".dynamicSQL";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (query == null || query.sql == null || query.sql.Length == 0)
                {
                    L.err(location, "Input sql was null or empty.");
                    return retVal;
                }
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                DateTime dtQueryStart = DateTime.Now;


                connection.Open();
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query.sql, connection))
                    {
                        List<string> fieldNames = new List<string>();

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            query.queryMS = (DateTime.Now - dtQueryStart).TotalMilliseconds;
                            DateTime dtResultStart = DateTime.Now;
                            while (reader.Read())
                            {
                                // Get a list of field names to iterate
                                if (fieldNames.Count == 0)
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        fieldNames.Add(reader.GetName(i));

                                // Iterate fields
                                Dictionary<string, object> row = new Dictionary<string, object>();
                                for (int i = 0; i < fieldNames.Count; i++)
                                    row.Add(fieldNames[i], reader[fieldNames[i]]);

                                query.result.Add(row);
                            }
                            query.responseFormatMS = (DateTime.Now - dtResultStart).TotalMilliseconds;
                            retVal = true;
                        }
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool existsTable(string tableName)
        {
            const string location = CLASSNAME + ".existsTable";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                string sql = "select count(*) from information_schema.tables where table_schema='public' and table_name=@TableName";

                connection.Open();
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName.ToLower());
                        long count = (long)command.ExecuteScalar();
                        retVal = count > 0;
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // insert - Attempts to build sql if not supplied, using tableName and parms
        public static bool insert(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".insert";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (query == null)
                {
                    L.err(location, "Input query was null.");
                    return retVal;
                }
                if (query.parms == null || query.parms.Count == 0)
                {
                    L.err(location, "Insert parameters were null or empty.");
                    return retVal;
                }

                // Attempt to autobuild sql if not exist
                if (query.sql == null || query.sql.Length == 0)
                {
                    if (query.tableName == null || query.tableName.Length == 0)
                    {
                        L.err(location, "Table name was null or empty.");
                        return retVal;
                    }

                    // Build SQL
                    StringBuilder sbKeys = new StringBuilder();
                    StringBuilder sbValues = new StringBuilder();
                    {
                        bool started = false;
                        foreach (KeyValuePair<string, object> kv in query.parms)
                        {
                            if (started)
                            {
                                sbKeys.Append(",");
                                sbValues.Append(",");
                            }
                            else started = true;

                            sbKeys.Append(kv.Key);
                            sbValues.Append("@" + kv.Key);
                        }
                    }
                    query.sql =
                        "INSERT INTO " + query.tableName + " (" + sbKeys.ToString() +
                        ") VALUES (" + sbValues.ToString() + ");";
                }

                DateTime dtStart = DateTime.Now;


                connection.Open();
                try
                {
                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (NpgsqlCommand command = new NpgsqlCommand(query.sql, connection, transaction))
                            {
                                command.Prepare();

                                foreach (KeyValuePair<string, object> kv in query.parms)
                                {
                                    command.Parameters.Add(new NpgsqlParameter("@" + kv.Key, kv.Value));
                                }

                                retVal = command.ExecuteNonQuery() > 0;
                            }
                            transaction.Commit();
                        }
                        catch (Exception exTxn)
                        {
                            if (transaction != null) transaction.Rollback();
                        }
                    }
                }
                catch (Exception exTxn)
                {
                    L.ex(location, exTxn);
                }
                connection.Close();


                if (query != null) query.queryMS += (DateTime.Now - dtStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // Generates sql from tablename and parms on first valid query
        public static bool insertSameFormat(ref List<SQLWrapper> queries)
        {
            const string location = CLASSNAME + ".insertSameFormat";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (queries == null || queries.Count == 0)
                {
                    L.err(location, "Input rows were null or empty.");
                    return retVal;
                }
                // This is an arbitrary rule, but idx-0 cannot be null, we are 
                // returning stats and sql statement on it for testing
                if (queries[0] == null)
                {
                    L.err(location, "Input query at index-0 was null.");
                    return retVal;
                }

                // Find the first valid parms to build sql from
                int idxSql = -1;
                int cntParms = 0;
                for (int i = 0; idxSql < 0 && i < queries.Count; i++)
                {
                    if (
                        queries[i].tableName != null && queries[i].tableName.Length > 0 &&
                        queries[i].parms != null && queries[i].parms.Count > 0
                    )
                    {
                        idxSql = i;
                    }
                }
                if (idxSql < 0)
                {
                    L.err(location, "No valid insert parms in queries.");
                    return retVal;
                }
                cntParms = queries[idxSql].parms.Count;


                DateTime dtInsertStart = DateTime.Now;

                // Build SQL
                StringBuilder sbKeys = new StringBuilder();
                StringBuilder sbValues = new StringBuilder();
                {
                    bool started = false;
                    foreach (KeyValuePair<string, object> kv in queries[idxSql].parms)
                    {
                        if (started)
                        {
                            sbKeys.Append(",");
                            sbValues.Append(",");
                        }
                        else started = true;

                        sbKeys.Append(kv.Key.ToLower());
                        sbValues.Append("@" + kv.Key);
                    }
                }
                string sql =
                    "INSERT INTO " + queries[idxSql].tableName + " (" + sbKeys.ToString() +
                    ") VALUES (" + sbValues.ToString() + ");";
                queries[0].sql = sql;

                connection.Open();
                try
                {
                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection, transaction))
                            {
                                int cntInserts = 0;
                                int cntParmErr = 0;
                                for (int i = 0; i < queries.Count; i++)
                                {
                                    try
                                    {
                                        // Write row parms
                                        if (queries[i].parms == null || queries[i].parms.Count != cntParms)
                                        {
                                            cntParmErr++;
                                            continue;
                                        }
                                        command.Parameters.Clear();
                                        foreach (KeyValuePair<string, object> kv in queries[i].parms)
                                            command.Parameters.AddWithValue("@" + kv.Key, kv.Value);

                                        // Execute command with row-count
                                        cntInserts += command.ExecuteNonQuery();
                                    }
                                    catch (Exception exCmd)
                                    {
                                        cntParmErr++;
                                        L.err(location, "Command Error: " + exCmd.Message);
                                    }
                                }
                                retVal = cntInserts == queries.Count;
                            }

                            transaction.Commit();
                        }
                        catch (Exception exTxn)
                        {
                            L.err(location, "Command Error: " + exTxn.Message);
                            if (transaction != null) transaction.Rollback();
                        }
                    }
                }
                catch (Exception exTxn)
                {
                    L.ex(location, exTxn);
                }
                connection.Close();


                queries[0].queryMS += (DateTime.Now - dtInsertStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // nonquery - Returns row count
        public static int nonquery(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".nonquery";
            int retVal = 0;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (query == null)
                {
                    L.err(location, "Input query list was null or empty.");
                    return retVal;
                }

                DateTime dtQueryStart = DateTime.Now;

                int cntErrors = 0;
                int cntEmptyQuery = 0;

                List<string> fieldNames = new List<string>();

                connection.Open();
                try
                {
                    // Validate query data
                    if (query.sql == null || query.sql.Length == 0)
                    {
                        L.err(location, "Query was null or empty.");
                    }
                    else
                    {
                        if (query.result == null) query.result =
                            new List<Dictionary<string, object>>();

                        // Build command
                        using (NpgsqlCommand command = new NpgsqlCommand(query.sql, connection))
                        {
                            // Caller should have already defined required parms in sql, add with value
                            if (query.parms != null)
                                foreach (KeyValuePair<string, object> kv in query.parms)
                                    command.Parameters.AddWithValue(kv.Key, kv.Value);

                            retVal = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

                if (cntEmptyQuery > 0 || cntErrors > 0)
                {
                    L.err(location, "Encountered (" + cntErrors + ") errors and (" + cntEmptyQuery + ") empty or null queries.");
                }

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static long ordinal(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".ordinal";
            long retVal = -1;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (query == null)
                {
                    L.err(location, "Input query list was null or empty.");
                    return retVal;
                }

                DateTime dtQueryStart = DateTime.Now;

                int cntErrors = 0;
                int cntEmptyQuery = 0;

                List<string> fieldNames = new List<string>();

                connection.Open();
                try
                {
                    // Validate query data
                    if (query.sql == null || query.sql.Length == 0)
                    {
                        L.err(location, "Query was null or empty.");
                    }
                    else
                    {
                        if (query.result == null) query.result =
                            new List<Dictionary<string, object>>();

                        // Build command
                        using (NpgsqlCommand command = new NpgsqlCommand(query.sql, connection))
                        {
                            // Caller should have already defined required parms in sql, add with value
                            if (query.parms != null)
                                foreach (KeyValuePair<string, object> kv in query.parms)
                                    command.Parameters.AddWithValue(kv.Key, kv.Value);

                            long val = (long)command.ExecuteScalar();
                            retVal = val;
                        }
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

                if (cntEmptyQuery > 0 || cntErrors > 0)
                {
                    L.err(location, "Encountered (" + cntErrors + ") errors and (" + cntEmptyQuery + ") empty or null queries.");
                }

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // que - A generic query from sql, without or without parms or rows. 
        public static bool que(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".que";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (query.sql == null || query.sql.Length == 0)
                {
                    L.err(location, "Input sql was null or empty.");
                    return retVal;
                }
                if (query.parms == null) query.parms = new Dictionary<string, object>();
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                DateTime dtStart = DateTime.Now;

                List<string> fieldNames = new List<string>();

                connection.Open();
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query.sql, connection))
                    {
                        if (query.parms != null)
                            foreach (KeyValuePair<string, object> kv in query.parms)
                                command.Parameters.AddWithValue(kv.Key, kv.Value);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Get a list of field names to iterate
                                if (fieldNames.Count == 0)
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        fieldNames.Add(reader.GetName(i));

                                Dictionary<string, object> row = new Dictionary<string, object>();
                                for (int i = 0; i < fieldNames.Count; i++)
                                    row.Add(fieldNames[i], reader[fieldNames[i]]);
                                query.result.Add(row);
                            }
                            retVal = true;
                        }
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

                query.queryMS += (DateTime.Now - dtStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // selectSameFormat - First valid sql is run, with new values. Idea is use row-0,
        // not replicate string across list.
        public static bool selectSameFormat(ref List<SQLWrapper> queries)
        {
            const string location = CLASSNAME + ".selectSameFormat";
            bool retVal = false;
            try
            {
                if (connection == null)
                {
                    L.err(location, "DB not initialized.");
                    return retVal;
                }
                if (queries == null || queries.Count == 0)
                {
                    L.err(location, "Input rows were null or empty.");
                    return retVal;
                }
                // This is an arbitrary rule, but idx-0 cannot be null, we are 
                // returning stats and sql statement on it for testing
                if (queries[0] == null)
                {
                    L.err(location, "Input query at index-0 was null.");
                    return retVal;
                }

                string sql = "";
                int idxSql = -1;
                int cntParms = 0;

                // Find the first valid sql to use
                for (int i = 0; i < queries.Count; i++)
                {
                    if (queries[i].sql != null && queries[i].sql.Length > 0)
                    {
                        sql = queries[i].sql;
                        break;
                    }
                }
                if (sql.Length == 0)
                {
                    L.err(location, "No sql statements in input.");
                    return retVal;
                }

                // Find the first populated parameters to validate from
                for (int i = 0; i < queries.Count; i++)
                {
                    if (queries[i].parms != null && queries[i].parms.Count > cntParms)
                    {
                        idxSql = i;
                        break;
                    }
                }
                if (idxSql > 0) cntParms = queries[idxSql].parms.Count;


                DateTime dtStart = DateTime.Now;

                int cntParmsErr = 0;
                int cntExecErr = 0;
                connection.Open();
                try
                {
                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                            {
                                command.Prepare();

                                List<string> fieldNames = new List<string>();
                                for (int i = 0; i < queries.Count; i++)
                                {
                                    try
                                    {
                                        if (queries[i] == null) continue;
                                        if (cntParms > 0 && queries[i].parms == null)
                                        {
                                            cntParmsErr++;
                                            continue;
                                        }
                                        if (queries[i].parms.Count != cntParms)
                                        {
                                            cntParmsErr++;
                                            continue;
                                        }

                                        if (queries[i].parms != null)
                                        {

                                            foreach (KeyValuePair<string, object> kv in queries[i].parms)
                                            {
                                                command.Parameters.AddWithValue(kv.Key, kv.Value);
                                            }
                                        }

                                        using (NpgsqlDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // Get a list of field names to iterate
                                                if (fieldNames.Count == 0)
                                                {
                                                    for (int f = 0; f < reader.FieldCount; f++)
                                                    {
                                                        fieldNames.Add(reader.GetName(f));
                                                    }
                                                }

                                                Dictionary<string, object> row = new Dictionary<string, object>();
                                                for (int f = 0; f < fieldNames.Count; f++)
                                                {
                                                    row.Add(fieldNames[f], reader[fieldNames[f]]);
                                                }

                                                queries[i].result.Add(row);
                                            }
                                        }

                                        if (queries[i].result == null)
                                            queries[i].result = new List<Dictionary<string, object>>();
                                    }
                                    catch (Exception exCmd)
                                    {
                                        cntExecErr++;
                                    }
                                }

                                retVal = true;
                            }
                            transaction.Commit();
                        }
                        catch (Exception exTxn)
                        {
                            if (transaction != null) transaction.Rollback();
                        }
                    }
                }
                catch (Exception exCmd)
                {
                    L.ex(location, exCmd);
                }
                connection.Close();

                queries[0].queryMS += (DateTime.Now - dtStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }





    }
}
