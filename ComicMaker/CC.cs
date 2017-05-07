using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ComicMaker
{
    class CC
    {
        public static UserControl1 UserControl1 { get; set; }
        public static UserControl2 UserControl2 { get; set; }
        public static int a = 0;
        public static List<DrawObject> graphicsList = new List<DrawObject>();
        public static Dictionary<ImageList, int> imagelists = new Dictionary<ImageList, int>();
        public static ComboBox combox = new ComboBox();
        public static ListBox listbox = new ListBox();
        public static Bitmap bitmap { get; set; }
        public static Color color { get; set; }
        /// <summary>是否画鼠标左键拖放范围的矩形框</summary>
        public static bool IsDrawNetRectangle { get; set; }
        /// <summary>鼠标左键拖放范围矩形大小及位置</summary>
        public static Rectangle NetRectangle { get; set; }
        /// <summary>用于判断焦点形状</summary>
        public static bool isToolPoint;
 //       public static RichTextBox richtextbox { get; set; }

        private static int autoID = 0;
        /// <summary>获取新对象的ID</summary>
        public static int GetNewID()
        {
            return autoID++;
        }
        /// <summary>当前对象的ID</summary>
        public static int ID { get; set; }
        //计算两点间的距离
        public static float GetDistance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int distance = (int)Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }
        /// <summary>
        /// 查找ID在graphicsList中的索引号，如果找不到返回-1
        /// </summary>
        /// <param name="ID">对象的ID</param>
        /// <returns>对象在graphicsList中的索引号，-1表示未找到</returns>
        public static int FindObjectIndex(int ID)
        {
            int index = -1;
            for (int i = 0; i < graphicsList.Count; i++)
            {
                if (graphicsList[i].ID == ID)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static void UnselectAll()
        {
            foreach (DrawObject w in graphicsList)
            {
                w.Selected = false;
            }
            CC.UserControl2.Refresh();
        }

        public static void SelectAll()
        {
            foreach (DrawObject w in graphicsList)
            {
                w.Selected = true;
            }
            CC.UserControl2.Refresh();
        }


        public static int SelectionCount
        {
            get
            {
                int n = 0;
                foreach (DrawObject w in graphicsList)
                {
                    if (w.Selected) n++;
                }
                return n;
            }
        }
        public static DrawObject GetSelectedObject(int index)
        {
            int n = -1;
            foreach (DrawObject w in graphicsList)
            {
                if (w.Selected)
                {
                    n++;
                    if (n == index)
                        return w;
                }
            }
            return null;
        }

        public static void DeleteSelection()
        {
            int n = graphicsList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                if (graphicsList[i].Selected)
                {
                    if (graphicsList[i].ToString().Split('.')[1] == "DrawText")
                    {
                        DrawText dt = (DrawText)graphicsList[i];
                        dt.DeletRichTextBox();
                    }
                    graphicsList.RemoveAt(i);
                }
            }
            CC.UserControl2.Refresh();
        }
               /// <summary>当从右向左选择时，将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        /// <summary>当从右向左选择时，将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }
        /// <summary>当从右向左选择时，将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }
        /// <summary>设置矩形框内选择的对象</summary>
        public static void SelectInRectangle(Rectangle rectangle)
        {
            foreach (DrawObject w in graphicsList)
            {
                if (w.IntersectsWith(rectangle))
                    w.Selected = true;
            }
        }
    }
}
