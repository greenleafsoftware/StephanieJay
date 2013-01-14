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
        public Group group { get; set; }
    }

    [XmlRootAttribute(ElementName = "group")]
    public class Group
    {
        public string name { get; set; }
        public List<Gig> gigs { get; set; }
    }

    [XmlRootAttribute(ElementName = "gig")]
    public class Gig
    {
        public string date { get; set; }
        public string venue { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}