using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ComicMaker
{
    /// <summary>
    /// 所有绘图对象的基类
    /// </summary>
    [Serializable]
    public abstract class DrawObject
    {
        public Color PenColor { get; set; }//画笔的颜色
        public int PenWidth { get; set; }//画笔的粗细
        public int ID { get; set; }//绘制图像的ID
        public abstract void Draw(Graphics g);//绘图方法
        public bool Selected { get; set; }// 是否选择了该对象
        //public string RichText { get; set; }//RichTextBox中的文字
        /// <summary>句柄数</summary>
        public abstract int HandleCount { get; }
        /// <summary>获取句柄所在的点</summary>
        public abstract Point GetHandle(int handleNumber);
        /// <summary>取句柄的实体矩形</summary>
        public abstract Rectangle GetHandleRectangle(int handleNumber);
        /// <summary>绘制句柄</summary>
        public abstract void DrawTracker(Graphics g);
        /// <summary>判断是否选中该对象及句柄</summary>
        public abstract int HitHandleTest(Point point);
        /// <summary>判断该点是否在对象范围内</summary>
        public abstract bool PointInObject(Point point);
        /// <summary>根据句柄取光标类型</summary>
        public abstract Cursor GetHandleCursor(int handleNumber);
        /// <summary>判断是否相交</summary>
        public abstract bool IntersectsWith(Rectangle rectangle);
        /// <summary>移动对象</summary>
        public abstract void Move(int deltaX, int deltaY);
        /// <summary>移动句柄</summary>
        public abstract void MoveHandleTo(Point point, int handleNumber);

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
