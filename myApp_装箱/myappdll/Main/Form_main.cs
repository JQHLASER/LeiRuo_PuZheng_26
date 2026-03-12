using mainclassqf;
using mainclassSoft;
using myappdll.定制;
using Sunny25.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    public partial class Form_main : Sunny25.UIForm
    {
        internal static Form_main form_Main;




        /**************************************************************************************************/
        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case mainclassSoft.WndProc.Win32.WM_DEVICECHANGE: DogTW_2024.监测狗是否被拔出来_OnDeviceChange(ref m); break;
            }


            //调用基类的同名方法
            base.WndProc(ref m);
        }



        /**************************************************************************************************/
        public Form_main()
        {
            InitializeComponent();
            form_Main = this;

            this.系统设置ToolStripMenuItem.Click += (s, e) =>
            {
                if (用户_ .user_sys .Config .当前登陆的用户信息 .权限 >=用户.enum权限.技术员 )
                {
                    MessageBox.Show("用户权限低", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (Form_系统参数 forms = new Form_系统参数())
                {
                    Log.Add(true, $"手动,进入系统设置窗体....");
                    forms.ShowDialog();
                    Log.Add(true, $"手动,关闭系统设置窗体");
                }
            };
            this.uiButton_清空读码.Click += (s, e) =>
            {
                if (MessageBox .Show ("是否清空手持扫码枪读码内容?", "",MessageBoxButtons.YesNo )==DialogResult.No )
                {
                    return;
                }
                手持扫码枪._读码内容.Clear();
                Log.Add(true, $"手动,清空手持扫码检读码内容");  
            }; 
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            DogTW_2024.监测狗是否被拔出来_form_RegisterDeviceNotification(this.Handle);
            功能.设置();
            页面设置_main.初始化();
            myApp_Main.进入主窗体();


            用户_.进入窗体();

            //处理需要初始化的程序
            系统事件.进入程序();

            Task.Run(() => { 编码.初始化(); });

            显示.加工条(Sunny25.LED_显示条.enum状态.None默认, "");

            系统类_myApp.Initiall(1);
            打印.初始化();
            Csv.初始化();
            点检样件.Cfg(1);


        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {

            #region 弹窗确认关闭系统?

            bool 是否关闭 = true;
            Sunny25.MessageBoxSize size = new Sunny25.MessageBoxSize();
            size.x = 600; size.y = 400;

            if (!Err.工作中(out string msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                是否关闭 = false;
                Sunny25.Messagebox.Show(msgErr, $"{语言.读取语言("关闭系统")}", size);
            }
            else if (Sunny25.Messagebox.Show(Language.读取语言("关闭系统?"), "", Sunny25.MessageboxButtons.YesNo, size) == DialogResult.No)
            {
                是否关闭 = false;
            }


            if (!是否关闭)
            {
                e.Cancel = true;
                return;
            }


            #endregion


            系统事件.关闭程序();
            myApp_Main.关闭主窗体();
            new mainclassqf.延时().Sleep_My(500);
            Log.释放();

            new mainclassqf.进程().结束自身进程_暴力();
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            申明.myForm25_sys.软件注册_sys.窗体_软件注册();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                页面设置_main.初始化();
            }

        }

        private void Form_main_Shown(object sender, EventArgs e)
        {

        }

        private void Form_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.uI_软件信息1.显示信息_弹窗();
            }
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户_.user_sys.窗体_用户管理();
        }

        private void 切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户_.用户切换();
        }

        private void 零件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            生产计数.js_sys.窗口_设置();
        }

        private void 计数清零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sunny25.Messagebox.Show(Language.读取语言("清零良品和不良品计数?"), "", Sunny25.MessageboxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            生产计数.js_sys.计数清零(true, true);

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            生产计数.js_sys.窗口_设置();
        }

        private void 语言ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            语言.窗体_设置();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Err.工作中(out string msgErr) || !Err.系统报警(申明.myForm25_sys, out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                return;
            }
            工作.Config.工作状态 = 12;
            工件.gj_sys.窗体_编辑();
            工作.Config.工作状态 = 0;
        }

        async Task 打开工件()
        {
            await Task.Run(() => { 工件.gj_sys.打开(); });
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Err.工作中(out string msgErr) || !Err.系统报警(申明.myForm25_sys, out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                return;
            }

            打开工件();
        }

        private void 读码器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() => { 读码器.读码(out List<读码器.info_码信息_> value, out List<读码器.info_码信息_> valueNotNull, out string msgErr); });
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!打印.Err_工作中(out string msgErr) || !工件.gj_sys.Err_未加载文件(out msgErr))
            {
                return;
            }

            Log.Add(true, $"打印机,打印测试...");
            Task.Run(() =>
            {
                计算.打印标签(计算.enum递增结果.箱拖递增, true);
            });


        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.窗体_查询();
        }

        private void 加工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Clear();
            Log.Add(true, $"加工,手动启动...", Log.enumLogState.All);
            加工.启动加工();
        }

        private void uiButton_复位_Click(object sender, EventArgs e)
        {
            if (IO_Value._OutPut_.三色灯_红灯)
            {
                Log.Add(true, $"手动点击,复位");
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, false);
            }
        }

        private void 图像标注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_图像标注_显示(工件.gj_sys.Config.文件.读码图像名称, 工件.gj_sys.Config.文件.图像标注参数.ToArray(), "测试").ShowDialog(this);
        }

        private void uiButton_换拖_Click(object sender, EventArgs e)
        {
            计算.强制换拖();
        }

        private void uiButton_换箱_Click(object sender, EventArgs e)
        {
            计算.强制换箱();
        }

        private void uiButton_尾料_Click(object sender, EventArgs e)
        {
            if (!工件.gj_sys.Err_未加载文件(out string msgErr) || !Err.系统报警(申明.myForm25_sys, out msgErr) || !Err.系统忙(申明.myForm25_sys, out msgErr))
            {
                Sunny25.Messagebox.Show(msgErr, "", Sunny25.MessageboxStatus.Red);
                return;
            }

            DialogResult dlt = new Form_尾料().ShowDialog();
            if (dlt == DialogResult.OK)
            {
                Log.Add(true, $"设置尾料 : {计算.Config.当前尾料},用户: {用户_.user_sys.Config.当前登陆的用户信息.用户}");
            }



        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            系统类_myApp.Initiall(1);
            读码器.初始化();
        }

        private void 点检样件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form_点检样件_ forms = new Form_点检样件_())
            {
                forms.ShowDialog();

            }
        }
    }
}
