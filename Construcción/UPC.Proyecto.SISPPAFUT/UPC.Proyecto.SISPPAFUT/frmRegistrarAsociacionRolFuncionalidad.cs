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
    public partial class frmRegistrarAsociacionRolFuncionalidad : Form
    {
        public frmRegistrarAsociacionRolFuncionalidad()
        {
            InitializeComponent();
            CargarFuncionalidades();
            CargarRoles();

            lst_EstadosAsociaciones = new List<int>();
            lst_Asociaciones = new List<RolXFuncionalidadBE>();
        }

        List<FuncionalidadBE> lst_funcionalidades = null;
        List<RolBE> lst_roles = null;
        List<RolXFuncionalidadBE> lst_Asociaciones = null;
        List<int> lst_EstadosAsociaciones = null;

        private static frmRegistrarAsociacionRolFuncionalidad frmRolFunc = null;

        public static frmRegistrarAsociacionRolFuncionalidad Instance()
        {
            if (frmRolFunc == null)
                frmRolFunc = new frmRegistrarAsociacionRolFuncionalidad();
            return frmRolFunc;
        }

        public void CargarRoles()
        {
            try
            {
                lst_roles = new List<RolBE>();

                RolBC objRolBC = new RolBC();

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

        public void CargarFuncionalidades()
        {
            try
            {
                lst_funcionalidades = new List<FuncionalidadBE>();

                FuncionalidadBC objFuncionalidadBC = new FuncionalidadBC();

                lst_funcionalidades = objFuncionalidadBC.Listar_Funcionalidades();

                cmbFuncionalidad.Items.Clear();

                cmbFuncionalidad.Items.Add("Seleccione una funcionalidad...");
                cmbFuncionalidad.SelectedIndex = 0;

                for(int i=0; i<lst_funcionalidades.Count; i++)
                {
                    cmbFuncionalidad.Items.Add(lst_funcionalidades[i].NombreFuncionalidad);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFuncionalidad.SelectedIndex <= 0 || cmbRol.SelectedIndex <= 0)
                {
                    MessageBox.Show("Seleccione una funcionalidad y un rol");
                    return;
                }

                int Cantidad = 0;

                RolXFuncionalidadBC objRolxFuncionalidadBC = new RolXFuncionalidadBC();
                Cantidad = objRolxFuncionalidadBC.VerificarSiExiste_RolXFuncionalidad(lst_roles[cmbRol.SelectedIndex - 1].idRol, lst_funcionalidades[cmbFuncionalidad.SelectedIndex - 1].idFuncionalidad);

                if (Cantidad > 0)
                {
                    MessageBox.Show("Esta asociación ya existe. Debe registrar una diferente");
                    return;
                }

                RolXFuncionalidadBE objRolFuncionalidadBE = new RolXFuncionalidadBE();
                objRolFuncionalidadBE.idFuncionalidad = lst_funcionalidades[cmbFuncionalidad.SelectedIndex - 1].idFuncionalidad;
                objRolFuncionalidadBE.NombreFuncionalidad = lst_funcionalidades[cmbFuncionalidad.SelectedIndex - 1].NombreFuncionalidad;
                objRolFuncionalidadBE.idRol = lst_roles[cmbRol.SelectedIndex - 1].idRol;
                objRolFuncionalidadBE.NombreRol = lst_roles[cmbRol.SelectedIndex - 1].NombreRol;

                lst_Asociaciones.Add(objRolFuncionalidadBE);

                dgvListaAsignaciones.Rows.Add(objRolFuncionalidadBE.NombreFuncionalidad, objRolFuncionalidadBE.NombreRol);

                lst_EstadosAsociaciones.Add(0);

                cmbFuncionalidad.SelectedIndex = 0;
                cmbRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lst_EstadosAsociaciones.Count; i++)
                {
                    if (lst_EstadosAsociaciones[i] == 1)
                    {
                        lst_Asociaciones.RemoveAt(i);
                    }
                }

                dgvListaAsignaciones.Rows.Clear();

                lst_EstadosAsociaciones.RemoveAll(valor => valor == 1);

                if (lst_Asociaciones.Count > 0)
                {
                    foreach (RolXFuncionalidadBE cDto in lst_Asociaciones)
                    {
                        dgvListaAsignaciones.Rows.Add(cDto.NombreFuncionalidad, cDto.NombreRol);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dgvListaAsignaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListaAsignaciones.IsCurrentCellDirty)
            {
                dgvListaAsignaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SeleccionEliminar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <0)
                return;

            if (dgvListaAsignaciones.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DataGridViewRow row = dgvListaAsignaciones.Rows[e.RowIndex];

                DataGridViewCheckBoxCell seleccion = row.Cells["Eliminar"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(seleccion.Value))
                {
                    lst_EstadosAsociaciones[e.RowIndex] = 1;
                }
                else
                {
                    lst_EstadosAsociaciones[e.RowIndex] = 0;
                }
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lst_Asociaciones.Count == 0)
            {
                MessageBox.Show("Añada asociaciones a la tabla para poder registrarlas");
                return;
            }

            RolXFuncionalidadBC objRolFuncionalidadBC;
            try
            {
                objRolFuncionalidadBC = new RolXFuncionalidadBC();

                objRolFuncionalidadBC.Insertar_RolXFuncionalidad(lst_Asociaciones);

                MessageBox.Show("Se registraron las asociaciones correctamente");

                dgvListaAsignaciones.Rows.Clear();
                lst_EstadosAsociaciones.Clear();
                lst_Asociaciones.Clear();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void frmRegistrarAsociacionRolFuncionalidad_Load(object sender, EventArgs e)
        {

        }
    }
}
