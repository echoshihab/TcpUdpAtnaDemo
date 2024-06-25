using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MessageSender
{
    public static class SyslogMessageUtil
    {
        /// <summary>
        /// Encapsulates audit message with syslog header per RFC5424
        /// </summary>
        /// <param name="auditMessage">The Audit Message</param>
        /// <param name="facilityCode">The Facility code</param>
        /// <param name="severity">The Severity</param>
        /// <returns></returns>
        public static string EncapsulateMessageWithSyslogHeader(string auditMessage, int facilityCode, int severity)
        {
            // SYSLOG-MSG      = HEADER SP STRUCTURED-DATA [SP MSG]

            // HEADER          = PRI VERSION SP TIMESTAMP SP HOSTNAME SP APP-NAME SP PROCID SP MSGID
            var pri = (facilityCode * 8) + severity;
            var version = 1; //https://datatracker.ietf.org/doc/html/rfc5424#section-9.1
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.ff'Z'"); // based on example format - https://datatracker.ietf.org/doc/html/rfc5424#section-6.2.3.1 , note T is required
            var hostName = Dns.GetHostEntry("localhost").HostName;
            var appName = Process.GetCurrentProcess().ProcessName;
            var procid = Environment.ProcessId;
            var msgId = "DICOM_PS3.15";

            // structured data = NILVALUE / 1*SD-ELEMENT
            // SD-ELEMENT      = "[" SD-ID *(SP SD-PARAM) "]"
            // unable to create structured data due to absence of IANA private enterprise number required for SD-ID
            var structuredData = "-"; //- represents NILVALUE https://datatracker.ietf.org/doc/html/rfc5424#section-7.2.2

            return $"{pri}{version} {timestamp} {hostName} {appName} {procid} {msgId} {structuredData} {auditMessage}";
        } // log audit


    }
}
