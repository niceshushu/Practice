using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
using S_KYA_Common;
using System.Text;

namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Easyui_MenuTreeHandler 的摘要说明
    /// </summary>
    public class Easyui_MenuTreeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string pid = context.Request["pid"];
            string floor = context.Request["floor"];
            if (floor != null && floor.Length > 0)
            {
                switch (floor)
                {
                    case "one"://获取第一层的菜单
                        List<Mod_Sys_Menu> Listmenu = new List<Mod_Sys_Menu>();
                        DataTable dt = getData(pid);
                        BindDataToModel(dt, Listmenu);
                        context.Response.Write(JSONhelper.ToJson(Listmenu));
                        break;
                    case "all"://获取这一层及其以下所有层
                        context.Response.Write(getaddData(pid));
                        break;
                    default:
                        break;
                }

            }

        }
        public string getaddData(string id)
        {
            //根据id查pid
            Hashtable ht = new Hashtable();
            ht.Add("Pid", $" AND Pid='{id}'");
            DataTable dt = Bll_Sys_Menu.Instance.GetList(ht).Tables[0];
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append($"\"id\":{dt.Rows[i]["MenuId"]},\"text\":\"{dt.Rows[i]["MenuName"]}\",\"iconCls\":\"{dt.Rows[i]["Icon"]}\"");
                sb.Append($",\"attributes\":\"{dt.Rows[i]["Menu_Url"]}\"");
 
                 sb.Append(",\"children\":");
                sb.Append(getaddData(dt.Rows[i]["MenuId"].ToString()));
                if (i == dt.Rows.Count - 1)
                {
                    sb.Append("}");
                }
                else
                {
                    sb.Append("},");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }



        public void BindDataToModel(DataTable dt, List<Mod_Sys_Menu> _Sys_Menu)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mod_Sys_Menu menuNavModel = new Mod_Sys_Menu();
                menuNavModel.MenuName = dt.Rows[i]["MenuName"].ToString();
                menuNavModel.Menu_Url = dt.Rows[i]["Menu_Url"].ToString();
                menuNavModel.Icon = dt.Rows[i]["Icon"].ToString();
                menuNavModel.Pid = Convert.ToInt32(dt.Rows[i]["Pid"]);
                menuNavModel.MenuId = Convert.ToInt32(dt.Rows[i]["MenuId"]);
                _Sys_Menu.Add(menuNavModel);
            }
        }

        public DataTable getData(string pid)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Pid", $" AND Pid='{pid}'");
            DataTable dt = Bll_Sys_Menu.Instance.GetList(ht).Tables[0];
            return dt;
        }

        public void AddMenuChild()
        {

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class SysModuleNavModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string attributes { get; set; }
        public string state { get; set; }
        public List<SysModuleNavModel> children { get; set; }
    }
}