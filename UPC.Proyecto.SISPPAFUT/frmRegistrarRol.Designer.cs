namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmRegistrarRol
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
            frmRol = null;
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.txtClaveRol = new System.Windows.Forms.TextBox();
            this.txtConfirmaClave = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Confirme clave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Descripción";
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(134, 30);
            this.txtNombreRol.MaxLength = 30;
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(188, 20);
            this.txtNombreRol.TabIndex = 1;
            this.txtNombreRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTexto);
            // 
            // txtClaveRol
            // 
            this.txtClaveRol.Location = new System.Drawing.Point(134, 56);
            this.txtClaveRol.MaxLength = 15;
            this.txtClaveRol.Name = "txtClaveRol";
            this.txtClaveRol.PasswordChar = '*';
            this.txtClaveRol.Size = new System.Drawing.Size(188, 20);
            this.txtClaveRol.TabIndex = 2;
            this.txtClaveRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTextoNumerico);
            // 
            // txtConfirmaClave
            // 
            this.txtConfirmaClave.Location = new System.Drawing.Point(134, 82);
            this.txtConfirmaClave.MaxLength = 15;
            this.txtConfirmaClave.Name = "txtConfirmaClave";
            this.txtConfirmaClave.PasswordChar = '*';
            this.txtConfirmaClave.Size = new System.Drawing.Size(188, 20);
            this.txtConfirmaClave.TabIndex = 3;
            this.txtConfirmaClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTextoNumerico);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(134, 108);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(280, 84);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTexto);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.inRegistrarRol);
            // 
            // frmRegistrarRol
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 249);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtConfirmaClave);
            this.Controls.Add(this.txtClaveRol);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarRol";
            this.ShowIcon = false;
            this.Text = "Registro de Roles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.TextBox txtClaveRol;
        private System.Windows.Forms.TextBox txtConfirmaClave;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button button1;
    }
}