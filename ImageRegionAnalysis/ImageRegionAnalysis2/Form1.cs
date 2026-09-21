using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;

namespace ImageRegionAnalysis2
{
    public partial class Form1 : Form
    {
        public const string CLASSNAME = "Form1";


        Dictionary<string, string> knownImages = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> readImages = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, Dictionary<string, string>> fileTemplates = new Dictionary<string, Dictionary<string, string>>();

        Bitmap workingBmp = null;

        Bits bits = null;
        //List<int> xBreaks = new List<int> { 25, 25, 25, 25 };// 100 %
        //List<int> yBreaks = new List<int> { 20, 20, 20, 20, 20 };// 100 %

        List<int> xBreaks = new List<int>() { 20, 20, 20, 20, 20 };// 100 %
        List<int> yBreaks = new List<int>() { 14, 15, 14, 14, 14, 15, 14 };// 100 %

        //List<int> xBreaks = new List<int>() { 20, 20, 20, 20, 20 };// 100 %
        //List<int> yBreaks = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };// 100 %

        const char cnull = '*';

        Dictionary<string, Region> template = null;
        JObject templatesFromFile = new JObject();
        string[] supportedTemplates = new string[]
        { // expected keys for templatesFromFile, in the order they should occur
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z", 
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
            "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
            "u", "v", "w", "x", "y", "z", 
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        // TODO - Revise orders everywhere, to prioritize lower-case first


        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                if (!L.logInit(null, rtbLogs, false))
                {
                    // Some logging may safely work
                    L.err(location, "Failed to initialize logging.");
                }
                L.l(location, "Application started.");

                if (!this.init())
                {
                    L.err(location, "Failed to initialize application.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public bool init()
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                int cntErrors = 0;


                if (this.knownImages == null || this.knownImages.Count == 0)
                {
                    this.knownImages = new Dictionary<string, string>();
                    this.readImages = new Dictionary<string, Dictionary<string, string>>();

                    /*knownImages.Add("Arial Large", @".\Images\fARIAL_2.bmp");
                    readImages.Add("Arial Large", new Dictionary<string, string>());
                    readImages["Arial Large"].Add("Arial Large Upper", @".\Images\Read_ARIAL_2.bmp");
                    fileTemplates.Add("Arial Large", new Dictionary<string, string>());
                    fileTemplates["Arial Large"].Add("Arial Large 5x7 (1)", @".\Templates\ARIAL_2_5x7(1).tpl");*/

                    knownImages.Add("Bahnschrift Large", @".\Images\fBAHNSCHRIFT_2.bmp");
                    readImages.Add("Bahnschrift Large", new Dictionary<string, string>());
                    readImages["Bahnschrift Large"].Add("Bahnschrift Large", @".\Images\Read_BAHNSCHRIFT_2.bmp");
                    //fileTemplates.Add("Bahnschrift Large", new Dictionary<string, string>());
                    //fileTemplates["Bahnschrift Large"].Add("Bahnschrift Large 5x7 (1)", @".\Templates\BAHNSCHRIFT_2_5x7(1).tpl");

                    /*knownImages.Add("Calibri Large", @".\Images\fCALIBRI_2.bmp");
                    readImages.Add("Calibri Large", new Dictionary<string, string>());
                    readImages["Calibri Large"].Add("Calibri Large", @".\Images\Read_CALIBRI_2.bmp");
                    fileTemplates.Add("Calibri Large", new Dictionary<string, string>());
                    fileTemplates["Calibri Large"].Add("Calibri Large 5x7 (1)", @".\Templates\CALIBRI_2_5x7(1).tpl");*/

                    knownImages.Add("Comic Sans Large", @".\Images\fCOMIC_SANS_2.bmp");
                    readImages.Add("Comic Sans Large", new Dictionary<string, string>());
                    readImages["Comic Sans Large"].Add("Comic Sans Large", @".\Images\Read_COMIC_SANS_2.bmp");
                    //fileTemplates.Add("Comic Sans Large", new Dictionary<string, string>());
                    //fileTemplates["Comic Sans Large"].Add("Comic Sans Large 5x7 (1)", @".\Templates\COMIC_SANS_2_5x7(1).tpl");

                    knownImages.Add("Courier New Large", @".\Images\fCOURIER_NEW_2.bmp");
                    readImages.Add("Courier New Large", new Dictionary<string, string>());
                    readImages["Courier New Large"].Add("Courier New Large", @".\Images\Read_COURIER_NEW_2.bmp");
                    //fileTemplates.Add("Courier New Large", new Dictionary<string, string>());
                    //fileTemplates["Courier New Large"].Add("Courier New Large 5x7 (1)", @".\Templates\COURIER_NEW_2_5x7(1).tpl");

                    knownImages.Add("Lucida Console Large", @".\Images\fLUCIDA_CONSOLE_2.bmp");
                    readImages.Add("Lucida Console Large", new Dictionary<string, string>());
                    readImages["Lucida Console Large"].Add("Lucida Console Large", @".\Images\Read_LUCIDA_CONSOLE_2.bmp");
                    //fileTemplates.Add("Lucida Console Large", new Dictionary<string, string>());
                    //fileTemplates["Lucida Console Large"].Add("Lucida Console Large 5x7 (1)", @".\Templates\LUCIDA_2_5x7(1).tpl");

                    knownImages.Add("MS Sans Serif Large", @".\Images\fMS_SANS_SERIF_2.bmp");
                    readImages.Add("MS Sans Serif Large", new Dictionary<string, string>());
                    readImages["MS Sans Serif Large"].Add("MS Sans Serif Large", @".\Images\Read_MS_SANS_SERIF_2.bmp");
                    //fileTemplates.Add("MS Sans Serif Large Large", new Dictionary<string, string>());
                    //fileTemplates["MS Sans Serif Large Large"].Add("MS Sans Serif Large 5x7 (1)", @".\Templates\MS_SANS_SERIF_2_5x7(1).tpl");

                    /*knownImages.Add("Myanmar Text Large", @".\Images\fMYANMAR_TEXT_2.bmp");
                    readImages.Add("Myanmar Text Large", new Dictionary<string, string>());
                    readImages["Myanmar Text Large"].Add("Myanmar Text Large", @".\Images\Read_MYANMAR_TEXT_2.bmp");
                    fileTemplates.Add(" Large", new Dictionary<string, string>());
                    fileTemplates[" Large"].Add("Myanmar Text Large 5x7 (1)", @".\Templates\MYANMAR_TEXT_2_5x7(1).tpl");

                    knownImages.Add("Tahoma Large", @".\Images\fTAHOMA_2.bmp");
                    readImages.Add("Tahoma Large", new Dictionary<string, string>());
                    readImages["Tahoma Large"].Add("Tahoma Large", @".\Images\Read_TAHOMA_2.bmp");
                    fileTemplates.Add("Myanmar Text Large", new Dictionary<string, string>());
                    fileTemplates["Myanmar Text Large"].Add("Tahoma Large 5x7 (1)", @".\Templates\_2_5x7(1).tpl");

                    knownImages.Add("Times New Roman Large", @".\Images\fTIMES_NEW_ROMAN_2.bmp");
                    readImages.Add("Times New Roman Large", new Dictionary<string, string>());
                    readImages["Times New Roman Large"].Add("Times New Roman Large", @".\Images\Read_TIMES_NEW_ROMAN_2.bmp");
                    fileTemplates.Add("Times New Roman Large", new Dictionary<string, string>());
                    fileTemplates["Times New Roman Large"].Add("Times New Roman Large 5x7 (1)", @".\Templates\TIMES_NEW_ROMAN_2_5x7(1).tpl");*/

                    knownImages.Add("Veranda Large", @".\Images\fVERANDA_2.bmp");
                    readImages.Add("Veranda Large", new Dictionary<string, string>());
                    readImages["Veranda Large"].Add("Veranda Large", @".\Images\Read_VERANDA_2.bmp");
                    //fileTemplates.Add("Veranda Large", new Dictionary<string, string>());
                    //fileTemplates["Veranda Large"].Add("Veranda Large 5x7 (1)", @".\Templates\VERANDA_2_5x7(1).tpl");




                    /*knownImages.Add("Arial Med", @".\Images\fARIAL_3.bmp");
                    readImages.Add("Arial Med", new Dictionary<string, string>());
                    readImages["Arial Med"].Add("Arial Med L", @".\Images\Read_ARIAL_3L.bmp");
                    readImages["Arial Med"].Add("Arial Med U", @".\Images\Read_ARIAL_3U.bmp");
                    fileTemplates.Add("Arial Med", new Dictionary<string, string>());
                    fileTemplates["Arial Med"].Add("Arial Med 5x7 (1)", @".\Templates\ARIAL_3_5x7(1).tpl");

                    knownImages.Add("Bahnschrift Med", @".\Images\fBAHNSCHRIFT_3.bmp");
                    readImages.Add("Bahnschrift Med", new Dictionary<string, string>());
                    readImages["Bahnschrift Med"].Add("Bahnschrift Med L", @".\Images\Read_BAHNSCHRIFT_3L.bmp");
                    readImages["Bahnschrift Med"].Add("Bahnschrift Med U", @".\Images\Read_BAHNSCHRIFT_3U.bmp");
                    fileTemplates.Add("Bahnschrift Med", new Dictionary<string, string>());
                    fileTemplates["Bahnschrift Med"].Add("Bahnschrift Med 5x7 (1)", @".\Templates\BAHNSCHRIFT_3_5x7(1).tpl");*/

                    knownImages.Add("Calibri Med", @".\Images\fCALIBRI_3.bmp");
                    readImages.Add("Calibri Med", new Dictionary<string, string>());
                    readImages["Calibri Med"].Add("Calibri Med L", @".\Images\Read_CALIBRI_3L.bmp");
                    readImages["Calibri Med"].Add("Calibri Med U", @".\Images\Read_CALIBRI_3U.bmp");
                    //fileTemplates.Add("Calibri Med", new Dictionary<string, string>());
                    //fileTemplates["Calibri Med"].Add("Calibri Med 5x7 (1)", @".\Templates\CALIBRI_3_5x7(1).tpl");

                    knownImages.Add("Comic Sans Med", @".\Images\fCOMIC_SANS_3.bmp");
                    readImages.Add("Comic Sans Med", new Dictionary<string, string>());
                    readImages["Comic Sans Med"].Add("Comic Sans Med L", @".\Images\Read_COMIC_SANS_3L.bmp");
                    readImages["Comic Sans Med"].Add("Comic Sans Med U", @".\Images\Read_COMIC_SANS_3U.bmp");
                    //fileTemplates.Add("Comic Sans Med", new Dictionary<string, string>());
                    //fileTemplates["Comic Sans Med"].Add("Comic Sans Med 5x7 (1)", @".\Templates\COMIC_SANS_3_5x7(1).tpl");

                    /*knownImages.Add("Courier New Med", @".\Images\fCOURIER_NEW_3.bmp");
                    readImages.Add("Courier New Med", new Dictionary<string, string>());
                    readImages["Courier New Med"].Add("Courier New Med L", @".\Images\Read_COURIER_NEW_3L.bmp");
                    readImages["Courier New Med"].Add("Courier New Med U", @".\Images\Read_COURIER_NEW_3U.bmp");
                    fileTemplates.Add("Courier New Med", new Dictionary<string, string>());
                    fileTemplates["Courier New Med"].Add("Courier New Med 5x7 (1)", @".\Templates\COURIER_NEW_3_5x7(1).tpl");*/

                    knownImages.Add("Lucida Console Med", @".\Images\fLUCIDA_CONSOLE_3.bmp");
                    readImages.Add("Lucida Console Med", new Dictionary<string, string>());
                    readImages["Lucida Console Med"].Add("Lucida Console Med L", @".\Images\Read_LUCIDA_CONSOLE_3L.bmp");
                    readImages["Lucida Console Med"].Add("Lucida Console Med U", @".\Images\Read_LUCIDA_CONSOLE_3U.bmp");
                    //fileTemplates.Add("Lucida Console Med", new Dictionary<string, string>());
                    //fileTemplates["Lucida Console Med"].Add("Lucida Console Med 5x7 (1)", @".\Templates\LUCIDA_CONSOLE_3_5x7(1).tpl");

                    /*knownImages.Add("MS Sans Serif Med", @".\Images\fMS_SANS_SERIF_3.bmp");
                    readImages.Add("MS Sans Serif Med", new Dictionary<string, string>());
                    readImages["MS Sans Serif Med"].Add("MS Sans Serif Med L", @".\Images\Read_MS_SANS_SERIF_3L.bmp");
                    readImages["MS Sans Serif Med"].Add("MS Sans Serif Med U", @".\Images\Read_MS_SANS_SERIF_3U.bmp");
                    fileTemplates.Add("MS Sans Serif Med", new Dictionary<string, string>());
                    fileTemplates["MS Sans Serif Med"].Add("MS Sans Serif Med 5x7 (1)", @".\Templates\MS_SANS_SERIF_3_5x7(1).tpl");

                    knownImages.Add("Myanmar Text Med", @".\Images\fMYANMAR_TEXT_3.bmp");
                    readImages.Add("Myanmar Text Med", new Dictionary<string, string>());
                    readImages["Myanmar Text Med"].Add("Myanmar Text Med L", @".\Images\Read_MYANMAR_TEXT_3L.bmp");
                    readImages["Myanmar Text Med"].Add("Myanmar Text Med U", @".\Images\Read_MYANMAR_TEXT_3U.bmp");
                    fileTemplates.Add("Myanmar Text Med", new Dictionary<string, string>());
                    fileTemplates["Myanmar Text Med"].Add("Myanmar Text Med 5x7 (1)", @".\Templates\MYANMAR_TEXT_3_5x7(1).tpl");

                    knownImages.Add("Tahoma Med", @".\Images\fTAHOMA_3.bmp");
                    readImages.Add("Tahoma Med", new Dictionary<string, string>());
                    readImages["Tahoma Med"].Add("Tahoma Med L", @".\Images\Read_TAHOMA_3L.bmp");
                    readImages["Tahoma Med"].Add("Tahoma Med U", @".\Images\Read_TAHOMA_3U.bmp");
                    fileTemplates.Add("Tahoma Med", new Dictionary<string, string>());
                    fileTemplates["Tahoma Med"].Add("Tahoma Med 5x7 (1)", @".\Templates\TAHOMA_3_5x7(1).tpl");

                    knownImages.Add("Times New Roman Med", @".\Images\fTIMES_NEW_ROMAN_3.bmp");
                    readImages.Add("Times New Roman Med", new Dictionary<string, string>());
                    readImages["Times New Roman Med"].Add("Times New Roman Med L", @".\Images\Read_TIMES_NEW_ROMAN_3L.bmp");
                    readImages["Times New Roman Med"].Add("Times New Roman Med U", @".\Images\Read_TIMES_NEW_ROMAN_3U.bmp");
                    fileTemplates.Add("Times New Roman Med", new Dictionary<string, string>());
                    fileTemplates["Times New Roman Med"].Add("Times New Roman Med 5x7 (1)", @".\Templates\TIMES_NEW_ROMAN_3_5x7(1).tpl");*/

                    knownImages.Add("Veranda Med", @".\Images\fVERANDA_3.bmp");
                    readImages.Add("Veranda Med", new Dictionary<string, string>());
                    readImages["Veranda Med"].Add("Veranda Med L", @".\Images\Read_VERANDA_3L.bmp");
                    readImages["Veranda Med"].Add("Veranda Med U", @".\Images\Read_VERANDA_3U.bmp");
                    //fileTemplates.Add("Veranda Med", new Dictionary<string, string>());
                    //fileTemplates["Veranda Med"].Add("Veranda Med 5x7 (1)", @".\Templates\VERANDA_3_5x7(1).tpl");





                    /*
                    knownImages.Add("Arial Min", @".\Images\fARIAL_1.bmp");
                    fileTemplates.Add("Arial Min", new Dictionary<string, string>());
                    fileTemplates["Arial Min"].Add("Arial Min 4x5 (1)", @".\Templates\ARIAL_1_4x5(1).tpl");

                    knownImages.Add("Bahnschrift Min", @".\Images\fBAHNSCHRIFT_1.bmp");
                    fileTemplates.Add("Bahnschrift Min", new Dictionary<string, string>());
                    fileTemplates["Bahnschrift Min"].Add("Bahnschrift Min 4x5 (1)", @".\Templates\BAHNSCHRIFT_1_4x5(1).tpl");

                    knownImages.Add("Calibri Min", @".\Images\fCALIBRI_1.bmp");
                    fileTemplates.Add("Calibri Min", new Dictionary<string, string>());
                    fileTemplates["Calibri Min"].Add("Calibri Min 4x5 (1)", @".\Templates\CALIBRI_1_4x5(1).tpl");

                    knownImages.Add("Comic Sans Min", @".\Images\fCOMIC_SANS_1.bmp");
                    fileTemplates.Add("Comic Sans Min", new Dictionary<string, string>());
                    fileTemplates["Comic Sans Min"].Add("Comic Sans Min 4x5 (1)", @".\Templates\COMIC_SANS_1_4x5(1).tpl");

                    knownImages.Add("Courier New Min", @".\Images\fCOURIER_NEW_1.bmp");
                    fileTemplates.Add("Courier New Min", new Dictionary<string, string>());
                    fileTemplates["Courier New Min"].Add("Courier New Min 4x5 (1)", @".\Templates\COURIER_NEW_1_4x5(1).tpl");

                    knownImages.Add("Lucida Console Min", @".\Images\fLUCIDA_CONSOLE_1.bmp");
                    fileTemplates.Add("Lucida Console Min", new Dictionary<string, string>());
                    fileTemplates["Lucida Console Min"].Add("Lucida Console Min 4x5 (1)", @".\Templates\LUCIDA_CONSOLE_1_4x5(1).tpl");

                    knownImages.Add("MS Sans Serif Min", @".\Images\fMS_SANS_SERIF_1.bmp");
                    fileTemplates.Add("MS Sans Serif Min", new Dictionary<string, string>());
                    fileTemplates["MS Sans Serif Min"].Add("MS Sans Serif Min 4x5 (1)", @".\Templates\MS_SANS_SERIF_1_4x5(1).tpl");

                    knownImages.Add("Myanmar Text Min", @".\Images\fMYANMAR_TEXT_1.bmp");
                    fileTemplates.Add("Myanmar Text Min", new Dictionary<string, string>());
                    fileTemplates["Myanmar Text Min"].Add("Myanmar Text Min 4x5 (1)", @".\Templates\MYANMAR_TEXT_1_4x5(1).tpl");

                    knownImages.Add("Tahoma Min", @".\Images\fTAHOMA_1.bmp");
                    fileTemplates.Add("Tahoma Min", new Dictionary<string, string>());
                    fileTemplates["Tahoma Min"].Add("Tahoma Min 4x5 (1)", @".\Templates\TAHOMA_1_4x5(1).tpl");

                    knownImages.Add("Times New Roman Min", @".\Images\fTIMES_NEW_ROMAN_1.bmp");
                    fileTemplates.Add("Times New Roman Min", new Dictionary<string, string>());
                    fileTemplates["Times New Roman Min"].Add("Times New Roman Min 4x5 (1)", @".\Templates\TIMES_NEW_ROMAN_1_4x5(1).tpl");

                    knownImages.Add("Veranda Min", @".\Images\fVERANDA_1.bmp");
                    fileTemplates.Add("Veranda Min", new Dictionary<string, string>());
                    fileTemplates["Veranda Min"].Add("Veranda Min 4x5 (1)", @".\Templates\VERANDA_1_4x5(1).tpl");
                    */
                }

                // Init font selection
                string trainingName = "Bahnschrift Large";
                if (this.comboKnownImages == null)
                {
                    L.err(location, "Known images combobox was null.");
                    cntErrors++;
                }
                else
                {
                    foreach (KeyValuePair<string, string> kv in this.knownImages)
                    {
                        comboKnownImages.Items.Add(kv.Key);
                    }
                    // Event handler will load default image of font set here
                    L.l(location, "Selecting start font.");
                    int idxSelect = comboKnownImages.Items.IndexOf(trainingName);
                    if (idxSelect >= 0)
                    {
                        comboKnownImages.SelectedItem = comboKnownImages.Items[idxSelect];
                    }
                }

                if (this.comboReadImages == null)
                {
                    L.err(location, "Read images combobox was null.");
                    cntErrors++;
                }
                else 
                {
                    foreach (KeyValuePair<string, Dictionary<string, string>> kv in this.readImages)
                    {
                        if (kv.Value == null) continue;
                        foreach (KeyValuePair<string, string> kvImg in kv.Value)
                        {
                            comboReadImages.Items.Add(kvImg.Key);
                        }
                    }
                    int idxSelect = comboReadImages.Items.IndexOf(trainingName);
                    if (idxSelect >= 0)
                    {
                        comboReadImages.SelectedItem = comboReadImages.Items[idxSelect];
                    }
                }

                if (this.comboKnownTemplates == null)
                {
                    L.err(location, "Known templates combobox was null.");
                    cntErrors++;
                }
                else 
                {
                    foreach (KeyValuePair<string, Dictionary<string, string>> kv in this.fileTemplates)
                    {
                        if (kv.Value == null) continue;
                        foreach (KeyValuePair<string, string> kvTemplate in kv.Value)
                        {
                            comboKnownTemplates.Items.Add(kvTemplate.Key);
                        }
                    }
                }

                //tbRegionsTemplatePath.Text = @".\Templates\FontTemplate_CALIBRI_2.json";
                //tbReadTextImageFile.Text = @".\Images\Read_CALIBRI_2.bmp";

                // Force timing of all events at boot
                if (!this.timeAllEvents(true))
                {
                    L.err(location, "Failed to enable timing of all events at boot.");
                }

                retVal = comboKnownImages.Items.Count == this.knownImages.Count;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        /*
         * compareTextCounter - Reads two char arrays from specified indexes counting matches
         */
        public int compareTextCounter(char[] arr1, int idx1, char[] arr2, int idx2)
        {
            const string location = CLASSNAME + ".compareTextCounter";
            int retVal = -1;
            try
            {
                if (arr1 == null || arr2 == null)
                {
                    L.err(location, "One or more input arrays were null.");
                    return retVal;
                }

                if (idx1 < 0 || idx1 >= arr1.Length || idx2 < 0 || idx2 >= arr2.Length)
                {
                    L.err(location, "Index out of bounds idx1(" + idx1 + "), size1 (" + arr1.Length + 
                        "), idx2 (" + idx2 + "), size2(" + arr2.Length + ").");
                    return retVal;
                }

                int cntr = 0;
                for (int i1 = idx1, i2 = idx2; i1 < arr1.Length && i2 < arr2.Length; i1++, i2++)
                    if (arr1[i1] == arr2[i2]) cntr++;

                retVal = cntr;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool compareTextToKnown(string textIn)
        {
            const string location = CLASSNAME + ".compareTextToKnown";
            bool retVal = false;
            try
            {
                Elapsed elapsedCompare = null;
                if (Config.TmgCompareAgainstActual)
                    elapsedCompare = new Elapsed(location, "Compare Against Actual", true);

                if (textIn == null)
                {
                    L.err(location, "Input text was null.");
                    return retVal;
                }

                string knownIn =
                    "THISISARANDOMPARAGRAPHOFUPPERCASELETTERSEXCEPTFORTHELETTERBETWEEN" +
                    "PANDRALSONOPUNCTUATIONCOULDTRYNUMBERSZEROPROBABLYWONTWORKORMAYBEO" +
                    "WONTWORKINSTEADNOTMUCHHOPEFOR1ANDIEITHERJUSTAMAYBETHERENEEDTOBEMORE" +
                    "NUMBERSWELLPRETENDWEAREADDING123456789080235";

                char[] text = textIn.ToCharArray();
                char[] known = knownIn.ToCharArray();

                char[] matches = null;
                Dictionary<string, int>[] offsets = null;
                int status = fixOneIsland(text, known, ref matches, ref offsets);
                L.l(location, "Fix one island status (" + status + ").");




                /*
                char[] matchedArr = new char[known.Length >= text.Length ? known.Length : text.Length];
                for (int i = 0; i < matchedArr.Length; i++) matchedArr[i] = '*';


                // This can be messy. 
                // Output can be short, or have surplus characters, versus known.
                // There needs to be a quick count helper, to take two indexes and strings, 
                //   to count available remaining matches
                // Slide to an optimal position, count matches, isolate mismatches, then 
                //   slide mismatches within middle regions until all that can be solved have.
                //   We know they occur in same order only. 


                // Find the best starting indexes between the two lines
                int idxText = 0;
                int idxKnown = 0;

                int lengthMismatch = known.Length - text.Length;

                int highestCount = -1;
                if (lengthMismatch > 0)
                {
                    // Characters are missing from output, Text=0, find Known
                    int bestKnownIndex = -1;
                    for (int idx = 0; idx <= lengthMismatch; idx++)
                    {
                        int countMatched = compareTextCounter(text, 0, known, idx);
                        L.l(location, "Count matched (" + countMatched + "), known index (" + idx + ").");
                        if (countMatched > highestCount)
                        {
                            bestKnownIndex = idx;
                            highestCount = countMatched;
                        }
                    }

                    if (bestKnownIndex < 0)
                    {
                        L.err(location, "Failed to find best known index.");
                        return retVal;
                    }
                    idxKnown = bestKnownIndex;
                }
                else if (lengthMismatch < 0)
                {
                    // Surplus characters in output, Known=0, find Text
                    int limit = -1 * lengthMismatch;
                    int bestTextIndex = -1;
                    for (int idx = 0; idx <= limit; idx++)
                    {
                        int countMatched = compareTextCounter(known, 0, text, idx);
                        L.l(location, "Count matched (" + countMatched + "), text index (" + idx + ").");
                        if (countMatched > highestCount)
                        {
                            bestTextIndex = idx;
                            highestCount = countMatched;
                        }
                    }

                    if (bestTextIndex < 0)
                    {
                        L.err(location, "Failed to find best text index.");
                        return retVal;
                    }
                    idxText = bestTextIndex;
                }
                else 
                {
                    // Matched
                    // do nothing 0,0
                }
                L.l(location, "Found best starting indexes, known (" + idxKnown + "), text (" + idxText + 
                    "), count (" + highestCount + "), known length (" + known.Length + "), text length (" + text.Length + ").");

                string sFirstMatchRaw = "";
                for (int idxT = idxText, idxK = idxKnown, idxOut = 0; idxT < text.Length && idxK < known.Length; idxT++, idxK++, idxOut++)
                {
                    if (text[idxT] == known[idxK])
                    {
                        matchedArr[idxOut] = known[idxK];
                    }
                }

                L.l(location, "Matched String: " + matchedArr.ToString());

                string sMatched = new string(matchedArr);
                Ui.Append(rtbReadTextImage, "\n\nMatched Characters\n" + sMatched + "\n");

                Ui.Append(rtbReadTextImage, "\n\nOriginal Text\n" + knownIn + "\n");


                // Create a storage for found characters
                bool[] found = new bool[matchedArr.Length];


                // Each character will get three offsets:  text, known, and matched
                // Matched may have more than one of the others. Matched will contain
                // null for unknowns, through output.
                Dictionary<string, int>[] offsets = new Dictionary<string, int>[matchedArr.Length];

                // Find beginning and end of largest contiguous piece


                // Read the match string
                {
                    int idxCountStart = -1;
                    int longest = 0;
                    int cntCurrent = 0;
                    int idxBestStart = 0;
                    int idxBestEnd = 0;
                    for (int i = 0; i < matchedArr.Length; i++)
                    {
                        if (matchedArr[i] != '*')
                        {
                            if (idxCountStart < 0) idxCountStart = i;
                            cntCurrent++;
                        }
                        else
                        {
                            if (idxCountStart >= 0)
                            {
                                if (cntCurrent > longest)
                                {
                                    idxBestStart = idxCountStart;
                                    idxBestEnd = i - 1;
                                    longest = cntCurrent;
                                    idxCountStart = -1;
                                    cntCurrent = 0;
                                }
                            }
                        }
                    }
                    if (idxCountStart >= 0)
                    {
                        if (cntCurrent > longest)
                        {
                            idxBestStart = idxCountStart;
                            idxBestEnd = matchedArr.Length - 1;
                            longest = cntCurrent;
                        }
                    }



                    L.l(location, "Matches: longest (" + longest + "), idxStart (" + idxBestStart + "), idxEnd (" + idxBestEnd + ").");

                    //char[] temp = new char[longest];
                    for (int i = idxBestStart; i <= idxBestEnd && i < offsets.Length; i++)
                    {
                        offsets[i] = new Dictionary<string, int>();
                        offsets[i].Add("known", idxBestStart + idxKnown);
                        offsets[i].Add("text", idxBestStart + idxText);
                    }

                    int cntNotNull = 0;
                    for (int i = 0; i < offsets.Length; i++)
                    {
                        if (offsets[i] != null) cntNotNull++;
                    }
                    L.l(location, "Locked first (" + cntNotNull + ") character offsets, out of (" + (1 + idxBestEnd - idxBestStart) + ").");
                }

                // We have something, presumably somewhere in the middle, an island
                // On each side, is the end or an error
                // I'm thinking, look left, count all of it, then slide the first X right and count again.
                // Not sure if islands is a reasonable way to look at it.. 


                // I think this stuff comes out in helpers

                // Find an island and place it
                {
                    int holeStart = -1;
                    int holeEnd = -1;
                    if (!findLargestIsland(matchedArr, '*', out holeStart, out holeEnd))
                    {
                        L.err(location, "Failed to find largest hole.");
                    }
                    L.l(location, "Hole start (" + holeStart + "), end (" + holeEnd + ").");
                    if (holeStart < 0 || holeEnd < 0)
                    {
                        L.err(location, "Hole less than zero (" + holeStart + "-" + holeEnd + ")");
                        return retVal;
                    }
                    int holeSize = 1 + holeEnd - holeStart;

                    // We are using matches indexes, so subtract the appropriate modifier for smaller arrays
                    int idxK = holeStart - idxKnown;
                    int idxT = holeStart - idxText;
                    int idxM = holeStart;

                    char[] arrK = new char[holeSize];
                    char[] arrT = new char[holeSize];

                    StringBuilder sbK = new StringBuilder();
                    StringBuilder sbT = new StringBuilder();
                    for (int i = 0, iK = idxK; i < holeSize && iK < known.Length; i++, iK++)
                    {
                        arrK[i] = known[iK];
                        sbK.Append(known[iK]);
                    }
                    for (int i = 0, iT = idxT; i < holeSize && iT < text.Length; i++, iT++)
                    {
                        arrT[i] = text[iT];
                        sbT.Append(text[iT]);
                    }

                    L.l(location, "Island, Known: " + sbK.ToString());
                    L.l(location, "Island Text: " + sbT.ToString());
                }
                */




                if (elapsedCompare != null)
                {
                    elapsedCompare.end();
                    Ui.Append(lbTimingOutput, elapsedCompare.toString());
                }

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int fixOneIsland(char[] text, char[] known, ref char[] matches, ref Dictionary<string, int>[] offsets)
        {
            const string location = CLASSNAME + ".fixOneIsland";
            int retVal = -1;// -1 = Error, 0 = No Islands, 1 = Fixed Something 
            try
            {
                if (text == null || known == null)
                {
                    L.err(location, "One or more input arrays was null.");
                    return retVal;
                }
                bool isKnownLarger = known.Length > text.Length;
                int maxLength = isKnownLarger ? known.Length : text.Length;
                int indexModifier = isKnownLarger ? known.Length - text.Length : text.Length - known.Length;

                if (matches == null)
                {
                    // Auto create first time
                    matches = new char[maxLength];
                    for (int i = 0; i < maxLength; i++) matches[i] = cnull;
                    //L.err(location, "Input matches was null.");
                    //return retVal;
                }
                if (offsets == null)
                {
                    offsets = new Dictionary<string, int>[maxLength];
                }

                // Copy input into even-edged arrays, quit caring who is who
                char[] a = new char[maxLength];
                char[] b = new char[maxLength];
                for (int i = 0; i < maxLength; i++)
                {
                    a[i] = cnull;
                    b[i] = cnull;
                }

                // Write the longer array into a, b will slide around a for matches
                if (isKnownLarger)
                {
                    for (int i = 0; i < known.Length; i++) a[i] = known[i];
                    for (int i = 0; i < text.Length; i++) b[i] = text[i];
                }
                else 
                {
                    for (int i = 0; i < known.Length; i++) b[i] = known[i];
                    for (int i = 0; i < text.Length; i++) a[i] = text[i];
                }

                // Find largest island
                int start;
                int end;
                if (!findLargestIsland(matches, cnull, out start, out end))
                //if (!findLargestIsland(matches, cnull, out start, out end))
                {
                    L.l(location, "Failed to find a largest island.");
                    return retVal;// Error for now, but this should be a nominal end when its finished
                }
                L.l(location, "Fixing island (" + start + "-" + end + ").");








                /*char[] outputMatches = new char[matches.Length];
                for (int i = 0; i < outputMatches.Length; i++) outputMatches[i] = cnull;

                // Find largest island
                int start;
                int end;
                if (!findLargestIsland(matches, '*', out start, out end))
                {
                    L.l(location, "Failed to find a largest island.");
                    return retVal;// Error for now, but this should be a nominal end when its finished
                }

                // Fix first island
                L.l(location, "Fixing island (" + start + "-" + end + ").");*/


                // Fix only this island... there needs to be another copy of matches, that is only fixed 
                //   islands, that is the real output, everything that is not the island, is a potential error

                // Take everything left of the island

                // Find largest island

                // Fix largest island

                // When it goes right, there is no way to keep from working on floating islands
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool findLargestIsland(char[] data, char matchVal, out int start, out int end)
        {
            const string location = CLASSNAME + ".findLargestIsland";
            bool retVal = false;
            int idxBestStart = 0;
            int idxBestEnd = 0;
            try
            {
                int idxCountStart = -1;
                int longest = 0;
                int cntCurrent = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == matchVal)
                    {
                        if (idxCountStart < 0) idxCountStart = i;
                        cntCurrent++;
                    }
                    else
                    {
                        if (idxCountStart >= 0)
                        {
                            if (cntCurrent > longest)
                            {
                                idxBestStart = idxCountStart;
                                idxBestEnd = i - 1;
                                longest = cntCurrent;
                                idxCountStart = -1;
                                cntCurrent = 0;
                            }
                        }
                    }
                }
                if (idxCountStart >= 0)
                {
                    if (cntCurrent > longest)
                    {
                        idxBestStart = idxCountStart;
                        idxBestEnd = data.Length - 1;
                        longest = cntCurrent;
                    }
                }
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            start = idxBestStart;
            end = idxBestEnd;
            return retVal;
        }

        public bool getCharacters()
        {
            const string location = CLASSNAME + ".getCharacters";
            bool retVal = false;
            try
            {
                Elapsed elapsedFindCharacters = null;
                if (Config.TmgFindTrainingCharacters)
                    elapsedFindCharacters = new Elapsed(location, "Find Training Characters", true);

                L.l(location, "Getting characters.");
                if (this.bits == null)
                {
                    L.err(location, "Image data not loaded.");
                    return retVal;
                }

                if (this.bits.textRows == null)
                {
                    L.err(location, "Text was null when getting characters.");
                    return retVal;
                }
                L.l(location, "Finding characters in (" + this.bits.textRows.Count + ") text rows.");

                this.bits.characters = null;
                this.bits.characters = new Region(this.bits.Width, this.bits.Height, new Pt(0, 0));

                List<Control> pbs = new List<Control>();
                for (int i = 0; i < this.bits.textRows.Count; i++)
                {
                    // Create storage everytime
                    this.bits.characters.regions.Add(new List<Region>());

                    if (this.bits.textRows[i] == null)
                    {
                        L.err(location, "Skipping invalid region at index (" + i + ").");
                        continue;
                    }
                    this.bits.characters.regions[i] = this.bits.columnsFromRegion(this.bits.textRows[i]);
                    L.l(location, "Found (" + this.bits.characters.regions[i].Count + ") characters in line (" + i + ").");

                    // Pause timer for UI updates
                    if (elapsedFindCharacters != null) elapsedFindCharacters.end();

                    for (int j = 0; j < this.bits.characters.regions[i].Count; j++)
                    {
                        if (this.bits.characters.regions[i][j] == null)
                        {
                            L.err(location, "Skipping null character at row (" + i + ") index (" + j + ").");
                            continue;
                        }
                        Bitmap bmp = this.bits.toBitmap(this.bits.characters.regions[i][j]);
                        if (bmp == null)
                        {
                            L.err(location, "Skipping null character bmp at row (" + i + ") index (" + j + ").");
                            continue;
                        }
                        PictureBox pb = new PictureBox();
                        pb.Width = bmp.Width;
                        pb.Height = bmp.Height;
                        pb.Margin = new Padding(5);
                        pb.Image = bmp;
                        pbs.Add(pb);
                    }

                    // Restart timer after UI updates
                    if (elapsedFindCharacters != null) elapsedFindCharacters.start();
                }
                if (elapsedFindCharacters != null)
                {
                    elapsedFindCharacters.end();
                    Ui.Append(lbTimingOutput, elapsedFindCharacters.toUiString());
                    //L.l(location, "Elapsed Find Characters: " + elapsedFindCharacters.toUiString());
                }

                Control[] pbsOut = pbs.ToArray();
                if (!Ui.Append(flowCharacters, pbsOut))
                {
                    L.err(location, "Failed to update ui with character crops.");
                }
                else 
                {
                    // Flag success for posting to ui
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
 
        public bool getCharacterRegionCounts()
        {
            const string location = CLASSNAME + ".getCharacterRegionCounts";
            bool retVal = false;
            try
            {
                if (this.bits == null || this.bits.characters == null || 
                    this.bits.characters.regions == null || this.bits.characters.regions.Count == 0)
                {
                    L.err(location, "Data not initialized fully.");
                    return retVal;
                }

                // Push result to UI
                retVal = this.showRegionsCounts();
                if (!retVal)
                {
                    L.err(location, "Failed to publish regions counts.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool getRows()
        {
            const string location = CLASSNAME + ".getRows";
            bool retVal = false;
            try
            {
                Elapsed elapsedFindLines = null;
                if (Config.TmgFindTrainingLines) elapsedFindLines = new Elapsed(location, "Find Training Lines", true);

                if (this.bits == null)
                {
                    L.err(location, "Image data not loaded.");
                    return retVal;
                }
                if (!this.bits.linesFromBits())
                {
                    L.err(location, "Failed to identify text rows.");
                    return retVal;
                }
                if (elapsedFindLines != null)
                {
                    elapsedFindLines.end();
                    string elapsedForUi = elapsedFindLines.toUiString();
                    if (!Ui.Append(lbTimingOutput, elapsedForUi))
                    {
                        L.err(location, "Failed to show timing for (" + elapsedFindLines.processName + ").");
                    }
                }

                Control[] pbs = new Control[this.bits.textRows.Count];
                for (int i = 0; i < this.bits.textRows.Count; i++)
                {
                    Bitmap bmp = this.bits.toBitmap(this.bits.textRows[i]);
                    if (bmp == null)
                    {
                        L.err(location, "Row (" + i + ") image was null.");
                        pbs[i] = null;
                        continue;
                    }
                    PictureBox pb = new PictureBox();
                    pb.Width = bmp.Width;
                    pb.Height = bmp.Height;
                    pb.Margin = new Padding(5);
                    pb.Image = bmp;
                    pbs[i] = pb;
                }

                // Post to UI
                if (flowRowImages.InvokeRequired)
                {
                    flowRowImages.Invoke(new Action(() => { retVal = this.getRows(); }));
                }
                else 
                {
                    flowRowImages.Controls.AddRange(pbs);
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool loadCharacterTemplates(string fullPath)
        {
            const string location = CLASSNAME + ".loadCharacterTemplates";
            bool retVal = false;
            try
            {
                Elapsed elapsedLoadTemplate = null;
                if (Config.TmgLoadTemplate)
                    elapsedLoadTemplate = new Elapsed(location, "Load Template", true);

                // TODO - MessageBox path and file errors
                if (fullPath == null || fullPath.Length == 0)
                {
                    L.err(location, "Input save path was null or empty.");
                    return retVal;
                }
                if (!File.Exists(@fullPath))
                {
                    L.err(location, "Input file does not exist: " + fullPath + ".");
                    return retVal;
                }


                string text = File.ReadAllText(@fullPath);
                if (text == null)
                {
                    L.err(location, "Content of file was null or empty.");
                    return retVal;
                }
                text = text.Trim();
                if (text.Length == 0 || !text.StartsWith("{") || !text.EndsWith("}"))
                {
                    L.err(location, "Content of file was empty or not JObject format.");
                    return retVal;
                }
                L.l(location, "Parsing (" + text.Length + ") file-length.");

                JObject jobj = null;
                try
                {
                    jobj = JObject.Parse(text);
                }
                catch (Exception exConv) { }
                
                if (jobj == null)
                {
                    L.err(location, "Failed to convert file contents to JObject.");
                    return retVal;
                }

                this.templatesFromFile = jobj;
                L.l(location, "Loaded (" + this.templatesFromFile.Count + ") character templates.");

                // Reconstruct an empty bits object, holding only characters
                this.template = new Dictionary<string, Region>();

                Bits temp = new Bits();
                temp.characters = new Region();
                temp.characters.regions = new List<List<Region>>();

                string missingKeys = "";
                for (int i = 0; i < supportedTemplates.Length; i++)
                {
                    Region region = new Region();
                    if (this.templatesFromFile.ContainsKey(supportedTemplates[i]))
                    {
                        JObject obj = (JObject)this.templatesFromFile[supportedTemplates[i]];
                        if (obj == null)
                        {
                            L.err(location, "Failed to retrieve JObject for character (" + supportedTemplates[i] + ").");

                            // TODO - enforce error
                            //return retVal;
                        }
                        if (!region.fromJObject(obj))
                        {
                            L.err(location, "Failed to build Region from storage character (" + supportedTemplates[i] + ").");

                            // TODO - enforce error
                            //return retVal;
                        }
                    }
                    else missingKeys += (missingKeys.Length > 0 ? ", " : "") + supportedTemplates[i];

                    this.template.Add(supportedTemplates[i], region);
                }
                if (missingKeys.Length > 0)
                {
                    L.err(location, "Missing Keys (" + missingKeys + ").");
                    // For now, this should be a hard error. Problem being unkeyed memory storage

                    // TODO - enforce error
                    //return retVal;
                }

                if (elapsedLoadTemplate != null)
                {
                    elapsedLoadTemplate.end();
                    Ui.Append(lbTimingOutput, elapsedLoadTemplate.toUiString());
                }

                // Validate we 'tried' to get everything, and shimmed with empty
                retVal = this.template.Count == this.supportedTemplates.Length;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool loadImage()
        {
            const string location = CLASSNAME + ".loadImage";
            bool retVal = false;
            try
            {
                Elapsed elapsedImgLoad = null;
                if (Config.TmgLoadTrainingImage) elapsedImgLoad = new Elapsed(location, "Load Training Image", true);


                // TODO - add file open
                if (tbFileIn == null || tbFileIn.Text.Length == 0)
                {
                    L.err(location, "Input path was null or empty.");
                    return retVal;
                }

                // Clear UI
                if (!uiReset())
                {
                    L.err(location, "Failed to clear old data from UI.");
                    // TODO - Not a halting error right now
                }

                // Retrieve bitmap or fail
                if (!File.Exists(tbFileIn.Text))
                {
                    L.err(location, "Image file does not exist: " + tbFileIn.Text + ".");
                    return retVal;
                }
                Bitmap bmp = (Bitmap)Bitmap.FromFile(tbFileIn.Text);
                if (bmp == null || bmp.Width == 0 || bmp.Height == 0)
                {
                    L.err(location, "Input image was null or empty.");
                    return retVal;
                }
                L.l(location, "Image size from file (" + bmp.Width + "w x " + bmp.Height + "h).");

                pbImageIn.Image = bmp;

                int threshhold = 128;
                if (numRgbThresh != null)
                {
                    threshhold = (int)numRgbThresh.Value;
                }

                // Finish by thresholding
                retVal = thresholdImage((Bitmap)bmp, threshhold);

                if (elapsedImgLoad != null)
                {
                    elapsedImgLoad.end();
                    string timingOut = elapsedImgLoad.toUiString();
                    if (!Ui.Append(lbTimingOutput, timingOut))
                    {
                        L.err(location, "Failed to push timing for (" + elapsedImgLoad.processName + ").");
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // TODO - Decide if this belongs in bits
        public bool loadCharacterSubRegions(ref Bits bits)
        {
            const string location = CLASSNAME + ".loadCharacterSubRegions";
            bool retVal = false;
            try
            {
                Elapsed elapsedCountText = null;
                if (Config.TmgCountTextImageCharacters)
                    elapsedCountText = new Elapsed(location, "Count Text Image Characters", true);

                // Iterate characters
                L.l(location, "Iterating regions.");
                for (int cY = 0; cY < bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < bits.characters.regions[cY].Count; cX++)
                    {
                        // Get sub-regions for character
                        Region subRegions = new Region(
                            bits.Width,
                            bits.Height,
                            bits.characters.regions[cY][cX].Start
                        );

                        // TODO - Debug log
                        if (Config.DebugRegionSize)
                        {
                            L.l(location, "Region X (" + cX + "), Y (" + cY + "), Start (" +
                                bits.characters.regions[cY][cX].Start.toString() +
                                "), width (" + (bits.characters.regions[cY][cX].End.x - bits.characters.regions[cY][cX].Start.x) +
                                "), height (" + (bits.characters.regions[cY][cX].End.y - bits.characters.regions[cY][cX].Start.y) + ").");
                        }
                        if (!subRegions.fromPercentages(
                            this.xBreaks,
                            this.yBreaks,
                            bits.characters.regions[cY][cX].End.x - bits.characters.regions[cY][cX].Start.x,
                            bits.characters.regions[cY][cX].End.y - bits.characters.regions[cY][cX].Start.y
                        ))
                        {
                            L.l(location, "Skipping char at (" + cX + ", " + cY + "), failed to get sub-regions.");
                            continue;
                        }

                        /*// DEBUG
                        if (!subRegions.logRegions())
                        {
                            L.err(location, "Failed to log regions.");
                            // Try anyway
                        }*/

                        // TODO - if we are not getting counts, check the subRegions reference

                        // Count character sub-regions
                        List<List<int>> countSet = bits.countRegions(subRegions, true);
                        if (countSet.Count == 0)
                        {
                            L.l(location, "Skipping empty character with (" + countSet.Count + ") set.");
                            continue;
                        }


                        // TODO - What is countSet doing? its not saved. does subregions have it?


                        // Save subregions to class-level data
                        bits.characters.regions[cY][cX].regions = subRegions.regions;
                    }
                }

                if (elapsedCountText != null)
                {
                    elapsedCountText.end();
                    Ui.Append(lbTimingOutput, elapsedCountText.toString());
                }

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public Bits loadCharacters(Bitmap bmp)
        {
            const string location = CLASSNAME + ".loadCharacters(bmp)";
            Bits retVal = null;
            try
            {

                // Get a bits of the image since we don't have one
                Bits bits = new Bits();
                if (!bits.fromBitmap(bmp, 128))
                {
                    L.err(location, "Failed to threshold image.");
                    return retVal;
                }
                if (bits == null || bits.ba == null || bits.ba.Length != (bits.Width * bits.Height))
                {
                    L.err(location, "Bits not initialized or size mismatch.");
                    return retVal;
                }
                L.l(location, "Imported image size (" + bits.Width + "w, " + bits.Height + "h).");

                // Get text rows from bits
                Elapsed elapsedFindRows = null;
                if (Config.TmgFindTextImageLines)
                    elapsedFindRows = new Elapsed(location, "Find Text Image Lines", true);

                if (!bits.linesFromBits() || bits.textRows == null)
                {
                    L.err(location, "Failed to identify text rows.");
                    return retVal;
                }

                if (elapsedFindRows != null)
                {
                    elapsedFindRows.end();
                    Ui.Append(lbTimingOutput, elapsedFindRows.toString());
                }
                L.l(location, "Read (" + bits.textRows.Count + ") text rows from input image.");

                // Get characters from text rows
                Elapsed elapsedFindCharacters = null;
                if (Config.TmgFindTextImageCharacters)
                    elapsedFindCharacters = new Elapsed(location, "Find Text Image Characters", true);

                bits.characters = new Region(bits.Width, bits.Height, new Pt(0, 0));
                for (int i = 0; i < bits.textRows.Count; i++)
                {
                    // Create storage everytime
                    bits.characters.regions.Add(new List<Region>());

                    if (bits.textRows[i] == null)
                    {
                        L.err(location, "Skipping invalid region at index (" + i + ").");
                        continue;
                    }
                    bits.characters.regions[i] = bits.columnsFromRegion(bits.textRows[i]);
                    L.l(location, "Found (" + bits.characters.regions[i].Count + ") characters in line (" + i + ").");
                }

                if (elapsedFindCharacters != null)
                {
                    elapsedFindCharacters.end();
                    Ui.Append(lbTimingOutput, elapsedFindCharacters.toString());
                }

                // Output Result
                retVal = bits;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool loadTextImage()
        {
            const string location = CLASSNAME + ".loadTextImage";
            bool retVal = false;
            try
            {
                L.l(location, "Loading text image.");

                Elapsed elapsedLoadText = null;
                if (Config.TmgLoadTextImage) elapsedLoadText = new Elapsed(location, "Load Text Image", true);

                pbReadTextImage.Image = null;

                string fullPath = "";
                if (tbReadTextImageFile != null)
                {
                    fullPath = tbReadTextImageFile.Text;
                }

                if (fullPath == null || fullPath.Length == 0)
                {
                    L.err(location, "Input path was null or empty.");
                    return retVal;
                }

                if (!File.Exists(@fullPath))
                {
                    L.err(location, "File does not exist at read, path (" + fullPath + ").");
                    return retVal;
                }

                Bitmap bmp = (Bitmap)Bitmap.FromFile(@fullPath);
                if (bmp == null || bmp.Width == 0 || bmp.Height == 0)
                {
                    L.err(location, "Bitmap from file was null or zero size.");
                }

                // Leave UI out of timing
                if (elapsedLoadText != null)
                {
                    elapsedLoadText.end();
                    Ui.Append(lbTimingOutput, elapsedLoadText.toString());
                }

                if (pbReadTextImage != null)
                {
                    pbReadTextImage.Image = bmp;
                    retVal = true;// TODO - Move result lower
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool readTextImage()
        {
            const string location = CLASSNAME + ".readTextImage";
            bool retVal = false;
            try
            {
                L.l(location, "Reading text image.");

                Elapsed elapsedReadText = null;
                if (Config.TmgReadText) elapsedReadText = new Elapsed(location, "Read Text", true);

                // Get bitmap from UI
                Bitmap bmp = null;
                if (pbReadTextImage.Image != null)
                {
                    bmp = (Bitmap)pbReadTextImage.Image;
                }
                if (bmp == null)
                {
                    L.err(location, "Text image not initialized at read.");
                    return retVal;
                }

                Bits bits = this.loadCharacters(bmp);
                if (bits == null)
                {
                    L.err(location, "Failed to read bitmap image.");
                    return retVal;
                }

                /*// Get a bits of the image since we don't have one
                Bits bits = new Bits();
                if (!bits.fromBitmap(bmp, 128))
                {
                    L.err(location, "Failed to threshold image.");
                    return retVal;
                }
                if (bits == null || bits.ba == null || bits.ba.Length != (bits.Width * bits.Height))
                {
                    L.err(location, "Bits not initialized or size mismatch.");
                    return retVal;
                }
                L.l(location, "Imported image size (" + bits.Width + "w, " + bits.Height + "h).");

                // Get text rows from bits
                if (!bits.linesFromBits() || bits.textRows == null)
                {
                    L.err(location, "Failed to identify text rows.");
                    return retVal;
                }
                L.l(location, "Read (" + bits.textRows.Count + ") text rows from input image.");

                // Get characters from text rows
                bits.characters = new Regions(bits.Width, bits.Height, new Pt() { x = 0, y = 0 });
                for (int i = 0; i < bits.textRows.Count; i++)
                {
                    // Create storage everytime
                    bits.characters.regions.Add(new List<Region>());

                    if (bits.textRows[i] == null)
                    {
                        L.err(location, "Skipping invalid region at index (" + i + ").");
                        continue;
                    }
                    bits.characters.regions[i] = bits.columnsFromRegion(bits.textRows[i]);
                    L.l(location, "Found (" + bits.characters.regions[i].Count + ") characters in line (" + i + ").");
                }*/

                // Get character subregions and subregion counts
                if (!this.loadCharacterSubRegions(ref bits))
                {
                    L.err(location, "Failed to load character subregions.");
                    return retVal;
                }

                /*// Count character subregions
                // Iterate characters
                L.l(location, "Iterating regions.");
                for (int cY = 0; cY < bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < bits.characters.regions[cY].Count; cX++)
                    {
                        // Get sub-regions for character
                        Regions subRegions = new Regions(
                            bits.Width,
                            bits.Height,
                            bits.characters.regions[cY][cX].Start
                        );

                        // TODO - Debug log
                        L.l(location, "Region X (" + cX + "), Y (" + cY + "), Start (" +
                            bits.characters.regions[cY][cX].Start.toString() +
                            "), width (" + (bits.characters.regions[cY][cX].End.x - bits.characters.regions[cY][cX].Start.x) +
                            "), height (" + (bits.characters.regions[cY][cX].End.y - bits.characters.regions[cY][cX].Start.y) + ").");

                        if (!subRegions.fromPercentages(
                            this.xBreaks,
                            this.yBreaks,
                            bits.characters.regions[cY][cX].End.x - bits.characters.regions[cY][cX].Start.x,
                            bits.characters.regions[cY][cX].End.y - bits.characters.regions[cY][cX].Start.y
                        ))
                        {
                            L.l(location, "Skipping char at (" + cX + ", " + cY + "), failed to get sub-regions.");
                            continue;
                        }

                        // DEBUG
                        //if (!subRegions.logRegions())
                        //{
                            //L.err(location, "Failed to log regions.");
                            // Try anyway
                        //}

                        // TODO - if we are not getting counts, check the subRegions reference

                        // Count character sub-regions
                        List<List<int>> countSet = bits.countRegions(subRegions, true);
                        if (countSet.Count == 0)
                        {
                            L.l(location, "Skipping empty character with (" + countSet.Count + ") set.");
                            continue;
                        }


                        // TODO - What is countSet doing? its not saved. does subregions have it?


                        // Save subregions to class-level data
                        bits.characters.regions[cY][cX].subregions = subRegions;
                    }
                }*/

                // Iterate characters again, but get the region diffs between all templates
                Elapsed elapsedFindClosest = null;
                if (Config.TmgFindClosestTemplate)
                    elapsedFindClosest = new Elapsed(location, "Find Closest Template", true);

                StringBuilder sbText = new StringBuilder();
                for (int idxY = 0; idxY < bits.characters.regions.Count; idxY++)
                {
                    for (int idxX = 0; idxX < bits.characters.regions[idxY].Count; idxX++)
                    {
                        // If a region does not exist, the other region is the diff
                        Region regionA = bits.characters.regions[idxY][idxX];
                        Region regionB = null;
                        Region regionC = null;// A+B=C

                        List<Region> diffs = new List<Region>();

                        if (regionA == null)
                        {
                            L.err(location, "Character at Y (" + idxY + "), X (" + idxX + ") was null. Using empty.");
                        }

                        for (int idxT = 0; idxT < this.supportedTemplates.Length; idxT++)
                        {
                            Region diff = new Region();
                            diff.regions = new List<List<Region>>();
                            //List<Regions> list = new List<Regions>();
                            //diff.regions.Add(new List<Region>());// templates is 1D
                            // 
                            if (this.template.ContainsKey(this.supportedTemplates[idxT]))
                            {
                                regionB = this.template[this.supportedTemplates[idxT]];

                                // If a region does not exist, the other region is the diff
                                if (regionA == null)
                                {
                                    if (regionB != null)
                                    {
                                        diff = regionB;
                                    }
                                }
                                else if (regionB == null)
                                {
                                    if (regionA != null)
                                    {
                                        diff = regionA;
                                    }
                                }
                                // Final check before diffing
                                else if (regionC == null || regionC.counts == null)
                                {
                                    Region absdiff = regionA.AbsDiff(regionB);
                                    if (absdiff == null)
                                    {
                                        diff = new Region();
                                    }
                                    else diff = absdiff;
                                }
                            }
                            diffs.Add(diff);
                        }

                        // Iterate diffs, looking for the lowest total diff, which means summing first
                        // Get sums of diffs per-template
                        Counts[] sumOfDiffs = new Counts[diffs.Count];
                        int cntSummed = 0;
                        for (int i = 0; i < diffs.Count; i++)
                        {
                            Counts temp = diffs[i].SumCounts();
                            if (temp == null) temp = new Counts(9999);
                            else cntSummed++;
                            sumOfDiffs[i] = temp;

                            //if (idxY == 0) L.l(location, "sumOfDiff (" + idxX + "): " + temp.ttlSet + ".");
                        }

                        //L.l(location, "Identified (" + cntSummed + ") sums of diffs from (" +
                            //this.supportedTemplates.Length + ") characters.");

                        // Choose the lowest overall sum of differences.
                        int idxLowestSum = -1;
                        //int lowestSumValue = -1;
                        double lowestSumValue = -1d;
                        for (int i = 0; i < sumOfDiffs.Length; i++)
                        {
                            if (lowestSumValue < 0)
                            {
                                lowestSumValue = sumOfDiffs[i].ttlSet;
                                //lowestSumValue = sumOfDiffs[i].perTtlSet;
                                idxLowestSum = i;
                                continue;
                            }
                            if (sumOfDiffs[i].ttlSet >= 0 && sumOfDiffs[i].ttlSet < lowestSumValue)
                            {
                                lowestSumValue = sumOfDiffs[i].ttlSet;
                                //lowestSumValue = sumOfDiffs[i].perTtlSet;
                                idxLowestSum = i;
                                continue;
                            }
                        }
                        string character = (supportedTemplates.Length > idxLowestSum && idxLowestSum >= 0 ?
                            supportedTemplates[idxLowestSum] : " [index out of range] ");

                        if (elapsedFindClosest != null) elapsedFindClosest.end();
                        L.l(location, "Lowest sum difference, index (" + idxLowestSum + "), diff (" + lowestSumValue +
                            "), closest character (" + character + ").");

                        sbText.Append(character);
                        if (!this.updateRtbReadText(character))
                        {
                            // TODO - Remove error as could be many
                            L.err(location, "Failed to publish character to read text.");
                        }
                        if (elapsedFindClosest != null) elapsedFindClosest.start();

                    }
                }
                if (elapsedFindClosest != null)
                {
                    elapsedFindClosest.end();
                    Ui.Append(lbTimingOutput, elapsedFindClosest.toString());
                }

                if (elapsedReadText != null)
                {
                    elapsedReadText.end();
                    Ui.Append(lbTimingOutput, elapsedReadText.toString());
                }



                // TODO - Return to building compare to known
                /*// Compare text against known
                if (!compareTextToKnown(sbText.ToString()))
                {
                    L.err(location, "Failed to compare text to known.");
                    return retVal;
                }*/


                // Output Result
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool saveCharactersAsTemplates(string fullPath)
        {
            const string location = CLASSNAME + ".saveCharactersAsTemplates";
            bool retVal = false;
            try
            {
                Elapsed elapsedSaveTemplate = null;
                if (Config.TmgSaveTemplate) elapsedSaveTemplate = new Elapsed(location, "Save Template", true);

                if (this.bits == null || this.bits.characters == null)
                {
                    L.err(location, "Image or characters not initialized at save.");
                    return retVal;
                }
                if (fullPath == null || fullPath.Length == 0)
                {
                    L.err(location, "Input save path was null or empty.");
                    return retVal;
                }

                bool savePretty = false;//1-line per property plus formatting lines
                if (cbSaveTemplatePretty != null)
                {
                    savePretty = true == cbSaveTemplatePretty.Checked;
                }

                JObject outValue = new JObject();

                for (int idxY = 1; idxY < this.bits.characters.regions.Count; idxY++)
                {
                    List<Region> list = this.bits.characters.regions[idxY];
                    if (list == null)
                    {
                        L.err(location, "Text row (" + idxY + ") was null.");
                        continue;
                    }

                    for (int idxX = 0; idxX < list.Count; idxX++)
                    {
                        JObject jregion = list[idxX].toJObject();
                        if (jregion == null)
                        {
                            L.err(location, "Failed to convert region to JObject.");
                            jregion = new JObject();
                        }
                        string textCharacter = "";
                        switch (idxY)
                        {
                            case 1:
                                {
                                    switch (idxX)
                                    {
                                        case 0:
                                            {
                                                textCharacter = "A";
                                            }
                                            break;
                                        case 1:
                                            {
                                                textCharacter = "B";
                                            }
                                            break;
                                        case 2:
                                            {
                                                textCharacter = "C";
                                            }
                                            break;
                                        case 3:
                                            {
                                                textCharacter = "D";
                                            }
                                            break;
                                        case 4:
                                            {
                                                textCharacter = "E";
                                            }
                                            break;
                                        case 5:
                                            {
                                                textCharacter = "F";
                                            }
                                            break;
                                        case 6:
                                            {
                                                textCharacter = "G";
                                            }
                                            break;
                                        case 7:
                                            {
                                                textCharacter = "H";
                                            }
                                            break;
                                        case 8:
                                            {
                                                textCharacter = "I";
                                            }
                                            break;
                                        case 9:
                                            {
                                                textCharacter = "J";
                                            }
                                            break;
                                        case 10:
                                            {
                                                textCharacter = "K";
                                            }
                                            break;
                                        case 11:
                                            {
                                                textCharacter = "L";
                                            }
                                            break;
                                        case 12:
                                            {
                                                textCharacter = "M";
                                            }
                                            break;
                                        case 13:
                                            {
                                                textCharacter = "N";
                                            }
                                            break;
                                        case 14:
                                            {
                                                textCharacter = "O";
                                            }
                                            break;
                                        case 15:
                                            {
                                                textCharacter = "P";
                                            }
                                            break;
                                        case 16:
                                            {
                                                textCharacter = "Q";
                                            }
                                            break;
                                        case 17:
                                            {
                                                textCharacter = "R";
                                            }
                                            break;
                                        case 18:
                                            {
                                                textCharacter = "S";
                                            }
                                            break;
                                        case 19:
                                            {
                                                textCharacter = "T";
                                            }
                                            break;
                                        case 20:
                                            {
                                                textCharacter = "U";
                                            }
                                            break;
                                        case 21:
                                            {
                                                textCharacter = "V";
                                            }
                                            break;
                                        case 22:
                                            {
                                                textCharacter = "W";
                                            }
                                            break;
                                        case 23:
                                            {
                                                textCharacter = "X";
                                            }
                                            break;
                                        case 24:
                                            {
                                                textCharacter = "Y";
                                            }
                                            break;
                                        case 25:
                                            {
                                                textCharacter = "Z";
                                            }
                                            break;
                                        default:
                                            L.err(location, "Unknown character idx (" + idxY + ", " + idxX + "), skipping in output.");
                                            continue;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    switch (idxX)
                                    {
                                        case 0:
                                            {
                                                textCharacter = "a";
                                            }
                                            break;
                                        case 1:
                                            {
                                                textCharacter = "b";
                                            }
                                            break;
                                        case 2:
                                            {
                                                textCharacter = "c";
                                            }
                                            break;
                                        case 3:
                                            {
                                                textCharacter = "d";
                                            }
                                            break;
                                        case 4:
                                            {
                                                textCharacter = "e";
                                            }
                                            break;
                                        case 5:
                                            {
                                                textCharacter = "f";
                                            }
                                            break;
                                        case 6:
                                            {
                                                textCharacter = "g";
                                            }
                                            break;
                                        case 7:
                                            {
                                                textCharacter = "h";
                                            }
                                            break;
                                        case 8:
                                            {
                                                textCharacter = "i";
                                            }
                                            break;
                                        case 9:
                                            {
                                                textCharacter = "j";
                                            }
                                            break;
                                        case 10:
                                            {
                                                textCharacter = "k";
                                            }
                                            break;
                                        case 11:
                                            {
                                                textCharacter = "l";
                                            }
                                            break;
                                        case 12:
                                            {
                                                textCharacter = "m";
                                            }
                                            break;
                                        case 13:
                                            {
                                                textCharacter = "n";
                                            }
                                            break;
                                        case 14:
                                            {
                                                textCharacter = "o";
                                            }
                                            break;
                                        case 15:
                                            {
                                                textCharacter = "p";
                                            }
                                            break;
                                        case 16:
                                            {
                                                textCharacter = "q";
                                            }
                                            break;
                                        case 17:
                                            {
                                                textCharacter = "r";
                                            }
                                            break;
                                        case 18:
                                            {
                                                textCharacter = "s";
                                            }
                                            break;
                                        case 19:
                                            {
                                                textCharacter = "t";
                                            }
                                            break;
                                        case 20:
                                            {
                                                textCharacter = "u";
                                            }
                                            break;
                                        case 21:
                                            {
                                                textCharacter = "v";
                                            }
                                            break;
                                        case 22:
                                            {
                                                textCharacter = "w";
                                            }
                                            break;
                                        case 23:
                                            {
                                                textCharacter = "x";
                                            }
                                            break;
                                        case 24:
                                            {
                                                textCharacter = "y";
                                            }
                                            break;
                                        case 25:
                                            {
                                                textCharacter = "z";
                                            }
                                            break;
                                        default:
                                            L.err(location, "Unknown character idx (" + idxY + ", " + idxX + "), skipping in output.");
                                            continue;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    switch (idxX)
                                    {
                                        case 0:
                                            {
                                                textCharacter = "0";
                                            }
                                            break;
                                        case 1:
                                            {
                                                textCharacter = "1";
                                            }
                                            break;
                                        case 2:
                                            {
                                                textCharacter = "2";
                                            }
                                            break;
                                        case 3:
                                            {
                                                textCharacter = "3";
                                            }
                                            break;
                                        case 4:
                                            {
                                                textCharacter = "4";
                                            }
                                            break;
                                        case 5:
                                            {
                                                textCharacter = "5";
                                            }
                                            break;
                                        case 6:
                                            {
                                                textCharacter = "6";
                                            }
                                            break;
                                        case 7:
                                            {
                                                textCharacter = "7";
                                            }
                                            break;
                                        case 8:
                                            {
                                                textCharacter = "8";
                                            }
                                            break;
                                        case 9:
                                            {
                                                textCharacter = "9";
                                            }
                                            break;
                                        default:
                                            L.err(location, "Unknown character idx (" + idxY + ", " + idxX + "), skipping in output.");
                                            continue;
                                    }
                                }
                                break;
                        }
                        outValue.Add(textCharacter, jregion);
                    }
                }

                // TODO - Perform a count validation



                // Save to file
                if (savePretty)
                {
                    File.WriteAllText(@fullPath, outValue.ToString());
                }
                else
                {
                    File.WriteAllText(@fullPath, outValue.ToString(Newtonsoft.Json.Formatting.None));
                }

                // Load template has its own timing
                if (elapsedSaveTemplate != null)
                {
                    elapsedSaveTemplate.end();
                    Ui.Append(lbTimingOutput, elapsedSaveTemplate.toUiString());
                }

                // TODO - Perform a read-in before updating class variables
                // Update class level templates to reflect what is being saved
                this.templatesFromFile = outValue;
                if (!this.loadCharacterTemplates(@fullPath))
                {
                    L.err(location, "Failed to load new template into memory.");
                }
                else
                {
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool selectImage()
        {
            const string location = CLASSNAME + ".selectImage";
            bool retVal = false;
            try
            {
                if (comboKnownImages == null)
                {
                    L.err(location, "Known images combobox was null.");
                    return retVal;
                }
                string selected = comboKnownImages.Text;
                if (selected == null || selected.Length == 0)
                {
                    L.err(location, "Selection was null or empty.");
                    return retVal;
                }

                string path = "";
                if (this.knownImages.ContainsKey(selected))
                {
                    path = this.knownImages[selected];
                }
                if (path == null || path.Length == 0)
                {
                    L.err(location, "Image path was null or empty.");
                    return retVal;
                }

                if (tbFileIn != null)
                {
                    // Set path to UI, and call load image
                    tbFileIn.Text = path;
                    retVal = loadImage();
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool selectReadImage()
        {
            const string location = CLASSNAME + ".selectReadImage";
            bool retVal = false;
            try
            {
                if (comboReadImages == null)
                {
                    L.err(location, "Read images combobox was null.");
                    return retVal;
                }
                string selected = comboReadImages.Text;
                if (selected == null || selected.Length == 0)
                {
                    L.err(location, "Selection was null or empty.");
                    return retVal;
                }

                string path = "";
                foreach (KeyValuePair<string, Dictionary<string, string>> kv in this.readImages)
                {
                    foreach(KeyValuePair<string, string> kvImg in kv.Value)
                    {
                        if (selected == kv.Key)
                        {
                            path = kvImg.Value;
                            break;
                        }
                    }
                    if (path.Length > 0) break;
                }

                if (path == null || path.Length == 0)
                {
                    L.err(location, "Image path was null or empty.");
                    return retVal;
                }

                if (tbReadTextImageFile != null)
                {
                    // Set path to UI, nothing else
                    tbReadTextImageFile.Text = path;
                    retVal = path == tbReadTextImageFile.Text;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool selectKnownTemplate()
        {
            const string location = CLASSNAME + ".selectKnownTemplate";
            bool retVal = false;
            try
            {
                if (comboKnownTemplates == null)
                {
                    L.err(location, "Known templates combobox was null.");
                    return retVal;
                }
                string selected = comboKnownTemplates.Text;
                if (selected == null || selected.Length == 0)
                {
                    L.err(location, "Selection was null or empty.");
                    return retVal;
                }
                L.l(location, "Selecting template (" + selected + ").");

                string path = "";
                foreach (KeyValuePair<string, Dictionary<string, string>> kv in this.fileTemplates)
                {
                    foreach (KeyValuePair<string, string> kvTemplate in kv.Value)
                    {
                        if (selected == kvTemplate.Key)
                        {
                            path = kvTemplate.Value;
                            break;
                        }
                    }
                    if (path.Length > 0) break;
                }

                if (path == null || path.Length == 0)
                {
                    L.err(location, "Template path was null or empty.");
                    return retVal;
                }

                if (tbRegionsTemplatePath != null)
                {
                    // Set path to UI, nothing else
                    tbRegionsTemplatePath.Text = path;
                    retVal = path == tbRegionsTemplatePath.Text;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        /*
         * Divide the current region, according to xBreaks and yBreaks. Count sub-regions
         * on-the-fly, publish to UI tab.
         */
        public bool showRegionsCounts()
        {
            const string location = CLASSNAME + ".showRegionsCounts";
            bool retVal = false;
            try
            {
                L.l(location, "Showing region counts.");

                Elapsed elapsedCountCharacters = null;
                if (Config.TmgCountTrainingCharacters)
                    elapsedCountCharacters = new Elapsed(location, "Count Training Characters", true);

                if (this.bits == null || this.bits.characters == null || this.bits.characters.regions == null)
                {
                    L.err(location, "Character data not initialized at show regions.");
                    return retVal;
                }

                Ui.Clear(rtbRegionCounts);

                // Iterate characters
                //L.l(location, "Iterating regions.");
                string outputHeader = "";
                int textRowLength = 0;
                for (int cY = 0; cY < this.bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < this.bits.characters.regions[cY].Count; cX++)
                    {
                        // Count character as a whole first
                        Region regionCharacter = this.bits.characters.regions[cY][cX];
                        int cntCharacter = this.bits.countRegion(ref regionCharacter);
                        this.bits.characters.regions[cY][cX] = regionCharacter;

                        // TODO - Remove debug section
                        string sCharacter = " ";
                        int characterIndex = (cY * 26) + cX;
                        if (characterIndex >= 0 && characterIndex < supportedTemplates.Length)
                        {
                            L.l(location, "Character (" + supportedTemplates[characterIndex] +
                                "), cY (" + cY + "), cX (" + cX + 
                                "), Counts: " + this.bits.characters.regions[cY][cX].counts.toString());
                        }




                        // Get sub-regions for character
                        Region subRegions = new Region(
                            this.bits.Width,
                            this.bits.Height,
                            this.bits.characters.regions[cY][cX].Start
                        );

                        // TODO - Debug log
                        if (Config.DebugRegionCount)
                        {
                            if (elapsedCountCharacters != null) 
                                elapsedCountCharacters.end();

                            L.l(location, "Region X (" + cX + "), Y (" + cY + "), Start (" +
                                this.bits.characters.regions[cY][cX].Start.toString() +
                                "), width (" + (this.bits.characters.regions[cY][cX].End.x - this.bits.characters.regions[cY][cX].Start.x) +
                                "), height (" + (this.bits.characters.regions[cY][cX].End.y - this.bits.characters.regions[cY][cX].Start.y) + ").");

                            if (elapsedCountCharacters != null) 
                                elapsedCountCharacters.start();
                        }

                        if (!subRegions.fromPercentages(
                            this.xBreaks,
                            this.yBreaks,
                            this.bits.characters.regions[cY][cX].End.x - this.bits.characters.regions[cY][cX].Start.x,
                            this.bits.characters.regions[cY][cX].End.y - this.bits.characters.regions[cY][cX].Start.y
                        ))
                        {
                            L.l(location, "Skipping char at (" + cX + ", " + cY + "), failed to get sub-regions.");
                            continue;
                        }

                        // DEBUG
                        if (elapsedCountCharacters != null) elapsedCountCharacters.end();
                        if (Config.DebugRegionSize && !subRegions.logRegions())
                        {
                            L.err(location, "Failed to log regions.");
                            // Try anyway
                        }
                        if (elapsedCountCharacters != null) elapsedCountCharacters.start();

                        // Count character sub-regions
                        List<List<int>> countSet = this.bits.countRegions(subRegions, true);
                        if (countSet.Count == 0)
                        {
                            L.l(location, "Skipping empty character with (" + countSet.Count + ") set.");
                            continue;
                        }

                        // Stop timer for UI
                        if (elapsedCountCharacters != null) elapsedCountCharacters.end();

                        // Format output for UI, use a simple table
                        StringBuilder sb = new StringBuilder();
                        if (outputHeader.Length == 0)
                        {
                            for (int x = 0; x < countSet[0].Count; x++)
                            {
                                sb.Append(" | ").Append(Convert.ToString(x).PadLeft(5));
                            }
                            sb.Append(" |\n");

                            // Get a header length, and restart with a table top-border
                            textRowLength = sb.Length - 1;
                            outputHeader = sb.ToString();
                            sb = new StringBuilder();
                        }
                        sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");
                        sb.Append(outputHeader);
                        sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");

                        for (int y = 0; y < countSet.Count; y++)
                        {
                            if (countSet[y] == null) continue;

                            for (int x = 0; x < countSet[y].Count; x++)
                            {
                                sb.Append(" | ").Append(Convert.ToString(countSet[y][x]).PadLeft(5));
                            }
                            sb.Append(" | \n");
                            sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");
                        }

                        // TODO - formatting output is wrong. It assumes data is well-formed and non-empty.
                        Pt start = subRegions.regions[0][0].Start;
                        Pt end = subRegions.getEnd();
                        /*Pt end = subRegions.regions[subRegions.regions.Count - 1]
                            [subRegions.regions[subRegions.regions.Count - 1].Count - 1].End;*/

                        string temp =
                            "\n\n\n\n" +
                            "Region  -  [(" + start.x + ", " + start.y +") , (" + end.x + ", " + end.y + ")] :" +
                            "\n\n" +
                            sb.ToString();
                        Ui.Append(rtbRegionCounts, temp);
                        

                        //rtbRegionCounts.Text += temp;

                        /*if (rtbRegionCounts == null)
                        {
                            L.err(location, "UI for region counts was null when posting counts.");

                        }
                        else
                        {
                            // TODO - formatting output is wrong. It assumes data is well-formed and non-empty.
                            Pt start = subRegions.regions[0][0].Start;
                            Pt end = subRegions.regions[subRegions.regions.Count - 1]
                                [subRegions.regions[subRegions.regions.Count - 1].Count - 1].End;

                            string temp =
                                "\n\n\n\n" +
                                "Region  -  ((" + start.x + ", " + start.y +
                                ") , (" + end.x + ", " + end.y + ") :" +
                                "\n\n" +
                                sb.ToString();

                            rtbRegionCounts.Text += temp;
                        }*/
                        // Start timer after UI
                        if (elapsedCountCharacters != null) elapsedCountCharacters.start();

                        // Save subregions to class-level data
                        this.bits.characters.regions[cY][cX].regions = subRegions.regions;
                    }
                }

                L.l(location, "Pushing counts to UI.");

                // Output counts and perimeter for each character to log as CSV
                StringBuilder sbCounts = new StringBuilder();
                StringBuilder sbPerimeter = new StringBuilder();
                for (int cY = 1, order = 0; cY < this.bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < this.bits.characters.regions[cY].Count; cX++, order++)
                    {
                        string sCharacter = " ";
                        int characterIndex = ((cY - 1) * 26) + cX;
                        if (characterIndex >= 0 && characterIndex < supportedTemplates.Length)
                        {
                            sCharacter = supportedTemplates[characterIndex];
                        }
                        sbCounts.Append(order).Append(",").Append(sCharacter).Append(",")
                            .Append(this.bits.characters.regions[cY][cX].counts.toCsv());
                        /*if (characterIndex >= 0 && characterIndex < supportedTemplates.Length)
                        {
                            L.l(location, "Character (" + supportedTemplates[characterIndex] +
                                "), cY (" + cY + "), cX (" + cX +
                                "), Counts: " + this.bits.characters.regions[cY][cX].counts.toString());
                        }*/

                        sbPerimeter
                            .Append(order).Append(",")
                            .Append(sCharacter).Append(",")
                            .Append(this.bits.characters.regions[cY][cX].counts.perimeterToCsv(sCharacter));
                    }
                }
                L.l(location, "Template Counts\n" + sbCounts.ToString());
                L.l(location, "Template length:" + sbCounts.Length);
                sbCounts.Length = 0;

                /*L.l(location, "Template Perimeters\n" + sbPerimeter.ToString());
                sbPerimeter.Length = 0;*/

                /*// Output perimeter counts for each character to log
                StringBuilder sbPerimeter = new StringBuilder();
                for (int cY = 1, order = 0; cY < this.bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < this.bits.characters.regions[cY].Count; cX++, order++)
                    {
                        string sCharacter = " ";
                        int characterIndex = ((cY - 1) * 26) + cX;
                        if (characterIndex >= 0 && characterIndex < supportedTemplates.Length)
                        {
                            sCharacter = supportedTemplates[characterIndex];
                        }
                        sbPerimeter
                            .Append(order).Append(",")
                            .Append(sCharacter).Append(",")
                            .Append(this.bits.characters.regions[cY][cX].counts.perimeterToCsv(sCharacter));
                            //.Append(this.bits.characters.regions[cY][cX].counts.toCsv());
                        L.l(location, "Percent Counts (" + sCharacter + "): " + 
                            this.bits.characters.regions[cY][cX].counts.perimeterToString());
                    }
                }*/

                /*// Output perimeter to CSV
                for (int cY = 1; cY < this.bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < this.bits.characters.regions[cY].Count; cX++)
                    {
                        string sCharacter = " ";
                        int characterIndex = ((cY - 1) * 26) + cX;
                        if (characterIndex >= 0 && characterIndex < supportedTemplates.Length)
                        {
                            sCharacter = supportedTemplates[characterIndex];
                        }


                    }
                }*/




                /*for (int cY = 0; cY < this.bits.characters.regions.Count; cY++)
                {
                    for (int cX = 0; cX < this.bits.characters.regions[cY].Count; cX++)
                    {
                        if (this.bits.characters.regions[cY][cX] == null) continue;
                        if (this.bits.characters.regions[cY][cX].counts == null) continue;

                        // Format output for UI, use a simple table
                        StringBuilder sb = new StringBuilder();
                        if (outputHeader.Length == 0)
                        {
                            for (int x = 0; x < countSet[0].Count; x++)
                            {
                                sb.Append(" | ").Append(Convert.ToString(x).PadLeft(5));
                            }
                            sb.Append(" |\n");

                            // Get a header length, and restart with a table top-border
                            textRowLength = sb.Length - 1;
                            outputHeader = sb.ToString();
                            sb = new StringBuilder();
                        }
                        sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");
                        sb.Append(outputHeader);
                        sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");

                        for (int y = 0; y < countSet.Count; y++)
                        {
                            if (countSet[y] == null) continue;

                            for (int x = 0; x < countSet[y].Count; x++)
                            {
                                sb.Append(" | ").Append(Convert.ToString(countSet[y][x]).PadLeft(5));
                            }
                            sb.Append(" | \n");
                            sb.Append(" ".PadRight(textRowLength, '-')).Append("\n");
                        }

                        // TODO - formatting output is wrong. It assumes data is well-formed and non-empty.
                        Pt start = subRegions.regions[0][0].Start;
                        Pt end = subRegions.regions[subRegions.regions.Count - 1]
                            [subRegions.regions[subRegions.regions.Count - 1].Count - 1].End;

                        string temp =
                            "\n\n\n\n" +
                            "Region  -  [(" + start.x + ", " + start.y + ") , (" + end.x + ", " + end.y + ")] :" +
                            "\n\n" +
                            sb.ToString();
                        Ui.Append(rtbRegionCounts, temp);

                    }
                }*/






                // Push timing to UI
                if (elapsedCountCharacters != null)
                {
                    elapsedCountCharacters.end();
                    Ui.Append(lbTimingOutput, elapsedCountCharacters.toString());
                }

                // Flag success for completing... TODO - evaluate error level and reconsider
                retVal = true;

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool thresholdImage(Bitmap bmp, int rgbThresh)
        {
            const string location = CLASSNAME + ".thresholdImage";
            bool retVal = false;
            try
            {
                L.l(location, "Preparing to load threshold image.");

                // Bitmap and threshold are validated in fromBitmap()
                this.bits = new Bits();
                if (!this.bits.fromBitmap(bmp, rgbThresh))
                {
                    L.err(location, "Failed to get bits from image.");
                    return retVal;
                }
                Bitmap bmpOut = this.bits.toBitmap();

                // TODO - If we are counting everything, count in threshold and store higher

                int cntSet = this.bits.countAll(true);
                int cntUnset = this.bits.countAll(false);
                int size = bmp.Width * bmp.Height;
                L.l(location, "Image Size (" + size + "), Set (" + cntSet + "), Unset (" + cntUnset + ").");

                this.workingBmp = bmpOut;
                pbImageOut.Image = this.workingBmp;


                L.l(location, "Finished loading thresholded image.");
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool uiReset()
        {
            const string location = CLASSNAME + ".uiReset";
            bool retVal = false;
            try
            {
                int cntErrors = 0;
                if (!Ui.Clear(pbImageIn))
                {
                    cntErrors++;
                    L.err(location, "Failed to clear Image In.");
                }
                if (!Ui.Clear(pbImageOut))
                {
                    cntErrors++;
                    L.err(location, "Failed to clear Image Out.");
                }
                /*if (!Ui.Clear(pbCroppedLines))
                {
                    cntErrors++;
                    L.err(location, "Failed to clear cropped lines.");
                }*/
                if (!Ui.Clear(flowRowImages))
                {
                    cntErrors++;
                    L.err(location, "Failed to clear cropped lines.");
                }
                if (!Ui.Clear(flowCharacters))
                {
                    cntErrors++;
                    L.err(location, "Failed to clear characters.");
                }
                // TODO - Add region counts rtb

                retVal = cntErrors == 0;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool updateRtbReadText(string appendString)
        {
            const string location = CLASSNAME + ".updateRtbReadText";
            bool retVal = false;
            try
            {
                if (rtbReadTextImage == null) return retVal;
                if (appendString == null) appendString = "";

                if (rtbReadTextImage.InvokeRequired)
                {
                    rtbReadTextImage.Invoke(new Action(() => { retVal = this.updateRtbReadText(appendString); }));
                }
                else 
                {
                    rtbReadTextImage.AppendText(appendString);
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool updateTimingSettings()
        {
            const string location = CLASSNAME + ".updateTimingSettings";
            bool retVal = false;
            try
            {
                // Invoke on one, then process all from UI here, Ui invokes individually
                if (cbTmgTrainFont.InvokeRequired)
                {
                    cbTmgTrainFont.Invoke(new Action(() => { retVal = updateTimingSettings(); }));
                }
                else
                {
                    Config.TmgTrainFont = Ui.Checked(cbTmgTrainFont);
                    Config.TmgLoadTrainingImage = Ui.Checked(cbTmgLoadTrainingImage);
                    Config.TmgFindTrainingLines = Ui.Checked(cbTmgFindTrainingLines);
                    Config.TmgFindTrainingCharacters = Ui.Checked(cbTmgFindTrainingCharacters);
                    Config.TmgCountTrainingCharacters = Ui.Checked(cbTmgCountTrainingCharacters);
                    Config.TmgSaveTemplate = Ui.Checked(cbTmgSaveTemplate);
                    Config.TmgLoadTemplate = Ui.Checked(cbTmgLoadTemplate);
                    Config.TmgLoadTextImage = Ui.Checked(cbTmgLoadTextImage);
                    Config.TmgFindTextImageLines = Ui.Checked(cbTmgFindTextImageLines);
                    Config.TmgFindTextImageCharacters = Ui.Checked(cbTmgFindTextImageCharacters);
                    Config.TmgCountTextImageCharacters = Ui.Checked(cbTmgCountTextImageCharacters);
                    Config.TmgFindClosestTemplate = Ui.Checked(cbTmgFindClosestTemplate);
                    Config.TmgReadText = Ui.Checked(cbTmgReadText);
                    Config.TmgCompareAgainstActual = Ui.Checked(cbTmgCompareAgainstActual);
                    Config.TmgTextReadReport = Ui.Checked(cbTmgTextReadReport);

                    // Flag success for completing
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        // --------------- TESTING AREA -------------------

        public double findRise2(Bitmap bmp)
        {
            const string location = CLASSNAME + ".findRise";
            double retVal = 0.0d;
            try
            {
                // Validate input
                if (bmp == null)
                {
                    L.err(location, "Input bitmap was null.");
                    return retVal;
                }
                if (bmp.Width == 0 || bmp.Height == 0)
                {
                    L.err(location, "Input bitmap was zero size.");
                    return retVal;
                }


            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public double findRise1(Bitmap bmp)
        {
            const string location = CLASSNAME + ".findRise";
            double retVal = 0.0d;
            try
            {
                // Validate input
                if (bmp == null)
                {
                    L.err(location, "Input bitmap was null.");
                    return retVal;
                }
                if (bmp.Width == 0 || bmp.Height == 0)
                {
                    L.err(location, "Input bitmap was zero size.");
                    return retVal;
                }

                List<double> rises = new List<double>();

                bool inLine = false;
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color test = bmp.GetPixel(0, y);
                    if (test.B > 125)
                    {
                        inLine = false;
                        continue;
                    }
                    if (inLine) continue;

                    inLine = true;

                    // We are at the start of a line, from-left-to-right, should be white up dark down
                    int cntXFound = 0;
                    int pathY = y;
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color px = bmp.GetPixel(x, pathY);
                        if (px.B < 125)// black?
                        {
                            bool foundEdge = false;

                            // look to the north
                            for (pathY = y; pathY < bmp.Height && pathY <= 0; pathY--)
                            {
                                Color pxUp = bmp.GetPixel(x, pathY);
                                if (pxUp.B > 125)// white?
                                {
                                    foundEdge = true;
                                    pathY = pathY++;// go back one
                                    break;
                                }
                            }
                        }
                    }


                    // TODO - Take final pathY once at other edge of image
                    // TODO - diff Y's, find overall rise, no distortion
                    // TODO - turn rise into angle
                    // TODO - straigten image


                    /*for (int x = 0; x < bmp.Width; x++)
                    {
                        Color px = bmp.GetPixel(x, y);
                        if (px.B < 125)
                        {
                            inLine = false;
                        }
                        else if (inLine)
                        {
                            continue; // already in the line
                        }
                        else 
                        {
                            
                            inLine = true;
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool drawLines()
        {
            const string location = CLASSNAME + ".drawLines";
            bool retVal = false;
            try
            {
                //L.l(location, "Drawing lines 2.");
                Draw draw = new Draw();
                int diffY = (int)numFindLinesRise.Value;

                Bitmap bmp = new Bitmap(400, 400, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }

                // Draw lines
                int linesDrawn = 0;
                bool inLine = false;
                for (int y1 = 20; y1 < bmp.Height; y1++)
                {
                    if (y1 % 20 == 0) inLine = !inLine;
                    if (!inLine) continue;// skip white space

                    draw.line(ref bmp, y1, y1 + diffY);//level
                    linesDrawn++;
                }


                /*for (int y1 = 20; y1 < bmp.Height; y1 += 20)
                {
                    int y2 = (int)(y1 * 1.4);

                    if (y2 >= 0 && y2 < bmp.Height)
                    {
                        draw.line(ref bmp, y1, y2);
                        linesDrawn++;
                    }
                }*/
                L.l(location, "Drew (" + linesDrawn + ") lines.");

                // Publish image
                if (pbFindLines1.InvokeRequired)
                {
                    pbFindLines1.Invoke(new Action(() => { retVal = this.drawLines(); }));
                }
                else
                {
                    //pbFindLines2.Image = null;
                    //pbFindLines2.Image = pbFindLines1.Image;
                    pbFindLines1.Image = null;
                    pbFindLines1.Image = bmp;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public bool countLines()
        {
            const string location = CLASSNAME + ".countLines";
            bool retVal = false;
            try
            {
                Bitmap bmp = null;
                if (pbFindLines1.Image != null)
                {
                    bmp = (Bitmap)pbFindLines1.Image;
                }
                if (bmp == null)
                {
                    L.err(location, "Lines image not initialized at count.");
                    return retVal;
                }

                // Get a bits of the image since we don't have one
                Bits bLines = new Bits();
                if (!bLines.fromBitmap(bmp, 128))
                {
                    L.err(location, "Failed to threshold image.");
                    return retVal;
                }

                // Count a line across image
                int y1 = bmp.Height / 2;
                int y2 = y1;
                Counts countsLine1 = bLines.countLine(true, y1, y2);
                if (countsLine1 == null)
                {
                    L.err(location, "Failed to count line 1.");
                }
                else
                {
                    // TODO - remove debugs
                    L.l(location, "Count (" + countsLine1.ttlSet + ") at line y1 (" + y1 + "), y2 (" + y2 + ").");
                    L.l(location, "setLeft (" + countsLine1.setLeft + "), setRight (" + countsLine1.setRight + ").");
                }

                // Draw the counted line
                Bitmap bmpOut = bLines.toBitmap();
                if (bmpOut == null)
                {
                    L.err(location, "Failed to convert 1-bit back to Bitmap.");
                }
                else
                {
                    Draw draw = new Draw();
                    if (!draw.line(ref bmpOut, y1, y2, Color.Red))
                    {
                        L.err(location, "Failed to draw count-line at y1 (" + y1 + "), y2 (" + y2 + ").");
                    }
                    pbFindLines2.Image = bmpOut;
                }
                

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public double findRise()
        {
            const string location = CLASSNAME + ".findRise";
            double retVal = 0.0d;
            try
            {
                Bitmap bmp = null;
                if (pbFindLines2.Image != null)
                {
                    bmp = (Bitmap)pbFindLines2.Image;
                }
                if (bmp == null)
                {
                    L.err(location, "Lines image not initialized at count.");
                    return retVal;
                }

                // Get a bits of the image since we don't have one
                Bits bits = new Bits();
                if (!bits.fromBitmap(bmp, 128))
                {
                    L.err(location, "Failed to threshold image.");
                    return retVal;
                }

                if (bits == null || bits.ba == null || bits.ba.Length != (bits.Width * bits.Height))
                {
                    L.err(location, "Bits not initialized or size mismatch.");
                    return retVal;
                }

                /*   WORKS
                // Try counting an x pattern
                {
                    List<Counts> lineCounts = new List<Counts>();
                    for (
                        int y1 = 0, y2 = bits.Height - 1;
                        y1 < bits.Height && y2 >= 0;
                        y1++, y2--
                    )
                    {
                        Counts count = bits.countLine(true, y1, y2);
                        lineCounts.Add(count == null ? new Counts() : count);
                    }


                    double leastSet = 0;// count of unset, number rises
                    int leastSetIdx = -1;

                    for (int i = 0; i < lineCounts.Count; i++)
                    {
                        if (lineCounts[i].ttlUnset > leastSet)
                        {
                            leastSetIdx = i;
                            leastSet = lineCounts[i].ttlUnset;
                        }
                        L.l(location, "Line Y1 (" + i +
                            "), set (" + lineCounts[i].ttlSet + "), unset (" + lineCounts[i].ttlUnset +
                            "), left (" + lineCounts[i].setLeft + "), right (" + lineCounts[i].setRight + ").");
                    }
                    L.l(location, "The least set line was index (" + leastSetIdx + "), unset (" + lineCounts[leastSetIdx].ttlUnset +
                        "), Y1 (" + leastSetIdx + "), Y2 (" + (bits.Height - 1 - leastSetIdx) + ").");
                }*/


                // Try walking left edge to start of line
                {
                    bool inLine = true;
                    int y1 = -1;
                    for (int y = 0; y < bits.Height; y++)
                    {
                        // If we are in a line, keep going until not
                        if (bits.ba[y * bits.Width] == true)
                        {
                            if (!inLine)
                            {
                                // We found the Y associated with top of a line
                                y1 = y - 1;// land on blank, above line
                                break;
                            }
                            inLine = true;
                        }
                        else inLine = false;
                    }
                    L.l(location, "Identified Y1 (" + y1 + ") as the top of a line.");

                    if (y1 < 0)
                    {
                        L.err(location, "Failed to locate Y at the top of a line.");
                    }
                    else
                    {
                        // Walk y2 up and down, looking for the first empty line
                        int y2 = -1;

                        for (int cntr = 0; y2 < 0 && cntr < 1000; cntr++)
                        {
                            int y = y1 + cntr;
                            if (y >= 0 && y < bits.Height)
                            {
                                Counts cntLine = bits.countLine(true, y1, y);
                                if (cntLine != null && cntLine.ttlSet == 0)
                                {
                                    y2 = y;
                                    break;
                                }
                            }

                            y = y1 - cntr;
                            if (y >= 0 && y < bits.Height)
                            {
                                Counts cntLine = bits.countLine(true, y1, y);
                                if (cntLine != null && cntLine.ttlSet == 0)
                                {
                                    y2 = y;
                                    break;
                                }
                            }
                        }
                        int tempY1 = -1;
                        if (y2 < 0)
                        {
                            L.err(location, "Failed to find a Y2 for Y1 (" + y1 + ") with empty line.");
                            int lineNum = 2;
                            tempY1 = findYStartOfLine(bits, lineNum); // Try the second line instead, slope is positive

                            L.l(location, "Trying again with Y1 (" + tempY1 + ") start of line (" + lineNum + ").");

                            for (int cntr = 0; y2 < 0 && cntr < 1000; cntr++)
                            {
                                int y = tempY1 + cntr;
                                if (y >= 0 && y < bits.Height)
                                {
                                    Counts cntLine = bits.countLine(true, tempY1, y);
                                    if (cntLine != null && cntLine.ttlSet == 0)
                                    {
                                        y2 = y;
                                        y1 = tempY1;
                                        break;
                                    }
                                }

                                y = tempY1 - cntr;
                                if (y >= 0 && y < bits.Height)
                                {
                                    Counts cntLine = bits.countLine(true, tempY1, y);
                                    if (cntLine != null && cntLine.ttlSet == 0)
                                    {
                                        y2 = y;
                                        y1 = tempY1;
                                        break;
                                    }
                                }
                            }
                        }

                        if (y2 < 0)
                        {
                            L.err(location, "Failed to find a Y2 for Y1 (" + y1 + ") and (" + tempY1 + ") with empty line. Final error.");
                        }
                        else 
                        {
                            L.l(location, "Empty line at Y1 (" + y1 + "), Y2 (" + y2 + ").");

                            // So, you found an empty line, good for you. Is it the edge of a set-
                            // line? Move Y2.

                            Counts countLine = bits.countLine(true, y1, y2);
                            L.l(location, "Count set (" + (countLine == null ? -1 : countLine.ttlSet) + 
                                ") at Y1 (" + y1 + "), Y2 (" + y2 + ").");

                            // We know that Y1 is at the top of a line, Y2 needs to be also,
                            // drop Y2 until no longer empty, go back one, find rise.

                            int oldY2 = y2;
                            for (int y = y2; y < bits.Height; y++)
                            {
                                Counts temp = bits.countLine(true, y1, y);
                                if (temp.ttlSet > 0)
                                {
                                    y2 = y - 1;
                                    break;
                                }
                            }
                            L.l(location, "Y2 before scanning (" + oldY2 + "), Y2 after (" + y2 + ").");

                            Counts countLine2 = bits.countLine(true, y1, y2);
                            L.l(location, "Count set (" + (countLine2 == null ? -1 : countLine2.ttlSet) +
                                ") at Final Line Y1 (" + y1 + "), Y2 (" + y2 + ").");


                            // Find rise
                            int diffY = y1 - y2;
                            if (diffY < 0) diffY *= 1;

                            // Turn rise to angle
                            // Math.Atan(oppositeSide / adjacent)
                            // Math.Asin(oppositeSide / hypotenuse); // * (180.0 / Math.PI); // for degrees from radians

                            float angle = (float)Math.Atan((float)diffY / (float)bits.Width) * (float)(180.0 / Math.PI);
                            L.l(location, "Rotating image by angle (" + angle + ").");
                            if (y1 < y2)
                            {
                                L.l(location, "Shifting angle, Y1 (" + y1 + ") < Y2 (" + y2 + ").");
                                //angle *= -1;
                            }

                            // I do not know if the angle is high or low, just what it is

                            // Rotate by angle
                            Bitmap bmpRotated1 = bits.rotateBitmap(bmp, angle);
                            //Bitmap bmpRotated1 = bits.rotateBitmap(bmp, 30);
                            if (bmpRotated1 == null || bmpRotated1.Width == 0 || bmpRotated1.Height == 0)
                            {
                                L.err(location, "Output bmp was null or zero-size.");
                            }

                            // Look at picture

                            pbFindLines2.Image = bmpRotated1;

                            // Try again
                        }
                    }
                }



                /*    WORKS
                // Try counting on level
                {
                    List<Counts> lineCountsLevel = new List<Counts>();
                    for (int y1 = 0; y1 < bits.Height; y1++)
                    {
                        Counts count = bits.countLine(true, y1, y1);
                        lineCountsLevel.Add(count == null ? new Counts() : count);
                    }

                    // For fun
                    for (int i = 0; i < lineCountsLevel.Count; i++)
                    {
                        L.l(location, "Set at Y (" + i + ") left (" + lineCountsLevel[i].setLeft +
                            "), right (" + lineCountsLevel[i].setRight + ").");
                    }

                    // Look for a left = 0 (or as close to as possible), lock in y1, drift y2 up and down, 
                    // look for closest y2 to result in an empty line. 

                    int mY1 = -1;
                    int leastSetLeft = 0;
                    int leastSetLeftIdx = -1;
                    bool inLine = true;
                    for (int y = 0; y < lineCountsLevel.Count; y++)
                    {
                        //if (lineCountsLevel[i].setLeft)
                    }

                    // Rotate, look again

                }*/

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public int findYStartOfLine(Bits bits, int lineNumber)
        {
            const string location = CLASSNAME + ".findYStartOfLine";
            int retVal = -1;
            try
            {

                int cntLine = 0;
                bool inLine = true; // don't count lines that touch the top

                for (int y = 0; y < bits.Height; y++)
                {
                    if (bits.ba[y * bits.Width] == true)
                    {
                        if (inLine) continue;

                        cntLine++;
                        inLine = true;

                        if (cntLine == lineNumber)
                        {
                            retVal = y - 1;
                            break;
                        }
                    }
                    else inLine = false;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }




        // ------------- END TESTING AREA -----------------


        // ---------------- UI HELPERS --------------------

        public bool clearTimingUi()
        {
            const string location = CLASSNAME + ".clearTimingUi";
            bool retVal = false;
            try
            {
                int cntErrors = 0;
                if (!Ui.Clear(lbTimingOutput))
                {
                    L.err(location, "Failed to clear timing listbox.");
                    cntErrors++;
                }
                if (!Ui.Clear(gridTimingOutput, false))
                {
                    L.err(location, "Failed to clear timing grid rows.");
                    cntErrors++;
                }
                retVal = 0L == cntErrors;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool timeAllEvents(bool enabled)
        {
            const string location = CLASSNAME + ".timeAllEvents";
            bool retVal = false;
            try
            {
                if (cbTmgTrainFont.InvokeRequired)
                {
                    cbTmgTrainFont.Invoke(new Action(() => { retVal = timeAllEvents(enabled); }));
                }
                else 
                {
                    if (cbTmgTrainFont != null) cbTmgTrainFont.Checked = enabled;
                    if (cbTmgLoadTrainingImage != null) cbTmgLoadTrainingImage.Checked = enabled;
                    if (cbTmgFindTrainingLines != null) cbTmgFindTrainingLines.Checked = enabled;
                    if (cbTmgFindTrainingCharacters != null) cbTmgFindTrainingCharacters.Checked = enabled;
                    if (cbTmgCountTrainingCharacters != null) cbTmgCountTrainingCharacters.Checked = enabled;
                    if (cbTmgSaveTemplate != null) cbTmgSaveTemplate.Checked = enabled;
                    if (cbTmgLoadTemplate != null) cbTmgLoadTemplate.Checked = enabled;
                    if (cbTmgLoadTextImage != null) cbTmgLoadTextImage.Checked = enabled;
                    if (cbTmgFindTextImageLines != null) cbTmgFindTextImageLines.Checked = enabled;
                    if (cbTmgFindTextImageCharacters != null) cbTmgFindTextImageCharacters.Checked = enabled;
                    if (cbTmgCountTextImageCharacters != null) cbTmgCountTextImageCharacters.Checked = enabled;
                    if (cbTmgFindClosestTemplate != null) cbTmgFindClosestTemplate.Checked = enabled;
                    if (cbTmgReadText != null) cbTmgReadText.Checked = enabled;
                    if (cbTmgCompareAgainstActual != null) cbTmgCompareAgainstActual.Checked = enabled;
                    if (cbTmgTextReadReport != null) cbTmgTextReadReport.Checked = enabled;

                    // Flag success for completing 
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }




        // -------------- END UI HELPERS ------------------


        // ----------------- EVENTS -----------------------


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".exitToolStripMenuItem_Click";
            try
            {
                L.l(location, "Exiting from toolstrip menu item.");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnClearLogs_Click";
            try
            {
                L.l(location, "Clearing logs.");
                long lengthCleared = L.clearLogs();
                L.l(location, "Cleared (" + lengthCleared + ") log length.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnClearTiming_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnClearTiming_Click";
            try
            {
                L.l(location, "Clearing timing ui by button click.");
                long lengthCleared = 0;
                if (lbTimingOutput != null) lengthCleared = lbTimingOutput.Items.Count;
                else if (gridTimingOutput != null) lengthCleared = gridTimingOutput.Rows.Count;
                if (!this.clearTimingUi())
                {
                    L.err(location, "Failed to clear timing ui.");
                }
                else
                {
                    L.l(location, "Cleared (" + lengthCleared + ") items from timing tab.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnCountLines_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnCountLines_Click";
            try
            {
                L.l(location, "Counting lines from button click.");
                if (!countLines())
                {
                    L.err(location, "Failed to count lines from button click.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnDrawLines_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnDrawLines_Click";
            try
            {
                L.l(location, "Drawing lines from click.");
                if (!drawLines())
                {
                    L.err(location, "Failed to draw lines.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnFindRise_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnFindRise_Click";
            try
            {
                L.l(location, "Finding rise from button click.");
                double rise = findRise();
                L.l(location, "Rise returned (" + rise + ").");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnLoadImage_Click";
            try
            {
                L.l(location, "Loading image from click.");
                if (!loadImage())
                {
                    L.err(location, "Failed to load image.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetTextRows_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetTextRows_Click";
            try
            {
                L.l(location, "Getting text rows from image.");
                if (!getRows())
                {
                    L.err(location, "Failed to get rows.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetCharacters_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetCharacters_Click";
            try
            {
                L.l(location, "Getting characters from button click.");
                if (!getCharacters())
                {
                    L.err(location, "Failed to get characters.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetRegionCounts_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetRegionCounts";
            try
            {
                if (!this.getCharacterRegionCounts())
                {
                    L.err(location, "Failed to get character regions counts.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnRegionsSaveTemplates_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnRegionsSaveTemplates_Click";
            try
            {
                L.l(location, "Saving character regions as templates from button click.");

                if (tbRegionsTemplatePath == null || tbRegionsTemplatePath.Text.Length == 0)
                {
                    L.err(location, "Input template path was null or empty.");
                }

                string fullPath = tbRegionsTemplatePath.Text;
                if (!this.saveCharactersAsTemplates(@fullPath))
                {
                    L.err(location, "Failed to save character regions as templates.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnRegionsLoadTemplates_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnRegionsLoadTemplates_Click";
            try
            {
                L.l(location, "Loading character regions as templates from button click.");

                if (tbRegionsTemplatePath == null || tbRegionsTemplatePath.Text.Length == 0)
                {
                    L.err(location, "Input template path was null or empty.");
                }

                string fullPath = tbRegionsTemplatePath.Text;
                if (!this.loadCharacterTemplates(@fullPath))
                {
                    L.err(location, "Failed to load character regions as templates.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnLoadTextImage_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnLoadTextImage_Click";
            try
            {
                L.l(location, "Loading text image from button click.");
                if (!this.loadTextImage())
                {
                    L.err(location, "Failed to load text image.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnReadTextImage_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnReadTextImage_Click";
            try
            {
                L.l(location, "Reading text image from button click.");
                if (!this.readTextImage())
                {
                    L.err(location, "Failed to read text image from button click.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {

        }

        private void cbTiming_CheckedChanged(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".cbTiming_Click";
            try
            {
                //L.l(location, "Saving timing setting from click.");
                if (!this.updateTimingSettings())
                {
                    L.err(location, "Failed to update timing settings from click.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void comboKnownImages_SelectedValueChanged(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".comboKnownImages_SelectedValueChanged";
            try
            {
                if (!selectImage())
                {
                    L.err(location, "Failed to select known image.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void comboReadImages_SelectedValueChanged(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".comboReadImages_SelectedValueChanged";
            try
            {
                if (!selectReadImage())
                {
                    L.err(location, "Failed to ready read image path.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void comboKnownTemplates_SelectedValueChanged(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".comboKnownTemplates_SelectedValueChanged";
            try
            {
                if (!selectKnownTemplate())
                {
                    L.err(location, "Failed to ready template path.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        // --------------- END EVENTS ---------------------
    }
}
