# Region

What being called here, is a region, is sometimes referred to other places as a region-of-interest. If you are familiar with the concepts, this document will not be that helpful to you, except for a few small-cases referring to how they are applied locally. 

A region is effectively two points, or more specifically, a way to define an enclosed shape. Rectangles and squares are popular for simplicity. This is where two-points comes from:

<br />

<p align="center">
<img src="/ImageRegionAnalysis/Images/Region_TwoPoints.png" style="height:140px;"/>
</p>
 

To say a region is two-points, really kind-of defeats the purpose. A region is bounded, and some data is required to bind it. A region can just as-well be one-point, a height, and a width. Conceptually, the region is a bound, we can treat it as two-points. 

A region marks the bounds, because what it contains is important. The points of the region above, are shown below, blank, and containing the top of an X. 

<p align="center">
<img src="/ImageRegionAnalysis/Images/Region_Empty.png" style="height:140px;"/><img src="/ImageRegionAnalysis/Images/Region_TopOfX1.png" style="height:140px;"/>
</p>
<br />
<br />

### What To Do With Regions When You Are Bored

One common use for regions, is to find things. Not things you lost, things you didn’t know you had. An image is an image, until it is an image is of something semi-predictable. Then predicting it, becomes the game. 

For Image Region Analysis (app and sources), the first region is the image itself. As the image is read-in, first as a Bitmap, then converted to 1-bit true/false pixels, a region is defined for it, that describes the entire height and width. 

<p align="center">
<img src="/ImageRegionAnalysis/Images/fARIAL_2_doc.png" style="height:140px;"/>
</p>


In the case of an early training image, the outermost region contains all of the data. It is the image itself (in some form, 1-bit or otherwise). 

<p align="center">
<img src="/ImageRegionAnalysis/Images/fARIAL_2_Doc_Lines.png" style="height:140px;"/>
</p>


The next set of regions for a training image, are lines of text. To be clear, we work the outermost image region, to find lines of text, and create them as regions. It is common practice to crop off white space along the perimeter of image before looking for lines. I have not added that step yet, so when finding lines, my regions contain everything from X=0 to X=max, most notable in the font-name and digits rows. Any whitespace that is part of your region, is treated as workable space and takes time to process. 

Lines are good, but we cannot read them as whole lines. The four-line regions, exist because we defined them to do work. They bind the space to look for characters in. 

<p align="center">
<img src="/ImageRegionAnalysis/Images/fARIAL_2_Line2CharsA-J.png" style="height:140px;"/>
</p>

 
The above image, is a partial illustration of segmenting upper-case line of a training image down into  26-separate regions of their own. 
You can see how regions begin to multiply. I dare say they are worse, than rabbits in a drawer. In the very-slim training images, there are 62-character regions that are kept, four row regions, an image region, and font-name character regions that are currently discarded, but may be reverse OCRd from the alphabet once read later on. 

But this is not OCR, these regions are just where the fun begins. We have seen where regions defined within another region, do not necessarily have to consume all of the space. The regions defining lines of text consumed all of the width due to a missing piece of crop-code, but they do not consume all of the height of the image region. 

Subregioning characters is a different matter. Previously, we were looking for floating regions in a space, because we were not quite sure where to look closer. Now, we have a character region, and are pretty sure that all of its data matters to us somehow. Just the same, it remains useful to apply regions to it, and inspect the character data based upon a generalization regarding where the data occurs in relation to the overall image. Just like a character is a region in a line, and a line a region in an image, subregions of characters define a space that falls inside of all outer layers, that can be looked at as a single item, rather than many pixels. 

<p align="center">
<img src="/ImageRegionAnalysis/Images/CharacterRegionFromText.png" style="height:400px;"/>
</p>
<p align="center"> 
(yes.. I left the spellchecker on in the first font images)
</p>
 


To do this, a grid of regions is used to describe the character region. That is, the character may be subdivided into columns and rows of smaller regions. For instance, each character may be automatically divided up into 4-regions-wide by 5-regions-high. What matters, is that every region of a row have matching start and end Y, and every element of a column have matching start and end X. This is not a problem, if you simply build a grid, with no border overlap. That is, the start of the next  row or column, is one-larger than the end of this row or column… not the same. You do not start and end at the same place, they are neighbors.

To illustrate, let's look at the number-8:
 
<p align="center">
<img src="/ImageRegionAnalysis/Images/f8_num8.png" style="height:140px;"/>
</p>


In the few fonts above, we can rationalize some things about the digit-8, with very little effort. Most set pixels are near the top, bottom, left, or right edge, with the exception of dead-center, and the vertical center edges. It also has nothing in the middle of the bottom, and nothing in the middle of the top. If we were forced to reconstruct the number-8, using only 35-pixels, it might look something like this:

<p align="center">
<img src="/ImageRegionAnalysis/Images/f8_Regioned8.png" style="height:200px;"/>
</p>
 

More specifically, it might look like this if you applied a 1-bit threshold. This is a broad categorization of what character subregioning is capable of. 1-bit, is the least informative way to look at region data. 

The purpose of a region, is to generalize the data of many smaller spaces. In the case of subregions (and most regions in Image Region Analysis), these smaller spaces are pixels. We generalize, because the volume of all data is too much to deeply interrogate quickly. Image pixels contain more information than is necessary, use too much space, and are slow as a result. Reducing the image to 1-bit helps substantially, but is still slow. It has to be worked that way once or more, but fewer times is better. 

A region allows capturing a multitude of data in a small space, which leaves room to draw values that cannot be done easily on a pixel-by-pixel basis. 
Put simply:

<pre>
1)	A region 25x40 pixels, has 1,000-pixels
2)	A typical image pixel might have around 4-bytes, or 32-bits
3)	A region 25x40, represents approximately  4-KB
4)	As 1-bit, the same region is 1,000 bits, or 125-bytes (this helps)
5)	As a region, the character gets a bit more complicated
    a.	The character region has:
         i.	Pt Start (int x, int y) for 64-bytes
        ii.	Pt End (int x, int y) for 64-bytes
    b.	If character subregions are 5x7
         i.	Pt Start (int x, int y) for 280-bytes total
        ii.	Pt End (int x, int y) for 280-bytes total
       iii.	Count (int) for 140-bytes each unique counter
</pre>

When using a character region, and 35-subregions to describe the character, a single counter for each region can summarize the character in a minimum of 828-bytes for 1,000-pixels, that are otherwise 4,000-bytes. Furthermore, additional int counters can be added for the expense of roughly 140-bytes each. 

To do a more direct comparison, to not generalizing data, a character described above with 10-integer counters, would:

Take 320,000-bytes as 10-int counters concerning each pixel

 OR 

Take 2,376-bytes as 10-int counters concerning a character region with 35-subregions

This is to ease some apprehension, that goes along with adding counters, to participate on vast arrays. Propper regioning, reduces the total counter overhead, for an affordable reduction in resolution.

The result, is each set of character subregion counts, effectively forms its own greyscale image of the character, in low resolution.  

<br />
<br />

EOF
