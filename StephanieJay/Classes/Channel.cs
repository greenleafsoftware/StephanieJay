using System.Xml.Serialization;
using System.Collections.Generic;

namespace RSS
{
    [XmlRootAttribute(ElementName = "channel")]
    public class Channel : Element
    {
        public string copyright { get; set; }
        public string language { get; set; }
        public Image image { get; set; }

        [XmlElement(ElementName = "item", Type = typeof(Item))]
        public List<Item> items { get; set; }
    }
}
