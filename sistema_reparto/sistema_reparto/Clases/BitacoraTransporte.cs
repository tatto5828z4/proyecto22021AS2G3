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
    public class BitacoraTransporte
    {
        //Atributos
        String idBitacora;
        String idTransporte;
        String idPiloto;
        String kimInicial;
        String kimFinal;
        String fechaSalida;
        String fechaEntrada;
        String horaSalida;
        String horaEntrada;
        String lugarSalida;
        String lugarLlegada;
        String nivelGasolina;

        public BitacoraTransporte(string idBitacora, string idTransporte, string idPiloto, string kimInicial, string kimFinal, string fechaSalida, string fechaEntrada, string horaSalida, string horaEntrada, string lugarSalida, string lugarLlegada, string nivelGasolina)
        {
            this.idBitacora = idBitacora;
            this.idTransporte = idTransporte;
            this.idPiloto = idPiloto;
            this.kimInicial = kimInicial;
            this.kimFinal = kimFinal;
            this.fechaSalida = fechaSalida;
            this.fechaEntrada = fechaEntrada;
            this.horaSalida = horaSalida;
            this.horaEntrada = horaEntrada;
            this.lugarSalida = lugarSalida;
            this.lugarLlegada = lugarLlegada;
            this.nivelGasolina = nivelGasolina;
        }

        public string IdBitacora { get => idBitacora; set => idBitacora = value; }
        public string IdTransporte { get => idTransporte; set => idTransporte = value; }
        public string IdPiloto { get => idPiloto; set => idPiloto = value; }
        public string KimInicial { get => kimInicial; set => kimInicial = value; }
        public string KimFinal { get => kimFinal; set => kimFinal = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string LugarSalida { get => lugarSalida; set => lugarSalida = value; }
        public string LugarLlegada { get => lugarLlegada; set => lugarLlegada = value; }
        public string NivelGasolina { get => nivelGasolina; set => nivelGasolina = value; }

        public BitacoraTransporte()
        {

        }
        public void funInsertar()
        {
            if (IdBitacora == "" && IdTransporte == "" && IdPiloto == "" && KimInicial == "" && KimFinal == "" && FechaSalida == "" && FechaEntrada == "" && HoraSalida == "" && HoraEntrada == "" && LugarSalida == "" && LugarLlegada == "" && NivelGasolina == "")
            {
                MessageBox.Show("No se pueden dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String psql = "INSERT INTO bitacoraTransporte(idBitacora,idTransporte,idPiloto,kmInicial, kmFinal, fechaSalida, fechaEntrada, horaSalida, horaEntrada, lugarSalida, lugarLlegada, nivelGasolina)" +
             " VALUES('" + IdBitacora + "' , '" + IdTransporte + "' , '" + IdPiloto + "', '" + KimInicial + "', '" + KimFinal + "', '" + FechaSalida + "', '" + FechaEntrada + "', '" + HoraSalida + "', '" + HoraEntrada + "' , '" + LugarSalida + "' , '" + LugarLlegada + "' , '" + NivelGasolina + "' )";

                //Console.WriteLine(psql);
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand insertarBitacoraTransporte = new MySqlCommand(psql, conexionBD);
                    insertarBitacoraTransporte.ExecuteNonQuery();
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
                    sql = "SELECT * FROM bitacoraTransporte";
                }
                else
                {
                    sql = "SELECT * FROM bitacoraTransporte WHERE idBitacora LIKE '%" + dato + "%'";
                }

                try
                {
                    MySqlConnection conexionBD = Conexion.conexion();
                    conexionBD.Open();

                    MySqlCommand buscarBitacoraTransporte = new MySqlCommand(sql, conexionBD);
                    reader = buscarBitacoraTransporte.ExecuteReader();


                    while (reader.Read())
                    {

                        BitacoraTransporte bitacoraTransporte = new BitacoraTransporte();

                        bitacoraTransporte.IdBitacora = reader.GetString("idBitacora");
                        bitacoraTransporte.IdTransporte = reader.GetString("idTransporte");
                        bitacoraTransporte.IdPiloto = reader.GetString("idPiloto");
                        bitacoraTransporte.KimInicial = reader.GetString("kmInicial");
                        bitacoraTransporte.KimFinal = reader.GetString("kmFinal");
                        bitacoraTransporte.FechaSalida = reader.GetString("fechaSalida");
                        bitacoraTransporte.FechaEntrada = reader.GetString("fechaEntrada");
                        bitacoraTransporte.HoraSalida = reader.GetString("horaSalida");
                        bitacoraTransporte.HoraEntrada = reader.GetString("horaEntrada");
                        bitacoraTransporte.LugarSalida = reader.GetString("lugarSalida");
                        bitacoraTransporte.LugarLlegada = reader.GetString("lugarLlegada");
                        bitacoraTransporte.NivelGasolina = reader.GetString("nivelGasolina");

                    lista.Add(bitacoraTransporte);
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
            String pSqlModificar = "UPDATE bitacoraTransporte SET idTransporte='" + IdTransporte + "', idPiloto='" + IdPiloto + "', kmInicial='" + KimInicial + "', kmFinal='" + KimFinal + "', fechaSalida='" + FechaSalida + "', fechaEntrada='" + FechaEntrada + "', horaSalida='" + HoraSalida + "', horaEntrada='" + HoraEntrada + "' , lugarSalida='" + LugarSalida + "' , lugarLlegada='" + LugarLlegada + "' , nivelGasolina='" + NivelGasolina + "' WHERE idBitacora='" + idModificar + "'";

            //Console.WriteLine(pSqlModificar);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand modificarBitacoraTransporte = new MySqlCommand(pSqlModificar, conexionBD);
                modificarBitacoraTransporte.ExecuteNonQuery();
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
        public void funBuscarSetearTxt(TextBox idbi, ComboBox idtran, ComboBox idpil, TextBox kmini, TextBox kmfin, DateTimePicker fechasal, DateTimePicker fechaent, DateTimePicker horasal, DateTimePicker horaent, TextBox lugarsal, TextBox lugarlle, TextBox nivel, String idBitacora)
        {
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT * from bitacoraTransporte WHERE idBitacora='" + idBitacora + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarBitacoraTransporte = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarBitacoraTransporte.ExecuteReader();

                while (leer.Read())
                {
                    idbi.Text = leer.GetString(0);
                    idtran.Text = leer.GetString(1);
                    idpil.Text = leer.GetString(2);
                    kmini.Text = leer.GetString(3);
                    kmfin.Text = leer.GetString(4);
                    fechasal.Text = leer.GetString(5);
                    fechaent.Text = leer.GetString(6);
                    horasal.Text = leer.GetString(7);
                    horaent.Text = leer.GetString(8);
                    lugarsal.Text = leer.GetString(9);
                    lugarlle.Text = leer.GetString(10);
                    nivel.Text = leer.GetString(11);
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
        public void obtenerNombreT(String codigo)
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

        public void obtenerNombreP(String codigo)
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

    }
}
