namespace AppPromedios
{
    partial class FrmIncio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnVerificar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.picConsultar = new System.Windows.Forms.PictureBox();
            this.picVerificar = new System.Windows.Forms.PictureBox();
            this.picActualizar = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActualizar)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(302, 52);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(154, 22);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Bienes y servicios";
            // 
            // BtnVerificar
            // 
            this.BtnVerificar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerificar.Location = new System.Drawing.Point(119, 257);
            this.BtnVerificar.Name = "BtnVerificar";
            this.BtnVerificar.Size = new System.Drawing.Size(116, 43);
            this.BtnVerificar.TabIndex = 5;
            this.BtnVerificar.Text = "Verificar";
            this.BtnVerificar.UseVisualStyleBackColor = true;
            this.BtnVerificar.Click += new System.EventHandler(this.BtnVerificar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(512, 257);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(116, 43);
            this.BtnActualizar.TabIndex = 6;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultar.Location = new System.Drawing.Point(320, 257);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(116, 43);
            this.BtnConsultar.TabIndex = 7;
            this.BtnConsultar.Text = "Consultar";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // picConsultar
            // 
            this.picConsultar.Image = global::AppPromedios.Properties.Resources.Consultar;
            this.picConsultar.Location = new System.Drawing.Point(320, 205);
            this.picConsultar.Name = "picConsultar";
            this.picConsultar.Size = new System.Drawing.Size(116, 46);
            this.picConsultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConsultar.TabIndex = 8;
            this.picConsultar.TabStop = false;
            // 
            // picVerificar
            // 
            this.picVerificar.Image = global::AppPromedios.Properties.Resources.verificar;
            this.picVerificar.Location = new System.Drawing.Point(119, 205);
            this.picVerificar.Name = "picVerificar";
            this.picVerificar.Size = new System.Drawing.Size(116, 46);
            this.picVerificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVerificar.TabIndex = 4;
            this.picVerificar.TabStop = false;
            // 
            // picActualizar
            // 
            this.picActualizar.Image = global::AppPromedios.Properties.Resources.actualizar;
            this.picActualizar.Location = new System.Drawing.Point(512, 205);
            this.picActualizar.Name = "picActualizar";
            this.picActualizar.Size = new System.Drawing.Size(116, 46);
            this.picActualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picActualizar.TabIndex = 3;
            this.picActualizar.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.Controls.Add(this.BtnActualizar);
            this.panelContenedor.Controls.Add(this.LblTitulo);
            this.panelContenedor.Controls.Add(this.picVerificar);
            this.panelContenedor.Controls.Add(this.BtnVerificar);
            this.panelContenedor.Controls.Add(this.picConsultar);
            this.panelContenedor.Controls.Add(this.BtnConsultar);
            this.panelContenedor.Controls.Add(this.picActualizar);
            this.panelContenedor.Location = new System.Drawing.Point(-3, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(809, 502);
            this.panelContenedor.TabIndex = 9;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // FrmIncio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.panelContenedor);
            this.Name = "FrmIncio";
            this.Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.picConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActualizar)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox picActualizar;
        private System.Windows.Forms.PictureBox picVerificar;
        private System.Windows.Forms.Button BtnVerificar;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.PictureBox picConsultar;
        private System.Windows.Forms.Panel panelContenedor;
    }
}

