using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AppLoginCSS
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

string rutaImagen;
        private void btnImagen_Click(object sender, EventArgs e)
        {
OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = op.FileName;
                pictureBox1.Image = Image.FromFile(rutaImagen);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtUser.Text) ||
                    string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                    return;
                }

                if (rutaImagen == null)
                {
                    MessageBox.Show("Selecciona una imagen");
                    return;
                }

                UsuarioDAO dao = new UsuarioDAO();

                if (dao.ExisteUsuario(txtUser.Text))
                {
                    MessageBox.Show("El usuario ya existe");
                    return;
                }

                Usuario u = new Usuario();

                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Email = txtEmail.Text;
                u.User = txtUser.Text;
                u.Pass = txtPass.Text;
                u.Foto = File.ReadAllBytes(rutaImagen);

               

                if (dao.Insertar(u))
                {
                    MessageBox.Show("Registro exitoso");

                    // Regresar al login automáticamente
                    Form1 login = new Form1();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}
