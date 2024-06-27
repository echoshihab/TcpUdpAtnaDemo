using System.Xml.Serialization;

namespace MessageSender.Enums
{
    public enum EventOutcomeIndicator
    {
        [XmlEnum("0")]
        NominalSuccess,
        [XmlEnum("4")]
        MinorFailure,
        [XmlEnum("8")]
        SeriousFailure,
        [XmlEnum("12")]
        MajorFailure
    }
}
