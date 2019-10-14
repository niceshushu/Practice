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
    public class Easyui_MenuTreeHandler :  KA_BasePage
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string pid = context.Request["pid"];
            string floor = context.Request["floor"];
            if (floor != null && floor.Length > 0)
            {
                switch (floor)
                {
                    case "one"://获取第一层的菜单
                        context.Response.Write(JSONhelper.ToJson(getData(pid)));
                        break;
                    case "all"://获取这一层及其以下所有层
                        context.Response.Write(getaddData(pid));
                        break;
                    default:
                        break;
                }

            }
            context.Response.End();
        }
        public string getaddData(string id)
        {
            //根据id查pid
            List<Mod_Sys_Menu> li_Sys_Menu = (from m in kBuffer._Table_Sys_Menu where m.Pid.ToString() == id select m).ToList();//Bll_Sys_Menu.Instance.GetList(ht);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (li_Sys_Menu != null)
            {
                for (int i = 0; i < li_Sys_Menu.Count; i++)
                {
                    sb.Append("{");
                    sb.Append($"\"id\":{li_Sys_Menu[i].MenuId},\"text\":\"{li_Sys_Menu[i].MenuName}\",\"iconCls\":\"{li_Sys_Menu[i].Icon}\"");
                    sb.Append($",\"attributes\":\"{li_Sys_Menu[i].Menu_Url}\"");
                    sb.Append($",\"sort\":\"{li_Sys_Menu[i].Sort}\"");
                    sb.Append($",\"pid\":\"{li_Sys_Menu[i].Pid}\"");

                    sb.Append(",\"children\":");
                    sb.Append(getaddData(li_Sys_Menu[i].MenuId.ToString()));
                    if (i == li_Sys_Menu.Count - 1)
                    {
                        sb.Append("}");
                    }
                    else
                    {
                        sb.Append("},");
                    }
                }
            }
            sb.Append("]");
            return sb.ToString();
        }



        public void BindDataToModel(DataTable dt, List<Mod_Sys_Menu> Origin_Sys_Menu)
        {
            List<Mod_Sys_Menu> _Sys_Menu = new List<Mod_Sys_Menu>();
            for (int i = 0; i < Origin_Sys_Menu.Count; i++)
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

        public List<Mod_Sys_Menu> getData(string pid)
        {
            var aa = Sys_User;
            Hashtable ht = new Hashtable();
            ht.Add("Pid", $" AND Pid='{pid}'");
            List<Mod_Sys_Menu> Li_Sys_Menus = Bll_Sys_Menu.Instance.GetList(ht);
            return Li_Sys_Menus;
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