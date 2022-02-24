using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using FileStorage.Utils;

namespace FileStorage.Formatters
{
    public class XmlFormatter
    {
        public static void GetXmlFormat(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<MetaInformation>));
                    formatter.Serialize(fs, MetaInformation.Deserialize());
                    Console.WriteLine($"\nThe meta-information has been exported, path = '{path}' ");
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("\nFailed to formatted.\n Reason: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nSomething went wrong. Try again, please!\n Resons: " + ex.Message);
                }
            }
        }
    }
}
