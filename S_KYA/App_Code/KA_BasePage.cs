using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S_KYA_Core.Model;
using System.Web.SessionState;

public abstract  class KA_BasePage : IHttpHandler, IRequiresSessionState
{

    private Mod_Sys_User _Sys_User = null;
    public Mod_Sys_User Sys_User
    {
        get
        {
          return  _Sys_User = _Sys_User ?? HttpContext.Current.Session["kya_Sys_UserInfo"] as Mod_Sys_User;
        }
        set
        {
            _Sys_User = value;
            HttpContext.Current.Session["kya_Sys_UserInfo"] = _Sys_User;
        }
    }

    public bool IsReusable => false;

    public abstract void ProcessRequest(HttpContext context);
}
