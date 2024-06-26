using System.Xml.Serialization;

namespace MessageSender.Models;

public class ActiveParticipant
{
    [XmlElement]
    public RoleIdCode RoleIDCode { get; set; }
    [XmlElement]
    public MediaIdentifier MediaIdentifier { get; set; }
    [XmlAttribute]
    public string UserID { get; set; }
    [XmlAttribute]
    public string AlternativeUserID { get; set; }
    [XmlAttribute]
    public string UserName { get; set; }
    [XmlAttribute]
    public bool UserIsRequester { get; set; }
    [XmlAttribute]
    public string NetworkAccessPointID { get; set; }
    [XmlAttribute]
    public string NetworkAccessPointTypeCode { get; set; }
}