using mainclassqf;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    internal class 页面设置_main
    { 
        public sealed class info_参数_
        {
            public float 工作区_left { set; get; } = 200;
            public float 工作区_right { set; get; } = 300;
            public int 日志_height { set; get; } = 120;
            public int 商标_width { set; get; } = 100;

            public int 窗体_width { set; get; } = 800;
            public int 窗体_height { set; get; } = 600;

            public bool 显示主窗体的控制按钮 { set; get; } = true;
            public bool 使能_语言 { set; get; } = false;

            /// <summary>
            /// 天
            /// </summary>
            public int 日志保存时间 { set; get; } = 90;

           

            /// <summary>
            /// ms
            /// </summary>
            public int 标题栏状态刷新周期 { set; get; } = 100;

            /// <summary>
            /// 防止显示器更换后不一致
            /// </summary>
            public float 图像标注_图像倍数_x { set; get; } = 1;
            /// <summary>
            /// 防止显示器更换后不一致
            /// </summary>
            public float 图像标注_图像倍数_y { set; get; } = 1;
        }


        internal class Config
        {
            internal static info_参数_ 参数 { set; get; } = new info_参数_();
        }
         
        internal static void 初始化()
        {
            读参数();
            Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[1].Width = Config.参数.工作区_left;
            Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[5].Width = Config.参数.工作区_right;
            Form_main.form_Main.功能栏1.商标宽度 = Config.参数.商标_width;
            Form_main.form_Main.uI_Log1.Height = Config.参数.日志_height;
            Form_main.form_Main.ControlBox = Config.参数.显示主窗体的控制按钮;
            设置主窗体大小();

            if (Form_main.form_Main.uI_Log1.Height == 0)
            {
                Form_main.form_Main.uI_Log1.Visible = false;
            }
            if (Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[1].Width == 0)
            {
                Form_main.form_Main.uiPanel_工作区_左.Visible = false;
            }
            if (Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[5].Width == 0)
            {
                Form_main.form_Main.uiPanel_工作区_右.Visible = false;
            }

     
            Form_main.form_Main.uI_Log1.保存期限 = Config.参数.日志保存时间;
            申明.myForm25_sys.Config.线程刷新周期 = Config.参数.标题栏状态刷新周期;

        }

        internal static void 设置主窗体大小()
        {
            Form_main.form_Main.size.Width = Config.参数.窗体_width;
            Form_main.form_Main.size.Height = Config.参数.窗体_height;
        }
         
        static void 读参数()
        {
            ushort model = 1;
            string path = Environment.CurrentDirectory + "\\mainPageCfg.txt";
            if (!new 文件_文件夹().文件是否存在(path))
            {
                Config.参数.工作区_left = Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[1].Width;
                Config.参数.工作区_right = Form_main.form_Main.tableLayoutPanel_工作区.ColumnStyles[5].Width;
                Config.参数.商标_width = Form_main.form_Main.功能栏1.商标宽度;
                Config.参数.日志_height = Form_main.form_Main.uI_Log1.Height;
                Config.参数.显示主窗体的控制按钮 = Form_main.form_Main.ControlBox;
                model = 0;
            }
            if (model == 0)
            {
                string vx = JsonConvert.SerializeObject(Config.参数, Formatting.Indented);
                new 文本().写文本(path, vx, true, Encoding.Default, out string msgErr);
            }
            new 文本().读取文件(path, Encoding.Default, out string rx, out string msgErr1);
            Config.参数 = JsonConvert.DeserializeObject<info_参数_>(rx);

        }


    }
}
