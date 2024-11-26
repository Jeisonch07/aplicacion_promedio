using ClosedXML.Excel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AppPromedios
{
    public partial class FrmConsultas : Form
    {
        private DataTable originalDataTable;

        // Constructor sin parámetros
        private string filePath = @"C:\Users\Jeison Guerrero\Documents\AppPromedio\AppPromedios\buenas (1) (1).xlsx";
        public FrmConsultas()
        {
            InitializeComponent();
        }

        // Constructor que recibe un DataTable
        public FrmConsultas(DataTable dataTable) : this() // Llama al constructor sin parámetros
        {
            originalDataTable = dataTable;
            dataGridView1.DataSource = originalDataTable?.Copy();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            FrmIncio formularioPrincipal = (FrmIncio)Application.OpenForms["FrmIncio"];
            formularioPrincipal.MostrarPantallaInicial();
            this.Close();
        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
            // Cargar todos los datos en el DataGridView al cargar el formulario
            if (originalDataTable != null)
            {
                dataGridView1.DataSource = originalDataTable.Copy();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string searchValue = TxtBuscar.Text.Trim().ToLower(); // Convertir el valor de búsqueda a minúsculas para comparación

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Por favor, ingrese un valor para buscar.");
                return;
            }

            // Crear una copia del DataTable filtrado
            DataTable filteredTable = originalDataTable.Clone();

            // Filtrar el DataTable original
            foreach (DataRow row in originalDataTable.Rows)
            {
                if (row.ItemArray.Any(item => item.ToString().ToLower().Contains(searchValue))) // Convertir item a minúsculas también
                {
                    filteredTable.ImportRow(row);
                }
            }

            dataGridView1.DataSource = filteredTable;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            // Restablecer el DataGridView con todos los datos
            if (originalDataTable != null)
            {
                dataGridView1.DataSource = originalDataTable.Copy();
            }
            TxtBuscar.Clear();
        }


        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
         
        }
    }
}
