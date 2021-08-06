using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public class Ubicacion
    {
        //atributos 
        String idUbicacion;
        String nombreUbicacion;
        String estatusUbicacion;

        //Encapsulamiento de atributos
        public string IdUbicacion { get => idUbicacion; set => idUbicacion = value; }
        public string NombreUbicacion { get => nombreUbicacion; set => nombreUbicacion = value; }
        public string EstatusUbicacion { get => estatusUbicacion; set => estatusUbicacion = value; }

        //constructor de la clase
        public Ubicacion(String id, String nombre, String estatus)
        {
            this.IdUbicacion = id;
            this.NombreUbicacion = nombre;
            this.EstatusUbicacion = estatus;
        }

        public Ubicacion()
        {

        }

        //Métodos
        public void funInsertar()
        {
            String psql = "INSERT INTO ubicacion(idUbicacion, nombreUbicacion, estatusUbicacion)" +
             " VALUES('" + idUbicacion + "' , '" + nombreUbicacion + "' , '" + estatusUbicacion+ "')" ;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarUbicacion = new MySqlCommand(psql, conexionBD);
                insertarUbicacion.ExecuteNonQuery();
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
                sql = "SELECT * FROM ubicacion";
            }
            else
            {
                sql = "SELECT * FROM ubicacion WHERE idUbicacion LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarubicacion = new MySqlCommand(sql, conexionBD);
                reader = buscarubicacion.ExecuteReader();


                while (reader.Read())
                {

                    Ubicacion ubicacion = new Ubicacion();

                    ubicacion.idUbicacion = reader.GetString("idUbicacion");
                    ubicacion.nombreUbicacion = reader.GetString("nombreUbicacion");
                    ubicacion.estatusUbicacion = reader.GetString("estatusUbicacion");
                    
                    lista.Add(ubicacion);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }


        public void funBuscarSetearTxt(TextBox id, TextBox nombre, TextBox estatus, String idUbicacion)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from ubicacion WHERE idUbicacion='" + idUbicacion + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarUbicacion = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarUbicacion.ExecuteReader();

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
            String pSqlModificar = "UPDATE ubicacion SET nombreUbicacion='" + nombreUbicacion + "' WHERE idUbicacion='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUbicacion.ExecuteNonQuery();
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
            
            String pSqlBuscar = "SELECT estatusUbicacion from ubicacion WHERE idUbicacion='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarUbicacion = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarUbicacion.ExecuteReader();

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

        public void funActivarUbicacion()
        {
            String pSqlModificar = "UPDATE ubicacion SET estatusUbicacion='A' WHERE idUbicacion='" + idUbicacion + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUbicacion.ExecuteNonQuery();
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

        public void funDarBajaUbicacion()
        {
            String pSqlModificar = "UPDATE ubicacion SET estatusUbicacion='I' WHERE idUbicacion='" + idUbicacion + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUbicacion.ExecuteNonQuery();
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
