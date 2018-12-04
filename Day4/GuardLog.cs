using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class GuardLog
    {
        //[1518-10-13 00:51] falls asleep
        //[1518-05-31 00:53] wakes up
        public string Time { get; set; }
        public string Entry { get; set; }

        public GuardLog(string entry)
        {
            var delimiter = entry.IndexOf(']');
            Time = entry.Substring(0, delimiter + 1);
            Entry = entry.Substring(delimiter + 1, (entry.Length - (delimiter + 1)));
        }
    }
}
