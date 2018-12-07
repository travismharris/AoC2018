using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step Q must be finished before step X can begin.
            var rawInput = AdventHelpers.Helpers.FetchInput("../../../Input/Day7Input.txt");
            var rawArray = rawInput.Split(new char[] { '\n' }, StringSplitOptions.None);
            var input = new List<string>();
            foreach(var s in rawArray)
            {
                input.Add(s[5] +" "+ s[36]);
            }

            InstructionSet instructions = new InstructionSet();
            
            input.ForEach(a => instructions.Add(a));

            input.ForEach(a => Console.WriteLine(a));
        }
    }
}
