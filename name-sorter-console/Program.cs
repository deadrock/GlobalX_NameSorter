using System;
using name_sorter_ClassLibrary1;

namespace name_sorter_console
{
    class Program
    {
        private const string OutputPath = "sorted-names-list.txt";

        static int Main(string[] args)
        {
            if ( args.Length != 1 || args[0] == "/?")
            {
                Usage();
                return -2;
            }

            var allNames = new FullnameCollection(args[0]);

            // get each name (sorted by Lastname, Givennames) and output each line to console and to file.
            using (var outputStream = new System.IO.StreamWriter(OutputPath))
            {
                foreach (var name in allNames.ByLastnameGivenname)
                {
                    Console.WriteLine(name.ToString());
                    outputStream.WriteLine(name.ToString());
                }
            }
            return 0;
        }

        static void Usage()
        {
            var executable = Environment.GetCommandLineArgs()[0];
            Console.Error.WriteLine($"{executable} InputFilePath");
        }
    }
}
