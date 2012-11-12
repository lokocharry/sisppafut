using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
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
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

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

        public List<CompeticionBE> listar_Competicion(String Pais)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_Competicion;
            SqlCommand cmd;
            String sqlCompeticionesListar;
            SqlParameter _Pais;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlCompeticionesListar = "spListarCompeticion";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sqlCompeticionesListar;
                cmd.CommandType = CommandType.StoredProcedure;

                _Pais = cmd.CreateParameter();
                _Pais.ParameterName = "@Pais";
                _Pais.SqlDbType = SqlDbType.VarChar;
                _Pais.Size = 20;
                _Pais.SqlValue = Pais;

                cmd.Parameters.Add(_Pais);

                cmd.Connection.Open();
                dr_Competicion = cmd.ExecuteReader();

                List<CompeticionBE> lst;
                CompeticionBE objCompeticionBE;

                lst = new List<CompeticionBE>();

                while (dr_Competicion.Read())
                {
                    objCompeticionBE = new CompeticionBE();

                    objCompeticionBE.Codigo_competicion = dr_Competicion.GetInt32(dr_Competicion.GetOrdinal("CodCompeticion"));
                    objCompeticionBE.Nombre_competicion = dr_Competicion.GetString(dr_Competicion.GetOrdinal("Nombre"));

                    lst.Add(objCompeticionBE);
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return lst;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }
    }
}
