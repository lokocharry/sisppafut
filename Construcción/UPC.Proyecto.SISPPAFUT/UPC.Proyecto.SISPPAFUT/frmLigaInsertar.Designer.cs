namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmLigaInsertar
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
            frmLiga = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLigaInsertar));
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_competicion = new System.Windows.Forms.Label();
            this.lbl_temporada = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.txt_temporada = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.chb_editar = new System.Windows.Forms.CheckBox();
            this.cmb_competicion = new System.Windows.Forms.ComboBox();
            this.cmb_pais = new System.Windows.Forms.ComboBox();
            this.cmb_equipo = new System.Windows.Forms.ComboBox();
            this.btn_agregarEquipo = new System.Windows.Forms.Button();
            this.dg_equipos = new System.Windows.Forms.DataGridView();
            this.bnt_guardar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_equipos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(227, 20);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(155, 24);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Registro de Ligas";
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Location = new System.Drawing.Point(23, 62);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(27, 13);
            this.lbl_pais.TabIndex = 1;
            this.lbl_pais.Text = "Pais";
            // 
            // lbl_competicion
            // 
            this.lbl_competicion.AutoSize = true;
            this.lbl_competicion.Location = new System.Drawing.Point(23, 96);
            this.lbl_competicion.Name = "lbl_competicion";
            this.lbl_competicion.Size = new System.Drawing.Size(65, 13);
            this.lbl_competicion.TabIndex = 2;
            this.lbl_competicion.Text = "Competicion";
            // 
            // lbl_temporada
            // 
            this.lbl_temporada.AutoSize = true;
            this.lbl_temporada.Location = new System.Drawing.Point(305, 96);
            this.lbl_temporada.Name = "lbl_temporada";
            this.lbl_temporada.Size = new System.Drawing.Size(61, 13);
            this.lbl_temporada.TabIndex = 3;
            this.lbl_temporada.Text = "Temporada";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(23, 134);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 4;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Location = new System.Drawing.Point(23, 168);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(105, 13);
            this.lbl_cantidad.TabIndex = 5;
            this.lbl_cantidad.Text = "Cantidad de Equipos";
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Location = new System.Drawing.Point(23, 202);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(40, 13);
            this.lbl_equipo.TabIndex = 6;
            this.lbl_equipo.Text = "Equipo";
            // 
            // txt_temporada
            // 
            this.txt_temporada.Location = new System.Drawing.Point(372, 92);
            this.txt_temporada.MaxLength = 10;
            this.txt_temporada.Name = "txt_temporada";
            this.txt_temporada.Size = new System.Drawing.Size(186, 20);
            this.txt_temporada.TabIndex = 7;
            this.txt_temporada.TextChanged += new System.EventHandler(this.inTemporada);
            this.txt_temporada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarTemporada);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(134, 131);
            this.txt_nombre.MaxLength = 30;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(346, 20);
            this.txt_nombre.TabIndex = 8;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(134, 165);
            this.txt_cantidad.MaxLength = 3;
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(54, 20);
            this.txt_cantidad.TabIndex = 9;
            this.txt_cantidad.TextChanged += new System.EventHandler(this.txt_cantidad_TextChanged);
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNumerica);
            // 
            // chb_editar
            // 
            this.chb_editar.AutoSize = true;
            this.chb_editar.Location = new System.Drawing.Point(505, 133);
            this.chb_editar.Name = "chb_editar";
            this.chb_editar.Size = new System.Drawing.Size(53, 17);
            this.chb_editar.TabIndex = 10;
            this.chb_editar.Text = "Editar";
            this.chb_editar.UseVisualStyleBackColor = true;
            this.chb_editar.CheckedChanged += new System.EventHandler(this.inEditarNombreLiga);
            // 
            // cmb_competicion
            // 
            this.cmb_competicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_competicion.FormattingEnabled = true;
            this.cmb_competicion.Location = new System.Drawing.Point(134, 92);
            this.cmb_competicion.Name = "cmb_competicion";
            this.cmb_competicion.Size = new System.Drawing.Size(165, 21);
            this.cmb_competicion.TabIndex = 11;
            this.cmb_competicion.SelectionChangeCommitted += new System.EventHandler(this.inCambiarSeleccionCompeticion);
            // 
            // cmb_pais
            // 
            this.cmb_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pais.FormattingEnabled = true;
            this.cmb_pais.Location = new System.Drawing.Point(134, 59);
            this.cmb_pais.Name = "cmb_pais";
            this.cmb_pais.Size = new System.Drawing.Size(165, 21);
            this.cmb_pais.TabIndex = 12;
            this.cmb_pais.SelectionChangeCommitted += new System.EventHandler(this.inCambiarSeleccionPais);
            this.cmb_pais.SelectedValueChanged += new System.EventHandler(this.inPaisSeleccionado);
            // 
            // cmb_equipo
            // 
            this.cmb_equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipo.FormattingEnabled = true;
            this.cmb_equipo.Location = new System.Drawing.Point(134, 199);
            this.cmb_equipo.Name = "cmb_equipo";
            this.cmb_equipo.Size = new System.Drawing.Size(137, 21);
            this.cmb_equipo.TabIndex = 13;
            // 
            // btn_agregarEquipo
            // 
            this.btn_agregarEquipo.Location = new System.Drawing.Point(277, 197);
            this.btn_agregarEquipo.Name = "btn_agregarEquipo";
            this.btn_agregarEquipo.Size = new System.Drawing.Size(105, 23);
            this.btn_agregarEquipo.TabIndex = 14;
            this.btn_agregarEquipo.Text = "Agregar a la lista";
            this.btn_agregarEquipo.UseVisualStyleBackColor = true;
            this.btn_agregarEquipo.Click += new System.EventHandler(this.inAgregarEquipoaLista);
            // 
            // dg_equipos
            // 
            this.dg_equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_equipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Equipo,
            this.Ciudad,
            this.Eliminar});
            this.dg_equipos.Location = new System.Drawing.Point(26, 226);
            this.dg_equipos.Name = "dg_equipos";
            this.dg_equipos.Size = new System.Drawing.Size(532, 150);
            this.dg_equipos.TabIndex = 15;
            this.dg_equipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_equipos_CellContentClick);
            // 
            // bnt_guardar
            // 
            this.bnt_guardar.Location = new System.Drawing.Point(483, 392);
            this.bnt_guardar.Name = "bnt_guardar";
            this.bnt_guardar.Size = new System.Drawing.Size(75, 23);
            this.bnt_guardar.TabIndex = 16;
            this.bnt_guardar.Text = "Guardar";
            this.bnt_guardar.UseVisualStyleBackColor = true;
            this.bnt_guardar.Click += new System.EventHandler(this.btnGuardarLiga);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(402, 392);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 17;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btnCancelar);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Equipo
            // 
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.Name = "Equipo";
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmLigaInsertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 427);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.bnt_guardar);
            this.Controls.Add(this.dg_equipos);
            this.Controls.Add(this.btn_agregarEquipo);
            this.Controls.Add(this.cmb_equipo);
            this.Controls.Add(this.cmb_pais);
            this.Controls.Add(this.cmb_competicion);
            this.Controls.Add(this.chb_editar);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.txt_temporada);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.lbl_cantidad);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.lbl_temporada);
            this.Controls.Add(this.lbl_competicion);
            this.Controls.Add(this.lbl_pais);
            this.Controls.Add(this.lbl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLigaInsertar";
            this.Text = "Liga";
            ((System.ComponentModel.ISupportInitialize)(this.dg_equipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_competicion;
        private System.Windows.Forms.Label lbl_temporada;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_cantidad;
        private System.Windows.Forms.Label lbl_equipo;
        private System.Windows.Forms.TextBox txt_temporada;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.CheckBox chb_editar;
        private System.Windows.Forms.ComboBox cmb_competicion;
        private System.Windows.Forms.ComboBox cmb_pais;
        private System.Windows.Forms.ComboBox cmb_equipo;
        private System.Windows.Forms.Button btn_agregarEquipo;
        private System.Windows.Forms.DataGridView dg_equipos;
        private System.Windows.Forms.Button bnt_guardar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}