using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class LigaEquipoDALC
    {
        public void insertar_LigaEquipo(LigaEquipoBE objLigaEquipoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_EquipoInsertarEnLiga = null;

            SqlParameter prm_CodigoLiga;
            SqlParameter prm_CodigoEquipo;

            String sqlEquipoInsertarEnLiga;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlEquipoInsertarEnLiga = "spCreateLigaEquipo";

                cmd_EquipoInsertarEnLiga = new SqlCommand(sqlEquipoInsertarEnLiga, conexion);
                cmd_EquipoInsertarEnLiga.CommandType = CommandType.StoredProcedure;

                prm_CodigoLiga = new SqlParameter();
                prm_CodigoLiga.ParameterName = "@codLiga";
                prm_CodigoLiga.SqlDbType = SqlDbType.Int;
                prm_CodigoLiga.Value = objLigaEquipoBE.CodigoLiga;

                prm_CodigoEquipo = new SqlParameter();
                prm_CodigoEquipo.ParameterName = "@codEquipo";
                prm_CodigoEquipo.SqlDbType = SqlDbType.Int;
                prm_CodigoEquipo.Value = objLigaEquipoBE.CodigoEquipo;

                cmd_EquipoInsertarEnLiga.Parameters.Add(prm_CodigoLiga);
                cmd_EquipoInsertarEnLiga.Parameters.Add(prm_CodigoEquipo);

                cmd_EquipoInsertarEnLiga.Connection.Open();
                cmd_EquipoInsertarEnLiga.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd_EquipoInsertarEnLiga.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
