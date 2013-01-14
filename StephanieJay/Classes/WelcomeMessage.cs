using System.Xml.Serialization;

namespace StephanieJay.Classes
{
    [XmlRootAttribute(ElementName = "welcomeMessage")]
    public class WelcomeMessage
    {
        public string title { get; set; }
        public string message { get; set; }
    }
}