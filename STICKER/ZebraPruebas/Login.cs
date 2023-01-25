using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ZebraPruebas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            panel1.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Array[] permisos = new Array[37];
            string usuario = "";
            if (validarCampos())
            {
                ConexionMySql con = new ConexionMySql();
                MySqlDataReader dr = con.Validarlogin(txtUser.Text, txtPass.Text, con.GetCxn());
                try
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int i = 0;
                            string rpta = "-1";
                            int ban = 1;
                            while (dr.Read())
                            {
                                if (dr.GetString(0).Equals("0"))
                                {
                                    ban = 0;
                                }
                                else
                                {
                                    if (dr.GetString("intVer").Equals("1"))
                                    {
                                        usuario = dr.GetString("strNombreEmpleado");
                                        int[] acciones = new int[2];
                                        acciones[0] = Int32.Parse(dr.GetString("intEditar"));
                                        acciones[1] = Int32.Parse(dr.GetString("idPermiso"));
                                        permisos[i] = acciones;
                                        i++;
                                        rpta = dr.GetString("Estado");
                                    }
                                }

                            }
                            if (ban == 1)
                            {
                                if (rpta.Equals("1"))
                                {
                                    this.Hide();
                                    Form1 frm = new Form1(permisos, usuario);
                                    frm.ShowDialog();
                                }
                            }
                            else
                            {
                                lblError.Text = dr.GetString(1).ToString();
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No tiene permisos asociados. " + ex.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private bool validarCampos()
        {
            lblError.Text = "";
            if (txtUser.Text == "")
            {
                lblError.Text = "Ingrese usuario";
                return false;
            }
            else if (txtPass.Text == "")
            {
                lblError.Text = "Ingrese contraseña";
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
