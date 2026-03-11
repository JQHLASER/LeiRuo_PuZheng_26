using MarkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace myappdll
{
    internal class 打印
    {
        public class info参数_
        {
            public string path_箱_标签 { set; get; }
            public string path_拖_标签 { set; get; }
        }

        internal class Config
        {
            public static string file_存放模板 { set; get; } = Environment.CurrentDirectory + "\\print";
            public static string 后缀 { set; get; } = ".btw";
            public static info参数_ 参数 { set; get; } = new info参数_();

            /// <summary>
            /// 0:无 ,10:打开文件中,11:打印中
            /// </summary>
            public static int 工作状态 { set; get; } = 0;
        }
         

        internal static void 初始化()
        {
            new mainclassqf.文件_文件夹().文件夹_不存在时新建(Config.file_存放模板);
            //  print_sys.BarTender_sys.初始化();

        }

        internal static void 标题栏状态()
        {
            List<string[]> lst = new List<string[]>();
            lst.Add(new string[] { "10", "加载打印文件中" });
            lst.Add(new string[] { "11", "打印机打印中" });
            申明.myForm25_sys.标题栏显状态_添加显示(Config.工作状态, lst);

        }



        internal static string 生成路径(string 文件名)
        {
            return $"{Config.file_存放模板}\\{文件名}";
        }

        internal static bool 打开_btw(string 文件名, out string msgErr)
        {
            Log.Add(true, $"打印机,打开文件...{文件名}");
            bool rt = true;
            msgErr = string.Empty;
            string path = 生成路径(文件名);

            List<string> lstWork = new List<string>();
            lstWork.Add("Err");
            lstWork.Add("打开");

            try
            {

                foreach (var s in lstWork)
                {
                    if (!rt)
                    {
                        break;
                    }
                    else if (s == "Err")
                    {
                        #region Err

                        if (string.IsNullOrEmpty(文件名))
                        {
                            msgErr = "文件名不能为空";
                            rt = false;
                        }
                        else if (!new mainclassqf.文件_文件夹().文件是否存在(path))
                        {
                            msgErr = $"未找到文件,{path}";
                            rt = false;
                        }


                        #endregion
                    }
                    else if (s == "打开")
                    {
                        rt = new mainIndustryqf.BarTender_打印().打开(path, null, null, out msgErr);
                    }
                }

            }
            catch (Exception ex)
            {
                rt = false;
                msgErr = ex.Message;
            }

            string show = rt ? $"打印机,打开文件成功,{文件名}" : $"打印机,打开文件失败,{文件名},{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool 打印_btw(string 文件名, mainIndustryqf.BarTender_打印.info_变量_[] beff, out string msgErr)
        {
            Log.Add(true, $"打印机,打印...{文件名}");
            msgErr = string.Empty;
            string path = 生成路径(文件名);


            List<string> lstWork = new List<string>();
            lstWork.Add("Err");
            lstWork.Add("打印");

            bool rt = true;
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "Err")
                {
                    #region Err

                    if (string.IsNullOrEmpty(文件名))
                    {
                        msgErr = "文件名不能为空";
                        rt = false;
                    }
                    else if (!new mainclassqf.文件_文件夹().文件是否存在(path))
                    {
                        msgErr = $"未找到文件,{path}";
                        rt = false;
                    }

                    #endregion
                }
                else if (s == "打印")
                {
                    mainIndustryqf.BarTender_打印.info_打印参数_ info = new mainIndustryqf.BarTender_打印.info_打印参数_();
                    info.判断修改内容结果 = true;
                    info.打印张数 = 1;
                    info.pic = null;
                    rt = new mainIndustryqf.BarTender_打印().打印(path, beff, info, out msgErr);
                }
            }

            string show = rt ? $"打印机,打印成功,{文件名}" : $"打印机,打印失败,{文件名},{msgErr}";
            Log.Add(rt, show);
            return rt;
        }

        internal static bool Err_工作中(out string msgErr)
        {
            msgErr = string.Empty;
            bool rt = true;
            if (Config.工作状态 != 0)
            {
                msgErr = "打印机工作中";
                rt = false;
            }

            return true;
        }


    }
}
