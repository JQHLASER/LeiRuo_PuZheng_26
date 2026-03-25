using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace myappdll
{
    internal partial class Form_图像标注_设置 : Sunny25.UIForm
    {
        图像 picBZ_sys = null;

        List<图像.info_绘制信息_> lst_main;

        /// <summary>
        /// 图像名称
        /// </summary>
        string FileName_image = "";
        int index_选中行 = -1;
        图像.info_绘制信息_ info当前编辑的;


        bool Err_未选中对象(out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            if (index_选中行 < 0)
            {
                msgErr = "未选中要操作的对象";
                rt = false;
                //  Sunny25.Messagebox.Show("未选中要标注的对象", "", Sunny25.MessageboxStatus.Red);
            }

            return rt;
        }


        void 显示()
        {
            this.uiListBox_对象.Items.Clear();
            int a = 0;
            foreach (var s in lst_main)
            {
                a++;
                this.uiListBox_对象.Items.Add(a.ToString());
            }

            picBZ_sys.标注图像(lst_main.ToArray());
        }

        void 标注图像()
        {


            图像.info_绘制信息_[] info = lst_main.ToArray();
            info[index_选中行].left = info当前编辑的.left;
            info[index_选中行].top = info当前编辑的.top;

            info[index_选中行].width_边框 = info当前编辑的.width_边框;
            info[index_选中行].height_边框 = info当前编辑的.height_边框;


            picBZ_sys.标注图像(info);

        }





        void 添加()
        {
            //if (lst_main.Count >= Form_工件_设置.forms.文件.数量.每盘个数)
            //{
            //    MessageBox.Show("已达到每盘个数");
            //    return;
            //}

            图像.info_绘制信息_ info = new 图像.info_绘制信息_();
            info.原始参数.width_picbox = this.pictureBox1.Width;
            info.原始参数.height_picbox = this.pictureBox1.Height;
            this.lst_main.Add(info);


            显示();
        }

        void 标注()
        {

            if (标注中)
            {
                this.toolStripButton_标注.Text = "确定";
                this.toolStripButton_标注.ForeColor = Color.Green;
                this.uiListBox_对象.Enabled = false;

                info当前编辑的 = lst_main[index_选中行];
            }
            else
            {
                this.toolStripButton_标注.Text = "标注";
                this.toolStripButton_标注.ForeColor = Color.Black;
                this.uiListBox_对象.Enabled = true;
            }
        }
        void 保存()
        {
            if (标注中)
            {
                lst_main[index_选中行].top = info当前编辑的.top;
                lst_main[index_选中行].left = info当前编辑的.left;
                lst_main[index_选中行].width_边框 = info当前编辑的.width_边框;
                lst_main[index_选中行].height_边框 = info当前编辑的.height_边框;


                lst_main[index_选中行].原始参数.left = info当前编辑的.left;
                lst_main[index_选中行].原始参数.top = info当前编辑的.top;



            }
        }










        /// <summary>
        /// FileName_image:图像名称
        /// </summary>
        /// <param name="FileName_image"></param>
        /// <param name="lst_"></param>
        internal Form_图像标注_设置(string FileName_image_, List<图像.info_绘制信息_> lst_)
        {
            InitializeComponent();
            this.lst_main = lst_;
            this.FileName_image = FileName_image_;

        }

        Bitmap img = null;
        private void Form_设置_Load(object sender, EventArgs e)
        { 
            读码器.读取图像(this.FileName_image, out img); 
            this.pictureBox1.Image?.Dispose();
            this.pictureBox1.Image = img;


            picBZ_sys = new 图像(img, this.pictureBox1.Width, this.pictureBox1.Height, this.Font);
            picBZ_sys.初始化(this.pictureBox1);
          

            显示();
        }





        private void Form_图像标注_设置_FormClosing(object sender, FormClosingEventArgs e)
        {
            img = null;
            if (this.pictureBox1.Image != null)
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }
            picBZ_sys.释放(this.pictureBox1);
        }

        private void toolStripButton_添加_Click(object sender, EventArgs e)
        {
            添加();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (标注中 && !标注编辑)
                {
                    标注编辑 = true;
                    info当前编辑的.left = e.X;
                    info当前编辑的.top = e.Y;

                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && 标注编辑)
            {
                标注编辑 = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (标注编辑)
                {

                    info当前编辑的.width_边框 = e.X - info当前编辑的.left;
                    info当前编辑的.height_边框 = e.Y - info当前编辑的.top;

                    标注图像();



                }
            }

        }
        bool 标注编辑 = false;
        bool 标注中 = false;
        private void toolStripButton_标注_Click(object sender, EventArgs e)
        {
            if (标注中 && index_选中行 > -1)
            {
                保存();
            }
            else if (!标注中 && !Err_未选中对象(out string msgErr))
            {
                Sunny25.Messagebox.Show(this, msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }

            标注中 = !标注中;
            标注();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!Err_未选中对象(out string msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }
            else if (Sunny25.Messagebox.Show("是否确认删除选中行?", "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            this.lst_main.RemoveAt(index_选中行);
            显示();




        }

        private void uiListBox_对象_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                index_选中行 = this.uiListBox_对象.SelectedIndex;
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (Sunny25.Messagebox.Show("是否关闭?", "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else if (Sunny25.Messagebox.Show("是否保存?", "", Sunny25.MessageboxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
            }
        }
    }
}
