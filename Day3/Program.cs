using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = File.ReadAllText("../../../Input/day3Input.txt");
            var inputLines = rawInput.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //var inputLines = new String[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            string[,] array = new string[1000, 1000];
            List<Fabric> fabrics = new List<Fabric>();

            foreach (var s in inputLines)
            {
                Fabric f = new Fabric(s);
                fabrics.Add(f);
                for (int row = (f.YCoord); row <= f.YCoordOffset; row++)
                {
                    for (int col = (f.XCoord); col <= f.XCoordOffset; col++)
                    {
                        array[row, col] += f.Input;
                    }

                }
            }


            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    var test = array[i, j];
                    if (test != null)
                    {
                        if (test.Count(a => a == '#') > 1)
                        {
                            var fabricToRemove = test.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            foreach (var d in fabricToRemove)
                            {
                                fabrics.Remove(fabrics.SingleOrDefault(z => z.Input == ("#" + d)));
                            }
                        }
                    }
                }
            }
            Console.WriteLine(fabrics.FirstOrDefault().Input);

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        var whatToWrite = GetIt(array[i, j]);
            //        Console.Write(whatToWrite);
            //    }
            //    Console.WriteLine();
            //}



            var multiCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (array[i, j] != null)
                    {
                        if (array[i, j].Count(a => a == '#') > 1)
                            multiCount++;
                    }
                }
            }

            Console.WriteLine("Multicount = " + multiCount);


        }

        public static string GetIt(string s)
        {
            if (s == null)
                return "@";
            if (s.Count(a => a == '#') > 1)
                return "M";
            if (s.Count(a => a == '#') == 1)
            {
                return s.Replace('#', ' ').Trim();
            }

            return "%";
        }



        //#1 @ 872,519: 18x18
    }
}
