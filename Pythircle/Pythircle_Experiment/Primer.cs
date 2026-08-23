//Pythircle
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;

namespace Pythircle
{
    public static class Primer
    {
        public const string CLASSNAME = "Primer";

        public static string getPrimerText()
        {
            const string location = CLASSNAME + ".getPrimerText";
            string retVal = "";
            try
            {
                 retVal = "This app illustrates a puzzle, of how to draw a circle, without the use" +
                 "of angles, radians, or degrees. This app takes the approach of using the " +
                 "Pythagorean Theorum, to calculate one XY point along the perimeter, for " +
                 "either all of X, or all of Y. This works, because the radius of the circle, " +
                 "is always the hypotenuse of a triangle. For each X or Y (let's use X), " +
                 "you can use hypotenuse^2 - X^2 to find Y^2, and solve for Y. " +
                 "\n\n" +
                 "For simplicity, this app calculates points for a single quadrant, then " +
                 "rotates the result to complete the other three quadrants. " +
                 "\n\n" +
                 "Before rotating, it is worth noting our arc contains some gaps. Because of the " +
                 "curved nature of a circle, a circle of any size is going to contain more XY " +
                 "perimeter points, than unique X or Y axis points. Because we processed all of " +
                 "one (e.g. X), and have a point for every value in that axis, we can backfill " +
                 "between points and their closest neighbors. Now the arc can be rotated to " +
                 "complete the circle." +
                 "\n\n" +
                 "---" +
                 "\n\n" +
                 "A second puzzle illustrated, is one solution for drawing an ellipse, using " +
                 "only a circle, and desired dimensions. Again, to keep things simple, " +
                 "only horizontal ellipses are drawn. First, a circle is drawn, matching " +
                 "the narrower size of the ellipse (height). The size of the circle is " +
                 "compared to the longer dimension requested (width), and a ratio of " +
                 "their sizes is created. Each XY point, is then slid along the X-axis, " +
                 "by multiplying X * ratio. Backfilling the gaps still applies." +
                 "\n\n" +
                 "Only odd sizes are supported for drawing an ellipse. Ellipses drawn " +
                 "using even numbers, can turn out diffent from the classic standard " +
                 "oval shape used for drawing.";
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

    }
}
