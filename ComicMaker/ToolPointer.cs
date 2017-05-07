using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ComicMaker
{
    class ToolPointer:ToolObject
    {
        private enum SelectionMode
        {
            None,//初始状态
            NetSelection,//选择图形图像模式
            Move,//移动
            Size//调整大小
        }
        private SelectionMode selectMode = SelectionMode.None;
        private DrawObject resizedObject;
        private int resizedObjectHandle;

        private Point lastPoint = new Point(0, 0);
        private Point startPoint = new Point(0, 0);

        public ToolPointer()
        {
        }
        public override void OnMouseDown(MouseEventArgs e)
        {
            CC.isToolPoint = true;
            Point p = new Point(e.X, e.Y);
            selectMode = SelectionMode.None;
            int n = CC.SelectionCount;
            //Size
            for (int i = n - 1; i >= 0; i--)
            {
                DrawObject w = CC.GetSelectedObject(i);
                int handleNumber = w.HitHandleTest(p);
                if (handleNumber > 0)
                {
                    //状态设置
                    selectMode = SelectionMode.Size;
                    resizedObject = w;
                    resizedObjectHandle = handleNumber;
                    //重置选中状态
                    CC.UnselectAll();
                    w.Selected = true;
                    break;
                }
            }
            //不需调整Size，查找是否位于对象中
            if (selectMode == SelectionMode.None)
            {
                int n1 = CC.graphicsList.Count;
                DrawObject w = null;
                //查找点是否位于某个对象中
                for (int i = n1 - 1; i >= 0; i--)
                {
                    if (CC.graphicsList[i].HitHandleTest(p) == 0)
                    {
                        w = CC.graphicsList[i];
                        break;
                    }
                }
                //如果位于某个图像内
                if (w != null)
                {
                    selectMode = SelectionMode.Move;
                    if ((Control.ModifierKeys & Keys.Control) == 0 && !w.Selected)
                        CC.UnselectAll();
                    w.Selected = true;
                    CC.UserControl2.Cursor = Cursors.SizeAll;
                }
            }
            //不改变大小、不在某个对象内，鼠标按下为绘制虚框
            if (selectMode == SelectionMode.None)
            {
                if ((Control.ModifierKeys & Keys.Control) == 0)
                {
                    CC.UnselectAll();
                }
                selectMode = SelectionMode.NetSelection;
                CC.IsDrawNetRectangle = true;
            }
            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            startPoint.X = p.X;
            startPoint.Y = p.Y;
            CC.UserControl2.Capture = true;
            CC.NetRectangle = CC.GetNormalizedRectangle(startPoint, lastPoint);
            CC.UserControl2.Refresh();
        }
        /// <summary>鼠标移动事件</summary>
        public override void OnMouseMove(MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            //没有按下任何鼠标键，鼠标状态发生变化
            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = null;
                //设置鼠标状态
                if (CC.graphicsList != null)
                {
                    for (int i = CC.graphicsList.Count - 1; i >= 0; i--)
                    {
                        int n = CC.graphicsList[i].HitHandleTest(p);
                        //对象区域内，不在句柄上
                        if (n == 0)
                        {
                            cursor = Cursors.Hand;//选择
                        }
                        //句柄上
                        if (n > 0)
                        {
                            cursor = CC.graphicsList[i].GetHandleCursor(n);
                            break;
                        }
                    }
                }
                ////对已经选中的对象
                //if (cursor == null)
                //{
                //    int x = 0;
                //    for (int j = CC.graphicsList.Count - 1; j >= 0; j--)
                //    {
                //        if (CC.graphicsList[j].Selected)
                //        {
                //            x++;
                //        }
                //    }
                //    if (x == 1)
                //    {

                //        for (int j = CC.graphicsList.Count - 1; j >= 0; j--)
                //        {
                //            if (CC.graphicsList[j].Selected && CC.graphicsList[j].PointInObject(p))
                //            {
                //                cursor = Cursors.NoMove2D;
                //            }
                //        }
                //    }
                //}
                CC.UserControl2.Cursor = cursor;
                return;
            }
            if (e.Button != MouseButtons.Left) return;
            //鼠标左键处理，调整大小、移动位置、绘制矩形虚选框
            int dx = p.X - lastPoint.X;
            int dy = p.Y - lastPoint.Y;

            lastPoint.X = p.X;
            lastPoint.Y = p.Y;

            if (selectMode == SelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    resizedObject.MoveHandleTo(p, resizedObjectHandle);
                    CC.UserControl2.Refresh();
                }
            }
            if (selectMode == SelectionMode.Move)
            {
                int n = CC.SelectionCount;
                for (int i = n - 1; i >= 0; i--)
                {
                    CC.GetSelectedObject(i).Move(dx, dy);
                }
                CC.UserControl2.Cursor = Cursors.SizeAll;
                CC.UserControl2.Refresh();
            }
            if (selectMode == SelectionMode.NetSelection)
            {
                //对应Draw方法
                CC.NetRectangle = CC.GetNormalizedRectangle(startPoint, lastPoint);
                CC.UserControl2.Refresh();
                return;
            }
        }
        public override void OnMouseUp(MouseEventArgs e)
        {
            if (selectMode == SelectionMode.NetSelection)
            {
                //设置矩形区域内的对象为选中状态
                CC.SelectInRectangle(CC.NetRectangle);
                //恢复初始状态
                selectMode = SelectionMode.None;
                //说明不再进行虚线矩形绘制
                CC.IsDrawNetRectangle = false;
            }
            //int dx = (int)(lastPoint.X - startPoint.X);
            //int dy = (int)(lastPoint.Y - startPoint.Y);

            if (resizedObject != null)
            {
                resizedObject = null;
            }
            CC.UserControl2.Capture = false;
            CC.UserControl2.Refresh();
        }
    }
}
