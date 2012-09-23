namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmInsertarEstadio
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
            frmEstadio = null;
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
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_ciudad = new System.Windows.Forms.TextBox();
            this.txt_aforo = new System.Windows.Forms.TextBox();
            this.cmb_pais = new System.Windows.Forms.ComboBox();
            this.cmb_anho = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pais :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año Fundacion :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Aforo :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ciudad :";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(84, 45);
            this.txt_nombre.MaxLength = 40;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(367, 20);
            this.txt_nombre.TabIndex = 5;
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNombre);
            // 
            // txt_ciudad
            // 
            this.txt_ciudad.Location = new System.Drawing.Point(84, 103);
            this.txt_ciudad.MaxLength = 40;
            this.txt_ciudad.Name = "txt_ciudad";
            this.txt_ciudad.Size = new System.Drawing.Size(100, 20);
            this.txt_ciudad.TabIndex = 6;
            this.txt_ciudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoCiudad);
            // 
            // txt_aforo
            // 
            this.txt_aforo.Location = new System.Drawing.Point(333, 103);
            this.txt_aforo.MaxLength = 6;
            this.txt_aforo.Name = "txt_aforo";
            this.txt_aforo.Size = new System.Drawing.Size(60, 20);
            this.txt_aforo.TabIndex = 7;
            this.txt_aforo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoAforo);
            // 
            // cmb_pais
            // 
            this.cmb_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pais.FormattingEnabled = true;
            this.cmb_pais.Items.AddRange(new object[] {
            "(Seleccione un país)"});
            this.cmb_pais.Location = new System.Drawing.Point(84, 75);
            this.cmb_pais.Name = "cmb_pais";
            this.cmb_pais.Size = new System.Drawing.Size(152, 21);
            this.cmb_pais.TabIndex = 8;
            // 
            // cmb_anho
            // 
            this.cmb_anho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_anho.FormattingEnabled = true;
            this.cmb_anho.Items.AddRange(new object[] {
            "(Seleccione un año...)"});
            this.cmb_anho.Location = new System.Drawing.Point(333, 75);
            this.cmb_anho.Name = "cmb_anho";
            this.cmb_anho.Size = new System.Drawing.Size(118, 21);
            this.cmb_anho.TabIndex = 9;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(376, 152);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 11;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_GuardarEstadio);
            // 
            // frmInsertarEstadio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 197);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cmb_anho);
            this.Controls.Add(this.cmb_pais);
            this.Controls.Add(this.txt_aforo);
            this.Controls.Add(this.txt_ciudad);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertarEstadio";
            this.Text = "Estadio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_ciudad;
        private System.Windows.Forms.TextBox txt_aforo;
        private System.Windows.Forms.ComboBox cmb_pais;
        private System.Windows.Forms.ComboBox cmb_anho;
        private System.Windows.Forms.Button btn_guardar;
    }
}