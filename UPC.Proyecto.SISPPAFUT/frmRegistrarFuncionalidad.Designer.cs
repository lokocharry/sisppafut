namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmRegistrarFuncionalidad
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
            frmFuncionalidad = null;
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
            this.txtNombreFuncionalidad = new System.Windows.Forms.TextBox();
            this.txtDescripcionFuncionalidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Funcionalidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // txtNombreFuncionalidad
            // 
            this.txtNombreFuncionalidad.Location = new System.Drawing.Point(157, 29);
            this.txtNombreFuncionalidad.MaxLength = 50;
            this.txtNombreFuncionalidad.Name = "txtNombreFuncionalidad";
            this.txtNombreFuncionalidad.Size = new System.Drawing.Size(236, 20);
            this.txtNombreFuncionalidad.TabIndex = 1;
            this.txtNombreFuncionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTexto);
            // 
            // txtDescripcionFuncionalidad
            // 
            this.txtDescripcionFuncionalidad.Location = new System.Drawing.Point(157, 64);
            this.txtDescripcionFuncionalidad.MaxLength = 200;
            this.txtDescripcionFuncionalidad.Multiline = true;
            this.txtDescripcionFuncionalidad.Name = "txtDescripcionFuncionalidad";
            this.txtDescripcionFuncionalidad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionFuncionalidad.Size = new System.Drawing.Size(236, 99);
            this.txtDescripcionFuncionalidad.TabIndex = 2;
            this.txtDescripcionFuncionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inControlarTexto);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRegistrarFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 217);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescripcionFuncionalidad);
            this.Controls.Add(this.txtNombreFuncionalidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarFuncionalidad";
            this.ShowIcon = false;
            this.Text = "Registro de Funcionalidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreFuncionalidad;
        private System.Windows.Forms.TextBox txtDescripcionFuncionalidad;
        private System.Windows.Forms.Button button1;
    }
}