namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmEstadisticasEquipo
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
            this.cmb_liga = new System.Windows.Forms.ComboBox();
            this.cmb_equipo = new System.Windows.Forms.ComboBox();
            this.lbl_liga = new System.Windows.Forms.Label();
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.gp_ultimos_partidos = new System.Windows.Forms.GroupBox();
            this.gb_jugadores = new System.Windows.Forms.GroupBox();
            this.dgv_ultimos_partidos = new System.Windows.Forms.DataGridView();
            this.dgv_jugadores = new System.Windows.Forms.DataGridView();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.gp_ultimos_partidos.SuspendLayout();
            this.gb_jugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ultimos_partidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_liga
            // 
            this.cmb_liga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_liga.FormattingEnabled = true;
            this.cmb_liga.Location = new System.Drawing.Point(103, 27);
            this.cmb_liga.Name = "cmb_liga";
            this.cmb_liga.Size = new System.Drawing.Size(344, 21);
            this.cmb_liga.TabIndex = 0;
            // 
            // cmb_equipo
            // 
            this.cmb_equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipo.FormattingEnabled = true;
            this.cmb_equipo.Location = new System.Drawing.Point(103, 54);
            this.cmb_equipo.Name = "cmb_equipo";
            this.cmb_equipo.Size = new System.Drawing.Size(344, 21);
            this.cmb_equipo.TabIndex = 1;
            // 
            // lbl_liga
            // 
            this.lbl_liga.AutoSize = true;
            this.lbl_liga.Location = new System.Drawing.Point(33, 30);
            this.lbl_liga.Name = "lbl_liga";
            this.lbl_liga.Size = new System.Drawing.Size(33, 13);
            this.lbl_liga.TabIndex = 2;
            this.lbl_liga.Text = "Liga :";
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Location = new System.Drawing.Point(33, 57);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(46, 13);
            this.lbl_equipo.TabIndex = 3;
            this.lbl_equipo.Text = "Equipo :";
            // 
            // gp_ultimos_partidos
            // 
            this.gp_ultimos_partidos.Controls.Add(this.dgv_ultimos_partidos);
            this.gp_ultimos_partidos.Location = new System.Drawing.Point(20, 141);
            this.gp_ultimos_partidos.Name = "gp_ultimos_partidos";
            this.gp_ultimos_partidos.Size = new System.Drawing.Size(444, 321);
            this.gp_ultimos_partidos.TabIndex = 4;
            this.gp_ultimos_partidos.TabStop = false;
            this.gp_ultimos_partidos.Text = "5 Últimos Partidos";
            // 
            // gb_jugadores
            // 
            this.gb_jugadores.Controls.Add(this.dgv_jugadores);
            this.gb_jugadores.Location = new System.Drawing.Point(491, 27);
            this.gb_jugadores.Name = "gb_jugadores";
            this.gb_jugadores.Size = new System.Drawing.Size(464, 435);
            this.gb_jugadores.TabIndex = 5;
            this.gb_jugadores.TabStop = false;
            this.gb_jugadores.Text = "Lista de Jugadores";
            // 
            // dgv_ultimos_partidos
            // 
            this.dgv_ultimos_partidos.AllowUserToAddRows = false;
            this.dgv_ultimos_partidos.AllowUserToDeleteRows = false;
            this.dgv_ultimos_partidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ultimos_partidos.Location = new System.Drawing.Point(16, 28);
            this.dgv_ultimos_partidos.Name = "dgv_ultimos_partidos";
            this.dgv_ultimos_partidos.ReadOnly = true;
            this.dgv_ultimos_partidos.Size = new System.Drawing.Size(411, 275);
            this.dgv_ultimos_partidos.TabIndex = 0;
            // 
            // dgv_jugadores
            // 
            this.dgv_jugadores.AllowUserToAddRows = false;
            this.dgv_jugadores.AllowUserToDeleteRows = false;
            this.dgv_jugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jugadores.Location = new System.Drawing.Point(18, 27);
            this.dgv_jugadores.Name = "dgv_jugadores";
            this.dgv_jugadores.ReadOnly = true;
            this.dgv_jugadores.Size = new System.Drawing.Size(429, 390);
            this.dgv_jugadores.TabIndex = 1;
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.Location = new System.Drawing.Point(103, 90);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(125, 23);
            this.btn_refrescar.TabIndex = 6;
            this.btn_refrescar.Text = "Refrescar";
            this.btn_refrescar.UseVisualStyleBackColor = true;
            // 
            // frmEstadisticasEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 478);
            this.Controls.Add(this.btn_refrescar);
            this.Controls.Add(this.gb_jugadores);
            this.Controls.Add(this.gp_ultimos_partidos);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.lbl_liga);
            this.Controls.Add(this.cmb_equipo);
            this.Controls.Add(this.cmb_liga);
            this.Name = "frmEstadisticasEquipo";
            this.Text = "Estadisticas del Equipo";
            this.Load += new System.EventHandler(this.frmEstadisticasEquipo_Load);
            this.gp_ultimos_partidos.ResumeLayout(false);
            this.gb_jugadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ultimos_partidos)).EndInit();
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
    }
}