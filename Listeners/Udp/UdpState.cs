using System.Net;
using System.Net.Sockets;

struct UdpState
{
    public UdpClient UdpClient { get; set; }
    public IPEndPoint IpEndPoint { get; set; }
}