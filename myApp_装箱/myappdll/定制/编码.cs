 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace myappdll
{
    internal class 编码
    {
        internal static 编码25 Encode_sys = new 编码25(mainIndustryqf.编码.enum_文件类型.txt);


        internal class Config
        {
            internal static string 标识_箱码 { set; get; } = "_箱码";
            internal static string 标识_拖码 { set; get; } = "_拖码";


            internal static string 对象_箱码_拖码 { set; get; } = "条码";



        }



        private static readonly object _lock = new object();

        internal static void 初始化()
        {
            lock (_lock)
            {
                if (isInistiall)
                {
                    return;
                }
                Encode_sys.Encod_sys.Action_文本 += On_文本;
                Encode_sys.Action_Log += log_;
                Encode_sys.初始化();
                isInistiall = true;
            }
        }
        static bool isInistiall = false;
        internal static void 释放()
        {
            if (!isInistiall)
            {
                return;
            }
            Encode_sys.Encod_sys.Action_文本 -= On_文本;
            Encode_sys.Action_Log -= log_;
            Encode_sys.释放();
        }

        static void log_(bool state, string logStr)
        {
            Log.Add(state, logStr);
        }

        internal static string 生成箱码文件名(string 工件名)
        {
            return $"{工件名}{Config.标识_箱码}";
        }
        internal static string 生成拖码文件名(string 工件名)
        {
            return $"{工件名}{Config.标识_拖码}";
        }

        internal static void 删除(string 工件名)
        {
            string 箱 = 生成箱码文件名(工件名);
            string 拖 = 生成拖码文件名(工件名);

            Encode_sys.Encod_sys.文件_删除(箱, out string msgErr);
            Encode_sys.Encod_sys.文件_删除(拖, out msgErr);
        }

        internal static void 另存为(string 工件名, string 新工件名)
        {
            string 箱 = 生成箱码文件名(工件名);
            string 拖 = 生成拖码文件名(工件名);
            string 箱1 = 生成箱码文件名(新工件名);
            string 拖1 = 生成拖码文件名(新工件名);

            Encode_sys.Encod_sys.文件_另存为(箱, 箱1, out string msgErr);
            Encode_sys.Encod_sys.文件_另存为(拖, 拖1, out msgErr);
        }

        internal static bool 生成箱码(string 工件名, DateTime now, bool 加工, out string 箱码)
        {
            箱码 = string.Empty;
            string 箱 = 生成箱码文件名(工件名);
            bool rt = Encode_sys.打开(箱, now, 加工);

            foreach (var s in Encode_sys.Config.文件信息.结构_文件对象内容)
            {
                if (s.对象名 == "条码")
                {
                    箱码 = s.内容;
                }
            }


            return rt;
        }

        internal static bool 生成拖码(string 工件名, DateTime now, bool 加工, out string 拖码)
        {
            拖码 = string.Empty;
            string 拖 = 生成拖码文件名(工件名);
            bool rt = Encode_sys.打开(拖, now, 加工);
            foreach (var s in Encode_sys.Config.文件信息.结构_文件对象内容)
            {
                if (s.对象名 == "条码")
                {
                    拖码 = s.内容;
                }
            }


            return rt;
        }

        static string On_文本(mainIndustryqf.编码.info_文本_ info, string 对象)
        {
            string xt = string.Empty;
            if (对象 == "机台代码")
            {
                xt = 工件.gj_sys.Config.文件.机台代码;
            }
            else if (对象 == "设备编号")
            {
                xt = 系统类_myApp.Config.参数.设备编号;
            }
            return xt;
        }

    }
}
