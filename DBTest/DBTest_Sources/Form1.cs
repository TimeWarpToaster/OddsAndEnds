using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTest
{
    public partial class Form1 : Form
    {
        const string CLASSNAME = "Form1";

        // Short-term connect string memory
        private Dictionary<DB.Engine, string> connectStrings = new Dictionary<DB.Engine, string>();
        private Dictionary<DB.Engine, string> dbNameStrings = new Dictionary<DB.Engine, string>();


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


                    string dbName = dbNameStrings[engine];
                    if (dbName == null) dbName = "";

                    if (connectStrings[engine] != tbDBSelectConnectString.Text)
                    {
                        //L.err(location, "Connect string for (" + engine + ") in memory was " +
                            //"out of sync with ui.");
                        connectStrings[engine] = tbDBSelectConnectString.Text;
                    }

                    else if (engine == DB.Engine.UNKNOWN)
                        L.err(location, "No db engine selected.");

                    else if (connectStrings[engine].Length == 0)
                        L.err(location, "Connect string for (" + engine + ") was null or empty.");

                    else if (!DB.initDB(engine, dbName, connectStrings[engine]))
                        L.err(location, "Failed to intialize (" + engine + ") database.");

                    else retVal = true;

                    if (retVal)
                    {
                        L.l(location, "Database initialized.");


                        // Create the table if it does not exist 
                        L.l(location, "Verifying tables exist.");
                        if (!DB.existsTable("TestTable"))
                        {
                            L.l(location, "Creating TestTable for not-existing.");
                            if (!DB.createTestTable(false))
                            {
                                L.err(location, "Failed to create test table.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool dropRecreateTable()
        {
            const string location = CLASSNAME + ".dropRecreateTable";
            bool retVal = false;
            try
            {
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
                    }
                    catch (Exception exTask)
                    {
                        L.err(location, "Task Error: " + exTask.Message);
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

                // Due to deletes, there is no way to know where data starts. Accept 
                // start and stop ids, knowing deletes may have occured between.
                try
                {
                    minSelectId = Convert.ToInt32(tbMinSelectId.Text);
                    maxSelectId = Convert.ToInt32(tbMaxSelectId.Text);
                    selectQty = Convert.ToInt32(tbSelectQty.Text);
                    useDbFunction = cbUseDbFunction.Checked;
                }
                catch (Exception exConv) { }

                if (minSelectId < 0 || maxSelectId < 0 || selectQty < 0)
                {
                    L.err(location, "Max Id and select quantity must be numbers > 0.");
                }
                else if (minSelectId > maxSelectId)
                {
                    L.err(location, "Min id must be less than max.");
                }
                else
                {
                    if (!enableUi(false)) L.err(location, "Failed to disable ui.");
                    Task task = new Task(new Action(() =>
                    {
                        try
                        {
                            // This wrapper will not contain sql or results (bulk). It exists
                            // to track actual insert times over the span of iterations.
                            SQLWrapper query = new SQLWrapper();

                            string page = "";
                            if (!TestHelpers.ModelSelect(ref query, selectQty, minSelectId, maxSelectId, useDbFunction))
                            {
                                L.err(location, "Failed to select model data.");
                                page = "Error:  Failed to select model data.";
                            }
                            else if (query.result == null)
                            {
                                L.err(location, "Failed to select rows.");
                                page = "Error:  Failed to select rows.";
                            }
                            else
                            {
                                // Build a simple html page from results

                                StringBuilder sb = new StringBuilder();
                                sb.Append(
                                    "<br />" +
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
                    if (btnDynamicQuery != null) btnDynamicQuery.Enabled = isEnabled;
                    if (btnMainInsertModel != null) btnMainInsertModel.Enabled = isEnabled;
                    if (btnMainSelect != null) btnMainSelect.Enabled = isEnabled;
                    if (tbInsertQty != null) tbInsertQty.Enabled = isEnabled;
                    if (tbMinSelectId != null) tbMinSelectId.Enabled = isEnabled;
                    if (tbMaxSelectId != null) tbMaxSelectId.Enabled = isEnabled;
                    if (tbSelectQty != null) tbSelectQty.Enabled = isEnabled;
                    if (rtbMainQuery != null) rtbMainQuery.Enabled = isEnabled;

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
                    else if (rbDBSelectMySQL.Checked) engine = DB.Engine.MSSQL;
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
    }
}
