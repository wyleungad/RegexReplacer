using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexReplacer
{
    internal class Program
    {
        const int ARRAY_LENGTH = 5;
        static void Main(string[] args)
        {
            string inputString = System.IO.File.ReadAllText(@".\regexInput.txt");
            string regexReplacement = "";
            String output = inputString;
            int i = 0;
            foreach (string regexRule in System.IO.File.ReadLines(@".\regexRule.txt"))
            {
                if (regexRule != "")
                {
                    // Input strings.

                    regexReplacement = System.IO.File.ReadLines(@".\regexReplacement.txt").ElementAt<String>(i);
                    Console.WriteLine("regexRule = " + regexRule);
                    Console.WriteLine("regexReplacement = " + regexReplacement);

                    output = RegexReplace(output, regexRule, regexReplacement);
                    i++;
                }
            }

            FileStream f = new FileStream(@".\regexOutput.txt", FileMode.Create);
            StreamWriter s = new StreamWriter(f);

            // Write output strings.
            s.Write(output);
            //Console.WriteLine(output);
            s.Close();
            f.Close();

            Console.ReadLine();
        }

        static string RegexReplace(string s, string regex, string replacement)
        {
            return Regex.Replace(s, regex, replacement);
        }
        
    }
}
