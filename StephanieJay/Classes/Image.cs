using System.Xml.Serialization;
namespace RSS
{
    [XmlRootAttribute(ElementName = "image")]
    public class Image : Element
    {
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _url;
    }
}
