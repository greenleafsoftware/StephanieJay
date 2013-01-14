using System.Xml.Serialization;

namespace StephanieJay.Classes
{
    [XmlRootAttribute(ElementName = "welcomeMessage")]
    public class Bio
    {
        public string description { get; set; }
    }
}