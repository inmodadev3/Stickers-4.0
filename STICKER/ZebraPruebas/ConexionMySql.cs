using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ZebraPruebas
{
    class ConexionMySql
    {
        private MySqlConnection con;
        public String Error;

        public ConexionMySql()
        {
            try
            {
                //con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=dash;");
                con = new MySqlConnection("datasource=10.10.10.128;port=3306;username=root;password=Sistemas2018*;database=dash;");
            }
            catch (Exception e)
            {
                Error = e.ToString();
            }


        }

        public MySqlConnection GetCxn()
        {
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        public MySqlDataReader ConsultarDetalleCompra(int sql, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ConsultarDetalleCompra", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdEstado", sql);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }

        }

        public int ActualizarDetalleCompra(MySqlConnection con, int idDetalle, string txtDescripcion, string txtReferencia, int txtPrecio1, int txtPrecio2, int txtPrecio3, int txtPrecio4, int txtPrecio5, int txtCantidad, string txtUDM, int intEstado, string txtDimension, int txtCantPaca, string txtMaterial, string txtSexo, string txtMarca, string txtObservacion)
        {
            int rpta = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ActualizarRefDetalleCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdDetalle", idDetalle);
                cmd.Parameters.AddWithValue("@strDescripcion", txtDescripcion);
                cmd.Parameters.AddWithValue("@intPrecioUno", txtPrecio1);
                cmd.Parameters.AddWithValue("@intPrecioDos", txtPrecio2);
                cmd.Parameters.AddWithValue("@intPrecioTres", txtPrecio3);
                cmd.Parameters.AddWithValue("@intPrecioCuatro", txtPrecio4);
                cmd.Parameters.AddWithValue("@intPrecioCinco", txtPrecio5);
                cmd.Parameters.AddWithValue("@strReferencia", txtReferencia);
                cmd.Parameters.AddWithValue("@intCantidad", null);//EN EL PROC SE VALIDA SI ES NULL PARA NO ACTUALIZARLO
                cmd.Parameters.AddWithValue("@strUDM", txtUDM);//NO SE USA EN EL PROC
                cmd.Parameters.AddWithValue("@intEstado", intEstado);
                cmd.Parameters.AddWithValue("@strDimension", txtDimension);

                cmd.Parameters.AddWithValue("@intCxU", txtCantidad);
                cmd.Parameters.AddWithValue("@strUnidadMedida", txtUDM);
                cmd.Parameters.AddWithValue("@intCantidadPaca", txtCantPaca);
                cmd.Parameters.AddWithValue("@strMaterial", txtMaterial);
                cmd.Parameters.AddWithValue("@strObservacion", txtObservacion);
                cmd.Parameters.AddWithValue("@strSexo", txtSexo);
                cmd.Parameters.AddWithValue("@strMarca", txtMarca);



                //manda el parametro de dmension

                rpta = cmd.ExecuteNonQuery();
                return rpta;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return rpta;
            }
        }

        public MySqlDataReader ConsultarPreciosEmpresa(MySqlConnection con, int precio1, int udm)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ConsultarPrecioEmpresa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intPrecio1", precio1);
                cmd.Parameters.AddWithValue("@intUDM", udm);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }



        public int Operar(string query, MySqlConnection con)
        {
            int rpta = -1;
            try
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, con);
                rpta = commandDatabase.ExecuteNonQuery();
                return rpta;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return rpta;
            }
        }

        public void CerrarCnx()
        {
            con.Close();
        }

        public MySqlDataReader ConsultarLoteReferenciaCompra(int idReferenciaDetalle, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ConsultarLoteReferenciaCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdDocumentoCompraDetalle", idReferenciaDetalle);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        public MySqlDataReader Validarlogin(string user, string password, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ValidarLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strUsuario", user);
                cmd.Parameters.AddWithValue("@strClave", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        public MySqlDataReader ConsultarEncabezadoPedidos(int intEstado, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ConsultarEncabezadoPedidosPorEstado", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intEstado", intEstado);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }

        }

        public MySqlDataReader ActualizarEstadoPedido(int id, int documento, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ActualizarEstadoPedido", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intId", id);
                cmd.Parameters.AddWithValue("@intDocumentoHgi", documento);
                cmd.Parameters.AddWithValue("@intEstado", 4);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }

        }

        public MySqlDataReader FiltrarEncabezadoPedidos(string txt, int estado, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_FiltrarEncabezadoPedidos", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strFiltro", txt);
                cmd.Parameters.AddWithValue("@intEstado", estado);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }

        }

        public MySqlDataReader ConsultarInformacionContenedor(string query, MySqlConnection con)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        public MySqlDataReader InsertarAuditoria(string usuario, string campo, string producto, string valorAnt, string valorNuevo, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_InsertarAuditoria", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strUsuario", usuario);
                cmd.Parameters.AddWithValue("@strProducto", producto);
                cmd.Parameters.AddWithValue("@strCampo", campo);
                cmd.Parameters.AddWithValue("@strValorAnterior", valorAnt);
                cmd.Parameters.AddWithValue("@strValorNuevo", valorNuevo);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        public MySqlDataReader ConsultarLoteReferencia(string strReferencia, MySqlConnection con)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_ConsultarLoteReferencia", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strReferencia", strReferencia);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return null;
            }

        }

        public int RegistrarLoteReferencia(MySqlConnection con, string txtReferencia, string txtColor, string txtEstilo)
        {
            int rpta = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand("SP_RegistrarLoteReferencia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strReferencia", txtReferencia);
                cmd.Parameters.AddWithValue("@strColor", txtColor);
                cmd.Parameters.AddWithValue("@strEstilo", txtEstilo);


                //manda el parametro de dmension

                rpta = cmd.ExecuteNonQuery();
                return rpta;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return rpta;
            }
        }

    }
}

