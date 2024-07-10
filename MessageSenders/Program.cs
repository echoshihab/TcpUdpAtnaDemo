// See https://aka.ms/new-console-template for more information

using MessageSender;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;


var auditMessage = AuditMessageUtil.GenerateAuditMessage(AuditMessageUtil.CreateAuditMessageForUserAuth);

var syslogMessage = SyslogMessageUtil.EncapsulateMessageWithSyslogHeader(auditMessage, ApplicationConstants.SYSLOG_SECURITY_AUTH_FACILITY_CODE, ApplicationConstants.SYSLOG_SEVERITY_AUTHORIZATION);

var data = Encoding.ASCII.GetBytes(syslogMessage);

if (args.Length == 0 || string.Equals("tcp", args[0], StringComparison.InvariantCultureIgnoreCase))
{
    Console.WriteLine("Sending Message via TCP");
    await SendTcpMessage(data);
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

async Task SendTcpMessage(byte[] data)
{
    var tcpEndpoint = new IPEndPoint(IPAddress.Loopback, 11514);
    
    using var tcpClient = new TcpClient();
    await tcpClient.ConnectAsync(tcpEndpoint);

    // alternate await tcpClient.ConnectAsync("localhost", 11514);

    await using var stream = tcpClient.GetStream();
    await using var sslStream = new SslStream(stream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

    try
    {
        var clientCertificate = new X509Certificate("c:\\certs\\client\\client.pfx", "Password1!");
        var clientCertificates = new X509CertificateCollection
        {
            clientCertificate
        };
        await sslStream.AuthenticateAsClientAsync("D02962.DBRI.LOCAL", clientCertificates, true);
    }
    catch (AuthenticationException e)
    {
        Console.WriteLine("Exception: {0}", e.Message);

        if (e.InnerException != null)
        {
            Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
        }

        Console.WriteLine ("Authentication failed - closing the connection.");
        tcpClient.Close();

        return;
    }

    await stream.WriteAsync(data, 0, data.Length);

    Console.WriteLine($"Audit sent to: {tcpEndpoint.Address}");

    await Task.Delay(10);

    tcpClient.Close(); // need this if the receiver is receiving data in continuous manner

    Console.ReadKey();
}

bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
{
    if (sslPolicyErrors == SslPolicyErrors.None)
        return true;
    return false;
}

async Task SendUdpMessage(byte[] data)
{
    var client = new UdpClient();
    var endpoint = new IPEndPoint(IPAddress.Loopback, 514);

    await client.SendAsync(data, endpoint, CancellationToken.None);

    Console.WriteLine($"Audit sent to: {endpoint.Address}");
    Console.ReadKey();
}