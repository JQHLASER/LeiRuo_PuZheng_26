namespace myappdll.定制
{
    partial class Form_尾料
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
            this.uiButton_Yes = new Sunny25.UIButton();
            this.uiButton2 = new Sunny25.UIButton();
            this.uItextBox_QF1 = new Sunny25.UItextBox_QF();
            this.SuspendLayout();
            // 
            // uiButton_Yes
            // 
            this.uiButton_Yes.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton_Yes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_Yes.Font = new System.Drawing.Font("微软雅黑", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Yes.Location = new System.Drawing.Point(84, 229);
            this.uiButton_Yes.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Yes.Name = "uiButton_Yes";
            this.uiButton_Yes.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uiButton_Yes.Size = new System.Drawing.Size(150, 40);
            this.uiButton_Yes.Style = Sunny25.UIStyle.深色1;
            this.uiButton_Yes.StyleCustomMode = true;
            this.uiButton_Yes.TabIndex = 6;
            this.uiButton_Yes.Text = "确定";
            this.uiButton_Yes.Click += new System.EventHandler(this.uiButton_Yes_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(270, 229);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiButton2.Size = new System.Drawing.Size(150, 40);
            this.uiButton2.Style = Sunny25.UIStyle.Red;
            this.uiButton2.StyleCustomMode = true;
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "关闭";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uItextBox_QF1
            // 
            this.uItextBox_QF1.BackColor = System.Drawing.Color.Transparent;
            this.uItextBox_QF1.FillColor = System.Drawing.Color.White;
            this.uItextBox_QF1.Font = new System.Drawing.Font("微软雅黑", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uItextBox_QF1.Font__Textbobox = new System.Drawing.Font("微软雅黑", 10F);
            this.uItextBox_QF1.Font_单位 = new System.Drawing.Font("微软雅黑", 10F);
            this.uItextBox_QF1.Font_标识 = new System.Drawing.Font("微软雅黑", 10F);
            this.uItextBox_QF1.HasMaximum = true;
            this.uItextBox_QF1.HasMinimum = true;
            this.uItextBox_QF1.Location = new System.Drawing.Point(101, 123);
            this.uItextBox_QF1.Margin = new System.Windows.Forms.Padding(4);
            this.uItextBox_QF1.Maximum = 1000D;
            this.uItextBox_QF1.Minimum = 0D;
            this.uItextBox_QF1.Name = "uItextBox_QF1";
            this.uItextBox_QF1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(83)))), ((int)(((byte)(100)))));
            this.uItextBox_QF1.Size = new System.Drawing.Size(252, 29);
            this.uItextBox_QF1.Style = Sunny25.UIStyle.深色1;
            this.uItextBox_QF1.TabIndex = 7;
            this.uItextBox_QF1.Text_Lable1_单位 = "mm";
            this.uItextBox_QF1.Text_Lable1_标识 = "数量:";
            this.uItextBox_QF1.textAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uItextBox_QF1.TextAlign_单位 = System.Drawing.ContentAlignment.MiddleLeft;
            this.uItextBox_QF1.TextAlign_标识 = System.Drawing.ContentAlignment.MiddleRight;
            this.uItextBox_QF1.Type = Sunny25.UITextBox.UIEditType.Integer;
            this.uItextBox_QF1.宽度Lable_单位 = 0;
            this.uItextBox_QF1.宽度Lable_标识 = 100;
            this.uItextBox_QF1.文本颜色_TextBox = System.Drawing.Color.Black;
            this.uItextBox_QF1.文本颜色_单位 = System.Drawing.Color.Black;
            this.uItextBox_QF1.文本颜色_标识 = System.Drawing.Color.Black;
            // 
            // Form_尾料
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 291);
            this.Controls.Add(this.uItextBox_QF1);
            this.Controls.Add(this.uiButton_Yes);
            this.Controls.Add(this.uiButton2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_尾料";
            this.ShowInTaskbar = false;
            this.Text = "尾料";
            this.操作按钮颜色 = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form_尾料_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny25.UIButton uiButton_Yes;
        private Sunny25.UIButton uiButton2;
        private Sunny25.UItextBox_QF uItextBox_QF1;
    }
}