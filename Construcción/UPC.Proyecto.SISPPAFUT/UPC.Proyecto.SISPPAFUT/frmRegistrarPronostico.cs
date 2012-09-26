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
                dgvPronosticos.ReadOnly = true;
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
                
                //for(int i=0;i<

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
