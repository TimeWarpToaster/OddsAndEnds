# Project Summary

## Overview

A primary goal of this project, was attempting to reduce overhead associated with OCR. Part of the problem stems from image manipulation. Image access is slow, cropping is slow, resizing is slow, and counting is also slow.

To this end, the image is reduced (common). The reduced image (1-bit array), is used as a frame of reference for everything that follows. Same size as original, pixels still reference back in a 1-to-1 relationship. All objects isolated within the reduced image, are effectively treated as a region, with a starting X and Y, and an ending X and Y (two-points, or four integers). The reduced image is the sole source of image data. No copies, no crops. Positions, counts, and stats only.

An unsuccessful attempt was made, to ensure the image is counted as few-times-as-possible. The result is not-quite there. The image is counted several times, some of these may still be reduced or combined, others cannot:

<pre>
    1)  Count image to get lines
    2)  Count all lines to get characters
    3)  Count character 
        a.  Scan for counts
        b.  Scan again for perimeter edges
    4) Count character subregions
</pre>

As is plain already, some areas of the image are being counted at-least five time from the top-of-head. However, the stats are powerful. We will get more into counts later.

(there is supposed to be more here)


## Counts

Counts are owned by a Region. This is not as simple as it seems. A Region also owns a List<List<Region>> to contain subregions. Each of these nested Regions also has a counts object. The counts of the region and the counts of the subregions serve distinct purposes. 

Region - This becomes important when the region is an entire character. Not all regions are worth formally counting, and may have a null counts or default values. For instance, a line is not worth carving up and counting directly, neither is a subregion.

Subregion - Characters are carved up into subregions. The number of subregions is changeable in code, but not yet configurable. Subregions of a character are counted independently, and the counts go back on the region object defining the subregion (not the character counts). Counting a subregion, is specifically for looking at one-area of a character image area. A logical-crop of a logical-crop, counted.

A Template, is effectively defined by counts, not pixel data. Specifically, the percent counts. Untested, but hope is maintaining percents as a priority over pixel-counts, will allow template scaling. A downside to both approaches, is that a template is effectively bound to the subregioning. A template based on character subregions that are 4x5, is incompatible with a character that has been read according to subregions that are 5x5. The counts, and percentages, are highly dependent upon same number of subregions of the same relative proportions (with respect to the character).  

<pre>
    Counts currently come in three kinds:

    1)  Raw count
    2)  Percent
    3)  Perimeter (List of raw count or percent, on a column or row basis)


    Among things counted are:

    1)  Set and unset (both always, for all areas counted)
    2)  Halves (left, top, right, bottom)
        a.  A half is not a quadrant. If you add up the set and unset for all halves, you have double the actual number of pixels counted.
    3)  Quadrants (coming soon)
</pre>

This means a subregion of a character, has counts for top, left, etcetera. Not just the overall subregion totals. Consequently, because the character region is counted the same as a subregion, this means the current implementation also has perimeter data for subregions (not sure if this will prove useful, so leaving it until analyzed). While the purpose of subregioning, is to effectively reduce the character resolution greatly into greyscale (int counts), it is more like many greyscales comprised along many factors, without maintaining image data. To put this literally, the comprised subregions of a character, can be converted to a semi-unique low-resolution grey-scale image of the character, for each count value. These subregion data-points provide the basis for OCR. More-so, than overall character counts.

Comparing counts is so common, specifically, comparing counts of the subregions List<List<Region>>, that it is worth have a counts.diff(inCounts); helper. A new counts object is created, containing the absolute difference for each count, of each subregion. Comparing the absolute difference of set and unset percentages, along with other factors, comprise the final result. Not yet added, is any formal weighting system. Lowest composite difference when compared against a template wins.

Pixel-counts have little meaning or relevance, beyond the life of image data. A count has no concept of container-size. What a count can have, is a relative percent to the whole. Most variables of value in comparisons, have a "per..." alternate, stored as a percent. A short-term count variable named int myCounter, would have its long-term counterpart double perMyCounter defined as-well. At some-point, the template may be thinned, to do away with int values that lost meaning. For now, they are part of counts, and go with counts into the template.

Perimeter counts are a List<int> where counts.blankLeft, is a count of unset pixels from the left perimeter in, before the first set pixel. Because it is left, and a value must exist for every row, the list is size-Y long. For counts.blankTop or blankBottom, the list of counts is size-X long. For percents, the perimeter counts are converted to a percent of their respective axis. Where blankLeft and blankRight are percent of width, blankTop and blankBottom percent of height.  

## Templates

Training images are currently in the simplest form possible ("Row #)" is not part of the format):

Row 1)  Font name<br />
Row 2)  A to Z (upper-case)<br />
Row 3)  a to z (lower-case)<br />
Row 4)  0 to 9 (numerals only)<br />
  
Row 1 is essentially for the user, although this may change. In the future, it may be utilized. Future revisions to templating, may also add a row to determine the font-size (this is currently difficult, due to capturing screenshots at semi-random zoom levels). Unfortunately, the template images I made, are zoomed to have an appropriate number of pixels, and are not purely font-size based.

At-present, there is no support for punctuation or symbols.

White space should not matter in the template images, so-long-as the characters occur in order on the correct line/row of template image. To say the characters of template images must occur in order, glosses over another long-term deficiency, that I am not sure can be improved greatly. In row-2, the upper-case letters must follow the alphabet in sequence, because their index 0-25, is converted to an anticipated expectation for that position. This is currently the only way to read template images in, and automatically assign an adequate value (assuming parse of regions occurs correctly, check this before saving a template). One extra blotch viewed in the characters tab, will throw off the rest of the line, and lines that follow (i.e. all character templates are stored in one sequential list, an extra entry early bumps assignments down-the-chain). 

No punctuation or symbols! No comma or period. Under current logic (not that fancy) they ought to be read as separate characters and bump everything else into an incorrect position. This, of-course, depends upon font, and how closely a comma or quote can curl around neighboring characters. 

When you know the characters have been distinguished correctly, you can save a template, and restore it later for reading with. The template, is essentially a JSON object, whose keys are the characters, each containing an object representing the counts derived from template. Counts are the template.

Importantly, counts for a character are overall, and broken up by regions. This means that a read image, must be split up according to the same subregion definitions. Not only the same number of regions across X and Y, but the regions between template and image need to have the same relative size. In future versions, the ability to independently set a % of width or height on a per-column or row basis should be restored, meaning the relative sizes can vary along X or Y but not both (i.e. col-0 is 20% wide, or row-1 is 10% tall).


## Unfinished

Counts are being expanded to include "perimeter" counts, these are counts of empty X and Y pixels before character data begins for a character, on a row-by-row and col-by-col basis. These should improve confidence greatly when generalized counts return multiple matches. These counts are currently incomplete, untested, and unreliable. In cases where the entire col or row is blank, the value is -1, when it really should be height or width of the region once done. Later, these counts may take an earlier place in deciding matches. 


## OCR Results

Attempting to read text by OCR will do a couple of things that are non-fancy. Aside from lacking support for punctuation and symbols, white-space is also removed. The characters are cropped and read as a chain, without regard for words, or distance between characters as they occur in the read image. When converted to text, all of the results run together as a single word. 

<br />
<br />
