using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLoginCSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtUser.Text) ||
                    string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Completa todos los campos");
                    return;
                }

                UsuarioDAO dao = new UsuarioDAO();
                Usuario u = dao.Login(txtUser.Text, txtPass.Text);

                if (u != null)
                {
                    Bienvenida b = new Bienvenida(u);
                    b.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.Show();
            this.Hide();
        }
    }
}
