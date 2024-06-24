// See https://aka.ms/new-console-template for more information
// add TCP Listener

using Listener.Tcp;
using Listener.Udp;



Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true; 
    UdpReceiver.StopReceiver();
};

await UdpReceiver.ReceiveMessagesAsync();
//await TcpReceiver.StartTcpListenerAsync();


