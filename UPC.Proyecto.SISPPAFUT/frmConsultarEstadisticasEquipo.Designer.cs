namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmConsultarEstadisticasEquipo
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
            frmEstadisticaEquipo = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_liga = new System.Windows.Forms.ComboBox();
            this.cmb_equipo = new System.Windows.Forms.ComboBox();
            this.lbl_liga = new System.Windows.Forms.Label();
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.gp_ultimos_partidos = new System.Windows.Forms.GroupBox();
            this.dgv_ultimos_partidos = new System.Windows.Forms.DataGridView();
            this.EquipoLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipoVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPartido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_jugadores = new System.Windows.Forms.GroupBox();
            this.dgv_jugadores = new System.Windows.Forms.DataGridView();
            this.col_jugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_goles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_partidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.gp_ultimos_partidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ultimos_partidos)).BeginInit();
            this.gb_jugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_liga
            // 
            this.cmb_liga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_liga.FormattingEnabled = true;
            this.cmb_liga.Location = new System.Drawing.Point(99, 26);
            this.cmb_liga.Name = "cmb_liga";
            this.cmb_liga.Size = new System.Drawing.Size(178, 21);
            this.cmb_liga.TabIndex = 0;
            this.cmb_liga.SelectedIndexChanged += new System.EventHandler(this.inLigaSeleccionada);
            // 
            // cmb_equipo
            // 
            this.cmb_equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipo.FormattingEnabled = true;
            this.cmb_equipo.Location = new System.Drawing.Point(99, 53);
            this.cmb_equipo.Name = "cmb_equipo";
            this.cmb_equipo.Size = new System.Drawing.Size(178, 21);
            this.cmb_equipo.TabIndex = 1;
            // 
            // lbl_liga
            // 
            this.lbl_liga.AutoSize = true;
            this.lbl_liga.Location = new System.Drawing.Point(29, 29);
            this.lbl_liga.Name = "lbl_liga";
            this.lbl_liga.Size = new System.Drawing.Size(33, 13);
            this.lbl_liga.TabIndex = 2;
            this.lbl_liga.Text = "Liga :";
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Location = new System.Drawing.Point(29, 56);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(46, 13);
            this.lbl_equipo.TabIndex = 3;
            this.lbl_equipo.Text = "Equipo :";
            // 
            // gp_ultimos_partidos
            // 
            this.gp_ultimos_partidos.Controls.Add(this.dgv_ultimos_partidos);
            this.gp_ultimos_partidos.Location = new System.Drawing.Point(20, 98);
            this.gp_ultimos_partidos.Name = "gp_ultimos_partidos";
            this.gp_ultimos_partidos.Size = new System.Drawing.Size(471, 319);
            this.gp_ultimos_partidos.TabIndex = 4;
            this.gp_ultimos_partidos.TabStop = false;
            this.gp_ultimos_partidos.Text = "Últimos 5 Partidos";
            // 
            // dgv_ultimos_partidos
            // 
            this.dgv_ultimos_partidos.AllowUserToAddRows = false;
            this.dgv_ultimos_partidos.AllowUserToDeleteRows = false;
            this.dgv_ultimos_partidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ultimos_partidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EquipoLocal,
            this.EquipoVisita,
            this.Resultado,
            this.FechaPartido});
            this.dgv_ultimos_partidos.Location = new System.Drawing.Point(12, 28);
            this.dgv_ultimos_partidos.Name = "dgv_ultimos_partidos";
            this.dgv_ultimos_partidos.ReadOnly = true;
            this.dgv_ultimos_partidos.Size = new System.Drawing.Size(444, 275);
            this.dgv_ultimos_partidos.TabIndex = 0;
            // 
            // EquipoLocal
            // 
            this.EquipoLocal.HeaderText = "Equipo Local";
            this.EquipoLocal.Name = "EquipoLocal";
            this.EquipoLocal.ReadOnly = true;
            // 
            // EquipoVisita
            // 
            this.EquipoVisita.HeaderText = "Equipo Visitante";
            this.EquipoVisita.Name = "EquipoVisita";
            this.EquipoVisita.ReadOnly = true;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            // 
            // FechaPartido
            // 
            this.FechaPartido.HeaderText = "Fecha";
            this.FechaPartido.Name = "FechaPartido";
            this.FechaPartido.ReadOnly = true;
            // 
            // gb_jugadores
            // 
            this.gb_jugadores.Controls.Add(this.dgv_jugadores);
            this.gb_jugadores.Location = new System.Drawing.Point(497, 98);
            this.gb_jugadores.Name = "gb_jugadores";
            this.gb_jugadores.Size = new System.Drawing.Size(367, 319);
            this.gb_jugadores.TabIndex = 5;
            this.gb_jugadores.TabStop = false;
            this.gb_jugadores.Text = "Lista de Jugadores";
            // 
            // dgv_jugadores
            // 
            this.dgv_jugadores.AllowUserToAddRows = false;
            this.dgv_jugadores.AllowUserToDeleteRows = false;
            this.dgv_jugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jugadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jugador,
            this.col_goles,
            this.col_partidos});
            this.dgv_jugadores.Location = new System.Drawing.Point(18, 27);
            this.dgv_jugadores.Name = "dgv_jugadores";
            this.dgv_jugadores.ReadOnly = true;
            this.dgv_jugadores.Size = new System.Drawing.Size(334, 276);
            this.dgv_jugadores.TabIndex = 1;
            // 
            // col_jugador
            // 
            this.col_jugador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_jugador.HeaderText = "Jugador";
            this.col_jugador.Name = "col_jugador";
            this.col_jugador.ReadOnly = true;
            this.col_jugador.Width = 170;
            // 
            // col_goles
            // 
            this.col_goles.HeaderText = "Cantidad Goles";
            this.col_goles.Name = "col_goles";
            this.col_goles.ReadOnly = true;
            this.col_goles.Width = 50;
            // 
            // col_partidos
            // 
            this.col_partidos.HeaderText = "Cantidad Partidos";
            this.col_partidos.Name = "col_partidos";
            this.col_partidos.ReadOnly = true;
            this.col_partidos.Width = 50;
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.Location = new System.Drawing.Point(283, 40);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(101, 34);
            this.btn_refrescar.TabIndex = 6;
            this.btn_refrescar.Text = "Refrescar";
            this.btn_refrescar.UseVisualStyleBackColor = true;
            this.btn_refrescar.Click += new System.EventHandler(this.btn_refrescar_Click);
            // 
            // frmConsultarEstadisticasEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 431);
            this.Controls.Add(this.btn_refrescar);
            this.Controls.Add(this.gb_jugadores);
            this.Controls.Add(this.gp_ultimos_partidos);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.lbl_liga);
            this.Controls.Add(this.cmb_equipo);
            this.Controls.Add(this.cmb_liga);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarEstadisticasEquipo";
            this.Text = "Estadisticas del Equipo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmEstadisticasEquipo_Load);
            this.gp_ultimos_partidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ultimos_partidos)).EndInit();
            this.gb_jugadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_liga;
        private System.Windows.Forms.ComboBox cmb_equipo;
        private System.Windows.Forms.Label lbl_liga;
        private System.Windows.Forms.Label lbl_equipo;
        private System.Windows.Forms.GroupBox gp_ultimos_partidos;
        private System.Windows.Forms.DataGridView dgv_ultimos_partidos;
        private System.Windows.Forms.GroupBox gb_jugadores;
        private System.Windows.Forms.DataGridView dgv_jugadores;
        private System.Windows.Forms.Button btn_refrescar;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPartido;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_goles;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_partidos;
    }
}