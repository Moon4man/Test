using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class FindFileCommand
    {
        public static void FindFile(string fileName)
        {
            try
            {
                foreach (string findFile in Directory.EnumerateFiles(ConfigurationManager.AppSettings["Storage"],
                    fileName, SearchOption.AllDirectories))
                {
                    FileInfo fileInf = new FileInfo(findFile);
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
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("\nDirectory not found! \n Resons: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong. Try again, please!\n Resons: " + ex.Message);
            }
        }
    }
}
