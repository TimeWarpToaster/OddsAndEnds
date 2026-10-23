using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;


namespace DBTest
{

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

                // Don't use this function as an example. Generally, you know what the field names
                // and return data look like. This is overdone to just handle it.

                int cntErrors = 0;

                if (inVals.ContainsKey("TestId") && inVals["TestId"] != null)
                    this.TestId = Convert.ToInt64(inVals["TestId"]);
                else if (inVals.ContainsKey("testid") && inVals["testid"] != null)
                    this.TestId = Convert.ToInt64(inVals["testid"]);
                else cntErrors++;

                {
                    object val = null;
                    if (inVals.ContainsKey("CDT") && inVals["CDT"] != null && inVals["CDT"] != DBNull.Value)
                        val = inVals["CDT"];
                    else if (inVals.ContainsKey("cdt") && inVals["cdt"] != null && inVals["cdt"] != DBNull.Value)
                        val = inVals["cdt"];
                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.CDT = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.CDT = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }
                
                if (inVals.ContainsKey("FID1") && inVals["FID1"] != null)
                    this.FID1 = Convert.ToInt64(inVals["FID1"]);
                else if (inVals.ContainsKey("fid1") && inVals["fid1"] != null)
                    this.FID1 = Convert.ToInt64(inVals["fid1"]);
                else cntErrors++;

                if (inVals.ContainsKey("FID2") && inVals["FID2"] != null)
                    this.FID2 = Convert.ToInt64(inVals["FID2"]);
                else if (inVals.ContainsKey("fid2") && inVals["fid2"] != null)
                    this.FID2 = Convert.ToInt64(inVals["fid2"]);
                else cntErrors++;

                if (inVals.ContainsKey("FID3") && inVals["FID3"] != null)
                    this.FID3 = Convert.ToInt64(inVals["FID3"]);
                else if (inVals.ContainsKey("fid3") && inVals["fid3"] != null)
                    this.FID3 = Convert.ToInt64(inVals["fid3"]);
                else cntErrors++;
                
                if (inVals.ContainsKey("Label") && inVals["Label"] != null)
                    this.Label = Convert.ToString(inVals["Label"]);
                else if (inVals.ContainsKey("label") && inVals["label"] != null)
                    this.Label = Convert.ToString(inVals["label"]);
                else cntErrors++;

                if (inVals.ContainsKey("UnitNum") && inVals["UnitNum"] != null)
                    this.UnitNum = Convert.ToString(inVals["UnitNum"]);
                else if (inVals.ContainsKey("unitnum") && inVals["unitnum"] != null)
                    this.UnitNum = Convert.ToString(inVals["unitnum"]);
                else cntErrors++;

                if (inVals.ContainsKey("SerialNum") && inVals["SerialNum"] != null)
                    this.SerialNum = Convert.ToString(inVals["SerialNum"]);
                else if (inVals.ContainsKey("serialnum") && inVals["serialnum"] != null)
                    this.SerialNum = Convert.ToString(inVals["serialnum"]);
                else cntErrors++;

                if (inVals.ContainsKey("MfrId") && inVals["MfrId"] != null)
                    this.MfrId = Convert.ToInt64(inVals["MfrId"]);
                else if (inVals.ContainsKey("mfrid") && inVals["mfrid"] != null)
                    this.MfrId = Convert.ToInt64(inVals["mfrid"]);
                else cntErrors++;

                if (inVals.ContainsKey("MfrLocId") && inVals["MfrLocId"] != null)
                    this.MfrLocId = Convert.ToInt32(inVals["MfrLocId"]);
                else if (inVals.ContainsKey("mfrlocid") && inVals["mfrlocid"] != null)
                    this.MfrLocId = Convert.ToInt32(inVals["mfrlocid"]);
                else cntErrors++;

                if (inVals.ContainsKey("MachineId") && inVals["MachineId"] != null)
                    this.MachineId = Convert.ToInt32(inVals["MachineId"]);
                else if (inVals.ContainsKey("machineid") && inVals["machineid"] != null)
                    this.MachineId = Convert.ToInt32(inVals["machineid"]);
                else cntErrors++;

                if (inVals.ContainsKey("Lot") && inVals["Lot"] != null)
                    this.Lot = Convert.ToInt32(inVals["Lot"]);
                else if (inVals.ContainsKey("lot") && inVals["lot"] != null)
                    this.Lot = Convert.ToInt32(inVals["lot"]);
                else cntErrors++;

                //L.l(location, "Processing MfrDate");
                /*object oMfrDate = null;
                if (inVals.ContainsKey("MfrDate") && inVals["MfrDate"] != null && inVals["MfrDate"] != DBNull.Value)
                {
                    try
                    {
                        string s = Convert.ToString(inVals["MfrDate"]);
                        this.MfrDate = DateTime.Parse(s);
                    }
                    catch (Exception exConv) { }
                }
                    //this.MfrDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["MfrDate"]).DateTime;
                else if (inVals.ContainsKey("mfrdate") && inVals["mfrdate"] != null && inVals["mfrdate"] != DBNull.Value)
                {
                    try
                    {
                        string s = Convert.ToString(inVals["mfrdate"]);
                        this.MfrDate = DateTime.Parse(s);
                    }
                    catch (Exception exConv) { }
                }
                //this.MfrDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["mfrdate"]).DateTime;*/

                
                {
                    object val = null;
                    if (inVals.ContainsKey("MfrDate") && inVals["MfrDate"] != null && inVals["MfrDate"] != DBNull.Value)
                        val = inVals["MfrDate"];
                    else if (inVals.ContainsKey("mfrdate") && inVals["mfrdate"] != null && inVals["mfrdate"] != DBNull.Value)
                        val = inVals["mfrdate"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.MfrDate = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.MfrDate = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                /*if (inVals.ContainsKey("InstDate") && inVals["InstDate"] != null && inVals["InstDate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["InstDate"]);
                    this.InstDate = DateTime.Parse(s);
                }
                    //this.InstDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["InstDate"]).DateTime;
                else if (inVals.ContainsKey("instdate") && inVals["instdate"] != null && inVals["instdate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["instdate"]);
                    this.InstDate = DateTime.Parse(s);
                }
                //this.InstDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["instdate"]).DateTime;
                else cntErrors++;*/

                {
                    object val = null;
                    if (inVals.ContainsKey("InstDate") && inVals["InstDate"] != null && inVals["InstDate"] != DBNull.Value)
                        val = inVals["InstDate"];
                    else if (inVals.ContainsKey("instdate") && inVals["instdate"] != null && inVals["instdate"] != DBNull.Value)
                        val = inVals["instdate"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.InstDate = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.InstDate = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                if (inVals.ContainsKey("InstAddr1") && inVals["InstAddr1"] != null)
                    this.InstAddr1 = Convert.ToString(inVals["InstAddr1"]);
                else if (inVals.ContainsKey("instaddr1") && inVals["instaddr1"] != null)
                    this.InstAddr1 = Convert.ToString(inVals["instaddr1"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstAddr2") && inVals["InstAddr2"] != null)
                    this.InstAddr2 = Convert.ToString(inVals["InstAddr2"]);
                else if (inVals.ContainsKey("instaddr2") && inVals["instaddr2"] != null)
                    this.InstAddr2 = Convert.ToString(inVals["instaddr2"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstCity") && inVals["InstCity"] != null)
                    this.InstCity = Convert.ToString(inVals["InstCity"]);
                else if (inVals.ContainsKey("instcity") && inVals["instcity"] != null)
                    this.InstCity = Convert.ToString(inVals["instcity"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstCounty") && inVals["InstCounty"] != null)
                    this.InstCounty = Convert.ToString(inVals["InstCounty"]);
                else if (inVals.ContainsKey("instcounty") && inVals["instcounty"] != null)
                    this.InstCounty = Convert.ToString(inVals["instcounty"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstProvince") && inVals["InstProvince"] != null)
                    this.InstProvince = Convert.ToString(inVals["InstProvince"]);
                else if (inVals.ContainsKey("instprovince") && inVals["instprovince"] != null)
                    this.InstProvince = Convert.ToString(inVals["instprovince"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstState") && inVals["InstState"] != null)
                    this.InstState = Convert.ToString(inVals["InstState"]);
                else if (inVals.ContainsKey("inststate") && inVals["inststate"] != null)
                    this.InstState = Convert.ToString(inVals["inststate"]);
                else cntErrors++;

                if (inVals.ContainsKey("InstCountry") && inVals["InstCountry"] != null)
                    this.InstCountry = Convert.ToString(inVals["InstCountry"]);
                else if (inVals.ContainsKey("instcountry") && inVals["instcountry"] != null)
                    this.InstCountry = Convert.ToString(inVals["instcountry"]);
                else cntErrors++;

                /*//L.l(location, "Processing LastChecked");
                if (inVals.ContainsKey("LastChecked") && inVals["LastChecked"] != null && inVals["LastChecked"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["LastChecked"]);
                    this.LastChecked = DateTime.Parse(s);
                }
                //this.LastChecked = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["LastChecked"]).DateTime;
                else if (inVals.ContainsKey("lastchecked") && inVals["lastchecked"] != null && inVals["lastchecked"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["lastchecked"]);
                    this.LastChecked = DateTime.Parse(s);
                }
                //this.LastChecked = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["lastchecked"]).DateTime;
                else cntErrors++;*/

                //L.l(location, "Processing LastChecked");
                {
                    object val = null;
                    if (inVals.ContainsKey("LastChecked") && inVals["LastChecked"] != null && inVals["LastChecked"] != DBNull.Value)
                        val = inVals["LastChecked"];
                    else if (inVals.ContainsKey("lastchecked") && inVals["lastchecked"] != null && inVals["lastchecked"] != DBNull.Value)
                        val = inVals["lastchecked"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.LastChecked = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.LastChecked = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }


                /*//L.l(location, "Processing LastModified");
                if (inVals.ContainsKey("LastModified") && inVals["LastModified"] != null && inVals["LastModified"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["LastModified"]);
                    this.LastModified = DateTime.Parse(s);
                }
                //this.LastModified = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["LastModified"]).DateTime;
                else if (inVals.ContainsKey("lastmodified") && inVals["lastmodified"] != null && inVals["lastmodified"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["lastmodified"]);
                    this.LastModified = DateTime.Parse(s);
                }
                //this.LastModified = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["lastmodified"]).DateTime;
                else cntErrors++;*/

                {
                    object val = null;
                    if (inVals.ContainsKey("LastModified") && inVals["LastModified"] != null && inVals["LastModified"] != DBNull.Value)
                        val = inVals["LastModified"];
                    else if (inVals.ContainsKey("lastmodified") && inVals["lastmodified"] != null && inVals["lastmodified"] != DBNull.Value)
                        val = inVals["lastmodified"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.LastModified = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.LastModified = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                
                /*//L.l(location, "Processing LastReplaced");
                if (inVals.ContainsKey("LastReplaced") && inVals["LastReplaced"] != null && inVals["LastReplaced"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["LastReplaced"]);
                    this.LastReplaced = DateTime.Parse(s);
                }
                //this.LastReplaced = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["LastReplaced"]).DateTime;
                else if (inVals.ContainsKey("lastreplaced") && inVals["lastreplaced"] != null && inVals["lastreplaced"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["lastreplaced"]);
                    this.LastReplaced = DateTime.Parse(s);
                }
                //this.LastReplaced = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["lastreplaced"]).DateTime;
                else cntErrors++;*/
                {
                    object val = null;
                    if (inVals.ContainsKey("LastReplaced") && inVals["LastReplaced"] != null && inVals["LastReplaced"] != DBNull.Value)
                        val = inVals["LastReplaced"];
                    else if (inVals.ContainsKey("lastreplaced") && inVals["lastreplaced"] != null && inVals["lastreplaced"] != DBNull.Value)
                        val = inVals["lastreplaced"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.LastReplaced = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.LastReplaced = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                if (inVals.ContainsKey("LastTechId") && inVals["LastTechId"] != null)
                    this.LastTechId = Convert.ToInt64(inVals["LastTechId"]);
                else if (inVals.ContainsKey("lasttechid") && inVals["lasttechid"] != null)
                    this.LastTechId = Convert.ToInt64(inVals["lasttechid"]);
                else cntErrors++;

                /*//L.l(location, "Processing BillingDate");
                if (inVals.ContainsKey("BillingDate") && inVals["BillingDate"] != null && inVals["BillingDate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["BillingDate"]);
                    this.BillingDate = DateTime.Parse(s);
                }
                //this.BillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["BillingDate"]).DateTime;
                else if (inVals.ContainsKey("billingdate") && inVals["billingdate"] != null && inVals["billingdate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["billingdate"]);
                    this.BillingDate = DateTime.Parse(s);
                }
                //this.BillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["billingdate"]).DateTime;
                else cntErrors++;*/

                {
                    object val = null;
                    if (inVals.ContainsKey("BillingDate") && inVals["BillingDate"] != null && inVals["BillingDate"] != DBNull.Value)
                        val = inVals["BillingDate"];
                    else if (inVals.ContainsKey("billingdate") && inVals["billingdate"] != null && inVals["billingdate"] != DBNull.Value)
                        val = inVals["billingdate"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.BillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.BillingDate = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                /*if (inVals.ContainsKey("LastBillingDate") && inVals["LastBillingDate"] != null && inVals["LastBillingDate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["LastBillingDate"]);
                    this.LastBillingDate = DateTime.Parse(s);
                }
                //this.LastBillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["LastBillingDate"]).DateTime;
                else if (inVals.ContainsKey("lastbillingdate") && inVals["lastbillingdate"] != null && inVals["lastbillingdate"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["lastbillingdate"]);
                    this.LastBillingDate = DateTime.Parse(s);
                }
                //this.LastBillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["lastbillingdate"]).DateTime;
                else cntErrors++;*/

                {
                    object val = null;
                    if (inVals.ContainsKey("LastBillingDate") && inVals["LastBillingDate"] != null && inVals["LastBillingDate"] != DBNull.Value)
                        val = inVals["LastBillingDate"];
                    else if (inVals.ContainsKey("lastbillingdate") && inVals["lastbillingdate"] != null && inVals["lastbillingdate"] != DBNull.Value)
                        val = inVals["lastbillingdate"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.LastBillingDate = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.LastBillingDate = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                //L.l(location, "Processing Due");
                if (inVals.ContainsKey("Due") && inVals["Due"] != null)
                    this.Due = Convert.ToDouble(inVals["Due"]);
                else if (inVals.ContainsKey("due") && inVals["due"] != null)
                    this.Due = Convert.ToDouble(inVals["due"]);
                else cntErrors++;

                //L.l(location, "Processing PastDue");
                if (inVals.ContainsKey("PastDue") && inVals["PastDue"] != null)
                    this.PastDue = Convert.ToDouble(inVals["PastDue"]);
                else if (inVals.ContainsKey("pastdue") && inVals["pastdue"] != null)
                    this.PastDue = Convert.ToDouble(inVals["pastdue"]);
                else cntErrors++;

                //L.l(location, "Processing LastDue");
                if (inVals.ContainsKey("LastDue") && inVals["LastDue"] != null)
                    this.LastDue = Convert.ToDouble(inVals["LastDue"]);
                else if (inVals.ContainsKey("lastdue") && inVals["lastdue"] != null)
                    this.LastDue = Convert.ToDouble(inVals["lastdue"]);
                else cntErrors++;

                //L.l(location, "Processing Something");
                if (inVals.ContainsKey("Something") && inVals["Something"] != null)
                    this.Something = Convert.ToDouble(inVals["Something"]);
                else if (inVals.ContainsKey("something") && inVals["something"] != null)
                    this.Something = Convert.ToDouble(inVals["something"]);
                else cntErrors++;

                //L.l(location, "Processing IsActive");
                if (inVals.ContainsKey("IsActive") && inVals["IsActive"] != null)
                    this.isActive = Convert.ToBoolean(inVals["IsActive"]);
                else if (inVals.ContainsKey("isactive") && inVals["isactive"] != null)
                    this.isActive = Convert.ToBoolean(inVals["isactive"]);
                else cntErrors++;

                //L.l(location, "Processing IsOnline");
                if (inVals.ContainsKey("IsOnline") && inVals["IsOnline"] != null)
                {
                    if (inVals["IsOnline"].GetType() == typeof(BitArray))
                    {
                        BitArray ba = (BitArray)inVals["IsOnline"];
                        this.isOnline = ba != null && ba.Count > 0 ? ba[0] : false;
                    }
                    else
                    {
                        this.isOnline = Convert.ToBoolean(inVals["IsOnline"]);
                    }
                }
                else if (inVals.ContainsKey("isonline") && inVals["isonline"] != null)
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

                /*//L.l(location, "Processing LastOffline");
                if (inVals.ContainsKey("LastOffline") && inVals["LastOffline"] != null && inVals["LastOffline"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["LastOffline"]);
                    this.LastOffline = DateTime.Parse(s);
                }
                //this.LastOffline = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["LastOffline"]).DateTime;
                else if (inVals.ContainsKey("lastoffline") && inVals["lastoffline"] != null && inVals["lastoffline"] != DBNull.Value)
                {
                    string s = Convert.ToString(inVals["lastoffline"]);
                    this.LastOffline = DateTime.Parse(s);
                }
                //this.LastOffline = DateTimeOffset.FromUnixTimeMilliseconds((long)inVals["lastoffline"]).DateTime;
                else cntErrors++;*/

                {
                    object val = null;
                    //L.l(location, "Processing LastOffline");
                    if (inVals.ContainsKey("LastOffline") && inVals["LastOffline"] != null && inVals["LastOffline"] != DBNull.Value)
                        val = inVals["LastOffline"];
                    else if (inVals.ContainsKey("lastoffline") && inVals["lastoffline"] != null && inVals["lastoffline"] != DBNull.Value)
                        val = inVals["lastoffline"];

                    if (val != null)
                    {
                        try
                        {
                            if (val.GetType() == typeof(long))
                            {
                                this.LastOffline = DateTimeOffset.FromUnixTimeMilliseconds((long)val).DateTime;
                            }
                            else
                            {
                                string s = Convert.ToString(val);
                                this.LastOffline = DateTime.Parse(s);
                            }
                        }
                        catch (Exception exConv) { }
                    }
                    else cntErrors++;
                }

                if (inVals.ContainsKey("FailedMessages") && inVals["FailedMessages"] != null)
                    this.FailedMessages = Convert.ToInt64(inVals["FailedMessages"]);
                else if (inVals.ContainsKey("failedmessages") && inVals["failedmessages"] != null)
                    this.FailedMessages = Convert.ToInt64(inVals["failedmessages"]);
                else cntErrors++;

                if (inVals.ContainsKey("LastActionCode") && inVals["LastActionCode"] != null)
                    this.LastActionCode = Convert.ToString(inVals["LastActionCode"]);
                else if (inVals.ContainsKey("lastactioncode") && inVals["lastactioncode"] != null)
                    this.LastActionCode = Convert.ToString(inVals["lastactioncode"]);
                else cntErrors++;

                if (inVals.ContainsKey("LastAction") && inVals["LastAction"] != null)
                    this.LastAction = Convert.ToString(inVals["LastAction"]);
                else if (inVals.ContainsKey("lastaction") && inVals["lastaction"] != null)
                    this.LastAction = Convert.ToString(inVals["lastaction"]);
                else cntErrors++;

                if (inVals.ContainsKey("NextActionCode") && inVals["NextActionCode"] != null)
                    this.NextActionCode = Convert.ToString(inVals["NextActionCode"]);
                else if (inVals.ContainsKey("nextactioncode") && inVals["nextactioncode"] != null)
                    this.NextActionCode = Convert.ToString(inVals["nextactioncode"]);
                else cntErrors++;

                if (inVals.ContainsKey("NextTechId") && inVals["NextTechId"] != null)
                    this.NextTechId = Convert.ToInt64(inVals["NextTechId"]);
                else if (inVals.ContainsKey("nexttechid") && inVals["nexttechid"] != null)
                    this.NextTechId = Convert.ToInt64(inVals["nexttechid"]);
                else cntErrors++;

                if (inVals.ContainsKey("CntActionsTaken") && inVals["CntActionsTaken"] != null)
                    this.CntActionsTaken = Convert.ToInt32(inVals["CntActionsTaken"]);
                else if (inVals.ContainsKey("cntactionstaken") && inVals["cntactionstaken"] != null)
                    this.CntActionsTaken = Convert.ToInt32(inVals["cntactionstaken"]);
                else cntErrors++;

                if (inVals.ContainsKey("LastNote") && inVals["LastNote"] != null)
                    this.LastNote = Convert.ToString(inVals["LastNote"]);
                else if (inVals.ContainsKey("lastnote") && inVals["lastnote"] != null)
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

        public Dictionary<string, object> toInsertParms()
        {
            const string location = CLASSNAME + ".toInsertParms";
            Dictionary<string, object> retVal = new Dictionary<string, object>();
            try
            {
                DB.Engine engine = DB.engine();
                bool isUnixMs = engine == DB.Engine.SQLITE;

                Dictionary<string, object> temp = new Dictionary<string, object>();
                temp.Add("FID1", this.FID1);
                temp.Add("FID2", this.FID2);
                temp.Add("FID3", this.FID3);
                temp.Add("Label", this.Label);
                temp.Add("UnitNum", this.UnitNum);
                temp.Add("SerialNum", this.SerialNum);
                temp.Add("MfrId", this.MfrId);
                temp.Add("MfrLocId", this.MfrLocId);
                temp.Add("MachineId", this.MachineId);
                temp.Add("Lot", this.Lot);
                if (isUnixMs)
                {
                    temp.Add("MfrDate", ((DateTimeOffset)this.MfrDate).ToUnixTimeMilliseconds());
                    temp.Add("InstDate", ((DateTimeOffset)this.InstDate).ToUnixTimeMilliseconds());
                }
                else
                {
                    temp.Add("MfrDate", this.MfrDate);
                    temp.Add("InstDate", this.InstDate);
                }
                temp.Add("InstAddr1", this.InstAddr1);
                temp.Add("InstAddr2", this.InstAddr2);
                temp.Add("InstCity", this.InstCity);
                temp.Add("InstCounty", this.InstCounty);
                temp.Add("InstProvince", this.InstProvince);
                temp.Add("InstState", this.InstState);
                temp.Add("InstCountry", this.InstCountry);
                if (isUnixMs)
                {
                    temp.Add("LastChecked", ((DateTimeOffset)this.LastChecked).ToUnixTimeMilliseconds());
                    temp.Add("LastModified", ((DateTimeOffset)this.LastModified).ToUnixTimeMilliseconds());
                    temp.Add("LastReplaced", ((DateTimeOffset)this.LastReplaced).ToUnixTimeMilliseconds());
                }
                else
                {
                    temp.Add("LastChecked", this.LastChecked);
                    temp.Add("LastModified", this.LastModified);
                    temp.Add("LastReplaced", this.LastReplaced);
                }
                temp.Add("LastTechId", this.LastTechId);
                if (isUnixMs)
                {
                    temp.Add("BillingDate", ((DateTimeOffset)this.BillingDate).ToUnixTimeMilliseconds());
                    temp.Add("LastBillingDate", ((DateTimeOffset)this.LastBillingDate).ToUnixTimeMilliseconds());
                }
                else
                {
                    temp.Add("BillingDate", this.BillingDate);
                    temp.Add("LastBillingDate", this.LastBillingDate);
                }
                temp.Add("Due", this.Due);
                temp.Add("PastDue", this.PastDue);
                temp.Add("LastDue", this.LastDue);
                temp.Add("Something", this.Something);
                temp.Add("IsActive", this.isActive);
                temp.Add("IsOnline", this.isOnline);
                if (isUnixMs)
                {
                    temp.Add("LastOffline", ((DateTimeOffset)this.LastOffline).ToUnixTimeMilliseconds());
                }
                else
                {
                    temp.Add("LastOffline", this.LastOffline);
                }
                temp.Add("FailedMessages", this.FailedMessages);
                temp.Add("LastActionCode", this.LastActionCode);
                temp.Add("LastAction", this.LastAction);
                temp.Add("NextActionCode", this.NextActionCode);
                temp.Add("NextTechId", this.NextTechId);
                temp.Add("CntActionsTaken", this.CntActionsTaken);
                temp.Add("LastNote", this.LastNote);

                retVal = temp;
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
        

        public static DateTime[] dates1 = new DateTime[30];// sequential last 30
        public static DateTime[] dates2 = new DateTime[30];// sequential mo. before
        public static DateTime[] dates3 = new DateTime[30];// random dates last year

        private static int idxDates1 = -1;
        private static int idxDates2 = -1;
        private static int idxDates3 = -1;

        private static int incrDates1 = 1;
        private static int incrDates2 = 1;
        private static int incrDates3 = 1;

        private static Random thr = new Random();

        private static string[] words = new string[0];

        private static string[] codes = new string[0];

        private static char[] chars = new char[0];


        public static bool init()
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                int cntErrors = 0;

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

                /*incrDates1 = r.Next(1, dates1.Length - 1);
                incrDates2 = r.Next(1, dates2.Length - 1);
                incrDates3 = r.Next(1, dates3.Length - 1);*/


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

                chars = new char[]
                {
                    'A','B','C','D','E','F','G','H','I','J','K','L','M',
                    'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                    '0','1','2','3','4','5','6','7','8','9','-'
                };


                // Output Result
                retVal = cntErrors == 0;
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

                if (retVal == (new DateTime()).ToUniversalTime())
                {
                    L.err(location, "Generated an invalid datetime.");
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
                retVal = thr.Next(0, 1200) + Math.Round(thr.NextDouble(), 2);
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
                temp.Label = words[thr.Next(0, words.Length - 1)];
                temp.UnitNum = randomString(20);
                temp.SerialNum = randomString(40);
                temp.MfrId = thr.Next();
                temp.MfrLocId = thr.Next(0, 50);
                temp.MachineId = thr.Next(0, 100);
                temp.Lot = thr.Next();
                temp.MfrDate = nextDt(3);
                temp.InstDate = nextDt(3);
                temp.InstAddr1 = thr.Next(0, 9999) + " " + words[thr.Next(0, words.Length - 1)] + " " + words[thr.Next(0, words.Length - 1)];
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
                        temp.sql = "SELECT * FROM TestTable WHERE TestTable.TestId=@TestId";
                        temp.parms.Add("TestId", ids[i]);
                    }
                    else
                    {
                        temp.sql = "SELECT * FROM TestTable WHERE TestTable.TestId=" + ids[i] + ";";
                    }

                    if (!DB.que(ref temp))
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


        public static string randomString(int length)
        {
            const string location = CLASSNAME + ".randomString";
            string retVal = "";
            try
            {
                if (chars == null || chars.Length == 0)
                {
                    L.err(location, "Chars array not initialized at random string create.");
                    return retVal;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                    sb.Append(chars[thr.Next(0, chars.Length - 1)]);
                retVal = sb.ToString();
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
