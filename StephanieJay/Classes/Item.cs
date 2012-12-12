using System.Xml.Serialization;

namespace RSS
{
    [XmlRootAttribute(ElementName = "item")]
    public class Item : Element
    {
        public Item() { }

        public Item(string title, string link, string description)
        {
            this.title = title;
            this.link = link;
            this.description = description;
        }

        public string author { get; set; }
        public string commments { get; set; }
        public string source { get; set; }
        public string category { get; set; }
        public string guid { get; set; }
    }
}
