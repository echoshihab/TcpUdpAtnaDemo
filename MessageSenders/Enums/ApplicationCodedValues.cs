using System.ComponentModel;
using System.Xml.Serialization;

namespace MessageSender.Enums
{

    public enum ApplicationCodedValues
    {
        [Category("APP")] // code system
        [Description("User")] //original text
        [XmlEnum("1")] // value
        User,

    }
}
