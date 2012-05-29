namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmActualizarRanking
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
            frmRanking = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_anio = new System.Windows.Forms.Label();
            this.lbl_mes = new System.Windows.Forms.Label();
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.lbl_posicion = new System.Windows.Forms.Label();
            this.lbl_puntos = new System.Windows.Forms.Label();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Location = new System.Drawing.Point(26, 38);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(30, 13);
            this.lbl_pais.TabIndex = 0;
            this.lbl_pais.Text = "Pais:";
            // 
            // lbl_anio
            // 
            this.lbl_anio.AutoSize = true;
            this.lbl_anio.Location = new System.Drawing.Point(27, 82);
            this.lbl_anio.Name = "lbl_anio";
            this.lbl_anio.Size = new System.Drawing.Size(29, 13);
            this.lbl_anio.TabIndex = 1;
            this.lbl_anio.Text = "Año:";
            // 
            // lbl_mes
            // 
            this.lbl_mes.AutoSize = true;
            this.lbl_mes.Location = new System.Drawing.Point(26, 124);
            this.lbl_mes.Name = "lbl_mes";
            this.lbl_mes.Size = new System.Drawing.Size(30, 13);
            this.lbl_mes.TabIndex = 2;
            this.lbl_mes.Text = "Mes:";
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Location = new System.Drawing.Point(258, 38);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(43, 13);
            this.lbl_equipo.TabIndex = 3;
            this.lbl_equipo.Text = "Equipo:";
            // 
            // lbl_posicion
            // 
            this.lbl_posicion.AutoSize = true;
            this.lbl_posicion.Location = new System.Drawing.Point(251, 82);
            this.lbl_posicion.Name = "lbl_posicion";
            this.lbl_posicion.Size = new System.Drawing.Size(50, 13);
            this.lbl_posicion.TabIndex = 4;
            this.lbl_posicion.Text = "Posicion:";
            // 
            // lbl_puntos
            // 
            this.lbl_puntos.AutoSize = true;
            this.lbl_puntos.Location = new System.Drawing.Point(258, 124);
            this.lbl_puntos.Name = "lbl_puntos";
            this.lbl_puntos.Size = new System.Drawing.Size(43, 13);
            this.lbl_puntos.TabIndex = 5;
            this.lbl_puntos.Text = "Puntos:";
            // 
            // cmbPais
            // 
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(62, 35);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(181, 21);
            this.cmbPais.TabIndex = 6;
            this.cmbPais.SelectedIndexChanged += new System.EventHandler(this.cmbPais_SelectedIndexChanged);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(62, 79);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(95, 21);
            this.cmbAnio.TabIndex = 7;
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(62, 124);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(95, 21);
            this.cmbMes.TabIndex = 8;
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(307, 35);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(181, 21);
            this.cmbEquipo.TabIndex = 9;
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(307, 79);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(95, 20);
            this.txtPosicion.TabIndex = 10;
            // 
            // txtPuntos
            // 
            this.txtPuntos.Location = new System.Drawing.Point(307, 121);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(95, 20);
            this.txtPuntos.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(269, 167);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(413, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmActualizarRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 210);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.txtPosicion);
            this.Controls.Add(this.cmbEquipo);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.lbl_puntos);
            this.Controls.Add(this.lbl_posicion);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.lbl_mes);
            this.Controls.Add(this.lbl_anio);
            this.Controls.Add(this.lbl_pais);
            this.Name = "frmActualizarRanking";
            this.Text = "Actualizar Ranking Mundial de Clubes";
            this.Load += new System.EventHandler(this.frmActualizarRanking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_anio;
        private System.Windows.Forms.Label lbl_mes;
        private System.Windows.Forms.Label lbl_equipo;
        private System.Windows.Forms.Label lbl_posicion;
        private System.Windows.Forms.Label lbl_puntos;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}