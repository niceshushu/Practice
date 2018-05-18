using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using S_KYA_Common.Data.SqlServer;
using S_KYA_Core.Model;
using S_KYA_Common.Provider;
using System.Collections;

namespace S_KYA_Core.Dal
{
    //菜单表_Sys_Menu
    public partial class Dal_Sys_Menu
    {
        public static Dal_Sys_Menu Instance
        {
            get { return SingletonProvider<Dal_Sys_Menu>.Instance; }
        }

        public bool Exists(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Menu");
            strSql.Append(" where ");
            strSql.Append(" MenuId = @MenuId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuId", SqlDbType.Int,4)
            };
            parameters[0].Value = MenuId;
            Mod_Sys_Menu o = (Mod_Sys_Menu)SqlEasy.ExecuteScalar(strSql.ToString(), parameters);
            if (o != null)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mod_Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Menu(");
            strSql.Append("Pid,MenuName,Menu_Url,Icon,Sort");
            strSql.Append(") values (");
            strSql.Append("@Pid,@MenuName, @Menu_Url, @Icon, @Sort");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter(" @Pid", SqlDbType.Int,4) ,
                        new SqlParameter(" @MenuName", SqlDbType.NVarChar,100) ,
                        new SqlParameter(" @Menu_Url", SqlDbType.NVarChar,500) ,
                        new SqlParameter(" @Icon", SqlDbType.VarChar,50) ,
                        new SqlParameter(" @Sort", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Pid;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.Menu_Url;
            parameters[3].Value = model.Icon;
            parameters[4].Value = model.Sort;

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
        public bool Update(Mod_Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Menu set ");

            strSql.Append(" Pid = @Pid , ");
            strSql.Append(" MenuName = @MenuName , ");
            strSql.Append(" Menu_Url = @Menu_Url , ");
            strSql.Append(" Icon = @Icon , ");
            strSql.Append(" Sort = @Sort  ");
            strSql.Append(" where MenuId=@MenuId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@MenuId", SqlDbType.Int,4) ,
                        new SqlParameter("@Pid", SqlDbType.Int,4) ,
                        new SqlParameter("@MenuName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@Menu_Url", SqlDbType.NVarChar,500) ,
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sort", SqlDbType.Int,4)

            };

            parameters[0].Value = model.MenuId;
            parameters[1].Value = model.Pid;
            parameters[2].Value = model.MenuName;
            parameters[3].Value = model.Menu_Url;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Sort;
            int rows = SqlEasy.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Menu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuId", SqlDbType.Int,4)
            };
            parameters[0].Value = MenuId;


            int rows = SqlEasy.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string MenuIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Menu ");
            strSql.Append(" where ID in (" + MenuIdlist + ")  ");
            int rows = SqlEasy.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_Sys_Menu GetModel(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MenuId, Pid, MenuName, Menu_Url, Icon, Sort  ");
            strSql.Append("  from Sys_Menu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuId", SqlDbType.Int,4)
            };
            parameters[0].Value = MenuId;


            Mod_Sys_Menu model = new Mod_Sys_Menu();
            DataSet ds = SqlEasy.ExecuteDataSet(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(ds.Tables[0].Rows[0]["MenuId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(ds.Tables[0].Rows[0]["Pid"].ToString());
                }
                model.MenuName = ds.Tables[0].Rows[0]["MenuName"].ToString();
                model.Menu_Url = ds.Tables[0].Rows[0]["Menu_Url"].ToString();
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Hashtable ht)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Menu ");
            strSql.Append(" Where 1=1  ");
            if (ht != null)
            {
                foreach (DictionaryEntry de in ht)
                {
                    strSql.AppendLine(de.Value.ToString());
                }
            }
            return SqlEasy.ExecuteDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Sys_Menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlEasy.ExecuteDataSet(strSql.ToString());
        }


    }
}

