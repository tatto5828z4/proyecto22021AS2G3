using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto
{
    public class Cliente
    {
        //Atributos
        String idCliente;
        String nombreCliente;
        String apellidoCliente;
        String telefonoCliente;
        String correoCliente;
        String direccionCliente;
        String estatusCliente;

        /* Inicio Generando Encapsulamiento de mis atributos de Cliente*/
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidoCliente { get => apellidoCliente; set => apellidoCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public string CorreoCliente { get => correoCliente; set => correoCliente = value; }
        public string DireccionCliente { get => direccionCliente; set => direccionCliente = value; }
        public string EstatusCliente { get => estatusCliente; set => estatusCliente = value; }

        /* Final Generando Encapsulamiento de mis atributos de Cliente*/

        public Cliente(String id, String nombre, String apellido, String telefono, String correo, String direccion, String estatus)
        {
            this.IdCliente = id;
            this.NombreCliente = nombre;
            this.ApellidoCliente = apellido;
            this.TelefonoCliente = telefono;
            this.CorreoCliente = correo;
            this.DireccionCliente = direccion;
            this.estatusCliente = estatus;
        }

        public Cliente()
        {

        }

        public void funInsertar()
        {
            String psql = "INSERT INTO cliente(idCliente,nombreCliente,apellidoCliente,telefonoCliente,correoCliente,direccionCliente,estatusCliente)" +
             " VALUES('" + IdCliente + "' , '" + NombreCliente + "' , '" + ApellidoCliente + "' , '" + TelefonoCliente + "' , '" + CorreoCliente + "' , '" + DireccionCliente + "', '"+estatusCliente+"')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarCliente = new MySqlCommand(psql, conexionBD);
                insertarCliente.ExecuteNonQuery();
                MessageBox.Show("Datos Ingresados Correctamente");
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public List<Object> consulta(String dato)
        {
            MySqlDataReader reader = null;
            List<Object> lista = new List<Object>();
            String sql;

            if (dato == null)
            {
                sql = "SELECT * FROM cliente";
            }
            else
            {
                sql = "SELECT * FROM cliente WHERE idCliente LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarClientes = new MySqlCommand(sql, conexionBD);
                reader = buscarClientes.ExecuteReader();


                while (reader.Read())
                {

                    Cliente cliente = new Cliente();

                    cliente.IdCliente = reader.GetString("idCliente");
                    cliente.NombreCliente = reader.GetString("nombreCliente");
                    cliente.ApellidoCliente = reader.GetString("apellidoCliente");
                    cliente.TelefonoCliente = reader.GetString("telefonoCliente");
                    cliente.CorreoCliente = reader.GetString("correoCliente");
                    cliente.DireccionCliente = reader.GetString("direccionCliente");
                    cliente.estatusCliente = reader.GetString("estatusCliente");

                    lista.Add(cliente);
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;
            
        }

        public void funBuscarSetearTxt(TextBox id, TextBox nombre, TextBox apellido, TextBox telefono, TextBox correo, RichTextBox direccion,TextBox estatus,String idCliente)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from cliente WHERE idCliente='"+idCliente+"'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarClientes = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarClientes.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    nombre.Text = leer.GetString(1);
                    apellido.Text = leer.GetString(2);
                    telefono.Text = leer.GetString(3);
                    correo.Text = leer.GetString(4);
                    direccion.Text = leer.GetString(5);
                    estatus.Text = leer.GetString(6);
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }


        public void funModificar(String idModificar)
        {
            String pSqlModificar = "UPDATE cliente SET nombreCliente='"+NombreCliente+"',"+
            " apellidoCliente='"+ApellidoCliente+ "', telefonoCliente='"+TelefonoCliente+ "', correoCliente='"+CorreoCliente+ "', direccionCliente='"+DireccionCliente+ "' WHERE idCliente='"+idModificar+"'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarCliente = new MySqlCommand(pSqlModificar, conexionBD);
                modificarCliente.ExecuteNonQuery();
                MessageBox.Show("Datos Modificados Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public String funBuscarEstatus(String idEstatus)
        {

            String estatusCliente = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusCliente from cliente WHERE idCliente='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarClientes = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarClientes.ExecuteReader();

                while (leer.Read())
                {
                    estatusCliente = leer.GetString("estatusCliente");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar el estatus " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

            return estatusCliente;
        }

        public void funDarBajaCliente()
        {
            String pSqlModificar = "UPDATE cliente SET estatusCliente='I' WHERE idCliente='"+idCliente+"'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarCliente = new MySqlCommand(pSqlModificar, conexionBD);
                modificarCliente.ExecuteNonQuery();
                MessageBox.Show("Estatus modificado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public void funActivarCliente()
        {
            String pSqlModificar = "UPDATE cliente SET estatusCliente='A' WHERE idCliente='" + idCliente + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarCliente = new MySqlCommand(pSqlModificar, conexionBD);
                modificarCliente.ExecuteNonQuery();
                MessageBox.Show("Estatus modificado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
