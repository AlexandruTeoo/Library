using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class BookDAO
    {
        #region GetBooks
        public static List<Book> GetBooks()
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql, Output = "";
                sql = "Select * from CARTI";
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
                Console.WriteLine(books);
                return books;
            }
        }
        #endregion
        #region DeleteBook
        public static void DeleteBook(Book book)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "DELETE FROM CARTI WHERE isbn = '" + book.ISBN + "'";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                command.ExecuteReader();
            }
        }
        #endregion
        #region InsertBook
        public static void InsertBook(Book book, int count)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "BEGIN \n insert_carte('" + book.Title + "', '" + book.Author + "', '" + book.Category + "'," +
                    " ' " + count +  "'); \n END;";

                OracleCommand command = new OracleCommand(sql, connection);
                command.Connection.Open();

                command.ExecuteReader();
            }
        }
        #endregion
        #region ModifyBook
        public static void  ModifyBook(Book book)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "BEGIN \n modificare_carte('" + book.ISBN 
                    + "', '" + book.Title 
                    + "', '" + book.Author 
                    + "','" + book.Category + "'); \n END;";

                OracleCommand command = new OracleCommand(sql, connection);
                command.Connection.Open();

                command.ExecuteReader();
            }
        }
        #endregion
    }
}
