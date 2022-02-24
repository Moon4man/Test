using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FileStorage.Commands.ProgramCommands
{
    class AuthorizationCommand
    {
        public static void AuthorizationInApp()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Authorization"].Value = "true";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            Console.WriteLine("\nAuthorization was successful!");
        }
    }
}
