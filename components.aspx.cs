using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class components : System.Web.UI.Page
    {

        static DBManager myDBManager = new DBManager();
        static List<Component> componentList = new List<Component>();
        static List<Component> filteredList = new List<Component>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!componentList.Any())
                {
                    componentList = myDBManager.getComponents();
                }

                filteredList = componentList;
                int counter = 0;
                HtmlTableRow row = new HtmlTableRow();

                foreach (Component myComponent in componentList)
                {

                    if (counter % 3 == 0)
                    {
                        row = new HtmlTableRow();
                    }

                    HtmlTableCell first = new HtmlTableCell();
                    string image = "<img src = " + myComponent.Url + " alt = " + myComponent.Description + " style='width: 200px; height: 200px;'> ";
                    string name = "<p><a runat='server' href='item.aspx?itemname=" + myComponent.Name + "'>" + myComponent.Name + "</a></p>";
                    string price = "<p>$" + myComponent.Price + "</p>";
                    first.InnerHtml = image + name + price;
                    row.Cells.Add(first);
                    componentTable.Rows.Add(row);
                    counter += 1;
                }
            }
        }

        protected void order_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.RadioButton myRadio = (System.Web.UI.WebControls.RadioButton)sender;
            string order = myRadio.ID;
            //MessageBox.Show(order);
            componentTable.Rows.Clear();
            List<Component> orderedList = filteredList;
            switch (order)
            {
                case "asce":
                    orderedList = filteredList.OrderBy(c => Int32.Parse(c.Price)).ToList();
                    break;
                case "desc":
                    orderedList = filteredList.OrderByDescending(c => Int32.Parse(c.Price)).ToList();
                    break;
                case "na":
                    orderedList = filteredList.OrderBy(c => c.Name).ToList();
                    break;
                default:
                    break;

            }


            //MessageBox.Show(orderedList.Count.ToString());

            int counter = 0;
            HtmlTableRow row = new HtmlTableRow();

            foreach (Component myComponent in orderedList)
            {

                if (counter % 3 == 0)
                {
                    row = new HtmlTableRow();
                }

                HtmlTableCell first = new HtmlTableCell();
                string image = "<img src = " + myComponent.Url + " alt = " + myComponent.Description + " style='width: 200px; height: 200px;'> ";
                string name = "<p><a runat='server' href='item.aspx?itemname=" + myComponent.Name + "'>" + myComponent.Name + "</a></p>";
                string price = "<p>$" + myComponent.Price + "</p>";
                first.InnerHtml = image + name + price;
                row.Cells.Add(first);
                componentTable.Rows.Add(row);
                counter += 1;
            }

        }

        protected void filter_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox filter = (System.Web.UI.WebControls.CheckBox)sender;
            string order = filter.ID;
            componentTable.Rows.Clear();
            filteredList = new List<Component>();

            if (ram.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "RAM").ToList());
            }
            if (hd.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "HD").ToList());
            }
            if (cpu.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "CPU").ToList());
            }
            if (dis.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "D").ToList());
            }
            if (os.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "OS").ToList());
            }
            if (sc.Checked)
            {
                filteredList.AddRange(componentList.Where(c => c.Type == "SC").ToList());
            }
            all.Checked = false;

            List<System.Web.UI.WebControls.RadioButton> radioList = new List<System.Web.UI.WebControls.RadioButton>();
            radioList.Add(nonebox);
            radioList.Add(asce);
            radioList.Add(desc);
            radioList.Add(na);

            System.Web.UI.WebControls.RadioButton checkedButton = radioList.FirstOrDefault(r => r.Checked);
            order_CheckedChanged(checkedButton, null);
        }

        protected void all_CheckedChanged(object sender, EventArgs e)
        {
            ram.Checked = false;
            hd.Checked = false;
            cpu.Checked = false;
            dis.Checked = false;
            os.Checked = false;
            sc.Checked = false;

            filteredList = componentList;

            List<System.Web.UI.WebControls.RadioButton> radioList = new List<System.Web.UI.WebControls.RadioButton>();
            radioList.Add(nonebox);
            radioList.Add(asce);
            radioList.Add(desc);
            radioList.Add(na);

            System.Web.UI.WebControls.RadioButton checkedButton = radioList.FirstOrDefault(r => r.Checked);
            order_CheckedChanged(checkedButton, null);
        }
    }
}