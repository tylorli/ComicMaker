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

namespace ComicMaker
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            
            InitializeComponent();
            CC.UserControl1 = this.userControl11;
            CC.UserControl2 = this.userControl21;
            CC.combox = this.comboBox1;
            CC.listbox = this.listBox1;
            comboBox1.SelectedItem = "金发女";
        }

        private void pen_Click(object sender, EventArgs e)
        {
            CC.UserControl2.ActiveTool = UserControl2.ToolType.Curve;
        }
        private void Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Multiselect = false;
            f.CheckPathExists = true;
            f.Title = "添加图像";
            f.Filter = "JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|PNG (*.png)|*.png|GIF (*.gif)|*.gif|All files|*.*";
            if (f.ShowDialog() == DialogResult.OK)
            {
                CC.bitmap = (Bitmap)Bitmap.FromFile(f.FileName, true);
                CC.UserControl2.ActiveTool = UserControl2.ToolType.Image;
            }
        }

        private void buttonletter_Click(object sender, EventArgs e)
        {
             CC.UserControl2.ActiveTool = UserControl2.ToolType.Text;
        }
        private void SelectClearButton_Click(object sender, EventArgs e)
        {
            CC.DeleteSelection();
            ObjectId.AddObjtoListBox();
            CC.UserControl2.ActiveTool = UserControl2.ToolType.Pointer;
        }

        private void SelectAllbutton_Click(object sender, EventArgs e)
        {
            CC.SelectAll();
            CC.UserControl2.ActiveTool = UserControl2.ToolType.Pointer;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedItem.ToString();
            switch (s)
            {
                case ("金发女"):
                    this.userControl11.refreashPicBox(0);
                    break;
                case ("日和"):
                    this.userControl11.refreashPicBox(1);
                    break;
                case ("金大爷"):
                    this.userControl11.refreashPicBox(2);
                    break;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CC.a = 1;
            MessageBox.Show("进入联机状态");
        }

    }
}

