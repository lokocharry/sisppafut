namespace UPC.Proyecto.SISPPAFUT
{
    partial class frmEditarDatosPartido
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
            frmEditarDPartido = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_equipos = new System.Windows.Forms.GroupBox();
            this.dgv_equipo_visitante = new System.Windows.Forms.DataGridView();
            this.col_cod_jugador_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nombre_jugador_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_apellidos_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nacionalidad_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fecha_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_posicion_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_altura_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_peso_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_titular_v = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_suplente_v = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv_equipo_local = new System.Windows.Forms.DataGridView();
            this.col_cod_jugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_posicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_titular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_suplente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_terminar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_equipo_visitante = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_equipo_local = new System.Windows.Forms.Label();
            this.btn_goles_agregar = new System.Windows.Forms.Button();
            this.dgv_goles = new System.Windows.Forms.DataGridView();
            this.col_jugador_goles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_equipo_goles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_minuto_goles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_eliminar_goles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmb_goles_actualizar = new System.Windows.Forms.Button();
            this.cmb_goles_equipos = new System.Windows.Forms.ComboBox();
            this.cmb_goles_jugadores = new System.Windows.Forms.ComboBox();
            this.cmb_goles_minuto = new System.Windows.Forms.ComboBox();
            this.cmb_lesiones_descanzo = new System.Windows.Forms.ComboBox();
            this.cmb_lesiones_jugadores = new System.Windows.Forms.ComboBox();
            this.cmb_lesiones_tipo = new System.Windows.Forms.ComboBox();
            this.cmb_lesiones_equipos = new System.Windows.Forms.ComboBox();
            this.btn_lesiones_actualizar = new System.Windows.Forms.Button();
            this.dgv_lesiones = new System.Windows.Forms.DataGridView();
            this.col_jugador_lesiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_equipo_lesiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_minuto_lesiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_eliminar_lesiones = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_lesiones_agregar = new System.Windows.Forms.Button();
            this.btn_guardar_datos = new System.Windows.Forms.Button();
            this.GrupoIncidencias = new System.Windows.Forms.TabControl();
            this.Amonestaciones = new System.Windows.Forms.TabPage();
            this.btn_amonestaciones_actualizar = new System.Windows.Forms.Button();
            this.cmb_amonestaciones_minuto = new System.Windows.Forms.ComboBox();
            this.dgv_amonestaciones = new System.Windows.Forms.DataGridView();
            this.col_jugador_amonestacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_equipo_amonestacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tipo_amonestacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_minuto_amonestacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_eliminar_amonestacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmb_amonestaciones_equipo = new System.Windows.Forms.ComboBox();
            this.btn_amonestaciones_agregar = new System.Windows.Forms.Button();
            this.cmb_amonestaciones_jugador = new System.Windows.Forms.ComboBox();
            this.cmb_amonestaciones_amonestacion = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_equipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equipo_visitante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equipo_local)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_goles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lesiones)).BeginInit();
            this.GrupoIncidencias.SuspendLayout();
            this.Amonestaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_amonestaciones)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_equipos
            // 
            this.gb_equipos.Controls.Add(this.dgv_equipo_visitante);
            this.gb_equipos.Controls.Add(this.dgv_equipo_local);
            this.gb_equipos.Controls.Add(this.btn_editar);
            this.gb_equipos.Controls.Add(this.btn_terminar);
            this.gb_equipos.Controls.Add(this.panel2);
            this.gb_equipos.Controls.Add(this.panel1);
            this.gb_equipos.Location = new System.Drawing.Point(12, 12);
            this.gb_equipos.Name = "gb_equipos";
            this.gb_equipos.Size = new System.Drawing.Size(649, 628);
            this.gb_equipos.TabIndex = 0;
            this.gb_equipos.TabStop = false;
            this.gb_equipos.Text = "Equipos";
            // 
            // dgv_equipo_visitante
            // 
            this.dgv_equipo_visitante.AllowUserToAddRows = false;
            this.dgv_equipo_visitante.AllowUserToDeleteRows = false;
            this.dgv_equipo_visitante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_cod_jugador_v,
            this.col_nombre_jugador_v,
            this.col_apellidos_v,
            this.col_nacionalidad_v,
            this.col_fecha_v,
            this.col_posicion_v,
            this.col_altura_v,
            this.col_peso_v,
            this.col_titular_v,
            this.col_suplente_v});
            this.dgv_equipo_visitante.Location = new System.Drawing.Point(324, 51);
            this.dgv_equipo_visitante.Name = "dgv_equipo_visitante";
            this.dgv_equipo_visitante.RowHeadersVisible = false;
            this.dgv_equipo_visitante.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_equipo_visitante.Size = new System.Drawing.Size(307, 534);
            this.dgv_equipo_visitante.TabIndex = 5;
            this.dgv_equipo_visitante.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_equip_visitante_CellContentClick);
            // 
            // col_cod_jugador_v
            // 
            this.col_cod_jugador_v.DataPropertyName = "CodJugador";
            this.col_cod_jugador_v.HeaderText = "Codigo";
            this.col_cod_jugador_v.Name = "col_cod_jugador_v";
            this.col_cod_jugador_v.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cod_jugador_v.Visible = false;
            // 
            // col_nombre_jugador_v
            // 
            this.col_nombre_jugador_v.DataPropertyName = "Nombres";
            this.col_nombre_jugador_v.HeaderText = "Nombre";
            this.col_nombre_jugador_v.Name = "col_nombre_jugador_v";
            this.col_nombre_jugador_v.ReadOnly = true;
            // 
            // col_apellidos_v
            // 
            this.col_apellidos_v.DataPropertyName = "Apellidos";
            this.col_apellidos_v.HeaderText = "Apellidos";
            this.col_apellidos_v.Name = "col_apellidos_v";
            // 
            // col_nacionalidad_v
            // 
            this.col_nacionalidad_v.DataPropertyName = "Nacionalidad";
            this.col_nacionalidad_v.HeaderText = "Nacionalidad";
            this.col_nacionalidad_v.Name = "col_nacionalidad_v";
            this.col_nacionalidad_v.Visible = false;
            // 
            // col_fecha_v
            // 
            this.col_fecha_v.DataPropertyName = "FechaNacimiento";
            this.col_fecha_v.HeaderText = "Fecha";
            this.col_fecha_v.Name = "col_fecha_v";
            this.col_fecha_v.Visible = false;
            // 
            // col_posicion_v
            // 
            this.col_posicion_v.DataPropertyName = "Posicion";
            this.col_posicion_v.HeaderText = "Posición";
            this.col_posicion_v.Name = "col_posicion_v";
            this.col_posicion_v.ReadOnly = true;
            this.col_posicion_v.Visible = false;
            this.col_posicion_v.Width = 65;
            // 
            // col_altura_v
            // 
            this.col_altura_v.DataPropertyName = "Altura";
            this.col_altura_v.HeaderText = "Altura";
            this.col_altura_v.Name = "col_altura_v";
            this.col_altura_v.Visible = false;
            // 
            // col_peso_v
            // 
            this.col_peso_v.DataPropertyName = "Peso";
            this.col_peso_v.HeaderText = "Peso";
            this.col_peso_v.Name = "col_peso_v";
            this.col_peso_v.Visible = false;
            // 
            // col_titular_v
            // 
            this.col_titular_v.HeaderText = "Titular";
            this.col_titular_v.Name = "col_titular_v";
            this.col_titular_v.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_titular_v.Width = 50;
            // 
            // col_suplente_v
            // 
            this.col_suplente_v.HeaderText = "Suplente";
            this.col_suplente_v.Name = "col_suplente_v";
            this.col_suplente_v.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_suplente_v.Width = 52;
            // 
            // dgv_equipo_local
            // 
            this.dgv_equipo_local.AllowUserToAddRows = false;
            this.dgv_equipo_local.AllowUserToDeleteRows = false;
            this.dgv_equipo_local.AllowUserToResizeColumns = false;
            this.dgv_equipo_local.AllowUserToResizeRows = false;
            this.dgv_equipo_local.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_cod_jugador,
            this.col_nombre,
            this.col_apellidos,
            this.col_nacionalidad,
            this.col_Fecha,
            this.col_posicion,
            this.col_altura,
            this.col_peso,
            this.col_titular,
            this.col_suplente});
            this.dgv_equipo_local.Location = new System.Drawing.Point(16, 51);
            this.dgv_equipo_local.Name = "dgv_equipo_local";
            this.dgv_equipo_local.RowHeadersVisible = false;
            this.dgv_equipo_local.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_equipo_local.Size = new System.Drawing.Size(302, 534);
            this.dgv_equipo_local.TabIndex = 4;
            this.dgv_equipo_local.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_equipo_local_CellContentClick);
            // 
            // col_cod_jugador
            // 
            this.col_cod_jugador.DataPropertyName = "CodJugador";
            this.col_cod_jugador.HeaderText = "Codigo";
            this.col_cod_jugador.Name = "col_cod_jugador";
            this.col_cod_jugador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cod_jugador.Visible = false;
            // 
            // col_nombre
            // 
            this.col_nombre.DataPropertyName = "Nombres";
            this.col_nombre.HeaderText = "Nombre";
            this.col_nombre.Name = "col_nombre";
            this.col_nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_apellidos
            // 
            this.col_apellidos.DataPropertyName = "Apellidos";
            this.col_apellidos.HeaderText = "Apellidos";
            this.col_apellidos.Name = "col_apellidos";
            this.col_apellidos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_nacionalidad
            // 
            this.col_nacionalidad.DataPropertyName = "Nacionalidad";
            this.col_nacionalidad.HeaderText = "Nacionalidad";
            this.col_nacionalidad.Name = "col_nacionalidad";
            this.col_nacionalidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_nacionalidad.Visible = false;
            // 
            // col_Fecha
            // 
            this.col_Fecha.DataPropertyName = "FechaNacimiento";
            this.col_Fecha.HeaderText = "Fecha";
            this.col_Fecha.Name = "col_Fecha";
            this.col_Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Fecha.Visible = false;
            // 
            // col_posicion
            // 
            this.col_posicion.DataPropertyName = "Posicion";
            this.col_posicion.HeaderText = "Posición";
            this.col_posicion.Name = "col_posicion";
            this.col_posicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_posicion.Visible = false;
            this.col_posicion.Width = 65;
            // 
            // col_altura
            // 
            this.col_altura.DataPropertyName = "Altura";
            this.col_altura.HeaderText = "Altura";
            this.col_altura.Name = "col_altura";
            this.col_altura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_altura.Visible = false;
            // 
            // col_peso
            // 
            this.col_peso.DataPropertyName = "Peso";
            this.col_peso.HeaderText = "Peso";
            this.col_peso.Name = "col_peso";
            this.col_peso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_peso.Visible = false;
            // 
            // col_titular
            // 
            this.col_titular.HeaderText = "Titular";
            this.col_titular.Name = "col_titular";
            this.col_titular.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_titular.Width = 45;
            // 
            // col_suplente
            // 
            this.col_suplente.HeaderText = "Suplente";
            this.col_suplente.Name = "col_suplente";
            this.col_suplente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_suplente.Width = 52;
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(475, 591);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(75, 23);
            this.btn_editar.TabIndex = 3;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_terminar
            // 
            this.btn_terminar.Location = new System.Drawing.Point(556, 591);
            this.btn_terminar.Name = "btn_terminar";
            this.btn_terminar.Size = new System.Drawing.Size(75, 23);
            this.btn_terminar.TabIndex = 2;
            this.btn_terminar.Text = "Terminar";
            this.btn_terminar.UseVisualStyleBackColor = true;
            this.btn_terminar.Click += new System.EventHandler(this.btn_terminar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_equipo_visitante);
            this.panel2.Location = new System.Drawing.Point(324, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 26);
            this.panel2.TabIndex = 1;
            // 
            // lbl_equipo_visitante
            // 
            this.lbl_equipo_visitante.AutoSize = true;
            this.lbl_equipo_visitante.Location = new System.Drawing.Point(3, 7);
            this.lbl_equipo_visitante.Name = "lbl_equipo_visitante";
            this.lbl_equipo_visitante.Size = new System.Drawing.Size(83, 13);
            this.lbl_equipo_visitante.TabIndex = 1;
            this.lbl_equipo_visitante.Text = "Equipo Visitante";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_equipo_local);
            this.panel1.Location = new System.Drawing.Point(16, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 26);
            this.panel1.TabIndex = 0;
            // 
            // lbl_equipo_local
            // 
            this.lbl_equipo_local.AutoSize = true;
            this.lbl_equipo_local.Location = new System.Drawing.Point(4, 6);
            this.lbl_equipo_local.Name = "lbl_equipo_local";
            this.lbl_equipo_local.Size = new System.Drawing.Size(69, 13);
            this.lbl_equipo_local.TabIndex = 0;
            this.lbl_equipo_local.Text = "Equipo Local";
            // 
            // btn_goles_agregar
            // 
            this.btn_goles_agregar.Location = new System.Drawing.Point(356, 45);
            this.btn_goles_agregar.Name = "btn_goles_agregar";
            this.btn_goles_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_goles_agregar.TabIndex = 7;
            this.btn_goles_agregar.Text = "Agregar";
            this.btn_goles_agregar.UseVisualStyleBackColor = true;
            this.btn_goles_agregar.Click += new System.EventHandler(this.btn_goles_agregar_Click);
            // 
            // dgv_goles
            // 
            this.dgv_goles.AllowUserToAddRows = false;
            this.dgv_goles.AllowUserToDeleteRows = false;
            this.dgv_goles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jugador_goles,
            this.col_equipo_goles,
            this.col_minuto_goles,
            this.col_eliminar_goles});
            this.dgv_goles.Location = new System.Drawing.Point(6, 74);
            this.dgv_goles.Name = "dgv_goles";
            this.dgv_goles.RowHeadersVisible = false;
            this.dgv_goles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_goles.Size = new System.Drawing.Size(425, 389);
            this.dgv_goles.TabIndex = 8;
            // 
            // col_jugador_goles
            // 
            this.col_jugador_goles.HeaderText = "Jugador";
            this.col_jugador_goles.Name = "col_jugador_goles";
            this.col_jugador_goles.ReadOnly = true;
            this.col_jugador_goles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_jugador_goles.Width = 150;
            // 
            // col_equipo_goles
            // 
            this.col_equipo_goles.HeaderText = "Equipo";
            this.col_equipo_goles.Name = "col_equipo_goles";
            this.col_equipo_goles.ReadOnly = true;
            this.col_equipo_goles.Width = 120;
            // 
            // col_minuto_goles
            // 
            this.col_minuto_goles.HeaderText = "Minuto";
            this.col_minuto_goles.Name = "col_minuto_goles";
            this.col_minuto_goles.ReadOnly = true;
            this.col_minuto_goles.Width = 70;
            // 
            // col_eliminar_goles
            // 
            this.col_eliminar_goles.HeaderText = "Eliminar";
            this.col_eliminar_goles.Name = "col_eliminar_goles";
            this.col_eliminar_goles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_eliminar_goles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_eliminar_goles.Width = 80;
            // 
            // cmb_goles_actualizar
            // 
            this.cmb_goles_actualizar.Location = new System.Drawing.Point(356, 469);
            this.cmb_goles_actualizar.Name = "cmb_goles_actualizar";
            this.cmb_goles_actualizar.Size = new System.Drawing.Size(75, 33);
            this.cmb_goles_actualizar.TabIndex = 9;
            this.cmb_goles_actualizar.Text = "Actualizar";
            this.cmb_goles_actualizar.UseVisualStyleBackColor = true;
            this.cmb_goles_actualizar.Click += new System.EventHandler(this.cmb_goles_actualizar_Click);
            // 
            // cmb_goles_equipos
            // 
            this.cmb_goles_equipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_goles_equipos.FormattingEnabled = true;
            this.cmb_goles_equipos.Items.AddRange(new object[] {
            "(Seleccione equipo)"});
            this.cmb_goles_equipos.Location = new System.Drawing.Point(6, 18);
            this.cmb_goles_equipos.Name = "cmb_goles_equipos";
            this.cmb_goles_equipos.Size = new System.Drawing.Size(171, 21);
            this.cmb_goles_equipos.TabIndex = 13;
            this.cmb_goles_equipos.SelectedIndexChanged += new System.EventHandler(this.cmb_goles_equipos_SelectedIndexChanged);
            // 
            // cmb_goles_jugadores
            // 
            this.cmb_goles_jugadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_goles_jugadores.FormattingEnabled = true;
            this.cmb_goles_jugadores.Items.AddRange(new object[] {
            "(Seleccione jugador)"});
            this.cmb_goles_jugadores.Location = new System.Drawing.Point(194, 18);
            this.cmb_goles_jugadores.Name = "cmb_goles_jugadores";
            this.cmb_goles_jugadores.Size = new System.Drawing.Size(237, 21);
            this.cmb_goles_jugadores.TabIndex = 15;
            // 
            // cmb_goles_minuto
            // 
            this.cmb_goles_minuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_goles_minuto.FormattingEnabled = true;
            this.cmb_goles_minuto.Items.AddRange(new object[] {
            "(Seleccione el minuto)",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90"});
            this.cmb_goles_minuto.Location = new System.Drawing.Point(6, 45);
            this.cmb_goles_minuto.Name = "cmb_goles_minuto";
            this.cmb_goles_minuto.Size = new System.Drawing.Size(171, 21);
            this.cmb_goles_minuto.TabIndex = 14;
            // 
            // cmb_lesiones_descanzo
            // 
            this.cmb_lesiones_descanzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lesiones_descanzo.FormattingEnabled = true;
            this.cmb_lesiones_descanzo.Items.AddRange(new object[] {
            "(Seleccione el tiempo de descanzo)",
            "1 día",
            "2 días",
            "3 días",
            "4 días",
            "5 días",
            "6 días",
            "7 días",
            "8 días",
            "9 días",
            "10 días",
            "11 días",
            "12 días",
            "13 días",
            "14 días",
            "15 días",
            "16 días",
            "17 días",
            "18 días",
            "19 días",
            "20 días",
            "21 días",
            "22 días",
            "23 días",
            "24 días",
            "25 días",
            "26 días",
            "27 días",
            "28 días",
            "29 días",
            "30 días",
            "31 días",
            "32 días",
            "33 días",
            "34 días",
            "35 días",
            "36 días",
            "37 días",
            "38 días",
            "39 días",
            "40 días",
            "41 días",
            "42 días",
            "43 días",
            "44 días",
            "45 días",
            "46 días",
            "47 días",
            "48 días",
            "49 días",
            "50 días",
            "51 días",
            "52 días",
            "53 días",
            "54 días",
            "55 días",
            "56 días",
            "57 días",
            "58 días",
            "59 días",
            "60 días"});
            this.cmb_lesiones_descanzo.Location = new System.Drawing.Point(170, 46);
            this.cmb_lesiones_descanzo.Name = "cmb_lesiones_descanzo";
            this.cmb_lesiones_descanzo.Size = new System.Drawing.Size(173, 21);
            this.cmb_lesiones_descanzo.TabIndex = 16;
            // 
            // cmb_lesiones_jugadores
            // 
            this.cmb_lesiones_jugadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lesiones_jugadores.FormattingEnabled = true;
            this.cmb_lesiones_jugadores.Items.AddRange(new object[] {
            "(Seleccione jugador)"});
            this.cmb_lesiones_jugadores.Location = new System.Drawing.Point(170, 19);
            this.cmb_lesiones_jugadores.Name = "cmb_lesiones_jugadores";
            this.cmb_lesiones_jugadores.Size = new System.Drawing.Size(260, 21);
            this.cmb_lesiones_jugadores.TabIndex = 15;
            // 
            // cmb_lesiones_tipo
            // 
            this.cmb_lesiones_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lesiones_tipo.FormattingEnabled = true;
            this.cmb_lesiones_tipo.Items.AddRange(new object[] {
            "(Seleccione el tipo)",
            "Fractura",
            "Esguince",
            "Traumatismo craneal",
            "Luxación",
            "Distensión muscular",
            "Contractura muscular",
            "Tirón muscular",
            "Calambre",
            "Desgarro"});
            this.cmb_lesiones_tipo.Location = new System.Drawing.Point(6, 46);
            this.cmb_lesiones_tipo.Name = "cmb_lesiones_tipo";
            this.cmb_lesiones_tipo.Size = new System.Drawing.Size(158, 21);
            this.cmb_lesiones_tipo.TabIndex = 14;
            // 
            // cmb_lesiones_equipos
            // 
            this.cmb_lesiones_equipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lesiones_equipos.FormattingEnabled = true;
            this.cmb_lesiones_equipos.Items.AddRange(new object[] {
            "(Seleccione equipo)"});
            this.cmb_lesiones_equipos.Location = new System.Drawing.Point(6, 19);
            this.cmb_lesiones_equipos.Name = "cmb_lesiones_equipos";
            this.cmb_lesiones_equipos.Size = new System.Drawing.Size(158, 21);
            this.cmb_lesiones_equipos.TabIndex = 13;
            this.cmb_lesiones_equipos.SelectedIndexChanged += new System.EventHandler(this.cmb_lesiones_equipos_SelectedIndexChanged);
            // 
            // btn_lesiones_actualizar
            // 
            this.btn_lesiones_actualizar.Location = new System.Drawing.Point(355, 469);
            this.btn_lesiones_actualizar.Name = "btn_lesiones_actualizar";
            this.btn_lesiones_actualizar.Size = new System.Drawing.Size(75, 33);
            this.btn_lesiones_actualizar.TabIndex = 9;
            this.btn_lesiones_actualizar.Text = "Actualizar";
            this.btn_lesiones_actualizar.UseVisualStyleBackColor = true;
            this.btn_lesiones_actualizar.Click += new System.EventHandler(this.btn_lesiones_actualizar_Click);
            // 
            // dgv_lesiones
            // 
            this.dgv_lesiones.AllowUserToAddRows = false;
            this.dgv_lesiones.AllowUserToDeleteRows = false;
            this.dgv_lesiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jugador_lesiones,
            this.col_equipo_lesiones,
            this.col_minuto_lesiones,
            this.Tiempo,
            this.col_eliminar_lesiones});
            this.dgv_lesiones.Location = new System.Drawing.Point(6, 73);
            this.dgv_lesiones.Name = "dgv_lesiones";
            this.dgv_lesiones.RowHeadersVisible = false;
            this.dgv_lesiones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_lesiones.Size = new System.Drawing.Size(424, 390);
            this.dgv_lesiones.TabIndex = 8;
            // 
            // col_jugador_lesiones
            // 
            this.col_jugador_lesiones.HeaderText = "Jugador";
            this.col_jugador_lesiones.Name = "col_jugador_lesiones";
            this.col_jugador_lesiones.ReadOnly = true;
            // 
            // col_equipo_lesiones
            // 
            this.col_equipo_lesiones.HeaderText = "Equipo";
            this.col_equipo_lesiones.Name = "col_equipo_lesiones";
            this.col_equipo_lesiones.ReadOnly = true;
            // 
            // col_minuto_lesiones
            // 
            this.col_minuto_lesiones.HeaderText = "Tipo";
            this.col_minuto_lesiones.Name = "col_minuto_lesiones";
            this.col_minuto_lesiones.ReadOnly = true;
            this.col_minuto_lesiones.Width = 110;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tiempo.Width = 60;
            // 
            // col_eliminar_lesiones
            // 
            this.col_eliminar_lesiones.HeaderText = "Eliminar";
            this.col_eliminar_lesiones.Name = "col_eliminar_lesiones";
            this.col_eliminar_lesiones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_eliminar_lesiones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_eliminar_lesiones.Width = 50;
            // 
            // btn_lesiones_agregar
            // 
            this.btn_lesiones_agregar.Location = new System.Drawing.Point(355, 46);
            this.btn_lesiones_agregar.Name = "btn_lesiones_agregar";
            this.btn_lesiones_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_lesiones_agregar.TabIndex = 7;
            this.btn_lesiones_agregar.Text = "Agregar";
            this.btn_lesiones_agregar.UseVisualStyleBackColor = true;
            this.btn_lesiones_agregar.Click += new System.EventHandler(this.btn_lesiones_agregar_Click);
            // 
            // btn_guardar_datos
            // 
            this.btn_guardar_datos.Location = new System.Drawing.Point(974, 603);
            this.btn_guardar_datos.Name = "btn_guardar_datos";
            this.btn_guardar_datos.Size = new System.Drawing.Size(135, 37);
            this.btn_guardar_datos.TabIndex = 6;
            this.btn_guardar_datos.Text = "Guardar";
            this.btn_guardar_datos.UseVisualStyleBackColor = true;
            this.btn_guardar_datos.Click += new System.EventHandler(this.btn_guardar_datos_Click);
            // 
            // GrupoIncidencias
            // 
            this.GrupoIncidencias.Controls.Add(this.Amonestaciones);
            this.GrupoIncidencias.Controls.Add(this.tabPage2);
            this.GrupoIncidencias.Controls.Add(this.tabPage3);
            this.GrupoIncidencias.Location = new System.Drawing.Point(667, 63);
            this.GrupoIncidencias.Name = "GrupoIncidencias";
            this.GrupoIncidencias.SelectedIndex = 0;
            this.GrupoIncidencias.Size = new System.Drawing.Size(445, 534);
            this.GrupoIncidencias.TabIndex = 6;
            // 
            // Amonestaciones
            // 
            this.Amonestaciones.Controls.Add(this.btn_amonestaciones_actualizar);
            this.Amonestaciones.Controls.Add(this.cmb_amonestaciones_minuto);
            this.Amonestaciones.Controls.Add(this.dgv_amonestaciones);
            this.Amonestaciones.Controls.Add(this.cmb_amonestaciones_equipo);
            this.Amonestaciones.Controls.Add(this.btn_amonestaciones_agregar);
            this.Amonestaciones.Controls.Add(this.cmb_amonestaciones_jugador);
            this.Amonestaciones.Controls.Add(this.cmb_amonestaciones_amonestacion);
            this.Amonestaciones.Location = new System.Drawing.Point(4, 22);
            this.Amonestaciones.Name = "Amonestaciones";
            this.Amonestaciones.Padding = new System.Windows.Forms.Padding(3);
            this.Amonestaciones.Size = new System.Drawing.Size(437, 508);
            this.Amonestaciones.TabIndex = 0;
            this.Amonestaciones.Text = "Amonestaciones";
            this.Amonestaciones.UseVisualStyleBackColor = true;
            // 
            // btn_amonestaciones_actualizar
            // 
            this.btn_amonestaciones_actualizar.Location = new System.Drawing.Point(356, 470);
            this.btn_amonestaciones_actualizar.Name = "btn_amonestaciones_actualizar";
            this.btn_amonestaciones_actualizar.Size = new System.Drawing.Size(75, 32);
            this.btn_amonestaciones_actualizar.TabIndex = 6;
            this.btn_amonestaciones_actualizar.Text = "Actualizar";
            this.btn_amonestaciones_actualizar.UseVisualStyleBackColor = true;
            this.btn_amonestaciones_actualizar.Click += new System.EventHandler(this.btn_amonestaciones_actualizar_Click);
            // 
            // cmb_amonestaciones_minuto
            // 
            this.cmb_amonestaciones_minuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_amonestaciones_minuto.FormattingEnabled = true;
            this.cmb_amonestaciones_minuto.Items.AddRange(new object[] {
            "(Seleccione el minuto)",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90"});
            this.cmb_amonestaciones_minuto.Location = new System.Drawing.Point(178, 45);
            this.cmb_amonestaciones_minuto.Name = "cmb_amonestaciones_minuto";
            this.cmb_amonestaciones_minuto.Size = new System.Drawing.Size(172, 21);
            this.cmb_amonestaciones_minuto.TabIndex = 8;
            // 
            // dgv_amonestaciones
            // 
            this.dgv_amonestaciones.AllowUserToAddRows = false;
            this.dgv_amonestaciones.AllowUserToDeleteRows = false;
            this.dgv_amonestaciones.AllowUserToResizeColumns = false;
            this.dgv_amonestaciones.AllowUserToResizeRows = false;
            this.dgv_amonestaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jugador_amonestacion,
            this.col_equipo_amonestacion,
            this.col_tipo_amonestacion,
            this.col_minuto_amonestacion,
            this.col_eliminar_amonestacion});
            this.dgv_amonestaciones.Location = new System.Drawing.Point(6, 72);
            this.dgv_amonestaciones.Name = "dgv_amonestaciones";
            this.dgv_amonestaciones.RowHeadersVisible = false;
            this.dgv_amonestaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_amonestaciones.Size = new System.Drawing.Size(425, 392);
            this.dgv_amonestaciones.TabIndex = 5;
            // 
            // col_jugador_amonestacion
            // 
            this.col_jugador_amonestacion.HeaderText = "Jugador";
            this.col_jugador_amonestacion.Name = "col_jugador_amonestacion";
            this.col_jugador_amonestacion.ReadOnly = true;
            this.col_jugador_amonestacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_equipo_amonestacion
            // 
            this.col_equipo_amonestacion.HeaderText = "Equipo";
            this.col_equipo_amonestacion.Name = "col_equipo_amonestacion";
            this.col_equipo_amonestacion.ReadOnly = true;
            // 
            // col_tipo_amonestacion
            // 
            this.col_tipo_amonestacion.HeaderText = "Tipo";
            this.col_tipo_amonestacion.Name = "col_tipo_amonestacion";
            this.col_tipo_amonestacion.ReadOnly = true;
            // 
            // col_minuto_amonestacion
            // 
            this.col_minuto_amonestacion.HeaderText = "Minuto";
            this.col_minuto_amonestacion.Name = "col_minuto_amonestacion";
            this.col_minuto_amonestacion.ReadOnly = true;
            this.col_minuto_amonestacion.Width = 60;
            // 
            // col_eliminar_amonestacion
            // 
            this.col_eliminar_amonestacion.HeaderText = "Eliminar";
            this.col_eliminar_amonestacion.Name = "col_eliminar_amonestacion";
            this.col_eliminar_amonestacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_eliminar_amonestacion.Width = 50;
            // 
            // cmb_amonestaciones_equipo
            // 
            this.cmb_amonestaciones_equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_amonestaciones_equipo.FormattingEnabled = true;
            this.cmb_amonestaciones_equipo.Items.AddRange(new object[] {
            "(Seleccione equipo)"});
            this.cmb_amonestaciones_equipo.Location = new System.Drawing.Point(6, 18);
            this.cmb_amonestaciones_equipo.Name = "cmb_amonestaciones_equipo";
            this.cmb_amonestaciones_equipo.Size = new System.Drawing.Size(166, 21);
            this.cmb_amonestaciones_equipo.TabIndex = 0;
            this.cmb_amonestaciones_equipo.SelectedIndexChanged += new System.EventHandler(this.cmb_amonestaciones_equipo_SelectedIndexChanged);
            // 
            // btn_amonestaciones_agregar
            // 
            this.btn_amonestaciones_agregar.Location = new System.Drawing.Point(356, 45);
            this.btn_amonestaciones_agregar.Name = "btn_amonestaciones_agregar";
            this.btn_amonestaciones_agregar.Size = new System.Drawing.Size(75, 21);
            this.btn_amonestaciones_agregar.TabIndex = 4;
            this.btn_amonestaciones_agregar.Text = "Agregar";
            this.btn_amonestaciones_agregar.UseVisualStyleBackColor = true;
            this.btn_amonestaciones_agregar.Click += new System.EventHandler(this.btn_amonestaciones_agregar_Click);
            // 
            // cmb_amonestaciones_jugador
            // 
            this.cmb_amonestaciones_jugador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_amonestaciones_jugador.FormattingEnabled = true;
            this.cmb_amonestaciones_jugador.Items.AddRange(new object[] {
            "(Seleccione jugador)"});
            this.cmb_amonestaciones_jugador.Location = new System.Drawing.Point(178, 18);
            this.cmb_amonestaciones_jugador.Name = "cmb_amonestaciones_jugador";
            this.cmb_amonestaciones_jugador.Size = new System.Drawing.Size(172, 21);
            this.cmb_amonestaciones_jugador.TabIndex = 7;
            // 
            // cmb_amonestaciones_amonestacion
            // 
            this.cmb_amonestaciones_amonestacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_amonestaciones_amonestacion.FormattingEnabled = true;
            this.cmb_amonestaciones_amonestacion.Items.AddRange(new object[] {
            "(Seleccione amonestación)",
            "Tarjeta Amarilla",
            "Tarjeta Roja"});
            this.cmb_amonestaciones_amonestacion.Location = new System.Drawing.Point(6, 45);
            this.cmb_amonestaciones_amonestacion.Name = "cmb_amonestaciones_amonestacion";
            this.cmb_amonestaciones_amonestacion.Size = new System.Drawing.Size(166, 21);
            this.cmb_amonestaciones_amonestacion.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmb_goles_actualizar);
            this.tabPage2.Controls.Add(this.cmb_goles_minuto);
            this.tabPage2.Controls.Add(this.dgv_goles);
            this.tabPage2.Controls.Add(this.cmb_goles_jugadores);
            this.tabPage2.Controls.Add(this.btn_goles_agregar);
            this.tabPage2.Controls.Add(this.cmb_goles_equipos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(437, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Goles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_lesiones_actualizar);
            this.tabPage3.Controls.Add(this.cmb_lesiones_descanzo);
            this.tabPage3.Controls.Add(this.dgv_lesiones);
            this.tabPage3.Controls.Add(this.cmb_lesiones_equipos);
            this.tabPage3.Controls.Add(this.btn_lesiones_agregar);
            this.tabPage3.Controls.Add(this.cmb_lesiones_tipo);
            this.tabPage3.Controls.Add(this.cmb_lesiones_jugadores);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(437, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lesiones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(667, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 26);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Incidencias del Partido";
            // 
            // frmEditarDatosPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 653);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.GrupoIncidencias);
            this.Controls.Add(this.btn_guardar_datos);
            this.Controls.Add(this.gb_equipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditarDatosPartido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de Partido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inCerrar);
            this.Load += new System.EventHandler(this.EditarDatosPartido_Load);
            this.gb_equipos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equipo_visitante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equipo_local)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_goles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lesiones)).EndInit();
            this.GrupoIncidencias.ResumeLayout(false);
            this.Amonestaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_amonestaciones)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_equipos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_equipo_local;
        private System.Windows.Forms.DataGridView dgv_equipo_visitante;
        private System.Windows.Forms.DataGridView dgv_equipo_local;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_terminar;
        private System.Windows.Forms.Label lbl_equipo_visitante;
        private System.Windows.Forms.Button btn_goles_agregar;
        private System.Windows.Forms.DataGridView dgv_goles;
        private System.Windows.Forms.Button cmb_goles_actualizar;
        private System.Windows.Forms.ComboBox cmb_goles_equipos;
        private System.Windows.Forms.ComboBox cmb_goles_jugadores;
        private System.Windows.Forms.ComboBox cmb_goles_minuto;
        private System.Windows.Forms.ComboBox cmb_lesiones_jugadores;
        private System.Windows.Forms.ComboBox cmb_lesiones_tipo;
        private System.Windows.Forms.ComboBox cmb_lesiones_equipos;
        private System.Windows.Forms.Button btn_lesiones_actualizar;
        private System.Windows.Forms.DataGridView dgv_lesiones;
        private System.Windows.Forms.Button btn_lesiones_agregar;
        private System.Windows.Forms.Button btn_guardar_datos;
        private System.Windows.Forms.ComboBox cmb_lesiones_descanzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jugador_goles;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_equipo_goles;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_minuto_goles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_eliminar_goles;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jugador_lesiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_equipo_lesiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_minuto_lesiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_eliminar_lesiones;
        private System.Windows.Forms.TabControl GrupoIncidencias;
        private System.Windows.Forms.TabPage Amonestaciones;
        private System.Windows.Forms.Button btn_amonestaciones_actualizar;
        private System.Windows.Forms.ComboBox cmb_amonestaciones_minuto;
        private System.Windows.Forms.DataGridView dgv_amonestaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jugador_amonestacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_equipo_amonestacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_amonestacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_minuto_amonestacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_eliminar_amonestacion;
        private System.Windows.Forms.ComboBox cmb_amonestaciones_equipo;
        private System.Windows.Forms.Button btn_amonestaciones_agregar;
        private System.Windows.Forms.ComboBox cmb_amonestaciones_jugador;
        private System.Windows.Forms.ComboBox cmb_amonestaciones_amonestacion;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cod_jugador_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre_jugador_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_apellidos_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nacionalidad_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_posicion_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_altura_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_peso_v;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_titular_v;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_suplente_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cod_jugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_posicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_altura;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_peso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_titular;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_suplente;
    }
}