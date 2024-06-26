using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class Sop : IdentifiedData
    {
        [XmlElement]
        public Instance Instance { get; set; }
        public int NumberOfInstances { get; set; }
    }
}
