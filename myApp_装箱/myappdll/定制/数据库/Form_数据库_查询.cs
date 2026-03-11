using Sunny25.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace myappdll
{
    internal partial class Form_数据库_查询 : Sunny25.UIForm
    {
        List<表.dataZX> lst = new List<表.dataZX>();



        internal Form_数据库_查询()
        {
            InitializeComponent();

        }

        private void Form_数据库_查询_Load(object sender, EventArgs e)
        {

        }

        private void uiButton_清空条件_Click(object sender, EventArgs e)
        {
            this.uItextBox_QF_SN条码.uiTextBox1.Clear();
            this.uItextBox_QF_拖条码.uiTextBox1.Clear();
            this.uItextBox_QF_机种.uiTextBox1.Clear();
            this.uItextBox_QF_箱条码.uiTextBox1.Clear();
        }

        private void uiButton_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton_查询_Click(object sender, EventArgs e)
        {
            查询();
        }



        async Task 查询()
        {
            this.Enabled = false;
            bool rt = false;
            string msgErr = string.Empty;
            this.Text = "正在查询...";

            await Task.Run(() =>
             {
                 表.dataZX info = new 表.dataZX();
                 info.拖条码 = this.uItextBox_QF_拖条码.Text.Trim();
                 info.箱条码 = this.uItextBox_QF_箱条码.Text.Trim();
                 info.SN条码 = this.uItextBox_QF_SN条码.Text.Trim();
                 info.机种 = this.uItextBox_QF_机种.Text.Trim();

                 rt = dataBase.查询(info, this.uI_日期范围1.uiDatePicker_开始.Value, this.uI_日期范围1.uiDatePicker_结束.Value, out lst, out msgErr);

             });
            this.Enabled = true;
            string show = rt ? "OK" : "NG";
            this.Text = $"查询结束,{show}";
            if (rt)
            {
                if (lst.Count > 0)
                {
                    Sunny25.Messagebox.Show($"查询成功,共{lst.Count}行", "");
                    dataBase.On_查询(lst);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Sunny25.Messagebox.Show($"查询成功,共{lst.Count}行", "", Sunny25.MessageboxStatus.Red);
                }
            }
            else
            {
                Sunny25.Messagebox.Show($"查询失败\r\n{msgErr}", "", Sunny25.MessageboxStatus.Red);
            }
        }



    }
}
