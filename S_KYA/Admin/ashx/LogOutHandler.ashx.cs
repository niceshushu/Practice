using S_KYA_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx
{
    /// <summary>
    /// LogOutHandler 的摘要说明
    /// </summary>
    public class LogOutHandler : KA_BasePage
    {
        public override void ProcessRequest(HttpContext context)
        {
            if (Sys_User != null)
            {
                HttpCookie aCookie = HttpContext.Current.Response.Cookies["hello"];

                if (aCookie != null)
                {
                    aCookie.Expires = DateTime.Now.AddDays(-1);//立刻失效
                    aCookie.Values.Clear();
                    HttpContext.Current.Response.Cookies.Set(aCookie);
                }
                //这玩意儿没用
                //HttpContext.Current.Request.Cookies.Remove("hello");
            }
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            Sys_User = null;//当前登录的用户去除
            var msg = new { success = false, message = "退出成功" };
            context.Response.Write(JSONhelper.ToJson(msg));
            //context.Response.End();
            //var logOutHref = string.Format("<script>window.location.href='" + (HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath) + "/Admin/page/login.html" + "';</script>");
            //HttpContext.Current.Response.Write("<script>alert('恭喜您，你的报名资料已经成功移除');</script>");
            //HttpContext.Current.Response.Write(logOutHref);
        }
    }
}