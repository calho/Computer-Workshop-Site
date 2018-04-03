using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["uid"] != null)
            {
                ls.InnerText = "Sign Out";
                ls.HRef = "~/logout";
            }
            else
            {
                ls.InnerText = "Login";
                ls.HRef = "~/login";
            }
        }
    }
}