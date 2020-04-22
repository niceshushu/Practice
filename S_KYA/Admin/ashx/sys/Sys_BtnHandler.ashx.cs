using S_KYA_Common;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_BtnHandler 的摘要说明
    /// </summary>
    public class Sys_BtnHandler : KA_BasePage
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Operate = context.Request["opertype"];
            switch (Operate)
            {
                case "getList":
                    getBtnList();
                    break;
                case "getSingle":
                    getSingle();
                    break;
                case "getTool":
                    getToolBarByMuid(context.Request["MenuId"], context);
                    break;
                case "add":
                    break;
                case "edit":

                default:
                    break;
            }
            context.Response.End();
        }

        private void getToolBarByMuid(string MenuId, HttpContext context)
        {
            Hashtable ht = new Hashtable();
            ht.Add("MenuId", $" and MenuID={MenuId}");
            var li_sys_Users = Bll_Sys_Btn.Instance.getSysBtnList(ht, "BtnID");

            //StringBuilder result = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            //string strResult = "";
            //result.Append("[");//下面这个foreach是错误的做法
            //foreach (var item in li_sys_Users)
            //{
            //    //<a id="a_search" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon-search" title="查询">查询</a>
            //    //< a href = "#" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true"></a>
            //    result.Append($"<a  id=\"{item.BtnCode}\" style=\"float:left\" href = \"javascript:;\" class=\"easyui-linkbutton\" ");
            //    result.Append($"data-options=\"iconCls:'icon-edit',plain:'true'\" >{item.BtnName}");
            //    result.Append("</a>");
            //    //result.Append("{");
            //    //result.Append("\"id\":\"" + item.BtnCode + "\",");
            //    //result.Append("\"text\":\"" + item.BtnName + "\",");
            //    //result.Append("\"iconCls\":\"icon-edit\",");
            //    //result.Append("\"handler\":\"function(){addedit();}\"");
            //    //result.Append("},");
            //}
            sb.Append("{\"toolbar\":[");
            foreach (var item in li_sys_Users)
            {
                if (!CheckButtonRights(item.BtnID.ToString()))//加上按钮权限过滤>.<
                {
                    continue;
                }
                sb.Append("{\"text\": \"" + item.BtnName + "\",\"iconCls\":\"" + item.Icon + "\",\"handler\":\"" + item.BtnCode + "();\"},");
            }
            sb.Remove(sb.Length-1,1);
            sb.Append("]}");
            //strResult = result.ToString().Trim(new char[] {',' });
            //strResult= strResult+"]";

            context.Response.Write(sb.ToString());
        }

        private void getSingle()
        {
            string MenuID = HttpContext.Current.Request.Params["MenuID"].ToString();
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