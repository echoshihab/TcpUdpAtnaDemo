using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Listener.Udp
{
    public  class AsyncCallbackUdpReceiver
    {
        private bool messageReceived;
        public void ReceiveCallback(IAsyncResult asyncResult)
        {
            var udpClient = ((UdpState)(asyncResult.AsyncState)).UdpClient;
            var ipEndpoint = ((UdpState)(asyncResult.AsyncState)).IpEndPoint;

            var receiveBytes = udpClient.EndReceive(asyncResult, ref ipEndpoint);
            var receiveString = Encoding.ASCII.GetString(receiveBytes);

            Console.WriteLine($"Received {receiveString}");
            this.messageReceived = true;
        }
        
        public void ReceiveMessages()
        {
            var listerEndpoint = new IPEndPoint(IPAddress.Loopback, 514);
            var udpClient = new UdpClient(listerEndpoint);

            var udpState = new UdpState
            {
                IpEndPoint = listerEndpoint,
                UdpClient = udpClient
            };

            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), udpState);

            while (!this.messageReceived)
            {
                Thread.Sleep(100);
            }
        }
    }
}
