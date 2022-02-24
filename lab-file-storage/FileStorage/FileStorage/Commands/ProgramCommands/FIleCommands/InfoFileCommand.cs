using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class InfoFileCommand
    {
        public static void GetInfo(string fileName)
        {
            string path = ConfigurationManager.AppSettings["Storage"] + @"\" + fileName;

            FileInfo fileInf = new FileInfo(path);
            try
            {
                if (fileInf.Exists)
                {
                    Console.WriteLine($"\nname: {fileInf.Name}\n" +
                                      $"extension: {fileInf.Extension}\n" +
                                      $"file size: {fileInf.Length} byte\n" +
                                      $"creation date: {fileInf.CreationTime.ToString("yyyy-MM-dd")}\n" +
                                      $"login: {ConfigurationManager.AppSettings["login"]}\n" +
                                      $"last access time: {fileInf.LastAccessTime.ToString("yyyy-MM-dd")}");
                }
                else Console.WriteLine("\nFile not find!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong. Try again, please!\n Resons: " + ex.Message);
            }
        }
    }
}
