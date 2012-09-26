using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;
using UPC.Seguridad.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class SISPPAFUTmdiPrincipal : Form
    {
        public SISPPAFUTmdiPrincipal()
        {
            InitializeComponent();
            estado_Funcionalidades = new List<int>(); //Valores -> 0: desactivado , 1: activado

            for (int i = 0; i < 26; i++)
                estado_Funcionalidades.Add(0);
        }
        int CodigoUsuario = 0;
        List<FuncionalidadBE> lst_funcionalidades;
        List<int> estado_Funcionalidades;

        private static SISPPAFUTmdiPrincipal frm = null;

        public static SISPPAFUTmdiPrincipal Instance()
        {
            if (frm == null)
                frm = new SISPPAFUTmdiPrincipal();
            return frm;
        }

        public void RecibirCodigoUsuario(int CodigoUsuario)
        {
            this.CodigoUsuario = CodigoUsuario;
        }

        public void CargarFuncionalidadesUsuario()
        {
            UsuarioFuncionalidadBC objUsuarioFuncionalidadBC;

            try
            {
                objUsuarioFuncionalidadBC = new UsuarioFuncionalidadBC();

                lst_funcionalidades = new List<FuncionalidadBE>();

                lst_funcionalidades = objUsuarioFuncionalidadBC.Listar_FuncionalidadesXUsuario(CodigoUsuario);

                for (int i = 0; i < lst_funcionalidades.Count; i++)
                {
                    estado_Funcionalidades[lst_funcionalidades[i].idFuncionalidad - 1] = 1;
                }
                int estado = estado_Funcionalidades.Count;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }


        private void SISPPAFUTmdiPrincipal_Load(object sender, EventArgs e)
        {
            CargarFuncionalidadesUsuario();
        }
    }
}
