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
    public partial class Bienvenida : Form
    {
        public Bienvenida(Usuario u)
        {
            InitializeComponent();
            lblNombre.Text = "Bienvenido " + u.Nombre;

            if (u.Foto != null)

            {
                MemoryStream ms = new MemoryStream(u.Foto);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}
