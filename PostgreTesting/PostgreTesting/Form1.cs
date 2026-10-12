using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreTesting
{
    public partial class Form1 : Form
    {
        public const string CLASSNAME = "Form1";


        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                if (!L.logInit(null, lbLogs, false))
                {
                    L.err(location, "Failed to initialize logging.");
                }
                L.l(location, "Application starting...");

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


        /*public bool connectDb()
        {
            const string location = CLASSNAME + ".connectDb";
            bool retVal = false;
            try
            {
                L.l(location, "Setting up connection.");
                string connectString = "Host=localhost;UserName=postgres;Password=EPost01;Database=FirstDB;Port=5432";

                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        L.l(location, "Connecting.");
                        conn.Open();
                        L.l(location, "DB connection successful.");

                        string sql = "SELECT * FROM MyTable;";

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            L.l(location, "Using statement.");
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                L.l(location, "Starting read.");
                                while (reader.Read())
                                {
                                    long id = reader.GetInt64(0);
                                    string field1 = reader.GetString(1);
                                    string field2 = reader.GetString(2);

                                    L.l(location, "ID (" + id + "), Field 1 (" + field1 + "), Field 2 (" + field2 + ").");
                                }
                                L.l(location, "Finished reading.");
                                retVal = true;
                            }
                        }
                    }
                    catch (Exception exConnect)
                    {
                        L.ex(location, exConnect);
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }*/

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
                            if (!TestHelpers.dynamicSQL(ref query))
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
                            List<TestTable> modelRows = new List<TestTable>();
                            for (int j = 0; j < 1000 && i < rows; j++, i++, cntrLog++)
                            {
                                modelRows.Add(TestHelpers.ModelRow());
                            }

                            // Insert set, uses transaction with prepared statement (no sp/function)
                            if (modelRows.Count == 0)
                            {
                                L.err(location, "Failed to package data set for db.");
                            }
                            else
                            {
                                if (!TestHelpers.insert(ref query, modelRows))
                                {
                                    L.err(location, "Failed to insert data set into db.");
                                }
                                else
                                {
                                    cntInserts += modelRows.Count;
                                }
                                ttlMs += query.queryMS;
                            }
                            if (cntrLog >= 100000)
                            {
                                cntrLog = 0;
                                L.l(location, "Inserted record (" + i + ") of (" + rows + ").");
                            }
                        }

                        L.l(location, "Inserted (" + cntInserts + ") of (" + rows + 
                            ") rows out of (" + query.queryMS + ").");



                        /*DateTime dtStart = DateTime.Now;
                        L.l(location, "Modeling (" + rows + ") rows of data.");
                        if (!TestHelpers.ModelData(rows))
                        {
                            L.err(location, "Failed to model data at (" + rows + ") rows.");
                        }*/

                        DateTime dtEnd = DateTime.Now;
                        L.l(location, "Finished modeling (" + rows + ") rows in (" + 
                            (dtEnd - dtStart).TotalMilliseconds.ToString() + ") ms.");

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
                                    "<br /><br />"
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
    }

}
