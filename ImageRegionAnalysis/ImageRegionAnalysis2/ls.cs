//Image Region Analysis
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRegionAnalysis2
{
    public static class ls
    {
        public const string CLASSNAME = "ls";


        // diff and eq are essentially identical across type, decide on passing through and casting output
        public static List<double> diff(List<double> lsA, List<double> lsB)
        {
            List<double> retVal = new List<double>();
            if (lsA == null && lsB == null) return null;
            if (lsA == null)
            {
                for (int i = 0; i < lsB.Count; i++)
                    retVal.Add(lsB[i]);
            }
            else if (lsB == null)
            {
                for (int i = 0; i < lsA.Count; i++)
                    retVal.Add(lsA[i]);
            }
            else
            {
                int max = lsA.Count > lsB.Count ? lsA.Count : lsB.Count;
                for (int i = 0; i < max; i++) retVal.Add(-1);

                for (int i = 0; i < max; i++)
                {
                    if (i < lsA.Count)
                    {
                        if (i < lsB.Count)// diff both
                            retVal[i] =
                                lsA[i] > lsB[i] ?
                                lsA[i] - lsB[i] :
                                lsB[i] - lsA[i];
                        else retVal[i] = lsA[i];// only that
                    }
                    else if (i < lsB.Count) retVal[i] = lsB[i];
                }
            }
            return retVal;
        }

        public static List<float> diff(List<float> lsA, List<float> lsB)
        {
            List<float> retVal = new List<float>();
            if (lsA == null && lsB == null) return null;
            if (lsA == null)
            {
                for (int i = 0; i < lsB.Count; i++)
                    retVal.Add(lsB[i]);
            }
            else if (lsB == null)
            {
                for (int i = 0; i < lsA.Count; i++)
                    retVal.Add(lsA[i]);
            }
            else
            {
                int max = lsA.Count > lsB.Count ? lsA.Count : lsB.Count;
                for (int i = 0; i < max; i++) retVal.Add(-1);

                for (int i = 0; i < max; i++)
                {
                    if (i < lsA.Count)
                    {
                        if (i < lsB.Count)// diff both
                            retVal[i] =
                                lsA[i] > lsB[i] ?
                                lsA[i] - lsB[i] :
                                lsB[i] - lsA[i];
                        else retVal[i] = lsA[i];// only that
                    }
                    else if (i < lsB.Count) retVal[i] = lsB[i];
                }
            }
            return retVal;
        }

        public static List<int> diff(List<int> lsA, List<int> lsB)
        {
            List<int> retVal = new List<int>();
            if (lsA == null && lsB == null) return null;
            if (lsA == null)
            {
                for (int i = 0; i < lsB.Count; i++)
                    retVal.Add(lsB[i]);
            }
            else if (lsB == null)
            {
                for (int i = 0; i < lsA.Count; i++)
                    retVal.Add(lsA[i]);
            }
            else
            {
                int max = lsA.Count > lsB.Count ? lsA.Count : lsB.Count;
                for (int i = 0; i < max; i++) retVal.Add(-1);

                for (int i = 0; i < max; i++)
                {
                    if (i < lsA.Count)
                    {
                        if (i < lsB.Count)// diff both
                            retVal[i] =
                                lsA[i] > lsB[i] ?
                                lsA[i] - lsB[i] :
                                lsB[i] - lsA[i];
                        else retVal[i] = lsA[i];// only that
                    }
                    else if (i < lsB.Count) retVal[i] = lsB[i];
                }
            }
            return retVal;
        }

        public static List<long> diff(List<long> lsA, List<long> lsB)
        {
            List<long> retVal = new List<long>();
            if (lsA == null && lsB == null) return null;
            if (lsA == null)
            {
                for (int i = 0; i < lsB.Count; i++)
                    retVal.Add(lsB[i]);
            }
            else if (lsB == null)
            {
                for (int i = 0; i < lsA.Count; i++)
                    retVal.Add(lsA[i]);
            }
            else
            {
                int max = lsA.Count > lsB.Count ? lsA.Count : lsB.Count;
                for (int i = 0; i < max; i++) retVal.Add(-1);

                for (int i = 0; i < max; i++)
                {
                    if (i < lsA.Count)
                    {
                        if (i < lsB.Count)// diff both
                            retVal[i] =
                                lsA[i] > lsB[i] ?
                                lsA[i] - lsB[i] :
                                lsB[i] - lsA[i];
                        else retVal[i] = lsA[i];// only that
                    }
                    else if (i < lsB.Count) retVal[i] = lsB[i];
                }
            }
            return retVal;
        }


        public static bool eq(List<bool> lsA, List<bool> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }

        public static bool eq(List<double> lsA, List<double> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }

        public static bool eq(List<float> lsA, List<float> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }

        public static bool eq(List<int> lsA, List<int> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }

        public static bool eq(List<long> lsA, List<long> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }

        public static bool eq(List<string> lsA, List<string> lsB)
        {
            if (lsA != null && lsB != null && lsA.Count == lsB.Count)
            {
                bool mismatch = false;
                for (int i = 0; !mismatch && i < lsA.Count; i++)
                {
                    if (lsA[i] != lsB[i]) mismatch = true;
                }
                return !mismatch;
            }
            else if (lsA == null && lsB == null) return true;
            else return false;
        }


        public static List<object> get(List<List<object>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<bool> get(List<List<bool>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<double> get(List<List<double>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<float> get(List<List<float>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<int> get(List<List<int>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<long> get(List<List<long>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<string> get(List<List<string>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }

        public static List<Region> get(List<List<Region>> list, int row)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count ?
                list[row] :
                null;
        }



        public static object get(List<List<object>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ? 
                list[row][col] : 
                null;
        }

        public static bool get(List<List<bool>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ? 
                list[row][col] : 
                false;
        }

        public static double get(List<List<double>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                -1d;
        }

        public static float get(List<List<float>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                -1f;
        }

        public static int get(List<List<int>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                -1;
        }

        public static long get(List<List<long>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                -1L;
        }

        public static string get(List<List<string>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                null;
        }

        public static Region get(List<List<Region>> list, int row, int col)
        {
            return
                list != null &&
                row >= 0 &&
                row < list.Count &&
                col >= 0 &&
                col < list[row].Count ?
                list[row][col] :
                null;
        }



        // Return XY coordinates into 2D list for all value matches found
        public static List<Pt> matches(List<List<object>> list, object matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                // Treat null as safe, find matches anyway
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<bool>> list, bool matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<double>> list, double matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<float>> list, float matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<int>> list, int matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<long>> list, long matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<string>> list, string matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                        if (matchValue == list[row][col]) retVal.Add(new Pt() { x = col, y = row });
            }
            return retVal;
        }

        public static List<Pt> matches(List<List<Region>> list, Region matchValue)
        {
            List<Pt> retVal = null;
            if (list != null)
            {
                for (int row = 0; row < list.Count; row++)
                    for (int col = 0; col < list[row].Count; col++)
                    {
                        if (
                            list[row][col] != null && // TODO - this does not work if matchValue == null
                            list[row][col].Equals(matchValue, false)
                            //list[row][col].Start != null &&
                            //list[row][col].End != null &&
                            //list[row][col].Start.Equals(matchValue.Start) &&
                            //list[row][col].End.Equals(matchValue.End)
                        )
                        {
                            retVal.Add(new Pt() { x = col, y = row });
                        }
                    }
            }
            return retVal;
        }


        public static string toCsvString(string labelCol1, List<object> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i] != null ? Convert.ToString(list[i]) : "");
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<bool> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(Convert.ToString(list[i]));
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<double> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i]);
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<float> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i]);
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<int> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i]);
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<long> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i]);
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }

        public static string toCsvString(string labelCol1, List<string> list, bool headWithIndex)
        {
            if (list == null) return "";

            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbBody = new StringBuilder();

            if (headWithIndex) sbHeader.Append("\n\n");
            sbBody.Append("\n");
            if (labelCol1 != null)
            {
                if (headWithIndex) sbHeader.Append(labelCol1);
                sbBody.Append(labelCol1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 || labelCol1 != null)
                {
                    if (headWithIndex) sbHeader.Append(", ");
                    sbBody.Append(", ");
                }
                if (headWithIndex) sbHeader.Append(i);
                sbBody.Append(list[i] != null ? list[i] : "");
            }
            string retVal = (headWithIndex ? sbHeader.ToString() : "") + sbBody.ToString();
            sbHeader.Clear();
            sbBody.Clear();
            return retVal;
        }
    }
}
