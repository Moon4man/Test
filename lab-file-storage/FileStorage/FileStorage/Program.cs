using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using FileStorage.Commands.ProgramCommands;
using FileStorage.Commands.ProgramCommands.AtherCommands;
using FileStorage.Formatters;
using FileStorage.Utils;

namespace FileStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string FileName, Path, Format, OldName, NewName;

            if (args.Length == 0)
            {
                Console.WriteLine("\nYou haven't entered anything!");
            }

            var command = args[1];

            if (args[1] == ConfigurationManager.AppSettings["login"] &&
                args[3] == ConfigurationManager.AppSettings["password"])
            {
               AuthorizationCommand.AuthorizationInApp();
               return;
            }

            if (ConfigurationManager.AppSettings["Authorization"] == "true")
            {
                try
                {
                    switch (command)
                    {
                        //info user
                        case "user":
                            UserInfoCommand.GetInfo();
                            break;
                        //file upload
                        case "upload":
                            Path = args[2];
                            UploadFileCommand.UploadFile(Path);
                            MetaInformation.Serialize();
                            break;
                        //file download
                        case "download":
                            FileName = args[2];
                            Path = args[3];
                            DownloadFileCommand.DownloadFile(FileName, Path);
                            MetaInformation.Serialize();
                            break;
                        //file move
                        case "move":
                            OldName = args[2];
                            NewName = args[3];
                            MoveFileCommand.MoveFile(OldName, NewName);
                            MetaInformation.Serialize();
                            break;
                        //file remove
                        case "remove":
                            FileName = args[2];
                            RemoveFileCommand.RemoveFile(FileName);
                            MetaInformation.Serialize();
                            break;
                        //file info
                        case "info":
                            FileName = args[2];
                            InfoFileCommand.GetInfo(FileName);
                            break;
                        //file find
                        case "find":
                            FileName = args[2];
                            FindFileCommand.FindFile(FileName);
                            break;
                        //file export
                        case "export":
                            if (args[2] != "--info")
                            {
                                Path = args[2];
                                if (args.Length == 3)
                                {
                                    JsonFormatter.GetJsonFormat(Path);
                                }
                                else
                                {
                                    Format = args[4];
                                    if (Format == "json")
                                        JsonFormatter.GetJsonFormat(Path);
                                    else if (Format == "xml")
                                        XmlFormatter.GetXmlFormat(Path);
                                    else Console.WriteLine("\nFormat is incorrect!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n - json\n" +
                                                  " - xml");
                            }
                            break;
                        case "exit":
                            ExitCommand.ExitFromApp();
                            break;
                        default:
                            Console.WriteLine("\nData is incorrect! Repeat your choice, please!");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nInvalid value! Try again!\n Resons: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nSomething went wrong. Try again, please!\n Resons: " + ex.Message);
                }
               
            }
            else Console.WriteLine("\nTo get started, log in to the app!");
        }
    }
}

