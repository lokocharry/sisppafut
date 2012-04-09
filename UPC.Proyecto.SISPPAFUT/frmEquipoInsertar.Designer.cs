namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmEquipoInsertar
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
            frmEquipo = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_anio = new System.Windows.Forms.Label();
            this.lbl_estadioPrincipal = new System.Windows.Forms.Label();
            this.lbl_EstadioAlterno = new System.Windows.Forms.Label();
            this.lbl_ciudad = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_ciudad = new System.Windows.Forms.TextBox();
            this.cmb_pais = new System.Windows.Forms.ComboBox();
            this.cmb_anio = new System.Windows.Forms.ComboBox();
            this.cmb_estadioPrincipal = new System.Windows.Forms.ComboBox();
            this.cmb_estadioAlterno = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.brn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(189, 25);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(181, 24);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Registro de Equipos";
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Location = new System.Drawing.Point(31, 66);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(44, 13);
            this.lbl_equipo.TabIndex = 1;
            this.lbl_equipo.Text = "Nombre";
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Location = new System.Drawing.Point(31, 100);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(27, 13);
            this.lbl_pais.TabIndex = 2;
            this.lbl_pais.Text = "Pais";
            // 
            // lbl_anio
            // 
            this.lbl_anio.AutoSize = true;
            this.lbl_anio.Location = new System.Drawing.Point(31, 130);
            this.lbl_anio.Name = "lbl_anio";
            this.lbl_anio.Size = new System.Drawing.Size(76, 13);
            this.lbl_anio.TabIndex = 3;
            this.lbl_anio.Text = "Año fundacion";
            // 
            // lbl_estadioPrincipal
            // 
            this.lbl_estadioPrincipal.AutoSize = true;
            this.lbl_estadioPrincipal.Location = new System.Drawing.Point(267, 100);
            this.lbl_estadioPrincipal.Name = "lbl_estadioPrincipal";
            this.lbl_estadioPrincipal.Size = new System.Drawing.Size(85, 13);
            this.lbl_estadioPrincipal.TabIndex = 4;
            this.lbl_estadioPrincipal.Text = "Estadio Principal";
            // 
            // lbl_EstadioAlterno
            // 
            this.lbl_EstadioAlterno.AutoSize = true;
            this.lbl_EstadioAlterno.Location = new System.Drawing.Point(267, 130);
            this.lbl_EstadioAlterno.Name = "lbl_EstadioAlterno";
            this.lbl_EstadioAlterno.Size = new System.Drawing.Size(78, 13);
            this.lbl_EstadioAlterno.TabIndex = 5;
            this.lbl_EstadioAlterno.Text = "Estadio Alterno";
            // 
            // lbl_ciudad
            // 
            this.lbl_ciudad.AutoSize = true;
            this.lbl_ciudad.Location = new System.Drawing.Point(31, 162);
            this.lbl_ciudad.Name = "lbl_ciudad";
            this.lbl_ciudad.Size = new System.Drawing.Size(40, 13);
            this.lbl_ciudad.TabIndex = 6;
            this.lbl_ciudad.Text = "Ciudad";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(112, 63);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(391, 20);
            this.txt_nombre.TabIndex = 7;
            // 
            // txt_ciudad
            // 
            this.txt_ciudad.Location = new System.Drawing.Point(112, 159);
            this.txt_ciudad.Name = "txt_ciudad";
            this.txt_ciudad.Size = new System.Drawing.Size(149, 20);
            this.txt_ciudad.TabIndex = 8;
            // 
            // cmb_pais
            // 
            this.cmb_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pais.FormattingEnabled = true;
            this.cmb_pais.Items.AddRange(new object[] {
            "(Seleccione un pais...)"});
            this.cmb_pais.Location = new System.Drawing.Point(112, 97);
            this.cmb_pais.Name = "cmb_pais";
            this.cmb_pais.Size = new System.Drawing.Size(149, 21);
            this.cmb_pais.TabIndex = 9;
            // 
            // cmb_anio
            // 
            this.cmb_anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_anio.FormattingEnabled = true;
            this.cmb_anio.Items.AddRange(new object[] {
            "(Seleccione un año...)"});
            this.cmb_anio.Location = new System.Drawing.Point(113, 127);
            this.cmb_anio.Name = "cmb_anio";
            this.cmb_anio.Size = new System.Drawing.Size(148, 21);
            this.cmb_anio.TabIndex = 10;
            // 
            // cmb_estadioPrincipal
            // 
            this.cmb_estadioPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estadioPrincipal.FormattingEnabled = true;
            this.cmb_estadioPrincipal.Items.AddRange(new object[] {
            "(Seleccionar estadio...)"});
            this.cmb_estadioPrincipal.Location = new System.Drawing.Point(358, 97);
            this.cmb_estadioPrincipal.Name = "cmb_estadioPrincipal";
            this.cmb_estadioPrincipal.Size = new System.Drawing.Size(145, 21);
            this.cmb_estadioPrincipal.TabIndex = 11;
            // 
            // cmb_estadioAlterno
            // 
            this.cmb_estadioAlterno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estadioAlterno.FormattingEnabled = true;
            this.cmb_estadioAlterno.Items.AddRange(new object[] {
            "(Seleccionar un estadio...)"});
            this.cmb_estadioAlterno.Location = new System.Drawing.Point(358, 127);
            this.cmb_estadioAlterno.Name = "cmb_estadioAlterno";
            this.cmb_estadioAlterno.Size = new System.Drawing.Size(145, 21);
            this.cmb_estadioAlterno.TabIndex = 12;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(347, 186);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 13;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_GuardarEquipo);
            // 
            // brn_cancelar
            // 
            this.brn_cancelar.Location = new System.Drawing.Point(428, 186);
            this.brn_cancelar.Name = "brn_cancelar";
            this.brn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.brn_cancelar.TabIndex = 14;
            this.brn_cancelar.Text = "Cancelar";
            this.brn_cancelar.UseVisualStyleBackColor = true;
            this.brn_cancelar.Click += new System.EventHandler(this.brn_Cancelar);
            // 
            // frmEquipoInsertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 232);
            this.Controls.Add(this.brn_cancelar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cmb_estadioAlterno);
            this.Controls.Add(this.cmb_estadioPrincipal);
            this.Controls.Add(this.cmb_anio);
            this.Controls.Add(this.cmb_pais);
            this.Controls.Add(this.txt_ciudad);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lbl_ciudad);
            this.Controls.Add(this.lbl_EstadioAlterno);
            this.Controls.Add(this.lbl_estadioPrincipal);
            this.Controls.Add(this.lbl_anio);
            this.Controls.Add(this.lbl_pais);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "frmEquipoInsertar";
            this.Text = "Equipo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_equipo;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_anio;
        private System.Windows.Forms.Label lbl_estadioPrincipal;
        private System.Windows.Forms.Label lbl_EstadioAlterno;
        private System.Windows.Forms.Label lbl_ciudad;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_ciudad;
        private System.Windows.Forms.ComboBox cmb_pais;
        private System.Windows.Forms.ComboBox cmb_anio;
        private System.Windows.Forms.ComboBox cmb_estadioPrincipal;
        private System.Windows.Forms.ComboBox cmb_estadioAlterno;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button brn_cancelar;
    }
}