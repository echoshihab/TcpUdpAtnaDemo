﻿// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;


var data = await File.ReadAllBytesAsync(@"C:\audits\sample_audit2.txt");

//await SendTcpMessage(data);
await SendUdpMessage(data);

async Task SendTcpMessage(byte[] data)
{

    var tcpEndpoint = new IPEndPoint(IPAddress.Loopback, 11514);
    using var tcpClient = new TcpClient();
    await tcpClient.ConnectAsync(tcpEndpoint);

    var stream = tcpClient.GetStream();

    await stream.WriteAsync(data, 0, data.Length);

    Console.WriteLine($"Audit sent to: {tcpEndpoint.Address}");

    await Task.Delay(10);

    //var data2 = new byte[256];

    //await stream.ReadAsync(data2, 0, data2.Length, CancellationToken.None);

    //Console.WriteLine(Encoding.ASCII.GetString(data2));

    Console.ReadKey();
}


async Task SendUdpMessage(byte[] data)
{
    var client = new UdpClient();
    var endpoint = new IPEndPoint(IPAddress.Loopback, 514);

    await client.SendAsync(data, endpoint, CancellationToken.None);

    Console.WriteLine($"Audit sent to: {endpoint.Address}");
    Console.ReadKey();
}