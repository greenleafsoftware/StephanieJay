using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace StephanieJay.Classes
{
    public class Xml<T>
    {
        public static void Save(string fileName, T entity)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = File.Create(fileName))
            {
                serializer.Serialize(stream, entity);
            }
        }

        public static T Load(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return Load(stream);
            }
        }

        public static T Load(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(fileStream);
        }
    }
}