using mainclassqf;
using Sunny25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    public class myApp_Main
    {

        /// <summary>
        /// 对外接口,进入主窗体
        /// </summary>
        public static void 程序启动()
        {
            new mainclassqf.GC_();

            #region 捕获异常/初始化

            申明.system_sys.捕获异常关闭();
            申明.system_sys.初始化();

            #endregion


            #region 启动前自检


            List<mainclassSoft.系统类.info_参数_> lst = new List<mainclassSoft.系统类.info_参数_>();

            #region 要检测的文件

           // mainclassSoft.系统类.info_参数_ info = new mainclassSoft.系统类.info_参数_();          
            //lst.Add(info);


            #endregion

            bool rt = 申明.system_sys.启动前自检(lst, out string msgErr);
            if (!rt)
            {
                Sunny25.MessageBoxSize size = new MessageBoxSize();
                size.x = 600;
                size.y = 400;
                Sunny25.Messagebox.Show(msgErr, "", MessageboxStatus.Red, size);
                return;
            }

            #endregion

            if (用户_.用户登陆())
            {
                new Form_main().ShowDialog();
            }

            
            //申明.system_sys.读取商标();

        }


        internal static void 进入主窗体()
        {
            申明.myForm25_sys.Action_功能标题 += 系统事件.功能栏;
            申明.myForm25_sys.Action_标题栏状态 += 系统事件.窗体标题栏;
            申明.myForm25_sys.Action_状态栏数据 += 系统事件.状态栏;
            申明.myForm25_sys.Action_软件注册状态_bool += 系统事件.注册结果;


            mainclassSoft.myForm_2025.con_控件_ con = new mainclassSoft.myForm_2025.con_控件_();
            con.FormMain = Form_main.form_Main;
            con.状态栏 = Form_main.form_Main.uI_状态栏1;
            con.功能标题栏 = Form_main.form_Main.功能栏1;
            con.log日志栏 = Form_main.form_Main.uI_Log1;

            
            申明.myForm25_sys.初始化(con);

        }

        internal static void 关闭主窗体()
        {
            申明.myForm25_sys.Action_功能标题 -= 系统事件.功能栏;
            申明.myForm25_sys.Action_标题栏状态 -= 系统事件.窗体标题栏;
            申明.myForm25_sys.Action_状态栏数据 -= 系统事件.状态栏;
            申明.myForm25_sys.Action_软件注册状态_bool -= 系统事件.注册结果;

            申明.myForm25_sys.释放();
          

        }


    }
}
