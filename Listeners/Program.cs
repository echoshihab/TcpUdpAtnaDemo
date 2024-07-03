// See https://aka.ms/new-console-template for more information
// add TCP Listener

using Listener.Tcp;
using Listener.Udp;

if (args.Length == 0 || string.Equals("tcp", args[0], StringComparison.InvariantCultureIgnoreCase))
{
    var tcpReceiver = new TcpReceiver();
    await tcpReceiver.ReceiveMessagesAsync();
} 
else if (string.Equals("udp", args[0], StringComparison.InvariantCultureIgnoreCase))
{
    var udpReceiver = new UdpReceiver();

    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true;
        udpReceiver.StopReceiver();
    };
    await udpReceiver.ReceiveMessagesAsync();
}
else
{
    Console.WriteLine("Invalid argument(s)");
    Console.ReadKey();
}






