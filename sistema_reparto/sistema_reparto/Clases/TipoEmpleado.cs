using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public class TipoEmpleado
    {
        //atributos 
        String idTipoEmpleado;
        String nombreTipoEmpleado;
        String estatusTipoEmpleado;

        public TipoEmpleado()
        {
        }

        public TipoEmpleado(String idTipoEmpleado, String nombreTipoEmpleado, String estatusTipoEmpleado)
        {
            this.idTipoEmpleado= idTipoEmpleado;
            this.nombreTipoEmpleado = nombreTipoEmpleado;
            this.estatusTipoEmpleado = estatusTipoEmpleado;
        }

        //Encapsulamiento de atributos
        public string IdTipoEmpleado { get => idTipoEmpleado; set => idTipoEmpleado = value; }
        public string NombreTipoEmpleado { get => nombreTipoEmpleado; set => nombreTipoEmpleado = value; }
        public string EstatusTipoEmpleado { get => estatusTipoEmpleado; set => estatusTipoEmpleado = value; }


        //Métodos
        public void funInsertar()
        {
            String psql = "INSERT INTO tipoEmpleado (idTipoEmpleado, nombreTipoEmpleado, estatusTipoEmpleado)" +
             " VALUES('" + idTipoEmpleado + "' , '" + nombreTipoEmpleado + "' , '" + estatusTipoEmpleado + "')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarTipoEmpleado = new MySqlCommand(psql, conexionBD);
                insertarTipoEmpleado.ExecuteNonQuery();
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

        public List<Object> consulta(String dato)
        {
            MySqlDataReader reader = null;
            List<Object> lista = new List<Object>();
            String sql;

            if (dato == null)
            {
                sql = "SELECT * FROM tipoEmpleado";
            }
            else
            {
                sql = "SELECT * FROM tipoEmpleado WHERE idTipoEmpleado LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarTipoEmpleado = new MySqlCommand(sql, conexionBD);
                reader = buscarTipoEmpleado.ExecuteReader();


                while (reader.Read())
                {

                    TipoEmpleado tipoEmpleado = new TipoEmpleado();

                    tipoEmpleado.idTipoEmpleado = reader.GetString("idTipoEmpleado");
                    tipoEmpleado.nombreTipoEmpleado = reader.GetString("nombreTipoEmpleado");
                    tipoEmpleado.estatusTipoEmpleado= reader.GetString("estatusTipoEmpleado");

                    lista.Add(tipoEmpleado);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }


        public void funBuscarSetearTxt(TextBox id, TextBox nombre, TextBox estatus, String idTipoEmpleado)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from tipoEmpleado WHERE idTipoEmpleado='" + idTipoEmpleado + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarTipoEmpleado = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarTipoEmpleado.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    nombre.Text = leer.GetString(1);
                    estatus.Text = leer.GetString(2);
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


        public void funModificar(String idModificar)
        {
            String pSqlModificar = "UPDATE tipoEmpleado SET nombreTipoEmpleado='" + nombreTipoEmpleado + "' WHERE idTipoEmpleado='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarTipoEmpleado = new MySqlCommand(pSqlModificar, conexionBD);
                modificarTipoEmpleado.ExecuteNonQuery();
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

            String estatusUbicacion = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusTipoEmpleado from TipoEmpleado WHERE idTipoEmpleado='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarTipoEmpleado = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarTipoEmpleado.ExecuteReader();

                while (leer.Read())
                {
                    estatusUbicacion = leer.GetString("estatusUbicacion");
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

            return estatusUbicacion;
        }

        public void funActivarTipoEmpleado()
        {
            String pSqlModificar = "UPDATE tipoEmpleado SET estatusTipoEmpleado='A' WHERE idTipoEmpleado='" + idTipoEmpleado + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificaTipoEmpleado = new MySqlCommand(pSqlModificar, conexionBD);
                modificaTipoEmpleado.ExecuteNonQuery();
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

        public void funDarBajaTipoEmpleado()
        {
            String pSqlModificar = "UPDATE tipoEmpleado SET estatusTipoEmpleado='I' WHERE idTipoEmpleado='" + idTipoEmpleado + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarTipoEmpleado = new MySqlCommand(pSqlModificar, conexionBD);
                modificarTipoEmpleado.ExecuteNonQuery();
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
