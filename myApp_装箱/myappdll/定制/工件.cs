using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace myappdll
{
    internal class 工件
    {
        internal static 文件 gj_sys = new 文件(申明.myForm25_sys, 编码.Encode_sys);
         
        internal static void 初始化()
        {
           
            gj_sys = new 文件(申明.myForm25_sys, 编码.Encode_sys);
            gj_sys.Action_加载文件失败输出报警 += 加载文件失败输出报警;
            gj_sys.Action_Log += log_;
            gj_sys.Action_加载文件 += 加载文件;


        }

        internal static void 启动时自动加载工件()
        {
          
            if (gj_sys is null || isInistiall)
            {
                return;
            }

            string name = "";
            gj_sys.读写_最后打开的参数(1, ref name);

            string path = gj_sys.Config.files_文件夹 + $"\\{name}{gj_sys.Config.后缀}";
            if (!string.IsNullOrEmpty(name) && new mainclassqf.文件_文件夹().文件是否存在(path))
            {
                Log.Add(true, $"工件,检测到最后一次加载的文件,{name}");
            }
            isInistiall = true;

            while (isRun && !string.IsNullOrEmpty(name) && new mainclassqf.文件_文件夹().文件是否存在(path))
            {
                bool rt = delay_sys.延时_并等待(1000);
                if (!rt)
                {
                    break;
                }
                if (!申明.myForm25_sys.系统报警状态())
                {
                    continue;
                }
                else
                {
                    gj_sys.打开(name);
                    break;
                }
            }


        }


        static mainclassqf.延时_Task delay_sys = new mainclassqf.延时_Task();

        static bool isInistiall = false;
        static bool isRun = true;
        internal static void 释放()
        {
            if (!isInistiall)
            {
                return;
            }
            isRun = false;
            delay_sys.中断延时();

            if (gj_sys is null)
            {
                return;
            }


            gj_sys.Action_加载文件失败输出报警 -= 加载文件失败输出报警;
            gj_sys.Action_Log -= log_;
            gj_sys.Action_加载文件 -= 加载文件;
            gj_sys.释放();
        }

        static void log_(bool state, string logStr)
        {
            Log.Add(state, logStr);
        }
        static void 加载文件失败输出报警()
        {
            IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
            gj_sys.Config.文件 = new 文件.info_参数_文件_();
            工件.gj_sys.Config.文件名 = string.Empty;
        }

        static bool 加载文件(bool 当前加载状态)
        {
            bool rt = 工作.加载工件(当前加载状态);

            if (rt)
            {
                //读码器.读取图像(gj_sys.Config.文件.读码图像名称, out Bitmap img);

                rt = 读码器.切换模板();
            }

            return rt;
        }


        internal static void 标题栏状态()
        {
            if (gj_sys is null)
            {
                return;
            }
            工件.gj_sys.标题栏状态();
        }


        internal static bool Err_图像标注数量与设置的每盘个数不一致(out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            if (工件.gj_sys.Config.文件.图像标注参数.Length != 工件.gj_sys.Config.文件.数量.每盘个数)
            {
                rt = false;
                msgErr = "图像标注数量与设置的每盘个数不一致";
                Log.Add(rt, msgErr);
            }

            return rt;
        }

        internal static bool Err_未设置模板图像(out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            if (string.IsNullOrEmpty(工件.gj_sys.Config.文件.读码图像名称))
            {
                rt = false;
                msgErr = "未设置模板图像名称";
                Log.Add(rt, msgErr);
            }

            return rt;
        }

        internal static bool Err_未找到设置的模板图像(out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            string path = $"{读码器.Config.参数.读码器图像文件夹}\\{工件.gj_sys.Config.文件.读码图像名称}";
            if (!new mainclassqf.文件_文件夹().文件是否存在(path))
            {
                rt = false;
                msgErr = "未找到设置的模板图像";
                Log.Add(rt, msgErr);
            }

            return rt;
        }
    }
}
