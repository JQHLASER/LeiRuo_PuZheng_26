using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll.定制
{
    public partial class Form_尾料 : Sunny25.UIForm 
    {
        public Form_尾料()
        {
            InitializeComponent();
        }

        private void Form_尾料_Load(object sender, EventArgs e)
        {
            this.uItextBox_QF1.IntValue=   计算.Config.当前尾料 ;
        }

        private void uiButton_Yes_Click(object sender, EventArgs e)
        {
            if (this.uItextBox_QF1.IntValue >= 工件.gj_sys.Config.文件.数量.每盘个数)
            {
                Sunny25.Messagebox.Show("尾料必须小于每盘个数");
                return;
            }
            计算.Config.当前尾料 = this.uItextBox_QF1.IntValue;
            this.DialogResult = DialogResult.OK;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
