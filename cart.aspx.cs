using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Part_4
{
    public partial class cart : System.Web.UI.Page
    {
        DBManager myDBManger = new DBManager();

        protected void editB(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)sender;
            //MessageBox.Show((string)button.CommandArgument);
            Session["order"] = (string)button.CommandArgument;
            //Server.Transfer("build.aspx", true);
            Response.Redirect("build.aspx");
        }

        protected void removeB(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)sender;
            //MessageBox.Show((string)button.CommandArgument);
            myDBManger.removeOrder((string)button.CommandArgument);
            Response.Redirect("cart.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                ordersTable.Visible = true;
                uOrdertable.Visible = false;

                if (Request.Cookies["COMP"] != null)
                {
                    comp.InnerText = Server.HtmlEncode(Request.Cookies["COMP"]["item"]);
                    tp.InnerText = Server.HtmlEncode(Request.Cookies["COMP"]["price"]);
                }



                if (Request.Cookies["RAM"] != null)
                {
                    r.InnerText = Server.HtmlEncode(Request.Cookies["RAM"]["item"]);
                    rp.InnerText = Server.HtmlEncode(Request.Cookies["RAM"]["price"]);
                }


                if (Request.Cookies["HD"] != null)
                {
                    h.InnerText = Server.HtmlEncode(Request.Cookies["HD"]["item"]);
                    hp.InnerText = Server.HtmlEncode(Request.Cookies["HD"]["price"]);
                }


                if (Request.Cookies["CPU"] != null)
                {
                    c.InnerText = Server.HtmlEncode(Request.Cookies["CPU"]["item"]);
                    cp.InnerText = Server.HtmlEncode(Request.Cookies["CPU"]["price"]);
                }


                if (Request.Cookies["D"] != null)
                {
                    d.InnerText = Server.HtmlEncode(Request.Cookies["D"]["item"]);
                    dp.InnerText = Server.HtmlEncode(Request.Cookies["D"]["price"]);
                }


                if (Request.Cookies["OS"] != null)
                {
                    o.InnerText = Server.HtmlEncode(Request.Cookies["OS"]["item"]);
                    op.InnerText = Server.HtmlEncode(Request.Cookies["OS"]["price"]);
                }


                if (Request.Cookies["SC"] != null)
                {
                    s.InnerText = Server.HtmlEncode(Request.Cookies["SC"]["item"]);
                    sp.InnerText = Server.HtmlEncode(Request.Cookies["SC"]["price"]);
                }
            }
            else
            {
                ordersTable.Visible = false;
                uOrdertable.Visible = true;

                DBManager myDBManager = new DBManager();
                List<string> orders = myDBManager.getOrders(Session["uid"].ToString());

                for (int i = 0; i < orders.Count; i+=3)
                {
                    HtmlTableRow row = new HtmlTableRow();

                    HtmlTableRow totalRow = new HtmlTableRow();

                    HtmlTableRow buttonRow = new HtmlTableRow();

                    HtmlTableCell cell = new HtmlTableCell();
                    HtmlTableCell priceCell = new HtmlTableCell();
                    HtmlTableCell itemCell = new HtmlTableCell();

                    HtmlTableCell totalCell = new HtmlTableCell();
                    HtmlTableCell totalPriceCell = new HtmlTableCell();

                    HtmlTableCell editCell = new HtmlTableCell();
                    HtmlTableCell removeCell = new HtmlTableCell();

                    cell.InnerHtml = "computer:<br>RAM:<br>Hard Drive:<br>CPU:<br>Display:<br>OS:<br>Soundcard:";
                    itemCell.InnerHtml = orders[i];
                    priceCell.InnerHtml = orders[i+1];

                    totalCell.InnerHtml = "Total:";

                    string[] prices = Regex.Split(orders[i+1], "<br>");
                    List<string> pricesList = prices.ToList<string>();
                    pricesList.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                    List<int> pricesInt = pricesList.Select(int.Parse).ToList();                    
                    int totalPrice = pricesInt.Sum();
                    totalPriceCell.InnerHtml = totalPrice.ToString();

                    System.Web.UI.WebControls.Button edit = new System.Web.UI.WebControls.Button();
                    edit.ID = "edit"+orders[i+2];
                    edit.Text = "Edit";
                    edit.Click += new EventHandler(editB);
                    edit.CommandArgument = orders[i + 2];
                    editCell.Controls.Add(edit);

                    System.Web.UI.WebControls.Button remove = new System.Web.UI.WebControls.Button();
                    remove.ID = "remove"+orders[i+2];
                    remove.Text = "Remove";
                    remove.Click += new EventHandler(removeB);
                    remove.CommandArgument = orders[i + 2];
                    removeCell.Controls.Add(remove);

                    row.Cells.Add(cell);
                    row.Cells.Add(itemCell);
                    row.Cells.Add(priceCell);

                    totalRow.Cells.Add(new HtmlTableCell());
                    totalRow.Cells.Add(totalCell);
                    totalRow.Cells.Add(totalPriceCell);

                    buttonRow.Cells.Add(editCell);
                    buttonRow.Cells.Add(removeCell);

                    uOrdertable.Rows.Add(row);
                    uOrdertable.Rows.Add(totalRow);
                    uOrdertable.Rows.Add(buttonRow);
                    uOrdertable.Rows.Add(new HtmlTableRow());
                }

            }




        }
    }
}