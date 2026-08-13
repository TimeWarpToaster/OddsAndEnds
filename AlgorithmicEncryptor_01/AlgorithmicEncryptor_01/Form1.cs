//Algorithmic Encryptor v01
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;

namespace AlgorithmicEncryptor_01
{
    public partial class Form1 : Form
    {
        public const string CLASSNAME = "Form1";

        private string keyPath = @".\";// Drop keys next to the executable
        private string keyExt = ".key";

        private int keyCharacterSize = 47;// The number of alternate encoding formats per character

        private Key currentKey = null;

        List<int> publishedNumbers = new List<int>();
        Random r = null;

        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                // Initialize without file logging
                if (!L.logInit(null, rtbLogsOut, false))
                {
                    // It is safe to call logging if init fails, but nothing will work
                }

                /*// Setup a dated log file at init (works)
                logPath = @"C:\AELogs\AELog_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
                if (!L.logInit(@logPath, rtbLogsOut, isFileLogging))
                {
                    // Some logging may safely work
                    L.err(location, "Failed to initialize logging.");
                }*/

                if (!initApp())
                {
                    L.err(location, "Failed to initialize application.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public bool initApp()
        {
            const string location = CLASSNAME + ".initApp";
            bool retVal = false;
            try
            {
                this.r = new Random();
                this.r.Next(this.r.Next(this.r.Next()));

                if (!setInstructions())
                {
                    L.err(location, "Failed to load instructions to ui.");
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

        private bool createKey()
        {
            const string location = CLASSNAME + ".createKey";
            bool retVal = false;
            try
            {
                Stopwatch swOverall = Stopwatch.StartNew();

                // Init parameters
                L.l(location, "Init parameters.");
                int numEquivs = this.keyCharacterSize; // Get from UI

                // TODO - Create archive/lookup to know key id is unique
                // for now, depend on id and identifier combined,
                // which, also does not help, neither is recorded except in-file
                L.l(location, "Construct key object.");
                Key key = new Key();
                key.keyId = this.r.Next();
                key.keyIdentifier = Guid.NewGuid().ToString().PadLeft(40).Substring(0,40);
                key.keyPath = this.keyPath;

                // Generate a random encoding
                if (!key.initChars(numEquivs))
                {
                    L.err(location, "Failed to construct key with (" + numEquivs + ") equivs.");
                    return retVal;
                }

                JObject obj = key.toJObject();
                if (obj == null) 
                {
                    L.err(location, "Key object was null.");
                    return retVal;
                }

                string pretty = obj.ToString(Newtonsoft.Json.Formatting.Indented);
                if (!this.setRtb(rtbCurrentKey, pretty))
                {
                    L.err(location, "Failed to set Current Key tab.");
                }
                if (!this.setRtb(rtbCurrentKey2, pretty))
                {
                    L.err(location, "Failed to set key in compare-panel (right).");
                }

                // Flag success for completing
                this.currentKey = key;
                retVal = true;

                swOverall.Stop();
                pushTime("Create key (overall)", swOverall);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getDecodedFromEncoded(string encoded)
        {
            const string location = CLASSNAME + ".getDecodedFromEncoded";
            string retVal = "";
            try
            {
                Stopwatch swDecode = new Stopwatch();
                Stopwatch swGetMathChars = new Stopwatch();
                Stopwatch swParse = new Stopwatch();
                Stopwatch swSolve = new Stopwatch();
                Stopwatch swUpdateUi = new Stopwatch();
                Stopwatch swOverall = Stopwatch.StartNew();

                if (encoded == null || encoded.Length == 0)
                {
                    L.err(location, "Encoded message was null or empty.");
                    return retVal;
                }

                if (currentKey == null)
                {
                    L.err(location, "Current key was null at decode.");
                    return retVal;
                }

                if (currentKey.chars == null || currentKey.mathChars == null)
                {
                    L.err(location, "Key chars or math chars was null.");
                    return retVal;
                }

                // Test length according to key
                if (encoded.Length % currentKey.mathStringLimit != 0)
                {
                    // Note: copying-and-pasting an encoded message directly into the form from
                    // a text editor, routinely adds an extra line-break or space character. Call
                    // trim when retrieving from ui.
                    L.err(location, "Encoded message was not a valid length for character size.");
                    return retVal;
                }
                L.l(location, "Encoded length (" + encoded.Length + ").");

                swGetMathChars.Start();
                char[] chars = encoded.ToCharArray();
                StringBuilder sbMathEquation = new StringBuilder();
                for (int i = 0; i + 2 < chars.Length; i += 3)
                {
                    string matchString = new string(new char[] { chars[i], chars[i + 1], chars[i + 2] });

                    char c = '~';// not a match
                    bool foundChar = false;

                    foreach (KeyValuePair<char, List<string>> kv in currentKey.mathChars)
                    {
                        for (int idxString = 0; idxString < kv.Value.Count; idxString++)
                        {
                            if (matchString == kv.Value[idxString])
                            {
                                c = kv.Key;
                                foundChar = true;
                                break;
                            }
                        }
                        if (foundChar) break;
                    }

                    if (c == '~')
                    {
                        L.err(location, "Failed to identify character for (" + matchString + ").");
                        return retVal;// hard error
                    }

                    sbMathEquation.Append(c);
                }
                swGetMathChars.Stop();


                swParse.Start();
                // Start by splitting individual equations from the string
                string mathEquation = sbMathEquation.ToString();
                //L.l(location, "Math equation: " + mathEquation);

                // TODO - Rewrite next two-lines into a parse
                string[] eqs = mathEquation.Split('=');
                for (int i = 0; i < eqs.Length; i++) eqs[i] += '=';
                swParse.Stop();

                swDecode.Start();
                StringBuilder sbDecode = new StringBuilder();
                for (int i = 0; i < eqs.Length; i++)
                {
                    // Quietly skip junk data, final equals can create an empty string at split, then append '=' (<=1)
                    if (eqs[i] == null || eqs[i].Length <= 1) continue;

                    // Build an equation object
                    swParse.Start();
                    Equation equation = new Equation();
                    if (!equation.fromString(eqs[i]))
                    {
                        L.err(location, "Failed to build equation from text. Value: " + eqs[i]);
                        return retVal;
                    }
                    swParse.Stop();

                    // Get a number value
                    swSolve.Start();
                    int solution = equation.solveForValue();
                    if (solution < 0)
                    {
                        L.err(location, "Failed to solve for equation: " + eqs[i]);
                        return retVal;
                    }
                    swSolve.Stop();
                    //L.l(location, "Solution: " + solution);

                    // Look up number in regular chars
                    bool foundChar = false;
                    foreach (KeyValuePair<char, List<int>> kv in currentKey.chars)
                    {
                        for (int idxInt = 0; idxInt < kv.Value.Count; idxInt++)
                        {
                            if (solution == kv.Value[idxInt])
                            {
                                sbDecode.Append(kv.Key);
                                foundChar = true;
                                break;
                            }
                        }
                        if (foundChar) break;
                    }
                    if (!foundChar)
                    {
                        L.err(location, "Failed to find character for char (" + solution + ").");
                        return retVal;
                    }
                }
                string decoded = sbDecode.ToString();
                swDecode.Stop();

                swUpdateUi.Start();
                if (!setRtb(rtbMessageDecoded, decoded))
                {
                    L.err(location, "Failed to set decoded message in UI.");
                }
                swUpdateUi.Stop();

                // Output Result
                retVal = decoded;

                swOverall.Stop();
                pushTime("Decode (get math)", swGetMathChars);
                pushTime("Decode (parse)", swParse);
                pushTime("Decode (solve)", swSolve);
                pushTime("Decode (decode)", swDecode);
                pushTime("Decode (update ui)", swUpdateUi);
                pushTime("Decode (overall)", swOverall);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getEncodedFromMath(string mathForm)
        {
            const string location = CLASSNAME + ".getEncodedFromMath";
            string retVal = "";
            try
            {
                if (mathForm == null || mathForm.Length == 0)
                {
                    L.err(location, "Input math form was null or empty.");
                    return retVal;
                }
                if (currentKey == null)
                {
                    L.err(location, "Current key was null.");
                    return retVal;
                }
                if (currentKey.mathChars == null || currentKey.mathChars.Count == 0)
                {
                    L.err(location, "Key math characters was null or empty.");
                    return retVal;
                }

                char[] chars = mathForm.ToCharArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < mathForm.Length; i++)
                {
                    char c = mathForm[i];
                    if (!currentKey.mathChars.ContainsKey(c))
                    {
                        L.err(location, "Failed to locate math char (" + c + ").");
                        return retVal;// hard error
                    }

                    // Pick a random index from mathChar equivalents
                    int idx = this.r.Next(0, currentKey.mathChars[c].Count - 1);
                    sb.Append(currentKey.mathChars[c][idx]);
                }

                if (!setRtb(rtbMessageEncoded, sb.ToString()))
                {
                    L.err(location, "Failed to update UI with encoded message.");
                }

                retVal = sb.ToString();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getMathFromNumbers()
        {
            const string location = CLASSNAME + ".getMathFromNumbers";
            string retVal = "";
            try
            {
                Stopwatch swOverall = Stopwatch.StartNew();
                if (this.publishedNumbers == null || this.publishedNumbers.Count == 0)
                {
                    L.err(location, "Numbers list was null or empty.");
                    return retVal;
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < this.publishedNumbers.Count; i++)
                {
                    // Get math for this number, with random numOfIterations
                    sb.Append(this.getMathInt(this.publishedNumbers[i], this.r.Next(3, 6)));
                }

                string sOut = sb.ToString();
                if (!this.setRtb(rtbMessageMath, sOut))
                {
                    L.err(location, "Failed to update ui with math from numbers.");
                }

                // Output Result
                retVal = sOut;
                swOverall.Stop();
                this.pushTime("Math from numbers (overall)", swOverall);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getMathList(List<int> nums)
        {
            const string location = CLASSNAME + ".getMathList";
            string retVal = "";
            try
            {
                if (nums == null)
                {
                    L.err(location, "Input number list was null.");
                    return retVal;
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < nums.Count; i++)
                {
                    sb.Append(getMathInt(nums[i], 4));
                }

                retVal = sb.ToString();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getMathInt(int value, int numOps)
        {
            const string location = CLASSNAME + ".getMathInt";
            string retVal = "";
            try
            {
                // Get an equation for number
                Equation equation = new Equation();
                if (!equation.fromNumber(value, numOps, r))
                {
                    L.err(location, "Failed to build equation for num (" + value + ") with ops (" + numOps + ").");
                    return retVal;
                }

                // Convert to string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < equation.nums.Count && i < equation.ops.Count; i++)
                {
                    sb.Append(Convert.ToString(equation.nums[i])).Append(equation.ops[i]);
                }

                //L.l(location, "Value (" + value + "), Equation: " + sb.ToString());
                //int solved = equation.solveForValue();
                //L.l(location, "Value (" + value + ") solved to (" + solved + ").");

                retVal = sb.ToString();
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private string getMessageText()
        {
            const string location = CLASSNAME + ".getMessageText";
            string retVal = "";
            try
            {
                if (rtbMessageIn == null)
                {
                    L.err(location, "UI was null at get text.");
                    return retVal;
                }
                if (rtbMessageIn.InvokeRequired)
                {
                    rtbMessageIn.Invoke(new Action(() => getMessageText()));
                }
                else 
                {
                    // Read value
                    retVal = rtbMessageIn.Text;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private List<int> getMessageNumbers()
        {
            const string location = CLASSNAME + ".getMessageNumbers";
            List<int> retVal = new List<int>();
            try
            {
                Stopwatch swData = new Stopwatch();
                Stopwatch swUpdateUi = new Stopwatch();
                Stopwatch swOverall = Stopwatch.StartNew();
                if (this.currentKey == null)
                {
                    L.err(location, "Current key was null or not created.");
                    return retVal;
                }
                string message = this.getMessageText();
                L.l(location, "Input message length (" + message.Length + ") chars.");

                if (message == null || message.Length == 0)
                {
                    L.err(location, "Input message was null or empty.");
                    return retVal;
                }

                swData.Start();

                List<int> result = new List<int>();

                char[] msgChars = message.ToCharArray();
                for (int i = 0; i < msgChars.Length; i++)
                {
                    char c = msgChars[i];

                    // See if character exists
                    if (!this.currentKey.chars.ContainsKey(c))
                    {
                        L.err(location, "Skipping unknown character (" + ((int)c) + ").");
                        continue;
                    }

                    // Get a number of equivs for character
                    int numEquivs = this.currentKey.chars[c].Count;

                    // Get a random index
                    int idx = this.r.Next(0, numEquivs-1);

                    // Add equiv to output
                    if (idx >= 0 && idx < this.currentKey.chars[c].Count)
                    {
                        result.Add(this.currentKey.chars[c][idx]);
                    }
                }
                swData.Stop();


                // Comprise a string for UI from list of numbers
                swUpdateUi.Start();
                StringBuilder sb = new StringBuilder();
                if (result.Count != msgChars.Length)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        sb.Append("idx ").Append(Convert.ToString(i).PadRight(5)).Append("  -  ").Append(result[i]).Append("\n");
                    }
                }
                else 
                {
                    for (int i = 0; i < msgChars.Length; i++)
                    {
                        sb.Append(msgChars[i]).Append("  -  ").Append(result[i]).Append("\n");
                    }
                }

                if (!this.setRtb(rtbMessageNumbers, sb.ToString()))
                {
                    L.err(location, "Failed to update tab Message Numbers.");
                    // do not hard error
                }
                swUpdateUi.Stop();


                // Evaluate success
                this.publishedNumbers = result;
                retVal = result;
                if (retVal.Count != msgChars.Length)
                {
                    L.err(location, "Output value length (" + retVal.Count + ") does not match input (" + msgChars.Length + ").");
                }
                swOverall.Stop();
                this.pushTime("Get message numbers (data)", swData);
                this.pushTime("Get message numbers (UI)", swUpdateUi);
                this.pushTime("Get message numbers (overall)", swOverall);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private bool pushTime(string processName, Stopwatch stopwatch)
        {
            const string location = CLASSNAME + ".pushTime";
            bool retVal = false;
            try
            {
                // Assume everything is set for now or exception
                L.t(location, processName + " - Elapsed (" + stopwatch.ElapsedMilliseconds + ").");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private bool readKey()
        {
            const string location = CLASSNAME + ".readKey";
            bool retVal = false;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Key Files (*" + this.keyExt + ")|*" + this.keyExt,
                    InitialDirectory = @"./"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.currentKey = new Key();

                    this.currentKey.keyPath = openFileDialog.FileName;
                    if (this.currentKey.keyPath == null || this.currentKey.keyPath.Length == 0)
                    {
                        L.err(location, "Input path was null or empty.");
                        return retVal;
                    }

                    if (!this.currentKey.fromFile())
                    {
                        L.err(location, "Failed to read key from file. Path: " + currentKey.keyPath);
                        return retVal;
                    }

                    //L.l(location, "Converting key for ui.");
                    JObject obj = this.currentKey.toJObject();
                    if (obj == null)
                    {
                        L.err(location, "Key object was null.");
                        return retVal;
                    }

                    string pretty = obj.ToString(Newtonsoft.Json.Formatting.Indented);
                    if (!this.setRtb(rtbCurrentKey, pretty))
                    {
                        L.err(location, "Failed to set Current Key tab.");
                    }
                    if (!this.setRtb(rtbCurrentKey2, pretty))
                    {
                        L.err(location, "Failed to set key in compare-panel (right).");
                    }
                }

                // Let dialog handle outcome
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool saveKey()
        {
            const string location = CLASSNAME + ".saveKey";
            bool retVal = false;
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Open or Create",
                    Filter = "Key Files (*" + this.keyExt + ")|*" + this.keyExt,
                    FileName = "AEKey_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".key",
                    InitialDirectory = @"./",
                    OverwritePrompt = false,
                    CheckFileExists = false
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.currentKey.keyPath = saveFileDialog.FileName;
                    L.l(location, "Writing to file: " + this.currentKey.keyPath);
                    long charsWritten = this.currentKey.toFile();
                    if (charsWritten <= 0)
                    {
                        L.err(location, "Failed to write to file: " + this.currentKey.keyPath);
                        return retVal;
                    }
                    L.l(location, "Wrote (" + charsWritten + ") characters to file.");
                }

                // Let dialog handle outcome
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private bool setRtb(RichTextBox rtb, string value)
        {
            const string location = CLASSNAME + ".setRtb";
            bool retVal = false;
            try
            {
                if (rtb == null)
                {
                    L.err(location, "Input rtb was null.");
                    return retVal;
                }
                if (value == null)
                {
                    L.err(location, "Input value was null.");
                    return retVal;
                }

                if (rtb.InvokeRequired)
                {
                    rtb.Invoke(new Action(() => setRtb(rtb, value)));
                }
                else
                {
                    rtb.Text = value;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private bool setInstructions()
        {
            const string location = CLASSNAME + ".setInstructions";
            bool retVal = false;
            try
            {
                string instructions =
                    "\n" +
                    "Algorithmic Encryptor\n" +
                    "\n" +
                    "\n" +
                    "Begin by creating a key, from the button on left. You may choose to save this key for use again " +
                    "later. Once a key has been created or read (if existing), the Current Key tab will show the key, " +
                    "in json format, as will the far right slide-out \"compare\" region. The compare region, is for if " +
                    "you wish to reverse the logic of other tabs.\n" +
                    "\n" +
                    "On the Message In tab, type a message you wish to encrypt. This harness app, as it is built, can handle " +
                    "messages upto a few pages long. Because of the expansion of volume, and the hastiness of the this harness " +
                    "app, there is a finite breaking point beyond a couple thousand words of input message.\n" +
                    "\n" +
                    "Switch to the Message Numbers tab, and click on the \"Get Msg Numbers\" button. Listed in the view, " +
                    "are each character individually, and the number chosen from its assigned values, to represent it in " +
                    "this encoding of the message. Each character has a chance of being represented, by many different " +
                    "values.\n" +
                    "\n" +
                    "Open the Message Math tab, and click on the \"Get Msg Math\" button. The numbers selected to represent " +
                    "your characters, have been turned into quasi-random equations, that solve back to the number.\n" +
                    "\n" +
                    "From the Message Encoded tab, click the \"Get Msg Encoded\" button. Each character from the Message Math " +
                    "tab output, has been converted into a three character piece of text. Each math character has been represented " +
                    "by one three-character string, from a pool of equivalent such strings.\n" +
                    "\n" +
                    "Keys can be saved, using Save Key, and loaded using Read Key. A word of caution, there is not much safety-railing. " +
                    "You can reload keys and keep working, but the other tabs will not update their content, until their corresponding " +
                    "action has been called again. Further, if you change keys, and skip over Get Msg Numbers, and go straight to " +
                    "Get Msg Math, it will work with the old content from the Message Numbers tab. This is meant to be an experiment, " +
                    "not a finished product. Used as such, it works.\n" +
                    "\n" +
                    "All of the text-fields are interactive. Meaning, you can manually edit keys, possibly malalign them. You can " +
                    "also mess up the math, or make meaningless changes to the numbers selected. More interestingly, you can " +
                    "paste a previously encoded message, from somewhere, and decrypt it, assuming you have the key-file.\n" +
                    "\n" +
                    "\n" +
                    "Flaws and Limitations\n" +
                    "\n" +
                    "This app is not hiding much. If you feel you have had an error, or something did not behave properly, check " +
                    "the Logs tab at far top. Most errors that can occur are reported there. If decoding and you get a set of " +
                    "three symbols that are not found, it is a good sign that the incorrect key is loaded to decrypt with.\n" +
                    "\n" +
                    "Everything runs on the UI thread. In general, your message size should be small enough, that this is of little " +
                    "or no impact. Maybe a few seconds on decode. If however, you are encoding chapters of your latest book, expect to " +
                    "wait and not click other buttons until it has finished.\n" +
                    "\n" +
                    "The entire contents for all actions are posted to ui for review. The downside, is this further implies a limit to " +
                    "message size, as the full message, assigned numbers per character, equations, encoded format, and decoded will " +
                    "be loaded at-once.\n" +
                    "\n" +
                    "Performance has not really been an issue. Much could be done to make things faster, but full encryption is always " +
                    "expensive. That said, this is suitable for encrypting text, or small files, but not much else. The encoded state, " +
                    "almost precludes advanced media.\n" +
                    "\n" +
                    "As this is an experiment, keys created are stored in human-readable format for validation. That is, the keys are " +
                    "not secured.\n" +
                    "\n" +
                    "The random equation generator, was built, and works, but even usage of operators is far-more complex than I wanted " +
                    "to entertain. For one thing, you cannot multiply half-of-the time, because the current value is larger than " +
                    "half-of-max. You can divide if the current value is greater than 2 or 3, but division has a propensity to " +
                    "drive the running value into single digits. There are ways to solve these (somewhat), but I have not done it. " +
                    "More plainly, this app and code, plays artificial favortism for addition and subtraction when building " +
                    "random equations. This is exagerated slightly, by forcing + or - as the final operation of an equation " +
                    "to arrive back at the final value. A more advanced algorithm could solve this. As could support for decimals.\n" +
                    "\n" +
                    "This app was built in three-days. If you are serious about moving a message, prove your decrypt before sending.\n" +
                    "\n" +
                    "Update to the above, I had to pull multiplication and division from the equation building, for reasons I just " + 
                    "really did not have the time to attend to. Multiples would occasionally draw too far out of bounds, to " +
                    "self correct with a finishing subtraction of Int32.MaxValue or less. I modeled division the same between " +
                    "equation generation and solving, but was getting a small rounding difference, by the end of equation, this was " +
                    "resulting in the number being off by a few-points. Maybe somebody else will have fun solving these." +
                    "\n" +
                    "\n" + 
                    "\n" + 
                    "\n" + 
                    "GNU GPL-3.0 License\n" +
                    "\n" + 
                    License.license;


                retVal = setRtb(rtbInstructions, instructions);
                if (!retVal)
                {
                    L.err(location, "Failed to set instructions in ui.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnClearLogs_Click";
            try
            {
                long numCleared = L.clearLogs();
                L.l(location, "Removed (" + numCleared + ") logs from UI.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".exitToolStripMenuItem_Click";
            try
            {
                L.l(location, "App exiting from menu item.");
                Environment.Exit(0);
                L.err(location, "App failed to exit from menu item.");
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnCreateKey_Click";
            try
            {
                if (!this.createKey())
                {
                    L.err(location, "Failed to create key upon button click.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetMessageNumbers_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetMessageNumbers";
            try
            {
                List<int> messageNumbers = this.getMessageNumbers();
                if (messageNumbers == null || messageNumbers.Count == 0)
                {
                    L.err(location, "Failed to get message numbers for UI.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnMessageMath_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnMessageMath";
            try
            {
                string s = this.getMathFromNumbers();
                if (s == null || s.Length == 0)
                {
                    L.err(location, "Failed to get math from numbers.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetMsgEncoded_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetMsgEncoded_Click";
            try
            {
                string mathForm = rtbMessageMath.Text;
                string encodedForm = this.getEncodedFromMath(mathForm);
                if (encodedForm == null || encodedForm.Length == 0)
                {
                    L.err(location, "Encoded form was null or empty.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnGetMsgDecoded_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnGetMsgDecoded_Click";
            try
            {
                string encoded = rtbMessageEncoded.Text.Trim();
                string decoded = getDecodedFromEncoded(encoded);
                if (decoded == null || decoded.Length == 0)
                {
                    L.err(location, "Failed to decode message from encoded.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnSaveKey_Click";
            try
            {
                if (!this.saveKey())
                {
                    L.err(location, "Failed to save current key to file.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnReadKey_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnReadKey_Click";
            try
            {
                if (!this.readKey())
                {
                    L.err(location, "Failed to read key from key-path.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }
    }
}

