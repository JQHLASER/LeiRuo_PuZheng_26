using MarkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static myappdll.图像;

namespace myappdll
{
    internal class 计算
    {
        public enum enum递增结果
        {
            None,
            箱递增,
            拖递增,
            箱拖递增,
        }


        public enum enum图像
        {
            读码数量不符,
            重码
        }


        internal class Config
        {
            /// <summary>
            /// 0:无尾料,大于0小于设置每盘的数据为有尾料
            /// </summary>
            internal static int 当前尾料 { set; get; } = 0;



        }

        internal static void 功能栏状态(List<string> lst)
        {
            if (Config.当前尾料 > 0)
            {
                lst.Add($"尾料: {Config.当前尾料}");
            }

        }

        internal static enum递增结果 递增(List<读码器.info_码信息_> lst不为空的码)
        {
            enum递增结果 结果 = enum递增结果.None;

            List<string> lstWork = new List<string>();
            lstWork.Add("递增数量");
            lstWork.Add("递增盘");
            lstWork.Add("递增箱");
            lstWork.Add("递增拖");


            bool rt = true;
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "递增数量")
                {
                    //工件.gj_sys.Config.文件.数量.当前箱个数 += lst码内容.Count;
                    //工件.gj_sys.Config.文件.数量.当前拖个数 += lst码内容.Count;
                    Log.Add(true, $"当前盘个数,{lst不为空的码.Count}");
                }
                else if (s == "递增盘")
                {
                    工件.gj_sys.Config.文件.数量.当前箱盘数 += 1;
                    Log.Add(true, $"递增,当前箱盘数,{工件.gj_sys.Config.文件.数量.当前箱盘数}");
                }
                else if (s == "递增箱")
                {
                    //if (工件.gj_sys.Config.文件.数量.当前箱盘数 >= 工件.gj_sys.Config.文件.数量.每箱盘数)
                    //{
                    //    工件.gj_sys.Config.文件.数量.当前拖箱数 += 1;
                    //    结果 = enum递增结果.箱递增;
                    //}
                    结果 = 箱_判断是否要换();


                }
                else if (s == "递增拖")
                {
                    //if (工件.gj_sys.Config.文件.数量.当前拖箱数 >= 工件.gj_sys.Config.文件.数量.每拖箱数)
                    //{
                    //    结果 = enum递增结果.箱拖递增;
                    //}

                    结果 = 拖_判断是否要换(结果);

                }

            }


            return 结果;
        }

        internal static bool 打印标签(enum递增结果 结果, bool 是否强制弹窗)
        {
            List<string> lstWrok = new List<string>();

            bool 是否询问 = false;
            if (系统类_myApp.Config.参数.使能_打印前弹窗确认 == 1 || 是否强制弹窗)
            {
                是否询问 = true;
            }



            if (结果 == enum递增结果.箱递增 || 结果 == enum递增结果.箱拖递增)
            {
                lstWrok.Add("打印箱标签");
            }

            if (结果 == enum递增结果.箱拖递增 || 结果 == enum递增结果.拖递增)
            {
                lstWrok.Add("打印拖标签");
            }

            打印.Config.工作状态 = 11;
            bool rt = true;
            foreach (string s in lstWrok)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "打印箱标签")
                {
                    if (是否询问)
                    {
                        bool 是否打印 = true;
                        //Form_main.form_Main.Invoke(new Action(() =>
                        //{
                        if (Sunny25.Messagebox.Show(Form_main.form_Main, $"箱码标签\r\n是否确认打印?\r\n箱码: {工件.gj_sys.Config.文件.编码内容.箱码}", "", Sunny25.MessageboxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            是否打印 = false;
                        }
                        // }));

                        if (!是否打印)
                        {
                            continue;
                        }
                    }
                    Log.Add(true, $"打印箱标签,{工件.gj_sys.Config.文件.编码内容.箱码}");
                    mainIndustryqf.BarTender_打印.info_变量_ info = new mainIndustryqf.BarTender_打印.info_变量_();
                    info.Name = "条码";
                    info.Value = 工件.gj_sys.Config.文件.编码内容.箱码;
                    mainIndustryqf.BarTender_打印.info_变量_[] beff = new mainIndustryqf.BarTender_打印.info_变量_[] { info };

                    rt = 打印.打印_btw(工件.gj_sys.Config.文件.打印标签_箱, beff, out string msgErr);

                }
                else if (s == "打印拖标签")
                {
                    if (是否询问)
                    {
                        bool 是否打印 = true;
                        //Form_main.form_Main.Invoke(new Action(() =>
                        //{
                        if (Sunny25.Messagebox.Show(Form_main.form_Main, $"拖码标签\r\n是否确认打印?\r\n拖码: {工件.gj_sys.Config.文件.编码内容.拖码}", "", Sunny25.MessageboxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            是否打印 = false;
                        }
                        // }));

                        if (!是否打印)
                        {
                            continue;
                        }
                    }
                    Log.Add(true, $"打印拖标签,{工件.gj_sys.Config.文件.编码内容.拖码}");

                    mainIndustryqf.BarTender_打印.info_变量_ info = new mainIndustryqf.BarTender_打印.info_变量_();
                    info.Name = "条码";
                    info.Value = 工件.gj_sys.Config.文件.编码内容.拖码;
                    mainIndustryqf.BarTender_打印.info_变量_[] beff = new mainIndustryqf.BarTender_打印.info_变量_[] { info };

                    rt = 打印.打印_btw(工件.gj_sys.Config.文件.打印标签_拖, beff, out string msgErr);
                }
            }
            打印.Config.工作状态 = 0;


            return rt;

        }

        internal static bool 读码内容_防重(List<读码器.info_码信息_> lst不为空的码信息, out List<string> lst重码内容, out string 错误信息)
        {
            错误信息 = "";
            lst重码内容 = new List<string>();
            List<string> lstWork = new List<string>();
            lstWork.Add("读码内容中防重");
            lstWork.Add("数据库中防重");

            bool rt = true;
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "读码内容中防重")
                {
                    rt = 读码器.读码内容防重(lst不为空的码信息, out lst重码内容);
                    if (!rt)
                    {
                        错误信息 = "当前读码内容中有重复码";
                    }
                }
                else if (s == "数据库中防重")
                {
                    rt = dataBase.查询_防重_SN条码(lst不为空的码信息, out List<表.dataZX> lst, out string msgErr);
                    foreach (var item in lst)
                    {
                        lst重码内容.Add(item.SN条码);
                    }

                    if (!rt)
                    {
                        错误信息 = "数据库中有重复码";
                    }
                }

            }

            return rt;
        }

        internal static bool 读码内容_保存到数据库(List<读码器.info_码信息_> lst不为空的码信息, DateTime now)
        {
            List<表.dataZX> lst = new List<表.dataZX>();
            foreach (var s in lst不为空的码信息)
            {


                表.dataZX info = new 表.dataZX();
                info.机台代码 = 工件.gj_sys.Config.文件.机台代码;
                info.机种 = 工件.gj_sys.Config.文件.机种;
                info.SN条码 = s.码内容;
                info.箱条码 = 工件.gj_sys.Config.文件.编码内容.箱码;
                info.拖条码 = 工件.gj_sys.Config.文件.编码内容.拖码;

                info.每盘数量 = 工件.gj_sys.Config.文件.数量.每盘个数;
                info.每箱盘数 = 工件.gj_sys.Config.文件.数量.每箱盘数;
                info.每箱数量 = 工件.gj_sys.Config.文件.数量.每箱盘数 * 工件.gj_sys.Config.文件.数量.每盘个数;
                info.每拖箱数 = 工件.gj_sys.Config.文件.数量.每拖箱数;

                info.时间 = now.ToString("yyyy-MM-dd HH:mm:ss");
                info.备注 = "";

                lst.Add(info);
            }

            return dataBase.添加(lst, out string msgErr);
        }

        internal static bool 读码内容_保存到Csv(List<读码器.info_码信息_> lst不为空的码, DateTime now)
        {
            List<表.dataZX> lst = new List<表.dataZX>();
            foreach (var s in lst不为空的码)
            {


                表.dataZX info = new 表.dataZX();
                info.机台代码 = 工件.gj_sys.Config.文件.机台代码;
                info.机种 = 工件.gj_sys.Config.文件.机种;
                info.SN条码 = s.码内容;
                info.箱条码 = 工件.gj_sys.Config.文件.编码内容.箱码;
                info.拖条码 = 工件.gj_sys.Config.文件.编码内容.拖码;
                info.时间 = now.ToString("yyyy-MM-dd HH:mm:ss");

                info.每盘数量 = 工件.gj_sys.Config.文件.数量.每盘个数;
                info.每箱盘数 = 工件.gj_sys.Config.文件.数量.每箱盘数;
                info.每箱数量 = 工件.gj_sys.Config.文件.数量.每箱盘数 * 工件.gj_sys.Config.文件.数量.每盘个数;
                info.每拖箱数 = 工件.gj_sys.Config.文件.数量.每拖箱数;

                info.备注 = "";

                lst.Add(info);
            }

            return Csv.保存(now, lst);
        }


        internal static bool 工件信息_保存()
        {
            return 工件.gj_sys.保存(out string msgErr);
        }

        internal static bool 生成_编码信息(bool 是否加工, DateTime now)
        {
            bool rt = true;
            List<string> lstWork = new List<string>();
            lstWork.Add("生成箱码");
            lstWork.Add("箱码防重");
            lstWork.Add("生成拖码");
            lstWork.Add("拖码防重");

            bool 生成箱码 = false;
            bool 生成拖码 = false;
            string 箱码 = "";
            string 拖码 = "";
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "生成箱码")
                {
                    if ((工件.gj_sys.Config.文件.数量.当前箱盘数 >= 工件.gj_sys.Config.文件.数量.每箱盘数) ||
                        (工件.gj_sys.Config.文件.数量.当前箱盘数 == 0)
                        || string.IsNullOrEmpty(工件.gj_sys.Config.文件.编码内容.箱码))
                    {
                        rt = 编码.生成箱码(工件.gj_sys.Config.文件名, now, 是否加工, out 箱码);
                        生成箱码 = true;
                    }


                }
                else if (s == "生成拖码")
                {
                    if ((工件.gj_sys.Config.文件.数量.当前拖箱数 >= 工件.gj_sys.Config.文件.数量.每拖箱数) ||
                      (工件.gj_sys.Config.文件.数量.当前拖箱数 == 0 && 工件.gj_sys.Config.文件.数量.当前箱盘数 == 0)
                      || string.IsNullOrEmpty(工件.gj_sys.Config.文件.编码内容.拖码))
                    {
                        rt = 编码.生成拖码(工件.gj_sys.Config.文件名, now, 是否加工, out 拖码);
                        生成拖码 = true;
                    }
                }

                else if (s == "箱码防重")
                {
                    if (生成箱码)
                    {
                        rt = dataBase.查询_防重_箱条码(箱码, out List<表.dataZX> lst, out string msgErr);
                        if (rt)
                        {
                            if (lst.Count == 0)
                            {
                                工件.gj_sys.Config.文件.编码内容.箱码 = 箱码;
                                工件.gj_sys.Config.文件.编码内容.最后一次换箱时间 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                Log.Add(true, $"生成箱码,{工件.gj_sys.Config.文件.编码内容.箱码}");
                            }
                            else
                            {
                                rt = false;
                                Log.Add(rt, $"生成箱码失败,箱码重码,{工件.gj_sys.Config.文件.编码内容.箱码}");
                            }
                        }
                        else
                        {
                            Log.Add(rt, $"生成箱码失败,箱码防重,{msgErr}");
                        }
                    }
                }

                else if (s == "拖码防重")
                {
                    if (生成拖码)
                    {
                        rt = dataBase.查询_防重_拖条码(拖码, out List<表.dataZX> lst, out string msgErr);
                        if (rt)
                        {
                            if (lst.Count == 0)
                            {
                                工件.gj_sys.Config.文件.编码内容.拖码 = 拖码;
                                工件.gj_sys.Config.文件.编码内容.最后一次换拖时间 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                Log.Add(true, $"生成拖码,{工件.gj_sys.Config.文件.编码内容.拖码}");
                            }
                            else
                            {
                                rt = false;
                                Log.Add(rt, $"生成拖码失败,拖码重码,{工件.gj_sys.Config.文件.编码内容.箱码}");
                            }
                        }
                        else
                        {
                            Log.Add(rt, $"生成拖码失败,拖码防重,{msgErr}");
                        }
                    }
                }
            }






            return rt;
        }

        static void 初始化原始码(out List<读码器.info_码信息_> lst原始码)
        {
            lst原始码 = new List<读码器.info_码信息_>();
            for (int i = 0; i < 工件.gj_sys.Config.文件.数量.每盘个数; i++)
            {
                读码器.info_码信息_ info = new 读码器.info_码信息_();
                info.索引 = i;
                info.码内容 = "";
                lst原始码.Add(info);
            }
        }

        internal static bool 读码器_读码(out List<读码器.info_码信息_> lst原始码, out List<读码器.info_码信息_> lst不为空的码)
        {
            lst原始码 = new List<读码器.info_码信息_>();
            lst不为空的码 = new List<读码器.info_码信息_>();

            List<string> lstWork = new List<string>();
            lstWork.Add("读码");
            lstWork.Add("解析");

            bool rt = true;
            List<string> lst读出码内容 = new List<string>();
            foreach (string s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "读码")
                {
                    if (!系统类_myApp.Config.参数.使能_手持扫码枪)
                    {
                        rt = 读码器.读码(out lst原始码, out lst不为空的码, out string msgErr);
                    }
                    else
                    {
                        lst原始码.Clear();
                        lst不为空的码.Clear();
                        for (global::System.Int32 i = 0; i < 手持扫码枪._读码内容.Count; i++)
                        { 
                            lst原始码.Add(new 读码器.info_码信息_
                            {
                                索引 = i,
                                码内容 = 手持扫码枪._读码内容[i]
                            });
                            lst不为空的码.Add(new 读码器.info_码信息_
                            {
                                索引 = i,
                                码内容 = 手持扫码枪._读码内容[i]
                            });
                        }
                    }
                }
                else if (s == "解析")
                {

                    if (!rt && lst读出码内容.Count != 工件.gj_sys.Config.文件.数量.每盘个数)
                    {
                        if (Config.当前尾料 > 0)
                        {
                            rt = true;
                            Log.Add(rt, $"尾料,{lst读出码内容.Count}");
                        }
                        else
                        {
                            Log.Add(rt, $"读出码数量与设置的每盘数量不一致,{lst读出码内容.Count}");
                        }
                    }
                }

            }

            if (!rt || lst原始码.Count == 0)
            {
                初始化原始码(out lst原始码);
            }


            return rt;
        }

        internal static bool 读码器_是否尾料(List<读码器.info_码信息_> lst不为空的原始码)
        {
            bool rt = true;
            string msgErr = string.Empty;
            int a = 工件.gj_sys.Config.文件.数量.每盘个数;

            if (Config.当前尾料 > 0)
            {
                if (Config.当前尾料 < lst不为空的原始码.Count)
                {
                    msgErr = $"尾料,{Config.当前尾料}<{lst不为空的原始码.Count}>";
                }
                else if (lst不为空的原始码.Count > Config.当前尾料)
                {

                    msgErr = $"读码数量大于设置的尾数,已被设置为尾料,{Config.当前尾料}<{lst不为空的原始码.Count}>";
                }
                Log.Add(rt, msgErr);
            }
            else
            {
                if (lst不为空的原始码.Count != 工件.gj_sys.Config.文件.数量.每盘个数)
                {
                    rt = false;
                    msgErr = $"读码数量与设置的每盘个数不匹配,非尾料,{a}<{lst不为空的原始码.Count}>";
                    Log.Add(rt, msgErr);
                }
            }





            Config.当前尾料 = 0;
            return rt;
        }
        internal static bool 判断_读出码数量大于每盘个数(List<读码器.info_码信息_> lst不为空的原始码, int 每盘个数, out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;

            if (lst不为空的原始码.Count > 每盘个数)
            {
                rt = false;
                if (Config.当前尾料 == 0)
                {
                    msgErr = $"读码数量大于设置的每盘个数,{lst不为空的原始码.Count}/{每盘个数}";
                }
                else
                {
                    msgErr = $"读码数量大于设置的尾料个数,{lst不为空的原始码.Count}/{每盘个数}";
                }
                Log.Add(rt, msgErr);
            }

            return rt;
        }

        internal static void 查看_读码器图像_读码数量不符(List<读码器.info_码信息_> lst原始码, string 错误信息)
        {
            图像.info_绘制信息_[] MainDraw = new info_绘制信息_[0];
            解析_图像_未读出码或数量不符(lst原始码, out MainDraw);

            Form_main.form_Main.Invoke(new Action(() => { new Form_图像标注_显示(工件.gj_sys.Config.文件.读码图像名称, MainDraw, 错误信息).ShowDialog(Form_main.form_Main); }));

        }
        internal static void 查看_读码器图像_重码(List<读码器.info_码信息_> lst不为空的原始码, List<string> lst重码, string 错误信息)
        {
            图像.info_绘制信息_[] MainDraw = new info_绘制信息_[0];
            解析_图像_重码(lst不为空的原始码, lst重码, out MainDraw);

            Form_main.form_Main.Invoke(new Action(() =>
            {
                new Form_图像标注_显示(工件.gj_sys.Config.文件.读码图像名称, MainDraw, 错误信息).ShowDialog(Form_main.form_Main);
            }));

        }

        static void 查看_读码器图像_混料(List<读码器.info_码信息_> lst不为空的原始码, List<string> lst混料码, string 错误信息)
        {
            图像.info_绘制信息_[] MainDraw = new info_绘制信息_[0];
            解析_图像_重码(lst不为空的原始码, lst混料码, out MainDraw);

            Form_main.form_Main.Invoke(new Action(() =>
            {
                new Form_图像标注_显示(工件.gj_sys.Config.文件.读码图像名称, MainDraw, 错误信息).ShowDialog(Form_main.form_Main);
            }));

        }

        static void 查看_读码器图像_点检样件(List<读码器.info_码信息_> lst不为空的原始码, List<string> lst混料码, string 错误信息)
        {
            图像.info_绘制信息_[] MainDraw = new info_绘制信息_[0];
            解析_图像_重码(lst不为空的原始码, lst混料码, out MainDraw);

            Form_main.form_Main.Invoke(new Action(() =>
            {
                new Form_图像标注_显示(工件.gj_sys.Config.文件.读码图像名称, MainDraw, 错误信息).ShowDialog(Form_main.form_Main);
            }));

        }

        static void 解析_图像_重码(List<读码器.info_码信息_> lst原始码, List<string> lst重码, out 图像.info_绘制信息_[] info图像)
        {
            List<图像.info_绘制信息_> lst_Draw = new List<info_绘制信息_>();
            for (int i = 0; i < lst原始码.Count; i++)
            {
                读码器.info_码信息_ s = lst原始码[i];
                图像.info_绘制信息_ info_Draw = 工件.gj_sys.Config.文件.图像标注参数[i];
                if (!string.IsNullOrEmpty(s.码内容) && lst重码.IndexOf(s.码内容) > -1)
                {
                    info_Draw.文本内容 = (i + 1).ToString();
                    lst_Draw.Add(info_Draw);
                }

            }
            info图像 = lst_Draw.ToArray();

        }

        static void 解析_图像_未读出码或数量不符(List<读码器.info_码信息_> lst原始码, out 图像.info_绘制信息_[] info图像)
        {
            List<图像.info_绘制信息_> lst_Draw = new List<info_绘制信息_>();
            for (int i = 0; i < 工件.gj_sys.Config.文件.数量.每盘个数; i++)
            {
                try
                {
                    读码器.info_码信息_ s = lst原始码[i];
                    图像.info_绘制信息_ info_Draw = 工件.gj_sys.Config.文件.图像标注参数[i];

                    if (string.IsNullOrEmpty(s.码内容))
                    {
                        info_Draw.文本内容 = (i + 1).ToString();
                        lst_Draw.Add(info_Draw);
                    }
                }
                catch (Exception)
                {
                }
            }
            info图像 = lst_Draw.ToArray();

        }

        internal static bool 混料检测(List<读码器.info_码信息_> lst不为空的码, out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            List<string> lst混料码 = new List<string>();
            //二维码/第4/5/6位三位是否为SN校验值
            foreach (var sM in lst不为空的码)
            {
                string Vcode = new mainclassqf.文本().获取(sM.码内容.Trim(), 3, 3);//第4/5/6位
                if (Vcode != 工件.gj_sys.Config.文件.SN码校验)
                {
                    msgErr = $"混料检测,NG,系统检测到混料,<机台代码: {工件.gj_sys.Config.文件.SN码校验}><{Vcode}><{sM.码内容}>";
                    rt = false;
                    Log.Add(rt, msgErr);
                    lst混料码.Add(sM.码内容);
                }
                else
                {
                    msgErr = $"混料检测,OK,<机台代码: {工件.gj_sys.Config.文件.SN码校验}><{Vcode}><{sM.码内容}>";
                    Log.Add(true, msgErr);
                }
            }

            if (!rt && lst混料码.Count > 0)
            {
                查看_读码器图像_混料(lst不为空的码, lst混料码, "混料");
            }
            return rt;
        }

        /// <summary>
        /// 防止点检样品混入
        /// </summary>
        /// <param name="lst不为空的码"></param>
        /// <param name="msgErr"></param>
        /// <returns></returns>
        internal static bool 点检样品(List<读码器.info_码信息_> lst不为空的码, out string msgErr)
        {
            bool rt = true;
            msgErr = string.Empty;
            List<string> lst点检码 = new List<string>();

            List<string> lst = 点检样件.Config.点检数据.ToList();

            ///二维码量后面三位是否为机台代码
            foreach (var sM in lst不为空的码)
            {
                if (lst.IndexOf(sM.码内容) > -1)
                {
                    rt = false;
                    msgErr = $"NG,系统检测到点检样件,<{sM.码内容}>";
                    Log.Add(rt, msgErr);
                    lst点检码.Add(sM.码内容);
                }
            }

            if (!rt && lst点检码.Count > 0)
            {
                查看_读码器图像_点检样件(lst不为空的码, lst点检码, "点检样件");
            }
            return rt;
        }


        internal static async Task 强制换箱()
        {
            if (!工件.gj_sys.Err_未加载文件(out string msgErr) || !Err.系统报警(申明.myForm25_sys, out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }
            else if (Sunny25.Messagebox.Show("是否确认强制换箱?\r\n此操作不可逆", "", Sunny25.MessageboxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            //编码.生成箱码(工件.gj_sys.Config.文件名, DateTime.Now, true, out string 箱码);
            //工件.gj_sys.Config.文件.编码内容.箱码 = 箱码;
            Log.Add(true, $"强制换箱,用户: {用户_.user_sys.Config.当前登陆的用户信息.用户}");

            工件.gj_sys.Config.文件.数量.当前箱盘数 = 0;
            工件.gj_sys.Config.文件.数量.当前拖箱数 += 1;

            enum递增结果 结果 = enum递增结果.箱递增;

            工件.gj_sys.Config.文件.编码内容.箱码 = "";
            结果 = 拖_判断是否要换(结果);

            工件.gj_sys.保存(out msgErr);

            if (结果 != enum递增结果.None)
            {


                bool rt = true;
                await Task.Run(() =>
                {
                    rt = 打印标签(结果, true);
                });

                string show = rt ? "换箱成功 " : "换箱成功,打印失败";
                Sunny25.MessageboxStatus status = rt ? Sunny25.MessageboxStatus.None : Sunny25.MessageboxStatus.Red;
                Sunny25.Messagebox.Show(show, "", status);

            }



        }

        internal static async Task 强制换拖()
        {
            if (!工件.gj_sys.Err_未加载文件(out string msgErr) || !Err.系统报警(申明.myForm25_sys, out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }
            else if (Sunny25.Messagebox.Show("是否确认强制换拖?\r\n此操作不可逆", "", Sunny25.MessageboxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            //DateTime now= DateTime.Now;
            //编码.生成箱码(工件.gj_sys.Config.文件名, now, true,out string 箱码);
            //工件.gj_sys.Config.文件.编码内容.箱码 = 箱码;
            //编码.生成拖码(工件.gj_sys.Config.文件名, now, true, out string 拖码);
            //工件.gj_sys.Config.文件.编码内容.拖码 = 拖码;


            Log.Add(true, $"强制换拖,用户: {用户_.user_sys.Config.当前登陆的用户信息.用户}");

            enum递增结果 结果 = enum递增结果.拖递增;
            if (工件.gj_sys.Config.文件.数量.当前箱盘数 > 0)
            {
                工件.gj_sys.Config.文件.数量.当前箱盘数 = 0;
                工件.gj_sys.Config.文件.编码内容.箱码 = "";
                结果 = enum递增结果.箱拖递增;
            }
            工件.gj_sys.Config.文件.编码内容.拖码 = "";
            工件.gj_sys.Config.文件.数量.当前拖箱数 = 0;
            工件.gj_sys.保存(out msgErr);


            if (结果 != enum递增结果.None)
            {
                bool rt = true;
                await Task.Run(() =>
                   {
                       rt = 打印标签(结果, true);

                   });

                string show = rt ? "换拖成功" : "换拖成功,打印失败";
                Sunny25.MessageboxStatus status = rt ? Sunny25.MessageboxStatus.None : Sunny25.MessageboxStatus.Red;
                Sunny25.Messagebox.Show(show, "", status);

            }

        }


        static enum递增结果 箱_判断是否要换()
        {
            enum递增结果 结果 = enum递增结果.None;
            if (工件.gj_sys.Config.文件.数量.当前箱盘数 >= 工件.gj_sys.Config.文件.数量.每箱盘数)
            {
                工件.gj_sys.Config.文件.数量.当前拖箱数 += 1;
                结果 = enum递增结果.箱递增;
            }
            Log.Add(true, $"递增,当前拖箱数,{工件.gj_sys.Config.文件.数量.当前拖箱数}");
            return 结果;
        }

        static enum递增结果 拖_判断是否要换(enum递增结果 结果)
        {
            if (工件.gj_sys.Config.文件.数量.当前拖箱数 >= 工件.gj_sys.Config.文件.数量.每拖箱数)
            {
                结果 = enum递增结果.箱拖递增;
            }
            return 结果;
        }

    }
}
