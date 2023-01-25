using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Rotulo : Form
    {
        private SqlDataAdapter dataAdapter;

        public Rotulo()
        {
            InitializeComponent();
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Items.Add(strPrinter);
            }
            Impresoras.SelectedIndex = (Impresoras.Items.Count - 1);
            CbBaseD.SelectedIndex = (CbBaseD.Items.Count - 1);
        }

        private void BuscarDocumento()
        {
            if (TxtDocumento.Text.Equals("") || TxtTransaccion.Text.Equals("") || TxtDocumento.Text.Equals("Documento") || TxtTransaccion.Text.Equals("Transaccion"))
            {
                MessageBox.Show("Por favor ingresar todos los datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimpiarInfo();
                String Bd = "";
                if (CbBaseD.Text == "Blanca")
                {
                    Bd = "INMODANET";
                }
                else
                {
                    Bd = "VERDENET";
                }

                string sql = "USE " + Bd + @"; if((select TblDocumentos.StrReferencia1 FROM TblDocumentos 
inner join TblTerceros on TblTerceros.StrIdTercero = TblDocumentos.StrTercero
WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento = " + TxtDocumento.Text + @") != '0' and 
(select TblDocumentos.StrReferencia2 FROM TblDocumentos 
inner join TblTerceros on TblTerceros.StrIdTercero = TblDocumentos.StrTercero
WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento =  " + TxtDocumento.Text + @") != '0')begin
		select tblTerceros.StrNombre, TblDocumentos.StrReferencia1, TblDocumentos.StrReferencia2, TblTerceros.StrTelefono, tblTerceros.StrCelular  
        FROM TblDocumentos 
		inner join TblTerceros on TblTerceros.StrIdTercero = TblDocumentos.StrTercero
		inner join TblCiudades on TblCiudades.StrIdCiudad = TblTerceros.StrCiudad
		WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento =  " + TxtDocumento.Text + @"
	end
else begin
	if((select TblDocumentos.IntVinculado FROM TblDocumentos 
		inner join TblTerceros on TblTerceros.StrIdTercero = TblDocumentos.StrTercero
		WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento =  " + TxtDocumento.Text + @") != '0') begin
			select  tblTerceros.StrNombre, TblVinculados.StrDireccion, TblCiudades.StrDescripcion , TblVinculados.StrTelefono,  TblVinculados.StrTercero
			FROM TblDocumentos 
            inner join tblTerceros on tblTerceros.StrIdTercero = TblDocumentos.strtercero
			inner join TblVinculados on TblVinculados.IntIdVinculado = TblDocumentos.IntVinculado and TblVinculados.StrTercero = TblDocumentos.strtercero
			inner join TblCiudades on TblCiudades.StrIdCiudad = TblVinculados.strZona
			WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento =  " + TxtDocumento.Text + @"
	end
	else begin
		select TblTerceros.StrNombre, TblTerceros.StrDireccion, TblCiudades.StrDescripcion, TblTerceros.StrTelefono, TblTerceros.StrCelular 
        FROM TblDocumentos 
		inner join TblTerceros on TblTerceros.StrIdTercero = TblDocumentos.StrTercero
		inner join TblCiudades on TblCiudades.StrIdCiudad = TblTerceros.StrCiudad
		WHERE TblDocumentos.IntTransaccion = " + TxtTransaccion.Text + @" AND TblDocumentos.IntDocumento =  " + TxtDocumento.Text + @"
	end
end";

                GetData("1", sql);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarDocumento();
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

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(selectCommand, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.FieldCount == 5)
                        {
                            this.cbxContacto.Items.Add(sqlDataReader.GetString(4));
                        }
                        if ((sqlDataReader.IsDBNull(0)))
                        {
                            //this.txtDestino.ReadOnly = false;
                        }
                        else
                        {
                            this.txtDestino.Text = sqlDataReader.GetString(0);
                        }
                        if ((sqlDataReader.IsDBNull(1)))
                        {
                            //this.txtDireccion.ReadOnly = false;
                        }
                        else
                        {
                            this.txtDireccion.Text = sqlDataReader.GetString(1);
                        }

                        if ((sqlDataReader.IsDBNull(2)))
                        {
                            //this.txtCiudad.ReadOnly = false;
                        }
                        else
                        {
                            this.txtCiudad.Text = sqlDataReader.GetString(2);
                        }

                        if ((sqlDataReader.IsDBNull(3)))
                        {

                        }
                        else
                        {
                            this.cbxContacto.Items.Add(sqlDataReader.GetString(3));
                        }



                        this.cbxContacto.SelectedIndex = 0;
                    }
                    Console.WriteLine(sqlDataReader.FieldCount);
                }
                else
                {
                    MessageBox.Show("Sin información..", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarInfo();
                }



            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LimpiarInfo()
        {
            this.txtCiudad.Text = "";
            this.txtDestino.Text = "";
            this.txtDireccion.Text = "";
            this.cbxContacto.Text = "";
            this.cbxContacto.Items.Clear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Impresoras.Text != "")
            {
                Printing();
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
                int cant = Int32.Parse(txtCantidadImpr.Text);
                for (int i = 1; i <= cant; i++)
                {
                    PrintingFormat();
                }

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

            ps1 = new PaperSize("Custom", 3000, 750);

            pd1.DefaultPageSettings.PaperSize = ps1;
            pd1.DefaultPageSettings.Landscape = true;
            pd1.Print();
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

                    g1 = code.PintarStickerRotulo(g1, this.txtDestino.Text, this.txtDireccion.Text, this.txtCiudad.Text, this.cbxContacto.Text);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TxtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BuscarDocumento();
            }
        }

        private void TxtDocumento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
