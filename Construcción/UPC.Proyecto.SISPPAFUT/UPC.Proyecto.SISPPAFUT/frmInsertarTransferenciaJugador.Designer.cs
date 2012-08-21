namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmInsertarTransferenciaJugador
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
            frmTransferirJugador = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTransferir = new System.Windows.Forms.Button();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.cmbJugador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEquipoTransf = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPaisTransf = new System.Windows.Forms.ComboBox();
            this.cbLiberar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(534, 144);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(131, 34);
            this.btnTransferir.TabIndex = 0;
            this.btnTransferir.Text = "Realizar Transferencia";
            this.btnTransferir.UseVisualStyleBackColor = true;
            // 
            // cmbPais
            // 
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(100, 24);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(121, 21);
            this.cmbPais.TabIndex = 1;
            this.cmbPais.SelectedIndexChanged += new System.EventHandler(this.inSeleccionPais);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "País";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Equipo";
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(100, 60);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(225, 21);
            this.cmbEquipo.TabIndex = 4;
            this.cmbEquipo.SelectedIndexChanged += new System.EventHandler(this.InSeleccionEquipo);
            // 
            // cmbJugador
            // 
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.Location = new System.Drawing.Point(100, 98);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(225, 21);
            this.cmbJugador.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jugador";
            // 
            // cmbEquipoTransf
            // 
            this.cmbEquipoTransf.FormattingEnabled = true;
            this.cmbEquipoTransf.Location = new System.Drawing.Point(440, 60);
            this.cmbEquipoTransf.Name = "cmbEquipoTransf";
            this.cmbEquipoTransf.Size = new System.Drawing.Size(225, 21);
            this.cmbEquipoTransf.TabIndex = 10;
            this.cmbEquipoTransf.SelectedIndexChanged += new System.EventHandler(this.InSeleccionEquipoTransf);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Equipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "País";
            // 
            // cmbPaisTransf
            // 
            this.cmbPaisTransf.FormattingEnabled = true;
            this.cmbPaisTransf.Location = new System.Drawing.Point(440, 24);
            this.cmbPaisTransf.Name = "cmbPaisTransf";
            this.cmbPaisTransf.Size = new System.Drawing.Size(121, 21);
            this.cmbPaisTransf.TabIndex = 7;
            this.cmbPaisTransf.SelectedIndexChanged += new System.EventHandler(this.inSeleccionPaisTransf);
            // 
            // cbLiberar
            // 
            this.cbLiberar.AutoSize = true;
            this.cbLiberar.Location = new System.Drawing.Point(372, 102);
            this.cbLiberar.Name = "cbLiberar";
            this.cbLiberar.Size = new System.Drawing.Size(129, 17);
            this.cbLiberar.TabIndex = 13;
            this.cbLiberar.Text = "No especificar equipo";
            this.cbLiberar.UseVisualStyleBackColor = true;
            this.cbLiberar.CheckedChanged += new System.EventHandler(this.inSeleccionSinEquipo);
            // 
            // frmInsertarTransferenciaJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 190);
            this.Controls.Add(this.cbLiberar);
            this.Controls.Add(this.cmbEquipoTransf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPaisTransf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbJugador);
            this.Controls.Add(this.cmbEquipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.btnTransferir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertarTransferenciaJugador";
            this.Text = "Transferencia de Jugadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.ComboBox cmbJugador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEquipoTransf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPaisTransf;
        private System.Windows.Forms.CheckBox cbLiberar;
    }
}