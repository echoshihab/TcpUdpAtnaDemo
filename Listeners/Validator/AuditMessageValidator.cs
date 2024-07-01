using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener.Validator
{
    public class AuditMessageValidator
    {
        public bool ValidateAuditMessage(string auditMessage)
        {
            return auditMessage.Contains(@"<AuditMessage>");
        }
    }
}
