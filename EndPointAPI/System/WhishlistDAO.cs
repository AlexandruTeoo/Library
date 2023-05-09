using Oracle.ManagedDataAccess.Client;

namespace EndPointAPI.System
{
    public class WhishlistDAO
    {
        public static List<Whishlist> GetWhishlists ()
        {
            List<Whishlist> _whishlist = new List<Whishlist>();

            OracleConnection con = Database.GetConnection();

            OracleCommand command;
            OracleDataReader dataReader;
            String sql, Output = "";

            sql = "Select * from WHISHLIST";
            command = new OracleCommand(sql, con);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Whishlist whishlist = new Whishlist(dataReader.GetValue(0).ToString(),
                                    Convert.ToInt32(dataReader.GetValue(1)));
                _whishlist.Add(whishlist);
            }

            Database.ClosedConnection();

            return _whishlist;
        }
    }
}
