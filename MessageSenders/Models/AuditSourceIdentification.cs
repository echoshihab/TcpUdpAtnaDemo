using System.Xml.Serialization;

namespace MessageSender.Models;

public class AuditSourceIdentification
{
    [XmlAttribute]
    public string Code { get; set; }
    public CsdAttributes CsdAttributes { get; set; }
    [XmlAttribute]
    public string AuditEnterpriseSiteId { get; set; }
    [XmlAttribute]
    public string AuditSourceId { get; set; }
    [XmlElement]
    public CodedValueType AuditSourceTypeCode { get; set; }
}