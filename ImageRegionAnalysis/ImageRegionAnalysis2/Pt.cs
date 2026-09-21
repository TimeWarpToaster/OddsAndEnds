using System;
using Newtonsoft.Json.Linq;

namespace ImageRegionAnalysis2
{
    public class Pt
    {
        public int x = -1;
        public int y = -1;


        public Pt() { }

        public Pt(int xIn, int yIn) { this.x = xIn; this.y = yIn; }

        public bool Equals(Pt pt)
        {
            return
                pt != null &&
                this.x == pt.x &&
                this.y == pt.y;
        }

        public string toString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }

        public JObject toJObject()
        {
            JObject retVal = new JObject();
            retVal.Add("x", this.x);
            retVal.Add("y", this.y);
            return retVal;
        }

        public bool fromJObject(JObject obj)
        {
            bool retVal = false;
            try
            {
                if (obj == null) return retVal;

                int cntErrors = 0;
                if (obj.ContainsKey("x")) this.x = (int)obj["x"];
                else 
                {
                    this.x = -1;
                    cntErrors++;
                }
                if (obj.ContainsKey("y")) this.y = (int)obj["y"];
                else 
                {
                    this.y = -1;
                    cntErrors++;
                }

                if (cntErrors > 0) L.l("Pt.fromJObject", "Encountered (" + cntErrors + ") errors.");

                retVal = 0 == cntErrors;
            }
            catch (Exception ex)
            {
                L.ex("Pt.fromJObject", ex);
            }
            return retVal;
        }
    }
}
