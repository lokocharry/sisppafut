using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class ExcepcionDALC
    {
        public int ExcepcionInsertar(ExcepcionBE obj)
        {
            SqlConnection Conn = null;
            SqlCommand cmdExcepcionInsertar = null;
            String sqlExcepcionInsertar;

            SqlParameter prmCodExcepcion;
            SqlParameter prmMensaje;
            SqlParameter prmStackTrace;
            SqlParameter prmFechaCliente;
            SqlParameter prmCodUsuario;
            SqlParameter prmIPCliente;

            int iCodExcepcion;

            try
            {
                Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlExcepcionInsertar = "spCreateExcepcion";
                cmdExcepcionInsertar = Conn.CreateCommand();
                cmdExcepcionInsertar.CommandText = sqlExcepcionInsertar;
                cmdExcepcionInsertar.CommandType = CommandType.StoredProcedure;

                prmCodExcepcion = cmdExcepcionInsertar.CreateParameter();
                prmCodExcepcion.SqlDbType = SqlDbType.Int;
                prmCodExcepcion.Direction = ParameterDirection.ReturnValue;

                prmMensaje = cmdExcepcionInsertar.CreateParameter();
                prmMensaje.ParameterName = "@Mensaje";
                prmMensaje.SqlDbType = SqlDbType.VarChar;
                prmMensaje.Size = 8000;
                prmMensaje.Value = obj.Mensaje;

                prmStackTrace = cmdExcepcionInsertar.CreateParameter();
                prmStackTrace.ParameterName = "@StackTrace";
                prmStackTrace.SqlDbType = SqlDbType.VarChar;
                prmStackTrace.Size = 8000;
                prmStackTrace.Value = obj.StackTrace;

                prmFechaCliente = cmdExcepcionInsertar.CreateParameter();
                prmFechaCliente.ParameterName = "@FechaCliente";
                prmFechaCliente.SqlDbType = SqlDbType.DateTime;
                prmFechaCliente.Value = obj.FechaCliente;

                prmCodUsuario = cmdExcepcionInsertar.CreateParameter();
                prmCodUsuario.ParameterName = "@CodUsuario";
                prmCodUsuario.SqlDbType = SqlDbType.Int;
                prmCodUsuario.Value = obj.CodUsuario;

                prmIPCliente = cmdExcepcionInsertar.CreateParameter();
                prmIPCliente.ParameterName = "@IPCliente";
                prmIPCliente.SqlDbType = SqlDbType.VarChar;
                prmIPCliente.Size = 30;
                prmIPCliente.Value = obj.IPCliente;

                cmdExcepcionInsertar.Parameters.Add(prmCodExcepcion);
                cmdExcepcionInsertar.Parameters.Add(prmMensaje);
                cmdExcepcionInsertar.Parameters.Add(prmStackTrace);
                cmdExcepcionInsertar.Parameters.Add(prmFechaCliente);
                cmdExcepcionInsertar.Parameters.Add(prmCodUsuario);
                cmdExcepcionInsertar.Parameters.Add(prmIPCliente);

                cmdExcepcionInsertar.Connection.Open();
                cmdExcepcionInsertar.ExecuteNonQuery();
                iCodExcepcion = Convert.ToInt32(prmCodExcepcion.Value);
                cmdExcepcionInsertar.Connection.Close();

                cmdExcepcionInsertar.Dispose();
                Conn.Dispose();

                return iCodExcepcion;
            }
            catch (Exception ex)
            {
                cmdExcepcionInsertar.Dispose();
                Conn.Dispose();
                return 0;
            }
        }
    }
}
