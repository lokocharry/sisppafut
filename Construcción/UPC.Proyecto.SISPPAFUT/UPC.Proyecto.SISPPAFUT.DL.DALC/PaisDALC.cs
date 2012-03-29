using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class PaisDALC
    {
        public int insertar_Pais(PaisBE objPaisBE)
        {
            String cadena;
            SqlConnection conexion = null;
            SqlCommand cmd_PaisInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_Nombre;

            int iCodigoPais;

            String sqlPaisInsertar;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);

                sqlPaisInsertar = "spCreatePais";

                cmd_PaisInsertar = new SqlCommand(sqlPaisInsertar, conexion);
                cmd_PaisInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = objPaisBE.NombrePais;

                cmd_PaisInsertar.Parameters.Add(prm_Codigo);
                cmd_PaisInsertar.Parameters.Add(prm_Nombre);

                cmd_PaisInsertar.Connection.Open();
                cmd_PaisInsertar.ExecuteNonQuery();

                iCodigoPais = Convert.ToInt32(prm_Codigo.Value);

                cmd_PaisInsertar.Connection.Close();

                conexion.Dispose();

                return iCodigoPais;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public int existe_Pais(String nombre)
        {
            String cadena;
            SqlConnection conexion = null;
            SqlDataReader dr_pais;
            SqlCommand cmd_PaisValidar;
            String sqlPaisValidar;
            SqlParameter prm_Nombre;

            int cantidad = 0;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);
                sqlPaisValidar = "spPaisVerificarRepetido";

                cmd_PaisValidar = new SqlCommand(sqlPaisValidar, conexion);
                cmd_PaisValidar.CommandType = CommandType.StoredProcedure;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = nombre;

                cmd_PaisValidar.Parameters.Add(prm_Nombre);

                cmd_PaisValidar.Connection.Open();
                dr_pais = cmd_PaisValidar.ExecuteReader();

                if(dr_pais.Read())
                {
                    cantidad = dr_pais.GetInt32(dr_pais.GetOrdinal("Cantidad"));
                }

                cmd_PaisValidar.Connection.Close();
                conexion.Dispose();

                return cantidad;
            }

            catch(Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public List<PaisBE> listar_Paises()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_paises;
            SqlCommand cmd_paises;
            String cadena;
            String sqlPaisesListar;

            try
            {
                cadena = "server=(local); database=SISPPAFUT; User Id=sa; Pwd=password";
                conexion = new SqlConnection(cadena);
                sqlPaisesListar = "spListarPaises";
                cmd_paises = new SqlCommand(sqlPaisesListar, conexion);
                cmd_paises.Connection.Open();
                dr_paises = cmd_paises.ExecuteReader();

                List<PaisBE> lista_paises;
                PaisBE objPaisBE;

                lista_paises = new List<PaisBE>();

                while (dr_paises.Read())
                {
                    objPaisBE = new PaisBE();

                    objPaisBE.NombrePais = dr_paises.GetString(dr_paises.GetOrdinal("Nombre"));

                    lista_paises.Add(objPaisBE);
                }

                cmd_paises.Connection.Close();
                conexion.Dispose();

                return lista_paises;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }
    }
}