using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_4
{
    public class DBconfig
    {
        public string DataSource { get; set; } = Environment.GetEnvironmentVariable("AZ_DATA_SOURCE");
        public string Catalog { get; set; } = Environment.GetEnvironmentVariable("AZ_DATA_CATALOG");
        public string Id { get; set; } = Environment.GetEnvironmentVariable("AZ_UID");
        public string Password { get; set; } = Environment.GetEnvironmentVariable("AZ_PASSWORD");
        //static string connectionString = "Data Source=calvinho2.database.windows.net;Initial Catalog=calvinho2;User ID=calvinho2@calvinho2;Password=Azure2abyz;";

        public string BuildConnectionString() => "Data Source=" + DataSource + ";Initial Catalog=" + Catalog + ";User ID=" + Id + ";Password=" + Password + ";";
    }
}