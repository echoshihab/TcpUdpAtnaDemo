// See https://aka.ms/new-console-template for more information
// add TCP Listener

using System.Net;
using System.Net.Sockets;
using System.Text;


var tcpListener = new TcpListener(IPAddress.Loopback, 11514);
await StartTcpListener();


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

        //var data = Encoding.ASCII.GetBytes("hello");

        //var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(25));

        //if (cts.IsCancellationRequested)
        //{
        //    cts.Cancel();
        //}

        //await stream.WriteAsync(data, 0, data.Length, CancellationToken.None);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


//async Task StartUdpListener()
//{
//    var listerEndpoint = new IPEndPoint(IPAddress.Loopback, 514);
//    var udpClient = new UdpClient(listerEndpoint);

//    udpClient.BeginReceive(new AsyncCallback(ReceiveCallBack), )
//}

//struct UdpState
//{
//    public UdpClient UdpClient { get; set; }
//    public IPEndPoint IpEndPoint { get; set; }
//}
//void ReceiveCallBack(IAsyncResult asyncResult)
//{
//    var udpClient = asyncResult.AsyncState;
//}

// add UDP Listener
