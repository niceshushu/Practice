using S_KYA_Common.Provider;
using S_KYA_Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Dal;
using System.Collections;

namespace S_KYA_Core.Bll
{
   public class Bll_Sys_Menu
    {
        public static Bll_Sys_Menu Instance
        {
            get { return SingletonProvider<Bll_Sys_Menu>.Instance; }
        }


        public bool Exists(int MenuId)
        {
            return Dal_Sys_Menu.Instance.Exists(MenuId);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mod_Sys_Menu model)
        {
            return Dal_Sys_Menu.Instance.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_Sys_Menu model)
        {
            return Dal_Sys_Menu.Instance.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MenuId)
        {
            return Dal_Sys_Menu.Instance.Delete(MenuId);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string MenuIdlist)
        {
            return Dal_Sys_Menu.Instance.DeleteList(MenuIdlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_Sys_Menu GetModel(int MenuId)
        {
            return Dal_Sys_Menu.Instance.GetModel(MenuId);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_Sys_Menu> GetList(Hashtable ht)
        {
            return Dal_Sys_Menu.Instance.GetList(ht);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return Dal_Sys_Menu.Instance.GetList(Top, strWhere, filedOrder);
        }
    }
}
