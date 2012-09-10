namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmTablaPosiciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PJG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PJL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PJV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "País";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(49, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Competición";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Liga";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(287, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(294, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(658, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(166, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pos,
            this.Equipo,
            this.Pts,
            this.PJG,
            this.GG,
            this.EG,
            this.PG,
            this.GAG,
            this.GEG,
            this.PJL,
            this.GL,
            this.EL,
            this.PL,
            this.GAL,
            this.GEL,
            this.PJV,
            this.GV,
            this.EV,
            this.PV,
            this.GAV,
            this.GEV});
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(815, 352);
            this.dataGridView1.TabIndex = 4;
            // 
            // Pos
            // 
            this.Pos.HeaderText = "Pos";
            this.Pos.Name = "Pos";
            this.Pos.ReadOnly = true;
            this.Pos.Width = 40;
            // 
            // Equipo
            // 
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.Name = "Equipo";
            this.Equipo.ReadOnly = true;
            this.Equipo.Width = 150;
            // 
            // Pts
            // 
            this.Pts.HeaderText = "Pts";
            this.Pts.Name = "Pts";
            this.Pts.ReadOnly = true;
            this.Pts.Width = 40;
            // 
            // PJG
            // 
            this.PJG.HeaderText = "PJ";
            this.PJG.Name = "PJG";
            this.PJG.ReadOnly = true;
            this.PJG.Width = 30;
            // 
            // GG
            // 
            this.GG.HeaderText = "G";
            this.GG.Name = "GG";
            this.GG.ReadOnly = true;
            this.GG.Width = 30;
            // 
            // EG
            // 
            this.EG.HeaderText = "E";
            this.EG.Name = "EG";
            this.EG.ReadOnly = true;
            this.EG.Width = 30;
            // 
            // PG
            // 
            this.PG.HeaderText = "P";
            this.PG.Name = "PG";
            this.PG.ReadOnly = true;
            this.PG.Width = 30;
            // 
            // GAG
            // 
            this.GAG.HeaderText = "GA";
            this.GAG.Name = "GAG";
            this.GAG.ReadOnly = true;
            this.GAG.Width = 30;
            // 
            // GEG
            // 
            this.GEG.HeaderText = "GE";
            this.GEG.Name = "GEG";
            this.GEG.ReadOnly = true;
            this.GEG.Width = 30;
            // 
            // PJL
            // 
            this.PJL.HeaderText = "PJ";
            this.PJL.Name = "PJL";
            this.PJL.ReadOnly = true;
            this.PJL.Width = 30;
            // 
            // GL
            // 
            this.GL.HeaderText = "G";
            this.GL.Name = "GL";
            this.GL.ReadOnly = true;
            this.GL.Width = 30;
            // 
            // EL
            // 
            this.EL.HeaderText = "E";
            this.EL.Name = "EL";
            this.EL.ReadOnly = true;
            this.EL.Width = 30;
            // 
            // PL
            // 
            this.PL.HeaderText = "P";
            this.PL.Name = "PL";
            this.PL.ReadOnly = true;
            this.PL.Width = 30;
            // 
            // GAL
            // 
            this.GAL.HeaderText = "GA";
            this.GAL.Name = "GAL";
            this.GAL.ReadOnly = true;
            this.GAL.Width = 30;
            // 
            // GEL
            // 
            this.GEL.HeaderText = "GE";
            this.GEL.Name = "GEL";
            this.GEL.ReadOnly = true;
            this.GEL.Width = 30;
            // 
            // PJV
            // 
            this.PJV.HeaderText = "PJ";
            this.PJV.Name = "PJV";
            this.PJV.ReadOnly = true;
            this.PJV.Width = 30;
            // 
            // GV
            // 
            this.GV.HeaderText = "G";
            this.GV.Name = "GV";
            this.GV.ReadOnly = true;
            this.GV.Width = 30;
            // 
            // EV
            // 
            this.EV.HeaderText = "E";
            this.EV.Name = "EV";
            this.EV.ReadOnly = true;
            this.EV.Width = 30;
            // 
            // PV
            // 
            this.PV.HeaderText = "P";
            this.PV.Name = "PV";
            this.PV.ReadOnly = true;
            this.PV.Width = 30;
            // 
            // GAV
            // 
            this.GAV.HeaderText = "GA";
            this.GAV.Name = "GAV";
            this.GAV.ReadOnly = true;
            this.GAV.Width = 30;
            // 
            // GEV
            // 
            this.GEV.HeaderText = "GE";
            this.GEV.Name = "GEV";
            this.GEV.ReadOnly = true;
            this.GEV.Width = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(543, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "|-------------------- GENERAL -------------------|----------------------- LOCAL -" +
                "---------------------|-------------------- VISITANTE -------------------|";
            // 
            // frmTablaPosiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTablaPosiciones";
            this.ShowIcon = false;
            this.Text = "Tabla de Posiciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PJG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GG;
        private System.Windows.Forms.DataGridViewTextBoxColumn EG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GEG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PJL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PJV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GV;
        private System.Windows.Forms.DataGridViewTextBoxColumn EV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GEV;
        private System.Windows.Forms.Label label4;
    }
}