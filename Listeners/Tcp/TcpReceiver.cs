using System.Net.Sockets;
using System.Net;
using System.Text;
using Listener.Validator;

namespace Listener.Tcp
{
    public class TcpReceiver : IReceiver
    {
        private TcpListener? tcpListener;
        private readonly AuditMessageValidator validator = new AuditMessageValidator();
        public async Task ReceiveMessagesAsync()
        {
            try
            {
                this.tcpListener = new TcpListener(IPAddress.Loopback, 11514);
                this.tcpListener.Start();

                using var handler = await this.tcpListener.AcceptTcpClientAsync();
                await using var stream = handler.GetStream();

                var message = await this.ContinuouslyReadStreamByBufferSizeAsync(new byte[10], stream);

                //alternate
                //var message = await this.ReadStreamByStreamReaderAsync(stream);

                if (!this.validator.ValidateAuditMessage(message))
                {
                    Console.WriteLine("The following audit message is invalid");
                }

                Console.WriteLine($"Message received: \"{message}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task<string> ContinuouslyReadStreamByBufferSizeAsync(byte[] buffer, Stream stream)
        {
            using var memoryStream = new MemoryStream();

            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await memoryStream.WriteAsync(buffer, 0, bytesRead);
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }


        private async Task<string> ReadStreamByStreamReaderAsync(Stream stream)
        {
            using var streamReader = new StreamReader(stream, Encoding.UTF8);
            var message= await streamReader.ReadToEndAsync();
            return message;
        }
    }
}
