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
                // Construim instrucțiunea SQL pentru a selecta toate cartile din baza de date
                sql = "Select * from CARTI";
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open(); // Deschidem conexiunea către baza de date utilizând obiectul OracleCommand

                OracleDataReader dataReader = command.ExecuteReader(); // Execută instrucțiunea SQL folosind ExecuteReader pentru a insera contul în baza de date

                List<Book> books = new List<Book>();

                while (dataReader.Read())
                {
                    // Citim valorile din rândul curent al rezultatelor și le asignăm variabilelor corespunzătoare
                    Book book = new Book(dataReader.GetInt32(0),
                                        dataReader.GetString(1),
                                        dataReader.GetString(2),
                                        dataReader.GetString(3),
                                        dataReader.GetInt32(4),
                                        dataReader.GetInt32(5));

                    books.Add(book); // Adaugam in lista de carti
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

                sql = "DELETE FROM CARTI WHERE isbn = '" + book.ISBN + "'"; // selecteaza toate cartile care au isbn-ul egal cu isbn-ul dat ca si parametru

                // Creăm un obiect OracleCommand pentru a executa instrucțiunea SQL
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open(); // Deschidem conexiunea către baza de date utilizând obiectul OracleCommand
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
                    " ' " + count +  "'); \n END;"; // insereaza in baza de date o carte care are valorile de mai sus

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
                    + "','" + book.Category + "'); \n END;"; // modifica cartea in baza de date

                OracleCommand command = new OracleCommand(sql, connection);
                command.Connection.Open();

                command.ExecuteReader();
            }
        }
        #endregion
    }
}
