using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_AuthorHandler 的摘要说明
    /// </summary>
    public class Sys_AuthorHandler : KA_BasePage
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

        }
    }
}