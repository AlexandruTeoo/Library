using Oracle.ManagedDataAccess.Client;

namespace EndPointAPI
{
    public class Database
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
