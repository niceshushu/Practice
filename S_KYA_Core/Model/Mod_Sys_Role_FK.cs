using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    public partial class Mod_Sys_Role
    {
        /// <summary>
        /// 
        /// </summary>
        public string RoleStatusName { get => _roleStatusName; set => _roleStatusName = value; }
        private string _roleStatusName;
    }
}
