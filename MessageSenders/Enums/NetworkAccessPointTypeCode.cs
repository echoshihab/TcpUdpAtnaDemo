using System.Xml.Serialization;

namespace MessageSender.Enums
{
    public enum NetworkAccessPointTypeCode
    {
        None,
        [XmlEnum("1")]
        MachineName,
        [XmlEnum("2")]
        IpAddress,
        [XmlEnum("3")]
        TelephoneNumber,
        [XmlEnum("4")]
        EmailAddress,
        [XmlEnum("5")]
        Uri
    }
}
