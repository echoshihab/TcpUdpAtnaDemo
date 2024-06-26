using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class IdentifiedData
    {
        [XmlAttribute]
        public string UID { get; set; }
    }
}
