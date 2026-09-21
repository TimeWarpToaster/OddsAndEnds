using System;
using System.Drawing;

namespace ImageRegionAnalysis2
{
    public class Draw
    {
        public const string CLASSNAME = "Draw";

        // line - Draw horizontal or diagonal lines, where y1 for sure touches the usable y-axis, y2 does not care
        public bool line(ref Bitmap bmp, int y1, int y2, Color color)// they go all the way across
        {
            const string location = CLASSNAME + ".line";
            bool retVal = false;
            try
            {
                if (bmp == null)
                {
                    L.err(location, "Bitmap was null.");
                    return retVal;
                }
                if (y1 < 0 || y1 >= bmp.Height)
                {
                    L.err(location, "Y1 (" + y1 + ") was out of range (0 - " + (bmp.Height - 1) + ").");
                    return retVal;
                }

                int diffY = y1 - y2;
                if (diffY < 0) diffY *= -1;

                double rise = diffY <= 0 ? 0 : ((double)diffY / (double)bmp.Width);

                double fromY1 = 0d;

                for (int x = 0; x < bmp.Width; x++)
                {
                    //L.l(location, "From Y1 (" + fromY1 + "), rise (" + rise + "), x (" + x + "), diffY (" + diffY + ").");
                    int y = (int)(y1 > y2 ? y1 - fromY1 : y1 + fromY1);
                    if (y >= 0 && y < bmp.Height)
                    {
                        bmp.SetPixel(x, y, color);
                    }
                    fromY1 += rise;
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool line(ref Bitmap bmp, int y1, int y2)// they go all the way across
        {
            return this.line(ref bmp, y1, y2, Color.Black);
        }

    }
}
