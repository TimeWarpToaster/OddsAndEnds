using System;
using System.Collections.Generic;

namespace DBTest
{
    public static class DB
    {
        public const string CLASSNAME = "DB";

        public enum Engine
        {
            MARIADB,
            MSSQL,
            MYSQL,
            POSTGRE,
            SQLITE,
            UNKNOWN
        }

        private static Engine currentEngine;


        public static bool dispose()
        {
            const string location = CLASSNAME + ".dispose";
            try
            {
                return
                    DBMariaDB.dispose() &&
                    DBMSSQL.dispose() &&
                    DBMySQL.dispose() &&
                    DBPostgre.dispose() &&
                    DBSQLite.dispose();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return false;
        }

        public static bool initDB(DB.Engine dbEngine, string dbName, string connectString)
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
                DB.currentEngine = dbEngine;

                L.l(location, "Initializing (" + DB.currentEngine + ") db engine.");
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.initDB(dbName, connectString); break;
                    case Engine.MSSQL: retVal = DBMSSQL.initDB(dbName, connectString); break;
                    case Engine.MYSQL: retVal = DBMySQL.initDB(dbName, connectString); break;
                    case Engine.POSTGRE: retVal = DBPostgre.initDB(dbName, connectString); break;
                    case Engine.SQLITE: retVal = DBSQLite.initDB(dbName, connectString); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
                if (retVal) L.l(location, "Initialized (" + DB.currentEngine + ").");

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        // get an engine by name
        public static DB.Engine engine(string engineName)
        {
            const string location = CLASSNAME + ".getEngine";
            Engine retVal = DB.Engine.UNKNOWN;
            try
            {
                if (engineName == null) 
                {
                    L.err(location, "Input db engine name was null.");
                    return retVal;
                }
                switch (engineName.ToUpper())
                {
                    case "MARIADB": retVal = DB.Engine.MARIADB; break;
                    case "MSSQL":   retVal = DB.Engine.MSSQL;   break;
                    case "MYSQL":   retVal = DB.Engine.MYSQL;   break;
                    case "POSTGRE": retVal = DB.Engine.POSTGRE; break;
                    case "SQLITE":  retVal = DB.Engine.SQLITE;  break;
                    default:
                        L.err(location, "Unknown engine (" + engineName + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // get the current engine
        public static DB.Engine engine() { return DB.currentEngine; }

        // set the current engine
        public static bool engine(DB.Engine dbEngine) { DB.currentEngine = dbEngine; return true; }



        public static int countTable(string tableName)
        {
            const string location = CLASSNAME + ".countTable";
            int retVal = -1;
            try
            {
                L.l(location, "Counting (" + DB.currentEngine + 
                    ") table (" + (tableName != null ? tableName : "null") + ").");
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.countTable(tableName); break;
                    case Engine.MSSQL: retVal = DBMSSQL.countTable(tableName); break;
                    case Engine.MYSQL: retVal = DBMySQL.countTable(tableName); break;
                    case Engine.POSTGRE: retVal = DBPostgre.countTable(tableName); break;
                    case Engine.SQLITE: retVal = DBSQLite.countTable(tableName); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
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
                L.l(location, (dropFirst ? "Recreating" : "Creating") + " TestTable in (" + DB.currentEngine + ").");

                if (!dropFirst && DB.existsTable("TestTable"))
                {
                    retVal = true;
                    return retVal;
                }
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.createTestTable(dropFirst); break;
                    case Engine.MSSQL: retVal = DBMSSQL.createTestTable(dropFirst); break;
                    case Engine.MYSQL: retVal = DBMySQL.createTestTable(dropFirst); break;
                    case Engine.POSTGRE: retVal = DBPostgre.createTestTable(dropFirst); break;
                    case Engine.SQLITE: retVal = DBSQLite.createTestTable(dropFirst); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
                if (retVal) 
                {
                    L.l(location, "Finished " + (dropFirst ? "recreating" : "creating") +
                        " TestTable in (" + DB.currentEngine + ") with result (" + retVal + ").");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool dynamicSQL(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".dynamicSQL";
            bool retVal = false;
            try
            {
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.dynamicSQL(ref query); break;
                    case Engine.MSSQL: retVal = DBMSSQL.dynamicSQL(ref query); break;
                    case Engine.MYSQL: retVal = DBMySQL.dynamicSQL(ref query); break;
                    case Engine.POSTGRE: retVal = DBPostgre.dynamicSQL(ref query); break;
                    case Engine.SQLITE: retVal = DBSQLite.dynamicSQL(ref query); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
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
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.existsTable(tableName); break;
                    case Engine.MSSQL: retVal = DBMSSQL.existsTable(tableName); break;
                    case Engine.MYSQL: retVal = DBMySQL.existsTable(tableName); break;
                    case Engine.POSTGRE: retVal = DBPostgre.existsTable(tableName); break;
                    case Engine.SQLITE: retVal = DBSQLite.existsTable(tableName); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool insert(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".insert(1)";
            bool retVal = false;
            try
            {
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.insert(ref query); break;
                    case Engine.MSSQL: retVal = DBMSSQL.insert(ref query); break;
                    case Engine.MYSQL: retVal = DBMySQL.insert(ref query); break;
                    case Engine.POSTGRE: retVal = DBPostgre.insert(ref query); break;
                    case Engine.SQLITE: retVal = DBSQLite.insert(ref query); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool insert(ref List<SQLWrapper> queries)
        {
            const string location = CLASSNAME + ".insert";
            bool retVal = false;
            try
            {
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.insertSameFormat(ref queries); break;
                    case Engine.MSSQL: retVal = DBMSSQL.insertSameFormat(ref queries); break;
                    case Engine.MYSQL: retVal = DBMySQL.insertSameFormat(ref queries); break;
                    case Engine.POSTGRE: retVal = DBPostgre.insertSameFormat(ref queries); break;
                    case Engine.SQLITE: retVal = DBSQLite.insertSameFormat(ref queries); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool que(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".que";
            bool retVal = false;
            try
            {
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.que(ref query); break;
                    case Engine.MSSQL: retVal = DBMSSQL.que(ref query); break;
                    case Engine.MYSQL: retVal = DBMySQL.que(ref query); break;
                    case Engine.POSTGRE: retVal = DBPostgre.que(ref query); break;
                    case Engine.SQLITE: retVal = DBSQLite.que(ref query); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool selectSameFormat(ref List<SQLWrapper> queries)
        {
            const string location = CLASSNAME + ".selectSameFormat";
            bool retVal = false;
            try
            {
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.selectSameFormat(ref queries); break;
                    case Engine.MSSQL: retVal = DBMSSQL.selectSameFormat(ref queries); break;
                    case Engine.MYSQL: retVal = DBMySQL.selectSameFormat(ref queries); break;
                    case Engine.POSTGRE: retVal = DBPostgre.selectSameFormat(ref queries); break;
                    case Engine.SQLITE: retVal = DBSQLite.selectSameFormat(ref queries); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
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
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.nonquery(ref query); break;
                    case Engine.MSSQL: retVal = DBMSSQL.nonquery(ref query); break;
                    case Engine.MYSQL: retVal = DBMySQL.nonquery(ref query); break;
                    case Engine.POSTGRE: retVal = DBPostgre.nonquery(ref query); break;
                    case Engine.SQLITE: retVal = DBSQLite.nonquery(ref query); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
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
                switch (DB.currentEngine)
                {
                    case Engine.MARIADB: retVal = DBMariaDB.ordinal(ref query); break;
                    case Engine.MSSQL: retVal = DBMSSQL.ordinal(ref query); break;
                    case Engine.MYSQL: retVal = DBMySQL.ordinal(ref query); break;
                    case Engine.POSTGRE: retVal = DBPostgre.ordinal(ref query); break;
                    case Engine.SQLITE: retVal = DBSQLite.ordinal(ref query); break;
                    default:
                        L.err(location, "Unknown engine (" + DB.currentEngine + ").");
                        break;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



    }
}
