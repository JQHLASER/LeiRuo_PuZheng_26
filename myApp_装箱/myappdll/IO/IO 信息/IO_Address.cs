using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class IO_Address
    {
        internal class _InPut_
        {
            internal static int 启动 { set; get; } = 0;
            internal static int 复位 { set; get; } = 1;
        }


        internal class _OutPut_
        {
            internal static int 三色灯_黄灯 { set; get; } = 0;
            internal static int 三色灯_绿灯 { set; get; } = 1;
            internal static int 三色灯_红灯 { set; get; } = 2;

        }





    }
}
