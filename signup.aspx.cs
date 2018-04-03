using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void su_Click(object sender, EventArgs e)
        {

            logger myLogger = new logger();

            if ((string.IsNullOrWhiteSpace(pwd.Value)) || (string.IsNullOrWhiteSpace(rpwd.Value)) || (string.IsNullOrWhiteSpace(un.Value)) || (string.IsNullOrWhiteSpace(qn.Value)) || (string.IsNullOrWhiteSpace(ans.Value)))
            {
                error.InnerText = "fill out all entries";
                return;
            }

            if (pwd.Value != rpwd.Value)
            {
                error.InnerText = "passwords not matching";
                return;
            }

            
            if(myLogger.signup(un.Value) != null)
            {
                error.InnerText = "username not available";
                return;
            }

            error.InnerText = "";

            myLogger.register(un.Value, pwd.Value, qn.Value, ans.Value);
            
            Server.Transfer("main.aspx", true);
        }
    }
}