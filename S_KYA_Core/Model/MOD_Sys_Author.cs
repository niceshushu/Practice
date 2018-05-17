using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace S_KYA_Core.Model
{
    //角色权限表
    public class Mod_Sys_Author
    {

        /// <summary>
        /// 主键ID
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>		
        private int _roleid;
        public int RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        /// <summary>
        /// 资源ID
        /// </summary>		
        private int _resourceid;
        public int ResourceId
        {
            get { return _resourceid; }
            set { _resourceid = value; }
        }
        /// <summary>
        /// 资源类型
        /// </summary>		
        private string _resourcetype;
        public string ResourceType
        {
            get { return _resourcetype; }
            set { _resourcetype = value; }
        }

    }
}


