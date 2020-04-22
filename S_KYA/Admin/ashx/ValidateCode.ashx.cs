using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using S_KYA_Common.ValidateCode;
namespace S_KYA
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode :  KA_BasePage
    {

        public override void ProcessRequest(HttpContext context)
        {
            BuildCode(context);
        }

        public  bool IsReusable
        {
            get
            {
                return false;
            }
        }
         /// <summary>
         /// 验证码生成
         /// </summary>
        private void BuildCode(HttpContext context)
        {
            QqValidateCode qqValidate = new QqValidateCode();
            qqValidate.CreateImage(context);
        }
    }
}