using S_KYA_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx
{
    /// <summary>
    /// LoginBeforeHandler 的摘要说明
    /// </summary>
    public class LoginBeforeHandler : KA_BasePage
    {
        public override void ProcessRequest(HttpContext context)
        {
            var msg = new { success = false, message = "session信息丢失" };
            //Session登录
            if (Sys_User != null)
            {
                msg = new { success = true, message = "ok" };
            }
            else
            {
                msg = new { success = false, message = "session信息丢失" };
            }
            context.Response.Write(JSONhelper.ToJson(msg));
            context.Response.End();
        }
    }
}