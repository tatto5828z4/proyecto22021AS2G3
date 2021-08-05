using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto.Clases
{
    public class Puesto
    {
        //Atributos
        String idPuesto;
        String NombrePuesto;
        String estatusPuesto;

        public string IdPuesto { get => idPuesto; set => idPuesto = value; }
        public string NombrePuesto1 { get => NombrePuesto; set => NombrePuesto = value; }
        public string EstatusPuesto { get => estatusPuesto; set => estatusPuesto = value; }

        public Puesto(String id, String nombre, String estatus)
        {
            this.IdPuesto = id;
            this.NombrePuesto1 = nombre;
            this.EstatusPuesto = estatus;
        }

        public Puesto()
        {

        }

        public void funInsertar()
        {
            String psql = "INSERT INTO Puesto(idPuesto,nombrePuesto,estatusPuesto)" +
             " VALUES('" + idPuesto + "' , '" + NombrePuesto + "' , '" + estatusPuesto + "')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarCliente = new MySqlCommand(psql, conexionBD);
                insertarCliente.ExecuteNonQuery();
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
                sql = "SELECT * FROM puesto";
            }
            else
            {
                sql = "SELECT * FROM puesto WHERE idPuesto LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarPuesto = new MySqlCommand(sql, conexionBD);
                reader = buscarPuesto.ExecuteReader();


                while (reader.Read())
                {

                    Puesto puesto = new Puesto();

                    puesto.idPuesto = reader.GetString("idPuesto");
                    puesto.NombrePuesto = reader.GetString("nombrePuesto");
                    puesto.estatusPuesto = reader.GetString("estatusPuesto");

                    lista.Add(puesto);
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
            String pSqlModificar = "UPDATE puesto SET nombrePuesto='" + NombrePuesto + "' WHERE idPuesto='"+idModificar+"'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarPuesto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPuesto.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox id, TextBox nombre,TextBox estatus, String idPuesto)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from puesto WHERE idPuesto='" + idPuesto + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPuestos = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPuestos.ExecuteReader();

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

            String estatusPuesto = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusPuesto from puesto WHERE idPuesto='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPuesto = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPuesto.ExecuteReader();

                while (leer.Read())
                {
                    estatusPuesto = leer.GetString("estatusPuesto");
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

            return estatusPuesto;
        }

        public void funActivarPuesto()
        {
            String pSqlModificar = "UPDATE puesto SET estatusPuesto='A' WHERE idPuesto='" + idPuesto + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarPuesto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPuesto.ExecuteNonQuery();
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

        public void funDarBajaPuesto()
        {
            String pSqlModificar = "UPDATE puesto SET estatusPuesto='I' WHERE idPuesto='" + idPuesto + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarPuesto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPuesto.ExecuteNonQuery();
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
