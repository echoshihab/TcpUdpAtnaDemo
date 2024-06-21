using System.Net;
using System.Net.Sockets;

namespace Listener.Udp
{
    public static class UdpReceiver
    {
        private static CancellationTokenSource _tokenSource;
        private static UdpClient _client;

        public static async Task ReceiveMessagesAsync()
        {
            _client = new UdpClient(new IPEndPoint(IPAddress.Loopback, 514));
            _tokenSource = new CancellationTokenSource();

            try
            {
                while (!_tokenSource.Token.IsCancellationRequested)
                {
                    var udpReceivedResult = await _client.ReceiveAsync(_tokenSource.Token);

                    var receivedMessage = System.Text.Encoding.UTF8.GetString(udpReceivedResult.Buffer);

                    Console.WriteLine($"Message: {receivedMessage}");
                }

                Console.WriteLine("cancelled via token");
            }                            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void StopReceiver()
        {
            Console.WriteLine("Stopping Receiver via cancelling token.");
            _tokenSource.Cancel();
            _client.Close();
        }
    }
}
