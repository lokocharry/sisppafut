namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmInsertarUsuario
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
            frmUsuario = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellidoPaterno = new System.Windows.Forms.Label();
            this.lblApeliidoMaterno = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.lblRepetirContrasenia = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.txtRepetirContrasenia = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(32, 27);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.lblIdentificacion.TabIndex = 0;
            this.lblIdentificacion.Text = "Identificacion";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(32, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Usuario";
            // 
            // lblApellidoPaterno
            // 
            this.lblApellidoPaterno.AutoSize = true;
            this.lblApellidoPaterno.Location = new System.Drawing.Point(32, 105);
            this.lblApellidoPaterno.Name = "lblApellidoPaterno";
            this.lblApellidoPaterno.Size = new System.Drawing.Size(84, 13);
            this.lblApellidoPaterno.TabIndex = 2;
            this.lblApellidoPaterno.Text = "Apellido Paterno";
            // 
            // lblApeliidoMaterno
            // 
            this.lblApeliidoMaterno.AutoSize = true;
            this.lblApeliidoMaterno.Location = new System.Drawing.Point(32, 147);
            this.lblApeliidoMaterno.Name = "lblApeliidoMaterno";
            this.lblApeliidoMaterno.Size = new System.Drawing.Size(86, 13);
            this.lblApeliidoMaterno.TabIndex = 3;
            this.lblApeliidoMaterno.Text = "Apellido Materno";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(32, 190);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(108, 13);
            this.lblFechaNac.TabIndex = 4;
            this.lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Location = new System.Drawing.Point(32, 231);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(61, 13);
            this.lblContrasenia.TabIndex = 5;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // lblRepetirContrasenia
            // 
            this.lblRepetirContrasenia.AutoSize = true;
            this.lblRepetirContrasenia.Location = new System.Drawing.Point(32, 266);
            this.lblRepetirContrasenia.Name = "lblRepetirContrasenia";
            this.lblRepetirContrasenia.Size = new System.Drawing.Size(98, 13);
            this.lblRepetirContrasenia.TabIndex = 6;
            this.lblRepetirContrasenia.Text = "Repetir Contraseña";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(160, 24);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(146, 20);
            this.txtIdentificacion.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(160, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(247, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(160, 102);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(247, 20);
            this.txtApellidoPaterno.TabIndex = 9;
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(160, 144);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(247, 20);
            this.txtApellidoMaterno.TabIndex = 10;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(160, 228);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(146, 20);
            this.txtContrasenia.TabIndex = 12;
            // 
            // txtRepetirContrasenia
            // 
            this.txtRepetirContrasenia.Location = new System.Drawing.Point(160, 263);
            this.txtRepetirContrasenia.Name = "txtRepetirContrasenia";
            this.txtRepetirContrasenia.PasswordChar = '*';
            this.txtRepetirContrasenia.Size = new System.Drawing.Size(146, 20);
            this.txtRepetirContrasenia.TabIndex = 13;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(160, 184);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(224, 305);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(332, 305);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmInsertarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 345);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.txtRepetirContrasenia);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.lblRepetirContrasenia);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblApeliidoMaterno);
            this.Controls.Add(this.lblApellidoPaterno);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblIdentificacion);
            this.Name = "frmInsertarUsuario";
            this.Text = "Usuario nuevo";
            this.Load += new System.EventHandler(this.frmInsertarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellidoPaterno;
        private System.Windows.Forms.Label lblApeliidoMaterno;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Label lblRepetirContrasenia;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.TextBox txtRepetirContrasenia;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}