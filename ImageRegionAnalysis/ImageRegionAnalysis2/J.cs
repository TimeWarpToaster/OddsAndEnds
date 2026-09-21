using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace ImageRegionAnalysis2
{
    public static class J
    {
        public const string CLASSNAME = "J";



        public static JArray fromList(List<double> ls)
        {

            JArray retVal = new JArray();
            if (ls != null)
                for (int i = 0; i < ls.Count; i++)
                    retVal.Add(ls[i]);
            return retVal;
        }

        public static JArray fromList(List<int> ls)
        {

            JArray retVal = new JArray();
            if (ls != null)
                for (int i = 0; i < ls.Count; i++)
                    retVal.Add(ls[i]);
            return retVal;
        }

        public static List<double> toList(JArray jarr, double defaultVal)
        {
            const string location = CLASSNAME + ".to";
            List<double> retVal = null;
            try
            {
                if (jarr == null)
                {
                    //L.err(location, "Input array was null.");
                    return retVal;
                }

                retVal = new List<double>();
                for (int i = 0; i < jarr.Count; i++)
                {
                    if (jarr[i] == null) retVal.Add(defaultVal);
                    try
                    {
                        int temp = Convert.ToInt32(jarr[i]);
                        retVal.Add(temp);
                    }
                    catch (Exception exConv)
                    {
                        retVal.Add(defaultVal);
                    }
                }
                //if (retVal.Count != jarr.Count) L.err(location, "Copied (" + retVal.Count + ") of (" + jarr.Count + ") items.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static List<int> toList(JArray jarr, int defaultVal)
        {
            const string location = CLASSNAME + ".to";
            List<int> retVal = null;
            try
            {
                if (jarr == null)
                {
                    //L.err(location, "Input array was null.");
                    return retVal;
                }
                
                retVal = new List<int>();
                for (int i = 0; i < jarr.Count; i++)
                {
                    if (jarr[i] == null) retVal.Add(defaultVal);
                    try
                    {
                        int temp = Convert.ToInt32(jarr[i]);
                        retVal.Add(temp);
                    }
                    catch (Exception exConv)
                    {
                        retVal.Add(defaultVal);
                    }
                }
                //if (retVal.Count != jarr.Count) L.err(location, "Copied (" + retVal.Count + ") of (" + jarr.Count + ") items.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


    }
}
