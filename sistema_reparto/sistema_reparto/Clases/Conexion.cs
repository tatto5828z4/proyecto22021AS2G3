using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_reparto
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            String servidor = "localhost";
            String bd = "sistemarepartobd";
            String usuario = "root";
            String password = "mysql2001";

            String cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario +
            "; Password=" + password + ";";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
