using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_KYA_Common.Provider;
using S_KYA_Core.Model;
using System.Data;
namespace S_KYA_Core.Dal
{
    public class DAL_Sys_Author
    {
        public static DAL_Sys_Author Instance
        {
            get { return SingletonProvider<DAL_Sys_Author>.Instance; }
        }


    }
}
