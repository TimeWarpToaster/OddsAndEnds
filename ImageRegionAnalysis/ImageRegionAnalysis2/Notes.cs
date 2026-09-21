namespace ImageRegionAnalysis2
{
    class Notes
    {

        /*
         * 2026-09-19 - 2026-09-20
         * 
         * [ ] IMPORTANT - xBreaks and yBreaks, need to be read in from template file, auto
         * [ ] Bits.linesFromBits.numRequired needs to be restored to percent of row, with object confirmation upon set-pixel.
         *     * The error stems from Q. The tail of Q gets segmented into new line, when looking for 1% of row to be set.
         *     [ ] Bits.columnsFromRegion.cntRequired needs the same fix
         *         [ ] Also, name them the same if kept
         *         
         *         
         * FONT ISSUES
         * 
         * [ ] Arial 'fg' is single character
         * [ ] Bahnschrift 
         *     [ ] 'FT' this is not affecting template, but impacts William Howard in caps
         * [ ] Calibri 'fg'
         * [ ] Courier New Medium is still turning 'F' and 'H' into multiple characters 'J', 'L', large serifs
         *     * For now, fix this same way as line-parse. Stop relying on percents atm.
         * [ ] MS Sans Serif Medium 'ij' (not large)
         * [ ] Myanmar Text 'ij'
         * [ ] Tahoma 'fg' is single character, even on large, 'TA'
         * [ ] Times New Roman 
         *     [ ] 'j' curls under prior character
         *     [ ] Med segments characters at serifs
         *     [ ] Many serifs can join in upper to for single character i.e. KXMNW can be joined
         *     
         * * Large Fonts No Issue
         *   * Bahnschrift
         *   * Comic Sans
         *   * Courier New
         *   * Lucida Console
         *   * MS Sans Serif
         *   * Veranda
         *   
         * * Med. Fonts No Issue
         *   * Calibri
         *   * Comic Sans
         *   * Lucida Console
         *   * Veranda
         *   
         * 
         * 2026-09-18
         * 
         * [ ] Need new counts for e.g. % Set Left of % Ttl Set
         * [ ] Fix a template model to proceed with. Work with three-sizes, small, medium, and large.
         *       Create all templates. Hardcode a toggle for now.
         * 
         * 
         * 2026-09-16
         * 
         * [*] Add four List<int> to the counts, keep track of unset-pixels outside of character
         * 
         *     3210000000123
         * 3      XXXXXXX      3                        VVV^^^ = round side O, o, D, e, Q, C, c, S, s, U, u, 3, 6, 8, 9, 0
         * 2     X       X     2                        VVVVVV = pyramidial 'A', slant 7, 4, 2, 
         * 1    XX       XX    1                        ^^^^^^ = inverted pyramidial 'V', 'W'
         * 0   XXXXXXXXXXXXX   0                        www... = short lower-case (where w is width)
         * 0   XX              11                       LLLHLL = opening this side (low/high)
         * 1    XX       XX    1                        ^^^VVV = converging lines X, x, K, k
         * 2      XXXXXXXX     2                        VV^^H/.= round upper P, R, B
         *     2110000000013                             H/.VV^^= round lower b, d, 
         *     
         * [ ] Create a basic table helper, to automate ascii tables
         * [ ] Create font data
         *     [ ] Produce CSV files of templates
         *     [ ] Combine all CSV sections into single spreadsheet
         * [ ] Create an alternate spreadsheet that may be more messy, with 62 tabs?
         *     [ ] Group rows by letter instead of font (cross-font & size)
         *     [ ] Begin defining rules based upon data
         * [ ] Experiment with another font-size, confirm percent approach (limit to accuracy?)
         * 
         * 
         * 
         * 2026-09-15
         * 
         * [ ] Typify the fonts (i.e. get some early stats)
         * [ ] Do font percentages match across scale?
         * [ ] Need to start recording data in a big way
         *     [ ] Also need to be able to compare it later, having data is not enough, DB?
         *         [ ] What do you do about latent storage? Looking up a font is slow, is it mem or DB?
         * [*] I love the new templates. I think (hope) they are just counts. It's close enough.
         * [*] Something of the counts isn't right
         *     * Frankly, only percentages really matter, if the goal is to scale. However, percentages are
         *       also wrong, if the small image does not have enough pixels for all X-regions. As is 'i'.
         *     * Okay, so also, the truth is also something close to dithering (although I don't know what that
         *       means), a large number of 1-bit pixels, are being transformed into a small number of 
         *       full greyscale pixels, at the expense of resolution, and gain of depth.
         * 
         * 
         * 
         * 
         * 2026-09-14
         * 
         * [*] Request to investigate using median-set-point position, as an inidicator to set-point 
         *       distribution, or specific character. How unique? Accurate?
         *     [*] 1) Get center of set pixels, add up y, add up x, divide down
         *     [*] 2) Get average distance from region center
         *              Pythagorean theorum X and Y back to region center, average the distance of set pixels
         *         * One and two are different. One gives only center, two gives only proportion. Put them together.
         *     [*] There are at-least two-more counts here. Average distance is diagonal XY. There should be 
         *           two-more averages for avgDistanceX and avgDistanceY. Like a weighted height-width-ratio.
         * [ ] Add a Counts object to typify the font / character-set / font-size (avg all counts for all characters)
         *     [ ] Determine characters statistically above, below, left, and right of average
         * [*] Convert all counts to percentages, they have limited frame of reference
         * 
         * 
         * 
         * 2026-09-10
         * 
         * [*] Create training images for set '3', medium size (technically, they are the "recommended minimum size")
         * [ ] Create templates for each optical font-size and font
         * [*] Create a list of Known Templates, link known templates to known images
         *     * There is a caveat, in that more than one template can be known per font-size (regioned 3x5, 5x10, ...)
         * [/] Autoload first appropriate template when known image (training image) is selected
         * [ ] Start recording second-closest template match, also record median of all templates per character
         * 
         * 
         * TESTING TODO LIST
         * [*] Begin timestamping processes, create a tiny report of ellapsed
         *   [ ] Identify areas of slowness, first-pass obvious
         *   [*] Did it, but did it wrong
         *     [*] Fix if checkboxes change during process, null exception can be thrown on uninit Elapsed object
         * [ ] Write a script 
         *   [*] Codify the text input that is in the image, with and without spaces
         *   [ ] Automate counting accurate and missed characters
         *     [ ] Consider how to report missed characters versus 62 templates report fashion, so we can see
         *   [ ] Figure out how to store test results, without necessarily storing megs per read
         *     [ ] If we have a reference text, just storing output text is half, we probably want a little more
         * [ ] Compare times by image-size and region count
         * [ ] Compare accuracy results by:
         *   [ ] Image size
         *   [ ] Region count
         *   [ ] Font
         * [ ] Compile results for missed characters across regions, fonts, and font-sizes
         *     * Expect them not to be the same, identify all culprits (e.g. 5 and S will always be there, find rest)
         * 
         * 
         * 
         * 
         * 
         * ----
         * 
         * 
         * 2026-09-09
         * 
         * First results are fine. Corner-cases are being exposed. 5 & S, B and Q (for some reason), O and 0, normal stuff
         * 
         * Once the pairs lacking confidence are known, they should toggle some additional simple tests, 5 and S may be as simple as
         * focusing on the Top and Left counts of the TopLeft region, and Bottom and Left of the MidLeft region. Effectively wieghting
         * specific regions higher, and perhaps specific counts.
         * 
         * Increasing the number of regions had small effect on overall accuracy with upper-case. 
         * Need to try mixed case
         * Need to create mid-size images
         *   * Go back to fewer regions
         * Need to retest uneven region sizes (mixed percents along axis)
         * 
         * [ ] Turn character region counts into percentages, so counts can scale across differently proportioned character regions
         * 
         * [ ] Address the issue of adding spaces back, try measuring this and last width, and look for gaps 
         *     larger than 1/2 of the greater width
         * 
         * * Want to clean-up, but everything works right-now
         *   * What works needs to migrate where it belongs
         * 
         * 
         * ----
         * 
         * 2026-09-08
         * 
         * [ ] Disengage UI from logic regions, mostly in Form1, need to create regions generically from input
         * [*] Add function to read text image, output to rtb
         * 
         * Need a regions object to act as a counts bucket, to match character sub-regions, and hold the 
         * sub-region diffs between two characters.
         * 
         * 
         * 
         * 
         * ----
         * 
         * 
         * 2026-09-07
         * TODO
         * [*] Convert character sub-region counts to json
         * [*] Save off character sub-region counts to file
         * [*] Create memory for stock sub-region counts
         * [*] Read saved counts into memory
         * 
         * ** Consider converting counts to a percent-pixels-set, so the template will scale.
         * 
         * 
         * * All characters need to crop down vertically. The tail of Courier New 'Q' is lower than all other characters
         *       but broad enough to be separated as an independant line. Character height on a line basis gets skewed,
         *       causing the template not to match valid characters (versus a line not containing Q).
         *       * Look in Bits.columnsFromRegions for crop opportunity
         *       * Post Note: this issue has been smoothed (not solved) at line-detection. Cropping down is more 
         *           complicated than it seems, because it skews results in some cases (i.e. partial print character).
         *           Having the anticipated height of a font one-character-to-another has its value. Even white-space 
         *           has value in this context. The distinction between upper and lower is exagerated. 
         * 
         * 
         * 
         * 
         * 
         * -----------------------------------------------------------------------------
         * 
         * OLD
         * 
         * Pt is fine
         * Region is fine
         * 
         * Regions is a pain to use
         * * Its not static, requires a member
         * * What do you call it? If its "regions", then regions.regions is silly.
         * * Regions works, the List<List<Region>> is fine (good as any)
         *   * Iterating the list is cumbersome. Needs an x,y helper to access a region
         * * Maybe wrapping functionality of the List<List<Region>> solves naming issues
         * * Counts is close to region, when is it worth region being more than position
         * * Some debate whether regions needs to be anchored to the whole, or if the 
         *   regions can free-float. Ideally, I have a notion to constrain all image (pixel)
         *   data to the image, going back to the image for everything. If this is true, 
         *   every xy must be relative to the original image, and not any region or 
         *   sub-region. All iteration needs to know this. However, if characters are 
         *   cropped, the opposite is true.
         *   * Are there two sets of offsets instead, offsets and dimensions?
         *   * For instance, the Regions.height and Regions.width, should mean the whole 
         *     image, if the offsets are relative to the whole image, however a height 
         *     and width of the region itself must exist. Those are not enough, the 
         *     height and width of the region must have a start location within the 
         *     height and width of the image, and the end of the region must fit as well.
         *     Region and Regions both complicate this, how much should they know?
         * 
         * 
         * -------------------------------------------------------------------
         * 
         * 
         * Read
         * ABCEFGHIJKLMNTUVWXYZ234567890
         * 
         * Actual
         * ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890
         * 
         * Matches
         * ABC*EFGHIJKLMN*****TUVWXYZ*234567890
         * 
         * 
         * Read
         * [ABC][EFGHIJKLMN][TUVWXYZ][234567890]
         * 
         * Actual
         *     [ABC] [EFGHIJKLMN]     [TUVWXYZ] [234567890]
         *      ABC D EFGHIJKLMN OPQRS TUVWXYZ 1 234567890
         *      ABC * EFGHIJKLMN ***** TUVWXYZ * 234567890
         * 
         * 
         * Read     :  ABC  O  EFGHIJKLMN  DRO 5  TUVWXYZ  l  234567890
         * Islands  : [ABC]   [EFGHIJKLMN]       [TUVWXYZ]   [234567890]
         * Matches  :  ABC  *  EFGHIJKLMN  *****  TUVWXYZ  *  234567890
         * Actual   :  ABC  D  EFGHIJKLMN  OPQRS  TUVWXYZ  1  234567890
         * 
         * Island Find Order:
         * Locked   :         [EFGHIJKLMN]       
         * Locked   :         [EFGHIJKLMN]                   [234567890]
         * Locked   :         [EFGHIJKLMN]       [TUVWXYZ]   [234567890]
         * Locked   : [ABC]   [EFGHIJKLMN]       [TUVWXYZ]   [234567890]
         * 
         * 
         * ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890
         * 
         * while (notdone)
         * {
         *      var hole = findLargestHole(offsets);
         *      
         *      int cntMostMatch
         *      int idxBest
         *      int idxStart
         *      for (idxStart = hole.start; idxStart < hole.end; idxStart++)
         *      {
         *          int count = 
         *      }
         *      
         *      char[] tempMatches
         *      for (idx = idxBest; ; idx++)
         *      {
         *          tempMatches[idx] = a[hole.start + idx] == b[hole.start + idx]
         *      }
         * }
         * 
         * Try an int[maxSize] holding offsets to smaller array, -1 for no match
         * 
         * 
         *      A  B  C  E  F  G  H  I  J  K  L  M  N  T  U  V  W  X  Y  Z  2  3  4  5  6  7  8  9  0
         *      1  2  3  5  6  7  8  9  10 11 12 13 14 20 21 22 23 24 25 26 28 29 30 31 32 33 34 35 36
         *      1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36
         *      A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  1  2  3  4  5  6  7  8  9  0
         * 
         * 
         * 
         *     [A  B  C]   [E  F  G  H  I  J  K  L  M  N]               [T  U  V  W  X  Y  Z]   [2  3  4  5  6  7  8  9  0]
         *      1  2  3     5  6  7  8  9  10 11 12 13 14                20 21 22 23 24 25 26    28 29 30 31 32 33 34 35 36
         *      1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36
         *      A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  1  2  3  4  5  6  7  8  9  0
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * ==================================================================================
         * 
         *                  FONT SIZES OF INITIAL CODE
         *                  
         * 
            Files Read_Font_Name_1.bmp

                ARIAL Small - 14px tall

                BAHNSCHRIFT Mid - 13px tall

                CALIBRI Mid - 12px tall

                COMIC SANS Mid - 14px tall

                COURIER NEW Mid - 11px tall

                LUCIDA CONSOLE Mid - 12px tall

                MS SANS SERIF Mid - 14px tall

                MYANMAR TEXT Mid - 14px tall

                TAHOMA Mid - 14px tall

                TIMES NEW ROMAN Mid - 12px tall

                VERANDA Mid - 15px tall




            Files Read_Font_Name_2.bmp

                ARIAL Large - 34px tall (training off by 1)

                BAHNSCHRIFT Large - 43px tall

                CALIBRI Large - 42px tall

                COMIC SANS Large - 44px tall

                COURIER NEW Large - 36px tall

                LUCIDA CONSOLE Large - 37px tall

                MS SANS SERIF Large - 42px tall

                MYANMAR TEXT Large - 42px tall

                TAHOMA Large - 43px tall

                TIMES NEW ROMAN Large - 40px tall

                VERANDA Large - 43px tall




            Files Read_Font_Name_3.bmp ----- NO LONGER ACCURATE, getting from line-height is appropriate

                ARIAL Mid - 22px tall / 21

                BAHNSCHRIFT Mid - 22px tall / 21

                CALIBRI Mid - 20px tall / 19

                COMIC SANS Mid - 21px tall / 22

                COURIER NEW Mid - 18px tall / 17

                LUCIDA CONSOLE Mid - 19px tall / 18

                MS SANS SERIF Mid - 23px tall / 22

                MYANMAR TEXT Mid - 22px tall / 21

                TAHOMA Mid - 23px tall / 22

                TIMES NEW ROMAN Mid - 21px tall / 20

                VERANDA Mid - 23px tall / 22
         * 
         * 
         * 
         * 
         * 
         * 
         */









    }
}
