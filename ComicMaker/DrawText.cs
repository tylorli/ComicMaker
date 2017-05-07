using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComicMaker
{
    [Serializable]
    public class DrawText : DrawRectangle
    {
        private RichTextBox richTextBox;
        private GraphicsPath gRect;
        private string richtext="输入文字";

        public string RichText
        {
            get { return richtext; }
            set { richtext = value; }
        }
        public GraphicsPath GRect
        {
            get { return gRect; }
            set { gRect = value; }
        }
        public RichTextBox RichTextBox
        {
            get { return richTextBox; }
            set { richTextBox = value; }
        }

        PointF[] pt = new PointF[3];
        public DrawText(int x, int y, int width, int height, int id)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.objRectangle = new Rectangle(x, y, width, height);
            this.PenColor = Color.Black;
            this.ID = id;
            this.Selected = false;
            richTextBox = new RichTextBox();
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            using (Pen pen = new Pen(PenColor))
            {
                g.DrawPath(pen, CreateRoundedRectanglePath(3));
                AddRichTextBox();
                if (richTextBox.Text != null)
                {
                    RichText = richTextBox.Text;
                }
            }
        }
        private GraphicsPath CreateRoundedRectanglePath(int cornerRadius)
        {
            pt[0] = new PointF(objRectangle.X, objRectangle.Y + objRectangle.Height - cornerRadius * 2);
            pt[1] = new PointF((float)(objRectangle.X - 2), (float)(objRectangle.Y + objRectangle.Height + 2));
            pt[2] = new PointF(objRectangle.X + cornerRadius * 2, objRectangle.Y + objRectangle.Height);
            GraphicsPath gRect = new GraphicsPath();
            gRect.AddArc(objRectangle.X, objRectangle.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            gRect.AddArc(objRectangle.X + objRectangle.Width - cornerRadius * 2, objRectangle.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            gRect.AddArc(objRectangle.X + objRectangle.Width - cornerRadius * 2, objRectangle.Y + objRectangle.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            gRect.AddLines(pt);
            gRect.CloseFigure();
            return gRect;
        }


        public void AddRichTextBox()
        {
            Point location = new Point(objRectangle.X + 10, objRectangle.Y + 2);
            try
            {
                richTextBox.Location = location;
            }
            catch (Exception ex)
            {
                return;
            }
            richTextBox.Text = RichText;
            richTextBox.BackColor = Color.LightGoldenrodYellow;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.Width = objRectangle.Width - 10;
            richTextBox.Height = objRectangle.Height - 10;
            richTextBox.Visible = true;
        }

        public void DeletRichTextBox()
        {
            this.richTextBox.Dispose();
        }
        public DrawText()
        {
        }
    }
}
