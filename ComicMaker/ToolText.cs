using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ComicMaker
{
    class ToolText : ToolObject
    {
        public override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            CC.ID = CC.GetNewID();
            DrawText w = new DrawText(e.X, e.Y, 10, 10, CC.ID);
            AddNewObject(w);
            isNewObjectAdded = true;
        }
        public override void OnMouseMove(MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                int index = CC.FindObjectIndex(CC.ID);
                DrawText w = (DrawText)CC.graphicsList[index];
                int x = w.objRectangle.X;
                int y = w.objRectangle.Y;
                w.X = x;
                w.Y = y;
                w.Width = e.X - x;
                w.Height = e.Y - y;
                Rectangle rect = new Rectangle(x, y, e.X - x, e.Y - y);
                w.objRectangle = rect;
                CC.UserControl2.Controls.Add(w.RichTextBox);
            }
            CC.UserControl2.Refresh();
        }
        public override void OnMouseUp(MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            base.OnMouseUp(e);
        }
    }
}
