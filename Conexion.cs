using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;  //la libreria de MySql
using System.Data;  //la libreria del DataTable

namespace EjemploTabs_2021
{
    class Conexion
    {
        public MySqlConnection conexion; //variable que se encarga de conectarnos al servidor MySql

        public Conexion() { //el constructor de la clase
            conexion = new MySqlConnection("Server=127.0.0.1; Database=veterinario_jupar; Uid=root; Pwd=; Port=3306 ");
        }

        public Boolean loginInicial(String _DNI, String _password) {
            try {
                conexion.Open();
                
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM t_usuarios WHERE DNI=@_DNI ", conexion);
                consulta.Parameters.AddWithValue("@_DNI", _DNI);

                MySqlDataReader resultado = consulta.ExecuteReader(); //guardo el resultado de la query
                if (resultado.Read())
                {
                    String passwordConHash = resultado.GetString("password");
                    if (BCrypt.Net.BCrypt.Verify(_password, passwordConHash))
                    {
                        conexion.Close();
                        //si entra aquí es porque sí que estan bien el usuario y la contraseña
                        return true;
                    }
                }
                conexion.Close();
                return false;
            }
            catch (MySqlException e) {
                throw e;
            }

        }

        public Boolean insertausuario(String _DNI, String _password, String _Nombre, String _Apellido, String _Sexo, String _Edad, String _email)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO t_usuarios (DNI, password, Nombre, Apellido, Sexo, Edad, email)  VALUES (@_DNI, @_password, @_Nombre, @_Apellido, @Sexo, @Edad, @_email)", conexion);
                consulta.Parameters.AddWithValue("@_DNI", _DNI);
                consulta.Parameters.AddWithValue("@_password", _password);
                consulta.Parameters.AddWithValue("@_Nombre", _Nombre);
                consulta.Parameters.AddWithValue("@_Apellido", _Apellido);
                consulta.Parameters.AddWithValue("@_Sexo", _Sexo);
                consulta.Parameters.AddWithValue("@_Edad", _Edad);
                consulta.Parameters.AddWithValue("@_email", _email);
                

                int resultado = consulta.ExecuteNonQuery(); //Ejecuta el insert
                if (resultado > 0)
                {
                    conexion.Close();
                    //si entra aquí es porque ha hecho bien la inserción
                    return true;
                }
                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
                throw e;
            }

        }
        public Boolean insertaMascota(String _Chip, String _Nombre, String _Raza, String _Edad, String _Genero)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO t_mascotas (Chip, Nombre, Raza, Edad, Genero)  VALUES (@_Chip, @_Nombre, @_Raza,  @Edad, @Genero)", conexion);
                consulta.Parameters.AddWithValue("@_Chip", _Chip);
                consulta.Parameters.AddWithValue("@_Nombre", _Nombre);
                consulta.Parameters.AddWithValue("@_Raza", _Raza);
                consulta.Parameters.AddWithValue("@_Edad", _Edad);
                consulta.Parameters.AddWithValue("@_Genero", _Genero);


                int resultado = consulta.ExecuteNonQuery(); //Ejecuta el insert
                if (resultado > 0)
                {
                    conexion.Close();
                    //si entra aquí es porque ha hecho bien la inserción
                    return true;
                }
                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
                throw e;
            }

        }

        public DataTable getInfoMascota(String _Chip)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM t_mascotas WHERE Chip='" + _Chip + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader(); //guardo el resultado de la query
                DataTable InfoMascota = new DataTable(); //formato que espera el datagridview
                InfoMascota.Load(resultado);  //convierte MysqlDataReader en DataTable
                conexion.Close();
                return InfoMascota;
            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw e;
            }
        }

        public DataTable getInfoUsuario(String _DNI)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM t_usuarios WHERE DNI='" + _DNI + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader(); //guardo el resultado de la query
                DataTable Infousuario = new DataTable(); //formato que espera el datagridview
                Infousuario.Load(resultado);  //convierte MysqlDataReader en DataTable
                conexion.Close();
                return Infousuario;
            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw e;
            }
        }


    }
}
