using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Database
    {
        public static OracleConnection con = null;

        private static void CreateConnection()
        {
            con = new OracleConnection();
            // create connection string using builder
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.Password = "STUDENT";
            ocsb.UserID = "STUDENT";
            ocsb.DataSource = "localhost:1521/XE";

            // connect
            con.ConnectionString = ocsb.ConnectionString;
            con.Open();
            MessageBox.Show("Connection Open!");
        }

        public static OracleConnection GetConnection()
        {
            if(con == null) 
            {
                CreateConnection();
            }
            return con;
        }

        public static void ClosedConnection()
        {
            con.Close();
            MessageBox.Show("Connection Closed!");
            con = null;
        }
    }
}
