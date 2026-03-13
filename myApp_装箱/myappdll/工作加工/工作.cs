using mainclassqf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 工作 : mainclassSoft.工作
    {
        internal static void 工作流程_备份()
        {
            if (!Err_编辑中(out string msgErr) || !Err.工作中(out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {

                return;
            }

            DateTime dates = DateTime.Now;
            bool rt = true;
            工作_事件_.On_加工(true, rt, dates);



            List<string> lstWork = new List<string>();
            lstWork.Add("Err");


            Config.工作停止 = 0;
            foreach (var item in lstWork)
            {
                if (!rt || Config.工作停止 == -1)
                {
                    rt = false;
                    break;
                }
                else if (item == "Err")
                {
                    // Log.Add_Work(true, $"");
                }


            }
            工作_事件_.On_加工(false, rt, dates);

        }


        internal static void 工作流程()
        {
            if (!Err.系统报警(申明.myForm25_sys, out string msgErr))
            {
                显示.加工条(Sunny25.LED_显示条.enum状态.Red, $"系统报警");
                Log.Add(false, msgErr, Log.enumLogState.Work);
                return;
            }
            else if (!Err_编辑中(out msgErr) || !Err.工作中(out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                return;
            }
            else if (系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                Log.Add(true, $"扫码: {string.Join(",", 手持扫码枪._读码内容)}");
            }
            DateTime dates = DateTime.Now;
            bool rt = true;
            工作_事件_.On_加工(true, rt, dates);

            List<string> lstWork = new List<string>();
            lstWork.Add("Err");
            lstWork.Add("计数复位计算");

            lstWork.Add("读码");
            lstWork.Add("点检样件");
            lstWork.Add("判断_读出码数量大于每盘个数");
            lstWork.Add("码数量判断,是否尾料");
            lstWork.Add("混料检查");

            lstWork.Add("防重");
            lstWork.Add("生成编码");

            lstWork.Add("mes交互");

            lstWork.Add("保存到数据库");
            lstWork.Add("保存CSV");
            lstWork.Add("递增");
            lstWork.Add("保存工件信息");
            lstWork.Add("打印标签");

            计算.enum递增结果 递增结果 = 计算.enum递增结果.None;
            List<读码器.info_码信息_> lst原始码 = new List<读码器.info_码信息_>();
            List<读码器.info_码信息_> lst不为空的码 = new List<读码器.info_码信息_>();


            List<string> lst重码内容 = new List<string>();
            Config.工作停止 = 0;
            foreach (var item in lstWork)
            {
                if (!rt || Config.工作停止 == -1)
                {
                    rt = false;
                    break;
                }
                else if (item == "Err")
                {
                    if (!工件.gj_sys.Err_未加载文件(out msgErr) || !工件.Err_图像标注数量与设置的每盘个数不一致(out msgErr) || !工件.Err_未设置模板图像(out msgErr))
                    {
                        rt = false;
                    }


                }
                else if (item == "计数复位计算")
                {
                    if (工件.gj_sys.Config.文件.数量.当前箱盘数 >= 工件.gj_sys.Config.文件.数量.每箱盘数)
                    {
                        工件.gj_sys.Config.文件.数量.当前箱盘数 = 0;
                    }

                    if (工件.gj_sys.Config.文件.数量.当前拖箱数 >= 工件.gj_sys.Config.文件.数量.每拖箱数)
                    {
                        工件.gj_sys.Config.文件.数量.当前拖箱数 = 0;
                    }

                }
                else if (item == "读码")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "读码器读码...");
                    rt = 计算.读码器_读码(out lst原始码, out lst不为空的码);
                    if (!rt)
                    {
                        IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                        计算.查看_读码器图像_读码数量不符(lst原始码, $"未读出码或未达到设置的数量");
                    }

                }
                else if (item == "点检样件")
                {

                    //防止点检样品混入
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "点检样件检测");
                    rt = 计算.点检样品(lst原始码, out msgErr);

                }
                else if (item == "判断_读出码数量大于每盘个数")
                {
                    int a = 工件.gj_sys.Config.文件.数量.每盘个数;
                    if (计算.Config.当前尾料 > 0)
                    {
                        a = 计算.Config.当前尾料;
                        Log.Add(true, $"尾料,{计算.Config.当前尾料}");
                    }
                    rt = 计算.判断_读出码数量大于每盘个数(lst不为空的码, a, out msgErr);
                }
                else if (item == "码数量判断,是否尾料")
                {
                    rt = 计算.读码器_是否尾料(lst不为空的码);
                    if (!rt)
                    {
                        IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                        计算.查看_读码器图像_读码数量不符(lst原始码, $"未读出码或未达到设置的数量");
                    }

                }
                else if (item == "混料检查")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "混料检测");
                    //二维码/第4/5/6位三位是否为SN校验值
                    rt = 计算.混料检测(lst不为空的码, out msgErr);
                }
                else if (item == "防重")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "防重...");
                    rt = 计算.读码内容_防重(lst不为空的码, out lst重码内容, out string 错误信息);
                    if (!rt)
                    {
                        IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                        计算.查看_读码器图像_重码(lst原始码, lst重码内容, 错误信息);
                    }
                }
                else if (item == "生成编码")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "生成编码...");
                    rt = 计算.生成_编码信息(true, dates);

                    if (string.IsNullOrEmpty(工件.gj_sys.Config.文件.编码内容.箱码))
                    {
                        rt = false;
                        Log.Add(rt, $"生成编码,箱码不能为空");
                    }
                    if (string.IsNullOrEmpty(工件.gj_sys.Config.文件.编码内容.拖码))
                    {
                        rt = false;
                        Log.Add(rt, $"生成编码,拖码不能为空");
                    }
                }
                else if (item == "保存到数据库")
                {

                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "保存到数据库...");
                    rt = 计算.读码内容_保存到数据库(lst不为空的码, dates);
                }
                else if (item == "递增")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "数量递增...");
                    递增结果 = 计算.递增(lst不为空的码);
                }
                else if (item == "保存工件信息")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "保存工件信息...");
                    rt = 计算.工件信息_保存();
                }
                else if (item == "保存CSV")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "保存到CSV...");
                    rt = 计算.读码内容_保存到Csv(lst不为空的码, dates);
                }
                else if (item == "打印标签")
                {
                    显示.加工条(Sunny25.LED_显示条.enum状态.Yello, "打印标签...");
                    rt = 计算.打印标签(递增结果, false);
                }
                else if (item == "mes交互")
                {
                    if (!系统类_myApp.Config.参数.使能_Mes)
                    {
                        continue;
                    }

                    string[] sn = lst不为空的码.Select(u => u.码内容).ToArray();
                    var rtMes = mes.上传(new mes_数据结构._上传_
                    {
                        datetime = dates.ToString("yyyy-MM-dd HH:mm:ss"),
                        lineNm = 系统类_myApp.Config.参数.设备编号,
                        data = new mes_数据结构._data_[]
                        {
                            new mes_数据结构._data_
                            {
                                Nds =工件.gj_sys.Config.文件.机种 ,
                                codeBox=工件.gj_sys.Config.文件.编码内容.箱码,
                                codeDrop =工件.gj_sys.Config.文件.编码内容.拖码,
                                sn =sn,
                            }
                        },
                    });
                    rt = rtMes.s;
                    Log.Add(rt, rtMes.m);
                    if (!rt)
                    {
                        Form_main.form_Main.Invoke((Action)(() =>
                        {
                            Sunny25.Messagebox.Show(Form_main.form_Main, rtMes.m, "Err", Sunny25.MessageboxButtons.OK, Sunny25.MessageboxStatus.Red);
                        }));
                    }
                }
            }

            if (系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                手持扫码枪._读码内容.Clear();
            }

            if (rt)
            {
                显示.加工条(Sunny25.LED_显示条.enum状态.Green, "OK,加工结束");
            }
            else
            {
                显示.加工条(Sunny25.LED_显示条.enum状态.Red, "NG,加工结束");
            }

            工作_事件_.On_加工(false, rt, dates);

        }

        internal static bool 加载工件(bool 当前加载状态)
        {
            string msgErr = string.Empty;
            bool rt = 当前加载状态;
            List<string> lstWork = new List<string>();
            lstWork.Add("加载测试箱编码");
            lstWork.Add("加载测试拖编码");
            lstWork.Add("加载测试箱打印标签");
            lstWork.Add("加载测试箱拖打印标签");

            lstWork.Add("判断是否设置标注图像名称");
            lstWork.Add("判断设置的标注数量");

            Config.工作状态 = 10;
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "加载测试箱编码")
                {
                    string name = 编码.生成箱码文件名(工件.gj_sys.Config.文件名);
                    rt = 编码.Encode_sys.打开(name);
                }
                else if (s == "加载测试拖编码")
                {
                    string name = 编码.生成拖码文件名(工件.gj_sys.Config.文件名);
                    rt = 编码.Encode_sys.打开(name);
                }
                else if (s == "加载测试箱打印标签")
                {
                    //打印.Config.工作状态 = 10;
                    //rt = 打印.打开_btw(工件.gj_sys.Config.文件.打印标签_箱, out msgErr);
                    //打印.Config.工作状态 = 0;
                    if (!new mainclassqf.文件_文件夹().文件是否存在(打印.生成路径(工件.gj_sys.Config.文件.打印标签_箱)))
                    {
                        rt = false;
                        msgErr = $"未找到箱打印标签,{工件.gj_sys.Config.文件.打印标签_箱}";
                        Log.Add(rt, msgErr);
                    }


                }
                else if (s == "加载测试箱拖打印标签")
                {
                    //打印.Config.工作状态 = 10;
                    //rt = 打印.打开_btw(工件.gj_sys.Config.文件.打印标签_拖, out msgErr);
                    //打印.Config.工作状态 = 0;

                    if (!new mainclassqf.文件_文件夹().文件是否存在(打印.生成路径(工件.gj_sys.Config.文件.打印标签_拖)))
                    {
                        rt = false;
                        msgErr = $"未找到拖打印标签,{工件.gj_sys.Config.文件.打印标签_拖}";
                        Log.Add(rt, msgErr);
                    }


                }
                else if (s == "判断设置的标注数量")
                {
                    rt = 工件.Err_图像标注数量与设置的每盘个数不一致(out msgErr);

                }
                else if (s == "判断是否设置标注图像名称")
                {
                    rt = 工件.Err_未设置模板图像(out msgErr);
                }
            }

            if (!rt)
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
            }


            Config.工作状态 = 0;

            return rt;
        }

        internal static bool Err_编辑中(out string msgErr)
        {
            bool rt = true;
            msgErr = "";
            if (Config.工作状态 == 12)
            {
                msgErr = "系统编辑中";
                rt = false;
                Log.Add(rt, msgErr);
            }

            return rt;
        }





    }
}
