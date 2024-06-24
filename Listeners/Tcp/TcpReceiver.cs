using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Listener.Tcp
{
    public static class TcpReceiver
    {
        private static TcpListener _tcpListener;
        public static async Task StartTcpListenerAsync()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Loopback, 11514);
                _tcpListener.Start();

                using var handler = await _tcpListener.AcceptTcpClientAsync();
                await using var stream = handler.GetStream();

                var buffer = new byte[1_024];
                int received = await stream.ReadAsync(buffer);

                var message = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine($"Message received: \"{message}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
