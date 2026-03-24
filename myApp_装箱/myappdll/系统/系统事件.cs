using mainclassSoft;
using mainIndustryqf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    internal class 系统事件
    {

        static void 主窗体控件处理()
        {
            功能.设置();
            Form_main.form_Main.Invoke(new Action(() =>
            {

                if (申明.myForm25_sys.Config.注册方式 == mainclassSoft.软件注册2024.enum注册方式.不使能)
                {
                    Form_main.form_Main.注册ToolStripMenuItem.Visible = false;
                }
                Form_main.form_Main.语言ToolStripMenuItem.Visible = 页面设置_main.Config.参数.使能_语言;



            }));

        }


        internal static void 功能栏(List<string> lst)
        {
            用户_.功能栏(lst);
            计算.功能栏状态(lst);
            lst.Add($"设备编号:{系统类_myApp.Config.参数.设备编号}");
            string types = 系统类_myApp.Config.参数.使能_手持扫码枪 ? "手持式扫码枪" : "固定式读码器";
            lst.Add($"模式:{types}");

            if (系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                lst.Add($"扫码数量:{手持扫码枪._读码内容.Count}");
                Form_main.form_Main.Invoke((Action)(() =>
                {
                    Form_main .form_Main.label_手持扫码枪_扫码计数 .Text = $"{手持扫码枪._读码内容.Count}";
                }));
            }
        }

        internal static void 状态栏(List<string> lst)
        {
            生产计数.js_sys.状态栏(lst);





        }

        internal static void 进入程序()
        {
            主窗体控件处理();
            Log.初始化();
            Err.初始化();




        }

        internal static void 关闭程序()
        {

            IO_Zauto.释放();
            Err.释放();
            生产计数.释放();
            编码.释放();
            工件.释放();
            读码器.释放();
            dataBase.释放();
            手持扫码枪.释放();
        }


        internal static void 用户权限(mainclassSoft.用户.enum权限 enum权限)
        {

            #region 用户管理

            Form_main.form_Main.管理ToolStripMenuItem.Visible = false;
            if (enum权限 >= 用户.enum权限.管理员)
            {
                //菜单
                Form_main.form_Main.管理ToolStripMenuItem.Visible = true;
            }




            #endregion


            #region 控件


            Form_main.form_Main.生产计数ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.编辑ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.uiButton_尾料.Enabled = false;
            Form_main.form_Main.uiButton_换拖.Enabled = false;
            Form_main.form_Main.uiButton_换箱.Enabled = false;
            Form_main.form_Main.刷新ToolStripMenuItem.Enabled = false;

            Form_main.form_Main.加工ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.打印ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.图像标注ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.点检样件ToolStripMenuItem.Enabled = false;
            Form_main.form_Main.系统设置ToolStripMenuItem.Visible = false;


            if (enum权限 > 用户.enum权限.操作员)
            {
                if (enum权限 >= 用户.enum权限.管理员)
                {
                    Form_main.form_Main.加工ToolStripMenuItem.Enabled = true;
                   
                }

                Form_main.form_Main.刷新ToolStripMenuItem.Enabled = true;
                Form_main.form_Main.编辑ToolStripMenuItem.Enabled = true;
                Form_main.form_Main.生产计数ToolStripMenuItem.Enabled = true;

                Form_main.form_Main.uiButton_尾料.Enabled = true;
                Form_main.form_Main.uiButton_换拖.Enabled = true;
                Form_main.form_Main.uiButton_换箱.Enabled = true;

                Form_main.form_Main.图像标注ToolStripMenuItem.Enabled = true;
                Form_main.form_Main.打印ToolStripMenuItem.Enabled = true;
                Form_main.form_Main.点检样件ToolStripMenuItem.Enabled = true;

                Form_main.form_Main.系统设置ToolStripMenuItem.Visible = true;


            }



            #endregion

        }





        /// <summary>
        /// 状态: =true:已注册,=false:未注册
        /// </summary>
        /// <param name="状态"></param>
        internal static async void  注册结果(bool 状态)
        {
            using (var logger = new StreamWriter("startup.log", append: true))
            {
                logger.WriteLine($"[{DateTime.Now}] 开始初始化配置...");
                try
                {
                    主窗体控件处理();
                    生产计数.初始化();
                    编码.初始化();
                    工件.初始化();
                    // 示例：记录启动日志



                    if (状态)
                    {


                        #region 已注册,初始化
                        系统类_myApp.Initiall(1);

                        IO_Zauto.初始化();

                        Task t1 = Task.Run(() => { 读码器.初始化(); });
                        Task t2 = Task.Run(() => { dataBase.初始化(); });
                        Task t3 = Task.Run(() => {   手持扫码枪.初始化();  });
                        //Task.Run(() => { });

                        await Task.WhenAll(t1, t2,t3);
                        new Thread(() => { 工件.启动时自动加载工件(); }) { IsBackground = true }.Start();



                        #endregion



                    }
                    else
                    {
                        #region 未注册,禁用

                        Form_main.form_Main.Invoke(new Action(() =>
                        {
                            Form_main.form_Main.toolStripDropDownButton_测试.Enabled = false;
                            Form_main.form_Main.toolStripDropDownButton_文件.Enabled = false;
                            Form_main.form_Main.toolStripDropDownButton_数据库.Enabled = false;
                            Form_main.form_Main.flowLayoutPanel_操作按钮.Enabled = false;


                        }));


                        #endregion
                    }

                    // 配置加载逻辑
                    logger.WriteLine($"[{DateTime.Now}] 配置初始化成功");
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"[{DateTime.Now}] 配置初始化失败: {ex.Message}");

                    Log.Add(false, $"[{DateTime.Now}] 配置初始化失败: {ex.Message}");
                }
            }

        }

        internal static void 窗体标题栏()
        {
            工作.标题栏状态(申明.myForm25_sys, "");
             
            编码.Encode_sys.标题栏状态(申明.myForm25_sys, "编码模块");           
            打印.标题栏状态();          
            手持扫码枪.标题栏状态();

            工件.标题栏状态();

            读码器.标题栏状态();
            dataBase.标题栏状态();
            IO_Zauto.窗体标题();


            显示.画布();
        }




    }
}
