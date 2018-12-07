using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Fabric
    {
        //#1 @ 872,519: 18x18
        public string Input { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public int XCoordOffset { get; set; }

        public int YCoordOffset { get; set; }

        public int FabricSize { get; set; }


        public Fabric(string input)
        {
            input = input.Replace(',', ' ');
            input = input.Replace('@', ' ');
            input = input.Replace(':', ' ');
            input = input.Replace('x', ' ');
            var escapedInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.Input = escapedInput[0];
            this.XCoord = Int32.Parse(escapedInput[1]);
            this.YCoord = Int32.Parse(escapedInput[2]);
            this.XCoordOffset = Int32.Parse(escapedInput[3]) + XCoord - 1;
            this.YCoordOffset = Int32.Parse(escapedInput[4]) + YCoord - 1;
            this.FabricSize = XCoordOffset * YCoordOffset;

            var a = "b";
        }
    }
}
