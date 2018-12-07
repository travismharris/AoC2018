using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class InstructionSet
    {
        public SortedDictionary<char, string> Instructions { get; set; }

        public InstructionSet()
        {
            Instructions = new SortedDictionary<char, string>();
        }

        public void Add(string input)
        {
            var instruction = input[0];//key
            var precursor = input[2];  //value

            var temp = "";
            if(Instructions.TryGetValue(instruction, out temp))
            {
                var newValue = (temp + precursor).ToArray();
                Array.Sort(newValue);
                                
                Instructions[instruction] = new string(newValue);
            }
            else
            {
                Instructions.Add(instruction, precursor.ToString());
            }
        }
    }
}
