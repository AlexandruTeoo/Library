/**************************************************************************
 *                                                                        *
 *  File:        WishlistLibrary.dll                                               *
 *  Copyright:   (c) 2023, Florin Leon                                    *
 *  E-mail:      florin.leon@academic.tuiasi.ro                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.html             *
 *  Description: WishlistDAO ()                                          *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using DatabaseLibrary;

namespace WishlistLibrary
{
    public class WishlistDAO
    {
        #region GetWishlist
        public static List<Book> GetWishlist(int accountId)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "SELECT * FROM CARTI c JOIN WISHLIST w ON w.carte_isbn = c.isbn WHERE w.account_id ='" + accountId + "'"; // afiseaza cartile din wishlist

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                List<Book> books = new List<Book>();

                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetInt32(0),
                                        dataReader.GetString(1),
                                        dataReader.GetString(2),
                                        dataReader.GetString(3),
                                        dataReader.GetInt32(4),
                                        dataReader.GetInt32(5));

                    books.Add(book);
                }
                return books;
            }
        }
        #endregion
        #region AddBookWishlist
        public static void AddBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "BEGIN \n insert_wishlist(" +
                        wishlist.AccountId + "," +
                        wishlist.ISBN + "); \n END;"; // insereaza in wishlist isbn-ul cartii si id-ul utilizatorului care o doreste

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                command.ExecuteReader();
            }
        }
        #endregion
        #region DeleteBookWishlist
        public static void DeleteBookWishlist(Wishlist wishlist)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "DELETE FROM WISHLIST WHERE account_id ='" + wishlist.AccountId + "' AND carte_isbn = '" + wishlist.ISBN + "'"; // sterge din wishlist cartea

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                command.ExecuteReader();
            }
        }
        #endregion
    }
}
