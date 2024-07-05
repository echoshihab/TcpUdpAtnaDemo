namespace Listener.Validator
{
    public class AuditMessageValidator
    {
        public bool ValidateAuditMessage(string auditMessage)
        {
            return auditMessage.Contains(@"<AuditMessage");
        }
    }
}
