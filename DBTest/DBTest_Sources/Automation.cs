using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTest
{
    public class Automation
    {
        public const string CLASSNAME = "Automation";

        public bool isProcessing = false;
        public bool isPaused = false;
        public bool isStopped = false;

        public bool isTestMariaDB = false;
        public bool isTestMSSQL = false;
        public bool isTestMySQL = false;
        public bool isTestPostgre = false;
        public bool isTestSQLite = false;

        private ListBox lbAutomationLogs = null;
        private RichTextBox rtbAutomationOutput = null;

        public int reqInsert1K = 0;
        public int reqInsert10K = 0;
        public int reqInsert100K = 0;
        public int reqInsert1M = 0;
        public int reqInsert10M = 0;

        // Sequential Select
        public int reqSelectId1S = 0;
        public int reqSelectId100S = 0;
        public int reqSelectId1KS = 0;
        public int reqSelectId10KS = 0;
        public int reqSelectId25KS = 0;

        // Non-Sequential Select
        public int reqSelectId1NS = 0;
        public int reqSelectId100NS = 0;
        public int reqSelectId1KNS = 0;
        public int reqSelectId10KNS = 0;
        public int reqSelectId25KNS = 0;

        public int reqSelectSerial1 = 0;
        public int reqSelectSerial100 = 0;
        public int reqSelectSerial1K = 0;
        public int reqSelectSerial10K = 0;
        public int reqSelectSerial25K = 0;

        public int reqSelectDateRange = 0;

        public int reqUpdate1 = 0;
        public int reqUpdate100 = 0;
        public int reqUpdate1K = 0;
        public int reqUpdate10K = 0;



        // TODO - Force use of procedures for all tests!


        public Automation()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public bool init(ListBox automationLogs, RichTextBox automationOutput)
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                int cntErrors = 0;
                if (automationLogs == null)
                {
                    L.err(location, "Input listbox for logs was null.");
                    cntErrors++;
                }
                else this.lbAutomationLogs = automationLogs;

                if (automationOutput == null)
                {
                    L.err(location, "Input richtextbox for display was null.");
                    cntErrors++;
                }
                else this.rtbAutomationOutput = automationOutput;

                retVal = cntErrors == 0;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        private bool clearOutput()
        {
            const string location = CLASSNAME + ".clearOutput";
            bool retVal = false;
            try
            {
                int cntComplete = 0;
                if (rtbAutomationOutput != null)
                {
                    if (rtbAutomationOutput.InvokeRequired)
                        rtbAutomationOutput.Invoke(new Action(() => { rtbAutomationOutput.Clear(); }));
                    else rtbAutomationOutput.Clear();
                    cntComplete++;
                }

                if (lbAutomationLogs != null)
                {
                    if (lbAutomationLogs.InvokeRequired)
                        lbAutomationLogs.Invoke(new Action(() => { lbAutomationLogs.Items.Clear(); }));
                    else lbAutomationLogs.Items.Clear();
                    cntComplete++;
                }

                retVal = cntComplete == 2;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public void handlePause()
        {
            const string location = CLASSNAME + ".handlePause";
            try
            {
                if (this.isPaused)
                {
                    L.l(location, "Processing paused by user.");
                    while (this.isPaused && !this.isStopped) Thread.Sleep(400);
                    L.l(location, "Processing (" + (this.isStopped ? "Stopped" : !this.isPaused ? "Resuming" : "Error") + ").");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public bool process()
        {
            const string location = CLASSNAME + ".process";
            bool retVal = false;
            try
            {
                this.isProcessing = true;
                l(location, "Starting Automation.");

                // Clear old output
                if (!clearOutput())
                {
                    L.err(location, "Failed to clear prior output before beginning.");
                }

                DateTime dtStartAutomation = DateTime.Now;

                // Prepare containers for report text
                StringBuilder sb = new StringBuilder();//overall
                StringBuilder sbTest = new StringBuilder();//this test


                // Get connect strings
                Dictionary<DB.Engine, string> connectStrings = new Dictionary<DB.Engine, string>();
                connectStrings.Add(DB.Engine.MARIADB, AppConfig.Get("MariaConnectString", ""));
                connectStrings.Add(DB.Engine.MSSQL, AppConfig.Get("MSSQLConnectString", ""));
                connectStrings.Add(DB.Engine.MYSQL, AppConfig.Get("MySQLConnectString", ""));
                connectStrings.Add(DB.Engine.POSTGRE, AppConfig.Get("PostgreConnectString", ""));
                connectStrings.Add(DB.Engine.SQLITE, AppConfig.Get("SQLiteConnectString", ""));
                connectStrings.Add(DB.Engine.UNKNOWN, "No Engine Selected...");

                // Get DB names
                Dictionary<DB.Engine, string>  dbNameStrings = new Dictionary<DB.Engine, string>();
                dbNameStrings.Add(DB.Engine.MARIADB, AppConfig.Get("MariaDbName", ""));
                dbNameStrings.Add(DB.Engine.MSSQL, AppConfig.Get("MSSQLDbName", ""));
                dbNameStrings.Add(DB.Engine.MYSQL, AppConfig.Get("MySQLDbName", ""));
                dbNameStrings.Add(DB.Engine.POSTGRE, AppConfig.Get("PostgreDbName", ""));
                dbNameStrings.Add(DB.Engine.SQLITE, AppConfig.Get("SQLiteDbName", ""));
                dbNameStrings.Add(DB.Engine.UNKNOWN, "No Engine Selected...");

                for (int iEngine = 0; iEngine < 5; iEngine++)
                {
                    this.handlePause();
                    if (this.isStopped) break;

                    DB.Engine oldEngine = DB.engine();
                    DB.Engine nowEngine = DB.Engine.UNKNOWN;
                    string connectString = "";
                    string dbName = "";
                    switch (iEngine)
                    {
                        case 0://MariaDB
                            if (!this.isTestMariaDB) continue;
                            nowEngine = DB.Engine.MARIADB;
                            break;
                        case 1://MSSQL
                            if (!this.isTestMSSQL) continue;
                            nowEngine = DB.Engine.MSSQL;
                            break;
                        case 2://MySQL
                            if (!this.isTestMySQL) continue;
                            nowEngine = DB.Engine.MYSQL;
                            break;
                        case 3://Postgre
                            if (!this.isTestPostgre) continue;
                            nowEngine = DB.Engine.POSTGRE;
                            break;
                        case 4://SQLite
                            if (!this.isTestSQLite) continue;
                            nowEngine = DB.Engine.SQLITE;
                            break;
                        default:
                            L.err(location, "Requested to automate unknown engine index (" + iEngine + ").");
                            continue;
                    }

                    // Set DB engine
                    L.l(location, "Changing engine from (" + oldEngine + ") to (" + nowEngine + ").");
                    sb.Append("\n--- CHANGING DB TO (" + nowEngine + ") ---\n\n");
                    sbTest.Append("\n--- CHANGING DB TO (" + nowEngine + ") ---\n\n");

                    // Connect
                    connectString = connectStrings[nowEngine];
                    dbName = dbNameStrings[nowEngine];
                    if (!DB.initDB(nowEngine, dbName, connectString))
                    //if (!DB.engine(nowEngine))
                    {
                        L.err(location, "Failed to set " + nowEngine + " as current.");
                        sb.Append("\nError:  Failed to set " + nowEngine + " as current.\n\n");
                        sb.Append("DB Name (" + dbName + "), Connect String (" + connectString + ").");
                        continue;
                    }

                    sb.Append("\nTotal Times:\n\n");
                    sbTest.Append("\nTest Times:\n\n");


                    string testName = "";
                    int totalInserts = 0;// use total inserts to limit select

                    // Containers for output
                    Dictionary<string, double> ttlTimes = new Dictionary<string, double>();
                    Dictionary<string, List<double>> times = new Dictionary<string, List<double>>();

                    DateTime dtStart = DateTime.Now;

                    // Drop and rebuild table, indexes, and procedures
                    if (!this.isStopped)
                    {
                        this.handlePause();

                        // TODO - Drop the current tables conditionally
                        l(location, "Droping TestTable and recreating.");

                        if (!DB.createTestTable(true))
                        {
                            lerr(location, "Failed to drop and recreate test table.");
                        }
                        else
                        {
                            l(location, "Finished recreating test table.");
                        }
                        l(location, "Reset TestTable in (" + (DateTime.Now - dtStart).TotalMilliseconds + "ms).");
                    }

                    // Insert
                    {
                        this.handlePause();
                        int quantity = 0;

                        // Insert 1K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Insert 1K";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqInsert1K + " iterations");
                            quantity = 1000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqInsert1K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                if (i % 10 == 0) l(location, "  Starting iteration (" + (i + 1) + ").");
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelData(ref query, quantity))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                totalInserts += quantity;
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Insert 10K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Insert 10K";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqInsert10K + " iterations");
                            quantity = 10000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqInsert10K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                l(location, "  Starting iteration (" + (i + 1) + ").");
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelData(ref query, quantity))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                totalInserts += quantity;
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Insert 100K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Insert 100K";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqInsert100K + " iterations");
                            quantity = 100000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqInsert100K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                l(location, "  Starting iteration (" + (i + 1) + ").");
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelData(ref query, quantity))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                totalInserts += quantity;
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Insert 1M
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Insert 1M";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqInsert1M + " iterations");
                            quantity = 1000000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqInsert1M; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                l(location, "  Starting iteration (" + (i + 1) + ").");
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelData(ref query, quantity))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                totalInserts += quantity;
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Insert 10M
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Insert 10M";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqInsert10M + " iterations");
                            quantity = 10000000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqInsert10M; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelData(ref query, quantity))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                totalInserts += quantity;
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }
                    }


                    // Establish a min and max Id for select tests
                    int minId = 1;
                    int maxId = totalInserts;


                    // Select By Id Sequential
                    /*{
                        this.handlePause();

                        // Select 1S
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1 By Id Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId1S + " iterations");
                        }

                        // Select 100S
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 100 By Id Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId100S + " iterations");
                        }

                        // Select 1KS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1K By Id Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId1KS + " iterations");
                        }

                        // Select 10KS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 10K By Id Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId10KS + " iterations");
                        }

                        // Select 25KS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 25K By Id Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId25KS + " iterations");
                        }
                    }*/


                    // Select By Id Non-Sequential
                    {
                        this.handlePause();
                        int quantity = 0;

                        // Select 1NS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1 By Id Non-Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId1NS + " iterations");
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            quantity = 1;
                            for (int i = 0; i < this.reqSelectId1NS; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelect(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }

                        // Select 100NS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 100 By Id Non-Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId100NS + " iterations");
                            quantity = 100;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectId100NS; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelect(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select 1KNS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1K By Id Non-Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId1KNS + " iterations");
                            quantity = 1000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectId1KNS; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelect(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select 10KNS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 10K By Id Non-Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId10KNS + " iterations");
                            quantity = 10000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectId10KNS; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelect(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select 25KNS
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 25K By Id Non-Sequential";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectId25KNS + " iterations");
                            quantity = 25000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectId25KNS; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelect(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }
                    }


                    // Select By Varchar
                    {
                        this.handlePause();
                        int quantity = 0;

                        // Select Varchar 1
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1 By Varchar";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectSerial1 + " iterations");
                            quantity = 1;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectSerial1; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelectVarchar(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select Varchar 100
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 100 By Varchar";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectSerial100 + " iterations");
                            quantity = 100;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectSerial100; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelectVarchar(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select Varchar 1K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 1K By Varchar";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectSerial1K + " iterations");
                            quantity = 1000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectSerial1K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelectVarchar(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select Varchar 10K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 10K By Varchar";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectSerial10K + " iterations");
                            quantity = 10000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectSerial10K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelectVarchar(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Select Varchar 25K
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select 25K By Varchar";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectSerial25K + " iterations");
                            quantity = 25000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectSerial25K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelSelectVarchar(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }
                    }


                    // Select By Date Range
                    {
                        this.handlePause();
                        int quantity = 0;

                        // Select By Date
                        if (!this.isStopped)
                        {
                            this.handlePause();
                            testName = "Select By Date Range (24-hours limit 10000)";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqSelectDateRange + " iterations");
                            quantity = 10000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < this.reqSelectDateRange; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                DateTime end = DateTime.Now;
                                DateTime start = DateTime.Now.AddDays(-1);
                                SQLWrapper query = new SQLWrapper();
                                query.isDbFunction = true;
                                if (!TestHelpers.ModelSelectDateRange(ref query, quantity, start, end))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }
                    }


                    // Update
                    {
                        this.handlePause();
                        int quantity = 0;

                        // Update 1
                        {
                            this.handlePause();
                            testName = "Update 1";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqUpdate1 + " iterations");
                            quantity = 1;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < reqUpdate1; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelUpdate(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Update 100
                        {
                            this.handlePause();
                            testName = "Update 100";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqUpdate100 + " iterations");
                            quantity = 100;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < reqUpdate100; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelUpdate(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Update 1K
                        {
                            this.handlePause();
                            testName = "Update 1K";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqUpdate1K + " iterations");
                            quantity = 1000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < reqUpdate1K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelUpdate(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }


                        // Update 10K
                        {
                            this.handlePause();
                            testName = "Update 10K";
                            l(location, nowEngine + " Beginning " + testName + " - " + this.reqUpdate10K + " iterations");
                            quantity = 10000;
                            ttlTimes.Add(testName, -1);
                            times.Add(testName, new List<double>());
                            for (int i = 0; i < reqUpdate10K; i++)
                            {
                                this.handlePause();
                                if (this.isStopped) break;
                                times[testName].Add(-1);
                                SQLWrapper query = new SQLWrapper();
                                if (!TestHelpers.ModelUpdate(ref query, quantity, minId, maxId))
                                {
                                    lerr(location, "Failed to test (" + testName + ") at iteration (" + i +
                                        "). Stopping this test.");
                                    break;
                                }
                                times[testName][i] = query.queryMS;
                                ttlTimes[testName] += query.queryMS;
                            }
                        }
                    }


                    // Output Testing Report --- Will only show first 1,000 results for each test
                    foreach (KeyValuePair<string, double> kv in ttlTimes)
                    {
                        // Not going to toggle on input booleans, memory for these probably needs to change.
                        // Simply accept results that exist here, any errors should have already occurred.
                        if (times[kv.Key].Count > 0)
                        {
                            string totalTimeMessage = "  Total Time:  " + kv.Key + " - iterations " + times[kv.Key].Count + " in " + kv.Value + "ms.";
                            L.l(location, totalTimeMessage);
                            sb.Append(totalTimeMessage + "\n");

                            sbTest.Append("\n" + kv.Key + ":\n\n");
                            for (int i = 0; i < times[kv.Key].Count && i < 1000; i++)
                            {
                                sbTest.Append("Iteration (" + (i + 1).ToString().PadLeft(3) + "): " +
                                    (times[kv.Key][i] < 0 ? "Error" : times[kv.Key][i].ToString()) + "\n");
                            }
                            sbTest.Append("\n\n");
                        }
                    }

                }

                string report = sb.ToString() + "\n\n--\n\n" + sbTest.ToString();
                sb.Clear();
                sbTest.Clear();

                // Update UI - treat ui update independent of process success
                if (!showResults("", report))
                {
                    L.err(location, "Failed to update ui with results.");
                }


                // Flag success for completing (for now)
                this.isProcessing = false;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
                this.isProcessing = false;
            }
            return retVal;
        }

        public bool showResults(string topSummary, string results)
        {
            const string location = CLASSNAME + ".showResults";
            bool retVal = false;
            try
            {
                if (this.rtbAutomationOutput == null)
                {
                    L.err(location, "Richtextbox was null when showing results.");
                    return retVal;
                }
                else if (this.rtbAutomationOutput.InvokeRequired)
                {
                    this.rtbAutomationOutput.Invoke(new Action(() => retVal = showResults(topSummary, results)));
                }
                else 
                {
                    StringBuilder resultsOut = new StringBuilder();

                    resultsOut.Append("\n" + topSummary + "\n\n");
                    resultsOut.Append(results);

                    this.rtbAutomationOutput.Text = resultsOut.ToString();
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        // Pausing will not cancel an ongoing transaction or step of a process, but will
        // safely exit between. Other forces like clearing the table may still cause error.
        public bool pause() { return this.isPaused = true; }

        public bool resume() { return !(this.isPaused = false); }

        // Determine what to do on stop. Should post what results exist instead of quitting immediately
        // as stopping a test should not allow resuming.
        public bool stop() { return this.isStopped = true; }




        // Logger
        private void l(string location, string message, string grade)
        {
            try
            {
                if (this.lbAutomationLogs == null)
                {
                    L.l(location, "Listbox was null.");
                    return;
                }

                if (this.lbAutomationLogs.InvokeRequired)
                {
                    //L.l(location, "Invoking on listbox.");
                    this.lbAutomationLogs.Invoke(new Action(() => { this.l(location, message, grade); }));
                }
                else
                {
                    //L.l(location, "Pushing automation message (" + message + ").");
                    if (message == null || message.Length == 0) return;

                    string msg = DateTime.Now.ToString(L.TAG.DTF) + " - " +
                        (location == null ? "Unknown Method" : location) + " - " +
                        (grade == null ? L.TAG.GENERAL : grade) + " - " +
                        message;

                    this.lbAutomationLogs.Items.Add(msg);
                    this.lbAutomationLogs.Invalidate();
                    //L.l(location, "Successfully pushed message.");
                }
            }
            catch (Exception ex)
            {
                L.err("Automation.l", "Automation log failed with error (" + ex.Message + ") on message (" + message + ").");
            }
        }
        private void lerr(string location, string message) { l(location, message, L.TAG.ERR); }
        private void lex(string location, string message) { l(location, message, L.TAG.EX); }
        private void l(string location, string message) { l(location, message, L.TAG.GENERAL); }

        public int clearAutomationLog()
        {
            const string location = CLASSNAME + ".clearAutomationLog";
            int retVal = -1;
            try
            {
                if (this.lbAutomationLogs == null) return retVal;
                if (this.lbAutomationLogs.InvokeRequired)
                {
                    this.lbAutomationLogs.Invoke(new Action(() => retVal = clearAutomationLog()));
                }
                else 
                {
                    int temp = this.lbAutomationLogs.Items.Count;
                    this.lbAutomationLogs.Items.Clear();
                    retVal = temp;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        /*// Main Output
        private void appendOutput(string line)
        {

        }*/
    }
}
