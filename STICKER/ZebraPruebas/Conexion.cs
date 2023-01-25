using System;
using System.Data;
using System.Data.SqlClient;

namespace ZebraPruebas
{
    class Conexion
    {
        SqlConnection cnn;
        String Comando;
        SqlCommand cmd;
        private String Url;
        public String Error;
        SqlDataAdapter Adapter;
        public DataSet data;
        public SqlDataReader Reader;

        public Conexion(String Comando)
        {
            Url = @"Server=192.168.1.127\SQLEXPRESS;Database=INMODANET;Trusted_Connection=no;Uid=Hgi;Pwd=Hgi;";
            this.Comando = Comando;
            cnn = new SqlConnection(Url);
            cmd = new SqlCommand(Comando, cnn);
            data = new DataSet();
        }
        public Boolean EjecutarQuery()
        {

            try
            {
                cmd.Connection.Open();
                Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                Error = e.Message;
                return false;
            }


        }
        public Boolean EjecutarReader()
        {

            try
            {
                try
                {
                    cnn.Open();
                    cmd = new SqlCommand(Comando, cnn);
                    Reader = cmd.ExecuteReader();
                    return true;
                }
                catch (SqlException e)
                {
                    cnn.Close();
                    Error = e.Message;
                    return false;
                }
            }
            catch (Exception e)
            {
                cnn.Close();
                Error = e.Message;
                return false;
            }


        }
        public Boolean EjecutarNonQuery()
        {
            try
            {
                try
                {
                    cnn.Open();
                    cmd = new SqlCommand(Comando, cnn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    cnn.Close();
                    Error = e.Message;
                    return false;
                }
            }
            catch (Exception e)
            {
                cnn.Close();
                Error = e.Message;
                return false;
            }
        }
        public void CerrarConexion()
        {
            cnn.Close();
        }
    }
}
