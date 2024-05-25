using Pracownicy;
using MySql.Data.MySqlClient;

namespace Pracowicy
{
    class Program
    {
        public static void Main(string[] args)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=workgroup;";
            MySqlConnection conn = new (connStr);

            new Menu(conn);
        }
    }
}