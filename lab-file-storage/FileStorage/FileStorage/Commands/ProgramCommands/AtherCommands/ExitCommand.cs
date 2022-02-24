using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FileStorage.Commands.ProgramCommands.AtherCommands
{
    class ExitCommand
    {
        public static void ExitFromApp()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Authorization"].Value = "false";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            Console.WriteLine("\nYou have logged out of the app!");
        }
    }
}
