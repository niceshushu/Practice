using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Common.Provider;
using S_KYA_Core.Model;
using System.Data;
using System.Collections;
using S_KYA_Common.Data.SqlServer;

namespace S_KYA_Core.Dal
{
    public class Dal_Sys_Author
    {
        public static Dal_Sys_Author Instance
        {
            get { return SingletonProvider<Dal_Sys_Author>.Instance; }
        }

        /// <summary>
        /// 获得数据列表,带分页
        /// </summary>
        public List<Mod_Sys_Author> GetList(Hashtable ht, string order, Mod_Com_Pager pager = null)
        {
            DataSet dataSet = null;
            List<Mod_Sys_Author> li_Sys_User = new List<Mod_Sys_Author>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Author ");
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
            }
            else
            {
                dataSet = SqlEasy.ExecuteDataSet(strSql.ToString());
                return ConvertToListData(dataSet);
            }

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_Sys_Author> GetList(Hashtable ht)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Author ");
            strSql.Append(" Where 1=1  ");
            if (ht != null)
            {
                foreach (DictionaryEntry de in ht)
                {
                    strSql.AppendLine(de.Value.ToString());
                }
            }
            return ConvertToListData(SqlEasy.ExecuteDataSet(strSql.ToString()));
        }

        private List<Mod_Sys_Author> ConvertToListData(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                List<Mod_Sys_Author> tmpLiSys_Author = new List<Mod_Sys_Author>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Mod_Sys_Author sys_Author = new Mod_Sys_Author();
                    sys_Author.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString()); //dataSet.Tables[0].Rows[i]["Id"].ToString() == "0" ? false : true;
                    sys_Author.ResourceId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ResourceId"].ToString());//dataSet.Tables[0].Rows[i]["PassSalt"].ToString();
                    sys_Author.ResourceType = dataSet.Tables[0].Rows[i]["ResourceType"].ToString();
                    sys_Author.RoleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["RoleId"].ToString() == "" ? "-1" : dataSet.Tables[0].Rows[i]["RoleId"].ToString());
                    tmpLiSys_Author.Add(sys_Author);
                }
                return tmpLiSys_Author;
            }
            else
            {
                return null;
            }
        }
    }
}
