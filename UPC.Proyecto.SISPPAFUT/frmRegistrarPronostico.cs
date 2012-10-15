using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmRegistrarPronostico : Form
    {
        private static frmRegistrarPronostico frmRegistroPronosticos = null;
        public static frmRegistrarPronostico Instance()
        {
            if (frmRegistroPronosticos == null)
            {
                frmRegistroPronosticos = new frmRegistrarPronostico();
            }
            return frmRegistroPronosticos;
        }

        private int idusuario;

        public int idUsuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public frmRegistrarPronostico()
        {
            InitializeComponent();
        }

        private void frmRegistrarPronostico_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarGrillaPartidos();
                dgvPartidosDataBind();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarGrillaPartidos()
        {
            try
            {
                dgvPronosticos.AllowUserToAddRows = false;
                dgvPronosticos.AllowUserToDeleteRows = false;
                dgvPronosticos.AllowUserToResizeColumns = false;
                dgvPronosticos.AllowUserToResizeRows = false;
                dgvPronosticos.AllowDrop = false;
                dgvPronosticos.MultiSelect = false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvPartidosDataBind()
        {
            try
            {
                PartidoBC objPartidoBC;
                objPartidoBC = new PartidoBC();

                List<PartidoSinJugarBE> listaPartidos;
                listaPartidos = new List<PartidoSinJugarBE>();

                listaPartidos = objPartidoBC.lista_partidos_sinjugar();

                if (listaPartidos.Count > 0)
                {
                    dgvPronosticos.Rows.Clear();
                    for (int i = 0; i < listaPartidos.Count; i++)
                    {
                        dgvPronosticos.Rows.Add(listaPartidos[i].Codigo_partido,
                                                listaPartidos[i].Equipo_local,
                                                listaPartidos[i].Equipo_visitante, false, false, false);

                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para mostrar.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarPronosticos();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }

        }

        private void guardarPronosticos()
        {
            try
            {
                PronosticoClienteBC objPronosticoClienteBC;
                PronosticoClienteBE objPronosticoClienteBE;
                String pronostico = "";
                List<PronosticoClienteBE> listaPronosticos = new List<PronosticoClienteBE>();

                for (int i = 0; i < dgvPronosticos.RowCount; i++)
                {
                    objPronosticoClienteBE = new PronosticoClienteBE();
                    objPronosticoClienteBE.CodigoPartido = Convert.ToInt32(dgvPronosticos.Rows[i].Cells[0].Value);
                    objPronosticoClienteBE.CodigoUsuario = idusuario; 

                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[3].Value) == true)
                    {
                        pronostico = "L";
                    }
                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[4].Value) == true)
                    {
                        pronostico = "E";
                    }
                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[5].Value) == true)
                    {
                        pronostico = "V";
                    }

                    objPronosticoClienteBE.Pronostico = pronostico;                    
                    pronostico = "";

                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[3].Value) == true ||
                        Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[4].Value) == true ||
                        Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[5].Value) == true)
                    {
                        listaPronosticos.Add(objPronosticoClienteBE);
                    }
                }

                objPronosticoClienteBC = new PronosticoClienteBC();
                for (int i = 0; i < listaPronosticos.Count; i++)
                {
                    objPronosticoClienteBC.inssertarPronosticoCliente(listaPronosticos[i]);
                }

                MessageBox.Show("Los pronosticos han sido registrados satisfactoriamente.", 
                    "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
