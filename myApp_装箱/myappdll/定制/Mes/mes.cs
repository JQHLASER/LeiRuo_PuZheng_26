 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sunny25.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class mes
    {

        internal static (bool s, string m) 上传(mes_数据结构._上传_ info)
        {
            string url = 系统类_myApp.Config.参数.Mes_Url;
            string jsonStr = JsonConvert.SerializeObject(info);
            string jsonStrLog = JsonConvert.SerializeObject(info, Formatting.Indented);
            Log.Add(true, $"mes请求...{jsonStrLog}");
            var rt = new mainclassqf.http请求_25().请求(mainclassqf.http请求_25.enum请求方式.Post, url, null, jsonStr, out string msg);
            Log.Add(true, $"mes接收...{msg}");
            if (rt)
            {
                try
                {
                    var rtJson = JToken.Parse(jsonStr);
                    var rtMes = JsonConvert.DeserializeObject<mes_数据结构._反馈_>(msg);
                    msg = rtMes.msg;
                    rt = rtMes.code == 0
                        ? true : false;
                }
                catch (Exception ex)
                {
                    rt = false;
                    msg = ex.ToString();
                }
            }
            return (rt, msg);
        }



    }
}
