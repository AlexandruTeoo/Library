using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BookDAO
    {
        public static string GetBooks()
        {
            OracleConnection con = Database.GetConnection();

            OracleCommand command;
            OracleDataReader dataReader;
            String sql, Output = "";

            sql = "Select * from CARTI";
            command = new OracleCommand(sql, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0)
                    + " - " + dataReader.GetValue(1)
                    + " - " + dataReader.GetValue(2)
                    + " - " + dataReader.GetValue(3)
                    + " - " + dataReader.GetValue(4)
                    + " - " + dataReader.GetValue(5) + "\n";
            }

            Database.ClosedConnection();

            return Output;
        }
    }
}
