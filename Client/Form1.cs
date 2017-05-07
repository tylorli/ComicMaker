using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using ComicMaker;


namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        Socket socket;
        Socket socket1;
        Socket client1;

        Serial se = new Serial("graphics.bin");
        byte[] receive = new Byte[1024];
        byte[] buffer = new Byte[10];
        bool p = false;
        NetworkStream ns;
        FileStream fs;
        int n = 0;
        public Form1()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Loopback, 9999);
            socket.Bind(iep);
            socket.Listen(10);
            CommenList.panel = this.panel1;
            //socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint iep1 = new IPEndPoint(IPAddress.Loopback, 8888);
            //socket1.Bind(iep1);
            //socket1.Listen(10);

            Thread t = new Thread(communicate);
            t.Start();
        }

        private void communicate()
        {
            int length = 0;
            while (true)
            {
                client = socket.Accept();
                client.Receive(buffer);
                //client1 = socket1.Accept();
                //UserList.userlist.Add(client);
                ns = new NetworkStream(client);
                fs = new FileStream("graphics.bin", FileMode.Create, FileAccess.Write, FileShare.None);

                
                for (int i = 0; i < 10; i++)
                {
                    if (buffer[i] == 1)
                    {
                        p = true;
                        //break;
                    }
                }

                while (true)
                {
                    length = ns.Read(receive, 0, receive.Length);

                    if (length == 0)
                    {
                        break;
                    }
                    fs.Write(receive, 0, length);
                }
                fs.Close();
                ns.Close();
                if (p == true)
                {
                    se.doit();
                    p = false;
                }

                else
                {
                    se.TextSerial();
                }

                client.Close();
                //se.savelist("shapelist.bin", CommenList.list);
                //for (int i = 0; i < UserList.userlist.Count; i++)
                //{
                //    ns = new NetworkStream(UserList.userlist[i]);
                //    fs = new FileStream("shapelist.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                //    int n;
                //    while (true)
                //    {
                //        n = fs.Read(receive, 0, receive.Length);
                //        if (n == 0)
                //            break;
                //        ns.Write(receive, 0, n);
                //    }
                //}
                //fs.Close();
                //ns.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (n < CommenList.list.Count)
            {
                for (int i = 0; i < CommenList.list.Count; i++)
                {
                    using (Pen pen = new Pen(Color.Red))
                    {
                        string s = CommenList.list[i].ToString().Split('.')[1];
                        switch (s)
                        { 
                            case("DrawRectangle"):
                                CommenList.list[i].Draw(e.Graphics);
                                break;
                            case("DrawImage"):
                                CommenList.list[i].Draw(e.Graphics);
                                break;
                            //case ("DrawText"):
                            default:
                                DrawText dt = (DrawText)CommenList.list[i];
                                dt.RichTextBox.Enabled = false;
                                dt.Draw(e.Graphics);
                                dt.AddRichTextBox();
                                dt.Draw(e.Graphics);
                                this.panel1.Controls.Add(dt.RichTextBox);
                                break;
                        }
                        //if(CommenList.list[i].ToString().Split('.')[1]=="DrawRectangle")
                        //CommenList.list[i].Draw(e.Graphics);
                        ////this.Refresh();
                        //if (CommenList.list[i].ToString().Split('.')[1] == "DrawImage")
                        //CommenList.list[i].Draw(e.Graphics);
                        //if (CommenList.list[i].ToString().Split('.')[1] == "DrawText")
                        //{
                        //    DrawText dt = (DrawText)CommenList.list[i];
                        //    dt.RichTextBox.Enabled = false;
                        //    //dt.Initial = true;
                        //    this.panel1.Controls.Add(dt.RichTextBox);
                        //    dt.Draw(e.Graphics);
                        //}
                    }
                }
                n = n + 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                se.openfile("shapelist.bin");
            }
            catch (Exception er)
            {
                MessageBox.Show("File not found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            se.savelist("shapelist.bin", CommenList.list);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DrawObject item in  CommenList.list)
            {
                if (item.ToString().Split('.')[1] == "DrawText")
                {
                    DrawText dt = (DrawText)item;
                    dt.DeletRichTextBox();
                }
            }
            CommenList.list.Clear();
            this.panel1.Refresh();
        }
    }
}
