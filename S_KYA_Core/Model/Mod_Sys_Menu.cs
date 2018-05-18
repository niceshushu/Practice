using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    public class Mod_Sys_Menu
    {

        /// <summary>
        /// 菜单ID
        /// </summary>		
        private int _menuid;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// 父节点
        /// </summary>		
        private int _pid;
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        private string _menuname;
        public string MenuName
        {
            get { return _menuname; }
            set { _menuname = value; }
        }
        /// <summary>
        /// 菜单地址
        /// </summary>		
        private string _menu_url;
        public string Menu_Url
        {
            get { return _menu_url; }
            set { _menu_url = value; }
        }
        /// <summary>
        /// 图标名称
        /// </summary>		
        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        private int _sort;
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}

