using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Common.Data.SqlServer;
using S_KYA_Core.Model;
namespace S_KYA_Core.Dal
{
    public class Dal_Common
    {
        public static bool GetPageSql(ref string strPageSql, string sql, string orderColumns, Mod_Com_Pager pager)
        {
            int pageSize = 0;
            int getPageNum = 0;
            int outTotalPage = 0;
            int outTotalRows = 0;
            if (pager != null)
            {
                pageSize = pager.PageSize;
                getPageNum = pager.PageNum;
                outTotalPage = pager.PageCount;
                outTotalRows = pager.RowCount;
            }
            //先计算总的数量，总记录
            string sqlRowCountTmp = string.Empty;
            sqlRowCountTmp = $"SELECT COUNT(1) AS Rc FROM ({sql}) PageData";
            object o = new object();
            o = SqlEasy.ExecuteScalar(sqlRowCountTmp);
            if (o != DBNull.Value)
            {
                outTotalRows = (int)o;
            }
            //计算页码
            if (outTotalRows % pageSize == 0)
            {
                outTotalPage = outTotalRows / pageSize;
            }
            else
            {
                outTotalPage = outTotalRows / pageSize + 1;
            }
            //校验取的页码
            if (getPageNum < 1)//比页面小就去第一页
            {
                getPageNum = 1;
            }
            if (outTotalPage < getPageNum)//比页面大就取最大页面
            {
                getPageNum = outTotalPage;
            }
            //开始行
            int startRow = (getPageNum - 1) * pageSize;
            //结束行
            int endRow = getPageNum * pageSize;

            pager.PageCount = outTotalPage;
            pager.RowCount = outTotalRows;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append($" SELECT ROW_NUMBER() OVER ( order by {orderColumns} desc) AS Rw,T.*");
            strSql.Append($" FROM ({sql}) T");
            strSql.Append(" )TT  ");

            strSql.AppendFormat(" WHERE TT.Rw > {0} and TT.Rw<={1}", startRow, endRow);
            strPageSql = strSql.ToString();
            return false;
        }
    }
}
