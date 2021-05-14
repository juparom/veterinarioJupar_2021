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
    public partial class Form1 : Form
    {
        Conexion miConexion = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaUsuario ventana = new AltaUsuario();
            ventana.Show();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();  //cierra la aplicación
        }

        private void cargausuario_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 ventana = new Form1();
            //ventana.Show();

            string DNI1 = textBox1.Text; //leo lo que el usuario ha escrito en las cajas
            DataTable usuarioCargado = (miConexion.getInfoUsuario(DNI1));

            label1.Text = usuarioCargado.Rows[0]["Nombre"].ToString();
            label2.Text = usuarioCargado.Rows[0]["Apellidos"].ToString();
            label3.Text = usuarioCargado.Rows[0]["Sexo"].ToString();
            label4.Text = usuarioCargado.Rows[0]["Edad"].ToString();
            label5.Text = usuarioCargado.Rows[0]["email"].ToString();
            label6.Text = usuarioCargado.Rows[0]["Mascota"].ToString();
        }

        private void RegistrarMascota_Click(object sender, EventArgs e)
        {
            RegistrarMascota ventana = new RegistrarMascota();
            ventana.Show();
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {

        }

        private void cargamascota_Click(object sender, EventArgs e)
        {
            string Chip1 = textBox2.Text; //leo lo que el usuario ha escrito en las cajas
            DataTable mascotaCargada = (miConexion.getInfoMascota(Chip1));

            label9.Text = mascotaCargada.Rows[0]["Nombre"].ToString();
            label10.Text = mascotaCargada.Rows[0]["Raza"].ToString();
            label11.Text = mascotaCargada.Rows[0]["Edad"].ToString();
            label12.Text = mascotaCargada.Rows[0]["Genero"].ToString();
         
        }
    }
}
