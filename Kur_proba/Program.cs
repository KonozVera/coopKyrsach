using System.Net;
using System.Net.Sockets;

TcpListener listener = new TcpListener(IPAddress.Parse("26.180.175.71"), 7777);
listener.Start();
listener.AcceptTcpClient();