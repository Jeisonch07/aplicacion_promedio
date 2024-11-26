using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace AppPromedios
{
public partial class FrmActualizacion : Form
{
    private string filePath = @"C:\Users\Jeison Guerrero\Documents\AppPromedio\AppPromedios\Hola1 (4).xlsx";

    public FrmActualizacion()
    {
        InitializeComponent();
    }

    // Evento de carga del formulario
    private void FrmActualizacion_Load(object sender, EventArgs e)
    {
        CargarDatos();
        dataGridView1.CellEndEdit += DataGridView1_CellEndEdit; // Asociar evento de celda editada
    }


    // Cargar los datos desde el archivo de Excel
    private void BtnCargar_Click(object sender, EventArgs e)
    {
        try
        {
            CargarDatos();
            MessageBox.Show("Datos cargados correctamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    // Guardar los datos en el archivo de Excel
    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            GuardarDatos();
            MessageBox.Show("Datos guardados exitosamente en el archivo de Excel.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar datos: {ex.Message}");
        }
    }

    // Cargar los datos desde el archivo de Excel
    private void CargarDatos()
    {
        try
        {
            DataTable dataTable = new DataTable();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("Sheet1");

                if (worksheet == null)
                {
                    MessageBox.Show("No se encontró la hoja 'Sheet1' en el archivo.");
                    return;
                }

                // Cargar las columnas
                foreach (var headerCell in worksheet.Row(1).CellsUsed())
                {
                    dataTable.Columns.Add(headerCell.GetValue<string>());
                }

                // Cargar las filas
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

            dataGridView1.DataSource = dataTable;

            // Calcular los promedios al cargar los datos
            CalcularPromedios();

            // Configurar ajuste de texto y tamaño de filas
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar los datos: {ex.Message}");
        }
    }

    // Guardar los datos en el archivo de Excel
    private void GuardarDatos()
    {
        try
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("Sheet1") ?? workbook.Worksheets.Add("Sheet1");
                worksheet.Clear();

                // Guardar las columnas
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                }

                // Guardar las filas
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString() ?? string.Empty;
                    }
                }

                workbook.SaveAs(filePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar los datos: {ex.Message}");
        }
    }

    // Calcular los promedios de las columnas específicas
    private void CalcularPromedios()
    {
        // Definir columnas que se usarán para el cálculo del promedio
        var columnasPromedio = new[] { "VALOR UNITARIO EMPRESA 1", "VALOR UNITARIO EMPRESA 2",
                                        "VALOR UNITARIO EMPRESA 3", "VALOR UNITARIO EMPRESA 4" };

        // Verificar si las columnas existen
        if (!columnasPromedio.All(columna => dataGridView1.Columns.Contains(columna)) ||
            !dataGridView1.Columns.Contains("VALOR UNITARIO PROMEDIO"))
            return;

        foreach (DataGridViewRow fila in dataGridView1.Rows)
        {
            if (fila.IsNewRow) continue;

            double suma = 0;
            int contador = 0;

            foreach (string columna in columnasPromedio)
            {
                if (double.TryParse(fila.Cells[columna].Value?.ToString(), NumberStyles.Any,
                                    CultureInfo.InvariantCulture, out double valor))
                {
                    suma += valor;
                    contador++;
                }
            }

            // Calcular el promedio si hay valores válidos
            double promedio = contador > 0 ? suma / contador : 0;

            // Asignar el promedio al campo correspondiente
            fila.Cells["VALOR UNITARIO PROMEDIO"].Value = promedio.ToString("N2", CultureInfo.InvariantCulture);
        }

        // Refrescar el DataGridView para mostrar los cambios
        dataGridView1.Refresh();
    }

    // Evento para recalcular promedios cuando se edita una celda
    private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        // Recalcular promedios después de editar una celda
        if (e.RowIndex >= 0)
        {
            CalcularPromedios();
        }
    }

    // Regresar al formulario principal
    private void btnRegresar_Click_1(object sender, EventArgs e)
    {
        try
        {
            FrmIncio formularioPrincipal = (FrmIncio)Application.OpenForms["FrmIncio"];
            formularioPrincipal.MostrarPantallaInicial();
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al regresar: {ex.Message}");
        }
    }

        private void LblConsultar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
