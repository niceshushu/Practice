using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
namespace S_KYA_Core.Model
{
    // 用户表
    public class Mod_Sys_User: BaseSession
    {
        /// <summary>
        /// 主键ID
        /// </summary>		
        private int _userid;
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>		
        private string _password;
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// RoleId
        /// </summary>		
        private int _roleid;
        public int RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        /// <summary>
        /// 掩码
        /// </summary>		
        private string _passsalt;

        [JsonIgnore]
        public string PassSalt
        {
            get { return _passsalt; }
            set { _passsalt = value; }
        }
       
        /// <summary>
        /// 是否启用
        /// </summary>		
        private bool _isdisabled;
        public bool IsDisabled
        {
            get { return _isdisabled; }
            set { _isdisabled = value; }
        }

        public override string ServerID => UserId.ToString()+"_"+PassWord.ToString();
    }
}

