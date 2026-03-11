
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    public partial class Form_系统参数 : Sunny25.UIForm
    {
        public Form_系统参数()
        {
            InitializeComponent();
            show();

            this.uiButton_保存.Click += (s, e) =>
            {
                系统类_myApp.Config.参数.使能_手持扫码枪 = this.uiCheckBox_手持扫码枪.Checked;
                系统类_myApp.Config.参数.使能_Mes = this.uiCheckBox_使能Mes.Checked;
                系统类_myApp.Config.参数.使能_打印前弹窗确认 = this.uiCheckBox_使能_打印前弹窗确认.Checked ? 1 : 0;
                系统类_myApp.Config.参数.Mes_Url = this.textBox_Mes_Url.Text.Trim();
                系统类_myApp.Config.参数.设备编号 = this.textBox_设备编号.Text.Trim();
                系统类_myApp.Initiall(0);
                show();
                MessageBox.Show("保存成功");
            };
        }
        void show()
        {
            this.uiCheckBox_手持扫码枪.Checked = 系统类_myApp.Config.参数.使能_手持扫码枪;
            this.uiCheckBox_使能Mes.Checked = 系统类_myApp.Config.参数.使能_Mes;
            this.uiCheckBox_使能_打印前弹窗确认.Checked = 系统类_myApp.Config.参数.使能_打印前弹窗确认 == 0 ? false : true;
            this.textBox_Mes_Url.Text = 系统类_myApp.Config.参数.Mes_Url;
            this.textBox_设备编号.Text = 系统类_myApp.Config.参数.设备编号;

        }
    }
}
