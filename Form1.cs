using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPromedios
{
    public partial class FrmIncio : Form
    {
        public FrmIncio()
        {
            InitializeComponent();

            BtnVerificar.TabIndex = 0;
            BtnConsultar.TabIndex = 1;
            BtnActualizar.TabIndex = 2;
        }

        private void LoadFormInPanel(Form form)
        {
            // Limpia cualquier formulario previo del panel
            panelContenedor.Controls.Clear();

            // Configura el formulario a cargar
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Agrega el formulario al panel
            panelContenedor.Controls.Add(form);
            panelContenedor.Tag = form;

            form.Show();
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new FrmVerificacion());
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new FrmConsultas());
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new FrmActualizacion());
        }

        public void MostrarPantallaInicial()
        {
            LoadFormInPanel(new FrmIncio()); // Asumiendo que FrmPantallaInicial es tu pantalla de inicio en el panel
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
