using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileStorage.Utils
{
    class StorageSize
    {
        public static long GetSizeStorageInMb()
        {
            long sizeStorage = 0;
            if (Directory.Exists(ConfigurationManager.AppSettings["Storage"]))
            {
                string[] files = Directory.GetFiles(ConfigurationManager.AppSettings["Storage"]);
                sizeStorage = 0;
                foreach (string file in files)
                {
                    FileInfo fileInf = new FileInfo(file);
                    sizeStorage += fileInf.Length;
                }
            }
            return sizeStorage / (1024 * 1024);
        }
    }
}
