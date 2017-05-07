using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComicMaker
{
    public partial class UserControl1 : UserControl
    {
        int PicNum = 0;
        PictureBox[] pb;
        List<PictureBox> PBList = new List<PictureBox>();
        public UserControl1()
        {
            InitializeComponent();
            CC.imagelists.Add(imageList1, 0);
            CC.imagelists.Add(imageList2, 1);
            CC.imagelists.Add(imageList3, 2);
            AddImagelisttoPBList(imageList1);
            AddPicBox();
        }
        public void refreashPicBox(int ImageListIndex)
        {
            delePicBox();
            PBList.Clear();
            ImageList CurrentImageList = this.GetImageList(ImageListIndex);
            AddImagelisttoPBList(CurrentImageList);
            AddPicBox();
        }

        public void AddImagelisttoPBList(ImageList CurrentImageList)
        {
            PicNum = CurrentImageList.Images.Count;
            pb = new PictureBox[PicNum];
            for (int i = 0; i < PicNum; i++)
            {
                pb[i] = new PictureBox();
                pb[i].BorderStyle = BorderStyle.FixedSingle;
                pb[i].Size = new System.Drawing.Size(100, 100);
                pb[i].SizeMode = PictureBoxSizeMode.Normal;
                pb[i].Image = CurrentImageList.Images[i];
                pb[i].Visible = false;
               // pb[i].
                this.Controls.Add(pb[i]);
            }
            this.PBList.AddRange(pb);
        }

        public ImageList GetImageList(int ImageListIndex)
        {
            foreach (KeyValuePair<ImageList, int> k in CC.imagelists)
            {
                if (k.Value == ImageListIndex)
                {
                    PicNum = k.Key.Images.Count;
                    return k.Key;
                }
            }
            return null;
        }

        public void AddPicBox()
        {
            int x = PBList.Count;
            int i = 0;
            foreach (PictureBox item in PBList)
            {
                int j = i % 2;
                int k = (i - 1) / 2;
                if (j == 1)
                {
                    item.Location = new Point(102, 102 * k);
                }
                else
                {
                    item.Location = new Point(0, 102 * k);
                }
                item.Enabled = false;
                item.Visible = true;
                i++;
            }
        }

        public void delePicBox()
        {
            foreach (PictureBox item in PBList)
            {
                item.Dispose();
            }
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            int t = e.X / 102  + (e.Y / 102)*2;
            if (0 <= t && t < PBList.Count)
            {
                CC.bitmap = (Bitmap)PBList[t].Image;
                CC.UserControl2.ActiveTool = UserControl2.ToolType.Image;
            }
        }





    }
}
