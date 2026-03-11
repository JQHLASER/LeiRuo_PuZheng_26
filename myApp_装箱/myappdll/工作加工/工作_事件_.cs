using mainclassqf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 工作_事件_
    {

        internal class Config
        {
            /// <summary>
            /// 10:加工中
            /// </summary>
            internal static int 加工中 { set; get; } = 0;
        }



        /// <summary>
        /// status: =true:开始,=false:结束
        /// </summary>
        /// <param name="status"></param>
        internal static void On_加工(bool status, bool 加工结果, DateTime dates)
        {
            if (status)
            {
                显示.加工条(Sunny25.LED_显示条.enum状态.Yello, $"{语言.读取语言("加工开始...")}");
                工作.Config.工作状态 = 10;
                Config.加工中 = 10;

                string logShow = $"-----------------------------------------start";
                Log.Add(true, logShow);

                logShow = $"{语言.读取语言("加工开始")}.... {工件 .gj_sys .Config .文件名}";
                Log.Add(true, logShow);

                On_加工中(true);
            }
            else
            {
                On_加工结束(加工结果);
                On_加工中(false);
                new mainclassqf.日期时间().计算时间差(dates, DateTime.Now, out string dateStr);
                string show = 加工结果 ? $"{语言.读取语言("加工结束")}...OK" : $"{语言.读取语言("加工结束")}...NG";

                Log.Add(true, $"{show},{dateStr}");


                show = $"-----------------------------------------end";
                Log.Add(true, show);


                工作.Config.工作状态 = 0;
                Config.加工中 = 0;
            }
        }


        static void On_加工中(bool status)
        {
            if (status)
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.绿灯, false);
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.黄灯, true);
            }
            else
            {
              
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.黄灯, false );
            }
        }

        static async Task On_加工结束(bool 加工结果)
        {
            IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.黄灯, false);
            if (加工结果)
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.绿灯, true);                
                显示.加工条(Sunny25.LED_显示条.enum状态.Green, $"OK,{语言.读取语言("加工结束")}");
            }
            else
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                显示.加工条(Sunny25.LED_显示条.enum状态.Red, $"NG,{语言.读取语言("加工结束")}");
            }
        }




    }
}
