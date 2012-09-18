namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmConsultarHistorialJugador
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
            frmConsultarHistorial = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConsultarHistorial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.CodJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombresJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidosJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbJugador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNacionalidad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultarHistorial
            // 
            this.btnConsultarHistorial.Location = new System.Drawing.Point(164, 133);
            this.btnConsultarHistorial.Name = "btnConsultarHistorial";
            this.btnConsultarHistorial.Size = new System.Drawing.Size(121, 33);
            this.btnConsultarHistorial.TabIndex = 0;
            this.btnConsultarHistorial.Text = "Consultar Historial";
            this.btnConsultarHistorial.UseVisualStyleBackColor = true;
            this.btnConsultarHistorial.Click += new System.EventHandler(this.btnConsultarHistorial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jugador";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodJugador,
            this.NombresJugador,
            this.ApellidosJugador,
            this.NombreEquipo});
            this.dgvHistorial.Location = new System.Drawing.Point(306, 35);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(345, 235);
            this.dgvHistorial.TabIndex = 2;
            // 
            // CodJugador
            // 
            this.CodJugador.HeaderText = "CodJugador";
            this.CodJugador.Name = "CodJugador";
            this.CodJugador.ReadOnly = true;
            this.CodJugador.Visible = false;
            // 
            // NombresJugador
            // 
            this.NombresJugador.HeaderText = "Nombres Jugador";
            this.NombresJugador.Name = "NombresJugador";
            this.NombresJugador.ReadOnly = true;
            // 
            // ApellidosJugador
            // 
            this.ApellidosJugador.HeaderText = "Apellidos Jugador";
            this.ApellidosJugador.Name = "ApellidosJugador";
            this.ApellidosJugador.ReadOnly = true;
            // 
            // NombreEquipo
            // 
            this.NombreEquipo.HeaderText = "Equipo";
            this.NombreEquipo.Name = "NombreEquipo";
            this.NombreEquipo.ReadOnly = true;
            // 
            // cmbJugador
            // 
            this.cmbJugador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.Location = new System.Drawing.Point(112, 79);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(173, 21);
            this.cmbJugador.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nacionalidad";
            // 
            // cmbNacionalidad
            // 
            this.cmbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNacionalidad.FormattingEnabled = true;
            this.cmbNacionalidad.Location = new System.Drawing.Point(112, 35);
            this.cmbNacionalidad.Name = "cmbNacionalidad";
            this.cmbNacionalidad.Size = new System.Drawing.Size(173, 21);
            this.cmbNacionalidad.TabIndex = 4;
            this.cmbNacionalidad.SelectedIndexChanged += new System.EventHandler(this.selectedNacionalidad);
            // 
            // frmConsultarHistorialJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 295);
            this.Controls.Add(this.cmbNacionalidad);
            this.Controls.Add(this.cmbJugador);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConsultarHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarHistorialJugador";
            this.Text = "Historial de Jugador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmConsultarHistorialJugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultarHistorial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.ComboBox cmbJugador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodJugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombresJugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidosJugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEquipo;
    }
}