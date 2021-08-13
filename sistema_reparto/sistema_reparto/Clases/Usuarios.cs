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
    public class Usuarios
    {
        //Atributos
        String idUsuario;
        String idPermiso;
        String nombreUsuario;
        String passUsuario;
        String estatus;

        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string IdPermiso { get => idPermiso; set => idPermiso = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string PassUsuario { get => passUsuario; set => passUsuario = value; }
        public string Estatus { get => estatus; set => estatus = value; }

        String codigoPermiso;
        int ingresarUsuario;
        int modificarUsuario;
        int dbUsuario;
        int consultaUsuario;
        int ingresarCliente;
        int modificarCliente;
        int dbCliente;
        int consultarCliente;
        int ingresarDepto;
        int modificarDepto;
        int dbDepto;
        int consultaDepto;
        int ingresarPuesto;
        int modificarPuesto;
        int dbPuesto;
        int consultaPuesto;
        int ingresarPiloto;
        int modificarPiloto;
        int dbPiloto;
        int consultaPiloto;
        int ingresarEmpleado;
        int modificarEmpleado;
        int dbEmpleado;
        int consultarEmpleado;
        int ingresarPaqueteEnc;
        int modificarPaqueteEnc;
        int dbPaqueteEnc;
        int consultarPaqueteEnc;
        int ingresarPaqueteDet;
        int modificarPaqueteDet;
        int dbPaqueteDet;
        int consultarPaqueteDet;
        int ingresarUbicacion;
        int modificarUbicacion;
        int dbUbicacion;
        int consultarUbicacion;
        int ingresarSububicacion;
        int modificarSububcacion;
        int dbSububicacion;
        int consultarSububicacion;
        int ingresarBodega;
        int modificarBodega;
        int dbBodega;
        int consultarBodega;
        int ingresarInventario;
        int modificarInventario;
        int consultarInventario;
        int consultarMovBodega;
        int ingresarTipoTrans;
        int modificarTipoTrans;
        int dbTipoTrans;
        int consultarTipoTrans;
        int ingresarTransporte;
        int modificarTransporte;
        int dbTransporte;
        int consultarTransporte;
        int ingresarRuta;
        int modificarRuta;
        int dbRuta;
        int consultarRuta;
        int ingresarEnvio;
        int modificarEnvio;
        int dbEnvio;
        int consultarEnvio;
        int ingresarBitacoraTrans;
        int modificarBitacoraTrans;
        int consultarBitacoraTrans;
        int consultaBitacoraUsuario;
        int ingresarCalificacion;
        int modificarCalificacion;
        int consultaCalificacion;
        int reportes;



        public Usuarios()
        {

        }

        public Usuarios(string idUsuario, string idPermiso, string nombreUsuario, string passUsuario, string estatus, string codigoPermiso, int ingresarUsuario, int modificarUsuario, int dbUsuario, int consultaUsuario, int ingresarCliente, int modificarCliente, int dbCliente, int consultarCliente, int ingresarDepto, int modificarDepto, int dbDepto, int consultaDepto, int ingresarPuesto, int modificarPuesto, int dbPuesto, int consultaPuesto, int ingresarPiloto, int modificarPiloto, int dbPiloto, int consultaPiloto, int ingresarEmpleado, int modificarEmpleado, int dbEmpleado, int consultarEmpleado, int ingresarPaqueteEnc, int modificarPaqueteEnc, int dbPaqueteEnc, int consultarPaqueteEnc, int ingresarPaqueteDet, int modificarPaqueteDet, int dbPaqueteDet, int consultarPaqueteDet, int ingresarUbicacion, int modificarUbicacion, int dbUbicacion, int consultarUbicacion, int ingresarSububicacion, int modificarSububcacion, int dbSububicacion, int consultarSububicacion, int ingresarBodega, int modificarBodega, int dbBodega, int consultarBodega, int ingresarInventario, int modificarInventario, int consultarInventario, int consultarMovBodega, int ingresarTipoTrans, int modificarTipoTrans, int dbTipoTrans, int consultarTipoTrans, int ingresarTransporte, int modificarTransporte, int dbTransporte, int consultarTransporte, int ingresarRuta, int modificarRuta, int dbRuta, int consultarRuta, int ingresarEnvio, int modificarEnvio, int dbEnvio, int consultarEnvio, int ingresarBitacoraTrans, int modificarBitacoraTrans, int consultarBitacoraTrans, int consultaBitacoraUsuario, int ingresarCalificacion, int modificarCalificacion, int consultaCalificacion, int reportes)
        {
            this.idUsuario = idUsuario;
            this.idPermiso = idPermiso;
            this.nombreUsuario = nombreUsuario;
            this.passUsuario = passUsuario;
            this.estatus = estatus;
            this.codigoPermiso = codigoPermiso;
            this.ingresarUsuario = ingresarUsuario;
            this.modificarUsuario = modificarUsuario;
            this.dbUsuario = dbUsuario;
            this.consultaUsuario = consultaUsuario;
            this.ingresarCliente = ingresarCliente;
            this.modificarCliente = modificarCliente;
            this.dbCliente = dbCliente;
            this.consultarCliente = consultarCliente;
            this.ingresarDepto = ingresarDepto;
            this.modificarDepto = modificarDepto;
            this.dbDepto = dbDepto;
            this.consultaDepto = consultaDepto;
            this.ingresarPuesto = ingresarPuesto;
            this.modificarPuesto = modificarPuesto;
            this.dbPuesto = dbPuesto;
            this.consultaPuesto = consultaPuesto;
            this.ingresarPiloto = ingresarPiloto;
            this.modificarPiloto = modificarPiloto;
            this.dbPiloto = dbPiloto;
            this.consultaPiloto = consultaPiloto;
            this.ingresarEmpleado = ingresarEmpleado;
            this.modificarEmpleado = modificarEmpleado;
            this.dbEmpleado = dbEmpleado;
            this.consultarEmpleado = consultarEmpleado;
            this.ingresarPaqueteEnc = ingresarPaqueteEnc;
            this.modificarPaqueteEnc = modificarPaqueteEnc;
            this.dbPaqueteEnc = dbPaqueteEnc;
            this.consultarPaqueteEnc = consultarPaqueteEnc;
            this.ingresarPaqueteDet = ingresarPaqueteDet;
            this.modificarPaqueteDet = modificarPaqueteDet;
            this.dbPaqueteDet = dbPaqueteDet;
            this.consultarPaqueteDet = consultarPaqueteDet;
            this.ingresarUbicacion = ingresarUbicacion;
            this.modificarUbicacion = modificarUbicacion;
            this.dbUbicacion = dbUbicacion;
            this.consultarUbicacion = consultarUbicacion;
            this.ingresarSububicacion = ingresarSububicacion;
            this.modificarSububcacion = modificarSububcacion;
            this.dbSububicacion = dbSububicacion;
            this.consultarSububicacion = consultarSububicacion;
            this.ingresarBodega = ingresarBodega;
            this.modificarBodega = modificarBodega;
            this.dbBodega = dbBodega;
            this.consultarBodega = consultarBodega;
            this.ingresarInventario = ingresarInventario;
            this.modificarInventario = modificarInventario;
            this.consultarInventario = consultarInventario;
            this.consultarMovBodega = consultarMovBodega;
            this.ingresarTipoTrans = ingresarTipoTrans;
            this.modificarTipoTrans = modificarTipoTrans;
            this.dbTipoTrans = dbTipoTrans;
            this.consultarTipoTrans = consultarTipoTrans;
            this.ingresarTransporte = ingresarTransporte;
            this.modificarTransporte = modificarTransporte;
            this.dbTransporte = dbTransporte;
            this.consultarTransporte = consultarTransporte;
            this.ingresarRuta = ingresarRuta;
            this.modificarRuta = modificarRuta;
            this.dbRuta = dbRuta;
            this.consultarRuta = consultarRuta;
            this.ingresarEnvio = ingresarEnvio;
            this.modificarEnvio = modificarEnvio;
            this.dbEnvio = dbEnvio;
            this.consultarEnvio = consultarEnvio;
            this.ingresarBitacoraTrans = ingresarBitacoraTrans;
            this.modificarBitacoraTrans = modificarBitacoraTrans;
            this.consultarBitacoraTrans = consultarBitacoraTrans;
            this.consultaBitacoraUsuario = consultaBitacoraUsuario;
            this.ingresarCalificacion = ingresarCalificacion;
            this.modificarCalificacion = modificarCalificacion;
            this.consultaCalificacion = consultaCalificacion;
            this.reportes = reportes;
        }

        public void funInsertarPermisos()
        {
            String psql = "INSERT INTO permisos(idPermiso,idTipoPermiso,ingresarUser,modificarUser,dbusuario,consultarUser,ingresarCliente,modificarCliente," +
            "dbCliente,consultarCliente,ingresarDepartamento,modificarDepartamento,dbDepartamento,consultarDepartamento,ingresarPuesto,modificarPuesto,dbPuesto," +
            "consultarPuesto,ingresarPiloto,modificarPiloto,dbPiloto,consultarPiloto,ingresarEmpleado,modificarEmpleado,dbEmpleado,consultarEmpleado,ingresarPaqueteEncabezado," +
            "modificarPaqueteEncabezado,dbPaqueteEncabezado,consultarPaqueteEncabezado,ingresarPaqueteDetalle,modificarPaqueteDetalle,dbPaqueteDetalle,consultarPaqueteDetalle," +
            "insertarUbicacion,modificarUbicacion,dbubicacion,consultarUbicacion,insertarSububicacion,modificarSububicacion,dbSububicacion,consultarSububicacion," +
            "insertarBodega,modifcarBodega,dbBodega,consultarBodega,insertarInventario,modificarInventario,consultarInventario,consultarMovBodega,insertarTipoTransp," +
            "modificarTipoTransp,dbTipoTransp,consultarTipoTransp,insertarTransporte,modificarTransporte,dbTransporte,consultarTransporte,ingresarRuta,modificarRuta," +
            "dbRuta,consultarRuta,ingresarEnvio,modificarEnvio,dbEnvio,consultarEnvio,ingresarBT,modificarBT,consultaBT,consultaBU,ingresarCalificacion,modificarCalificacion," +
            "consultaCalificacion,reportes)" +
            " VALUES('" + codigoPermiso + "' , '" + idPermiso + "' , '" + ingresarUsuario + "' , '" + modificarUsuario + "' , '" + dbUsuario + "', '" + consultaUsuario + "'," +
            "'" + ingresarCliente + "', '" + modificarCliente + "' , '" + dbCliente + "', '" + consultarCliente + "' ," +
            "'" + ingresarDepto + "', '" + modificarDepto + "', '" + dbDepto + "', '" + consultaDepto + "'," +
            "'" + ingresarPuesto + "', '" + modificarPuesto + "', '" + dbPuesto + "', '" + consultaPuesto + "' ," +
            "'" + ingresarPiloto + "', '" + modificarPiloto + "' , '" + dbPiloto + "', '" + consultaPiloto + "' ," +
            "'" + ingresarEmpleado + "', '" + modificarEmpleado + "', '" + dbEmpleado + "', '" + consultarEmpleado + "' ," +
            "'" + ingresarPaqueteEnc + "', '" + modificarPaqueteEnc + "', '" + dbPaqueteEnc + "' , '" + consultarPaqueteEnc + "' ," +
            "'" + ingresarPaqueteDet + "', '" + modificarPaqueteDet + "' , '" + dbPaqueteDet + "' , '" + consultarPaqueteDet + "'," +
            "'" + ingresarUbicacion + "', '" + modificarUbicacion + "', '" + dbUbicacion + "', '" + consultarUbicacion + "' ," +
            "'" + ingresarSububicacion + "', '" + modificarSububcacion + "' , '" + dbSububicacion + "', '" + consultarSububicacion + "' ," +
            "'" + ingresarBodega + "', '" + modificarBodega + "', '" + dbBodega + "' , '" + consultarBodega + "'," +
            "'" + ingresarInventario + "' , '" + modificarInventario + "' , '" + consultarInventario + "'," +
            "'" + consultarMovBodega + "'," +
            "'" + ingresarTipoTrans + "' , '" + modificarTipoTrans + "' , '" + dbTipoTrans + "' , '" + consultarTipoTrans + "'," +
            "'" + ingresarTransporte + "' , '" + modificarTransporte + "' , '" + dbTransporte + "' , '" + consultarTransporte + "'," +
            "'" + ingresarRuta + "' , '" + modificarRuta + "' , '" + dbTransporte + "', '" + consultarTransporte + "', " +
            "'" + ingresarEnvio + "', '" + modificarEnvio + "' , '" + dbEnvio + "' , '" + consultarEnvio + "' ," +
            "'" + ingresarBitacoraTrans + "' , '" + modificarBitacoraTrans + "' , '" + consultarBitacoraTrans + "' , " +
            "'" + consultaBitacoraUsuario + "' , " +
            "'" + ingresarCalificacion + "' , '" + modificarCalificacion + "', '" + consultaCalificacion + "' , " +
            "'" + reportes + "')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarPermisos = new MySqlCommand(psql, conexionBD);
                insertarPermisos.ExecuteNonQuery();
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

        public void funInsertarUsuario()
        {
            String psql = "INSERT INTO usuario(idUser,idPermiso,nombreUsuario,passwordUsuario,estatusUsuario)" +
             " VALUES('" + idUsuario + "' , '" + codigoPermiso + "' , '" + nombreUsuario + "' , '" + passUsuario + "' , '" + estatus + "')";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand insertarUsuarios = new MySqlCommand(psql, conexionBD);
                insertarUsuarios.ExecuteNonQuery();
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
                sql = "SELECT * FROM usuario";
            }
            else
            {
                sql = "SELECT * FROM usuario WHERE idUser LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarUsuario = new MySqlCommand(sql, conexionBD);
                reader = buscarUsuario.ExecuteReader();


                while (reader.Read())
                {

                    Usuarios usuario = new Usuarios();

                    usuario.idUsuario = reader.GetString("idUser");
                    usuario.idPermiso = reader.GetString("idPermiso");
                    usuario.nombreUsuario = reader.GetString("nombreUsuario");
                    usuario.passUsuario = reader.GetString("passwordUsuario");
                    usuario.estatus = reader.GetString("estatusUsuario");

                    lista.Add(usuario);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }

        public void funModificarPermisos(String idModificar)
        {
            String pSqlModificar = "UPDATE permisos SET idTipoPermiso='" + idPermiso + "', ingresarUser='" + ingresarUsuario + "', modificarUser='" + modificarUsuario + "'" +
            ", dbusuario='" + dbUsuario + "', consultarUser='" + consultaUsuario + "' , ingresarCliente='" + ingresarCliente + "' " +
            ", modificarCliente='" + modificarCliente + "', dbCliente='" + dbCliente + "', consultarCliente='" + consultarCliente + "' " +
            ", ingresarDepartamento='" + ingresarDepto + "', modificarDepartamento='" + modificarDepto + "' " +
            ", dbDepartamento='" + dbDepto + "' , consultarDepartamento='" + consultaDepto + "' " +
            ", ingresarPuesto='" + ingresarPuesto + "' , modificarPuesto='" + modificarPuesto + "' , dbPuesto='" + dbPuesto + "' , consultarPuesto='" + consultaPuesto + "' " +
            ", ingresarPiloto='" + ingresarPiloto + "', modificarPiloto='" + modificarPiloto + "', dbPiloto='" + dbPiloto + "' , consultarPiloto='" + consultaPiloto + "' " +
            ", ingresarEmpleado='" + ingresarEmpleado + "' , modificarEmpleado='" + modificarEmpleado + "' , dbEmpleado='" + dbEmpleado + "' , consultarEmpleado='" + consultarEmpleado + "' " +
            ", ingresarPaqueteEncabezado='" + ingresarPaqueteEnc + "' , modificarPaqueteEncabezado='" + modificarPaqueteEnc + "' , dbPaqueteEncabezado='" + dbPaqueteEnc + "' " +
            ", consultarPaqueteEncabezado='" + consultarPaqueteEnc + "' , ingresarPaqueteDetalle='" + ingresarPaqueteDet + "' , modificarPaqueteDetalle='" + modificarPaqueteDet + "' " +
            ", dbPaqueteDetalle='" + dbPaqueteDet + "' , consultarPaqueteDetalle='" + consultarPaqueteDet + "' , insertarUbicacion='" + ingresarUbicacion + "' " +
            ", modificarUbicacion='" + modificarUbicacion + "' , dbubicacion='" + dbUbicacion + "' , consultarUbicacion='" + consultarUbicacion + "' " +
            ", insertarSububicacion='" + ingresarSububicacion + "' , modificarSububicacion='" + modificarSububcacion + "' , dbSububicacion='" + dbSububicacion + "' " +
            ", consultarSububicacion='" + consultarSububicacion + "' , insertarBodega='" + ingresarBodega + "' , modifcarBodega='" + modificarBodega + "' " +
            ", dbBodega='" + dbBodega + "', consultarBodega='" + consultarBodega + "', insertarInventario='" + ingresarInventario + "' , modificarInventario='" + modificarInventario + "'" +
            ", consultarInventario='" + consultarInventario + "' , consultarMovBodega='" + consultarMovBodega + "' , insertarTipoTransp='" + ingresarTipoTrans + "' " +
            ", modificarTipoTransp='" + modificarTipoTrans + "' , dbTipoTransp='" + dbTipoTrans + "' , consultarTipoTransp='" + consultarTipoTrans + "'  " +
            ", insertarTransporte='" + ingresarTransporte + "' ,  modificarTransporte='" + modificarTransporte + "' , dbTransporte='" + dbTransporte + "' " +
            ", consultarTransporte='" + consultarTransporte + "' , ingresarRuta='" + ingresarRuta + "' , modificarRuta='" + modificarRuta + "' , dbRuta='" + dbRuta + "'  " +
            ", consultarRuta='" + consultarRuta + "' , ingresarEnvio='" + ingresarEnvio + "' , modificarEnvio='" + modificarEnvio + "' , dbEnvio='" + dbEnvio + "' " +
            ", consultarEnvio='" + consultarEnvio + "' , ingresarBT='" + ingresarBitacoraTrans + "' , modificarBT='" + modificarBitacoraTrans + "' " +
            ", consultaBT='" + consultarBitacoraTrans + "' , consultaBU='" + consultaBitacoraUsuario + "' , ingresarCalificacion='" + ingresarCalificacion + "' " +
            ", modificarCalificacion='" + modificarCalificacion + "' , consultaCalificacion='" + consultaCalificacion + "', reportes='" + reportes + "'  WHERE idPermiso='" + idModificar + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarPermisos = new MySqlCommand(pSqlModificar, conexionBD);
                modificarPermisos.ExecuteNonQuery();
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

        public void funModificarUsuario()
        {
            String pSqlModificar = "UPDATE usuario SET idPermiso='" + codigoPermiso + "' , nombreUsuario='"+nombreUsuario+"'" +
            ", passwordUsuario='"+passUsuario+ "' WHERE idUser='" + idUsuario + "'";

            //Console.WriteLine(psql);
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUsuario = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUsuario.ExecuteNonQuery();
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

        public void funBuscarSetearTxt(TextBox nombreU, TextBox passU, TextBox estatusU, ComboBox tipoP, CheckBox chkIngresarU
        , CheckBox chkModificarU, CheckBox chkDarBajaU, CheckBox chkConsultaU, CheckBox chkIngresarC, CheckBox chkModificarC,
        CheckBox chkDarBajaC, CheckBox chkConsultarC, CheckBox chkIngresarD, CheckBox chkModificarD, CheckBox chkDarBajaD, CheckBox chkConsultarD,
        CheckBox chkIngresarPu, CheckBox chkModificarPu, CheckBox chkDarBajaPu, CheckBox chkConsultaPu, CheckBox chkIngresarPi, CheckBox chkModificarPi,
        CheckBox chkDarBajaPi, CheckBox chkConsultaPi, CheckBox chkIngresarEm, CheckBox chkModificarE, CheckBox chkDarBajaE, CheckBox chkConsultaE,
        CheckBox chkPaqueteEnc, CheckBox chkModificarEnc, CheckBox chkDarBajaPaEnc, CheckBox chkConsultaPaEc, CheckBox chkIngresarPaDe,
        CheckBox chkModificarPaDet, CheckBox chkDarBajaPaDet, CheckBox chkConsultaDet, CheckBox chkIngresarUb, CheckBox chkModificarUb,
        CheckBox chkDarBajaUb, CheckBox chkConsultaUb, CheckBox chkIngresarSub, CheckBox chkModificarSub, CheckBox chkDarBajaSub,
        CheckBox chkConsultaSub, CheckBox chkIngresarBo, CheckBox chkModificarBo, CheckBox chkDarBajaBo, CheckBox chkConsultarBo,
        CheckBox chkInventario, CheckBox chkModificarIn, CheckBox chkConsultaIn, CheckBox chkConsultarMovBo, CheckBox chkIngresarTipoT,
        CheckBox chkModificarTiT, CheckBox chkDarBajaTip, CheckBox chkConsultarTip, CheckBox chkIngresarTra, CheckBox chkModificarTra,
        CheckBox chkDarBajaTra, CheckBox chkConsultarTra, CheckBox chkIngresarRuta, CheckBox chkModificarRu, CheckBox chkDarBajaRu,
        CheckBox chkConsultarRu, CheckBox chkIngresarEnvio, CheckBox chkModificarEn, CheckBox chkDarBajaEn, CheckBox chkConsultaEn,
        CheckBox chkInsertarBitaTrans, CheckBox chkModificarBi, CheckBox chkConsultarBTTras, CheckBox chkBitacoraUsuario,
        CheckBox chkIngresarCalificacion, CheckBox chkModificarCa, CheckBox chkConsultarCa, CheckBox chkReportes, String idUsuario, String idPermiso)
        {
            MySqlDataReader leer = null;
            MySqlDataReader leerPermisos = null;

            String ingresarUsuario = "";
            String modificarUsuario = "";
            String dbUsuario = "";
            String consultarUser = "";
            String ingresarCliente = "";
            String modificarCliente = "";
            String dbCliente = "";
            String consultarCliente = "";
            String ingresarDep = "";
            String modificarDep = "";
            String dbDep = "";
            String consultarDep = "";
            String ingresarPuesto = "";
            String modificarPuesto = "";
            String dbPuesto = "";
            String consultarPuesto = "";
            String ingresarPiloto = "";
            String modificarPiloto = "";
            String dbPiloto = "";
            String consultarPiloto = "";
            String ingresarEmple = "";
            String modificarEmple = "";
            String dbEmpleado = "";
            String consultarEmple = "";
            String ingresarPaEnc = "";
            String modificarPaEnc = "";
            String dbPacEnc = "";
            String consultarPaEnc = "";
            String ingresarPaDet = "";
            String modificarPaDet = "";
            String dbPaDet = "";
            String consultarPaDet = "";
            String ingresarUb = "";
            String modificarUb = "";
            String dbUbicacion = "";
            String consultarUb = "";
            String ingresarSubUb = "";
            String modificarSubUb = "";
            String dbSubUb = "";
            String consultarSubUb = "";
            String ingresarBo = "";
            String modificarBo = "";
            String dbBodega = "";
            String consultarBo = "";
            String insertarIn = "";
            String modificarIn = "";
            String consultarIn = "";
            String consultarMovBo = "";
            String ingresarTipoTrans = "";
            String modificarTipoTrans = "";
            String dbTipoTrans = "";
            String consultarTipoTrans = "";
            String ingresarTrans = "";
            String modificarTrans = "";
            String dbTrans = "";
            String consultarTrans = "";
            String ingresarRuta = "";
            String modificaRuta = "";
            String dbRuta = "";
            String consultarRuta = "";
            String ingresarEnvio = "";
            String modificarEnvio = "";
            String dbEnvio = "";
            String consultarEnvio = "";
            String ingresarBT = "";
            String modificarBT = "";
            String consultarBT = "";
            String consultarBU = "";
            String ingresarCali = "";
            String modificarCali = "";
            String consultaCali = "";
            String reportes = "";

            String pSqlBuscar = "SELECT * from usuario WHERE idUser='" + idUsuario + "'";
            String pSqlPermisos = "SELECT * from permisos WHERE idPermiso='" + idPermiso + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarUsuarios = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarUsuarios.ExecuteReader();

                while (leer.Read())
                {
                    nombreU.Text = leer.GetString("nombreUsuario");
                    passU.Text = leer.GetString("passwordUsuario");
                    estatusU.Text = leer.GetString("estatusUsuario");
                }

                conexionBD.Close();

                conexionBD.Open();
                MySqlCommand buscarPermisos = new MySqlCommand(pSqlPermisos, conexionBD);
                leerPermisos = buscarPermisos.ExecuteReader();

                while (leerPermisos.Read())
                {
                    tipoP.Text = leerPermisos.GetString("idTipoPermiso");

                    ingresarUsuario = leerPermisos.GetString("ingresarUser");
                    modificarUsuario = leerPermisos.GetString("modificarUser");
                    dbUsuario = leerPermisos.GetString("dbusuario");
                    consultarUser = leerPermisos.GetString("consultarUser");
                    ingresarCliente = leerPermisos.GetString("ingresarCliente");
                    modificarCliente = leerPermisos.GetString("modificarCliente");
                    dbCliente = leerPermisos.GetString("dbCliente");
                    consultarCliente = leerPermisos.GetString("consultarCliente");
                    ingresarDep = leerPermisos.GetString("ingresarDepartamento");
                    modificarDep = leerPermisos.GetString("modificarDepartamento");
                    dbDep = leerPermisos.GetString("dbDepartamento");
                    consultarDep = leerPermisos.GetString("consultarDepartamento");
                    ingresarPuesto = leerPermisos.GetString("ingresarPuesto");
                    modificarPuesto = leerPermisos.GetString("modificarPuesto");
                    dbPuesto = leerPermisos.GetString("dbPuesto");
                    consultarPuesto = leerPermisos.GetString("consultarPuesto");
                    ingresarPiloto = leerPermisos.GetString("ingresarPiloto");
                    modificarPiloto = leerPermisos.GetString("modificarPiloto");
                    dbPiloto = leerPermisos.GetString("dbPiloto");
                    consultarPiloto = leerPermisos.GetString("consultarPiloto");
                    ingresarEmple = leerPermisos.GetString("ingresarEmpleado");
                    modificarEmple = leerPermisos.GetString("modificarEmpleado");
                    dbEmpleado = leerPermisos.GetString("dbEmpleado");
                    consultarEmple = leerPermisos.GetString("consultarEmpleado");
                    ingresarPaEnc = leerPermisos.GetString("ingresarPaqueteEncabezado");
                    modificarPaEnc = leerPermisos.GetString("modificarPaqueteEncabezado");
                    dbPacEnc = leerPermisos.GetString("dbPaqueteEncabezado");
                    consultarPaEnc = leerPermisos.GetString("consultarPaqueteEncabezado");
                    ingresarPaDet = leerPermisos.GetString("ingresarPaqueteDetalle");
                    modificarPaDet = leerPermisos.GetString("modificarPaqueteDetalle");
                    dbPaDet = leerPermisos.GetString("dbPaqueteDetalle");
                    consultarPaDet = leerPermisos.GetString("consultarPaqueteDetalle");
                    ingresarUb = leerPermisos.GetString("insertarUbicacion");
                    modificarUb = leerPermisos.GetString("modificarUbicacion");
                    dbUbicacion = leerPermisos.GetString("dbubicacion");
                    consultarUb = leerPermisos.GetString("consultarUbicacion");
                    ingresarSubUb = leerPermisos.GetString("insertarSububicacion");
                    modificarSubUb = leerPermisos.GetString("modificarSububicacion");
                    dbSubUb = leerPermisos.GetString("dbSububicacion");
                    consultarSubUb = leerPermisos.GetString("consultarSububicacion");
                    ingresarBo = leerPermisos.GetString("insertarBodega");
                    modificarBo = leerPermisos.GetString("modifcarBodega");
                    dbBodega = leerPermisos.GetString("dbBodega");
                    consultarBo = leerPermisos.GetString("consultarBodega");
                    insertarIn = leerPermisos.GetString("insertarInventario");
                    modificarIn = leerPermisos.GetString("modificarInventario");
                    consultarIn = leerPermisos.GetString("consultarInventario");
                    consultarMovBo = leerPermisos.GetString("consultarMovBodega");
                    ingresarTipoTrans = leerPermisos.GetString("insertarTipoTransp");
                    modificarTipoTrans = leerPermisos.GetString("modificarTipoTransp");
                    dbTipoTrans = leerPermisos.GetString("dbTipoTransp");
                    consultarTipoTrans = leerPermisos.GetString("consultarTipoTransp");
                    ingresarTrans = leerPermisos.GetString("insertarTransporte");
                    modificarTrans = leerPermisos.GetString("modificarTransporte");
                    dbTrans = leerPermisos.GetString("dbTransporte");
                    consultarTrans = leerPermisos.GetString("consultarTransporte");
                    ingresarRuta = leerPermisos.GetString("ingresarRuta");
                    modificaRuta = leerPermisos.GetString("modificarRuta");
                    dbRuta = leerPermisos.GetString("dbRuta");
                    consultarRuta = leerPermisos.GetString("consultarRuta");
                    ingresarEnvio = leerPermisos.GetString("ingresarEnvio");
                    modificarEnvio = leerPermisos.GetString("modificarEnvio");
                    dbEnvio = leerPermisos.GetString("dbEnvio");
                    consultarEnvio = leerPermisos.GetString("consultarEnvio");
                    ingresarBT = leerPermisos.GetString("ingresarBT");
                    modificarBT = leerPermisos.GetString("modificarBT");
                    consultarBT = leerPermisos.GetString("consultaBT");
                    consultarBU = leerPermisos.GetString("consultaBU");
                    ingresarCali = leerPermisos.GetString("ingresarCalificacion");
                    modificarCali = leerPermisos.GetString("modificarCalificacion");
                    consultaCali = leerPermisos.GetString("consultaCalificacion");
                    reportes = leerPermisos.GetString("reportes");


                    funBoolCheck(ingresarUsuario, chkIngresarU);
                    funBoolCheck(modificarUsuario, chkModificarU);
                    funBoolCheck(dbUsuario, chkDarBajaU);
                    funBoolCheck(consultarUser, chkConsultaU);
                    funBoolCheck(ingresarCliente, chkIngresarC);
                    funBoolCheck(modificarCliente, chkModificarC);
                    funBoolCheck(dbCliente, chkDarBajaC);
                    funBoolCheck(consultarCliente, chkConsultarC);
                    funBoolCheck(ingresarDep, chkIngresarD);
                    funBoolCheck(modificarDep, chkModificarD);
                    funBoolCheck(dbDep, chkDarBajaD);
                    funBoolCheck(consultarDep, chkConsultarD);
                    funBoolCheck(ingresarPuesto, chkIngresarPu);
                    funBoolCheck(modificarPuesto, chkModificarPu);
                    funBoolCheck(dbPuesto, chkDarBajaPu);
                    funBoolCheck(consultarPuesto, chkConsultaPu);
                    funBoolCheck(ingresarPiloto, chkIngresarPi);
                    funBoolCheck(modificarPiloto, chkModificarPi);
                    funBoolCheck(dbPiloto, chkDarBajaPi);
                    funBoolCheck(consultarPiloto, chkConsultaPi);
                    funBoolCheck(ingresarEmple, chkIngresarEm);
                    funBoolCheck(modificarEmple, chkModificarE);
                    funBoolCheck(dbEmpleado, chkDarBajaE);
                    funBoolCheck(consultarEmple, chkConsultaE);
                    funBoolCheck(ingresarPaEnc, chkPaqueteEnc);
                    funBoolCheck(modificarPaEnc, chkModificarEnc);
                    funBoolCheck(dbPacEnc, chkDarBajaPaEnc);
                    funBoolCheck(consultarPaEnc, chkConsultaPaEc);
                    funBoolCheck(ingresarPaDet, chkIngresarPaDe);
                    funBoolCheck(modificarPaDet, chkModificarPaDet);
                    funBoolCheck(dbPaDet, chkDarBajaPaDet);
                    funBoolCheck(consultarPaDet, chkConsultaDet);
                    funBoolCheck(ingresarUb, chkIngresarUb);
                    funBoolCheck(modificarUb, chkModificarUb);
                    funBoolCheck(dbUbicacion, chkDarBajaUb);
                    funBoolCheck(consultarUb, chkConsultaUb);
                    funBoolCheck(ingresarSubUb, chkIngresarSub);
                    funBoolCheck(modificarSubUb, chkModificarSub);
                    funBoolCheck(dbSubUb, chkDarBajaSub);
                    funBoolCheck(consultarSubUb, chkConsultaSub);
                    funBoolCheck(ingresarBo, chkIngresarBo);
                    funBoolCheck(modificarBo, chkModificarBo);
                    funBoolCheck(dbBodega, chkDarBajaBo);
                    funBoolCheck(consultarBo, chkConsultarBo);
                    funBoolCheck(insertarIn, chkInventario);
                    funBoolCheck(modificarIn, chkModificarIn);
                    funBoolCheck(consultarIn, chkConsultaIn);
                    funBoolCheck(consultarMovBo, chkConsultarMovBo);
                    funBoolCheck(ingresarTipoTrans, chkIngresarTipoT);
                    funBoolCheck(modificarTipoTrans, chkModificarTiT);
                    funBoolCheck(dbTipoTrans, chkDarBajaTip);
                    funBoolCheck(consultarTipoTrans, chkConsultarTip);
                    funBoolCheck(ingresarTrans, chkIngresarTra);
                    funBoolCheck(modificarTrans, chkModificarTra);
                    funBoolCheck(dbTrans, chkDarBajaTra);
                    funBoolCheck(consultarTrans, chkConsultarTra);
                    funBoolCheck(ingresarRuta, chkIngresarRuta);
                    funBoolCheck(modificaRuta, chkModificarRu);
                    funBoolCheck(dbRuta, chkDarBajaRu);
                    funBoolCheck(consultarRuta, chkConsultarRu);
                    funBoolCheck(ingresarEnvio, chkIngresarEnvio);
                    funBoolCheck(modificarEnvio, chkModificarEn);
                    funBoolCheck(dbEnvio, chkDarBajaEn);
                    funBoolCheck(consultarEnvio, chkConsultaEn);
                    funBoolCheck(ingresarBT, chkInsertarBitaTrans);
                    funBoolCheck(modificarBT, chkModificarBi);
                    funBoolCheck(consultarBT, chkConsultarBTTras);
                    funBoolCheck(consultarBU, chkBitacoraUsuario);
                    funBoolCheck(ingresarCali, chkIngresarCalificacion);
                    funBoolCheck(modificarCali, chkModificarCa);
                    funBoolCheck(consultaCali, chkConsultarCa);
                    funBoolCheck(reportes, chkReportes);
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

        public void funSetearChecks(CheckBox chkIngresarU, CheckBox chkModificarU, CheckBox chkDarBajaU, CheckBox chkConsultaU, CheckBox chkIngresarC, CheckBox chkModificarC,
        CheckBox chkDarBajaC, CheckBox chkConsultarC, CheckBox chkIngresarD, CheckBox chkModificarD, CheckBox chkDarBajaD, CheckBox chkConsultarD,
        CheckBox chkIngresarPu, CheckBox chkModificarPu, CheckBox chkDarBajaPu, CheckBox chkConsultaPu, CheckBox chkIngresarPi, CheckBox chkModificarPi,
        CheckBox chkDarBajaPi, CheckBox chkConsultaPi, CheckBox chkIngresarEm, CheckBox chkModificarE, CheckBox chkDarBajaE, CheckBox chkConsultaE,
        CheckBox chkPaqueteEnc, CheckBox chkModificarEnc, CheckBox chkDarBajaPaEnc, CheckBox chkConsultaPaEc, CheckBox chkIngresarPaDe,
        CheckBox chkModificarPaDet, CheckBox chkDarBajaPaDet, CheckBox chkConsultaDet, CheckBox chkIngresarUb, CheckBox chkModificarUb,
        CheckBox chkDarBajaUb, CheckBox chkConsultaUb, CheckBox chkIngresarSub, CheckBox chkModificarSub, CheckBox chkDarBajaSub,
        CheckBox chkConsultaSub, CheckBox chkIngresarBo, CheckBox chkModificarBo, CheckBox chkDarBajaBo, CheckBox chkConsultarBo,
        CheckBox chkInventario, CheckBox chkModificarIn, CheckBox chkConsultaIn, CheckBox chkConsultarMovBo, CheckBox chkIngresarTipoT,
        CheckBox chkModificarTiT, CheckBox chkDarBajaTip, CheckBox chkConsultarTip, CheckBox chkIngresarTra, CheckBox chkModificarTra,
        CheckBox chkDarBajaTra, CheckBox chkConsultarTra, CheckBox chkIngresarRuta, CheckBox chkModificarRu, CheckBox chkDarBajaRu,
        CheckBox chkConsultarRu, CheckBox chkIngresarEnvio, CheckBox chkModificarEn, CheckBox chkDarBajaEn, CheckBox chkConsultaEn,
        CheckBox chkInsertarBitaTrans, CheckBox chkModificarBi, CheckBox chkConsultarBTTras, CheckBox chkBitacoraUsuario,
        CheckBox chkIngresarCalificacion, CheckBox chkModificarCa, CheckBox chkConsultarCa, CheckBox chkReportes, String idPermiso)
        {

            MySqlDataReader leerPermisos = null;

            String ingresarUsuario = "";
            String modificarUsuario = "";
            String dbUsuario = "";
            String consultarUser = "";
            String ingresarCliente = "";
            String modificarCliente = "";
            String dbCliente = "";
            String consultarCliente = "";
            String ingresarDep = "";
            String modificarDep = "";
            String dbDep = "";
            String consultarDep = "";
            String ingresarPuesto = "";
            String modificarPuesto = "";
            String dbPuesto = "";
            String consultarPuesto = "";
            String ingresarPiloto = "";
            String modificarPiloto = "";
            String dbPiloto = "";
            String consultarPiloto = "";
            String ingresarEmple = "";
            String modificarEmple = "";
            String dbEmpleado = "";
            String consultarEmple = "";
            String ingresarPaEnc = "";
            String modificarPaEnc = "";
            String dbPacEnc = "";
            String consultarPaEnc = "";
            String ingresarPaDet = "";
            String modificarPaDet = "";
            String dbPaDet = "";
            String consultarPaDet = "";
            String ingresarUb = "";
            String modificarUb = "";
            String dbUbicacion = "";
            String consultarUb = "";
            String ingresarSubUb = "";
            String modificarSubUb = "";
            String dbSubUb = "";
            String consultarSubUb = "";
            String ingresarBo = "";
            String modificarBo = "";
            String dbBodega = "";
            String consultarBo = "";
            String insertarIn = "";
            String modificarIn = "";
            String consultarIn = "";
            String consultarMovBo = "";
            String ingresarTipoTrans = "";
            String modificarTipoTrans = "";
            String dbTipoTrans = "";
            String consultarTipoTrans = "";
            String ingresarTrans = "";
            String modificarTrans = "";
            String dbTrans = "";
            String consultarTrans = "";
            String ingresarRuta = "";
            String modificaRuta = "";
            String dbRuta = "";
            String consultarRuta = "";
            String ingresarEnvio = "";
            String modificarEnvio = "";
            String dbEnvio = "";
            String consultarEnvio = "";
            String ingresarBT = "";
            String modificarBT = "";
            String consultarBT = "";
            String consultarBU = "";
            String ingresarCali = "";
            String modificarCali = "";
            String consultaCali = "";
            String reportes = "";

            String pSqlPermisos = "SELECT * from permisos WHERE idPermiso='" + idPermiso + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            MySqlCommand buscarPermisos = new MySqlCommand(pSqlPermisos, conexionBD);
            leerPermisos = buscarPermisos.ExecuteReader();

            try
            {


                while (leerPermisos.Read())
                {

                    ingresarUsuario = leerPermisos.GetString("ingresarUser");
                    modificarUsuario = leerPermisos.GetString("modificarUser");
                    dbUsuario = leerPermisos.GetString("dbusuario");
                    consultarUser = leerPermisos.GetString("consultarUser");
                    ingresarCliente = leerPermisos.GetString("ingresarCliente");
                    modificarCliente = leerPermisos.GetString("modificarCliente");
                    dbCliente = leerPermisos.GetString("dbCliente");
                    consultarCliente = leerPermisos.GetString("consultarCliente");
                    ingresarDep = leerPermisos.GetString("ingresarDepartamento");
                    modificarDep = leerPermisos.GetString("modificarDepartamento");
                    dbDep = leerPermisos.GetString("dbDepartamento");
                    consultarDep = leerPermisos.GetString("consultarDepartamento");
                    ingresarPuesto = leerPermisos.GetString("ingresarPuesto");
                    modificarPuesto = leerPermisos.GetString("modificarPuesto");
                    dbPuesto = leerPermisos.GetString("dbPuesto");
                    consultarPuesto = leerPermisos.GetString("consultarPuesto");
                    ingresarPiloto = leerPermisos.GetString("ingresarPiloto");
                    modificarPiloto = leerPermisos.GetString("modificarPiloto");
                    dbPiloto = leerPermisos.GetString("dbPiloto");
                    consultarPiloto = leerPermisos.GetString("consultarPiloto");
                    ingresarEmple = leerPermisos.GetString("ingresarEmpleado");
                    modificarEmple = leerPermisos.GetString("modificarEmpleado");
                    dbEmpleado = leerPermisos.GetString("dbEmpleado");
                    consultarEmple = leerPermisos.GetString("consultarEmpleado");
                    ingresarPaEnc = leerPermisos.GetString("ingresarPaqueteEncabezado");
                    modificarPaEnc = leerPermisos.GetString("modificarPaqueteEncabezado");
                    dbPacEnc = leerPermisos.GetString("dbPaqueteEncabezado");
                    consultarPaEnc = leerPermisos.GetString("consultarPaqueteEncabezado");
                    ingresarPaDet = leerPermisos.GetString("ingresarPaqueteDetalle");
                    modificarPaDet = leerPermisos.GetString("modificarPaqueteDetalle");
                    dbPaDet = leerPermisos.GetString("dbPaqueteDetalle");
                    consultarPaDet = leerPermisos.GetString("consultarPaqueteDetalle");
                    ingresarUb = leerPermisos.GetString("insertarUbicacion");
                    modificarUb = leerPermisos.GetString("modificarUbicacion");
                    dbUbicacion = leerPermisos.GetString("dbubicacion");
                    consultarUb = leerPermisos.GetString("consultarUbicacion");
                    ingresarSubUb = leerPermisos.GetString("insertarSububicacion");
                    modificarSubUb = leerPermisos.GetString("modificarSububicacion");
                    dbSubUb = leerPermisos.GetString("dbSububicacion");
                    consultarSubUb = leerPermisos.GetString("consultarSububicacion");
                    ingresarBo = leerPermisos.GetString("insertarBodega");
                    modificarBo = leerPermisos.GetString("modifcarBodega");
                    dbBodega = leerPermisos.GetString("dbBodega");
                    consultarBo = leerPermisos.GetString("consultarBodega");
                    insertarIn = leerPermisos.GetString("insertarInventario");
                    modificarIn = leerPermisos.GetString("modificarInventario");
                    consultarIn = leerPermisos.GetString("consultarInventario");
                    consultarMovBo = leerPermisos.GetString("consultarMovBodega");
                    ingresarTipoTrans = leerPermisos.GetString("insertarTipoTransp");
                    modificarTipoTrans = leerPermisos.GetString("modificarTipoTransp");
                    dbTipoTrans = leerPermisos.GetString("dbTipoTransp");
                    consultarTipoTrans = leerPermisos.GetString("consultarTipoTransp");
                    ingresarTrans = leerPermisos.GetString("insertarTransporte");
                    modificarTrans = leerPermisos.GetString("modificarTransporte");
                    dbTrans = leerPermisos.GetString("dbTransporte");
                    consultarTrans = leerPermisos.GetString("consultarTransporte");
                    ingresarRuta = leerPermisos.GetString("ingresarRuta");
                    modificaRuta = leerPermisos.GetString("modificarRuta");
                    dbRuta = leerPermisos.GetString("dbRuta");
                    consultarRuta = leerPermisos.GetString("consultarRuta");
                    ingresarEnvio = leerPermisos.GetString("ingresarEnvio");
                    modificarEnvio = leerPermisos.GetString("modificarEnvio");
                    dbEnvio = leerPermisos.GetString("dbEnvio");
                    consultarEnvio = leerPermisos.GetString("consultarEnvio");
                    ingresarBT = leerPermisos.GetString("ingresarBT");
                    modificarBT = leerPermisos.GetString("modificarBT");
                    consultarBT = leerPermisos.GetString("consultaBT");
                    consultarBU = leerPermisos.GetString("consultaBU");
                    ingresarCali = leerPermisos.GetString("ingresarCalificacion");
                    modificarCali = leerPermisos.GetString("modificarCalificacion");
                    consultaCali = leerPermisos.GetString("consultaCalificacion");
                    reportes = leerPermisos.GetString("reportes");


                    funBoolCheck(ingresarUsuario, chkIngresarU);
                    funBoolCheck(modificarUsuario, chkModificarU);
                    funBoolCheck(dbUsuario, chkDarBajaU);
                    funBoolCheck(consultarUser, chkConsultaU);
                    funBoolCheck(ingresarCliente, chkIngresarC);
                    funBoolCheck(modificarCliente, chkModificarC);
                    funBoolCheck(dbCliente, chkDarBajaC);
                    funBoolCheck(consultarCliente, chkConsultarC);
                    funBoolCheck(ingresarDep, chkIngresarD);
                    funBoolCheck(modificarDep, chkModificarD);
                    funBoolCheck(dbDep, chkDarBajaD);
                    funBoolCheck(consultarDep, chkConsultarD);
                    funBoolCheck(ingresarPuesto, chkIngresarPu);
                    funBoolCheck(modificarPuesto, chkModificarPu);
                    funBoolCheck(dbPuesto, chkDarBajaPu);
                    funBoolCheck(consultarPuesto, chkConsultaPu);
                    funBoolCheck(ingresarPiloto, chkIngresarPi);
                    funBoolCheck(modificarPiloto, chkModificarPi);
                    funBoolCheck(dbPiloto, chkDarBajaPi);
                    funBoolCheck(consultarPiloto, chkConsultaPi);
                    funBoolCheck(ingresarEmple, chkIngresarEm);
                    funBoolCheck(modificarEmple, chkModificarE);
                    funBoolCheck(dbEmpleado, chkDarBajaE);
                    funBoolCheck(consultarEmple, chkConsultaE);
                    funBoolCheck(ingresarPaEnc, chkPaqueteEnc);
                    funBoolCheck(modificarPaEnc, chkModificarEnc);
                    funBoolCheck(dbPacEnc, chkDarBajaPaEnc);
                    funBoolCheck(consultarPaEnc, chkConsultaPaEc);
                    funBoolCheck(ingresarPaDet, chkIngresarPaDe);
                    funBoolCheck(modificarPaDet, chkModificarPaDet);
                    funBoolCheck(dbPaDet, chkDarBajaPaDet);
                    funBoolCheck(consultarPaDet, chkConsultaDet);
                    funBoolCheck(ingresarUb, chkIngresarUb);
                    funBoolCheck(modificarUb, chkModificarUb);
                    funBoolCheck(dbUbicacion, chkDarBajaUb);
                    funBoolCheck(consultarUb, chkConsultaUb);
                    funBoolCheck(ingresarSubUb, chkIngresarSub);
                    funBoolCheck(modificarSubUb, chkModificarSub);
                    funBoolCheck(dbSubUb, chkDarBajaSub);
                    funBoolCheck(consultarSubUb, chkConsultaSub);
                    funBoolCheck(ingresarBo, chkIngresarBo);
                    funBoolCheck(modificarBo, chkModificarBo);
                    funBoolCheck(dbBodega, chkDarBajaBo);
                    funBoolCheck(consultarBo, chkConsultarBo);
                    funBoolCheck(insertarIn, chkInventario);
                    funBoolCheck(modificarIn, chkModificarIn);
                    funBoolCheck(consultarIn, chkConsultaIn);
                    funBoolCheck(consultarMovBo, chkConsultarMovBo);
                    funBoolCheck(ingresarTipoTrans, chkIngresarTipoT);
                    funBoolCheck(modificarTipoTrans, chkModificarTiT);
                    funBoolCheck(dbTipoTrans, chkDarBajaTip);
                    funBoolCheck(consultarTipoTrans, chkConsultarTip);
                    funBoolCheck(ingresarTrans, chkIngresarTra);
                    funBoolCheck(modificarTrans, chkModificarTra);
                    funBoolCheck(dbTrans, chkDarBajaTra);
                    funBoolCheck(consultarTrans, chkConsultarTra);
                    funBoolCheck(ingresarRuta, chkIngresarRuta);
                    funBoolCheck(modificaRuta, chkModificarRu);
                    funBoolCheck(dbRuta, chkDarBajaRu);
                    funBoolCheck(consultarRuta, chkConsultarRu);
                    funBoolCheck(ingresarEnvio, chkIngresarEnvio);
                    funBoolCheck(modificarEnvio, chkModificarEn);
                    funBoolCheck(dbEnvio, chkDarBajaEn);
                    funBoolCheck(consultarEnvio, chkConsultaEn);
                    funBoolCheck(ingresarBT, chkInsertarBitaTrans);
                    funBoolCheck(modificarBT, chkModificarBi);
                    funBoolCheck(consultarBT, chkConsultarBTTras);
                    funBoolCheck(consultarBU, chkBitacoraUsuario);
                    funBoolCheck(ingresarCali, chkIngresarCalificacion);
                    funBoolCheck(modificarCali, chkModificarCa);
                    funBoolCheck(consultaCali, chkConsultarCa);
                    funBoolCheck(reportes, chkReportes);
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

        public void funBoolCheck(String estado, CheckBox check)
        {
            if (estado == "False")
            {
                check.Checked = false;

            }
            else if (estado == "True")
            {
                check.Checked = true;
            }
        }

        public String funBuscarEstatus(String idEstatus)
        {

            String estatusUser = "";
            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT estatusUsuario from usuario WHERE idUser='" + idEstatus + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand buscarUser = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarUser.ExecuteReader();

                while (leer.Read())
                {
                    estatusUser = leer.GetString("estatusUsuario");
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

            return estatusUser;
        }

        public void funActivarUsuario()
        {
            String pSqlModificar = "UPDATE usuario SET estatusUsuario='A' WHERE idUser='" + idUsuario + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUsuario = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUsuario.ExecuteNonQuery();
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

        public void funDarBajaUsuario()
        {
            String pSqlModificar = "UPDATE usuario SET estatusUsuario='I' WHERE idUser='" + idUsuario + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand modificarUsuario = new MySqlCommand(pSqlModificar, conexionBD);
                modificarUsuario.ExecuteNonQuery();
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

        public void funLlenarCombo(ComboBox tipoPermiso)
        {
            tipoPermiso.DataSource = null;
            tipoPermiso.Items.Clear();

            String psql = "SELECT idTipoPermiso,nombreTipoPermiso FROM tipoPermiso";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand llenarCombo = new MySqlCommand(psql, conexionBD);
                MySqlDataAdapter data = new MySqlDataAdapter(llenarCombo);

                DataTable dt = new DataTable();
                data.Fill(dt);

                tipoPermiso.ValueMember = "idTipoPermiso";
                tipoPermiso.DisplayMember = "nombreTipoPermiso";
                tipoPermiso.DataSource = dt;
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

        public int obtenerNombreTP(String codigoP)
        {
            MySqlDataReader leer = null;
            int tipoP = 0;

            String pSqlBuscar = "SELECT idTipoPermiso from permisos WHERE idPermiso='" + codigoP + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarIDtipoPermiso = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarIDtipoPermiso.ExecuteReader();
                while (leer.Read())
                {
                    tipoP = int.Parse(leer.GetString("idTipoPermiso"));
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Leer los datos " + ex.Message);
            }

            return tipoP;

        }

        public String funVerificarExistenciaP(String codigoP)
        {
            String boleano = "";

            MySqlDataReader leer = null;

            String pSqlBuscar = "SELECT idPermiso from permisos WHERE idPermiso='" + codigoP + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand buscarPermiso = new MySqlCommand(pSqlBuscar, conexionBD);
                leer = buscarPermiso.ExecuteReader();
                while (leer.Read())
                {
                    boleano = leer.GetString("idPermiso");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Leer los datos " + ex.Message);
            }

            return boleano;
        }
    }
}
