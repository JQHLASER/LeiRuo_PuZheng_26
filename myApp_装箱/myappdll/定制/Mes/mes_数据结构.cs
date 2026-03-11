using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    public  class mes_数据结构
    {
        public class _上传_
        {
            /// <summary>
            /// 交互时间
            /// </summary>
            public string datetime { set; get; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            /// <summary>
            /// 设备编号
            /// </summary>
            public string lineNm { set; get; } = "";
            public _data_[] data { set; get; } = new _data_[0];
        }


        public class _data_
        {
            /// <summary>
            /// 机种
            /// </summary>
            public string Nds { set; get; } = "";
            /// <summary>
            /// 箱码
            /// </summary>
            public string codeBox { set; get; } = "";
            /// <summary>
            /// 拖码
            /// </summary>
            public string codeDrop { set; get; } = "";

            /// <summary>
            /// 每盘上的sn码
            /// </summary>
            public string[] sn { set; get; } = new string[0];
        }

        public class _反馈_
        {
            /// <summary>
            /// =0成功,=1失败
            /// </summary>
            public int code { set; get; } = -1;

            /// <summary>
            /// 消息
            /// </summary>
            public string msg { set; get; } = "";
 
        }


    }
}
