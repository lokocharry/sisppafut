using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;


namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmEditarDatosPartido : Form
    {
        private int _codigo_partido;

        public int Codigo_partido
        {
            get { return _codigo_partido; }
            set { _codigo_partido = value; }
        }

        private String _equipo_local;

        public String Equipo_local
        {
            get { return _equipo_local; }
            set { _equipo_local = value; }
        }

        private String _equipo_visita;

        public String Equipo_visita
        {
            get { return _equipo_visita; }
            set { _equipo_visita = value; }
        }

        private PartidoBE objPartidoBE;
        private List<JugadorBE> lista_equipo_local;
        private List<JugadorBE> lista_equipo_visita;
        private List<AmonestacionBE> lista_amonestaciones;
        private List<GolBE> lista_goles;
        private List<LesionPartidoBE> lista_lesiones;
        private List<JugadorPartidoBE> lista_jugadores_partido;

        private static frmEditarDatosPartido frmEditarDPartido = null;
        
        public static frmEditarDatosPartido Instance()
        {
            if (frmEditarDPartido == null)
            {
                frmEditarDPartido = new frmEditarDatosPartido();
            }
            return frmEditarDPartido;
        }

        public frmEditarDatosPartido()
        {
            InitializeComponent();
            iniciarGrillaEquipoLocal();
            iniciarGrillaEquipoVisitante();
        }
                
        public void iniciarGrillaEquipoLocal()
        {
            try
            {
                dgv_equipo_local.AllowUserToAddRows = false;
                dgv_equipo_local.AllowUserToDeleteRows = false;
                dgv_equipo_local.AllowUserToResizeColumns = false;
                dgv_equipo_local.AllowUserToResizeRows = false;

                dgv_equipo_local.AllowDrop = false;

                dgv_equipo_local.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                //dgv_equipo_local.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_equipo_local.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_equipo_local.Columns[0].Visible = false;
                dgv_equipo_local.Columns[1].Visible = true;
                dgv_equipo_local.Columns[2].Visible = true;
                dgv_equipo_local.Columns[3].Visible = false;
                dgv_equipo_local.Columns[4].Visible = false;
                dgv_equipo_local.Columns[5].Visible = true;
                dgv_equipo_local.Columns[6].Visible = false;
                dgv_equipo_local.Columns[7].Visible = false;
                dgv_equipo_local.Columns[8].Visible = true;
                dgv_equipo_local.Columns[9].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_equipo_local.BackgroundColor;
                csFilaImpar.BackColor = dgv_equipo_local.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_equipo_local.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_equipo_local.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_equipo_local.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void iniciarGrillaEquipoVisitante()
        {
            try
            {
                dgv_equipo_visitante.AllowUserToAddRows = false;
                dgv_equipo_visitante.AllowUserToDeleteRows = false;
                dgv_equipo_visitante.AllowUserToResizeColumns = false;
                dgv_equipo_visitante.AllowUserToResizeRows = false;

                dgv_equipo_visitante.AllowDrop = false;

                dgv_equipo_visitante.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                //dgv_equipo_visitante.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_equipo_visitante.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_equipo_visitante.Columns[0].Visible = false;
                dgv_equipo_visitante.Columns[1].Visible = true;
                dgv_equipo_visitante.Columns[2].Visible = true;
                dgv_equipo_visitante.Columns[3].Visible = false;
                dgv_equipo_visitante.Columns[4].Visible = false;
                dgv_equipo_visitante.Columns[5].Visible = true;
                dgv_equipo_visitante.Columns[6].Visible = false;
                dgv_equipo_visitante.Columns[7].Visible = false;
                dgv_equipo_visitante.Columns[8].Visible = true;
                dgv_equipo_visitante.Columns[9].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_equipo_visitante.BackgroundColor;
                csFilaImpar.BackColor = dgv_equipo_visitante.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_equipo_visitante.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_equipo_visitante.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_equipo_visitante.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void EditarDatosPartido_Load(object sender, EventArgs e)
        {
            objPartidoBE = obtenerPartido();

            lista_equipo_local = new List<JugadorBE>();
            lista_equipo_visita = new List<JugadorBE>();
            lista_amonestaciones = new List<AmonestacionBE>();
            lista_goles = new List<GolBE>();
            lista_lesiones = new List<LesionPartidoBE>();

            lbl_equipo_local.Text = Equipo_local;
            lbl_equipo_visitante.Text = Equipo_visita;

            obtenerPartido();

            dgvJugadoresDataBind();
            llenarCombos();
        }

        private void cmb_amonestaciones_equipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_amonestaciones_equipo, cmb_amonestaciones_jugador);
        }

        private void cmb_goles_equipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_goles_equipos, cmb_goles_jugadores); 
        }

        private void cmb_lesiones_equipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_lesiones_equipos, cmb_lesiones_jugadores);
        }

        private void btn_amonestaciones_agregar_Click(object sender, EventArgs e)
        {
            int equipo = cmb_amonestaciones_equipo.SelectedIndex;

            AmonestacionBE objAmonestacionBE = new AmonestacionBE();

            objAmonestacionBE.Codigo_partido = Codigo_partido;
            objAmonestacionBE.Codigo_jugador = dame_codigo_jugador(equipo, cmb_amonestaciones_jugador);
            objAmonestacionBE.Minuto = Convert.ToInt32(cmb_amonestaciones_minuto.SelectedIndex - 1);
            objAmonestacionBE.Tipo = cmb_amonestaciones_amonestacion.SelectedIndex;

            dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem, 
                                        cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);

            lista_amonestaciones.Add(objAmonestacionBE);
        }

        private void btn_goles_agregar_Click(object sender, EventArgs e)
        {
            int equipo = cmb_goles_equipos.SelectedIndex;

            GolBE objGolBE = new GolBE();

            objGolBE.Codigo_partido = Codigo_partido;
            objGolBE.Codigo_jugador = dame_codigo_jugador(equipo, cmb_goles_jugadores);
            objGolBE.Minuto_gol = Convert.ToInt32(cmb_goles_minuto.SelectedIndex - 1);

            lista_goles.Add(objGolBE);

            dgv_goles.Rows.Add(dame_nombre_jugador(cmb_goles_equipos.SelectedIndex, cmb_goles_jugadores), cmb_goles_equipos.SelectedItem,
                               cmb_goles_minuto.SelectedItem);
        }

        private void btn_lesiones_agregar_Click(object sender, EventArgs e)
        {
            int equipo = cmb_lesiones_equipos.SelectedIndex;

            LesionPartidoBE objLesionPartidoBE = new LesionPartidoBE();

            objLesionPartidoBE.Codigo_partido = Codigo_partido;
            objLesionPartidoBE.Codigo_jugador = dame_codigo_jugador(equipo, cmb_lesiones_jugadores);
            objLesionPartidoBE.Tipo_lesion = "";
            objLesionPartidoBE.Dias_descanso = 0;

            lista_lesiones.Add(objLesionPartidoBE);

            dgv_lesiones.Rows.Add(dame_nombre_jugador(cmb_lesiones_equipos.SelectedIndex, cmb_lesiones_jugadores), cmb_lesiones_equipos.SelectedItem,
                                cmb_lesiones_minuto.SelectedItem);
        }

        private void btn_guardar_datos_Click(object sender, EventArgs e)
        {
            AmonestacionBC objAmonestaionesBC = new AmonestacionBC();
            objAmonestaionesBC.insertar_Amonestacion(lista_amonestaciones);

            GolBC objGolBC = new GolBC();
            objGolBC.insertar_Goles(lista_goles);

            LesionPartidoBC objLesionesBC = new LesionPartidoBC();
            objLesionesBC.insertar_Lesiones(lista_lesiones);

            JugadorPartidoBC objJugadorPartio = new JugadorPartidoBC();
            objJugadorPartio.insertar_jugadores(lista_jugadores_partido);
        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {
            dgv_equipo_local.Enabled = false;
            dgv_equipo_visitante.Enabled = false;
            btn_terminar.Enabled = false;
            btn_editar.Enabled = true;

            gb_amonestaciones.Enabled = true;
            gb_goles.Enabled = true;
            gb_lesiones.Enabled = true;

            lista_jugadores_partido = new List<JugadorPartidoBE>();

            DataGridViewCheckBoxCell check_titular = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell check_suplente = new DataGridViewCheckBoxCell();

            JugadorPartidoBE objJugadorPartidoBE;

            for (int i = 0; i < lista_equipo_local.Count; i++)
            {
                check_titular = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[i].Cells["col_titular"];
                check_suplente = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[i].Cells["col_suplente"];

                if (check_suplente.Value != null || check_titular.Value != null)
                {
                    objJugadorPartidoBE = new JugadorPartidoBE();

                    objJugadorPartidoBE.Codigo_partido = Codigo_partido;
                    objJugadorPartidoBE.Codigo_jugador = lista_equipo_local[i].CodigoJugador;

                    if (check_titular.Value != null)
                    {
                        if((bool)check_titular.Value.Equals(true))
                            objJugadorPartidoBE.Estado = 1;
                    }

                    if (check_suplente.Value != null)
                    {
                        if ((bool)check_suplente.Value.Equals(true))
                            objJugadorPartidoBE.Estado = 0;
                    }

                    lista_jugadores_partido.Add(objJugadorPartidoBE);
                }
            }

            for (int i = 0; i < lista_equipo_visita.Count; i++)
            {
                check_titular = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[i].Cells["col_titular_v"];
                check_suplente = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[i].Cells["col_suplente_v"];

                if (check_suplente.Value != null || check_titular.Value != null)
                {
                    objJugadorPartidoBE = new JugadorPartidoBE();

                    objJugadorPartidoBE.Codigo_partido = Codigo_partido;
                    objJugadorPartidoBE.Codigo_jugador = lista_equipo_visita[i].CodigoJugador;

                    if (check_titular.Value != null)
                    {
                        if ((bool)check_titular.Value.Equals(true))
                            objJugadorPartidoBE.Estado = 1;
                    }

                    if (check_suplente.Value != null)
                    {
                        if ((bool)check_suplente.Value.Equals(true))
                            objJugadorPartidoBE.Estado = 0;
                    }

                    lista_jugadores_partido.Add(objJugadorPartidoBE);
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            dgv_equipo_local.Enabled = true;
            dgv_equipo_visitante.Enabled = true;
            btn_terminar.Enabled = true;
            btn_editar.Enabled = false;
        }

        private void dgv_equipo_local_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell check_titular = new DataGridViewCheckBoxCell();
            check_titular = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[dgv_equipo_local.CurrentRow.Index].Cells["col_titular"];

            DataGridViewCheckBoxCell check_suplente = new DataGridViewCheckBoxCell();
            check_suplente = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[dgv_equipo_local.CurrentRow.Index].Cells["col_suplente"];

            if (check_titular.Value != null)
            {
                check_suplente.Value = false;
            }

            if (check_suplente.Value != null)
            {
                check_titular.Value = false;
            }

            /*
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }
            MessageBox.Show(ch1.Value.ToString());
            */
        }

        private void dgv_equip_visitante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell check_titular = new DataGridViewCheckBoxCell();
            check_titular = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[dgv_equipo_visitante.CurrentRow.Index].Cells["col_titular_v"];

            DataGridViewCheckBoxCell check_suplente = new DataGridViewCheckBoxCell();
            check_suplente = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[dgv_equipo_visitante.CurrentRow.Index].Cells["col_suplente_v"];

            if (check_titular.Value != null)
            {
                check_suplente.Value = false;
            }

            if (check_suplente.Value != null)
            {
                check_titular.Value = false;
            }
        }
        
        //------------------------------------------------------------------------------------------

        private void dgvJugadoresDataBind()
        {
            JugadorBC objJugadorBC = new JugadorBC();

            lista_equipo_local = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
            lista_equipo_visita = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);

            dgv_equipo_local.DataSource = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
            dgv_equipo_visitante.DataSource = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);
        }

        private void setearCombos()
        {
            cmb_amonestaciones_equipo.SelectedIndex = 0;
            cmb_amonestaciones_jugador.SelectedIndex = 0;
            cmb_amonestaciones_minuto.SelectedIndex = 0;
            cmb_amonestaciones_amonestacion.SelectedIndex = 0;

            cmb_goles_equipos.SelectedIndex = 0;
            cmb_goles_jugadores.SelectedIndex = 0;
            cmb_goles_minuto.SelectedIndex = 0;

            cmb_lesiones_equipos.SelectedIndex = 0;
            cmb_lesiones_jugadores.SelectedIndex = 0;
            cmb_lesiones_minuto.SelectedIndex = 0;
        }

        private void llenarCombos()
        {
            cmb_amonestaciones_equipo.Items.Add(Equipo_local);
            cmb_amonestaciones_equipo.Items.Add(Equipo_visita);

            cmb_goles_equipos.Items.Add(Equipo_local);
            cmb_goles_equipos.Items.Add(Equipo_visita);

            cmb_lesiones_equipos.Items.Add(Equipo_local);
            cmb_lesiones_equipos.Items.Add(Equipo_visita);
        }

        private void llenar_comboJugadores(ComboBox combo_equipos, ComboBox combo_jugadores)
        {
            combo_jugadores.Items.Clear();
            combo_jugadores.Items.Add("(Seleccione jugador)");

            if (combo_equipos.SelectedIndex == 1)
            {
                for (int i = 0; i < lista_equipo_local.Count; i++)
                    combo_jugadores.Items.Add(lista_equipo_local[i].Nombres + " " + lista_equipo_local[i].Apellidos);
            }

            if (combo_equipos.SelectedIndex == 2)
            {
                for (int i = 0; i < lista_equipo_visita.Count; i++)
                    combo_jugadores.Items.Add(lista_equipo_visita[i].Nombres + " " + lista_equipo_visita[i].Apellidos);
            }

            combo_jugadores.SelectedIndex = 0;
        }
        
        //------------------------------------------------------------------------------------------

        public PartidoBE obtenerPartido()
        {
            PartidoBC objPartidoBC = new PartidoBC();
            return objPartidoBC.obtener_Partido(Codigo_partido);
        }

        private int dame_codigo_jugador(int pos_equipo, ComboBox combo)
        {
            int code;

            if (pos_equipo == 1)
                code = lista_equipo_local[combo.SelectedIndex - 1].CodigoJugador;

            else if (pos_equipo == 2)
                code = lista_equipo_visita[combo.SelectedIndex - 1].CodigoJugador;

            else
                code = 0;

            return code;
        }

        private String dame_nombre_jugador(int pos_equipo, ComboBox combo)
        {
            String nombre;
            int posicion = combo.SelectedIndex - 1;

            if (pos_equipo == 1)
                nombre = lista_equipo_local[posicion].Nombres + " " + lista_equipo_local[posicion].Apellidos;
            else if (pos_equipo == 2)
                nombre = lista_equipo_visita[posicion].Nombres + " " + lista_equipo_visita[posicion].Apellidos;
            else
                nombre = "";

            return nombre;
        }


        private void inSalir(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
