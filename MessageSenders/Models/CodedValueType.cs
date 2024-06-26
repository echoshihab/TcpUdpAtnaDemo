using System.Xml.Serialization;

namespace MessageSender.Models;

public class CodedValueType
{
    [XmlAttribute("csd-code")]
    public string CsdCode { get; set; }
    public CsdAttributes CsdAttributes { get; set; }
}