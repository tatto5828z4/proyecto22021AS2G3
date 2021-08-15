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
        String idBodega;
        String idPaquete;
        String idCliente;
        String idEmpleado;
        String fechaE;
        String estatusE;

        




        public Envio()
        {

        }

        public Envio(string idPiloto, string idOrdenE, string idTransporteE, string idRutaE, string idMovBodegaE, string idBodega, string idPaquete, string idCliente, string idEmpleado, string fechaE, string estatusE)
        {
            this.idPiloto = idPiloto;
            this.idOrdenE = idOrdenE;
            this.idTransporteE = idTransporteE;
            this.idRutaE = idRutaE;
            this.idMovBodegaE = idMovBodegaE;
            this.idBodega = idBodega;
            this.idPaquete = idPaquete;
            this.idCliente = idCliente;
            this.idEmpleado = idEmpleado;
            this.fechaE = fechaE;
            this.estatusE = estatusE;
        }

        public string IdPiloto { get => idPiloto; set => idPiloto = value; }
        public string IdOrdenE { get => idOrdenE; set => idOrdenE = value; }
        public string IdTransporteE { get => idTransporteE; set => idTransporteE = value; }
        public string IdRutaE { get => idRutaE; set => idRutaE = value; }
        public string IdMovBodegaE { get => idMovBodegaE; set => idMovBodegaE = value; }
        public string FechaE { get => fechaE; set => fechaE = value; }
        public string EstatusE { get => estatusE; set => estatusE = value; }
        public string IdBodega { get => idBodega; set => idBodega = value; }
        public string IdPaquete { get => idPaquete; set => idPaquete = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }

        public void funInsertar()

        {

            idBodega = funBuscarDato("idBodega", "movimientoBodega", "idMovBodega", idMovBodegaE);
            idPaquete = funBuscarDato("idPaquete", "movimientoBodega", "idMovBodega", idMovBodegaE);
            idEmpleado = funBuscarDato("idEmpleadoMB", "movimientoBodega", "idMovBodega", idMovBodegaE);
            idCliente = funBuscarDato("idCliente", "movimientoBodega", "idMovBodega", idMovBodegaE);


            String psql = "INSERT INTO envio(idPiloto,idOrdenE,idTransporteE,idRutaE,idMovBodega,idBodega,idPaquete,idCliente,idEmpleado,fechaE,estatusE)" +
            " VALUES('" + idPiloto + "','" + idOrdenE + "' , '" + idTransporteE + "','" + idRutaE + "' , '" + idMovBodegaE + "' , '" + idBodega + "' , '" + idPaquete + "' , '" + idCliente + "' , '" + idEmpleado + "','" + fechaE + "','" + estatusE + "' )";

            Console.WriteLine(psql);


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
                    envio.idMovBodegaE = reader.GetString("idMovBodega");
                    envio.idBodega = reader.GetString("idBodega");

                    envio.idPaquete = reader.GetString("idPaquete");
                    envio.idCliente = reader.GetString("idCliente");
                    envio.idEmpleado = reader.GetString("idEmpleado");


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

        public String obtenerNombreCliente(String codigo)
        {
            MySqlDataReader leer = null;
            String cliente = "";

            String pSqlBuscar = "SELECT nombreCliente from cliente WHERE idCliente='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                   
                    cliente = leer.GetString("nombreCliente");
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
            return cliente;
        }

        public String obtenerNombreEmpleado(String codigo)
        {
            MySqlDataReader leer = null;
            String empleado = "";

            String pSqlBuscar = "SELECT nombreEmpleado from empleado WHERE idEmpleado='" + codigo + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {

                    empleado = leer.GetString("nombreEmpleado");
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
            return empleado;
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
                    codigo = leer.GetString("idMovBodega");
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
            " idMovBodegaE='" + idMovBodegaE + "'" + " idBodega='" + idBodega + "'" + 
            "idPaquete='" + idPaquete + "idCliente='"+ idCliente +"'"+ "idEmpleado='"+ idEmpleado +
            ", fechaE ='" + fechaE + "'," +
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

        public void funBuscarSetearTxt(ComboBox idPiloto, TextBox idOrdenE, ComboBox idTransporteE, ComboBox idRutaE, ComboBox idMovBodegaE, TextBox idBodega , TextBox idPaquete, TextBox idCliente, TextBox idEmpleado, DateTimePicker fechaE,TextBox estatusE) { 
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

                    idBodega.Text = leer.GetString("idBodega");
                    idPaquete.Text = leer.GetString("idPaquete");

                    //String RetornoNombre = leer.GetString("idCliente");

                    idCliente.Text = leer.GetString("idCliente");
                    idEmpleado.Text = leer.GetString("idEmpleado");

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


        /*funcion para buscar datos*/
        public String funBuscarDato(String dato, String tabla, String idBuscar, String id)
        {
            MySqlDataReader leer = null;
            String sql;
            String datoEncontrado = "";

            sql = "SELECT" + " " + dato + " " + "FROM" + " " + tabla + " " + "WHERE" + " " + idBuscar + "=" + id;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarDatos = new MySqlCommand(sql, conexionBD);
                leer = buscarDatos.ExecuteReader();

                while (leer.Read())
                {
                    datoEncontrado = leer.GetString(dato);
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

            return datoEncontrado;
        }

        //, TextBox idempleado
        public void funsetenadotexts(String id,  TextBox idempleado,TextBox bodega, TextBox paquete, TextBox  cliente)
        {

            String IdEmpleado = funBuscarDato("idEmpleadoMB", "movimientoBodega", "idMovBodega", id);
            String NombreEmpleado = funBuscarDato("nombreEmpleado", "empleado", "idEmpleado", IdEmpleado);


            /*Encontrar campo idbodega*/
            String idBodega = funBuscarDato("idBodega", "movimientoBodega", "idMovBodega", id);
            String idBodegaEnvio = funBuscarDato("idBodega", "bodega", "idBodega", idBodega);

            /*Encontrar campo idpaquete*/
            String idPaquete = funBuscarDato("idPaquete", "movimientoBodega", "idMovBodega", id);
            String idPaqueteEnvio = funBuscarDato("idPaqueteEncabezado", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);

            /*Encontrar campo id y nombre del cliente*/
            String idCliente = funBuscarDato("idCliente", "movimientoBodega", "idMovBodega", id);
            String nombreCliente = funBuscarDato("nombreCliente", "cliente", "idCliente", idCliente);

            /*Encontrar campo id y nombre empleado*/

            // String idEmpleadol = funBuscarDato("idEmpleado", "movimientoBodega", "idMovBodega", id);
            //  String nombreEmpleado = funBuscarDato("nombreEmpleado", "empleado", "idEmpleado", idEmpleadol);

            idempleado.Text = NombreEmpleado;
            bodega.Text = idBodegaEnvio;
            paquete.Text = idPaqueteEnvio;
            cliente.Text = nombreCliente;
          


        }

        public void funLlenarCamposNombre(String id, TextBox idempleado, TextBox cliente)
        {
            String IdEmpleado = funBuscarDato("idEmpleadoMB", "movimientoBodega", "idMovBodega", id);
            String NombreEmpleado = funBuscarDato("nombreEmpleado", "empleado", "idEmpleado", IdEmpleado);

            /*Encontrar campo id y nombre del cliente*/
            String idCliente = funBuscarDato("idCliente", "movimientoBodega", "idMovBodega", id);
            String nombreCliente = funBuscarDato("nombreCliente", "cliente", "idCliente", idCliente);

            idempleado.Text = NombreEmpleado;
            cliente.Text = nombreCliente;
        }
    }
}
