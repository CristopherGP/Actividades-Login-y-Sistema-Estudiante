using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppLoginCSS
{
    public class UsuarioDAO
    {
        Conexion con = new Conexion();
        private object user;

        public Usuario Login(string user, string pass)
        {
            var conexion = con.conectar();

            string sql = "SELECT * FROM usuarios WHERE usuario=@u AND contrasena=@p";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pass);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Usuario u = new Usuario();
                u.Id = reader.GetInt32("id");
                u.Nombre = reader.GetString("nombre");
                u.Apellido = reader.GetString("apellido");
                u.User = reader.GetString("usuario");
                u.Foto = (byte[])reader["foto"];
                return u;
            }

            return null;
        }

        

        public bool Insertar(Usuario u)
        {
            var conexion = con.conectar();

            string sql = "INSERT INTO usuarios(nombre,apellido,email,usuario,contrasena,foto) VALUES(@n,@a,@e,@u,@p,@f)";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@n", u.Nombre);
            cmd.Parameters.AddWithValue("@a", u.Apellido);
            cmd.Parameters.AddWithValue("@e", u.Email);
            cmd.Parameters.AddWithValue("@u", u.User);
            cmd.Parameters.AddWithValue("@p", u.Pass);
            cmd.Parameters.AddWithValue("@f", u.Foto);

            return cmd.ExecuteNonQuery() > 0;
        }

        // 🔥 ESTE MÉTODO DEBE ESTAR AQUÍ
        public bool ExisteUsuario(string user)
        {
            var conexion = con.conectar();

            string sql = "SELECT COUNT(*) FROM usuarios WHERE usuario=@u";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@u", user);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }
    }
}
