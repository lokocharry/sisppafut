namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmConsultaSuspensiones
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_jugador = new System.Windows.Forms.Label();
            this.cmb_jugadores = new System.Windows.Forms.ComboBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_jugador
            // 
            this.lbl_jugador.AutoSize = true;
            this.lbl_jugador.Location = new System.Drawing.Point(44, 43);
            this.lbl_jugador.Name = "lbl_jugador";
            this.lbl_jugador.Size = new System.Drawing.Size(51, 13);
            this.lbl_jugador.TabIndex = 0;
            this.lbl_jugador.Text = "Jugador :";
            // 
            // cmb_jugadores
            // 
            this.cmb_jugadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_jugadores.FormattingEnabled = true;
            this.cmb_jugadores.Location = new System.Drawing.Point(111, 40);
            this.cmb_jugadores.Name = "cmb_jugadores";
            this.cmb_jugadores.Size = new System.Drawing.Size(214, 21);
            this.cmb_jugadores.TabIndex = 1;
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(156, 83);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 2;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(250, 83);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // frmConsultaSuspensiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 144);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.cmb_jugadores);
            this.Controls.Add(this.lbl_jugador);
            this.Name = "frmConsultaSuspensiones";
            this.Text = "Consulta de Suspensiones";
            this.Load += new System.EventHandler(this.frmConsultaSuspensiones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_jugador;
        private System.Windows.Forms.ComboBox cmb_jugadores;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}