using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
namespace S_KYA_Common.ValidateCode
{
    public class Validate : IHttpHandler, IRequiresSessionState
    {
        public static bool Validation(string vcode)
        {
            if (HttpContext.Current.Session["__validatecodeimage"] != null)
            {
                return vcode.ToLower() == HttpContext.Current.Session["__validatecodeimage"].ToString().ToLower();
            }
            else
            {
                return false;
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            
        }
    }
}
