using AdventHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = Helpers.FetchInput("../../../Input/Day5Input.txt");
            //var rawInput = "dabAcCaCBAcCcaDA";

            Console.WriteLine("Input length = " + rawInput.Length);

            for (int outter = 65; outter < 91; outter++)
            {
                char upper = (char)outter;
                char lower = (char)(outter + 32);

                var rawInput2 = rawInput.ToArray().ToList();
                rawInput2.RemoveAll(a => a == upper);
                rawInput2.RemoveAll(a => a == lower);

                var rawInput3 = new string(rawInput2.ToArray());

                var run = true;
                while (run)
                {
                    for (int i = 0; i < rawInput3.Length - 1; i++)
                    {
                        var testLength = rawInput3.Length;
                        if (SameLetter(rawInput3[i].ToString(), rawInput3[i + 1].ToString()))
                        {
                            if (DifferentCase(rawInput3[i], rawInput3[i + 1]))
                            {
                                //Console.WriteLine("RawInput before removal: "+ rawInput);
                                rawInput3 = rawInput3.Remove(i, 1);
                                rawInput3 = rawInput3.Remove(i, 1);
                                //Console.WriteLine("RawInput after removal:  " + rawInput);
                                break;
                            }
                        }
                        if (i == (testLength - 2))
                            run = false;
                    }
                }
                Console.WriteLine("Letter " + upper + ": Yields Length of " + rawInput3.Length);
            }

            //Console.WriteLine("-----------------------------------------------\nRawInput processed:  " + rawInput + "  Remaining Units = " + rawInput.Length);
            //Console.WriteLine("Length:  " + rawInput.Length);
        }

        public static bool SameLetter(string a, string b)
        {
            if (a.ToUpper() == b.ToUpper())
                return true;

            return false;
        }

        public static bool DifferentCase(char a, char b)
        {
            return !(a == b);
        }
    }
}
