using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = FetchInput("../../../Input/Day1Input.txt");
            var inputArray = rawInput.Split('\n');
            var frequencyChanges = new Dictionary<long, string>();
            Int64 runningTotal = 0;
            Int64 repeatedValue = 0;
            int howManyRuns = 0;

            while (repeatedValue == 0)
            {
                howManyRuns++;
                foreach (var a in inputArray)
                {
                    var val = Int64.Parse(a);
                    Console.Write("val = " + val + " old runningTotal = " + runningTotal + ".  ");
                    runningTotal += val;
                    Console.Write("Now runningTotal is " + runningTotal + ".\n");
                    if (frequencyChanges.ContainsKey(runningTotal))
                    {
                        Console.WriteLine("\nFirst repeat value is " + runningTotal);
                        repeatedValue = runningTotal;
                        break;
                    }
                    frequencyChanges.Add(runningTotal, a);
                }
            }

            var stopbeforeexit = "hi";
        }

        public static string FetchInput(string inputPath)
        {
            string text;
            var fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }

    }
}
