using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_reparto.Clases
{
    public class Inventario
    {
        //Atributos
        String idInventario;
        String idBodega;
        String idPaquete;
        String idCliente;
        String idEmpleado;
        String cantidad;
        String fecha;

        public Inventario()
        {

        }

        public string IdInventario { get => idInventario; set => idInventario = value; }
        public string IdBodega { get => idBodega; set => idBodega = value; }
        public string IdPaquete { get => idPaquete; set => idPaquete = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public string Fecha { get => fecha; set => fecha = value; }




        public List<Object> consulta(String dato)
        {
            MySqlDataReader reader = null;
            List<Object> lista = new List<Object>();
            String sql;

            if (dato == null)
            {
                sql = "SELECT * FROM inventario";
            }
            else
            {
                sql = "SELECT * FROM inventario WHERE idInventario LIKE '%" + dato + "%'";
            }

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                MySqlCommand buscarInventario = new MySqlCommand(sql, conexionBD);
                reader = buscarInventario.ExecuteReader();


                while (reader.Read())
                {

                    Inventario inventario = new Inventario();

                    inventario.idInventario = reader.GetString("idInventario");
                    inventario.idBodega = reader.GetString("idBodega");
                    inventario.IdPaquete = reader.GetString("idPaquete");
                    inventario.idCliente = reader.GetString("idCliente");
                    inventario.idEmpleado = reader.GetString("idEmpleadoMB");
                    inventario.cantidad = reader.GetString("cantidadInventario");
                    inventario.fecha = reader.GetString("fechaIngresoInventario");

                    lista.Add(inventario);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }
    }
}
