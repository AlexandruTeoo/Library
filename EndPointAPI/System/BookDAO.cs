using EndPointAPI;
using System;
using System.Reflection.Metadata.Ecma335;

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

        List<Book> _books = new List<Book>
        {
			//
        };
        return _books;
    }
}
