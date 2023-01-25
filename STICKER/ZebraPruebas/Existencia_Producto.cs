using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ZebraPruebas.Properties;

namespace ZebraPruebas
{
    public partial class Existencia_Producto : Form
    {
        string referncia;
        string ubicacion;
        public Existencia_Producto(string referencia, string ubicacion)
        {
            InitializeComponent();
            this.referncia = referencia;
            this.ubicacion = ubicacion;
            this.lblReferencia.Text = "Existe referencia: " + this.referncia;
            this.lblUbicacion.Text = "Ubicacion: " + this.ubicacion;
            this.cargarFoto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarFoto()
        {
            if (!this.referncia.Equals(""))
            {
                string url = "http://10.10.10.128/ownCloud/fotos_nube/" + this.referncia + ".jpg";
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                    Stream StreamImagen = response.GetResponseStream();
                    Image img = System.Drawing.Image.FromStream(StreamImagen);
                    panelIMG.BackgroundImage = img;
                    panelIMG.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception ex)
                {
                    panelIMG.BackgroundImage = Resources.sinfoto;
                    panelIMG.BackgroundImageLayout = ImageLayout.Stretch;
                    //MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
