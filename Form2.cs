using ClosedXML.Excel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AppPromedios
{
    public partial class FrmVerificacion : Form
    {
        // Ruta al archivo de Excel
        private readonly string filePath = @"C:\Users\Jeison Guerrero\Documents\AppPromedio\AppPromedios\Hola1 (4).xlsx";

        public FrmVerificacion()
        {
            InitializeComponent();
        }

        // Evento al cargar el formulario
        private void FrmVerificacion_Load(object sender, EventArgs e)
        {
            // Opcionalmente, cargar los datos al abrir la pantalla
            CargarDatos();
        }

        // Botón para regresar a la pantalla principal
        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            FrmIncio formularioPrincipal = (FrmIncio)Application.OpenForms["FrmIncio"];
            formularioPrincipal.MostrarPantallaInicial();
            this.Close();
        }

        // Botón para verificar datos
        private void BtnVerificar2_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                MessageBox.Show("Datos actuales.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // Método para cargar los datos del archivo Excel al DataGridView
        private void CargarDatos()
        {
            try
            {
                // Crear un DataTable para almacenar los datos
                DataTable dataTable = new DataTable();

                // Leer el archivo Excel
                using (var workbook = new XLWorkbook(filePath))
                {
                    // Obtener el nombre de las hojas
                    var sheetNames = workbook.Worksheets.Select(ws => ws.Name).ToList();
                    string availableSheets = string.Join(", ", sheetNames);

                    // Verificar si existe la hoja "Sheet1"
                    var worksheet = workbook.Worksheet("Sheet1");
                    if (worksheet == null)
                    {
                        MessageBox.Show("No se encontró la hoja 'Sheet1' en el archivo. Verifique el nombre de la hoja.");
                        return;
                    }

                    // Verificar si la hoja tiene datos
                    if (worksheet.LastRowUsed() == null)
                    {
                        MessageBox.Show("La hoja 'Sheet1' está vacía.");
                        return;
                    }

                    // Agregar columnas al DataTable
                    foreach (var headerCell in worksheet.Row(1).CellsUsed())
                    {
                        dataTable.Columns.Add(headerCell.GetValue<string>());
                    }

                    // Agregar filas al DataTable
                    int lastRow = worksheet.LastRowUsed().RowNumber();
                    for (int row = 2; row <= lastRow; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        int i = 0;

                        foreach (var cell in worksheet.Row(row).CellsUsed())
                        {
                            dataRow[i++] = cell.GetValue<string>();
                        }

                        dataTable.Rows.Add(dataRow);
                    }
                }

                // Verificar si hay datos cargados
                if (dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable;

                    // Ajustar las columnas para ocupar todo el ancho disponible
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hacer el DataGridView de solo lectura
                    dataGridView1.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("El archivo de Excel no contiene datos en la hoja 'Sheet1'.");
                }
            }
            catch (System.IO.IOException ioEx)
            {
                MessageBox.Show("Error al acceder al archivo de Excel: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
    }
}
