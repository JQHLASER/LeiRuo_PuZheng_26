using mainclassqf;
using MarkAPI;
using Newtonsoft.Json;
using SqlSugar;
using Sunny25;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace myappdll
{
    internal class dataBase
    {
        static mainclassqf.SqlSugar25_DB db_sys = new SqlSugar25_DB();
        static mainWork25.数据库_dataBase<表.dataZX> sql_sys;



        static string _id = "database";
        internal static void 初始化()
        {
            string path = mainclassSoft.系统类.Config.File_MyAppSys_Config + "\\dataBase.cfg";
            //mainclassqf.SqlSugar25_DB.Info_参数_ info = new mainclassqf.SqlSugar25_DB.Info_参数_();
            //info.数据库类型 = mainclassqf.SqlSugar25_DB.enum数据库类型.SqlServer;
            //info.使能_读参数文件 = true;
            //  info.数据库连接参数.SQLserver_Cfg.数据库名称;

            mainclassqf.SqlSugar25_DB.Info_SQLserver_ infoServer = new SqlSugar25_DB.Info_SQLserver_();
            db_sys.读取数据库信息(1, ref infoServer, path);

            string sql = db_sys.生成连接字符串(infoServer);
            List<ConnectionConfig> lstConne = new List<ConnectionConfig> {
                db_sys.生成连接参数(sql,_id , SqlSugar.DbType.SqlServer),
            };
            //db_sys = new mainclassqf.SqlSugar25_DB(info, path, SqlSugar25_DB.enumSQLserver.新驱动);
            db_sys.初始化(lstConne);


            sql_sys = new mainWork25.数据库_dataBase<表.dataZX>(db_sys, _id);

            sql_sys.Action_初始化 += On_初始化;
            sql_sys.Action_查询 += On_查询;
            sql_sys.Action_进入查询窗体 += On_进入查询窗体;
            sql_sys.Action_导出_含导出路径 += On_导出;
            sql_sys.Action_指定页信息 += On_到指定页;

            sql_sys.初始化();
            表格式();
        }

        internal static void 释放()
        {
            if (sql_sys is null)
            {
                return;
            }
            sql_sys.Action_初始化 -= On_初始化;
            sql_sys.Action_查询 -= On_查询;
            sql_sys.Action_进入查询窗体 -= On_进入查询窗体;
            sql_sys.Action_导出_含导出路径 -= On_导出;
            sql_sys.Action_指定页信息 -= On_到指定页;
        }

        internal static void 标题栏状态()
        {
            if (db_sys != null && sql_sys != null)
            {
                sql_sys.标题栏状态(申明.myForm25_sys);
            }
        }

        static bool On_初始化()
        {
            bool rt = true;
            rt = 查询_初始化测试(out string msgErr);
            return rt;
        }


        #region 操作数据库

        internal static bool 添加(List<表.dataZX> lst, out string msgErr)
        {
            bool rt = true;
            string json = JsonConvert.SerializeObject(lst.ToArray(), Formatting.Indented);
            Log.Add(rt, $"数据库,添加...\r\n{json}");
            msgErr = string.Empty;
            rt = sql_sys.添加(lst, out int 受影响行, out msgErr);
            string show = rt ? $"数据库,添加成功,{受影响行}" : $"数据库,添加失败,{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool 查询_初始化测试(out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            string sqlStr = "select * from dataZX where 1=1 and 拖条码='^%&*()(&^@'";
            rt = sql_sys.查询_SQL语句(sqlStr, out List<表.dataZX> lst, out msgErr);
            string show = rt ? $"数据库,初始化成功" : $"数据库,初始化失败,{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        /// <summary>
        /// true:正常,false:失败或重码
        /// </summary>
        /// <param name="lstSN条码"></param>
        /// <param name="lst"></param>
        /// <param name="msgErr"></param>
        /// <returns></returns>
        internal static bool 查询_防重_SN条码(List<读码器.info_码信息_> lst不为空的码信息, out List<表.dataZX> lst, out string msgErr)
        {
            List<string> lstSN条码 = new List<string>();
            foreach (var s in lst不为空的码信息)
            {
                lstSN条码.Add(s.码内容);
            }


            bool rt = true;
            string json = JsonConvert.SerializeObject(lstSN条码.ToArray(), Formatting.Indented);
            Log.Add(rt, $"数据库,查询SN条码...\r\n{json}");

            msgErr = string.Empty;
            string sqlStr = "select SN条码 from dataZX where 1=1 and SN条码 in ";
            sqlStr += "(";
            for (int i = 0; i < lstSN条码.Count; i++)
            {
                if (i == 0)
                {
                    sqlStr += $"'{lstSN条码[i]}'";
                }
                else
                {
                    sqlStr += $",'{lstSN条码[i]}'";
                }
            }
            sqlStr += ")";


            //List<string> sns = new List<string>();
            //foreach (var s in lst不为空的码信息)
            //{
            //    sns.Add(s.码内容);
            //} 

            //var list = db_sys.Db.Queryable<表.dataZX>()
            // .Where(d => sns.Contains(d.SN条码))
            // .Select(d => new { d.SN条码 }) // 不要 *
            // .ToList();


            rt = sql_sys.查询_SQL语句(sqlStr, out lst, out msgErr);

            if (rt && lst.Count > 0)
            {
                rt = false;
                json = JsonConvert.SerializeObject(lst, Formatting.Indented);
                msgErr = $"重码,\r\n{json}";
            }

            string show = rt ? $"数据库,查询SN条码,OK" : $"数据库,查询SN条码,NG,{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool 查询_防重_拖条码(string 拖条码, out List<表.dataZX> lst, out string msgErr)
        {
            bool rt = true;
            Log.Add(rt, $"数据库,查询拖条码...{拖条码}");

            msgErr = string.Empty;
            string sqlStr = $"select * from dataZX where 1=1 and 拖条码 in ('{拖条码}')";

            rt = sql_sys.查询_SQL语句(sqlStr, out lst, out msgErr);

            if (rt && lst.Count > 0)
            {
                rt = false;
                string json = JsonConvert.SerializeObject(lst);
                msgErr = $"重码,\r\n{json}";
            }

            string show = rt ? $"数据库,查询拖条码,OK" : $"数据库,查询拖条码,NG,{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool 查询_防重_箱条码(string 箱条码, out List<表.dataZX> lst, out string msgErr)
        {
            bool rt = true;
            Log.Add(rt, $"数据库,查询箱条码...{箱条码}");

            msgErr = string.Empty;
            string sqlStr = $"select * from dataZX where 1=1 and 箱条码 in ('{箱条码}')";

            rt = sql_sys.查询_SQL语句(sqlStr, out lst, out msgErr);

            if (rt && lst.Count > 0)
            {
                rt = false;
                string json = JsonConvert.SerializeObject(lst);
                msgErr = $"重码,\r\n{json}";
            }

            string show = rt ? $"数据库,查询箱条码,OK" : $"数据库,查询箱条码,NG,{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool 查询(表.dataZX 条件, DateTime 起始时间, DateTime 结束时间, out List<表.dataZX> lst, out string msgErr)
        {
            string dateStart = 起始时间.ToString("yyyy-MM-dd HH:mm:ss");
            string dateEnd = new mainclassqf.日期时间().增减时间(结束时间, 2, 1).ToString("yyyy-MM-dd HH:mm:ss");

            string sqlStr = "select * from dataZX where 1=1 ";

            bool 是否含时间 = true;
            if (!string.IsNullOrEmpty(条件.机种))
            {
                sqlStr += $"and 机种 ='{条件.机种}'";
            }

            if (!string.IsNullOrEmpty(条件.SN条码))
            {
                是否含时间 = false;
                sqlStr += $"and SN条码 ='{条件.SN条码}'";
            }
            if (!string.IsNullOrEmpty(条件.拖条码))
            {
                是否含时间 = false;
                sqlStr += $"and 拖条码 ='{条件.拖条码}'";
            }
            if (!string.IsNullOrEmpty(条件.箱条码))
            {
                是否含时间 = false;
                sqlStr += $"and 箱条码 ='{条件.箱条码}'";
            }

            if (是否含时间)
            {
                sqlStr += $"and 时间 >='{dateStart}' and 时间 <='{dateEnd}'";

            }

            msgErr = string.Empty;
            bool rt = sql_sys.查询_SQL语句(sqlStr, out lst, out msgErr);
            return rt;
        }


        #endregion



        #region 查询

        internal static void 窗体_查询()
        {
            sql_sys.窗体_查询();
        }

        static void On_进入查询窗体()
        {
            Sunny25.UIDataGridView UIdatagridview_ = sql_sys.form_查询窗体.forms.uI_查询1.uiDataGridView1;
            UIdatagridview_.sys.清除_全部行();
            sql_sys.查询窗体_清除();
            sql_sys.查询窗体_显示标题();
        }

        static void On_查询()
        {
            DialogResult dlt = new Form_数据库_查询().ShowDialog();
        }

        internal static void On_查询(List<表.dataZX> lst)
        {
            sql_sys.查询窗体_清除();
            sql_sys.Config.查询窗体_info.lst数据 = lst;
            new mainclassqf.List_().分割成多页(lst, sql_sys.Config.查询窗体_info.每页行数, out List<表.dataZX[]> lst数据_分页后);
            sql_sys.Config.查询窗体_info.lst数据_分页后 = lst数据_分页后;
            sql_sys.Config.查询窗体_info.总行数 = lst.Count;
            sql_sys.Config.查询窗体_info.总页数 = lst数据_分页后.Count;
            sql_sys.On_到头页();


        }


        static void On_导出(string CsvPath)
        {
            导出(CsvPath);
        }

        static void 导出(string CsvPath)
        {


            List<string[]> lstCsv = new List<string[]>();
            List<string> lstStr = new List<string>();

            #region 标题

            lstStr.Add("拖条码");
            lstStr.Add("箱条码");
            lstStr.Add("SN条码");
            lstStr.Add("机种");
            lstStr.Add("机台代码");
            lstStr.Add("时间");
            lstStr.Add("备注");

            lstCsv.Add(lstStr.ToArray());


            #endregion

            #region 内容

            foreach (var s in sql_sys.Config.查询窗体_info.lst数据)
            {
                lstStr.Clear();
                lstStr.Add(s.拖条码);
                lstStr.Add(s.箱条码);
                lstStr.Add(s.SN条码);
                lstStr.Add(s.机种);
                lstStr.Add(s.机台代码);
                lstStr.Add(s.时间);
                lstStr.Add(s.备注);
                lstCsv.Add(lstStr.ToArray());
            }


            #endregion

            string path = CsvPath;
            bool rt = new mainclassqf.CSV().Write(path, lstCsv, false, out string msgErr, new mainclassqf.编码Encoding().Encoding_编码());
            if (rt)
            {
                Sunny25.Messagebox.Show($"导出成功\r\n共{sql_sys.Config.查询窗体_info.lst数据.Count}行");
            }
            else
            {
                Sunny25.Messagebox.Show($"导出失败\r\n{msgErr}", "", MessageboxStatus.Red);
            }


        }

        static void On_到指定页(表.dataZX[] beff)
        {
            //显示到uidatagridview容器中
            sql_sys.form_查询窗体.forms.Invoke(new Action(() =>
            {
                Sunny25.UIDataGridView uiDatagridview_ = sql_sys.form_查询窗体.forms.uI_查询1.uiDataGridView1;

                foreach (var b in beff)
                {
                    int count = uiDatagridview_.sys.获取_总行数();
                    uiDatagridview_.sys.添加行();

                    uiDatagridview_.sys.设置_数据(count, 0, b.拖条码);
                    uiDatagridview_.sys.设置_数据(count, 1, b.箱条码);
                    uiDatagridview_.sys.设置_数据(count, 2, b.SN条码);
                    uiDatagridview_.sys.设置_数据(count, 3, b.机种);
                    uiDatagridview_.sys.设置_数据(count, 4, b.机台代码);
                    uiDatagridview_.sys.设置_数据(count, 5, b.时间);

                    uiDatagridview_.sys.设置_数据(count, 6, b.每盘数量.ToString());
                    uiDatagridview_.sys.设置_数据(count, 7, b.每箱数量.ToString());
                    uiDatagridview_.sys.设置_数据(count, 8, b.每箱盘数.ToString());
                    uiDatagridview_.sys.设置_数据(count, 9, b.每拖箱数.ToString());

                    uiDatagridview_.sys.设置_数据(count, 10, b.备注);

                }

            }));



        }

        static void 表格式()
        {
            Sunny25.UIDataGridView UIdatagridview_ = sql_sys.form_查询窗体.forms.uI_查询1.uiDataGridView1;

            int cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 300);
            UIdatagridview_.sys.设置_列标题(cloumn, "拖条码");

            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 300);
            UIdatagridview_.sys.设置_列标题(cloumn, "箱条码");

            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 200);
            UIdatagridview_.sys.设置_列标题(cloumn, "SN条码");

            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "机种");

            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "机台代码");

            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 220);
            UIdatagridview_.sys.设置_列标题(cloumn, "时间");


            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "每盘数量");


            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "每箱数量");


            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "每箱盘数");


            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 150);
            UIdatagridview_.sys.设置_列标题(cloumn, "每拖箱数");



            cloumn = UIdatagridview_.sys.获取_总列数();
            UIdatagridview_.sys.添加列();
            UIdatagridview_.sys.设置_列宽(cloumn, 120);
            UIdatagridview_.sys.设置_列标题(cloumn, "备注");

            sql_sys.窗体_查询_列处理();
        }


        #endregion

    }
}
