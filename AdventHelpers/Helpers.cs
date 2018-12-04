using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventHelpers
{
    public static class Helpers
    {

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
