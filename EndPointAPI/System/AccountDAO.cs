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

    public static Account GetAccount(int accId)
    {
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

        return acc;
    }

    public int lastId ()
    {
        //"SELECT MAX(ACCOUNT_ID) FROM ACCOUNT"
        return 2; // return nr de conturi din db
    }
}
