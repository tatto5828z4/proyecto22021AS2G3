using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using sistema_reparto.Clases;

namespace sistema_reparto
{
    public partial class frmLogin : Form
    {
        /* Codigo para redondear mi panel */
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );



        /* Codigo para mover mi panel */
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public frmLogin()
        {
            InitializeComponent();
            pnlDes.Visible = false;
            btnLogin.Enabled = false;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            LoginC login = new LoginC();

            bool cantidadUsuarios = login.funCantidadUsuarios();

            if (cantidadUsuarios == false)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                pnlDes.Visible = true;
            }
        }

        

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseClick(object sender, MouseEventArgs e)
        {
            /*Obtenemos codigo de usuario y contraseña */
            Login.idUsuario = txtID.Text;
            Login.passUsuario = txtPass.Text;

            LoginC login = new LoginC();

            bool usuarioEncontrado = login.funBuscandoUsuario();

            if(usuarioEncontrado == true)
            {
                MessageBox.Show("Bienvenido!");

                frmPrincipal cliente = new frmPrincipal();
                cliente.Visible = true;

                Visible = false;
            }
            else
            {
                MessageBox.Show("Datos Ingresado Incorrectos,por favor intente de nuevo!");
                txtID.Text = "";
                txtPass.Text = "";
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pnlOk_MouseClick(object sender, MouseEventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            registro.Visible = true;

            Visible = false;
        }
    }
}
