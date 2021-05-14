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
    public partial class Login : Form
    {
        Conexion miConexion = new Conexion();
        public Login()
        {
            
            InitializeComponent();
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 ventana = new Form1();
            //ventana.Show();

            string dni = usuario.Text; //leo lo que el usuario ha escrito en las cajas
            string password = pass.Text;
            if (miConexion.loginInicial(dni, password))
            {
                this.Hide();
                Form1 ventana = new Form1();
                ventana.Show();

            }
            else
            {  //o la contraseña o el usuario son incorrectos
                MessageBox.Show("el usuario o la contraseña son incorrectos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miConexion.conexion.Open();
            MySqlCommand consulta = new MySqlCommand("SELECT DNI, password FROM t_usuarios", miConexion.conexion);
            MySqlDataReader resultado = consulta.ExecuteReader();
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            while (resultado.Read())
            {
                passwords.Add(resultado.GetString("DNI"), resultado.GetString("password"));
            }
            miConexion.conexion.Close();
            miConexion.conexion.Open();
            foreach (var element in passwords)
            {
                MySqlCommand consultaHash = new MySqlCommand("UPDATE t_usuarios SET password=@_PASSWORD WHERE DNI=@_DNI", miConexion.conexion);
                consultaHash.Parameters.AddWithValue("@_DNI", element.Key);
                consultaHash.Parameters.AddWithValue("@_PASSWORD", BCrypt.Net.BCrypt.HashPassword(element.Value, BCrypt.Net.BCrypt.GenerateSalt()));
                consultaHash.ExecuteNonQuery();
            }
            miConexion.conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaUsuario ventana = new AltaUsuario();
            ventana.Show();
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.PasswordChar = '*';
        }
    }
}
