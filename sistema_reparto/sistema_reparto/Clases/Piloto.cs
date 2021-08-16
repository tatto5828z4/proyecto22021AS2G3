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
    public class Piloto
    {
        //Atributos
        String idPiloto;
        String dpiPiloto;
        String idUser;
        String nombrePiloto;
        String apellidoPiloto;
        String telefonoPiloto;
        String direccionPiloto;
        String sueldoPiloto;
        String estatusPiloto;

        public Piloto(string idPiloto, string dpiPiloto, string idUser, string nombrePiloto, string apellidoPiloto, string telefonoPiloto, string direccionPiloto, string sueldoPiloto, string estatusPiloto)
        {
            this.idPiloto = idPiloto;
            this.dpiPiloto = dpiPiloto;
            this.idUser = idUser;
            this.nombrePiloto = nombrePiloto;
            this.apellidoPiloto = apellidoPiloto;
            this.telefonoPiloto = telefonoPiloto;
            this.direccionPiloto = direccionPiloto;
            this.sueldoPiloto = sueldoPiloto;
            this.estatusPiloto = estatusPiloto;
        }

        public string IdPiloto { get => idPiloto; set => idPiloto = value; }
        public string DpiPiloto { get => dpiPiloto; set => dpiPiloto = value; }
        public string IdUser { get => idUser; set => idUser = value; }
        public string NombrePiloto { get => nombrePiloto; set => nombrePiloto = value; }
        public string ApellidoPiloto { get => apellidoPiloto; set => apellidoPiloto = value; }
        public string TelefonoPiloto { get => telefonoPiloto; set => telefonoPiloto = value; }
        public string DireccionPiloto { get => direccionPiloto; set => direccionPiloto = value; }
        public string SueldoPiloto { get => sueldoPiloto; set => sueldoPiloto = value; }
        public string EstatusPiloto { get => estatusPiloto; set => estatusPiloto = value; }

        public Piloto()
        {

        }

        public void funInsertar()
        {
            if (IdPiloto == "" && DpiPiloto == "" && IdUser == "" && NombrePiloto == "" && ApellidoPiloto == "" && TelefonoPiloto == "" && DireccionPiloto == "" && SueldoPiloto == "" && EstatusPiloto == "")
            {
                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String psql = "INSERT INTO piloto(idPiloto,dpiPiloto,idUser,nombrePiloto, apellidoPiloto, telefonoPiloto, direccionPiloto, sueldoPiloto, estatusPiloto)" +
             " VALUES('" + IdPiloto + "' , '" + DpiPiloto + "' , '" + IdUser + "', '" + NombrePiloto + "', '" + ApellidoPiloto + "', '" + TelefonoPiloto + "', '" + DireccionPiloto + "', '" + SueldoPiloto + "', '" + EstatusPiloto + "')";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarPiloto = new MySqlCommand(psql, conexionBD);
                    insertarPiloto.ExecuteNonQuery();
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
                sql = "SELECT * FROM piloto";
            }
            else
            {
                sql = "SELECT * FROM piloto WHERE idPiloto LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarPiloto = new MySqlCommand(sql, conexionBD);
                reader = buscarPiloto.ExecuteReader();


                while (reader.Read())
                {

                    Piloto piloto = new Piloto();

                    piloto.IdPiloto = reader.GetString("idPiloto");
                    piloto.DpiPiloto = reader.GetString("dpiPiloto");
                    piloto.IdUser = reader.GetString("idUser");
                    piloto.NombrePiloto = reader.GetString("nombrePiloto");
                    piloto.ApellidoPiloto = reader.GetString("apellidoPiloto");
                    piloto.TelefonoPiloto = reader.GetString("telefonoPiloto");
                    piloto.DireccionPiloto = reader.GetString("direccionPiloto");
                    piloto.SueldoPiloto = reader.GetString("sueldoPiloto");
                    piloto.EstatusPiloto = reader.GetString("estatusPiloto");


                    lista.Add(piloto);
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
            Console.WriteLine(IdPiloto);
            String pSqlModificar = "UPDATE piloto SET dpiPiloto='" + DpiPiloto + "', idUser='" + IdUser + "', nombrePiloto='" + NombrePiloto + "', apellidoPiloto='" + ApellidoPiloto + "', telefonoPiloto='" + TelefonoPiloto + "', direccionPiloto='" + DireccionPiloto + "', sueldoPiloto='" + SueldoPiloto + "' WHERE idPiloto='" + idModificar + "'";

            //Console.WriteLine(pSqlModificar);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarPiloto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPiloto.ExecuteNonQuery();
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
        public void funBuscarSetearTxt(TextBox id, TextBox dpi, ComboBox iduser, TextBox nombre, TextBox apellido, TextBox telefono, TextBox direccion, TextBox sueldo, TextBox estatus, String idPiloto)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from piloto WHERE idPiloto='" + idPiloto + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPiloto = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPiloto.ExecuteReader();

                while (leer.Read())
                {
                    id.Text = leer.GetString(0);
                    dpi.Text = leer.GetString(1);
                    iduser.Text = leer.GetString(2);
                    nombre.Text = leer.GetString(3);
                    apellido.Text = leer.GetString(4);
                    telefono.Text = leer.GetString(5);
                    direccion.Text = leer.GetString(6);
                    sueldo.Text = leer.GetString(7);
                    estatus.Text = leer.GetString(8);
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

            String estatusPiloto = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusPiloto from piloto WHERE idpiloto='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarPiloto = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPiloto.ExecuteReader();

                while (leer.Read())
                {
                    estatusPiloto = leer.GetString("estatusPiloto");
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

            return estatusPiloto;
        }
        public void funActivar()
        {
            String pSqlModificar = "UPDATE piloto SET estatusPiloto='A' WHERE idPiloto='" + IdPiloto + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarPiloto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPiloto.ExecuteNonQuery();
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
        public void funDarBaja()
        {
            String pSqlModificar = "UPDATE piloto SET estatusPiloto='I' WHERE idPiloto='" + IdPiloto + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarPiloto = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPiloto.ExecuteNonQuery();
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
        public void funLlenarCombo(ComboBox combobox, String tabla, String id, String nombre)
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
        public void obtenerNombreUsuario(String idUsuario)
        {
            MySqlDataReader leer = null;
            String pSqlBuscar = "SELECT nombreUsuario from usuario WHERE idUser='" + idUsuario + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscar = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscar.ExecuteReader();

                while (leer.Read())
                {
                    idUsuario = leer.GetString("nombreUsuario");
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

    }
    
}
