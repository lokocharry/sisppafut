namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmApostadorVerPronosticos
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
            frmVerPronosticos = null;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_temporada = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_pais = new System.Windows.Forms.ComboBox();
            this.cmb_competicion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.codPartido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pronostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.Pronostico,
            this.Fecha});
            this.dg_Pronosticos.Location = new System.Drawing.Point(274, 23);
            this.dg_Pronosticos.Name = "dg_Pronosticos";
            this.dg_Pronosticos.ReadOnly = true;
            this.dg_Pronosticos.RowHeadersVisible = false;
            this.dg_Pronosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dg_Pronosticos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Pronosticos.Size = new System.Drawing.Size(441, 274);
            this.dg_Pronosticos.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_temporada);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_pais);
            this.groupBox1.Controls.Add(this.cmb_competicion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 208);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Área de Selección";
            // 
            // cmb_temporada
            // 
            this.cmb_temporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_temporada.FormattingEnabled = true;
            this.cmb_temporada.Location = new System.Drawing.Point(93, 105);
            this.cmb_temporada.Name = "cmb_temporada";
            this.cmb_temporada.Size = new System.Drawing.Size(145, 21);
            this.cmb_temporada.TabIndex = 6;
            this.cmb_temporada.SelectedValueChanged += new System.EventHandler(this.inSeleccionarTemporada);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Temporada:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mostrar Predicciones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.inMostrarPredicciones);
            // 
            // cmb_pais
            // 
            this.cmb_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pais.FormattingEnabled = true;
            this.cmb_pais.Location = new System.Drawing.Point(93, 33);
            this.cmb_pais.Name = "cmb_pais";
            this.cmb_pais.Size = new System.Drawing.Size(145, 21);
            this.cmb_pais.TabIndex = 3;
            this.cmb_pais.SelectedValueChanged += new System.EventHandler(this.cmb_SeleccionarPais);
            // 
            // cmb_competicion
            // 
            this.cmb_competicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_competicion.FormattingEnabled = true;
            this.cmb_competicion.Location = new System.Drawing.Point(93, 69);
            this.cmb_competicion.Name = "cmb_competicion";
            this.cmb_competicion.Size = new System.Drawing.Size(145, 21);
            this.cmb_competicion.TabIndex = 2;
            this.cmb_competicion.SelectedValueChanged += new System.EventHandler(this.cmb_SeleccionarCompeticion);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Competencia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "País:";
            // 
            // codPartido
            // 
            this.codPartido.HeaderText = "Codigo Partido";
            this.codPartido.Name = "codPartido";
            this.codPartido.ReadOnly = true;
            this.codPartido.Visible = false;
            this.codPartido.Width = 20;
            // 
            // codPronostico
            // 
            this.codPronostico.HeaderText = "Codigo Pronostico";
            this.codPronostico.Name = "codPronostico";
            this.codPronostico.ReadOnly = true;
            this.codPronostico.Visible = false;
            this.codPronostico.Width = 20;
            // 
            // Local
            // 
            this.Local.HeaderText = "Equipo Local";
            this.Local.Name = "Local";
            this.Local.ReadOnly = true;
            this.Local.Width = 120;
            // 
            // Visitante
            // 
            this.Visitante.HeaderText = "Equipo Visitante";
            this.Visitante.Name = "Visitante";
            this.Visitante.ReadOnly = true;
            this.Visitante.Width = 120;
            // 
            // Pronostico
            // 
            this.Pronostico.HeaderText = "Pronóstico";
            this.Pronostico.Name = "Pronostico";
            this.Pronostico.ReadOnly = true;
            this.Pronostico.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // frmApostadorVerPronosticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 319);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dg_Pronosticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApostadorVerPronosticos";
            this.Text = "Pronosticos de la semana";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pronosticos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Pronosticos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_pais;
        private System.Windows.Forms.ComboBox cmb_competicion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_temporada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPronostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pronostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}