using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace RSS
{
    [XmlRootAttribute(ElementName = "rss")]
    public class Rss
    {
        public Rss() { }

        public Rss(string version)
        {
            Version = version;
        }

        public Channel channel { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        public void Save(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rss));
            FileStream stream = File.Create(filename);
            serializer.Serialize(stream, this);
        }

        public static Rss Load(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            return Load(stream);
        }

        public static Rss Load(Stream fileStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rss));
            Rss rss = (Rss)serializer.Deserialize(fileStream);
            return rss;
        }
    }
}
