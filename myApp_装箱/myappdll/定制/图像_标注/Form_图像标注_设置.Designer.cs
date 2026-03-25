namespace myappdll
{
    partial class Form_图像标注_设置
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_图像标注_设置));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiListBox_对象 = new Sunny25.UIListBox();
            this.工具栏1 = new Sunny25.工具栏();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_添加 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_标注 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiButton2 = new Sunny25.UIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.工具栏1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiButton2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 704);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiListBox_对象);
            this.panel1.Controls.Add(this.工具栏1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(831, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 628);
            this.panel1.TabIndex = 1;
            // 
            // uiListBox_对象
            // 
            this.uiListBox_对象.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiListBox_对象.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiListBox_对象.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiListBox_对象.ItemSelectForeColor = System.Drawing.SystemColors.Control;
            this.uiListBox_对象.Location = new System.Drawing.Point(0, 0);
            this.uiListBox_对象.Margin = new System.Windows.Forms.Padding(0);
            this.uiListBox_对象.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox_对象.Name = "uiListBox_对象";
            this.uiListBox_对象.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox_对象.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiListBox_对象.Size = new System.Drawing.Size(69, 628);
            this.uiListBox_对象.Style = Sunny25.UIStyle.Custom;
            this.uiListBox_对象.StyleCustomMode = true;
            this.uiListBox_对象.TabIndex = 0;
            this.uiListBox_对象.Text = "uiListBox1";
            this.uiListBox_对象.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiListBox_对象_MouseDown);
            // 
            // 工具栏1
            // 
            this.工具栏1.BackColor = System.Drawing.Color.Transparent;
            this.工具栏1.Dock = System.Windows.Forms.DockStyle.Right;
            this.工具栏1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.工具栏1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.工具栏1.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.工具栏1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripButton_添加,
            this.toolStripSeparator1,
            this.toolStripButton_标注,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator5});
            this.工具栏1.Location = new System.Drawing.Point(69, 0);
            this.工具栏1.Name = "工具栏1";
            this.工具栏1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.工具栏1.ShowItemToolTips = false;
            this.工具栏1.Size = new System.Drawing.Size(75, 628);
            this.工具栏1.TabIndex = 1;
            this.工具栏1.Text = "工具栏1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripButton_添加
            // 
            this.toolStripButton_添加.AutoSize = false;
            this.toolStripButton_添加.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_添加.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_添加.Image")));
            this.toolStripButton_添加.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_添加.Name = "toolStripButton_添加";
            this.toolStripButton_添加.Size = new System.Drawing.Size(70, 50);
            this.toolStripButton_添加.Text = "添加";
            this.toolStripButton_添加.Click += new System.EventHandler(this.toolStripButton_添加_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripButton_标注
            // 
            this.toolStripButton_标注.AutoSize = false;
            this.toolStripButton_标注.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_标注.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_标注.Image")));
            this.toolStripButton_标注.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_标注.Name = "toolStripButton_标注";
            this.toolStripButton_标注.Size = new System.Drawing.Size(70, 50);
            this.toolStripButton_标注.Text = "标注";
            this.toolStripButton_标注.Click += new System.EventHandler(this.toolStripButton_标注_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(70, 50);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(64, 6);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(822, 628);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 15.02609F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(831, 637);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Size = new System.Drawing.Size(144, 64);
            this.uiButton2.Style = Sunny25.UIStyle.Red;
            this.uiButton2.StyleCustomMode = true;
            this.uiButton2.TabIndex = 4;
            this.uiButton2.Text = "关闭";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // Form_图像标注_设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 739);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_图像标注_设置";
            this.ShowInTaskbar = false;
            this.Text = "设置图像";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.操作按钮颜色 = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_图像标注_设置_FormClosing);
            this.Load += new System.EventHandler(this.Form_设置_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.工具栏1.ResumeLayout(false);
            this.工具栏1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Sunny25.UIListBox uiListBox_对象;
        private Sunny25.工具栏 工具栏1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_添加;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_标注;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Sunny25.UIButton uiButton2;
        internal System.Windows.Forms.PictureBox pictureBox1;
    }
}