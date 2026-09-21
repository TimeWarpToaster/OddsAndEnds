using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json.Linq;

namespace ImageRegionAnalysis2
{
    public class Counts
    {
        public const string CLASSNAME = "Counts";

        // TODO - perTtlSet
        public int ttlSet = 0;
        // TODO - perTtlUnset
        public int ttlUnset = 0;

        public int ttlX = 0;
        public int ttlY = 0;
        public double avgX = 0d;
        public double avgY = 0d;

        public double ttlDistance = 0d;
        public double avgDistance = 0d;

        public int ttlDistanceX = 0;// from left   -   TODO - consider summing back and forth from center
        public int ttlDistanceY = 0;// from top
        public double avgDistanceX = 0d;
        public double avgDistanceY = 0d;

        public int ttlLeft = 0;
        public int ttlTop = 0;
        public int ttlRight = 0;
        public int ttlBottom = 0;

        public int setLeft = 0;
        public int setTop = 0;
        public int setRight = 0;
        public int setBottom = 0;

        //public int setTL = 0;
        //public int setTR = 0;
        //public int setBR = 0;
        //public int setBL = 0;

        public int unsetLeft = 0;
        public int unsetTop = 0;
        public int unsetRight = 0;
        public int unsetBottom = 0;

        public int ttl = 0;
        public int counted = 0;

        public List<int> blankLeft = new List<int>();// Holds counts of unset pixels before character begins, first-set pixel stops count
        public List<int> blankTop = new List<int>();
        public List<int> blankRight = new List<int>();
        public List<int> blankBottom = new List<int>();

        public List<double> perBlankLeft = new List<double>();// Holds percent blank relative to width
        public List<double> perBlankTop = new List<double>();// relative to height
        public List<double> perBlankRight = new List<double>();
        public List<double> perBlankBottom = new List<double>();


        // Percentages only
        public double perTtlSet = 0;
        public double perTtlUnset = 0;

        public double perAvgX = 0d;// Average X relative to width
        public double perAvgY = 0d;// Average Y relative to height

        public double perAvgDistanceX = 0d;
        public double perAvgDistanceY = 0d;

        public double perSetLeft = 0;
        public double perSetTop = 0;
        public double perSetRight = 0;
        public double perSetBottom = 0;

        public double perUnsetLeft = 0;
        public double perUnsetTop = 0;
        public double perUnsetRight = 0;
        public double perUnsetBottom = 0;


        public Counts() { }

        public Counts(int initNum)
        {
            this.ttlSet = 
            this.ttlUnset = 
            this.ttlX = 
            this.ttlY = 
            this.setLeft = 
            this.setTop = 
            this.setRight = 
            this.setBottom = 
            this.ttl =
            this.counted = initNum;

            this.avgX =
            this.avgY =
            this.ttlDistance =
            this.avgDistance = (double)initNum;

            // There is not any reference to size. Lists need to be empty at construction
            this.blankLeft = new List<int>();
            this.blankTop = new List<int>();
            this.blankRight = new List<int>();
            this.blankBottom = new List<int>();

            this.perBlankLeft = new List<double>();
            this.perBlankTop = new List<double>();
            this.perBlankRight = new List<double>();
            this.perBlankBottom = new List<double>();

            // Percentages only
            this.perTtlSet = 
            this.perTtlUnset = 
            this.perAvgX = 
            this.perAvgY = 
            this.perAvgDistanceX =
            this.perAvgDistanceY =
            this.perSetLeft = 
            this.perSetTop = 
            this.perSetRight = 
            this.perSetBottom = 
            this.perUnsetLeft = 
            this.perUnsetTop = 
            this.perUnsetRight = 
            this.perUnsetBottom = (double)initNum;
        }

        public Counts(Counts counts)
        {
            if (counts != null)
            {
                this.ttlSet = counts.ttlSet;
                this.ttlUnset = counts.ttlUnset;
                this.ttlX = counts.ttlX;
                this.ttlY = counts.ttlY;
                this.avgX = counts.avgX;
                this.avgY = counts.avgY;
                this.ttlDistance = counts.ttlDistance;
                this.avgDistance = counts.avgDistance;
                this.setLeft = counts.setLeft;
                this.setTop = counts.setTop;
                this.setRight = counts.setRight;
                this.setBottom = counts.setBottom;
                this.ttl = counts.ttl;
                this.counted = counts.counted;

                // There is not any reference to size. Lists need to be empty at construction
                this.blankLeft = new List<int>();
                this.blankTop = new List<int>();
                this.blankRight = new List<int>();
                this.blankBottom = new List<int>();

                if (counts.blankLeft != null) this.blankLeft.AddRange(counts.blankLeft);
                if (counts.blankTop != null) this.blankTop.AddRange(counts.blankTop);
                if (counts.blankRight != null) this.blankRight.AddRange(counts.blankRight);
                if (counts.blankBottom != null) this.blankBottom.AddRange(counts.blankBottom);

                this.perBlankLeft = new List<double>();
                this.perBlankTop = new List<double>();
                this.perBlankRight = new List<double>();
                this.perBlankBottom = new List<double>();

                if (counts.perBlankLeft != null) this.perBlankLeft.AddRange(counts.perBlankLeft);
                if (counts.perBlankTop != null) this.perBlankTop.AddRange(counts.perBlankTop);
                if (counts.perBlankRight != null) this.perBlankRight.AddRange(counts.perBlankRight);
                if (counts.perBlankBottom != null) this.perBlankBottom.AddRange(counts.perBlankBottom);

                // Percentages only
                this.perTtlSet = counts.perTtlSet;
                this.perTtlUnset = counts.perTtlUnset;
                this.perAvgX = counts.perAvgX;
                this.perAvgY = counts.perAvgY;
                this.perAvgDistanceX = counts.perAvgDistanceX;
                this.perAvgDistanceY = counts.perAvgDistanceY;
                this.perSetLeft = counts.perSetLeft;
                this.perSetTop = counts.perSetTop;
                this.perSetRight = counts.perSetRight;
                this.perSetBottom = counts.perSetBottom;
                this.perUnsetLeft = counts.perUnsetLeft;
                this.perUnsetTop = counts.perUnsetTop;
                this.perUnsetRight = counts.perUnsetRight;
                this.perUnsetBottom = counts.perUnsetBottom;
            }
        }

        public Counts AbsDiff(Counts counts)
        {
            Counts retVal = null;
            try
            {
                if (counts == null) return retVal;

                Counts temp = new Counts();

                // Default everything to something that looks like an error when doing diffs
                temp.ttlSet = -1;
                temp.ttlUnset = -1;

                temp.ttlX = -1;
                temp.ttlY = -1;
                temp.avgX = -1d;
                temp.avgY = -1d;

                temp.ttlDistance = -1d;
                temp.avgDistance = -1d;
                temp.ttlDistanceX = -1;
                temp.ttlDistanceY = -1;
                temp.avgDistanceX = -1d;
                temp.avgDistanceY = -1d;

                temp.setLeft = -1;
                temp.setTop = -1;
                temp.setRight = -1;
                temp.setBottom = -1;

                temp.ttl = -1;
                temp.counted = -1;

                temp.blankLeft = new List<int>();// Holds counts of unset pixels before character begins, first-set pixel stops count
                temp.blankTop = new List<int>();
                temp.blankRight = new List<int>();
                temp.blankBottom = new List<int>();

                temp.perBlankLeft = new List<double>();// Holds percent blank relative to width
                temp.perBlankTop = new List<double>();// relative to height
                temp.perBlankRight = new List<double>();
                temp.perBlankBottom = new List<double>();


                // Percentages only
                temp.perTtlSet = -1;
                temp.perTtlUnset = -1;

                temp.perAvgX = -1d;// Average X relative to width
                temp.perAvgY = -1d;// Average Y relative to height

                temp.perAvgDistanceX = -1d;
                temp.perAvgDistanceY = -1d;

                temp.perSetLeft = -1d;
                temp.perSetTop = -1d;
                temp.perSetRight = -1d;
                temp.perSetBottom = -1d;

                temp.perUnsetLeft = -1d;
                temp.perUnsetTop = -1d;
                temp.perUnsetRight = -1d;
                temp.perUnsetBottom = -1d;


                temp.ttlSet =
                    counts.ttlSet > this.ttlSet ?
                    counts.ttlSet - this.ttlSet :
                    this.ttlSet - counts.ttlSet;

                temp.ttlUnset =
                    counts.ttlUnset > this.ttlUnset ?
                    counts.ttlUnset - this.ttlUnset :
                    this.ttlUnset - counts.ttlUnset;

                temp.ttlX =
                    counts.ttlX > this.ttlX ?
                    counts.ttlX - this.ttlX :
                    this.ttlX - counts.ttlX;

                temp.ttlY =
                    counts.ttlY > this.ttlY ?
                    counts.ttlY - this.ttlY :
                    this.ttlY - counts.ttlY;

                temp.avgX =
                    counts.avgX > this.avgX ?
                    counts.avgX - this.avgX :
                    this.avgX - counts.avgX;

                temp.avgY =
                    counts.avgY > this.avgY ?
                    counts.avgY - this.avgY :
                    this.avgY - counts.avgY;

                temp.ttlDistance =
                    counts.ttlDistance > this.ttlDistance ?
                    counts.ttlDistance - this.ttlDistance :
                    this.ttlDistance - counts.ttlDistance;

                temp.avgDistance =
                    counts.avgDistance > this.avgDistance ?
                    counts.avgDistance - this.avgDistance :
                    this.avgDistance - counts.avgDistance;

                temp.ttlDistanceX =
                    counts.ttlDistanceX > this.ttlDistanceX ?
                    counts.ttlDistanceX - this.ttlDistanceX :
                    this.ttlDistanceX - counts.ttlDistanceX;

                temp.ttlDistanceY =
                    counts.ttlDistanceY > this.ttlDistanceY ?
                    counts.ttlDistanceY - this.ttlDistanceY :
                    this.ttlDistanceY - counts.ttlDistanceY;

                temp.avgDistanceX =
                    counts.avgDistanceX > this.avgDistanceX ?
                    counts.avgDistanceX - this.avgDistanceX :
                    this.avgDistanceX - counts.avgDistanceX;

                temp.avgDistanceY =
                    counts.avgDistanceY > this.avgDistanceY ?
                    counts.avgDistanceY - this.avgDistanceY :
                    this.avgDistanceY - counts.avgDistanceY;

                temp.setLeft =
                    counts.setLeft > this.setLeft ?
                    counts.setLeft - this.setLeft :
                    this.setLeft - counts.setLeft;

                temp.setTop =
                    counts.setTop > this.setTop ?
                    counts.setTop - this.setTop :
                    this.setTop - counts.setTop;

                temp.setRight =
                    counts.setRight > this.setRight ?
                    counts.setRight - this.setRight :
                    this.setRight - counts.setRight;

                temp.setBottom =
                    counts.setBottom > this.setBottom ?
                    counts.setBottom - this.setBottom :
                    this.setBottom - counts.setBottom;

                temp.ttl =
                    counts.ttl > this.ttl ?
                    counts.ttl - this.ttl :
                    this.ttl - counts.ttl;

                temp.counted =
                    counts.counted > this.counted ?
                    counts.counted - this.counted :
                    this.counted - counts.counted;
                /*if (counts.blankLeft != null && this.blankLeft != null)
                {
                    int max = counts.blankLeft.Count > this.blankLeft.Count ? counts.blankLeft.Count : this.blankLeft.Count;
                    for (int i = 0; i < max; i++) temp.blankLeft.Add(-1);
                    for (int i = 0; i < max; i++)
                    {
                        if (i < counts.blankLeft.Count)
                        {
                            if (i < this.blankLeft.Count)// diff both
                                temp.blankLeft[i] =
                                    counts.blankLeft[i] > this.blankLeft[i] ?
                                    counts.blankLeft[i] - this.blankLeft[i] :
                                    this.blankLeft[i] - counts.blankLeft[i];
                            else temp.blankLeft[i] = counts.blankLeft[i];// only that
                        }
                        else if (this.blankLeft != null)
                        {
                            temp.blankLeft[i] = this.blankLeft[i];// only this
                        }
                        else 
                        {
                            temp.blankLeft[i] = 0;// both null is a match
                        }
                    }
                }*/


                temp.blankLeft = ls.diff(counts.blankLeft, this.blankLeft);
                temp.blankTop = ls.diff(counts.blankTop, this.blankTop);
                temp.blankRight = ls.diff(counts.blankRight, this.blankRight);
                temp.blankBottom = ls.diff(counts.blankBottom, this.blankBottom);

                temp.perBlankLeft = ls.diff(counts.perBlankLeft, this.perBlankLeft);
                temp.perBlankTop = ls.diff(counts.perBlankTop, this.perBlankTop);
                temp.perBlankRight = ls.diff(counts.perBlankRight, this.perBlankRight);
                temp.perBlankBottom = ls.diff(counts.perBlankBottom, this.perBlankBottom);


                // Percentages only
                temp.perTtlSet =
                    counts.perTtlSet > this.perTtlSet ?
                    counts.perTtlSet - this.perTtlSet :
                    this.perTtlSet - counts.perTtlSet;

                temp.perTtlUnset =
                    counts.perTtlUnset > this.perTtlUnset ?
                    counts.perTtlUnset - this.perTtlUnset :
                    this.perTtlUnset - counts.perTtlUnset;

                temp.perAvgX =
                    counts.perAvgX > this.perAvgX ?
                    counts.perAvgX - this.perAvgX :
                    this.perAvgX - counts.perAvgX;

                temp.perAvgY =
                    counts.perAvgY > this.perAvgY ?
                    counts.perAvgY - this.perAvgY :
                    this.perAvgY - counts.perAvgY;

                temp.perAvgDistanceX =
                    counts.perAvgDistanceX > this.perAvgDistanceX ?
                    counts.perAvgDistanceX - this.perAvgDistanceX :
                    this.perAvgDistanceX - counts.perAvgDistanceX;

                temp.perAvgDistanceY =
                    counts.perAvgDistanceY > this.perAvgDistanceY ?
                    counts.perAvgDistanceY - this.perAvgDistanceY :
                    this.perAvgDistanceY - counts.perAvgDistanceY;

                temp.perSetLeft =
                    counts.perSetLeft > this.perSetLeft ?
                    counts.perSetLeft - this.perSetLeft :
                    this.perSetLeft - counts.perSetLeft;

                temp.perSetTop =
                    counts.perSetTop > this.perSetTop ?
                    counts.perSetTop - this.perSetTop :
                    this.perSetTop - counts.perSetTop;

                temp.perSetRight =
                    counts.perSetRight > this.perSetRight ?
                    counts.perSetRight - this.perSetRight :
                    this.perSetRight - counts.perSetRight;

                temp.perSetBottom =
                    counts.perSetBottom > this.perSetBottom ?
                    counts.perSetBottom - this.perSetBottom :
                    this.perSetBottom - counts.perSetBottom;

                temp.perUnsetLeft =
                    counts.perUnsetLeft > this.perUnsetLeft ?
                    counts.perUnsetLeft - this.perUnsetLeft :
                    this.perUnsetLeft - counts.perUnsetLeft;

                temp.perUnsetTop =
                    counts.perUnsetTop > this.perUnsetTop ?
                    counts.perUnsetTop - this.perUnsetTop :
                    this.perUnsetTop - counts.perUnsetTop;

                temp.perUnsetRight =
                    counts.perUnsetRight > this.perUnsetRight ?
                    counts.perUnsetRight - this.perUnsetRight :
                    this.perUnsetRight - counts.perUnsetRight;

                temp.perUnsetBottom =
                    counts.perUnsetBottom > this.perUnsetBottom ?
                    counts.perUnsetBottom - this.perUnsetBottom :
                    this.perUnsetBottom - counts.perUnsetBottom;



                // Output Result
                retVal = temp;
            }
            catch (Exception ex)
            {
                L.ex(CLASSNAME + ".AbsDiff", ex);
            }
            return retVal;
        }

        public bool Equals(Counts counts)
        {
            return 
                counts != null &&
                counts.ttlSet == this.ttlSet &&
                counts.ttlUnset == this.ttlUnset &&
                counts.ttlX == this.ttlX &&
                counts.ttlY == this.ttlY &&
                counts.avgX == this.avgX &&
                counts.avgY == this.avgY &&
                counts.ttlDistance == this.ttlDistance &&
                counts.avgDistance == this.avgDistance &&
                counts.ttlDistanceX == this.ttlDistanceX &&
                counts.ttlDistanceY == this.ttlDistanceY &&
                counts.avgDistanceX == this.avgDistanceX &&
                counts.avgDistanceY == this.avgDistanceY &&
                counts.setLeft == this.setLeft &&
                counts.setTop == this.setTop &&
                counts.setRight == this.setRight &&
                counts.setBottom == this.setBottom &&
                counts.ttl == this.ttl &&
                counts.counted == this.counted &&

                // TODO - Not fully decided on what is absolutely required for an equals... all the way? or just critical?

                // Compare Lists
                ls.eq(counts.blankLeft, this.blankLeft) &&
                ls.eq(counts.blankTop, this.blankTop) &&
                ls.eq(counts.blankRight, this.blankRight) &&
                ls.eq(counts.blankBottom, this.blankBottom) &&

                ls.eq(counts.perBlankLeft, this.perBlankLeft) &&
                ls.eq(counts.perBlankTop, this.perBlankTop) &&
                ls.eq(counts.perBlankRight, this.perBlankRight) &&
                ls.eq(counts.perBlankBottom, this.perBlankBottom) &&

                // Compare Percents
                counts.perTtlSet == this.perTtlSet &&
                counts.perTtlUnset == this.perTtlUnset &&
                counts.perAvgX == this.perAvgX &&
                counts.perAvgY == this.perAvgY &&
                counts.perAvgDistanceX == this.perAvgDistanceX &&
                counts.perAvgDistanceY == this.perAvgDistanceY &&
                counts.perSetLeft == this.perSetLeft &&
                counts.perSetTop == this.perSetTop &&
                counts.perSetRight == this.perSetRight &&
                counts.perSetBottom == this.perSetBottom &&
                counts.perUnsetLeft == this.perUnsetLeft &&
                counts.perUnsetTop == this.perUnsetTop &&
                counts.perUnsetRight == this.perUnsetRight &&
                counts.perUnsetBottom == this.perUnsetBottom;
        }

        public bool fromJObject(JObject obj)
        {
            const string location = CLASSNAME + ".fromJObject";
            bool retVal = false;
            try
            {
                // Either succeed or fail, don't error for specific conditions
                if (obj == null) return retVal;

                int cntErrors = 0;
                if (obj.ContainsKey("ttlSet")) this.ttlSet = Convert.ToInt32(obj["ttlSet"]);
                else
                {
                    this.ttlSet = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlUnset")) this.ttlUnset = Convert.ToInt32(obj["ttlUnset"]);
                else
                {
                    this.ttlUnset = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlX")) this.ttlX = Convert.ToInt32(obj["ttlX"]);
                else
                {
                    this.ttlX = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlY")) this.ttlY = Convert.ToInt32(obj["ttlY"]);
                else
                {
                    this.ttlY = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("avgX")) this.avgX = Convert.ToDouble(obj["avgX"]);
                else
                {
                    this.avgX = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("avgY")) this.avgY = Convert.ToDouble(obj["avgY"]);
                else
                {
                    this.avgY = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlDistance")) this.ttlDistance = Convert.ToDouble(obj["ttlDistance"]);
                else
                {
                    this.ttlDistance = 0d;// use the errors
                    cntErrors++;
                }

                if (obj.ContainsKey("avgDistance")) this.avgDistance = Convert.ToDouble(obj["avgDistance"]);
                else
                {
                    this.avgDistance = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlDistanceX")) this.ttlDistanceX = Convert.ToInt32(obj["ttlDistanceX"]);
                else
                {
                    this.ttlDistanceX = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttlDistanceY")) this.ttlDistanceY = Convert.ToInt32(obj["ttlDistanceY"]);
                else
                {
                    this.ttlDistanceY = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("avgDistanceX")) this.avgDistanceX = Convert.ToDouble(obj["avgDistanceX"]);
                else
                {
                    this.avgDistanceX = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("avgDistanceY")) this.avgDistanceY = Convert.ToDouble(obj["avgDistanceY"]);
                else
                {
                    this.avgDistanceY = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("setLeft")) this.setLeft = Convert.ToInt32(obj["setLeft"]);
                else
                {
                    this.setLeft = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("setTop")) this.setTop = Convert.ToInt32(obj["setTop"]);
                else
                {
                    this.setTop = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("setRight")) this.setRight = Convert.ToInt32(obj["setRight"]);
                else
                {
                    this.setRight = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("setBottom")) this.setBottom = Convert.ToInt32(obj["setBottom"]);
                else
                {
                    this.setBottom = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("unsetLeft")) this.unsetLeft = Convert.ToInt32(obj["unsetLeft"]);
                else
                {
                    this.unsetLeft = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("unsetTop")) this.unsetTop = Convert.ToInt32(obj["unsetTop"]);
                else
                {
                    this.unsetTop = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("unsetRight")) this.unsetRight = Convert.ToInt32(obj["unsetRight"]);
                else
                {
                    this.unsetRight = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("unsetBottom")) this.unsetBottom = Convert.ToInt32(obj["unsetBottom"]);
                else
                {
                    this.unsetBottom = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("ttl")) this.ttl = Convert.ToInt32(obj["ttl"]);
                else
                {
                    this.ttl = 0;
                    cntErrors++;
                }

                if (obj.ContainsKey("counted")) this.counted = Convert.ToInt32(obj["counted"]);
                else
                {
                    this.counted = 0;
                    cntErrors++;
                }


                // TODO - Create a J class to start holding JSON helpers somewhere isolated

                if (obj.ContainsKey("blankLeft"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["blankLeft"]; } catch (Exception exConv) { }
                    this.blankLeft = J.toList(jarr, -1);
                    if (this.blankLeft == null)
                    {
                        this.blankLeft = new List<int>();
                        cntErrors++;
                    }
                    else if (this.blankLeft.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("blankTop"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["blankTop"]; } catch (Exception exConv) { }
                    this.blankTop = J.toList(jarr, -1);
                    if (this.blankTop == null)
                    {
                        this.blankTop = new List<int>();
                        cntErrors++;
                    }
                    else if (this.blankTop.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("blankRight"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["blankRight"]; } catch (Exception exConv) { }
                    this.blankRight = J.toList(jarr, -1);
                    if (this.blankRight == null)
                    {
                        this.blankRight = new List<int>();
                        cntErrors++;
                    }
                    else if (this.blankRight.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("blankBottom"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["blankBottom"]; } catch (Exception exConv) { }
                    this.blankBottom = J.toList(jarr, -1);
                    if (this.blankBottom == null)
                    {
                        this.blankBottom = new List<int>();
                        cntErrors++;
                    }
                    else if (this.blankBottom.Count != jarr.Count) cntErrors++;
                }


                if (obj.ContainsKey("perBlankLeft"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["perBlankLeft"]; } catch (Exception exConv) { }
                    this.perBlankLeft = J.toList(jarr, -1d);// Force list-of-double
                    if (this.perBlankLeft == null)
                    {
                        this.perBlankLeft = new List<double>();
                        cntErrors++;
                    }
                    else if (this.perBlankLeft.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("perBlankTop"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["perBlankTop"]; } catch (Exception exConv) { }
                    this.perBlankTop = J.toList(jarr, -1d);
                    if (this.perBlankTop == null)
                    {
                        this.perBlankTop = new List<double>();
                        cntErrors++;
                    }
                    else if (this.perBlankTop.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("perBlankRight"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["perBlankRight"]; } catch (Exception exConv) { }
                    this.perBlankRight = J.toList(jarr, -1d);
                    if (this.perBlankRight == null)
                    {
                        this.perBlankRight = new List<double>();
                        cntErrors++;
                    }
                    else if (this.perBlankRight.Count != jarr.Count) cntErrors++;
                }
                if (obj.ContainsKey("perBlankBottom"))
                {
                    JArray jarr = null;
                    try { jarr = (JArray)obj["perBlankBottom"]; } catch (Exception exConv) { }
                    this.perBlankBottom = J.toList(jarr, -1d);
                    if (this.perBlankBottom == null)
                    {
                        this.perBlankBottom = new List<double>();
                        cntErrors++;
                    }
                    else if (this.perBlankBottom.Count != jarr.Count) cntErrors++;
                }



                if (obj.ContainsKey("perTtlSet")) this.perTtlSet = Convert.ToDouble(obj["perTtlSet"]);
                else 
                {
                    this.perTtlSet = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perTtlUnset")) this.perTtlUnset = Convert.ToDouble(obj["perTtlUnset"]);
                else
                {
                    this.perTtlUnset = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("perAvgX")) this.perAvgX = Convert.ToDouble(obj["perAvgX"]);
                else
                {
                    this.perAvgX = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perAvgY")) this.perAvgY = Convert.ToDouble(obj["perAvgY"]);
                else
                {
                    this.perAvgY = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("perAvgDistanceX")) this.perAvgDistanceX = Convert.ToDouble(obj["perAvgDistanceX"]);
                else
                {
                    this.perAvgDistanceX = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perAvgDistanceY")) this.perAvgDistanceY = Convert.ToDouble(obj["perAvgDistanceY"]);
                else
                {
                    this.perAvgDistanceY = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("perSetLeft")) this.perSetLeft = Convert.ToDouble(obj["perSetLeft"]);
                else
                {
                    this.perSetLeft = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perSetTop")) this.perSetTop = Convert.ToDouble(obj["perSetTop"]);
                else
                {
                    this.perSetTop = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perSetRight")) this.perSetRight = Convert.ToDouble(obj["perSetRight"]);
                else
                {
                    this.perSetRight = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perSetBottom")) this.perSetBottom = Convert.ToDouble(obj["perSetBottom"]);
                else
                {
                    this.perSetBottom = 0d;
                    cntErrors++;
                }

                if (obj.ContainsKey("perUnsetLeft")) this.perUnsetLeft = Convert.ToDouble(obj["perUnsetLeft"]);
                else
                {
                    this.perUnsetLeft = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perUnsetTop")) this.perUnsetTop = Convert.ToDouble(obj["perUnsetTop"]);
                else
                {
                    this.perUnsetTop = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perUnsetRight")) this.perUnsetRight = Convert.ToDouble(obj["perUnsetRight"]);
                else
                {
                    this.perUnsetRight = 0d;
                    cntErrors++;
                }
                if (obj.ContainsKey("perUnsetBottom")) this.perUnsetBottom = Convert.ToDouble(obj["perUnsetBottom"]);
                else
                {
                    this.perUnsetBottom = 0d;
                    cntErrors++;
                }





                if (cntErrors > 0) L.l(location, "Encountered (" + cntErrors + ") errors.");

                // Flag Result
                retVal = 0 == cntErrors;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string perimeterToCsv(string cIn)
        {
            const string location = CLASSNAME + ".perimeterToCsv";
            string retVal = "";
            try
            {
                string c = cIn != null ? cIn : " ";
                // TODO - Dump perimeter lists (this.blank...) to CSV, use X and Y position for headings
                StringBuilder sb = new StringBuilder();
                sb.Append(ls.toCsvString("(" + c + ") blankLeft", this.blankLeft, true));
                sb.Append(ls.toCsvString("(" + c + ") blankTop", this.blankTop, true));
                sb.Append(ls.toCsvString("(" + c + ") blankRight", this.blankRight, true));
                sb.Append(ls.toCsvString("(" + c + ") blankBottom", this.blankBottom, true));
                sb.Append(ls.toCsvString("(" + c + ") perBlankLeft", this.perBlankLeft, true));
                sb.Append(ls.toCsvString("(" + c + ") perBlankTop", this.perBlankTop, true));
                sb.Append(ls.toCsvString("(" + c + ") perBlankRight", this.perBlankRight, true));
                sb.Append(ls.toCsvString("(" + c + ") perBlankBottom", this.perBlankBottom, true));

                retVal = sb.ToString();
                sb.Length = 0;


                /*StringBuilder sbHeader = new StringBuilder();
                StringBuilder sbBody = new StringBuilder();

                sbHeader.Append("\nblankLeft");
                sbBody.Append("\nblankLeft");
                for (int i = 0; i < this.blankLeft.Count; i++)
                {
                    sbHeader.Append(", ").Append(i);
                    sbBody.Append(", ").Append(blankLeft[i]);
                }
                sb.Append(sbHeader.ToString());
                sb.Append(sbBody.ToString());

                sbHeader.Clear();
                sbBody.Clear();

                sbHeader.Append("\nblankTop");
                sbBody.Append("\nblankTop");*/
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string perimeterToString()
        {
            const string location = CLASSNAME + ".perimeterToString";
            string retVal = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n\n").Append("Left Edge :: ");
                if (this.blankLeft != null)
                {
                    for (int i = 0; i < this.blankLeft.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.blankLeft[i]);
                    }
                }

                sb.Append("\n\n").Append("Top Edge :: ");
                if (this.blankTop != null)
                {
                    for (int i = 0; i < this.blankTop.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.blankTop[i]);
                    }
                }

                sb.Append("\n\n").Append("Right Edge :: ");
                if (this.blankRight != null)
                {
                    for (int i = 0; i < this.blankRight.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.blankRight[i]);
                    }
                }

                sb.Append("\n\n").Append("Bottom Edge ::");
                if (this.blankBottom != null)
                {
                    for (int i = 0; i < this.blankBottom.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.blankBottom[i]);
                    }
                }

                sb.Append("\n\n").Append("% Left Edge :: ");
                if (this.perBlankLeft != null)
                {
                    for (int i = 0; i < this.perBlankLeft.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.perBlankLeft[i]);
                    }
                }

                sb.Append("\n\n").Append("% Top Edge :: ");
                if (this.perBlankTop != null)
                {
                    for (int i = 0; i < this.perBlankTop.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.perBlankTop[i]);
                    }
                }

                sb.Append("\n\n").Append("% Right Edge :: ");
                if (this.perBlankRight != null)
                {
                    for (int i = 0; i < this.perBlankRight.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.perBlankRight[i]);
                    }
                }

                sb.Append("\n\n").Append("% Bottom Edge ::");
                if (this.perBlankBottom != null)
                {
                    for (int i = 0; i < this.perBlankBottom.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        sb.Append(this.perBlankBottom[i]);
                    }
                }


                // Output Result
                retVal = sb.ToString();
                sb.Length = 0;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public JObject toJObject()
        {
            JObject retVal = new JObject();

            // Output Counts
            retVal.Add("ttlSet", this.ttlSet);
            retVal.Add("ttlUnset", this.ttlUnset);
            retVal.Add("ttlX", this.ttlX);
            retVal.Add("ttlY", this.ttlY);
            retVal.Add("avgX", this.avgX);
            retVal.Add("avgY", this.avgY);
            retVal.Add("ttlDistance", this.ttlDistance);
            retVal.Add("avgDistance", this.avgDistance);
            retVal.Add("ttlDistanceX", this.ttlDistanceX);
            retVal.Add("ttlDistanceY", this.ttlDistanceY);
            retVal.Add("avgDistanceX", this.avgDistanceX);
            retVal.Add("avgDistanceY", this.avgDistanceY);
            retVal.Add("setLeft", this.setLeft);
            retVal.Add("setTop", this.setTop);
            retVal.Add("setRight", this.setRight);
            retVal.Add("setBottom", this.setBottom);
            retVal.Add("unsetLeft", this.unsetLeft);
            retVal.Add("unsetTop", this.unsetTop);
            retVal.Add("unsetRight", this.unsetRight);
            retVal.Add("unsetBottom", this.unsetBottom);
            retVal.Add("ttl", this.ttl);
            retVal.Add("counted", this.counted);

            // Output Lists
            retVal.Add("blankLeft", J.fromList(this.blankLeft));
            retVal.Add("blankTop", J.fromList(this.blankTop));
            retVal.Add("blankRight", J.fromList(this.blankRight));
            retVal.Add("blankBottom", J.fromList(this.blankBottom));
            retVal.Add("perBlankLeft", J.fromList(this.perBlankLeft));
            retVal.Add("perBlankTop", J.fromList(this.perBlankTop));
            retVal.Add("perBlankRight", J.fromList(this.perBlankRight));
            retVal.Add("perBlankBottom", J.fromList(this.perBlankBottom));
            /*{
                JArray jarr = J.fromList(this.blankLeft);
                if (this.blankLeft != null)
                    for (int i = 0; i < this.blankLeft.Count; i++)
                        jarr.Add(this.blankLeft[i]);
                retVal.Add("blankLeft", jarr);
            }
            {
                JArray jarr = new JArray();
                if (this.blankTop != null)
                    for (int i = 0; i < this.blankTop.Count; i++)
                        jarr.Add(this.blankTop[i]);
                retVal.Add("blankTop", jarr);
            }
            {
                JArray jarr = new JArray();
                if (this.blankRight != null)
                    for (int i = 0; i < this.blankRight.Count; i++)
                        jarr.Add(this.blankRight[i]);
                retVal.Add("blankRight", jarr);
            }*/

            // Output Percents
            retVal.Add("perTtlSet", this.perTtlSet);
            retVal.Add("perTtlUnset", this.perTtlUnset);
            retVal.Add("perAvgX", this.perAvgX);
            retVal.Add("perAvgY", this.perAvgY);
            retVal.Add("perAvgDistanceX", this.perAvgDistanceX);
            retVal.Add("perAvgDistanceY", this.perAvgDistanceY);
            retVal.Add("perSetLeft", this.perSetLeft);
            retVal.Add("perSetTop", this.perSetTop);
            retVal.Add("perSetRight", this.perSetRight);
            retVal.Add("perSetBottom", this.perSetBottom);
            retVal.Add("perUnsetLeft", this.perUnsetLeft);
            retVal.Add("perUnsetTop", this.perUnsetTop);
            retVal.Add("perUnsetRight", this.perUnsetRight);
            retVal.Add("perUnsetBottom", this.perUnsetBottom);

            return retVal;
        }

        public string toCsv()
        {
            return
                (this.ttl > 0 ? (((double)this.ttlSet / (double)this.ttl) * (double)100) : 0) + "," +
                this.ttlSet + "," +
                (this.ttl > 0 ? (((double)this.ttlUnset / (double)this.ttl) * (double)100) : 0) + "," +
                this.ttlUnset + "," +
                this.ttlX + "," +
                this.ttlY + "," +
                this.avgX + "," +
                this.avgY + "," +
                this.ttlDistance + "," +
                this.avgDistance + "," +
                this.ttlDistanceX + "," +
                this.ttlDistanceY + "," + 
                this.avgDistanceX + "," + 
                this.avgDistanceY + "," +
                this.setLeft + "," +
                this.setTop + "," +
                this.setRight + "," +
                this.setBottom + "," +
                this.unsetLeft + "," +
                this.unsetTop + "," +
                this.unsetRight + "," +
                this.unsetBottom + "," +
                this.ttl + "," +
                this.counted + "," +

                this.perTtlSet + "," +
                this.perTtlUnset + "," +
                this.perAvgX + "," +
                this.perAvgY + "," +
                this.perAvgDistanceX + "," +
                this.perAvgDistanceY + "," +
                this.perSetLeft + "," +
                this.perSetTop + "," +
                this.perSetRight + "," +
                this.perSetBottom + "," +
                this.perUnsetLeft + "," +
                this.perUnsetTop + "," +
                this.perUnsetRight + "," +
                this.perUnsetBottom + Environment.NewLine;
        }

        public string toString()
        {
            return
                "Ttl Set (" + this.ttlSet + "), " +
                "Ttl Unset (" + this.ttlUnset + "), " +
                "Ttl X (" + this.ttlX + "), " +
                "Ttl Y (" + this.ttlY + "), " +
                "Avg X (" + this.avgX + "), " +
                "Avg Y (" + this.avgY + "), " +
                "Ttl Distance (" + this.ttlDistance + "), " +
                "Avg Distance (" + this.avgDistance + "), " +
                "Ttl D X (" + this.ttlDistanceX + "), " +
                "Ttl D Y (" + this.ttlDistanceY + "), " + 
                "Avg D X (" + this.avgDistanceX + "), " + 
                "Avg D Y (" + this.avgDistanceY + "), " +
                "Set Left (" + this.setLeft + "), " +
                "Set Top (" + this.setTop + "), " +
                "Set Right (" + this.setRight + "), " +
                "Set Bottom (" + this.setBottom + "), " +
                "Unset Left (" + this.unsetLeft + "), " +
                "Unset Top (" + this.unsetTop + "), " +
                "Unset Right (" + this.unsetRight + "), " +
                "Unset Bottom (" + this.unsetBottom + "), " +
                "Ttl (" + this.ttl + "), " +
                "Counted (" + this.counted + "), " +

                "%Ttl Set (" + this.perTtlSet + "), " +
                "%Ttl Unset (" + this.perTtlUnset + "), " +
                "%Avg X (" + this.perAvgX + "), " +
                "%Avg Y (" + this.perAvgY + "), " +
                "%Avg D X (" + this.perAvgDistanceX + "), " +
                "%Avg D Y (" + this.perAvgDistanceY + "), " +
                "%Set Left (" + this.perSetLeft + "), " +
                "%Set Top (" + this.perSetTop + "), " +
                "%Set Right (" + this.perSetRight + "), " +
                "%Set Bottom (" + this.perSetBottom + "), " +
                "%Unset Left (" + this.perUnsetLeft + "), " +
                "%Unset Top (" + this.perUnsetTop + "), " +
                "%Unset Right (" + this.perUnsetRight + "), " +
                "%Unset Bottom (" + this.perUnsetBottom + ").";
        }
    }
}
