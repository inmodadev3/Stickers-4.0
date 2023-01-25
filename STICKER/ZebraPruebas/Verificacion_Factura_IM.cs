using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Verificacion_Factura_IM : Form
    {
        DataTable tabla = new DataTable();
        string tercero;
        int numDocumentoFactura;

        public Verificacion_Factura_IM()
        {
            InitializeComponent();
            GenerarTabla();
            CargarDatosPanel1();
            CargarDatosPanel2();
            AgregarImpresoras();
        }

        private void AgregarImpresoras()
        {
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Items.Add(strPrinter);
            }
            Impresoras.SelectedIndex = (Impresoras.Items.Count - 1);
        }

        private void Verificacion_Factura_IM_Load(object sender, EventArgs e)
        {

        }

        private void GenerarTabla()
        {
            tabla.Columns.Add("Id");
            tabla.Columns.Add("Columna 2");
        }

        private void CargarDatosPanel1()
        {
            try
            {
                ConexionMySql con = new ConexionMySql();
                MySqlDataReader rpta = con.ConsultarEncabezadoPedidos(3, con.GetCxn());
                tabla.Rows.Clear();

                dataGridView1.Rows.Clear();
                string tipo;
                if (rpta == null)
                {
                    MessageBox.Show("..." + con.Error);
                    lblRpta.Text = con.Error;
                    //lblRpta.Visible = true;
                }
                else
                {
                    if (rpta.HasRows)
                    {
                        int i = 0;
                        while (rpta.Read())
                        {
                            tipo = rpta.GetString(16);
                            if (tipo.Equals("0"))
                            {
                                dataGridView1.Rows.Add(new string[] { rpta.GetString(0), rpta.GetString(4), rpta.GetString(5) });
                                i++;
                            }
                        }
                    }
                    else
                    {
                        lblRpta.Text = "No se encontro nada";
                        //lblRpta.Visible = true;
                    }
                }
                con.CerrarCnx();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error D..." + ex);
            }
        }

        private void CargarDatosPanel2()
        {
            try
            {
                ConexionMySql con = new ConexionMySql();
                MySqlDataReader rpta = con.ConsultarEncabezadoPedidos(4, con.GetCxn());

                dataGridView2.Rows.Clear();
                string tipo;
                if (rpta == null)
                {
                    MessageBox.Show("deiby..." + con.Error);
                    lblRpta.Text = con.Error;
                    //lblRpta.Visible = true;
                }
                else
                {
                    if (rpta.HasRows)
                    {
                        int i = 0;
                        while (rpta.Read())
                        {
                            tipo = rpta.GetString(16);
                            if (tipo.Equals("0"))
                            {
                                dataGridView2.Rows.Add(new string[] { rpta.GetString(0), rpta.GetString(5), rpta.GetString(7) });
                                i++;
                            }
                        }
                    }
                    else
                    {
                        lblRpta.Text = "No se encontro nada";
                        //lblRpta.Visible = true;
                    }
                }
                con.CerrarCnx();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error D..." + ex);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.ToString().Equals("4"))
            {
                int fila = e.RowIndex;
                //MessageBox.Show((dataGridView1.Rows[fila].Cells["txtTransaccion"].Value.ToString()));
                string transaccion = (dataGridView1.Rows[fila].Cells["txtTransaccion"].Value.ToString());
                int documento = Int32.Parse(dataGridView1.Rows[fila].Cells["txtNumero"].Value.ToString());
                int id = Int32.Parse(dataGridView1.Rows[fila].Cells["Id"].Value.ToString());
                string idTercero = (dataGridView1.Rows[fila].Cells["txtIdTercero"].Value.ToString());
                //MessageBox.Show(idTercero.ToString());
                if (this.ConsultarPedidoHGI(documento, transaccion, idTercero))
                {
                    if (transaccion.Equals("09"))
                    {
                        transaccion = "04";
                    }
                    else if (transaccion.Equals("1009"))
                    {
                        transaccion = "1004";
                    }
                    if (this.ConsultarFacturaHGI(documento, transaccion, idTercero))
                    {
                        //Actualizar estado
                        //Actualiza el estado del pedido y valida si ya existe un documento asociado 
                        int r = this.ActualizarEstadoPedido(id, documento);
                        if (r == 0)
                        {
                            this.AccionTrigrer(1);
                            this.ActualizarDocRefPedidos(documento, this.numDocumentoFactura);
                            this.AccionTrigrer(0);
                            //Imprimir sticker
                            Printing();
                            CargarDatosPanel1();
                            CargarDatosPanel2();
                        }
                        else if (r == -1)
                        {
                            MessageBox.Show("Hubo un error al consultar", "Informacion General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El pedido " + r + " ya esta asociado al documento " + documento + " verifique nuevamente", "Informacion General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
        }

        private bool ConsultarPedidoHGI(int doc, string transaccion, string idTercero = "")
        {
            bool rpta = false;
            string sql;
            if (idTercero.Equals(""))
            {
                sql = "select * from tbldocumentos inner join TblTerceros on TblDocumentos.StrTercero = TblTerceros.StrIdTercero where TblDocumentos.IntTransaccion = " + transaccion + " and TblDocumentos.IntDocumento =" + doc;
            }
            else
            {
                sql = "select * from tbldocumentos inner join TblTerceros on TblDocumentos.StrTercero = TblTerceros.StrIdTercero where TblDocumentos.IntTransaccion = " + transaccion + " and TblDocumentos.IntDocumento =" + doc + " and TblTerceros.StrIdTercero = '" + idTercero + "'";
            }
            //MessageBox.Show(sql);
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        rpta = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe documento creado en la transaccion " + transaccion, "Informacion General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rpta = false;
                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
                return rpta;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

        }

        private bool ConsultarFacturaHGI(int docRef, string transaccion, string idTercero = "")
        {
            bool rpta = false;
            string sql;
            if (idTercero.Equals(""))
            {
                sql = "select StrNombre, IntDocumento from TblDocumentos inner join TblTerceros on TblDocumentos.StrTercero = TblTerceros.StrIdTercero where TblDocumentos.IntTransaccion = " + transaccion + " and TblDocumentos.IntDocRef =" + docRef;
            }
            else
            {
                sql = "select StrNombre, IntDocumento from TblDocumentos inner join TblTerceros on TblDocumentos.StrTercero = TblTerceros.StrIdTercero where TblDocumentos.IntTransaccion = " + transaccion + " and TblDocumentos.IntDocRef =" + docRef + " and TblTerceros.StrIdTercero = '" + idTercero + "'";
            }
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.tercero = reader.GetString(0);
                            this.numDocumentoFactura = Int32.Parse(reader.GetInt32(1).ToString());
                            rpta = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No hay documento asociado en la transaccion " + transaccion, "Informacion General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rpta = false;
                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta Factura HGI");
            }
            return rpta;
        }

        private int ActualizarEstadoPedido(int id, int docuemento)
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ActualizarEstadoPedido(id, docuemento, con.GetCxn());
            int r = -1;
            if (rpta.HasRows)
            {
                int i = 0;
                while (rpta.Read())
                {
                    string existencia = rpta.GetString("rpta");
                    if (existencia.Equals("-1"))
                    {
                        r = Int32.Parse(rpta.GetString("intIdPedido"));
                    }
                    else if (existencia.Equals("1"))
                    {
                        r = 0;
                    }
                }
            }
            return r;
        }

        private void Printing()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(documentoAimprimir);
                // Especifica que impresora se utilizara!!
                pd.PrinterSettings.PrinterName = Impresoras.Text;
                PageSettings pa = new PageSettings();
                pa.Margins = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.Margins = pa.Margins;
                PaperSize ps = new PaperSize("Custom", 350, 20);
                pd.DefaultPageSettings.PaperSize = ps;
                //pd.DefaultPageSettings.Landscape = true;
                pd.Print();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Printing " + exp.Message);
            }
        }

        private void documentoAimprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                using (Graphics g = e.Graphics)
                {
                    using (Font fnt = new Font("ArialBlack", 14))//Formato
                    {
                        string caption = "IM";
                        g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 15, 5);//posicion del texto
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }

        private void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            string txt = txtFiltrar.Text;
            int estadoPedido;
            if (txt.Equals(""))
            {
                this.CargarDatosPanel1();
                this.CargarDatosPanel2();
            }
            else
            {
                if (cbxPanel.SelectedIndex.ToString().Equals("0"))
                {
                    estadoPedido = 3;

                    dataGridView1.Rows.Clear();
                }
                else
                {
                    estadoPedido = 4;
                    dataGridView2.Rows.Clear();
                }

                try
                {
                    ConexionMySql con = new ConexionMySql();
                    MySqlDataReader rpta = con.FiltrarEncabezadoPedidos(txt, estadoPedido, con.GetCxn());
                    string tipo;
                    if (rpta == null)
                    {
                        MessageBox.Show("Null..." + con.Error);
                        lblRpta.Text = con.Error;
                        //lblRpta.Visible = true;
                    }
                    else
                    {
                        if (rpta.HasRows)
                        {
                            while (rpta.Read())
                            {
                                tipo = rpta.GetString(16);
                                if (tipo.Equals("0"))
                                {
                                    if (estadoPedido == 3)
                                    {
                                        dataGridView1.Rows.Add(new string[] { rpta.GetString(0), rpta.GetString(5), rpta.GetString(7) });
                                    }
                                    else
                                    {
                                        dataGridView2.Rows.Add(new string[] { rpta.GetString(0), rpta.GetString(5), rpta.GetString(7) });
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblRpta.Text = "No se encontro nada";
                            //lblRpta.Visible = true;
                        }
                    }
                    con.CerrarCnx();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error D..." + ex);
                }
            }

        }

        private void txtNumDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //VALIDACION DE DOCUMENTOS CUANDO SE INGRESAN  MANUAL AL SISTEMA DE HGI
            if (e.KeyChar == (char)(Keys.Enter))
            {
                string transaccion = "04";
                if (this.ConsultarPedidoHGI(Int32.Parse(txtNumDocumento.Text), cbxTransaccionManual.Text))
                {
                    if (cbxTransaccionManual.Text.Equals("09"))
                    {
                        transaccion = "04";
                    }
                    else if (cbxTransaccionManual.Text.Equals("1009"))
                    {
                        transaccion = "1004";
                    }
                    else if (cbxTransaccionManual.Text.Equals("0410"))
                    {
                        transaccion = "041";
                    }
                    if (this.ConsultarFacturaHGI(Int32.Parse(txtNumDocumento.Text), transaccion))
                    {
                        if (MessageBox.Show("Documentos asociado al cliente " + this.tercero, "Informacion General", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {

                            this.AccionTrigrer(1);
                            if (transaccion.Equals("041")) // POS
                            {
                                MessageBox.Show("pos  " + Int32.Parse(txtNumDocumento.Text) + " : " + this.numDocumentoFactura);
                                this.ActualizarDocRefPos(Int32.Parse(txtNumDocumento.Text), this.numDocumentoFactura);
                            }
                            else
                            {
                                this.ActualizarDocRefPedidos(Int32.Parse(txtNumDocumento.Text), this.numDocumentoFactura);
                            }
                            this.AccionTrigrer(0);
                            //IMPRIMIR STICKER
                            Printing();
                        }
                        else
                        {
                            //MessageBox.Show("Cancelado", "Informacion General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Este proceso solo funciona cuando se carga el csv a la transaccion 09 ya que se carga con el docref 
            //Actualiza el campo docref de la transaccion 04 con el numero de documento que tenga asociado el documento de la transaccion 09
            int NumeroDocumento;
            int NumeroDocRef;
            string sql = "select TblDocumentos.IntDocRef, TblDocumentos.IntDocumento from TblDocumentos where TblDocumentos.IntTransaccion = 09 and TblDocumentos.IntDocRef != 0";
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            NumeroDocumento = Int32.Parse(reader.GetInt32(0).ToString());
                            NumeroDocRef = Int32.Parse(reader.GetInt32(1).ToString());
                            this.AccionTrigrer(1);
                            this.actualizarDocRefFactura(NumeroDocumento, NumeroDocRef);
                            this.AccionTrigrer(0);
                        }


                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta Factura HGI");
            }
        }

        private void AccionTrigrer(int accion)
        {
            string sql;
            if (accion == 1)
            {
                sql = "disable trigger TgHgiNet_tbldocumentos on TblDocumentos;";
            }
            else
            {
                sql = "enable trigger TgHgiNet_tbldocumentos on TblDocumentos;";
            }

            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //this.tercero = reader.GetString(0);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta Factura HGI");
            }
        }

        private void actualizarDocRefFactura(int numDocFactura, int NumDocRefPedidos)
        {
            string sql = "update TblDocumentos set IntDocRef = " + NumDocRefPedidos + " where TblDocumentos.IntDocumento = " + numDocFactura + " and TblDocumentos.IntTransaccion = 04;";
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //this.tercero = reader.GetString(0);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta Factura HGI");
            }
        }

        private void ActualizarDocRefPedidos(int numDocPedido, int NumDocRefFactura)
        {
            string sql = "update TblDocumentos set IntDocRef = " + NumDocRefFactura + " where TblDocumentos.IntDocumento = " + numDocPedido + " and TblDocumentos.IntTransaccion = 09;";
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //this.tercero = reader.GetString(0);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta Factura HGI");
            }
        }

        private void ActualizarDocRefPos(int numDocPedido, int NumDocRefFactura)
        {
            string sql = "update TblDocumentos set IntDocRef = " + NumDocRefFactura + " where TblDocumentos.IntDocumento = " + numDocPedido + " and TblDocumentos.IntTransaccion = 0410;";
            try
            {
                Conexion con = new Conexion(sql);
                if (con.EjecutarReader())
                {
                    SqlDataReader reader = con.Reader;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //this.tercero = reader.GetString(0);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("false " + con.Error);
                }
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta Factura HGI");
            }
        }

        private void txtNumDocumento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
