using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (!CheckUserIsLogin())
            {
                return;
            }

            string operatorType = context.Request["operatorType"];
            if (operatorType == "getTreeBtn")
            {
                context.Response.Write(GetMenuTreeAndBtn()); 
            }
            context.Response.End();
        }

        /// <summary>
        /// 获取菜单以及按钮（授权管理页-左侧-用）
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public string GetMenuTreeAndBtn(string RoleId = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var menuitem = kBuffer._Table_Sys_Menu;
            for (int i = 0; i < menuitem.Count; i++)
            {
                sb.Append("{");
                sb.Append($"\"id\":{menuitem[i].MenuId},\"text\":\"{menuitem[i].MenuName}\",\"iconCls\":\"{menuitem[i].Icon}\",");
                sb.Append($"\"attributes\":");
                sb.Append("{");
                sb.Append($"\"attr\":\"menu\",");
                sb.Append($"\"inp\":" + menuitem[i].MenuId);
                sb.Append("},");
                sb.Append($"\"children\":[");
              
                var btnList = kBuffer._Table_Sys_Btn.Where(btn => btn.MenuID == menuitem[i].MenuId).ToList();
                for (int j = 0; j < btnList.Count(); j++)
                {
                    sb.Append("{");
                    sb.Append($"\"id\":{btnList[j].BtnID},\"text\":\"{btnList[j].BtnName}\",\"iconCls\":\"{btnList[j].Icon}\",");
                    sb.Append($"\"attributes\":");
                    sb.Append("{");
                    sb.Append($"\"attr\":\"btn\",");
                    sb.Append($"\"inp\":" + btnList[j].BtnID);
                    sb.Append("}");
                    if (j == btnList.Count - 1)
                    {
                        sb.Append("}");
                    }
                    else
                    {
                        sb.Append("},");
                    }
                }

                sb.Append("]");

                if (i == menuitem.Count - 1)
                {
                    sb.Append("}");
                }
                else
                {
                    sb.Append("},");
                }
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}