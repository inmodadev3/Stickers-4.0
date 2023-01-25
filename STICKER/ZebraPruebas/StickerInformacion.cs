using System;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class StickerInformacion : Form
    {
        public bool continuar;
        public StickerInformacion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.continuar = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.continuar = false;
            this.Close();
        }

        private void StickerInformacion_Load(object sender, EventArgs e)
        {

        }
    }
}
