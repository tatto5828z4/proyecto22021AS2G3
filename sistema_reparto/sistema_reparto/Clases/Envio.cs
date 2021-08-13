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
    public class Envio
    {
        //Atributos
        String idPiloto;
        String idOrdenE;
        String idTransporteE;
        String idRutaE;
        String idMovBodegaE;
        String fechaE;
        String estatusE;
        

        public Envio()
        {

        }

        public Envio(string idPiloto, string idOrdenE, string idTransporteE, string idRutaE, string idMovBodegaE, string fechaE, string estatusE)
        {
            this.IdPiloto = idPiloto;
            this.IdOrdenE = idOrdenE;
            this.IdTransporteE = idTransporteE;
            this.IdRutaE = idRutaE;
            this.IdMovBodegaE = idMovBodegaE;
            this.FechaE = fechaE;
            this.EstatusE = estatusE;
        }

        public string IdPiloto { get => idPiloto; set => idPiloto = value; }
        public string IdOrdenE { get => idOrdenE; set => idOrdenE = value; }
        public string IdTransporteE { get => idTransporteE; set => idTransporteE = value; }
        public string IdRutaE { get => idRutaE; set => idRutaE = value; }
        public string IdMovBodegaE { get => idMovBodegaE; set => idMovBodegaE = value; }
        public string FechaE { get => fechaE; set => fechaE = value; }
        public string EstatusE { get => estatusE; set => estatusE = value; }


        public void funInsertar()
        {
            String psql = "INSERT INTO envio(idPiloto,idOrdenE,idTransporteE,idRutaE,idMovBodegaE," +
                "fechaE,estatusE)" +
                " VALUES ('" + idPiloto + "' , '" + idOrdenE + "' , '" + idTransporteE + "' , '"
                + idRutaE + "' , '" + idMovBodegaE + "', '" + fechaE + "', '" + estatusE
                + "')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarEn = new MySqlCommand(psql, conexionBD);
                insertarEn.ExecuteNonQuery();
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


        public void cargarCombobox(ComboBox combobox, String tabla, String id, String nombre)
        {
            combobox.DataSource = null;
            combobox.Items.Clear();

            String sql = "SELECT * FROM " + tabla;
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand cargarCombobox = new MySqlCommand(sql, conexionBD);
                /*Guarda la consulta en este objeto*/
                MySqlDataAdapter data = new MySqlDataAdapter(cargarCombobox);
                DataTable dt = new DataTable();
                /*Los datos de una consulta los agregamos a un combobox*/
                data.Fill(dt);

                combobox.ValueMember = id;
                combobox.DisplayMember = nombre;
                /*Se llena el combobox*/
                combobox.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar datos del combobox " + ex.Message);
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
                sql = "SELECT * FROM envio";
            }
            else
            {
                sql = "SELECT * FROM envio WHERE idOrdenE LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarPaqueteE = new MySqlCommand(sql, conexionBD);
                reader = buscarPaqueteE.ExecuteReader();


                while (reader.Read())
                {

                    Envio envio = new Envio();

                    envio.idPiloto = reader.GetString("idPiloto");
                    envio.idOrdenE = reader.GetString("idOrdenE");

                    envio.idTransporteE = reader.GetString("idTransporteE");
                    envio.idRutaE = reader.GetString("idRutaE");
                    envio.idMovBodegaE = reader.GetString("idMovBodegaE");
                    envio.fechaE = reader.GetString("fechaE");
                    envio.estatusE = reader.GetString("estatusE");
                    

                    lista.Add(envio);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }


        
        public void obtenerNombre(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombrePiloto from piloto WHERE idPiloto='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombrePiloto");
                }
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

        /*Para llenar los combobox a travez de la tabla son 5 */
        public void obtenerNombrePiloto(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombrePiloto from piloto WHERE idPiloto='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombrePiloto");
                }
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

      

        /*TRANSPORTE*/
        public void obtenerNombreTransporte(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreTransporte from transporte WHERE idTransporte='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombreTransporte");
                }
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

        /*Ruta*/
        public void obtenerNombreRuta(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT idRuta from ruta WHERE idRuta='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("idRuta");
                }
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

        /*Movimiento Bodega*/
        public void obtenerNombreMB(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT idMovBodega from movimientoBodega WHERE idMovBodega='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("idRuta");
                }
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

        public void funModificar(String idModificar)
        {
            

            String pSqlModificar = "UPDATE envio SET idPiloto='" + idPiloto + "'," +
            " idTransporteE='" + idTransporteE + "', idRutaE='" + idRutaE + "'," +
            " idMovBodegaE='" + idMovBodegaE + "', fechaE='" + fechaE + "'," +
            " estatusE = '" + estatusE + "'"+
            " WHERE idOrdenE='" + idOrdenE + "'";

            

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarEnvio = new MySqlCommand(pSqlModificar, conexionBD);
                modificarEnvio.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(ComboBox idPiloto, TextBox idOrdenE, ComboBox idTransporteE, ComboBox idRutaE, ComboBox idMovBodegaE, DateTimePicker fechaE,TextBox estatusE) { 
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from envio WHERE idOrdenE='" + idOrdenE + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand busqueda = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = busqueda.ExecuteReader();

                while (leer.Read())
                {
                    idPiloto.Text = leer.GetString("idPiloto");
                    idOrdenE.Text = leer.GetString("idOrdenE");
                    idTransporteE.Text = leer.GetString("idTransporteE");
                    idRutaE.Text = leer.GetString("idRutaE");
                    idMovBodegaE.Text = leer.GetString("idMovBodegaE");
                    fechaE.Text = leer.GetString("fechaE");
                    estatusE.Text = leer.GetString("estatusE");
                    
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

            String estatusE = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusE from envio WHERE idOrdenE='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarEstatus = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarEstatus.ExecuteReader();

                while (leer.Read())
                {
                    estatusE = leer.GetString("estatusE");
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

            return estatusE;
        }

        /*Funcion que nos permite cambiar el estado a Enviado el producto*/

        public void funCambiar_Enviado(string IdOrden)
        {
            String pSqlModificar = "UPDATE envio SET estatusE='E' WHERE idOrdenE='" + IdOrden + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarEstatus = new MySqlCommand(pSqlModificar, conexionBD);
                modificarEstatus.ExecuteNonQuery();
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

        /*Funcion para cambiar el estado del envio a entregado*/
        public void funEnvio_Entregado(string IdOrden)
        {
            String pSqlModificar = "UPDATE envio SET estatusE='R' WHERE idOrdenE='" + IdOrden + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarEstatus = new MySqlCommand(pSqlModificar, conexionBD);
                modificarEstatus.ExecuteNonQuery();
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
