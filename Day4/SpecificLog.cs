using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class SpecificLog
    {
        public int GuardId { get; set; }
        public List<GuardLogWithId> Logs { get; set; }
        public int SleepTime { get; set; }
        public int[] Minutes { get; set; }
        public int MostPopularMinute { get; set; }
        public int Occurences { get; set; }

        public SpecificLog(List<GuardLogWithId> logs)
        {
            this.Logs = logs;
            this.GuardId = logs.First().GuardId;
            this.SleepTime = GetSleepTime();
            this.Minutes = DetermineMinutes();
            this.Occurences = Minutes.Max();
            this.MostPopularMinute = Minutes.ToList().IndexOf(Occurences);
        }

        public int GetSleepTime()
        {
            var totalSleep = 0;
            for(int i = 0; i < Logs.Count-2; i+=2)
            {
                TimeSpan span = Logs[i + 1].Time - Logs[i].Time;
                totalSleep += span.Minutes;
            }
            return totalSleep;
        }

        public int[] DetermineMinutes()
        {
            var array = new int[61];
            for(int i = 0; i < Logs.Count-1; i += 2)
            {
                var sleep = Logs[i].Time.Minute;
                var wake = Logs[i+1].Time.Minute;
                if (wake == 0)
                    wake = 60;

                for(int j = sleep; j < wake; j++)
                {
                    array[j] += 1;
                }
            }
            return array;
        }

        public override string ToString()
        {
            return "GuardId: " + GuardId + " totalSleep: " + SleepTime + " Count: " + Occurences + " Minute: " + MostPopularMinute;

        }

    }
}
