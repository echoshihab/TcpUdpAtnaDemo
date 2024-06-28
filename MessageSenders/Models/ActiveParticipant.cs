using System.Xml.Serialization;
using MessageSender.Enums;

namespace MessageSender.Models;

public class ActiveParticipant
{
    [XmlElement]
    public CodedValueType RoleIDCode { get; set; }
    [XmlElement]
    public MediaIdentifier? MediaIdentifier { get; set; }
    [XmlAttribute]
    public string UserID { get; set; }
    [XmlAttribute]
    public string AlternativeUserID { get; set; }
    [XmlAttribute]
    public string UserName { get; set; }
    [XmlAttribute]
    public bool UserIsRequester { get; set; }
    [XmlAttribute]
    public string? NetworkAccessPointID { get; set; }
    [XmlAttribute]
    public NetworkAccessPointTypeCode NetworkAccessPointTypeCode { get; set; }

    private bool ShouldSerializeNetworkAccessPointID() => this.NetworkAccessPointTypeCode != Enums.NetworkAccessPointTypeCode.None;
    private bool ShouldSerializeNetworkAccessPointTypeCode() => this.NetworkAccessPointID != null && this.NetworkAccessPointTypeCode != null;

    private bool ShouldSerializeMediaIdentifier() => this.MediaIdentifier != null;

}