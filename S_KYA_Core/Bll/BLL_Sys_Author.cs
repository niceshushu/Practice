using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Common.Data.SqlServer;
using S_KYA_Common.Provider;
using S_KYA_Core.Dal;
using S_KYA_Core.Model;

namespace S_KYA_Core.Bll
{
    public class Bll_Sys_Author
    {
        public static Bll_Sys_Author Instance
        {
            get { return SingletonProvider<Bll_Sys_Author>.Instance; }
        }
        public List<Mod_Sys_Author> GetList(Hashtable ht, string order, Mod_Com_Pager pager = null)
        {
            return Dal_Sys_Author.Instance.GetList(ht, order, pager);
        }
        public List<Mod_Sys_Author> GetList(Hashtable ht)
        {
            return Dal_Sys_Author.Instance.GetList(ht);
        }
    }
}
