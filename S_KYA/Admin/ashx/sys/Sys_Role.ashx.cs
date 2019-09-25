using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using S_KYA_Common;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_Role 的摘要说明
    /// </summary>
    public class Sys_Role : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Operate = context.Request["opertype"];
            switch (Operate)
            {
                case "getList":
                    getRoleList();
                    context.Response.End();
                    break;
                case "add":
                    context.Response.End();
                    break;
                case "edit":

                default:
                    break;
            }
        }

        private void getRoleList()
        {
            int pageindex = int.Parse(HttpContext.Current.Request.Params["page"]);
            int pagesize = int.Parse(HttpContext.Current.Request.Params["rows"]);
            Mod_Com_Pager pager = new Mod_Com_Pager(pagesize, pageindex);

            Hashtable ht = new Hashtable();
            DataSet ds = Bll_Sys_Role.Instance.getSysRoleList(ht, "RoleID", pager);
            DataTable dt = null;
            List<Mod_Sys_User> _Sys_User = new List<Mod_Sys_User>();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            string result = $"\"total\":\"{pager.RowCount.ToString()}\",\"rows\":{JSONhelper.ToJson(dt)}";
            result = "{" + result + "}";
            HttpContext.Current.Response.Write(result);
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