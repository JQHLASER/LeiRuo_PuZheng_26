using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 加工
    {
        /// <summary>
        /// 异步
        /// </summary>
        internal static async Task 启动加工()
        {
            Form_main.form_Main.flowLayoutPanel_操作按钮.Enabled = false;
            await Task.Run(() => { 工作.工作流程(); });
            Form_main.form_Main.flowLayoutPanel_操作按钮.Enabled = true ;
        }

    }
}
