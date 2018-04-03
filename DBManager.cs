using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Part_4
{
    public class DBManager
    {
        DBconfig dbConfig;

        static string connectionString;

        static SqlConnection connection;

        public DBManager()
        {
            dbConfig = new DBconfig();
            connectionString = dbConfig.BuildConnectionString();
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection() => connection;


        public void fillDropDownList(DropDownList list, string type)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select item, id from TMA3_components where type = @type;";
                cmd.Parameters.AddWithValue("@type", type);

                list.DataSource = cmd.ExecuteReader();
                list.DataTextField = "item";
                list.DataValueField = "id";
                list.DataBind();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public double getItemPrice(string id)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select price from TMA3_components where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            double price = 0;

            while (reader.Read())
            {
                price = reader.GetDouble(reader.GetOrdinal("price"));
            }
            connection.Close();
            return price;

        }

        public void setDefault(List<DropDownList> dlist, string id)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from TMA3_default where itemID = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dlist[0].SelectedValue = reader.GetInt32(reader.GetOrdinal("RAM")).ToString();
                dlist[1].SelectedValue = reader.GetInt32(reader.GetOrdinal("HD")).ToString();
                dlist[2].SelectedValue = reader.GetInt32(reader.GetOrdinal("CPU")).ToString();
                dlist[3].SelectedValue = reader.GetInt32(reader.GetOrdinal("D")).ToString();
                dlist[4].SelectedValue = reader.GetInt32(reader.GetOrdinal("OS")).ToString();
                dlist[5].SelectedValue = reader.GetInt32(reader.GetOrdinal("SC")).ToString();
            }
            connection.Close();
        }

        public void saveOrder(List<DropDownList> dlist, string uid, string oid = null)
        {
            if (oid != null)
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update TMA3_orders set COMP = @COMP,RAM = @RAM,HD = @HD,CPU = @CPU,D = @D,OS = @OS,SC = @SC where id = @id and uid = @uid";
                cmd.Parameters.AddWithValue("@UID", uid);
                cmd.Parameters.AddWithValue("@COMP", dlist[0].SelectedValue);
                cmd.Parameters.AddWithValue("@RAM", dlist[1].SelectedValue);
                cmd.Parameters.AddWithValue("@HD", dlist[2].SelectedValue);
                cmd.Parameters.AddWithValue("@CPU", dlist[3].SelectedValue);
                cmd.Parameters.AddWithValue("@D", dlist[4].SelectedValue);
                cmd.Parameters.AddWithValue("@OS", dlist[5].SelectedValue);
                cmd.Parameters.AddWithValue("@SC", dlist[6].SelectedValue);
                cmd.Parameters.AddWithValue("@id", oid);

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            else
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into TMA3_orders(UID,COMP,RAM,HD,CPU,D,OS,SC) values (@UID, @COMP, @RAM, @HD, @CPU, @D, @OS, @SC)";
                cmd.Parameters.AddWithValue("@UID", uid);
                cmd.Parameters.AddWithValue("@COMP", dlist[0].SelectedValue);
                cmd.Parameters.AddWithValue("@RAM", dlist[1].SelectedValue);
                cmd.Parameters.AddWithValue("@HD", dlist[2].SelectedValue);
                cmd.Parameters.AddWithValue("@CPU", dlist[3].SelectedValue);
                cmd.Parameters.AddWithValue("@D", dlist[4].SelectedValue);
                cmd.Parameters.AddWithValue("@OS", dlist[5].SelectedValue);
                cmd.Parameters.AddWithValue("@SC", dlist[6].SelectedValue);

                cmd.ExecuteNonQuery();

                connection.Close();
            }

        }

        public List<string> getOrders(string uid)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select c0.item comp, c1.item r, c1.price rp, c2.item h, c2.price hp, c3.item c, c3.price cp, " +
                "c4.item d, c4.price dp, c5.item os, c5.price osp, c6.item s, c6.price sp, o.id oid  from " +
                "TMA3_orders o, tma3_components c0, tma3_components c1, tma3_components c2, tma3_components c3, tma3_components c4, " +
                "tma3_components c5, tma3_components c6 " +
                "where uid = @uid and c0.id = o.COMP and c1.id = o.RAM and c2.id = o.HD and c3.id = o.CPU and c4.id = o.D and c5.id = o.OS and c6.id = o.SC; ";

            cmd.Parameters.AddWithValue("@uid", uid);

            SqlDataReader reader = cmd.ExecuteReader();
            List<string> orders = new List<string>();

            while (reader.Read())
            {
                string orderItems = reader.GetString(reader.GetOrdinal("comp")) + "<br>" + reader.GetString(reader.GetOrdinal("r")) + "<br>" + reader.GetString(reader.GetOrdinal("h")) + "<br>" + reader.GetString(reader.GetOrdinal("c")) + "<br>" + reader.GetString(reader.GetOrdinal("d")) + "<br>" + reader.GetString(reader.GetOrdinal("os")) + "<br>" + reader.GetString(reader.GetOrdinal("s"));
                string orderPrices = "<br>" + reader.GetDouble(reader.GetOrdinal("rp")) + "<br>" + reader.GetDouble(reader.GetOrdinal("hp")) + "<br>" + reader.GetDouble(reader.GetOrdinal("cp")) + "<br>" + reader.GetDouble(reader.GetOrdinal("dp")) + "<br>" + reader.GetDouble(reader.GetOrdinal("osp")) + "<br>" + reader.GetDouble(reader.GetOrdinal("sp"));
                orders.Add(orderItems);
                orders.Add(orderPrices);
                orders.Add(reader.GetInt32(reader.GetOrdinal("oid")).ToString());
            }

            connection.Close();
            return orders;
        }

        public void removeOrder(string oid)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "delete from TMA3_orders where id = @id ";
            cmd.Parameters.AddWithValue("@id", oid);
            //MessageBox.Show(cmd.CommandText);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void setEdit(List<DropDownList> dlist, string oid)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from TMA3_orders where id = @id;";
            cmd.Parameters.AddWithValue("@id", oid);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dlist[0].SelectedValue = reader.GetInt32(reader.GetOrdinal("COMP")).ToString();
                dlist[1].SelectedValue = reader.GetInt32(reader.GetOrdinal("RAM")).ToString();
                dlist[2].SelectedValue = reader.GetInt32(reader.GetOrdinal("HD")).ToString();
                dlist[3].SelectedValue = reader.GetInt32(reader.GetOrdinal("CPU")).ToString();
                dlist[4].SelectedValue = reader.GetInt32(reader.GetOrdinal("D")).ToString();
                dlist[5].SelectedValue = reader.GetInt32(reader.GetOrdinal("OS")).ToString();
                dlist[6].SelectedValue = reader.GetInt32(reader.GetOrdinal("SC")).ToString();
            }
            connection.Close();
        }

        public List<Component> getComponents()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from TMA3_components where description <> ''";

            SqlDataReader reader = cmd.ExecuteReader();

            List<Component> componentList = new List<Component>();

            while (reader.Read())
            {
                string url = reader.GetString(reader.GetOrdinal("url")).ToString();
                string name = reader.GetString(reader.GetOrdinal("item")).ToString();
                string description = reader.GetString(reader.GetOrdinal("description")).ToString();
                string price = reader.GetDouble(reader.GetOrdinal("price")).ToString();
                string type = reader.GetString(reader.GetOrdinal("type")).ToString();
                componentList.Add(new Component(url, name, description, price, type));
            }

            connection.Close();

            return componentList;
        }


    }
}