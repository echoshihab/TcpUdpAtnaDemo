using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class AuditMessage
    {
        public AuditMessage()
        {
            this.ActiveParticipants = new List<ActiveParticipant>();
        }

        [XmlElement]
        public EventIdentification EventIdentification { get; set; }
        [XmlElement]
        public List<ActiveParticipant> ActiveParticipants { get; set; }
        [XmlElement]
        public AuditSourceIdentification AuditSourceIdentification { get; set; }
        [XmlElement]
        public ParticipantObjectIdentification? ParticipantObjectIdentification { get; set; }

        private bool ShouldSerializeParticipantObjectIdentification() => this.ParticipantObjectIdentification != null;
    }
}
