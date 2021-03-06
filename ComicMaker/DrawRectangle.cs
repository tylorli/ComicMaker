﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ComicMaker
{
    [Serializable]
    public class DrawRectangle : DrawObject
    {
        public Rectangle objRectangle;
        public DrawRectangle() { }


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

        public DrawRectangle(int x, int y, int width, int height, Color penColor, int id)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.objRectangle = new Rectangle(x, y, width, height);
            this.PenColor = penColor;
            this.ID = id;
        }
        //重写基类的方法
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(this.PenColor))
            {
                g.DrawRectangle(pen, this.objRectangle);
            }
        }

        /// <summary>画句柄并填充</summary>
        public override void DrawTracker(Graphics g)
        {
            using(SolidBrush brush = new SolidBrush(Color.Black))
            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }
        }
        /// <summary>取句柄点数</summary>
        public override int HandleCount
        {
            get { return 8; }
        }
        /// <summary>取句柄所在的点</summary>
        public override Point GetHandle(int handleNumber)
        {
            Rectangle rect = new Rectangle(objRectangle.X, objRectangle.Y, objRectangle.Width, objRectangle.Height);
            int x = rect.X;
            int y = rect.Y;
            int xCenter = x + rect.Width / 2;
            int yCenter = y + rect.Height / 2;
            switch (handleNumber)
            {
                case 1:
                    x = rect.X;
                    y = rect.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rect.Y;
                    break;
                case 3:
                    x = rect.Right;
                    y = rect.Y;
                    break;
                case 4:
                    x = rect.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rect.Right;
                    y = rect.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rect.Bottom;
                    break;
                case 7:
                    x = rect.X;
                    y = rect.Bottom;
                    break;
                case 8:
                    x = rect.X;
                    y = yCenter;
                    break;
            }
            return new Point(x, y);
        }
        /// <summary>判断点是否在该对象范围内</summary>
        public override bool PointInObject(Point point)
        {
            return objRectangle.Contains(point);
        }
        /// <summary>移动句柄</summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            Rectangle rect = new Rectangle(objRectangle.X, objRectangle.Y, objRectangle.Width, objRectangle.Height);
            int left = rect.Left;
            int top = rect.Top;
            int right = rect.Right;
            int bottom = rect.Bottom;
            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }
            //int x = objRectangle.X;
            //int y = objRectangle.Y;
            objRectangle = CC.GetNormalizedRectangle(left, top, right, bottom);
        }
        /// <summary>判断是否相交</summary>
        public override bool IntersectsWith(Rectangle rectangle)
        {
            return objRectangle.IntersectsWith(rectangle);
        }
        /// <summary>移动对象</summary>
        public override void Move(int deltaX, int deltaY)
        {
            objRectangle.X += deltaX;
            objRectangle.Y += deltaY;
        }
        /// <summary>取句柄所在的矩形</summary>
        public override Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
            int x = point.X;
            int y = point.Y;
            if (handleNumber == 1) { x -= 4; y -= 4; }
            else if (handleNumber == 2) { x -= 2; y -= 4; }
            else if (handleNumber == 3) { x += 2; y -= 4; }
            else if (handleNumber == 4) { x += 2; y -= 2; }
            else if (handleNumber == 5) { x += 2; y += 2; }
            else if (handleNumber == 6) { x -= 2; y += 2; }
            else if (handleNumber == 7) { x -= 4; y += 2; }
            else if (handleNumber == 8) { x -= 4; y -= 2; }
            return new Rectangle(x, y, 5, 5);
        }
        /// <summary>判定该对象和句柄是否被选中</summary>
        public override int HitHandleTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                    {
                        return i;
                    }
                }
            }
            if (PointInObject(point))
            {
                return 0;
            }
            return -1;
        }
        /// <summary>根据句柄，获得光标的形状</summary>
        public override Cursor  GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }
    }
}
