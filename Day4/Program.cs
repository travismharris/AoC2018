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

            foreach(var input in inputArray)
            {
                logs.Add(new GuardLog(input));
            }

            logs = logs.OrderBy(l => l.Time).ToList();

            var GuardIdIndicies = new List<int>();
            int a = 0;
            do
            {
                a = logs.FindIndex(a, b => b.Entry.Contains("#"));
                if(a!=-1)
                    GuardIdIndicies.Add(a);
                a++;
            } while (a > 0);

            var LogsWithIds = new List<GuardLogWithId>();

            for(int i = 0; i < (GuardIdIndicies.Count-1); i++)
            {
                var temp = logs.GetRange(GuardIdIndicies[i], (GuardIdIndicies[i + 1] - GuardIdIndicies[i]));
                var id = GetGuardId(temp.First().Entry);
                foreach(var item in temp)
                {
                    LogsWithIds.Add(new GuardLogWithId() { Entry = item.Entry, GuardId = id, Time = item.Time });
                }
            }
            var temp2 = logs.GetRange(GuardIdIndicies.Last(), logs.Count - GuardIdIndicies.Last());
            var id2 = GetGuardId(temp2.First().Entry);
            foreach (var item in temp2)
            {
                LogsWithIds.Add(new GuardLogWithId() { Entry = item.Entry, GuardId = id2, Time = item.Time });
            }

            LogsWithIds = LogsWithIds.OrderBy(l => l.GuardId).ThenBy(l => l.Time).ToList();

            LogsWithIds.RemoveAll(rem => rem.Entry.Contains("#"));
            //[1518-10-13 00:51] falls asleep
            //[1518-05-31 00:53] wakes up

            var finalList = new List<SpecificLog>();

            while (LogsWithIds.FirstOrDefault() != null)
            {
                var myId = LogsWithIds.First().GuardId;
                var logList = LogsWithIds.Where(c => c.GuardId == myId);
                finalList.Add(new SpecificLog(logList.ToList()));
                LogsWithIds.RemoveAll(remove => remove.GuardId == myId);
            }

            foreach (var f in finalList)
            {
                Console.WriteLine(f);
            }
        }

        public static int GetGuardId(string entry)
        {
            entry = entry.Trim();
            var parts = entry.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var id = parts[1];
            return int.Parse(id.Replace("#", ""));
        }
    }
}
