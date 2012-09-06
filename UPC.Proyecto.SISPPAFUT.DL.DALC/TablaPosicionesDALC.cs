using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class TablaPosicionesDALC
    {
        public int insertar_Tabla(TablaPosicionesBE objBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;

            SqlParameter CodTabla;
            SqlParameter CodLiga;
            SqlParameter CodEquipo;
            SqlParameter PuntosLocal;
            SqlParameter PartidosJugadosLocal;
            SqlParameter VictoriasLocal;
            SqlParameter EmpatesLocal;
            SqlParameter DerrotasLocal;
            SqlParameter GolesAnotadosLocal;
            SqlParameter GolesEncajadosLocal;
            SqlParameter PuntosVisita;
            SqlParameter PartidosJugadosVisita;
            SqlParameter VictoriasVisita;
            SqlParameter EmpatesVisita;
            SqlParameter DerrotasVisita;
            SqlParameter GolesAnotadosVisita;
            SqlParameter GolesEncajadosVisita;

            int iCodTabla;

            String sql;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sql = "spInsertarEquipoTablaPosiciones";

                cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                CodTabla = new SqlParameter();
                CodTabla.Direction = ParameterDirection.ReturnValue;
                CodTabla.SqlDbType = SqlDbType.Int;

                CodLiga = new SqlParameter();
                CodLiga.ParameterName = "@CodLiga";
                CodLiga.SqlDbType = SqlDbType.Int;
                CodLiga.Value = objBE.codLiga;

                CodEquipo = new SqlParameter();
                CodEquipo.ParameterName = "@CodEquipo";
                CodEquipo.SqlDbType = SqlDbType.Int;
                CodEquipo.Value = objBE.codEquipo;

                PuntosLocal = new SqlParameter();
                PuntosLocal.ParameterName = "@PuntosLocal";
                PuntosLocal.SqlDbType = SqlDbType.Int;
                PuntosLocal.Value = objBE.puntosLocal;

                PartidosJugadosLocal = new SqlParameter();
                PartidosJugadosLocal.ParameterName = "@PartidosJugadosLocal";
                PartidosJugadosLocal.SqlDbType = SqlDbType.Int;
                PartidosJugadosLocal.Value = objBE.partidosJugadosLocal;

                VictoriasLocal = new SqlParameter();
                VictoriasLocal.ParameterName = "@VictoriasLocal";
                VictoriasLocal.SqlDbType = SqlDbType.Int;
                VictoriasLocal.Value = objBE.victoriasLocal;

                EmpatesLocal = new SqlParameter();
                EmpatesLocal.ParameterName = "@EmpatesLocal";
                EmpatesLocal.SqlDbType = SqlDbType.Bit;
                EmpatesLocal.Value = objBE.empatesLocal;

                DerrotasLocal = new SqlParameter();
                DerrotasLocal.ParameterName = "@DerrotasLocal";
                DerrotasLocal.SqlDbType = SqlDbType.Int;
                DerrotasLocal.Value = objBE.derrotasLocal;

                GolesAnotadosLocal = new SqlParameter();
                GolesAnotadosLocal.ParameterName = "@GolesAnotadosLocal";
                GolesAnotadosLocal.SqlDbType = SqlDbType.Bit;
                GolesAnotadosLocal.Value = objBE.golesAnotadosLocal;

                GolesEncajadosLocal = new SqlParameter();
                GolesEncajadosLocal.ParameterName = "@GolesEncajadosLocal";
                GolesEncajadosLocal.SqlDbType = SqlDbType.Bit;
                GolesEncajadosLocal.Value = objBE.golesEncajadosLocal;

                PuntosVisita = new SqlParameter();
                PuntosVisita.ParameterName = "@PuntosVisita";
                PuntosVisita.SqlDbType = SqlDbType.Int;
                PuntosVisita.Value = objBE.puntosVisita;

                PartidosJugadosVisita = new SqlParameter();
                PartidosJugadosVisita.ParameterName = "@PartidosJugadosVisita";
                PartidosJugadosVisita.SqlDbType = SqlDbType.Int;
                PartidosJugadosVisita.Value = objBE.partidosJugadosVisita;

                VictoriasVisita = new SqlParameter();
                VictoriasVisita.ParameterName = "@VictoriasVisita";
                VictoriasVisita.SqlDbType = SqlDbType.Int;
                VictoriasVisita.Value = objBE.victoriasVisita;

                EmpatesVisita = new SqlParameter();
                EmpatesVisita.ParameterName = "@EmpatesVisita";
                EmpatesVisita.SqlDbType = SqlDbType.Int;
                EmpatesVisita.Value = objBE.empatesVisita;

                DerrotasVisita = new SqlParameter();
                DerrotasVisita.ParameterName = "@DerrotasVisita";
                DerrotasVisita.SqlDbType = SqlDbType.Decimal;
                DerrotasVisita.Value = objBE.derrotasVisita;

                GolesAnotadosVisita = new SqlParameter();
                GolesAnotadosVisita.ParameterName = "@GolesAnotadosVisita";
                GolesAnotadosVisita.SqlDbType = SqlDbType.Int;
                GolesAnotadosVisita.Value = objBE.golesAnotadosVisita;

                GolesEncajadosVisita = new SqlParameter();
                GolesEncajadosVisita.ParameterName = "@GolesEncajadosVisita";
                GolesEncajadosVisita.SqlDbType = SqlDbType.Int;
                GolesEncajadosVisita.Value = objBE.golesEncajadosVisita;

                cmd.Parameters.Add(CodTabla);
                cmd.Parameters.Add(CodLiga);
                cmd.Parameters.Add(CodEquipo);
                cmd.Parameters.Add(PuntosLocal);
                cmd.Parameters.Add(PartidosJugadosLocal);
                cmd.Parameters.Add(VictoriasLocal);
                cmd.Parameters.Add(EmpatesLocal);
                cmd.Parameters.Add(DerrotasLocal);
                cmd.Parameters.Add(GolesAnotadosLocal);
                cmd.Parameters.Add(GolesEncajadosLocal);
                cmd.Parameters.Add(PuntosVisita);
                cmd.Parameters.Add(PartidosJugadosVisita);
                cmd.Parameters.Add(VictoriasVisita);
                cmd.Parameters.Add(EmpatesVisita);
                cmd.Parameters.Add(DerrotasVisita);
                cmd.Parameters.Add(GolesAnotadosVisita);
                cmd.Parameters.Add(GolesEncajadosVisita);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                iCodTabla = Convert.ToInt32(CodTabla.Value);

                return iCodTabla;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public List<TablaPosicionesBE> ObtenerTablaLiga(int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr;
            SqlCommand cmd = null;
            String sqlTabla;
            SqlParameter prm_codLiga;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlTabla = "spPosicionEquipoTabla";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sqlTabla;
                cmd.CommandType = CommandType.StoredProcedure;

                prm_codLiga = new SqlParameter();
                prm_codLiga.ParameterName = "@CodLiga";
                prm_codLiga.SqlDbType = SqlDbType.Int;
                prm_codLiga.Value = codLiga;

                cmd.Parameters.Add(prm_codLiga);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<TablaPosicionesBE> lstTablaLiga;
                TablaPosicionesBE objTablaBE;

                lstTablaLiga = new List<TablaPosicionesBE>();

                while (dr.Read())
                {
                    objTablaBE = new TablaPosicionesBE();

                    objTablaBE.codEquipo = dr.GetInt32(dr.GetOrdinal("CodEquipo"));
                    objTablaBE.codLiga = dr.GetInt32(dr.GetOrdinal("CodLiga"));
                    objTablaBE.codTabla = dr.GetInt32(dr.GetOrdinal("CodTabla"));
                    objTablaBE.derrotasLocal = dr.GetInt32(dr.GetOrdinal("DerrotasLocal"));
                    objTablaBE.derrotasVisita = dr.GetInt32(dr.GetOrdinal("DerrotasVisita"));
                    objTablaBE.empatesLocal = dr.GetInt32(dr.GetOrdinal("EmpatesLocal"));
                    objTablaBE.empatesVisita = dr.GetInt32(dr.GetOrdinal("EmpatesVisita"));
                    objTablaBE.golesAnotadosLocal = dr.GetInt32(dr.GetOrdinal("GolesAnotadosLocal"));
                    objTablaBE.golesAnotadosVisita = dr.GetInt32(dr.GetOrdinal("GolesAnotadosVisita"));
                    objTablaBE.golesEncajadosLocal = dr.GetInt32(dr.GetOrdinal("GolesEncajadosLocal"));
                    objTablaBE.golesEncajadosVisita = dr.GetInt32(dr.GetOrdinal("GolesEncajadosVisita"));
                    objTablaBE.partidosJugadosLocal = dr.GetInt32(dr.GetOrdinal("PartidosJugadosLocal"));
                    objTablaBE.partidosJugadosVisita = dr.GetInt32(dr.GetOrdinal("PartidosJugadosVisita"));
                    objTablaBE.posicion = dr.GetInt32(dr.GetOrdinal("Posicion"));
                    objTablaBE.puntosLocal = dr.GetInt32(dr.GetOrdinal("PuntosLocal"));
                    objTablaBE.puntosVisita = dr.GetInt32(dr.GetOrdinal("PuntosVisita"));
                    objTablaBE.victoriasLocal = dr.GetInt32(dr.GetOrdinal("VictoriasLocal"));
                    objTablaBE.victoriasVisita = dr.GetInt32(dr.GetOrdinal("VictoriasVisita"));

                    lstTablaLiga.Add(objTablaBE);
                }

                return lstTablaLiga;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
