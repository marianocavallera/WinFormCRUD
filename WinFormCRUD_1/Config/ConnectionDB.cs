using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCRUD_1.Config
{
    public class ConnectionDB
    {
        public static SqlConnection ConnectionSQL()
        {
            SqlConnection conn = new SqlConnection("server=MARIANITO\\SQLEXPRESS01; database=WinFormCRUDdb; Trusted_Connection=True;");

            conn.Open();

            return conn;
        }


    }
}
