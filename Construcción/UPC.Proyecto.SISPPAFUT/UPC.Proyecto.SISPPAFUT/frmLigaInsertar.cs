using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmLigaInsertar : Form
    {
        private static frmLigaInsertar frmLiga = null;
        public static frmLigaInsertar Instance()
        {
            if (frmLiga == null)
            {
                frmLiga = new frmLigaInsertar();
            }
            return frmLiga;
        }

        public frmLigaInsertar()
        {
            InitializeComponent();
        }

        private void inLoad(object sender, EventArgs e)
        {
            PaisBC objPaisBC = new PaisBC();
            List<PaisBE> lista_paises = objPaisBC.listarPaises();

            for (int i = 0; i < lista_paises.Count; i++)
            {
                cmb_pais.Items.Add(lista_paises[i].NombrePais);
            }
        }

        private void inPaisSeleccionado(object sender, EventArgs e)
        {
            //-- Se lista las competiciones del país seleccionado
            CompeticionBC objCompeticionBC = new CompeticionBC();
            List<CompeticionBE> lstCompeticion = objCompeticionBC.ListarCompeticion(cmb_pais.Text);

            for (int i = 0; i < lstCompeticion.Count; i++)
            {
                cmb_competicion.Items.Add(lstCompeticion[i].Nombre_competicion);
            }

            //-- Se listan los equipos del país seleccionado
            EquipoBC objEquipoBC = new EquipoBC();
            List<EquipoBE> lstEquipo = objEquipoBC.listarEquipos(cmb_pais.Text);

            for (int i = 0; i < lstEquipo.Count; i++)
            {
                cmb_equipo.Items.Add(lstEquipo[i].NombreEquipo);
            }
        }

        private void inTemporada(object sender, EventArgs e)
        {
            txt_nombre.Text = String.Format("{0} {1}", cmb_competicion.Text, txt_temporada.Text);
        }

        private void inEditarNombreLiga(object sender, EventArgs e)
        {
            if (chb_editar.Checked)
            {
                txt_nombre.Enabled = true;
            }
            else
                txt_nombre.Enabled = false;
        }
    }
}
