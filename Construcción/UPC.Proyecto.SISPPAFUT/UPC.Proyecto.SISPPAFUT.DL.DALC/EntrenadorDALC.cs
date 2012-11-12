using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class EntrenadorDALC
    {
        public int RegistrarEntrenador(EntrenadorBE objEntrenadorBE)
        {
            SqlConnection conexion;
            SqlCommand cmd;
            String spCreateEntrenador = "";

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                spCreateEntrenador = "spCreateEntrenador";
                cmd = new SqlCommand(spCreateEntrenador, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmCodEntrenador = new SqlParameter();
                prmCodEntrenador.SqlDbType = SqlDbType.Int;
                prmCodEntrenador.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmNombres = new SqlParameter();
                prmNombres.ParameterName = "@Nombres";
                prmNombres.SqlDbType = SqlDbType.VarChar;
                prmNombres.Size = 20;
                prmNombres.Value = objEntrenadorBE.Nombres;

                SqlParameter prmApellidos = new SqlParameter();
                prmApellidos.ParameterName = "@Apellidos";
                prmApellidos.SqlDbType = SqlDbType.VarChar;
                prmApellidos.Size = 20;
                prmApellidos.Value = objEntrenadorBE.Apellidos;

                SqlParameter prmNacionalidad = new SqlParameter();
                prmNacionalidad.ParameterName = "@Nacionalidad";
                prmNacionalidad.SqlDbType = SqlDbType.VarChar;
                prmNacionalidad.Size = 20;
                prmNacionalidad.Value = objEntrenadorBE.Nacionalidad;

                SqlParameter prmFecha = new SqlParameter();
                prmFecha.SqlDbType = SqlDbType.DateTime;
                prmFecha.ParameterName = "@FechaNacimiento";
                prmFecha.Value = objEntrenadorBE.Fecha;

                cmd.Parameters.Add(prmCodEntrenador);
                cmd.Parameters.Add(prmNombres);
                cmd.Parameters.Add(prmApellidos);
                cmd.Parameters.Add(prmNacionalidad);
                cmd.Parameters.Add(prmFecha);

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                int codigo = int.Parse(prmCodEntrenador.Value.ToString());

                cmd.Connection.Close();
                cmd.Connection.Dispose();

                return codigo;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarEntrenador(EntrenadorBE objEntrenadorBE)
        {
            SqlConnection conexion;
            SqlCommand cmd;
            String spUpdateEntrenador = "";

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                spUpdateEntrenador = "spUpdateEntrenador";
                cmd = new SqlCommand(spUpdateEntrenador, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmCodEntrenador = new SqlParameter();
                prmCodEntrenador.ParameterName = "@CodEntrenador";
                prmCodEntrenador.SqlDbType = SqlDbType.Int;
                prmCodEntrenador.Value = objEntrenadorBE.CodEntrenador;

                SqlParameter prmFecha = new SqlParameter();
                prmFecha.SqlDbType = SqlDbType.DateTime;
                prmFecha.ParameterName = "@FechaNacimiento";
                prmFecha.Value = objEntrenadorBE.Fecha;

                cmd.Parameters.Add(prmCodEntrenador);
                cmd.Parameters.Add(prmFecha);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                cmd.Connection.Dispose();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EntrenadorBE> ListarEntrenadores()
        {
            SqlConnection conexion;
            SqlCommand cmd;
            String spLeerEntrenadores;
            SqlDataReader dr;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                spLeerEntrenadores = "spListarEntrenadores";
                cmd = new SqlCommand(spLeerEntrenadores, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<EntrenadorBE> lst_entrenadores = new List<EntrenadorBE>();
                EntrenadorBE objEntrenadorBE;

                while (dr.Read())
                {
                    objEntrenadorBE = new EntrenadorBE();
                    objEntrenadorBE.CodEntrenador = dr.GetInt32(dr.GetOrdinal("CodEntrenador"));
                    objEntrenadorBE.Apellidos = dr.GetString(dr.GetOrdinal("Apellidos"));
                    objEntrenadorBE.Nombres = dr.GetString(dr.GetOrdinal("Nombres"));
                    objEntrenadorBE.Fecha = dr.GetDateTime(dr.GetOrdinal("FechaNacimiento"));
                    objEntrenadorBE.Nacionalidad = dr.GetString(dr.GetOrdinal("Nacionalidad"));

                    lst_entrenadores.Add(objEntrenadorBE);
                }

                cmd.Connection.Close();
                cmd.Connection.Dispose();

                return lst_entrenadores;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
