using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class DownloadFileCommand
    {
        public static void DownloadFile(string fileName, string path)
        { 
            string pathForStorage = ConfigurationManager.AppSettings["Storage"] + @"\" + fileName;
            string newPath = path + @"\" + fileName;
             
            FileInfo fileInf = new FileInfo(pathForStorage);

                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, false);
                    Console.WriteLine($"\nThe file '{fileName}' has been downloaded");
                }
                else Console.WriteLine("\nFile not find!");
        }
    }
}
