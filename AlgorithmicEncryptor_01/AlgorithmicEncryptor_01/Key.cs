//Algorithmic Encryptor v01
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace AlgorithmicEncryptor_01
{
    public class Key
    {
        public const string CLASSNAME = "Key";

        public long keyId = -1L;
        public string keyIdentifier = ""; // guid
        public string keyPath = @"";

        public Dictionary<char, List<int>> chars = new Dictionary<char, List<int>>();
        public Dictionary<char, List<string>> mathChars = new Dictionary<char, List<string>>();

        public int mathStringLimit = 3;// How many characters are math chars encoded?


        // Whatever is in your stockChars, gets added to your chars array, with generated equivalent matches.
        // Add it here. Same for stockMathChars, if you plan to do fancier a(b*c) type stuff.
        public char[] stockChars =
            new char[]
                {
                    '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
                    'e', 's', 't', 'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k',
                    'l', 'm', 'n', 'o', 'p', 'q', 'r', 'u', 'v',
                    'w', 'x', 'y', 'z',
                    'E', 'S', 'T', 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J', 'K',
                    'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'U', 'V',
                    'W', 'X', 'Y', 'Z',
                    '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
                    '_', '+', '{', '}', '|', ':', '"', '<', '>', '?', ' '/*space*/,
                    '`', '-', '=', '[', ']', '\\', ';', '\'', ',', '.', '/',
                    '\r', '\n', '\t',
                    // basic formatting below, elipses, slant-quotes, slant-apostrophe, extended hyphen
                    '\u201c', '\u201d', '\u2018', '\u2019', '\u2026', '\u2013'
                };

        public char[] stockMathChars =
            new char[]
                {
                    '1', '2', '3', '4', '5',
                    '6', '7', '8', '9', '0',
                    '+', '-', '*', '/', '='
                };

        public char[] stockEncoding = // Same as stockChars, but removes dangerous chars just for encoding
            new char[]
                {
                    '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
                    '_', '+', '{', '}', '|', ':', '<', '>', '?',
                    '`', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
                    '-', '=', '[', ']', ';', ',', '.', '/',
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                    'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                    'W', 'X', 'Y', 'Z',
                    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                    'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                    'w', 'x', 'y', 'z',
                };



        public Key()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                if (!this.init(0, true))
                {
                    L.err(location, "Failed to init at construct.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        public Key(int numEquivs)
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                if (!this.init(numEquivs, true))
                {
                    L.err(location, "Failed to init with generate random key.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        // init - If numEquivs is greater than zero, a new key will be generated to match
        public bool init(int numEquivs, bool extraLogging)
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                // Intialize outer dictionaries
                this.chars = new Dictionary<char, List<int>>();
                this.mathChars = new Dictionary<char, List<string>>();

                bool generated = false;
                if (numEquivs > 0)
                {
                    generated = initChars(numEquivs);
                    if (!generated)
                    {
                        L.err(location, "Failed to generate a new key on init.");
                    }
                }

                if (extraLogging && !this.logCounts())
                {
                    L.err(location, "Failed to log counts at init.");
                }

                retVal = numEquivs <= 0 || generated;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // numEquiv is number of equivalent valid representations per character.
        // each char will have numEquiv integers, and mathChar will have numEquiv strings.
        public bool initChars(int numEquivs)
        {
            const string location = CLASSNAME + ".initChars";
            bool retVal = false;
            try
            {
                // Hard quit limit, key fails if exceeded
                int retryLimit = 100;

                List<int> usedIntChars = new List<int>();
                List<string> usedSChars = new List<string>();

                // Intialize outer dictionaries
                if (!this.init(0, false))// init without logging counts
                {
                    L.err(location, "Failed to init data before creating random key.");
                    return retVal;
                }

                // Initialize inner lists
                for (int i = 0; i < stockChars.Length; i++)
                {
                    chars.Add(this.stockChars[i], new List<int>());
                }

                for (int i = 0; i < this.stockMathChars.Length; i++)
                {
                    mathChars.Add(this.stockMathChars[i], new List<string>());
                }


                Random r = new Random();
                r.Next(r.Next());

                // Roundrobbin all
                for (int num = 0; num < numEquivs; num++)
                {
                    for (int idx = 0; idx < this.chars.Count; idx++)
                    {
                        char c = this.stockChars[idx];

                        // Check our count anyway
                        if (this.chars[c].Count < numEquivs)
                        {
                            // For now, try upto 100 times, then crash with error
                            int randomNum = -1;
                            for (int retry = 0; retry < retryLimit; retry++)
                            {
                                randomNum = r.Next();
                                if (usedIntChars.IndexOf(randomNum) < 0)
                                {
                                    usedIntChars.Add(randomNum);
                                    this.chars[c].Add(randomNum);
                                    break;
                                }
                            }
                            if (this.chars[c].IndexOf(randomNum) < 0)
                            {
                                L.err(location, "Failed to assign char (" +
                                    c + ") in (" + retryLimit + ") attempts.");
                                return retVal;
                            }
                        }
                    }
                }

                for (int num = 0; num < numEquivs; num++)
                {
                    for (int idx = 0; idx < this.mathChars.Count; idx++)
                    {
                        char c = this.stockMathChars[idx];

                        if (this.mathChars[c].Count < numEquivs)
                        {
                            string s = "";
                            for (int retry = 0; retry < retryLimit; retry++)
                            {
                                s = "";
                                for (int i = 0; i < mathStringLimit; i++)
                                {
                                    int idxChar = r.Next(0, this.stockEncoding.Length);
                                    s += this.stockEncoding[idxChar];
                                }
                                if (s.Length == mathStringLimit)
                                {
                                    if (usedSChars.IndexOf(s) < 0)
                                    {
                                        usedSChars.Add(s);
                                        this.mathChars[c].Add(s);
                                        break;
                                    }
                                }
                            }
                            if (this.mathChars[c].IndexOf(s) < 0)
                            {
                                L.err(location, "Failed to assign math char (" +
                                    c + ") after (" + retryLimit + ") attempts.");
                            }
                        }
                    }
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

        public bool isReadyForFile()
        {
            const string location = CLASSNAME + ".isReadyForFile";
            bool retVal = false;
            try
            {
                retVal =
                    this.keyId >= 0 &&
                    this.keyIdentifier != null &&
                    this.keyIdentifier.Length == 40 &&
                    this.keyPath != null &&
                    this.keyPath.Length > 0;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        public string getFileString()
        {
            const string location = CLASSNAME + ".getFileString";
            string retVal = "";
            try
            {
                if (this.keyPath == null || this.keyPath.Length == 0)
                {
                    L.err(location, "Key path was null or empty at read.");
                    return retVal;
                }
                if (!File.Exists(@keyPath))
                {
                    L.err(location, "File does not exist at read.");
                    return retVal;
                }

                string keyString = File.ReadAllText(@keyPath).Trim();
                if (keyString != null && keyString.Length > 0)
                {
                    retVal = keyString;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fromFile()
        {
            const string location = CLASSNAME + ".fromFile";
            bool retVal = false;
            try
            {
                // Initialize class level data
                this.chars = new Dictionary<char, List<int>>();
                this.mathChars = new Dictionary<char, List<string>>();

                // Get text from file
                string sFromFile = this.getFileString();
                if (sFromFile == null || sFromFile.Length == 0)
                {
                    L.err(location, "Failed to read key-string from file.");
                    return retVal;
                }
                //L.l(location, "Key String: " + sFromFile);

                // Get JSON from text
                JObject jKey = null;
                try
                {
                    jKey = JObject.Parse(sFromFile);
                }
                catch (Exception exConv) { }

                retVal = this.fromJObject(jKey);
                if (!retVal)
                {
                    L.err(location, "Failed to read key from storage format.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fromJObject(JObject jKey)
        {
            const string location = CLASSNAME + ".fromJObject";
            bool retVal = false;
            try
            {
                if (jKey == null || jKey.Count == 0)
                {
                    L.err(location, "Key from file was null or empty.");
                    return retVal;
                }
                if (!jKey.ContainsKey("chars"))
                {
                    L.err(location, "Key from file does not contain characters.");
                    return retVal;
                }
                if (!jKey.ContainsKey("mathChars"))
                {
                    L.err(location, "Key from file does not contain math characters.");
                    return retVal;
                }

                // Get key identity from input
                long id = -1L;
                if (jKey.ContainsKey("keyId"))
                {
                    id = (long)jKey["keyId"];
                }
                else
                {
                    L.err(location, "Filed did not contain a keyId.");
                    return retVal;
                }

                string keyGuid = "";
                if (jKey.ContainsKey("keyIdentifier"))
                {
                    keyGuid = (string)jKey["keyIdentifier"];
                }
                else
                {
                    L.err(location, "File did not contain a keyIdentifier.");
                    return retVal;
                }

                // Get key characters from input
                JObject jChars = null;
                JObject jMathChars = null;
                try
                {
                    jChars = (JObject)jKey["chars"];
                    jMathChars = (JObject)jKey["mathChars"];
                }
                catch (Exception exConv) { }
                if (jChars == null || jMathChars == null)
                {
                    L.err(location, "Failed to retrieve chars or math chars from file data.");
                    return retVal;
                }

                L.l(location, "Import characters (" + jChars.Count + ") and math characters (" +
                    jMathChars.Count + ") into key (" + id + ").");

                // Setup temporary data and counts
                Dictionary<char, List<int>> tChars = new Dictionary<char, List<int>>();
                Dictionary<char, List<string>> tMathChars = new Dictionary<char, List<string>>();

                int cntInChar = 0;
                int cntInMathChars = 0;
                int cntOutChar = 0;
                int cntOutMathChars = 0;

                // Iterate chars into temp data
                List<string> charKeys = jChars.Properties().Select(p => p.Name).ToList();
                for (int i = 0; i < charKeys.Count; i++)
                {
                    char c = charKeys[i].ToCharArray()[0];
                    tChars.Add(c, new List<int>());
                    JArray jarr = (JArray)jChars[charKeys[i]];

                    for (int j = 0; j < jarr.Count; j++)
                    {
                        tChars[c].Add((int)jarr[j]);
                    }

                    cntInChar += jarr.Count;
                    cntOutChar += tChars[c].Count;
                }
                if (cntInChar != cntOutChar)
                {
                    L.err(location, "Character counts do not match, input (" + cntInChar + "), output (" + cntOutChar +").");
                    return retVal;
                }

                // Iterate mathChars into temp data
                List<string> mathKeys = jMathChars.Properties().Select(p => p.Name).ToList();
                for (int i = 0; i < mathKeys.Count; i++)
                {
                    char c = mathKeys[i].ToCharArray()[0];
                    tMathChars.Add(c, new List<string>());
                    JArray jarr = (JArray)jMathChars[mathKeys[i]];

                    for (int j = 0; j < jarr.Count; j++)
                    {
                        tMathChars[c].Add((string)jarr[j]);
                    }

                    cntInMathChars += jarr.Count;
                    cntOutMathChars += tMathChars[c].Count;
                }
                if (cntInMathChars != cntOutMathChars)
                {
                    L.err(location, "Math character count mismatch, input (" + cntInMathChars + "), output (" + cntOutMathChars + ").");
                }

                // Update class level objects
                this.keyId = id;
                this.keyIdentifier = keyGuid;
                this.chars = tChars;
                this.mathChars = tMathChars;

                L.l(location, "Imported chars (" + this.chars.Count + "), math chars(" + this.mathChars.Count + "), into key (" + this.keyId + ").");

                // Flag success
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public long toFile()
        {
            const string location = CLASSNAME + ".toFile";
            long retVal = -1L;// bytes written to output, negative for error condition
            try
            {
                if (!this.isReadyForFile())
                {
                    L.err(location, "Key is incomplete/not ready for file.");
                    return retVal;
                }

                JObject jKey = this.toJObject();
                if (jKey == null)
                {
                    L.err(location, "Failed converting to JSON.");
                    return retVal;
                }
                if (jKey.Count == 0)
                {
                    L.err(location, "JSON was empty.");
                    return retVal;
                }

                string output = jKey.ToString(Newtonsoft.Json.Formatting.None);
                if (output == null || output.Length <= 2)
                {
                    L.err(location, "Output text was null or empty.");
                    return retVal;
                }

                using (FileStream fs =
                    new FileStream(@keyPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                )
                {
                    try
                    {
                        byte[] temp = Encoding.UTF8.GetBytes(output);
                        fs.Write(temp, 0, temp.Length);
                        retVal = temp.Length;
                    }
                    catch (Exception exStream)
                    {
                        L.err(location, "Stream error: " + exStream.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public JObject toJObject()
        {
            const string location = CLASSNAME + ".toJObject";
            JObject retVal = null;
            try
            {
                // Load chars to json
                JObject jChars = new JObject();
                for (int i = 0; i < this.chars.Count; i++)
                {
                    char c = this.stockChars[i];
                    JArray jarr = new JArray();
                    for (int j = 0; j < this.chars[c].Count; j++)
                    {
                        jarr.Add(this.chars[c][j]);
                    }

                    jChars.Add(Convert.ToString(c), jarr);
                }

                // Load math chars to json
                JObject jMathChars = new JObject();
                for (int i = 0; i < this.mathChars.Count; i++)
                {
                    char c = this.stockMathChars[i];
                    JArray jarr = new JArray();
                    for (int j = 0; j < this.mathChars[c].Count; j++)
                    {
                        jarr.Add(this.mathChars[c][j]);
                    }

                    jMathChars.Add(Convert.ToString(c), jarr);
                }

                // Output Result (all-or-none)
                JObject result = new JObject();
                result.Add("keyId", this.keyId);
                result.Add("keyIdentifier", this.keyIdentifier);
                result.Add("chars", jChars);
                result.Add("mathChars", jMathChars);
                retVal = result;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        public bool logCounts()
        {
            const string location = CLASSNAME + ".logCounts";
            bool retVal = false;
            try
            {
                L.l(location, 
                    "Key Counts - " + 
                    "stockChars(" + this.stockChars.Length + 
                    "), stockMathChars(" + this.stockMathChars.Length + 
                    "), stockEncodingChars(" + this.stockEncoding.Length + 
                    "), chars (" + this.chars.Count + 
                    "), mathChars (" + this.mathChars.Count + ").");

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
    }
}
