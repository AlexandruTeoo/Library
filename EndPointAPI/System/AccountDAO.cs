using EndPointAPI;
using Oracle.ManagedDataAccess.Client;
using System;

public class AccountDAO
{
    public static List<Account> GetAccounts()
    {
        List<Account> _accounts = new List<Account>
        {
            //
        };
        return _accounts;
    }

    public static Account GetAccount(string username, string parola)
    {
        using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
        {
            String sql;

            sql = "SELECT * FROM ACCOUNTS WHERE username='" + username + "' AND parola='" + parola + "'";
            OracleCommand command = new OracleCommand(sql, connection);

            command.Connection.Open();
            OracleDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            { 
            Account account = new Account(dataReader.GetInt32(0),
                dataReader.GetString(1),
                dataReader.GetString(2),
                dataReader.GetString(3),
                dataReader.GetString(4),
                dataReader.GetString(5),
                dataReader.GetString(6),
                dataReader.GetString(7),
                dataReader.GetString(8),
                dataReader.GetString(9),
                dataReader.GetInt32(10),
                dataReader.GetInt32(11)
                );
                return account;
            }
            return null;
        }
        /*
        OracleConnection con = Database.GetConnection();

        OracleCommand command;
        OracleDataReader dataReader;
        String sql, Output = "";

        sql = "Select * from ACCOUNTS WHERE ACCOUNT_ID = " + accId + ";";
        command = new OracleCommand(sql, con);
        dataReader = command.ExecuteReader();

        Account acc = new Account(Convert.ToInt32(dataReader.GetValue(0)),
                                dataReader.GetValue(1).ToString(),
                                dataReader.GetValue(2).ToString(),
                                dataReader.GetValue(3).ToString(),
                                dataReader.GetValue(4).ToString(),
                                dataReader.GetValue(5).ToString(),
                                dataReader.GetValue(6).ToString(),
                                dataReader.GetValue(7).ToString(),
                                dataReader.GetValue(8).ToString(),
                                dataReader.GetValue(9).ToString());

        Database.ClosedConnection();
        */
    }

    public int lastId ()
    {
        //"SELECT MAX(ACCOUNT_ID) FROM ACCOUNT"
        return 2; // return nr de conturi din db
    }
}
