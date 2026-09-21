using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRegionAnalysis2
{
    public class CompareString
    {
        public const string CLASSNAME = "CompareString";


        string in1 = "";
        string in2 = "";

        char[] c1 = null;// longest
        char[] c2 = null;// shortest

        char[] matches = null;

        int[] offsets = null;

        bool[] complete = null;

        const char cnull = '*';


        public CompareString(string s1, string s2)
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }


        public bool init(string s1, string s2) 
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                if (s1 == null || s2 == null)
                {
                    // TODO - Think about finishing with the other, all matches
                    L.err(location, "One or more input strings were null.");
                    return retVal;
                }

                if (s1.Length > s2.Length)
                {
                    this.in1 = s1;// longest
                    this.in2 = s2;
                }
                else 
                {
                    this.in1 = s2;// longest
                    this.in2 = s1;
                }
                int maxLength = s1.Length;

                // Initalize storage to cnull
                this.c1 = new char[maxLength];
                this.c2 = new char[maxLength];
                this.matches = new char[maxLength];
                this.offsets = new int[maxLength];
                this.complete = new bool[maxLength];
                for (int i = 0; i < maxLength; i++)
                {
                    this.c1[i] = cnull; 
                    this.c2[i] = cnull; 
                    this.matches[i] = cnull;
                    this.offsets[i] = -1;
                    this.complete[i] = false;
                }

                // Copy input strings to fixed length arrays
                {
                    char[] arr1 = this.in1.ToCharArray();
                    for (int i = 0; i < arr1.Length && i < this.c1.Length; i++) this.c1[i] = arr1[i];

                    char[] arr2 = this.in2.ToCharArray();
                    for (int i = 0; i < arr2.Length && i < this.c2.Length; i++) this.c2[i] = arr2[i];
                }

                // Because arr2 is smaller, slide it right in arr1, perhaps for a while after it runs out of room
                //for (int idx1 = 0;)
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }






    }
}
