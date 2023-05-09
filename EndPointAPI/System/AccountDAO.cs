using EndPointAPI;
using System;

public class AccountDAO
{
    public static List<Account> GetAccounts()
    {
        /*
		 1 se ia conexiunea cu bd
		2 se face select pe tabela cu carti
		3 se parcurge fiecare linie din raspuns
		4 pentru fiecare linie se creaza o carte
		5 se adauga cartea in lista 
		6 return lista
		 */

        /*Account a = new Account();
        a.Id = 1;*/

        List<Account> _accounts = new List<Account>
        {
            //
        };
        return _accounts;
    }

    public int lastId ()
    {
        //"SELECT MAX(ACCOUNT_ID) FROM ACCOUNT"
        return 2; // return nr de conturi din db
    }
}
