
using mainIndustryqf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    class IO_ZKW
    {
        internal static  IO掌控王 IO_ZKW_sys = new IO掌控王();

        internal static void 初始化()
        {
            IO_ZKW_sys.Action_输入 += On_输入;
            IO_ZKW_sys.Action_输出 += On_输出;
            IO_ZKW_sys.初始化();

        }

        internal static void 释放()
        {
            IO_ZKW_sys.Action_输入 -= On_输入;
            IO_ZKW_sys.Action_输出 -= On_输出;     
            IO_ZKW_sys.释放();

        }

        static void On_输入(bool[] status)
        {
            
        }

        static void On_输出(bool[] status)
        {

        }


    }
}
