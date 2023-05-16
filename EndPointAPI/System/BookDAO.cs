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
    public static string GetConnectionString()
    {
        return "User Id=STUDENT;Password=STUDENT;Data Source=localhost:1521/XE";
    }
    //DE MODIFICAT DE RETURNAT O LISTA DE CARTI, SI NU UN STRING
    public static string GetBooks()
    {
        using (OracleConnection connection = new OracleConnection(GetConnectionString()))

        {
            String sql, Output = "";
            sql = "Select * from CARTI";
            OracleCommand command = new OracleCommand(sql, connection);

            command.Connection.Open();
            OracleDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                //AICI FACI O CARTE NOUA
                Output = Output + dataReader.GetValue(0)
                    + " - " + dataReader.GetValue(1)
                    + " - " + dataReader.GetValue(2)
                    + " - " + dataReader.GetValue(3)
                    + " - " + dataReader.GetValue(4)
                    + " - " + dataReader.GetValue(5) + "\n";
                // _books.Add(book);
            }
            // return _books.
            return Output;
        }
    }
}
