using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto
{
    public class Departamento
    {

        // Atributos
        String idDepartamento;
        String NombreDepartamento;
        String EstatusDepartamento;

        public string IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public string NombreDepartamento1 { get => NombreDepartamento; set => NombreDepartamento = value; }
        public string EstatusDepartamento1 { get => EstatusDepartamento; set => EstatusDepartamento = value; }

        public Departamento(String id, String nombre, String estatus)
        {
            this.IdDepartamento = id;
            this.NombreDepartamento1 = nombre;
            this.EstatusDepartamento1 = estatus;
        }

        public Departamento()
        {

        }

        public void funInsertar()
        {
            String psql = "INSERT INTO departamento(idDepartamento,nombreDepartamentos,estatusDepartamento)" +
             " VALUES('" + idDepartamento + "' , '" + NombreDepartamento + "' , '" + EstatusDepartamento + "')";

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
                sql = "SELECT * FROM departamento";
            }
            else
            {
                sql = "SELECT * FROM departamento WHERE idDepartamento LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarDepartamento = new MySqlCommand(sql, conexionBD);
                reader = buscarDepartamento.ExecuteReader();


                while (reader.Read())
                {

                    Departamento departamento = new Departamento();

                    departamento.idDepartamento = reader.GetString("idDepartamento");
                    departamento.NombreDepartamento = reader.GetString("nombreDepartamentos");
                    departamento.EstatusDepartamento = reader.GetString("estatusDepartamento");

                    lista.Add(departamento);
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
            String pSqlModificar = "UPDATE departamento SET nombreDepartamentos='" + NombreDepartamento + "' WHERE idDepartamento='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarDepartamento = new MySqlCommand(pSqlModificar, conexionBD);
                modificarDepartamento.ExecuteNonQuery();
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


        public void funBuscarSetearTxt(TextBox id, TextBox nombre, TextBox estatus, String idDepartamento)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from departamento WHERE idDepartamento='" + idDepartamento + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarDepartamento = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarDepartamento.ExecuteReader();

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

            String estatusDepartamento = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusDepartamento from departamento WHERE idDepartamento='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarDepartamento = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarDepartamento.ExecuteReader();

                while (leer.Read())
                {
                    estatusDepartamento = leer.GetString("estatusDepartamento");
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

            return estatusDepartamento;
        }



        public void funActivarDepartamento()
        {
            String pSqlModificar = "UPDATE departamento SET estatusDepartamento='A' WHERE idDepartamento='" + idDepartamento + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarDepartamento = new MySqlCommand(pSqlModificar, conexionBD);
                modificarDepartamento.ExecuteNonQuery();
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

        public void funDarBajaDepartamento()
        {
            String pSqlModificar = "UPDATE departamento SET estatusDepartamento='I' WHERE idDepartamento='" + idDepartamento + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarDepartamento = new MySqlCommand(pSqlModificar, conexionBD);
                modificarDepartamento.ExecuteNonQuery();
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
