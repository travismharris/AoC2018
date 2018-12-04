using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventHelpers;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = Helpers.FetchInput("../../../Input/Day2Input.txt");
            var inputArray = rawInput.Split('\n');
            var inputList = inputArray.ToList();
           // inputList = new List<string>(){ "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };

            int twoferCount = 0;
            int threeferCount = 0;

            foreach(var s in inputArray)
            {
                twoferCount += GetTwofer(s);
                threeferCount += GetThreefer(s);
            }

            //Console.Write("\nTwofers: " + twoferCount + "  Threefers: " + threeferCount);
            //Console.Write("\t twoferCount * threeferCount = " + twoferCount * threeferCount);
            var a = GetCommonLetters(inputList);
            Console.WriteLine(a);
            Console.ReadKey();
        }

        public static string GetCommonLetters(List<string> inputList)
        {
            while(inputList.Count > 2)
            {
                var searchSubject = inputList.First();
                
                inputList.RemoveAt(0);
                foreach(var s in inputList)
                {
                    var diffCount = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != searchSubject[i])
                        {
                            diffCount++;
                            if (diffCount > 1)
                                break;
                        }
                    }
                    if(diffCount==1)
                    {
                        return searchSubject + " ~ " + s;
                    }
                }
            }
            return "Error";
        }

        public static int GetTwofer(string s)
        {
            if (CheckTwo(s) == "two")
                return 1;
            return 0;
        }

        public static string CheckTwo(string s)
        {
            var unique = s.Distinct().ToArray();
            if (s.Length > unique.Length)
            {
                foreach (var c in unique)
                {
                    var charCount = s.Count(a => a == c);
                    if (charCount == 2)
                        return "two";
                }
            }
            return "none";
        }

        public static string CheckThree(string s)
        {
            var unique = s.Distinct().ToArray();
            if (s.Length > unique.Length)
            {
                foreach (var c in unique)
                {
                    var charCount = s.Count(a => a == c);
                    if (charCount == 3)
                        return "three";
                }
            }
            return "none";
        }

        public static int GetThreefer(string s)
        {
            if (CheckThree(s) == "three")
                return 1;
            return 0;
        }

        
    }
}
