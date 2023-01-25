using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Items : Form
    {
        int i = 0;
        int NumeroItems = 0;
        int swMenu = 0;
        Conexion con;
        Boolean Ejecutado;
        SqlDataReader Reader;
        public Items()
        {
            InitializeComponent();
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Items.Add(strPrinter);
            }
            Impresoras.SelectedIndex = (Impresoras.Items.Count - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtNumeroItems.Text)) { }
            else
            {
                NumeroItems = Int32.Parse(TxtNumeroItems.Text);
                Double Numero = NumeroItems / 4;
                Double NumeroImpresiones = Math.Ceiling(Numero);
                if (Impresoras.Text != "")
                {
                    for (i = 1; i <= NumeroItems; i = i + 4)
                    {
                        Printing(NumeroImpresiones);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Impresora");
                }
            }
        }
        private void Printing(Double NumeroImpresiones)
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
                        string caption;
                        if (i <= NumeroItems)
                        {
                            caption = string.Format("{0}", i);//Texto de la etiqueta
                            g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 25, 5);//posicion del texto
                        }
                        if (i + 1 <= NumeroItems)
                        {
                            caption = string.Format("{0}", i + 1);
                            g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 125, 5);
                        }
                        if (i + 2 <= NumeroItems)
                        {
                            caption = string.Format("{0}", i + 2);
                            g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 210, 5);
                        }
                        if (i + 3 <= NumeroItems)
                        {
                            caption = string.Format("{0}", i + 3);
                            g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 310, 5);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }

        private void TxtTransaccion_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtTransaccion.Text, "[^0-9]"))
            {

                TxtTransaccion.Text = TxtTransaccion.Text.Remove(TxtTransaccion.Text.Length - 1);
            }
        }

        private void TxtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtDocumento.Text, "[^0-9]"))
            {

                TxtDocumento.Text = TxtTransaccion.Text.Remove(TxtDocumento.Text.Length - 1);
            }
        }

        private void TxtTransaccion_Enter(object sender, EventArgs e)
        {
            if (TxtTransaccion.Text == "Transaccion")
            {
                TxtTransaccion.Text = "";
                TxtTransaccion.ForeColor = Color.Black;
            }
        }

        private void TxtNumeroItems_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtNumeroItems.Text, "[^0-9]"))
            {

                TxtNumeroItems.Text = TxtTransaccion.Text.Remove(TxtNumeroItems.Text.Length - 1);
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

        private void TxtNumeroItems_Enter(object sender, EventArgs e)
        {

            if (TxtNumeroItems.Text == "Items")
            {
                TxtNumeroItems.Text = "";
                TxtNumeroItems.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
