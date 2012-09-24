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
        List<UsuarioFuncionalidadBE> lst_Asociaciones;
        List<int> lst_estados;

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
            lst_estados = new List<int>();
            lst_Asociaciones = new List<UsuarioFuncionalidadBE>();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbFuncionalidad.SelectedIndex <= 0 || cmbRol.SelectedIndex <= 0 || cmbUsuario.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un usuario, rol y funcionalidad");
                return;
            }

            UsuarioFuncionalidadBE objUsuarioFuncionalidadBE = new UsuarioFuncionalidadBE();

            objUsuarioFuncionalidadBE.Rol = lst_roles[cmbRol.SelectedIndex - 1].NombreRol;
            objUsuarioFuncionalidadBE.Usuario = lst_usuarios[cmbUsuario.SelectedIndex-1].NombreUsuario;
            objUsuarioFuncionalidadBE.Funcionalidad = lst_funcionalidades[cmbFuncionalidad.SelectedIndex -1].NombreFuncionalidad;
            objUsuarioFuncionalidadBE.idFuncionalidad = lst_funcionalidades[cmbFuncionalidad.SelectedIndex - 1].idFuncionalidad;
            objUsuarioFuncionalidadBE.idUsuario = lst_usuarios[cmbUsuario.SelectedIndex - 1].IdUsuario;

            String Rol = lst_roles[cmbRol.SelectedIndex-1].NombreRol;

            lst_Asociaciones.Add(objUsuarioFuncionalidadBE);
            dgvAsociaciones.Rows.Add(objUsuarioFuncionalidadBE.Usuario,Rol, objUsuarioFuncionalidadBE.Funcionalidad);

            lst_estados.Add(0);
            
            cmbFuncionalidad.SelectedIndex = 0;                   
            cmbRol.SelectedIndex = 0;
            cmbUsuario.SelectedIndex = 0;    
        }

        private void dgvAsociaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAsociaciones.IsCurrentCellDirty)
            {
                dgvAsociaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void inSeleccionEliminar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAsociaciones.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DataGridViewRow row = dgvAsociaciones.Rows[e.RowIndex];

                DataGridViewCheckBoxCell seleccion = row.Cells["Eliminar"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(seleccion.Value))
                {
                    lst_estados[e.RowIndex] = 1;
                }
                else
                {
                    lst_estados[e.RowIndex] = 0;
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lst_estados.Count; i++)
                {
                    if (lst_estados[i] == 1)
                    {
                        lst_Asociaciones.RemoveAt(i);
                    }
                }

                dgvAsociaciones.Rows.Clear();

                lst_estados.RemoveAll(valor => valor == 1);

                if (lst_Asociaciones.Count > 0)
                {
                    foreach (UsuarioFuncionalidadBE cDto in lst_Asociaciones)
                    {
                        dgvAsociaciones.Rows.Add(cDto.Usuario, cDto.Rol, cDto.Funcionalidad);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lst_Asociaciones.Count == 0)
            {
                MessageBox.Show("Añada asociaciones a la tabla para poder registrarlas");
                return;
            }

            UsuarioFuncionalidadBC objUsuarioFuncionalidadBC;
            try
            {
                objUsuarioFuncionalidadBC = new UsuarioFuncionalidadBC();

                objUsuarioFuncionalidadBC.Insertar_UsuarioFuncionalidad(lst_Asociaciones);

                MessageBox.Show("Se registraron las asociaciones correctamente");

                dgvAsociaciones.Rows.Clear();
                lst_estados.Clear();
                lst_Asociaciones.Clear();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
