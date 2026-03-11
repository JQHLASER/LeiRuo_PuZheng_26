namespace myappdll
{
    partial class Form_系统参数
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
            this.uiCheckBox_手持扫码枪 = new Sunny25.UICheckBox();
            this.uiButton_保存 = new Sunny25.UIButton();
            this.uiCheckBox_使能Mes = new Sunny25.UICheckBox();
            this.uiCheckBox_使能_打印前弹窗确认 = new Sunny25.UICheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_设备编号 = new System.Windows.Forms.TextBox();
            this.textBox_Mes_Url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiCheckBox_手持扫码枪
            // 
            this.uiCheckBox_手持扫码枪.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiCheckBox_手持扫码枪.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiCheckBox_手持扫码枪.Location = new System.Drawing.Point(76, 172);
            this.uiCheckBox_手持扫码枪.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_手持扫码枪.Name = "uiCheckBox_手持扫码枪";
            this.uiCheckBox_手持扫码枪.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_手持扫码枪.Size = new System.Drawing.Size(160, 29);
            this.uiCheckBox_手持扫码枪.TabIndex = 0;
            this.uiCheckBox_手持扫码枪.Text = "使能_手持扫码枪";
            // 
            // uiButton_保存
            // 
            this.uiButton_保存.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiButton_保存.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton_保存.Location = new System.Drawing.Point(307, 522);
            this.uiButton_保存.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_保存.Name = "uiButton_保存";
            this.uiButton_保存.Size = new System.Drawing.Size(188, 47);
            this.uiButton_保存.TabIndex = 1;
            this.uiButton_保存.Text = "保存";
            // 
            // uiCheckBox_使能Mes
            // 
            this.uiCheckBox_使能Mes.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiCheckBox_使能Mes.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiCheckBox_使能Mes.Location = new System.Drawing.Point(76, 137);
            this.uiCheckBox_使能Mes.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_使能Mes.Name = "uiCheckBox_使能Mes";
            this.uiCheckBox_使能Mes.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_使能Mes.Size = new System.Drawing.Size(160, 29);
            this.uiCheckBox_使能Mes.TabIndex = 2;
            this.uiCheckBox_使能Mes.Text = "使能_mes";
            // 
            // uiCheckBox_使能_打印前弹窗确认
            // 
            this.uiCheckBox_使能_打印前弹窗确认.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiCheckBox_使能_打印前弹窗确认.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiCheckBox_使能_打印前弹窗确认.Location = new System.Drawing.Point(76, 102);
            this.uiCheckBox_使能_打印前弹窗确认.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_使能_打印前弹窗确认.Name = "uiCheckBox_使能_打印前弹窗确认";
            this.uiCheckBox_使能_打印前弹窗确认.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_使能_打印前弹窗确认.Size = new System.Drawing.Size(160, 29);
            this.uiCheckBox_使能_打印前弹窗确认.TabIndex = 3;
            this.uiCheckBox_使能_打印前弹窗确认.Text = "使能_打印前弹窗确认";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "设备编号:";
            // 
            // textBox_设备编号
            // 
            this.textBox_设备编号.Location = new System.Drawing.Point(158, 223);
            this.textBox_设备编号.Name = "textBox_设备编号";
            this.textBox_设备编号.Size = new System.Drawing.Size(193, 26);
            this.textBox_设备编号.TabIndex = 5;
            // 
            // textBox_Mes_Url
            // 
            this.textBox_Mes_Url.Location = new System.Drawing.Point(158, 259);
            this.textBox_Mes_Url.Multiline = true;
            this.textBox_Mes_Url.Name = "textBox_Mes_Url";
            this.textBox_Mes_Url.Size = new System.Drawing.Size(552, 115);
            this.textBox_Mes_Url.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mes_Url:";
            // 
            // Form_系统参数
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.textBox_Mes_Url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_设备编号);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiCheckBox_使能_打印前弹窗确认);
            this.Controls.Add(this.uiCheckBox_使能Mes);
            this.Controls.Add(this.uiButton_保存);
            this.Controls.Add(this.uiCheckBox_手持扫码枪);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_系统参数";
            this.ShowInTaskbar = false;
            this.Text = "系统设置";
            this.操作按钮颜色 = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny25 . UICheckBox uiCheckBox_手持扫码枪;
        private Sunny25. UIButton uiButton_保存;
        private Sunny25. UICheckBox uiCheckBox_使能Mes;
        private Sunny25. UICheckBox uiCheckBox_使能_打印前弹窗确认;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_设备编号;
        private System.Windows.Forms.TextBox textBox_Mes_Url;
        private System.Windows.Forms.Label label2;
    }
}