using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BE;
using UPC.Seguridad.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmRegistrarAsociacionUsuarioFuncionalidad : Form
    {
        public frmRegistrarAsociacionUsuarioFuncionalidad()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        List<RolBE> lst_roles;
        List<UsuarioBE> lst_usuarios;
        List<FuncionalidadBE> lst_funcionalidades;

        private static frmRegistrarAsociacionUsuarioFuncionalidad frmRolFunc = null;

        public static frmRegistrarAsociacionUsuarioFuncionalidad Instance()
        {
            if (frmRolFunc == null)
                frmRolFunc = new frmRegistrarAsociacionUsuarioFuncionalidad();
            return frmRolFunc;
        }

        public void CargarRoles()
        {
            UsuarioRolBC objRolBC;

            try 
            { 
                lst_roles = new List<RolBE>();
                objRolBC = new UsuarioRolBC();

                lst_roles = objRolBC.Listar_RolesXUsuario(lst_usuarios[cmbUsuario.SelectedIndex -1].IdUsuario);

                cmbRol.Items.Clear();

                cmbRol.Items.Add("Seleccione un rol...");
                cmbRol.SelectedIndex = 0;

                for (int i = 0; i < lst_roles.Count; i++)
                {
                    cmbRol.Items.Add(lst_roles[i].NombreRol);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void CargarUsuarios()
        {
            UsuarioBC objUsuarioBC;

            try
            {
                lst_usuarios = new List<UsuarioBE>();
                objUsuarioBC = new UsuarioBC();

                lst_usuarios = objUsuarioBC.listar_Usuarios();

                cmbUsuario.Items.Clear();

                cmbUsuario.Items.Add("Seleccione un usuario...");
                cmbUsuario.SelectedIndex = 0;

                for (int i = 0; i < lst_usuarios.Count; i++)
                {
                    cmbUsuario.Items.Add(lst_usuarios[i].NombreUsuario);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void frmRegistrarAsociacionUsuarioFuncionalidad_Load(object sender, EventArgs e)
        {

        }

        public void CargarFuncionalidades()
        {
            RolXFuncionalidadBC objFuncionalidadBC;

            try
            { 
                objFuncionalidadBC = new RolXFuncionalidadBC();

                lst_funcionalidades = new List<FuncionalidadBE>();

                lst_funcionalidades = objFuncionalidadBC.Listar_FuncionalidadesXRol(lst_roles[cmbRol.SelectedIndex - 1].idRol);

                cmbFuncionalidad.Items.Clear();
                cmbFuncionalidad.Items.Add("Seleccione una funcionalidad...");
                cmbFuncionalidad.SelectedIndex = 0;

                for (int i = 0; i < lst_funcionalidades.Count; i++)
                {
                    cmbFuncionalidad.Items.Add(lst_funcionalidades[i].NombreFuncionalidad);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inSeleccionRol(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex > 0)
            {
                CargarFuncionalidades();
            }
            else
                cmbFuncionalidad.Items.Clear();
            
        }

        private void inSeleccionUsuario(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex > 0)
            {
                CargarRoles();
            }
            else
            {
                cmbRol.Items.Clear();
            }
        }
    }
}
