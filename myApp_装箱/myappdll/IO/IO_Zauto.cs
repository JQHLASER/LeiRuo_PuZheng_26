using mainclassSoft;
using mainIndustryqf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace myappdll
{
    class IO_Zauto
    {
        internal static Zaxis_2024 zauto_sys = new Zaxis_2024();


        internal static void 窗体标题()
        {
            zauto_sys.标题栏状态(申明.myForm25_sys);

            int a = 0;
            if (IO_Value._OutPut_.三色灯_红灯)
            {
                a = -1;
            }
            List<string[]> lst = new List<string[]>();
            lst.Add(new string[] { "-1", "三色灯红色报警" });
            申明.myForm25_sys.标题栏显状态_添加显示(a, lst);
        }

        internal static void 初始化()
        {
            zauto_sys.Action_输入 += On_输入;
            zauto_sys.Action_输出 += On_输出;

            zauto_sys.Action_输入_b += On_输入b;
            zauto_sys.Action_输出_b += On_输出b;

            zauto_sys.ZAuto_sys.Config.连接参数.通讯方式 = Z运动_封装.enmu连接方式.串口;
            zauto_sys.初始化();

        }
        internal static void 释放()
        {

            zauto_sys.Action_输入 -= On_输入;
            zauto_sys.Action_输出 -= On_输出;

            zauto_sys.Action_输入_b -= On_输入b;
            zauto_sys.Action_输出_b -= On_输出b;

            zauto_sys.释放();
        }

        static void On_输入(byte[] status)
        {

        }

        static void On_输出(byte[] status)
        {

        }
        static void On_输入b(bool[] status)
        {
            bool 启动 = status[IO_Address._InPut_.启动];
            bool 复位 = status[IO_Address._InPut_.复位];


            Form_main.form_Main.Invoke(new Action(() =>
            {
                Form_main.form_Main.uI_Led25_启动.状态 = 启动 ? Sunny25.UI_Led25.enum状态.On1 : Sunny25.UI_Led25.enum状态.Off;
                Form_main.form_Main.uI_Led25_复位.状态 = 复位 ? Sunny25.UI_Led25.enum状态.On1 : Sunny25.UI_Led25.enum状态.Off;


            }));


            if (启动 && !IO_Value._InPut_.启动)
            {
                if (!系统类_myApp.Config.参数.使能_手持扫码枪)
                {

                    if (工作.Config.工作状态 == 0 && 申明.myForm25_sys.系统闲置状态())
                    {
                        if (用户_.user_sys.Config.当前登陆的用户信息.权限 == 用户.enum权限.操作员 ||
                            用户_.user_sys.Config.当前登陆的用户信息.权限 == 用户.enum权限.开发者)
                        {
                            Log.Clear();
                            Log.Add(true, $"IO,启动触发....", Log.enumLogState.All);
                            加工.启动加工();
                        }
                        else
                        {
                            Log.Add(false, $"IO,启动触发,请切换到操作员权限用户", Log.enumLogState.All);
                        }

                    }
                    else if (工作.Config.工作状态 == 10)
                    {
                        Log.Add(false, $"IO,启动触发....系统工作中");
                    }
                    else if (工作.Config.工作状态 == 11 || 申明.myForm25_sys.系统报警状态())
                    {
                        Log.Add(false, $"IO,启动触发....系统报警中");
                    }
                }
                else
                {
                    Log.Add(false, $"IO,启动触发....手持扫码枪模式,触发无效");
                }
            }

            if (复位 && !IO_Value._InPut_.复位)
            {
                Log.Add(true, $"IO触发,复位");
                if (IO_Value._OutPut_.三色灯_红灯)
                {
                    IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, false);
                }
            }

            IO_Value._InPut_.启动 = 启动;
            IO_Value._InPut_.复位 = 复位;
        }

        static void On_输出b(bool[] status)
        {
            bool 红灯 = status[IO_Address._OutPut_.三色灯_红灯];
            bool 绿灯 = status[IO_Address._OutPut_.三色灯_绿灯];
            bool 黄灯 = status[IO_Address._OutPut_.三色灯_黄灯];



            Form_main.form_Main.Invoke(new Action(() =>
            {
                Form_main.form_Main.三色灯_三色灯.状态_红灯 = 红灯;
                Form_main.form_Main.三色灯_三色灯.状态_绿灯 = 绿灯;
                Form_main.form_Main.三色灯_三色灯.状态_黄灯 = 黄灯;

            }));

            IO_Value._OutPut_.三色灯_红灯 = 红灯;
            IO_Value._OutPut_.三色灯_绿灯 = 绿灯;
            IO_Value._OutPut_.三色灯_黄灯 = 黄灯;
        }



        public enum enum三色灯
        {
            黄灯,
            绿灯,
            红灯,
        }
        internal static void Out_三色灯(enum三色灯 name, bool 状态)
        {
            int a = IO_Address._OutPut_.三色灯_黄灯;
            switch (name)
            {
                case enum三色灯.黄灯:
                    a = IO_Address._OutPut_.三色灯_黄灯;
                    break;
                case enum三色灯.绿灯:
                    a = IO_Address._OutPut_.三色灯_绿灯;
                    break;
                case enum三色灯.红灯:
                    a = IO_Address._OutPut_.三色灯_红灯;
                    break;
            }
            bool rt = zauto_sys.IO_输出_设置输出(a, 状态, out string msgErr);
            if (!rt)
            {
                string state = 状态 ? "On" : "Off";
                Log.Add(rt, $"IO,三色灯操作失败,{a},{state},{msgErr}");
            }
        }




    }
}
