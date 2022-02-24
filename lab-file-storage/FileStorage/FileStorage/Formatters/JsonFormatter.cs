using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using FileStorage.Utils;
using Newtonsoft.Json;

namespace FileStorage.Formatters
{
    public class JsonFormatter 
    {
        public static void GetJsonFormat(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (FileStream fs = new FileStream(path, FileMode.Create))
            { }
             
            using (StreamWriter fs = new StreamWriter(path, false))
            using (JsonWriter writer = new JsonTextWriter(fs))
            {
                try
                {
                    serializer.Serialize(writer, MetaInformation.Deserialize());
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
