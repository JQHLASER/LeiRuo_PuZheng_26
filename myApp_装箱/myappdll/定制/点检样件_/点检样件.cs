using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 点检样件
    {
        internal class Config
        {
            internal static string[] 点检数据 { set; get; } = new string[0];
        }

        /// <summary>
        /// 读写参数
        /// </summary>
        /// <param name="model"></param>
        internal static void Cfg(ushort model)
        {
            string path = mainclassSoft.系统类.Config.File_MyAppSys_Config + "\\djsys.cfg";
            string[] dj = Config.点检数据;
            new mainclassSoft.系统类().读写参数(ref  dj, model, path, out string smgErr);
            Config.点检数据 = dj;
        }





    }
}
