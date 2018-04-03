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
    public class logger
    {

        DBconfig dbConfig;

        static string connectionString;

        static SqlConnection connection;

        public logger()
        {
            dbConfig = new DBconfig();
            connectionString = dbConfig.BuildConnectionString();
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection() => connection;

        public string login(string username, string password)
        {

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select id from TMA3_users where username = @username and password = @password";
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = cmd.ExecuteReader();
            string uid = null;

            while (reader.Read())
            {
                uid = reader[0].ToString();
            }
            connection.Close();
            return uid;
        }

        public string signup(string username)
        {

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select id from TMA3_users where username = @username";
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            string uid = null;

            while (reader.Read())
            {
                uid = reader.GetInt32(reader.GetOrdinal("id")).ToString();
            }
            connection.Close();
            return uid;
        }

        public void register(string username, string password, string question, string answer)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into TMA3_users(username, password, question, answer) values (@username, @password, @question, @answer)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public string recover(string username, string question, string answer)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select id from TMA3_users where username = @username and question = @question and answer = @answer";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);

            SqlDataReader reader = cmd.ExecuteReader();
            string uid = null;

            while (reader.Read())
            {
                uid = reader.GetInt32(reader.GetOrdinal("id")).ToString();
            }
            connection.Close();
            return uid;
        }

        public int changePassword(string id, string password)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update TMA3_users set password = @password where id = @id";
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", id);
            int users = cmd.ExecuteNonQuery();
            
            connection.Close();
            return users;
        }
    }
}