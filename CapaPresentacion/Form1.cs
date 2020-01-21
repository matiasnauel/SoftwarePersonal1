using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos ObjetoCN = new CN_Productos();
        private string idProducto = null;
        private bool EDITAR = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MostrarProductos  ()
        {
            CN_Productos ObjetoCN = new CN_Productos();
            dataGridView1.DataSource = ObjetoCN.mostrarProducto(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void Guardado_Click(object sender, EventArgs e)
        {
            if (EDITAR == false)
            {
                try
                {
                    ObjetoCN.InsertarProd(texNombre.Text, textDescripcion.Text, textMarca.Text, textPrecio.Text, textStock.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);

                }
            }
            if (EDITAR == true)
            {
                try
                {
                    ObjetoCN.EditProd(idProducto,texNombre.Text, textDescripcion.Text, textMarca.Text, textPrecio.Text, textStock.Text);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    LimpiarForm();
                    EDITAR = false;

                }
                catch (Exception m)
                {

                    MessageBox.Show("No se ha podido insertar los datos: " + m);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EDITAR = true;
                texNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                textMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                textPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                textStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["ID_identi"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila");

            }
        }
        private void LimpiarForm ()
        {
            texNombre.Clear();
            textDescripcion.Clear();
            textMarca.Clear();
            textPrecio.Clear();
            textStock.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["ID_identi"].Value.ToString();
                ObjetoCN.EliminarProd(idProducto);
                MessageBox.Show("eliminado correctamente");
                MostrarProductos(); 

            }
             else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }
    }
}
