﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using S_KYA_Common;
using S_KYA_Common.Data.SqlServer;
using S_KYA_Common.ValidateCode;
using S_KYA_Core.Model;
using S_KYA_Core.Bll;
namespace S_KYA.ashx
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : KA_BasePage
    {

        public override void ProcessRequest(HttpContext context)
        {
            //初始化密码
            string passalt = StringHelper.RandomString(4);
            string pwd = StringHelper.MD5string("111111" + passalt);
            //初始化密码
            string pwdss = StringHelper.MD5string("111111" + StringHelper.RandomString(4));
            context.Response.ContentType = "text/plain";
            var username = context.Request["username"];
            var password = context.Request["password"];
            var validateCode = context.Request["validateCode"];
            var saveCookieDays = PublicMethod.GetInt(context.Request["savedays"]);
            var msg = new { success = false, message = "用户名不存在" };

            //Session登录
            if (Sys_User != null)
            {
                msg = new { success = true, message = "ok" };
            }
            else
            {
                if (!Validate.Validation(validateCode))
                {
                    msg = new { success = false, message = "验证码错误" };
                }
                else
                {
                    try
                    {
                        Mod_Sys_User u = S_KYA_Core.Dal.Dal_Sys_User.Instance.testGetUser(username);
                        if (u != null)
                        {
                            if (!u.IsDisabled)
                            {
                                bool flag = Bll_Sys_User.Instance.UserLogin(username, password, saveCookieDays);
                                if (flag)
                                {
                                    msg = new { success = true, message = "ok" };
                                    u.ExpiresTime = DateTime.Now.AddDays(saveCookieDays);
                                    Sys_User = u;
                                }
                                else
                                {
                                    msg = new { success = false, message = "亲，用户名或密码不正确哦。" };
                                }
                            }
                            else
                            {
                                msg = new { success = false, message = "亲，您的帐号已被禁用，请联系管理员吧。" };
                            }

                            //msg = new { success = true, message = "ok" };//跳过验证，随便都可以登录
                        }
                        else
                        {
                            msg = new { success = false, message = "亲，用户名或密码不正确哦。" };
                        }
                    }
                    catch (Exception ex)
                    {
                        msg = new { success = false, message = $"系统错误:【{ex.Message}】请联系开发人员" };
                    }

                }

            }
            context.Response.Write(JSONhelper.ToJson(msg));
            context.Response.End();
        }

    }
}
/*
随机字符串 
length : 字符串长度
function randomString(length) {
    var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    var size = length || 8;
    var i = 1;
    var ret = "";
    while (i <= size) {
        var max = chars.length - 1;
        var num = Math.floor(Math.random() * max);
        var temp = chars.substr(num, 1);
        ret += temp;
        i++;
    }
    return ret;
}
 */
