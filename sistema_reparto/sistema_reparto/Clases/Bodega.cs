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
    public class Bodega
    {
        //Atributos
        String idBodega;
        String idUbicacionBodega;
        String idSubUbicacionBodega;
        String estatusBodega;

        public Bodega()
        {

        }

        public Bodega(String idBodega, String idUbicacionBodega, String idSubUbicacionBodega, String estatusBodega)
        {
            this.idBodega = idBodega;
            this.idUbicacionBodega = idUbicacionBodega;
            this.idSubUbicacionBodega = idSubUbicacionBodega;
            this.estatusBodega = estatusBodega;
        }



        //Getter and Setters
        public string IdBodega { get => idBodega; set => idBodega = value; }
        public string IdUbicacionBodega { get => idUbicacionBodega; set => idUbicacionBodega = value; }
        public string IdSubUbicacionBodega { get => idSubUbicacionBodega; set => idSubUbicacionBodega = value; }
        public string EstatusBodega { get => estatusBodega; set => estatusBodega = value; }


        //Métodos creados
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
            String psql = "INSERT INTO bodega (idBodega,idUbicacionBodega,idSububicacionBodega,estatusBodega)" +
                " VALUES ('" + idBodega + "' , '" + idUbicacionBodega + "' , '" + idSubUbicacionBodega + "' , '"
                + estatusBodega + "')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarBodega = new MySqlCommand(psql, conexionBD);
                insertarBodega.ExecuteNonQuery();
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
                sql = "SELECT * FROM bodega";
            }
            else
            {
                sql = "SELECT * FROM bodega WHERE idBodega LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarPaqueteE = new MySqlCommand(sql, conexionBD);
                reader = buscarPaqueteE.ExecuteReader();


                while (reader.Read())
                {

                    Bodega bodega = new Bodega();

                    bodega.idBodega = reader.GetString("idBodega");
                    bodega.IdUbicacionBodega = reader.GetString("idUbicacionBodega");

                    bodega.idSubUbicacionBodega = reader.GetString("idSububicacionBodega");
                   
                    bodega.estatusBodega = reader.GetString("estatusBodega");
                    
                    lista.Add(bodega);
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
            String pSqlModificar = "UPDATE bodega SET idUbicacionBodega='" + IdUbicacionBodega + "'," +
            " idSububicacionBodega='" + idSubUbicacionBodega + "',"+
            " estatusBodega = '" + estatusBodega + "'" +
            " WHERE idBodega='" + idModificar+"'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarBodega = new MySqlCommand(pSqlModificar, conexionBD);
                modificarBodega.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox id, ComboBox idUbicacion, ComboBox idSubUbic, TextBox estatus ,String idBodega)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from bodega WHERE idBodega='" + idBodega + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand busqueda = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = busqueda.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    idUbicacion.Text = leer.GetString(1);
                    idSubUbic.Text = leer.GetString(2);
                    /*idPaquete.Text = leer.GetString(3);
                      idcliente.Text = leer.GetString(4);
                      idempleado.Text = leer.GetString(5);*/
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

        public void obtenerNombreUbicacion(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreUbicacion FROM ubicacion WHERE idUbicacion= '"+codigo+"'";
            
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombreUbicacion");
                    
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

        public void obtenerNombreSubUbicacion(String codigo)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreSubUbicacion FROM subUbicacion WHERE idSububicacion= '" + codigo + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    codigo = leer.GetString("nombreSubUbicacion");
                    
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
        /*
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

        }*/

        public String funBuscarEstatus(String idEstatus)
        {

            String estatusB = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusBodega FROM bodega WHERE idBodega='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarEstatus = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarEstatus.ExecuteReader();

                while (leer.Read())
                {
                    estatusB = leer.GetString("estatusBodega");
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

            return estatusB;
        }

        public void funDarBajaBodega()
        {
            String pSqlModificar = "UPDATE bodega SET estatusBodega='I' WHERE idBodega='" + idBodega + "'";

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

        public void funActivarCliente()
        {
            String pSqlModificar = "UPDATE bodega SET estatusBodega = 'A' WHERE idBodega = '" + idBodega + "'";

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
