using System.Xml.Serialization;

namespace MessageSender.Models;

public class ParticipantObjectIdentification
{
    [XmlElement]
    public CodedValueType ParticipantObjectIDTypeCode { get; set; }
    [XmlElement]
    public string ParticipantObjectName { get; set; }
    [XmlElement]
    public byte[] ParticipantObjectQuery { get; set; }
    [XmlElement]
    public ParticipantObjectDetail ParticipantObjectDetail { get; set; }
    [XmlElement]
    public string? ParticipantObjectDescription { get; set; }
    public DicomObjectDescription DicomObjectDescription { get; set; }
    [XmlAttribute]
    public string ParticipantObjectId { get; set; }
    [XmlAttribute]
    public string ParticipantObjectTypeCode { get; set; }
    [XmlAttribute]
    public string ParticipantObjectTypeCodeRole { get; set; }
    [XmlAttribute]
    public string ParticipantObjectDataLifeCycle { get; set; }
    [XmlAttribute]
    public string ParticipantObjectSensitivity { get; set; }
}