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

namespace EndPointAPI
{
    public class Database
    {
        public static OracleConnection con = null;


        private static string GetConnectionString()
        {
            //String connString = "host=localhost:1521;database=XE;uid=STUDENT;pwd=STUDENT";
            //"User Id=<username>;Password=<password>;Data Source=<datasource>"

            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.Password = "STUDENT";
            ocsb.ConnectionTimeout = 1000;
            ocsb.UserID = "STUDENT";
            ocsb.DataSource = "localhost:1521/XE";
            //return ocsb.ConnectionString;
            return ocsb.ConnectionString;
        }

        private static void CreateConnection()
        {
            con = new OracleConnection();

            // connect
            con.ConnectionString = GetConnectionString();
            con.Open();
            Console.WriteLine("Connection established (" + con.ServerVersion + ")");
        }

        public static OracleConnection GetConnection()
        {
            if (con == null)
            {
                CreateConnection();
            }
            return con;
        }

        public static void ClosedConnection()
        {
            con.Close();
            con = null;
        }
    }
}
