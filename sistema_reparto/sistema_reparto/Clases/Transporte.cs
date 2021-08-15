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
    public class Transporte
    {
        String idTransporte;
        String nombreTransporte;
        String idTipoTransporte;
        String placaTransporte;
        String colorTransporte;
        String noChasisTransporte;
        String modeloTransporte;
        String marcaTransporte;
        String propietarioTransporte;
        String estatusTransporte;

        public Transporte(string idTransporte, string nombreTransporte, string idTipoTransporte, string placaTransporte, string colorTransporte, string noChasisTransporte, string modeloTransporte, string marcaTransporte, string propietarioTransporte, string estatusTransporte)
        {
            this.idTransporte = idTransporte;
            this.nombreTransporte = nombreTransporte;
            this.idTipoTransporte = idTipoTransporte;
            this.placaTransporte = placaTransporte;
            this.colorTransporte = colorTransporte;
            this.noChasisTransporte = noChasisTransporte;
            this.modeloTransporte = modeloTransporte;
            this.marcaTransporte = marcaTransporte;
            this.propietarioTransporte = propietarioTransporte;
            this.estatusTransporte = estatusTransporte;
        }

        public Transporte()
        {
        }

        public string IdTransporte { get => idTransporte; set => idTransporte = value; }
        public string NombreTransporte { get => nombreTransporte; set => nombreTransporte = value; }
        public string IdTipoTransporte { get => idTipoTransporte; set => idTipoTransporte = value; }
        public string PlacaTransporte { get => placaTransporte; set => placaTransporte = value; }
        public string ColorTransporte { get => colorTransporte; set => colorTransporte = value; }
        public string NoChasisTransporte { get => noChasisTransporte; set => noChasisTransporte = value; }
        public string ModeloTransporte { get => modeloTransporte; set => modeloTransporte = value; }
        public string MarcaTransporte { get => marcaTransporte; set => marcaTransporte = value; }
        public string PropietarioTransporte { get => propietarioTransporte; set => propietarioTransporte = value; }
        public string EstatusTransporte { get => estatusTransporte; set => estatusTransporte = value; }

        public void funInsertar()
        {
            if (IdTransporte == "" && NombreTransporte == "" && IdTipoTransporte == "" && PlacaTransporte == "" && ColorTransporte == "" && NoChasisTransporte == "" && ModeloTransporte == "" && MarcaTransporte == "" && PropietarioTransporte == "" && EstatusTransporte == "")
            {
                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String psql = "INSERT INTO transporte(idTransporte,nombreTransporte,idTipoTransporte,placaTransporte, colorTransporte, noChasisTransporte, modeloTransporte, marcaTransporte, propietarioTransporte, estatusTransporte)" +
             " VALUES('" + IdTransporte + "' , '" + NombreTransporte + "' , '" + IdTipoTransporte + "', '" + PlacaTransporte + "', '" + ColorTransporte + "', '" + NoChasisTransporte + "', '" + ModeloTransporte + "', '" + MarcaTransporte + "', '" + PropietarioTransporte + "', '" + EstatusTransporte + "')";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarTransporte = new MySqlCommand(psql, conexionBD);
                    insertarTransporte.ExecuteNonQuery();
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
                sql = "SELECT * FROM transporte";
            }
            else
            {
                sql = "SELECT * FROM transporte WHERE idTransporte LIKE '%" + dato + "%'";
            }
            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarTransporte = new MySqlCommand(sql, conexionBD);
                reader = buscarTransporte.ExecuteReader();


                while (reader.Read())
                {
                    Transporte transporte = new Transporte();

                    transporte.IdTransporte = reader.GetString("idTransporte");
                    transporte.NombreTransporte = reader.GetString("nombreTransporte");
                    transporte.IdTipoTransporte = reader.GetString("idTipoTransporte");
                    transporte.PlacaTransporte = reader.GetString("placaTransporte");
                    transporte.ColorTransporte = reader.GetString("colorTransporte");
                    transporte.NoChasisTransporte = reader.GetString("noChasisTransporte");
                    transporte.ModeloTransporte = reader.GetString("modeloTransporte");
                    transporte.MarcaTransporte = reader.GetString("marcaTransporte");
                    transporte.PropietarioTransporte = reader.GetString("propietarioTransporte");
                    transporte.EstatusTransporte = reader.GetString("estatusTransporte");

                    lista.Add(transporte);
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
            Console.WriteLine(IdTransporte);
            String pSqlModificar = "UPDATE transporte SET nombreTransporte='" + NombreTransporte + "', idTipoTransporte='" + IdTipoTransporte + "', placaTransporte='" + PlacaTransporte + "', colorTransporte='" + ColorTransporte + "', noChasisTransporte='" + NoChasisTransporte + "', modeloTransporte='" + ModeloTransporte + "', marcaTransporte='" + MarcaTransporte + "', propietarioTransporte='" + PropietarioTransporte + "' WHERE idTransporte='" + idModificar + "'";
            //Console.WriteLine(pSqlModificar);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarTransporte = new MySqlCommand(pSqlModificar, conexionBD);
                modificarTransporte.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox id, TextBox nombre, ComboBox idTipoT, TextBox placa, TextBox color, TextBox nochasis, TextBox modelo, TextBox marca, TextBox propietario, TextBox estatus, String idTransporte)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from transporte WHERE idTransporte='" + idTransporte + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarEmpleado = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarEmpleado.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    nombre.Text = leer.GetString(1);
                    idTipoT.Text = leer.GetString(2);
                    placa.Text = leer.GetString(3);
                    color.Text = leer.GetString(4);
                    nochasis.Text = leer.GetString(5);
                    modelo.Text = leer.GetString(6);
                    marca.Text = leer.GetString(7);
                    propietario.Text = leer.GetString(8);
                    estatus.Text = leer.GetString(9);
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

            String estatusTransporte = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusTransporte from transporte WHERE idTransporte='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarTrans = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarTrans.ExecuteReader();

                while (leer.Read())
                {
                    estatusTransporte = leer.GetString("estatusTransporte");
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

            return estatusTransporte;
        }

        public void funActivarEmpleado()
        {
            String pSqlModificar = "UPDATE transporte SET estatusTransporte='A' WHERE idTransporte='" + IdTransporte + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarTransporte = new MySqlCommand(pSqlModificar, conexionBD);
                modificarTransporte.ExecuteNonQuery();
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
            String pSqlModificar = "UPDATE transporte SET estatusTransporte='I' WHERE idTransporte='" + IdTransporte + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarTransporte = new MySqlCommand(pSqlModificar, conexionBD);
                modificarTransporte.ExecuteNonQuery();
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

        public void obtenerNombreTipoTransporte(String idTransporte)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreTipoTransporte from tipoTransporte WHERE idTipoTransporte='" + idTransporte + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarTipoTrans = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarTipoTrans.ExecuteReader();
                while (leer.Read())
                {
                    idTransporte = leer.GetString("nombreTipoTransporte");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos " + ex.Message);
            }
        }
    }
}
