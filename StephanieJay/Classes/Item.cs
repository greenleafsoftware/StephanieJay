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

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string commments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        private string _author;
        private string _comments;
        private string _source;
        private string _category;
        private string _guid;

    }
}
