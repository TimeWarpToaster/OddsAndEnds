using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Npgsql;

namespace PostgreTesting
{
    public class SQLWrapper
    {
        public string sql = "";
        public Dictionary<string, object> parms = new Dictionary<string, object>();
        public List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
        public bool isDbFunction = false;
        public double queryMS = 0d;
        public double responseFormatMS = 0d;
    }

    public class TestTable
    {
        public const string CLASSNAME = "TestTable";

        public long TestId = 0L;
        public DateTime CDT { get; set; }
        public long FID1 = 0L;
        public long FID2 = 0L;
        public long FID3 = 0L;
        public string Label = "";
        public string UnitNum = "";
        public string SerialNum = "";
        public long MfrId = 0L;
        public int MfrLocId = 0;
        public int MachineId = 0;
        public int Lot = 0;
        public DateTime MfrDate { get; set; }
        public DateTime InstDate { get; set; }
        public string InstAddr1 = "";
        public string InstAddr2 = "";
        public string InstCity = "";
        public string InstCounty = "";
        public string InstProvince = "";
        public string InstState = "";
        public string InstCountry = "";
        public DateTime LastChecked { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastReplaced { get; set; }
        public long LastTechId = 0L;
        public DateTime BillingDate { get; set; }//testme - locale
        public DateTime LastBillingDate { get; set; }// locale
        public double Due = 0d;//real
        public double PastDue = 0d;//real
        public double LastDue = 0d;//real
        public double Something = 0d;//double
        public bool isActive = false;//bool
        public bool isOnline = false;//bit
        public DateTime LastOffline { get; set; }//tzutc
        public long FailedMessages = 0L;
        public string LastActionCode = "";
        public string LastAction = "";
        public string NextActionCode = "";
        public long NextTechId = 0L;
        public int CntActionsTaken = 0;
        public string LastNote = "";



        public TestTable() { }

        public TestTable(Dictionary<string, object> inVals)
        {
            const string location = CLASSNAME + ".Constructor(D)";
            try
            {
                if (!this.from(inVals))
                {
                    L.err(location, "Failed to initialize object from in-values.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private bool from(Dictionary<string, object> inVals)
        {
            const string location = CLASSNAME + ".from";
            bool retVal = false;
            try
            {
                if (inVals == null || inVals.Count == 0)
                {
                    L.err(location, "Input values were null or empty.");
                    return retVal;
                }

                int cntErrors = 0;

                if (inVals.ContainsKey("testid") && inVals["testid"] != null)
                    this.TestId = Convert.ToInt64(inVals["testid"]);
                else cntErrors++;

                if (inVals.ContainsKey("cdt") && inVals["cdt"] != null)
                    this.CDT = Convert.ToDateTime(inVals["cdt"]);
                else cntErrors++;

                if (inVals.ContainsKey("fid1") && inVals["fid1"] != null)
                    this.FID1 = Convert.ToInt64(inVals["fid1"]);
                else cntErrors++;

                if (inVals.ContainsKey("fid2") && inVals["fid2"] != null)
                    this.FID2 = Convert.ToInt64(inVals["fid2"]);
                else cntErrors++;

                if (inVals.ContainsKey("fid3") && inVals["fid3"] != null)
                    this.FID3 = Convert.ToInt64(inVals["fid3"]);
                else cntErrors++;

                if (inVals.ContainsKey("Label") && inVals["Label"] != null)
                    this.Label = Convert.ToString(inVals["Label"]);
                else cntErrors++;

                if (inVals.ContainsKey("unitnum") && inVals["unitnum"] != null)
                    this.UnitNum = Convert.ToString(inVals["unitnum"]);
                else cntErrors++;

                if (inVals.ContainsKey("serialnum") && inVals["serialnum"] != null)
                    this.SerialNum = Convert.ToString(inVals["serialnum"]);
                else cntErrors++;

                if (inVals.ContainsKey("mfrid") && inVals["mfrid"] != null)
                    this.MfrId = Convert.ToInt64(inVals["mfrid"]);
                else cntErrors++;

                if (inVals.ContainsKey("mfrlocid") && inVals["mfrlocid"] != null)
                    this.MfrLocId = Convert.ToInt32(inVals["mfrlocid"]);
                else cntErrors++;

                if (inVals.ContainsKey("machineid") && inVals["machineid"] != null)
                    this.MachineId = Convert.ToInt32(inVals["machineid"]);
                else cntErrors++;

                if (inVals.ContainsKey("lot") && inVals["lot"] != null)
                    this.Lot = Convert.ToInt32(inVals["lot"]);
                else cntErrors++;

                if (inVals.ContainsKey("mfrdate") && inVals["mfrdate"] != null)
                    this.MfrDate = Convert.ToDateTime(inVals["mfrdate"]);
                else cntErrors++;

                if (inVals.ContainsKey("instdate") && inVals["instdate"] != null)
                    this.InstDate = Convert.ToDateTime(inVals["instdate"]);
                else cntErrors++;

                if (inVals.ContainsKey("instaddr1") && inVals["instaddr1"] != null)
                    this.InstAddr1 = Convert.ToString(inVals["instaddr1"]);
                else cntErrors++;

                if (inVals.ContainsKey("instaddr2") && inVals["instaddr2"] != null)
                    this.InstAddr2 = Convert.ToString(inVals["instaddr2"]);
                else cntErrors++;

                if (inVals.ContainsKey("instcity") && inVals["instcity"] != null)
                    this.InstCity = Convert.ToString(inVals["instcity"]);
                else cntErrors++;

                if (inVals.ContainsKey("instcounty") && inVals["instcounty"] != null)
                    this.InstCounty = Convert.ToString(inVals["instcounty"]);
                else cntErrors++;

                if (inVals.ContainsKey("instprovince") && inVals["instprovince"] != null)
                    this.InstProvince = Convert.ToString(inVals["instprovince"]);
                else cntErrors++;

                if (inVals.ContainsKey("inststate") && inVals["inststate"] != null)
                    this.InstState = Convert.ToString(inVals["inststate"]);
                else cntErrors++;

                if (inVals.ContainsKey("instcountry") && inVals["instcountry"] != null)
                    this.InstCountry = Convert.ToString(inVals["instcountry"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastchecked") && inVals["lastchecked"] != null)
                    this.LastChecked = Convert.ToDateTime(inVals["lastchecked"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastchecked") && inVals["lastchecked"] != null)
                    this.LastChecked = Convert.ToDateTime(inVals["lastchecked"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastmodified") && inVals["lastmodified"] != null)
                    this.LastModified = Convert.ToDateTime(inVals["lastmodified"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastreplaced") && inVals["lastreplaced"] != null)
                    this.LastReplaced = Convert.ToDateTime(inVals["lastreplaced"]);
                else cntErrors++;

                if (inVals.ContainsKey("lasttechid") && inVals["lasttechid"] != null)
                    this.LastTechId = Convert.ToInt64(inVals["lasttechid"]);
                else cntErrors++;

                if (inVals.ContainsKey("billingdate") && inVals["billingdate"] != null)
                    this.BillingDate = Convert.ToDateTime(inVals["billingdate"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastbillingdate") && inVals["lastbillingdate"] != null)
                    this.LastBillingDate = Convert.ToDateTime(inVals["lastbillingdate"]);
                else cntErrors++;

                if (inVals.ContainsKey("due") && inVals["due"] != null)
                    this.Due = Convert.ToDouble(inVals["due"]);
                else cntErrors++;

                if (inVals.ContainsKey("pastdue") && inVals["pastdue"] != null)
                    this.PastDue = Convert.ToDouble(inVals["pastdue"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastdue") && inVals["lastdue"] != null)
                    this.LastDue = Convert.ToDouble(inVals["lastdue"]);
                else cntErrors++;

                if (inVals.ContainsKey("something") && inVals["something"] != null)
                    this.Something = Convert.ToDouble(inVals["something"]);
                else cntErrors++;

                if (inVals.ContainsKey("isactive") && inVals["isactive"] != null)
                    this.isActive = Convert.ToBoolean(inVals["isactive"]);
                else cntErrors++;

                if (inVals.ContainsKey("isonline") && inVals["isonline"] != null)
                {
                    if (inVals["isonline"].GetType() == typeof(BitArray))
                    {
                        BitArray ba = (BitArray)inVals["isonline"];
                        this.isOnline = ba != null && ba.Count > 0 ? ba[0] : false;
                    }
                    else
                    {
                        this.isOnline = Convert.ToBoolean(inVals["isonline"]);
                    }
                }
                else cntErrors++;

                if (inVals.ContainsKey("lastoffline") && inVals["lastoffline"] != null)
                    this.LastOffline = Convert.ToDateTime(inVals["lastoffline"]);
                else cntErrors++;

                if (inVals.ContainsKey("failedmessages") && inVals["failedmessages"] != null)
                    this.FailedMessages = Convert.ToInt64(inVals["failedmessages"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastactioncode") && inVals["lastactioncode"] != null)
                    this.LastActionCode = Convert.ToString(inVals["lastactioncode"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastaction") && inVals["lastaction"] != null)
                    this.LastAction = Convert.ToString(inVals["lastaction"]);
                else cntErrors++;

                if (inVals.ContainsKey("nextactioncode") && inVals["nextactioncode"] != null)
                    this.NextActionCode = Convert.ToString(inVals["nextactioncode"]);
                else cntErrors++;

                if (inVals.ContainsKey("nexttechid") && inVals["nexttechid"] != null)
                    this.NextTechId = Convert.ToInt64(inVals["nexttechid"]);
                else cntErrors++;

                if (inVals.ContainsKey("cntactionstaken") && inVals["cntactionstaken"] != null)
                    this.CntActionsTaken = Convert.ToInt32(inVals["cntactionstaken"]);
                else cntErrors++;

                if (inVals.ContainsKey("lastnote") && inVals["lastnote"] != null)
                    this.LastNote = Convert.ToString(inVals["lastnote"]);
                else cntErrors++;


                if (cntErrors > 0)
                {
                    // Do not hang on errors during testing, pump result
                    L.err(location, "Unpacked db row as object with (" + cntErrors + ") errors.");
                }

                // Flag success for completing (testing)
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string toString()
        {
            const string location = CLASSNAME + ".toString";
            string retVal = "";
            try
            {
                // No partial results during testing
                string temp =
                    "TestTable Row:" +
                    "  TestId (" + TestId + ")" + 
                    ", CDT (" + CDT.ToString(L.TAG.DTF) + ")" +
                    ", FID1 (" + FID1 + ")" +
                    ", FID2 (" + FID2 + ")" +
                    ", FID3 (" + FID3 + ")" +
                    ", Label (" + Label + ")" +
                    ", UnitNum (" + UnitNum + ")" +
                    ", SerialNum (" + SerialNum + ")" +
                    ", MfrId (" + MfrId + ")" +
                    ", MfrLocId (" + MfrLocId + ")" +
                    ", MachineId (" + MachineId + ")" +
                    ", Lot (" + Lot + ")" +
                    ", MfrDate (" + MfrDate.ToString(L.TAG.DTF) + ")" +
                    ", InstDate (" + InstDate.ToString(L.TAG.DTF) + ")" +
                    ", InstAddr1 (" + InstAddr1 + ")" +
                    ", InstAddr2 (" + InstAddr2 + ")" +
                    ", InstCity (" + InstCity + ")" +
                    ", InstCounty (" + InstCounty + ")" +
                    ", InstProvince (" + InstProvince + ")" +
                    ", InstState (" + InstState + ")" +
                    ", InstCountry (" + InstCountry + ")" +
                    ", LastChecked (" + LastChecked.ToString(L.TAG.DTF) + ")" +
                    ", LastModified (" + LastModified.ToString(L.TAG.DTF) + ")" +
                    ", LastReplaced (" + LastReplaced.ToString(L.TAG.DTF) + ")" +
                    ", LastTechId (" + LastTechId + ")" +
                    ", BillingDate (" + BillingDate.ToString(L.TAG.DTF) + ")" +//testme - locale
                    ", LastBillingDate (" + LastBillingDate.ToString(L.TAG.DTF) + ")" +// locale
                    ", Due (" + Due + ")" +//real
                    ", PastDue (" + PastDue + ")" +//real
                    ", LastDue (" + LastDue + ")" +//real
                    ", Something (" + Something + ")" +//double
                    ", isActive (" + isActive + ")" +//bool
                    ", isOnline (" + isOnline + ")" +//bit
                    ", LastOffline (" + LastOffline.ToString(L.TAG.DTF) + ")" +//tzutc
                    ", FailedMessages (" + FailedMessages + ")" +
                    ", LastActionCode (" + LastActionCode + ")" +
                    ", LastAction (" + LastAction + ")" +
                    ", NextActionCode (" + NextActionCode + ")" +
                    ", NextTechId (" + NextTechId + ")" +
                    ", CntActionsTaken (" + CntActionsTaken + ")" +
                    ", LastNote (" + LastNote + ")" + 
                    ".";
                retVal = temp;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string toThTr()
        {
            const string location = CLASSNAME + ".toTh";
            string retVal = "";
            try
            {
                // No partial results during testing
                retVal =
                    "<tr>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">TestId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">CDT</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">FID1</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">FID2</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">FID3</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">Label</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">UnitNum</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">SerialNum</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">MfrId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">MfrLocId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">MachineId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">Lot</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">MfrDate</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstDate</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstAddr1</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstAddr2</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstCity</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstCounty</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstProvince</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstState</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">InstCountry</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastChecked</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastModified</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastReplaced</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastTechId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">BillingDate</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastBillingDate</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">Due</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">PastDue</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastDue</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">Something</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">isActive</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">isOnline</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastOffline</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">FailedMessages</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastActionCode</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastAction</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">NextActionCode</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">NextTechId</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">CntActionsTaken</th>" +
                    "<th style=\"white-space: nowrap; padding: 0, 5;\">LastNote</th>" + 
                    "</tr>";
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string toTr()
        {
            const string location = CLASSNAME + ".toTr";
            string retVal = "";
            try
            {
                // No partial results during testing
                string temp =
                    "<tr>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + TestId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + CDT.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + FID1 + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + FID2 + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + FID3 + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + Label + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + UnitNum + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + SerialNum + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + MfrId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + MfrLocId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + MachineId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + Lot + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + MfrDate.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstDate.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstAddr1 + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstAddr2 + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstCity + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstCounty + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstProvince + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstState + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + InstCountry + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastChecked.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastModified.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastReplaced.ToString(L.TAG.DTF) + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastTechId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + BillingDate.ToString(L.TAG.DTF) + "</td>" +//testme - locale
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastBillingDate.ToString(L.TAG.DTF) + "</td>" +// locale
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + Due + "</td>" +//real
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + PastDue + "</td>" +//real
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastDue + "</td>" +//real
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + Something + "</td>" +//double
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + isActive + "</td>" +//bool
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + isOnline + "</td>" +//bit
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastOffline.ToString(L.TAG.DTF) + "</td>" +//tzutc
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + FailedMessages + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastActionCode + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastAction + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + NextActionCode + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + NextTechId + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + CntActionsTaken + "</td>" +
                    "<td style=\"white-space: nowrap; padding: 0, 5;\">" + LastNote + "</td>" +
                    "</tr>";
                retVal = temp;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

    }

    public static class TestHelpers
    {
        public const string CLASSNAME = "TestHelpers";

        private const string connectString = "Host=localhost;UserName=postgres;Password=YourPassword;Database=DbName;Port=5432";

        public static DateTime[] dates1 = new DateTime[31];// sequential last 30
        public static DateTime[] dates2 = new DateTime[31];// sequential mo. before
        public static DateTime[] dates3 = new DateTime[31];// random dates last year

        private static int idxDates1 = -1;
        private static int idxDates2 = -1;
        private static int idxDates3 = -1;

        private static int incrDates1 = 1;
        private static int incrDates2 = 1;
        private static int incrDates3 = 1;

        private static Random thr = new Random();

        private static string[] words = new string[0];

        private static string[] codes = new string[0];


        public static bool init()
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                // Fill in our random date catalogues
                DateTime dt = DateTime.UtcNow;
                for (int i = 0; i < 30; i++)
                {
                    dates1[i] = dt;// Sequential dates month 1
                    dt = dt.AddDays(-1);
                }
                for (int i = 0; i < 30; i++)
                {
                    dates2[i] = dates1[i].AddMonths(-1);// Sequential dates month 2
                }
                Random r = new Random();
                r.Next(r.Next(r.Next()));
                thr.Next(r.Next());

                int maxSubtract = 364;
                int currentSubtract = 0;
                for (int i = 0; i < 30; i++)
                {
                    int numDays = r.Next(0, 100);
                    currentSubtract += numDays;
                    if (currentSubtract > maxSubtract)// Random dates year
                    {
                        dt = dt.AddDays(currentSubtract);
                        currentSubtract = 0;
                    }
                    else
                    {
                        dt = dt.AddDays(-currentSubtract);
                    }
                    dates3[i] = dt;
                }

                idxDates1 = r.Next(0, dates1.Length - 1);
                idxDates2 = r.Next(0, dates2.Length - 1);
                idxDates3 = r.Next(0, dates3.Length - 1);

                incrDates1 = r.Next(1, dates1.Length - 1);
                incrDates2 = r.Next(1, dates2.Length - 1);
                incrDates3 = r.Next(1, dates3.Length - 1);


                words = new string[]
                {
                    "Left", "Right", "Noon", "Somewhere", "Street", "Building", "Avenue", "Light",
                    "Night", "Sign", "Road", "Table", "Circle", "Square", "Villa", "Park", "Lane",
                    "Field", "District", "Line", "Express", "Route", "Number", "Civic", "Door",
                    "Window", "Under", "Over", "Pavement", "Sidewalk"
                };

                codes = new string[]
                {
                    "AIRN", "GNIH", "SAHK", "FAUG", "EUYV", "MXMH", "TUOI", "JKDS",
                    "SAHO", "AHFK", "ACIS", "UCHW", "UFYE", "FAMT", "VMHI", "QPTY"
                };

                // Output Result
                retVal = true;
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
                if (query == null || query.sql == null || query.sql.Length == 0)
                {
                    L.err(location, "Input sql was null or empty.");
                    return retVal;
                }
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                DateTime dtQueryStart = DateTime.Now;
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    conn.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query.sql, conn))
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
                
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool insert(ref SQLWrapper query, List<TestTable> rows)
        {
            const string location = CLASSNAME + ".insert";
            bool retVal = false;
            try
            {
                if (rows == null || rows.Count == 0)
                {
                    L.err(location, "Input rows were null or empty.");
                }

                DateTime dtInsertStart = DateTime.Now;
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        string sql = "INSERT INTO TestTable (" +
                            "FID1, FID2, FID3, \"Label\", UnitNum, SerialNum, MfrId, MfrLocId, MachineId, " +
                            "Lot, MfrDate, InstDate, InstAddr1, InstAddr2, InstCity, InstCounty, " + 
                            "InstProvince, InstState, InstCountry, LastChecked, LastModified, " + 
                            "LastReplaced, LastTechId, BillingDate, LastBillingDate, Due, " +
                            "PastDue, LastDue, Something, isActive, isOnline, LastOffline, " +
                            "FailedMessages, LastActionCode, LastAction, NextActionCode, NextTechId, " +
                            "CntActionsTaken, LastNote) VALUES (" +
                            "@FID1, " +
                            "@FID2, " +
                            "@FID3, " +
                            "@Label, " +
                            "@UnitNum, " +
                            "@SerialNum, " +
                            "@MfrId, " +
                            "@MfrLocId, " +
                            "@MachineId, " +
                            "@Lot, " +
                            "@MfrDate, " +//dt
                            "@InstDate, " +//dt
                            "@InstAddr1, " +
                            "@InstAddr2, " +
                            "@InstCity, " +
                            "@InstCounty, " +
                            "@InstProvince, " +
                            "@InstState, " +
                            "@InstCountry, " +
                            "@LastChecked, " +//dt
                            "@LastModified, " +//dt
                            "@LastReplaced, " +//dt
                            "@LastTechId, " +
                            "@BillingDate, " +//dt
                            "@LastBillingDate, " +//dt
                            "@Due, " +//real
                            "@PastDue, " +//real
                            "@LastDue, " +//real
                            "@Something, " +//double
                            "@isActive, " +//bool
                            "@isOnline, " +//bit
                            "@LastOffline, " +//tzutc
                            "@FailedMessages, " +
                            "@LastActionCode, " +
                            "@LastAction, " +
                            "@NextActionCode, " +
                            "@NextTechId, " +
                            "@CntActionsTaken, " +
                            "@LastNote" + 
                            ");";


                        using (NpgsqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn, transaction))
                                {
                                    //retVal = true;


                                    command.Parameters.Add("@FID1", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@FID2", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@FID3", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@Label", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@UnitNum", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@SerialNum", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@MfrId", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@MfrLocId", NpgsqlTypes.NpgsqlDbType.Integer);
                                    command.Parameters.Add("@MachineId", NpgsqlTypes.NpgsqlDbType.Integer);
                                    command.Parameters.Add("@Lot", NpgsqlTypes.NpgsqlDbType.Integer);
                                    command.Parameters.Add("@MfrDate", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@InstDate", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@InstAddr1", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstAddr2", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstCity", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstCounty", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstProvince", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstState", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@InstCountry", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@LastChecked", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@LastModified", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@LastReplaced", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@LastTechId", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@BillingDate", NpgsqlTypes.NpgsqlDbType.Timestamp);
                                    command.Parameters.Add("@LastBillingDate", NpgsqlTypes.NpgsqlDbType.Timestamp);
                                    command.Parameters.Add("@Due", NpgsqlTypes.NpgsqlDbType.Real);
                                    command.Parameters.Add("@PastDue", NpgsqlTypes.NpgsqlDbType.Real);
                                    command.Parameters.Add("@LastDue", NpgsqlTypes.NpgsqlDbType.Real);
                                    command.Parameters.Add("@Something", NpgsqlTypes.NpgsqlDbType.Double);
                                    command.Parameters.Add("@isActive", NpgsqlTypes.NpgsqlDbType.Boolean);
                                    command.Parameters.Add("@isOnline", NpgsqlTypes.NpgsqlDbType.Bit);
                                    command.Parameters.Add("@LastOffline", NpgsqlTypes.NpgsqlDbType.TimestampTz);
                                    command.Parameters.Add("@FailedMessages", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@LastActionCode", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@LastAction", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@NextActionCode", NpgsqlTypes.NpgsqlDbType.Varchar);
                                    command.Parameters.Add("@NextTechId", NpgsqlTypes.NpgsqlDbType.Bigint);
                                    command.Parameters.Add("@CntActionsTaken", NpgsqlTypes.NpgsqlDbType.Integer);
                                    command.Parameters.Add("@LastNote", NpgsqlTypes.NpgsqlDbType.Text);


                                    command.Prepare();

                                    int cntInserts = 0;
                                    for (int i = 0; i < rows.Count; i++)
                                    {
                                        command.Parameters["@FID1"].Value = rows[i].FID1;
                                        command.Parameters["@FID2"].Value = rows[i].FID2;
                                        command.Parameters["@FID3"].Value = rows[i].FID3;
                                        command.Parameters["@Label"].Value = rows[i].Label;
                                        command.Parameters["@UnitNum"].Value = rows[i].UnitNum;
                                        command.Parameters["@SerialNum"].Value = rows[i].SerialNum;
                                        command.Parameters["@MfrId"].Value = rows[i].MfrId;
                                        command.Parameters["@MfrLocId"].Value = rows[i].MfrLocId;
                                        command.Parameters["@MachineId"].Value = rows[i].MachineId;
                                        command.Parameters["@Lot"].Value = rows[i].Lot;
                                        command.Parameters["@MfrDate"].Value = rows[i].MfrDate;
                                        command.Parameters["@InstDate"].Value = rows[i].InstDate;
                                        command.Parameters["@InstAddr1"].Value = rows[i].InstAddr1;
                                        command.Parameters["@InstAddr2"].Value = rows[i].InstAddr2;
                                        command.Parameters["@InstCity"].Value = rows[i].InstCity;
                                        command.Parameters["@InstCounty"].Value = rows[i].InstCounty;
                                        command.Parameters["@InstProvince"].Value = rows[i].InstProvince;
                                        command.Parameters["@InstState"].Value = rows[i].InstState;
                                        command.Parameters["@InstCountry"].Value = rows[i].InstCountry;
                                        command.Parameters["@LastChecked"].Value = rows[i].LastChecked;
                                        command.Parameters["@LastModified"].Value = rows[i].LastModified;
                                        command.Parameters["@LastReplaced"].Value = rows[i].LastReplaced;
                                        command.Parameters["@LastTechId"].Value = rows[i].LastTechId;
                                        command.Parameters["@BillingDate"].Value = rows[i].BillingDate;
                                        command.Parameters["@LastBillingDate"].Value = rows[i].LastBillingDate;
                                        command.Parameters["@Due"].Value = rows[i].Due;
                                        command.Parameters["@PastDue"].Value = rows[i].PastDue;
                                        command.Parameters["@LastDue"].Value = rows[i].LastDue;
                                        command.Parameters["@Something"].Value = rows[i].Something;
                                        command.Parameters["@isActive"].Value = rows[i].isActive;
                                        command.Parameters["@isOnline"].Value = rows[i].isOnline;
                                        command.Parameters["@LastOffline"].Value = rows[i].LastOffline;
                                        command.Parameters["@FailedMessages"].Value = rows[i].FailedMessages;
                                        command.Parameters["@LastActionCode"].Value = rows[i].LastActionCode;
                                        command.Parameters["@LastAction"].Value = rows[i].LastAction;
                                        command.Parameters["@NextActionCode"].Value = rows[i].NextActionCode;
                                        command.Parameters["@NextTechId"].Value = rows[i].NextTechId;
                                        command.Parameters["@CntActionsTaken"].Value = rows[i].CntActionsTaken;
                                        command.Parameters["@LastNote"].Value = rows[i].LastNote;

                                        command.ExecuteNonQuery();
                                        cntInserts++;
                                    }
                                    retVal = cntInserts == rows.Count;
                                }
                                transaction.Commit();
                            }
                            catch (Exception exTxn)
                            {
                                L.ex(location, exTxn);
                            }
                        }

                    }
                    catch (Exception exConnect)
                    {
                        L.ex(location, exConnect);
                    }
                }
                if (query != null) query.queryMS += (DateTime.Now - dtInsertStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public static TestTable select(long id, bool useDbFunction)
        {
            const string location = CLASSNAME + ".select";
            TestTable retVal = new TestTable();
            try
            {
                //L.l(location, "Setting up connection.");
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        string sql = "";
                        if (useDbFunction)
                        {
                            sql = "SELECT GetTestTableById(@pTestId);";
                        }
                        else
                        {
                            sql = "SELECT * FROM TestTable WHERE TestId=" + id + ";";
                        }

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            if (useDbFunction)
                            {
                                command.Parameters.AddWithValue("pTestId", NpgsqlTypes.NpgsqlDbType.Bigint, id);
                            }
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                //L.l(location, "Starting read.");
                                while (reader.Read())
                                {
                                    retVal.TestId = reader["TestId"] == null ? retVal.TestId : Convert.ToInt64(reader["TestId"]);
                                    retVal.CDT = reader["CDT"] == null ? retVal.CDT : Convert.ToDateTime(reader["CDT"]);
                                    retVal.FID1 = reader["FID1"] == null ? retVal.FID1 : Convert.ToInt64(reader["FID1"]);
                                    retVal.FID2 = reader["FID2"] == null ? retVal.FID2 : Convert.ToInt64(reader["FID2"]);
                                    retVal.FID3 = reader["FID3"] == null ? retVal.FID3 : Convert.ToInt64(reader["FID3"]);
                                    retVal.Label = reader["Label"] == null ? "" : (string)reader["Label"];
                                    retVal.UnitNum = reader["UnitNum"] == null ? "" : (string)reader["UnitNum"];
                                    retVal.SerialNum = reader["SerialNum"] == null ? "" : (string)reader["SerialNum"];
                                    retVal.MfrId = reader["MfrId"] == null ? retVal.MfrId : Convert.ToInt64(reader["MfrId"]);
                                    retVal.MfrLocId = reader["MfrLocId"] == null ? retVal.MfrLocId : Convert.ToInt32(reader["MfrLocId"]);
                                    retVal.MachineId = reader["MachineId"] == null ? retVal.MachineId : Convert.ToInt32(reader["MachineId"]);
                                    retVal.Lot = reader["Lot"] == null ? retVal.Lot : Convert.ToInt32(reader["Lot"]);
                                    retVal.MfrDate = reader["MfrDate"] == null ? retVal.MfrDate : Convert.ToDateTime(reader["MfrDate"]);
                                    retVal.InstDate = reader["InstDate"] == null ? retVal.InstDate : Convert.ToDateTime(reader["InstDate"]);
                                    retVal.InstAddr1 = reader["InstAddr1"] == null ? "" : (string)reader["InstAddr1"];
                                    retVal.InstAddr2 = reader["InstAddr2"] == null ? "" : (string)reader["InstAddr2"];
                                    retVal.InstCity = reader["InstCity"] == null ? "" : (string)reader["InstCity"];
                                    retVal.InstCounty = reader["InstCounty"] == null ? "" : (string)reader["InstCounty"];
                                    retVal.InstProvince = reader["InstProvince"] == null ? "" : (string)reader["InstProvince"];
                                    retVal.InstState = reader["InstState"] == null ? "" : (string)reader["InstState"];
                                    retVal.InstCountry = reader["InstCountry"] == null ? "" : (string)reader["InstCountry"];
                                    retVal.LastChecked = reader["LastChecked"] == null ? retVal.LastChecked : Convert.ToDateTime(reader["LastChecked"]);
                                    retVal.LastModified = reader["LastModified"] == null ? retVal.LastModified : Convert.ToDateTime(reader["LastModified"]);
                                    retVal.LastReplaced = reader["LastReplaced"] == null ? retVal.LastReplaced : Convert.ToDateTime(reader["LastReplaced"]);
                                    retVal.LastTechId = reader["LastTechId"] == null ? retVal.LastTechId : Convert.ToInt64(reader["LastTechId"]);
                                    retVal.BillingDate = reader["BillingDate"] == null ? retVal.BillingDate : Convert.ToDateTime(reader["BillingDate"]);//testme - locale
                                    retVal.LastBillingDate = reader["LastBillingDate"] == null ? retVal.LastBillingDate : Convert.ToDateTime(reader["LastBillingDate"]);// locale
                                    retVal.Due = reader["Due"] == null ? retVal.Due : Convert.ToDouble(reader["Due"]);//real
                                    retVal.PastDue = reader["PastDue"] == null ? retVal.PastDue : Convert.ToDouble(reader["PastDue"]);//real
                                    retVal.LastDue = reader["LastDue"] == null ? retVal.LastDue : Convert.ToDouble(reader["LastDue"]);//real
                                    retVal.Something = reader["Something"] == null ? retVal.Something : Convert.ToDouble(reader["Something"]);//double
                                    retVal.isActive = reader["isActive"] == null ? retVal.isActive : Convert.ToBoolean(reader["isActive"]);//bool
                                    retVal.isOnline = reader["isOnline"] == null ? retVal.isOnline : Convert.ToBoolean(reader["isOnline"]);//bit
                                    retVal.LastOffline = reader["LastOffline"] == null ? retVal.LastOffline : Convert.ToDateTime(reader["LastOffline"]);//tzutc
                                    retVal.FailedMessages = reader["FailedMessages"] == null ? retVal.FailedMessages : Convert.ToInt64(reader["FailedMessages"]);
                                    retVal.LastActionCode = reader["LastActionCode"] == null ? "" : (string)reader["LastActionCode"];
                                    retVal.LastAction = reader["LastAction"] == null ? "" : (string)reader["LastAction"];
                                    retVal.NextActionCode = reader["NextActionCode"] == null ? "" : (string)reader["NextActionCode"];
                                    retVal.NextTechId = reader["NextTechId"] == null ? retVal.NextTechId : Convert.ToInt64(reader["NextTechId"]);
                                    retVal.CntActionsTaken = reader["CntActionsTaken"] == null ? retVal.CntActionsTaken : Convert.ToInt32(reader["CntActionsTaken"]);
                                    retVal.LastNote = reader["LastNote"] == null ? "" : (string)reader["LastNote"];

                                    break;
                                }
                                //L.l(location, "Finished reading.");
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
        }

        public static TestTable select(long id)
        {
            const string location = CLASSNAME + ".select";
            TestTable retVal = new TestTable();
            try
            {
                //L.l(location, "Setting up connection.");
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        string sql = "SELECT * FROM GetTestTableById(@pTestId)";

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            command.Parameters.AddWithValue("pTestId", NpgsqlTypes.NpgsqlDbType.Bigint, id);

                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                L.l(location, "Starting read, fields (" + reader.FieldCount + "), has rows (" + reader.HasRows + ").");
                                while (reader.Read())
                                {
                                    L.l(location, "Reading row for id (" + id + ").");
                                    //L.l(location, "String-0: " + reader.GetString(0));
                                    retVal.TestId = reader["TestId"] == null ? retVal.TestId : Convert.ToInt64(reader["TestId"]);
                                    retVal.CDT = reader["CDT"] == null ? retVal.CDT : Convert.ToDateTime(reader["CDT"]);
                                    retVal.FID1 = reader["FID1"] == null ? retVal.FID1 : Convert.ToInt64(reader["FID1"]);
                                    retVal.FID2 = reader["FID2"] == null ? retVal.FID2 : Convert.ToInt64(reader["FID2"]);
                                    retVal.FID3 = reader["FID3"] == null ? retVal.FID3 : Convert.ToInt64(reader["FID3"]);
                                    retVal.Label = reader["Label"] == null ? "" : (string)reader["Label"];
                                    retVal.UnitNum = reader["UnitNum"] == null ? "" : (string)reader["UnitNum"];
                                    retVal.SerialNum = reader["SerialNum"] == null ? "" : (string)reader["SerialNum"];
                                    retVal.MfrId = reader["MfrId"] == null ? retVal.MfrId : Convert.ToInt64(reader["MfrId"]);
                                    retVal.MfrLocId = reader["MfrLocId"] == null ? retVal.MfrLocId : Convert.ToInt32(reader["MfrLocId"]);
                                    retVal.MachineId = reader["MachineId"] == null ? retVal.MachineId : Convert.ToInt32(reader["MachineId"]);
                                    retVal.Lot = reader["Lot"] == null ? retVal.Lot : Convert.ToInt32(reader["Lot"]);
                                    retVal.MfrDate = reader["MfrDate"] == null ? retVal.MfrDate : Convert.ToDateTime(reader["MfrDate"]);
                                    retVal.InstDate = reader["InstDate"] == null ? retVal.InstDate : Convert.ToDateTime(reader["InstDate"]);
                                    retVal.InstAddr1 = reader["InstAddr1"] == null ? "" : (string)reader["InstAddr1"];
                                    retVal.InstAddr2 = reader["InstAddr2"] == null ? "" : (string)reader["InstAddr2"];
                                    retVal.InstCity = reader["InstCity"] == null ? "" : (string)reader["InstCity"];
                                    retVal.InstCounty = reader["InstCounty"] == null ? "" : (string)reader["InstCounty"];
                                    retVal.InstProvince = reader["InstProvince"] == null ? "" : (string)reader["InstProvince"];
                                    retVal.InstState = reader["InstState"] == null ? "" : (string)reader["InstState"];
                                    retVal.InstCountry = reader["InstCountry"] == null ? "" : (string)reader["InstCountry"];
                                    retVal.LastChecked = reader["LastChecked"] == null ? retVal.LastChecked : Convert.ToDateTime(reader["LastChecked"]);
                                    retVal.LastModified = reader["LastModified"] == null ? retVal.LastModified : Convert.ToDateTime(reader["LastModified"]);
                                    retVal.LastReplaced = reader["LastReplaced"] == null ? retVal.LastReplaced : Convert.ToDateTime(reader["LastReplaced"]);
                                    retVal.LastTechId = reader["LastTechId"] == null ? retVal.LastTechId : Convert.ToInt64(reader["LastTechId"]);
                                    retVal.BillingDate = reader["BillingDate"] == null ? retVal.BillingDate : Convert.ToDateTime(reader["BillingDate"]);//testme - locale
                                    retVal.LastBillingDate = reader["LastBillingDate"] == null ? retVal.LastBillingDate : Convert.ToDateTime(reader["LastBillingDate"]);// locale
                                    retVal.Due = reader["Due"] == null ? retVal.Due : Convert.ToDouble(reader["Due"]);//real
                                    retVal.PastDue = reader["PastDue"] == null ? retVal.PastDue : Convert.ToDouble(reader["PastDue"]);//real
                                    retVal.LastDue = reader["LastDue"] == null ? retVal.LastDue : Convert.ToDouble(reader["LastDue"]);//real
                                    retVal.Something = reader["Something"] == null ? retVal.Something : Convert.ToDouble(reader["Something"]);//double
                                    retVal.isActive = reader["isActive"] == null ? retVal.isActive : Convert.ToBoolean(reader["isActive"]);//bool
                                    BitArray baIsOnline = reader["isOnline"] == null ? null : (BitArray)reader["isOnline"];//bit
                                    retVal.isOnline = baIsOnline != null && baIsOnline.Count > 0 && baIsOnline[0];
                                    retVal.LastOffline = reader["LastOffline"] == null ? retVal.LastOffline : Convert.ToDateTime(reader["LastOffline"]);//tzutc
                                    retVal.FailedMessages = reader["FailedMessages"] == null ? retVal.FailedMessages : Convert.ToInt64(reader["FailedMessages"]);
                                    retVal.LastActionCode = reader["LastActionCode"] == null ? "" : (string)reader["LastActionCode"];
                                    retVal.LastAction = reader["LastAction"] == null ? "" : (string)reader["LastAction"];
                                    retVal.NextActionCode = reader["NextActionCode"] == null ? "" : (string)reader["NextActionCode"];
                                    retVal.NextTechId = reader["NextTechId"] == null ? retVal.NextTechId : Convert.ToInt64(reader["NextTechId"]);
                                    retVal.CntActionsTaken = reader["CntActionsTaken"] == null ? retVal.CntActionsTaken : Convert.ToInt32(reader["CntActionsTaken"]);
                                    retVal.LastNote = reader["LastNote"] == null ? "" : (string)reader["LastNote"];
                                    L.l(location, "Db Id (" + reader["TestId"] + ").");

                                    break;
                                }
                                L.l(location, "Finished reading.");
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
        }

        public static List<TestTable> select(List<long> ids, bool useDbFunction)
        {
            const string location = CLASSNAME + ".select";
            List<TestTable> retVal = new List<TestTable>();
            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        using (NpgsqlTransaction transaction = conn.BeginTransaction())
                        {

                            for (int i = 0; i < ids.Count; i++)
                            {

                                long id = ids[i];

                                string sql = "";
                                if (useDbFunction)
                                {
                                    //L.l(location, "Using DB Function.");
                                    sql = "SELECT * FROM GetTestTableById(@pTestId);";
                                }
                                else
                                {
                                    sql = "SELECT * FROM TestTable WHERE TestId=" + id + ";";
                                }

                                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                                {
                                    if (useDbFunction)
                                    {
                                        command.Parameters.AddWithValue("pTestId", id);
                                    }
                                    using (NpgsqlDataReader reader = command.ExecuteReader())
                                    {
                                        //L.l(location, "Starting read.");
                                        while (reader.Read())
                                        {
                                            TestTable row = new TestTable();
                                            row.TestId = reader["TestId"] == null ? row.TestId : Convert.ToInt64(reader["TestId"]);
                                            row.CDT = reader["CDT"] == null ? row.CDT : Convert.ToDateTime(reader["CDT"]);
                                            row.FID1 = reader["FID1"] == null ? row.FID1 : Convert.ToInt64(reader["FID1"]);
                                            row.FID2 = reader["FID2"] == null ? row.FID2 : Convert.ToInt64(reader["FID2"]);
                                            row.FID3 = reader["FID3"] == null ? row.FID3 : Convert.ToInt64(reader["FID3"]);
                                            row.Label = reader["Label"] == null ? "" : (string)reader["Label"];
                                            row.UnitNum = reader["UnitNum"] == null ? "" : (string)reader["UnitNum"];
                                            row.SerialNum = reader["SerialNum"] == null ? "" : (string)reader["SerialNum"];
                                            row.MfrId = reader["MfrId"] == null ? row.MfrId : Convert.ToInt64(reader["MfrId"]);
                                            row.MfrLocId = reader["MfrLocId"] == null ? row.MfrLocId : Convert.ToInt32(reader["MfrLocId"]);
                                            row.MachineId = reader["MachineId"] == null ? row.MachineId : Convert.ToInt32(reader["MachineId"]);
                                            row.Lot = reader["Lot"] == null ? row.Lot : Convert.ToInt32(reader["Lot"]);
                                            row.MfrDate = reader["MfrDate"] == null ? row.MfrDate : Convert.ToDateTime(reader["MfrDate"]);
                                            row.InstDate = reader["InstDate"] == null ? row.InstDate : Convert.ToDateTime(reader["InstDate"]);
                                            row.InstAddr1 = reader["InstAddr1"] == null ? "" : (string)reader["InstAddr1"];
                                            row.InstAddr2 = reader["InstAddr2"] == null ? "" : (string)reader["InstAddr2"];
                                            row.InstCity = reader["InstCity"] == null ? "" : (string)reader["InstCity"];
                                            row.InstCounty = reader["InstCounty"] == null ? "" : (string)reader["InstCounty"];
                                            row.InstProvince = reader["InstProvince"] == null ? "" : (string)reader["InstProvince"];
                                            row.InstState = reader["InstState"] == null ? "" : (string)reader["InstState"];
                                            row.InstCountry = reader["InstCountry"] == null ? "" : (string)reader["InstCountry"];
                                            row.LastChecked = reader["LastChecked"] == null ? row.LastChecked : Convert.ToDateTime(reader["LastChecked"]);
                                            row.LastModified = reader["LastModified"] == null ? row.LastModified : Convert.ToDateTime(reader["LastModified"]);
                                            row.LastReplaced = reader["LastReplaced"] == null ? row.LastReplaced : Convert.ToDateTime(reader["LastReplaced"]);
                                            row.LastTechId = reader["LastTechId"] == null ? row.LastTechId : Convert.ToInt64(reader["LastTechId"]);
                                            row.BillingDate = reader["BillingDate"] == null ? row.BillingDate : Convert.ToDateTime(reader["BillingDate"]);//testme - locale
                                            row.LastBillingDate = reader["LastBillingDate"] == null ? row.LastBillingDate : Convert.ToDateTime(reader["LastBillingDate"]);// locale
                                            row.Due = reader["Due"] == null ? row.Due : Convert.ToDouble(reader["Due"]);//real
                                            row.PastDue = reader["PastDue"] == null ? row.PastDue : Convert.ToDouble(reader["PastDue"]);//real
                                            row.LastDue = reader["LastDue"] == null ? row.LastDue : Convert.ToDouble(reader["LastDue"]);//real
                                            row.Something = reader["Something"] == null ? row.Something : Convert.ToDouble(reader["Something"]);//double
                                            row.isActive = reader["isActive"] == null ? row.isActive : Convert.ToBoolean(reader["isActive"]);//bool
                                                                                                                                             //row.isOnline = reader["isOnline"] == null ? row.isOnline : Convert.ToBoolean(reader["isOnline"]);//bit
                                            BitArray baIsOnline = reader["isOnline"] == null ? null : (BitArray)reader["isOnline"];//bit
                                            row.isOnline = baIsOnline != null && baIsOnline.Count > 0 && baIsOnline[0];
                                            row.LastOffline = reader["LastOffline"] == null ? row.LastOffline : Convert.ToDateTime(reader["LastOffline"]);//tzutc
                                            row.FailedMessages = reader["FailedMessages"] == null ? row.FailedMessages : Convert.ToInt64(reader["FailedMessages"]);
                                            row.LastActionCode = reader["LastActionCode"] == null ? "" : (string)reader["LastActionCode"];
                                            row.LastAction = reader["LastAction"] == null ? "" : (string)reader["LastAction"];
                                            row.NextActionCode = reader["NextActionCode"] == null ? "" : (string)reader["NextActionCode"];
                                            row.NextTechId = reader["NextTechId"] == null ? row.NextTechId : Convert.ToInt64(reader["NextTechId"]);
                                            row.CntActionsTaken = reader["CntActionsTaken"] == null ? row.CntActionsTaken : Convert.ToInt32(reader["CntActionsTaken"]);
                                            row.LastNote = reader["LastNote"] == null ? "" : (string)reader["LastNote"];

                                            retVal.Add(row);
                                            break;
                                        }
                                        //L.l(location, "Finished reading.");
                                    }
                                }
                            }
                            transaction.Commit();
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
        }


        public static bool update(TestTable row, bool useDbFunction)
        {
            const string location = CLASSNAME + ".update";
            bool retVal = false;
            try
            {
                if (row == null)
                {
                    L.err(location, "Input row was null.");
                    return retVal;
                }
                else if (row.TestId <= 0)
                {
                    L.err(location, "Input row id (" + row.TestId + ") was <= 0.");
                    return retVal;
                }


                string sql = "";
                if (useDbFunction)
                {
                    sql = "UPDATE TestTable " +
                        "FID1=@FID1, " +
                        "FID2=@FID2, " +
                        "FID3=@FID3, " +
                        "\"Label\"=@Label, " +
                        "UnitNum=@UnitNum, " +
                        "SerialNum=@SerialNum, " +
                        "MfrId=@MfrId, " +
                        "MfrLocId=@MfrLocId, " +
                        "MachineId=@MachineId, " +
                        "Lot=@Lot, " +
                        "MfrDate=@MfrDate, " +//dt
                        "InstDate=@InstDate, " +//dt
                        "InstAddr1=@InstAddr1, " +
                        "InstAddr2=@InstAddr2, " +
                        "InstCity=@InstCity, " +
                        "InstCounty=@InstCounty, " +
                        "InstProvince=@InstProvince, " +
                        "InstState=@InstState, " +
                        "InstCountry=@InstCountry, " +
                        "LastChecked=@LastChecked, " +//dt
                        "LastModified=@LastModified, " +//dt
                        "LastReplaced=@LastReplaced, " +//dt
                        "LastTechId=@LastTechId, " +
                        "BillingDate=@BillingDate, " +//dt
                        "LastBillingDate=@LastBillingDate, " +//dt
                        "Due=@Due, " +//real
                        "PastDue=@PastDue, " +//real
                        "LastDue=@LastDue, " +//real
                        "Something=@Something, " +//double
                        "isActive=@isActive, " +//bool
                        "isOnline=@isOnline, " +//bit
                        "LastOffline=@LastOffline, " +//tzutc
                        "FailedMessages=@FailedMessages, " +
                        "LastActionCode=@LastActionCode, " +
                        "LastAction=@LastAction, " +
                        "NextActionCode=@NextActionCode, " +
                        "NextTechId=@NextTechId, " +
                        "CntActionsTaken=@CntActionsTaken, " +
                        "LastNote=@LastNote " +

                        "WHERE TableId=@TableId;";
                }
                else
                {
                    sql =
                    "UPDATE TestTable SET " +

                    "FID1=" + row.FID1 + ", " +
                    "FID2=" + row.FID2 + ", " +
                    "FID3=" + row.FID3 + ", " +
                    "\"Label\"=" + (row.Label == null ? "NULL" : "\"" + row.Label + "\"") + ", " +
                    "UnitNum=" + (row.UnitNum == null ? "NULL" : "\"" + row.UnitNum + "\"") + ", " +
                    "SerialNum=" + (row.SerialNum == null ? "NULL" : "\"" + row.SerialNum + "\"") + ", " +
                    "MfrId=" + row.MfrId + ", " +
                    "MfrLocId=" + row.MfrLocId + ", " +
                    "MachineId=" + row.MachineId + ", " +
                    "Lot=" + row.Lot + ", " +
                    "MfrDate=" + (row.MfrDate == null ? "NULL" : "\"" + row.MfrDate.ToString(L.TAG.DTF) + "\"") + ", " +//tz
                    "InstDate=" + (row.InstDate == null ? "NULL" : "\"" + row.InstDate.ToString(L.TAG.DTF) + "\"") + ", " +//tz
                    "InstAddr1=" + (row.InstAddr1 == null ? "NULL" : "\"" + row.InstAddr1 + "\"") + ", " +
                    "InstAddr2=" + (row.InstAddr2 == null ? "NULL" : "\"" + row.InstAddr2 + "\"") + ", " +
                    "InstCity=" + (row.InstCity == null ? "NULL" : "\"" + row.InstCity + "\"") + ", " +
                    "InstCounty=" + (row.InstCountry == null ? "NULL" : "\"" + row.InstCounty + "\"") + ", " +
                    "InstProvince=" + (row.InstProvince == null ? "NULL" : "\"" + row.InstProvince + "\"") + ", " +
                    "InstState=" + (row.InstState == null ? "NULL" : "\"" + row.InstState + "\"") + ", " +
                    "InstCountry=" + (row.InstCountry == null ? "NULL" : "\"" + row.InstCountry + "\"") + ", " +
                    "LastChecked=" + (row.LastChecked == null ? "NULL" : "\"" + row.LastChecked + "\"") + ", " +//tz
                    "LastModified=" + (row.LastModified == null ? "NULL" : "\"" + row.LastModified.ToString(L.TAG.DTF) + "\"") + ", " +//tz
                    "LastReplaced=" + (row.LastReplaced == null ? "NULL" : "\"" + row.LastReplaced.ToString(L.TAG.DTF) + "\"") + ", " +//tz
                    "LastTechId=" + row.LastTechId + ", " +
                    "BillingDate=" + (row.BillingDate == null ? "NULL" : "\"" + row.BillingDate.ToString(L.TAG.DTF) + "\"") + ", " +//testme - locale
                    "LastBillingDate=" + (row.LastBillingDate == null ? "NULL" : "\"" + row.LastBillingDate.ToString(L.TAG.DTF) + "\"") + ", " +// locale
                    "Due=" + row.Due + ", " +//real
                    "PastDue=" + row.PastDue + ", " +//real
                    "LastDue=" + row.LastDue + ", " +//real
                    "Something=" + row.Something + ", " +//double
                    "isActive=" + row.isActive + ", " +//bool
                    "isOnline=" + row.isOnline + ", " +//bit
                    "LastOffline=" + (row.LastOffline == null ? "NULL" : "\"" + row.LastOffline.ToString(L.TAG.DTF) + "\"") + ", " +//tzutc
                    "FailedMessages=" + row.FailedMessages + ", " +
                    "LastActionCode=" + (row.LastActionCode == null ? "NULL" : "\"" + row.LastActionCode + "\"") + ", " +
                    "LastAction=" + (row.LastAction == null ? "NULL" : "\"" + row.LastAction + "\"") + ", " +
                    "NextActionCode=" + (row.NextActionCode == null ? "NULL" : "\"" + row.NextActionCode + "\"") + ", " +
                    "NextTechId=" + row.NextTechId + ", " +
                    "CntActionsTaken=" + row.CntActionsTaken + ", " +
                    "LastNote=" + (row.LastNote == null ? "NULL" : "\"" + row.LastNote + "\"") +

                    "WHERE TestId=" + row.TestId;
                }

                //L.l(location, "Setting up connection.");
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            if (useDbFunction)
                            {
                                command.Parameters.AddWithValue("@TestId", row.TestId);
                                command.Parameters.AddWithValue("@FID1", row.FID1);
                                command.Parameters.AddWithValue("@FID2", row.FID2);
                                command.Parameters.AddWithValue("@FID3", row.FID3);
                                command.Parameters.AddWithValue("@Label", row.Label);
                                command.Parameters.AddWithValue("@UnitNum", row.UnitNum);
                                command.Parameters.AddWithValue("@SerialNum", row.SerialNum);
                                command.Parameters.AddWithValue("@MfrId", row.MfrId);
                                command.Parameters.AddWithValue("@MfrLocId", row.MfrLocId);
                                command.Parameters.AddWithValue("@MachineId", row.MachineId);
                                command.Parameters.AddWithValue("@Lot", row.Lot);
                                command.Parameters.AddWithValue("@MfrDate", row.MfrDate);
                                command.Parameters.AddWithValue("@InstDate", row.InstDate);
                                command.Parameters.AddWithValue("@InstAddr1", row.InstAddr1);
                                command.Parameters.AddWithValue("@InstAddr2", row.InstAddr2);
                                command.Parameters.AddWithValue("@InstCity", row.InstCity);
                                command.Parameters.AddWithValue("@InstCounty", row.InstCounty);
                                command.Parameters.AddWithValue("@InstProvince", row.InstProvince);
                                command.Parameters.AddWithValue("@InstState", row.InstState);
                                command.Parameters.AddWithValue("@InstCountry", row.InstCountry);
                                command.Parameters.AddWithValue("@LastChecked", row.LastChecked);
                                command.Parameters.AddWithValue("@LastModified", row.LastModified);
                                command.Parameters.AddWithValue("@LastReplaced", row.LastReplaced);
                                command.Parameters.AddWithValue("@LastTechId", row.LastTechId);
                                command.Parameters.AddWithValue("@BillingDate", row.BillingDate);
                                command.Parameters.AddWithValue("@LastBillingDate", row.LastBillingDate);
                                command.Parameters.AddWithValue("@Due", row.Due);
                                command.Parameters.AddWithValue("@PastDue", row.PastDue);
                                command.Parameters.AddWithValue("@LastDue", row.LastDue);
                                command.Parameters.AddWithValue("@Something", row.Something);
                                command.Parameters.AddWithValue("@isActive", row.isActive);
                                command.Parameters.AddWithValue("@isOnline", row.isOnline);
                                command.Parameters.AddWithValue("@LastOffline", row.LastOffline);
                                command.Parameters.AddWithValue("@FailedMessages", row.FailedMessages);
                                command.Parameters.AddWithValue("@LastActionCode", row.LastActionCode);
                                command.Parameters.AddWithValue("@LastAction", row.LastAction);
                                command.Parameters.AddWithValue("@NextActionCode", row.NextActionCode);
                                command.Parameters.AddWithValue("@NextTechId", row.NextTechId);
                                command.Parameters.AddWithValue("@CntActionsTaken", row.CntActionsTaken);
                                command.Parameters.AddWithValue("@LastNote", row.LastNote);
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
        }

        public static bool query(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".query";
            bool retVal = false;
            try
            {
                // Basic query validation, does not account for caller reuse.
                if (query == null)
                {
                    query = new SQLWrapper();
                }
                if (query.parms == null) query.parms = new Dictionary<string, object>();
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                DateTime dtStart = DateTime.Now;

                StringBuilder sbParms = new StringBuilder(); ;
                if (query.parms != null)
                {
                    foreach (KeyValuePair<string, object> kv in query.parms)
                    {
                        if (kv.Key.Trim().Length == 0) continue;
                        if (sbParms.Length > 0) sbParms.Append(", ");
                        sbParms.Append("@" + kv.Key);
                    }
                }

                if (query.isDbFunction)
                {
                    // Modify the sql line to properly represent function parameters
                    query.sql = "SELECT * FROM " + query.sql + "(" + sbParms.ToString() + ");";
                }
                //L.l(location, "Executing query: " + query.sql);

                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    try
                    {
                        conn.Open();

                        using (NpgsqlCommand command = new NpgsqlCommand(query.sql, conn))
                        {
                            if (query.isDbFunction && query.parms != null)
                            {
                                foreach (KeyValuePair<string, object> kv in query.parms)
                                {
                                    if (kv.Key.Trim().Length == 0) continue;
                                    command.Parameters.AddWithValue(kv.Key, kv.Value);
                                    //L.l(location, "Searching id (" + kv.Value + ").");
                                }
                            }

                            List<string> fieldNames = new List<string>();

                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                //L.l(location, "Starting read.");
                                int count = 0;
                                while (reader.Read())
                                {
                                    // Get a list of field names to iterate
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        fieldNames.Add(reader.GetName(i));
                                    }

                                    Dictionary<string, object> row = new Dictionary<string, object>();
                                    int cntrFields = 0;
                                    for (int i = 0; i < fieldNames.Count; i++)
                                    {
                                        row.Add(fieldNames[i], reader[fieldNames[i]]);
                                        cntrFields++;
                                    }
                                    //L.l(location, "Added (" + cntrFields + ") fields to result object.");

                                    query.result.Add(row);
                                    count++;
                                }
                                //L.l(location, "Read (" + count + ") rows.");
                                retVal = true;
                            }
                        }
                    }
                    catch (Exception exConnect)
                    {
                        L.ex(location, exConnect);
                    }
                }
                query.queryMS += (DateTime.Now - dtStart).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }




        public static DateTime nextDt(int dtIdentifier)
        {
            const string location = CLASSNAME + ".nextDt";
            DateTime retVal = new DateTime();
            try
            {
                DateTime[] arr = null;
                int idx = -1;
                int incr = -1;
                switch (dtIdentifier)
                {
                    case 1:
                        arr = dates1;
                        idx = idxDates1;
                        incr = incrDates1;
                        break;
                    case 2:
                        arr = dates2;
                        idx = idxDates2;
                        incr = incrDates2;
                        break;
                    case 3:
                        arr = dates3;
                        idx = idxDates3;
                        incr = incrDates3;
                        break;
                    default:
                        L.err(location, "Unknown dates group (" + dtIdentifier + ").");
                        break;
                }
                if (arr == null)
                {
                    L.err(location, "Input array was null.");
                    return retVal;
                }
                if (idx < 0 || idx >= arr.Length)
                {
                    L.err(location, "Input index (" + idx + ") was out of bounds (0-" + arr.Length + ")");
                    return retVal;
                }
                if (incr < 1 || incr >= arr.Length)
                {
                    L.err(location, "Input increment (" + incr + ") was out of bounds (0-" + (arr.Length - 1) + ").");
                }


                // Move index to next
                idx += incr;
                if (idx >= arr.Length) idx -= arr.Length;

                // Iterate past any null values
                int cntr = 0;
                bool foundNext = false;
                while (!foundNext && cntr < arr.Length)
                {
                    if (arr[idx] != null)
                    {
                        retVal = arr[idx].ToUniversalTime();
                        foundNext = true;
                        continue;
                    }
                    else
                    {
                        idx += incr;
                        if (idx >= arr.Length) idx -= arr.Length;
                    }
                    cntr++;
                }

                // Update class level parms
                if (foundNext)
                {
                    switch (dtIdentifier)
                    {
                        case 1:
                            idxDates1 = idx;
                            incrDates1 = incr;
                            break;
                        case 2:
                            idxDates2 = idx;
                            incrDates2 = incr;
                            break;
                        case 3:
                            idxDates3 = idx;
                            incrDates3 = incr;
                            break;
                        default:
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

        public static double nextDoubleDollar()
        {
            const string location = CLASSNAME + ".nextDouble";
            double retVal = 0.0d;
            try
            {
                // These are mostly small numbers here, cap at 1200, make look like dues, fees, or amounts
                retVal = thr.Next(0, 1200) + Math.Round(thr.NextDouble(),2);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static TestTable ModelRow()
        {
            const string location = CLASSNAME + ".ModelRow";
            TestTable retVal = null;
            try
            {
                TestTable temp = new TestTable();
                temp.TestId = 0L;
                temp.CDT = nextDt(3);
                temp.FID1 = thr.Next();
                temp.FID2 = thr.Next();
                temp.FID3 = thr.Next();
                temp.Label = "";
                temp.UnitNum = "";
                temp.SerialNum = "";
                temp.MfrId = thr.Next();
                temp.MfrLocId = thr.Next(0, 50);
                temp.MachineId = thr.Next(0, 100);
                temp.Lot = thr.Next();
                temp.MfrDate = nextDt(3);
                temp.InstDate = nextDt(3);
                temp.InstAddr1 = thr.Next(0,9999) + " " + words[thr.Next(0, words.Length - 1)] + " " + words[thr.Next(0, words.Length - 1)];
                temp.InstAddr2 = words[thr.Next(0, words.Length - 1)] + " " + words[thr.Next(0, words.Length - 1)];
                temp.InstCity = words[thr.Next(0, words.Length - 1)];
                temp.InstCounty = words[thr.Next(0, words.Length - 1)];
                temp.InstProvince = words[thr.Next(0, words.Length - 1)];
                temp.InstState = words[thr.Next(0, words.Length - 1)];
                temp.InstCountry = words[thr.Next(0, words.Length - 1)];
                temp.LastChecked = nextDt(3);
                temp.LastModified = nextDt(3);
                temp.LastReplaced = temp.InstDate.ToUniversalTime();
                temp.LastTechId = thr.Next();
                temp.BillingDate = nextDt(1);//testme - locale
                temp.LastBillingDate = nextDt(2);// locale
                temp.Due = nextDoubleDollar();//real
                temp.PastDue = nextDoubleDollar();//real
                temp.LastDue = nextDoubleDollar();//real
                temp.Something = nextDoubleDollar(); ;//double
                temp.isActive = thr.NextDouble() > 0.80 ? false : true;//bool
                temp.isOnline = thr.NextDouble() > 0.99 ? false : true;//bit
                temp.LastOffline = nextDt(2);//tzutc
                temp.FailedMessages = thr.Next(0, 1999);
                temp.LastActionCode = codes[thr.Next(0, codes.Length - 1)];//vc4
                temp.LastAction = words[thr.Next(0, words.Length - 1)];
                temp.NextActionCode = codes[thr.Next(0, codes.Length - 1)];//vc4
                temp.NextTechId = thr.Next();
                temp.CntActionsTaken = thr.Next(0, 175);
                int noteLength = thr.NextDouble() > 0.75 ? thr.Next(10, 100) : 0;
                if (noteLength > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < noteLength; i++)
                    {
                        sb.Append(words[thr.Next(0, words.Length - 1)] + " ");
                    }
                    temp.LastNote = sb.ToString();
                    sb.Length = 0;
                }
                else temp.LastNote = "";

                // Output Result
                retVal = temp;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool ModelData(ref SQLWrapper query, int rows)
        {
            const string location = CLASSNAME + ".ModelData";
            bool retVal = false;
            try
            {
                // Basic query validation, does not account for caller reuse.
                if (query == null)
                {
                    query = new SQLWrapper();
                }
                if (query.parms == null) query.parms = new Dictionary<string, object>();
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                if (rows < 0 || rows > 100000000)
                {
                    L.err(location, "Requested row count (" + rows + ") out of bounds.");
                    return retVal;
                }

                int cntInserts = 0;
                int cntrLog = 0;
                for (int i = 0; i < rows;)
                {
                    List<TestTable> modelRows = new List<TestTable>();
                    for (int j = 0; j < 1000 && i < rows; j++, i++, cntrLog++)
                    {
                        modelRows.Add(ModelRow());
                    }
                    if (modelRows.Count == 0)
                    {
                        L.err(location, "Failed to package data set for db.");
                    }
                    else
                    {
                        // No loading, timestamp only
                        SQLWrapper temp = new SQLWrapper();

                        DateTime dtInsStart = DateTime.Now;
                        if (!insert(ref temp, modelRows))
                        {
                            L.err(location, "Failed to insert data set into db.");
                        }
                        else
                        {
                            cntInserts += modelRows.Count;
                        }
                        query.queryMS += temp.queryMS;
                    }
                    if (cntrLog >= 100000)
                    {
                        cntrLog = 0;
                        L.l(location, "Inserted record (" + i + ") of (" + rows + ").");
                    }
                }

                L.l(location, "Inserted (" + cntInserts + ") of (" + rows + ") rows.");

                retVal = cntInserts == rows;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool ModelSelect(ref SQLWrapper query, int rows, int minId, int maxId, bool isDbFunction)
        {
            const string location = CLASSNAME + ".ModelSelect";
            bool retVal = false;
            try
            {
                // Basic query validation, does not account for caller reuse.
                if (query == null)
                {
                    query = new SQLWrapper();
                }
                if (query.parms == null) query.parms = new Dictionary<string, object>();
                if (query.result == null) query.result = new List<Dictionary<string, object>>();

                DateTime dtGetIdsStart = DateTime.Now;
                if (maxId / 2 < rows)
                {
                    L.err(location, "Will not randomly grab more than half of max, select fewer rows.");
                    return retVal;
                }
                List<long> ids = new List<long>();
                Random r = new Random();
                r.Next(r.Next(r.Next()));

                for (int i = 0; ids.Count < rows; i++)
                {
                    long current = r.Next(minId, maxId);
                    if (ids.IndexOf(current) < 0)
                    {
                        ids.Add(current);
                        i++;
                    }
                }
                DateTime dtGetIdsEnd = DateTime.Now;
                L.l(location, "Generated (" + ids.Count + ") random ids in (" + (dtGetIdsEnd - dtGetIdsStart).TotalMilliseconds + "ms).");

                L.l(location, "Using " + (isDbFunction ? "db function" : "dynamic sql") + " to query.");

                L.l(location, "Selecting rows for (" + ids.Count + ") ids.");
                DateTime dtStart = DateTime.Now;
                List<TestTable> myRows = new List<TestTable>();


                // Select with generic helper
                for (int i = 0; i < ids.Count; i++)
                {
                    SQLWrapper temp = new SQLWrapper();
                    temp.isDbFunction = isDbFunction;
                    if (temp.isDbFunction)
                    {
                        temp.sql = "GetTestTableById";
                        temp.parms.Add("pTestId", ids[i]);
                    }
                    else 
                    {
                        temp.sql = "SELECT * FROM TestTable WHERE TestTable.TestId=" + ids[i] + ";";
                    }

                    if (!TestHelpers.query(ref temp))
                    {
                        continue;// Failure count will play out in final result
                    }

                    if (temp.result == null)
                    {
                        L.err(location, "Failed to acquire result from DB, null.");
                        continue;
                    }
                    if (temp.result.Count == 0)
                    {
                        L.err(location, "Result from DB was null.");
                        continue;
                    }
                    if (temp.result[0] == null)
                    {
                        L.err(location, "Result row was null.");
                        continue;
                    }
                    if (temp.result[0].Count == 0)
                    {
                        L.err(location, "Result row-0 was empty.");
                        continue;
                    }

                    query.result.Add(temp.result[0]);
                    query.queryMS += temp.queryMS;
                }

                // Select 1K rows at a time, aggregate result
                /*for (int i = 0; i < ids.Count; i += 1000)
                {
                    int limit = i + 1000 >= ids.Count ? ids.Count - i : 1000;
                    List<long> temp = new List<long>();
                    temp.AddRange(ids.GetRange(i, limit));
                    if (temp.Count == 0)
                    {
                        L.err(location, "Query returned empty.");
                        continue;
                    }
                    myRows.AddRange(select(temp, useDbFunction));
                }*/


                // Select single row
                /*List<TestTable> myRows = new List<TestTable>();
                for (int i = 0; i < ids.Count; i++)
                {
                    TestTable row = select(ids[i]);
                    //TestTable row = select(ids[i], useDbFunction);// False = dynamic sql, True = db function
                    if (row != null) myRows.Add(row);

                    //List<TestTable> res = select(ids, useDbFunction);
                    //if (res != null) myRows.AddRange(res);
                }*/


                DateTime dtEnd = DateTime.Now;
                L.l(location, "Finished selecting (" + query.result.Count + ") rows, out of (" + ids.Count + ") ids, and (" +
                    rows + ") requested, after (" + (dtEnd - dtStart).TotalMilliseconds + "ms).");
                /*L.l(location, "Finished selecting (" + myRows.Count + ") rows, out of (" + ids.Count + ") ids, and (" +
                    rows + ") requested, after (" + (dtEnd - dtStart).TotalMilliseconds + "ms).");*/

                retVal = query.result.Count == rows;


                // Debug
                /*for (int i = 0; i < myRows.Count; i += 100)
                {
                    if (myRows[i] == null) continue;
                    L.l(location, myRows[i].toString());
                }*/
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public static string ResultToHtml(ref SQLWrapper query)
        {
            const string location = CLASSNAME + ".ResultToHtml";
            string retVal = "";
            try
            {
                // Row-0 will give field headings, rows will be queried as-such,
                // missing keys will be empty, extra keys will be ignored. 
                if (query == null)
                {
                    retVal = "Input query was null.";
                    L.err(location, "Input query was null.");
                    return retVal;
                }
                if (query.result == null)
                {
                    retVal = "Table was null.";
                    L.err(location, "Input result was null.");
                    return retVal;
                }
                if (query.result.Count == 0)
                {
                    retVal = "Result was empty.";
                    return retVal;
                }

                StringBuilder sb = new StringBuilder();

                // Create a header and get field names
                List<string> fields = new List<string>();
                if (query.result.Count > 0 && query.result[0] != null)
                {
                    sb.Append((new TestTable(query.result[0])).toThTr());
                }

                // Add row data by field name
                for (int idxRow = 0; idxRow < query.result.Count && idxRow < 1000; idxRow++)
                {
                    if (query.result[idxRow] == null) continue;
                    sb.Append((new TestTable(query.result[idxRow])).toTr());
                }

                // If there is something to show, format HTML
                if (sb.Length > 0)
                {
                    retVal =
                        "<!DOCTYPE html>" +
                        "<head><title>none</title></head>" +
                        //"<head><title>none</title><style>.tbltd{white-space: nowrap; padding: 0, 5;}</style></head>" +
                        "<body>" +
                        //"<br />" +
                        "<p>Result Rows: " + query.result.Count +
                        (query.result.Count <= 1000 ? "" : "&nbsp;&nbsp;-&nbsp;&nbsp;Showing first 1000 rows.") + "</p>" +
                        "<p>Time ms: " + query.queryMS + "</p>" +
                        "<br /><br />" +
                        "<table>" +
                        sb.ToString() +
                        "</table>" +
                        "<br /><br />" +
                        "</body>" +
                        "</html>";
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
