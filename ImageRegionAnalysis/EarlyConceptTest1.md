# Early Concept Test 1

## Overview

The very earliest OCR testing results. Relies entirely upon region analysis and set pixel counts, with no rules, remediating, weighting of values. Lowest net difference of set-pixel region counts wins.

Most results are to be anticipated (60-90% accurate). Of these, most are things like O, o, and 0 all looking alike, S and 5, and strangely R and X. Taking into account the primitive match selection process, the results indicate a general viability of concept. 

Results for Lucida Console are an exception among what is posted below. A couple things went wrong during template creation. When parsing the training characters from image, there was an extra artifact around 'K', that bumped the rest down the line. However, you can see by the result of O=o a large number of times, that a character was also not read by the time of training 'o'. The effect is, a large number of "wrong" matches, that are only off by one character due to the template being shorted (e.g. L=M, M=N, ...). In other words, it correctly matched the template it was supposed to, but the template was lettered incorrectly at training. Reading the input image with this incorrect template, also produced two non-existent characters in the read output. No other font did this. I am fairly sure of what went wrong, but have not had time to study it. The results of this run are posted here anyway.


## Input Data / Read Image

Below is a copy of the text contained in read images for various fonts. It is not fancy or complicated, nor does it have a good distribution of character usage. It does include uppercase A-Z, minus Q and V, and the numbers 0-9. When the image is read, whitespace is removed. This is what the computer is expected to produce:

THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235

Input: 241 characters

Distribution Of Letters And Numbers:
<pre>
A: 17,   B:  8,   C:  5,   D:  9,   E: 32,   F:  3,   G:  2,   H:  7,   I:  7,  J:  1, 
K:  2,   L:  7,   M:  7,   N: 16,   O: 20,   P: 10,   Q:  0,   R: 22,   S:  9,
T: 20,   U:  8,   V:  0,   W:  7,   X:  1,   Y:  4,   Z:  1,  
0:  2,   1:  2,   2:  2,   3:  2,   4:  1,   5:  2,   6:  1,   7:  1,   8:  2,  9:  1
</pre>

In the sections that follow, each named font will be followed by the input text, the read text, and a line of symbols marking mismatches with an 'x'. Posted here are results using 4x5 subregions, where there are 4-equal regions across X, and 5-equal regions across Y. 

To do something similar yourself with build sources, open Form1, and near the top edit xBreaks and YBreaks. Create the array as 4-X's at 25, and 5-Y's at 20. Load the corresponding training image from Main tab, on the second tab find lines, on the third tab find characters, on the fourth tab give a path and file name for the template, click the Counts button, Save the template, then Load the template. Finally, go to the read tab, and open the matching read image. NOTE:  I do not have read images for all fonts / sizes that posses training images. You might want to flip through the images folder first. I believe the medium fonts are best supported. Right now, medium means around 20-24px tall depending upon font. 


## Results

### Bahnschrift Medium - 4x5 Subregions

<pre>
THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235
THISISARAN00MPARAGRAPHOFUPPERCASELE*7ERSEXCEPTFORTHELE*EERBETWEENPANORALSON0PUNCTUATIONC0UL0TRYNUMBERSZER0PR0BABLYW0NTWORK0RMAYBE0W0NTW0RKINSTEA0N0TMUCHH0PEF0R1AN0IEITHERJUSTAMAYBETHERENEE0T0BEM0RENUMBERSWELLPRETEN0WEAREA0OING12S4567E90E02S5
..........xx.......................xx.................xx............x......x............x..x.............x..x......x......x......x.x...x........x.x......x...x....x.........................x.x...x...................x......xx.....x....x..x..x.
</pre>
<pre>
Errors:    32  (13.278%)

D:   9      -  28.1% of errors, 3.7% of total
O:  15      -  46.9% of errors, 6.2% of total
3:   2      -   6.2% of errors, 0.8% of total
8:   2      -   6.2% of errors, 0.8% of total
TT:  2(4)   -  12.5% of errors, 0.8% of total


D:
 0:  7 - 77.8% of D's
 O:  2 - 22.3% of D's

O:
 0: 15 - 75.0% of O's

3:
 S:  2 - 100%  of 3's

8:
 E:  2 - 100%  of 8's

TT:
 7:  1 - 50% of TT's
 E:  1 - 50% of TT's
</pre>


### Calibri Medium - 4x5 Subregions

<pre>
THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235
1HmSmSARANODMPABAGBAPHDFUPPEBCASEEET1EBSEXCEP1FOBTHELETTERRETWEENPANDBALSDNDPUNCTUA1kDNCDULOTBzNbMBEBSZEBOPBDRARLzWDNTWOBKDBMAzREDWONTWOBKmNSTEAONDTHUCHHDPEFDB1ANOmEmTHEB3OSTAMAzRE1HEBENEEOTDBEMDBENOHREBSWEEEPBE1ENOWEABEADOkNG1234S67BBQBD23S
x.x.x.....xx...x..x...x.....x....x..x.x......x..x.........x..........x...x.x.......xxx..x..x.xx.x...x...x..xxx.x.x.x....x.xx..xx.x......x.x.....x.x.x....x...xx...xx.x...xxx.....xx.x..x....x.x...xx..xxx.x...xx.x.x..x...x...xx......x..xxxxx..x
</pre>

<pre>
Errors:    81  (33.610%)

B: 6      -   7.4% of errors, 2.5% of total
D: 7      -   8.6% of errors, 2.9% of total
I: 7      -   8.6% of errors, 2.9% of total
J: 1      -   1.2% of errors, 0.4% of total
L: 3      -   3.7% of errors, 1.2% of total
M: 2      -   2.5% of errors, 0.8% of total
O: 15     -  18.5% of errors, 6.2% of total
R: 20     -  24.7% of errors, 8.3% of total
T: 6      -   7.4% of errors, 2.5% of total
U: 3      -   3.7% of errors, 1.2% of total
Y: 4      -   4.9% of errors, 1.7% of total
0: 2      -   2.5% of errors, 0.8% of total
5: 2      -   2.5% of errors, 0.8% of total
8: 2      -   2.5% of errors, 0.8% of total
9: 1      -   1.2% of errors, 0.4% of total


B:
 R:  6 - 75.0% of B's

D:
 O:  7 - 77.8% of D's

I:
 m:  5 - 71.4% of I's
 k:  2 - 28.6% of I's

J:
 3:  1 - 100%  of J's

L:
 E:  3  - 9.4% of E's

M:
 H:  2 - 28.6% of M's

O:
 D: 15 - 75% of O's

R:
 B: 20 - 90.1% of R's

T:
 1:  6 - 30.0% of T's

U:
 b:  1 - 12.5% of U's
 O:  2 - 25.0% of U's

Y:
 z:  4 - 100% of Y's

0:
 Q:  1 - 50.0% of 0's
 D:  1 - 50.0% of 0's

5:
 S:  2 - 100%  of 5's

8:
 B:  2 - 100%  of 8's

9:
 B:  1 - 100%  of 9's
</pre>

### Comic Sans Medium - 4x5 Subregions

<pre>
THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235
THISISARAND0MPApAGRAPH0FUPPERCASELETTERSEXCEPTFORTHELETTEpBETWEENPANDRALSONOPUNCTUATI0NCOULDTpyNUMBERSZER0PR0BABLyWONTWORK0RMAyBEOWONTW0pKINSTEADN0TMUCHH0PEF0R1ANDIEITHERJUSTAMAyBETHEpENEEDT0BEM0RENUMBEpSWELLPRETENDWEAREADDING1234567B908o235
...........x...x......x..................................x...........................x.......xx..........x..x....x........x...x........xx.........x......x...x...................x.....x......x...x.......x..............................x...x...
<pre>

<pre>
Errors:    24 (9.959%)

O: 12     -   50.0% of errors, 5.0% of total
R:  6     -   25.0% of errors, 2.5% of total
Y:  4     -   16.7% of errors, 1.7% of total
0:  1     -    4.2% of errors, 0.4% of total
8:  1     -    4.2% of errors, 0.4% of total


O:
 0: 12 - 60.0% of O's

R:
 p:  6 - 27.3% of R's

Y:
 y:  4 - 100% of Y's

0:
 o:  1 - 50% of 0's

8:
 B:  1 - 12.5% of 8's
</pre>


### Lucida Console Medium - 4x5 Subregions

<pre>
THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235
UHITITASAOPDNQASAGSAQHDFoQQESCATEMEUUESTEYCEQUFPSUHEMEUUESBEUXEEOQ1OPSAMToOPQPOCUoAUIoOCooMDUSWOoNBESTzESDQSDBABMZXoOUXoSKxoSNAZBEDXoOUXoSKxIOTUEADOoUNoCHHoQEFoS1AODIEIUHESJPTUANAZBEUHESEOEEDUoBENDSEOPNBESTXEMMQSEUEODXE1SEADoIOG1z34T678qD8PaJT
x..x.x.x.xxxxx.x..x.x.x.xxx.x..x.x.xx.xx.x..xx.xxx..x.xx.xx.xx..xxxxxx.xxxxxxxx.xx.x.xx.xxx.xxxxxx..xxx.xxxxx...xxxxxxxxx.xxxx.x..xxxxxxxx.x.xxx...xxxxx...xx..xx..x....x..x.xxx.x.x..x..x.x...xx..xxx.xxx..xxx.xxxx.x.x.x.xx...x.x..x..x...xx.xxxx
</pre>

<pre>
Errors:   147 (61.0%)


A: 2      -  1.4% of errors, 0.8% of total
D: 3      -  2.0% of errors, 1.2% of total
L: 7      -  4.8% of errors, 2.9% of total
M: 7      -  4.8% of errors, 2.9% of total
N: 16     - 10.9% of errors, 6.6% of total
O: 20     - 13.6% of errors, 8.3% of total
P: 10     -  6.8% of errors, 4.1% of total
R: 22     - 15.0% of errors, 9.1% of total
S: 9      -  6.1% of errors, 3.7% of total
T: 20     - 13.6% of errors, 8.3% of total
U: 8      -  5.4% of errors, 3.3% of total
W: 7      -  4.8% of errors, 2.9% of total
X: 1      -  0.7% of errors, 0.4% of total
Y: 4      -  2.7% of errors, 1.7% of total
Z: 1      -  0.7% of errors, 0.4% of total
0: 2      -  1.4% of errors, 0.8% of total
2: 2      -  1.4% of errors, 0.8% of total
3: 1      -  0.7% of errors, 0.4% of total
5: 2      -  1.4% of errors, 0.8% of total
9: 1      -  0.7% of errors, 0.4% of total
Unknown: 2-  1.4% of errors


A:
 1:  2 - 11.8% of A's

D: 
 P:  2 - 20.0% of D's
 o:  1 - 10.0% of D's

L: M: 7  - 100% of L's

M: N: 7  - 100% of M's

N: O: 16 - 100% of N's

O:
 D: 6  - 30.0% of O's
 P: 2  - 10.0% of O's
 o: 12 - 60.0% of O's

P: Q: 10 - 100% of P's

R:
 S: 22 - 100% of R's

S: 
 T: 9 - 100% of S's

T:
 U: 20 - 100% of T's

U: 
 o: 5 - 62.5% of U's
 P: 3 - 37.5% of U's

W: X: 7 - 100% of W's

X: Y: 1 - 100% of X's

Y: 
 Z: 3 - 75.0% of Y's
 W: 1 - 25.0% of Y's

Z:
 z: 1 - 100% of Z's

0:
 D: 1 - 50.0% of 0's
 P: 1 - 50.0% of 0's

2: 
 a: 1 - 50.0% of 2's
 z: 1 - 50.0% of 2's

3: 
 J: 1 - 100% of 3's

5: 
 T: 2 - 100% of 5's

9: 
 q: 1 - 100% of 9's

Anomolies: 2 (extra non-existent characters)
</pre>

### Veranda Medium - 4x5 Subregions

<pre>
THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEENPANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEOWONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORENUMBERSWELLPRETENDWEAREADDING123456789080235
THISISARAND0MPARAGRAPH0FUPPEXCASELE*5EXSEXCEPTFORTHELE*5EXBETWEENPANDRALS0NOPUNCTUAT10NC0ULDTRYNUMBERSZER0PR0BABLYWONTW0RK0RMAYBEOW0NTW0XKINSTEADN0TMUCHH0PEF0R1ANDIE1THERJUSTAMAYBETHERENEEDT0BEM0RENUMBERSWELLPXETENDWEAREADDING123456789O8O235
...........x..........x.....x......xx.x...............xx.x...............x..........xx..x................x..x..........x..x........x...xx.........x......x...x.......x........................x...x..............x.........................x.x...
</pre>

<pre>
Errors:    29 (12.033%)

I: 2      -   6.9% of errors, 0.8% of total
O: 16     -  55.2% of errors, 6.6% of total
R: 5      -  17.2% of errors, 2.1% of total
0: 2      -   6.9% of errors, 0.8% of total
TT: 2(4)  -  13.8% of errors, 0.8% of total


I:
 1: 2 - 28.6% of I's

O:
 0: 16 - 80.0% of O's

R:
 X: 5 - 22.7% of R's

0:
 O: 2 - 100% of 0's

TT:
 5: 2(4) - 100% of TT's
</pre>

<br />
<br />

