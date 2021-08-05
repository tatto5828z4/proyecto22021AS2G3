using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public class SubUbicacion
    {
        String idSubUbicacion;
        String nombreSubUbicacion;
        String estatusSubUbicacion;

        public string IdSubUbicacion { get => idSubUbicacion; set => idSubUbicacion = value; }
        public string NombreSubUbicacion { get => nombreSubUbicacion; set => nombreSubUbicacion = value; }
        public string EstatusSubUbicacion { get => estatusSubUbicacion; set => estatusSubUbicacion = value; }

        public SubUbicacion(string idSubUbicacion, string nombreSubUbicacion, string estatusSubUbicacion)
        {
            this.idSubUbicacion = idSubUbicacion;
            this.nombreSubUbicacion = nombreSubUbicacion;
            this.estatusSubUbicacion = estatusSubUbicacion;
        }

        public SubUbicacion()
        {

        }

        public void funInsertar()
        {
            if (IdSubUbicacion == "" && NombreSubUbicacion == "")
            {

                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {


                String psql = "INSERT INTO subUbicacion(idSububicacion,nombreSubUbicacion,estatusSubUbicacion)" +
               " VALUES('" + IdSubUbicacion + "' , '" + NombreSubUbicacion + "' , '" + EstatusSubUbicacion + "')";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarSububicacion = new MySqlCommand(psql, conexionBD);
                    insertarSububicacion.ExecuteNonQuery();
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
                sql = "SELECT * FROM subUbicacion";
            }
            else
            {
                sql = "SELECT * FROM subUbicacion WHERE idSububicacion LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarSubUbicacion = new MySqlCommand(sql, conexionBD);
                reader = buscarSubUbicacion.ExecuteReader();


                while (reader.Read())
                {

                    SubUbicacion subUbicacion = new SubUbicacion();

                    subUbicacion.IdSubUbicacion = reader.GetString("idSububicacion");
                    subUbicacion.NombreSubUbicacion = reader.GetString("nombreSubUbicacion");
                    subUbicacion.EstatusSubUbicacion = reader.GetString("estatusSubUbicacion");

                    lista.Add(subUbicacion);
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
            String pSqlModificar = "UPDATE subUbicacion SET nombreSubUbicacion='" + NombreSubUbicacion + "' WHERE idSububicacion='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarSubUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarSubUbicacion.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox id, TextBox nombre, TextBox estatus, String idSubUbicacion)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from subUbicacion WHERE idSububicacion='" + idSubUbicacion + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarSubUbicacion = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarSubUbicacion.ExecuteReader();

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

        public String funBuscarEstatus(String idEstatus)
        {

            String estatusSubUbicacion = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusSubUbicacion from subUbicacion WHERE idSububicacion='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarSubUbicacion = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarSubUbicacion.ExecuteReader();

                while (leer.Read())
                {
                    estatusSubUbicacion = leer.GetString("estatusSubUbicacion");
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

            return estatusSubUbicacion;
        }

        public void funActivarSubUbicacion()
        {
            String pSqlModificar = "UPDATE subUbicacion SET estatusSubUbicacion='A' WHERE idSububicacion='" + idSubUbicacion + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarSubUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarSubUbicacion.ExecuteNonQuery();
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

        public void funDarBajaSubUbicacion()
        {
            String pSqlModificar = "UPDATE subUbicacion SET estatusSubUbicacion='I' WHERE idSububicacion='" + idSubUbicacion + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarSubUbicacion = new MySqlCommand(pSqlModificar, conexionBD);
                modificarSubUbicacion.ExecuteNonQuery();
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
