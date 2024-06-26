using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class AuditMessage
    {
        [XmlElement]
        public EventIdentification EventIdentification { get; set; }
        [XmlElement]
        public ActiveParticipant ActiveParticipant { get; set; }
        [XmlElement]
        public AuditSourceIdentification AuditSourceIdentification { get; set; }
        [XmlElement]
        public ParticipantObjectIdentification ParticipantObjectIdentification { get; set; }
    }
}
