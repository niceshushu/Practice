using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S_KYA.CommonPage
{
    public partial class ErrPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litMsg.Text = Session["errMsg"] == null ? "对不起，有错误发生！" : Session["errMsg"].ToString();
        }
    }
}