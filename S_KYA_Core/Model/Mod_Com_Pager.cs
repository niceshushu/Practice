using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    public class Mod_Com_Pager
    {

        private int _PageSize = 10;
        private int _PageNum = 1;
        private int _PageCount = 1;
        private int _RowCount = 0;
        public Mod_Com_Pager(int pageSize = 10, int pageNum = 1)
        {
            this.PageSize = pageSize;
            this.PageNum = pageNum;
        }
        /// <summary>
        /// 设置或者获取当前每页显示行数
        /// </summary>
        public int PageSize { get => _PageSize; set => _PageSize = value; }
        /// <summary>
        /// 设置或者获取当前显示页码
        /// </summary>
        public int PageNum { get => _PageNum; set => _PageNum = value; }
        /// <summary>
        /// 设置或者获取当前数据总页数
        /// </summary>
        public int PageCount { get => _PageCount; set => _PageCount = value; }
        /// <summary>
        /// 设置或者获取当前数据总行数
        /// </summary>
        public int RowCount { get => _RowCount; set => _RowCount = value; }



    }
}
