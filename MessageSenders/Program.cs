// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;
using MessageSender;



var auditMessage = AuditMessageUtil.GenerateAuditMessage(AuditMessageUtil.CreateAuditMessageForUserAuth);

var syslogMessage = SyslogMessageUtil.EncapsulateMessageWithSyslogHeader(auditMessage, ApplicationConstants.SYSLOG_SECURITY_AUTH_FACILITY_CODE, ApplicationConstants.SYSLOG_SEVERITY_AUTHORIZATION);

if (syslogMessage != null)
{
    await SendTcpMessage(Encoding.ASCII.GetBytes(syslogMessage));
}


//await SendUdpMessage(data);

async Task SendTcpMessage(byte[] data)
{

    var tcpEndpoint = new IPEndPoint(IPAddress.Loopback, 11514);
    
    using var tcpClient = new TcpClient();
    await tcpClient.ConnectAsync(tcpEndpoint);

    var stream = tcpClient.GetStream();

    await stream.WriteAsync(data, 0, data.Length);

    Console.WriteLine($"Audit sent to: {tcpEndpoint.Address}");

    await Task.Delay(10);

    tcpClient.Close(); // need this if the receiver is receiving data in continuous manner

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