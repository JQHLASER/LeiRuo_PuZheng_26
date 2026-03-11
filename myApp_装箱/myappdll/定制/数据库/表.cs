
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 表
    {
        /// <summary>
        /// 装箱表
        /// </summary>
        public class dataZX
        {

            public string 拖条码 { set; get; } = "";
            public string 箱条码 { set; get; } = "";
            public string SN条码 { set; get; } = "";
            public string 机种 { set; get; } = "";
            public string 机台代码 { set; get; } = "";
            public string 时间 { set; get; } = "";

            public int 每盘数量 { set; get; } = 0;

            public int 每箱盘数 { set; get; } = 0;
            public int 每箱数量 { set; get; } = 0;
            public int 每拖箱数 { set; get; } = 0;

            public string 备注 { set; get; } = "";

        }









    }
}
