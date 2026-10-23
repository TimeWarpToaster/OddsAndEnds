using System.Collections.Generic;

namespace DBTest
{
    public class SQLWrapper
    {
        public string sql = "";
        public string tableName = "";// Insert requires tableName & parms only

        public Dictionary<string, object> parms = new Dictionary<string, object>();
        public List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
        public bool isDbFunction = false;// Future use (MSSQL, MySQL)
        public double queryMS = 0d;
        public double responseFormatMS = 0d;
    }
}
