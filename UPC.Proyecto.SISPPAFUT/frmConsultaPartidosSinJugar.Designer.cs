namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmConsultaPartidosSinJugar
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
            frmListarPartidos = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_lista_partidos = new System.Windows.Forms.DataGridView();
            this.cod_partido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partido_pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partido_liga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partido_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partido_visita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partido_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_editar_partido = new System.Windows.Forms.Button();
            this.btn_editar_datos_partido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_partidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_lista_partidos
            // 
            this.dgv_lista_partidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_lista_partidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_partido,
            this.partido_pais,
            this.partido_liga,
            this.partido_local,
            this.partido_visita,
            this.partido_fecha});
            this.dgv_lista_partidos.Location = new System.Drawing.Point(22, 25);
            this.dgv_lista_partidos.Name = "dgv_lista_partidos";
            this.dgv_lista_partidos.RowHeadersVisible = false;
            this.dgv_lista_partidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_lista_partidos.Size = new System.Drawing.Size(520, 354);
            this.dgv_lista_partidos.TabIndex = 0;
            // 
            // cod_partido
            // 
            this.cod_partido.DataPropertyName = "Codigo_partido";
            this.cod_partido.HeaderText = "Código";
            this.cod_partido.Name = "cod_partido";
            this.cod_partido.Visible = false;
            // 
            // partido_pais
            // 
            this.partido_pais.DataPropertyName = "Pais";
            this.partido_pais.HeaderText = "País";
            this.partido_pais.Name = "partido_pais";
            // 
            // partido_liga
            // 
            this.partido_liga.DataPropertyName = "Liga";
            this.partido_liga.HeaderText = "Liga";
            this.partido_liga.Name = "partido_liga";
            // 
            // partido_local
            // 
            this.partido_local.DataPropertyName = "Equipo_local";
            this.partido_local.HeaderText = "Equipo Local";
            this.partido_local.Name = "partido_local";
            // 
            // partido_visita
            // 
            this.partido_visita.DataPropertyName = "Equipo_visitante";
            this.partido_visita.HeaderText = "Equipo Visita";
            this.partido_visita.Name = "partido_visita";
            // 
            // partido_fecha
            // 
            this.partido_fecha.DataPropertyName = "Fecha";
            this.partido_fecha.HeaderText = "Fecha";
            this.partido_fecha.Name = "partido_fecha";
            // 
            // btn_editar_partido
            // 
            this.btn_editar_partido.Location = new System.Drawing.Point(255, 389);
            this.btn_editar_partido.Name = "btn_editar_partido";
            this.btn_editar_partido.Size = new System.Drawing.Size(113, 32);
            this.btn_editar_partido.TabIndex = 1;
            this.btn_editar_partido.Text = "Editar Partido";
            this.btn_editar_partido.UseVisualStyleBackColor = true;
            this.btn_editar_partido.Click += new System.EventHandler(this.btn_editar_partido_Click);
            // 
            // btn_editar_datos_partido
            // 
            this.btn_editar_datos_partido.Location = new System.Drawing.Point(374, 389);
            this.btn_editar_datos_partido.Name = "btn_editar_datos_partido";
            this.btn_editar_datos_partido.Size = new System.Drawing.Size(168, 32);
            this.btn_editar_datos_partido.TabIndex = 2;
            this.btn_editar_datos_partido.Text = "Editar Datos del Partido";
            this.btn_editar_datos_partido.UseVisualStyleBackColor = true;
            this.btn_editar_datos_partido.Click += new System.EventHandler(this.btn_editar_datos_partido_Click);
            // 
            // frmConsultaPartidosSinJugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 433);
            this.Controls.Add(this.btn_editar_datos_partido);
            this.Controls.Add(this.btn_editar_partido);
            this.Controls.Add(this.dgv_lista_partidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaPartidosSinJugar";
            this.Text = "Lista de Partidos sin Jugar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmListaPartidosSinJugar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_partidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lista_partidos;
        private System.Windows.Forms.Button btn_editar_partido;
        private System.Windows.Forms.Button btn_editar_datos_partido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_partido;
        private System.Windows.Forms.DataGridViewTextBoxColumn partido_pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn partido_liga;
        private System.Windows.Forms.DataGridViewTextBoxColumn partido_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn partido_visita;
        private System.Windows.Forms.DataGridViewTextBoxColumn partido_fecha;
    }
}