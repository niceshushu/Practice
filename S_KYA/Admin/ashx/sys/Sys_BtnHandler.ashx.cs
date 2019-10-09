using S_KYA_Common;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_BtnHandler 的摘要说明
    /// </summary>
    public class Sys_BtnHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Operate = context.Request["opertype"];
            switch (Operate)
            {
                case "getList":
                    getBtnList();
                    break;
                case "add":
                    break;
                case "edit":

                default:
                    break;
            }
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void getBtnList()
        {
            int pageindex = int.Parse(HttpContext.Current.Request.Params["page"]);
            int pagesize = int.Parse(HttpContext.Current.Request.Params["rows"]);
            string MenuID = HttpContext.Current.Request.Params["MenuID"].ToString();
            Mod_Com_Pager pager = new Mod_Com_Pager(pagesize, pageindex);

            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(MenuID))
            {
                ht.Add("MenuID", " and MenuID=" + MenuID);
            }
            var li_sys_Users = Bll_Sys_Btn.Instance.getSysBtnList(ht, "BtnID", pager);
            List<Mod_Sys_Btn> _Sys_User = new List<Mod_Sys_Btn>();
            string result = $"\"total\":\"{pager.RowCount.ToString()}\",\"rows\":{JSONhelper.ToJson(li_sys_Users)}";
            result = "{" + result + "}";
            //string result = $"\"total\": \"{ pager.RowCount.ToString()} \",\"rows\":\"{JSONhelper.ToJson(dt)}\"";
            HttpContext.Current.Response.Write(result);
        }
    }
}