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
                bool noException = true;

                try
                {
                    ConsoleOperations.VerifyFormat(File.ReadAllLines(args[0]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Path.GetFileName(args[0]) + ": " + ex.Message);
                    noException = false;
                }

                if (noException)
                {
                    try
                    {
                        ConsoleOperations.ReadArgs(args);
                    }
                    catch (InputFormatException)
                    {
                        Console.WriteLine(Path.GetFileName(args[0]) + ": " + "Shape declaration is incorrect or id does not belong to a known element");
                    }
                }
            }
            else
            {
                ConsoleOperations.ReadFromConsole();
            }
        }
    }
}