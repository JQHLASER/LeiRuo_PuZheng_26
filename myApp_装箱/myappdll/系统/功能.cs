using mainclassSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 功能
    {
        internal class Config
        {
            internal static 软件注册2024.enum注册方式 注册方式 { get; } = 软件注册2024.enum注册方式.加密狗;
            /// <summary>
            /// 使用|为分割符
            /// </summary>
            internal static string 软件识别码 { get; } = "定制|读码装箱";

            /// <summary>
            /// 另存一个带work标识的日志
            /// </summary>
            internal static bool 使能_日志_work { set; get; } = false;


            internal static bool 使能_用户 { set; get; } = true;

            internal static bool 使能_生产计数_零件 { set; get; } = false;
            internal static bool 使能_生产计数_良品 { set; get; } = false;
            internal static bool 使能_生产计数_不良品 { set; get; } = false;


        }

        internal static void 设置()
        {
            申明.myForm25_sys.Config.注册方式 = Config.注册方式;
            DogTW_2024.Config.软件识别码 = Config.软件识别码;

        }




    }
}
