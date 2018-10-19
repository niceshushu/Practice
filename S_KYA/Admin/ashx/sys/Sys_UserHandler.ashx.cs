﻿using S_KYA_Common;
using S_KYA_Core.Bll;
using S_KYA_Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace S_KYA.Admin.ashx.sys
{
    /// <summary>
    /// Sys_UserHandler 的摘要说明
    /// </summary>
    public class Sys_UserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Operate = context.Request["opertype"];
            switch (Operate)
            {
                case "getList":
                    getUserList();
                    context.Response.End();
                    break;
                case "add":
                    AddUser();
                    context.Response.End();
                    break;
                case "edit":

                default:
                    break;
            }

        }
        private void UpdateUser()
        {

        }
        private void AddUser()
        {
            string PassSalt = StringHelper.RandomString(4);
            string PassWord = StringHelper.MD5string(HttpContext.Current.Request.Params["psys_user_txtPassWord"] + PassSalt);
            string UserName = HttpContext.Current.Request.Params["psys_user_txtUserName"];
            Mod_Sys_User mod_Sys_User = new Mod_Sys_User();
            mod_Sys_User.PassSalt = PassSalt;
            mod_Sys_User.PassWord = PassWord;
            mod_Sys_User.RoleId = -1;
            mod_Sys_User.UserName = UserName;
            int result = Bll_Sys_User.Instance.Add(mod_Sys_User);
            Mod_Com_Json mod_Com_Json = new Mod_Com_Json();
            if (result == 1)
            {
                mod_Com_Json.Data = "";
                mod_Com_Json.Message = "成功";
                mod_Com_Json.StatuCode = "200";
            }
            else
            {
                mod_Com_Json.Data = "";
                mod_Com_Json.Message = "失败";
                mod_Com_Json.StatuCode = "-1";
            }
            HttpContext.Current.Response.Write(JSONhelper.ToJson(mod_Com_Json));

        }

        public void getUserList()
        {
            int pageindex = int.Parse(HttpContext.Current.Request.Params["page"]);
            int pagesize = int.Parse(HttpContext.Current.Request.Params["rows"]);
            Mod_Com_Pager pager = new Mod_Com_Pager(pagesize, pageindex);

            Hashtable ht = new Hashtable();
            DataSet ds = Bll_Sys_User.Instance.getSysUserList(ht, "UserId", pager);
            DataTable dt = null;
            List<Mod_Sys_User> _Sys_User = new List<Mod_Sys_User>();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                #region 没用
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Mod_Sys_User _User = new Mod_Sys_User();
                //    _User.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                //    _User.UserName = dt.Rows[i]["UserName"].ToString();
                //    if (dt.Rows[i]["RoleId"] != DBNull.Value)
                //    {
                //        _User.RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]);
                //    }
                //    if (dt.Rows[i]["IsDisabled"] != DBNull.Value)
                //    {
                //        _User.IsDisabled = Convert.ToBoolean(dt.Rows[i]["IsDisabled"]);
                //    }
                //    _Sys_User.Add(_User);
                //} 
                #endregion
            }
            string result = $"\"total\":\"{pager.RowCount.ToString()}\",\"rows\":{JSONhelper.ToJson(dt)}";
            result = "{" + result + "}";
            //string result = $"\"total\": \"{ pager.RowCount.ToString()} \",\"rows\":\"{JSONhelper.ToJson(dt)}\"";
            HttpContext.Current.Response.Write(result);
        }

        public void BindDataToModel(DataTable dt, List<Mod_Sys_User> _Sys_User)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mod_Sys_User _User = new Mod_Sys_User();
                _User.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                _User.UserName = dt.Rows[i]["UserName"].ToString();
                _User.PassWord = dt.Rows[i]["PassWord"].ToString();
                _User.RoleId = Convert.ToInt32(dt.Rows[i]["Pid"]);
                _User.PassSalt = dt.Rows[i]["PassSalt"].ToString();
                _User.IsDisabled = Convert.ToBoolean(dt.Rows[i]["IsDisabled"]);
                _Sys_User.Add(_User);
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