using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoginCSS
{
    public class Conexion
    {
        private string cadena = "server=localhost;database=app_login;uid=root;pwd=Samara182;";

        public MySqlConnection conectar()
        {
            MySqlConnection con = new MySqlConnection(cadena);
            con.Open();
            return con;
        }
    }
}
