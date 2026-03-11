using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using static myappdll.文件;

namespace myappdll
{
    internal class 显示
    {
        public class info_加工显示条_
        {
            public Sunny25.LED_显示条.enum状态 状态 { set; get; } = Sunny25.LED_显示条.enum状态.White;
            public string 内容 { set; get; } = "";

        }



        internal class Config
        {
            internal static info_加工显示条_ 加工显示条 { set; get; } = new info_加工显示条_();
        }


        internal static void 加工条(Sunny25.LED_显示条.enum状态 状态, string text)
        {
            Form_main.form_Main.Invoke(new Action(() =>
            {
                Form_main.form_Main.leD_显示条1.显示(状态, text);

            }));

            Config.加工显示条.状态 = 状态;
            Config.加工显示条.内容 = text;

        }

        internal static void 画布()
        {
            if (工件.gj_sys is null)
            {
                return;
            }



            string name = "";
            string value = "";
            int 标题长度 = 20;
            int 数量长度 = 6;

            Form_main.form_Main.Invoke((Action)(() =>
            {
                Sunny25.Draw画布 drawBox = Form_main.form_Main.draw画布_工作区;

                drawBox.清空();

                name = "工件";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件名;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");


                name = "读码器(切换指令)";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.读码指令}";
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");

                name = "标注图像";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.读码图像名称}";
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");


                name = "打印标签(箱)";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件.打印标签_箱;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");

                name = "打印标签(拖)";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件.打印标签_拖;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");


                name = "机台代码";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件.机台代码;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");


                name = "SN码校验";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件.SN码校验;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");



                name = "机种";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = 工件.gj_sys.Config.文件.机种;
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");

                name = "每盘个数";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.数量.每盘个数}";
                value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                drawBox.添加(0, 0, 0, 0, 0, false, $" 个/盘");

                name = "每箱盘数";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.数量.每箱盘数}";
                value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                drawBox.添加(0, 0, 0, 0, 0, false, $" 盘/箱");


                name = "每拖箱数";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.数量.每拖箱数}";
                value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                drawBox.添加(0, 0, 0, 0, 0, false, $" 箱/拖");

                name = "条码(箱)";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.编码内容.箱码}";
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");

                name = "条码(拖)";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.编码内容.拖码}";
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");

                drawBox.添加_分割线(0, 1, 0, 0, 0, "----- 加工信息 -----", $"----------");

                //name = "当前盘个数";
                //name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                //value = $"{工件.gj_sys.Config.文件.数量.当前箱个数}";
                //value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');
                //drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                //drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                //drawBox.添加(0, 0, 0, 0, 0, false, $" 个/当前盘");

                name = "当前箱盘数";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.数量.当前箱盘数}";
                value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');

                string bz = "";
                if (工件.gj_sys.Config.文件.数量.当前箱盘数 >= 工件.gj_sys.Config.文件.数量.每箱盘数)
                {
                    bz = "(已满箱)";
                }
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                drawBox.添加(0, 0, 0, 0, 0, false, $" 盘/当前箱  {bz}");

                name = "当前拖箱数";
                name = new mainclassqf.文本().对齐(name, 标题长度, 0, ' ');
                value = $"{工件.gj_sys.Config.文件.数量.当前拖箱数}";
                value = new mainclassqf.文本().对齐(value, 数量长度, 2, ' ');
                bz = "";
                if (工件.gj_sys.Config.文件.数量.当前拖箱数 >= 工件.gj_sys.Config.文件.数量.每拖箱数)
                {
                    bz = "(已满拖)";
                }
                drawBox.添加(0, 1, 0, 0, 0, true, $"{name} : ");
                drawBox.添加(0, 0, 0, 0, 0, false, $"{value}");
                drawBox.添加(0, 0, 0, 0, 0, false, $" 箱/当前拖  {bz}");


                string xt = "";
                if (计算.Config.当前尾料 > 0)
                {
                    xt = "当前尾料";
                }

                drawBox.添加_分割线(0, 1, 0, 0, 0, $"----- 加工状态 ----- {xt} ----", $"----------");


                int a = 4;
                name = Config.加工显示条.内容;
                value = "";

                switch (Config.加工显示条.状态)
                {
                    case Sunny25.LED_显示条.enum状态.White:
                        name = "";
                        value = "";

                        break;
                    case Sunny25.LED_显示条.enum状态.Green:
                        a = 3;

                        break;
                    case Sunny25.LED_显示条.enum状态.Yello:

                        a = 4;
                        break;
                    case Sunny25.LED_显示条.enum状态.Red:

                        a = 2;
                        break;
                }

                drawBox.添加(1, a, 0, 0, 0, true, $"{name}");
                drawBox.添加(1, a, 0, 0, 0, false, $"{value}");



                drawBox.画图();
            }));
        }

    }
}
