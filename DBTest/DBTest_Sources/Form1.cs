using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace DBTest
{
    public partial class Form1 : Form
    {
        const string CLASSNAME = "Form1";

        // Short-term connect string memory
        private Dictionary<DB.Engine, string> connectStrings = new Dictionary<DB.Engine, string>();
        private Dictionary<DB.Engine, string> dbNameStrings = new Dictionary<DB.Engine, string>();
        //DB.Engine engine = DB.Engine.UNKNOWN;

        Automation auto = null;


        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                if (!L.logInit(null, rtbLogs, false))
                {
                    L.err(location, "Failed to initialize logging.");
                }
                L.l(location, "Application starting...");

                // Add application exit handler for cleanup
                Application.ApplicationExit += OnApplicationExit;
                L.l(location, "Finished adding app exit handler.");

                if (!this.init())
                {
                    L.err(location, "Failed to finish initializing application data.");
                }

                // Initialize database
                connectDb();

                // Initialize random data for bulk inserts
                if (!TestHelpers.init())
                {
                    L.err(location, "Failed to initialize Test Helpers.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private bool init()
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                string dbName = AppConfig.Get("SelectedDB", "");
                DB.Engine engine = DB.engine(dbName);
                if (engine == DB.Engine.UNKNOWN) L.err(location, "No db engine selected.");

                connectStrings = new Dictionary<DB.Engine, string>();
                connectStrings.Add(DB.Engine.MARIADB,   AppConfig.Get("MariaConnectString", ""));
                connectStrings.Add(DB.Engine.MSSQL,     AppConfig.Get("MSSQLConnectString", ""));
                connectStrings.Add(DB.Engine.MYSQL,     AppConfig.Get("MySQLConnectString", ""));
                connectStrings.Add(DB.Engine.POSTGRE,   AppConfig.Get("PostgreConnectString", ""));
                connectStrings.Add(DB.Engine.SQLITE,    AppConfig.Get("SQLiteConnectString", ""));
                connectStrings.Add(DB.Engine.UNKNOWN, "No Engine Selected...");

                dbNameStrings = new Dictionary<DB.Engine, string>();
                dbNameStrings.Add(DB.Engine.MARIADB, AppConfig.Get("MariaDbName", ""));
                dbNameStrings.Add(DB.Engine.MSSQL, AppConfig.Get("MSSQLDbName", ""));
                dbNameStrings.Add(DB.Engine.MYSQL, AppConfig.Get("MySQLDbName", ""));
                dbNameStrings.Add(DB.Engine.POSTGRE, AppConfig.Get("PostgreDbName", ""));
                dbNameStrings.Add(DB.Engine.SQLITE, AppConfig.Get("SQLiteDbName", ""));
                dbNameStrings.Add(DB.Engine.UNKNOWN, "No Engine Selected...");

                tbDBSelectConnectString.Text = connectStrings[engine];
                switch (engine)
                {
                    case DB.Engine.MARIADB: rbDBSelectMariaDB.Checked = true;   break;
                    case DB.Engine.MSSQL:   rbDBSelectMSSQL.Checked = true;     break;
                    case DB.Engine.MYSQL:   rbDBSelectMySQL.Checked = true;     break;
                    case DB.Engine.POSTGRE: rbDBSelectPostgre.Checked = true;   break;
                    case DB.Engine.SQLITE:  rbDBSelectSQLite.Checked = true;    break;
                    default: break;
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        // Revised
        public bool connectDb()
        {
            const string location = CLASSNAME + ".connectDb";
            bool retVal = false;
            try
            {
                if (tabDBSelect.InvokeRequired)
                {
                    tabDBSelect.Invoke(new Action(() =>
                    {
                        try
                        {
                            retVal = this.connectDb();
                        }
                        catch (Exception ex)
                        {
                            L.ex(location, ex);
                        }
                    }));
                }
                else
                {
                    L.l(location, "Connecting DB.");

                    DB.Engine engine = DB.Engine.UNKNOWN;
                    if (rbDBSelectMariaDB.Checked) engine = DB.Engine.MARIADB;
                    else if (rbDBSelectMSSQL.Checked) engine = DB.Engine.MSSQL;
                    else if (rbDBSelectMySQL.Checked) engine = DB.Engine.MYSQL;
                    else if (rbDBSelectPostgre.Checked) engine = DB.Engine.POSTGRE;
                    else if (rbDBSelectSQLite.Checked) engine = DB.Engine.SQLITE;

                    string html = "<p>Connecting (" + engine + ").</p>";
                    updateWebView(html);

                    string dbName = dbNameStrings[engine];
                    if (dbName == null) dbName = "";

                    if (connectStrings[engine] != tbDBSelectConnectString.Text)
                    {
                        L.err(location, "Connect string for (" + engine + ") in memory was " +
                            "out of sync with ui.");
                        connectStrings[engine] = tbDBSelectConnectString.Text;
                    }

                    if (engine == DB.Engine.UNKNOWN)
                        L.err(location, "No db engine selected.");

                    else if (connectStrings[engine].Length == 0)
                        L.err(location, "Connect string for (" + engine + ") was null or empty.");

                    else if (!DB.initDB(engine, dbName, connectStrings[engine]))
                        L.err(location, "Failed to intialize (" + engine + ") database.");

                    else retVal = true;

                    if (retVal)
                    {
                        L.l(location, "Database initialized.");
                        html += "<p>Database initialized.</p>";
                        updateWebView(html);

                        if (lblEngineOut != null)
                        {
                            if (lblEngineOut.InvokeRequired)
                            {
                                lblEngineOut.Invoke(new Action(() => { lblEngineOut.Text = engine.ToString(); }));
                            }
                            else 
                            {
                                lblEngineOut.Text = engine.ToString();
                            }
                        }


                        // Create the table if it does not exist 
                        L.l(location, "Verifying tables exist.");
                        if (!DB.existsTable("TestTable"))
                        {
                            L.l(location, "Creating TestTable for not-existing.");
                            html += "<p>Creating TestTable for not-existing.</p>";
                            updateWebView(html);
                            if (!DB.createTestTable(false))
                            {
                                L.err(location, "Failed to create test table.");
                                html += "<p>Failed to create TestTable.</p>";
                                updateWebView(html);
                            }
                        }
                    }
                    else
                    {
                        html += "<p>Error: Failed to connect (" + engine + ").</p>";
                        html += "<p>Check logs.</p>";
                        updateWebView(html);
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public bool automate()
        {
            const string location = CLASSNAME + ".automate";
            bool retVal = false;
            try
            {
                L.l(location, "Getting parameters to automate.");

                if (this.auto != null && this.auto.isProcessing)
                {
                    L.l(location, "Attempted to automate while already automating.");
                    return retVal;
                }

                this.auto = new Automation();
                if (!auto.init(lbAutomationLogs, rtbAutomationOutput))
                    return retVal;//Early Exit

                

                bool hasErrors = false;
                try
                {
                    this.auto.isTestMariaDB = cbAutomateMariaDB.Checked;
                    this.auto.isTestMSSQL = cbAutomateMSSQL.Checked;
                    this.auto.isTestMySQL = cbAutomateMySQL.Checked;
                    this.auto.isTestPostgre = cbAutomatePostgre.Checked;
                    this.auto.isTestSQLite = cbAutomateSQLite.Checked;

                    this.auto.reqInsert1K = Convert.ToInt32(numInsert1K.Value);
                    this.auto.reqInsert10K = Convert.ToInt32(numInsert10K.Value);
                    this.auto.reqInsert100K = Convert.ToInt32(numInsert100K.Value);
                    this.auto.reqInsert1M = Convert.ToInt32(numInsert1M.Value);
                    this.auto.reqInsert10M = Convert.ToInt32(numInsert10M.Value);

                    this.auto.reqSelectId1S = Convert.ToInt32(numSelect1S.Value);
                    this.auto.reqSelectId100S = Convert.ToInt32(numSelect100S.Value);
                    this.auto.reqSelectId1KS = Convert.ToInt32(numSelect1KS.Value);
                    this.auto.reqSelectId10KS = Convert.ToInt32(numSelect10KS.Value);
                    this.auto.reqSelectId25KS = Convert.ToInt32(numSelect25KS.Value);

                    this.auto.reqSelectId1NS = Convert.ToInt32(numSelect1NS.Value);
                    this.auto.reqSelectId100NS = Convert.ToInt32(numSelect100NS.Value);
                    this.auto.reqSelectId1KNS = Convert.ToInt32(numSelect1KNS.Value);
                    this.auto.reqSelectId10KNS = Convert.ToInt32(numSelect10KNS.Value);
                    this.auto.reqSelectId25KNS = Convert.ToInt32(numSelect25KNS.Value);

                    this.auto.reqSelectSerial1 = Convert.ToInt32(numSelectVarchar1.Value);
                    this.auto.reqSelectSerial100 = Convert.ToInt32(numSelectVarchar100.Value);
                    this.auto.reqSelectSerial1K = Convert.ToInt32(numSelectVarchar1K.Value);
                    this.auto.reqSelectSerial10K = Convert.ToInt32(numSelectVarchar10K.Value);
                    this.auto.reqSelectSerial25K = Convert.ToInt32(numSelectVarchar25K.Value);

                    this.auto.reqSelectDateRange = Convert.ToInt32(numSelectDateRange.Value);

                    this.auto.reqUpdate1 = Convert.ToInt32(numUpdate1.Value);
                    this.auto.reqUpdate100 = Convert.ToInt32(numUpdate100.Value);
                    this.auto.reqUpdate1K = Convert.ToInt32(numUpdate1K.Value);
                    this.auto.reqUpdate10K = Convert.ToInt32(numUpdate10K.Value);
                }
                catch (Exception exUi)
                {
                    hasErrors = true;
                }

                if (hasErrors)
                {
                    L.err(location, "One or more automation values was out-of-range (0-" + Int32.MaxValue + ").");
                    return retVal;
                }

                if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                Task task = new Task(new Action(() => 
                {
                    try
                    {
                        L.l(location, "Automation started.");
                        if (!this.auto.process())
                        {
                            L.err(location, "Automation process failed before completing.");
                        }
                        if (!enableUi(true)) L.err(location, "Failed to enable ui.");
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask);
                    }
                }));
                task.Start();

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
                try
                {
                    if (!enableUi(true)) L.err(location, "Failed to enable ui on error.");
                }
                catch (Exception exUi)
                {
                    L.err(location, "Error enabling ui: " + exUi);
                }
            }
            return retVal;
        }

        public bool dropRecreateTable()
        {
            const string location = CLASSNAME + ".dropRecreateTable";
            bool retVal = false;
            try
            {
                if (!enableUi(false)) L.l(location, "Failed to disable ui before drop create.");
                Task task = new Task(new Action(() => 
                { 
                    try
                    {
                        int cntRowsStart = DB.countTable("testtable");
                        L.l(location, "Rows before clearing (" + cntRowsStart + ").");

                        DateTime dtStart = DateTime.Now;
                        if (!DB.createTestTable(true))
                        {
                            L.err(location, "Failed to drop and recreate test table.");
                        }
                        else 
                        {
                            L.l(location, "Finished recreating test table.");
                        }
                        L.l(location, "Cleared table in (" + (DateTime.Now - dtStart).TotalMilliseconds + "ms).");

                        int cntRows = DB.countTable("TestTable");
                        L.l(location, "Test table rows (" + cntRows + ").");

                        if (!enableUi(true)) L.l(location, "Failed to enable ui after drop create.");
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                        try
                        {
                            if (!enableUi(true)) L.l(location, "Failed to enable ui after error.");
                        }
                        catch (Exception exUi) 
                        {
                            L.err(location, "Failed to enable ui on error with message: " + exUi.Message);
                        }
                    }
                }));
                task.Start();

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool dynamicSQL()
        {
            const string location = CLASSNAME + ".dynamicSQL";
            bool retVal = false;
            try
            {
                SQLWrapper query = new SQLWrapper();

                if (rtbMainQuery.InvokeRequired)
                {
                    rtbMainQuery.Invoke(new Action(() => { retVal = dynamicSQL(); }));
                }
                else
                {
                    query.sql = rtbMainQuery.Text;
                }

                if (query.sql.Length > 0)
                {
                    if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                    L.l(location, "Query string: " + query.sql);
                    Task task = new Task(new Action(() =>
                    {
                        try
                        {
                            string page = "";
                            if (!DB.dynamicSQL(ref query))
                            {
                                L.err(location, "Query failed: " + query.sql);
                                page = "Error: Query failed - " + query.sql;
                            }
                            else
                            {
                                L.l(location, "Rows returned (" + query.result.Count + ").");

                                page = TestHelpers.ResultToHtml(ref query);
                                if (page == null || page.Length == 0)
                                {
                                    L.err(location, "Received html that was null or empty.");
                                    page = "Error: Received html that was null or empty.";
                                }
                            }
                            if (!updateWebView(page))
                            {
                                L.err(location, "Failed to update ui with html.");
                            }
                            if (!enableUi(true)) L.err(location, "Failed to enable ui.");
                        }
                        catch (Exception exTask)
                        {
                            L.err(location, "Task Error: " + exTask.Message);
                            try
                            {
                                if (!enableUi(true)) L.err(location, "Failed to enable ui on error.");
                            }
                            catch (Exception exUi)
                            {
                                L.err(location, "Error enabling ui: " + exUi);
                            }
                        }
                    }));
                    task.Start();

                    // Flag Result
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool getTableIndexes()
        {
            const string location = CLASSNAME + ".getTableIndexes";
            bool retVal = false;
            try
            {
                L.l(location, "Getting indexes for test table.");

                if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                Task task = new Task(new Action(() => 
                { 
                    try
                    {
                        string tableName = "TestTable";

                        Dictionary<string, string> indexes = DB.getIndexes(tableName);

                        StringBuilder sb = new StringBuilder();
                        foreach (KeyValuePair<string, string> kv in indexes)
                        {
                            sb.Append("<tr>");
                            sb.Append("<td>" + kv.Key + "</td>");
                            sb.Append("<td>" + (kv.Value == null ? "" : kv.Value) + "</td>");
                            sb.Append("</tr>");
                        }

                        string pageHtml =
                            "<p>Table: " + tableName + "</p>" +
                            "<p>Indexes: " + indexes.Count + "</p>" +
                            "<table>" +
                            "<tr><th>Index Name</th><th>Data</th></tr>" + // 2nd column varies
                            sb.ToString() +
                            "</table>";

                        if (!enableUi(true)) L.err(location, "Failed to enable ui.");
                        if (!updateWebView(pageHtml))
                        {
                            L.err(location, "Failed to update ui with result.");
                        }
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                        try
                        {
                            if (!enableUi(true)) L.err(location, "Failed to enable ui on error.");
                        }
                        catch (Exception exUi)
                        {
                            L.err(location, "Error enabling ui: " + exUi);
                        }
                    }
                }));
                task.Start();

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public void modelInsert()
        {
            const string location = CLASSNAME + ".modelInsert";
            try
            {
                if (tbInsertQty == null)
                {
                    L.err(location, "UI element was null.");
                    return;
                }
                int rows = -1;
                try
                {
                    rows = Convert.ToInt32(tbInsertQty.Text);
                }
                catch (Exception exConv) { }
                if (rows < 0)
                {
                    L.err(location, "Insert quantity must be a number > 0.");
                    return;
                }
                if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        DateTime dtStart = DateTime.Now;

                        // This wrapper will not contain sql or results (bulk). It exists
                        // to track actual insert times over the span of iterations.
                        SQLWrapper query = new SQLWrapper();


                        int cntInserts = 0;
                        int cntrLog = 0;
                        double ttlMs = 0d;
                        for (int i = 0; i < rows;)
                        {
                            // Create a set of 1000 random rows at a time
                            //List<TestTable> modelRows = new List<TestTable>();
                            List<SQLWrapper> modelRows = new List<SQLWrapper>();
                            for (int j = 0; j < 1000 && i < rows; j++, i++, cntrLog++)
                            {
                                //modelRows.Add(TestHelpers.ModelRow());
                                SQLWrapper row = new SQLWrapper();
                                row.tableName = "TestTable";// TODO - SOFT DEFINE
                                row.parms = TestHelpers.ModelRow().toInsertParms();
                                modelRows.Add(row);
                            }

                            // Insert set, uses transaction with prepared statement (no sp/function)
                            if (modelRows.Count == 0)
                            {
                                L.err(location, "Failed to package data set for db.");
                            }
                            else
                            {
                                if (!DB.insert(ref modelRows))
                                {
                                    L.err(location, "Failed to insert data set into db.");
                                }
                                else
                                {
                                    cntInserts += modelRows.Count;
                                }
                                for (int idxRow = 0; idxRow < modelRows.Count; idxRow++)
                                {
                                    if (modelRows[idxRow] == null) continue;
                                    ttlMs += modelRows[idxRow].queryMS;
                                }
                            }
                            if (cntrLog >= 100000)
                            {
                                cntrLog = 0;
                                L.l(location, "Inserted record (" + i + ") of (" + rows + ").");
                            }
                        }
                        if (!enableUi(true)) L.err(location, "Failed to enable ui.");

                        // Log db time
                        L.l(location, "Inserted (" + cntInserts + ") of (" + rows +
                            ") rows out of (" + ttlMs + ").");

                        // Log total time
                        DateTime dtEnd = DateTime.Now;
                        L.l(location, "Finished modeling (" + rows + ") rows in (" +
                            (dtEnd - dtStart).TotalMilliseconds.ToString() + ") ms.");


                        string msgOut = "<p>Inserted (" + cntInserts + ") of (" + rows + ").</p>" + 
                        "In: " + ttlMs + "ms</p>.";
                        if (!updateWebView(msgOut))
                        {
                            L.err(location, "Failed to update ui.");
                        }

                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                        try
                        {
                            if (!enableUi(true)) L.err(location, "Failed to enable ui on error.");
                        }
                        catch (Exception exUi)
                        {
                            L.err(location, "Error enabling ui: " + exUi);
                        }
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public bool modelSelect()
        {
            const string location = CLASSNAME + ".modelSelect";
            bool retVal = false;
            try
            {
                int minSelectId = -1;
                int maxSelectId = -1;
                int selectQty = -1;
                bool useDbFunction = true;

                bool selectId = false;
                bool selectVarchar = false;
                bool selectDate = false;

                // Due to deletes, there is no way to know where data starts. Accept 
                // start and stop ids, knowing deletes may have occured between.
                try
                {
                    minSelectId = Convert.ToInt32(tbMinSelectId.Text);
                    maxSelectId = Convert.ToInt32(tbMaxSelectId.Text);
                    selectQty = Convert.ToInt32(tbSelectQty.Text);
                    useDbFunction = cbUseDbFunction.Checked;

                    selectId = rbSelectByTestId.Checked;
                    selectVarchar = rbSelectBySerialNum.Checked;
                    selectDate = rbSelectByDateRange.Checked;


                }
                catch (Exception exConv) { }

                if (!selectDate)
                {
                    if (minSelectId < 0 || maxSelectId < 0 || selectQty < 0)
                    {
                        L.err(location, "Max Id and select quantity must be numbers > 0.");
                        return retVal;
                    }
                    if (minSelectId > maxSelectId)
                    {
                        L.err(location, "Min id must be less than max.");
                        return retVal;
                    }
                }
                if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        // Get the current engine for logging purposes
                        DB.Engine engine = DB.engine();

                        // This wrapper will not contain sql or results (bulk). It exists
                        // to track actual insert times over the span of iterations.
                        SQLWrapper query = new SQLWrapper();
                        query.isDbFunction = true;

                        bool success = false;
                        string selectType = "";
                        if (selectId)
                        {
                            success = TestHelpers.ModelSelect(ref query, selectQty, minSelectId, maxSelectId);
                            selectType = "Id";
                        }
                        else if (selectVarchar)
                        {
                            success = TestHelpers.ModelSelectVarchar(ref query, selectQty, minSelectId, maxSelectId);
                            selectType = "Varchar";
                        }
                        else if (selectDate)
                        {
                            success = TestHelpers.ModelSelectDateRange(ref query, selectQty, DateTime.Now.AddDays(-7), DateTime.Now);
                            selectType = "Date";
                        }


                        string page = "";
                        if (!success)
                        {
                            string errMsg = "Failed to select model data for (Select by " + selectType + ").";
                            L.err(location, errMsg);
                            page = "Error:  " + errMsg + ".";
                        }
                        else if (query.result == null)
                        {
                            string errMsg = "Failed to select rows for (Select by " + selectType + ").";
                            L.err(location, errMsg);
                            page = "Error:  " + errMsg + ".";
                        }
                        else
                        {
                            // Build a simple html page from results

                            StringBuilder sb = new StringBuilder();
                            sb.Append(
                                "<br />" +
                                "<p>Engine: " + engine + "</p>" +
                                "<p>Select By: " + selectType + "</p>" +
                                "<p>Result Rows: " + query.result.Count +
                                (query.result.Count <= 1000 ? "" : "&nbsp;&nbsp;-&nbsp;&nbsp;Showing first 1000 rows.") + "</p>" +
                                "<p>Time ms: " + query.queryMS + "</p>" +
                                "<br />"
                            );
                            sb.Append("<table>");
                            if (query.result.Count > 0 && query.result[0] != null)
                            {
                                sb.Append((new TestTable(query.result[0])).toThTr());
                            }
                            for (int i = 0; i < query.result.Count; i++)
                            {
                                if (query.result[i] == null) continue;
                                sb.Append((new TestTable(query.result[i])).toTr());
                            }
                            sb.Append("</table>");

                            sb.Length = 0;
                            sb = null;

                            L.l(location, "Rows returned (" + query.result.Count + ").");
                            page = TestHelpers.ResultToHtml(ref query);
                        }

                        if (page == null || page.Length == 0)
                        {
                            L.err(location, "Received html that was null or empty.");
                            page = "Error: Received html that was null or empty.";
                        }

                        if (!updateWebView(page))
                        {
                            L.err(location, "Failed pushing result to view.");
                        }

                        L.l(location, "Finished selecting rows.");
                        if (!enableUi(true)) L.err(location, "Failed to enable ui.");
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                        try
                        {
                            if (!enableUi(true)) L.err(location, "Failed to enable ui on error.");
                        }
                        catch (Exception exUi)
                        {
                            L.err(location, "Error enabling ui: " + exUi);
                        }
                    }
                }));
                task.Start();

                // Output Result
                retVal = true;
                
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        public bool enableUi(bool isEnabled)
        {
            const string location = CLASSNAME + ".enableUi";
            bool retVal = false;
            try
            {
                if (tabMain.InvokeRequired)
                {
                    tabMain.Invoke(new Action(() => { retVal = enableUi(isEnabled); }));
                }
                else
                {
                    // Main Tab

                    // Main Options
                    if (btnMainInsertModel != null) btnMainInsertModel.Enabled = isEnabled;
                    if (btnMainSelect != null) btnMainSelect.Enabled = isEnabled;
                    if (tbInsertQty != null) tbInsertQty.Enabled = isEnabled;
                    if (tbMinSelectId != null) tbMinSelectId.Enabled = isEnabled;
                    if (tbMaxSelectId != null) tbMaxSelectId.Enabled = isEnabled;
                    if (tbSelectQty != null) tbSelectQty.Enabled = isEnabled;
                    if (cbUseDbFunction != null) cbUseDbFunction.Enabled = isEnabled;
                    if (rbSelectByTestId != null) rbSelectByTestId.Enabled = isEnabled;
                    if (rbSelectBySerialNum != null) rbSelectBySerialNum.Enabled = isEnabled;
                    if (rbSelectByDateRange != null) rbSelectByDateRange.Enabled = isEnabled;
                    if (btnDropRecreate != null) btnDropRecreate.Enabled = isEnabled;

                    // Query Tab
                    if (rtbMainQuery != null) rtbMainQuery.Enabled = isEnabled;
                    if (btnDynamicQuery != null) btnDynamicQuery.Enabled = isEnabled;

                    // DB Select Tab
                    if (rbDBSelectMariaDB != null) rbDBSelectMariaDB.Enabled = isEnabled;
                    if (rbDBSelectMSSQL != null) rbDBSelectMSSQL.Enabled = isEnabled;
                    if (rbDBSelectMySQL != null) rbDBSelectMySQL.Enabled = isEnabled;
                    if (rbDBSelectPostgre != null) rbDBSelectPostgre.Enabled = isEnabled;
                    if (rbDBSelectSQLite != null) rbDBSelectSQLite.Enabled = isEnabled;
                    if (tbDBSelectConnectString != null) tbDBSelectConnectString.Enabled = isEnabled;
                    if (btnDBSelectConnect != null) btnDBSelectConnect.Enabled = isEnabled;
                    if (btnDBSelectRestoreCurrent != null) btnDBSelectRestoreCurrent.Enabled = isEnabled;
                    if (btnSaveConnectionString != null) btnSaveConnectionString.Enabled = isEnabled;

                    // Additional Tests Tab
                    if (btnInsertSingle != null) btnInsertSingle.Enabled = isEnabled;
                    if (btnCountTable != null) btnCountTable.Enabled = isEnabled;
                    if (btnNonQuery != null) btnNonQuery.Enabled = isEnabled;
                    if (btnOrdinal != null) btnOrdinal.Enabled = isEnabled;
                    if (btnGetIndexes != null) btnGetIndexes.Enabled = isEnabled;



                    // TODO - Go back to toggling ui elements individually. Pause button not 
                    // enabling if parent container is disabled.

                    // Automation Tab

                    // Automation Options
                    //if (pnlAutomationOptions != null) pnlAutomationOptions.Enabled = isEnabled;
                    if (btnStartAutomation != null) btnStartAutomation.Enabled = isEnabled;
                    if (btnPauseAutomation != null) btnPauseAutomation.Enabled = true;// leave the pause and stop buttons alone
                    if (btnStopAutomation != null) btnStopAutomation.Enabled = true;
                    if (cbAutomateMariaDB != null) cbAutomateMariaDB.Enabled = isEnabled;
                    if (cbAutomateMSSQL != null) cbAutomateMSSQL.Enabled = isEnabled;
                    if (cbAutomateMySQL != null) cbAutomateMySQL.Enabled = isEnabled;
                    if (cbAutomatePostgre != null) cbAutomatePostgre.Enabled = isEnabled;
                    if (cbAutomateSQLite != null) cbAutomateSQLite.Enabled = isEnabled;
                    if (btnAutomateDBAll != null) btnAutomateDBAll.Enabled = isEnabled;

                    if (numInsert1K != null) numInsert1K.Enabled = isEnabled;
                    if (numInsert10K != null) numInsert10K.Enabled = isEnabled;
                    if (numInsert100K != null) numInsert100K.Enabled = isEnabled;
                    if (numInsert1M != null) numInsert1M.Enabled = isEnabled;
                    if (numInsert10M != null) numInsert10M.Enabled = isEnabled;

                    // Sequential select is not yet implemented
                    //if (numSelect1S != null) numSelect1S.Enabled = isEnabled;//KS
                    //if (numSelect1KS != null) numSelect1KS.Enabled = isEnabled;
                    //if (numSelect100S != null) numSelect100S.Enabled = isEnabled;//KS
                    //if (numSelect10KS != null) numSelect10KS.Enabled = isEnabled;
                    //if (numSelect25KS != null) numSelect25KS.Enabled = isEnabled;

                    if (numSelect1KNS != null) numSelect1KNS.Enabled = isEnabled;
                    if (numSelect10KNS != null) numSelect10KNS.Enabled = isEnabled;
                    if (numSelect100NS != null) numSelect100NS.Enabled = isEnabled;//KS
                    if (numSelect10KNS != null) numSelect10KNS.Enabled = isEnabled;
                    if (numSelect25KNS != null) numSelect25KNS.Enabled = isEnabled;
                    
                    if (numSelectVarchar1 != null) numSelectVarchar1.Enabled = isEnabled;
                    if (numSelectVarchar100 != null) numSelectVarchar100.Enabled = isEnabled;
                    if (numSelectVarchar1K != null) numSelectVarchar1K.Enabled = isEnabled;//KS
                    if (numSelectVarchar10K != null) numSelectVarchar10K.Enabled = isEnabled;
                    if (numSelectVarchar25K != null) numSelectVarchar25K.Enabled = isEnabled;

                    if (numSelectDateRange != null) numSelectDateRange.Enabled = isEnabled;

                    if (numUpdate1 != null) numUpdate1.Enabled = isEnabled;
                    if (numUpdate100 != null) numUpdate100.Enabled = isEnabled;
                    if (numUpdate1K != null) numUpdate1K.Enabled = isEnabled;
                    if (numUpdate10K != null) numUpdate10K.Enabled = isEnabled;


                    // Automation Log Options
                    //if (splitContainer7.Panel1 != null) splitContainer7.Panel1.Enabled = isEnabled;


                    // Output Result
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool updateWebView(string page)
        {
            const string location = CLASSNAME + ".updateWebView";
            bool retVal = false;
            try
            {
                if (page == null)
                {
                    L.err(location, "Input page was null.");
                    return retVal;
                }

                if (webMainHtml.InvokeRequired)
                {
                    webMainHtml.Invoke(new Action(() => { retVal = updateWebView(page); }));
                }
                else
                {
                    webMainHtml.DocumentText = page;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnClearLogs_Click";
            try
            {
                L.l(location, "Clearing logs.");
                long length = L.clearLogs();
                L.l(location, "Cleared (" + length + ") log length.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnDBSelectRestoreCurrent_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnDBSelectRestoreCurrent_Click";
            try
            {
                DB.Engine engine = DB.Engine.UNKNOWN;
                if (rbDBSelectMariaDB.Checked) engine = DB.Engine.MARIADB;
                else if (rbDBSelectMSSQL.Checked) engine = DB.Engine.MSSQL;
                else if (rbDBSelectMySQL.Checked) engine = DB.Engine.MSSQL;
                else if (rbDBSelectPostgre.Checked) engine = DB.Engine.POSTGRE;
                else if (rbDBSelectSQLite.Checked) engine = DB.Engine.SQLITE;
                else engine = DB.Engine.UNKNOWN;

                L.l(location, "Restoring the (" + engine + ") connect string from saved.");
                string stored = "";
                switch (engine)
                {
                    case DB.Engine.MARIADB:
                        stored = AppConfig.Get("MariaConnectString", "");
                        break;
                    case DB.Engine.MSSQL:
                        stored = AppConfig.Get("MSSQLConnectString", "");
                        break;
                    case DB.Engine.MYSQL:
                        stored = AppConfig.Get("MySQLConnectString", "");
                        break;
                    case DB.Engine.POSTGRE:
                        stored = AppConfig.Get("PostgreConnectString", "");
                        break;
                    case DB.Engine.SQLITE:
                        stored = AppConfig.Get("SQLiteConnectString", "");
                        break;
                    default:
                        L.err(location, "Unknown engine (" + engine + ").");
                        break;
                }

                tbDBSelectConnectString.Text = stored;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnDynamicQuery_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnDynamicQuery_Click";
            try
            {
                L.l(location, "Starting dynamic query.");
                if (!dynamicSQL())
                {
                    L.err(location, "Failed to perform dynamic query.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnDropRecreate_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnDropRecreate";
            try
            {
                L.l(location, "Preparing to drop and recreate table.");
                if (!dropRecreateTable())
                {
                    L.err(location, "Failed to start drop and recreate.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnMainQuery_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnMainQuery";
            try
            {
                L.l(location, "Preparing to model data.");
                modelInsert();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnMainSelect_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnMainSelect_Click";
            try
            {
                L.l(location, "Selecting rows from button click.");
                if (!modelSelect())
                {
                    L.err(location, "Failed to select model data.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".exitToolStripMenuItem_Click";
            try
            {
                L.l(location, "Application exiting from menu item.");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void rbDbSelect_CheckedChanged(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".rbDbSelect_Click";
            try
            {
                DB.Engine engine = DB.Engine.UNKNOWN;
                if (rbDBSelectMariaDB.Checked) engine = DB.Engine.MARIADB;
                else if (rbDBSelectMSSQL.Checked) engine = DB.Engine.MSSQL;
                else if (rbDBSelectMySQL.Checked) engine = DB.Engine.MYSQL;
                else if (rbDBSelectPostgre.Checked) engine = DB.Engine.POSTGRE;
                else if (rbDBSelectSQLite.Checked) engine = DB.Engine.SQLITE;
                else engine = DB.Engine.UNKNOWN;

                L.l(location, "Selecting (" + engine + ") database engine from ui.");
                tbDBSelectConnectString.Text = connectStrings[engine];
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".OnApplicationExit";
            try
            {
                // Unload handler before anything can go wrong
                Application.ApplicationExit -= OnApplicationExit;

                L.l(location, "Cleaning up resources.");
                if (!DB.dispose())
                {
                    L.err(location, "Failed to dispose of database.");
                }
                else 
                {
                    L.l(location, "Database connection disposed.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void tbDBSelectConnectString_Leave(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".tbDBSelectConnectString_Leave";
            try
            {
                if (tbDBSelectConnectString.Text.Length > 0)
                {
                    DB.Engine engine = DB.Engine.UNKNOWN;
                    if (rbDBSelectMariaDB.Checked) engine = DB.Engine.MARIADB;
                    else if (rbDBSelectMSSQL.Checked) engine = DB.Engine.MSSQL;
                    else if (rbDBSelectMySQL.Checked) engine = DB.Engine.MYSQL;
                    else if (rbDBSelectPostgre.Checked) engine = DB.Engine.POSTGRE;
                    else if (rbDBSelectSQLite.Checked) engine = DB.Engine.SQLITE;
                    else engine = DB.Engine.UNKNOWN;

                    connectStrings[engine] = tbDBSelectConnectString.Text;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnDBSelectConnect_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnDBSelectConnect_Click";
            try
            {
                L.l(location, "Preparing to connect from button click.");
                if (!connectDb()) L.err(location, "Failed to connect db.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnOrdinalTest_Click_Sample(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnOrdinalTest_Click";
            try
            {
                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        L.l(location, "Starting ordinal test.");
                        long id = 4;// An id to lookup
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "SELECT TestId from TestTable where TestId=@TestId;";
                        query.parms.Add("TestId", id);

                        long dbId = DB.ordinal(ref query);
                        L.l(location, "Id returned (" + dbId + "), id requested (" + id + ").");
                    }
                    catch (Exception ex)
                    {
                        L.ex(location, ex);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnNonQuery_Click_Sample(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnNonQuery_Click";
            try
            {
                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        L.l(location, "Testing non-query.");
                        long id = 4;// Id to edit

                        SQLWrapper query = new SQLWrapper();
                        query.sql = "UPDATE TestTable SET Label='Success' where TestId=@TestId;";
                        query.parms.Add("TestId", id);

                        int cntRows = DB.nonquery(ref query);

                        L.l(location, "Rows affected by non-query (" + cntRows + ").");
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnInsertSingle_Click_Sample(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnInsertSingle_Click";
            try
            {
                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        TestTable row = TestHelpers.ModelRow();

                        SQLWrapper query = new SQLWrapper();
                        query.tableName = "TestTable";
                        query.parms = row.toInsertParms();

                        if (!DB.insert(ref query))
                        {
                            L.err(location, "Failed to insert single row.");
                        }
                        else
                        {
                            L.l(location, "Successfully inserted row.");
                        }
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnInsertSingle_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnInsertSingle_Click";
            try
            {
                L.l(location, "Preparing to insert single from button click.");

                Task task = new Task(new Action(() => 
                { 
                    try
                    {
                        TestTable row = TestHelpers.ModelRow();
                        SQLWrapper query = new SQLWrapper();
                        query.tableName = "TestTable";
                        query.parms = row.toInsertParms();

                        string msgOut = "";
                        if (!DB.insert(ref query))
                        {
                            msgOut = "<p>Error: Failed to insert single record</p>" + 
                                "<p>In: " + query.queryMS + "ms</p>";
                            L.err(location, "Failed to insert single record.");
                        }
                        else
                        {
                            msgOut = "<p>Inserted single record</p>" + 
                                "<p>In: " + query.queryMS + "ms";
                            L.l(location, "Inserted single record.");
                        }

                        if (!updateWebView(msgOut))
                        {
                            L.err(location, "Failed to update ui.");
                        }
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnCountTable_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnCountTable_Click";
            try
            {
                L.l(location, "Preparing to count table from button click.");

                string tableName = "TestTable";

                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        
                        long count = DB.countTable(tableName);
                        L.l(location, "Table (" + tableName + "), rows (" + count + ").");


                        string msgOut = "<p>Table Name: " + tableName + "</p>" +
                        "<p>Row Count: " + count + "</p>";
                        if (!updateWebView(msgOut))
                        {
                            L.err(location, "Failed to update ui.");
                        }
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnNonQuery_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnNonQuery_Click";
            try
            {
                L.l(location, "Preparing to nonquery from button click.");

                Task task = new Task(new Action(() => 
                { 
                    try
                    {
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "update TestTable set FID1=2 where TestId < 11;";

                        int rowCount = DB.nonquery(ref query);
                        L.l(location, "Updated (" + rowCount + ") rows with nonquery.");

                        string msgOut = "<p>Affected Rows: " + rowCount + "</p>" +
                        "<p>In: " + query.queryMS + "ms</p>";
                        if (!updateWebView(msgOut))
                        {
                            L.err(location, "Failed to update ui.");
                        }
                    }
                    catch (Exception ex)
                    {
                        L.ex(location, ex);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnOrdinal_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnOrdinal_Click";
            try
            {
                L.l(location, "Preparing to get ordinal from button click.");

                Task task = new Task(new Action(() =>
                {
                    try
                    {
                        SQLWrapper query = new SQLWrapper();
                        query.sql = "select count(*) from TestTable;";//can be zero

                        long value = DB.ordinal(ref query);

                        L.l(location, "Selected ordinal (" + value + ").");

                        string msgOut = "<p>Selected ordinal: " + value + "</p>" +
                        "<p>In: " + query.queryMS + "ms</p>";
                        if (!updateWebView(msgOut))
                        {
                            L.err(location, "Failed to update ui.");
                        }
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
                    }
                }));
                task.Start();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnSaveConnectionString_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnSaveConnectionString_Click";
            try
            {
                L.l(location, "Saving connection string from button click.");

                string storedKey = "";
                DB.Engine engine = DB.Engine.UNKNOWN;

                if (rbDBSelectMariaDB.Checked)
                {
                    engine = DB.Engine.MARIADB;
                    storedKey = "MariaConnectString";
                }
                else if (rbDBSelectMSSQL.Checked)
                {
                    engine = DB.Engine.MSSQL;
                    storedKey = "MSSQLConnectString";
                }
                else if (rbDBSelectMySQL.Checked)
                {
                    engine = DB.Engine.MYSQL;
                    storedKey = "MySQLConnectString";
                }
                else if (rbDBSelectPostgre.Checked)
                {
                    engine = DB.Engine.POSTGRE;
                    storedKey = "PostgreConnectString";
                }
                else if (rbDBSelectSQLite.Checked)
                {
                    engine = DB.Engine.SQLITE;
                    storedKey = "SQLiteConnectString";
                }
                else engine = DB.Engine.UNKNOWN;

                if (engine != DB.Engine.UNKNOWN)
                {
                    connectStrings[engine] = tbDBSelectConnectString.Text;

                    if (!AppConfig.Set(storedKey, connectStrings[engine]))
                    {
                        string errMsg = "Failed to update (" + engine.ToString() + ") at (" + storedKey +
                            ") with connect string (" + tbDBSelectConnectString.Text + ").";
                        L.err(location, errMsg);
                        MessageBox.Show(errMsg, "Error");
                    }
                    else 
                    {
                        MessageBox.Show("Saved engine (" + engine.ToString() + ") with connect string.", "Success");
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetIndexes_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetIndexes_Click";
            try
            {
                L.l(location, "Getting indexes from button click.");
                if (!getTableIndexes())
                {
                    L.err(location, "Failed to start getting table indexes.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnStartAutomation_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnStartAutomation_Click";
            try
            {
                if (!automate())
                {
                    L.err(location, "Failed to launch automated testing.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnPauseAutomation_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnPauseAutomation_Click";
            try
            {
                string action = btnPauseAutomation.Text.ToLower();
                if (action == "pause")
                {
                    string msg = "Attempting to pause automated tests. This may take a short time to complete due to open transactions.";
                    L.l(location, msg);
                    MessageBox.Show(msg, "Wait while workload pauses...");
                    if (this.auto == null)
                    {
                        L.l(location, "Attempted to pause before automation.");
                    }
                    else if (!this.auto.pause())
                    {
                        L.err(location, "Failed to pause automation.");
                    }
                    else
                    {
                        L.l(location, "Paused automated tests.");
                        btnPauseAutomation.Text = "Resume";
                    }
                }
                else if (action == "resume")
                {
                    L.l(location, "Attempting to resume automated tests.");
                    if (this.auto == null)
                    {
                        L.l(location, "Attempted to resume before automation.");
                    }
                    else if (!this.auto.resume())
                    {
                        L.err(location, "Failed to resume automation.");
                    }
                    else
                    {
                        L.l(location, "Resumed automated tests.");
                        btnPauseAutomation.Text = "Pause";
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnStopAutomation_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnStopAutomation_Click";
            try
            {
                string msg = "Attempting to stop automated tests. This may take a short time to complete due to open transactions.";
                L.l(location, msg);
                MessageBox.Show(msg, "Wait while workload stops...");
                if (this.auto == null)
                {
                    L.l(location, "Attempted to stop before automation.");
                }
                else if (!this.auto.stop())
                {
                    L.err(location, "Failed to stop automation.");
                }
                else
                {
                    L.l(location, "Stopped automated tests.");
                    btnPauseAutomation.Text = "Pause";
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnAutomateDBAll_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnAutomateDBAll_Click";
            try
            {
                L.l(location, "Selecting all databases for automation.");
                if (cbAutomateMariaDB != null) cbAutomateMariaDB.Checked = true;
                if (cbAutomateMSSQL != null) cbAutomateMSSQL.Checked = true;
                if (cbAutomateMySQL != null) cbAutomateMySQL.Checked = true;
                if (cbAutomatePostgre != null) cbAutomatePostgre.Checked = true;
                if (cbAutomateSQLite != null) cbAutomateSQLite.Checked = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnAutomationClearLogs_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnAutomationClearLogs_Click";
            try
            {
                if (this.auto == null)
                {
                    L.err(location, "Automation was not running at log clear.");
                }
                else 
                {
                    int lengthCleared = this.auto.clearAutomationLog();
                    if (lengthCleared < 0) L.err(location, "Failed to clear automation logs.");
                    else L.l(location, "Cleared (" + lengthCleared + ") automation logs.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }
    }
}

