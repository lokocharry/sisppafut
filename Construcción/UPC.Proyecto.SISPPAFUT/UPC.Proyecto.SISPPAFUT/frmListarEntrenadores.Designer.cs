namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmListarEntrenadores
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
            frmListarEntrenador = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEntrenadores = new System.Windows.Forms.DataGridView();
            this.Entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrenadores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEntrenadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relación de Entrenadores";
            // 
            // dgvEntrenadores
            // 
            this.dgvEntrenadores.AllowUserToAddRows = false;
            this.dgvEntrenadores.AllowUserToDeleteRows = false;
            this.dgvEntrenadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrenadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entrenador,
            this.Fecha,
            this.Nacionalidad});
            this.dgvEntrenadores.Location = new System.Drawing.Point(17, 27);
            this.dgvEntrenadores.Name = "dgvEntrenadores";
            this.dgvEntrenadores.ReadOnly = true;
            this.dgvEntrenadores.RowHeadersVisible = false;
            this.dgvEntrenadores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEntrenadores.Size = new System.Drawing.Size(506, 287);
            this.dgvEntrenadores.TabIndex = 0;
            this.dgvEntrenadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntrenadores_CellContentClick);
            // 
            // Entrenador
            // 
            this.Entrenador.HeaderText = "Entrenadores";
            this.Entrenador.Name = "Entrenador";
            this.Entrenador.ReadOnly = true;
            this.Entrenador.Width = 280;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha de Nacimiento";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 110;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.HeaderText = "Nacionalidad";
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.ReadOnly = true;
            this.Nacionalidad.Width = 110;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(460, 347);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 28);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmListarEntrenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 387);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListarEntrenadores";
            this.ShowIcon = false;
            this.Text = "Entrenadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmListarEntrenadores_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrenadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEntrenadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nacionalidad;
        private System.Windows.Forms.Button btnEditar;
    }
}