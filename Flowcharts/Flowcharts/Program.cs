using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {            
            if(args.Length > 0)
            {
                ConsoleOperations.VerifyFormat(File.ReadAllLines(args[0]));
                ConsoleOperations.ReadArgs(args);
            }
            else
            {
                ConsoleOperations.ReadFromConsole();
            }
        }
    }
}