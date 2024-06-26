using System.Xml.Serialization;

namespace MessageSender.Models;

public class DicomObjectDescription
{
    [XmlElement("MPPS")]
    public Mpps Mpps { get; set; }
    [XmlElement]
    public Accession Accession { get; set; }
    [XmlElement("SOPClass")]
    public Sop Sop { get; set; }
    [XmlElement]
    public ParticipantObjectContainsStudy ParticipantObjectContainsStudy { get; set; }
    [XmlElement]
    public bool Encrypted { get; set; }
    [XmlElement]
    public bool Anonymized { get; set; }
}