using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class LogDALC
    {
        public int InsertarLogBE(LogBE obj)
        {
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEInsertar;

            SqlParameter codRegistro;
            SqlParameter codOperacion;
            SqlParameter tabla;
            SqlParameter usuario;
            //SqlParameter fecha;
            SqlParameter ip;
            SqlParameter razon;

            int iCod;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlLogBEInsertar = "spCreateLog";

                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEInsertar;
                cmd.CommandType = CommandType.StoredProcedure;

                codRegistro = cmd.CreateParameter();
                codRegistro.Direction = ParameterDirection.ReturnValue;
                codRegistro.SqlDbType = SqlDbType.Int;

                codOperacion = cmd.CreateParameter();
                codOperacion.ParameterName = "@CodOperacion";
                codOperacion.SqlDbType = SqlDbType.Int;
                codOperacion.SqlValue = obj.CodOperacion;

                tabla = cmd.CreateParameter();
                tabla.ParameterName = "@Tabla";
                tabla.SqlDbType = SqlDbType.VarChar;
                tabla.Size = 50;
                tabla.SqlValue = obj.Tabla;

                usuario = cmd.CreateParameter();
                usuario.ParameterName = "@Usuario";
                usuario.SqlDbType = SqlDbType.VarChar;
                usuario.Size = 20;
                usuario.SqlValue = obj.Usuario;

                //fecha = cmd.CreateParameter();
                //fecha.ParameterName = "@Fecha";
                //fecha.SqlDbType = SqlDbType.VarChar;
                //fecha.SqlValue = obj.Fecha;

                ip = cmd.CreateParameter();
                ip.ParameterName = "@IP";
                ip.SqlDbType = SqlDbType.VarChar;
                ip.Size = 23;
                ip.SqlValue = obj.IP;

                razon = cmd.CreateParameter();
                razon.ParameterName = "@Razon";
                razon.SqlDbType = SqlDbType.VarChar;
                razon.Size = 500;
                razon.SqlValue = obj.Razon;

                cmd.Parameters.Add(codRegistro);
                cmd.Parameters.Add(codOperacion);
                cmd.Parameters.Add(tabla);
                cmd.Parameters.Add(usuario);
                //cmd.Parameters.Add(fecha);
                cmd.Parameters.Add(ip);
                cmd.Parameters.Add(razon);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                iCod = Convert.ToInt32(codRegistro.Value);

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return iCod;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }

        public List<LogBE> ListarLogBE()
        {
            SqlDataReader dr;
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEListar;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlLogBEListar = "spListarLog";
                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEListar;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<LogBE> lst;
                lst = new List<LogBE>();

                LogBE obj;

                while (dr.Read())
                {
                    obj = new LogBE();
                    obj.CodRegistro = dr.GetInt32(dr.GetOrdinal("codRegistro"));
                    obj.CodOperacion = dr.GetInt32(dr.GetOrdinal("codOperacion"));
                    obj.Tabla = dr.GetString(dr.GetOrdinal("Tabla"));
                    obj.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    obj.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                    obj.IP = dr.GetString(dr.GetOrdinal("IP"));
                    obj.Razon = dr.GetString(dr.GetOrdinal("Razon"));

                    lst.Add(obj);
                }

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return lst;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }
                
        public List<LogBE> ListarLogBETabla(String Tabla)
        {
            SqlDataReader dr;
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEListar;
            SqlParameter tabla;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlLogBEListar = "uspLogListarTabla";
                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEListar;
                cmd.CommandType = CommandType.StoredProcedure;

                tabla = cmd.CreateParameter();
                tabla.ParameterName = "@Tabla";
                tabla.SqlDbType = SqlDbType.VarChar;
                tabla.Size = 50;
                tabla.SqlValue = Tabla;

                cmd.Parameters.Add(tabla);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<LogBE> lst;
                lst = new List<LogBE>();

                LogBE obj;

                while (dr.Read())
                {
                    obj = new LogBE();
                    obj.CodRegistro = dr.GetInt32(dr.GetOrdinal("codRegistro"));
                    obj.CodOperacion = dr.GetInt32(dr.GetOrdinal("codOperacion"));
                    obj.Tabla = dr.GetString(dr.GetOrdinal("Tabla"));
                    obj.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    obj.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                    obj.IP = dr.GetString(dr.GetOrdinal("IP"));
                    obj.Razon = dr.GetString(dr.GetOrdinal("Razon"));

                    lst.Add(obj);
                }

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return lst;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }

        public List<LogBE> ListarLogBEUsuario(String Usuario)
        {
            SqlDataReader dr;
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEListar;
            SqlParameter usuario;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlLogBEListar = "uspLogListarUsuario";
                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEListar;
                cmd.CommandType = CommandType.StoredProcedure;

                usuario = cmd.CreateParameter();
                usuario.ParameterName = "@Usuario";
                usuario.SqlDbType = SqlDbType.VarChar;
                usuario.Size = 50;
                usuario.SqlValue = Usuario;

                cmd.Parameters.Add(usuario);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<LogBE> lst;
                lst = new List<LogBE>();

                LogBE obj;

                while (dr.Read())
                {
                    obj = new LogBE();
                    obj.CodRegistro = dr.GetInt32(dr.GetOrdinal("codRegistro"));
                    obj.CodOperacion = dr.GetInt32(dr.GetOrdinal("codOperacion"));
                    obj.Tabla = dr.GetString(dr.GetOrdinal("Tabla"));
                    obj.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    obj.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                    obj.IP = dr.GetString(dr.GetOrdinal("IP"));
                    obj.Razon = dr.GetString(dr.GetOrdinal("Razon"));

                    lst.Add(obj);
                }

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return lst;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }

        public List<LogBE> ListarLogBEFecha(DateTime Fecha)
        {
            SqlDataReader dr;
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEListar;
            SqlParameter fecha;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlLogBEListar = "uspLogListarFecha";
                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEListar;
                cmd.CommandType = CommandType.StoredProcedure;

                fecha = cmd.CreateParameter();
                fecha.ParameterName = "@Fecha";
                fecha.SqlDbType = SqlDbType.DateTime;
                fecha.SqlValue = Fecha;

                cmd.Parameters.Add(fecha);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<LogBE> lst;
                lst = new List<LogBE>();

                LogBE obj;

                while (dr.Read())
                {
                    obj = new LogBE();
                    obj.CodRegistro = dr.GetInt32(dr.GetOrdinal("codRegistro"));
                    obj.CodOperacion = dr.GetInt32(dr.GetOrdinal("codOperacion"));
                    obj.Tabla = dr.GetString(dr.GetOrdinal("Tabla"));
                    obj.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    obj.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                    obj.IP = dr.GetString(dr.GetOrdinal("IP"));
                    obj.Razon = dr.GetString(dr.GetOrdinal("Razon"));

                    lst.Add(obj);
                }

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return lst;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }

        public List<LogBE> ListarLogBEIP(String IP)
        {
            SqlDataReader dr;
            SqlConnection Conn = null;
            SqlCommand cmd = null;
            String sqlLogBEListar;
            SqlParameter ip;

            try
            {
                Conn = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlLogBEListar = "uspLogListarIP";
                cmd = Conn.CreateCommand();
                cmd.CommandText = sqlLogBEListar;
                cmd.CommandType = CommandType.StoredProcedure;

                ip = cmd.CreateParameter();
                ip.ParameterName = "@IP";
                ip.SqlDbType = SqlDbType.VarChar;
                ip.Size = 23;
                ip.SqlValue = IP;

                cmd.Parameters.Add(ip);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<LogBE> lst;
                lst = new List<LogBE>();

                LogBE obj;

                while (dr.Read())
                {
                    obj = new LogBE();
                    obj.CodRegistro = dr.GetInt32(dr.GetOrdinal("codRegistro"));
                    obj.CodOperacion = dr.GetInt32(dr.GetOrdinal("codOperacion"));
                    obj.Tabla = dr.GetString(dr.GetOrdinal("Tabla"));
                    obj.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    obj.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                    obj.IP = dr.GetString(dr.GetOrdinal("IP"));
                    obj.Razon = dr.GetString(dr.GetOrdinal("Razon"));

                    lst.Add(obj);
                }

                cmd.Connection.Close();

                cmd.Dispose();
                Conn.Dispose();

                return lst;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Conn.Dispose();
                throw ex;
            }
        }
    }
}
