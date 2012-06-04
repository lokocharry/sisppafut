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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dg_Pronosticos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocentajeLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeEmpate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEntrenar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Pronosticos
            // 
            this.dg_Pronosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Pronosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Local,
            this.Visitante,
            this.pocentajeLocal,
            this.porcentajeEmpate,
            this.porcentajeVisita,
            this.Pronostico});
            this.dg_Pronosticos.Location = new System.Drawing.Point(12, 12);
            this.dg_Pronosticos.Name = "dg_Pronosticos";
            this.dg_Pronosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dg_Pronosticos.Size = new System.Drawing.Size(650, 353);
            this.dg_Pronosticos.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
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
            // pocentajeLocal
            // 
            this.pocentajeLocal.HeaderText = "L(%)";
            this.pocentajeLocal.Name = "pocentajeLocal";
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
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(532, 377);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(130, 23);
            this.btnEntrenar.TabIndex = 1;
            this.btnEntrenar.Text = "Entrenar";
            this.btnEntrenar.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocentajeLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeEmpate;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pronostico;
        private System.Windows.Forms.Button btnEntrenar;
    }
}