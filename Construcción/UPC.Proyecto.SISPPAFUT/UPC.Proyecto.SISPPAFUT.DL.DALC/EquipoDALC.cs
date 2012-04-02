using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class EquipoDALC
    {
        public int insertar_Equipo(EquipoBE objEquipoBE)
        {
            String cadena;
            SqlConnection conexion = null;
            SqlCommand cmd_EquipoInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPais;
            SqlParameter prm_Nombre;
            SqlParameter prm_AnioFundacion;
            SqlParameter prm_Ciudad;
            SqlParameter prm_CodigoEstadioPrincipal;
            SqlParameter prm_CodigoEstadioAlterno;

            int iCodigoEquipo;

            String sqlEquipoInsertar;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);

                sqlEquipoInsertar = "spCreateEquipo";

                cmd_EquipoInsertar = new SqlCommand(sqlEquipoInsertar, conexion);
                cmd_EquipoInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoPais = new SqlParameter();
                prm_CodigoPais.ParameterName = "@codPais";
                prm_CodigoPais.SqlDbType = SqlDbType.Int;
                prm_CodigoPais.Value = objEquipoBE.CodigoPais;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = objEquipoBE.NombreEquipo;

                prm_AnioFundacion = new SqlParameter();
                prm_AnioFundacion.ParameterName = "@anioFundacion";
                prm_AnioFundacion.SqlDbType = SqlDbType.Int;
                prm_AnioFundacion.Value = objEquipoBE.AnioFundacion;

                prm_Ciudad = new SqlParameter();
                prm_Ciudad.ParameterName = "@ciudad";
                prm_Ciudad.SqlDbType = SqlDbType.VarChar;
                prm_Ciudad.Size = 20;
                prm_Ciudad.Value = objEquipoBE.CiudadEquipo;

                prm_CodigoEstadioPrincipal = new SqlParameter();
                prm_CodigoEstadioPrincipal.ParameterName = "@codEstadioPrincipal";
                prm_CodigoEstadioPrincipal.SqlDbType = SqlDbType.Int;
                prm_CodigoEstadioPrincipal.Value = objEquipoBE.CodigoEstadioPrincipal;

                prm_CodigoEstadioAlterno = new SqlParameter();
                prm_CodigoEstadioAlterno.ParameterName = "@codEstadioAlterno";
                prm_CodigoEstadioAlterno.SqlDbType = SqlDbType.Int;
                prm_CodigoEstadioAlterno.Value = objEquipoBE.CodigoEstadioAlterno;

                cmd_EquipoInsertar.Parameters.Add(prm_Codigo);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoPais);
                cmd_EquipoInsertar.Parameters.Add(prm_Nombre);
                cmd_EquipoInsertar.Parameters.Add(prm_AnioFundacion);
                cmd_EquipoInsertar.Parameters.Add(prm_Ciudad);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoEstadioPrincipal);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoEstadioAlterno);

                cmd_EquipoInsertar.Connection.Open();
                cmd_EquipoInsertar.ExecuteNonQuery();

                iCodigoEquipo = Convert.ToInt32(prm_Codigo.Value);

                cmd_EquipoInsertar.Connection.Close();

                conexion.Dispose();

                return iCodigoEquipo;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public int existe_Equipo(String nombre)
        {

            String cadena;
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd_EquipoValidar;
            String sqlEquipoValidar;
            SqlParameter prm_Nombre;

            int cantidad = 0;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);
                sqlEquipoValidar = "spEquipoVerificarRepetido";

                cmd_EquipoValidar = new SqlCommand(sqlEquipoValidar, conexion);
                cmd_EquipoValidar.CommandType = CommandType.StoredProcedure;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = nombre;

                cmd_EquipoValidar.Parameters.Add(prm_Nombre);

                cmd_EquipoValidar.Connection.Open();
                dr_equipo = cmd_EquipoValidar.ExecuteReader();

                if (dr_equipo.Read())
                {
                    cantidad = dr_equipo.GetInt32(dr_equipo.GetOrdinal("Cantidad"));
                }

                cmd_EquipoValidar.Connection.Close();
                conexion.Dispose();

                return cantidad;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public List<EquipoBE> listar_Equipos()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipos;
            SqlCommand cmd_equipos;
            String cadena;
            String sqlEquiposListar;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);
                sqlEquiposListar = "spListarEquipos";
                cmd_equipos = new SqlCommand(sqlEquiposListar, conexion);
                cmd_equipos.Connection.Open();
                dr_equipos = cmd_equipos.ExecuteReader();

                List<EquipoBE> lista_equipos;
                EquipoBE objEquipoBE;

                lista_equipos = new List<EquipoBE>();

                while (dr_equipos.Read())
                {
                    objEquipoBE = new EquipoBE();

                    objEquipoBE.NombreEquipo = dr_equipos.GetString(dr_equipos.GetOrdinal("Nombre"));

                    lista_equipos.Add(objEquipoBE);
                }

                cmd_equipos.Connection.Close();
                conexion.Dispose();

                return lista_equipos;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }
    }
}
