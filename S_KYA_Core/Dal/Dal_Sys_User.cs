using S_KYA_Common.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Model;
using System.Data;
using S_KYA_Common.Data.SqlServer;
namespace S_KYA_Core.Dal
{
    public class Dal_Sys_User
    {
        public static Dal_Sys_User Instance
        {
            get { return SingletonProvider<Dal_Sys_User>.Instance; }
        }
        public Mod_Sys_User testGetUser(string UserName)
        {
            try
            {
                DataTable dt =SqlEasy.ExecuteDataTable(string.Format("SELECT * FROM Sys_User WHERE UserName='{0}'", UserName));
                Mod_Sys_User Sys_User = null;
                if (dt.Rows.Count == 1)
                {
                    Sys_User = new Mod_Sys_User();
                    Sys_User.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    Sys_User.PassWord = dt.Rows[0]["PassWord"].ToString();
                    Sys_User.UserName = dt.Rows[0]["UserName"].ToString();
                    Sys_User.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    if (dt.Rows[0]["IsDisabled"] == DBNull.Value)
                    {
                        Sys_User.IsDisabled = false;
                    }
                    else
                    {

                        Sys_User.IsDisabled = Convert.ToBoolean(dt.Rows[0]["IsDisabled"]);
                    }

                }
                return Sys_User;

            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
