using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace S_KYA_Common.CollectedTools
{
    public class ShuCollected
    {
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <param name="transparent">是否使用了代理</param>
        /// <returns>ip地址</returns>
        public static string GetIPAddress(bool transparent = false)
        {
            string ip = string.Empty;
            if (HttpContext.Current != null)
            {
                if (transparent)
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    {
                        ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                    }
                }
                if (string.IsNullOrWhiteSpace(ip))
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                    {
                        ip = HttpContext.Current.Request.ServerVariables["HTTP_VIA"].ToString();
                    }
                    else
                    {
                        ip= HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); 
                    }
                }
            }
            return ip;
        }
    }
}
