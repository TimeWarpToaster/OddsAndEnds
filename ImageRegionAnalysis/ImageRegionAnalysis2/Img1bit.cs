using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ImageRegionAnalysis2
{
    public class Bits
    {
        public const string CLASSNAME = "Bits";

        public BitArray ba { get; set; }

        private int width = 0;
        public int Width => this.width;

        private int height = 0;
        public int Height => this.height;


        public List<Region> textRows = new List<Region>();
        public Region characters = new Region(0, 0, new Pt());




        public Bits() { }


        public List<Region> columnsFromRegion(Region region)
        {
            const string location = CLASSNAME + ".columnsFromRegion";
            List<Region> retVal = new List<Region>();
            try
            {
                if (region == null || region.Start == null || region.End == null)
                {
                    //L.err(location, "Region or one of its points was null.");
                    return retVal;
                }

                // TODO - Rewrite the below
                // Validate region against ba
                // Iterate over region of ba

                L.l(location, "Finding characters over region start (" + region.Start.toString() + 
                    "), end (" + region.End.toString() + ").");

                float percentRequired = 0.05f;

                // We are counting X as a vertical column, that's why it's Y for cntRequired, out of height
                //int cntRequired = (int)((region.End.y - region.Start.y) * percentRequired) | 0;
                int cntRequired = 1;

                //L.l(location, "Looking for count required (" + cntRequired + ") over (" + (region.End.x - region.Start.x) + ").");

                List<int> cntSetX = new List<int>();
                int cntElements = region.End.x - region.Start.x + 1;
                for (int i = 0; i < cntElements; i++) cntSetX.Add(0);


                int offsetSetX = 0;
                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    offsetSetX = 0;
                    int offset = y * this.width;

                    for (int x = region.Start.x; x <= region.End.x; x++, offsetSetX++)
                    {
                        if (this.ba[offset + x] == true) cntSetX[offsetSetX]++;
                    }
                }

                int startTrueX = -1;
                List<Region> regions = new List<Region>();
                for (int x = 0; x < cntSetX.Count; x++)
                {
                    if (cntSetX[x] > cntRequired)
                    {
                        if (startTrueX < 0) startTrueX = x + region.Start.x;
                    }
                    else if (startTrueX >= 0)
                    {
                        // Completed a region
                        Region charRegion = new Region()
                        {
                            Start = new Pt() { x = startTrueX, y = region.Start.y },
                            End = new Pt() { x = x + region.Start.x - 1, y = region.End.y }//-1 because last col ended
                        };
                        regions.Add(charRegion);
                        startTrueX = -1;
                    }
                }

                // Test if we are in a region. Complete if open and space allows.
                if (startTrueX >= 0 && startTrueX < region.End.x)
                {
                    Region charRegion = new Region()
                    {
                        Start = new Pt() { x = startTrueX, y = region.Start.y },
                        End = new Pt() { x = region.End.x, y = region.End.y }
                    };
                    regions.Add(charRegion);
                }

                
                /*// TODO - Resume cropping characters vertically
                List<Region> croppedV = cropRegionsV(regions);
                if (croppedV == null)
                {
                    L.err(location, "Character regions were null after cropping vertically.");
                }
                else if (croppedV.Count != regions.Count)
                {
                    L.err(location, "Cropped results (" + croppedV.Count + 
                        ") contained a different number of characters than sent (" + regions.Count + ").");
                }
                else 
                {
                    int nullIn = 0;
                    int nullOut = 0;
                    for (int i = 0; i < croppedV.Count && i < regions.Count; i++)
                    {
                        if (regions[i] == null) nullIn++;
                        if (croppedV[i] == null) nullOut++;
                    }
                    if (nullIn != nullOut)
                    {
                        L.err(location, "Inconsistent crop count.");
                    }
                    else
                    {
                        // Succeed with crops
                        regions = croppedV;
                    }
                }*/

                // Output Result
                retVal = regions;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int countAll(bool value)
        {
            const string location = CLASSNAME + ".countAll";
            int retVal = -1;
            try
            {
                if (ba == null)
                {
                    L.err(location, "Data was null at count.");
                    return retVal;
                }

                int cntMatch = 0;
                for (int i = 0; i < this.ba.Length; i++) if (value == this.ba[i]) cntMatch++;
                retVal = cntMatch;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public List<List<int>> countCharacterRegions(int row, int col, bool value)
        {
            const string location = CLASSNAME + ".countCharacterRegions";
            List<List<int>> retVal = new List<List<int>>();
            try
            {
                if (this.characters == null)
                {
                    L.err(location, "Characters data was null.");
                    return retVal;
                }

                Region character = ls.get(this.characters.regions, row, col);
                if (character == null)
                {
                    L.err(location, "Failed to locate character at row (" + row + "), col (" + col + ").");
                    return retVal;
                }
                if (character.regions == null)
                {
                    L.err(location, "Character sub regions were null at row (" + row + "), col (" + col + ").");
                    return retVal;
                }
                List<List<Region>> subRegions = character.regions;

                List<List<int>> result = new List<List<int>>();
                for (int y = 0; y < subRegions.Count; y++)
                {
                    for (int x = 0; x < subRegions[y].Count; x++)
                    {
                        Region temp = subRegions[y][x];
                        int counted = this.countRegion(ref temp);
                        int cntMatch = value == true ? subRegions[y][x].counts.ttlSet : subRegions[y][x].counts.ttlUnset;
                        subRegions[y][x] = temp;
                    }
                }

                retVal = result;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public Counts countLine(bool matchVal, int y1, int y2)// they go all the way across
        {
            const string location = CLASSNAME + ".countLine";
            Counts retVal = null;
            //int retVal = -1;
            try
            {
                if (this.ba == null)
                {
                    L.err(location, "Image data was null.");
                    return retVal;
                }
                if (this.ba.Count == 0 || this.ba.Count != this.width * this.height)
                {
                    L.err(location, "Image not initialized. Size (" + this.ba.Count + "), width (" + this.width + 
                        "), height (" + this.height + "), expected (" + (this.width * this.height) + ").");
                    return retVal;
                }
                if (y1 < 0 || y1 >= this.height || y2 < 0 || y2 >= this.height)
                {
                    L.err(location, "Y1 (" + y1 + ") or Y2 (" + y2 + ") was out of range (0 - " + (this.height - 1) + ").");
                    return retVal;
                }

                int diffY = y1 - y2;
                if (diffY < 0) diffY *= -1;

                double rise = diffY <= 0 ? 0 : ((double)diffY / (double)this.width);

                double fromY1 = 0d;

                // For counting left-right orientation of "most-set"
                int midX = this.width / 2 | 0;

                Counts counts = new Counts();
                for (int x = 0; x < this.width; x++)
                {
                    //L.l(location, "From Y1 (" + fromY1 + "), rise (" + rise + "), x (" + x + "), diffY (" + diffY + ").");
                    int y = (int)(y1 > y2 ? y1 - fromY1 : y1 + fromY1);
                    int offset = (y * this.width) + x;
                    if (offset > 0 && offset < this.ba.Count)
                    {
                        if (this.ba[offset] == matchVal)
                        {
                            counts.ttlSet++;
                            if (x < midX) counts.setLeft++; // 0-index
                            else counts.setRight++;
                        }
                        else 
                        {
                            counts.ttlUnset++;
                        }
                    }
                    fromY1 += rise;
                }

                // Output result
                retVal = counts;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // TODO - Revice countRegions arguments, use new countRegion method to work on local data
        public List<List<int>> countRegions(Region regions, bool value)
        {
            const string location = CLASSNAME + ".countRegions";
            List<List<int>> retVal = new List<List<int>>();
            try
            {
                if (regions == null)
                {
                    L.err(location, "Input regions was null.");
                    return retVal;
                }

                List<List<int>> result = new List<List<int>>();
                for (int y = 0; y < regions.regions.Count; y++)
                {
                    List<int> row = new List<int>();
                    for (int x = 0; x < regions.regions[y].Count; x++)
                    {
                        if (regions.regions[y][x] == null)
                        {
                            row.Add(0);
                            continue;
                        }
                        Region temp = regions.regions[y][x];
                        int counted = this.countRegion(ref temp);
                        regions.regions[y][x] = temp;
                        int cntMatch = -1;
                        if (regions.regions[y][x].counts != null)
                        {
                            cntMatch = value == true ? regions.regions[y][x].counts.ttlSet : regions.regions[y][x].counts.ttlUnset;
                        }
                        row.Add(cntMatch);
                    }
                    result.Add(row);
                }

                retVal = result;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private int countRegion(int characterRow, int characterCol, int roiRow, int roiCol /*, Region region/*, bool value*/)
        {
            const string location = CLASSNAME + ".countRegion";
            int retVal = -1;
            try
            {
                // For all intents and purposes, assume local caller checked characters, row, and column
                if (this.ba == null)
                {
                    L.err(location, "Data not initialized at count region.");
                    return retVal;
                }
                // TODO - Check characters
                // TODO - Check characters.subregions

                Region region = this.characters.regions[characterRow][characterCol].regions[roiRow][roiCol];
                if (region == null)
                {
                    L.err(location, "Input region was null.");
                    return retVal;
                }
                if (region.End == null || region.Start == null)
                {
                    L.err(location, "Region start or end point was null.");
                    return retVal;
                }
                if (region.Start.x < 0 || region.Start.y < 0 || region.End.x < 0 || region.End.y < 0)
                {
                    L.err(location, "Start or end x or y less than zero.");
                    return retVal;
                }
                if (region.Start.x > region.End.x || region.Start.y > region.End.y)
                {
                    L.err(location, "Region start greater than region end. Start: " + region.Start.toString() +
                        ". End: " + region.End.toString() + ".");
                    return retVal;
                }
                int maxRegionOffset = (region.End.y * this.width) + region.End.x;
                if (maxRegionOffset >= this.ba.Length)
                {
                    L.err(location, "Region max offset (" + maxRegionOffset + ") greater than total (" + this.ba.Length + ").");
                    return retVal;
                }

                // Clear old counts, then begin
                region.counts = new Counts();
                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    int rowOffset = y * this.width;
                    for (int x = region.Start.x; x <= region.End.x; x++)
                    {
                        if (this.ba[rowOffset + x] == true)
                        {
                            region.counts.ttlSet++;
                        }
                        else
                        {
                            region.counts.ttlUnset++;
                        }
                    }
                }

                retVal = region.counts.ttlSet + region.counts.ttlUnset;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int countRegion(ref Region region)
        {
            const string location = CLASSNAME + ".countRegion";
            int retVal = -1;
            try
            {
                if (this.ba == null)
                {
                    L.err(location, "Data not initialized at count region.");
                    return retVal;
                }
                if (region == null)
                {
                    // This is no longer an error condition, count as zero
                    //L.err(location, "Input region was null.");
                    return 0;
                }
                if (region.End == null || region.Start == null)
                {
                    L.err(location, "Region start or end point was null.");
                    return retVal;
                }
                if (region.Start.x < 0 || region.Start.y < 0 || region.End.x < 0 || region.End.y < 0)
                {
                    L.err(location, "Start or end x or y less than zero.");
                    return retVal;
                }
                if (region.Start.x > region.End.x || region.Start.y > region.End.y)
                {
                    L.err(location, "Region start greater than region end. Start: " + region.Start.toString() +
                        ". End: " + region.End.toString() + ".");
                    return retVal;
                }
                int maxRegionOffset = (region.End.y * this.width) + region.End.x;
                if (maxRegionOffset >= this.ba.Length)
                {
                    L.err(location, "Region max offset (" + maxRegionOffset + ") greater than total (" + this.ba.Length + ").");
                    return retVal;
                }

                // Clear old counts, then begin
                int width = region.End.x - region.Start.x + 1;
                int height = region.End.y - region.Start.y + 1;

                int midY = region.Start.y + ((region.End.y - region.Start.y) / 2);
                int midX = region.Start.x + ((region.End.x - region.Start.x) / 2);
                region.counts = new Counts();
                for (int i = 0; i < height; i++)
                {
                    region.counts.blankLeft.Add(-1);
                    region.counts.blankRight.Add(-1);
                    region.counts.perBlankLeft.Add(0);
                    region.counts.perBlankRight.Add(0);
                }
                for (int i = 0; i < width; i++)
                {
                    region.counts.blankTop.Add(-1);
                    region.counts.blankBottom.Add(-1);
                    region.counts.perBlankTop.Add(0);
                    region.counts.perBlankBottom.Add(0);
                }

                int cWidth = region.End.x - region.Start.x + 1;
                int cHeight = region.End.y - region.Start.y + 1;
                region.counts.ttl = cWidth * cHeight; // .ttl is a calculation, .counted is processed

                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    int rowOffset = y * this.width;
                    for (int x = region.Start.x; x <= region.End.x; x++)
                    {
                        if (rowOffset + x >= this.ba.Length)
                        {
                            L.err(location, "Offset (" + (rowOffset + x) + ") out of range (" + this.ba.Length + ").");
                        }
                        if (this.ba[rowOffset + x] == true)
                        {
                            region.counts.ttlSet++;
                            region.counts.ttlX += x;
                            region.counts.ttlY += y;// per-pixel
                            if (x < midX) region.counts.setLeft++;
                            else region.counts.setRight++;
                            if (y < midY) region.counts.setTop++;
                            else region.counts.setBottom++;

                            // Get a distance of set pixels from region center
                            {
                                int diffX = x < midX ? midX - x : x - midX;
                                int diffY = y < midY ? midY - y : y - midY;

                                double distance = Math.Sqrt(((diffX * diffX) + (diffY * diffY)));
                                region.counts.ttlDistance += distance;

                                region.counts.ttlDistanceX += diffX;
                                region.counts.ttlDistanceY += diffY;
                            }

                            //region.counts.ttlDistanceX += (x - midX);
                            //region.counts.ttlDistanceY += (y - midY);
                        }
                        else
                        {
                            region.counts.ttlUnset++;
                            if (x < midX) region.counts.unsetLeft++;
                            else region.counts.unsetRight++;
                            if (y < midY) region.counts.unsetTop++;
                            else region.counts.unsetBottom++;
                        }
                        region.counts.counted++;
                    }
                }

                // TODO - Move ttlDirectionals into in-line counting
                region.counts.ttlLeft = region.counts.setLeft + region.counts.unsetLeft;
                region.counts.ttlTop = region.counts.setTop + region.counts.unsetTop;
                region.counts.ttlRight = region.counts.setRight + region.counts.unsetRight;
                region.counts.ttlBottom = region.counts.setBottom + region.counts.unsetBottom;

                // Get percentages for set halves
                if (region.counts.ttlLeft > 0)
                {
                    region.counts.perSetLeft =
                        ((double)region.counts.setLeft / (double)region.counts.ttlLeft) * (double)100;
                    region.counts.perUnsetLeft =
                        ((double)region.counts.unsetLeft / (double)region.counts.ttlLeft) * (double)100;
                }
                if (region.counts.ttlTop > 0)
                {
                    region.counts.perSetTop =
                        ((double)region.counts.setTop / (double)region.counts.ttlTop) * (double)100;
                    region.counts.perUnsetTop =
                        ((double)region.counts.unsetTop / (double)region.counts.ttlTop) * (double)100;
                }
                if (region.counts.ttlRight > 0)
                {
                    region.counts.perSetRight =
                        ((double)region.counts.setRight / (double)region.counts.ttlRight) * (double)100;
                    region.counts.perUnsetRight =
                        ((double)region.counts.unsetRight / (double)region.counts.ttlRight) * (double)100;
                }
                if (region.counts.ttlBottom > 0)
                {
                    region.counts.perSetBottom =
                        ((double)region.counts.setBottom / (double)region.counts.ttlBottom) * (double)100;
                    region.counts.perUnsetBottom =
                        ((double)region.counts.unsetBottom / (double)region.counts.ttlBottom) * (double)100;
                }

                // Get percent set and unset overall
                if (region.counts.counted > 0)// Not sure that I want to use counted here... it is most accurate with respect to data, not anticipated
                {
                    region.counts.perTtlSet =
                        ((double)region.counts.ttlSet / (double)region.counts.counted) * (double)100;
                    region.counts.perTtlUnset =
                        ((double)region.counts.ttlUnset / (double)region.counts.counted) * (double)100;
                }

                // Get average distances and X,Y accruals
                if (region.counts.ttlSet > 0)
                {
                    region.counts.ttlX -= (region.Start.x * region.counts.ttlSet);// reduce X and Y by start
                    region.counts.ttlY -= (region.Start.y * region.counts.ttlSet);

                    if (region.counts.ttlX > 0)
                    {
                        region.counts.avgX = region.counts.ttlX / region.counts.ttlSet;
                        if (width > 0)
                        {
                            // High percent indicates right-bound
                            region.counts.perAvgX = ((double)region.counts.avgX / (double)width) * (double)100;
                        }

                    }
                    if (region.counts.ttlY > 0)
                    {
                        region.counts.avgY = region.counts.ttlY / region.counts.ttlSet;
                        if (height > 0)
                        {
                            // High-percent indicates bottom-bound
                            region.counts.perAvgY = ((double)region.counts.avgY / (double)height) * (double)100;
                        }
                    }

                    // Get average distances from center
                    region.counts.avgDistance = (double)region.counts.ttlDistance / (double)region.counts.ttlSet;
                    region.counts.avgDistanceX = (double)region.counts.ttlDistanceX / (double)region.counts.ttlSet;
                    region.counts.avgDistanceY = (double)region.counts.ttlDistanceY / (double)region.counts.ttlSet;

                    // Get average distances from center as percent of width and height
                    if (width > 0)
                    {
                        region.counts.perAvgX = ((double)region.counts.avgX / (double)width) * (double)100;
                        region.counts.perAvgDistanceX = ((double)region.counts.avgDistanceX / (double)width) * (double)100;
                    }
                    if (height > 0)
                    {
                        region.counts.perAvgY = ((double)region.counts.avgY / (double)height) * (double)100;
                        region.counts.perAvgDistanceY = ((double)region.counts.avgDistanceY / (double)height) * (double)100;
                    }
                }


                // TODO - Default all "blanks" counts to width/height if not found (i.e. all-blank), look for < 0

                // Quick loops to count blank pixels outside character
                //L.l(location, "Preparing perimeter counts.");
                for (int y = region.Start.y, iY = 0; y <= region.End.y; y++, iY++)
                {
                    int rowOffset = y * this.width;
                    for (int x = region.Start.x, iX = 0; x <= region.End.x; x++, iX++)
                    {
                        if (this.ba[rowOffset + x] == true)
                        {
                            if (region.counts.blankLeft[iY] < 0)
                            {
                                region.counts.blankLeft[iY] = iX;
                            }
                            break;
                        }
                    }

                    for (int x = region.End.x, iX = 0; x >= region.Start.x; x--, iX++)
                    {
                        if (this.ba[rowOffset + x] == true)
                        {
                            if (region.counts.blankRight[iY] < 0)
                            {
                                region.counts.blankRight[iY] = iX;
                            }
                            break;
                        }
                    }
                }

                // TODO - Flip the top and bottom blanks to iterate Y once, try to calculate offsets once
                for (int x = region.Start.x, iX = 0; x <= region.End.x; x++, iX++)
                {
                    for (int y = region.Start.y, iY = 0; y <= region.End.y; y++, iY++)
                    {
                        if (this.ba[(y * this.width) + x] == true)
                        {
                            if (region.counts.blankTop[iX] < 0)
                            {
                                region.counts.blankTop[iX] = iY;
                            }
                            break;
                        }
                    }

                    for (int y = region.End.y, iY = 0; y >= region.Start.y; y--, iY++)
                    {
                        if (this.ba[(y * this.width) + x] == true)
                        {
                            if (region.counts.blankBottom[iX] < 0)
                            {
                                region.counts.blankBottom[iX] = iY;
                            }
                            break;
                        }
                    }
                }


                // Push negatives to max
                for (int i = 0; i < region.counts.blankLeft.Count; i++)
                    if (region.counts.blankLeft[i] < 0)
                        region.counts.blankLeft[i] = height;
                for (int i = 0; i < region.counts.blankRight.Count; i++)
                    if (region.counts.blankRight[i] < 0)
                        region.counts.blankRight[i] = height;
                for (int i = 0; i < region.counts.blankTop.Count; i++)
                    if (region.counts.blankTop[i] < 0)
                        region.counts.blankTop[i] = width;
                for (int i = 0; i < region.counts.blankBottom.Count; i++)
                    if (region.counts.blankBottom[i] < 0)
                        region.counts.blankBottom[i] = width;

                //L.l(location, "Finished preparing perimeter counts.");


                // Get percentages for perimeter blanks
                if (width > 0)
                {
                    for (int i = 0; i < region.counts.blankLeft.Count && i < region.counts.perBlankLeft.Count; i++)
                        region.counts.perBlankLeft[i] = ((double)region.counts.blankLeft[i] / (double)width) * (double)100;
                    for (int i = 0; i < region.counts.blankRight.Count && i < region.counts.perBlankRight.Count; i++)
                        region.counts.perBlankRight[i] = ((double)region.counts.blankRight[i] / (double)width) * (double)100;
                }
                if (height > 0)
                {
                    for (int i = 0; i < region.counts.blankTop.Count && i < region.counts.perBlankTop.Count; i++)
                        region.counts.perBlankTop[i] = ((double)region.counts.blankTop[i] / (double)height) * (double)100;
                    for (int i = 0; i < region.counts.blankBottom.Count && i < region.counts.perBlankBottom.Count; i++)
                        region.counts.perBlankBottom[i] = ((double)region.counts.blankBottom[i] / (double)height) * (double)100;
                }

                retVal = region.counts.ttlSet + region.counts.ttlUnset;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int countRegionBak(ref Region region)
        {
            const string location = CLASSNAME + ".countRegion";
            int retVal = -1;
            try
            {
                if (this.ba == null)
                {
                    L.err(location, "Data not initialized at count region.");
                    return retVal;
                }
                if (region == null)
                {
                    // This is no longer an error condition, count as zero
                    //L.err(location, "Input region was null.");
                    return 0;
                }
                if (region.End == null || region.Start == null)
                {
                    L.err(location, "Region start or end point was null.");
                    return retVal;
                }
                if (region.Start.x < 0 || region.Start.y < 0 || region.End.x < 0 || region.End.y < 0)
                {
                    L.err(location, "Start or end x or y less than zero.");
                    return retVal;
                }
                if (region.Start.x > region.End.x || region.Start.y > region.End.y)
                {
                    L.err(location, "Region start greater than region end. Start: " + region.Start.toString() + 
                        ". End: " + region.End.toString() + ".");
                    return retVal;
                }
                int maxRegionOffset = (region.End.y * this.width) + region.End.x;
                if (maxRegionOffset >= this.ba.Length)
                {
                    L.err(location, "Region max offset (" + maxRegionOffset + ") greater than total (" + this.ba.Length + ").");
                    return retVal;
                }

                // Clear old counts, then begin
                int midY = region.Start.y + ((region.End.y - region.Start.y) / 2);
                int midX = region.Start.x + ((region.End.x - region.Start.x) / 2);
                region.counts = new Counts();
                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    int rowOffset = y * this.width;
                    for (int x = region.Start.x; x <= region.End.x; x++)
                    {
                        if (this.ba[rowOffset + x] == true)
                        {
                            region.counts.ttlSet++;
                            if (x < midX) region.counts.setLeft++;
                            else region.counts.setRight++;
                            if (y < midY) region.counts.setTop++;
                            else region.counts.setBottom++;
                        }
                        else 
                        {
                            region.counts.ttlUnset++;
                            if (x < midX) region.counts.unsetLeft++;
                            else region.counts.unsetRight++;
                            if (y < midY) region.counts.unsetTop++;
                            else region.counts.unsetBottom++;
                        }
                    }
                }

                retVal = region.counts.ttlSet + region.counts.ttlUnset;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public List<Region> cropRegionsV(List<Region> inRegions)
        {
            const string location = CLASSNAME + ".cropRegionsV";
            List<Region> retVal = inRegions;
            try
            {
                L.l(location, "Crop regions start.");
                if (inRegions == null)
                {
                    L.err(location, "Input regions was null.");
                    return retVal;
                }
                if (this.ba == null)
                {
                    L.err(location, "Data not initialized at vertical crops.");
                    return retVal;
                }
                L.l(location, "Begin iterate.");

                List<Region> regions = new List<Region>();
                for (int i = 0; i < inRegions.Count; i++)
                {
                    if (inRegions[i] == null)
                    {
                        L.l(location, "Found a null region.");
                        regions.Add(null);
                        continue;
                    }
                    if (inRegions[i].Start == null || inRegions[i].End == null)
                    {
                        L.l(location, "Found a null start or end.");
                        regions.Add(inRegions[i]);
                        continue;
                    }

                    int cntRequired = 2;
                    int topY = inRegions[i].Start.y;
                    int bottomY = inRegions[i].End.y;
                    int topYFound = -1;
                    int bottomYFound = -1;

                    L.l(location, "Finding top.");
                    for (int y = topY; topYFound < 0 && y <= bottomY; y++)
                    {
                        int offsetRow = y * this.width;
                        int cntSet = 0;
                        for (int x = inRegions[i].Start.x; x <= inRegions[i].End.x; x++)
                        {
                            if (this.ba[offsetRow + x] == true)
                            {
                                cntSet++;
                                if (cntSet >= cntRequired)
                                {
                                    L.l(location, "Found top Y (" + y + ").");
                                    topYFound = y;
                                    break;
                                }
                            }
                        }
                    }

                    L.l(location, "Finding bottom.");
                    for (int y = bottomY; bottomYFound < 0 && y >= topY; y--)
                    {
                        int offsetRow = y * this.width;
                        int cntSet = 0;
                        for (int x = inRegions[i].Start.x; x <= inRegions[i].End.x; x++)
                        {
                            if (this.ba[offsetRow + x] == true)
                            {
                                cntSet++;
                                if (cntSet >= cntRequired)
                                {
                                    L.l(location, "Found bottom Y (" + y + ").");
                                    bottomYFound = y;
                                    break;
                                }
                            }
                        }
                    }
                    L.l(location, "Creating crop at top (" + topYFound + "), bottom (" + bottomYFound + ").");

                    if (topYFound < 0 || bottomYFound < 0)
                    {
                        L.l(location, "Failed to find top (" + topYFound + ") or bottom (" + bottomYFound + ").");
                        // just give the region back
                        regions.Add(inRegions[i]);
                    }
                    else 
                    {
                        L.l(location, "Adding cropped region to output.");
                        Region region = new Region();
                        region.Start = new Pt(inRegions[i].Start.x, topY);
                        region.End = new Pt(inRegions[i].End.x, bottomY);
                        /*region.Start.x = inRegions[i].Start.x;
                        region.Start.y = topY;
                        region.End.x = inRegions[i].End.x;
                        region.End.y = bottomY;*/
                        regions.Add(region);
                        L.l(location, "Added cropped region to output.");
                    }
                }

                // Output Result
                L.l(location, "Outputting result.");
                retVal = regions;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fromBitmap(Bitmap bmp, int rgbThresh) // average intensity of rgb
        {
            const string location = CLASSNAME + ".fromBitmap";
            bool retVal = false;
            try
            {
                if (bmp == null)
                {
                    L.err(location, "Input Bitmap was null.");
                    return retVal;
                }
                this.width = bmp.Width;
                this.height = bmp.Height;

                this.ba = null;
                this.ba = new BitArray(this.width * this.height, false);

                for (int y = 0, offset = 0; y < bmp.Height && offset < this.ba.Length; y++)
                {
                    for (int x = 0; x < bmp.Width && offset < this.ba.Length; x++, offset++)
                    {
                        Color color = bmp.GetPixel(x, y);

                        // TODO - Dividing is slow, so is get pixel, but not as much as they say
                        if (((color.R + color.G + color.B) / 3) < rgbThresh) 
                        {
                            this.ba[offset] = true;
                        }
                        else 
                        {
                            this.ba[offset] = false;
                        }
                    }
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool isValid(Region region)
        {
            return
                this.ba != null &&
                this.ba.Length > 0 &&
                region != null &&
                region.Start != null &&
                region.Start.x >= 0 &&
                region.Start.y >= 0 &&
                region.End != null &&
                region.End.x >= 0 &&
                region.End.y >= 0 &&
                region.Start.x < region.End.x &&// These two could result in automatic flip if paired (same >)
                region.Start.y < region.End.y &&
                region.Start.x < this.ba.Length &&
                region.Start.y < this.ba.Length &&
                region.End.x < this.ba.Length &&
                region.End.y < this.ba.Length;
        }

        public bool linesFromBits()
        {
            const string location = CLASSNAME + ".linesFromBits";
            bool retVal = false;
            try
            {
                // Clear old data
                this.textRows = new List<Region>();

                // Validate necessities
                if (this.ba == null)
                {
                    L.err(location, "Input bits was null.");
                    return retVal;
                }
                if (this.Width * this.Height != this.ba.Length)
                {
                    L.err(location, "Expected size (" + (this.Width * this.Height) +
                        ") mismatch versus actual (" + this.ba.Length + ").");
                    return retVal;
                }

                // TODO - The following numRequired was failing on uppercase line for tail of Q, getting segmented into new short-line.
                // For now, requiring perfect noise reduction, until time to find objects instead of single-set.
                float percentRequired = 0.01f;
                //int numRequired = (int)(percentRequired * this.Width);
                int numRequired = 1;

                // Get counts of set pixels for each column
                List<int> cntRows = new List<int>();
                for (int y = 0; y < this.Height; y++)
                {
                    int offset = y * this.Width;
                    int cntSetRow = 0;

                    for (int x = 0; x < this.Width; x++, offset++)
                    {
                        if (this.ba[offset] == true) cntSetRow++;
                    }
                    cntRows.Add(cntSetRow);
                }

                // Scan counts for regions
                List<Region> regions = new List<Region>();
                int rowStart = -1;
                for (int y = 0; y < cntRows.Count; y++)
                {
                    if (cntRows[y] > numRequired)
                    {
                        if (rowStart < 0) rowStart = y;
                    }
                    else if (rowStart >= 0)
                    {
                        // We have a start and end row, make a full width region
                        Region region = new Region()
                        {
                            Start = new Pt() { x = 0, y = rowStart },
                            End = new Pt() { x = this.width - 1, y = y - 1 }//-1 because last row ended
                        };
                        regions.Add(region);
                        rowStart = -1;
                    }
                }

                // Test if we are in a region. Complete if open and space allows.
                if (rowStart >= 0 && rowStart < this.height - 1)
                {
                    Region openRegion = new Region()
                    {
                        Start = new Pt() { x = 0, y = rowStart },
                        End = new Pt() { x = this.width - 1, y = this.height - 1 }
                    };
                    regions.Add(openRegion);
                }

                // Output result
                this.textRows = regions;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public Bitmap linesToBitmap(List<Region> lines)// textual lines
        {
            const string location = CLASSNAME + ".linesToBitmap";
            Bitmap retVal = null;
            try
            {
                if (lines == null)
                {
                    L.err(location, "Input line regions were null.");
                    return retVal;
                }

                int padBetweenLines = 10;// fill this space with buff/grey

                int ttlRegionHeights = 0;
                for (int i = 0; i < lines.Count; i++)
                {
                    ttlRegionHeights += (lines[i].End.y - lines[i].Start.y + 1);
                }
                L.l(location, "ttlRegionHeight (" + ttlRegionHeights + ").");

                int ttlPadHeight = (lines.Count + 1) * padBetweenLines;// fencepost the padding
                L.l(location, "ttlPadHeight (" + ttlPadHeight + ").");

                int imgHeight = ttlRegionHeights + ttlRegionHeights;
                int imgWidth = (lines[0].End.x - lines[0].Start.x) + 1 + (padBetweenLines * 2);// frame width too
                L.l(location, "Image out size (" + imgWidth + "w, " + imgHeight + ")");

                // Simpler to paint background, than toggle in and out of regions
                Bitmap bmpOut = new Bitmap(imgWidth, imgHeight);
                for (int y = 0; y < bmpOut.Height; y++)
                    for (int x = 0; x < bmpOut.Width; x++)
                        bmpOut.SetPixel(x, y, Color.Red);

                int bmpStartX = padBetweenLines + 1;
                int bmpVPad = padBetweenLines;// accumulated vertical padding
                int bmpVLine = 0;// accumulated line height

                // Now paint lines
                for (int i = 0; i < lines.Count; i++)
                {
                    L.l(location, "Starting line (" + i + ") out of (" + lines.Count + ").");
                    L.l(location, "Region (" + i + "): " + lines[i].toString() + ".");
                    if (!this.isValid(lines[i]))
                    {
                        L.err(location, "Skipping invalid line at index (" + i + ").");
                        continue;
                    }

                    // After every line
                    bmpVPad += padBetweenLines;
                    bmpVLine += (lines[i].End.y - lines[i].Start.y) + 1;
                }
                L.l(location, "Finished with (" + lines.Count + ") rows.");

                // Output Result 
                retVal = bmpOut;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public Bitmap rotateBitmap(Bitmap bmp, float angle)
        {
            const string location = CLASSNAME + ".rotateBitmap";
            Bitmap retVal = null;
            try
            {
                if (bmp == null)
                {
                    L.err(location, "Input image was null.");
                    return retVal;
                }

                Bitmap bmpOut = new Bitmap(bmp.Width, bmp.Height);
                bmpOut.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                using (Graphics graphics = Graphics.FromImage(bmpOut))
                {
                    try
                    {
                        // Rotation point
                        graphics.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

                        // Rotate to angle
                        graphics.RotateTransform(angle);

                        // Move center back
                        graphics.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

                        // Draw image
                        graphics.DrawImage(bmp, new Point(0, 0));
                    }
                    catch (Exception ex)
                    {
                        L.ex(location, ex);
                    }
                }

                // Output Result
                retVal = bmpOut;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public Bitmap toBitmap()
        {
            const string location = CLASSNAME + ".toBitmap";
            Bitmap retVal = null;
            try
            {
                if (this.ba == null || this.width <= 0 || this.height <= 0 ||
                    this.ba.Length != this.width * this.height)
                {
                    L.err(location, "This image object was not configured properly to display.");
                    return retVal;
                }
                L.l(location, "Creating image size (" + this.width + "w x " + this.height + "h).");


                Bitmap bmp = new Bitmap(this.width, this.height);

                for (int y = 0, offset = 0; y < bmp.Height && offset < this.ba.Length; y++)
                {
                    for (int x = 0; x < bmp.Width && offset < this.ba.Length; x++, offset++)
                    {
                        bmp.SetPixel(x, y, this.ba[offset] == true ? Color.Black : Color.White);
                    }
                }

                retVal = bmp;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;  
        }

        public Bitmap toBitmap(Region region)
        {
            const string location = CLASSNAME + ".toBitmap(r)";
            Bitmap retVal = null;
            try
            {
                if (this.ba == null)
                {
                    L.err(location, "Image data not initialized.");
                    return retVal;
                }
                if (region == null)
                {
                    // Not an error
                    return null;
                }
                if (!this.isValid(region))
                {
                    L.err(location, "Region not initialized or out of bounds (" + this.width + ", " + this.height + ").");
                    return retVal;
                }
                L.l(location, "Reading region: " + region.toString() + ".");
                Bitmap bmpOut = new Bitmap(
                    region.End.x - region.Start.x + 1,
                    region.End.y - region.Start.y + 1
                );
                //L.l(location, "Output size: (" + bmpOut.Width + "w, " + bmpOut.Height + "h).");

                for (int y = region.Start.y, yOut = 0; y <= region.End.y; y++, yOut++)
                {
                    int rowOffset = y * this.width;
                    for (int x = region.Start.x, xOut = 0; x <= region.End.x; x++, xOut++)
                    {
                        bmpOut.SetPixel(xOut, yOut, this.ba[rowOffset + x] == true ? Color.Black : Color.White);
                    }
                }

                // Output Result
                retVal = bmpOut;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


    }
}
