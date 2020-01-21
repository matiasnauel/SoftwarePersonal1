using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
   public  class CN_Productos
    {
       private  CD_Productos objetoCD =  new CD_Productos();
       public DataTable  mostrarProducto ()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarProd(string Nombre, String descripcion, string marca, string precio, string stock)
        {
            objetoCD.Insertar(Nombre, descripcion, marca,Convert.ToInt32(precio),Convert.ToInt32(stock));
        }
        public void EditProd (string id,string Nombre, String descripcion, string marca, string precio, string stock)
        {
            objetoCD.Editar(Convert.ToInt32 (id), Nombre, descripcion, marca,Convert.ToInt32 (precio),Convert.ToInt32(stock));
        }
        public void EliminarProd (string id )
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
