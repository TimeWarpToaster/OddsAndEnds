using System;
using System.Configuration;
using System.Linq;

namespace DBTest
{
    public static class AppConfig
    {
        private const string fkLoc = "AppConfig.Get(key)";
        public static string Get(string key)
        {
            string retValue = "";
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
                {
                    return retValue;
                }
                retValue = ConfigurationManager.AppSettings[key];
                if (retValue == null) retValue = "";
            }
            catch (Exception ex)
            {
                L.ex(fkLoc, ex);
            }
            return retValue;
        }


        private const string fkbLoc = "AppConfig.Get(key,bool)";
        public static bool Get(string key, bool defualtValue)
        {
            try
            {
                string temp = Get(key);
                if (!string.IsNullOrEmpty(temp)) return Convert.ToBoolean(temp);
            }
            catch (Exception ex)
            {
                L.ex(fkbLoc, ex);
            }
            return defualtValue;
        }


        private const string fkiLoc = "AppConfig.Get(key,int)";
        public static int Get(string key, int defualtValue)
        {
            try
            {
                string temp = Get(key);
                if (!string.IsNullOrEmpty(temp)) return Convert.ToInt32(temp);
            }
            catch (Exception ex)
            {
                L.ex(fkiLoc, ex);
            }
            return defualtValue;
        }


        private const string fkdLoc = "AppConfig.Get(key,long)";
        public static long Get(string key, long defualtValue)
        {
            try
            {
                string temp = Get(key);
                if (!string.IsNullOrEmpty(temp)) return Convert.ToInt64(temp);
            }
            catch (Exception ex)
            {
                L.ex(fkdLoc, ex);
            }
            return defualtValue;
        }


        private const string fksLoc = "AppConfig.Get(key,string)";
        public static string Get(string key, string defualtValue)
        {
            string retValue = defualtValue;
            try
            {
                retValue = Get(key);
                if (string.IsNullOrEmpty(retValue)) return defualtValue;
            }
            catch (Exception ex)
            {
                L.ex(fksLoc, ex);
            }
            return retValue;
        }
    }
}
