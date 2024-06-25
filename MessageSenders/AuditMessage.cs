using System.Xml.Serialization;

namespace MessageSender
{
    public class AuditMessage
    {
        public EventIdentification EventIdentification { get; set; }
        public ActiveParticipant ActiveParticipant { get; set; }
    }

    public class ActiveParticipant
    {
        public RoleIdCode RoleIdCode { get; set; }
        public MediaIdentifier MediaIdentifier { get; set; }
        [XmlAttribute]
        public string UserId { get; set; }
        [XmlAttribute]
        public string AlternativeUserId { get; set; }
        [XmlAttribute]
        public bool UserIsRequester { get; set; }
        [XmlAttribute]
        public string NetworkAccessPointId { get; set; }
        [XmlAttribute]
        public string NetworkAccessPointTypeCode { get;set; }
    }

    public class EventIdentification
    {
        public EventId EventId { get; set; }
        public EventTypeCode EventTypeCode { get; set; }
        [XmlAttribute]
        public string EventActionCode { get; set; }
        [XmlAttribute]
        public DateTime EventDateTime { get; set; }
        [XmlAttribute]
        public int EvenOutcomeIndicator { get; set; }
        public string EventOutcomDescription { get; set; }
    }

    public class EventId
    {
        public CodedValueType CodedValueType { get; set; }
    }

    public class RoleIdCode
    {
        public CodedValueType CodedValueType { get; set; }
    }

    public class MediaType
    {
        public CodedValueType CodedValueType { get; set; }
    }

    public class MediaIdentifier
    {
        public MediaType MediaType { get; set; }
    }

    public class EventTypeCode
    {
        public CodedValueType CodedValueType { get; set; }
    }

    public class CodedValueType
    {
        public string CsdCode {get; set; }
        public string CodeSystemName { get; set; }
        public string DisplayName { get; set; }
        public string OriginalText { get; set; }
    }
}
