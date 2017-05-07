using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ComicMaker
{
    class Connect
    {
            private IPAddress ip;
            public IPAddress Ip
            {
                get { return ip; }
                set { ip = value; }
            }
            private int port;

            public int Port
            {
                get { return port; }
                set { port = value; }
            }

            public Connect(IPAddress ip, int port)
            {
                this.ip = ip;
                this.port = port;
            }

            public Socket communicate()
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(this.ip, this.port);
                socket.Connect(iep);
                return socket;
            }

            public void send(byte[] buffer, Socket socket)
            {
                NetworkStream ns = new NetworkStream(socket);
                ns.Write(buffer, 0, buffer.Length);
                ns.Close();
            }
    }
}
