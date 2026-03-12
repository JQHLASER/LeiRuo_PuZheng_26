using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 系统类_myApp
    {
        public class info_Main
        {
            /// <summary>
            /// 0:不确认,1:确认
            /// </summary>
            public int 使能_打印前弹窗确认 { set; get; } = 0;
            public string 设备编号 { set; get; } = "";
            public bool 使能_手持扫码枪 { set; get; } = false;
            public bool  使能_Mes { set; get; } = false ;
            public string Mes_Url { set; get; } = "http://127.0.0.1:3003/";
        }


        internal class Config
        {
            internal static info_Main 参数 { set; get; } = new info_Main();
        }

        private static  readonly object _lock = new object();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="model"></param>
        internal static void Initiall(ushort model)
        {
            lock (_lock)
            {
                string path = mainclassSoft.系统类.Config.File_MyAppSys_Config + "\\systemCfg.txt";
                info_Main info = Config.参数;
                new mainclassSoft.系统类().读写参数(ref info, model, path, out string msgErr);
                Config.参数 = info;
            }
        }



    }
}
