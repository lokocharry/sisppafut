namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmPartidoInsertar
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
            this.lbl_pais = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_liga = new System.Windows.Forms.Label();
            this.lbl_local = new System.Windows.Forms.Label();
            this.lbl_visitante = new System.Windows.Forms.Label();
            this.lbl_estadio = new System.Windows.Forms.Label();
            this.cmb_pais = new System.Windows.Forms.ComboBox();
            this.cmb_estadio = new System.Windows.Forms.ComboBox();
            this.cmb_local = new System.Windows.Forms.ComboBox();
            this.cmb_competicion = new System.Windows.Forms.ComboBox();
            this.cmb_temporada = new System.Windows.Forms.ComboBox();
            this.cmb_visitante = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.lbl_nacimiento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Location = new System.Drawing.Point(36, 39);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(33, 13);
            this.lbl_pais.TabIndex = 0;
            this.lbl_pais.Text = "Pais :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Competicion :";
            // 
            // lbl_liga
            // 
            this.lbl_liga.AutoSize = true;
            this.lbl_liga.Location = new System.Drawing.Point(341, 72);
            this.lbl_liga.Name = "lbl_liga";
            this.lbl_liga.Size = new System.Drawing.Size(70, 13);
            this.lbl_liga.TabIndex = 2;
            this.lbl_liga.Text = "Temporada : ";
            // 
            // lbl_local
            // 
            this.lbl_local.AutoSize = true;
            this.lbl_local.Location = new System.Drawing.Point(36, 108);
            this.lbl_local.Name = "lbl_local";
            this.lbl_local.Size = new System.Drawing.Size(75, 13);
            this.lbl_local.TabIndex = 3;
            this.lbl_local.Text = "Equipo Local :";
            // 
            // lbl_visitante
            // 
            this.lbl_visitante.AutoSize = true;
            this.lbl_visitante.Location = new System.Drawing.Point(341, 105);
            this.lbl_visitante.Name = "lbl_visitante";
            this.lbl_visitante.Size = new System.Drawing.Size(89, 13);
            this.lbl_visitante.TabIndex = 4;
            this.lbl_visitante.Text = "Equipo Visitante :";
            // 
            // lbl_estadio
            // 
            this.lbl_estadio.AutoSize = true;
            this.lbl_estadio.Location = new System.Drawing.Point(36, 144);
            this.lbl_estadio.Name = "lbl_estadio";
            this.lbl_estadio.Size = new System.Drawing.Size(48, 13);
            this.lbl_estadio.TabIndex = 5;
            this.lbl_estadio.Text = "Estadio :";
            // 
            // cmb_pais
            // 
            this.cmb_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pais.FormattingEnabled = true;
            this.cmb_pais.Location = new System.Drawing.Point(121, 31);
            this.cmb_pais.Name = "cmb_pais";
            this.cmb_pais.Size = new System.Drawing.Size(199, 21);
            this.cmb_pais.TabIndex = 6;
            this.cmb_pais.SelectedIndexChanged += new System.EventHandler(this.cmb_SeleccionarPais);
            // 
            // cmb_estadio
            // 
            this.cmb_estadio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estadio.FormattingEnabled = true;
            this.cmb_estadio.Location = new System.Drawing.Point(121, 136);
            this.cmb_estadio.Name = "cmb_estadio";
            this.cmb_estadio.Size = new System.Drawing.Size(199, 21);
            this.cmb_estadio.TabIndex = 7;
            // 
            // cmb_local
            // 
            this.cmb_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_local.FormattingEnabled = true;
            this.cmb_local.Location = new System.Drawing.Point(121, 100);
            this.cmb_local.Name = "cmb_local";
            this.cmb_local.Size = new System.Drawing.Size(199, 21);
            this.cmb_local.TabIndex = 10;
            this.cmb_local.SelectedIndexChanged += new System.EventHandler(this.cmb_SeleccionarEquipoLocal);
            // 
            // cmb_competicion
            // 
            this.cmb_competicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_competicion.FormattingEnabled = true;
            this.cmb_competicion.Location = new System.Drawing.Point(121, 64);
            this.cmb_competicion.Name = "cmb_competicion";
            this.cmb_competicion.Size = new System.Drawing.Size(199, 21);
            this.cmb_competicion.TabIndex = 11;
            this.cmb_competicion.SelectedIndexChanged += new System.EventHandler(this.cmb_SeleccionarCompeticion);
            // 
            // cmb_temporada
            // 
            this.cmb_temporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_temporada.FormattingEnabled = true;
            this.cmb_temporada.Location = new System.Drawing.Point(432, 64);
            this.cmb_temporada.Name = "cmb_temporada";
            this.cmb_temporada.Size = new System.Drawing.Size(199, 21);
            this.cmb_temporada.TabIndex = 12;
            this.cmb_temporada.SelectedIndexChanged += new System.EventHandler(this.cmb_SeleccionarTemporada);
            // 
            // cmb_visitante
            // 
            this.cmb_visitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_visitante.FormattingEnabled = true;
            this.cmb_visitante.Location = new System.Drawing.Point(432, 97);
            this.cmb_visitante.Name = "cmb_visitante";
            this.cmb_visitante.Size = new System.Drawing.Size(199, 21);
            this.cmb_visitante.TabIndex = 13;
            this.cmb_visitante.SelectedIndexChanged += new System.EventHandler(this.cmb_SeleccionarEquipoVisitante);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(475, 185);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 15;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.inGuardarPartido);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(556, 185);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 16;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.inCancelar);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(432, 134);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(104, 20);
            this.dtp_fecha.TabIndex = 18;
            // 
            // lbl_nacimiento
            // 
            this.lbl_nacimiento.AutoSize = true;
            this.lbl_nacimiento.Location = new System.Drawing.Point(341, 141);
            this.lbl_nacimiento.Name = "lbl_nacimiento";
            this.lbl_nacimiento.Size = new System.Drawing.Size(37, 13);
            this.lbl_nacimiento.TabIndex = 17;
            this.lbl_nacimiento.Text = "Fecha";
            // 
            // frmPartidoInsertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 228);
            this.ControlBox = false;
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.lbl_nacimiento);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cmb_visitante);
            this.Controls.Add(this.cmb_temporada);
            this.Controls.Add(this.cmb_competicion);
            this.Controls.Add(this.cmb_local);
            this.Controls.Add(this.cmb_estadio);
            this.Controls.Add(this.cmb_pais);
            this.Controls.Add(this.lbl_estadio);
            this.Controls.Add(this.lbl_visitante);
            this.Controls.Add(this.lbl_local);
            this.Controls.Add(this.lbl_liga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_pais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPartidoInsertar";
            this.Text = "Partido";
            this.Load += new System.EventHandler(this.frmPartidoInsertar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_liga;
        private System.Windows.Forms.Label lbl_local;
        private System.Windows.Forms.Label lbl_visitante;
        private System.Windows.Forms.Label lbl_estadio;
        private System.Windows.Forms.ComboBox cmb_pais;
        private System.Windows.Forms.ComboBox cmb_estadio;
        private System.Windows.Forms.ComboBox cmb_local;
        private System.Windows.Forms.ComboBox cmb_competicion;
        private System.Windows.Forms.ComboBox cmb_temporada;
        private System.Windows.Forms.ComboBox cmb_visitante;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label lbl_nacimiento;
    }
}