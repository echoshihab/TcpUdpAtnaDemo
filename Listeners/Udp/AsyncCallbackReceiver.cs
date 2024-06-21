using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Listener.Udp
{
    public static class AsyncCallbackReceiver
    {
        private static bool messageReceived;
        public static void ReceiveCallback(IAsyncResult asyncResult)
        {
            var udpClient = ((UdpState)(asyncResult.AsyncState)).UdpClient;
            var ipEndpoint = ((UdpState)(asyncResult.AsyncState)).IpEndPoint;

            var receiveBytes = udpClient.EndReceive(asyncResult, ref ipEndpoint);
            var receiveString = Encoding.ASCII.GetString(receiveBytes);

            Console.WriteLine($"Received {receiveString}");
            messageReceived = true;
        }
        
        public static void ReceiveMessages()
        {
            var listerEndpoint = new IPEndPoint(IPAddress.Loopback, 514);
            var udpClient = new UdpClient(listerEndpoint);

            var udpState = new UdpState
            {
                IpEndPoint = listerEndpoint,
                UdpClient = udpClient
            };

            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), udpState);

            while (!messageReceived)
            {
                Thread.Sleep(100);
            }
        }
    }
}
