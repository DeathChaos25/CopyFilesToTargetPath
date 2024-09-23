using System;
using System.Collections.Generic;
using System.IO;

namespace CopyFilesToTargetPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("CopyFilesToTargetPath:\nUsage: Drag and drop a file into the program, the following operations will be done:\n" +
                    "- the program will look for target (relative) paths where the input file originates from on a target_paths.txt file\n" +
                    "- the program will save all files in the input file directory that have the same extension as the input file\n" +
                    "- the files will then be copied to every path located in target_paths");
                return;
            }

            string inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string inputDirectory = Path.GetDirectoryName(inputFile);
            string fileExtension = Path.GetExtension(inputFile);

            List<string> filesList = new List<string>(Directory.GetFiles(inputDirectory, "*" + fileExtension));

            string targetPathsFile = Path.Combine(inputDirectory, "target_paths.txt");
            if (!File.Exists(targetPathsFile))
            {
                Console.WriteLine("target_paths.txt not found.");
                return;
            }

            List<string> targetPaths = new List<string>(File.ReadAllLines(targetPathsFile));


            foreach (string file in filesList)
            {
                string fileName = Path.GetFileName(file);

                foreach (string targetPath in targetPaths)
                {
                    string fullTargetPath = Path.Combine(inputDirectory, targetPath);

                    Directory.CreateDirectory(fullTargetPath);

                    string destinationFile = Path.Combine(fullTargetPath, fileName);
                    try
                    {
                        File.Copy(file, destinationFile, overwrite: true);
                        Console.WriteLine($"Copied {fileName} to {fullTargetPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to copy {fileName} to {fullTargetPath}: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("File copy operation completed.");
        }
    }

}
