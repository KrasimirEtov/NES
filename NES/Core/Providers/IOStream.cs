using NES.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Core.Providers
{
    static public class IOStream
    {
        public static IEnumerable<string> ReadLine(string fileName)
        {
            using (StreamReader sr = new StreamReader($"../../../{fileName}.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        
        public static void WriteLine(string message, string fileName)
        {
			using (StreamWriter sw = new StreamWriter($"../../../{fileName}.txt", true))
			{
				sw.WriteLine(message);
			}
        }
    }
}
