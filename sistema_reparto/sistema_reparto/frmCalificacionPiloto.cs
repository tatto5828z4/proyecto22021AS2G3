using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_reparto
{
    public partial class frmCalificacionPiloto : Form
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

        /* Varibles para cambiar color de mi Boton */
        Color colorHoverBodega = Color.FromArgb(80, 115, 119);
        Color colorNormalBodega = Color.FromArgb(59, 102, 107);

        /* Codigo para mover mi panel */
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        public frmCalificacionPiloto()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            /*Componentes Iniciales*/
            lblTituloCalificacion.Visible = true;
            lblAbcCalificacion.Visible = true;
            pnlBordeCalificacion.Visible = false;

            lblRegistrarCalificacion.Visible = false;
            lblModificarCalificacion.Visible = false;
            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = false;
            

            /*Habilitando componentes*/
            pnlIdIDC.Visible = false;
            pnlIdPiloto.Visible = false;
            pnlIdPaqueteEnc.Visible = false;
            pnlIdCliente.Visible = false;
            pnlIdEmpleado.Visible = false;
            pnlFecha.Visible = false;
            pnlLlegadaTardia.Visible = false;
            pnlLlegadaTiempo.Visible = false;
            pnlPercances.Visible = false;
            pnlRetrazos.Visible = false;
            pnlObservaciones.Visible = false;
            txtBuscarCalificacion.Visible = false;

            pnlBotonCalificacion.Visible = false;
            dgvCalificacion.Visible = false;
            pnlLlenarCamposCDC.Visible = false;
            pnlLLenarCamposC.Visible = false;
            pnlActivarC.Visible = false;
            pnlDarBajaC.Visible = false;
            pnlModificarC.Visible = false;
            pnlBotonGuardarC.Visible = false;
            /*Fin habilitando componentes*/

        }

        private void frmCalificacionPiloto_Load(object sender, EventArgs e)
        {

        }

        private void frmCalificacionPiloto_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblAbcCalificacion_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lblAbcCalificacion_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeCalificacion.Visible = true;

            lblRegistrarCalificacion.Visible = true;
            lblModificarCalificacion.Visible = true;
            
            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = false;
            

        }

        private void lblRegistrarCalificacion_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeRegistrar.Visible = true;
            pnlBordeModificar.Visible = false;
            

            /*Habilitando componentes*/
            pnlIdIDC.Visible = true;
            pnlIdPiloto.Visible = true;
            pnlIdPaqueteEnc.Visible = true;
            pnlIdCliente.Visible = true;
            pnlIdEmpleado.Visible = true;
            pnlFecha.Visible = true;
            pnlLlegadaTardia.Visible = true;
            pnlLlegadaTiempo.Visible = true;
            pnlPercances.Visible = true;
            pnlRetrazos.Visible = true;
            pnlObservaciones.Visible = true;
            txtBuscarCalificacion.Visible = true;

            pnlBotonCalificacion.Visible = true;
            dgvCalificacion.Visible = true;
            pnlLlenarCamposCDC.Visible = true;
            pnlLLenarCamposC.Visible = true;
            pnlActivarC.Visible = true;
            pnlDarBajaC.Visible = true;
            pnlModificarC.Visible = true;
            pnlBotonGuardarC.Visible = true;
            /*Fin habilitando componentes*/

            /*Habilitando componentes*/
            pnlIdIDC.Enabled = true ;
            pnlIdPiloto.Enabled = true;
            pnlIdPaqueteEnc.Enabled = true;
            pnlIdCliente.Enabled = true;
            pnlIdEmpleado.Enabled = true;
            pnlFecha.Enabled = true;
            pnlLlegadaTardia.Enabled = true;
            pnlLlegadaTiempo.Enabled = true;
            pnlPercances.Enabled = true;
            pnlRetrazos.Enabled = true;
            pnlObservaciones.Enabled = true;
            txtBuscarCalificacion.Enabled = true;

            /*Fin habilitando componentes*/
        }

        private void lblModificarCalificacion_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = true;
            

            /*Habilitando componentes*/
            pnlIdIDC.Visible = true;
            pnlIdPiloto.Visible = true;
            pnlIdPaqueteEnc.Visible = true;
            pnlIdCliente.Visible = true;
            pnlIdEmpleado.Visible = true;
            pnlFecha.Visible = true;
            pnlLlegadaTardia.Visible = true;
            pnlLlegadaTiempo.Visible = true;
            pnlPercances.Visible = true;
            pnlRetrazos.Visible = true;
            pnlObservaciones.Visible = true;
            txtBuscarCalificacion.Visible = true;

            pnlBotonCalificacion.Visible = true;
            dgvCalificacion.Visible = true;
            pnlLlenarCamposCDC.Visible = true;
            pnlLLenarCamposC.Visible = true;
            pnlActivarC.Visible = true;
            pnlDarBajaC.Visible = true;
            pnlModificarC.Visible = true;
            pnlBotonGuardarC.Visible = true;
            /*Fin habilitando componentes*/

            /*Habilitando componentes*/
            pnlIdIDC.Enabled = false;
            pnlIdPiloto.Enabled = true;
            pnlIdPaqueteEnc.Enabled = true;
            pnlIdCliente.Enabled = true;
            pnlIdEmpleado.Enabled = true;
            pnlFecha.Enabled = true;
            pnlLlegadaTardia.Enabled = true;
            pnlLlegadaTiempo.Enabled = true;
            pnlPercances.Enabled = true;
            pnlRetrazos.Enabled = true;
            pnlObservaciones.Enabled = true;
            txtBuscarCalificacion.Enabled = true;
            /*Fin habilitando componentes*/
        }

        private void lblEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = false;
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
