using System.Net;
using System.Net.Sockets;

namespace Listener.Udp
{
    public class UdpReceiver : IReceiver
    {
        private CancellationTokenSource? tokenSource;
        private UdpClient? client;

        public async Task ReceiveMessagesAsync()
        {
            this.client = new UdpClient(new IPEndPoint(IPAddress.Loopback, 514));
            this.tokenSource = new CancellationTokenSource();

            try
            {
                while (!this.tokenSource.Token.IsCancellationRequested)
                {
                    var udpReceivedResult = await this.client.ReceiveAsync(this.tokenSource.Token);

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

        public void StopReceiver()
        {
            Console.WriteLine("Stopping Receiver via cancelling token.");
            this.tokenSource?.Cancel();
            this.client?.Close();
        }
    }
}
