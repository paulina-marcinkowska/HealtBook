using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Twilio.TwiML;
using Foundatio.Utility;

namespace KsiazeczkaZdrowia
{
    public static class SaveXml
    {
       public static void SaveDataXml<T>(List<T> listToSave) 
        {
            var xml = SerializeData(listToSave);
            SaveToFile(xml);

        }
        static string SerializeData<T>(List<T> listToSave) 
        {
            string xml = typeof(T).ToString();
            XmlSerializer xmlList = new XmlSerializer(typeof(List<T>));
            using (StringWriter swList = new Utf8StringWriter()) 
            {
                using (XmlWriter writer = XmlWriter.Create(swList)) 
                {
                    xmlList.Serialize(writer, listToSave);
                    xml = swList.ToString();
                }
            }
            return xml;
        }

        static void SaveToFile(string xml)
        {
            string path = @".txt";

            if (!File.Exists(path)) 
            {
                File.WriteAllText(path, xml);

            }
            else 
            {
                File.AppendAllText(path, xml);

            }
             string odczyt = File.ReadAllText(path);

        }

    }
}
