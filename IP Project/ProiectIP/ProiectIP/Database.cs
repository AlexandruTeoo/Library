using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class Database
    {
        //AICI SE STERGE EFECTIV TOT
        //TREBUIE MUTATA FUNCTIA DIN BOOKDAO AICI (GetConnectionString())
        public static string GetConnectionString()
        {
            return "User Id=STUDENT;Password=STUDENT;Data Source=localhost:1521/XE";
        }
    }
}
