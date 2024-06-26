using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class ParticipantObjectDetail
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("value")]
        public byte[] Value { get; set; }
    }
}
