namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmEntrenarPronosticos
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
            this.dg_Pronosticos = new System.Windows.Forms.DataGridView();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeEmpate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Pronosticos
            // 
            this.dg_Pronosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Pronosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.codPronostico,
            this.Local,
            this.Visitante,
            this.porcentajeLocal,
            this.porcentajeEmpate,
            this.porcentajeVisita,
            this.Pronostico});
            this.dg_Pronosticos.Location = new System.Drawing.Point(12, 12);
            this.dg_Pronosticos.Name = "dg_Pronosticos";
            this.dg_Pronosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dg_Pronosticos.Size = new System.Drawing.Size(650, 353);
            this.dg_Pronosticos.TabIndex = 0;
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(532, 377);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(130, 23);
            this.btnEntrenar.TabIndex = 1;
            this.btnEntrenar.Text = "Entrenar";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo Equipo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // codPronostico
            // 
            this.codPronostico.HeaderText = "Codigo Pronostico";
            this.codPronostico.Name = "codPronostico";
            this.codPronostico.Visible = false;
            // 
            // Local
            // 
            this.Local.HeaderText = "Equipo Local";
            this.Local.Name = "Local";
            // 
            // Visitante
            // 
            this.Visitante.HeaderText = "Equipo Visitante";
            this.Visitante.Name = "Visitante";
            // 
            // porcentajeLocal
            // 
            this.porcentajeLocal.HeaderText = "L(%)";
            this.porcentajeLocal.Name = "porcentajeLocal";
            // 
            // porcentajeEmpate
            // 
            this.porcentajeEmpate.HeaderText = "E(%)";
            this.porcentajeEmpate.Name = "porcentajeEmpate";
            // 
            // porcentajeVisita
            // 
            this.porcentajeVisita.HeaderText = "V(%)";
            this.porcentajeVisita.Name = "porcentajeVisita";
            // 
            // Pronostico
            // 
            this.Pronostico.HeaderText = "Pronostico";
            this.Pronostico.Name = "Pronostico";
            // 
            // frmEntrenarPronosticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 412);
            this.Controls.Add(this.btnEntrenar);
            this.Controls.Add(this.dg_Pronosticos);
            this.Name = "frmEntrenarPronosticos";
            this.Text = "Entrenar Pronosticos";
            this.Load += new System.EventHandler(this.frmEntrenarPronosticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Pronosticos;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPronostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeEmpate;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pronostico;
    }
}