using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRegionAnalysis2
{
    public static class U
    {
        public const string CLASSNAME = "U";

        public enum DIRECTION
        {
            RIGHT,
            DOWN,
            LEFT, 
            UP
        }


        // Finds objects along X-Axis (characters), startDirection needs to be left or right for now
        //public static Region findFirstObject(Bits bits, Region region, DIRECTION startDirection)
        public static List<int> findFirstObject(Bits bits, Region region, DIRECTION startDirection, bool listOnly)
        {
            const string location = CLASSNAME + ".findFirstObject";
            //Region retVal = null;
            List<int> retVal = null;
            try
            {
                if (bits == null)
                {
                    L.err(location, "Input data was null.");
                    return retVal;
                }
                if (bits.ba == null || bits.ba.Length == 0)
                {
                    L.err(location, "Input data not initialized.");
                    return retVal;
                }
                if (bits.Width * bits.Height != bits.ba.Length)
                {
                    L.err(location, "Input data size (" + (bits.Width * bits.Height) + ") mismatch (" + bits.ba.Length + ").");
                    return retVal;
                }
                if (region == null)
                {
                    L.err(location, "Input region was null.");
                    return retVal;
                }
                if (!bits.isValid(region))
                {
                    L.err(location, "Region not valid against data. Data (" + bits.Width + "w, " + bits.Height +
                        "h), Region: " + region.toString());
                    return retVal;
                }

                L.l(location, "Region In: " + region.toString());

                // TODO - This needs to be turned into a column scan

                int idxDataStart = -1;// bits.ba index
                int midY = ((region.End.y - region.Start.y + 1) / 2 | 0) + region.Start.y;
                if (startDirection == DIRECTION.RIGHT)
                {
                    for (int y = midY; idxDataStart < 0 && y <= region.End.y; y++)
                    {
                        int rowOffset = y * bits.Width;
                        for (int x = region.Start.x; idxDataStart < 0 && x <= region.End.x; x++)
                        {
                            if (bits.ba[rowOffset + x] == true)
                            {
                                idxDataStart = rowOffset + x;
                            }
                        }
                    }
                }
                else if (startDirection == DIRECTION.LEFT)
                {
                    for (int y = midY; idxDataStart < 0 && y <= region.End.y; y++)
                    {
                        int rowOffset = y * bits.Width;
                        for (int x = region.End.x; idxDataStart < 0 && x >= region.Start.x; x--)
                        {
                            if (bits.ba[rowOffset + x] == true)
                            {
                                idxDataStart = rowOffset + x;
                            }
                        }
                    }
                }
                else 
                {
                    L.err(location, "Start direction needs to be left or right.");
                    return retVal;
                }
                if (idxDataStart < 0 /*|| xStart < 0 || yStart < 0*/)
                {
                    // May not really be an error
                    L.err(location, "Failed to find any set pixels.");
                    return retVal;
                }

                L.l(location, "Data Start Offset (" + idxDataStart + "), X (" + (idxDataStart % bits.Width) + 
                    "), Y (" + (idxDataStart / bits.Width | 0) + "), Width (" + bits.Width + 
                    "), Height (" + bits.Height + "), Data Size (" + bits.ba.Length + ").");


                List<int> mypath = new List<int>();// bits.ba offsets
                mypath.Add(idxDataStart);

                if (count8Neighbors(ref bits, idxDataStart, true) == 0)
                {
                    // Pixel has no set neighbors
                    L.err(location, "Failed to size region. Pixel has no matching neighbors.");
                    return retVal;
                }

                // We were covering X-axis when we found a pixel, going right
                DIRECTION direction = startDirection;
                //DIRECTION direction = DIRECTION.RIGHT;
                //DIRECTION lastDirection = DIRECTION.RIGHT;


                int myOffset = -1;
                int cntr = 0;
                for (; ; cntr++)
                {
                    /*if (cntr < 1000 || cntr % 100 == 0)
                    {
                        L.l(location, "Iteration (" + cntr + ") of mim-loop, offset (" + myOffset + ").");
                    }*/
                    if (cntr > 10000) break;// Stop looping if too much


                    if (myOffset == idxDataStart)
                    {
                        break;// stop looping
                    }
                    else if (myOffset < 0)
                    {
                        myOffset = idxDataStart;
                    }

                    // assume the offset you are standing on is good

                    // look right
                    int tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset + bits.Width;// Turn right, go down
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.DOWN;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset - 1;// Turn right, go left
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.LEFT;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset - bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.UP;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.RIGHT;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }

                    // Look straight
                    tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset + bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset - 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset - bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }



                    // Look left
                    tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset - bits.Width;// Left of Right is UP
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.UP;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.RIGHT;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset + bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.DOWN;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset - 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.LEFT;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }

                    // If we made it here, we are backtracking. Go back one, in the opposite direction, and be proud

                    switch (direction)
                    {
                        case DIRECTION.RIGHT: direction = DIRECTION.LEFT; break;
                        case DIRECTION.DOWN: direction = DIRECTION.UP; break;
                        case DIRECTION.LEFT: direction = DIRECTION.RIGHT; break;
                        case DIRECTION.UP: direction = DIRECTION.DOWN; break;
                        default: break;
                    }
                    if (mypath.Count > 0)
                    {
                        int lastOffset = mypath[mypath.Count - 1];
                        mypath.Add(lastOffset);
                        myOffset = lastOffset;
                    }

                }

                /*// TODO - Remove debug border - mark search region
                int tempheight = region.End.y - region.Start.y;
                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    int rowOffset = (y * bits.Width) + region.Start.x;
                    mypath.Add(rowOffset);
                    mypath.Add((y * bits.Width) + region.End.x);

                    if (y == region.Start.y || y == region.End.y || y == midY)
                    {
                        for (int x = region.Start.x; x < region.End.x; x++)
                        {
                            mypath.Add(rowOffset + x);
                        }
                    }
                }*/




                /*Region regionOut = new Region();
                regionOut.Start = new Pt(-1, -1);
                regionOut.End = new Pt(-1, -1);
                regionOut.height = region.height;
                regionOut.width = region.width;

                int highestIdx = mypath[0];
                int lowestIdx = mypath[0];

                for (int i = 0; i < mypath.Count; i++)
                {
                    if (mypath[i] < lowestIdx) lowestIdx = mypath[i];
                    if (mypath[i] > highestIdx) highestIdx = mypath[i];
                }

                regionOut.Start.y = lowestIdx / bits.Width | 0;
                regionOut.End.y = highestIdx / bits.Width | 0;

                //regionOut.Start.x = lowestIdx % regionOut.Start.y;
                //regionOut.End.x = highestIdx % regionOut.End.y;

                regionOut.Start.x = lowestIdx % bits.Width;
                regionOut.End.x = highestIdx % bits.Width;

                L.l(location, "Found Region: " + regionOut.toString());*/




                // Require a region to be X (20) pixels or discard
                /*if (((regionOut.End.x - regionOut.Start.x)+1) * ((regionOut.End.y - regionOut.Start.y) + 1) > 20)
                {
                    retVal = regionOut;
                }*/
                retVal = mypath;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
        public static Region findFirstObject(Bits bits, Region region, DIRECTION startDirection)
        {
            const string location = CLASSNAME + ".findFirstObject";
            Region retVal = null;
            try
            {
                List<int> mypath = U.findFirstObject(bits, region, startDirection, true);
                if (mypath == null || mypath.Count == 0)
                {
                    L.err(location, "Failed to find any objects");
                    return retVal;
                }

                Region regionOut = new Region();
                regionOut.Start = new Pt(-1, -1);
                regionOut.End = new Pt(-1, -1);
                regionOut.height = region.height;
                regionOut.width = region.width;

                int highestIdx = mypath[0];
                int lowestIdx = mypath[0];

                for (int i = 0; i < mypath.Count; i++)
                {
                    if (mypath[i] < lowestIdx) lowestIdx = mypath[i];
                    if (mypath[i] > highestIdx) highestIdx = mypath[i];
                }

                regionOut.Start.y = lowestIdx / bits.Width | 0;
                regionOut.End.y = highestIdx / bits.Width | 0;

                //regionOut.Start.x = lowestIdx % regionOut.Start.y;
                //regionOut.End.x = highestIdx % regionOut.End.y;

                regionOut.Start.x = lowestIdx % bits.Width;
                regionOut.End.x = highestIdx % bits.Width;

                L.l(location, "Found Region: " + regionOut.toString());

                /*// TODO - Remove debug border - mark search region
                int tempheight = region.End.y - region.Start.y;
                for (int y = region.Start.y; y <= region.End.y; y++)
                {
                    int rowOffset = (y * bits.Width) + region.Start.x;
                    mypath.Add(rowOffset);
                    mypath.Add((y * bits.Width) + region.End.x);

                    if (y == region.Start.y || y == region.End.y || y == midY)
                    {
                        for (int x = region.Start.x; x < region.End.x; x++)
                        {
                            mypath.Add(rowOffset + x);
                        }
                    }
                }*/



                // Require a region to be X (20) pixels or discard
                if (((regionOut.End.x - regionOut.Start.x)+1) * ((regionOut.End.y - regionOut.Start.y) + 1) > 20)
                {
                    retVal = regionOut;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        /*// Finds objects along X-Axis (characters)
        public static Region findFirstObject(ref Bits bits, Region region)
        {
            const string location = CLASSNAME + ".findFirstObject";
            Region retVal = new Region();
            try
            {
                if (bits == null)
                {
                    L.err(location, "Input data was null.");
                    return retVal;
                }
                if (bits.ba == null || bits.ba.Length == 0)
                {
                    L.err(location, "Input data not initialized.");
                    return retVal;
                }
                if (bits.Width * bits.Height != bits.ba.Length)
                {
                    L.err(location, "Input data size (" + (bits.Width * bits.Height) + ") mismatch (" + bits.ba.Length + ").");
                    return retVal;
                }
                if (region == null)
                {
                    L.err(location, "Input region was null.");
                    return retVal;
                }
                if (!bits.isValid(region))
                {
                    L.err(location, "Region not valid against data. Data (" + bits.Width + "w, " + bits.Height +
                        "h), Region: " + region.toString());
                    return retVal;
                }


                int idxDataStart = -1;// bits.ba index
                int xStart = -1;// region.x
                int yStart = -1;// region.y

                for (int y = region.Start.y; idxDataStart < 0 && y <= region.End.y; y++)
                {
                    int rowOffset = y * bits.Width;
                    for (int x = region.Start.x; idxDataStart < 0 &&  x <= region.End.x; x++)
                    {
                        if (bits.ba[rowOffset + x] == true)
                        {
                            idxDataStart = rowOffset + x;
                            xStart = x;
                            yStart = y;

                            // TODO - Create region here, move past region?
                        }
                    }
                }
                if (idxDataStart < 0 || xStart < 0 || yStart < 0)
                {
                    // May not really be an error
                    L.err(location, "Failed to find any set pixels.");
                    return retVal;
                }


                List<int> mypath = new List<int>();// bits.ba offsets
                mypath.Add(idxDataStart);

                if (count8Neighbors(ref bits, idxDataStart, true) == 0)
                {
                    // Pixel has no set neighbors
                    L.err(location, "Failed to size region. Pixel has no matching neighbors.");
                    return retVal;
                }

                // We were covering X-axis when we found a pixel, going right
                DIRECTION direction = DIRECTION.RIGHT;
                //DIRECTION lastDirection = DIRECTION.RIGHT;


                int myOffset = -1;
                int cntr = 0;
                for (; ; cntr++)
                {
                    if (cntr % 100 == 0)
                    {
                        L.l(location, "Iteration (" + cntr + ") of mim-loop.");
                    }
                    if (myOffset == idxDataStart)
                    {
                        break;// stop looping
                    }
                    else if (myOffset < 0)
                    {
                        myOffset = idxDataStart;
                    }

                    // assume the offset you are standing on is good

                    // look right
                    int tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset + bits.Width;// Turn right, go down
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.DOWN;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset - 1;// Turn right, go left
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.LEFT;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset + bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.UP;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.RIGHT;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }

                    // Look straight
                    tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset + bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset - 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset - bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }



                    // Look left
                    tempOffset = -1;
                    switch (direction)
                    {
                        case DIRECTION.RIGHT:
                            {
                                tempOffset = myOffset - bits.Width;// Left of Right is UP
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.UP;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.DOWN:
                            {
                                tempOffset = myOffset + 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.RIGHT;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.LEFT:
                            {
                                tempOffset = myOffset + bits.Width;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.DOWN;
                                    continue;
                                }
                            }
                            break;
                        case DIRECTION.UP:
                            {
                                tempOffset = myOffset - 1;
                                if (tempOffset >= 0 && tempOffset < bits.ba.Length && bits.ba[tempOffset] == true)
                                {
                                    mypath.Add(tempOffset);
                                    myOffset = tempOffset;
                                    direction = DIRECTION.LEFT;
                                    continue;
                                }
                            }
                            break;
                        default: break;
                    }

                    // If we made it here, we are backtracking. Go back one, in the opposite direction, and be proud

                    switch (direction)
                    {
                        case DIRECTION.RIGHT: direction = DIRECTION.LEFT; break;
                        case DIRECTION.DOWN: direction = DIRECTION.UP; break;
                        case DIRECTION.LEFT: direction = DIRECTION.RIGHT; break;
                        case DIRECTION.UP: direction = DIRECTION.UP; break;
                        default: break;
                    }
                    if (mypath.Count > 0)
                    {
                        myOffset = mypath[mypath.Count - 1];
                    }

                }


                Region regionOut = new Region();
                regionOut.Start = new Pt(-1,-1);
                regionOut.End = new Pt(-1,-1);

                int highestIdx = mypath[0];
                int lowestIdx = mypath[0];

                for (int i = 0; i < mypath.Count; i++)
                {
                    if (mypath[i] < lowestIdx) lowestIdx = mypath[i];
                    if (mypath[i] > highestIdx) highestIdx = mypath[i];
                }

                regionOut.Start.x = lowestIdx % bits.Width;
                regionOut.End.x = highestIdx % bits.Width;

                regionOut.Start.y = lowestIdx / bits.Width | 0;
                regionOut.End.y = highestIdx / bits.Width | 0;


                retVal = regionOut;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }*/



        public static short count8Neighbors(ref Bits bits, int offsetIn, bool matchVal)
    {
        const string location = CLASSNAME + ".count8Neighbors";
        short retVal = 0;
        try
        {
            if (bits == null || bits.ba == null || offsetIn >= bits.ba.Length || 
                bits.ba.Length != bits.Width * bits.Height 
            )
            {
                // TODO - decide whether to error
                return retVal;
            }

            int offset = offsetIn - 1 - bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn - 1;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn - 1 + bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn + bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn + 1 + bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn + 1;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn + 1 - bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

            offset = offsetIn - bits.Width;
            if (offset >= 0 && offset < bits.ba.Length && bits.ba[offset] == matchVal)
            {
                retVal++;
            }

        }
        catch (Exception ex)
        {
            L.ex(location, ex);
        }
        return retVal;
    }


        public static int maskToBitmap(List<int> offsets, ref Bitmap bmp, Color color)
        {
            const string location = CLASSNAME + ".maskToBitmap";
            int retVal = 0; // error count
            try
            {
                if (offsets == null || bmp == null || color == null || bmp.Width == 0 || bmp.Height == 0)
                {
                    L.err(location, "Input data not initialized.");
                    return 1;
                }
                
                for (int i = 0; i < offsets.Count; i++)
                {
                    int x = offsets[i] % bmp.Width;
                    int y = offsets[i] / bmp.Width | 0;

                    if (x < 0 || x >= bmp.Width || y < 0 || y >= bmp.Height)
                    {
                        retVal++;
                    }
                    else 
                    {
                        bmp.SetPixel(x, y, color);
                    }
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
