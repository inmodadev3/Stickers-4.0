using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ZebraPruebas.Properties;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ZebraPruebas
{
    public partial class Imprimir_Sticker : Form
    {
        private string referencia;
        private string descripcion;
        private string precio1;
        private string precio2;
        private string precio3;
        private string precio4;
        private string precio5;
        private string UDM;
        private int cantidad;
        private int columna = 0;

        private int pares = 0;
        private int individual = 0;
        private int contador = 0;
        private int countStickerVendedor = 0;
        private const int CONSULTA_OK = 1;
        private bool imprimir = true;
        private string errorHide = "";
        private int PermisoEditar = 0;
        private string NombreUsuario = "";
        private string rutaImagen = "";

        public Imprimir_Sticker(int Permiso, Form1 form1)
        {
            InitializeComponent();
            this.NombreUsuario = form1.NombreUser;
            this.PermisoEditar = Permiso;//1 Editar | 0 No Edita
            LlenarComboBox();
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Items.Add(strPrinter);
            }
            Impresoras.SelectedIndex = (Impresoras.Items.Count - 1);
            DataGrid();
            LlenarCbxSexo();
            LlenarCbxMarca();
            LlenarCbxMaterial();
            //ConsultarReferencias();
        }

        public Imprimir_Sticker(Array permisos)
        {

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

        public void LlenarCbxSexo()
        {
            Conexion con = new Conexion("select * from TblProdParametro1 where StrIdPParametro1 in ('0', '03', '2', '3', '4', '5')order by StrDescripcion asc;");
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
            Conexion con = new Conexion("select * from TblProdParametro2 where StrIdPParametro in ('0', '10', '15', '17', '18', '19', '2', '20', '21', '22', '24', '25', '26', '27', '28', '29', '3', '31', '32', '34', '35', '36', '37', '38', '39', '4', '40', '41', '42', '45', '46', '47', '48', '49', '5', '50', '51', '52', '53', '54', '55', '56', '57', '58', '59', '6', '61', '62', '63', '7', '8', '9')order by StrDescripcion asc; ");
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
            Conexion con = new Conexion("select * from tblProdParametro3 order by StrDescripcion asc");
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

        private void DataGrid()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Referencia", "Referencia");
            dataGridView1.Columns.Add("Descripcion", "Descripcion");
            dataGridView1.Columns.Add("CantPorUnidad", "Cantidad");
            dataGridView1.Columns.Add("UDM", "Unidad de medida");
            dataGridView1.Columns.Add("Precio1", "Precio 1");
            dataGridView1.Columns.Add("Precio2", "Precio 2");
            dataGridView1.Columns.Add("Precio3", "Precio 3");
            dataGridView1.Columns.Add("Precio4", "Precio 4");
            dataGridView1.Columns.Add("Precio5", "Precio 5");
            dataGridView1.Columns.Add("Dimension", "Dimension");
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["Precio1"].Visible = false;
            this.dataGridView1.Columns["Precio2"].Visible = false;
            this.dataGridView1.Columns["Precio3"].Visible = false;
            this.dataGridView1.Columns["Precio4"].Visible = false;
            this.dataGridView1.Columns["Precio5"].Visible = false;
            this.dataGridView1.Columns["CantPorUnidad"].Visible = false;
            this.dataGridView1.Columns["Dimension"].Visible = false;
        }

        public void ConsultarReferencias()
        {

            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ConsultarDetalleCompra(3, con.GetCxn());

            dataGridView1.Rows.Clear();
            if (rpta == null)
            {
                lblRpta.Text = con.Error;
                lblRpta.Visible = true;
            }
            else
            {
                if (rpta.HasRows)
                {

                    while (rpta.Read())
                    {
                        // this.descripcion = 
                        dataGridView1.Rows.Add(rpta.GetString(8), rpta.GetString(1), rpta.GetString(6), rpta.GetString(2), rpta.GetString(3), rpta.GetString(9), rpta.GetString(10), rpta.GetString(11), rpta.GetString(12), rpta.GetString(13), rpta.GetString(16));
                        //                 ID                              First name                  Last Name                    Address
                        //lblMensaje.Text = rpta.GetString(0) + " - " + rpta.GetString(1) + " - " + rpta.GetString(2) + " - " + rpta.GetString(3);
                        // Ejemplo para mostrar en el listView1 :
                        //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        //var listViewItem = new ListViewItem(row);
                        //listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    lblRpta.Text = "No se encontro nada";
                    lblRpta.Visible = true;
                }
            }
            con.CerrarCnx();
            //MessageBox.Show("fin");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Impresoras.Text != "")
            {
                if (!txtReferencia.Text.Equals("Referencia"))
                {
                    if (checkBox2.Checked)
                    {
                        PrintingBasic();
                    }
                    else
                    {
                        lblMensaje.Visible = false;
                        FormatoPrecio(0);
                        if (this.PermisoEditar == 1) { Auditoria(); ActualizarProducto(); ActualizarLoteReferenciaDash(txtReferencia.Text, txtColor.Text, txtEstilo.Text); }
                        FormatoPrecio(1);
                        Printing();
                    }

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
                            if (this.txtReferencia.TextLength > 11)
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
                        txtCantidadImpr.Text = "0";
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
            if (txtReferencia.TextLength > 11)
            {
                ps1 = new PaperSize("Custom", 310, 200);
            }
            else
            {
                ps1 = new PaperSize("Custom", 330, 110);
            }
            //Se valida el tipo de stricker
            if (txtReferencia.TextLength > 11)
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
                        if (this.txtReferencia.TextLength > 11)
                        {
                            this.countStickerVendedor++;
                            g1 = code.PintarStickerXL(g1, this.txtReferencia.Text, this.txtDescripcion.Text, this.precio1, this.precio2, this.precio3, this.precio4, this.cbxUnidadMedida.Text, this.txtCantidad.Text,
                                this.txtDimension.Text, this.txtColor.Text.Replace("Color", ""), this.txtEstilo.Text.Replace("Estilo", ""), this.countStickerVendedor);
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
                            if (this.txtReferencia.TextLength > 11)
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
                            if (this.txtReferencia.TextLength > 11)
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

                        //code.IncludeLabel = true;
                        //code.LabelPosition = LabelPositions.TOPCENTER;
                        //code.LabelFont = drawFont;
                        code.Alignment = AlignmentPositions.CENTER;

                        if (txtReferencia.TextLength <= 8)
                        {
                            if (txtReferencia.TextLength <= 4) //validar con wilson
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
                                    x = 5;
                                    w = 150;
                                    img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 200, 30);
                                }
                                else
                                {
                                    if (txtReferencia.TextLength ==15)
                                    {
                                        w = 155;
                                        x = 1;
                                        img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 205, 30);
                                    }
                                    else
                                    {
                                        if (txtReferencia.TextLength == 16)
                                        {
                                            w = 155;
                                            x = 1;
                                            img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 225, 30);
                                        }
                                        else
                                        {
                                            if (txtReferencia.TextLength == 17)
                                            {

                                                w = 155;
                                                x = 1;
                                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 230, 30);
                                                
                                            }
                                            else
                                            {
                                                x = 1;
                                                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 290, 30);
                                            }
                                        }
                                        //x = 1;
                                        //img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 290, 30);
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
                                    g.DrawImage(img, xImg, 15, w, 20);//(cant * 11)
                                    //g.DrawImage(img, xImg, 15,w,40);
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
                                    g.DrawString(this.txtReferencia.Text, drawFont, System.Drawing.Brushes.Black, (x+170), 0);
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

        private void VariosDocumentos(System.Drawing.Printing.PrintPageEventArgs e, bool Checked)
        {
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // MessageBox.Show("Printpage");
            //AsignarValores();
            // Printing();
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
                conversion = textBox.Text.Replace("$", "").Replace(".", "").Replace(",", "");
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
                this.precio3 = this.precio2.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
                this.precio4 = this.precio2.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
            }
            if (ban == 2)
            {

                this.precio1 = (Convert.ToDouble(this.precio1)).ToString("C");
                this.precio2 = (Convert.ToDouble(this.precio2)).ToString("C");
                this.precio3 = (Convert.ToDouble(this.precio3)).ToString("C");
                this.precio4 = (Convert.ToDouble(this.precio4)).ToString("C");
                this.precio5 = (Convert.ToDouble(this.precio5)).ToString("C");
            }
            /*this.precio1 = this.txtPrecio1.Text;
            this.precio1 = this.precio1.Replace("0", "N").Replace("1", "Z").Replace("2", "Y").Replace("3", "W").Replace("4", "V").Replace("5", "U").Replace("6", "S").Replace("7", "R").Replace("8", "P").Replace("9", "O");
            MessageBox.Show("precion: " + this.txtPrecio1.Text + " letras: " + txtPrecio1);*/

        }

        private void lblRpta_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatos(object sender, DataGridViewCellEventArgs e)
        {

            // FormatoPrecio(0);
            CargarDatos();
        }

        private void PintarSticker(string strReferencia, string clase, string tipo, string grupo, string linea)
        {
            string clasificacion = "";

            if (clase.Equals("GENERAL")) { clase = ""; } else { clasificacion += clase + "/"; }
            if (linea.Equals("GENERAL")) { linea = ""; } else { clasificacion += linea + "/"; }
            if (grupo.Equals("GENERAL")) { grupo = ""; } else { clasificacion += grupo + "/"; }
            if (tipo.Equals("GENERAL")) { tipo = ""; } else { clasificacion += tipo + "/"; }

            string url = "http://10.10.10.128/ownCloud/fotos_nube/" + strReferencia + ".jpg";
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel1.BackgroundImage = img;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                this.panel1.MouseClick -= panel1_MouseClick;
            }
            catch (Exception)
            {
                url = "http://app.inmodafantasy.com.co/ownCloud/fotos_nube/FOTOS%20%20POR%20SECCION%20CON%20PRECIO/" + clasificacion + strReferencia + "/" + strReferencia + "$1.jpg";
                this.rutaImagen = "http://app.inmodafantasy.com.co/ownCloud/fotos_nube/FOTOS%20%20POR%20SECCION%20CON%20PRECIO/" + clasificacion + strReferencia + "/";
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                    Stream StreamImagen = response.GetResponseStream();
                    Image img = System.Drawing.Image.FromStream(StreamImagen);
                    panel1.BackgroundImage = img;
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    panel1.MouseClick += panel1_MouseClick;
                }
                catch (Exception)
                {
                    panel1.BackgroundImage = Resources.sinfoto;
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    //MessageBox.Show(ex.ToString());
                }
            }




            /*FormatoPrecio(0);
            Barcode code = new Barcode();
            code.Alignment = AlignmentPositions.CENTER;
            Image img;
            if (txtReferencia.TextLength >= 10)
            {
                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 290, 30);
            }
            else
            {
                img = code.Encode(TYPE.CODE128, this.txtReferencia.Text, Color.Black, Color.White, 180, 30);
            }
            panelStickerCode.BackgroundImage = img;
            FormatoPrecio(1);
            lblStickerPrecio1.Text = precio1;
            lblStickerPrecio2.Text = precio2;
            lblStickerPrecio3.Text = precio3;
            lblStickerUnd.Text = cbxUnidadMedida.Text;
            lblStickerReferencia.Text = txtReferencia.Text;
            lblStickerDescripcion.Text = txtDescripcion.Text;
            lblCxU.Text = "CxU: "+txtCantidad.Text;
            lblDim.Text = "Dim: "+txtDimension.Text;*/

        }

        private void CargarDatos()
        {

            lblIdDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtReferencia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.ForeColor = Color.Black;
            int index = cbxUnidadMedida.FindString(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            cbxUnidadMedida.SelectedIndex = index;

            //CON FORMATO
            txtPrecio1.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value.ToString())).ToString("C");
            txtPrecio1.Text = txtPrecio1.Text.Replace("$", "");
            txtPrecio1.ForeColor = Color.Black;
            txtPrecio2.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value.ToString())).ToString("C");
            txtPrecio3.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value.ToString())).ToString("C");
            txtPrecio4.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[8].Value.ToString())).ToString("C");
            txtPrecio5.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[9].Value.ToString())).ToString("C");

            //SIN FORMATO 
            /*txtPrecio1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtPrecio1.ForeColor = Color.Black;

            txtPrecio2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPrecio3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtPrecio4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtPrecio5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();*/
            txtCantidad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDimension.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtDimension.ForeColor = Color.Black;
            txtCantidad.ForeColor = Color.Black;

        }

        private void ConsultarLoteReferenciaDash(string strReferencia)
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ConsultarLoteReferencia(strReferencia, con.GetCxn());
            if (rpta.HasRows)
            {
                while (rpta.Read())
                {
                    try
                    {


                        if (rpta.IsDBNull(rpta.GetOrdinal("strColor")))
                        {
                            txtColor.Text = "";
                        }
                        else
                        {
                            txtColor.Text = rpta.GetString(1);
                        }
                        if (rpta.IsDBNull(rpta.GetOrdinal("strEstilo")))
                        {
                            txtEstilo.Text = "";
                        }
                        else
                        {
                            txtEstilo.Text = rpta.GetString(0);
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());
                        throw;
                    }
                }
            }
        }

        private void ActualizarLoteReferenciaDash(string referencia, string color, string estilo)
        {
            if (!(color.Equals("Color") || estilo.Equals("Estilo")))
            {
                ConexionMySql con = new ConexionMySql();
                int rpta = con.RegistrarLoteReferencia(con.GetCxn(), referencia, color, estilo);
            }
            else
            {
                if (color.Equals("Color"))
                {
                    color = "";
                }
                if (estilo.Equals("Estilo"))
                {
                    estilo = "";
                }
                ConexionMySql con = new ConexionMySql();
                int rpta = con.RegistrarLoteReferencia(con.GetCxn(), referencia, color, estilo);
            }

        }

        private void BuscarReferencia()
        {
            try
            {

                WebServiceProducto.WSPortal client = new WebServiceProducto.WSPortal();
                client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.PreAuthenticate = true;
                var datos = client.Producto(txtBuscarReferencia.Text.ToString());
                //var s = JsonConvert.DeserializeObject<RootObject>(datos);

                List<RootObject> items = JsonConvert.DeserializeObject<List<RootObject>>(datos);
                dataGridView1.Rows.Clear();
                if (items.Count != 0)
                {
                    this.panel1.MouseClick -= panel1_MouseClick;
                    //consultar lote referencia
                    this.ConsultarLoteReferenciaDash(txtBuscarReferencia.Text.ToString());

                    foreach (var value in items)
                    {
                        txtReferencia.Text = "";
                        bool check = false;
                        switch (value.IntVigente)
                        {
                            case "1":
                                check = true;
                                break;
                            case "0":
                                check = false;
                                break;
                        }
                        Console.WriteLine(value);
                        chkActivar.Enabled = true;
                        chkActivar.Checked = check;
                        chkActivar.ForeColor = Color.Black;
                        PintarSticker(value.StrIdProducto.ToString(), value.Clase.ToString(), value.Tipo.ToString(), value.Grupo.ToString(), value.Linea.ToString());
                        lblIdDetalle.Text = value.StrIdProducto.ToString();
                        txtReferencia.Text = value.StrIdProducto.ToString();
                        txtReferencia.Tag = txtReferencia.Text;
                        txtDescripcion.Text = value.StrDescripcion.ToString();
                        txtDescripcion.Tag = txtDescripcion.Text;
                        txtDescripcion.ForeColor = Color.Black;
                        txtUbicacion.ForeColor = Color.Black;
                        txtUbicacion.Text = value.StrParam2.ToString();
                        txtUbicacion.Tag = txtUbicacion.Text;
                        int index = cbxUnidadMedida.FindString(value.StrUnidad.ToString());
                        cbxUnidadMedida.SelectedIndex = index;
                        cbxUnidadMedida.Tag = cbxUnidadMedida.Text;

                        //poner descripcion!!!!
                        /*cbxSexo.SelectedIndex = Convert.ToInt32(value.StrPParametro1.ToString());
                        cbxMarca.SelectedIndex = Convert.ToInt32(value.StrPParametro2.ToString());
                        cbxMaterial.SelectedIndex = Convert.ToInt32(value.StrPParametro3.ToString());*/
                        cbxMaterial.SelectedItem = value.Material.ToString();
                        cbxSexo.SelectedItem = value.Sexo.ToString();
                        cbxMarca.SelectedItem = value.Marca.ToString();
                        txtObservacion.Text = value.StrDescripcionCorta.ToString();

                        //CON FORMATO
                        txtPrecio1.Text = (Convert.ToDouble(value.IntPreciouno.ToString())).ToString("C");
                        txtPrecio1.Text = txtPrecio1.Text.Replace("$", "");
                        txtPrecio1.ForeColor = Color.Black;
                        txtPrecio1.Tag = txtPrecio1.Text;
                        txtPrecio2.Text = (Convert.ToDouble(value.IntPreciodos.ToString())).ToString("C");
                        txtPrecio2.Tag = txtPrecio2.Text;
                        txtPrecio3.Text = (Convert.ToDouble(value.IntPreciotres.ToString())).ToString("C");
                        txtPrecio3.Tag = txtPrecio3.Text;
                        txtPrecio4.Text = (Convert.ToDouble(value.IntPreciocuatro.ToString())).ToString("C");
                        txtPrecio4.Tag = txtPrecio4.Text;
                        txtPrecio5.Text = (Convert.ToDouble(value.IntPreciocinco.ToString())).ToString("C");
                        txtPrecio5.Tag = txtPrecio5.Text;

                        //SIN FORMATO 
                        /*txtPrecio1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        txtPrecio1.ForeColor = Color.Black;

                        txtPrecio2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        txtPrecio3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                        txtPrecio4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        txtPrecio5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();*/
                        txtCantidad.Text = value.Strauxiliar.ToString();
                        txtCantidad.Tag = txtCantidad.Text;
                        txtDimension.Text = value.StrParam3.ToString();
                        txtDimension.Tag = txtDimension.Text;
                        txtDimension.ForeColor = Color.Black;
                        txtCantidad.ForeColor = Color.Black;
                        txtCantPaca.Text = value.IntControl.Replace(".00000", "").Replace(",00000", "");
                        txtCantPaca.Tag = txtCantPaca.Text;
                        if (txtCantPaca.Text == "")
                        {
                            txtCantPaca.Text = "0";
                        }

                        /* if (!n.Equals("0"))
                         {
                             n = n.Replace(".", "").Replace("0", "");
                             if (n.Equals(""))
                             {
                                 n = "0";
                             }
                         }*/



                        /*txtReferencia.Text = value.StrIdProducto.ToString();
                        txtDescripcion.Text = value.StrDescripcion.ToString();
                        txtCantidad.Text = value.IntDias.ToString();
                        txtDimension.Text = value.StrParam3.ToString();
                        int index = cbxUnidadMedida.FindString(value.StrUnidad.ToString());
                        cbxUnidadMedida.SelectedIndex = index;
                        txtPrecio1.Text = (Convert.ToDouble(value.IntPreciouno.ToString())).ToString("C");
                        txtPrecio1.Text = txtPrecio1.Text.Replace("$", "");
                        txtPrecio1.ForeColor = Color.Black;
                        txtPrecio2.Text = (Convert.ToDouble(value.IntPreciodos.ToString())).ToString("C");
                        txtPrecio3.Text = (Convert.ToDouble(value.IntPreciotres.ToString())).ToString("C");
                        txtPrecio4.Text = (Convert.ToDouble(value.IntPreciocuatro.ToString())).ToString("C");
                        txtPrecio5.Text = (Convert.ToDouble(value.IntPreciocinco.ToString())).ToString("C");*/

                        /*dataGridView1.Rows.Add(value.StrIdProducto.ToString(), value.StrIdProducto.ToString(), value.StrDescripcion.ToString(),
                            value.IntDias.ToString(),value.StrUnidad.ToString(), value.IntPreciouno.ToString(), value.IntPreciodos.ToString(),
                            value.IntPreciotres.ToString(), value.IntPreciocuatro.ToString(), value.IntPreciocinco.ToString(), value.StrParam3.ToString());

                        CargarDatos();*/
                        if (this.PermisoEditar == 1) { btnTerminar.Enabled = true; }
                        //MessageBox.Show("id : " + id);
                    }
                }
                else
                {
                    MessageBox.Show("No existe referencia en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /* JsonTextReader reader = new JsonTextReader(new StringReader(datos));
                 while (reader.Read())
                 {
                     if (reader.Value != null)
                     {
                         MessageBox.Show("Indice: " + reader.TokenType + " valor: " + reader.Value);
                         Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                     }
                     else
                     {
                         Console.WriteLine("Token: {0}", reader.TokenType);
                     }
                 }*/
                //var rpta = client.Producto(txtReferencia.Text, "1");
                //MessageBox.Show(rpta);
                //txtReferencia.Text = rpta;
                //txtReferencia.Text = rpta;
                //txtReferencia.Text = rpta;
                //txtReferencia.Text = rpta;
                //txtReferencia.Text = rpta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al consultar, verificar error " + ex.ToString());
                errorHide = ex.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarReferencia.Text != "")
            {
                BuscarReferencia();
                ConsultarCantidadesInventaro();
            }

        }

        private void txtBuscarReferencia_Enter(object sender, EventArgs e)
        {
            if (txtBuscarReferencia.Text != "")
            {
                //BuscarReferencia();
            }

        }

        private void txtBuscarReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBuscarReferencia.Text != "")
                {
                    BuscarReferencia();
                    ConsultarCantidadesInventaro();
                }
            }
            /*if(txtBuscarReferencia.Text != "")
            {
                BuscarReferencia();
            }
            /*if (e.KeyCode == Keys.Enter)
            {
                BuscarReferencia();
            }*/
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
            if (txtCantPaca.Text.Equals("Cant Paca") || txtCantPaca.Text.Equals(""))
            {
                txtCantPaca.Focus();
                lblMensaje.Text = "Ingreses la cantidad paca";
                lblMensaje.Visible = true;
                return false;
            }
            /* if (txtCantidad.TextLength == 0 || txtCantidad.Text.Equals("CxU"))
             {
                 txtCantidad.Focus();
                 lblMensaje.Text = "Ingreses la cantidad";
                 lblMensaje.Visible = true;
                 return false;
             }
             /*if (Impresoras.Text.Equals(""))
             {
                 Impresoras.Focus();
                 lblMensaje.Text = "Seleccione la impresora";
                 lblMensaje.Visible = true;
                 return false;
             }
             if (txtDimension.Text.Equals("") || txtDimension.Text.Equals("Dimension"))
             {
                 txtDimension.Focus();
                 lblMensaje.Text = "Ingrese la dimension";
                 lblMensaje.Visible = true;
                 return false;
             }*/

            return true;

        }

        private void ConsultarCantidadesInventaro()
        {
            String connectionString =
                    @"Server=192.168.1.127\SQLEXPRESS;Database=INMODANET;Trusted_Connection=no;Uid=Hgi;Pwd=Hgi;";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string sql = "select IntCantidadFinal from QrySaldosProductos where StrProducto = '"+txtBuscarReferencia.Text+"'";

            SqlCommand cmd = new SqlCommand(sql, con) ;

            txtCantidadInventario.Text = "";
            Console.WriteLine("CMD");
            Console.WriteLine(cmd);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("READER");
                Console.WriteLine(reader);
                while (reader.Read())
                {
                    Console.WriteLine("Validando");
                    Console.WriteLine(reader[0]);

                    if (reader[0] != null)
                    {
                        Console.WriteLine("INVENTARIOS");
                        object inventario = reader[0];
                        int inventarioparseado = Convert.ToInt32(inventario);
                        txtCantidadInventario.Text = Convert.ToString(inventarioparseado);
                    }
                }
            }



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
        private async Task ActualizarProductoBukkapAsync()
        {
            try
            {
                HttpClient webclient = new HttpClient();
                var privateToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbXByZXNhX2lkIjoyLCJpYXQiOjE2NDAwMjIxNTZ9.8c3ELp1HK2ZBQe8Y0DCIGjppe6q4VI196A9ndanK608";
                var publicToken = "{\"publicToken\":\"d9b52bfa-fc88-416b-9141-007866d9dc87\"}";
                webclient.DefaultRequestHeaders.Accept.Clear();
                webclient.DefaultRequestHeaders.Add("Authorization", privateToken);
                webclient.DefaultRequestHeaders.Add("auth", publicToken);
                Console.WriteLine("entrando");
                var getproducto = await webclient.GetStringAsync("https://api.bukappweb.com:3000/api/productos/producto/" + txtReferencia.Text.ToString());
                JObject json = JObject.Parse(getproducto);
                float Calcprecio5 = float.Parse(this.precio1) / 4000;
                //Console.WriteLine(json);
                Console.WriteLine(json["data"]["subcategoria_producto2_id"].ToString() == "" ?0: (int)json["data"]["subcategoria_producto2_id"]);
                //Console.WriteLine(json["data"]["subcategoria_producto2_id"] != null ? (int)json["data"]["subcategoria_producto2_id"] : 0);
                var jsonObject = new productoBukkap()
                {
                    strIdProducto = txtReferencia.Text.ToString(),
                    strDescripcion = txtDescripcion.Text.ToString(),
                    boolHabilitado = (bool)json["data"]["boolHabilitado"],
                    strCodigoAlterno = json["data"]["strCodigoAlterno"].ToString(),
                    intPrecio1 = float.Parse(this.precio1),
                    intPrecio2 = float.Parse(this.precio2),
                    intPrecio3 = float.Parse(this.precio3),
                    intPrecio4 = float.Parse(this.precio4),
                    intPrecio5 = Calcprecio5,
                    unidad_id = (int)json["data"]["unidad_id"],
                    categoria_producto_id = json["data"]["categoria_producto_id"].ToString() != ""? (int)json["data"]["categoria_producto_id"]:0,
                    subcategoria_producto1_id = json["data"]["subcategoria_producto1_id"].ToString() != ""? (int)json["data"]["subcategoria_producto1_id"]:0,
                    subcategoria_producto2_id = json["data"]["subcategoria_producto2_id"].ToString() != ""? (int)json["data"]["subcategoria_producto2_id"]:0,
                    parametro_producto1_id = (int)json["data"]["intParametro1"],
                    parametro_producto2_id = (int)json["data"]["intParametro2"],
                    strParametroTxt1 = txtUbicacion.Text.ToString(),
                    strParametroTxt2 = json["data"]["strParametroTxt2"].ToString(),
                    strDescripcionLarga = json["data"]["strDescripcionLarga"].ToString(),
                    intPeso = (float)json["data"]["intPeso"],
                    intCubicaje = (int)json["data"]["intCubicaje"],
                    intCantidadCaja = (int)json["data"]["intCantidadCaja"],
                    intCantidadMinima = (int)json["data"]["intCantidadMinima"],
                    strCantidadPresentacion = json["data"]["intCantidadPresentacion"].ToString(),
                    strMaterial = cbxMaterial.Text.ToString(),
                    strMedida = txtDimension.Text.ToString(),
                };

                Console.WriteLine(jsonObject);
                var content = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                var stringContent = new StringContent(content);
                var myObject = new StringContent(content, Encoding.UTF8, "application/json");
                webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await webclient.PostAsync("https://api.bukappweb.com:3000/api/productos/", myObject);
                var responseString = await response.Content.ReadAsStringAsync();

                
                Console.WriteLine("saliendo");

                if ((bool)json["success"] == false)
                {
                    MessageBox.Show("Producto no actualizado en Bukkapp intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    Console.WriteLine("todo ok");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al actualizar, verificar error " + ex.ToString());
                errorHide = ex.ToString();
            }

        }
        private void ActualizarProducto()
        {
            try
            {
                WebServiceProducto.WSPortal client = new WebServiceProducto.WSPortal();
                client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.PreAuthenticate = true;
                //cbxMarca.SelectedIndex.ToString() pendiente actualizar api
                string datos = client.ActualizarProducto(txtReferencia.Text.ToString(), this.precio1, this.precio2, this.precio3, this.precio4,
                    this.precio5, txtDescripcion.Text.ToString(), cbxUnidadMedida.Text.ToString(), txtCantidad.Text.ToString(), txtDimension.Text.ToString(), "", txtCantPaca.Text.ToString(), txtUbicacion.Text.ToString()
                    , txtObservacion.Text, cbxSexo.Text.ToString(), cbxMaterial.Text.ToString(), cbxMarca.Text.ToString()); //PONER UBICACION 

                if (Int32.Parse(datos) == CONSULTA_OK)
                {
                    lblMensaje.Text = "";
                    txtUbicacion.Tag = txtUbicacion.Text;
                    txtReferencia.Tag = txtReferencia.Text;
                    txtDimension.Tag = txtDimension.Text;
                    txtDescripcion.Tag = txtDescripcion.Text;
                    txtCantidad.Tag = txtCantidad.Text;
                    txtCantPaca.Tag = txtCantPaca.Text;
                    txtPrecio1.Tag = txtPrecio1.Text;
                    txtPrecio2.Tag = txtPrecio2.Text;
                    txtPrecio3.Tag = txtPrecio3.Text;
                    txtPrecio4.Tag = txtPrecio4.Text;
                    txtPrecio5.Tag = txtPrecio5.Text;
                    cbxUnidadMedida.Tag = cbxUnidadMedida.Text;
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar " + datos.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al actualizar, verificar error " + ex.ToString());
                errorHide = ex.ToString();
            }
        }

        private void Auditoria()
        {

            if (!txtReferencia.Text.Equals(txtReferencia.Tag)) { InsertarAuditoria(txtReferencia.Tag.ToString(), txtReferencia.Text, "Referencia"); }
            if (!txtDimension.Text.Equals(txtDimension.Tag)) { InsertarAuditoria(txtDimension.Tag.ToString(), txtDimension.Text, "Dimension"); }
            if (!txtDescripcion.Text.Equals(txtDescripcion.Tag)) { InsertarAuditoria(txtDescripcion.Tag.ToString(), txtDescripcion.Text, "Descripcion"); }
            if (!txtUbicacion.Text.Equals(txtUbicacion.Tag)) { InsertarAuditoria(txtUbicacion.Tag.ToString(), txtUbicacion.Text, "Ubicacion"); }
            if (!txtCantidad.Text.Equals(txtCantidad.Tag)) { InsertarAuditoria(txtCantidad.Tag.ToString(), txtCantidad.Text, "Cantidad"); }
            if (!txtCantPaca.Text.Equals(txtCantPaca.Tag)) { InsertarAuditoria(txtCantPaca.Tag.ToString(), txtCantPaca.Text, "Cantidad Paca"); }
            if (!txtPrecio1.Text.Equals(txtPrecio1.Tag)) { InsertarAuditoria(txtPrecio1.Tag.ToString(), txtPrecio1.Text, "Precio1"); }
            if (!txtPrecio2.Text.Equals(txtPrecio2.Tag)) { InsertarAuditoria(txtPrecio2.Tag.ToString(), txtPrecio2.Text, "Precio2"); }
            if (!txtPrecio3.Text.Equals(txtPrecio3.Tag)) { InsertarAuditoria(txtPrecio3.Tag.ToString(), txtPrecio3.Text, "Precio3"); }
            if (!txtPrecio4.Text.Equals(txtPrecio4.Tag)) { InsertarAuditoria(txtPrecio4.Tag.ToString(), txtPrecio4.Text, "Precio4"); }
            if (!txtPrecio5.Text.Equals(txtPrecio5.Tag)) { InsertarAuditoria(txtPrecio5.Tag.ToString(), txtPrecio5.Text, "Precio5"); }
            if (!cbxUnidadMedida.Text.Equals(cbxUnidadMedida.Tag)) { InsertarAuditoria(cbxUnidadMedida.Tag.ToString(), cbxUnidadMedida.Text, "UDM"); }

            txtReferencia.Tag = txtReferencia.Text;
            txtDimension.Tag = txtDimension.Text;
            txtDescripcion.Tag = txtDescripcion.Text;
            txtUbicacion.Tag = txtUbicacion.Text;
            txtCantidad.Tag = txtCantidad.Text;
            txtCantPaca.Tag = txtCantPaca.Text;
            txtPrecio1.Tag = txtPrecio1.Text;
            txtPrecio2.Tag = txtPrecio2.Text;
            txtPrecio3.Tag = txtPrecio3.Text;
            txtPrecio4.Tag = txtPrecio4.Text;
            txtPrecio5.Tag = txtPrecio5.Text;
            cbxUnidadMedida.Tag = cbxUnidadMedida.Text;
        }

        private void InsertarAuditoria(string valorAnterior, string valorNuevo, string campo)
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.InsertarAuditoria(this.NombreUsuario, campo, this.txtReferencia.Text, valorAnterior, valorNuevo, con.GetCxn());
            if (rpta == null) { MessageBox.Show(con.Error); }
            con.CerrarCnx();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            if (Validar())
            {
                FormatoPrecio(0);
                Auditoria();
                ActualizarProductoBukkapAsync();
                ActualizarProducto();
                ActualizarLoteReferenciaDash(txtReferencia.Text, txtColor.Text, txtEstilo.Text);
                /*DialogResult result = MessageBox.Show("Quiere imprimir el sticker?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
           
                if (result == DialogResult.Yes)
                {
                    //AsignarValores();
                    if (Impresoras.Text != "")
                    {
                        FormatoPrecio(1);
                        Printing();

                        limpiar();
                        btnTerminar.Enabled = false;
                    }
                    else
                    {
                        lblMensaje.Text = "Seleccione la impresora";
                        lblMensaje.Visible = true;
                    }
                }
                else
                {
                    limpiar();
                    btnTerminar.Enabled = false;
                }*/


            }


        }

        private void txtPrecio1_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarPrecios();
            //PintarSticker();
        }

        private void cbxUnidadMedida_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidarPrecios();
            //PintarSticker();
        }

        private void txtDimension_Enter(object sender, EventArgs e)
        {
            if (txtDimension.Text == "Dimension")
            {
                lblDimension.Visible = true;
                txtDimension.Text = "";
                txtDimension.ForeColor = Color.Black;
            }
        }

        private void txtDimension_Leave(object sender, EventArgs e)
        {
            if (txtDimension.Text == "")
            {
                lblDimension.Visible = false;
                txtDimension.ForeColor = Color.DimGray;
                txtDimension.Text = "Dimension";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtReferencia.Text = "Referencia";
            txtDescripcion.Text = "Descripcion";
            txtUbicacion.Text = "Ubicacion";
            txtUbicacion.ForeColor = Color.DimGray;
            txtDescripcion.ForeColor = Color.DimGray;
            cbxUnidadMedida.SelectedIndex = 0;
            cbxSexo.SelectedIndex = 0;
            cbxMaterial.SelectedIndex = 0;
            cbxMarca.SelectedIndex = 0;
            txtPrecio1.Text = "Precio 1";
            txtPrecio1.ForeColor = Color.DimGray;
            txtPrecio2.Text = "Precio 2";
            txtPrecio3.Text = "Precio 3";
            txtPrecio4.Text = "Precio 4";
            txtPrecio5.Text = "Precio 5";
            txtCantidad.Text = "CxU";
            txtDimension.Text = "Dimension";
            txtEstilo.Text = "Estilo";
            txtColor.Text = "Color";
            txtCantPaca.Text = "Cant Paca";
            txtObservacion.Text = "Observacion";
            txtObservacion.ForeColor = Color.DimGray;
            txtCantPaca.ForeColor = Color.DimGray;
            txtDimension.ForeColor = Color.DimGray;
            txtCantidad.ForeColor = Color.DimGray;
            txtColor.ForeColor = Color.DimGray;
            lblIdDetalle.Text = "";
            lblMensaje.Text = "";
            lblMensaje.Visible = false;
            lblRpta.Text = "";
            lblRpta.Visible = false;
            txtBuscarReferencia.Text = "";
            chkActivar.Checked = false;
            chkActivar.Enabled = false;
            chkActivar.ForeColor = Color.Black;
        }

        private void txtPrecio1_Enter(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "Precio 1")
            {
                lblPrecio1.Visible = true;
                txtPrecio1.Text = "";
                txtPrecio1.ForeColor = Color.Black;
            }
        }

        private void txtPrecio1_Leave(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "")
            {
                lblPrecio1.Visible = false;
                txtPrecio1.ForeColor = Color.DimGray;
                txtPrecio1.Text = "Precio 1";
            }
        }

        private void txtPrecio3_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                lblDescripcion.Visible = true;
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                lblDescripcion.Visible = false;
                txtDescripcion.ForeColor = Color.DimGray;
                txtDescripcion.Text = "Descripcion";
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "CxU")
            {
                lblCantidad.Visible = true;
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.Black;
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                lblCantidad.Visible = false;
                txtCantidad.ForeColor = Color.DimGray;
                txtCantidad.Text = "CxU";
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
                txtPrecio2.ForeColor = Color.Red;
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
            if (txtCantidad.Text == "CxU")
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

        private void panelStickerCode_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            //PintarSticker();
        }

        private void cbxUnidadMedida_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxUnidadMedida_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cbxUnidadMedida_TextChanged(object sender, EventArgs e)
        {
            //PintarSticker();
        }

        private void txtBuscarReferencia_MouseEnter(object sender, EventArgs e)
        {

        }

        private void lblStickerPrecio2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtColor_Enter(object sender, EventArgs e)
        {
            if (txtColor.Text == "Color")
            {
                txtColor.Text = "";
                txtColor.ForeColor = Color.Black;
            }
        }

        private void txtEstilo_Enter(object sender, EventArgs e)
        {
            if (txtEstilo.Text == "Estilo")
            {
                txtEstilo.Text = "";
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
            if (txtEstilo.Text == "")
            {
                txtEstilo.ForeColor = Color.DimGray;
                txtEstilo.Text = "Estilo";
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionMySql con = new ConexionMySql();
            MySqlDataReader rpta = con.ConsultarDetalleCompra(4, con.GetCxn());
            string r = "";
            if (rpta.HasRows)
            {

                while (rpta.Read())
                {

                    if (rpta.IsDBNull(rpta.GetOrdinal("strReferenciaM")))
                    {
                        r = rpta.GetString("strReferencia");
                    }
                    else
                    {
                        r = rpta.GetString("strReferenciaM");
                    }
                    this.BuscarReferenciasHGI(r);
                }
            }
            MessageBox.Show("finalizo");


        }



        private void BuscarReferenciasHGI(string referencia)
        {
            try
            {
                WebServiceProducto.WSPortal client = new WebServiceProducto.WSPortal();
                client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.PreAuthenticate = true;
                var datos = client.Producto(referencia);
                //var s = JsonConvert.DeserializeObject<RootObject>(datos);

                List<RootObject> items = JsonConvert.DeserializeObject<List<RootObject>>(datos);
                if (items.Count == 0)
                {
                    /// OP46430 / OP46434 / OP46437 / PERV1025
                    txtReferencia.Text += " / " + referencia;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al consultar, verificar error");
                errorHide = ex.ToString();
            }
        }

        private void chkActivar_CheckedChanged(object sender, EventArgs e)
        {
            if (txtReferencia.Text.Length != 0)
            {
                try
                {
                    //actualizarEstadoProducto
                    WebServiceProducto.WSPortal client = new WebServiceProducto.WSPortal();
                    client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    client.PreAuthenticate = true;
                    //MessageBox.Show(txtReferencia.Text.ToString()+"  "+ txtPrecio1.Text.ToString() + "  " + txtPrecio2.Text.ToString() + "  " + txtPrecio3.Text.ToString() + "  " + txtPrecio4.Text.ToString() + "  " + txtPrecio5.Text.ToString() + "  " + txtDescripcion.Text.ToString() + "  " + cbxUnidadMedida.Text.ToString() + "  " + txtCantidad.Text.ToString() + "  " + txtDimension.Text.ToString());

                    string datos = client.ActualizarEstadoProducto(txtReferencia.Text.ToString(), Convert.ToInt32(chkActivar.Checked).ToString());
                    //MessageBox.Show(datos);
                    if (Int32.Parse(datos) == CONSULTA_OK)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al actualizar");
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Erroooor: " + ex.ToString());
                    errorHide = ex.ToString();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MOSTRAR ERRORES OCULTOS
            if (errorHide.Length == 0)
            {
                MessageBox.Show("Sin errores");
            }
            else
            {
                MessageBox.Show(errorHide);
            }
            errorHide = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiar();
        }

        private void PrintingBasic()
        {
            try
            {

                this.pares = Int32.Parse(txtCantidadImpr.Text) / 3;
                if (this.pares > 0)
                {
                    for (int i = 1; i < this.pares; i++)
                    {
                        this.columna = 3;
                        PrintingFormat();
                    }
                    if (Int32.Parse(txtCantidadImpr.Text) % 2 == 0)
                    {
                        this.pares = 0;
                        checkBox1.Checked = false;
                        txtCantidadImpr.Text = "0";
                        PrintingFormat();
                    }
                }
                if (Int32.Parse(txtCantidadImpr.Text) <= 3)
                {
                    this.individual = Int32.Parse(txtCantidadImpr.Text);
                }
                else
                {
                    this.individual = Int32.Parse(txtCantidadImpr.Text) % 3;
                }

                this.pares = 0;
                if (this.individual > 0)
                {
                    this.columna = this.individual;
                    PrintingFormat();
                }
                else
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = false;
                        PrintingFormat();
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

        private void PrintingFormat()
        {
            PrintDocument pd1 = new PrintDocument();
            pd1.PrintPage += new PrintPageEventHandler(infoAimprimir);
            // Especifica que impresora se utilizara!!
            pd1.PrinterSettings.PrinterName = Impresoras.Text;// "ZDesigner GT800 (EPL) (Copiar 1)";
            PageSettings pa1 = new PageSettings();
            pa1.Margins = new Margins(0, 0, 0, 0);
            pd1.DefaultPageSettings.Margins = pa1.Margins;
            PaperSize ps1;
            if (txtReferencia.TextLength > 11)
            {
                ps1 = new PaperSize("Custom", 420, 100);
            }
            else
            {
                ps1 = new PaperSize("Custom", 420, 50);
            }
            //Se valida el tipo de stricker
            if (txtReferencia.TextLength > 11)
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

        private void infoAimprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                using (Font fnt = new Font("Arial", 12, FontStyle.Bold))//Formato
                {
                    Graphics g1 = e.Graphics;
                    Image img;
                    BarCode code = new BarCode();
                    img = code.generarCodigo(txtReferencia.Text);



                    this.countStickerVendedor++;
                    g1 = code.PintarStickerSmall(g1, this.txtReferencia.Text, this.columna);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtUbicacion_TextChanged(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == "Ubicacion")
            {
                lblUbicacion.Visible = false;
                txtUbicacion.ForeColor = Color.DimGray;
            }
            else
            {
                lblUbicacion.Visible = true;
                txtUbicacion.ForeColor = Color.Black;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            ModalProducto modal = new ModalProducto(txtReferencia.Text, this.rutaImagen);
            modal.ShowDialog();
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

        private void cbxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidadInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidadInventario.Text == "Cantidad")
            {
     
                lblcantidadinv.Visible = false;
                txtCantidadInventario.ForeColor = Color.DimGray;
            }
            else
            {
                lblcantidadinv.Visible = true;
                txtCantidadInventario.ForeColor = Color.Black;
            }
        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_2(object sender, EventArgs e)
        {

        }

        private void lblcantidadinv_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecio5_Click(object sender, EventArgs e)
        {

        }
    }
}
public class productoBukkap
{
    public string strIdProducto { get; set; }
    public string strDescripcion { get; set; }
    public bool boolHabilitado { get; set; }
    public string strCodigoAlterno { get; set; }
    public float intPrecio1 { get; set; }
    public float intPrecio2 { get; set; }
    public float intPrecio3 { get; set; }
    public float intPrecio4 { get; set; }
    public float intPrecio5 { get; set; }
    public int unidad_id { get; set; }
    public int categoria_producto_id { get; set; }
    public int subcategoria_producto1_id { get; set; }
    public int subcategoria_producto2_id { get; set; }
    public int parametro_producto1_id { get; set; }
    public int parametro_producto2_id { get; set; }
    public string strParametroTxt1 { get; set; }
    public string strParametroTxt2 { get; set; }
    public string strDescripcionLarga { get; set; }
    public float intPeso { get; set; }
    public int intCubicaje { get; set; }
    public int intCantidadCaja { get; set; }
    public int intCantidadMinima { get; set; }
    public string strCantidadPresentacion { get; set; }
    public string strMaterial { get; set; }
    public string strMedida { get; set; }

}