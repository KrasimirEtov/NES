using NES.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Core.Providers
{
    static public class IOStream
    {
        public static IEnumerable<string> ReadLine(string filename)
        {
            using (StreamReader sr = new StreamReader($"../../../{filename}"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        
        public static void WriteLine(string message, string filename)
        {
            using (StreamWriter sr = new StreamWriter($"../../{filename}", true))
            {
                sr.Write(message);
            }
        }
    }
}
