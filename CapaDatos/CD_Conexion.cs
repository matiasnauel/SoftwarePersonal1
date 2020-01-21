using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
   public  class CD_Conexion
    {
        
        private MySqlConnection conexion = new MySqlConnection("server= localhost ; user = root ; database = productosclientes ; password = 3431");
        public MySqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;

        }
        public MySqlConnection cerrarConexion ()
        {
            if (conexion.State ==  ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;

        }

    }
}
