// See https://aka.ms/new-console-template for more information

using MessageSender;
using MessageSender.Senders;
using System.Net;
using System.Net.Sockets;
using System.Text;


var auditMessage = AuditMessageUtil.GenerateAuditMessage(AuditMessageUtil.CreateAuditMessageForUserAuth);

var syslogMessage = SyslogMessageUtil.EncapsulateMessageWithSyslogHeader(auditMessage, ApplicationConstants.SYSLOG_SECURITY_AUTH_FACILITY_CODE, ApplicationConstants.SYSLOG_SEVERITY_AUTHORIZATION);

var data = Encoding.ASCII.GetBytes(syslogMessage);

if (args.Length == 0 || string.Equals("tcp", args[0], StringComparison.InvariantCultureIgnoreCase))
{
    Console.WriteLine("Sending Message via TCP");
    var tcpSender = new TcpSender();
    await tcpSender.SendTcpMessageAsync(data);
} 
else if (string.Equals("udp", args[0], StringComparison.InvariantCultureIgnoreCase))
{
    Console.WriteLine("Sending Message via UDP");
    await SendUdpMessage(data);
}
else
{
    Console.WriteLine("Invalid argument(s)");
    Console.ReadKey();
}

async Task SendUdpMessage(byte[] data)
{
    var client = new UdpClient();
    var endpoint = new IPEndPoint(IPAddress.Loopback, 514);

    await client.SendAsync(data, endpoint, CancellationToken.None);

    Console.WriteLine($"Audit sent to: {endpoint.Address}");
    Console.ReadKey();
}