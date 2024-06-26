using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class Accession
    {
        [XmlAttribute]
        public string Number { get; set; }
    }
}
