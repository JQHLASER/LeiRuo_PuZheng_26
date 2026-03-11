using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    internal class 用户_
    {
        internal static mainclassSoft.用户 user_sys = new mainclassSoft.用户();

        internal static bool 用户登陆()
        {
            if (!功能.Config.使能_用户)
            {
                return true;
            }
            return user_sys.窗体_登陆() == DialogResult.OK ? true : false;
        }

        internal static bool 用户切换()
        {
            bool rt = 用户_.用户登陆();
            if (rt)
            {
                进入窗体(true);
            }
            return rt;
        }

        internal static void 进入窗体(bool 切换 = false)
        {
            //菜单
            Form_main.form_Main.toolStripDropDownButton_用户.Visible = 功能.Config.使能_用户 ? true : false;
            if (!功能.Config.使能_用户)
            {
                return;
            }

            #region 日志

            string 用户 = Language.读取语言("用户");
            string 权限 = Language.读取语言("权限");
            string show = 切换 ? $"{Language.读取语言("用户切换成功")}," : $"{Language.读取语言("用户登陆成功")},";
            show += $"【{用户}:{user_sys.Config.当前登陆的用户信息.用户}】";
            show += $"【{权限}:{Language.读取语言(user_sys.Config.当前登陆的用户信息.权限.ToString())}】";
            Log.Add(true, show);

            #endregion                       
        
            系统事件.用户权限(user_sys.Config.当前登陆的用户信息.权限);
        }

        internal static void 功能栏(List<string> lst)
        {
            if (!功能.Config.使能_用户)
            {
                return;
            }
            string 用户 = Language.读取语言("用户");
            string 权限 = Language.读取语言("权限");
            string show = $"{用户}: {user_sys.Config.当前登陆的用户信息.用户}";
            show += $"  {权限}: {Language.读取语言(user_sys.Config.当前登陆的用户信息.权限.ToString())}";
            lst.Add(show);

        }



    }
}
