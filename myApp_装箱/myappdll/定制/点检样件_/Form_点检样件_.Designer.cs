namespace myappdll
{
    partial class Form_点检样件_
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
            this.uiTextBox1 = new Sunny25.UITextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiButton_添加 = new Sunny25.UIButton();
            this.uiButton_删除 = new Sunny25.UIButton();
            this.uiButton_刷新 = new Sunny25.UIButton();
            this.uiButton2 = new Sunny25.UIButton();
            this.uiButton1 = new Sunny25.UIButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox1.HideSelection = false;
            this.uiTextBox1.Location = new System.Drawing.Point(5, 45);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.MaxLength = 2147483647;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Multiline = true;
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ReadOnly = true;
            this.uiTextBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(124)))));
            this.uiTextBox1.Size = new System.Drawing.Size(520, 601);
            this.uiTextBox1.Style = Sunny25.UIStyle.深色;
            this.uiTextBox1.TabIndex = 0;
            this.uiTextBox1.WordWarp = false;
            this.uiTextBox1.填充颜色 = System.Drawing.Color.White;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiButton_添加);
            this.panel1.Controls.Add(this.uiButton_删除);
            this.panel1.Controls.Add(this.uiButton_刷新);
            this.panel1.Controls.Add(this.uiButton2);
            this.panel1.Controls.Add(this.uiButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(525, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 601);
            this.panel1.TabIndex = 1;
            // 
            // uiButton_添加
            // 
            this.uiButton_添加.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton_添加.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_添加.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton_添加.Location = new System.Drawing.Point(10, 14);
            this.uiButton_添加.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_添加.Name = "uiButton_添加";
            this.uiButton_添加.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_添加.Size = new System.Drawing.Size(77, 51);
            this.uiButton_添加.Style = Sunny25.UIStyle.深色1;
            this.uiButton_添加.StyleCustomMode = true;
            this.uiButton_添加.TabIndex = 0;
            this.uiButton_添加.Text = "添加";
            this.uiButton_添加.Click += new System.EventHandler(this.uiButton_添加_Click);
            // 
            // uiButton_删除
            // 
            this.uiButton_删除.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton_删除.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_删除.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton_删除.Location = new System.Drawing.Point(10, 80);
            this.uiButton_删除.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_删除.Name = "uiButton_删除";
            this.uiButton_删除.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_删除.Size = new System.Drawing.Size(77, 51);
            this.uiButton_删除.Style = Sunny25.UIStyle.深色1;
            this.uiButton_删除.StyleCustomMode = true;
            this.uiButton_删除.TabIndex = 1;
            this.uiButton_删除.Text = "删除";
            this.uiButton_删除.Click += new System.EventHandler(this.uiButton_删除_Click);
            // 
            // uiButton_刷新
            // 
            this.uiButton_刷新.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton_刷新.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_刷新.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton_刷新.Location = new System.Drawing.Point(10, 146);
            this.uiButton_刷新.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_刷新.Name = "uiButton_刷新";
            this.uiButton_刷新.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_刷新.Size = new System.Drawing.Size(77, 51);
            this.uiButton_刷新.Style = Sunny25.UIStyle.深色1;
            this.uiButton_刷新.StyleCustomMode = true;
            this.uiButton_刷新.TabIndex = 2;
            this.uiButton_刷新.Text = "刷新";
            this.uiButton_刷新.Click += new System.EventHandler(this.uiButton_刷新_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton2.Location = new System.Drawing.Point(10, 278);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Size = new System.Drawing.Size(77, 51);
            this.uiButton2.Style = Sunny25.UIStyle.Red;
            this.uiButton2.StyleCustomMode = true;
            this.uiButton2.TabIndex = 4;
            this.uiButton2.Text = "关闭";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton1.Location = new System.Drawing.Point(10, 212);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton1.Size = new System.Drawing.Size(77, 51);
            this.uiButton1.Style = Sunny25.UIStyle.深色1;
            this.uiButton1.StyleCustomMode = true;
            this.uiButton1.TabIndex = 3;
            this.uiButton1.Text = "保存";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // Form_点检样件_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 651);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_点检样件_";
            this.Padding = new System.Windows.Forms.Padding(5, 45, 5, 5);
            this.ShowInTaskbar = false;
            this.Text = "点检样件";
            this.操作按钮颜色 = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form_点检样件__Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny25.UITextBox uiTextBox1;
        private System.Windows.Forms.Panel panel1;
        private Sunny25.UIButton uiButton2;
        private Sunny25.UIButton uiButton1;
        private Sunny25.UIButton uiButton_添加;
        private Sunny25.UIButton uiButton_删除;
        private Sunny25.UIButton uiButton_刷新;
    }
}
