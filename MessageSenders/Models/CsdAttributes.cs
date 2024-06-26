using System.Xml.Serialization;

namespace MessageSender.Models;

public class CsdAttributes
{
    [XmlAttribute("codeSystemName")]
    public string CodeSystemName { get; set; }
    [XmlAttribute("displayName")]
    public string DisplayName { get; set; }
    [XmlAttribute("originalText")]
    public string OriginalText { get; set; }
}