using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicMaker
{
    [Serializable]
    public class SerialText:DrawRectangle
    {
        private string DrawRichText;

        public string DrawRichText1
        {
            get { return DrawRichText; }
            set { DrawRichText = value; }
        }


        //private int x;

        //public int X
        //{
        //    get { return x; }
        //    set { x = value; }
        //}
        //private int y;

        //public int Y
        //{
        //    get { return y; }
        //    set { y = value; }
        //}
        //private int width;

        //public int Width
        //{
        //    get { return width; }
        //    set { width = value; }
        //}
        //private int height;

        //public int Height
        //{
        //    get { return height; }
        //    set { height = value; }
        //}
        //private int id;

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        public SerialText(string text, int x, int y, int width, int height, int id)
        {
            this.DrawRichText1 = text;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.ID = id;
        }
    }
}
