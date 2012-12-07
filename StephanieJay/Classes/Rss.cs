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

        public Channel channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

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
            Rss ret = (Rss)serializer.Deserialize(fileStream);
            return ret;
        }

        [XmlAttribute("version")]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private Channel _channel;
        private string _version;
    }
}
