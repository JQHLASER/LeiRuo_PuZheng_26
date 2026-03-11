
using mainclassqf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace myappdll
{
    public class 图像
    {
        public class info_绘制信息_
        {
            public float left { set; get; } = 0;
            public float top { set; get; } = 0;
            public float width_边框 { set; get; } = 0;
            public float height_边框 { set; get; } = 0;
            public float 边框粗细 { set; get; } = 5;
            public Font fonts { set; get; } = new Font("微转雅黑", 30, FontStyle.Bold);
            public System.Drawing.Brush 文本颜色 { set; get; } = System.Drawing.Brushes.Red;
            public Color 边框颜色 { set; get; } = Color.Red;
            public string 文本内容 { set; get; } = "";
            public info_绘制信息_原始参数_ 原始参数 { set; get; } = new info_绘制信息_原始参数_();
        }

        public class info_绘制信息_原始参数_
        {
            public float left { set; get; } = 0;
            public float top { set; get; } = 0;
            public float width_边框 { set; get; } = 0;
            public float height_边框 { set; get; } = 0;
            public float width_picbox { set; get; } = 0;
            public float height_picbox { set; get; } = 0;
        }

        internal class Config_
        {
            internal PictureBox picBox { set; get; } = new PictureBox();
            internal info_绘制信息_[] Beff绘制信息 { set; get; } = new info_绘制信息_[0];
        }

        internal Config_ Config = new Config_();

        // 优化：绘制逻辑封装成一个方法
        private void DrawAnnotations(Graphics g)
        {
            int a = 0;
            foreach (var s in Config.Beff绘制信息)
            {
                a++;
                if (s == null || string.IsNullOrEmpty(s.文本内容) || s.width_边框 == 0 || s.height_边框 == 0)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(s.文本内容)) s.文本内容 = a.ToString();

                // 定义字体和颜色
                Font font = s.fonts;
                System.Drawing.Brush brush = s.文本颜色;

                // 绘制文本
                PointF point = new PointF(s.left, s.top);
                g.DrawString(s.文本内容, font, brush, point);

                // 绘制边框
                System.Drawing.Pen pen = new System.Drawing.Pen(s.边框颜色, s.边框粗细);
                g.DrawRectangle(pen, s.left, s.top, s.width_边框, s.height_边框);
            }
        }

        // Paint事件处理：简化逻辑
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                DrawAnnotations(g); // 使用封装的绘制方法
            }
            catch (Exception ex)
            {
                Log.Add(false, ex.Message); // 改进：记录异常
            }
        }

        // Resize事件处理：更新绘制信息
        private void pictureBox_Resize(object sender, EventArgs e)
        {
            foreach (var s in Config.Beff绘制信息)
            {
                if (s != null)
                {
                    s.top = (s.原始参数.top / s.原始参数.width_picbox) * Config.picBox.Height;
                    s.left = (s.原始参数.left / s.原始参数.width_picbox) * Config.picBox.Width;
                    s.height_边框 = (s.原始参数.height_边框 / s.原始参数.height_picbox) * Config.picBox.Height;
                    s.width_边框 = (s.原始参数.width_边框 / s.原始参数.width_picbox) * Config.picBox.Width;
                }
            }
            Config.picBox.Invalidate(); // 更新绘制区域
        }

        // 改进：初始化时避免重复绑定事件
        internal void 初始化(PictureBox pic)
        {
            if (Config.picBox != pic) // 防止重复初始化
            {
                Config.picBox = pic;
                pic.Paint += pictureBox_Paint;
                pic.Resize += pictureBox_Resize;
            }
        }

        // 释放资源，确保图像正确清理
        internal void 释放(PictureBox pic)
        {
            if (pic.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }

            pic.Paint -= pictureBox_Paint; // 解绑事件
            pic.Resize -= pictureBox_Resize;
        }

        // 更新图像标注
        internal void 标注图像(info_绘制信息_[] beff)
        {
            Config.Beff绘制信息 = beff;
            Config.picBox.Invalidate(); // 更新图像显示
        }

        // 改进：图像读取方法
        internal void 读取图像并标注(string Path_image, Bitmap img)
        {
            try
            {
                读码器.读取图像(Path_image, out img);
                标注图像(Config.Beff绘制信息); // 读取图像后进行标注
            }
            catch (Exception ex)
            {
                Log.Add(false, ex.Message); // 改进：记录读取错误
            }
        }

    }

}
