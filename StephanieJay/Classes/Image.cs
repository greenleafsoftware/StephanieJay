using System.Xml.Serialization;

namespace RSS
{
    [XmlRootAttribute(ElementName = "image")]
    public class Image : Element
    {
        public string url { get; set; }
    }
}
