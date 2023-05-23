using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class WishlistDAO
    {
        public static List<Wishlist> GetWishlist(int accountId)
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

        public static void AddBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "BEGIN \n insert_wishlist(" +
                        wishlist._accountId + "," +
                        wishlist._isbn + "); \n END;";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                command.ExecuteReader();
            }
        }

        public static void DeleteBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "delete_wishlist(" + wishlist._wishlistId + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                command.ExecuteReader();
            }
        }
    }
}
