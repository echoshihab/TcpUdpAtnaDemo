using System.Xml.Serialization;

namespace MessageSender.Models
{
    public class ParticipantObjectContainsStudy
    {
        [XmlElement("StudyIDs")]
        public StudyId StudyId { get; set; }
    }
}
