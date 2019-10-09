using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    //按钮表
    public class Mod_Sys_Btn
    {
        private int _btnid;
        /// <summary>
        /// 按钮ID
        /// </summary>	
        public int BtnID
        {
            get { return _btnid; }
            set { _btnid = value; }
        }

        private string _btncode;
        /// <summary>
        /// 页面组件ID
        /// </summary>	
        public string BtnCode
        {
            get { return _btncode; }
            set { _btncode = value; }
        }

        private string _btnname;
        /// <summary>
        /// 按钮名称
        /// </summary>	
        public string BtnName
        {
            get { return _btnname; }
            set { _btnname = value; }
        }

        private string _btntitle;
        /// <summary>
        /// 按钮标题
        /// </summary>	
        public string BtnTitle
        {
            get { return _btntitle; }
            set { _btntitle = value; }
        }

        private int _menuid;
        /// <summary>
        /// 菜单ID
        /// </summary>	
        public int MenuID
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

    }

}
