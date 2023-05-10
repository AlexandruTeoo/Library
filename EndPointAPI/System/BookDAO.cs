using EndPointAPI;
using System.Reflection.Metadata.Ecma335;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BookDAO
{
	public static List<Book> GetBooks() 
	{
		/*
		 1 se ia conexiunea cu bd
		2 se face select pe tabela cu carti
		3 se parcurge fiecare linie din raspuns
		4 pentru fiecare linie se creaza o carte
		5 se adauga cartea in lista 
		6 return lista
		 */

		List<Book> _books = new List<Book>();

        OracleConnection con = Database.GetConnection();

        OracleCommand command;
        OracleDataReader dataReader;
        String sql, Output = "";

        sql = "Select * from CARTI"; // retusat in Books
        command = new OracleCommand(sql, con);
        dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            Book book = new Book(dataReader.GetValue(0).ToString(),
                                dataReader.GetValue(1).ToString(),
                                dataReader.GetValue(2).ToString(),
                                Convert.ToInt32(dataReader.GetValue(3)),
                                Convert.ToInt32(dataReader.GetValue(4)),
                                Convert.ToInt32(dataReader.GetValue(5)));
            _books.Add(book);   
        }

        Database.ClosedConnection();

        return _books;
    }
}
