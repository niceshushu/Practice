using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S_KYA_Common;
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
            string Operate = context.Request["psm_opertype"];
            switch (Operate)
            {
                case "Insert":
                    AddSys_Menue();
                    context.Response.End();
                    break;
                case "Update":
                    EditSys_Menue();
                    context.Response.End();
                    break;
                case "Delete":
                    DeleteSys_Menue();
                    context.Response.End();
                    break;
                case "Search":
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 新增菜单
        /// </summary>
        public void AddSys_Menue()
        {
            Mod_Sys_Menu _Sys_Menu = new Mod_Sys_Menu();
            BindDataToModel(ref _Sys_Menu);
            int rval = Bll_Sys_Menu.Instance.Add(_Sys_Menu);
            Mod_Com_Json mod_Com_Json = new Mod_Com_Json();
            if (rval >= 0)
            {
                mod_Com_Json.Message = "新增成功";
                mod_Com_Json.StatuCode = "200";
            }
            else
            {
                mod_Com_Json.Message = "新增失败";
                mod_Com_Json.StatuCode = "-1";
            }
            HttpContext.Current.Response.Write(JSONhelper.ToJson(mod_Com_Json));
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        public void EditSys_Menue()
        {
            Mod_Sys_Menu _Sys_Menu = new Mod_Sys_Menu();
            BindDataToModel(ref _Sys_Menu);
            bool rval = Bll_Sys_Menu.Instance.Update(_Sys_Menu);
            Mod_Com_Json mod_Com_Json = new Mod_Com_Json();
            if (rval)
            {
                mod_Com_Json.Message = "修改成功";
                mod_Com_Json.StatuCode = "200";
            }
            else
            {
                mod_Com_Json.Message = "修改失败";
                mod_Com_Json.StatuCode = "-1";
            }
            HttpContext.Current.Response.Write(JSONhelper.ToJson(mod_Com_Json));
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        public void DeleteSys_Menue()
        {
            Mod_Sys_Menu _Sys_Menu = new Mod_Sys_Menu();
            BindDataToModel(ref _Sys_Menu);
            bool rval = Bll_Sys_Menu.Instance.Delete(_Sys_Menu.MenuId);
            Mod_Com_Json mod_Com_Json = new Mod_Com_Json();
            if (rval)
            {
                mod_Com_Json.Message = "删除成功";
                mod_Com_Json.StatuCode = "200";
            }
            else
            {
                mod_Com_Json.Message = "删除失败";
                mod_Com_Json.StatuCode = "-1";
            }
            HttpContext.Current.Response.Write(JSONhelper.ToJson(mod_Com_Json));
        }

        public void BindDataToModel(ref Mod_Sys_Menu _Sys_Menu)
        {
            string Operate = HttpContext.Current.Request["psm_opertype"];
            _Sys_Menu.MenuName = HttpContext.Current.Request.Form["pmenuName"];
            _Sys_Menu.Menu_Url = HttpContext.Current.Request.Form["pmenuMenu_Url"];
            _Sys_Menu.Icon = HttpContext.Current.Request.Form["pmenuIcon"];
            _Sys_Menu.Pid = Convert.ToInt32(HttpContext.Current.Request.Form["pmenuPid"]);
            _Sys_Menu.Icon = HttpContext.Current.Request.Form["Icon"];
            _Sys_Menu.Sort =HttpContext.Current.Request.Form["pmenuSort"]==""?0 : Convert.ToInt32(HttpContext.Current.Request.Form["pmenuSort"]);
            if (Operate != "Insert")
            {
                _Sys_Menu.MenuId = Convert.ToInt32(HttpContext.Current.Request["pmenuId"]);
            }

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