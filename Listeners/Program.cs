// See https://aka.ms/new-console-template for more information
// add TCP Listener

using System.Net;
using System.Net.Sockets;
using System.Text;
using Listener.Udp;


var tcpListener = new TcpListener(IPAddress.Loopback, 11514);
//await StartTcpListener();
//StartUdpReceiver();

Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true; 
    UdpReceiver.StopReceiver();
};

await UdpReceiver.ReceiveMessagesAsync();

async Task StartTcpListener()
{
    try
    {
        tcpListener.Start();

        using var handler = await tcpListener.AcceptTcpClientAsync();
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

void StartUdpReceiver()
{
    AsyncCallbackUdpReceiver.ReceiveMessages();
}

