namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmModuloEntrenamiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
            frmEntrenamiento = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_Pronosticos = new System.Windows.Forms.DataGridView();
            this.codPartido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeEmpate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Pronosticos
            // 
            this.dg_Pronosticos.AllowUserToAddRows = false;
            this.dg_Pronosticos.AllowUserToDeleteRows = false;
            this.dg_Pronosticos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_Pronosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Pronosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPartido,
            this.codPronostico,
            this.Local,
            this.Visitante,
            this.porcentajeLocal,
            this.porcentajeEmpate,
            this.porcentajeVisita,
            this.Pronostico});
            this.dg_Pronosticos.Location = new System.Drawing.Point(12, 12);
            this.dg_Pronosticos.Name = "dg_Pronosticos";
            this.dg_Pronosticos.ReadOnly = true;
            this.dg_Pronosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dg_Pronosticos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Pronosticos.Size = new System.Drawing.Size(648, 224);
            this.dg_Pronosticos.TabIndex = 0;
            // 
            // codPartido
            // 
            this.codPartido.HeaderText = "Codigo Partido";
            this.codPartido.Name = "codPartido";
            this.codPartido.ReadOnly = true;
            this.codPartido.Visible = false;
            this.codPartido.Width = 93;
            // 
            // codPronostico
            // 
            this.codPronostico.HeaderText = "Codigo Pronostico";
            this.codPronostico.Name = "codPronostico";
            this.codPronostico.ReadOnly = true;
            this.codPronostico.Visible = false;
            this.codPronostico.Width = 108;
            // 
            // Local
            // 
            this.Local.HeaderText = "Equipo Local";
            this.Local.Name = "Local";
            this.Local.ReadOnly = true;
            this.Local.Width = 101;
            // 
            // Visitante
            // 
            this.Visitante.HeaderText = "Equipo Visitante";
            this.Visitante.Name = "Visitante";
            this.Visitante.ReadOnly = true;
            // 
            // porcentajeLocal
            // 
            this.porcentajeLocal.HeaderText = "L(%)";
            this.porcentajeLocal.Name = "porcentajeLocal";
            this.porcentajeLocal.ReadOnly = true;
            this.porcentajeLocal.Width = 101;
            // 
            // porcentajeEmpate
            // 
            this.porcentajeEmpate.HeaderText = "E(%)";
            this.porcentajeEmpate.Name = "porcentajeEmpate";
            this.porcentajeEmpate.ReadOnly = true;
            // 
            // porcentajeVisita
            // 
            this.porcentajeVisita.HeaderText = "V(%)";
            this.porcentajeVisita.Name = "porcentajeVisita";
            this.porcentajeVisita.ReadOnly = true;
            this.porcentajeVisita.Width = 101;
            // 
            // Pronostico
            // 
            this.Pronostico.HeaderText = "Pronostico";
            this.Pronostico.Name = "Pronostico";
            this.Pronostico.ReadOnly = true;
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(545, 371);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(115, 31);
            this.btnEntrenar.TabIndex = 1;
            this.btnEntrenar.Text = "Entrenar";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 242);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(648, 123);
            this.textBox1.TabIndex = 2;
            // 
            // frmModuloEntrenamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 411);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEntrenar);
            this.Controls.Add(this.dg_Pronosticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModuloEntrenamiento";
            this.Text = "Módulo de Entrenamiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmEntrenarPronosticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Pronosticos;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPronostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeEmpate;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pronostico;
        private System.Windows.Forms.TextBox textBox1;
    }
}