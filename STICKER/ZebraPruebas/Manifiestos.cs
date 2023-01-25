using Spire.Pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Manifiestos : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public Manifiestos()
        {
            InitializeComponent();
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

        private void CbBaseD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtTransaccion_Enter(object sender, EventArgs e)
        {
            if (TxtTransaccion.Text == "Transaccion")
            {
                TxtTransaccion.Text = "";
                TxtTransaccion.ForeColor = Color.Black;
            }
        }

        private void TxtTransaccion_Leave(object sender, EventArgs e)
        {
            if (TxtTransaccion.Text == "")
            {
                TxtTransaccion.ForeColor = Color.DimGray;
                TxtTransaccion.Text = "Transaccion";
            }
        }

        private void TxtDocumento_Enter(object sender, EventArgs e)
        {
            if (TxtDocumento.Text == "Documento")
            {
                TxtDocumento.Text = "";
                TxtDocumento.ForeColor = Color.Black;
            }
        }

        private void TxtDocumento_Leave(object sender, EventArgs e)
        {
            if (TxtDocumento.Text == "")
            {
                TxtDocumento.ForeColor = Color.DimGray;
                TxtDocumento.Text = "Documento";
            }
        }

        private void TxtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtTransaccion.Text, "[^0-9]"))
            {

                TxtDocumento.Text = TxtTransaccion.Text.Remove(TxtTransaccion.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Bd = "";
            if (CbBaseD.Text == "Blanca")
            {
                Bd = "INMODANET";
            }
            else
            {
                Bd = "VERDENET";
            }
            Productos.DataSource = bindingSource1;
            GetData("1", "USE " + Bd + "; select StrSerie as #,StrProducto as Referencia,IntValorUnitario AS Precio,IntCantidad AS Cantidad,IntValorTotal as Total,StrParam1 as Manifiesto FROM TblDetalleDocumentos " +
                    " INNER JOIN TblProductos ON TblDetalleDocumentos.StrProducto = TblProductos.StrIdProducto" +
                    " INNER JOIN TblDocumentos ON TblDetalleDocumentos.IntDocumento = TblDocumentos.IntDocumento and TblDocumentos.IntTransaccion = TblDetalleDocumentos.IntTransaccion" +
                    " WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + " AND TblDocumentos.IntDocumento = " + TxtDocumento.Text + "Order by IntId");
            ManifiestosImp.DataSource = bindingSource2;
            GetData("2", "USE " + Bd + "; Select distinct StrParam1 as Manifiesto FROM TblProductos " +
                    " INNER JOIN TblDetalleDocumentos ON TblProductos.StrIdProducto = TblDetalleDocumentos.StrProducto" +
                    " Where IntTransaccion = " + TxtTransaccion.Text + " And IntDocumento =  " + TxtDocumento.Text + "");
        }
        private void GetData(String Source, string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    @"Server=192.168.1.127\SQLEXPRESS;Database=INMODANET;Trusted_Connection=no;Uid=Hgi;Pwd=Hgi;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                if (Source == "1")
                    bindingSource1.DataSource = table;
                else
                {
                    if (Source == "2")
                        bindingSource2.DataSource = table;
                    else
                        bindingSource3.DataSource = table;
                }

                // Resize the DataGridView columns to fit the newly loaded content.
                Productos.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ManifiestosImp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String Mani = ManifiestosImp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"c:\MANIFIESTOS\" + Mani + ".pdf";
                proc.Start();

                Console.WriteLine(@"\\10.10.10.128\inmoda\MANIFIESTOS\" + Mani + ".pdf");
                MessageBox.Show(ManifiestosImp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentra el manifiesto \r\n" + ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Bd = "";
            if (CbBaseD.Text == "Blanca")
            {
                Bd = "INMODANET";
            }
            else
            {
                Bd = "VERDENET";
            }
            ManifiestoPrd.DataSource = bindingSource3;
            GetData("3", " Select distinct StrParam1 AS Manifiesto FROM TblProductos " +
                    " Where StrIdProducto = '" + TxtProducto.Text + "'");
        }

        private void ManidiestoPrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String Mani = ManifiestoPrd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"c:\MANIFIESTOS\" + Mani + ".pdf";
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentra el manifiesto \r\n" + ex.Message);
            }
        }

        private void TxtProducto_Enter(object sender, EventArgs e)
        {
            if (TxtProducto.Text == "Referencia")
            {
                TxtProducto.Text = "";
                TxtProducto.ForeColor = Color.Black;
            }
        }

        private void TxtProducto_Leave(object sender, EventArgs e)
        {
            if (TxtProducto.Text == "")
            {
                TxtProducto.ForeColor = Color.DimGray;
                TxtProducto.Text = "Referencia";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string maniNoExists = "";
            string[] mani = new string[100];
            if (ManifiestosImp.RowCount != 0)
            {
                int i = 0;
                foreach (DataGridViewRow row in ManifiestosImp.Rows)
                {
                    try
                    {
                        string Mani = row.Cells[0].Value.ToString();
                        string ruta = @"C:\MANIFIESTOS\" + Mani + ".pdf";
                        if (File.Exists(ruta))
                        {
                            PdfDocument pdf = new PdfDocument();

                            pdf.LoadFromFile(ruta);




                            /*  //ABRIR VENTANA DE IMPRESION
                              PrintDialog dialogPrint = new PrintDialog();
                              dialogPrint.AllowPrintToFile = true;
                              dialogPrint.AllowSomePages = true;
                              dialogPrint.PrinterSettings.MinimumPage = 1;
                              dialogPrint.PrinterSettings.MaximumPage = pdf.Pages.Count;
                              dialogPrint.PrinterSettings.FromPage = 1;
                              dialogPrint.PrinterSettings.ToPage = pdf.Pages.Count;

                              if (dialogPrint.ShowDialog() == DialogResult.OK){
                                   //Set the pagenumber which you choose as the start page to print
                                   pdf.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                                   //Set the pagenumber which you choose as the final page to print
                                   pdf.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                                   //Set the name of the printer which is to print the PDF
                                   pdf.PrinterName = dialogPrint.PrinterSettings.PrinterName;
                                   pdf.Print();
                                }*/




                            //IMPRIMIR CADA PDF
                            /*PdfPageSettings ps = new PdfPageSettings();

                            var letter = PdfPageSize.A4;*/

                            /*ps.Orientation = PdfPageOrientation.Landscape;
                            ps.Margins.Top = 10;
                            ps.Margins.Bottom = 10;
                            ps.Size = letter;

                            pdf.PageSettings = ps;*/


                            /*pdf.PageSettings.Size = PdfPageSize.A3;
                            pdf.PageSettings.Orientation = PdfPageOrientation.Landscape;*/
                            //pdf.PageScaling = PdfPrintPageScaling.CustomSacle;
                            //pdf.CustomScaling = 50;


                            /* pdf.PrintSettings.SelectSinglePageLayout(Spire.Pdf.Print.PdfSinglePageScalingMode.CustomScale, true, 50f);
                             pdf.PrintSettings.PrinterName = Impresoras.Text;
                             pdf.PrintSettings.Duplex = System.Drawing.Printing.Duplex.Horizontal;*/


                            pdf.Print();
                        }
                        else
                        {
                            //maniNoExists += Mani + "\n";
                            mani[i] = Mani;
                            i++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                }
                string informacion = "";
                foreach (DataGridViewRow row in Productos.Rows)
                {
                    string Mani = row.Cells[5].Value.ToString();
                    string referencia = row.Cells[1].Value.ToString();
                    if (Array.Exists(mani, elemnt => elemnt == Mani))
                    {
                        /*while (true)
                        {
                            int index = Array.FindIndex(mani, elemnt => elemnt == Mani);
                            if(index == -1)
                            {
                                break;
                            }
                            else
                            {
                                mani[index] = null;
                            }
                        }*/


                        maniNoExists += "Manifiesto: " + Mani + "\tRef: " + referencia + "\n";
                    }
                    //maniNoExists += "Manifiesto: " + Mani + "\tRef: " + referencia + "\n";
                }
                if (!maniNoExists.Equals(""))
                {
                    MessageBox.Show("Los siguientes manifientos no existen: \n" + maniNoExists, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Sin informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManifiestosImp_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void TxtDocumento_AcceptsTabChanged(object sender, EventArgs e)
        {

        }
    }


}
