using System.Net.Sockets;
using System.Net;
using System.Text;
using Listener.Validator;

namespace Listener.Tcp
{
    public static class TcpReceiver
    {
        private static TcpListener _tcpListener;
        private static AuditMessageValidator _validator = new AuditMessageValidator();
        public static async Task StartTcpListenerAsync()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Loopback, 11514);
                _tcpListener.Start();

                using var handler = await _tcpListener.AcceptTcpClientAsync();
                await using var stream = handler.GetStream();


                //with continuous 
                var message = await ContinuouslyReadStreamByBufferSizeAsync(new byte[10], stream);

                //var message = await ReadyStreamByStreamReaderAsync(stream);

                // the following doesn't require sender to close connection because of the stream.ReadAsync returns immediately at presence of any data with assigned buffer size
                //var buffer = new byte[1_024];
                //int received = await stream.ReadAsync(buffer);
                //var message = Encoding.UTF8.GetString(buffer, 0, received);

                if (!_validator.ValidateAuditMessage(message))
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

        private static async Task<string> ContinuouslyReadStreamByBufferSizeAsync(byte[] buffer, Stream stream)
        {
            using var memoryStream = new MemoryStream();

            while ((await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await memoryStream.WriteAsync(buffer);
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }


        private static async Task<string> ReadStreamByStreamReaderAsync(Stream stream)
        {
            using var streamReader = new StreamReader(stream, Encoding.UTF8);
            var message= await streamReader.ReadToEndAsync();
            return message;
        }
    }
}
