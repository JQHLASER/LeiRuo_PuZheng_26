using Sunny25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace myappdll
{
    internal class Csv
    {

        internal class Config
        {
            internal static string FileCsv { set; get; } = Environment.CurrentDirectory + "\\Csv";
        }

        internal static void 初始化()
        {
            new mainclassqf.文件_文件夹().文件夹_不存在时新建(Config.FileCsv);

        }

        internal static bool 保存(DateTime now, List<表.dataZX> lst)
        {
            bool rt = true;
            string File_0 = Config.FileCsv + $"\\{now.Year}";
            string File_1 = $"{File_0}\\{now.Month}";
            string path = $"{File_1}\\{now.Day}";

            new mainclassqf.文件_文件夹().文件夹_不存在时新建(File_0);
            new mainclassqf.文件_文件夹().文件夹_不存在时新建(File_1);


            if (lst.Count > 0)
            {
                path += $"_{lst[0].机种}.csv ";
            }

            bool 是否添加 = new mainclassqf.文件_文件夹().文件是否存在(path) ? true : false;


            List<string[]> lstCsv = new List<string[]>();
            List<string> lstStr = new List<string>();

            #region 标题

            if (!是否添加)
            {
                lstStr.Add("拖条码");
                lstStr.Add("箱条码");
                lstStr.Add("SN条码");
                lstStr.Add("机种");
                lstStr.Add("机台代码");
                lstStr.Add("时间");

                lstStr.Add("每盘数量(个/盘)");
                lstStr.Add("每箱盘数(盘/箱)");
                lstStr.Add("每箱数量(个/箱)");
                lstStr.Add("每拖箱数(箱/拖)");


                lstStr.Add("备注");

                lstCsv.Add(lstStr.ToArray());
            }

            #endregion

            #region 内容

            foreach (var s in lst)
            {
                lstStr.Clear();
                lstStr.Add(s.拖条码);
                lstStr.Add(s.箱条码);
                lstStr.Add(s.SN条码);
                lstStr.Add(s.机种);
                lstStr.Add(s.机台代码);
                lstStr.Add(s.时间);

                lstStr.Add(s.每盘数量.ToString());
                lstStr.Add(s.每箱盘数.ToString());
                lstStr.Add(s.每箱数量.ToString());
                lstStr.Add(s.每拖箱数.ToString());

                lstStr.Add(s.备注);
                lstCsv.Add(lstStr.ToArray());
            }


            #endregion


            rt = new mainclassqf.CSV().Write(path, lstCsv, true, out string msgErr, new mainclassqf.编码Encoding().Encoding_编码());
            if (!rt)
            {
                Log.Add(rt, $"Csv,保存失败,{msgErr}");
            }

            return rt;
        }

    }
}
