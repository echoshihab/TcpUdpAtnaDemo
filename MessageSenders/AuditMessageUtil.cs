using System.Net;
using System.Net.Mime;
using System.Xml.Serialization;
using MessageSender.Enums;
using MessageSender.Models;

namespace MessageSender
{
    public static class AuditMessageUtil
    {
        public static string GenerateAuditMessage(Func<string> auditMessageGenerator)
        {
            return auditMessageGenerator.Invoke();
        }

        public static string CreateAuditMessageForUserAuth()
        {
            var auditMessage = new AuditMessage
            {
                EventIdentification = new EventIdentification()
                {
                    EventID = new CodedValueType(DicomCodedValues.UserAuthentication),
                    EventActionCode = EventActionCode.Execute,
                    EventTypeCode = new CodedValueType(DicomCodedValues.Login),
                    EventDateTime = DateTime.UtcNow,
                    EvenOutcomeIndicator = EventOutcomeIndicator.NominalSuccess
                }
            };

            auditMessage.ActiveParticipants.Add(new()
            {
                UserID = "TCPUdpDemo",
                AlternativeUserID = "",
                RoleIDCode = new CodedValueType(ApplicationCodedValues.User),
                UserName = "Patient1",
                UserIsRequester = true,
                NetworkAccessPointID = "128.117.136.169",
                NetworkAccessPointTypeCode = NetworkAccessPointTypeCode.IpAddress,
            });

            auditMessage.ActiveParticipants.Add(new()
            {
                UserID = "Application",
                AlternativeUserID = "",
                RoleIDCode = new CodedValueType(DicomCodedValues.Application),
                UserName = "Application",
                UserIsRequester = false,
                NetworkAccessPointID = IPAddress.Loopback.ToString(),
                NetworkAccessPointTypeCode = NetworkAccessPointTypeCode.IpAddress,
            });

            auditMessage.AuditSourceIdentification = new AuditSourceIdentification()
            {
                AuditEnterpriseSiteId = ApplicationConstants.AUDIT_ENTERPRISE_SITE_ID,
                AuditSourceId = ApplicationConstants.APPLICATION_IDENTIFIER,
                AuditSourceTypeCode = new CodedValueType(AuditSourceTypeCode.ApplicationServerProcessOrThread)
            };

            return SerializeMessageToXmlString(auditMessage);
        }

        private static string SerializeMessageToXmlString(AuditMessage message)
        {
            var xmlSerializer = new XmlSerializer(typeof(AuditMessage));

            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, message);

            return stringWriter.ToString();
        }
    }
}
