using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using CommandLine;

namespace FileStorage.Commands.ProgramCommands
{
    class MoveFileCommand
    {
        public static void MoveFile(string oldName, string newName)
        {
            string path = ConfigurationManager.AppSettings["Storage"] + @"\" + oldName;
            string newPath = ConfigurationManager.AppSettings["Storage"] + @"\" + newName;

            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
                Console.WriteLine($"\nThe file '{oldName}' has been moved to '{newName}'");
            }
            else Console.WriteLine("\nFile not find!");
        }
    }
}
