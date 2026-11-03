using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    public static class TSQL
    {
        public const string CLASSNAME = "TSQL";


        public static class MariaDB
        {
            public const string CLASSNAME = "TSQL.MariaDB";


            public static bool createTestIndexes()
            {
                const string location = CLASSNAME + ".createTestIndexes";
                bool retVal = false;
                try
                {
                    Dictionary<string, string> existing = TSQL.MariaDB.getIndexes("TestTable");

                    bool idIdxExists = false;
                    bool cdtIdxExists = false;
                    bool serialNumIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                        else if (kv.Key == "idx_TestTable_SerialNum") serialNumIdxExists = true;
                    }

                    //int cntErr = 0;
                    if (!idIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.TestId.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE UNIQUE INDEX idx_TestTable_Id ON TestTable (TestId);";

                        long created = DB.nonquery(ref query);
                        //L.l(location, "Id index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    if (!cdtIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.CDT.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_Cdt ON TestTable (CDT) USING btree;";
                        long created = DB.nonquery(ref query);
                        //L.l(location, "CDT index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    if (!serialNumIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.SerialNum.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_SerialNum ON TestTable (SerialNum);";
                        long created = DB.nonquery(ref query);
                        //L.l(location, "SerialNum index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    // TODO - Decide on inconsistent section below, no one else has it

                    // Requery if indices exist
                    existing = new Dictionary<string, string>();
                    existing = TSQL.MariaDB.getIndexes("TestTable");

                    idIdxExists = false;
                    cdtIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                    }

                    retVal = idIdxExists && cdtIdxExists;
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static bool createTestProcedures()
            {
                const string location = CLASSNAME + ".createTestProcedures";
                bool retVal = false;
                try
                {
                    L.l(location, "Creating test procedures.");

                    int cntErr = 0;
                    long cntCreated = 0;

                    SQLWrapper getById = new SQLWrapper();
                    getById.sql =
                        "DROP PROCEDURE IF EXISTS getTestTableById;" +
                        "CREATE PROCEDURE IF NOT EXISTS getTestTableById(IN pTestId integer) " + 
                        "begin " + 
                        "select * from TestTable T where T.TestId=pTestId; " + 
                        "end;";
                    cntCreated += DB.nonquery(ref getById);

                    SQLWrapper updateById = new SQLWrapper();
                    updateById.sql =
                        @"DROP PROCEDURE IF EXISTS updateTestTableById;
                        
                        CREATE PROCEDURE IF NOT EXISTS updateTestTableById(
                        IN pTestId integer,
                        IN pFID1 integer,
                        IN pFID2 integer,
                        IN pFID3 integer,
                        IN pLabel varchar(40),
                        IN pUnitNum varchar(40),
                        IN pSerialNum varchar(40),
                        IN pMfrId integer,
                        IN pMfrLocId integer,
                        IN pMachineId integer,
                        IN pLot integer,
                        IN pMfrDate datetime,
                        IN pInstDate datetime,
                        IN pInstAddr1 varchar(40),
                        IN pInstAddr2 varchar(40),
                        IN pInstCity varchar(20),
                        IN pInstCounty varchar(20),
                        IN pInstProvince varchar(20),
                        IN pInstState varchar(20),
                        IN pInstCountry varchar(20),
                        IN pLastChecked datetime,
                        IN pLastModified datetime,
                        IN pLastReplaced datetime,
                        IN pLastTechId integer,
                        IN pBillingDate datetime,
                        IN pLastBillingDate datetime,
                        IN pDue real,
                        IN pPastDue real,
                        IN pLastDue real,
                        IN pSomething real,
                        IN pIsActive boolean,
                        IN pIsOnline boolean,
                        IN pLastOffline datetime,
                        IN pFailedMessages integer,
                        IN pLastActionCode varchar(4),
                        IN pLastAction varchar(40),
                        IN pNextActionCode varchar(4),
                        IN pNextTechId integer,
                        IN pCntActionsTaken integer,
                        IN pLastNote text
                        ) 
                        begin 
                        update TestTable set 
                        
                        FID1=pFID1,
                        FID2=pFID2,
                        FID3=pFID3,
                        Label=pLabel,
                        UnitNum=pUnitNum,
                        SerialNum=pSerialNum,
                        MfrId=pMfrId,
                        MfrLocId=pMfrLocId,
                        MachineId=pMachineId,
                        Lot=pLot,
                        MfrDate=pMfrDate,
                        InstDate=pInstDate,
                        InstAddr1=pInstAddr1,
                        InstAddr2=pInstAddr2,
                        InstCity=pInstCity,
                        InstCounty=pInstCounty,
                        InstProvince=pInstProvince,
                        InstState=pInstState,
                        InstCountry=pInstCountry,
                        LastChecked=pLastChecked,
                        LastModified=pLastModified,
                        LastReplaced=pLastReplaced,
                        LastTechId=pLastTechId,
                        BillingDate=pBillingDate,
                        LastBillingDate=pLastBillingDate,
                        Due=pDue,
                        PastDue=pPastDue,
                        LastDue=pLastDue,
                        Something=pSomething,
                        IsActive=pIsActive,
                        IsOnline=pIsOnline,
                        LastOffline=pLastOffline,
                        FailedMessages=pFailedMessages,
                        LastActionCode=pLastActionCode,
                        LastAction=pLastAction,
                        NextActionCode=pNextActionCode,
                        NextTechId=pNextTechId,
                        CntActionsTaken=pCntActionsTaken,
                        LastNote=pLastNote 
                        where TestId=pTestId; 
                        end;";
                    cntCreated += DB.nonquery(ref updateById);


                    SQLWrapper getByDt = new SQLWrapper();
                    getByDt.sql =
                        @"DROP PROCEDURE IF EXISTS getTestTableByDt;

                        CREATE PROCEDURE IF NOT EXISTS getTestTableByDt(
                        IN pDtStart datetime, IN pDtEnd datetime, IN pMaxRecords integer)
                        begin
                        select * from TestTable T 
                        where T.CDT > pDtStart and T.CDT <= pDtEnd 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;";
                    cntCreated += DB.nonquery(ref getByDt);

                    SQLWrapper getByVarchar = new SQLWrapper();
                    getByVarchar.sql =
                        @"DROP PROCEDURE IF EXISTS getTestTableBySerialNum;

                        CREATE PROCEDURE IF NOT EXISTS getTestTableBySerialNum(
                        IN pSerialNum varchar(40), IN pMaxRecords integer)
                        begin
                        select * from TestTable T 
                        where T.SerialNum=pSerialNum 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;";
                    cntCreated += DB.nonquery(ref getByVarchar);



                    retVal = true;

                    /*if (created <= 0) 
                    {
                        L.err(location, "Failed to create procedure getTestTableById.");
                        cntErr++;
                    }

                    // TODO - Add a DB...existsProcedure(query) routine

                    retVal = cntErr == 0;*/
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
                    SQLWrapper query = new SQLWrapper();
                    query.sql =
                        (!dropFirst ? "" : "DROP TABLE IF EXISTS TestTable;") +
                        "CREATE TABLE TestTable (" +
                        "TestId integer primary key auto_increment," +
                        "CDT datetime DEFAULT now()," + // integer for unix time, real for Julian
                        "FID1 integer," +
                        "FID2 integer," +
                        "FID3 integer," +
                        "Label varchar(40)," +
                        "UnitNum varchar(40)," +
                        "SerialNum varchar(40)," +
                        "MfrId integer," +
                        "MfrLocId integer," +
                        "MachineId integer," +
                        "Lot integer," +
                        "MfrDate datetime," +
                        "InstDate datetime," +
                        "InstAddr1 varchar(40)," +
                        "InstAddr2 varchar(40)," +
                        "InstCity varchar(20)," +
                        "InstCounty varchar(20)," +
                        "InstProvince varchar(20)," +
                        "InstState varchar(20)," +
                        "InstCountry varchar(20)," +
                        "LastChecked datetime," +
                        "LastModified datetime," +
                        "LastReplaced datetime," +
                        "LastTechId integer," +
                        "BillingDate datetime," +
                        "LastBillingDate datetime," +
                        "Due real," +
                        "PastDue real," +
                        "LastDue real," +
                        "Something real," +// double and float are real
                        "IsActive boolean," +
                        "IsOnline boolean," +
                        "LastOffline datetime," +
                        "FailedMessages integer," +
                        "LastActionCode varchar(4)," +
                        "LastAction varchar(40)," +
                        "NextActionCode varchar(4)," +
                        "NextTechId integer," +
                        "CntActionsTaken integer," +
                        "LastNote text" +
                        ");";

                    DB.nonquery(ref query);
                    retVal = DB.existsTable("TestTable");

                    if (retVal)
                    {
                        // TODO - TEST SECTION
                        L.l(location, "Checking indexes.");
                        if (!createTestIndexes())
                        {
                            L.err(location, "Failed to create indexes.");
                        }

                        L.l(location, "Checking procedures.");
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create procedures.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static Dictionary<string, string> getIndexes(string tableName)
            {
                const string location = CLASSNAME + ".getIndexes";
                Dictionary<string, string> retVal = new Dictionary<string, string>();
                try
                {
                    if (tableName == null || tableName.Length == 0)
                    {
                        L.err(location, "Input table name was null or empty.");
                        return retVal;
                    }

                    SQLWrapper query = new SQLWrapper();
                    query.sql = "show index from " + tableName + ";";

                    if (!DB.que(ref query))
                    {
                        L.err(location, "Failed to query indexes on table (" + tableName + ").");
                    }
                    else if (query.result == null)
                    {
                        L.err(location, "Results were null.");
                    }
                    else
                    {
                        // Convert each row into a single KeyValuePair
                        int formatErr = 0;
                        for (int i = 0; i < query.result.Count; i++)
                        {
                            if (query.result[i] == null || query.result[i].Count < 2)
                            {
                                formatErr++;
                                continue;
                            }

                            string key =
                                query.result[i].ContainsKey("Key_name") &&
                                query.result[i]["Key_name"] != DBNull.Value ?
                                (string)query.result[i]["Key_name"] : "";

                            string val =
                                query.result[i].ContainsKey("Column_name") &&
                                query.result[i]["Column_name"] != DBNull.Value ?
                                (string)query.result[i]["Column_name"] : "";

                            retVal.Add(key, val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }
        }

        public static class MSSQL
        {
            public const string CLASSNAME = "TSQL.MSSQL";

            public static bool createTestIndexes()
            {
                const string location = CLASSNAME + ".createTestIndexes";
                bool retVal = false;
                try
                {
                    Dictionary<string, string> existing = TSQL.MSSQL.getIndexes("TestTable");

                    bool idIdxExists = false;
                    bool cdtIdxExists = false;
                    bool serialNumIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                        else if (kv.Key == "idx_TestTable_SerialNum") serialNumIdxExists = true;
                    }

                    int cntErr = 0;
                    if (!idIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.TestId.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE UNIQUE INDEX idx_TestTable_Id ON TestTable(TestId);select cast(1 as bigint);";

                        long created = DB.ordinal(ref query);
                        L.l(location, "Id index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!cdtIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.CDT.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE NONCLUSTERED INDEX idx_TestTable_Cdt ON TestTable (CDT);select cast(1 as bigint);";

                        long created = DB.ordinal(ref query);
                        L.l(location, "CDT index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!serialNumIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.SerialNum.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE NONCLUSTERED INDEX idx_TestTable_SerialNum ON TestTable (SerialNum);select cast(1 as bigint);";
                        long created = DB.ordinal(ref query);
                        L.l(location, "SerialNum index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    retVal = cntErr == 0;
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static bool createTestProcedures()
            {
                const string location = CLASSNAME + ".createTestProcedures";
                bool retVal = false;
                try
                {
                    L.l(location, "Creating test procedures.");
                    long cntCreated = 0;

                    SQLWrapper getById = new SQLWrapper();
                    getById.sql =
                        @"CREATE OR ALTER PROC getTestTableById (@TestId bigint) 
                        AS SET NOCOUNT ON 
                        select * from TestTable T where T.TestId=@TestId;";
                    cntCreated += DB.ordinal(ref getById);


                    SQLWrapper updateById = new SQLWrapper();
                    updateById.sql =
                        @"CREATE OR ALTER PROC updateTestTableById 
                        (
                        @TestId bigint,
                        @FID1 int,
                        @FID2 int,
                        @FID3 int,
                        @Label varchar(40),
                        @UnitNum varchar(40),
                        @SerialNum varchar(40),
                        @MfrId bigint,
                        @MfrLocId bigint,
                        @MachineId bigint,
                        @Lot bigint,
                        @MfrDate datetime,
                        @InstDate datetime,
                        @InstAddr1 varchar(40),
                        @InstAddr2 varchar(40),
                        @InstCity varchar(20),
                        @InstCounty varchar(20),
                        @InstProvince varchar(20),
                        @InstState varchar(20),
                        @InstCountry varchar(20),
                        @LastChecked datetime,
                        @LastModified datetime,
                        @LastReplaced datetime,
                        @LastTechId bigint,
                        @BillingDate datetime,
                        @LastBillingDate datetime,
                        @Due float,
                        @PastDue float,
                        @LastDue float,
                        @Something decimal,
                        @IsActive bit,
                        @IsOnline bit,
                        @LastOffline datetime,
                        @FailedMessages bigint,
                        @LastActionCode varchar(4),
                        @LastAction varchar(40),
                        @NextActionCode varchar(4),
                        @NextTechId bigint,
                        @CntActionsTaken int,
                        @LastNote text
                        )
                        AS SET NOCOUNT ON 

                        update TestTable set
                        FID1=@FID1,
                        FID2=@FID2,
                        FID3=@FID3,
                        Label=@Label,
                        UnitNum=@UnitNum,
                        SerialNum=@SerialNum,
                        MfrId=@MfrId,
                        MfrLocId=@MfrLocId,
                        MachineId=@MachineId,
                        Lot=@Lot,
                        MfrDate=@MfrDate,
                        InstDate=@InstDate,
                        InstAddr1=@InstAddr1,
                        InstAddr2=@InstAddr2,
                        InstCity=@InstCity,
                        InstCounty=@InstCounty,
                        InstProvince=@InstProvince,
                        InstState=@InstState,
                        InstCountry=@InstCountry,
                        LastChecked=@LastChecked,
                        LastModified=@LastModified,
                        LastReplaced=@LastReplaced,
                        LastTechId=@LastTechId,
                        BillingDate=@BillingDate,
                        LastBillingDate=@LastBillingDate,
                        Due=@Due,
                        PastDue=@PastDue,
                        LastDue=@LastDue,
                        Something=@Something,
                        IsActive=@IsActive,
                        IsOnline=@IsOnline,
                        LastOffline=@LastOffline,
                        FailedMessages=@FailedMessages,
                        LastActionCode=@LastActionCode,
                        LastAction=@LastAction,
                        NextActionCode=@NextActionCode,
                        NextTechId=@NextTechId,
                        CntActionsTaken=@CntActionsTaken,
                        LastNote=@LastNote 
                        where TestId=@TestId;";
                    cntCreated += DB.ordinal(ref updateById);



                    SQLWrapper getByDt = new SQLWrapper();
                    getByDt.sql =
                        @"CREATE OR ALTER PROC getTestTableByDt(
                        @DtStart datetime, @DtEnd datetime, @MaxRecords int)

                        AS SET NOCOUNT ON 

                        select top (@MaxRecords) * from TestTable T 
                        where T.CDT > @DtStart and T.CDT <= @DtEnd 
                        order by T.TestId desc;";
                    cntCreated += DB.nonquery(ref getByDt);

                    SQLWrapper getByVarchar = new SQLWrapper();
                    getByVarchar.sql =
                        @"CREATE OR ALTER PROC getTestTableBySerialNum(@SerialNum varchar(40), @MaxRecords int)

                        AS SET NOCOUNT ON 

                        select top (@MaxRecords) * from TestTable T 
                        where T.SerialNum=@SerialNum 
                        order by T.TestId desc;";
                    cntCreated += DB.nonquery(ref getByVarchar);


                    retVal = true;
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
                    SQLWrapper query = new SQLWrapper();
                    query.sql =
                        (!dropFirst ? "" : "DROP TABLE IF EXISTS TestTable;") +
                        "CREATE TABLE TestTable (" +
                        "TestId bigint identity(1,1) primary key," +
                        "CDT datetime DEFAULT getdate()," + // integer for unix time, real for Julian
                        "FID1 int," +
                        "FID2 int," +
                        "FID3 int," +
                        "Label varchar(40)," +
                        "UnitNum varchar(40)," +
                        "SerialNum varchar(40)," +
                        "MfrId bigint," +
                        "MfrLocId bigint," +
                        "MachineId bigint," +
                        "Lot bigint," +
                        "MfrDate datetime," +
                        "InstDate datetime," +
                        "InstAddr1 varchar(40)," +
                        "InstAddr2 varchar(40)," +
                        "InstCity varchar(20)," +
                        "InstCounty varchar(20)," +
                        "InstProvince varchar(20)," +
                        "InstState varchar(20)," +
                        "InstCountry varchar(20)," +
                        "LastChecked datetime," +
                        "LastModified datetime," +
                        "LastReplaced datetime," +
                        "LastTechId bigint," +
                        "BillingDate datetime," +
                        "LastBillingDate datetime," +
                        "Due float," +
                        "PastDue float," +
                        "LastDue float," +
                        "Something decimal," +// double and float are real
                        "IsActive bit," +
                        "IsOnline bit," +
                        "LastOffline datetime," +
                        "FailedMessages bigint," +
                        "LastActionCode varchar(4)," +
                        "LastAction varchar(40)," +
                        "NextActionCode varchar(4)," +
                        "NextTechId bigint," +
                        "CntActionsTaken int," +
                        "LastNote text" +
                        ");";

                    DB.nonquery(ref query);
                    retVal = DB.existsTable("TestTable");

                    if (retVal)
                    {
                        // TODO - TEST SECTION
                        L.l(location, "Checking indexes.");
                        if (!createTestIndexes())
                        {
                            L.err(location, "Failed to create indexes.");
                        }

                        L.l(location, "Checking procedures.");
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create procedures.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static Dictionary<string, string> getIndexes(string tableName)
            {
                const string location = CLASSNAME + ".getIndexes";
                Dictionary<string, string> retVal = new Dictionary<string, string>();
                try
                {
                    if (tableName == null || tableName.Length == 0)
                    {
                        L.err(location, "Input table name was null or empty.");
                        return retVal;
                    }

                    SQLWrapper query = new SQLWrapper();
                    query.sql = "select I.name, I.type_desc from sys.indexes I " + 
                        "inner join sys.tables T on I.object_id = T.object_id " +
                        "where T.name=@TableName and I.type > 0 " + 
                        "order by I.name;";
                    query.parms.Add("TableName", tableName);

                    if (!DB.que(ref query))
                    {
                        L.err(location, "Failed to query indexes on table (" + tableName + ").");
                    }
                    else if (query.result == null)
                    {
                        L.err(location, "Results were null.");
                    }
                    else
                    {
                        // Convert each row into a single KeyValuePair
                        int formatErr = 0;
                        for (int i = 0; i < query.result.Count; i++)
                        {
                            if (query.result[i] == null || query.result[i].Count < 2)
                            {
                                formatErr++;
                                continue;
                            }

                            string key =
                                query.result[i].ContainsKey("name") &&
                                query.result[i]["name"] != DBNull.Value ?
                                (string)query.result[i]["name"] : "";

                            string val =
                                query.result[i].ContainsKey("type_desc") &&
                                query.result[i]["type_desc"] != DBNull.Value ?
                                (string)query.result[i]["type_desc"] : "";

                            retVal.Add(key, val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }
        }

        public static class MySQL
        {
            public const string CLASSNAME = "TSQL.MySQL";

            public static bool createTestIndexes()
            {
                const string location = CLASSNAME + ".createTestIndexes";
                bool retVal = false;
                try
                {
                    Dictionary<string, string> existing = TSQL.MySQL.getIndexes("TestTable");

                    bool idIdxExists = false;
                    bool cdtIdxExists = false;
                    bool serialNumIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                        else if (kv.Key == "idx_TestTable_SerialNum") serialNumIdxExists = true;
                    }

                    int cntErr = 0;
                    if (!idIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.TestId.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE UNIQUE INDEX idx_TestTable_Id ON TestTable(TestId) " + 
                            "algorithm=inplace;select 1;";

                        long created = DB.ordinal(ref query);
                        L.l(location, "Id index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!cdtIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.CDT.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_Cdt ON TestTable (CDT) USING btree " + 
                            "algorithm=inplace;select 1;";

                        long created = DB.ordinal(ref query);
                        L.l(location, "CDT index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!serialNumIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.SerialNum.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_SerialNum ON TestTable (SerialNum);select 1;";
                        long created = DB.ordinal(ref query);
                        L.l(location, "SerialNum index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    retVal = cntErr == 0;
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static bool createTestProcedures()
            {
                const string location = CLASSNAME + ".createTestProcedures";
                bool retVal = false;
                try
                {
                    L.l(location, "Creating test procedures.");
                    long cntCreated = 0;

                    SQLWrapper getById = new SQLWrapper();
                    getById.sql =
                        @"DROP PROCEDURE IF EXISTS getTestTableById;
                        CREATE PROCEDURE getTestTableById(IN pTestId integer) 
                        begin 
                        select * from TestTable T where T.TestId=pTestId; 
                        end;";
                    cntCreated += DB.nonquery(ref getById);


                    SQLWrapper updateById = new SQLWrapper();
                    updateById.sql =
                        @"
                        DROP PROCEDURE IF EXISTS updateTestTableById;
                        CREATE PROCEDURE updateTestTableById(
                        IN pTestId integer,
                        IN pFID1 integer,
                        IN pFID2 integer,
                        IN pFID3 integer,
                        IN pLabel varchar(40),
                        IN pUnitNum varchar(40),
                        IN pSerialNum varchar(40),
                        IN pMfrId integer,
                        IN pMfrLocId integer,
                        IN pMachineId integer,
                        IN pLot integer,
                        IN pMfrDate datetime,
                        IN pInstDate datetime,
                        IN pInstAddr1 varchar(40),
                        IN pInstAddr2 varchar(40),
                        IN pInstCity varchar(20),
                        IN pInstCounty varchar(20),
                        IN pInstProvince varchar(20),
                        IN pInstState varchar(20),
                        IN pInstCountry varchar(20),
                        IN pLastChecked datetime,
                        IN pLastModified datetime,
                        IN pLastReplaced datetime,
                        IN pLastTechId integer,
                        IN pBillingDate datetime,
                        IN pLastBillingDate datetime,
                        IN pDue real,
                        IN pPastDue real,
                        IN pLastDue real,
                        IN pSomething real,
                        IN pIsActive boolean,
                        IN pIsOnline boolean,
                        IN pLastOffline datetime,
                        IN pFailedMessages integer,
                        IN pLastActionCode varchar(4),
                        IN pLastAction varchar(40),
                        IN pNextActionCode varchar(4),
                        IN pNextTechId integer,
                        IN pCntActionsTaken integer,
                        IN pLastNote text
                        )
                        begin 
                        update TestTable set 
                        
                        FID1=pFID1,
                        FID2=pFID2,
                        FID3=pFID3,
                        Label=pLabel,
                        UnitNum=pUnitNum,
                        SerialNum=pSerialNum,
                        MfrId=pMfrId,
                        MfrLocId=pMfrLocId,
                        MachineId=pMachineId,
                        Lot=pLot,
                        MfrDate=pMfrDate,
                        InstDate=pInstDate,
                        InstAddr1=pInstAddr1,
                        InstAddr2=pInstAddr2,
                        InstCity=pInstCity,
                        InstCounty=pInstCounty,
                        InstProvince=pInstProvince,
                        InstState=pInstState,
                        InstCountry=pInstCountry,
                        LastChecked=pLastChecked,
                        LastModified=pLastModified,
                        LastReplaced=pLastReplaced,
                        LastTechId=pLastTechId,
                        BillingDate=pBillingDate,
                        LastBillingDate=pLastBillingDate,
                        Due=pDue,
                        PastDue=pPastDue,
                        LastDue=pLastDue,
                        Something=pSomething,
                        IsActive=pIsActive,
                        IsOnline=pIsOnline,
                        LastOffline=pLastOffline,
                        FailedMessages=pFailedMessages,
                        LastActionCode=pLastActionCode,
                        LastAction=pLastAction,
                        NextActionCode=pNextActionCode,
                        NextTechId=pNextTechId,
                        CntActionsTaken=pCntActionsTaken,
                        LastNote=pLastNote 
                        where TestId=pTestId; 
                        end;";
                    cntCreated += DB.nonquery(ref updateById);



                    SQLWrapper getByDt = new SQLWrapper();
                    getByDt.sql =
                        @"
                        DROP PROCEDURE IF EXISTS getTestTableByDt;
                        CREATE PROCEDURE getTestTableByDt(
                        IN pDtStart datetime, IN pDtEnd datetime, IN pMaxRecords integer)
                        begin
                        select * from TestTable T 
                        where T.CDT > pDtStart and T.CDT <= pDtEnd 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;";
                    cntCreated += DB.nonquery(ref getByDt);

                    SQLWrapper getByVarchar = new SQLWrapper();
                    getByVarchar.sql =
                        @"
                        DROP PROCEDURE IF EXISTS getTestTableBySerialNum;
                        CREATE PROCEDURE getTestTableBySerialNum(
                        IN pSerialNum varchar(40), IN pMaxRecords integer) 
                        begin 
                        select * from TestTable T 
                        where T.SerialNum=pSerialNum 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;";
                    cntCreated += DB.nonquery(ref getByVarchar);


                    retVal = true;
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
                    SQLWrapper query = new SQLWrapper();
                    query.sql =
                        (!dropFirst ? "" : "DROP TABLE IF EXISTS TestTable;") +
                        "CREATE TABLE TestTable (" +
                        "TestId integer primary key auto_increment," +
                        "CDT datetime DEFAULT now()," + // integer for unix time, real for Julian
                        "FID1 integer," +
                        "FID2 integer," +
                        "FID3 integer," +
                        "Label varchar(40)," +
                        "UnitNum varchar(40)," +
                        "SerialNum varchar(40)," +
                        "MfrId integer," +
                        "MfrLocId integer," +
                        "MachineId integer," +
                        "Lot integer," +
                        "MfrDate datetime," +
                        "InstDate datetime," +
                        "InstAddr1 varchar(40)," +
                        "InstAddr2 varchar(40)," +
                        "InstCity varchar(20)," +
                        "InstCounty varchar(20)," +
                        "InstProvince varchar(20)," +
                        "InstState varchar(20)," +
                        "InstCountry varchar(20)," +
                        "LastChecked datetime," +
                        "LastModified datetime," +
                        "LastReplaced datetime," +
                        "LastTechId integer," +
                        "BillingDate datetime," +
                        "LastBillingDate datetime," +
                        "Due real," +
                        "PastDue real," +
                        "LastDue real," +
                        "Something real," +// double and float are real
                        "IsActive boolean," +
                        "IsOnline boolean," +
                        "LastOffline datetime," +
                        "FailedMessages integer," +
                        "LastActionCode varchar(4)," +
                        "LastAction varchar(40)," +
                        "NextActionCode varchar(4)," +
                        "NextTechId integer," +
                        "CntActionsTaken integer," +
                        "LastNote text" +
                        ");";

                    DB.nonquery(ref query);
                    retVal = DB.existsTable("TestTable");

                    if (retVal)
                    {
                        // TODO - TEST SECTION
                        L.l(location, "Checking indexes.");
                        if (!createTestIndexes())
                        {
                            L.err(location, "Failed to create indexes.");
                        }

                        L.l(location, "Checking procedures.");
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create procedures.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static Dictionary<string, string> getIndexes(string tableName)
            {
                const string location = CLASSNAME + ".getIndexes";
                Dictionary<string, string> retVal = new Dictionary<string, string>();
                try
                {
                    if (tableName == null || tableName.Length == 0)
                    {
                        L.err(location, "Input table name was null or empty.");
                        return retVal;
                    }

                    SQLWrapper query = new SQLWrapper();
                    query.sql = "show index from TestTable;";
                    /*query.sql = "select indexname, indexdef from pg_indexes " +
                        "where tablename=@TableName;";
                    query.parms.Add("TableName", tableName);*/

                    if (!DB.que(ref query))
                    {
                        L.err(location, "Failed to query indexes on table (" + tableName + ").");
                    }
                    else if (query.result == null)
                    {
                        L.err(location, "Results were null.");
                    }
                    else
                    {
                        // Convert each row into a single KeyValuePair
                        int formatErr = 0;
                        for (int i = 0; i < query.result.Count; i++)
                        {
                            if (query.result[i] == null || query.result[i].Count < 2)
                            {
                                formatErr++;
                                continue;
                            }

                            string key =
                                query.result[i].ContainsKey("Key_name") &&
                                query.result[i]["Key_name"] != DBNull.Value ?
                                (string)query.result[i]["Key_name"] : "";

                            string val =
                                query.result[i].ContainsKey("Column_name") &&
                                query.result[i]["Column_name"] != DBNull.Value ?
                                (string)query.result[i]["Column_name"] : "";

                            retVal.Add(key, val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }
        }

        public static class Postgre
        {
            public const string CLASSNAME = "TSQL.Postgre";

            public static bool createTestIndexes()
            {
                const string location = CLASSNAME + ".createTestIndexes";
                bool retVal = false;
                try
                {
                    Dictionary<string, string> existing = TSQL.Postgre.getIndexes("TestTable");

                    bool idIdxExists = false;
                    bool cdtIdxExists = false;
                    bool serialNumIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                        else if (kv.Key == "idx_TestTable_SerialNum") serialNumIdxExists = true;
                    }

                    int cntErr = 0;
                    if (!idIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.TestId.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE UNIQUE INDEX CONCURRENTLY idx_TestTable_Id ON TestTable(TestId);select 1::bigint;";

                        long created = DB.ordinal(ref query);
                        L.l(location, "Id index created (" + (created > 0 ? "True": "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!cdtIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.CDT.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX CONCURRENTLY idx_TestTable_Cdt ON TestTable USING btree(CDT);select 1::bigint;";

                        long created = DB.ordinal(ref query);
                        L.l(location, "CDT index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    if (!serialNumIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.SerialNum.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX CONCURRENTLY idx_TestTable_SerialNum ON TestTable (SerialNum);select 1::bigint;";
                        long created = DB.ordinal(ref query);
                        L.l(location, "SerialNum index created (" + (created > 0 ? "True" : "False") + ").");
                        if (created <= 0) cntErr++;
                    }

                    retVal = cntErr == 0;
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static bool createTestProcedures()
            {
                const string location = CLASSNAME + ".createTestProcedures";
                bool retVal = false;
                try
                {
                    L.l(location, "Creating test procedures.");
                    long cntCreated = 0;

                    SQLWrapper getById = new SQLWrapper();

                    getById.sql =
                        @"-- FUNCTION: public.gettesttablebyid(bigint)

                            DROP FUNCTION IF EXISTS public.gettesttablebyid(bigint);

                            CREATE OR REPLACE FUNCTION public.gettesttablebyid(
                                    ptestid bigint)

                            RETURNS TABLE(
                            testid bigint, 
                            cdt timestamptz, 
                            fid1 bigint, 
                            fid2 bigint, 
                            fid3 bigint, 
                            label character varying, 
                            unitnum character varying, 
                            serialnum character varying, 
                            mfrid bigint, 
                            mfrlocid integer, 
                            machineid integer, 
                            lot integer, 
                            mfrdate timestamptz, 
                            instdate timestamptz, 
                            instaddr1 character varying, 
                            instaddr2 character varying, 
                            instcity character varying, 
                            instcounty character varying, 
                            instprovince character varying, 
                            inststate character varying, 
                            instcountry character varying, 
                            lastchecked timestamptz, 
                            lastmodified timestamptz, 
                            lastreplaced timestamptz, 
                            lasttechid bigint, 
                            billingdate timestamp, 
                            lastbillingdate timestamp, 
                            due real, 
                            pastdue real, 
                            lastdue real, 
                            something double precision, 
                            isactive boolean, 
                            isonline boolean, 
                            lastoffline timestamp with time zone, 
                            failedmessages bigint, 
                            lastactioncode character varying, 
                            lastaction character varying, 
                            nextactioncode character varying, 
                            nexttechid bigint, 
                            cntactionstaken integer, 
                            lastnote text)
                            LANGUAGE 'plpgsql'

                        AS $BODY$

                        begin

                        RETURN QUERY
                        --Where clause fields must be prefixed with table name, to prevent
                        --ambiguous field name error in result.
                        select * from TestTable T where T.TestId=pTestId;
                        end;
                        $BODY$;

                        ALTER FUNCTION public.gettesttablebyid(bigint)
                            OWNER TO postgres;";

                    cntCreated = DB.nonquery(ref getById);


                    SQLWrapper updateById = new SQLWrapper();
                    /*
                        -- FUNCTION: public.updatetesttablebyid(
                            bigint, bigint, bigint, bigint, character varying, character varying, character varying, 
                            bigint, integer, integer, integer, timestamptz, timestamptz, character varying, character varying, 
                            character varying, character varying, character varying, character varying, character varying, 
                            timestamptz, timestamptz, timestamptz, bigint, timestamp, timestamp, real, real, real, 
                            double precision, boolean, boolean, timestamptz, bigint, character varying, character varying, 
                            character varying, bigint, integer, text
                        )
                     */
                    updateById.sql =
                        @"

                            DROP FUNCTION IF EXISTS public.updatetesttablebyid(
                            bigint, 
                            bigint, 
                            bigint, 
                            bigint, 
                            character varying, 
                            character varying, 
                            character varying, 
                            bigint, 
                            integer, 
                            integer, 
                            integer, 
                            timestamp with time zone, 
                            timestamp with time zone, 
                            character varying, 
                            character varying, 
                            character varying, 
                            character varying, 
                            character varying, 
                            character varying, 
                            character varying, 
                            timestamp with time zone, 
                            timestamp with time zone, 
                            timestamp with time zone, 
                            bigint, 
                            timestamp, 
                            timestamp, 
                            real, 
                            real, 
                            real, 
                            double precision, 
                            boolean, 
                            boolean, 
                            timestamp with time zone, 
                            bigint, 
                            character varying, 
                            character varying, 
                            character varying, 
                            bigint, 
                            integer, 
                            text
                            );

                            CREATE OR REPLACE FUNCTION public.updatetesttablebyid(
                                    
                            ptestid bigint, 
                            pfid1 bigint, 
                            pfid2 bigint, 
                            pfid3 bigint, 
                            plabel character varying, 
                            punitnum character varying, 
                            pserialnum character varying, 
                            pmfrid bigint, 
                            pmfrlocid integer, 
                            pmachineid integer, 
                            plot integer, 
                            pmfrdate timestamp with time zone, 
                            pinstdate timestamp with time zone, 
                            pinstaddr1 character varying, 
                            pinstaddr2 character varying, 
                            pinstcity character varying, 
                            pinstcounty character varying, 
                            pinstprovince character varying, 
                            pinststate character varying, 
                            pinstcountry character varying, 
                            plastchecked timestamp with time zone, 
                            plastmodified timestamp with time zone, 
                            plastreplaced timestamp with time zone, 
                            plasttechid bigint, 
                            pbillingdate timestamp, 
                            plastbillingdate timestamp, 
                            pdue real, 
                            ppastdue real, 
                            plastdue real, 
                            psomething double precision, 
                            pisactive boolean, 
                            pisonline boolean, 
                            plastoffline timestamp with time zone, 
                            pfailedmessages bigint, 
                            plastactioncode character varying, 
                            plastaction character varying, 
                            pnextactioncode character varying, 
                            pnexttechid bigint, 
                            pcntactionstaken integer, 
                            plastnote text
                                    )
                            RETURNS TABLE (status numeric) 
                            LANGUAGE 'plpgsql'

                        AS $$

                        begin
                        --Where clause fields must be prefixed with table name, to prevent
                        --ambiguous field name error in result.
                        update TestTable set 
                        
                            fid1=pfid1, 
                            fid2=pfid2, 
                            fid3=pfid3, 
                            label=plabel, 
                            unitnum=punitnum, 
                            serialnum=pserialnum, 
                            mfrid=pmfrid, 
                            mfrlocid=pmfrlocid, 
                            machineid=pmachineid, 
                            lot=plot, 
                            mfrdate=pmfrdate, 
                            instdate=pinstdate, 
                            instaddr1=pinstaddr1, 
                            instaddr2=pinstaddr2, 
                            instcity=pinstcity, 
                            instcounty=pinstcounty, 
                            instprovince=pinstprovince, 
                            inststate=pinststate, 
                            instcountry=pinstcountry, 
                            lastchecked=plastchecked, 
                            lastmodified=plastmodified, 
                            lastreplaced=plastreplaced, 
                            lasttechid=plasttechid, 
                            billingdate=pbillingdate, 
                            lastbillingdate=plastbillingdate, 
                            due=pdue, 
                            pastdue=ppastdue, 
                            lastdue=plastdue, 
                            something=psomething, 
                            isactive=pisactive, 
                            isonline=pisonline, 
                            lastoffline=plastoffline, 
                            failedmessages=pfailedmessages, 
                            lastactioncode=plastactioncode, 
                            lastaction=plastaction, 
                            nextactioncode=pnextactioncode, 
                            nexttechid=pnexttechid, 
                            cntactionstaken=pcntactionstaken, 
                            lastnote=plastnote 
                        where TestTable.TestId=pTestId; 
                        end;
                        $$;

                        ALTER FUNCTION public.updatetesttablebyid(
                            bigint, bigint, bigint, bigint, character varying, character varying, character varying, 
                            bigint, integer, integer, integer, timestamp with time zone, timestamp with time zone, character varying, character varying, 
                            character varying, character varying, character varying, character varying, character varying, 
                            timestamp with time zone, timestamp with time zone, timestamp with time zone, bigint, timestamp, timestamp, real, real, real, 
                            double precision, boolean, boolean, timestamp with time zone, bigint, character varying, character varying, 
                            character varying, bigint, integer, text
                        )
                        OWNER TO postgres;

                        select 1;
                        ";
                    cntCreated = DB.nonquery(ref updateById);



                    SQLWrapper getByDt = new SQLWrapper();
                    getByDt.sql =
                        @"
                        DROP FUNCTION IF EXISTS public.getTestTableByDt(
                            timestamptz, timestamptz, int);

                        CREATE OR REPLACE FUNCTION public.getTestTableByDt(
                            pDtStart timestamptz, pDtEnd timestamptz, pMaxRecords int)

                            RETURNS TABLE(
                            testid bigint, 
                            cdt timestamptz, 
                            fid1 bigint, 
                            fid2 bigint, 
                            fid3 bigint, 
                            label character varying, 
                            unitnum character varying, 
                            serialnum character varying, 
                            mfrid bigint, 
                            mfrlocid integer, 
                            machineid integer, 
                            lot integer, 
                            mfrdate timestamptz, 
                            instdate timestamptz, 
                            instaddr1 character varying, 
                            instaddr2 character varying, 
                            instcity character varying, 
                            instcounty character varying, 
                            instprovince character varying, 
                            inststate character varying, 
                            instcountry character varying, 
                            lastchecked timestamptz, 
                            lastmodified timestamptz, 
                            lastreplaced timestamptz, 
                            lasttechid bigint, 
                            billingdate timestamp, 
                            lastbillingdate timestamp, 
                            due real, 
                            pastdue real, 
                            lastdue real, 
                            something double precision, 
                            isactive boolean, 
                            isonline boolean, 
                            lastoffline timestamp with time zone, 
                            failedmessages bigint, 
                            lastactioncode character varying, 
                            lastaction character varying, 
                            nextactioncode character varying, 
                            nexttechid bigint, 
                            cntactionstaken integer, 
                            lastnote text)
                            LANGUAGE 'plpgsql'

                        AS $BODY$ 

                        begin 

                        RETURN QUERY 
                        select * from TestTable T 
                        where T.CDT > pDtStart and T.CDT <= pDtEnd 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;
                        $BODY$;

                        ALTER FUNCTION public.getTestTableByDt(timestamptz, timestamptz, integer)
                        OWNER TO postgres; 

                        select 1;
                        ";
                    cntCreated += DB.nonquery(ref getByDt);

                    SQLWrapper getByVarchar = new SQLWrapper();
                    getByVarchar.sql =
                        @"
                        DROP FUNCTION IF EXISTS public.getTestTableBySerialNum(character varying, int);

                        CREATE OR REPLACE FUNCTION public.getTestTableBySerialNum(
                        pSerialNum character varying, pMaxRecords int)

                            RETURNS TABLE(
                            testid bigint, 
                            cdt timestamptz, 
                            fid1 bigint, 
                            fid2 bigint, 
                            fid3 bigint, 
                            label character varying, 
                            unitnum character varying, 
                            serialnum character varying, 
                            mfrid bigint, 
                            mfrlocid integer, 
                            machineid integer, 
                            lot integer, 
                            mfrdate timestamptz, 
                            instdate timestamptz, 
                            instaddr1 character varying, 
                            instaddr2 character varying, 
                            instcity character varying, 
                            instcounty character varying, 
                            instprovince character varying, 
                            inststate character varying, 
                            instcountry character varying, 
                            lastchecked timestamptz, 
                            lastmodified timestamptz, 
                            lastreplaced timestamptz, 
                            lasttechid bigint, 
                            billingdate timestamp, 
                            lastbillingdate timestamp, 
                            due real, 
                            pastdue real, 
                            lastdue real, 
                            something double precision, 
                            isactive boolean, 
                            isonline boolean, 
                            lastoffline timestamp with time zone, 
                            failedmessages bigint, 
                            lastactioncode character varying, 
                            lastaction character varying, 
                            nextactioncode character varying, 
                            nexttechid bigint, 
                            cntactionstaken integer, 
                            lastnote text)
                            LANGUAGE 'plpgsql'

                        AS $BODY$

                        begin

                        RETURN QUERY
                        select * from TestTable T 
                        where T.SerialNum=pSerialNum 
                        order by T.TestId desc 
                        limit pMaxRecords;
                        end;
                        $BODY$;

                        ALTER FUNCTION public.getTestTableBySerialNum(character varying, int)
                        OWNER TO postgres;

                        select 1;
                        ";
                    cntCreated += DB.nonquery(ref getByVarchar);

                    retVal = true;
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
                    SQLWrapper query = new SQLWrapper();
                    query.sql =
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

                    DB.nonquery(ref query);
                    retVal = DB.existsTable("TestTable");

                    if (retVal)
                    {
                        // TODO - TEST SECTION
                        L.l(location, "Checking indexes.");
                        if (!createTestIndexes())
                        {
                            L.err(location, "Failed to create indexes.");
                        }

                        L.l(location, "Checking procedures.");
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create procedures.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            // TODO - Finish or remove existsIndex
            public static bool existsIndex(string tableName, string indexName)
            {
                const string location = CLASSNAME + ".existsIndex";
                bool retVal = false;
                try
                {
                    if (tableName == null || tableName.Length == 0 ||
                        indexName == null || indexName.Length == 0)
                    {
                        L.err(location, "Input table or index name was null or empty.");
                        return retVal;
                    }

                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static Dictionary<string, string> getIndexes(string tableName)
            {
                const string location = CLASSNAME + ".getIndexes";
                Dictionary<string, string> retVal = new Dictionary<string, string>();
                try
                {
                    if (tableName == null || tableName.Length == 0)
                    {
                        L.err(location, "Input table name was null or empty.");
                        return retVal;
                    }

                    SQLWrapper query = new SQLWrapper();
                    query.sql = "select indexname, indexdef from pg_indexes " +
                        "where tablename=@TableName;";
                    query.parms.Add("TableName", tableName.ToLower());

                    if (!DB.que(ref query))
                    {
                        L.err(location, "Failed to query indexes on table (" + tableName + ").");
                    }
                    else if (query.result == null)
                    {
                        L.err(location, "Results were null.");
                    }
                    else
                    {
                        L.l(location, "Iterating (" + query.result.Count + ") results.");
                        // Convert each row into a single KeyValuePair
                        int formatErr = 0;
                        for (int i = 0; i < query.result.Count; i++)
                        {
                            if (query.result[i] == null || query.result[i].Count < 2)
                            {
                                formatErr++;
                                continue;
                            }

                            string key = 
                                query.result[i].ContainsKey("indexname") &&
                                query.result[i]["indexname"] != DBNull.Value ?
                                (string)query.result[i]["indexname"] : "";

                            string val = 
                                query.result[i].ContainsKey("indexdef") &&
                                query.result[i]["indexdef"] != DBNull.Value ? 
                                (string)query.result[i]["indexdef"] : "";

                            retVal.Add(key, val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }
        }

        public static class SQLite
        {
            public const string CLASSNAME = "TSQL.SQLite";

            private static Dictionary<string, string> tempProcedures = new Dictionary<string, string>();

            public static bool createTestIndexes()
            {
                const string location = CLASSNAME + ".createTestIndexes";
                bool retVal = false;
                try
                {
                    Dictionary<string, string> existing = TSQL.SQLite.getIndexes("TestTable");

                    bool idIdxExists = false;
                    bool cdtIdxExists = false;
                    bool serialNumIdxExists = false;
                    foreach (KeyValuePair<string, string> kv in existing)
                    {
                        if (kv.Key == "idx_TestTable_Id") idIdxExists = true;
                        else if (kv.Key == "idx_TestTable_Cdt") cdtIdxExists = true;
                        else if (kv.Key == "idx_TestTable_SerialNum") serialNumIdxExists = true;
                    }

                    int cntErr = 0;
                    if (!idIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.TestId.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE UNIQUE INDEX idx_TestTable_Id ON TestTable(TestId);";

                        long created = DB.nonquery(ref query);
                        //L.l(location, "Id index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    if (!cdtIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.CDT.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_Cdt ON TestTable (CDT);";

                        long created = DB.nonquery(ref query);
                        //L.l(location, "CDT index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    if (!serialNumIdxExists)
                    {
                        L.l(location, "Creating index on TestTable.SerialNum.");
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "CREATE INDEX idx_TestTable_SerialNum ON TestTable (SerialNum);";
                        long created = DB.nonquery(ref query);
                        //L.l(location, "SerialNum index created (" + (created > 0 ? "True" : "False") + ").");
                        //if (created <= 0) cntErr++;
                    }

                    retVal = cntErr == 0;
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static bool createTestProcedures()
            {
                const string location = CLASSNAME + ".createTestProcedures";
                bool retVal = false;
                try
                {
                    L.l(location, "Creating test procedures.");

                    // SQLite does not support saved procedures,
                    // help out by holding some sql instead

                    TSQL.SQLite.tempProcedures = new Dictionary<string, string>();

                    string getById = @"select * from TestTable T where T.TestId=@TestId;";
                    TSQL.SQLite.tempProcedures.Add("getTestTableById", getById);


                    string updateById =
                        @"
                        update TestTable set
                        FID1=@FID1,
                        FID2=@FID2,
                        FID3=@FID3,
                        Label=@Label,
                        UnitNum=@UnitNum,
                        SerialNum=@SerialNum,
                        MfrId=@MfrId,
                        MfrLocId=@MfrLocId,
                        MachineId=@MachineId,
                        Lot=@Lot,
                        MfrDate=@MfrDate,
                        InstDate=@InstDate,
                        InstAddr1=@InstAddr1,
                        InstAddr2=@InstAddr2,
                        InstCity=@InstCity,
                        InstCounty=@InstCounty,
                        InstProvince=@InstProvince,
                        InstState=@InstState,
                        InstCountry=@InstCountry,
                        LastChecked=@LastChecked,
                        LastModified=@LastModified,
                        LastReplaced=@LastReplaced,
                        LastTechId=@LastTechId,
                        BillingDate=@BillingDate,
                        LastBillingDate=@LastBillingDate,
                        Due=@Due,
                        PastDue=@PastDue,
                        LastDue=@LastDue,
                        Something=@Something,
                        IsActive=@IsActive,
                        IsOnline=@IsOnline,
                        LastOffline=@LastOffline,
                        FailedMessages=@FailedMessages,
                        LastActionCode=@LastActionCode,
                        LastAction=@LastAction,
                        NextActionCode=@NextActionCode,
                        NextTechId=@NextTechId,
                        CntActionsTaken=@CntActionsTaken,
                        LastNote=@LastNote 
                        where TestId=@TestId;
                        ";
                    TSQL.SQLite.tempProcedures.Add("updateTestTableById", updateById);



                    string getByDt =
                        @"select * from TestTable T 
                        where T.CDT > @DtStart and T.CDT <= @DtEnd 
                        order by T.TestId desc 
                        limit @MaxRecords;";
                    TSQL.SQLite.tempProcedures.Add("getTestTableByDt", getByDt);

                    string getByVarchar =
                        @"select * from TestTable T 
                        where T.SerialNum=@SerialNum 
                        order by T.TestId desc 
                        limit @MaxRecords;";
                    TSQL.SQLite.tempProcedures.Add("getTestTableBySerialNum", getByVarchar);


                    retVal = true;
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
                    SQLWrapper query = new SQLWrapper();
                    query.sql =
                        (!dropFirst ? "" : "DROP TABLE IF EXISTS TestTable;") +
                        "CREATE TABLE TestTable (" +
                        "TestId integer primary key," +
                        "CDT integer DEFAULT (unixepoch() * 1000)," + // integer for unix time, real for Julian
                        //"CDT integer DEFAULT current_timestamp," + // integer for unix time, real for Julian
                        "FID1 integer," +
                        "FID2 integer," +
                        "FID3 integer," +
                        "Label varchar(40)," +
                        "UnitNum varchar(40)," +
                        "SerialNum varchar(40)," +
                        "MfrId integer," +
                        "MfrLocId integer," +
                        "MachineId integer," +
                        "Lot integer," +
                        "MfrDate integer," +
                        "InstDate integer," +
                        "InstAddr1 varchar(40)," +
                        "InstAddr2 varchar(40)," +
                        "InstCity varchar(20)," +
                        "InstCounty varchar(20)," +
                        "InstProvince varchar(20)," +
                        "InstState varchar(20)," +
                        "InstCountry varchar(20)," +
                        "LastChecked integer," +
                        "LastModified integer," +
                        "LastReplaced integer," +
                        "LastTechId integer," +
                        "BillingDate integer," +
                        "LastBillingDate integer," +
                        "Due real," +
                        "PastDue real," +
                        "LastDue real," +
                        "Something real," +// double and float are real
                        "IsActive boolean," +
                        "IsOnline boolean," +
                        "LastOffline integer," +
                        "FailedMessages integer," +
                        "LastActionCode varchar(4)," +
                        "LastAction varchar(40)," +
                        "NextActionCode varchar(4)," +
                        "NextTechId integer," +
                        "CntActionsTaken integer," +
                        "LastNote text" +
                        ");";

                    DB.nonquery(ref query);
                    retVal = DB.existsTable("TestTable");

                    if (retVal)
                    {
                        // TODO - TEST SECTION
                        L.l(location, "Checking indexes.");
                        if (!createTestIndexes())
                        {
                            L.err(location, "Failed to create indexes.");
                        }

                        L.l(location, "Checking procedures.");
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create procedures.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static Dictionary<string, string> getIndexes(string tableName)
            {
                const string location = CLASSNAME + ".getIndexes";
                Dictionary<string, string> retVal = new Dictionary<string, string>();
                try
                {
                    if (tableName == null || tableName.Length == 0)
                    {
                        L.err(location, "Input table name was null or empty.");
                        return retVal;
                    }

                    SQLWrapper query = new SQLWrapper();
                    //query.sql = "show index from TestTable;";
                    query.sql = "select name, tbl_name from sqlite_master " +
                        "where type='index' and tbl_name=@TableName;";
                    query.parms.Add("TableName", tableName);

                    if (!DB.que(ref query))
                    {
                        L.err(location, "Failed to query indexes on table (" + tableName + ").");
                    }
                    else if (query.result == null)
                    {
                        L.err(location, "Results were null.");
                    }
                    else
                    {
                        // Convert each row into a single KeyValuePair
                        int formatErr = 0;
                        for (int i = 0; i < query.result.Count; i++)
                        {
                            if (query.result[i] == null || query.result[i].Count < 2)
                            {
                                formatErr++;
                                continue;
                            }

                            string key =
                                query.result[i].ContainsKey("name") &&
                                query.result[i]["name"] != DBNull.Value ?
                                (string)query.result[i]["name"] : "";

                            string val =
                                query.result[i].ContainsKey("tbl_name") &&
                                query.result[i]["tbl_name"] != DBNull.Value ?
                                (string)query.result[i]["tbl_name"] : "";

                            retVal.Add(key, val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    L.ex(location, ex);
                }
                return retVal;
            }

            public static string getTestProcedure(string procedureName)
            {
                const string location = CLASSNAME + ".getTestProcedure";
                string retVal = "";
                try
                {
                    if (tempProcedures == null || tempProcedures.Count == 0)
                    {
                        if (!createTestProcedures())
                        {
                            L.err(location, "Failed to create test procedures.");
                            return retVal;
                        }
                    }

                    if (procedureName == null || procedureName.Length == 0) return retVal;

                    foreach (KeyValuePair<string, string> kv in tempProcedures)
                    {
                        if (procedureName == kv.Key)
                        {
                            retVal = kv.Value;
                            break;
                        }
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
}
