using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Part_4
{
    public partial class feedback : System.Web.UI.Page
    {

        string connectionString = "Data Source=calvinho2.database.windows.net;Initial Catalog=calvinho2;User ID=calvinho2@calvinho2;Password=Azure2abyz;";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select date, name, fb from feedback order by date DESC;", connection);
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            try
            {
                GridView1.HeaderRow.Cells[2].Text = "feedback";
            }
            catch (Exception nex)
            {

            }

            connection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if ((String.IsNullOrWhiteSpace(name.Text)) || (string.IsNullOrWhiteSpace(fb.Text)))
            {
                error.InnerText = "Please fill in both name and feedback";
                return;
            }

            else if (fb.Text.Length > fb.MaxLength)
            {
                error.InnerText = "Max feedback characters is " + fb.MaxLength.ToString();
                return;
            }

            else if (name.Text.Length > name.MaxLength)
            {
                error.InnerText = "Max name characters is " + fb.MaxLength.ToString();
                return;
            }

            else
            {
                error.InnerText = String.Empty;
            }


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into feedback(date, name, fb) values (@date, @name, @fb)";
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@fb", fb.Text);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("select date, name, fb from feedback order by date DESC;", connection);

            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            try
            {
                GridView1.HeaderRow.Cells[2].Text = "feedback";
            }
            catch(Exception exc)
            {

            }

            connection.Close();

            error.InnerText = "Thank you for your feedback!";

            name.Text = String.Empty;
            fb.Text = String.Empty;

        }
    }
}