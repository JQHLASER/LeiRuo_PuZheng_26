
using SqlSugar;
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
            [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
            public int id { set; get; }
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


        /*
         //注:索引时必须SN条形码在最前面,否则防重查询时会有点慢
         //需要索引的字段
            SN条码
            拖条码
            箱条码
            机台代码
            时间
            机种


         CREATE TABLE dataZX
            (                 
                   id                  [bigint] IDENTITY(1, 1)  PRIMARY KEY   ，
                   拖条码              [varchar](255) NULL,
                   箱条码              [varchar](255) NULL,
                   SN条码              [varchar](255) NULL,
                   机种                [varchar](255) NULL,
                   机台代码            [varchar](255) NULL,
                   时间                [varchar](255) NULL,
                   每盘数量            [int]  NULL,
                   每箱盘数            [int]  NULL,
                   每箱数量            [int]  NULL,
                   每拖箱数            [int]  NULL,
                   备注                [varchar](255) NULL
            );

         */






    }
}
