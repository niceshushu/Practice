using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_MenuHandler 的摘要说明
    /// </summary>
    public class Sys_MenuHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Operate = context.Request["Operate"];
            switch (Operate)
            {
                case "btnInsert":
                    AddSys_Menue();
                    break;
                case "btnUpdate":
                    break;
                case "btnDelete":
                    break;
                case "btnSearch":
                    break;
                default:
                    break;
            }

        }
        public void AddSys_Menue()
        {
            Mod_Sys_Menu _Sys_Menu = new Mod_Sys_Menu();
            BindDataToModel(ref _Sys_Menu);
            Bll_Sys_Menu.Instance.Add(_Sys_Menu);
        }

        public void BindDataToModel(ref Mod_Sys_Menu _Sys_Menu)
        {
            _Sys_Menu.MenuName= HttpContext.Current.Request.Form["MenuName"];
            _Sys_Menu.Menu_Url = HttpContext.Current.Request.Form["Menu_Url"];
            _Sys_Menu.Icon = HttpContext.Current.Request.Form["Icon"];
            _Sys_Menu.Pid = Convert.ToInt32(HttpContext.Current.Request.Form["Pid"]);
            _Sys_Menu.Icon = HttpContext.Current.Request.Form["Icon"];
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