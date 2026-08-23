# Pythircle Experiment

Some time back, I was having a fuss with sin and cosine, and wondered if it would be possible to draw a circle without needing either. More specifically, if it would be possible for me to draw a circle. The answer came in the form of Pythagora's theorem. It is possible to draw a circle, using only triangles.

The clue came from looking at images of a unit-circle, seeing that every angle from center, produces a right triangle, except for X=0 and Y=0. Now, a circle, being a circle, has a radius. This radius has an alternate identity as the hypotenuse of every right-triangle that can be drawn inside the circle, where one point is center and another is perimeter.

If we know the radius of a circle, or what size circle we want to draw, we know every possible value for X and every possible Y, but nothing for each XY. That means that if we follow either X or Y (exclusively), we always know the length of two-sides. From here, we can use A^2 * B^2 = C^2, to find a point along the perimeter (more on this in a minute).

More specifically, because we know our hypotenuse, if we were to follow X and calculate Y, our equations looks like:

    h^2 - x^2 = y^2
    Math.Sqrt(h^2 - x^2) = y


For every X, we can calculate a corresponding Y. There are some problems however. Large circles will not be contiguous. There are not enough X or Y values to calculate every perimeter XY. The important thing, is you have one point for every value in at-least one axis. If you followed X to calculate Y, backfill along Y, until you meet the last neighbor. 


This process is simple enough to follow for one-quadrant (the top-right quadrant), where X and Y are both positive. The math could be flipped and triangles inverted, but I'm more of a programmer. The rest of the solution, involves flipping the result for the first quadrant, and copying the set pixels into the other three quadrants.

--

The circle was satisfying, but I wanted an ellipse too. Pythagorean theorem was no longer an option. We can still know all of X or Y, but no longer know the hypotenuse. To draw an ellipse, a pythircle was used, by drawing a circle the size of the smaller of desired height or width. A circle that fits inside at the narrow point of desired ellipse. The width of the circle is compared against the larger dimension, and a ratio is created. Points along the circle are then multiplied by this ratio to obtain all critical XY along the other axis. Gaps are backfilled, as was the circle. 

To keep things simple, the ellipse also works a single quadrant, then flips the result. 

The finished product, are ellipses and circles drawn without angles, radians, degrees, sin, cosine, or tangent. 
<br />
<br />
