using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageSender.Enums
{
    public enum NetworkAccessPointTypeCode
    {
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
