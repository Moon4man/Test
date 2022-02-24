using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class RemoveFileCommand
    {
        public static void RemoveFile(string fileName)
        {
            string path = ConfigurationManager.AppSettings["Storage"] + @"\" + fileName;

            FileInfo fileInf = new FileInfo(path);

                if (fileInf.Exists)
                {
                    fileInf.Delete();
                    Console.WriteLine($"\nThe file {fileName} has been removed");
                }
                else Console.WriteLine("\nFile not find!");
        }
    }
}
