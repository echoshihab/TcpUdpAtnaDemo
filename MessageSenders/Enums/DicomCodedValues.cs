using System.ComponentModel;
using System.Xml.Serialization;

namespace MessageSender.Enums
{

    public enum DicomCodedValues
    {
        [Category("DCM")] // code system
        [Description("User Authentication")] //original text
        [XmlEnum("110114")] // value
        UserAuthentication,
        [Category("DCM")]
        [Description("Login")]
        [XmlEnum("110122")]
        Login,
        [Category("DCM")]
        [Description("Application")]
        [XmlEnum("110150")]
        Application,

    }
}
