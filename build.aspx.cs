using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Part_4
{
    public partial class build : System.Web.UI.Page
    {
        static string orderID = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            DBManager myDBManager = new DBManager();

            List<DropDownList> dlist = new List<DropDownList>();

            dlist.Add(DropDownList1);
            dlist.Add(DropDownList2);
            dlist.Add(DropDownList3);
            dlist.Add(DropDownList4);
            dlist.Add(DropDownList5);
            dlist.Add(DropDownList6);
            dlist.Add(DropDownList7);

            List<DropDownList> cdlist = new List<DropDownList>();

            cdlist.Add(DropDownList2);
            cdlist.Add(DropDownList3);
            cdlist.Add(DropDownList4);
            cdlist.Add(DropDownList5);
            cdlist.Add(DropDownList6);
            cdlist.Add(DropDownList7);


            if (!IsPostBack)
            {
                orderID = null;

                //MessageBox.Show("!postback");
                myDBManager.fillDropDownList(DropDownList1, "COMP");
                myDBManager.fillDropDownList(DropDownList2, "RAM");
                myDBManager.fillDropDownList(DropDownList3, "HD");
                myDBManager.fillDropDownList(DropDownList4, "CPU");
                myDBManager.fillDropDownList(DropDownList5, "D");
                myDBManager.fillDropDownList(DropDownList6, "OS");
                myDBManager.fillDropDownList(DropDownList7, "SC");

                if (Session["order"] != null)
                {
                    myDBManager.setEdit(dlist, Session["order"].ToString());
                    orderID = Session["order"].ToString();
                    Session["order"] = null;
                    //MessageBox.Show(orderID);

                }
                else
                {
                    myDBManager.setDefault(cdlist, "1");

                }

            }




            if (IsPostBack)

            {

                string controlID = Page.Request.Params["__EVENTTARGET"];

                System.Web.UI.Control postbackControl = Page.FindControl(controlID);

                string HTMLid = postbackControl.ClientID;

                if (HTMLid == "DropDownList1")
                {

                    string comp = DropDownList1.SelectedValue;

                    myDBManager.setDefault(cdlist, comp);

                    
                    
                }

            }
            

            ram.InnerText = DropDownList2.SelectedItem.Text.ToString() + ":";
            ramp.InnerText = myDBManager.getItemPrice(DropDownList2.SelectedValue).ToString();
            int r = 0;
            Int32.TryParse(ramp.InnerText, out r);

            hd.InnerText = DropDownList3.SelectedItem.Text.ToString() + ":";
            hdp.InnerText = myDBManager.getItemPrice(DropDownList3.SelectedValue).ToString();
            int h = 0;
            Int32.TryParse(hdp.InnerText, out h);

            cpu.InnerText = DropDownList4.SelectedItem.Text.ToString() + ":";
            cpup.InnerText = myDBManager.getItemPrice(DropDownList4.SelectedValue).ToString();
            int c = 0;
            Int32.TryParse(cpup.InnerText, out c);

            d.InnerText = DropDownList5.SelectedItem.Text.ToString() + ":";
            dp.InnerText = myDBManager.getItemPrice(DropDownList5.SelectedValue).ToString();
            int dpp = 0;
            Int32.TryParse(dp.InnerText, out dpp);

            os.InnerText = DropDownList6.SelectedItem.Text.ToString() + ":";
            osp.InnerText = myDBManager.getItemPrice(DropDownList6.SelectedValue).ToString();
            int o = 0;
            Int32.TryParse(osp.InnerText, out o);

            sc.InnerText = DropDownList7.SelectedItem.Text.ToString() + ":";
            scp.InnerText = myDBManager.getItemPrice(DropDownList7.SelectedValue).ToString();
            int s = 0;
            Int32.TryParse(scp.InnerText, out s);

            int totp = r + h + c + dpp + o + s;

            tot.InnerText = totp.ToString();



        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if(Session["uid"] == null)
            {
                HttpCookie coc = Request.Cookies["COMP"];
                if (coc == null)
                {
                    coc = new HttpCookie("COMP");
                }
                coc.Values["item"] = DropDownList1.SelectedItem.Text.ToString();
                coc.Values["price"] = tot.InnerText;
                coc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(coc);

                HttpCookie ramc = Request.Cookies["RAM"];
                if (ramc == null)
                {
                    ramc = new HttpCookie("RAM");
                }
                ramc.Values["item"] = DropDownList2.SelectedItem.Text.ToString();
                ramc.Values["price"] = DropDownList2.SelectedValue.ToString();
                ramc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(ramc);

                HttpCookie hdc = Request.Cookies["HD"];
                if (hdc == null)
                {
                    hdc = new HttpCookie("HD");
                }
                hdc.Values["item"] = DropDownList3.SelectedItem.Text.ToString();
                hdc.Values["price"] = DropDownList3.SelectedValue.ToString();
                hdc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(hdc);

                HttpCookie cpuc = Request.Cookies["CPU"];
                if (cpuc == null)
                {
                    cpuc = new HttpCookie("CPU");
                }
                cpuc.Values["item"] = DropDownList4.SelectedItem.Text.ToString();
                cpuc.Values["price"] = DropDownList4.SelectedValue.ToString();
                cpuc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cpuc);

                HttpCookie dc = Request.Cookies["D"];
                if (dc == null)
                {
                    dc = new HttpCookie("D");
                }
                dc.Values["item"] = DropDownList5.SelectedItem.Text.ToString();
                dc.Values["price"] = DropDownList5.SelectedValue.ToString();
                dc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(dc);

                HttpCookie osc = Request.Cookies["OS"];
                if (osc == null)
                {
                    osc = new HttpCookie("OS");
                }
                osc.Values["item"] = DropDownList6.SelectedItem.Text.ToString();
                osc.Values["price"] = DropDownList6.SelectedValue.ToString();
                osc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(osc);

                HttpCookie scc = Request.Cookies["SC"];
                if (scc == null)
                {
                    scc = new HttpCookie("SC");
                }
                scc.Values["item"] = DropDownList7.SelectedItem.Text.ToString();
                scc.Values["price"] = DropDownList7.SelectedValue.ToString();
                scc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(scc);
            }

            else
            {
                DBManager myDBManager = new DBManager();

                List<DropDownList> dlist = new List<DropDownList>();

                dlist.Add(DropDownList1);
                dlist.Add(DropDownList2);
                dlist.Add(DropDownList3);
                dlist.Add(DropDownList4);
                dlist.Add(DropDownList5);
                dlist.Add(DropDownList6);
                dlist.Add(DropDownList7);

                if (orderID != null)
                {
                    myDBManager.saveOrder(dlist, Session["uid"].ToString(), orderID);
                }
                else
                {
                    myDBManager.saveOrder(dlist, Session["uid"].ToString());

                }
            }


            Response.Redirect("cart.aspx");

        }
    }
}