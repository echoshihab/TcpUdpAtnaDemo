using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    public interface IReceiver
    {
        Task ReceiveMessagesAsync();
    }
}
