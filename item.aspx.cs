using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_4
{
    public partial class item : System.Web.UI.Page
    {

        string connectionString = "Data Source=calvinho2.database.windows.net;Initial Catalog=calvinho2;User ID=calvinho2@calvinho2;Password=Azure2abyz;";

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Component> componentList = new List<Component>();
            DBManager myDBManger = new DBManager();

            componentList = myDBManger.getComponents();

            string myName = Request.QueryString["itemname"];

            Component myComponent = componentList.Find(c => c.Name == myName);

            string image = "<img src = " + myComponent.Url + " alt = " + myComponent.Description + " > ";
            string name = "<p>" + myComponent.Name + "</p>";
            string description = "<p>" + myComponent.Description + "</p>";
            string price = "<p>$" + myComponent.Price + "</p>";
            itemProfile.InnerHtml = image + name + description + price;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select date, name, score, review from TMA3_reviews where item = @item order by date DESC;";
            cmd.Parameters.AddWithValue("@item", myName);

            connection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            cmd.Parameters.Clear();
            cmd.CommandText = "select avg(score) score from TMA3_reviews where item = @item;";
            cmd.Parameters.AddWithValue("@item", myName);

            SqlDataReader reader = cmd.ExecuteReader();
            string avgScore = null;
            while (reader.Read())
            {
                avgScore = reader[0].ToString();

            }

            scoreText.InnerHtml = "<p>" + avgScore + "/5.0</p>";

            connection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if ((String.IsNullOrWhiteSpace(name.Text)) || (string.IsNullOrWhiteSpace(review.Text)))
            {
                error.InnerText = "Please fill in both name and review";
                return;
            }

            else if (review.Text.Length > review.MaxLength)
            {
                error.InnerText = "Max review characters is " + review.MaxLength.ToString();
                return;
            }
            else if (name.Text.Length > name.MaxLength)
            {
                error.InnerText = "Max name characters is " + review.MaxLength.ToString();
                return;
            }
            else
            {
                error.InnerText = String.Empty;
            }

            string myName = Request.QueryString["itemname"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into TMA3_reviews(item, date, name, review, score) values (@item, @date, @name, @review, @score)";
            cmd.Parameters.AddWithValue("@item", myName);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@review", review.Text);
            cmd.Parameters.AddWithValue("@score", score.SelectedValue);
            cmd.ExecuteNonQuery();

            cmd = connection.CreateCommand();
            cmd.CommandText = "select date, name, score, review from TMA3_reviews where item = @item order by date DESC;";
            cmd.Parameters.AddWithValue("@item", myName);

            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            cmd.Parameters.Clear();
            cmd.CommandText = "select avg(score) score from TMA3_reviews where item = @item;";
            cmd.Parameters.AddWithValue("@item", myName);

            SqlDataReader reader = cmd.ExecuteReader();
            string avgScore = null;
            while (reader.Read())
            {
                avgScore = reader[0].ToString();

            }

            scoreText.InnerHtml = "<p>" + avgScore + "/5.0</p>";

            connection.Close();

            error.InnerText = "Thank you for your feedback!";

            name.Text = String.Empty;
            review.Text = String.Empty;

        }
    }
}