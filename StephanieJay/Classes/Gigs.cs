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
        //    [XmlElement(ElementName = "group", Type = typeof(Group))]
        //    public List<Group> groups { get; set; }
        //}

        //[XmlRootAttribute(ElementName = "group")]
        //public class Group
        //{
        //    public string name { get; set; }
        //    public DateTime date { get; set; }
        //    [XmlElement(ElementName = "gig", Type = typeof(Gig))]
        //    public List<Gig> gigs { get; set; }
        //}
        public List<Gig> gigs { get; set; }
    }
    [XmlRootAttribute(ElementName = "gig")]
    public class Gig
    {
        public string guid { get; set; }
        public DateTime date { get; set; }
        public string venue { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}