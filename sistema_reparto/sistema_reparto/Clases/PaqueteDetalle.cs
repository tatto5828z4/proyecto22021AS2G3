using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public class PaqueteDetalle
    {
        String idPaqueteEncabezado;
        String idCliente;
        String idEmpleado;
        String idOrden;
        String descripcionProducto;

        public PaqueteDetalle(string idPaqueteEncabezado, string idCliente, string idEmpleado, string idOrden, string descripcionProducto)
        {
            this.idPaqueteEncabezado = idPaqueteEncabezado;
            this.idCliente = idCliente;
            this.idEmpleado = idEmpleado;
            this.idOrden = idOrden;
            this.descripcionProducto = descripcionProducto;
        }

        public PaqueteDetalle()
        {
        }

        public string IdPaqueteEncabezado { get => idPaqueteEncabezado; set => idPaqueteEncabezado = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string IdOrden { get => idOrden; set => idOrden = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }

        public void funInsertar()
        {
            if (IdPaqueteEncabezado == "" && IdCliente == "" && IdEmpleado == "" && IdOrden == "" && DescripcionProducto == "")
            {
                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String psql = "INSERT INTO paqueteDetallado(idPaqueteEncabezado,idCliente,idEmpleado,idOrden, descripcionProducto)" +
             " VALUES('" + idPaqueteEncabezado + "' , '" + idCliente + "' , '" + idEmpleado + "', '" + idOrden + "', '" + descripcionProducto + "')";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarPD = new MySqlCommand(psql, conexionBD);
                    insertarPD.ExecuteNonQuery();
                    MessageBox.Show("Datos Ingresados Correctamente");
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
        }


        public List<Object> consulta(String dato)
        {
            MySqlDataReader reader = null;
            List<Object> lista = new List<Object>();
            String sql;
            if (dato == null)
            {
                sql = "SELECT * FROM paqueteDetallado";
            }
            else
            {
                sql = "SELECT * FROM paqueteDetallado WHERE idOrden LIKE '%" + dato + "%'";
            }
            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarPaqueteDetallado = new MySqlCommand(sql, conexionBD);
                reader = buscarPaqueteDetallado.ExecuteReader();


                while (reader.Read())
                {
                    PaqueteDetalle paqueteDetalle = new PaqueteDetalle();

                    paqueteDetalle.IdPaqueteEncabezado = reader.GetString("idPaqueteEncabezado");
                    paqueteDetalle.IdCliente = reader.GetString("idCliente");
                    paqueteDetalle.IdEmpleado = reader.GetString("idEmpleado");
                    paqueteDetalle.IdOrden = reader.GetString("idOrden");
                    paqueteDetalle.DescripcionProducto = reader.GetString("descripcionProducto");

                    lista.Add(paqueteDetalle);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public void funModificar(String idModificar)
        {
            String pSqlModificar = "UPDATE paqueteDetallado SET idCliente='" + IdCliente + "', idEmpleado='" + IdEmpleado + "', descripcionProducto='" + DescripcionProducto + "' WHERE idOrden='" + idModificar + "'";
            //Console.WriteLine(pSqlModificar);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarPD = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPD.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(ComboBox idPE, ComboBox idC, ComboBox idE, TextBox idO, RichTextBox descripcion, String idorden)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from paqueteDetallado WHERE idOrden='" + idorden + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPD = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPD.ExecuteReader();

                while (leer.Read())
                {
                    idPE.Text = leer.GetString(0);
                    idC.Text = leer.GetString(1);
                    idE.Text = leer.GetString(2);
                    idO.Text = leer.GetString(3);
                    descripcion.Text = leer.GetString(4);
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
        }

        public void funLlenarComboTE(ComboBox combobox, String tabla, String id, String nombre)
        {
            combobox.DataSource = null;
            combobox.Items.Clear();
            String psql = "Select * FROM " + tabla;
            Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            try
            {
                MySqlCommand llenarCombo = new MySqlCommand(psql, conexionBD);
                MySqlDataAdapter data = new MySqlDataAdapter(llenarCombo);
                DataTable dt = new DataTable();
                data.Fill(dt);
                combobox.ValueMember = id;
                combobox.DisplayMember = nombre;
                combobox.DataSource = dt;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
        }

        /*
        public void obtenerNombrePE(String idPaqueteEncabezado)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreDepartamentos from departamento WHERE idDepartamento='" + idDepartamento + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarDepartamento = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarDepartamento.ExecuteReader();
                while (leer.Read())
                {
                    idDepartamento = leer.GetString("nombreDepartamentos");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
        }*/
        public void obtenerNombreCliente(String idCliente)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreCliente from cliente WHERE idCliente='" + idCliente + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarPD = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPD.ExecuteReader();
                while (leer.Read())
                {
                    idCliente = leer.GetString("nombreCliente");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
        }

        public void obtenerNombreEmpleado(String idEmpleado)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreEmpleado from empleado WHERE idEmpleado='" + idEmpleado + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarE = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarE.ExecuteReader();
                while (leer.Read())
                {
                    idEmpleado = leer.GetString("nombreEmpleado");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
        }

        public void funEliminar(String idEliminar)
        {
            String pSqlModificar = "delete from paquetedetallado WHERE idOrden='" + idEliminar + "'";
            //Console.WriteLine(pSqlModificar);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand eliminarPD = new MySqlCommand(pSqlModificar, conexionBD);
                eliminarPD.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados Correctamente");
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
