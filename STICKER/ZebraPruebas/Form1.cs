using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Form1 : Form
    {

        public PanelSticker objSticker = null;
        public int EditarIngresos = 0;
        public int EditarSticker = 0;
        public string NombreUser = "";


        public Form1(Array[] permisos, string usuario)
        {
            InitializeComponent();
            Validarpermisos(permisos);
            this.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            PanelMenu.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            BtnItems.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            BtnRotulo.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            BtnManifiestos.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnIngresos.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnStickers.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnFacIM.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            lblUsuario.Text = usuario;
            this.NombreUser = usuario;
        }

        public Form1()
        {
            InitializeComponent();
            btnIngresos.Enabled = true;
            btnStickers.Enabled = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            PanelMenu.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            BtnItems.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            BtnRotulo.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            BtnManifiestos.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnIngresos.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnStickers.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnFacIM.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
        }

        private void Validarpermisos(Array[] permisos)
        {
            for (int i = 0; i < permisos.Length; i++)
            {
                try
                {
                    Array r = permisos[i];
                    int editar = Int32.Parse(r.GetValue(0).ToString());
                    int permiso = Int32.Parse(r.GetValue(1).ToString());
                    if (permiso == 22)
                    {
                        BtnRotulo.Enabled = true;
                    }
                    else if (permiso == 23)
                    {
                        BtnItems.Enabled = true;
                    }
                    else if (permiso == 24)
                    {
                        BtnManifiestos.Enabled = true;
                    }
                    else if (permiso == 25)
                    {
                        btnIngresos.Enabled = true;
                        this.EditarIngresos = editar;
                    }
                    else if (permiso == 26)
                    {
                        btnStickers.Enabled = true;
                        this.EditarSticker = editar;
                    }
                    else if (permiso == 38)
                    {
                        btnFacIM.Enabled = true;
                    }
                }
                catch (Exception exp)
                {
                    /*MessageBox.Show(exp.ToString());
                    throw;*/
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button1_Click(object sender, EventArgs e)
        {

        }




        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void LblItems_MouseHover(object sender, EventArgs e)
        { }

        private void LblItems_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            BtnMenuLateral.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
        }

        private void BtnMenuLateral_MouseLeave(object sender, EventArgs e)
        {
            BtnMenuLateral.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
        }

        private void BtnMenuLateral_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void pictureBox1_MouseHover_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
        }
        private int ConsultaItems()
        {
            return 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void AbrirFormEnPanel(Object FormHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void BtnManifiestos_Click(object sender, EventArgs e)
        {
            if (this.objSticker != null)
            {
                this.objSticker.terminarTimer();
                this.objSticker = null;
            }

            AbrirFormEnPanel(new Manifiestos());
        }

        private void BtnItems_Click(object sender, EventArgs e)
        {
            if (this.objSticker != null)
            {
                this.objSticker.terminarTimer();
                this.objSticker = null;
            }
            AbrirFormEnPanel(new Items());
        }

        private void BtnRotulo_Click(object sender, EventArgs e)
        {
            if (this.objSticker != null)
            {
                this.objSticker.terminarTimer();
                this.objSticker = null;
            }
            AbrirFormEnPanel(new Rotulo());
        }

        private void BtnStickers_Click(object sender, EventArgs e)
        {
            this.objSticker = new PanelSticker();
            AbrirFormEnPanel(this.objSticker);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.objSticker != null)
            {
                this.objSticker.terminarTimer();
                this.objSticker = null;
            }
            AbrirFormEnPanel(new Imprimir_Sticker(this.EditarSticker, this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnStickers_Click(sender, e);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFacIM_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Verificacion_Factura_IM());
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
