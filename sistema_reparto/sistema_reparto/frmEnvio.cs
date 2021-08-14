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
    public partial class frmEnvio : Form
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
        Color colorHoverEnvio = Color.FromArgb(80, 115, 119);
        Color colorNormalEnvio = Color.FromArgb(59, 102, 107);


        /* Codigo para mover mi panel */
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public frmEnvio()
        {
            InitializeComponent();

            /*LLENADO DE COMBOBOX*/
            /*Llamando Combobox*/
            Envio envio = new Envio();
            envio.cargarCombobox(cbxPiloto, "piloto", "idPiloto", "nombrePiloto");
            envio.cargarCombobox(cbxIdTransporte, "transporte", "idTransporte", "nombreTransporte");      
            envio.cargarCombobox(cbxIdRuta, "ruta", "idRuta", "idRuta");
            envio.cargarCombobox(cbxMoBodega, "movimientoBodega", "idMovBodega", "idMovBodega");

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            webBrowser1.ScriptErrorsSuppressed = true;

            pnlBordeEn.Visible = false;
            lblRegistrarEnvio.Visible = false;
            pnlBordeRegistrar.Visible = false;
            lblModificarEnvio.Visible = false;
            pnlBordeModificar.Visible = false;
            pnlCampoIdPiloto.Visible = false;
            pnlOrdenEnvio.Visible = false;
            pnlIdTransporte.Visible = false;
            pnlEstatusEnvio.Visible = false;
            pnlRuta.Visible = false;
            pnlMoBodega.Visible = false;
            pnlFechaEnvio.Visible = false;
            pnlBotonGuardarEnvio.Visible = false;
            txtBuscarEnvio.Visible = false;
            pnlBotonBuscarEnvio.Visible = false;
            dgvEnvio.Visible = false;
            pnlLLenarCamposEnvio.Visible = false;
            txtIdRuta.Visible = false;
            pnlIdRuta.Visible = false;
            dgvRuta.Visible = false;
            
            pnlModificarEnvio.Visible = false;
            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            pnlLlenarCamposEDB.Visible = false;
            lblCambiaEstado.Visible = false;
            pnlCambiaEstado.Visible = false;
            pnlEntregado.Visible = false;



        }

        private void pnlEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            frmEnvio obj = new frmEnvio();

            obj.Visible = true;

            Visible = false;
        }

        private void lblEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            frmEnvio obj = new frmEnvio();

            obj.Visible = true;

            Visible = false;
        }

        private void picEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            frmEnvio obj = new frmEnvio();

            obj.Visible = true;

            Visible = false;
        }

        private void btnCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal obj = new frmPrincipal();

            obj.Visible = true;

            Visible = false;
        }

        private void lblCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal obj = new frmPrincipal();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal obj = new frmPrincipal();

            obj.Visible = true;

            Visible = false;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAbcEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeEn.Visible = true;
            lblRegistrarEnvio.Visible = true;
            lblModificarEnvio.Visible = true;

            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            lblCambiaEstado.Visible = true;
            
            pnlCambiaEstado.Visible = false;

        }

        public void mapa()
        {
            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://www.google.com/maps?=");

            webBrowser1.Navigate(queryaddress.ToString());
        }




        private void lblRegistrarEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            funCargarTablaRuta(null);
           // String buscarE = txtBuscarEnvio.Text;
            funCargarTabla(null);
            mapa();
            pnlBordeRegistrar.Visible = true;
            pnlCampoIdPiloto.Visible = true;
            pnlOrdenEnvio.Visible = true;
            pnlIdTransporte.Visible = true;
            pnlEstatusEnvio.Visible = true;
            pnlRuta.Visible = true;
            pnlMoBodega.Visible = true;
            pnlFechaEnvio.Visible = true;
            pnlBotonGuardarEnvio.Visible = true;
            txtBuscarEnvio.Visible = true;
            pnlBotonBuscarEnvio.Visible = true;
            dgvEnvio.Visible = true;
            pnlLLenarCamposEnvio.Visible = true;
            txtIdRuta.Visible = true;
            pnlIdRuta.Visible = true;
            dgvRuta.Visible = true;
           
            pnlBordeModificar.Visible = false;
            pnlModificarEnvio.Visible = false;
            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            pnlLlenarCamposEDB.Visible = false;
            pnlCambiaEstado.Visible = false;
            
            /*Desabilitando Campos*/
            pnlOrdenEnvio.Visible = false;
            txtOrdenEnvio.Enabled = false;
            pnlEstatusEnvio.Visible = false;

            pnlEntregado.Visible = false;
        }

        private void lblModificarEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            funCargarTabla(null);
            funVaciarCampos();
            funCargarTablaRuta(null);
            //String buscarE = txtBuscarEnvio.Text;
            funCargarTabla(null);
            mapa();

            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = true;

            pnlBotonGuardarEnvio.Visible = false;
            pnlModificarEnvio.Visible = true;


            pnlOrdenEnvio.Visible = true;

            
            pnlCampoIdPiloto.Visible = true;
            pnlIdTransporte.Visible = true;
            pnlEstatusEnvio.Visible = false;
            pnlRuta.Visible = true;
            pnlMoBodega.Visible = true;
            pnlFechaEnvio.Visible = true;
          
            txtBuscarEnvio.Visible = true;
            pnlBotonBuscarEnvio.Visible = true;
            dgvEnvio.Visible = true;
            pnlLLenarCamposEnvio.Visible = true;
            txtIdRuta.Visible = true;
            pnlIdRuta.Visible = true;
            dgvRuta.Visible = true;
           
            pnlBordeModificar.Visible = true;
            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            pnlCambiaEstado.Visible = false;
            /*Ocultando Panales*/
            pnlOrdenEnvio.Enabled = false;
            pnlEntregado.Visible = false;

            pnlLlenarCamposEDB.Visible = true;
            txtEstatusMoEnvio.Enabled = false;
            pnlLlenarCamposEDB.Visible = false;
           
        }

        private void btnCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverEnvio;
        }

        private void btnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalEnvio;
        }

        private void lblCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverEnvio;
        }

        private void lblCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalEnvio;
        }

        private void picIconoCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverEnvio;
        }

        private void picIconoCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalEnvio;
        }

        private void btnPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverEnvio;
        }

        private void btnPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalEnvio;
        }

        private void lblPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverEnvio;
        }

        private void lblPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalEnvio;
        }

        private void picPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverEnvio;
        }

        private void picPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalEnvio;
        }

        private void btnPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos obj = new frmPuestos();
            obj.Visible = true;

            Visible = false;
        }

        private void lblPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos obj = new frmPuestos();
            obj.Visible = true;

            Visible = false;
        }

        private void picPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos obj = new frmPuestos();
            obj.Visible = true;

            Visible = false;
        }

        private void btnDepartamento_MouseClick(object sender, MouseEventArgs e)
        {
            frmDepartamento obj = new frmDepartamento();
            obj.Visible = true;

            Visible = false;
        }

        private void lblDepartamento_MouseClick(object sender, MouseEventArgs e)
        {

            frmDepartamento obj = new frmDepartamento();
            obj.Visible = true;

            Visible = false;
        }

        private void picDepartamento_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void picDepartamento_MouseClick(object sender, MouseEventArgs e)
        {

            frmDepartamento obj = new frmDepartamento();
            obj.Visible = true;

            Visible = false;
        }

        private void btnDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverEnvio;
        }

        private void btnDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalEnvio;
        }

        private void lblDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverEnvio;
        }

        private void lblDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalEnvio;
        }

        private void picDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalEnvio;
        }

        private void picDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverEnvio;
        }

        private void btnUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion obj = new frmUbicacion();

            obj.Visible = true;

            Visible = false;

        }

        private void lblUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion obj = new frmUbicacion();

            obj.Visible = true;

            Visible = false;
        }

        private void lblUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverEnvio;
        }

        private void btnUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalEnvio;
        }

        private void btnUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverEnvio;
        }

        private void lblUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalEnvio;
        }

        private void picIconoUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion obj = new frmUbicacion();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverEnvio;
        }

        private void picIconoUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalEnvio;
        }

        private void btnTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmtipoEmpleado obj = new frmtipoEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void lblTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmtipoEmpleado obj = new frmtipoEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void picTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmtipoEmpleado obj = new frmtipoEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void btnTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorHoverEnvio;
        }

        private void btnTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorNormalEnvio;
        }

        private void lblTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorHoverEnvio;
        }

        private void lblTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorNormalEnvio;
        }

        private void picTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorHoverEnvio;
        }

        private void picTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
            btnTipoEmpleado.BackColor = colorNormalEnvio;
        }

        private void btnRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta obj = new frmRuta();

            obj.Visible = true;

            Visible = false;
        }

        private void lblRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta obj = new frmRuta();

            obj.Visible = true;

            Visible = false;
        }

        private void picRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta obj = new frmRuta();

            obj.Visible = true;

            Visible = false;
        }

        private void btnRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverEnvio;
        }

        private void btnRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalEnvio;
        }

        private void lblRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverEnvio;
        }

        private void lblRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalEnvio;
        }

        private void picRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverEnvio;
        }

        private void picRuta_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalEnvio;
        }

        private void pnlSubUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmSubUbicacion obj = new frmSubUbicacion();

            obj.Visible = true;

            Visible = false;
        }

        private void lblSubUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmSubUbicacion obj = new frmSubUbicacion();

            obj.Visible = true;

            Visible = false;
        }

        private void picSubUbicacion_DoubleClick(object sender, EventArgs e)
        {
            frmSubUbicacion obj = new frmSubUbicacion();

            obj.Visible = true;

            Visible = false;
        }

        private void pnlSubUbicacion_MouseHover(object sender, EventArgs e)
        {
           pnlSubUbicacion.BackColor = colorHoverEnvio;
        }

        private void pnlSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalEnvio;
        }

        private void lblSubUbicacion_MouseHover(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorHoverEnvio;
        }

        private void lblSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalEnvio;
        }

        private void picSubUbicacion_MouseHover(object sender, EventArgs e)
        {

            pnlSubUbicacion.BackColor = colorHoverEnvio;
        }

        private void picSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalEnvio;
        }

        private void btnTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento obj = new frmTipoMovimiento();

            obj.Visible = true;

            Visible = false;
        }

        private void lblTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento obj = new frmTipoMovimiento();

            obj.Visible = true;

            Visible = false;
        }

        private void picTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento obj = new frmTipoMovimiento();

            obj.Visible = true;

            Visible = false;
        }

        private void btnTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorHoverEnvio;
        }

        private void btnTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorNormalEnvio;
        }

        private void lblTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorHoverEnvio;
        }

        private void lblTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorNormalEnvio;
        }

        private void picTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorHoverEnvio;
        }

        private void picTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {
            btnTipoMovimiento.BackColor = colorNormalEnvio;
        }

        private void btnTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte obj = new frmTipoTransporte();

            obj.Visible = true;

            Visible = false;


        }

        private void lblTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte obj = new frmTipoTransporte();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte obj = new frmTipoTransporte();

            obj.Visible = true;

            Visible = false;
        }

        private void btnTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverEnvio;
        }

        private void btnTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalEnvio;
        }

        private void lblTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverEnvio;
        }

        private void lblTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalEnvio;
        }

        private void picIconoTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverEnvio;
        }

        private void picIconoTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalEnvio;
        }

        private void btnUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            frmUsuarios obj = new frmUsuarios();

            obj.Visible = true;

            Visible = false;
        }

        private void lblUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            frmUsuarios obj = new frmUsuarios();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            frmUsuarios obj = new frmUsuarios();

            obj.Visible = true;

            Visible = false;
        }

        private void btnUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverEnvio;
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalEnvio;
        }

        private void lblUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverEnvio;
        }

        private void lblUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalEnvio;
        }

        private void picIconoUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverEnvio;
        }

        private void picIconoUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalEnvio;
        }

        private void btnPaqueteEncabezado_MouseClick(object sender, MouseEventArgs e)
        {
            frmPaqueteEncabezado obj = new frmPaqueteEncabezado();

            obj.Visible = true;

            Visible = false;

        }

        private void lblPaqueteEncabezado_MouseClick(object sender, MouseEventArgs e)
        {
            frmPaqueteEncabezado obj = new frmPaqueteEncabezado();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoPaqueteE_MouseClick(object sender, MouseEventArgs e)
        {
            frmPaqueteEncabezado obj = new frmPaqueteEncabezado();

            obj.Visible = true;

            Visible = false;
        }

        private void btnPaqueteEncabezado_MouseHover(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorHoverEnvio;
        }

        private void btnPaqueteEncabezado_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalEnvio;
        }

        private void lblPaqueteEncabezado_MouseHover(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorHoverEnvio;
        }

        private void lblPaqueteEncabezado_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalEnvio;
        }

        private void picIconoPaqueteE_MouseHover(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorHoverEnvio;
        }

        private void picIconoPaqueteE_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalEnvio;
        }

        private void pnlEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;

        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void pnlEmpleado_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverEnvio;
        }

        private void pnlEmpleado_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalEnvio;
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverEnvio;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalEnvio;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverEnvio;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalEnvio;
        }

        private void frmEnvio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlBotonGuardarEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            /* Inicio de ejecucion de funcion insertar un cliente */

           /* if (txtEstatusMoEnvio.Text == "")
            {
                MessageBox.Show("No se pueden ingresar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {*/
           /*Estados del estatus :  E --  , R */
                
                String estatusE = "P";
                Envio envio = funObtenerTxt(estatusE);
                envio.funInsertar();
                /* Final de ejecucion de funcion insertar un cliente */

                funCargarTabla(null);
                funVaciarCampos();
           // }
        }



        public Envio funObtenerTxt(String estatus)
        {
            /*Inicio obteniedo variables a usar con mi ABC cliente */
            String idPiloto = cbxPiloto.SelectedValue.ToString();
            String idOrdenE = "0";
            String idTransporteE = cbxIdTransporte.SelectedValue.ToString();
            String idRutaE = cbxIdRuta.SelectedValue.ToString();
            String idMovBodegaE = cbxMoBodega.SelectedValue.ToString();
            String fechaE = txtFechaClienteEntPE.Value.ToString("yyyy-MM-dd");


            String estatusEnvio = estatus;

            /*Final obteniedo variables a usar con mi ABC */

            /* Inicio creamos un objeto de tipo paqueteEncabezado para poder utilizar el metodo de insertar */
            Envio envio = new Envio(idPiloto, idOrdenE, idTransporteE, idRutaE, idMovBodegaE, fechaE, estatusEnvio);
            /* Final creamos un objeto de tipo cliente para poder utilizar el metodo de insertar cliente */

            return envio;
        }

        public Envio funObtenerTxtModificar(String estatus)
        {
            /*Inicio obteniedo variables a usar con mi ABC cliente */
            String idPiloto = cbxPiloto.SelectedValue.ToString();
            String idOrdenE = txtOrdenEnvio.Text;
            String idTransporteE = cbxIdTransporte.SelectedValue.ToString();
            String idRutaE = cbxIdRuta.SelectedValue.ToString();
            String idMovBodegaE = cbxMoBodega.SelectedValue.ToString();
            String fechaE = txtFechaClienteEntPE.Value.ToString("yyyy-MM-dd");


            String estatusEnvio = estatus;

            /*Final obteniedo variables a usar con mi ABC */

            /* Inicio creamos un objeto de tipo paqueteEncabezado para poder utilizar el metodo de insertar */
            Envio envio = new Envio(idPiloto, idOrdenE, idTransporteE, idRutaE, idMovBodegaE, fechaE, estatus);
            /* Final creamos un objeto de tipo cliente para poder utilizar el metodo de insertar cliente */

            return envio;
        }


        private void funCargarTabla(string dato)
        {
            List<Envio> lista = new List<Envio>();
            Envio envio = new Envio();

            dgvEnvio.DataSource = envio.consulta(dato);
        }


        public void funVaciarCampos()
        {
            txtEstatusMoEnvio.Text = "";
            txtOrdenEnvio.Text = "";
           
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlBotonGuardarEnvio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlModificarEnvio_MouseClick(object sender, MouseEventArgs e)
        {

           String estatusE = "P";
            
            Envio envio = funObtenerTxtModificar(estatusE);
            String idOrdenE = txtOrdenEnvio.Text;

            envio.funModificar(idOrdenE);
            funCargarTabla(null);

            envio.funBuscarSetearTxt(cbxPiloto, txtOrdenEnvio, cbxIdTransporte, cbxIdRuta, cbxMoBodega, txtFechaClienteEntPE, txtEstatusMoEnvio);
            funVaciarCampos();
        }

        private void pnlLLenarCamposEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            txtOrdenEnvio.Text = dgvEnvio.CurrentRow.Cells[1].Value.ToString();

            String idPiloto = dgvEnvio.CurrentRow.Cells[0].Value.ToString();
            Envio envio = new Envio();
            envio.obtenerNombre(idPiloto);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxPiloto.SelectedValue = idPiloto;

            String idTransporteE = dgvEnvio.CurrentRow.Cells[2].Value.ToString();
            Envio Transporte = new Envio();
            Transporte.obtenerNombre(idTransporteE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idTransporteE;


            String idRutaE = dgvEnvio.CurrentRow.Cells[3].Value.ToString();
            Envio ruta = new Envio();
            ruta.obtenerNombre(idRutaE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idRutaE;

            String idMovBodegaE = dgvEnvio.CurrentRow.Cells[4].Value.ToString();
            Envio mBodega = new Envio();
            ruta.obtenerNombre(idMovBodegaE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idMovBodegaE;



            // De string a dateTime
            txtFechaClienteEntPE.Value = Convert.ToDateTime(dgvEnvio.CurrentRow.Cells[5].Value.ToString());
          
       

            txtEstatusMoEnvio.Text = dgvEnvio.CurrentRow.Cells[6].Value.ToString();

        }

        private void pnlEnviado_MouseClick(object sender, MouseEventArgs e)
        {
            String estatus = "E";
            String OrdenEnvio = txtOrdenEnvio.Text;
            Envio envio = funObtenerTxtModificar(estatus);

            envio.funCambiar_Enviado(OrdenEnvio);
            funCargarTabla(null);

            pnlEnviado.Visible = false;
            pnlRecibido.Visible = true;
            pnlEntregado.Visible = false;

            envio.funBuscarSetearTxt(cbxPiloto, txtOrdenEnvio, cbxIdTransporte, cbxIdRuta, cbxMoBodega, txtFechaClienteEntPE, txtEstatusMoEnvio);
            txtEstatusMoEnvio.Text = "E";
            // pnlEnviado.Visible = false;
        }

        private void pnlRecibido_MouseClick(object sender, MouseEventArgs e)
        {
            String estatus = "R";
            String OrdenEnvio = txtOrdenEnvio.Text;
            Envio envio = funObtenerTxtModificar(estatus);

            envio.funEnvio_Entregado(OrdenEnvio);
            funCargarTabla(null);

            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            pnlEntregado.Visible = true;

            envio.funBuscarSetearTxt(cbxPiloto, txtOrdenEnvio, cbxIdTransporte, cbxIdRuta, cbxMoBodega, txtFechaClienteEntPE, txtEstatusMoEnvio);
            txtEstatusMoEnvio.Text = "R";
            // pnlRecibido.Visible = false; 
        }

        private void pnlLlenarCamposEDB_MouseClick(object sender, MouseEventArgs e)
        {
            txtOrdenEnvio.Text = dgvEnvio.CurrentRow.Cells[1].Value.ToString();

            String idPiloto = dgvEnvio.CurrentRow.Cells[0].Value.ToString();
            Envio envio = new Envio();
            envio.obtenerNombre(idPiloto);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxPiloto.SelectedValue = idPiloto;

            String idTransporteE = dgvEnvio.CurrentRow.Cells[2].Value.ToString();
            Envio Transporte = new Envio();
            Transporte.obtenerNombre(idTransporteE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idTransporteE;


            String idRutaE = dgvEnvio.CurrentRow.Cells[3].Value.ToString();
            Envio ruta = new Envio();
            ruta.obtenerNombre(idRutaE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idRutaE;

            String idMovBodegaE = dgvEnvio.CurrentRow.Cells[4].Value.ToString();
            Envio mBodega = new Envio();
            ruta.obtenerNombre(idMovBodegaE);
            //en la funcion idPiloto se le asigna el nombre que existe en la BD y se le coloca al combobox
            cbxIdTransporte.SelectedValue = idMovBodegaE;



            // De string a dateTime
            txtFechaClienteEntPE.Value = Convert.ToDateTime(dgvEnvio.CurrentRow.Cells[5].Value.ToString());

            txtEstatusMoEnvio.Text = dgvEnvio.CurrentRow.Cells[6].Value.ToString();

            Envio envioB = new Envio();
            String idOE = txtOrdenEnvio.Text;

            String pEstatusEn = envioB.funBuscarEstatus(idOE);

            if (pEstatusEn == "P")
            {
                pnlEnviado.Visible = true;
                pnlRecibido.Visible = false;
                pnlEntregado.Visible = false;

            }
            else if(pEstatusEn == "E")
            {
                pnlEnviado.Visible = false;
                pnlRecibido.Visible = true;
                pnlEntregado.Visible = false;
            }
            else if (pEstatusEn == "R")
            {
                pnlEnviado.Visible = false;
                pnlRecibido.Visible = false;
                pnlEntregado.Visible = true;

            }


        }

        private void lblCambiaEstado_MouseClick(object sender, MouseEventArgs e)
        {
           // String buscarE = txtBuscarEnvio.Text;
            funCargarTabla(null);
            funCargarTablaRuta(null);
            mapa();
            funVaciarCampos();

            pnlEstatusEnvio.Visible = true;
            pnlBordeRegistrar.Visible = false;
            pnlCambiaEstado.Visible = true; ;
            pnlBordeModificar.Visible = false;
            pnlModificarEnvio.Visible = false;
            pnlModificarEnvio.Visible = false;
            pnlLLenarCamposEnvio.Visible = false;
            pnlLlenarCamposEDB.Visible = true;
            dgvRuta.Visible = true;
            pnlCampoIdPiloto.Visible = true;
            pnlIdTransporte.Visible = true;
            pnlRuta.Visible = true;
            pnlMoBodega.Visible = true;
            pnlOrdenEnvio.Visible = true;
            pnlFechaEnvio.Visible = true;
            dgvEnvio.Visible = true;
            txtBuscarEnvio.Visible = true;
            pnlBotonBuscarEnvio.Visible = true;
            txtIdRuta.Visible = true;
            pnlIdRuta.Visible = true;
            txtEstatusMoEnvio.Enabled = false;
        }

        private void lblModificarEnvio_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void pnlBotonBuscarEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            String buscarE = txtBuscarEnvio.Text;
            funCargarTabla(buscarE);
            /* Final buscando el dato ingresado por el usuario y llenando mi tabla */

            /* Inicio Vaciando los campos */
            funVaciarCampos();
            pnlEnviado.Visible = false;
            pnlRecibido.Visible = false;
            pnlEntregado.Visible = false;
            /* Final Vaciando los campos */
        }


        /* Inicio funcion para cargar mi tabla de ruta */
        private void funCargarTablaRuta(string dato)
        {
            List<Ruta> lista = new List<Ruta>();
            Ruta ruta = new Ruta();

            dgvRuta.DataSource = ruta.consulta(dato);
        }

        private void pnlIdRuta_MouseClick(object sender, MouseEventArgs e)
        {
            string buscarRuta= txtIdRuta.Text;

            funCargarTablaRuta(buscarRuta);


        }

        private void btnBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmBodega OBJ = new frmBodega();
            OBJ.Visible = true;

            Visible = false;

        }

        private void lblBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmBodega OBJ = new frmBodega();
            OBJ.Visible = true;

            Visible = false;
        }

        private void picBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmBodega OBJ = new frmBodega();
            OBJ.Visible = true;

            Visible = false;
        }

        private void btnBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverEnvio;
        }

        private void btnBodega_MouseLeave(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorNormalEnvio;
        }

        private void lblBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverEnvio;
        }

        private void lblBodega_MouseLeave(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorNormalEnvio;
        }

        private void picBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverEnvio;
        }

        private void picBodega_MouseLeave(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorNormalEnvio;
        }

        private void pnlEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverEnvio;
        }

        private void pnlEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalEnvio;
        }

        private void lblEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverEnvio;
        }

        private void lblEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalEnvio;
        }

        private void picEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverEnvio;
        }

        private void picEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalEnvio;
        }

        private void pnlTrans_MouseClick(object sender, MouseEventArgs e)
        {
            frmTransporte obj = new frmTransporte();
            obj.Visible = true;
            Visible = false;
        }
        /* Final funcion para cargar mi tabla de Ruta */
    }
}
