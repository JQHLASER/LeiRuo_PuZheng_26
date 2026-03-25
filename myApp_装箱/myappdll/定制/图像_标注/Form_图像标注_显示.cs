using MarkAPI;
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

namespace myappdll
{
    internal partial class Form_图像标注_显示 : Sunny25.UIForm
    {
        图像 picBZ_sys = null ;
        图像.info_绘制信息_[] infoBeff;
        /// <summary>
        /// 图像名称
        /// </summary>
        string FileName_image = "";
        string Value_Err = "";
        void 显示()
        {
            picBZ_sys.标注图像(infoBeff );
        }


        /// <summary>
        /// FileName_image_ : 图像名称
        /// </summary>
        /// <param name="FileName_image_"></param>
        /// <param name="infoBeff_"></param>
        internal Form_图像标注_显示(string FileName_image_, 图像.info_绘制信息_[] infoBeff_, string 错误信息)
        {
            InitializeComponent();
            this.infoBeff = infoBeff_;
            this.FileName_image = FileName_image_;
            this.Value_Err = 错误信息;
        }

        Bitmap img = null;
        private void Form_图像标注_显示_Load(object sender, EventArgs e)
        {
            this.label1.Text = "";
            if (!工件.Err_未设置模板图像(out string msgErr) || !工件.Err_未找到设置的模板图像(out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                this.Close();
                return;
            }
             
            读码器.读取图像(this.FileName_image, out   img);
            if (this.pictureBox1.Image != null)
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }
            this.pictureBox1.Image =img ;
            this.label1.Text = $"{this.Value_Err}";
            picBZ_sys = new 图像(img,this.pictureBox1 .Width ,this.pictureBox1 .Height ,this.Font );
            picBZ_sys.初始化(this.pictureBox1);
            显示();
             
        }



        private void uiButton2_Click_1(object sender, EventArgs e)
        {
             
            this.Close();
        }

        private void Form_图像标注_显示_FormClosing(object sender, FormClosingEventArgs e)
        {
            img = null;
            if (this.pictureBox1.Image != null)
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }
            picBZ_sys.释放(this.pictureBox1);
        }
    }
}
