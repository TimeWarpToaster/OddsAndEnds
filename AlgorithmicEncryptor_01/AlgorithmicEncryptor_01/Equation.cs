//Algorithmic Encryptor v01
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections.Generic;

namespace AlgorithmicEncryptor_01
{
    public class Equation
    {
        public const string CLASSNAME = "Equation";


        // Every number is followed by an operator, the last being equals (/terminator)
        public int value = -1;
        public List<int> nums = new List<int>();
        public List<char> ops = new List<char>();
        public int solution = -1;

        public int minIntermediate = 0;
        public int maxIntermediate = Int32.MaxValue / 4;

        public char[] MathOperators = new char[] { '+', '-', '*', '/' };

        public Equation() { }

        public bool fromNumber(int value, int numberOfOps, Random r)
        {
            const string location = CLASSNAME + ".fromNumber";
            bool retVal = false;
            try
            {
                this.nums = new List<int>();
                this.ops = new List<char>();

                List<int> tnums = new List<int>();
                List<char> tops = new List<char>();

                int marginToDivide = Int32.MaxValue / 3; // > 2
                int marginToMutliply = Int32.MaxValue / 3;
                int marginToAdd = Int32.MaxValue - 2;
                int marginToSubtract = 10;

                // Keep track of the equation value
                long runningNumber = -1L;

                int lastNumber = -1; // Always positive, negative is a minus operator
                for (int i = 0; i < numberOfOps; i++)
                {
                    // If this is the last iteration, cleanup with return to value
                    // This isn't fair, but level off equations with + or - to be simple
                    // if it is a problem, take care of it with more equivs for these
                    if (i == numberOfOps - 1)
                    {
                        if (lastNumber < 0)
                        {
                            L.err(location, "Last number invalid at equals.");
                            return retVal;
                        }

                        int diff = 0;
                        if (runningNumber > value)
                        {
                            diff = (int)runningNumber - value;
                            tops.Add('-');
                            tnums.Add(diff);
                        }
                        else
                        {
                            diff = value - (int)runningNumber;
                            tops.Add('+');
                            tnums.Add(diff);
                        }

                        tops.Add('=');
                        break;// Finished building
                    }

                    // This is not the last iteration, so proceed

                    if (lastNumber < 0)
                    {
                        // First iteration, add a random number to list and proceed
                        lastNumber = r.Next();
                        runningNumber = lastNumber;
                        tnums.Add(lastNumber);
                    }

                    // Work the middle of equation
                    // Figure out which operations are safe, based upon the value
                    List<char> tsafeOps = new List<char>();
                    if (runningNumber < marginToAdd) tsafeOps.Add('+');
                    if (runningNumber > marginToSubtract) tsafeOps.Add('-');

                    // To reenable multiplication and division as options, uncomment below.
                    // Multiplication was getting too far out of bounds for the equation to 
                    // self-correct. Division had an occasional small rounding difference.
                    //if (runningNumber < marginToMutliply) tsafeOps.Add('*');
                    //if (runningNumber > marginToDivide) tsafeOps.Add('/');

                    char[] safeOps = tsafeOps.ToArray();
                    if (safeOps == null || safeOps.Length == 0)
                    {
                        L.err(location, "Available operators was null or empty for lastNum (" + lastNumber + ").");
                        return retVal;// hard error
                    }

                    //string sSafeOps = "";
                    //for (int j = 0; j < safeOps.Length; j++) sSafeOps += safeOps[j];
                    //L.l(location, "Safe Ops (" + sSafeOps + ").");

                    int idxOpList = r.Next(0, safeOps.Length);
                    char op = safeOps[idxOpList];

                    switch (op)
                    {
                        case '+':
                            {
                                int currentNumber = r.Next(0, Int32.MaxValue - lastNumber);
                                tops.Add('+');
                                tnums.Add(currentNumber);
                                runningNumber += currentNumber;
                                lastNumber = currentNumber;
                            }
                            break;
                        case '-':
                            {
                                int currentNumber = r.Next(0, lastNumber);
                                tops.Add('-');
                                tnums.Add(currentNumber);
                                runningNumber -= currentNumber;
                                lastNumber = currentNumber;
                            }
                            break;
                        case '*':
                            {
                                int maxMultiplier = Int32.MaxValue - 1;
                                if (runningNumber > 0) maxMultiplier = Int32.MaxValue / (int)runningNumber | 0;
                                int currentNumber = r.Next(0, maxMultiplier);
                                tops.Add('*');
                                tnums.Add(currentNumber);
                                runningNumber *= currentNumber;
                                lastNumber = currentNumber;
                            }
                            break;
                        case '/':
                            {
                                // allow dividing by upto half current value
                                int maxDivisor = (int)((runningNumber / 2) | 0);
                                int currentNumber = 1;// prevent divide by zero
                                if (maxDivisor > 1) currentNumber = r.Next(1, maxDivisor);
                                tops.Add('/');
                                tnums.Add(currentNumber);
                                //L.l(location, "Running Val (" + runningNumber + "), Current Number (" + currentNumber + ").");
                                runningNumber = (int)((runningNumber / currentNumber) | 0);
                                lastNumber = currentNumber;
                            }
                            break;
                        default:
                            L.err(location, "Unknown operator (" + ((int)op) + ").");
                            return retVal;
                    }

                }


                if (tnums.Count == 0 || tops.Count == 0)
                {
                    L.err(location, "Numbers or operators was null.");
                }
                else if (tnums.Count != tops.Count)
                {
                    L.err(location, "Invalid equation, numbers (" + tnums.Count + "), operators (" + tops.Count + ").");
                }
                else
                {
                    this.nums = tnums;
                    this.ops = tops;

                    // Flag success
                    retVal = true;
                }


                /*// TODO - Remove debug section
                if (this.nums != null)
                    for (int i = 0; i < this.nums.Count; i++)
                        L.l(location, "Number (" + i + "): " + this.nums[i]);
                if (this.ops != null)
                    for (int i = 0; i < this.ops.Count; i++)
                        L.l(location, "Ops (" + i + "): " + this.ops[i]);*/

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fromString(string eqIn)
        {
            const string location = CLASSNAME + ".fromString";
            bool retVal = false;
            try
            {
                if (eqIn == null || eqIn.Length == 0)
                {
                    L.err(location, "Text equation in was null or empty.");
                    return retVal;
                }

                List<string> parts = new List<string>();
                char[] chars = eqIn.ToCharArray();
                string word = "";
                char[] ops = new char[] { '+', '-', '*', '/', '=' };
                for (int i = 0; i < chars.Length; i++)
                {
                    bool isOp =
                        chars[i] == '+' ||
                        chars[i] == '-' ||
                        chars[i] == '*' ||
                        chars[i] == '/' ||
                        chars[i] == '=';

                    if (isOp)
                    {
                        if (word.Length > 0)
                        {
                            parts.Add(word);
                            word = "";
                            parts.Add(Convert.ToString(chars[i]));
                            continue;
                        }
                    }
                    word += chars[i];
                }


                // Expect alternating num->op->num->op..End
                this.nums = new List<int>();
                this.ops = new List<char>();

                List<int> tnums = new List<int>();
                List<char> tops = new List<char>();

                bool onNum = true;
                bool hasError = false;
                for (int i = 0; i < parts.Count; i++)
                {
                    if (onNum)
                    {
                        try
                        {
                            int num = Convert.ToInt32(parts[i]);
                            tnums.Add(num);
                        }
                        catch (Exception exConv)
                        {
                            L.err(location, "Conversion error for num (" + parts[i] + "): " + exConv.Message);
                            hasError = true;
                        }
                        onNum = false;
                        if (hasError) return retVal;
                    }
                    else
                    {
                        try
                        {
                            char op = Convert.ToChar(parts[i]);
                            tops.Add(op);
                        }
                        catch (Exception exConv)
                        {
                            L.err(location, "Conversion error for op (" + parts[i] + "): " + exConv.Message);
                            hasError = true;
                        }
                        onNum = true;
                        if (hasError) return retVal;
                    }
                }

                if (tnums.Count > 0 && tops.Count > 0 && tnums.Count == tops.Count)
                {
                    this.nums = tnums;
                    this.ops = tops;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public int solveForValue()
        {
            const string location = CLASSNAME + ".solveForValue";
            int retVal = -1;
            try
            {
                if (this.nums == null || this.nums.Count == 0)
                {
                    L.err(location, "Numbers was null at solve.");
                    return retVal;
                }
                if (this.ops == null || this.ops.Count == 0)
                {
                    L.err(location, "Ops was null at solve.");
                    return retVal;
                }
                if (this.nums.Count != this.ops.Count)
                {
                    L.err(location, "Count of numbers (" + this.nums.Count + ") does not match ops (" + this.ops.Count + ").");
                    return retVal;
                }


                int runningVal = 0;
                char currentOperator = ' ';
                for (int i = 0; i < this.nums.Count; i++)
                {
                    if (i == 0)
                    {
                        runningVal = this.nums[i];
                        currentOperator = this.ops[i];
                        continue;
                    }

                    int num = this.nums[i];
                    switch (currentOperator)
                    {
                        case '+':
                            {
                                runningVal += num;
                            }
                            break;
                        case '-':
                            {
                                runningVal -= num;
                            }
                            break;
                        case '*':
                            {
                                runningVal *= num;
                            }
                            break;
                        case '/':
                            {
                                // Divisor is carefully managed at construction. There is no safe 
                                // way to protect against / 0 here, without changing outcome.
                                // Needs to fail.
                                if (num == 0) return retVal;
                                runningVal = (int)((runningVal / num) | 0);
                            }
                            break;
                        default:
                            {
                                L.err(location, "Unknown operator (" + currentOperator + ").");
                                return retVal;
                            }
                    }

                    currentOperator = this.ops[i];
                    if (currentOperator == '=')
                    {
                        // Finished
                        retVal = runningVal;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

    }
}
