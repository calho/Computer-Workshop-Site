using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class login : System.Web.UI.Page
    {
        static logger myLogger = new logger();
        static DBManager myDBManager = new DBManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void log_Click(object sender, EventArgs e)
        {
            string username = un.Value;
            string pass = pwd.Value;
            string uid = myLogger.login(username, pass);
            if (uid == null)
            {
                error.InnerText = "incorrect username and/or password";
            }
            else
            {
                error.InnerText = "";
                Session["uid"] = uid;
                Server.Transfer("main.aspx", true);
            }

        }
    }
}