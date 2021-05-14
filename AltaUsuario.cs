using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using MySql.Data.MySqlClient;

namespace EjemploTabs_2021
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String passHasheada = BCrypt.Net.BCrypt.HashPassword(textBoxPASS.Text, BCrypt.Net.BCrypt.GenerateSalt());
            ////MessageBox.Show(textBoxPASS.Text + "  " + passHasheada);

            Conexion miConexion = new Conexion();
            Boolean resultado = miConexion.insertausuario(textBoxDNI.Text, passHasheada, textBoxNombre.Text, textBoxApellido.Text, textBoxSexo.Text, textBoxEdad.Text, textBoxEmail.Text); 
            if (resultado)
            {
                MessageBox.Show("INSERTADO CORRECTAMENTE");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error inesperado y no se ha podido insertar. Pruebe mas tarde");
            }
        }
    }
}
