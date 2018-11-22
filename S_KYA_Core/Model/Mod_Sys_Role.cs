using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    public class Mod_Sys_Role
    {	
        private int _roleid;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get => _roleName; set => _roleName = value; }

        private string _roleName;
    }
}
