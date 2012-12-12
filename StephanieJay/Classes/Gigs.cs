using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace StephanieJay.Classes
{
    [XmlRootAttribute(ElementName = "gigs")]
    public class Gigs
    {
        public Gigs() { }

        [XmlElement(ElementName = "group", Type = typeof(Group))]
        public List<Group> groups
        {
            get { return _group; }
            set { _group = value; }
        }

        public void Save(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gigs));
            FileStream stream = File.Create(filename);
            serializer.Serialize(stream, this);
        }

        public static Gigs Load(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            return Load(stream);
        }

        public static Gigs Load(Stream fileStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gigs));
            Gigs ret = (Gigs)serializer.Deserialize(fileStream);
            return ret;
        }
        
        private List<Group> _group;

    }

    [XmlRootAttribute(ElementName = "group")]
    public class Group
    {
        public Group() { }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement(ElementName = "job", Type = typeof(Job))]
        public List<Job> jobs
        {
            get { return _job; }
            set { _job = value; }
        }

        private string _name;
        private List<Job> _job;
    }

    [XmlRootAttribute(ElementName = "job")]
    public class Job
    {
        public Job() { }

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string venue
        {
            get { return _venue; }
            set { _venue = value; }
        }

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

       public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _date;
        private string _venue;
        private string _city;
        private string _country;
    }
}