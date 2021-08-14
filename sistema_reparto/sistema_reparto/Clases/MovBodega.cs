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
    public class MovBodega
    {
        //Atributos
        String idMovBo;
        String idBodega;
        String idTipoMovBo;
        String idPaquete;
        String idCliente;
        String idEmpleado;
        String fechaHora;
        String idInventario;

        public string IdMovBo { get => idMovBo; set => idMovBo = value; }
        public string IdBodega { get => idBodega; set => idBodega = value; }
        public string IdTipoMovBo { get => idTipoMovBo; set => idTipoMovBo = value; }
        public string IdPaquete { get => idPaquete; set => idPaquete = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string FechaHora { get => fechaHora; set => fechaHora = value; }

        public MovBodega(string idMovBo, string idBodega, string idTipoMovBo, string idPaquete, string fechaHora, string idInventario)
        {
            this.idMovBo = idMovBo;
            this.idBodega = idBodega;
            this.idTipoMovBo = idTipoMovBo;
            this.idPaquete = idPaquete;
            this.fechaHora = fechaHora;
            this.idInventario = idInventario;
        }

        public MovBodega()
        {

        }

        public void funAbastecerIn()
        {
            idEmpleado = funBuscarDato("idEmpleado", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);
            idCliente = funBuscarDato("idCliente", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);
            String cantidadPaquete = funBuscarDato("cantidadPaquetes", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);

            int error = 0;

            String psql = "INSERT INTO movimientoBodega(idMovBodega,idBodega,idTipoMovMB,idPaquete,idCliente,idEmpleadoMB,fechaHoraMB)" +
             " VALUES('" + idMovBo + "' , '" + idBodega + "' , '" + idTipoMovBo + "' , '"+idPaquete+"' , '"+idCliente+"' , '"+idEmpleado+"' , '"+fechaHora+"' )";

            String psqlIn = "INSERT INTO inventario(idInventario,idBodega,idPaquete,idCliente,idEmpleadoMB,cantidadInventario,fechaIngresoInventario)" +
            "VALUES('" + idInventario + "', '" + idBodega + "' , '" + idPaquete + "' , '" + idCliente + "' , '" + idEmpleado + "'" +
            ", '" + cantidadPaquete + "' , '" + fechaHora + "')";

            //Console.WriteLine(psql);

            int cantidadInventarioBo = funVerificarExistenciaCantidad();

            if (cantidadInventarioBo == 0)
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarMovBo = new MySqlCommand(psql, conexionBD);
                    insertarMovBo.ExecuteNonQuery();

                    error = 1;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar los datos " + ex.Message);

                    error = 0;
                }
                finally
                {
                    conexionBD.Close();
                }

                if (error == 1)
                {
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand insertarIn = new MySqlCommand(psqlIn, conexionBD);
                        insertarIn.ExecuteNonQuery();

                        MessageBox.Show("Bodega Abastecida Correctamente");


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
            else
            {
                MessageBox.Show("El Paquete ya existe en una Bodega!");
            }



        }

        public void funDesAbastecer()
        {
            int cantitdadActualizar = 0;


            idEmpleado = funBuscarDato("idEmpleado", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);
            idCliente = funBuscarDato("idCliente", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete);

            int cantidadInventario = int.Parse(funBuscarDato("cantidadInventario", "inventario", "idInventario", idInventario));
            int cantidadPaqueteEnc = int.Parse(funBuscarDato("cantidadPaquetes", "paqueteEncabezado", "idPaqueteEncabezado", idPaquete));

            cantitdadActualizar = cantidadInventario - cantidadPaqueteEnc;

            String pSqlDesAbastecer = "UPDATE inventario SET cantidadInventario='"+ cantitdadActualizar + "' WHERE idInventario='" + idInventario + "'";
            
            String psql = "INSERT INTO movimientoBodega(idMovBodega,idBodega,idTipoMovMB,idPaquete,idCliente,idEmpleadoMB,fechaHoraMB)" +
             " VALUES('" + idMovBo + "' , '" + idBodega + "' , '" + idTipoMovBo + "' , '" + idPaquete + "' , '" + idCliente + "' , '" + idEmpleado + "' , '" + fechaHora + "' )";

            String pSqlModificarEnc = "UPDATE paqueteEncabezado SET estatusPaqEncabezado='I' WHERE idPaqueteEncabezado='" + idPaquete + "'";

            
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarMovBo = new MySqlCommand(psql, conexionBD);
                    insertarMovBo.ExecuteNonQuery();

                    MessageBox.Show("Bodega Desabastecida Correctamente");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar los datos " + ex.Message);

                }
                finally
                {
                    conexionBD.Close();
                }

                conexionBD.Open();

                try
                {
                    MySqlCommand insertarIn = new MySqlCommand(pSqlDesAbastecer, conexionBD);
                    insertarIn.ExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar los datos " + ex.Message);

                }
                finally
                {
                    conexionBD.Close();
                }

                conexionBD.Open();

                try
                {
                    MySqlCommand modificarEstatusEnc = new MySqlCommand(pSqlModificarEnc, conexionBD);
                    modificarEstatusEnc.ExecuteNonQuery();
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

        public void funSeteandoTexts(String id,TextBox empleado,TextBox cliente)
        {
            /* Inicio Obteniendo el id y el nombre del empleado */
            String idEmpleado = funBuscarDato("idEmpleado", "paqueteEncabezado", "idPaqueteEncabezado", id);
            String nombreEmpleado = funBuscarDato("nombreEmpleado", "empleado", "idEmpleado", idEmpleado);
            /* Final Obteniendo el id y el nombre del empleado */

            /* Inicio Obteniendo el id y el nombre del Cliente */
            String idCliente = funBuscarDato("idCliente", "paqueteEncabezado", "idPaqueteEncabezado", id);
            String nombreCliente = funBuscarDato("nombreCliente", "cliente", "idCliente", idCliente);
            /* Final Obteniendo el id y el nombre del Cliente */

            empleado.Text = nombreEmpleado;
            cliente.Text = nombreCliente;
        }

        public String funBuscarDato(String dato, String tabla, String idBuscar, String id)
        {
            MySqlDataReader leer = null;
            String sql;
            String datoEncontrado = "";

            sql = "SELECT" + " " + dato + " " + "FROM" + " " + tabla + " "  + "WHERE" + " " + idBuscar + "=" + id;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPuestos = new MySqlCommand(sql, conexionBD);
                leer = buscarPuestos.ExecuteReader();

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

        public void funLlenarCombo(ComboBox idPaEnc)
        {
            idPaEnc.DataSource = null;
            idPaEnc.Items.Clear();

            String psql = "SELECT idPaqueteEncabezado FROM paqueteEncabezado WHERE estatusPaqEncabezado='A'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand llenarCombo = new MySqlCommand(psql, conexionBD);
                MySqlDataAdapter data = new MySqlDataAdapter(llenarCombo);

                DataTable dt = new DataTable();
                data.Fill(dt);

                idPaEnc.ValueMember = "idPaqueteEncabezado";
                idPaEnc.DisplayMember = "idPaqueteEncabezado";
                idPaEnc.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al leer los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public void funLlenarComboBodega(ComboBox idBodega)
        {
            idBodega.DataSource = null;
            idBodega.Items.Clear();

            String psql = "SELECT idBodega FROM bodega WHERE estatusBodega='A'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand llenarCombo = new MySqlCommand(psql, conexionBD);
                MySqlDataAdapter data = new MySqlDataAdapter(llenarCombo);

                DataTable dt = new DataTable();
                data.Fill(dt);

                idBodega.ValueMember = "idBodega";
                idBodega.DisplayMember = "idBodega";
                idBodega.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al leer los datos " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public void funLlenarComboTipoMov(ComboBox tipoMov)
        {
            tipoMov.DataSource = null;
            tipoMov.Items.Clear();

            String psql = "SELECT idTipoMov,nombreTipoMov FROM tipoMovimiento WHERE estatusTipoMov='A'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand llenarCombo = new MySqlCommand(psql, conexionBD);
                MySqlDataAdapter data = new MySqlDataAdapter(llenarCombo);

                DataTable dt = new DataTable();
                data.Fill(dt);

                tipoMov.ValueMember = "idTipoMov";
                tipoMov.DisplayMember = "nombreTipoMov";
                tipoMov.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al leer los datos " + ex.Message);
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
                sql = "SELECT * FROM movimientoBodega";
            }
            else
            {
                sql = "SELECT * FROM movimientoBodega WHERE idMovBodega LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarMovBo = new MySqlCommand(sql, conexionBD);
                reader = buscarMovBo.ExecuteReader();


                while (reader.Read())
                {

                    MovBodega movBodega = new MovBodega();

                    movBodega.idMovBo = reader.GetString("idMovBodega");
                    movBodega.idBodega = reader.GetString("idBodega");
                    String tipoMov = reader.GetString("idTipoMovMB");
                    String nombreTipoMov = funBuscarDato("nombreTipoMov", "tipoMovimiento", "idTipoMov", tipoMov);

                    movBodega.IdTipoMovBo = nombreTipoMov;
                    movBodega.idPaquete = reader.GetString("idPaquete");
                    movBodega.idCliente = reader.GetString("idCliente");
                    movBodega.idEmpleado = reader.GetString("idEmpleadoMB");
                    movBodega.fechaHora = reader.GetString("fechaHoraMB");

                    lista.Add(movBodega);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }

        public int funVerificarExistenciaCantidad()
        {
            MySqlDataReader reader = null;

            int cantidadInventario = 0;

            String psql = "SELECT cantidadInventario FROM inventario WHERE idPaquete=" + IdPaquete + " " + "ORDER BY idPaquete DESC";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {

                MySqlCommand buscarMovBo = new MySqlCommand(psql, conexionBD);
                reader = buscarMovBo.ExecuteReader();


                while (reader.Read())
                {
                    cantidadInventario = int.Parse(reader.GetString("cantidadInventario"));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return cantidadInventario;
        }

        public int funVerificarExistenciaBodega()
        {
            MySqlDataReader reader = null;

            int cantidadInventario = 0;
            String bodega = "";

            String psql = "SELECT cantidadInventario FROM inventario WHERE idPaquete=" + IdPaquete + " " + "ORDER BY idPaquete DESC";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {

                MySqlCommand buscarMovBo = new MySqlCommand(psql, conexionBD);
                reader = buscarMovBo.ExecuteReader();


                while (reader.Read())
                {
                    cantidadInventario = int.Parse(reader.GetString("cantidadInventario"));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return cantidadInventario;
        }
    }
}
