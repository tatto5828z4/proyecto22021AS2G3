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
    public partial class frmRegistro : Form
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

        public frmRegistro()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            txtTipoPer.Enabled = false;
            txtTipoPer.Text = "Administrador";
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {

        }

        private void frmRegistro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlGuardarU_MouseClick(object sender, MouseEventArgs e)
        {
            String idUsuario = txtCodigoUsuario.Text;
            String pass = txtContraseñaU.Text;
            String confirmPass = txtConfirmarC.Text;
            String nombreUsuario = txtUsuario.Text;

            if(pass == confirmPass)
            {
                LoginC login = new LoginC(idUsuario, pass, nombreUsuario);

                login.funInsertarUsuario();

                frmLogin loginfr = new frmLogin();
                loginfr.Visible = true;

                Visible = false;
            }
            else
            {
                MessageBox.Show("Ingrese Datos Correctamente!");
            }
        }
    }
}
