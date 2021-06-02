using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {            
            if(args.Length > 0)
            {
                ConsoleOperations.ReadArgs(args);
            }
            else
            {
                ConsoleOperations.ReadFromConsole();
            }
        }
    }
}