using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;
namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();
       
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataTable Mostrar()
        {

            MySqlConnection connection = conexion.AbrirConexion();
            MySqlCommand comando = new MySqlCommand("MostrarProductos",connection);
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(tabla);
                conexion.cerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Insertar(string Nombre, String descripcion, string marca, int precio, int stock)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_Nombre", Nombre);
            comando.Parameters.AddWithValue("_Descripcion", descripcion);
            comando.Parameters.AddWithValue("_Marca", marca);
            comando.Parameters.AddWithValue("_Precio", precio);
            comando.Parameters.AddWithValue("_Stock",stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrarConexion();

          

        }
        public void Editar( int id, string Nombre, String descripcion, string marca, int precio, int stock)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EDITAR";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_Nombre", Nombre);
            comando.Parameters.AddWithValue("_Descripcion", descripcion);
            comando.Parameters.AddWithValue("_Marca", marca);
            comando.Parameters.AddWithValue("_Precio", precio);
            comando.Parameters.AddWithValue("_Stock", stock);
            comando.Parameters.AddWithValue("_ID_identi", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrarConexion();
           

        }
        public void Eliminar (int id )
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_ID_identi", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }

    }
}
