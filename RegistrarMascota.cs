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
    public partial class RegistrarMascota : Form
    {
        public RegistrarMascota()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Conexion miConexion = new Conexion();
            Boolean resultado = miConexion.insertaMascota(textBoxChip.Text, textBoxNombre.Text, textBoxRaza.Text, textBoxEdad.Text, textBoxSexo.Text);
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
