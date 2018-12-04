using AdventHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = Helpers.FetchInput("../../../Input/Day4Input.txt");
            rawInput = rawInput.Replace("\r", "");
            var inputArray = rawInput.Split('\n');
            List<GuardLog> logs = new List<GuardLog>();
            foreach(var a in inputArray)
            {
                logs.Add(new GuardLog(a));
            }
            //[1518-10-13 00:51] falls asleep
            //[1518-05-31 00:53] wakes up


        }
    }
}
