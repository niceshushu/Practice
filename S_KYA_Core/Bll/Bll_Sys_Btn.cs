using S_KYA_Common.Provider;
using S_KYA_Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Core.Dal;

namespace S_KYA_Core.Bll
{
    public class Bll_Sys_Btn
    {
        public static Bll_Sys_Btn Instance
        {
            get { return SingletonProvider<Bll_Sys_Btn>.Instance; }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<Mod_Sys_Btn> getSysBtnList(Hashtable ht, string order = null, Mod_Com_Pager pager = null)
        {
            return Dal_Sys_Btn.Instance.GetList(ht, order, pager);
        }
    }
}
