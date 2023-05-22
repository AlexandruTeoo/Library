using Oracle.ManagedDataAccess.Client;

namespace EndPointAPI.System
{
    public class WishlistDAO
    {
        public static List<Wishlist> GetWishlist ()
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from WISHLIST";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    List<Wishlist> wishlist = new List<Wishlist>();

                    while (dataReader.Read())
                    {
                        Wishlist book = new Wishlist(
                            dataReader.GetString(0),
                            dataReader.GetInt32(1)
                        );

                        wishlist.Add(book);
                    }
                    return wishlist;
                }
                return null;
            }
        }

        public static List<Wishlist> GetWishlistByAcc(int accountId)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from WISHLIST WHERE account_id = '" + accountId + "'";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    List<Wishlist> wishlist = new List<Wishlist>();

                    while (dataReader.Read())
                    {
                        Wishlist loan = new Wishlist(
                            dataReader.GetString(0),
                            dataReader.GetInt32(1)
                        );

                        wishlist.Add(loan);
                    }
                    return wishlist;
                }
                return null;
            }
        }

        public static int AddBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "CREATE OR REPLACE PROCEDURE insert_wishlist(" +
                                                wishlist._accountId + "," +
                                                wishlist._isbn + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.GetInt32(1) == null)
                    {
                        return -1; // acc not found -> trebuie verificat cu loan._accountId in sql??
                    }
                    return 0;
                }
                return -2;
            }
        }

        public static void DeleteBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "CREATE OR REPLACE PROCEDURE delete_wishlist(" +
                                                wishlist._wishlistId + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                //command.Connection.Open();
                //OracleDataReader dataReader = command.ExecuteReader();
            }
        }
    }
}
