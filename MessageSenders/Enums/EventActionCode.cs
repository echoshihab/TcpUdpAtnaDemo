using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageSender.Enums
{
    public enum EventActionCode 
    {
        [XmlEnum("C")]
        Create,
        [XmlEnum("R")]
        Read,
        [XmlEnum("U")]
        Update,
        [XmlEnum("D")]
        Delete,
        [XmlEnum("E")]
        Execute
    }
}
