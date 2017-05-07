using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ComicMaker
{
    public partial class UserControl2 : UserControl
    {
        Connect conn = new Connect(IPAddress.Loopback, 9999);
       // Connect conn1 = new Connect(IPAddress.Loopback, 8888);
        Serial ss = new Serial();
        NetworkStream ns;
        FileStream fs;
        Socket socket;
        SerialText st;
        byte[] buffer;
        byte[] remark;
        public enum ToolType { Pointer, Rectangle, Text, Curve, Image,count};
        private ToolType activeTool;
        public ToolType ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }
        ToolObject[] tools = new ToolObject[(int)ToolType.count];
        public UserControl2()
        {
            InitializeComponent();
            tools[(int)ToolType.Pointer] = new ToolPointer();
            tools[(int)ToolType.Curve] = new ToolCurve();
            tools[(int)ToolType.Rectangle] = new ToolRectangle();
            tools[(int)ToolType.Text] = new ToolText();
            tools[(int)ToolType.Image] = new ToolImage();
        }
        private void UserControl2_MouseDown(object sender, MouseEventArgs e)
        {
            CC.UserControl2.Capture = false;
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseDown(e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                activeTool = ToolType.Pointer;
            }
        }
        private void UserControl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                tools[(int)activeTool].OnMouseMove(e);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void UserControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseUp(e);
            }
            ObjectId.AddObjtoListBox();
            if (CC.a == 1)
            {
                buffer = new Byte[1024];
                socket = conn.communicate();
                remark = new Byte[10];
                if (CC.graphicsList.Last() is DrawText)
                {
                    DrawText dt = (DrawText)CC.graphicsList.Last();
                    string text = dt.RichText;
                    int x = dt.X;
                    int y = dt.Y;
                    int width = dt.Width;
                    int heigh = dt.Height;
                    int id = dt.ID;
                    st = new SerialText(text, x, y, width, heigh, id);
                    ss.save("graphics.bin", st);
                    for (int i = 0; i < 10; i++)
                    {
                        remark[i] = 0;
                    }
                    socket.Send(remark);
                }
                else
                {
                    ss.save("graphics.bin", CC.graphicsList.Last());
                    for (int i = 0; i < 10; i++)
                    {
                        remark[i] = 1;
                    }
                    socket.Send(remark);
                }

                ns = new NetworkStream(socket);
                fs = new FileStream("graphics.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                int n;
                n = fs.Read(buffer, 0, buffer.Length);
                while (true)
                {
                    if (n == 0)
                        break;
                    ns.Write(buffer, 0, n);
                    n = fs.Read(buffer, 0, buffer.Length);
                }
                fs.Close();
                ns.Close();
                socket.Close();
                this.Refresh();
            }

        }
        private void UserControl2_Paint(object sender, PaintEventArgs e)
        {
            int x1 = (int)this.Size.Width / 2;
            int y1 = (int)this.Size.Height / 2;
            Point p1=new Point(0, y1);
            Point p2 = new Point(467, y1);
            Point p3=new Point (x1,0);
            Point p4=new Point (x1,311);
            Pen pen = new Pen(Color.Gray, 1);
            Graphics g = e.Graphics;
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
            DrawObject w;
            for (int i = 0; i < CC.graphicsList.Count; i++)
            {
                w = CC.graphicsList[i];
                if (w.IntersectsWith(Rectangle.Round(g.ClipBounds)))
                {
                    w.Draw(g);
                }
                //绘制句柄
                if (w.Selected == true)
                {
                    w.DrawTracker(g);
                }
            }
            //画鼠标左键拖放范围的选择框
            if (CC.IsDrawNetRectangle == true)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, CC.NetRectangle, Color.Black, Color.Transparent);
            }
        }
    }
}
