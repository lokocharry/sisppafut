namespace UPC.Proyecto.SISPPAFUT
{
    partial class SISPPAFUTmdi
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            MDI = null;
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.competicionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCompeticiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ligasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaLigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoEstadioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paisesToolStripMenuItem,
            this.competicionesToolStripMenuItem,
            this.ligasToolStripMenuItem,
            this.estadiosToolStripMenuItem,
            this.equiposToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menúToolStripMenuItem.Text = "Menú";
            // 
            // paisesToolStripMenuItem
            // 
            this.paisesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem});
            this.paisesToolStripMenuItem.Name = "paisesToolStripMenuItem";
            this.paisesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.paisesToolStripMenuItem.Text = "Paises";
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.registrarToolStripMenuItem.Text = "Nuevo País";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.inNuevoPais);
            // 
            // competicionesToolStripMenuItem
            // 
            this.competicionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCompeticiónToolStripMenuItem});
            this.competicionesToolStripMenuItem.Name = "competicionesToolStripMenuItem";
            this.competicionesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.competicionesToolStripMenuItem.Text = "Competiciones";
            // 
            // nuevaCompeticiónToolStripMenuItem
            // 
            this.nuevaCompeticiónToolStripMenuItem.Name = "nuevaCompeticiónToolStripMenuItem";
            this.nuevaCompeticiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevaCompeticiónToolStripMenuItem.Text = "Nueva Competición";
            this.nuevaCompeticiónToolStripMenuItem.Click += new System.EventHandler(this.inNuevaCompeticion);
            // 
            // ligasToolStripMenuItem
            // 
            this.ligasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaLigaToolStripMenuItem});
            this.ligasToolStripMenuItem.Name = "ligasToolStripMenuItem";
            this.ligasToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ligasToolStripMenuItem.Text = "Ligas";
            // 
            // nuevaLigaToolStripMenuItem
            // 
            this.nuevaLigaToolStripMenuItem.Name = "nuevaLigaToolStripMenuItem";
            this.nuevaLigaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevaLigaToolStripMenuItem.Text = "Nueva Liga";
            this.nuevaLigaToolStripMenuItem.Click += new System.EventHandler(this.inNuevaLiga);
            // 
            // estadiosToolStripMenuItem
            // 
            this.estadiosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoEstadioToolStripMenuItem});
            this.estadiosToolStripMenuItem.Name = "estadiosToolStripMenuItem";
            this.estadiosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.estadiosToolStripMenuItem.Text = "Estadios";
            // 
            // nuevoEstadioToolStripMenuItem
            // 
            this.nuevoEstadioToolStripMenuItem.Name = "nuevoEstadioToolStripMenuItem";
            this.nuevoEstadioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoEstadioToolStripMenuItem.Text = "Nuevo Estadio";
            this.nuevoEstadioToolStripMenuItem.Click += new System.EventHandler(this.inNuevoEstadio);
            // 
            // equiposToolStripMenuItem
            // 
            this.equiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoEquipoToolStripMenuItem});
            this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
            this.equiposToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.equiposToolStripMenuItem.Text = "Equipos";
            // 
            // nuevoEquipoToolStripMenuItem
            // 
            this.nuevoEquipoToolStripMenuItem.Name = "nuevoEquipoToolStripMenuItem";
            this.nuevoEquipoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoEquipoToolStripMenuItem.Text = "Nuevo Equipo";
            this.nuevoEquipoToolStripMenuItem.Click += new System.EventHandler(this.InNuevoEquipo);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.InSalir);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 483);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Inteligente para Pronóstico de Partidos de Fútbol";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competicionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCompeticiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ligasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaLigaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoEstadioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoEquipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

