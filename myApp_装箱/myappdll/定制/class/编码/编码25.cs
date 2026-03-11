using mainclassqf;
using mainclassSoft;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace myappdll
{
    public class 编码25
    {

        public 编码25(mainIndustryqf.编码.enum_文件类型 文件类型 = mainIndustryqf.编码.enum_文件类型.ini_net)
        {
            this.Encod_sys.Config.文件类型 = 文件类型;
        }


        public class info_文件信息_
        {
            public mainIndustryqf.编码.info_班次结构_[] 结构_班次 { set; get; } = new mainIndustryqf.编码.info_班次结构_[0];
            public mainIndustryqf.编码.info_文件cfg_ 文件 { set; get; } = new mainIndustryqf.编码.info_文件cfg_();
            public mainIndustryqf.编码.info_对象obj_内容_[] 结构_文件对象内容 { set; get; } = new mainIndustryqf.编码.info_对象obj_内容_[0];
            public List<string> lst_对象名称 { set; get; } = new List<string>();
            public List<string> lst_对象内容 { set; get; } = new List<string>();
            public string 文件名 { set; get; } = string.Empty;

        }

        public mainIndustryqf.编码 Encod_sys = new mainIndustryqf.编码();
        public Config_ Config = new Config_();


        public class Config_
        {
            public info_文件信息_ 文件信息 { set; get; } = new info_文件信息_();
        }


        public void 初始化_加载上次文件()
        {
            string name = "";
            读写_最后打开的参数(1, ref name);
            if (Err_文件名(name, out string msgErr))
            {
                打开(name);
            }
        }
        public void 读写_最后打开的参数(ushort model, ref string 文件名)
        {
            string path = Environment.CurrentDirectory + "\\bmcfg.dll";
            if (model == 0)
            {
                new ini().Write("文件", "文件名", 文件名, path);
            }
            文件名 = new ini().Read("文件", "文件名", 文件名, path);
        }

        public void 文件信息初始化()
        {
            this.Config.文件信息 = new info_文件信息_();
        }


        public void 初始化()
        {
            Encod_sys.Config.功能.定制功能_根据指定时间更新日期 = false;
            Encod_sys.Config.功能.工具_关联对象 = true;
            Encod_sys .Config .功能 .工具_班次 = false ;
            Encod_sys.Config.功能.文本_外部数据  = true ;



            Encod_sys.Action_获取模板名称 += On_获取所有激光模板;
            Encod_sys.初始化();

        }
        public void 释放()
        {
            Encod_sys.Action_获取模板名称 -= On_获取所有激光模板;
            Encod_sys.释放();
        }

        public void 窗体_系统设置()
        {
            if (!Encod_sys.Err_未初始化(out string msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }

            Encod_sys.窗体_系统设置();
        }

        public void 标题栏状态(mainclassSoft.myForm_2025 myForms, string 标题)
        {
            this.Encod_sys.标题栏状态(myForms, 标题);
        }




        public bool 打开(string 文件名, DateTime now, bool 加工)
        {
            List<string> lstWork = new List<string>();
            lstWork.Add("Err");
            lstWork.Add("打开");
           lstWork.Add("赋值");
            lstWork.Add("生成");

            bool rt = true;
            string msgErr = string.Empty;
            mainIndustryqf.编码.info_文件cfg_ 文件 = new mainIndustryqf.编码.info_文件cfg_();
            mainIndustryqf.编码.info_班次结构_[] 班次结构 = new mainIndustryqf.编码.info_班次结构_[0];
            mainIndustryqf.编码.info_对象obj_内容_[] 结构_对象内容 = new mainIndustryqf.编码.info_对象obj_内容_[0];

            Config.文件信息 = new info_文件信息_();


            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "Err")
                {
                    #region Err

                    if (!Encod_sys.Err_未初始化(out msgErr))
                    {
                        rt = false;
                    }
                    else if (!Err_文件名(文件名, out msgErr))
                    {
                        rt = false;
                    }

                    #endregion
                }
                else if (s == "打开")
                {
                    #region 打开

                    rt = Encod_sys.文件_打开(文件名, out 文件, out 班次结构, out msgErr);
                    string show = rt ? $"{语言.读取语言("编码模块,打开文件成功")},{文件名}" : $"{语言.读取语言("编码模块,打开文件失败")},{文件名},{msgErr}";

                  

                  On_Log(rt, show);

                    #endregion
                }
                else if (s == "赋值")
                {
                    #region 赋值

                    Config.文件信息.文件名 = 文件名;
                    Config.文件信息.文件 = 文件;
                    Config.文件信息.结构_班次 = 班次结构;
                    
                  //  读写_最后打开的参数(0, ref 文件名);

                    #endregion
                }

                else if (s == "生成")
                {

                    #region 生成

                    rt = 生成内容(加工, now, out 结构_对象内容, out List<string> lst对象名称, out List<string> lst对象内容);
                    Config.文件信息.结构_文件对象内容 = 结构_对象内容;
                    Config.文件信息.lst_对象内容 = lst对象内容;
                    Config.文件信息.lst_对象名称 = lst对象名称;

                    #endregion

                }


            }


            return rt;
        }


        /// <summary>
        /// 只是打开,非加工时
        /// </summary>
        /// <param name="文件名"></param>
        /// <returns></returns>
        public bool 打开(string 文件名 )
        {
          return    打开(  文件名, DateTime .Now , false );
        }


        /// <summary>
        /// 加工: =true,工作时调用,=false:非工作时用
        /// </summary>
        /// <param name="加工"></param>
        /// <param name="时间"></param>
        /// <param name="结构_对象内容"></param>
        /// <param name="lst对象名称"></param>
        /// <param name="lst对象内容"></param>
        /// <returns></returns>
        public bool 生成内容(bool 加工, DateTime 时间, out mainIndustryqf.编码.info_对象obj_内容_[] 结构_对象内容, out List<string> lst对象名称, out List<string> lst对象内容)
        {
            bool 时间更新处理 = true;
            bool rt = true;
            string msgErr = "";
            结构_对象内容 = new mainIndustryqf.编码.info_对象obj_内容_[0];
            lst对象名称 = new List<string>();
            lst对象内容 = new List<string>();

            if (!Encod_sys.Err_未初始化(out msgErr))
            {
                rt = false;
                On_Log(rt, msgErr);
                return rt;
            }

            string show = $"{语言.读取语言("编码模块,生成内容...开始")},{Config.文件信息.文件名}";
            On_Log(rt, show);

            List<string> lstWork = new List<string>();
            lstWork.Add("生成");


            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "生成")
                {
                    rt = Encod_sys.加工_生成数据(Config.文件信息.文件, Config.文件信息.文件名, 时间, 时间更新处理, Config.文件信息.结构_班次, 加工, out 结构_对象内容, out lst对象名称, out lst对象内容, out msgErr);
                    if (rt)
                    {
                        Config.文件信息.结构_文件对象内容 = 结构_对象内容;
                        Config.文件信息.lst_对象内容 = lst对象内容;
                        Config.文件信息.lst_对象名称 = lst对象名称;
                    }

                    show = rt ? $"{语言.读取语言("编码模块,生成内容成功")}" : $"{语言.读取语言("编码模块,生成内容失败")}, {msgErr}";
                    On_Log(rt, show);

                }
            }


            return rt;
        }

        public bool 复位序列号(out string msgErr)
        {
            bool rt = true;
            msgErr = "";
            rt = Encod_sys.生成数据(true, Config.文件信息.文件, DateTime.Now, Config.文件信息.结构_班次, out mainIndustryqf.编码.info_对象obj_内容_[] Obj1, mainIndustryqf.编码.enum序列号操作_.强制复位, out List<string> lst对象名, out List<string> lst内容, out msgErr);

            if (rt)
            {
                Encod_sys.文件_保存_queue(Config.文件信息.文件名, DateTime.Now, Config.文件信息.文件);
            }


            msgErr = rt ? "复位序列号成功" : $"复位序列号失败,{msgErr}";
            On_Log(rt, msgErr);

            return rt;
        }


        #region Err



        public bool Err_未检测到编码信息(out string msgErr)
        {
            msgErr = string.Empty;
            bool rt = true;
            if (Config.文件信息.lst_对象内容.Count == 0)
            {
                msgErr = $"{语言.读取语言("编码模块,未检测到编码信息")}";
                On_Log(false, msgErr);
                rt = false;
            }
            return rt;
        }

        bool Err_文件名(string 文件名, out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            string path = Encod_sys.文件_获取文件完整路径cfgs(文件名);
            if (string.IsNullOrEmpty(文件名))
            {
                rt = false;
                msgErr = $"{语言.读取语言("编码模块,文件名不能为空")}";
                On_Log(false, msgErr);
            }
            else if (!new 文件_文件夹().文件是否存在(path))
            {
                rt = false;
                msgErr = $"{语言.读取语言("编码模块,未找到文件")}";
                On_Log(false, msgErr);
            }


            return rt;
        }

        bool Err_未初始化(out string msgErr)
        {
            msgErr = string.Empty;
            bool rt = true;
            if (this.Encod_sys.Config.初始化状态 != 0)
            {
                msgErr = $"{语言.读取语言("编码模块,未初始化")}";
                On_Log(false, msgErr);
                rt = false;
            }
            return rt;
        }





        #endregion



        #region 事件


        public Action<bool, string> Action_Log;
        void On_Log(bool state, string logMsg)
        {
            Action_Log?.Invoke(state, logMsg);
        }

        public Func<string[]> Action_获取所有激光模板;
        string[] On_获取所有激光模板()
        {
            return Action_获取所有激光模板?.Invoke();
        }


        #endregion




        public void 显示到画布(Sunny25.Draw画布 Draw画布, int 标题长度)
        {

            string name = $"----------【{语言.读取语言("编码")}】";
            string value = $"----------";
            Draw画布.添加_分割线(0, 0, 0, 0, 0, $"{name}", $"{value}");

            foreach (var s in Config.文件信息.结构_文件对象内容)
            {

                string xt = "";

                if (Encod_sys.Config.功能.使能_对象属性_位数校验 && s.属性.对象位数 > 0)
                {
                    xt += $"<S:{s.属性.对象位数},V:{Encoding.ASCII.GetByteCount(s.内容)}>";
                }

                if (Encod_sys.Config.功能.使能_对象属性_防重 && s.属性.防重)
                {
                    xt += $"<{语言.读取语言("防重")}>";
                }

                if (Encod_sys.Config.功能.使能_对象属性_读码 && s.属性.读码)
                {
                    xt += $"<{语言.读取语言("读码")}>";
                }
                if (Encod_sys.Config.功能.使能_对象属性_变量校验 && s.属性.变量校验)
                {
                    xt += $"<{语言.读取语言("变量校验")}>";
                }
                if (Encod_sys.Config.功能.使能_对象属性_关键字校验 && s.属性.关键字校验)
                {
                    xt += $"<{语言.读取语言("关键字校验")}>";
                }
                name = new 文本().对齐(s.对象名, 标题长度, 0, ' ');
                Draw画布.添加(0, 0, 0, 0, 0, true, $"{name} :");

                if (!string.IsNullOrEmpty(xt))
                {
                    value = $"{语言.读取语言("属性")}:{xt}";
                    Draw画布.添加(0, 0, 0, 0, 0, false, value);

                    name = new 文本().对齐("", 标题长度, 0, ' ');
                    Draw画布.添加(0, 0, 0, 0, 0, true, $"{name}  ");
                }


                Draw画布.添加(0, 1, 0, 0, 0, false, s.内容);

            }


        }

        









    }
}
