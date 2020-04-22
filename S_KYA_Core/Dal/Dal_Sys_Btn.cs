using S_KYA_Common.Data.SqlServer;
using S_KYA_Common.Provider;
using S_KYA_Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Dal
{
    public partial class Dal_Sys_Btn
    {
        public static Dal_Sys_Btn Instance
        {
            get { return SingletonProvider<Dal_Sys_Btn>.Instance; }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_Sys_Btn> GetList(Hashtable ht, string order, Mod_Com_Pager pager = null)
        {
            DataSet dataSet = null;
            List<Mod_Sys_Btn> li_Sys_Btn = new List<Mod_Sys_Btn>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Btn ");
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
            strSql.Append(" FROM Sys_Btn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlEasy.ExecuteDataSet(strSql.ToString());
        }


        private List<Mod_Sys_Btn> ConvertToListData(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                List<Mod_Sys_Btn> tmpLiSys_Btn = new List<Mod_Sys_Btn>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Mod_Sys_Btn sys_btn = new Mod_Sys_Btn();
                    sys_btn.BtnCode = dataSet.Tables[0].Rows[i]["BtnCode"].ToString();
                    sys_btn.BtnID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["BtnID"].ToString());
                    sys_btn.BtnName = dataSet.Tables[0].Rows[i]["BtnName"].ToString();
                    sys_btn.BtnTitle = dataSet.Tables[0].Rows[i]["BtnTitle"].ToString();
                    sys_btn.MenuID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["MenuID"].ToString());
                    sys_btn.Icon = dataSet.Tables[0].Rows[i]["Icon"].ToString();
                    tmpLiSys_Btn.Add(sys_btn);
                }
                return tmpLiSys_Btn;
            }
            else
            {
                return null;
            }

        }
    }
}
