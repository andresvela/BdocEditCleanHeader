using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine.Utility;
using System.IO;

namespace BdocEditCleanHeader
{
    class Program
    {
        private static String ReplaceFirst(String text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        static void Main(string[] args)
        {
             Arguments CommandLine = new Arguments(args);

             if (CommandLine["top"] == null && CommandLine["bottom"] == null &&  CommandLine["file"] == null)
             {
                 System.Console.WriteLine("BdocEditCleanHeader Parameters: .");
                 System.Console.WriteLine("-top  : Xml to find top header");
                 System.Console.WriteLine("-bottom  : Xml to find bottom header");
                 System.Console.WriteLine("-file  : Xml to find bottom header");
                 return;
             }
             else {

                 String strFile = File.ReadAllText(CommandLine["file"]);

                 strFile = Program.ReplaceFirst(strFile, CommandLine["top"], "");
                 strFile = Program.ReplaceFirst(strFile, CommandLine["bottom"], "");

                 File.WriteAllText(CommandLine["file"], strFile);            
             
             }
        }

        
    }
}
