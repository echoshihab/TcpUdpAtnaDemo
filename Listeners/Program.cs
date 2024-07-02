// See https://aka.ms/new-console-template for more information
// add TCP Listener

using Listener.Tcp;
using Listener.Udp;



//Console.CancelKeyPress += (sender, e) =>
//{
//    e.Cancel = true; 
//    UdpReceiver.StopReceiver();
//};

//var udpReceiver  = new UdpReceiver();
//await udpReceiver.ReceiveMessagesAsync();

var tcpReceiver = new TcpReceiver();
await tcpReceiver.ReceiveMessagesAsync();

