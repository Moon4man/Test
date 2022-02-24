using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using FileStorage.Utils;

namespace FileStorage.Commands.ProgramCommands
{
    class UserInfoCommand
    {
        public static void GetInfo()
        {
            Console.WriteLine($"\nlogin: {ConfigurationManager.AppSettings["login"]}\n" +
                              $"creation Date: {GetToday()}\n" +
                              $"storage used: {StorageSize.GetSizeStorageInMb()} MB");
        }

        public static string GetToday()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}
