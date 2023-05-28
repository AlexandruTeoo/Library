/**************************************************************************
 *                                                                        *
 *  File:        BookLibrary.dll                                          *
 *  Copyright:   (c) 2023, Alexandru-Teodor Atanase                       *
 *  E-mail:      alexandru-teodor.atanase@student.tuiasi.ro               *
 *  Website:     https://github.com/AlexandruTeoo/IP-Projec               *
 *  Description: BookDAO.cs ()                                            *
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
using DatabaseLibrary;

namespace BookLibrary
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
        #region GetBook
        public static Book GetBook(string title, string author)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql, Output = "";
                // Construim instrucțiunea SQL pentru a selecta toate cartile din baza de date
                sql = "Select * from CARTI WHERE titlu = '" + title + "' AND autor = '" + author + "'";
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open(); // Deschidem conexiunea către baza de date utilizând obiectul OracleCommand

                OracleDataReader dataReader = command.ExecuteReader(); // Execută instrucțiunea SQL folosind ExecuteReader pentru a insera contul în baza de date

                if (dataReader.Read())
                {
                    // Citim valorile din rândul curent al rezultatelor și le asignăm variabilelor corespunzătoare
                    Book book = new Book(dataReader.GetInt32(0),
                                        dataReader.GetString(1),
                                        dataReader.GetString(2),
                                        dataReader.GetString(3),
                                        dataReader.GetInt32(4),
                                        dataReader.GetInt32(5));
                    Console.WriteLine(book);
                    return book;
                }
                return null;
            }
        }
        #endregion
        #region DeleteBook
        public static void DeleteBook(Book book)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "BEGIN \n delete_book('" + book.ISBN + "'); \n END;"; // selecteaza toate cartile care au isbn-ul egal cu isbn-ul dat ca si parametru

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
        public static void ModifyBook(Book book)
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
