using System;
namespace RSS
{
    public class Element
    {
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string pubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

        private string _title;
        private string _link;
        private string _description;
        private string _pubDate;
    }
}
