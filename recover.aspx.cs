using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class recover : System.Web.UI.Page
    {
        static logger myLogger = new logger();
        static DBManager myDBManager = new DBManager();

        static string myUid = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uid = myLogger.recover(un.Value, qn.Value, ans.Value);

            if (uid == null)
            {
                error.InnerText = "username, question, and answer combination did not match";
            }
            else
            {
                error.InnerText = "";
                tc.Visible = false;
                check.Visible = false;
                tp.Visible = true;
                cp.Visible = true;
                myUid = uid;
            }
        }

        protected void cp_Click(object sender, EventArgs e)
        {

            if ((string.IsNullOrWhiteSpace(pwd.Value)) || (string.IsNullOrWhiteSpace(rpwd.Value)) )
            {
                perror.InnerText = "fill out all entries";
                return;
            }

            if (pwd.Value != rpwd.Value)
            {
                perror.InnerText = "passwords not matching";
                return;
            }

            if(myLogger.changePassword(myUid, pwd.Value) == 1)
            {
                Server.Transfer("main.aspx", true);
            }
            else
            {
                perror.InnerText = "oops something went wrong";
            }
        }
    }
}