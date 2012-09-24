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
    public partial class frmRegistrarAsociacionRolUsuario : Form
    {
        public frmRegistrarAsociacionRolUsuario()
        {
            InitializeComponent();
            CargarRoles();
            CargarUsuarios();
        }

        List<RolBE> lst_roles;
        List<UsuarioBE> lst_usuarios;
        List<UsuarioRolBE> lst_Asociaciones;
        List<int> lst_estados;

        private static frmRegistrarAsociacionRolUsuario frmrolus = null;

        public static frmRegistrarAsociacionRolUsuario Instance()
        {
            if (frmrolus == null)
                frmrolus = new frmRegistrarAsociacionRolUsuario();
            return frmrolus;
        }

        public void CargarUsuarios()
        {
            UsuarioBC objUsuarioBC;

            try
            {
                objUsuarioBC = new UsuarioBC();

                lst_usuarios = new List<UsuarioBE>();
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

        public void CargarRoles()
        {
            RolBC objRolBC;

            try
            {
                objRolBC = new RolBC();
                lst_roles = new List<RolBE>();

                lst_roles = objRolBC.Listar_roles();

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

        private void frmRegistrarAsociacionRolUsuario_Load(object sender, EventArgs e)
        {
            lst_Asociaciones = new List<UsuarioRolBE>();
            lst_estados = new List<int>();
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex <= 0 || cmbRol.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un usuario y un rol");
                return;
            }

            int Cantidad = 0;

            UsuarioRolBC objUsuarioRolBC = new UsuarioRolBC();
            Cantidad = objUsuarioRolBC.VerificarExiste_Asociacion(lst_roles[cmbRol.SelectedIndex - 1].idRol, lst_usuarios[cmbUsuario.SelectedIndex - 1].IdUsuario);

            if (Cantidad > 0)
            {
                MessageBox.Show("Esta asociación ya existe. Debe registrar una diferente");
                return;
            }

            UsuarioRolBE objRolUsuarioBE = new UsuarioRolBE();
            objRolUsuarioBE.IdUsuario = lst_usuarios[cmbUsuario.SelectedIndex - 1].IdUsuario;
            objRolUsuarioBE.NombreUsuario = lst_usuarios[cmbUsuario.SelectedIndex - 1].NombreUsuario;
            objRolUsuarioBE.IdRol = lst_roles[cmbRol.SelectedIndex - 1].idRol;
            objRolUsuarioBE.NombreRol = lst_roles[cmbRol.SelectedIndex - 1].NombreRol;

            lst_Asociaciones.Add(objRolUsuarioBE);

            dgvAsignaciones.Rows.Add(objRolUsuarioBE.NombreUsuario, objRolUsuarioBE.NombreRol);

            lst_estados.Add(0);

            cmbUsuario.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
        }

        private void dgvAsignaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAsignaciones.IsCurrentCellDirty)
            {
                dgvAsignaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void inSeleccionEliminar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAsignaciones.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DataGridViewRow row = dgvAsignaciones.Rows[e.RowIndex];

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

                dgvAsignaciones.Rows.Clear();

                lst_estados.RemoveAll(valor => valor == 1);

                if (lst_Asociaciones.Count > 0)
                {
                    foreach (UsuarioRolBE cDto in lst_Asociaciones)
                    {
                        dgvAsignaciones.Rows.Add(cDto.NombreUsuario, cDto.NombreRol);
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

            UsuarioRolBC objUsuarioRolBC;
            try
            {
                objUsuarioRolBC = new UsuarioRolBC();

                objUsuarioRolBC.asignar_RolUsuario(lst_Asociaciones);

                MessageBox.Show("Se registraron las asociaciones correctamente");

                dgvAsignaciones.Rows.Clear();
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
