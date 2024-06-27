using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageSender.Enums
{
    public enum AuditSourceTypeCode
    {
        [XmlEnum("1")]
        EndUserInterface,
        [XmlEnum("2")]
        DataAcquisitionDeviceOrInstrument,
        [XmlEnum("3")]
        WebServerProcessOrThread,
        [XmlEnum("4")]
        ApplicationServerProcessOrThread,
        [XmlEnum("5")]
        DatabaseServerProcessOrThread,
        [XmlEnum("6")]
        SecurityServer,
        [XmlEnum("7")]
        NetworkComponent,
        [XmlEnum("8")]
        OperatingSoftware,
        [XmlEnum("9")]
        Other
    }
}
