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
    public class CalificacionPiloto
    {
        String idCalificacion;
        String idPiloto;
        String idPaqueteEncabezado;
        String idCliente;
        String idEmpleado;
        String fechaRecepcion;
        String llegadaTardia;
        String llegadaTiempo;
        String percances;
        String retrazos;
        String observaciones;

        public CalificacionPiloto()
        {

        }

        public CalificacionPiloto(String idCalificacion, String idPiloto, String idPaqueteEncabezado, String idCliente, String idEmpleado, String fechaRecepcion, String llegadaTardia, String llegadaTiempo, String percances, String retrazos, String observaciones)
        {
            this.IdCalificacion = idCalificacion;
            this.IdPiloto = idPiloto;
            this.IdPaqueteEncabezado = idPaqueteEncabezado;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.FechaRecepcion = fechaRecepcion;
            this.LlegadaTardia = llegadaTardia;
            this.LlegadaTiempo = llegadaTiempo;
            this.Percances = percances;
            this.Retrazos = retrazos;
            this.Observaciones = observaciones;
        }


        //Métodos
        public string IdCalificacion { get => idCalificacion; set => idCalificacion = value; }
        public string IdPiloto { get => idPiloto; set => idPiloto = value; }
        public string IdPaqueteEncabezado { get => idPaqueteEncabezado; set => idPaqueteEncabezado = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string FechaRecepcion { get => fechaRecepcion; set => fechaRecepcion = value; }
        public string LlegadaTardia { get => llegadaTardia; set => llegadaTardia = value; }
        public string LlegadaTiempo { get => llegadaTiempo; set => llegadaTiempo = value; }
        public string Percances { get => percances; set => percances = value; }
        public string Retrazos { get => retrazos; set => retrazos = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }


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

        public void funInsertar()
        {
            String psql = "INSERT INTO calificacionPiloto (idCalificacion,idPiloto,idPaqueteEncabezado,idCliente, idEmpleado, fechaRecepcion, llegadaTardia, llegadaTiempo, percances, retrasos, observaciones)" +
                " VALUES ('" + idCalificacion + "' , '" + idPiloto + "' , '" + idPaqueteEncabezado + "' ,'" + idCliente + "', '" + idEmpleado + "', '" + fechaRecepcion
                + "','" + llegadaTardia + "', '" + llegadaTiempo + "', '" + percances + "', '" + retrazos + "', '" + observaciones + "')";
                

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarCalificacion = new MySqlCommand(psql, conexionBD);
                insertarCalificacion.ExecuteNonQuery();
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
                sql = "SELECT * FROM calificacionPiloto";
            }
            else
            {
                sql = "SELECT * FROM calificacionPiloto WHERE idCalificacion LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand calificacionPiloto = new MySqlCommand(sql, conexionBD);
                reader = calificacionPiloto.ExecuteReader();


                while (reader.Read())
                {

                    CalificacionPiloto calificacion = new CalificacionPiloto();

                    calificacion.idCalificacion = reader.GetString("idCalificacion");
                    calificacion.idPiloto = reader.GetString("idPiloto");
                    calificacion.idPaqueteEncabezado = reader.GetString("idPaqueteEncabezado");
                    calificacion.idCliente = reader.GetString("idCliente");

                    calificacion.IdEmpleado = reader.GetString("idEmpleado");
                    calificacion.fechaRecepcion = reader.GetString("fechaRecepcion");
                    calificacion.llegadaTardia = reader.GetString("llegadaTardia");
                    calificacion.llegadaTiempo = reader.GetString("llegadaTiempo");

                    calificacion.percances = reader.GetString("percances");
                    calificacion.retrazos = reader.GetString("retrasos");
                    calificacion.observaciones = reader.GetString("observaciones");

                    lista.Add(calificacion);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }

        public void obtenerNombrePiloto(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombrePiloto FROM piloto WHERE idPiloto= '" + codigo + "'";

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

        public void obtenerNombreCliente(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreCliente FROM cliente WHERE idCliente= '" + codigo + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombreCliente");

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

        public void obtenerNombreEmpleado(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreEmpleado FROM empleado WHERE idEmpleado= '" + codigo + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombreEmpleado");

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
            String pSqlModificar = "UPDATE calificacionPiloto SET " +
            " idPiloto='" + idPiloto + "', idPaqueteEncabezado='" + idPaqueteEncabezado + "'," +
            " idCliente='" + idCliente + "', idEmpleado='" + idEmpleado + "'," +
            " fechaRecepcion = '" + fechaRecepcion + "', llegadaTardia = '" + llegadaTardia + "'," +
            " llegadaTiempo = '" + llegadaTiempo + "'," +
            " percances='" + percances + "', retrasos ='" + retrazos + "', observaciones='"+observaciones+"'"+
            " WHERE idCalificacion='" + IdCalificacion + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificar = new MySqlCommand(pSqlModificar, conexionBD);
                modificar.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox idCal, ComboBox idPiloto, ComboBox idPaqueteE, ComboBox idCliente, ComboBox idEmpleado, DateTimePicker fechaRecepcion, CheckBox llegadaT, CheckBox llegadaTiempo, CheckBox percances, CheckBox retrasos, RichTextBox observaciones ,String idCalificacion)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from calificacionPiloto WHERE idCalificacion='" + idCalificacion + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand busqueda = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = busqueda.ExecuteReader();

                while (leer.Read())
                {
                    idCal.Text = leer.GetString(0);
                    String Piloto = leer.GetString(1);
                    
                    obtenerNombrePiloto(Piloto);
                    idPiloto.SelectedValue = Piloto;

                    idPaqueteE.Text = leer.GetString(2);

                    String cliente = leer.GetString(3);
                    obtenerNombreCliente(cliente);
                    idCliente.SelectedValue = cliente;

                    String empleado = leer.GetString(4);
                    obtenerNombreCliente(empleado);
                    idEmpleado.SelectedValue = empleado;

                    fechaRecepcion.Text = leer.GetString(5);
                    llegadaT.Text = leer.GetString(6);
                    llegadaTiempo.Text = leer.GetString(7);
                    percances.Text = leer.GetString(8);
                    retrasos.Text = leer.GetString(9);
                    observaciones.Text = leer.GetString(10);
                    
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

    }
}
