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

        //Lista del total del jugadores de los equipo
        private List<JugadorBE> lista_equipo_local;
        private List<JugadorBE> lista_equipo_visita;

        //Lista de los jugadores que jugaron el partido
        private List<JugadorBE> lista_jugaron_local;
        private List<JugadorBE> lista_jugaron_visita;
        
        private List<AmonestacionBE> lista_amonestaciones;
        private List<GolBE> lista_goles;
        private List<LesionPartidoBE> lista_lesiones;
        private List<JugadorPartidoBE> lista_jugadores_partido;
        private List<JugadorBE> lista_jugadores_suspendidos;

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
            objAmonestacionBE.Tipo = -1;

            if (cmb_amonestaciones_amonestacion.SelectedIndex == 1)
            {
                objAmonestacionBE.Tipo = 0;
            }
            else if (cmb_amonestaciones_amonestacion.SelectedIndex == 2)
            {
                objAmonestacionBE.Tipo = 1;
            }

            //Se debe escoger tarjeta amarilla o roja
            if (objAmonestacionBE.Tipo != -1)
            {
                dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem,
                                            cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);

                lista_amonestaciones.Add(objAmonestacionBE);
            }
            else
            {
                MessageBox.Show("Escoger una amonestacion valida.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            try
            {
                AmonestacionBC objAmonestaionesBC = new AmonestacionBC();
                objAmonestaionesBC.insertar_Amonestacion(lista_amonestaciones);

                GolBC objGolBC = new GolBC();
                objGolBC.insertar_Goles(lista_goles);

                LesionPartidoBC objLesionesBC = new LesionPartidoBC();
                objLesionesBC.insertar_Lesiones(lista_lesiones);

                JugadorPartidoBC objJugadorPartio = new JugadorPartidoBC();
                objJugadorPartio.insertar_jugadores(lista_jugadores_partido);

                SuspensionBC objSuspensionBC = new SuspensionBC();
                for (int i = 0; i < lista_amonestaciones.Count; i++)
                {
                    if (lista_amonestaciones[i].Tipo == 0)
                    {
                        objSuspensionBC.actualizar_Suspension(lista_amonestaciones[i].Codigo_jugador, 1);
                    }
                    if (lista_amonestaciones[i].Tipo == 1)
                    {
                        objSuspensionBC.actualizar_Suspension(lista_amonestaciones[i].Codigo_jugador, 2);
                    }
                }

                for (int i = 0; i < lista_jugadores_suspendidos.Count; i++)
                {
                    objSuspensionBC.actualizar_Suspension(lista_jugadores_suspendidos[i].CodigoJugador, 3);
                }

                MessageBox.Show("Los datos del partido han sido registrados.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }

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

            lista_jugaron_local = new List<JugadorBE>();
            lista_jugaron_visita = new List<JugadorBE>();

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
                    lista_jugaron_local.Add(lista_equipo_local[i]);
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
                    lista_jugaron_visita.Add(lista_equipo_visita[i]);
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
            if (dgv_equipo_local.IsCurrentCellDirty)
                dgv_equipo_local.CommitEdit(DataGridViewDataErrorContexts.Commit);

            DataGridViewCheckBoxCell check_l = new DataGridViewCheckBoxCell();

            if (dgv_equipo_local.Columns["col_titular_v"].Index == e.ColumnIndex)
            {
                check_l = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular_v"];

                dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular_v"].Value = true;
                dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente_v"].Value = false;
            }
            else
                if (dgv_equipo_local.Columns["col_suplente_v"].Index == e.ColumnIndex)
                {
                    check_l = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente_v"];

                    dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente_v"].Value = true;
                    dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular_v"].Value = false;
                } 
        }

        private void dgv_equip_visitante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_equipo_visitante.IsCurrentCellDirty)
                dgv_equipo_visitante.CommitEdit(DataGridViewDataErrorContexts.Commit);

            DataGridViewCheckBoxCell check_l = new DataGridViewCheckBoxCell();

            if (dgv_equipo_visitante.Columns["col_titular_v"].Index == e.ColumnIndex)
            {
                check_l = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_titular_v"];

                dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_titular_v"].Value = true;
                dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_suplente_v"].Value = false;
            }
            else
                if (dgv_equipo_visitante.Columns["col_suplente_v"].Index == e.ColumnIndex)
                {
                    check_l = (DataGridViewCheckBoxCell)dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_suplente_v"];

                    dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_suplente_v"].Value = true;
                    dgv_equipo_visitante.Rows[e.RowIndex].Cells["col_titular_v"].Value = false;
                }            
        }

        private void dgvJugadoresDataBind()
        {
            JugadorBC objJugadorBC = new JugadorBC();
            SuspensionBC objSuspensionBC = new SuspensionBC();
            lista_jugadores_suspendidos = new List<JugadorBE>();

            lista_equipo_local = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
            lista_equipo_visita = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);

            for (int i = 0; i < lista_equipo_local.Count; i++)
            {
                if (objSuspensionBC.leer_EstadoSuspension(lista_equipo_local[i].CodigoJugador).Equals("SUSPENDIDO"))
                {
                    lista_jugadores_suspendidos.Add(lista_equipo_local[i]);
                    lista_equipo_local.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < lista_equipo_visita.Count; i++)
            {
                if (objSuspensionBC.leer_EstadoSuspension(lista_equipo_visita[i].CodigoJugador).Equals("SUSPENDIDO"))
                {
                    lista_jugadores_suspendidos.Add(lista_equipo_visita[i]);
                    lista_equipo_visita.RemoveAt(i);
                    i--;
                }
            }

            dgv_equipo_local.DataSource = lista_equipo_local;
            dgv_equipo_visitante.DataSource = lista_equipo_visita;
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
                for (int i = 0; i < lista_jugaron_local.Count; i++)
                    combo_jugadores.Items.Add(lista_jugaron_local[i].Nombres + " " + lista_jugaron_local[i].Apellidos);
            }

            if (combo_equipos.SelectedIndex == 2)
            {
                for (int i = 0; i < lista_jugaron_visita.Count; i++)
                    combo_jugadores.Items.Add(lista_jugaron_visita[i].Nombres + " " + lista_jugaron_visita[i].Apellidos);
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
                code = lista_jugaron_local[combo.SelectedIndex - 1].CodigoJugador;

            else if (pos_equipo == 2)
                code = lista_jugaron_visita[combo.SelectedIndex - 1].CodigoJugador;

            else
                code = 0;

            return code;
        }

        private String dame_nombre_jugador(int pos_equipo, ComboBox combo)
        {
            String nombre;
            int posicion = combo.SelectedIndex - 1;

            if (pos_equipo == 1)
                nombre = lista_jugaron_local[posicion].Nombres + " " + lista_jugaron_local[posicion].Apellidos;
            else if (pos_equipo == 2)
                nombre = lista_jugaron_visita[posicion].Nombres + " " + lista_jugaron_visita[posicion].Apellidos;
            else
                nombre = "";

            return nombre;
        }


        private void inSalir(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_amonestaciones_actualizar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell check_delete = new DataGridViewCheckBoxCell();

            for (int i = 0; i < lista_amonestaciones.Count; i++)
            {
                check_delete = (DataGridViewCheckBoxCell)dgv_amonestaciones.Rows[i].Cells["col_eliminar_amonestacion"];

                if (check_delete.Value != null)
                    if ((bool)check_delete.Value.Equals(true))
                    {
                        lista_amonestaciones.RemoveAt(i);
                        dgv_amonestaciones.Rows.RemoveAt(i);
                        i--;
                    }
            }            
        }

        private void cmb_goles_actualizar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell check_delete = new DataGridViewCheckBoxCell();

            for (int i = 0; i < lista_goles.Count; i++)
            {
                check_delete = (DataGridViewCheckBoxCell)dgv_goles.Rows[i].Cells["col_eliminar_goles"];

                if (check_delete.Value != null)
                    if ((bool)check_delete.Value.Equals(true))
                    {
                        lista_goles.RemoveAt(i);
                        dgv_goles.Rows.RemoveAt(i);
                        i--;
                    }
            }   
        }

        private void btn_lesiones_actualizar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell check_delete = new DataGridViewCheckBoxCell();

            for (int i = 0; i < lista_lesiones.Count; i++)
            {
                check_delete = (DataGridViewCheckBoxCell)dgv_lesiones.Rows[i].Cells["col_eliminar_lesiones"];

                if (check_delete.Value != null)
                    if ((bool)check_delete.Value.Equals(true))
                    {
                        lista_lesiones.RemoveAt(i);
                        dgv_lesiones.Rows.RemoveAt(i);
                        i--;
                    }
            }
        }
    }
}
