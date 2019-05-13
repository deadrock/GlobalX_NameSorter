using System;
using name_sorter_ClassLibrary1;

namespace name_sorter_console
{
    class Program
    {
        private const string OutputPath = "sorted-names-list.txt";

        /// <summary>
        /// Reads a file containing names (one name per line) Sorts them and outputs to new file and to the console.
        /// </summary>
        /// <param name="args">args[0] should be the name of the file to read</param>
        /// <returns></returns>
        static int Main(string[] args)
        {
            if (args.Length != 1 || args[0] == "/?" || args[0].Length == 0 )
            {
                Usage();
                return -2;
            }

            var inputFilepath = args[0];  // 

            var service = new FullnameCollectionService();

            // Load the data
            var allNames = service.LoadFromFile(args[0]);

            // sort the data
            allNames = service.SortByLastnameGivenname(allNames);

            // output the data
            service.WriteToStream(allNames, Console.Out);
            service.WriteToFile(allNames, OutputPath);
                       
            return 0;
        }

        static void Usage()
        {
            var executable = Environment.GetCommandLineArgs()[0];
            Console.Error.WriteLine($"{executable} InputFilePath");
        }
    }
}
