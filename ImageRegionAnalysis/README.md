# Image Region Analysis 2

### This Work Is Unfinished
Generally not for any useful purpose in its present state. The Image Region Analysis harness is just an experiment into the most basic ideas of OCR, or more broadly, toward ways to aggregate knowledge of a large number of points, in a compact and meaningful way. Currently unfinished, there are numerous loose-ends, ranging from final character cropping, to dealing with uneven lines and character proportions within fonts. It only has a couple of weeks of work in it, and is unfinished in many ways. Think of this as a source backup, and sharing with a friend, consume at your own risk.


### Current Functionality
The app opens up by loading an image of text for a font. The image is expected to follow the format:

Line 1) Font Name<br />
Line 2) ABCDEFGHIJKLMNOPQRSTUVWXYZ<br />
Line 3) abcdefghijklmnopqrstuvwxyz<br />
Line 4) 0123456789<br />

For examples, look in the ./Images folder for files prefixed with the letter 'f'. For clarity, do not include the "Line #) ", but only what is shown above after.

There is currently no support for punctuation or symbols. Simply have not added them. The image is also expected to be straightened and consistent, mostly testing with screenshots of text for the moment. Noise reduction is not part of this app, but a single-pass threshold exists. On image load from the Main tab, the original image is displayed to the right, and thresholded on the left.

The app makes a basic pass to pull out rows of text, and separate characters from rows. If you look at the sources, I have several fonts walled off from selection, this is because their lines or character crops still need work. Have not dealt with characters that cross or serifs that bleed yet in this app. What is there, mostly parses correct to alphabet, but lacks crop to height (character regions are still being determined by line-height, which is wrong long-term).

On the Regions tab, assuming you have cropped out lines and characters, you can get Counts for each character. The character is divided up into a number of regions across X and Y, and aggregate counts are derived. This is REALLY MORE FUN IN CODE. Only the overall count for pixels set is being shown. If you are lucky, you should recognize most of the characters, just by looking at 30 or so counts, not closely, just look at them. That's only one stat though. There are 20 or 30, that have not yet been utilized, from percents to further reduced counts. For instance, each count displayed, has a right, left, top, and bottom. Perimeter counts are new, and being performed, but not yet being put to use. The data looks promising. You can narrow down many characters by the way they move across X and Y, as a second validation to set point stats. 

A template is effectively a set of character counts that has been broken out into JSON according to their individual character. A template can be saved and retrieved. Essential for reading text, which is not yet supported.

The Read Text tab is essentially only useful to me right now, because I still have to manually create all of the images. At-present, any read image has to very-closely match the proportions font-pixel-size (due almost wholly, to the count compares using set counts rather than the more recent percents, using percents rather than direct counts will begin to allow scaling across reasonable size brackets... ultimately, the number of regions a template is created with, plays directly back into the range of font-sizes it will be able to support as-well).

That said, if you load an image to be read, and have a matching template loaded, it will try to read the image. It worked a few days ago, and likely will again, but I have made numerous changes over the last couple of days, and am sorry to say, it does not work now. I think one font gave better than half this morning when I tested it, and most failed abysmally. It does work, just not now. I do expect reading, even partial reading, to be down for another week, as I have one significant change to make in how templates are constructed, and another to make in the vertical cropping of letters. 

Find lines is not tied into anything. It began as an exploration more of straightening than finding, so solid lines are drawn at an angle, then it tries to find and straighten them. It is not all that useful as-is for text. It is not a true finding tool. Because of how it is finding the lines, it only works within about 20-30 degrees of tilt. If the rise becomes too great (from 0), all bets are off.  

<br />
<br />
