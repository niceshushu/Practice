using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace S_KYA
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (HttpContext.Current.Server.GetLastError() == null)
            {
                return;
            }
            Exception objErr = HttpContext.Current.Server.GetLastError().GetBaseException();

            string error = "异常页面:" + (System.Web.HttpContext.Current.Request == null ? "" : System.Web.HttpContext.Current.Request.Url.ToString()) + "<br>";
            error += $"异常源:{objErr.Source}<br>";
            error += $"异常信息:{objErr.Message}<br>";
            error += $"堆栈信息:{objErr.StackTrace}<br>";
            HttpContext.Current.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}