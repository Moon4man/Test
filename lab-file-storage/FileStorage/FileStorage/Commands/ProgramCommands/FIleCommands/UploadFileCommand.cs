using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class UploadFileCommand
    {
        public static void UploadFile(string path)
        {
            string[] pathFile = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string fileName = pathFile[pathFile.Length - 1];
            string newPath = ConfigurationManager.AppSettings["Storage"] + @"\" + fileName;

            FileInfo fileInf = new FileInfo(path);
            try
            {
                if (fileInf.Exists)
                {
                    if (fileInf.Length < (150 * 1024 * 1024))
                    {
                        fileInf.CopyTo(newPath, false);
                        Console.WriteLine($"\nThe file '{newPath}' has been uploaded");
                        Console.WriteLine($" - name: {fileInf.Name}\n" +
                                          $" - file size: {fileInf.Length} byte\n" +
                                          $" - extension: {fileInf.Extension}");
                    }
                    else Console.WriteLine("\nThe file is too large!");
                }
                else Console.WriteLine("\nFile not find!");
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine("\nFile already exists!\n Resons: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong. Try again, please!\n Resons: " + ex.Message);
            }
        }
    }
}
