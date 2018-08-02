using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Model;
namespace S_KYA_Core.Dal
{
    public class Dal_Common
    {
        public static bool GetPageSql(ref string strPageSql,string sql,string orderColumns,Mod_Com_Pager pager)
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

            return false;
        }
    }
}
