using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class PanelSticker : Form
    {
        private int columna = 0;
        private string precio1;
        private string precio2;
        private string precio3;
        private string precio4;
        private string precio5;
        private int pares = 0;
        private int individual = 0;
        private int contador = 0;
        private bool imprimir = true;

        DataTable tabla = new DataTable();
        DataTable tabla2 = new DataTable();
        public PanelSticker()
        {
            InitializeComponent();
            AgregarImpresoras();
            DataGrid();
            LlenarComboBox();
            ConsultarReferencias();
            CheckForIllegalCrossThreadCalls = false;
            timer1.Start();
            ConsultarReferenciasTerminadas();

            LlenarCbxSexo();
            LlenarCbxMarca();
            LlenarCbxMaterial();
            //pruebaHilo();MessageBox.Show("hola");

        }

        public void LlenarCbxSexo()
        {
            Conexion con = new Conexion("select * from tblProdParametro1");
            if (con.EjecutarReader())
            {
                SqlDataReader reader = con.Reader;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbxSexo.Items.Add(reader.GetString(1));
                    }
                    cbxSexo.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("nada");
                }
            }
            else
            {
                MessageBox.Show("false " + con.Error);
            }
            con.CerrarConexion();
        }
        public void LlenarCbxMaterial()
        {
            Conexion con = new Conexion("select * from tblProdParametro2");
            if (con.EjecutarReader())
            {
                SqlDataReader reader = con.Reader;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbxMaterial.Items.Add(reader.GetString(1));
                    }
                    cbxMaterial.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("nada");
                }
            }
            else
            {
                MessageBox.Show("false " + con.Error);
            }
            con.CerrarConexion();
        }
        public void LlenarCbxMarca()
        {
            Conexion con = new Conexion("select * from tblProdParametro3");
            if (con.EjecutarReader())
            {
                SqlDataReader reader = con.Reader;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbxMarca.Items.Add(reader.GetString(1));
                    }
                    cbxMarca.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("nada");
                }
            }
            else
            {
                MessageBox.Show("false " + con.Error);
            }
            con.CerrarConexion();
        }

        private void AgregarImpresoras()
        {
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Items.Add(strPrinter);
            }
            Impresoras.SelectedIndex = (Impresoras.Items.Count - 1);
        }

        public void terminarTimer()
        {
            timer1.Stop();
        }



        public void LlenarComboBox()
        {
            Conexion con = new Conexion("select strIdUnidad from tblunidades");
            if (con.EjecutarReader())
            {
                SqlDataReader reader = con.Reader;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbxUnidadMedida.Items.Add(reader.GetString(0));
                    }
                    cbxUnidadMedida.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("nada");
                }
            }
            else
            {
                MessageBox.Show("false " + con.Error);
            }
            con.CerrarConexion();
        }

        private void DataGrid()
        {
            /*dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Referencia", "Referencia");
            dataGridView1.Columns.Add("Descripcion", "Descripcion");
            dataGridView1.Columns.Add("UDM", "Unidad de medida");
            dataGridView1.Columns.Add("Precio1", "Precio 1");
            dataGridView1.Columns.Add("Precio2", "Precio 2");
            dataGridView1.Columns.Add("Precio3", "Precio 3");
            dataGridView1.Columns.Add("Precio4", "Precio 4");
            dataGridView1.Columns.Add("Precio5", "Precio 5");
            dataGridView1.Columns.Add("CantPorUnidad", "CantPorUnidad");
            dataGridView1.Columns.Add("Dimension", "Dimension");
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["Precio1"].Visible = false;
            this.dataGridView1.Columns["Precio2"].Visible = false;
            this.dataGridView1.Columns["Precio3"].Visible = false;
            this.dataGridView1.Columns["Precio4"].Visible = false;
            this.dataGridView1.Columns["Precio5"].Visible = false;
            this.dataGridView1.Columns["CantPorUnidad"].Visible = false;
            this.dataGridView1.Columns["Dimension"].Visible = false;*/




            tabla.Columns.Add("Id");
            tabla.Columns.Add("Referencia");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("UDM");
            tabla.Columns.Add("Precio1");
            tabla.Columns.Add("Precio2");
            tabla.Columns.Add("Precio3");
            tabla.Columns.Add("Precio4");
            tabla.Columns.Add("Precio5");
            tabla.Columns.Add("CantPorUnidad");
            tabla.Columns.Add("Dimension");
            tabla.Columns.Add("Cant Paca");
            tabla.Columns.Add("Material");
            tabla.Columns.Add("Sexo");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Observacion");

            /*
            tabla2.Columns.Add("Color");
            tabla2.Columns.Add("Estilo");*/
        }

        public void pruebaHilo()
        {
            try
            {
                ThreadStart theradStart = new ThreadStart(this.ConsultarReferencias);
                Thread th1 = new Thread(theradStart);
                th1.Start();
                th1.Join();
            }
            catch (Exception e)
            {
                MessageBox.Show("error " + e);
            }
        }

        public void ConsultarReferencias()
        {
            try
            {
                ConexionMySql con = new ConexionMySql();
                MySqlDataReader rpta = con.ConsultarDetalleCompra(2, con.GetCxn());
                //dataGridView1.DataSource = null;
                tabla.Rows.Clear();
                string referencia, UDM, cantPaca, material, sexo, marca, observacion;
                if (rpta == null)
                {
                    MessageBox.Show("deiby..." + con.Error);
                    lblRpta.Text = con.Error;
                    lblRpta.Visible = true;
                }
                else
                {
                    if (rpta.HasRows)
                    {

                        while (rpta.Read())
                        {
                            if (rpta.IsDBNull(rpta.GetOrdinal("strReferenciaM")))
                            {
                                referencia = rpta.GetString(1);
                            }
                            else
                            {
                                referencia = rpta.GetString("strReferenciaM");
                            }
                            if (rpta.IsDBNull(rpta.GetOrdinal("strUnidadMedidaM")))
                            {
                                UDM = rpta.GetString(3);
                            }
                            else
                            {
                                UDM = rpta.GetString("strUnidadMedidaM");
                            }
                            if (rpta.IsDBNull(rpta.GetOrdinal("intCantidadPaca")))
                            {
                                cantPaca = "0";
                            }
                            else
                            {
                                cantPaca = rpta.GetString("intCantidadPaca");
                            }

                            if (rpta.IsDBNull(rpta.GetOrdinal("strMaterial")))
                            {
                                material = "";
                            }
                            else
                            {
                                material = rpta.GetString("strMaterial");
                            }

                            if (rpta.IsDBNull(rpta.GetOrdinal("strSexo")))
                            {
                                sexo = "";
                            }
                            else
                            {
                                sexo = rpta.GetString("strSexo");
                            }

                            if (rpta.IsDBNull(rpta.GetOrdinal("strMarca")))
                            {
                                marca = "";
                            }
                            else
                            {
                                marca = rpta.GetString("strMarca");
                            }

                            if (rpta.IsDBNull(rpta.GetOrdinal("strObservacion")))
                            {
                                observacion = "";
                            }
                            else
                            {
                                observacion = rpta.GetString("strObservacion");
                            }

                            tabla.Rows.Add(rpta.GetString(8), referencia, rpta.GetString(6), UDM, rpta.GetString(9), rpta.GetString(10), rpta.GetString(11), rpta.GetString(12), rpta.GetString(13), rpta.GetString(2), rpta.GetString(16), cantPaca, material, sexo, marca, observacion);

                        }
                        dataGridView1.DataSource = tabla;
                    }
                    else
                    {
                        lblRpta.Text = "No se encontro nada";
                        lblRpta.Visible = false;
                    }
                }
                con.CerrarCnx();
                //MessageBox.Show("fin");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error D..." + ex);
            }

        }

        private void ConsultarReferenciaHGI(string referencia)
        {
            try
            {
                WebServiceProducto.WSPortal client = new WebServiceProducto.WSPortal();
                client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.PreAuthenticate = true;
                var datos = client.Producto(referencia);
                //var s = JsonConvert.DeserializeObject<RootObject>(datos);

                List<RootObject> items = JsonConvert.DeserializeObject<List<RootObject>>(datos);
                if (items.Count != 0)
                {
                    foreach (var value in items)
                    {
                        Existencia_Producto objE_P = new Existencia_Producto(referencia, value.StrParam2);
                        objE_P.Show();
                        //MessageBox.Show("Existe referencia: " + referencia + " \nUbicacion: " + value.StrParam2, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //MessageBox.Show("No existe referencia en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erroooor: " + ex.ToString());
            }
        }

        private void cargarDatos(object sender, DataGridViewCellEventArgs e)
        {
            ConsultarEstiloReferencia(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

            ConsultarReferenciaHGI(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            try
            {
                lblIdDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtReferencia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.ForeColor = Color.Black;
                int index = cbxUnidadMedida.FindString(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                cbxUnidadMedida.SelectedIndex = index;
                //txtUnidadMedida.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtPrecio1.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value.ToString())).ToString("C");
                txtPrecio1.Text = txtPrecio1.Text.Replace("$", "");
                txtPrecio1.ForeColor = Color.Black;
                txtPrecio2.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value.ToString())).ToString("C");
                txtPrecio3.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value.ToString())).ToString("C");
                txtPrecio4.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value.ToString())).ToString("C");
                txtPrecio5.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[8].Value.ToString())).ToString("C");
                txtCantidad.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtDimension.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txtCantPaca.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                txtDimension.ForeColor = Color.Black;
                txtCantidad.ForeColor = Color.Black;
                txtObservacion.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                cbxSexo.SelectedItem = (dataGridView1.CurrentRow.Cells[13].Value.ToString().ToUpper());
                cbxMarca.SelectedItem = (dataGridView1.CurrentRow.Cells[14].Value.ToString().ToUpper());
                cbxMaterial.SelectedItem = (dataGridView1.CurrentRow.Cells[12].Value.ToString().ToUpper());
            }
            catch (Exception exx)
            {
                cbxMaterial.SelectedIndex = 0;

            }

            ConsultarInformacionReferencia();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            ConsultarReferenciasTerminadas();
        }

        private void limpiar()
        {
            txtReferencia.Text = "Referencia";
            txtDescripcion.Text = "Descripcion";
            txtDescripcion.ForeColor = Color.DimGray;
            cbxUnidadMedida.SelectedIndex = 0;
            txtPrecio1.Text = "Precio 1";
            txtPrecio1.ForeColor = Color.DimGray;
            txtPrecio2.Text = "Precio 2";
            txtPrecio3.Text = "Precio 3";
            txtPrecio4.Text = "Precio 4";
            txtPrecio5.Text = "Precio 5";
            txtColor.Text = "Color";
            txtEstilo.Text = "Estilo";
            txtCantidad.Text = "Cantidad";
            txtDimension.Text = "Dimension";
            txtCantPaca.Text = "Cant Paca";
            txtObservacion.Text = "Observacion";
            txtObservacion.ForeColor = Color.DimGray;
            txtCantPaca.ForeColor = Color.DimGray;
            txtColor.ForeColor = Color.DimGray;
            txtEstilo.ForeColor = Color.DimGray;
            txtDimension.ForeColor = Color.DimGray;
            txtCantidad.ForeColor = Color.DimGray;
            lblIdDetalle.Text = "";
            lblMensaje.Text = "";
            lblMensaje.Visible = false;
            lblRpta.Text = "";
            lblRpta.Visible = false;
            lblCantCompra.Text = "";
            lblUdmCompra.Text = "";
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            /*if (Validar())
            {
                FormatoPrecio(0);
                ActualizarDetalleCompra();
                limpiar();
                ConsultarReferenciasTerminadas();
                ConsultarReferencias();
            }*/
        }

        private void Printing()
        {
            try
            {

                if (checkBox1.Checked == true)
                {
                    this.pares = Int32.Parse(txtCantidadImpr.Text) / 2;
                    if (this.pares > 0)
                    {
                        for (int i = 1; i <= this.pares; i++)
                        {
                            Printing2();
                        }
                        if (Int32.Parse(txtCantidadImpr.Text) % 2 == 0)
                        {
                            this.pares = 0;
                            checkBox1.Checked = false;
                            txtCantidadImpr.Text = "0";
                            Printing2();
                        }
                    }
                    this.individual = Int32.Parse(txtCantidadImpr.Text) % 2;
                    this.pares = 0;
                    if (this.individual > 0)
                    {
                        Printing2();
                    }
                    else
                    {
                        if (checkBox1.Checked != false)
                        {
                            checkBox1.Checked = false;
                            Printing2();
                        }

                    }

                }
                else
                {
                    if (Int32.Parse(txtCantidadImpr.Text) > 0)
                    {
                        this.pares = Int32.Parse(txtCantidadImpr.Text) / 2;
                        if (this.pares > 0)
                        {
                            if (this.txtReferencia.TextLength > 13)
                            {
                                for (int i = 1; i <= Int32.Parse(txtCantidadImpr.Text); i++)
                                {
                                    Printing2();
                                }
                            }
                            else
                            {
                                for (int i = 1; i <= this.pares; i++)
                                {
                                    Printing2();
                                }
                            }

                        }
                        this.individual = Int32.Parse(txtCantidadImpr.Text) % 2;
                        this.pares = 0;
                        if (this.individual > 0)
                        {
                            Printing2();
                        }
                    }
                    else
                    {
                        //txtCantidadImpr.Text = "0";
                        Printing2();
                    }

                }
                this.pares = 0;
                this.individual = 0;
                this.contador = 0;

            }
            catch (Exception exp)
            {
                MessageBox.Show("!Error  " + exp.Message);
            }
        }

        private void Printing2()
        {
            PrintDocument pd1 = new PrintDocument();
            pd1.PrintPage += new PrintPageEventHandler(documentoAimprimir);
            // Especifica que impresora se utilizara!!
            pd1.PrinterSettings.PrinterName = Impresoras.Text;// "ZDesigner GT800 (EPL) (Copiar 1)";
            PageSettings pa1 = new PageSettings();
            pa1.Margins = new Margins(0, 0, 0, 0);
            pd1.DefaultPageSettings.Margins = pa1.Margins;
            PaperSize ps1;
            if (txtReferencia.TextLength > 13)
            {
                ps1 = new PaperSize("Custom", 310, 200);
            }
            else
            {
                ps1 = new PaperSize("Custom", 330, 110);
            }
            //Se valida el tipo de stricker
            if (txtReferencia.TextLength > 13)
            {
                StickerInformacion objSI = new StickerInformacion();
                objSI.ShowDialog();
                this.imprimir = objSI.continuar;
            }

            pd1.DefaultPageSettings.PaperSize = ps1;
            //pd.DefaultPageSettings.Landscape = true;
            if (this.imprimir)
            {
                pd1.Print();
            }
        }

        /*private void documentoAimprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                using (Graphics g = e.Graphics)
                {
                    using (Font fnt = new Font("Arial", 12, FontStyle.Bold))//Formato
                    {
                        Font drawFont = new Font("Arial", 9);
                        Font font = new Font("Arial", (float)5.5, FontStyle.Bold);
                        Barcode code = new Barcode();
                        //code.BarWidth = 200;
                        Image img;
                        int x = 45;
                        int w = 140;
                        int xImg = 0;
                        
                        code.Alignment = AlignmentPositions.CENTER;


                        if (txtReferencia.TextLength <= 8)
                        {
                            if (txtReferencia.TextLength <= 5)
                            {
                                if (txtReferencia.TextLength <= 2)
                                {
                                    img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 60, 30);
                                    w = 50;
                                    xImg = 35;
                                }
                                else
                                {
                                    img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 100, 30);
                                }
                            }
                            else
                            {
                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 150, 30);
                            }

                        }
                        else
                        {
                            if (txtReferencia.TextLength >= 9 && txtReferencia.TextLength <= 12)
                            {
                                x = 1;
                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 180, 30);
                            }
                            else
                            {
                                if (txtReferencia.TextLength >= 13 && txtReferencia.TextLength <= 14)
                                {
                                    x = 1;
                                    img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 190, 30);
                                }
                                else
                                {
                                    if (txtReferencia.TextLength >= 15 && txtReferencia.TextLength <= 19)
                                    {

                                        x = 1;
                                        img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 280, 30);
                                    }
                                    else
                                    {
                                        x = 1;
                                        img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 290, 30);
                                    }

                                }

                            }
                        }

                        if (checkBox1.Checked == true)
                        {
                            VariosDocumentos(e, true);
                        }
                        else
                        {
                            if (Int32.Parse(txtCantidadImpr.Text) > 0)
                            {
                                VariosDocumentos(e, false);
                            }
                            else
                            {
                                if (this.columna == 0)
                                {
                                    this.columna = 1;
                                    //PointF drawPoint = new PointF(150.0F, 150.0F);
                                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, x, 0);
                                    g.DrawImage(img, xImg, 15, w, 15);//(cant * 11)

                                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 30);
                                    g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 0, 45);
                                    g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 80, 45);
                                    g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 0, 60);
                                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 65);
                                    g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 0, 80);
                                    g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 0, 90);
                                    g.DrawString("Color: " + this.txtColor.Text.Replace("Color", ""), font, System.Drawing.Brushes.Black, 60, 80);
                                    g.DrawString("Estilo: " + this.txtEstilo.Text.Replace("Estilo", ""), font, System.Drawing.Brushes.Black, 60, 90);
                                    //g.DrawString("v:", drawFont, System.Drawing.Brushes.Black, 130, 88);
                                }
                                else
                                {
                                    this.columna = 0;
                                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, (x + 170), 0);
                                    g.DrawImage(img, 169, 15, 140, 15);
                                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 30);
                                    g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 170, 45);
                                    g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 240, 45);
                                    g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 170, 60);
                                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 250, 65);
                                    g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 170, 80);
                                    g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 170, 90);
                                    g.DrawString("Color: " + this.txtColor.Text.Replace("Color", ""), font, System.Drawing.Brushes.Black, 230, 80);
                                    g.DrawString("Estilo: " + this.txtEstilo.Text.Replace("Estilo", ""), font, System.Drawing.Brushes.Black, 230, 90);
                                    //g.DrawString("v:", drawFont, System.Drawing.Brushes.Black, 300, 88);
                                }
                                // Draw string to screen.
                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("!!Error " + ex.Message);
            }
        }*/

        private void documentoAimprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                using (Font fnt = new Font("Arial", 12, FontStyle.Bold))//Formato
                {
                    Graphics g1 = e.Graphics;
                    Image img;
                    BarCode code = new BarCode();
                    img = code.generarCodigo(txtReferencia.Text);


                    if (checkBox1.Checked == true)
                    {
                        if (this.txtReferencia.TextLength > 13)
                        {
                            g1 = code.PintarStickerXL(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio1, this.precio2, this.precio3, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));
                        }
                        else
                        {
                            VariosDocumentos(e, true);
                        }

                    }
                    else
                    {
                        if (Int32.Parse(txtCantidadImpr.Text) > 0)
                        {
                            if (this.txtReferencia.TextLength > 13)
                            {
                                g1 = code.PintarStickerXL(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio1, this.precio2, this.precio3, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));
                            }
                            else
                            {
                                VariosDocumentos(e, false);
                            }

                        }
                        else
                        {
                            if (this.txtReferencia.TextLength > 13)
                            {
                                //MessageBox.Show("Para imprimir esta referencia se requiere sticker largo","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

                                g1 = code.PintarStickerXL(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio1, this.precio2, this.precio3, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));



                            }
                            else
                            {
                                if (this.columna == 0)
                                {
                                    this.columna = 1;
                                    g1 = code.PintarStickerCol1(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));
                                }
                                else
                                {
                                    this.columna = 0;
                                    g1 = code.PintarStickerCol2(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));

                                }
                            }


                        }


                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("!!Error " + ex.Message);
            }
        }

        private void VariosDocumentos(System.Drawing.Printing.PrintPageEventArgs e, bool Checked)
        {
            /*using (Graphics g = e.Graphics)
            {
                Font fnt = new Font("Arial", 12, FontStyle.Bold);
                Font drawFont = new Font("Arial", 9);
                Font font = new Font("Arial", (float)5.5, FontStyle.Bold);
                Barcode code = new Barcode();
                Image img;
                int x = 45;
                code.Alignment = AlignmentPositions.CENTER;
                if (txtReferencia.TextLength <= 8)
                {
                    img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 150, 30);
                }
                else
                {
                    if (txtReferencia.TextLength >= 9 && txtReferencia.TextLength <= 12)
                    {
                        x = 1;
                        img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 180, 30);
                    }
                    else
                    {
                        if (txtReferencia.TextLength >= 13 && txtReferencia.TextLength <= 14)
                        {
                            x = 1;
                            img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 190, 30);
                        }
                        else
                        {
                            if (txtReferencia.TextLength >= 15 && txtReferencia.TextLength <= 19)
                            {

                                x = 1;
                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 280, 30);
                            }
                            else
                            {
                                x = 1;
                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 290, 30);
                            }
                        }
                    }
                }


                if (this.pares > 0)
                {
                    this.contador++;

                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, x, 0);
                    g.DrawImage(img, 0, 15, 140, 15);

                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 30);
                    g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 0, 45);
                    g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 80, 45);
                    g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 0, 60);
                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 65);
                    g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 0, 80);
                    g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 0, 90);
                    g.DrawString("Color: " + this.txtColor.Text.Replace("Color", ""), font, System.Drawing.Brushes.Black, 60, 80);
                    g.DrawString("Estilo: " + this.txtEstilo.Text.Replace("Estilo", ""), font, System.Drawing.Brushes.Black, 60, 90);
                    if (Checked)
                    {
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 120, 86);
                        this.contador++;
                    }
                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, (x + 170), 0);
                    g.DrawImage(img, 169, 15, 140, 15); // 100
                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 30);
                    g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 170, 45);
                    g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 240, 45);
                    g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 170, 60);
                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 250, 65);
                    g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 170, 80);
                    g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 170, 90);
                    g.DrawString("Color: " + this.txtColor.Text.Replace("Color", ""), font, System.Drawing.Brushes.Black, 230, 80);
                    g.DrawString("Estilo: " + this.txtEstilo.Text.Replace("Estilo", ""), font, System.Drawing.Brushes.Black, 230, 90);
                    if (Checked)
                    {
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 280, 86);
                    }

                }
                if (this.individual > 0)
                {
                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, x, 0);
                    g.DrawImage(img, 0, 15, 140, 15);

                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 30);
                    g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 0, 45);
                    g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 80, 45);
                    g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 0, 60);
                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 65);
                    g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 0, 80);
                    g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 0, 90);
                    g.DrawString("Color: " + this.txtColor.Text.Replace("Color", ""), font, System.Drawing.Brushes.Black, 60, 80);
                    g.DrawString("Estilo: " + this.txtEstilo.Text.Replace("Estilo", ""), font, System.Drawing.Brushes.Black, 60, 90);
                    if (Checked)
                    {
                        this.contador++;
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 120, 86);
                        g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, (x + 170), 0);
                        g.DrawImage(img, 160, 15, 140, 15);
                        g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 30);
                        g.DrawString(this.precio1, fnt, System.Drawing.Brushes.Black, 170, 45);
                        g.DrawString(this.precio2, fnt, System.Drawing.Brushes.Black, 240, 45);
                        g.DrawString(this.precio3, fnt, System.Drawing.Brushes.Black, 170, 60);
                        g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 250, 65);
                        g.DrawString("CxU: " + this.txtCantidad.Text, font, System.Drawing.Brushes.Black, 170, 80);
                        g.DrawString("Dim: " + this.txtDimension.Text, font, System.Drawing.Brushes.Black, 170, 90);
                        g.DrawString("Color: " + this.txtColor.Text, font, System.Drawing.Brushes.Black, 230, 80);
                        g.DrawString("Estilo: " + this.txtEstilo.Text, font, System.Drawing.Brushes.Black, 230, 90);
                    }

                }
            }*/
            using (Graphics g = e.Graphics)
            {
                Font fnt = new Font("Arial", 12, FontStyle.Bold);
                Font drawFont = new Font("Arial", 9);
                Font font = new Font("Arial", (float)5.5, FontStyle.Bold);

                Graphics g1 = e.Graphics;
                BarCode code = new BarCode();


                if (this.pares > 0)
                {
                    this.contador++;
                    g1 = code.PintarStickerCol1(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));

                    if (Checked)
                    {
                        g1.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 130, 96);
                        this.contador++;
                    }

                    g1 = code.PintarStickerCol2(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));

                    if (Checked)
                    {
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 298, 96);
                    }

                }
                if (this.individual > 0)
                {
                    g1 = code.PintarStickerCol1(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                        this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));

                    if (Checked)
                    {
                        this.contador++;
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 130, 96);
                        g1 = code.PintarStickerCol2(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio3, this.precio1, this.precio2, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                         this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""));
                    }

                }
            }

        }

        /*private void documentoAimprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                using (Graphics g = e.Graphics)
                {
                    using (Font fnt = new Font("Arial", 12, FontStyle.Bold))//Formato
                    {
                        Font drawFont = new Font("Arial", 9);
                        Font font = new Font("Arial", 7, FontStyle.Bold);
                        Barcode code = new Barcode();
                        code.Alignment = AlignmentPositions.CENTER; 
                        Image img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 180, 30);
                        //panel1.BackgroundImage = code.Encode(BarcodeLib.TYPE.CODE128, this.referencia, Color.Black, Color.White, 400, 100);
                        if (checkBox1.Checked == true)
                        {
                            VariosDocumentos(e, true);
                        }
                        else
                        {
                            if (Int32.Parse(txtCantidadImpr.Text) > 0)
                            {
                                VariosDocumentos(e, false);
                            }
                            else
                            {
                                if (this.columna == 0)
                                {
                                    this.columna = 1;
                                    //PointF drawPoint = new PointF(150.0F, 150.0F);
                                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 45, 0);
                                    g.DrawImage(img, 15, 20, 100, 20);

                                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 45);
                                    g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 0, 60);
                                    g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 80, 60);
                                    g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 0, 80);
                                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 80);
                                    //g.DrawString("v:", drawFont, System.Drawing.Brushes.Black, 130, 88);
                                }
                                else
                                {
                                    this.columna = 0;
                                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 215, 0);
                                    g.DrawImage(img, 185, 20, 100, 20);
                                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 45);
                                    g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 170, 60);
                                    g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 250, 60);
                                    g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 170, 80);
                                    g.DrawString(this.cbxUnidadMedida.Text, drawFont, System.Drawing.Brushes.Black, 250, 80);
                                    //g.DrawString("v:", drawFont, System.Drawing.Brushes.Black, 300, 88);
                                }
                                // Draw string to screen.
                            }


                        }
                        this.pares = 0;
                        this.individual = 0;
                        this.contador = 0;

    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("!!Error " + ex.Message);
            }
        }

        private void VariosDocumentos(System.Drawing.Printing.PrintPageEventArgs e, bool Checked)
        {
            using (Graphics g = e.Graphics)
            {
                Font fnt = new Font("Arial", 12, FontStyle.Bold);
                Font drawFont = new Font("Arial", 9);
                Font font = new Font("Arial", 7, FontStyle.Bold);
                Barcode code = new Barcode();
                code.IncludeLabel = true;
                code.LabelPosition = LabelPositions.TOPCENTER;
                code.LabelFont = drawFont;
                code.Alignment = AlignmentPositions.CENTER;
                Image img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 180, 30);
                if (this.pares > 0)
                {
                    this.contador++;
                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 45, 0);
                    g.DrawImage(img, 15, 20, 100, 20);
                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 45);
                    g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 0, 60);
                    g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 80, 60);
                    g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 0, 80);
                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 80);
                    if (Checked)
                    {
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 120, 88);
                        this.contador++;
                    }

                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 215, 0);
                    g.DrawImage(img, 185, 20, 100, 20);
                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 45);
                    g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 170, 60);
                    g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 250, 60);
                    g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 170, 80);
                    g.DrawString(this.cbxUnidadMedida.Text, drawFont, System.Drawing.Brushes.Black, 250, 80);
                    if (Checked)
                    {
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 281, 88);
                    }

                }
                if (this.individual > 0)
                {
                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 45, 0);
                    g.DrawImage(img, 15, 20, 100, 20);

                    g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 0, 45);
                    g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 0, 60);
                    g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 80, 60);
                    g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 0, 80);
                    g.DrawString(this.cbxUnidadMedida.Text, font, System.Drawing.Brushes.Black, 80, 80);
                    if (Checked)
                    {
                        this.contador++;
                        g.DrawString("v:" + this.contador, drawFont, System.Drawing.Brushes.Black, 130, 88);
                        g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, 215, 0);
                        g.DrawImage(img, 185, 20, 100, 20);
                        g.DrawString(this.txtDescripcion.Text, drawFont, System.Drawing.Brushes.Black, 170, 45);
                        g.DrawString(this.txtPrecio1.Text, fnt, System.Drawing.Brushes.Black, 170, 60);
                        g.DrawString(this.txtPrecio2.Text, fnt, System.Drawing.Brushes.Black, 250, 60);
                        g.DrawString(this.txtPrecio3.Text, fnt, System.Drawing.Brushes.Black, 170, 80);
                        g.DrawString(this.cbxUnidadMedida.Text, drawFont, System.Drawing.Brushes.Black, 250, 80);
                    }
                    
                }
            }
            
        }

        private void Printing()
        {
            try
            { 

                if (checkBox1.Checked == true)
                {
                    this.pares = Int32.Parse(txtCantidadImpr.Text) / 2;
                    if (this.pares > 0)
                    {
                        for (int i = 1; i <= this.pares; i++)
                        {
                            Printing2();
                        }
                        if (Int32.Parse(txtCantidadImpr.Text) % 2 == 0)
                        {
                            this.pares = 0;
                            checkBox1.Checked = false;
                            txtCantidadImpr.Text = "0";
                            Printing2();
                        }
                    }
                    this.individual = Int32.Parse(txtCantidadImpr.Text) % 2;
                    this.pares = 0;
                    if (this.individual > 0)
                    {
                        Printing2();
                    }
                    else
                    {
                        if (checkBox1.Checked != false)
                        {
                            checkBox1.Checked = false;
                            Printing2();
                        }
                    }
                    
                }
                else
                {
                    if (Int32.Parse(txtCantidadImpr.Text) > 0)
                    {
                        this.pares = Int32.Parse(txtCantidadImpr.Text) / 2;
                        if (this.pares > 0)
                        {
                            for (int i = 1; i <= this.pares; i++)
                            {
                                Printing2();
                            }
                        }
                        this.individual = Int32.Parse(txtCantidadImpr.Text) % 2;
                        this.pares = 0;
                        if (this.individual > 0)
                        {
                            Printing2();
                        }
                    }
                    else
                    {
                        Printing2();
                    }
                    
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("!Error  " + exp.Message);
            }
        }

        private void Printing2()
        {
            PrintDocument pd1 = new PrintDocument();
            pd1.PrintPage += new PrintPageEventHandler(documentoAimprimir);
            // Especifica que impresora se utilizara!!
            pd1.PrinterSettings.PrinterName = Impresoras.Text;// "ZDesigner GT800 (EPL) (Copiar 1)";
            PageSettings pa1 = new PageSettings();
            pa1.Margins = new Margins(0, 0, 0, 0);
            pd1.DefaultPageSettings.Margins = pa1.Margins;
            PaperSize ps1 = new PaperSize("Custom", 300, 100);
            pd1.DefaultPageSettings.PaperSize = ps1;
            //pd.DefaultPageSettings.Landscape = true;
            pd1.Print();
        }*/

        private void ActualizarDetalleCompra()
        {
            lblMensaje.Visible = false;
            ConexionMySql con = new ConexionMySql();
            try
            {
                string txtReferencia = this.txtReferencia.Text;
                string txtDescripcion = this.txtDescripcion.Text;
                string txtUDM = this.cbxUnidadMedida.Text.ToUpper();
                int txtCantidad = Int32.Parse(this.txtCantidad.Text);
                int txtPrecio1 = Int32.Parse(this.precio1);
                int txtPrecio2 = Int32.Parse(this.precio2);
                int txtPrecio3 = Int32.Parse(this.precio3);
                int txtPrecio4 = Int32.Parse(this.precio4);
                int txtPrecio5 = Int32.Parse(this.precio5);
                int idDetalle = Int32.Parse(this.lblIdDetalle.Text);
                int txtCantPaca = Int32.Parse(this.txtCantPaca.Text);
                string txtDimension = this.txtDimension.Text;

                int rpta = con.ActualizarDetalleCompra(con.GetCxn(), idDetalle, txtDescripcion, txtReferencia, txtPrecio1, txtPrecio2,
                                                        txtPrecio3, txtPrecio4, txtPrecio5, txtCantidad, txtUDM, 3, txtDimension,
                                                        txtCantPaca,
                                                        this.cbxMaterial.SelectedItem.ToString(),
                                                        this.cbxSexo.SelectedItem.ToString(),
                                                        this.cbxMarca.SelectedItem.ToString(),
                                                        this.txtObservacion.Text
                                                        );

                if (rpta != -1)
                {
                    //MessageBox.Show("Referencia actualizada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarReferencias();
                    ConsultarReferenciasTerminadas();
                }
                else
                {
                    MessageBox.Show("Upss, algo salio mal : " + con.Error, "Información", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Hubo un error en los datos,  por favor validar";
            }

        }

        public bool Validar()
        {
            if (txtPrecio1.TextLength == 0 || txtPrecio1.Text.Equals("Precio 1"))
            {
                txtPrecio1.Focus();
                lblMensaje.Text = "Ingreses precio 1";
                lblMensaje.Visible = true;
                return false;
            }
            if (txtDescripcion.TextLength == 0 || txtDescripcion.Text.Equals("Descripcion"))
            {
                txtDescripcion.Focus();
                lblMensaje.Text = "Ingreses la descripcion";
                lblMensaje.Visible = true;
                return false;
            }
            if (txtCantidad.TextLength == 0 || txtCantidad.Text.Equals("Cantidad"))
            {
                txtCantidad.Focus();
                lblMensaje.Text = "Ingreses la cantidad";
                lblMensaje.Visible = true;
                return false;
            }
            if (txtDimension.Text.Equals(""))
            {
                Impresoras.Focus();
                lblMensaje.Text = "Ingrese la dimension";
                lblMensaje.Visible = true;
                return false;
            }

            return true;

        }

        private void txtPrecio1_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarPrecios();
        }

        private void ValidarPrecios()
        {
            string udm = cbxUnidadMedida.Text;
            int udm2;
            int precio1 = 0;
            if (txtPrecio1.TextLength != 0)
            {
                try
                {
                    precio1 = Int32.Parse(CambiarFormatoPrecio(1, txtPrecio1, null));
                    ConexionMySql con = new ConexionMySql();
                    if (udm != "DOC")
                    {
                        udm2 = 1;
                    }
                    else
                    {
                        udm2 = 0;
                    }
                    MySqlDataReader reader = con.ConsultarPreciosEmpresa(con.GetCxn(), precio1, udm2);

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtPrecio2.Text = CambiarFormatoPrecio(0, null, (reader.GetString(2)));
                                txtPrecio3.Text = CambiarFormatoPrecio(0, null, (reader.GetString(3)));
                            }
                        }
                        else
                        {
                            txtPrecio2.Text = CambiarFormatoPrecio(0, null, ((precio1) * 1.1).ToString());
                            txtPrecio3.Text = CambiarFormatoPrecio(0, null, ((precio1) * 1.2).ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show(con.Error);
                    }
                    con.CerrarCnx();
                    txtPrecio4.Text = CambiarFormatoPrecio(0, null, ((precio1) * 2).ToString());
                    txtPrecio5.Text = CambiarFormatoPrecio(0, null, ((precio1) / 2).ToString());
                }
                catch (Exception)
                {
                    string word = txtPrecio1.Text;
                    txtPrecio1.Text = word.Remove(word.Length - 1);
                }


            }
            else
            {
                txtPrecio2.Text = "0";
                txtPrecio3.Text = "0";
                txtPrecio4.Text = "0";
                txtPrecio5.Text = "0";
            }
        }

        private string CambiarFormatoPrecio(int ban, TextBox textBox, string valor)
        {
            string conversion = "";
            if (ban == 0)
            {
                if (textBox != null)
                {
                    conversion = (Convert.ToDouble(textBox.Text)).ToString("C");
                }
                else
                {
                    conversion = (Convert.ToDouble(valor)).ToString("C");
                }
            }
            if (ban == 1)
            {
                conversion = textBox.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim();
            }
            return conversion;
        }

        private void FormatoPrecio(int ban)
        {
            if (ban == 0)
            {
                this.precio1 = txtPrecio1.Text.Replace("$", "").Replace(".", "").Replace(",", "");
                this.precio2 = txtPrecio2.Text.Replace("$", "").Replace(".", "").Replace(",", "");
                this.precio3 = txtPrecio3.Text.Replace("$", "").Replace(".", "").Replace(",", "");
                this.precio4 = txtPrecio4.Text.Replace("$", "").Replace(".", "").Replace(",", "");
                this.precio5 = txtPrecio5.Text.Replace("$", "").Replace(".", "").Replace(",", "");
            }
            if (ban == 1)
            {
                this.precio1 = this.precio1.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
                this.precio2 = this.precio2.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
                this.precio3 = this.precio3.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
                this.precio4 = this.precio4.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
            }
            if (ban == 2)
            {

                this.precio1 = (Convert.ToDouble(this.precio1)).ToString("C");
                this.precio2 = (Convert.ToDouble(this.precio2)).ToString("C");
                this.precio3 = (Convert.ToDouble(this.precio3)).ToString("C");
                this.precio4 = (Convert.ToDouble(this.precio4)).ToString("C");
                this.precio5 = (Convert.ToDouble(this.precio5)).ToString("C");
            }

            //MessageBox.Show(this.precio1 + " : " + this.precio2 + " : " + this.precio3 + " : " + this.precio4 + " : " + this.precio5);
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Datos_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecio1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPrecio1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecio1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtUnidadMedida_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxUnidadMedida_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            //MessageBox.Show("cambio " + senderComboBox.SelectedItem.ToString());
            cbxUnidadMedida.Text = senderComboBox.SelectedItem.ToString();
            ValidarPrecios();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void PanelSticker_Load(object sender, EventArgs e)
        {
        }

        private void txtPrecio1_Enter(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "Precio 1")
            {
                txtPrecio1.Text = "";
                txtPrecio1.ForeColor = Color.Black;
            }
        }

        private void txtPrecio1_Leave(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "")
            {
                txtPrecio1.ForeColor = Color.DimGray;
                txtPrecio1.Text = "Precio 1";
            }
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.ForeColor = Color.DimGray;
                txtDescripcion.Text = "Descripcion";
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "Cantidad")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.Black;
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.ForeColor = Color.DimGray;
                txtCantidad.Text = "Cantidad";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*MessageBox.Show("timer");
            pruebaHilo();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarReferencias();
            ConsultarReferenciasTerminadas();
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (checkBox1.Checked == true)
            {
                txtCantidadImpr.Visible = true;
            }
            else
            {
                txtCantidadImpr.Visible = false;
            }*/

        }

        private void txtDimension_Enter(object sender, EventArgs e)
        {
            if (txtDimension.Text == "Dimension")
            {
                txtDimension.Text = "";
                txtDimension.ForeColor = Color.Black;
            }
        }

        private void txtDimension_Leave(object sender, EventArgs e)
        {
            if (txtDimension.Text == "")
            {
                txtDimension.ForeColor = Color.DimGray;
                txtDimension.Text = "Dimension";
            }
        }


        private void txtPrecio1_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "Precio 1")
            {
                lblPrecio1.Visible = false;
                txtPrecio1.ForeColor = Color.DimGray;
            }
            else
            {
                lblPrecio1.Visible = true;
                txtPrecio1.ForeColor = Color.Black;
            }
        }

        private void txtPrecio2_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio2.Text == "Precio 2")
            {
                lblPrecio2.Visible = false;
                txtPrecio2.ForeColor = Color.DimGray;
            }
            else
            {
                lblPrecio2.Visible = true;
                txtPrecio2.ForeColor = Color.Black;
            }
        }

        private void txtPrecio3_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio3.Text == "Precio 3")
            {
                lblPrecio3.Visible = false;
                txtPrecio3.ForeColor = Color.DimGray;
            }
            else
            {
                lblPrecio3.Visible = true;
                txtPrecio3.ForeColor = Color.Black;
            }
        }

        private void txtPrecio4_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio4.Text == "Precio 4")
            {
                lblPrecio4.Visible = false;
                txtPrecio4.ForeColor = Color.DimGray;
            }
            else
            {
                lblPrecio4.Visible = true;
                txtPrecio4.ForeColor = Color.Black;
            }
        }

        private void txtPrecio5_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio5.Text == "Precio 5")
            {
                lblPrecio5.Visible = false;
                txtPrecio5.ForeColor = Color.DimGray;
            }
            else
            {
                lblPrecio5.Visible = true;
                txtPrecio5.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                lblDescripcion.Visible = false;
                txtDescripcion.ForeColor = Color.DimGray;
            }
            else
            {
                lblDescripcion.Visible = true;
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "Cantidad")
            {
                lblCantidad.Visible = false;
                txtCantidad.ForeColor = Color.DimGray;
            }
            else
            {
                lblCantidad.Visible = true;
                txtCantidad.ForeColor = Color.Black;
            }
        }

        private void txtDimension_TextChanged(object sender, EventArgs e)
        {
            if (txtDimension.Text == "Dimension")
            {
                lblDimension.Visible = false;
                txtDimension.ForeColor = Color.DimGray;
            }
            else
            {
                lblDimension.Visible = true;
                txtDimension.ForeColor = Color.Black;
            }
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            if (txtReferencia.Text == "Referencia")
            {
                lblReferencia.Visible = false;
                txtReferencia.ForeColor = Color.DimGray;
            }
            else
            {
                lblReferencia.Visible = true;
                txtReferencia.ForeColor = Color.Black;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltrar.Text != "Filtrar")
            {
                tabla.DefaultView.RowFilter = $"Referencia LIKE '{txtFiltrar.Text}%'";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CargarDatos2(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla2.Columns.Contains("id"))
            {
                lblIdDetalle.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtReferencia.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.ForeColor = Color.Black;
                int index = cbxUnidadMedida.FindString(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                cbxUnidadMedida.SelectedIndex = index;
                //txtUnidadMedida.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtPrecio1.Text = (Convert.ToDouble(dataGridView2.CurrentRow.Cells[4].Value.ToString())).ToString("C");
                txtPrecio1.Text = txtPrecio1.Text.Replace("$", "");
                txtPrecio1.ForeColor = Color.Black;
                txtPrecio2.Text = (Convert.ToDouble(dataGridView2.CurrentRow.Cells[5].Value.ToString())).ToString("C");
                txtPrecio3.Text = (Convert.ToDouble(dataGridView2.CurrentRow.Cells[6].Value.ToString())).ToString("C");
                txtPrecio4.Text = (Convert.ToDouble(dataGridView2.CurrentRow.Cells[7].Value.ToString())).ToString("C");
                txtPrecio5.Text = (Convert.ToDouble(dataGridView2.CurrentRow.Cells[8].Value.ToString())).ToString("C");
                txtCantidad.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                txtDimension.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                txtCantPaca.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                txtDimension.ForeColor = Color.Black;
                txtCantidad.ForeColor = Color.Black;


                txtObservacion.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                cbxMaterial.SelectedItem = (dataGridView2.CurrentRow.Cells[12].Value.ToString().ToUpper());
                cbxSexo.SelectedItem = (dataGridView2.CurrentRow.Cells[13].Value.ToString().ToUpper());
                cbxMarca.SelectedItem = (dataGridView2.CurrentRow.Cells[14].Value.ToString().ToUpper());

                ConsultarEstiloReferencia(Int32.Parse(lblIdDetalle.Text));
                ConsultarInformacionReferencia();
            }
            else
            {
                this.txtColor.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                this.txtEstilo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Impresoras.Text != "")
            {
                if (!txtReferencia.Text.Equals("Referencia"))
                {
                    lblMensaje.Visible = false;
                    FormatoPrecio(0);
                    ActualizarDetalleCompra();
                    FormatoPrecio(1);
                    Printing();
                    checkBox1.Checked = true;
                    txtCantidadImpr.Text = "2";
                }
                else
                {
                    MessageBox.Show("Sin información");
                }
            }
            else
            {
                MessageBox.Show("Seleccione Impresora");
            }

        }

        public void ConsultarReferenciasTerminadas()
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ConsultarDetalleCompra(3, con.GetCxn());
            //dataGridView2.DataSource = null;
            tabla2.Columns.Clear();
            string UDM, referencia, cantPaca, material, sexo, marca, observacion;


            tabla2.Columns.Add("Id");
            tabla2.Columns.Add("Referencia");
            tabla2.Columns.Add("Descripcion");
            tabla2.Columns.Add("UDM");
            tabla2.Columns.Add("Precio1");
            tabla2.Columns.Add("Precio2");
            tabla2.Columns.Add("Precio3");
            tabla2.Columns.Add("Precio4");
            tabla2.Columns.Add("Precio5");
            tabla2.Columns.Add("CantPorUnidad");
            tabla2.Columns.Add("Dimension");
            tabla2.Columns.Add("Cant Paca");
            tabla2.Columns.Add("Material");

            tabla2.Columns.Add("Sexo");
            tabla2.Columns.Add("Marca");
            tabla2.Columns.Add("Observacion");

            tabla2.Rows.Clear();
            if (rpta == null)
            {
                MessageBox.Show(con.Error);
                lblRpta.Text = con.Error;
                lblRpta.Visible = true;
            }
            else
            {
                if (rpta.HasRows)
                {

                    while (rpta.Read())
                    {
                        if (rpta.IsDBNull(rpta.GetOrdinal("strReferenciaM")))
                        {
                            referencia = rpta.GetString(1);
                        }
                        else
                        {
                            referencia = rpta.GetString("strReferenciaM");
                        }
                        if (rpta.IsDBNull(rpta.GetOrdinal("strUnidadMedidaM")))
                        {
                            UDM = rpta.GetString(3);
                        }
                        else
                        {
                            UDM = rpta.GetString("strUnidadMedidaM");
                        }
                        if (rpta.IsDBNull(rpta.GetOrdinal("intCantidadPaca")))
                        {
                            cantPaca = "0";
                        }
                        else
                        {
                            cantPaca = rpta.GetString("intCantidadPaca");
                        }

                        if (rpta.IsDBNull(rpta.GetOrdinal("strMaterial")))
                        {
                            material = "";
                        }
                        else
                        {
                            material = rpta.GetString("strMaterial");
                        }
                        if (rpta.IsDBNull(rpta.GetOrdinal("strSexo")))
                        {
                            sexo = "";
                        }
                        else
                        {
                            sexo = rpta.GetString("strSexo");
                        }

                        if (rpta.IsDBNull(rpta.GetOrdinal("strMarca")))
                        {
                            marca = "";
                        }
                        else
                        {
                            marca = rpta.GetString("strMarca");
                        }

                        if (rpta.IsDBNull(rpta.GetOrdinal("strObservacion")))
                        {
                            observacion = "";
                        }
                        else
                        {
                            observacion = rpta.GetString("strObservacion");
                        }
                        tabla2.Rows.Add(rpta.GetString(8), referencia, rpta.GetString(6), UDM, rpta.GetString(9), rpta.GetString(10), rpta.GetString(11), rpta.GetString(12), rpta.GetString(13), rpta.GetString(2), rpta.GetString(16), cantPaca, material, sexo, marca, observacion);

                        //dataGridView1.Rows.Add(rpta.GetString(8), rpta.GetString(1), rpta.GetString(6), rpta.GetString(3), rpta.GetString(9), rpta.GetString(10), rpta.GetString(11), rpta.GetString(12), rpta.GetString(13), rpta.GetString(2), rpta.GetString(16));
                        //                 ID                              First name                  Last Name                    Address
                        //lblMensaje.Text = rpta.GetString(0) + " - " + rpta.GetString(1) + " - " + rpta.GetString(2) + " - " + rpta.GetString(3);
                        // Ejemplo para mostrar en el listView1 :
                        //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        //var listViewItem = new ListViewItem(row);
                        //listView1.Items.Add(listViewItem);
                    }
                    dataGridView2.DataSource = tabla2;
                }
                else
                {
                    lblRpta.Text = "No se encontro nada";
                    lblRpta.Visible = false;
                }
            }
            con.CerrarCnx();
            //MessageBox.Show("fin");
        }

        public void ConsultarEstiloReferencia(int id)
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ConsultarLoteReferenciaCompra(id, con.GetCxn());
            //dataGridView2.DataSource = null;
            /*if (tabla2.Columns.Count > 0)
            {
                tabla2.Columns.RemoveAt(tabla2.Columns.Count - 1);
            }*/
            tabla2.Columns.Clear();
            tabla2.Columns.Add("Color");
            tabla2.Columns.Add("Estilo");
            tabla2.Rows.Clear();
            //MessageBox.Show("rpta : " + rpta);
            if (rpta == null)
            {
                MessageBox.Show("rpta : null");
            }
            else
            {
                if (rpta.HasRows)
                {
                    while (rpta.Read())
                    {
                        string color = "";
                        string estilo = "";

                        if (!Convert.IsDBNull(rpta[1]))
                        {
                            estilo = rpta.GetString(1);
                        }
                        if (!Convert.IsDBNull(rpta[2]))
                        {
                            color = rpta.GetString(2);
                        }
                        tabla2.Rows.Add(color, estilo);
                    }
                    dataGridView2.DataSource = tabla2;
                }
            }
        }

        private void txtColor_Enter(object sender, EventArgs e)
        {
            if (txtColor.Text == "Color")
            {
                txtColor.Text = "";
                txtColor.ForeColor = Color.Black;
            }
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            if (txtColor.Text == "Color")
            {
                lblColor.Visible = false;
                txtColor.ForeColor = Color.DimGray;
            }
            else
            {
                lblColor.Visible = true;
                txtColor.ForeColor = Color.Black;
            }
        }

        private void txtEstilo_TextChanged(object sender, EventArgs e)
        {
            if (txtEstilo.Text == "Estilo")
            {
                lblEstilo.Visible = false;
                txtEstilo.ForeColor = Color.DimGray;
            }
            else
            {
                lblEstilo.Visible = true;
                txtEstilo.ForeColor = Color.Black;
            }
        }

        private void txtColor_Leave(object sender, EventArgs e)
        {
            if (txtColor.Text == "")
            {
                txtColor.ForeColor = Color.DimGray;
                txtColor.Text = "Color";
            }
        }

        private void txtEstilo_Leave(object sender, EventArgs e)
        {
            /*if (txtEstilo.Text == "")
            {
                txtEstilo.ForeColor = Color.DimGray;
                txtEstilo.Text = "Estilo";
            }*/
        }

        private void txtEstilo_Enter(object sender, EventArgs e)
        {

        }

        private void txtFiltrar_Enter(object sender, EventArgs e)
        {
            if (txtFiltrar.Text == "Filtrar")
            {
                txtFiltrar.ForeColor = Color.Black;
                txtFiltrar.Text = "";
            }
        }

        private void txtFiltrar_Leave(object sender, EventArgs e)
        {
            if (txtFiltrar.Text == "")
            {
                txtFiltrar.ForeColor = Color.DimGray;
                txtFiltrar.Text = "Filtrar";
            }
        }
        //IMPORTANTE HAY QUE CONFIGURAR EL WINDOWS PARA QUE TOME ESTA CONFIGURACION DE MONEDA
        private void txtPrecio2_KeyUp(object sender, KeyEventArgs e)
        {
            FormatoText(txtPrecio2);
        }

        private void txtPrecio3_KeyUp(object sender, KeyEventArgs e)
        {
            FormatoText(txtPrecio3);
        }

        private void txtPrecio4_KeyUp(object sender, KeyEventArgs e)
        {
            FormatoText(txtPrecio4);
        }

        private void txtPrecio5_KeyUp(object sender, KeyEventArgs e)
        {
            FormatoText(txtPrecio5);
        }

        private void FormatoText(TextBox textBox)
        {
            if (!textBox.Text.Equals("$ ") && (!textBox.Text.Equals("")))
            {
                textBox.Text = CambiarFormatoPrecio(1, textBox, "");
                textBox.Text = CambiarFormatoPrecio(0, null, textBox.Text);
                textBox.Select(textBox.Text.Length, 0);
            }
            else
            {
                textBox.Text = "";
            }
        }

        private void txtCantPaca_TextChanged(object sender, EventArgs e)
        {
            if (txtCantPaca.Text == "Cant Paca")
            {
                lblCantPaca.Visible = false;
                txtCantPaca.ForeColor = Color.DimGray;
            }
            else
            {
                lblCantPaca.Visible = true;
                txtCantPaca.ForeColor = Color.Black;
            }
        }

        private void txtCantPaca_Enter(object sender, EventArgs e)
        {
            if (txtCantPaca.Text == "Cant Paca")
            {
                lblCantPaca.Visible = true;
                txtCantPaca.Text = "";
                txtCantPaca.ForeColor = Color.Black;
            }
        }

        private void txtCantPaca_Leave(object sender, EventArgs e)
        {
            if (txtCantPaca.Text == "")
            {
                lblCantPaca.Visible = false;
                txtCantPaca.ForeColor = Color.DimGray;
                txtCantPaca.Text = "Cant Paca";
            }
        }

        private void ConsultarInformacionReferencia()
        {
            ConexionMySql con = new ConexionMySql();
            string query = "SELECT * FROM tbldocumentocompradetalle WHERE strReferenciaM = '" + txtReferencia.Text + "'";
            MySqlDataReader reader = con.ConsultarInformacionContenedor(query, con.GetCxn());

            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblCantCompra.Text = reader.GetString("intCantidad");
                        lblUdmCompra.Text = reader.GetString("strUnidadMedida");
                    }
                }
                else
                {
                    MessageBox.Show("nada");
                }
            }
            else
            {
                MessageBox.Show(con.Error);
            }
            con.CerrarCnx();
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            if (txtObservacion.Text == "Observacion")
            {
                lblObservacion.Visible = false;
                txtObservacion.ForeColor = Color.DimGray;
            }
            else
            {
                lblObservacion.Visible = true;
                txtObservacion.ForeColor = Color.Black;
            }
        }
    }
}
