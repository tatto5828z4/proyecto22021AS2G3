using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public static class Login
    {
        public static string idUsuario { get; set; }
        public static string passUsuario { get; set; }
    }

    public class LoginC
    {
        //Atributos
        String idUsuario;
        String passUsuario;
        String nombreUsuario;

        public LoginC()
        {

        }

        public LoginC(string idUsuario, string passUsuario, string nombreUsuario)
        {
            this.idUsuario = idUsuario;
            this.passUsuario = passUsuario;
            this.nombreUsuario = nombreUsuario;
        }

        public bool funBuscandoUsuario()
        {
            MySqlDataReader leer = null;
            String ids = "";
            String pass = "";
            bool encontrado = false;

            String pSqlBuscar = "SELECT idUser,passwordUsuario from usuario";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarClientes = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarClientes.ExecuteReader();

                while (leer.Read())
                {
                    ids = leer.GetString("idUser");
                    pass = leer.GetString("passwordUsuario");

                    if (ids == Login.idUsuario && pass == Login.passUsuario)
                    {
                        encontrado = true;

                        break;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

            return encontrado;
        }

        public bool funCantidadUsuarios()
        {
            String pSqlBuscar = "SELECT count(*) from usuario";
            String cantidad = "";
            bool encontrados = false;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarUsuarios = new MySqlCommand(pSqlBuscar, conexionBD);
                cantidad = buscarUsuarios.ExecuteScalar().ToString();
              
                if (cantidad == "0")
                {
                    encontrados = true;
                }

       
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

            return encontrados;
        }

        public void funInsertarUsuario()
        {
            String psql = "INSERT INTO usuario(idUser,idPermiso,nombreUsuario,passwordUsuario,estatusUsuario)" +
             " VALUES('" + idUsuario + "' , '" + "1" + "' , '" + nombreUsuario + "' , '" + passUsuario + "' , '" + "A" + "')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarUsuarios = new MySqlCommand(psql, conexionBD);
                insertarUsuarios.ExecuteNonQuery();
                MessageBox.Show("Usuario Agregado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public String funBuscarNormbre(String id)
        {
            MySqlDataReader leer = null;
            String nombre = "";

            String pSqlBuscar = "SELECT nombreUsuario from usuario WHERE idUser=" + id;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarClientes = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarClientes.ExecuteReader();

                while (leer.Read())
                {
                    nombre = leer.GetString("nombreUsuario");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

            return nombre;
        }
    }
}
