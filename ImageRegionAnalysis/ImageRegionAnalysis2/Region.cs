using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace ImageRegionAnalysis2
{
    public class Region
    {
        public const string CLASSNAME = "Region";


        public Pt Start { get; set; }// top-left
        public Pt End { get; set; }// bottom-right

        public int width = 0;
        public int height = 0;

        public Counts counts { get; set; }

        //public Regions regions { get; set; }// Helps count a region as sub-regions

        public List<List<Region>> regions = new List<List<Region>>();



        public Region() { }

        public Region(int widthIn, int heightIn, Pt start)
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                this.width = widthIn;
                this.height = heightIn;
                this.Start = start;
                if (this.Start != null)
                {
                    this.End = new Pt(this.Start.x + this.width - 1, this.Start.y + this.height - 1);
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        // TODO - AbsDiff -> static
        public Region AbsDiff(Region regionB)
        {
            const string location = CLASSNAME + ".AbsDiff";
            Region retVal = null;
            try
            {
                if (regionB == null || regionB.regions == null)
                {
                    L.err(location, "Input regionsB was null.");
                    return retVal;
                }

                // We can either quit if the regions count does not match, or count what we can

                if (regionB.regions.Count != this.regions.Count)
                {
                    L.err(location, "Number of rows does not match between regions objects.");
                    return retVal;
                }
                bool colMismatch = false;
                for (int idxY = 0; !colMismatch && idxY < regionB.regions.Count; idxY++)
                {
                    if (regionB.regions[idxY].Count != this.regions[idxY].Count)
                        colMismatch = true;
                }
                if (colMismatch)
                {
                    L.err(location, "Number of columns does not match between regions objects.");
                    return retVal;
                }

                Region cntsRegions = new Region();
                cntsRegions.regions = new List<List<Region>>();

                int cntSetThis = 0;
                int cntSetIn = 0;
                int cntNullIn = 0;
                for (int idxY = 0; idxY < regionB.regions.Count; idxY++)
                {
                    List<Region> list = new List<Region>();
                    for (int idxX = 0; idxX < regionB.regions[idxY].Count; idxX++)
                    {
                        Counts temp = null;
                        if (regionB.regions[idxY][idxX] == null && this.regions[idxY][idxX] != null)
                        {
                            temp = new Counts(this.regions[idxY][idxX].counts);
                        }
                        else if (this.regions[idxY][idxX] == null && regionB.regions[idxY][idxX] != null)
                        {
                            temp = new Counts(regionB.regions[idxY][idxX].counts);
                        }
                        else if (this.regions[idxY][idxX] != null && this.regions[idxY][idxX].counts != null)
                        {
                            temp = regionB.regions[idxY][idxX].counts.AbsDiff(this.regions[idxY][idxX].counts);
                        }
                        if (temp == null)
                        {
                            if (Config.DebugRegionCount) L.err(location, "Failed to get abs diff counts.");
                            temp = new Counts();
                        }


                        Region region = new Region();
                        region.counts = temp;
                        list.Add(region);

                        if (this.regions[idxY][idxX] != null && this.regions[idxY][idxX].counts != null)
                        {
                            cntSetThis += this.regions[idxY][idxX].counts.ttlSet;
                        }

                        if (regionB.regions[idxY][idxX] != null && regionB.regions[idxY][idxX].counts != null)
                        {
                            cntSetIn += regionB.regions[idxY][idxX].counts.ttlSet;
                        }
                        else cntNullIn++;
                    }
                    cntsRegions.regions.Add(list);
                }
                if (cntNullIn > 0 && Config.DebugRegionCount)
                    L.err(location, "Found (" + cntNullIn + ") null counts objects in input.");
                //L.l(location, "Total set in (" + cntSetIn + "), total set this (" + cntSetThis + ").");
                retVal = cntsRegions;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool Equals(Region region)
        {
            return this.Equals(region, false);
        }

        public bool Equals(Region region, bool pointsOnly)
        {
            // TODO - Does not compare auxiliary Regions object, kind-of important
            return
                region != null &&
                region.Start != null &&
                region.Start.Equals(this.Start) &&
                region.End != null &&
                region.End.Equals(this.End) &&
                (
                    pointsOnly ||
                    (this.counts == null && region.counts == null) ||
                    region.counts.Equals(this.counts)
                );
        }

        public bool fromJObject(JObject obj)
        {
            const string location = CLASSNAME + ".fromJObject";
            bool retVal = false;
            try
            {
                if (obj == null) return retVal;

                int cntErrors = 0;
                if (obj.ContainsKey("Start"))
                {
                    Pt pt = new Pt();
                    if (pt.fromJObject((JObject)obj["Start"]))
                    {
                        this.Start = pt;
                    }
                    else
                    {
                        this.Start = null;
                        cntErrors++;
                    }
                }

                if (obj.ContainsKey("End"))
                {
                    Pt pt = new Pt();
                    if (pt.fromJObject((JObject)obj["end"]))
                    {
                        this.End = pt;
                    }
                    else
                    {
                        this.End = null;
                        cntErrors++;
                    }
                }

                if (obj.ContainsKey("counts"))
                {
                    Counts cnts = new Counts();
                    if (cnts.fromJObject((JObject)obj["counts"]))
                    {
                        this.counts = cnts;
                    }
                    else
                    {
                        this.counts = null;
                        //cntErrors++;
                    }
                }

                if (obj.ContainsKey("regions"))
                {
                    JArray jRegions = (JArray)obj["regions"];
                    if (!this.regionsFromJArray(jRegions))
                    {
                        L.err(location, "Failed to extract regions from JArray.");
                    }


                    /*List<List<Region>> temp = this.regionsFromJArray(jRegions);
                    Regions regions = new Regions();
                    if (regions.fromJObject((JObject)obj["subregions"]))
                    {
                        this.regions = regions;
                    }
                    else
                    {
                        this.regions = null;
                        //cntErrors++;
                    }*/
                }

                //if (cntErrors > 0) L.l(location, "Encountered (" + cntErrors + ") errors.");

                //retVal = 0 == cntErrors;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // Choose a series of percents to break columns and rows by
        // These will scale to fit the image, as regions
        public bool fromPercentages(List<int> xBreaks, List<int> yBreaks, int characterWidth, int characterHeight)
        {
            const string location = CLASSNAME + ".fromPercentages";
            bool retVal = false;
            try
            {
                if (Config.DebugFromPercentages)
                {
                    L.l(location, "Getting regions from percentages, character width (" + characterWidth +
                        "), height (" + characterHeight + ").");
                }
                if (characterWidth <= 0 || characterHeight <= 0)
                {
                    L.err(location, "Width (" + characterWidth + ") or Height (" + characterHeight + ") invalid for regions.");
                    return retVal;
                }

                // Make sure X and Y < 100%
                int totalXPercent = 0;
                for (int i = 0; i < xBreaks.Count; i++) totalXPercent += xBreaks[i];
                if (totalXPercent > 100)
                {
                    L.err(location, "Total desired x regions (" + totalXPercent + "%) greater than 100%.");
                    return retVal;
                }

                int totalYPercent = 0;
                for (int i = 0; i < yBreaks.Count; i++) totalYPercent += yBreaks[i];
                if (totalYPercent > 100)
                {
                    L.err(location, "Total desired y regions (" + totalYPercent + "%) greater than 100%.");
                    return retVal;
                }

                // Flush all prior regions
                this.regions = null;
                this.regions = new List<List<Region>>();
                List<List<Region>> result = new List<List<Region>>();

                if (yBreaks.Count > 0 && xBreaks.Count > 0)
                {

                    // TODO - Go back to a for-loop across Y and X percents, using breaks-0 symmetrically
                    double regionWidth = ((double)characterWidth * (double)xBreaks[0]) / (double)100;
                    double regionHeight = ((double)characterHeight * (double)yBreaks[0]) / (double)100;

                    double offsetY = this.Start.y;
                    for (int idxY = 0; idxY < yBreaks.Count; idxY++)
                    {
                        //double regionHeight = ((double)characterHeight * (double)yBreaks[idxY]) / (double)100;
                        //double regionHeight = ((double)yBreaks[idxY] / (double)characterHeight) * (double)100;
                        double offsetX = this.Start.x;

                        List<Region> row = new List<Region>();
                        for (int idxX = 0; idxX < xBreaks.Count; idxX++)
                        {
                            //double regionWidth = ((double)characterWidth * (double)xBreaks[idxX]) / (double)100;
                            //double regionWidth = ((double)xBreaks[idxX] / (double)characterWidth) * (double)100;
                            Region region = new Region();
                            region.Start = new Pt()
                            {
                                x = (int)Math.Floor(offsetX),
                                y = (int)Math.Floor(offsetY)
                            };
                            region.End = new Pt()
                            {
                                x = (int)Math.Floor(region.Start.x + regionWidth),
                                y = (int)Math.Floor(region.Start.y + regionHeight)
                            };

                            if (idxX == xBreaks.Count - 1)
                            {
                                region.End.x = this.Start.x + characterWidth;
                            }
                            if (idxY == yBreaks.Count - 1)
                            {
                                region.End.y = this.Start.y + characterHeight;
                            }

                            if (region.Start.x > region.End.x || region.Start.y > region.End.y)
                            {
                                region = null;
                            }
                            // TODO - Long term, some regions in the data need to be null, 
                            // and everyone needs to deal with it. Just forcing begining
                            // to end still causes a 1px creep for every unused column or row.
                            // An I that is 4px cannot have 5 regions, not really, but also has to, kind-of, for now

                            row.Add(region);

                            // Advance to next X-pixel, stay where we are if this region ran out of room
                            if (region != null) offsetX = region.End.x + 1;
                        }
                        result.Add(row);

                        // Advance to next Y-pixel
                        //offsetY = result[idxY][result[idxY].Count - 1].End.y + 1;
                        if (result[idxY][result[idxY].Count - 1] != null)
                        { 
                            offsetY = result[idxY][result[idxY].Count - 1].End.y + 1;
                        }
                    }
                }


                // Do some validation, to ensure rows and columns are even
                int establishedX = -1;
                int cntY = -1;
                int cntX = -1;
                int cntRowErrors = 0;
                for (int y = 0; y < result.Count; y++)
                {
                    if (result[y] == null) continue;
                    cntY++;
                    cntX = 0;

                    if (establishedX < 0) establishedX = result[0].Count;

                    for (int x = 0; x < result[y].Count; x++)
                    {
                        if (
                            result[y][x] == null ||

                            result[y][x].Start == null ||
                            result[y][x].Start.x < 0 ||
                            result[y][x].Start.y < 0 ||

                            result[y][x].End == null ||
                            result[y][x].End.x < 0 ||
                            result[y][x].End.y < 0
                        ) continue;
                        cntX++;
                    }
                    if (cntX != establishedX) cntRowErrors++;
                }

                // Set regions on class
                if (Config.DebugFromPercentages)
                    L.l(location, "Outputting results [(" + result.Count + ")(" + result[0].Count + ")].");

                this.regions = result;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        /*
         * getEnd() - It is possible for more requested regions than available pixels. Not all regions
         * are possible, resulting in null regions. This method finds the point inclusive of all set-
         * pixels, but which also may be null its own self. The returned point is a substitute for sizing.
         */
        public Pt getEnd()
        {
            const string location = CLASSNAME + ".getEnd";
            Pt retVal = null;
            try
            {
                if (this.regions == null)
                {
                    L.err(location, "Sub-regions not initialized.");
                    return retVal;
                }
                int greatestX = -1;
                int greatestY = -1;

                // Try to find a valid X and Y
                for (int y = 0; y < this.regions.Count; y++)
                {
                    if (this.regions[y] == null) continue;

                    for (int x = 0; x < this.regions[y].Count; x++)
                    {
                        if (this.regions[y][x] == null) continue;
                        if (this.regions[y][x].End == null) continue;

                        if (greatestX < this.regions[y][x].End.x)
                        {
                            greatestX = this.regions[y][x].End.x;
                        }
                        if (greatestY < this.regions[y][x].End.y)
                        {
                            greatestY = this.regions[y][x].End.y;
                        }
                    }
                }

                if (greatestX >= 0 && greatestY >= 0)
                {
                    // If start exists verify, otherwise assume best value
                    if (this.Start != null)
                    {
                        if (greatestX >= this.Start.x && greatestY >= this.Start.y)
                        {
                            retVal = new Pt(greatestX, greatestY);
                        }
                    }
                    else
                    {
                        retVal = new Pt(greatestX, greatestY);
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public Region getRegion(int col, int row)
        {
            const string location = CLASSNAME + "region(ii)";
            Region retVal = null;
            try
            {
                if (this.regions == null)
                {
                    L.l(location, "Data was null at get row.");
                    return retVal;
                }
                if (row < 0 || row >= this.regions.Count)
                {
                    L.l(location, "Row (" + row + ") was out of range (0 - " + this.regions.Count + ").");
                    return retVal;
                }
                if (this.regions[row] == null)
                {
                    L.l(location, "Row (" + row + ") was null when getting column (" + col + ").");
                    return retVal;
                }
                if (col < 0 || col >= this.regions[row].Count)
                {
                    L.err(location, "Col (" + col + ") was out of bounds for row(" + row + ") (0 - " + this.regions.Count + ").");
                    return retVal;
                }
                // Allow a null value
                retVal = this.regions[row][col];
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public List<Region> getRow(int row)
        {
            const string location = CLASSNAME + "region(i)";
            List<Region> retVal = null;
            try
            {
                if (this.regions == null)
                {
                    L.l(location, "Data was null at get row.");
                    return retVal;
                }
                if (row < 0 || row >= this.regions.Count)
                {
                    L.l(location, "Row (" + row + ") was out of range (0 - " + this.regions.Count + ").");
                    return retVal;
                }
                // Allow null value without error, caller checks
                retVal = this.regions[row];
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool logRegions()
        {
            const string location = CLASSNAME + ".logRegions";
            bool retVal = false;
            try
            {
                if (this.regions == null)
                {
                    L.err(location, "Regions were null at logging.");
                    return retVal;
                }

                for (int y = 0; y < this.regions.Count; y++)
                {
                    if (this.regions[y] == null) continue;

                    StringBuilder sb = new StringBuilder();
                    for (int x = 0; x < this.regions[y].Count; x++)
                    {
                        if (this.regions[y][x] == null) continue;
                        sb.Append("[(");
                        if (this.regions[y][x].Start == null)
                        {
                            sb.Append("Null Start");
                        }
                        else
                        {
                            sb.Append(this.regions[y][x].Start.x)
                                .Append(", ")
                                .Append(this.regions[y][x].Start.y);
                        }
                        sb.Append("), (");
                        if (this.regions[y][x].End == null)
                        {
                            sb.Append("Null End");
                        }
                        else
                        {
                            sb.Append(this.regions[y][x].End.x)
                                .Append(", ")
                                .Append(this.regions[y][x].End.y);
                        }
                        sb.Append(")]");
                    }

                    L.l(location, "Row (" + y + "): " + sb.ToString());
                    sb.Clear();
                }

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool regionsFromJArray(JArray jRegions)
        {
            const string location = CLASSNAME + ".regionsFromJArray";
            bool retVal = false;
            try
            {
                this.regions = null;

                if (jRegions == null)
                {
                    L.err(location, "Input json was null.");
                    return retVal;
                }

                List<List<Region>> list = new List<List<Region>>();
                for (int y = 0; y < jRegions.Count; y++)
                {
                    List<Region> row = new List<Region>();
                    if (jRegions[y] == null)
                    {
                        list.Add(row);
                        continue;
                    }

                    JArray inRow = (JArray)jRegions[y];
                    for (int x = 0; x < inRow.Count; x++)
                    {
                        Region temp = null;
                        if (inRow[x] != null)
                        {
                            JObject inField = (JObject)inRow[x];
                            if (inField == null || inField.Count == 0)
                            {
                                row.Add(null);
                                continue;
                            }

                            temp = new Region();
                            if (!temp.fromJObject(inField))
                            {
                                row.Add(null);
                                continue;
                            }
                            row.Add(temp);
                        }
                    }
                    list.Add(row);
                }

                this.regions = list;
                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public JArray regionsToJArray()
        {
            const string location = CLASSNAME + ".regionsToJArray";
            JArray retVal = new JArray();
            try
            {
                if (this.regions == null)
                {
                    L.err(location, "Data not initialized at to json.");
                    return retVal;
                }

                for (int y = 0; y < this.regions.Count; y++)
                {
                    JArray row = new JArray();
                    if (this.regions[y] == null)
                    {
                        retVal.Add(row);
                        continue;
                    }
                    
                    for (int x = 0; x < this.regions[y].Count; x++)
                    {
                        JObject obj = new JObject();
                        if (this.regions[y][x] != null)
                            obj = this.regions[y][x].toJObject();
                        row.Add(obj);
                    }
                    retVal.Add(row);
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // TODO - SumCounts -> static
        public Counts SumCounts()
        {
            const string location = CLASSNAME + ".SumCounts";
            Counts retVal = new Counts();
            try
            {
                if (this.regions == null)
                {
                    L.err(location, "Regions were null when summing counts.");
                    return retVal;
                }

                Counts sums = new Counts();
                int cntNullY = 0;
                int cntNullX = 0;
                int cntNullCounts = 0;
                for (int idxY = 0; idxY < this.regions.Count; idxY++)
                {
                    if (this.regions[idxY] == null)
                    {
                        cntNullY++;
                        continue;
                    }
                    for (int idxX = 0; idxX < this.regions[idxY].Count; idxX++)
                    {
                        if (this.regions[idxY][idxX] == null)
                        {
                            cntNullX++;
                            continue;
                        }
                        if (this.regions[idxY][idxX].counts == null)
                        {
                            cntNullCounts++;
                            continue;
                        }

                        Counts temp = this.regions[idxY][idxX].counts;
                        sums.ttlSet += temp.ttlSet;
                        sums.ttlUnset += temp.ttlUnset;


                        sums.ttlX += temp.ttlX;
                        sums.ttlY += temp.ttlY;
                        sums.avgX += temp.avgX;
                        sums.avgY += temp.avgY;
                        sums.ttlDistance += temp.ttlDistance;
                        sums.avgDistance += temp.avgDistance;
                        sums.ttlDistanceX += temp.ttlDistanceX;
                        sums.ttlDistanceY += temp.ttlDistanceY;
                        sums.avgDistanceX += temp.avgDistanceX;
                        sums.avgDistanceY += temp.avgDistanceY;

                        sums.setLeft += temp.setLeft;
                        sums.setTop += temp.setTop;
                        sums.setRight += temp.setRight;
                        sums.setBottom += temp.setBottom;

                        sums.unsetLeft += temp.unsetLeft;
                        sums.unsetTop += temp.unsetTop;
                        sums.unsetRight += temp.unsetRight;
                        sums.unsetBottom += temp.unsetBottom;

                        sums.ttl += temp.ttl;
                        sums.counted += temp.counted;

                        sums.perTtlSet += temp.perTtlSet;
                        sums.perTtlUnset += temp.perTtlUnset;
                        sums.perAvgX += temp.perAvgX;
                        sums.perAvgY += temp.perAvgY;
                        sums.perAvgDistanceX += temp.perAvgDistanceX;
                        sums.perAvgDistanceY += temp.perAvgDistanceY;
                        sums.perSetLeft += temp.perSetLeft;
                        sums.perSetTop += temp.perSetTop;
                        sums.perSetRight += temp.perSetRight;
                        sums.perSetBottom += temp.perSetBottom;
                        sums.perUnsetLeft += temp.perUnsetLeft;
                        sums.perUnsetTop += temp.perUnsetTop;
                        sums.perUnsetRight += temp.perUnsetRight;
                        sums.perUnsetBottom += temp.perUnsetBottom;

                    }
                }

                if (cntNullX > 0 || cntNullY > 0 || cntNullCounts > 0)
                {
                    L.err(location, "Encountered nulls, x (" + cntNullX + "), y (" + cntNullY + "), counts (" + cntNullCounts + ").");
                }

                // Output Result
                retVal = sums;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public JObject toJObject()
        {
            const string location = CLASSNAME + ".toJObject";
            JObject retVal = new JObject();
            try
            {
                JObject obj = new JObject();
                obj.Add("Start", this.Start == null ? new JObject() : this.Start.toJObject());
                obj.Add("End", this.End == null ? new JObject() : this.End.toJObject());
                obj.Add("counts", this.counts == null ? new JObject() : this.counts.toJObject());
                //obj.Add("subregions", this.regions == null ? new JObject() : this.regions.toJObject());
                obj.Add("regions", this.regions == null ? new JArray() : this.regionsToJArray());
                retVal = obj;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public string toString()
        {
            return "Start (" + (this.Start == null ? "NULL" : (this.Start.x + ", " + this.Start.y)) + "), " +
                "End (" + (this.End == null ? "NULL" : (this.End.x + ", " + this.End.y)) + ")";
        }

    }
}
