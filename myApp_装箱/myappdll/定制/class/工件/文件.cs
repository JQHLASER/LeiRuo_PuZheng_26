
using mainclassqf;
using mainIndustryqf;
using Sunny25.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace myappdll
{
    public class 文件
    {
        mainclassSoft.myForm_2025 myForms;
        编码25 Encod_sys;

        public Config_ Config = new Config_();
        public mainWork25.文件类<info_参数_文件_> gj_sys = null;



        public 文件(mainclassSoft.myForm_2025 myForms_, 编码25 Encod_sys_)
        {
            this.myForms = myForms_;
            this.Encod_sys = Encod_sys_;

            mainWork25.文件类<info_参数_文件_>.info_参数_ 参数 = new mainWork25.文件类<info_参数_文件_>.info_参数_();

            参数.后缀 = Config.后缀;
            参数.files_文件夹 = Config.files_文件夹;
            gj_sys = new mainWork25.文件类<info_参数_文件_>(参数);


            gj_sys.Config.使能_文件加密 = false;
            gj_sys.Action_Log += On_Log;
        }



        #region 数据类

        public class info_数量_
        {
            public int 每盘个数 { set; get; } = 0;
            public int 每箱盘数 { set; get; } = 0;
            public int 每拖箱数 { set; get; } = 0;




            public int 当前箱盘数 { set; get; } = 0;
            public int 当前拖箱数 { set; get; } = 0;

        }


        public class info_编码内容_
        {
            public string 箱码 { set; get; } = "";
            public string 拖码 { set; get; } = "";
            public string 最后一次换拖时间 { set; get; } = "";
            public string 最后一次换箱时间 { set; get; } = "";
        }




        public class info_参数_文件_
        {
            public info_数量_ 数量 { set; get; } = new info_数量_();
            public string 打印标签_箱 { set; get; } = "";
            public string 打印标签_拖 { set; get; } = "";

            /// <summary>
            /// 手动设置
            /// </summary>
            public string SN码校验 { set; get; } = "";


            public string 机台代码 { set; get; } = ""
;
            public string 机种 { set; get; } = "";



            /// <summary>
            /// 后来改成用这个指令来切换模板了
            /// </summary>
            public string 读码指令 { set; get; } = "";
            public info_编码内容_ 编码内容 { set; get; } = new info_编码内容_();


            public string 读码图像名称 { set; get; } = "";
            public 图像.info_绘制信息_[] 图像标注参数 { set; get; } = new 图像.info_绘制信息_[0];
        }


        #endregion


        public class Config_
        {
            /// <summary>
            /// 当前加载的文件信息
            /// </summary>
            public info_参数_文件_ 文件 { set; get; } = new info_参数_文件_();

            /// <summary>
            /// 当前加载的文件名
            /// </summary>
            public string 文件名 { set; get; } = "";
            public string files_文件夹 { set; get; } = Environment.CurrentDirectory + "\\Fecfg";
            public string 后缀 { set; get; } = ".ecfg";


        }




        public void 释放()
        {
            if (gj_sys is null)
            {
                return;
            }
            gj_sys.Config.初始化状态 = -1;
            gj_sys.Action_Log -= On_Log;
        }


        public void 窗体_编辑()
        {
            if (!mainclassSoft.Err.系统报警(this.myForms, out string msgErr) || !mainclassSoft.Err.系统忙(this.myForms, out msgErr))
            {
                return;
            }
            else if (!gj_sys.Err_未初始化(out msgErr))
            {
                On_Log(false, msgErr);
                return;
            }
            On_Log(true, 语言.读取语言("文件模块,进入编辑窗体") + "...");
            new Form_工件_设置(this, this.Encod_sys, this.Config.文件名).ShowDialog();
            On_Log(true, 语言.读取语言("文件模块,退出编辑窗体"));
            if (Err_文件名(Config.文件名))
            {
                Task.Run(() => { this.打开(Config.文件名); });
            }
        }


        /// <summary>
        /// 保存当前打开的文件
        /// </summary>
        /// <param name="msgErr"></param>
        public bool 保存(out string msgErr)
        {
            info_参数_文件_ 文件 = Config.文件;
            bool rt = gj_sys.读写文件(0, Config.文件名, ref 文件, out msgErr);
            //  Config.文件 = 文件;
            //if (!rt)
            //{
            //    Log.Add(rt, $"文件模块,保存工件信息失败,{msgErr}");
            //}

            // rt = rt = gj_sys.读写文件(1, Config.文件名, ref 文件, out msgErr);


            return true;
        }


        public bool 打开(string 文件名)
        {

            gj_sys.Config.操作状态 = 10;

            On_Log(true, 语言.读取语言("文件模块,加载文件信息........."));

            info_参数_文件_ 文件 = new info_参数_文件_();
            this.Encod_sys.文件信息初始化();


            bool rt = true;
            string msgErr = "";
            List<string> lstWork = new List<string>();
            lstWork.Add("打开工件");
            lstWork.Add("赋值");
            lstWork.Add("打开编码文件");




            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "打开工件")
                {
                    rt = gj_sys.打开(文件名, ref 文件, out msgErr);
                    Config.文件 = 文件;

                    if (rt)
                    {
                        On_Log(true, $"{语言.读取语言("文件模块,打开文件成功")},{文件名}");
                    }
                    else
                    {
                        On_Log(false, $"{语言.读取语言("文件模块,打开文件失败")},{文件名},{msgErr}");
                        Config.文件 = new info_参数_文件_();
                        Config.文件名 = string.Empty;
                        rt = false;
                    }
                }
                else if (s == "打开编码文件")
                {
                    //rt = this.Encod_sys.打开(文件名);
                    //if (rt && !this.Encod_sys.Err_未检测到编码信息(out msgErr))
                    //{
                    //    rt = false;
                    //}

                }
                else if (s == "赋值")
                {
                    Config.文件名 = 文件名;
                    Config.文件 = 文件;
                }




            }



            rt = On_加载文件(rt);
            if (!rt)
            {
                On_加载文件失败输出报警();
            }

            string show = rt ? 语言.读取语言("文件模块,加载文件信息,OK") : 语言.读取语言("文件模块,加载文件信息,NG");
            On_Log(rt, $".......{show}");


            gj_sys.Config.操作状态 = 0;
            return rt;
        }

        /// <summary>
        /// 弹窗
        /// </summary>
        public DialogResult 打开()
        {
            if (!mainclassSoft.Err.系统报警(this.myForms, out string msgErr) || !mainclassSoft.Err.系统忙(this.myForms, out msgErr))
            {
                return DialogResult.No;
            }
            else if (!gj_sys.Err_未初始化(out msgErr))
            {
                On_Log(false, msgErr);
                return DialogResult.No;
            }
            info_参数_文件_ 文件 = new info_参数_文件_();
            DialogResult dlt = gj_sys.打开_弹窗(ref 文件, out string 文件名, out msgErr);
            if (dlt == DialogResult.OK)
            {
                if (打开(文件名))
                {
                    读写_最后打开的参数(0, ref 文件名);
                }

            }
            else if (dlt == DialogResult.No)
            {
                Sunny25.Messagebox.Show(msgErr);
            }


            return dlt;

        }

        public void 读写_最后打开的参数(ushort model, ref string 文件名)
        {
            string path = Environment.CurrentDirectory + "\\gjcfg.dll";
            if (model == 0)
            {
                new ini().Write("文件", "文件名", 文件名, path);
            }
            文件名 = new ini().Read("文件", "文件名", 文件名, path);
        }




        public void 标题栏状态()
        {

            if (gj_sys is null)
            {
                return;
            }

            gj_sys.标题栏状态(this.myForms, "工件模块");

        }


        public bool Err_文件名(string 文件名)
        {

            string path = gj_sys.文件路径(文件名);
            if (string.IsNullOrEmpty(文件名))
            {

                return false;
            }
            else if (!new 文件_文件夹().文件是否存在(path))
            {

                return false;
            }
            return true;
        }
        public bool Err_文件名(string 文件名, out string msgErr)
        {
            msgErr = string.Empty;

            string path = gj_sys.文件路径(文件名);
            if (string.IsNullOrEmpty(文件名))
            {
                msgErr = 语言.读取语言("文件模块，请输入文件名");
                On_Log(false, msgErr);
                return false;
            }
            else if (!new 文件_文件夹().文件是否存在(path))
            {
                msgErr = 语言.读取语言("文件模块，未找到文件");
                On_Log(false, msgErr);
                return false;
            }
            return true;
        }

        public bool Err_未加载文件(out string msgErr)
        {
            msgErr = "";

            if (string.IsNullOrEmpty(Config.文件名))
            {
                msgErr = 语言.读取语言("文件模块，未加载文件信息");
                On_Log(false, msgErr);
                return false;
            }
            return true;
        }





        public Action<bool, string> Action_Log;
        void On_Log(bool state, string logMsg)
        {
            Action_Log?.Invoke(state, logMsg);
        }

        public Action Action_加载文件失败输出报警;
        void On_加载文件失败输出报警()
        {
            Action_加载文件失败输出报警?.Invoke();
        }

        /// <summary>
        /// 返回(bool)是否有错误
        /// <para>传入参数(bool)当前是否有错误</para>
        /// </summary>
        public Func<bool, bool> Action_加载文件;
        bool On_加载文件(bool 是否成功)
        {
            bool rt = true;
            if (Action_加载文件 != null)
            {
                rt = Action_加载文件(是否成功);
            }


            return rt;
        }






    }
}