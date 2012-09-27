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

        Boolean listo_guardar_datos = false;
        
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
            btn_editar.Enabled = false;
            GrupoIncidencias.Enabled = false;
        }

        private static int ComparaGol(GolBE x, GolBE y)
        {
            return x.Minuto_gol.CompareTo(y.Minuto_gol);
        }

        public List<GolBE> SortGol(List<GolBE> lst)
        {
            lst.Sort(ComparaGol);
            return lst;
        }

        private static int ComparaAmonestacion(AmonestacionBE x, AmonestacionBE y)
        {
            return x.Minuto.CompareTo(y.Minuto);
        }

        public List<AmonestacionBE> SortAmonestacion(List<AmonestacionBE> lst)
        {
            lst.Sort(ComparaAmonestacion);
            return lst;
        }

        private class GrillaGolComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public GrillaGolComparer(SortOrder sortOrder)
            {
                sortOrderModifier = 1;
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

                //-- El ordenamiento es en base al minuto del gol                
                return Convert.ToInt32(DataGridViewRow1.Cells["col_minuto_goles"].Value.ToString()).CompareTo(Convert.ToInt32(DataGridViewRow2.Cells["col_minuto_goles"].Value.ToString()));
            }
        }

        private class GrillaAmonestacionComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public GrillaAmonestacionComparer(SortOrder sortOrder)
            {
                sortOrderModifier = 1;
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

                //-- El ordenamiento es en base al minuto del gol                
                return Convert.ToInt32(DataGridViewRow1.Cells["col_minuto_amonestacion"].Value.ToString()).CompareTo(Convert.ToInt32(DataGridViewRow2.Cells["col_minuto_amonestacion"].Value.ToString()));
            }
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
                dgv_equipo_local.Columns[5].Visible = false;
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
                dgv_equipo_visitante.Columns[5].Visible = false;
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
            try
            {
                int equipo = cmb_amonestaciones_equipo.SelectedIndex;
                bool existe = false;
                bool roja = false;
                int q_amonestacion;

                AmonestacionBE objAmonestacionBE = new AmonestacionBE();

                if (cmb_amonestaciones_equipo.SelectedIndex > 0)
                {
                    if (cmb_amonestaciones_jugador.SelectedIndex > 0)
                    {
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
                            //-- Se debe escoger el minuto de juego donde se produjo la acción
                            if (cmb_amonestaciones_minuto.SelectedIndex > 0)
                            {
                                q_amonestacion = 0;
                                foreach (AmonestacionBE cDto in lista_amonestaciones)
                                {
                                    if (cDto.Codigo_jugador == objAmonestacionBE.Codigo_jugador && cDto.Tipo == objAmonestacionBE.Tipo && cDto.Minuto == objAmonestacionBE.Minuto)
                                    {
                                        existe = true;
                                        break;
                                    }
                                    else
                                        if (cDto.Codigo_jugador == objAmonestacionBE.Codigo_jugador)
                                        {
                                            q_amonestacion++;
                                            if (cDto.Tipo == 1)
                                            {
                                                roja = true;
                                                break;
                                            }
                                        }
                                }

                                if (!existe)
                                {
                                    if (q_amonestacion == 0)
                                    {
                                        dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem,
                                                               cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);

                                        lista_amonestaciones.Add(objAmonestacionBE);
                                    }
                                    else
                                        if (q_amonestacion == 1 && !roja)
                                        {
                                            if (objAmonestacionBE.Tipo == 0) //- Segunda amarilla
                                            {
                                                dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem,
                                                               cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);
                                                lista_amonestaciones.Add(objAmonestacionBE);
                                                //-- Roja por segunda amarilla en el partido
                                                AmonestacionBE objNuevaAmonestacion = new AmonestacionBE();
                                                objNuevaAmonestacion.Codigo_jugador = objAmonestacionBE.Codigo_jugador;
                                                objNuevaAmonestacion.Codigo_partido = objAmonestacionBE.Codigo_partido;
                                                objNuevaAmonestacion.Minuto = objAmonestacionBE.Minuto;
                                                objNuevaAmonestacion.Tipo = 1;
                                                dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem,
                                                               "Tarjeta Roja", cmb_amonestaciones_minuto.SelectedItem);
                                                lista_amonestaciones.Add(objNuevaAmonestacion);
                                            }
                                            else //-- Tarjeta roja directa
                                            {
                                                dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex, cmb_amonestaciones_jugador), cmb_amonestaciones_equipo.SelectedItem,
                                                               cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);
                                                lista_amonestaciones.Add(objAmonestacionBE);
                                            }
                                        }
                                        else
                                            MessageBox.Show("El jugador ya recibió la máxima cantidad de amonestaciones por partido.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgv_amonestaciones.Sort(new GrillaAmonestacionComparer(SortOrder.Ascending));
                                    List<AmonestacionBE> lst = new List<AmonestacionBE>();
                                    lst = lista_amonestaciones;
                                    lista_amonestaciones = SortAmonestacion(lst);
                                }
                                else
                                    MessageBox.Show("La amonestación ya figura en la lista de amonestaciones.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Debe escoger el minuto en el que se produjo la amonestación.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Debe escoger una amonestacion válida.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Debe escoger un jugador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe escoger un equipo.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }       

        private void btn_goles_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                int equipo = cmb_goles_equipos.SelectedIndex;
                bool existe = false;

                GolBE objGolBE = new GolBE();

                if (cmb_goles_equipos.SelectedIndex > 0)
                {
                    if (cmb_goles_jugadores.SelectedIndex > 0)
                    {
                        if (cmb_goles_minuto.SelectedIndex > 0)
                        {
                            objGolBE.Codigo_partido = Codigo_partido;
                            objGolBE.Codigo_jugador = dame_codigo_jugador(equipo, cmb_goles_jugadores);
                            objGolBE.Minuto_gol = Convert.ToInt32(cmb_goles_minuto.SelectedIndex - 1);

                            foreach (GolBE cDto in lista_goles)
                            {
                                if (cDto.Codigo_jugador == objGolBE.Codigo_jugador && cDto.Minuto_gol == objGolBE.Minuto_gol)
                                {
                                    existe = true;
                                    break;
                                }
                            }

                            if (!existe)
                            {
                                dgv_goles.Rows.Add(dame_nombre_jugador(cmb_goles_equipos.SelectedIndex, cmb_goles_jugadores), cmb_goles_equipos.SelectedItem,
                                                  cmb_goles_minuto.SelectedItem);
                                lista_goles.Add(objGolBE);

                                dgv_goles.Sort(new GrillaGolComparer(SortOrder.Ascending));
                                List<GolBE> lst = new List<GolBE>();
                                lst = lista_goles;
                                lista_goles = SortGol(lst);
                            }
                            else
                                MessageBox.Show("El gol ya se encuentra en la lista de goles.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Debe escoger el minuto en el que se produjo el gol.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Debe escoger un jugador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe escoger un equipo.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }        

        private void btn_lesiones_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                int equipo = cmb_lesiones_equipos.SelectedIndex;
                bool existe = false;

                LesionPartidoBE objLesionPartidoBE = new LesionPartidoBE();

                if (cmb_lesiones_equipos.SelectedIndex > 0)
                {
                    if (cmb_lesiones_jugadores.SelectedIndex > 0)
                    {
                        if (cmb_lesiones_tipo.SelectedIndex > 0)
                        {
                            if (cmb_lesiones_descanzo.SelectedIndex > 0)
                            {
                                objLesionPartidoBE.Codigo_partido = Codigo_partido;
                                objLesionPartidoBE.Codigo_jugador = dame_codigo_jugador(equipo, cmb_lesiones_jugadores);
                                objLesionPartidoBE.Tipo_lesion = cmb_lesiones_tipo.Text;
                                objLesionPartidoBE.Dias_descanso = cmb_lesiones_descanzo.SelectedIndex;

                                foreach (LesionPartidoBE cDto in lista_lesiones)
                                {
                                    if (cDto.Codigo_jugador == objLesionPartidoBE.Codigo_jugador) //-- falta acomodar las variables respecto a la base de datos
                                    {
                                        existe = true;
                                        break;
                                    }
                                }

                                if (!existe)
                                {
                                    dgv_lesiones.Rows.Add(dame_nombre_jugador(cmb_lesiones_equipos.SelectedIndex, cmb_lesiones_jugadores), cmb_lesiones_equipos.SelectedItem,
                                                       cmb_lesiones_tipo.SelectedItem, cmb_lesiones_descanzo.SelectedIndex);
                                    lista_lesiones.Add(objLesionPartidoBE);
                                }
                                else
                                    MessageBox.Show("La lesión ya se encuentra en la lista de lesiones.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Debe escoger el tiempo de descanzo aproximado.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Debe escoger el minuto de juego en la que se produjo la lesión.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Debe escoger un jugador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe escoger un equipo.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_guardar_datos_Click(object sender, EventArgs e)
        {
            try
            {
                if (listo_guardar_datos)
                {
                    if (VerificarGoles_Amonestaciones())
                    {
                        //Registro de jugadores que actuaron como titular o suplente en el partido
                        JugadorPartidoBC objJugadorPartio = new JugadorPartidoBC();
                        objJugadorPartio.insertar_jugadores(lista_jugadores_partido);

                        //Registro de amonestaciones
                        AmonestacionBC objAmonestaionesBC = new AmonestacionBC();
                        objAmonestaionesBC.insertar_Amonestacion(lista_amonestaciones);

                        //Registro de goles
                        GolBC objGolBC = new GolBC();
                        objGolBC.insertar_Goles(lista_goles);

                        //Actualizacion de resultado en el partido
                        PartidoBC objPartidoBC = new PartidoBC();
                        int cont_goles_local = 0;
                        int cont_goles_visita = 0;

                        for (int i = 0; i < lista_goles.Count; i++)
                        {
                            if (esJugadorLocal(lista_goles[i].Codigo_jugador))
                                cont_goles_local++;

                            else
                                cont_goles_visita++;
                        }

                        objPartidoBC.actualizar_Resultado(Codigo_partido, cont_goles_local, cont_goles_visita);

                        //Registro de lesiones
                        LesionPartidoBC objLesionesBC = new LesionPartidoBC();
                        objLesionesBC.insertar_Lesiones(lista_lesiones);
                        
                        //Actualizacion de suspensiones
                        SuspensionBC objSuspensionBC = new SuspensionBC();
                        for (int i = 0; i < lista_amonestaciones.Count; i++)
                        {
                            if (lista_amonestaciones[i].Tipo == 0)
                            {
                                objSuspensionBC.actualizar_Suspension(lista_amonestaciones[i].Codigo_jugador, objPartidoBE.Codigo_liga, 1);
                            }
                            if (lista_amonestaciones[i].Tipo == 1)
                            {
                                objSuspensionBC.actualizar_Suspension(lista_amonestaciones[i].Codigo_jugador, objPartidoBE.Codigo_liga, 2);
                            }
                        }

                        //Actualizamos las suspensiones de los jugadores suspendidos para este partido
                        for (int i = 0; i < lista_jugadores_suspendidos.Count; i++)
                        {
                            objSuspensionBC.actualizar_Suspension(lista_jugadores_suspendidos[i].CodigoJugador, objPartidoBE.Codigo_liga, 3);
                        }

                        MessageBox.Show("Los datos del partido han sido registrados.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmConsultaPartidosSinJugar frm = frmConsultaPartidosSinJugar.Instance();
                        frm.dgvPatidosDataBind();
                        this.Close();

                    }
                    else
                        MessageBox.Show("Existe datos inválidos en los goles marcados y amonestaciones. Verifique los datos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Los datos no están preparados para ser registrados.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }                

        private Boolean VerificarGoles_Amonestaciones()
        {
            foreach (AmonestacionBE cDtoA in lista_amonestaciones)
            {
                foreach (GolBE cDtoG in lista_goles)
                {
                    //-- Si un jugador fue amonestado con Tarjeta roja antes de meter un gol
                    if (cDtoA.Tipo == 1 && cDtoA.Codigo_jugador == cDtoG.Codigo_jugador && cDtoG.Minuto_gol > cDtoA.Minuto)
                        return false;
                }
            }

            return true;
        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {
            try
            {
                lista_jugadores_partido = new List<JugadorPartidoBE>();

                lista_jugaron_local = new List<JugadorBE>();
                lista_jugaron_visita = new List<JugadorBE>();

                DataGridViewCheckBoxCell check_titular = new DataGridViewCheckBoxCell();
                DataGridViewCheckBoxCell check_suplente = new DataGridViewCheckBoxCell();

                JugadorPartidoBE objJugadorPartidoBE;

                int cantidad_jugadores_local_titulares = 0;
                int cantidad_jugadores_local_suplentes = 0;
                int cantidad_jugadores_visita_titulares = 0;
                int cantidad_jugadores_visita_suplentes = 0;

                listo_guardar_datos = false;

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
                            if ((bool)check_titular.Value.Equals(true))
                            {
                                objJugadorPartidoBE.Estado = 1; //-- 1: titular
                                cantidad_jugadores_local_titulares++;
                            }
                        }

                        if (check_suplente.Value != null)
                        {
                            if ((bool)check_suplente.Value.Equals(true))
                            {
                                objJugadorPartidoBE.Estado = 0; //-- 0: suplente
                                cantidad_jugadores_local_suplentes++;
                            }
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
                            {
                                objJugadorPartidoBE.Estado = 1; //-- 1: titular
                                cantidad_jugadores_visita_titulares++;
                            }
                        }

                        if (check_suplente.Value != null)
                        {
                            if ((bool)check_suplente.Value.Equals(true))
                            {
                                objJugadorPartidoBE.Estado = 0; //-- 0: suplente
                                cantidad_jugadores_visita_suplentes++;
                            }
                        }

                        lista_jugadores_partido.Add(objJugadorPartidoBE);
                        lista_jugaron_visita.Add(lista_equipo_visita[i]);
                    }
                }

                //-- Se valida que hayan 11 jugadores titulares por equipo y máximo 7 jugadores suplentes por equipo
                if (cantidad_jugadores_local_titulares == 11 && cantidad_jugadores_local_suplentes <= 7 && cantidad_jugadores_visita_titulares == 11 && cantidad_jugadores_visita_suplentes <= 7)
                {
                    dgv_equipo_local.Enabled = false;
                    dgv_equipo_visitante.Enabled = false;
                    btn_terminar.Enabled = false;
                    btn_editar.Enabled = true;

                    GrupoIncidencias.Enabled = true;
                    setearCombos();

                    listo_guardar_datos = true;
                }
                else
                    MessageBox.Show("Debe seleccionar 11 jugadores titulares por equipo y máximo 7 jugadores suplentes por equipo.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            dgv_equipo_local.Enabled = true;
            dgv_equipo_visitante.Enabled = true;
            btn_terminar.Enabled = true;
            btn_editar.Enabled = false;

            GrupoIncidencias.Enabled = false;
            setearCombos();

            lista_amonestaciones = new List<AmonestacionBE>();
            lista_goles = new List<GolBE>();
            lista_lesiones = new List<LesionPartidoBE>();
        }

        private void dgv_equipo_local_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_equipo_local.IsCurrentCellDirty)
                dgv_equipo_local.CommitEdit(DataGridViewDataErrorContexts.Commit);

            DataGridViewCheckBoxCell check_l = new DataGridViewCheckBoxCell();

            if (dgv_equipo_local.Columns["col_titular"].Index == e.ColumnIndex)
            {
                check_l = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular"];

                dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular"].Value = true;
                dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente"].Value = false;
            }
            else
                if (dgv_equipo_local.Columns["col_suplente"].Index == e.ColumnIndex)
                {
                    check_l = (DataGridViewCheckBoxCell)dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente"];

                    dgv_equipo_local.Rows[e.RowIndex].Cells["col_suplente"].Value = true;
                    dgv_equipo_local.Rows[e.RowIndex].Cells["col_titular"].Value = false;
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
            try
            {
                JugadorBC objJugadorBC = new JugadorBC();
                SuspensionBC objSuspensionBC = new SuspensionBC();

                lista_jugadores_suspendidos = new List<JugadorBE>();

                //INICIALIZAMOS LAS LISTAS CON LOS EQUIPOS (LOCAL Y VISITA) COMPLETOS
                lista_equipo_local = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
                lista_equipo_visita = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);

                for (int i = 0; i < lista_equipo_local.Count; i++)
                {
                    //FILTRAMOS LOS JUGADORES SUSPENDIDOS DEL EQUIPO LOCAL
                    if (objSuspensionBC.leer_EstadoSuspension(lista_equipo_local[i].CodigoJugador, objPartidoBE.Codigo_liga).Equals("SUSPENDIDO"))
                    {
                        lista_jugadores_suspendidos.Add(lista_equipo_local[i]);
                        lista_equipo_local.RemoveAt(i);
                        i--;
                    }
                    else
                        //FILTRAMOS LOS JUGADORES LESIONADOS DEL EQUIPO LOCAL
                        if (objJugadorBC.estado_LesionJugador(lista_equipo_local[i].CodigoJugador, objPartidoBE.Fecha_partido).Equals("LESIONADO"))
                        {
                            lista_equipo_local.RemoveAt(i);
                            i--;
                        }
                }

                for (int i = 0; i < lista_equipo_visita.Count; i++)
                {
                    //FILTRAMOS LOS JUGADORES SUSPENDIDOS DEL EQUIPO VISITANTE
                    if (objSuspensionBC.leer_EstadoSuspension(lista_equipo_visita[i].CodigoJugador, objPartidoBE.Codigo_liga).Equals("SUSPENDIDO"))
                    {
                        lista_jugadores_suspendidos.Add(lista_equipo_visita[i]);
                        lista_equipo_visita.RemoveAt(i);
                        i--;
                    }
                    else
                        //FILTRAMOS LOS JUGADORES LESIONADOS DEL EQUIPO VISITANTE
                        if (objJugadorBC.estado_LesionJugador(lista_equipo_visita[i].CodigoJugador, objPartidoBE.Fecha_partido).Equals("LESIONADO"))
                        {
                            lista_equipo_visita.RemoveAt(i);
                            i--;
                        }
                }

                //LLENAMOS LOS GRILLA CON LAS LISTA FILTRADA DE CADA EQUIPO
                dgv_equipo_local.DataSource = lista_equipo_local;
                dgv_equipo_visitante.DataSource = lista_equipo_visita;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void setearCombos()
        {
            cmb_amonestaciones_equipo.SelectedIndex = 0;
            cmb_amonestaciones_jugador.SelectedIndex = 0;
            cmb_amonestaciones_minuto.SelectedIndex = 0;
            cmb_amonestaciones_amonestacion.SelectedIndex = 0;
            dgv_amonestaciones.Rows.Clear();

            cmb_goles_equipos.SelectedIndex = 0;
            cmb_goles_jugadores.SelectedIndex = 0;
            cmb_goles_minuto.SelectedIndex = 0;
            dgv_goles.Rows.Clear();

            cmb_lesiones_equipos.SelectedIndex = 0;
            cmb_lesiones_jugadores.SelectedIndex = 0;
            cmb_lesiones_tipo.SelectedIndex = 0;
            cmb_lesiones_descanzo.SelectedIndex = 0;
            dgv_lesiones.Rows.Clear();
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

        private bool esJugadorLocal(int codigo_jugador)
        {
            //Nos permite saber si el jugador pertenece al equipo local o no
            for (int i = 0; i < lista_jugaron_local.Count; i++)
            {
                if (codigo_jugador == lista_jugaron_local[i].CodigoJugador)
                    return true;
            }

            return false;
  
        }

        private void btn_amonestaciones_actualizar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell check_delete = new DataGridViewCheckBoxCell();
            bool doble_amonestacion;
            for (int i = 0; i < lista_amonestaciones.Count; i++)
            {
                doble_amonestacion = false;
                check_delete = (DataGridViewCheckBoxCell)dgv_amonestaciones.Rows[i].Cells["col_eliminar_amonestacion"];

                if (check_delete.Value != null)
                {
                    if (i > 0)
                    {
                        String nJugador1 = dgv_amonestaciones.Rows[i].Cells["col_jugador_amonestacion"].Value.ToString();
                        String nJugador2 = dgv_amonestaciones.Rows[i - 1].Cells["col_jugador_amonestacion"].Value.ToString();
                        String eJugador1 = dgv_amonestaciones.Rows[i].Cells["col_equipo_amonestacion"].Value.ToString();
                        String eJugador2 = dgv_amonestaciones.Rows[i - 1].Cells["col_equipo_amonestacion"].Value.ToString();
                        String tJugador1 = dgv_amonestaciones.Rows[i].Cells["col_tipo_amonestacion"].Value.ToString();
                        String tJugador2 = dgv_amonestaciones.Rows[i - 1].Cells["col_tipo_amonestacion"].Value.ToString();
                        String mJugador1 = dgv_amonestaciones.Rows[i].Cells["col_minuto_amonestacion"].Value.ToString();
                        String mJugador2 = dgv_amonestaciones.Rows[i - 1].Cells["col_minuto_amonestacion"].Value.ToString();

                        if (nJugador1 == nJugador2 && eJugador1 == eJugador2 && tJugador1 == "Tarjeta Roja" && tJugador2 == "Tarjeta Amarilla" && mJugador1 == mJugador2)
                            doble_amonestacion = true;
                    }

                    if ((bool)check_delete.Value.Equals(true))
                    {
                        if(doble_amonestacion)
                        {
                            lista_amonestaciones.RemoveAt(i);
                            lista_amonestaciones.RemoveAt(i-1);
                            dgv_amonestaciones.Rows.RemoveAt(i);
                            dgv_amonestaciones.Rows.RemoveAt(i-1);
                            i=i-2;
                        }
                        else
                        {
                            lista_amonestaciones.RemoveAt(i);
                            dgv_amonestaciones.Rows.RemoveAt(i);
                            i--;
                        }
                    }
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

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}
