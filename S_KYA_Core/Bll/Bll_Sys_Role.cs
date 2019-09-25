using S_KYA_Common.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Dal;
using S_KYA_Core.Model;
using System.Collections;
using System.Data;

namespace S_KYA_Core.Bll
{
    public class Bll_Sys_Role
    {
        public static Bll_Sys_Role Instance
        {
            get { return SingletonProvider<Bll_Sys_Role>.Instance; }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet getSysRoleList(Hashtable ht, string order = null, Mod_Com_Pager pager = null)
        {
           return Dal_Sys_Role.Instance.GetList(ht, order, pager);
        }
        public bool Exists(int RoleId)
        {
            return Dal_Sys_Role.Instance.Exists(RoleId);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mod_Sys_Role model)
        {
            return Dal_Sys_Role.Instance.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_Sys_Role model)
        {
            return Dal_Sys_Role.Instance.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
        {
            return Dal_Sys_Role.Instance.Delete(RoleID);
        }
    }

}
