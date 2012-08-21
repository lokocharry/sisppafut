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
            this.btnConsultarHistorial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.cmbJugador = new System.Windows.Forms.ComboBox();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temporada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultarHistorial
            // 
            this.btnConsultarHistorial.Location = new System.Drawing.Point(12, 78);
            this.btnConsultarHistorial.Name = "btnConsultarHistorial";
            this.btnConsultarHistorial.Size = new System.Drawing.Size(121, 27);
            this.btnConsultarHistorial.TabIndex = 0;
            this.btnConsultarHistorial.Text = "Consultar Historial";
            this.btnConsultarHistorial.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jugador";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Club,
            this.Temporada});
            this.dgvHistorial.Location = new System.Drawing.Point(244, 35);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(200, 235);
            this.dgvHistorial.TabIndex = 2;
            // 
            // cmbJugador
            // 
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.Location = new System.Drawing.Point(63, 35);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(175, 21);
            this.cmbJugador.TabIndex = 3;
            // 
            // Club
            // 
            this.Club.HeaderText = "Club";
            this.Club.Name = "Club";
            // 
            // Temporada
            // 
            this.Temporada.HeaderText = "Temporada";
            this.Temporada.Name = "Temporada";
            // 
            // frmConsultarHistorialJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 295);
            this.Controls.Add(this.cmbJugador);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConsultarHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarHistorialJugador";
            this.Text = "Historial de Jugador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultarHistorial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.ComboBox cmbJugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temporada;
    }
}