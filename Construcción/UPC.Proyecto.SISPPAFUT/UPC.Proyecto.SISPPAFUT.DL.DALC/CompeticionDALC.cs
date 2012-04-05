using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class CompeticionDALC
    {
        public int insertar_Competicion(CompeticionBE objCompeticionBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_CompeticionInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPais;
            SqlParameter prm_Nombre;

            int iCodigoCompeticion;

            String sqlCompeticionInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlCompeticionInsertar = "spCreateCompeticion";

                cmd_CompeticionInsertar = new SqlCommand(sqlCompeticionInsertar, conexion);
                cmd_CompeticionInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoPais = new SqlParameter();
                prm_CodigoPais.ParameterName = "@CodPais";
                prm_CodigoPais.SqlDbType = SqlDbType.Int;
                prm_CodigoPais.Value = objCompeticionBE.Codigo_pais;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = objCompeticionBE.Nombre_competicion;

                cmd_CompeticionInsertar.Parameters.Add(prm_Codigo);
                cmd_CompeticionInsertar.Parameters.Add(prm_CodigoPais);
                cmd_CompeticionInsertar.Parameters.Add(prm_Nombre);

                cmd_CompeticionInsertar.Connection.Open();
                cmd_CompeticionInsertar.ExecuteNonQuery();

                iCodigoCompeticion = Convert.ToInt32(prm_Codigo.Value);

                cmd_CompeticionInsertar.Connection.Close();
                conexion.Dispose();

                return iCodigoCompeticion;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }
         
    }
}
