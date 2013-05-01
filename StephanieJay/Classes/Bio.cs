using System.Xml.Serialization;

namespace StephanieJay.Classes
{
    [XmlRootAttribute(ElementName = "Bio")]
    public class Bio
    {
        public string description { get; set; }
    }
}