using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class EstadioDALC
    {
        public int insertar_Estadio(EstadioBE objEstadioBE)
        {
            String cadena;
            SqlConnection conexion = null;
            SqlCommand cmd_EstadioInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPais;
            SqlParameter prm_AnhoFundacion;
            SqlParameter prm_Nombre;
            SqlParameter prm_Ciudad;
            SqlParameter prm_Aforo;

            int iCodigoEstadio;

            String sqlEstadioInsertar;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);

                sqlEstadioInsertar = "spCreateEstadio";

                cmd_EstadioInsertar = new SqlCommand(sqlEstadioInsertar, conexion);
                cmd_EstadioInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoPais = new SqlParameter();
                prm_CodigoPais.ParameterName = "@CodPais";
                prm_CodigoPais.SqlDbType = SqlDbType.Int;
                prm_CodigoPais.Value = objEstadioBE.Codigo_pais;

                prm_AnhoFundacion = new SqlParameter();
                prm_AnhoFundacion.ParameterName = "@AnioFundacion";
                prm_AnhoFundacion.SqlDbType = SqlDbType.Int;
                prm_AnhoFundacion.Value = objEstadioBE.Anho_fundacion;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = objEstadioBE.Nombre_estadio;

                prm_Ciudad = new SqlParameter();
                prm_Ciudad.ParameterName = "@Ciudad";
                prm_Ciudad.SqlDbType = SqlDbType.VarChar;
                prm_Ciudad.Size = 20;
                prm_Ciudad.Value = objEstadioBE.Ciudad_estadio;

                prm_Aforo = new SqlParameter();
                prm_Aforo.ParameterName = "@Aforo";
                prm_Aforo.SqlDbType = SqlDbType.Int;
                prm_Aforo.Value = objEstadioBE.Aforo_estadio;

                cmd_EstadioInsertar.Parameters.Add(prm_Codigo);
                cmd_EstadioInsertar.Parameters.Add(prm_CodigoPais);
                cmd_EstadioInsertar.Parameters.Add(prm_AnhoFundacion);
                cmd_EstadioInsertar.Parameters.Add(prm_Nombre);
                cmd_EstadioInsertar.Parameters.Add(prm_Ciudad);
                cmd_EstadioInsertar.Parameters.Add(prm_Aforo);

                cmd_EstadioInsertar.Connection.Open();
                cmd_EstadioInsertar.ExecuteNonQuery();

                iCodigoEstadio = Convert.ToInt32(prm_Codigo.Value);

                cmd_EstadioInsertar.Connection.Close();
                conexion.Dispose();

                return iCodigoEstadio;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }
    }
}
