using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class GuardLogWithId
    {
        //[1518-10-13 00:51] falls asleep
        //[1518-05-31 00:53] wakes up
        public DateTime Time { get; set; }
        public string Entry { get; set; }
        public int GuardId { get; set; }



        public override string ToString()
        {
            return "GuardId: " + GuardId + " " + Time.ToString() + " " + Entry;
        }
    }
}
