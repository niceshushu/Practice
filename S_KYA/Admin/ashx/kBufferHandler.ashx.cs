using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx
{
    /// <summary>
    /// kBufferHandler 的摘要说明
    /// </summary>
    public class kBufferHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            //刷新缓存
            kBuffer._Fresh_Table_Sys_Menu();
            kBuffer._Fresh_Table_Sys_Role_GroupRight();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}