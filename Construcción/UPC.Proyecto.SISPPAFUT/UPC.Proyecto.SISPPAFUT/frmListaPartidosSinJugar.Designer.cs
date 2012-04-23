namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmListaPartidosSinJugar
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_editar_partido = new System.Windows.Forms.Button();
            this.btn_editar_datos_partido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 354);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_editar_partido
            // 
            this.btn_editar_partido.Location = new System.Drawing.Point(346, 402);
            this.btn_editar_partido.Name = "btn_editar_partido";
            this.btn_editar_partido.Size = new System.Drawing.Size(113, 23);
            this.btn_editar_partido.TabIndex = 1;
            this.btn_editar_partido.Text = "Editar Partido";
            this.btn_editar_partido.UseVisualStyleBackColor = true;
            this.btn_editar_partido.Click += new System.EventHandler(this.btn_editar_partido_Click);
            // 
            // btn_editar_datos_partido
            // 
            this.btn_editar_datos_partido.Location = new System.Drawing.Point(465, 402);
            this.btn_editar_datos_partido.Name = "btn_editar_datos_partido";
            this.btn_editar_datos_partido.Size = new System.Drawing.Size(168, 23);
            this.btn_editar_datos_partido.TabIndex = 2;
            this.btn_editar_datos_partido.Text = "Editar Datos del Partido";
            this.btn_editar_datos_partido.UseVisualStyleBackColor = true;
            // 
            // frmListaPartidosSinJugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 441);
            this.Controls.Add(this.btn_editar_datos_partido);
            this.Controls.Add(this.btn_editar_partido);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmListaPartidosSinJugar";
            this.Text = "Lista de Partidos sin Jugar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_editar_partido;
        private System.Windows.Forms.Button btn_editar_datos_partido;
    }
}