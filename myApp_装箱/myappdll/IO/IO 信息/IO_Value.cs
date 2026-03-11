using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class IO_Value
    {
        internal class _InPut_
        {
            internal static bool 启动 { set; get; } = false;
            internal static bool 复位 { set; get; } = false;
        }


        internal class _OutPut_
        {
            internal static bool 三色灯_黄灯 { set; get; } = false;
            internal static bool 三色灯_绿灯 { set; get; } = false;
            internal static bool 三色灯_红灯 { set; get; } = false;

        }









    }
}
