using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RSS
{
    [XmlRootAttribute(ElementName = "channel")]
    public class Channel : Element
    {
        public string copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }

        public string language
        {
            get { return _language; }
            set { _language = value; }
        }

        public Image image
        {
            get { return _image; }
            set { _image = value; }
        }

        [XmlElement(ElementName = "item", Type = typeof(Item))]
        public List<Item> items
        {
            get { return _item; }
            set { _item = value; }
        }

        private string _copyright;
        private string _language;
        private Image _image;
        private List<Item> _item;
    }
}
