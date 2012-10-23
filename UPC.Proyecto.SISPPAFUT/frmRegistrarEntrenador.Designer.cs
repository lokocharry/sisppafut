namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmRegistrarEntrenador
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
            frm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.cmbFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nacionalidad";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(117, 30);
            this.txtNombres.MaxLength = 20;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(338, 20);
            this.txtNombres.TabIndex = 3;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inValidarTexto);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(117, 61);
            this.txtApellidos.MaxLength = 20;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(338, 20);
            this.txtApellidos.TabIndex = 4;
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inValidarTexto);
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Location = new System.Drawing.Point(117, 92);
            this.txtNacionalidad.MaxLength = 20;
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(165, 20);
            this.txtNacionalidad.TabIndex = 5;
            this.txtNacionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inValidarTexto);
            // 
            // cmbFecha
            // 
            this.cmbFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmbFecha.Location = new System.Drawing.Point(357, 92);
            this.cmbFecha.MinDate = new System.DateTime(1881, 1, 1, 0, 0, 0, 0);
            this.cmbFecha.Name = "cmbFecha";
            this.cmbFecha.Size = new System.Drawing.Size(98, 20);
            this.cmbFecha.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha Nac.";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(380, 128);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 32);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmRegistrarEntrenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 181);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbFecha);
            this.Controls.Add(this.txtNacionalidad);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarEntrenador";
            this.ShowIcon = false;
            this.Text = "Entrenador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.frmRegistrarEntrenador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.DateTimePicker cmbFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
    }
}