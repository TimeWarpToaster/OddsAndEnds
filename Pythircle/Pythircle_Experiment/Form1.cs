//Pythircle
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Pythircle
{
    public partial class Form1 : Form
    {
        const string CLASSNAME = "Form1";
        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                // Initialize Logging
                if (!L.logInit(null, lbLogs, false))
                {
                    // Some logging may safely work
                    L.err(location, "Failed to intialize logging.");
                }
                L.l(location, "Application started.");

                // Load Tabs
                rtbAbout.Text = License.license;
                rtbPrimer.Text = Primer.getPrimerText();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public BitArray drawEllipses(int xDiameter, int yDiameter)
        {
            const string location = CLASSNAME + ".drawEllipses";
            BitArray retVal = null;
            try
            {
                L.l(location, "Drawing an ellipse (" + xDiameter + "w X " + yDiameter + "h).");
                int circleDiameter = (xDiameter > yDiameter) ? yDiameter: xDiameter;

                // Get a reference circle. Draw to full yDiameter, we can then scale points
                // along X to form an ellipses. If we spread along-X (scale-up) there will be 
                // gaps. Keep a record of last X, and fill gaps for each new expanded dot.

                // Note: this app currently only supports horizontal ellipses, width > height

                BitArray dataIn = drawPythircle(yDiameter);
                BitArray dataOut = new BitArray(xDiameter * yDiameter, true);

                // To perform one-quadrant, means we offset to read half of X and half of Y
                int xStart = (circleDiameter / 2) | 0;// Read right-side, "radius"/"hypotenuse" is start X
                int midXOut = (xDiameter / 2) | 0;
                int maxQuadrantY = ((yDiameter / 2) | 0) + 1;

                if (xDiameter > yDiameter)
                {
                    double ratio = (double)xDiameter / (double)yDiameter;
                    L.d(location, "Ratio (" + ratio + ")x to (1)y, for (" + xDiameter + ")width, (" + yDiameter + ")height.");

                    int lastX = 0;
                    int lastY = 0;
                    int lastIdx = 0;

                    // Read from circle, expand along X.
                    for (int x = xStart; x < circleDiameter; x++)
                    {
                        for (int yCircle = 0 /*technically same here*/; yCircle < maxQuadrantY; yCircle++)
                        {
                            // Get index into circle data
                            int idx = (yCircle * circleDiameter) + x;

                            // If the pixel is part of circle, expand X
                            if (idx < dataIn.Length && dataIn[idx] == false)
                            {
                                // Use same Y
                                int thisX = (int)Math.Round(((xDiameter / 2) | 0) + (x * ratio),MidpointRounding.ToEven);
                                int thisY = yCircle;

                                // Get index into ellipse and set
                                int idxOut = (int)Math.Round((double)(thisY * xDiameter), MidpointRounding.ToEven) + thisX + midXOut;//midX offset
                                if (idxOut < dataOut.Length)
                                {
                                    dataOut[idxOut] = false;
                                }

                                // Fill gaps in lastX
                                if (lastX > 0 && Math.Abs(thisX - lastX) > 1)
                                {
                                    for (int tIdx = idxOut-1, xGap = thisX; xGap > lastX && tIdx >= 0; tIdx--, xGap--)
                                    {
                                        dataOut[tIdx] = false;
                                    }
                                }
                                lastX = thisX;
                                lastY = thisY;// may not be needed
                                lastIdx = idxOut;// may not be needed
                            }
                        }
                    }

                    // Set response
                    retVal = dataOut;

                }

                int cntFlipErrors = this.flipTopRightQuadrant(ref dataOut, xDiameter, yDiameter);
                if (cntFlipErrors > 0)
                {
                    L.err(location, "Encountered (" + cntFlipErrors + ") flip errors.");
                }


                // Now construct a bitmap for UI
                Bitmap bmp = new Bitmap(xDiameter, yDiameter);
                for (int y = 0; y < yDiameter; y++)
                {
                    for (int x = 0, idx = (y * xDiameter) + x; x < xDiameter; x++, idx = (y * xDiameter) + x)
                    {
                        if (dataOut[idx] == false) bmp.SetPixel(x, y, Color.Black);
                    }
                }

                // Push bitmap to UI
                pbImage.Image = (Image)bmp;
            }
            catch (Exception ex) 
            {
                //L.log(location, ex.Message, TAG.EX);
                L.ex(location, ex);
            }
            return retVal;
        }

        public BitArray drawPythircle(int diameter)
        {
            const string location = CLASSNAME + ".drawPythircle";
            BitArray retVal = null;
            try
            {
                // Force odd pixel count, to have a true center
                if (diameter % 2 == 0) diameter -= 1;

                int radius = (diameter / 2) | 0;
                int hypotenuse = radius;
                int hSquare = hypotenuse * hypotenuse;

                // Temporary container for 1-bit image
                BitArray ba = new BitArray(diameter * diameter, true);// true = white later on?

                // Draw top-right quadrant only
                int lastY = 0;
                for (int x = 0 /*centerX*/; x <= hypotenuse; x++)
                {
                    int xSquare = x * x;
                    int ySquare = hSquare - xSquare;

                    int y = (int)Math.Round(Math.Sqrt(ySquare), MidpointRounding.ToEven);

                    int myX = x + hypotenuse;
                    int myY = hypotenuse - y;

                    int idx = (myY * diameter) + myX;
                    if (idx < ba.Length)
                    {
                        ba[idx] = false;
                    }
                    else 
                    {
                        L.err(location, "Failed to mark index (" + idx + ") out of (" + ba.Length + ").");
                    }

                    if (lastY > 0)
                    {
                        if (myY - lastY > 1)
                        {
                            idx -= diameter;
                            for (int tY = myY; tY > lastY; tY--, idx -= diameter)
                            {
                                if (idx >= 0 && idx < ba.Length)
                                {
                                    ba[idx] = false;
                                }
                            }
                        }
                    }
                    lastY = myY;
                }

                // Flip result to the other three quadrants
                int cntFlipErrors = this.flipTopRightQuadrant(ref ba, diameter, diameter);
                if (cntFlipErrors > 0)
                {
                    L.err(location, "Encountered (" + cntFlipErrors + ") flip errors.");
                }

                // Flag success here, set response
                retVal = ba;

                // Now construct a bitmap for UI
                Bitmap bmp = new Bitmap(diameter, diameter);
                for (int y = 0; y < diameter; y++)
                {
                    for (int x = 0, idx = (y * diameter) + x; x < diameter; x++, idx = (y * diameter) + x)
                    {
                        if (ba[idx] == false) bmp.SetPixel(x, y, Color.Black);
                    }
                }

                // Push bitmap to UI
                pbImage.Image = (Image)bmp;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int flipTopRightQuadrant(ref BitArray ba, int width, int height)
        {
            const string location = CLASSNAME + ".flipTopRightQuadrant";
            int retVal = 0;// Flip errors
            try
            {
                int maxQuadrantY = ((height / 2) | 0) + 1;
                int tidx = 0;
                for (int y = 0; y <= maxQuadrantY; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = (y * width) + x;
                        if (ba[idx] == false)
                        {
                            int tX = x;
                            int tY = y;

                            // flip
                            tY = height - y - 1;
                            tidx = (tY * width) + tX;
                            if (tidx < ba.Length) ba[tidx] = false;
                            else retVal++;

                            // reverse
                            tX = width - x;
                            tidx = (tY * width) + tX;
                            if (tidx < ba.Length) ba[tidx] = false;
                            else retVal++;

                            // flip
                            tY = y;
                            tidx = (tY * width) + tX;
                            if (tidx < ba.Length) ba[tidx] = false;
                            else retVal++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        private void btnGoCircle_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGoCircle_Click";
            try
            {
                L.l(location, "Drawing Circle.");

                int diameter = -1;
                try
                {
                    diameter = Convert.ToInt32(tbCircleDiameter.Text);
                }
                catch (Exception ex) { }

                if (diameter < 0 || diameter > 1000)
                {
                    MessageBox.Show(
                        "Diameter (" + tbCircleDiameter.Text + ") must be a number between (0-1000).",
                        "Diameter Error",
                        MessageBoxButtons.OK
                    );
                }
                else
                {
                    // Force odd size for true center-pixel
                    BitArray data = drawPythircle(diameter);
                    if (data == null || data.Length == 0)
                    {
                        L.err(location, "Failed to draw Circle.");
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }


        private void btnGoEllipse_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGoEllipse_Click";
            try
            {
                L.l(location, "Drawing Ellipse.");

                int width = -1;
                int height = -1;
                try
                {
                    width = Convert.ToInt32(tbEllipseWidth.Text);
                    height = Convert.ToInt32(tbEllipseHeight.Text);
                }
                catch (Exception ex) { }

                if (width < 0 || width > 1000 || height < 0 || height > 1000)
                {
                    MessageBox.Show(
                        "Width (" + tbEllipseWidth.Text + ") and Height (" + tbEllipseHeight.Text +
                            ") must be numbers between (0-1000).",
                        "Ellipse Size Error",
                        MessageBoxButtons.OK
                    );
                }
                else
                {
                    // Force odd dimensions, so shape has a true-center pixel
                    // Allowing even sizes can give odd graphs
                    if (width % 2 == 0)
                    {
                        width++;
                        tbEllipseWidth.Text = Convert.ToString(width);
                    }
                    if (height % 2 == 0)
                    {
                        height++;
                        tbEllipseHeight.Text = Convert.ToString(height);
                    }
                    if (height > width)
                    {
                        int tempHeight = height;
                        height = width;
                        width = tempHeight;
                        tbEllipseWidth.Text = Convert.ToString(width);
                        tbEllipseHeight.Text = Convert.ToString(height);
                    }
                    BitArray data = drawEllipses(width, height);
                    if (data == null || data.Length == 0)
                    {
                        L.err(location, "Failed to draw Ellipses.");
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }
    }

}
