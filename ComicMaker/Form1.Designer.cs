namespace ComicMaker
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.SelectAllbutton = new System.Windows.Forms.Button();
            this.SelectClearButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Image = new System.Windows.Forms.Button();
            this.pen = new System.Windows.Forms.Button();
            this.buttonletter = new System.Windows.Forms.Button();
            this.userControl21 = new ComicMaker.UserControl2();
            this.userControl11 = new ComicMaker.UserControl1();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "金发女",
            "日和",
            "金大爷"});
            this.comboBox1.Location = new System.Drawing.Point(17, 55);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "漫画制作器";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(724, 10);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(724, 38);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "预览";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(724, 97);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(108, 292);
            this.listBox1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(721, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "对象列表：";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blissful not giving a fuck.png");
            this.imageList1.Images.SetKeyName(1, "drunk.png");
            this.imageList1.Images.SetKeyName(2, "EpicFailGuy.png");
            this.imageList1.Images.SetKeyName(3, "freddiesoclose.png");
            this.imageList1.Images.SetKeyName(4, "Grandma Shit.png");
            this.imageList1.Images.SetKeyName(5, "nothingtodohere.png");
            this.imageList1.Images.SetKeyName(6, "o face tears and sweat so sweet i love the release mmm yeah.png");
            this.imageList1.Images.SetKeyName(7, "oh god eesh.png");
            this.imageList1.Images.SetKeyName(8, "oh god.png");
            this.imageList1.Images.SetKeyName(9, "omgrun.png");
            this.imageList1.Images.SetKeyName(10, "pffttchhchh busted.png");
            this.imageList1.Images.SetKeyName(11, "rage confused.png");
            this.imageList1.Images.SetKeyName(12, "spiderpman.png");
            this.imageList1.Images.SetKeyName(13, "ThrowUpInMouth.png");
            this.imageList1.Images.SetKeyName(14, "TrueStory.png");
            this.imageList1.Images.SetKeyName(15, "what.png");
            this.imageList1.Images.SetKeyName(16, "youthful fear.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "01blondehair.png");
            this.imageList2.Images.SetKeyName(1, "blonde_big smile.png");
            this.imageList2.Images.SetKeyName(2, "blonde_concentrated.png");
            this.imageList2.Images.SetKeyName(3, "blonde_crying.png");
            this.imageList2.Images.SetKeyName(4, "blonde_dazed.png");
            this.imageList2.Images.SetKeyName(5, "blonde_determined.png");
            this.imageList2.Images.SetKeyName(6, "blonde_dude.png");
            this.imageList2.Images.SetKeyName(7, "blonde_dumbfounded.png");
            this.imageList2.Images.SetKeyName(8, "blonde_ewbte.png");
            this.imageList2.Images.SetKeyName(9, "blonde_excited bliss.png");
            this.imageList2.Images.SetKeyName(10, "blonde_excited tears.png");
            this.imageList2.Images.SetKeyName(11, "blonde_excited.png");
            this.imageList2.Images.SetKeyName(12, "blonde_facepalm.png");
            this.imageList2.Images.SetKeyName(13, "blonde_fake smile.png");
            this.imageList2.Images.SetKeyName(14, "blonde_forever alone.png");
            this.imageList2.Images.SetKeyName(15, "blonde_fuck that bitch.png");
            this.imageList2.Images.SetKeyName(16, "blonde_fuck yeah.png");
            this.imageList2.Images.SetKeyName(17, "blonde_happy.png");
            this.imageList2.Images.SetKeyName(18, "blonde_hmmm.png");
            this.imageList2.Images.SetKeyName(19, "blonde_i wonder.png");
            this.imageList2.Images.SetKeyName(20, "blonde_lean.png");
            this.imageList2.Images.SetKeyName(21, "blonde_lol.png");
            this.imageList2.Images.SetKeyName(22, "blonde_me gusta.png");
            this.imageList2.Images.SetKeyName(23, "blonde_milk.png");
            this.imageList2.Images.SetKeyName(24, "blonde_normal.png");
            this.imageList2.Images.SetKeyName(25, "blonde_normal2.png");
            this.imageList2.Images.SetKeyName(26, "blonde_okay.png");
            this.imageList2.Images.SetKeyName(27, "blonde_pfft.png");
            this.imageList2.Images.SetKeyName(28, "blonde_quite.png");
            this.imageList2.Images.SetKeyName(29, "blonde_rage canadian.png");
            this.imageList2.Images.SetKeyName(30, "blonde_rage extreme.png");
            this.imageList2.Images.SetKeyName(31, "blonde_rage extreme2.png");
            this.imageList2.Images.SetKeyName(32, "blonde_rage foaming.png");
            this.imageList2.Images.SetKeyName(33, "blonde_rage getting pissed.png");
            this.imageList2.Images.SetKeyName(34, "blonde_rage mad.png");
            this.imageList2.Images.SetKeyName(35, "blonde_rage mad2.png");
            this.imageList2.Images.SetKeyName(36, "blonde_rage quiet.png");
            this.imageList2.Images.SetKeyName(37, "blonde_rage shaking.png");
            this.imageList2.Images.SetKeyName(38, "blonde_rage super.png");
            this.imageList2.Images.SetKeyName(39, "blonde_rage.png");
            this.imageList2.Images.SetKeyName(40, "blonde_rage2.png");
            this.imageList2.Images.SetKeyName(41, "blonde_really determined.png");
            this.imageList2.Images.SetKeyName(42, "blonde_red tongue.png");
            this.imageList2.Images.SetKeyName(43, "blonde_smile.png");
            this.imageList2.Images.SetKeyName(44, "blonde_sweet tears.png");
            this.imageList2.Images.SetKeyName(45, "blonde_tongue down.png");
            this.imageList2.Images.SetKeyName(46, "blonde_troll sad.png");
            this.imageList2.Images.SetKeyName(47, "blonde_troll.png");
            this.imageList2.Images.SetKeyName(48, "blonde_what.png");
            this.imageList2.Images.SetKeyName(49, "blonde_why no hands.png");
            this.imageList2.Images.SetKeyName(50, "blonde_why.png");
            this.imageList2.Images.SetKeyName(51, "blonde_wut.png");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "日和01.png");
            this.imageList3.Images.SetKeyName(1, "日和02.png");
            this.imageList3.Images.SetKeyName(2, "日和03.png");
            this.imageList3.Images.SetKeyName(3, "日和04.png");
            this.imageList3.Images.SetKeyName(4, "日和05.png");
            this.imageList3.Images.SetKeyName(5, "日和06.png");
            this.imageList3.Images.SetKeyName(6, "日和07.png");
            this.imageList3.Images.SetKeyName(7, "日和08.png");
            this.imageList3.Images.SetKeyName(8, "日和09.png");
            this.imageList3.Images.SetKeyName(9, "日和10.png");
            this.imageList3.Images.SetKeyName(10, "日和11.png");
            this.imageList3.Images.SetKeyName(11, "日和12.png");
            // 
            // SelectAllbutton
            // 
            this.SelectAllbutton.Location = new System.Drawing.Point(638, 10);
            this.SelectAllbutton.Name = "SelectAllbutton";
            this.SelectAllbutton.Size = new System.Drawing.Size(75, 23);
            this.SelectAllbutton.TabIndex = 12;
            this.SelectAllbutton.Text = "全选对象";
            this.SelectAllbutton.UseVisualStyleBackColor = true;
            this.SelectAllbutton.Click += new System.EventHandler(this.SelectAllbutton_Click);
            // 
            // SelectClearButton
            // 
            this.SelectClearButton.Location = new System.Drawing.Point(638, 39);
            this.SelectClearButton.Name = "SelectClearButton";
            this.SelectClearButton.Size = new System.Drawing.Size(75, 23);
            this.SelectClearButton.TabIndex = 13;
            this.SelectClearButton.Text = "清除选中";
            this.SelectClearButton.UseVisualStyleBackColor = true;
            this.SelectClearButton.Click += new System.EventHandler(this.SelectClearButton_Click);
            // 
            // button3
            // 
            this.button3.Image = global::ComicMaker.Properties.Resources.网络;
            this.button3.Location = new System.Drawing.Point(501, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 48);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Image
            // 
            this.Image.Image = global::ComicMaker.Properties.Resources.文件;
            this.Image.Location = new System.Drawing.Point(380, 14);
            this.Image.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(90, 46);
            this.Image.TabIndex = 4;
            this.Image.UseVisualStyleBackColor = true;
            this.Image.Click += new System.EventHandler(this.Image_Click);
            // 
            // pen
            // 
            this.pen.Image = global::ComicMaker.Properties.Resources.画笔;
            this.pen.Location = new System.Drawing.Point(263, 13);
            this.pen.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(91, 46);
            this.pen.TabIndex = 3;
            this.pen.UseVisualStyleBackColor = true;
            this.pen.Click += new System.EventHandler(this.pen_Click);
            // 
            // buttonletter
            // 
            this.buttonletter.Location = new System.Drawing.Point(181, 25);
            this.buttonletter.Name = "buttonletter";
            this.buttonletter.Size = new System.Drawing.Size(75, 23);
            this.buttonletter.TabIndex = 16;
            this.buttonletter.Text = "文字";
            this.buttonletter.UseVisualStyleBackColor = true;
            this.buttonletter.Click += new System.EventHandler(this.buttonletter_Click);
            // 
            // userControl21
            // 
            this.userControl21.ActiveTool = ComicMaker.UserControl2.ToolType.Pointer;
            this.userControl21.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.userControl21.Location = new System.Drawing.Point(237, 79);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(467, 311);
            this.userControl21.TabIndex = 15;
            // 
            // userControl11
            // 
            this.userControl11.AutoScroll = true;
            this.userControl11.Location = new System.Drawing.Point(1, 79);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(220, 310);
            this.userControl11.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 401);
            this.Controls.Add(this.buttonletter);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.SelectClearButton);
            this.Controls.Add(this.SelectAllbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.pen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FormMain";
            this.Text = "漫画制作器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pen;
        private System.Windows.Forms.Button Image;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.Button SelectAllbutton;
        private System.Windows.Forms.Button SelectClearButton;
        private ComicMaker.UserControl1 userControl11;
        private UserControl2 userControl21;
        private System.Windows.Forms.Button buttonletter;

    }
}

