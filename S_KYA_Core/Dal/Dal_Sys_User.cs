using S_KYA_Common.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Model;
using System.Data;
using S_KYA_Common.Data.SqlServer;
using System.Data.SqlClient;
using System.Collections;

namespace S_KYA_Core.Dal
{
    public class Dal_Sys_User
    {
        public static Dal_Sys_User Instance
        {
            get { return SingletonProvider<Dal_Sys_User>.Instance; }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_Sys_User> GetList(Hashtable ht, string order, Mod_Com_Pager pager = null)
        {
            DataSet dataSet = null;
            List<Mod_Sys_User> li_Sys_User = new List<Mod_Sys_User>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_User ");
            strSql.Append(" Where 1=1  ");
            if (ht != null)
            {
                foreach (DictionaryEntry de in ht)
                {
                    strSql.AppendLine(de.Value.ToString());
                }
            }
            string strPageSql = string.Empty;
            if (pager != null)
            {
                Dal_Common.GetPageSql(ref strPageSql, strSql.ToString(), order, pager);
            }
            if (!string.IsNullOrEmpty(strPageSql))
            {
                dataSet = SqlEasy.ExecuteDataSet(strPageSql);
                return ConvertToListData(dataSet);
                //return dataSet;
            }
            else
            {
                dataSet = SqlEasy.ExecuteDataSet(strSql.ToString());
                return ConvertToListData(dataSet);
                //return dataSet;
            }

        }

        public Mod_Sys_User testGetUser(string UserName)
        {
            try
            {
                DataTable dt = SqlEasy.ExecuteDataTable(string.Format("SELECT * FROM Sys_User WHERE UserName='{0}'", UserName));
                Mod_Sys_User Sys_User = null;
                if (dt.Rows.Count == 1)
                {
                    Sys_User = new Mod_Sys_User();
                    Sys_User.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    Sys_User.PassWord = dt.Rows[0]["PassWord"].ToString();
                    Sys_User.UserName = dt.Rows[0]["UserName"].ToString();
                    Sys_User.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    Sys_User.PassSalt = dt.Rows[0]["PassSalt"].ToString();
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

            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mod_Sys_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_User(");
            strSql.Append("UserName,PassWord,RoleId,PassSalt,IsDisabled");
            strSql.Append(") values (");
            strSql.Append("@UserName,@PassWord, @RoleId, @PassSalt, @IsDisabled");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@PassWord", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@RoleId", SqlDbType.Int,8) ,
                        new SqlParameter("@PassSalt", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsDisabled", SqlDbType.Bit,2)

            };

            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.RoleId;
            parameters[3].Value = model.PassSalt;
            parameters[4].Value = model.IsDisabled;

            object obj = SqlEasy.ExecuteNonQuery(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);

            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mod_Sys_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update Sys_User SET ");
            strSql.Append(" UserName=@UserName, ");
            strSql.Append(" PassWord=@PassWord, ");
            strSql.Append(" RoleId=@RoleId, ");
            strSql.Append(" PassSalt=@PassSalt, ");
            strSql.Append(" IsDisabled=@IsDisabled ");
            strSql.Append(" where 1=1 and UserId=" + model.UserId);
            SqlParameter[] parameters = {
                        new SqlParameter("@UserName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@PassWord", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@RoleId", SqlDbType.Int,8) ,
                        new SqlParameter("@PassSalt", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsDisabled", SqlDbType.Bit,2)

            };

            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.RoleId;
            parameters[3].Value = model.PassSalt;
            parameters[4].Value = model.IsDisabled;

            object obj = SqlEasy.ExecuteNonQuery(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);

            }
        }

        private List<Mod_Sys_User> ConvertToListData(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                List<Mod_Sys_User> tmpLiSys_User = new List<Mod_Sys_User>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Mod_Sys_User sys_User = new Mod_Sys_User();
                    sys_User.IsDisabled = dataSet.Tables[0].Rows[i]["IsDisabled"].ToString().ToLower() == "false" ? false : true;
                    sys_User.PassSalt = dataSet.Tables[0].Rows[i]["PassSalt"].ToString();
                    sys_User.PassWord = dataSet.Tables[0].Rows[i]["PassWord"].ToString();
                    sys_User.RoleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["RoleId"].ToString() == "" ? "-1" : dataSet.Tables[0].Rows[i]["RoleId"].ToString());
                    sys_User.UserId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["UserId"].ToString());
                    sys_User.UserName = dataSet.Tables[0].Rows[i]["UserName"].ToString();
                    tmpLiSys_User.Add(sys_User);
                }
                return tmpLiSys_User;
            }
            else
            {
                return null;
            }

        }
    }
}
