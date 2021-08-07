using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace sistema_reparto.Clases
{
    public class Ruta
    {
        // Atributos ruta
        String idRuta;
        String inicioRuta;
        String finalRuta;
        String estatusRuta;

        public string IdRuta { get => idRuta; set => idRuta = value; }
        public string InicioRuta { get => inicioRuta; set => inicioRuta = value; }
        public string FinalRuta { get => finalRuta; set => finalRuta = value; }
        public string EstatusRuta { get => estatusRuta; set => estatusRuta = value; }

        public Ruta(String id, String inicio, String final, String estatus)
        {
            this.IdRuta = id;
            this.InicioRuta = inicio;
            this.FinalRuta = final;
            this.EstatusRuta = estatus;
        }

        public Ruta()
        {

        }

        public void funInsertar()
        {
            if (idRuta == "" && inicioRuta == "" && finalRuta == "")
            {

                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {



                String psql = "INSERT INTO ruta(idRuta,inicioRuta,finalRuta, estatusRuta)" +
             " VALUES('" + idRuta + "' , '" + inicioRuta + "' , '" + finalRuta + "', '" + estatusRuta + "')";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarRuta = new MySqlCommand(psql, conexionBD);
                    insertarRuta.ExecuteNonQuery();
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
                sql = "SELECT * FROM ruta";
            }
            else
            {
                sql = "SELECT * FROM ruta WHERE idRuta LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarRuta = new MySqlCommand(sql, conexionBD);
                reader = buscarRuta.ExecuteReader();


                while (reader.Read())
                {

                    Ruta ruta = new Ruta();

                    ruta.IdRuta = reader.GetString("idRuta");
                    ruta.InicioRuta = reader.GetString("inicioRuta");
                    ruta.FinalRuta = reader.GetString("finalRuta");
                    ruta.EstatusRuta = reader.GetString("estatusRuta");
                    lista.Add(ruta);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }

        /*Funcion para modificar */
        public void funModificar(String idModificar)
        {
            String pSqlModificar = "UPDATE Ruta SET inicioRuta='" + inicioRuta + "', finalRuta='" + finalRuta + "' WHERE idRuta='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarRuta = new MySqlCommand(pSqlModificar, conexionBD);
                modificarRuta.ExecuteNonQuery();
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


        public void funBuscarSetearTxt(TextBox id, TextBox inicio, TextBox final, TextBox estatus, String idRuta)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from ruta WHERE idRuta='" + idRuta + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarRuta = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarRuta.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    inicio.Text = leer.GetString(1);
                    final.Text = leer.GetString(2);
                    estatus.Text = leer.GetString(3);
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

            String estatusRuta = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusRuta from ruta WHERE idRuta='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarRuta = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarRuta.ExecuteReader();

                while (leer.Read())
                {
                    estatusRuta = leer.GetString("estatusRuta");
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

            return estatusRuta;
        }

        public void funActivarRuta()
        {
            String pSqlModificar = "UPDATE ruta SET estatusRuta='A' WHERE idRuta='" + idRuta + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarRuta = new MySqlCommand(pSqlModificar, conexionBD);
                modificarRuta.ExecuteNonQuery();
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


        public void funDarBajaRuta()
        {
            String pSqlModificar = "UPDATE ruta SET estatusRuta='I' WHERE idRuta='" + idRuta + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarRuta = new MySqlCommand(pSqlModificar, conexionBD);
                modificarRuta.ExecuteNonQuery();
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
