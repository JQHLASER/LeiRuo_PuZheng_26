using mainclassqf;
using mainclassSoft;
using mainIndustryqf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace myappdll
{
    internal partial class Form_工件_设置 : Sunny25.UIForm
    {
        文件 gj_sys;
        编码25 Encod_sys;
        string 文件名 = "";
        internal 文件.info_参数_文件_ 文件 = new 文件.info_参数_文件_();
        internal static Form_工件_设置 forms;


        void 新建()
        {
            if (Sunny25.Messagebox.Show(语言.读取语言("是否新建?"), "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            清空();
            保存(0);
        }

        /// <summary>
        /// model =0:不弹窗直接打开,=1:弹窗打开
        /// </summary>
        /// <param name="model"></param>
        void 打开(ushort model = 1)
        {
            bool 是否显示 = true;
            if (model == 1)
            {
                DialogResult rt = gj_sys.gj_sys.打开_弹窗(ref 文件, out 文件名, out string msgErr);
                if (rt != DialogResult.OK)
                {
                    是否显示 = false;
                }

            }
            else
            {
                bool rt = this.gj_sys.gj_sys.打开(文件名, ref 文件, out string msgErr);
            }
            if (是否显示)
            {
                显示();
            }
        }

        /// <summary>
        /// model: =0:保存且文件名为空时另存,=1:另存为
        /// </summary>
        /// <param name="model"></param>
        void 保存(ushort model, bool 成功是否弹窗 = true)
        {
            if (this.uItextBox_QF_每盘个数.IntValue == 0)
            {
                Sunny25.Messagebox.Show(语言.读取语言("请设置每盘个数"));
                return;
            }
            else if (this.uItextBox_QF_每箱盘数.IntValue == 0)
            {
                Sunny25.Messagebox.Show(语言.读取语言("请设置每箱盘数"));
                return;
            }
            else if (this.uItextBox_QF_每拖箱数.IntValue == 0)
            {
                Sunny25.Messagebox.Show(语言.读取语言("请设置每拖箱数"));
                return;
            }
            else if (this.uIcombobox_QF_打印标签_箱.uiComboBox1.SelectedIndex == -1)
            {
                Sunny25.Messagebox.Show(语言.读取语言("请选择箱打印标签模板"));
                return;
            }
            else if (this.uIcombobox_QF_打印标签_拖.uiComboBox1.SelectedIndex == -1)
            {
                Sunny25.Messagebox.Show(语言.读取语言("请选择拖打印标签模板"));
                return;
            }


            bool 是否新建文件 = string.IsNullOrEmpty(this.文件名) ? true : false;
            bool 是否保存 = false;
            if (model == 0)
            {
                if (string.IsNullOrEmpty(this.文件名))
                {
                    model = 1;
                }
                else
                {
                    是否保存 = true;
                }
            }

            //另存为
            if (model == 1)
            {
                //SaveFileDialog save = new SaveFileDialog();
                //save.InitialDirectory = this.gj_sys.Config.files_文件夹;
                //save.Filter = $"|*{this.gj_sys.Config.后缀}";
                //DialogResult dlt = save.ShowDialog();


                文件_选择文件.info_参数_ info_ = new 文件_选择文件.info_参数_();
                info_.文件夹路径 = this.gj_sys.Config.files_文件夹;
                info_.后缀 = $"*{this.gj_sys.Config.后缀}";
                info_.显示后缀 = false;

                DialogResult dlt = new mainclassqf.文件_选择文件().窗体_选择文件(info_, 文件_选择文件.enum模式.保存, out string name, true);

                if (dlt != DialogResult.OK)
                {
                    return;
                }

                编码.另存为(this.文件名, name);
                是否保存 = true;
                this.文件名 = 是否保存 ? name : this.文件名;


            }

            if (是否保存)
            {

                文件.数量.当前拖箱数 = this.uItextBox_QF_当前拖箱数.IntValue;
                文件.数量.当前箱盘数 = this.uItextBox_QF_当前箱盘数.IntValue;

                文件.数量.每拖箱数 = this.uItextBox_QF_每拖箱数.IntValue;
                文件.数量.每盘个数 = this.uItextBox_QF_每盘个数.IntValue;
                文件.数量.每箱盘数 = this.uItextBox_QF_每箱盘数.IntValue;

                文件.码长度 = this.uItextBox_QF_码长度.IntValue;

                文件.SN码校验 = this.uItextBox_QF_SN码校验.Text;
                文件.机种 = this.uItextBox_QF_机种.Text;
                文件.机台代码 = this.uItextBox_QF_机台代码.Text;


                文件.打印标签_拖 = this.uIcombobox_QF_打印标签_拖.uiComboBox1.SelectedText;
                文件.打印标签_箱 = this.uIcombobox_QF_打印标签_箱.uiComboBox1.SelectedText;

                文件.读码图像名称 = this.uItextBox_QF_读码图像.Text;
                文件.读码指令 = this.uItextBox_QF_读码指令_切换模板.Text;

                this.gj_sys.gj_sys.读写文件(0, this.文件名, ref 文件, out string msgErr);
                显示();
                if (成功是否弹窗)
                {
                    Sunny25.Messagebox.Show(语言.读取语言("保存成功"), "", Sunny25.MessageboxStatus.Green);
                }
            }

        }

        void 删除()
        {
            if (string.IsNullOrEmpty(this.文件名))
            {
                Sunny25.Messagebox.Show(语言.读取语言("未选择文件"), "", Sunny25.MessageboxStatus.Red);
                return;
            }
            else if (Sunny25.Messagebox.Show(语言.读取语言("删除?"), "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            bool rt = this.gj_sys.gj_sys.删除(this.文件名, out string msgErr);

            if (rt)
            {
                编码.删除(this.文件名);
                清空();
                Sunny25.Messagebox.Show(语言.读取语言("删除成功"), "", Sunny25.MessageboxStatus.Green);
            }
            else
            {
                Sunny25.Messagebox.Show($"{语言.读取语言("删除失败")}\r\n{msgErr}", "", Sunny25.MessageboxStatus.Red);
            }
        }



        void 枚举所有模板()
        {
            new mainclassqf.文件_文件夹().获取_文件夹下文件名_不含路径(打印.Config.file_存放模板, $"*{打印.Config.后缀}", out string[] beff, out string msgErr);
            this.uIcombobox_QF_打印标签_拖.uiComboBox1.DataSource = beff;
            this.uIcombobox_QF_打印标签_箱.uiComboBox1.DataSource = beff;

        }

        void 显示()
        {
            this.Text = this.文件名;
            this.uItextBox_QF_当前拖箱数.IntValue = 文件.数量.当前拖箱数;
            this.uItextBox_QF_当前箱盘数.IntValue = 文件.数量.当前箱盘数;

            this.uItextBox_QF_每拖箱数.IntValue = 文件.数量.每拖箱数;
            this.uItextBox_QF_每盘个数.IntValue = 文件.数量.每盘个数;
            this.uItextBox_QF_每箱盘数.IntValue = 文件.数量.每箱盘数;
            this.uItextBox_QF_码长度.IntValue = 文件.码长度;

            this.uItextBox_QF_SN码校验.Text = 文件.SN码校验;
            this.uItextBox_QF_机种.Text = 文件.机种;

            this.uIcombobox_QF_打印标签_拖.uiComboBox1.SelectedIndex = this.uIcombobox_QF_打印标签_拖.uiComboBox1.Items.IndexOf(文件.打印标签_拖);

            this.uIcombobox_QF_打印标签_箱.uiComboBox1.SelectedIndex = this.uIcombobox_QF_打印标签_拖.uiComboBox1.Items.IndexOf(文件.打印标签_箱);
            this.uItextBox_QF_读码图像.Text = 文件.读码图像名称;

            this.uItextBox_QF_读码指令_切换模板.Text = 文件.读码指令;

            this.uItextBox_QF_机台代码.Text = 文件.机台代码;

        }

        void 清空()
        {
            this.文件名 = "";
            this.Text = this.文件名;



            this.uItextBox_QF_当前拖箱数.IntValue = 0;
            this.uItextBox_QF_当前箱盘数.IntValue = 0;

            this.uItextBox_QF_每拖箱数.IntValue = 0;
            this.uItextBox_QF_每盘个数.IntValue = 0;
            this.uItextBox_QF_每箱盘数.IntValue = 0;
            this.uItextBox_QF_码长度.IntValue = 12;

            this.uItextBox_QF_SN码校验.Text = "";
            this.uItextBox_QF_机种.Text = "";

            this.uIcombobox_QF_打印标签_拖.uiComboBox1.SelectedIndex = -1;

            this.uIcombobox_QF_打印标签_箱.uiComboBox1.SelectedIndex = -1;
            this.uItextBox_QF_读码图像.Text = "";
            this.uItextBox_QF_读码指令_切换模板.Text = 读码器.Config.参数.启动读码;
            this.uItextBox_QF_机台代码.Text = "";
        }




        //*******************************************************
        internal Form_工件_设置(文件 gj_sys_, 编码25 Encod_sys_, string 文件名_)
        {
            InitializeComponent();
            this.gj_sys = gj_sys_;
            this.文件名 = 文件名_;
            this.Encod_sys = Encod_sys_;
            forms = this;

            this.uItextBox_QF_码长度.Visible = 系统类_myApp.Config.参数.使能_手持扫码枪;
            this.uItextBox_QF_读码指令_切换模板.Visible = !系统类_myApp.Config.参数.使能_手持扫码枪;
       




        }

        private void Form_工件_设置_Load(object sender, EventArgs e)
        {

            new 窗体().居中(this, this.panel1);
            this.Text = "";


            枚举所有模板();



            if (!string.IsNullOrEmpty(this.文件名))
            {
                打开(0);
            }




        }

        private void toolStripButton_关闭_Click(object sender, EventArgs e)
        {
            if (Sunny25.Messagebox.Show(语言.读取语言("关闭?"), "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else if (!string.IsNullOrEmpty(this.文件名) &&
                Sunny25.Messagebox.Show(语言.读取语言("关闭前是否保存?"), "", Sunny25.MessageboxButtons.YesNo) == DialogResult.Yes)
            {
                保存(0, false);
            }

            this.Close();
        }

        private void toolStripButton_新建_Click(object sender, EventArgs e)
        {
            新建();
        }

        private void toolStripButton_打开_Click(object sender, EventArgs e)
        {
            打开();
        }

        private void toolStripButton_保存_Click(object sender, EventArgs e)
        {

            保存(0);
        }

        private void toolStripButton_另存_Click(object sender, EventArgs e)
        {

            保存(1);
        }

        private void toolStripButton_删除_Click(object sender, EventArgs e)
        {

            删除();
        }




        private void uiButton_编码_箱_Click(object sender, EventArgs e)
        {
            if (!this.Encod_sys.Encod_sys.Err_未初始化(out string msgErr) || !this.gj_sys.gj_sys.Err_文件名不能为空(this.文件名, out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }
            this.Encod_sys.Encod_sys.窗体_设置_主窗体(编码.生成箱码文件名(this.文件名));
        }

        private void uiButton_拖码_Click(object sender, EventArgs e)
        {
            if (!this.Encod_sys.Encod_sys.Err_未初始化(out string msgErr) || !this.gj_sys.gj_sys.Err_文件名不能为空(this.文件名, out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }
            this.Encod_sys.Encod_sys.窗体_设置_主窗体(编码.生成拖码文件名(this.文件名));
        }

        private void uiButton_读码图像标注_Click(object sender, EventArgs e)
        {
            string FileName_image = this.uItextBox_QF_读码图像.Text.Trim();
            if (string.IsNullOrEmpty(FileName_image))
            {
                Sunny25.Messagebox.Show("请选择模板图片", "", Sunny25.MessageboxStatus.Red);
                return;
            }

            List<图像.info_绘制信息_> lst = this.文件.图像标注参数.ToList();
            if (new Form_图像标注_设置(FileName_image, lst).ShowDialog() == DialogResult.OK)
            {
                this.文件.图像标注参数 = lst.ToArray();
            }
        }

        private void uiButton_选择读码图像_Click(object sender, EventArgs e)
        {
            mainclassqf.文件_选择文件.info_参数_ info = new 文件_选择文件.info_参数_();
            info.文件夹路径 = 读码器.Config.参数.读码器图像文件夹;
            info.后缀 = "*.jpg";
            info.显示后缀 = true;

            //DialogResult rt = new mainclassqf.文件_选择文件().窗体_选择文件(info, 文件_选择文件.enum模式.打开, out string fileName, true);


            var rtName = new QF_MainClass_26.文件_文件夹().文件_获取_文件夹下所有文件名(读码器.Config.参数.读码器图像文件夹);

            var rt = new QF_WinForm_26.软件类().Win_文件类弹窗(读码器.Config.参数.读码器图像文件夹, "Jpg", "*.jpg", QF_WinForm_26._文件弹窗类型_.打开);

            if (rt.dlt == DialogResult.OK)
            {
                this.uItextBox_QF_读码图像.Text = $"{rt.文件名}.jpg";
                //  string pathX = $"{读码器.Config.参数.读码器图像文件夹}\\{this.uItextBox_QF_读码图像.Text}";
                //  bool rtF = new mainclassqf.文件_文件夹().复制文件(fileName, pathX, true, out string msgErr);
                //if (!rtF)
                //{
                //    Sunny25.Messagebox.Show(msgErr, "Err", Sunny25.MessageboxStatus.Red);
                //}


            }


        }
    }
}
