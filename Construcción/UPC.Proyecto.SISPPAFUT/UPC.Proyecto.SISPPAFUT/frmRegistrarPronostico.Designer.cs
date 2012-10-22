namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmRegistrarPronostico
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
            frmRegistroPronosticos = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPronosticos = new System.Windows.Forms.DataGridView();
            this.CodPartido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipoLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipoVisitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Empate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Visita = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPronosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPronosticos
            // 
            this.dgvPronosticos.AllowUserToAddRows = false;
            this.dgvPronosticos.AllowUserToDeleteRows = false;
            this.dgvPronosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPronosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodPartido,
            this.EquipoLocal,
            this.EquipoVisitante,
            this.Local,
            this.Empate,
            this.Visita});
            this.dgvPronosticos.Location = new System.Drawing.Point(22, 24);
            this.dgvPronosticos.Name = "dgvPronosticos";
            this.dgvPronosticos.RowHeadersVisible = false;
            this.dgvPronosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPronosticos.Size = new System.Drawing.Size(455, 189);
            this.dgvPronosticos.TabIndex = 0;
            this.dgvPronosticos.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvPronosticos_CancelRowEdit);
            this.dgvPronosticos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPronosticos_CellClick);
            this.dgvPronosticos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inSeleccionarTipo);
            this.dgvPronosticos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPronosticos_CellEndEdit);
            // 
            // CodPartido
            // 
            this.CodPartido.HeaderText = "Partido";
            this.CodPartido.Name = "CodPartido";
            this.CodPartido.Visible = false;
            // 
            // EquipoLocal
            // 
            this.EquipoLocal.HeaderText = "Equipo Local";
            this.EquipoLocal.Name = "EquipoLocal";
            this.EquipoLocal.Width = 150;
            // 
            // EquipoVisitante
            // 
            this.EquipoVisitante.HeaderText = "Equipo Visitante";
            this.EquipoVisitante.Name = "EquipoVisitante";
            this.EquipoVisitante.Width = 150;
            // 
            // Local
            // 
            this.Local.HeaderText = "Local";
            this.Local.Name = "Local";
            this.Local.Width = 50;
            // 
            // Empate
            // 
            this.Empate.HeaderText = "Empate";
            this.Empate.Name = "Empate";
            this.Empate.Width = 50;
            // 
            // Visita
            // 
            this.Visita.HeaderText = "Visita";
            this.Visita.Name = "Visita";
            this.Visita.Width = 50;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(395, 219);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmRegistrarPronostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 268);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvPronosticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarPronostico";
            this.Text = "Mis Pronosticos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmRegistrarPronostico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPronosticos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPronosticos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPartido;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoVisitante;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Local;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Empate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visita;
    }
}