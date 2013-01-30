using System.Xml.Serialization;

namespace StephanieJay.Classes
{
    [XmlRootAttribute(ElementName = "bio")]
    public class Bio
    {
        public string description { get; set; }
    }
}