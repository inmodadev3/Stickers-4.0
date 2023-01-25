using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ZebraPruebas.Properties;

namespace ZebraPruebas
{
    public partial class ModalProducto : Form
    {
        private string referencia = "";
        private string url = "";
        private int i = 4;
        public ModalProducto(string referencia, string url)
        {
            this.referencia = referencia;
            this.url = url;
            InitializeComponent();
            this.main();
        }

        private void main()
        {
            panel1.BackgroundImage = null;
            try
            {
                string urlImg = this.url + "/" + this.referencia + "$1.jpg";
                HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel2.BackgroundImage = img;
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {
                panel2.BackgroundImage = Resources.sinfoto;
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
                //MessageBox.Show(ex.ToString());
            }

            try
            {
                string urlImg = this.url + "/" + this.referencia + "$2.jpg";
                HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel3.BackgroundImage = img;
                panel3.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {
                panel3.BackgroundImage = Resources.sinfoto;
                panel3.BackgroundImageLayout = ImageLayout.Stretch;
                //MessageBox.Show(ex.ToString());
            }

            try
            {
                string urlImg = this.url + "/" + this.referencia + "$3.jpg";
                HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel4.BackgroundImage = img;
                panel4.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {
                panel4.BackgroundImage = Resources.sinfoto;
                panel4.BackgroundImageLayout = ImageLayout.Stretch;
                //MessageBox.Show(ex.ToString());
            }

            try
            {
                string urlImg = this.url + "/" + this.referencia + "$4.jpg";
                HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel5.BackgroundImage = img;
                panel5.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {
                panel5.BackgroundImage = Resources.sinfoto;
                panel5.BackgroundImageLayout = ImageLayout.Stretch;
                //MessageBox.Show(ex.ToString());
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            this.Dispose();
            this.Close();

        }






        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                this.i = this.i + 1;
                string urlImg = this.url + "/" + this.referencia + "$" + (this.i) + ".jpg";
                HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                Stream StreamImagen = response.GetResponseStream();
                Image img = System.Drawing.Image.FromStream(StreamImagen);
                panel1.BackgroundImage = img;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
            }
            catch (Exception)
            {
                this.i = 4;
                panel1.BackgroundImage = null;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            bool ban = true;
            while (ban)
            {
                try
                {
                    this.i = this.i - 1;
                    if (this.i == 3)
                    {
                        this.i = 10;
                    }
                    if (this.i == 4)
                    {
                        panel1.BackgroundImage = null;
                        panel2.Visible = true;
                        panel3.Visible = true;
                        panel4.Visible = true;
                        panel5.Visible = true;
                        ban = false;
                    }
                    else
                    {
                        string urlImg = this.url + "/" + this.referencia + "$" + (this.i) + ".jpg";
                        HttpWebRequest request = WebRequest.Create(urlImg) as HttpWebRequest;
                        HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                        Stream StreamImagen = response.GetResponseStream();
                        Image img = System.Drawing.Image.FromStream(StreamImagen);
                        panel1.BackgroundImage = img;
                        panel1.BackgroundImageLayout = ImageLayout.Stretch;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        panel4.Visible = false;
                        panel5.Visible = false;
                        ban = false;
                    }


                }
                catch (Exception)
                {
                    if (this.i == 5)
                    {
                        this.i = 4;
                        this.BackgroundImage = null;
                        panel2.Visible = true;
                        panel3.Visible = true;
                        panel4.Visible = true;
                        panel5.Visible = true;
                        ban = false;
                    }

                }
            }

        }
    }
}
