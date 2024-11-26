using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppPromedios
{
    public partial class Ejemplo : Form
    {
        private string excelPath = @"C:\Users\Jeison Guerrero\Documents\AppPromedio\AppPromedios\ejemplo2.xlsx";
        private XLWorkbook workbook;

        public Ejemplo()
        {
            InitializeComponent();
            //dataGridView1.Dock = DockStyle.Fill; // Esto hace que el DataGridView ocupe todo el espacio del formulario
        }

        private void Ejemplo_Load(object sender, EventArgs e)
        {
            // Configuración inicial del DataGridView
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;

            try
            {
                workbook = new XLWorkbook(excelPath);
                var worksheet = workbook.Worksheet("Sheet1"); // Cambia la hoja según sea necesario

                // Limpiar DataGridView
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Leer columnas
                foreach (var cell in worksheet.Row(1).CellsUsed())
                {
                    dataGridView1.Columns.Add(cell.GetString(), cell.GetString());
                }

                // Leer filas
                foreach (var row in worksheet.RowsUsed().Skip(1)) // Saltar cabecera
                {
                    var rowData = new List<object>();
                    foreach (var cell in row.Cells())
                    {
                        rowData.Add(cell.Value);
                    }
                    dataGridView1.Rows.Add(rowData.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el archivo existe
                if (!System.IO.File.Exists(excelPath))
                {
                    MessageBox.Show("El archivo de Excel no se encontró en la ruta especificada.");
                    return;
                }

                // Inicializar el libro de trabajo y cargar la hoja "Sheet1"
                workbook = new XLWorkbook(excelPath);
                var worksheet = workbook.Worksheet("Sheet1"); // Asegurarse de que es "Sheet1"

                // Limpiar el DataGridView antes de cargar nuevos datos
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Configurar el DataGridView para ocupar todo el espacio del formulario
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Leer encabezados de columna (primera fila en Excel)
                foreach (var cell in worksheet.Row(1).CellsUsed())
                {
                    dataGridView1.Columns.Add(cell.GetString(), cell.GetString());
                }

                // Leer filas de datos, omitiendo la primera fila que contiene los encabezados
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var rowData = new List<object>();
                    foreach (var cell in row.Cells())
                    {
                        rowData.Add(cell.Value);
                    }
                    dataGridView1.Rows.Add(rowData.ToArray());
                }

                // Refrescar el DataGridView para asegurarse de que se muestren los datos
                dataGridView1.Refresh();

                MessageBox.Show("Datos cargados correctamente desde 'Sheet1'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el archivo de Excel está cargado
                if (workbook == null)
                {
                    MessageBox.Show("Primero carga el archivo Excel usando el botón 'Leer'.");
                    return;
                }

                // Seleccionar la hoja correcta
                var worksheet = workbook.Worksheet("PROMEDIO"); // Cambia "PROMEDIO" si es necesario

                // Verificar si hay datos en el DataGridView
                if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[dataGridView1.Rows.Count - 1].IsNewRow)
                {
                    MessageBox.Show("No hay datos válidos para añadir.");
                    return;
                }

                // Determinar la fila donde añadir los nuevos datos
                int lastRow = worksheet.LastRowUsed().RowNumber() + 1;
                var newRow = worksheet.Row(lastRow);

                // Añadir datos desde la última fila del DataGridView al worksheet
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    var cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[i].Value;

                    // Convertir el valor a string antes de asignarlo
                    newRow.Cell(i + 1).Value = cellValue?.ToString() ?? string.Empty;
                }

                MessageBox.Show("Datos añadidos a la hoja PROMEDIO.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir datos: {ex.Message}");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var worksheet = workbook.Worksheet("Sheet1");

                // Ajustar el ancho de las columnas en Excel para que coincidan con el contenido
                worksheet.Columns().AdjustToContents();

                // Guardar el archivo Excel
                workbook.SaveAs(excelPath);
                MessageBox.Show("Archivo guardado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}");
            }
        }
    }
}