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
    }
}
