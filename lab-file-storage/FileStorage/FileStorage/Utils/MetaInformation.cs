using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FileStorage.Utils
{
    [Serializable]
    public class MetaInformation : ISerializable
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string FileCreationDate { get; set; }
        public string LastAccessTime { get; set; }

        public MetaInformation() { }

        public MetaInformation(string fileName, string fileExtension, long fileSize, string fileCreationDate, string lastAccessTime)
        {
            FileName = fileName;
            FileExtension = fileExtension;
            FileSize = fileSize;
            FileCreationDate = fileCreationDate;
            LastAccessTime = lastAccessTime;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.SetType(typeof(MetaInformation));
            info.AddValue("fileName", FileName);
            info.AddValue("fileExtension", FileExtension);
            info.AddValue("fileSize", FileSize);
            info.AddValue("fileCreationDate", FileCreationDate);
            info.AddValue("lastAccessTime", LastAccessTime);
        }

        private MetaInformation(SerializationInfo info, StreamingContext ctx)
        {
            FileName = info.GetString("fileName");
            FileExtension = info.GetString("fileExtension");
            FileSize = info.GetInt64("fileSize");
            FileCreationDate = info.GetString("fileCreationDate");
            LastAccessTime = info.GetString("lastAccessTime");
        }
        public static void Serialize()
        {
            List<MetaInformation> metaInfo = new List<MetaInformation>();
             
            if (Directory.Exists(ConfigurationManager.AppSettings["Storage"]))
            {
                string[] files = Directory.GetFiles(ConfigurationManager.AppSettings["Storage"]);
                foreach (string file in files)
                { 
                    FileInfo fileInf = new FileInfo(file);
                    metaInfo.Add(new MetaInformation(fileInf.Name, fileInf.Extension, fileInf.Length, fileInf.CreationTime.ToString("yyyy-MM-dd"), fileInf.LastAccessTime.ToString("yyyy-MM-dd")));
                }
            }

            using (FileStream fs = new FileStream(ConfigurationManager.AppSettings["MetaFile"], FileMode.OpenOrCreate))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, metaInfo);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("\nFailed to serialize.\n Reason: " + ex.Message);
                }
            }
        }
        public static List<MetaInformation> Deserialize()
        {
            List<MetaInformation> metaInfo = new List<MetaInformation>();

            using (FileStream fs = new FileStream(ConfigurationManager.AppSettings["MetaFile"], FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    metaInfo = (List<MetaInformation>)formatter.Deserialize(fs);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("\nFailed to deserialize.\n Reason: " + ex.Message);
                }
            }
            return metaInfo;
        }
    }
}
