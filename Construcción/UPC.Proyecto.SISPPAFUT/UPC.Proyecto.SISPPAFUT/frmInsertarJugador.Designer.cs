namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmInsertarJugador
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
            frmJugador = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.lbl_nacionalidad = new System.Windows.Forms.Label();
            this.lbl_nacimiento = new System.Windows.Forms.Label();
            this.lbl_altura = new System.Windows.Forms.Label();
            this.lbl_peso = new System.Windows.Forms.Label();
            this.lbl_posicion = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nacionalidad = new System.Windows.Forms.TextBox();
            this.txt_altura = new System.Windows.Forms.TextBox();
            this.txt_peso = new System.Windows.Forms.TextBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.cmb_posicion = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(34, 28);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(50, 13);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Nombre :";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(34, 58);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(50, 13);
            this.lbl_apellido.TabIndex = 1;
            this.lbl_apellido.Text = "Apellido :";
            // 
            // lbl_nacionalidad
            // 
            this.lbl_nacionalidad.AutoSize = true;
            this.lbl_nacionalidad.Location = new System.Drawing.Point(34, 89);
            this.lbl_nacionalidad.Name = "lbl_nacionalidad";
            this.lbl_nacionalidad.Size = new System.Drawing.Size(75, 13);
            this.lbl_nacionalidad.TabIndex = 2;
            this.lbl_nacionalidad.Text = "Nacionalidad :";
            // 
            // lbl_nacimiento
            // 
            this.lbl_nacimiento.AutoSize = true;
            this.lbl_nacimiento.Location = new System.Drawing.Point(286, 89);
            this.lbl_nacimiento.Name = "lbl_nacimiento";
            this.lbl_nacimiento.Size = new System.Drawing.Size(66, 13);
            this.lbl_nacimiento.TabIndex = 3;
            this.lbl_nacimiento.Text = "Fecha Nac :";
            // 
            // lbl_altura
            // 
            this.lbl_altura.AutoSize = true;
            this.lbl_altura.Location = new System.Drawing.Point(34, 121);
            this.lbl_altura.Name = "lbl_altura";
            this.lbl_altura.Size = new System.Drawing.Size(57, 13);
            this.lbl_altura.TabIndex = 4;
            this.lbl_altura.Text = "Altura (m) :";
            // 
            // lbl_peso
            // 
            this.lbl_peso.AutoSize = true;
            this.lbl_peso.Location = new System.Drawing.Point(286, 121);
            this.lbl_peso.Name = "lbl_peso";
            this.lbl_peso.Size = new System.Drawing.Size(59, 13);
            this.lbl_peso.TabIndex = 5;
            this.lbl_peso.Text = "Peso (Kg) :";
            // 
            // lbl_posicion
            // 
            this.lbl_posicion.AutoSize = true;
            this.lbl_posicion.Location = new System.Drawing.Point(34, 154);
            this.lbl_posicion.Name = "lbl_posicion";
            this.lbl_posicion.Size = new System.Drawing.Size(53, 13);
            this.lbl_posicion.TabIndex = 6;
            this.lbl_posicion.Text = "Posicion :";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(118, 25);
            this.txt_nombre.MaxLength = 40;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(344, 20);
            this.txt_nombre.TabIndex = 9;
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNombre);
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(118, 55);
            this.txt_apellido.MaxLength = 40;
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(344, 20);
            this.txt_apellido.TabIndex = 10;
            this.txt_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNombre);
            // 
            // txt_nacionalidad
            // 
            this.txt_nacionalidad.Location = new System.Drawing.Point(118, 86);
            this.txt_nacionalidad.MaxLength = 40;
            this.txt_nacionalidad.Name = "txt_nacionalidad";
            this.txt_nacionalidad.Size = new System.Drawing.Size(153, 20);
            this.txt_nacionalidad.TabIndex = 11;
            this.txt_nacionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNombre);
            // 
            // txt_altura
            // 
            this.txt_altura.Location = new System.Drawing.Point(118, 118);
            this.txt_altura.MaxLength = 4;
            this.txt_altura.Name = "txt_altura";
            this.txt_altura.Size = new System.Drawing.Size(65, 20);
            this.txt_altura.TabIndex = 12;
            this.txt_altura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNumerico);
            // 
            // txt_peso
            // 
            this.txt_peso.Location = new System.Drawing.Point(358, 118);
            this.txt_peso.MaxLength = 6;
            this.txt_peso.Name = "txt_peso";
            this.txt_peso.Size = new System.Drawing.Size(65, 20);
            this.txt_peso.TabIndex = 13;
            this.txt_peso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntradaNumerica);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(358, 86);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(104, 20);
            this.dtp_fecha.TabIndex = 14;
            // 
            // cmb_posicion
            // 
            this.cmb_posicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_posicion.FormattingEnabled = true;
            this.cmb_posicion.Location = new System.Drawing.Point(118, 151);
            this.cmb_posicion.Name = "cmb_posicion";
            this.cmb_posicion.Size = new System.Drawing.Size(153, 21);
            this.cmb_posicion.TabIndex = 15;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(378, 187);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(84, 27);
            this.btn_guardar.TabIndex = 19;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.inGuardarJugador);
            // 
            // frmInsertarJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 233);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cmb_posicion);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.txt_peso);
            this.Controls.Add(this.txt_altura);
            this.Controls.Add(this.txt_nacionalidad);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lbl_posicion);
            this.Controls.Add(this.lbl_peso);
            this.Controls.Add(this.lbl_altura);
            this.Controls.Add(this.lbl_nacimiento);
            this.Controls.Add(this.lbl_nacionalidad);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertarJugador";
            this.Text = "Jugador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmJugadorInsertar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.Label lbl_nacionalidad;
        private System.Windows.Forms.Label lbl_nacimiento;
        private System.Windows.Forms.Label lbl_altura;
        private System.Windows.Forms.Label lbl_peso;
        private System.Windows.Forms.Label lbl_posicion;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_nacionalidad;
        private System.Windows.Forms.TextBox txt_altura;
        private System.Windows.Forms.TextBox txt_peso;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.ComboBox cmb_posicion;
        private System.Windows.Forms.Button btn_guardar;
    }
}