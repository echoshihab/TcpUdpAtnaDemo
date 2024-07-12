using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace MessageSender.Senders
{
    public class TcpSender
    {
        public async Task SendTcpMessageAsync(byte[] data)
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

        public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }
    }
}
