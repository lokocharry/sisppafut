using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class EstadioDALC
    {
        public int insertar_Estadio(EstadioBE objEstadioBE)
        {
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
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

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

        public List<EstadioBE> listar_Estadios()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_estadios;
            SqlCommand cmd_estadios;
            String sqlEstadiosListar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlEstadiosListar = "spListarEstadios";
                cmd_estadios = new SqlCommand(sqlEstadiosListar, conexion);
                cmd_estadios.Connection.Open();
                dr_estadios = cmd_estadios.ExecuteReader();

                List<EstadioBE> lista_estadios;
                EstadioBE objEstadioBE;

                lista_estadios = new List<EstadioBE>();

                while (dr_estadios.Read())
                {
                    objEstadioBE = new EstadioBE();

                    objEstadioBE.Codigo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodEstadio"));
                    objEstadioBE.Codigo_pais = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodPais"));
                    objEstadioBE.Anho_fundacion = dr_estadios.GetInt32(dr_estadios.GetOrdinal("AnioFundacion"));
                    objEstadioBE.Nombre_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Nombre"));
                    objEstadioBE.Ciudad_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Ciudad"));
                    objEstadioBE.Aforo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("Aforo"));

                    lista_estadios.Add(objEstadioBE);
                }

                cmd_estadios.Connection.Close();
                conexion.Dispose();

                return lista_estadios;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public List<EstadioBE> obtenerEstadioDeEquipo(int codigo_equipo)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_estadios;
            SqlCommand cmd_estadios;
            String sqlEstadiosListar;
            SqlParameter prm_equipo;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlEstadiosListar = "spListarEstadiosDeEquipo";

                cmd_estadios = new SqlCommand(sqlEstadiosListar, conexion);
                cmd_estadios.CommandType = CommandType.StoredProcedure;

                prm_equipo = new SqlParameter();
                prm_equipo.ParameterName = "@Codigo";
                prm_equipo.SqlDbType = SqlDbType.Int;
                prm_equipo.Value = codigo_equipo;

                cmd_estadios.Parameters.Add(prm_equipo);

                cmd_estadios.Connection.Open();
                dr_estadios = cmd_estadios.ExecuteReader();

                List<EstadioBE> lista_estadios;
                EstadioBE objEstadioBE;

                lista_estadios = new List<EstadioBE>();

                while (dr_estadios.Read())
                {
                    objEstadioBE = new EstadioBE();
                    
                    objEstadioBE.Codigo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodEstadio"));
                    objEstadioBE.Codigo_pais = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodPais"));
                    objEstadioBE.Anho_fundacion = dr_estadios.GetInt32(dr_estadios.GetOrdinal("AnioFundacion"));
                    objEstadioBE.Nombre_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Nombre"));
                    objEstadioBE.Ciudad_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Ciudad"));
                    objEstadioBE.Aforo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("Aforo"));

                    lista_estadios.Add(objEstadioBE);
                }

                cmd_estadios.Connection.Close();
                conexion.Dispose();

                return lista_estadios;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public List<EstadioBE> obtenerEstadioDePais(int codigo_pais)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_estadios;
            SqlCommand cmd_estadios;
            String sqlEstadiosListar;
            SqlParameter prm_pais;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlEstadiosListar = "spListarEstadiosDePais";

                cmd_estadios = new SqlCommand(sqlEstadiosListar, conexion);
                cmd_estadios.CommandType = CommandType.StoredProcedure;

                prm_pais = new SqlParameter();
                prm_pais.ParameterName = "@Codigo";
                prm_pais.SqlDbType = SqlDbType.Int;
                prm_pais.Value = codigo_pais;

                cmd_estadios.Parameters.Add(prm_pais);

                cmd_estadios.Connection.Open();
                dr_estadios = cmd_estadios.ExecuteReader();

                List<EstadioBE> lista_estadios;
                EstadioBE objEstadioBE;

                lista_estadios = new List<EstadioBE>();

                while (dr_estadios.Read())
                {
                    objEstadioBE = new EstadioBE();

                    objEstadioBE.Codigo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodEstadio"));
                    objEstadioBE.Codigo_pais = dr_estadios.GetInt32(dr_estadios.GetOrdinal("CodPais"));
                    objEstadioBE.Anho_fundacion = dr_estadios.GetInt32(dr_estadios.GetOrdinal("AnioFundacion"));
                    objEstadioBE.Nombre_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Nombre"));
                    objEstadioBE.Ciudad_estadio = dr_estadios.GetString(dr_estadios.GetOrdinal("Ciudad"));
                    objEstadioBE.Aforo_estadio = dr_estadios.GetInt32(dr_estadios.GetOrdinal("Aforo"));

                    lista_estadios.Add(objEstadioBE);
                }

                cmd_estadios.Connection.Close();
                conexion.Dispose();

                return lista_estadios;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }
    }
}
