using MySql.Data.MySqlClient;
using sistema_reparto.Clases;
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
    public partial class frmtipoEmpleado : Form
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

        /* Varibles para cambiar color de mi Boton */
        Color colorHoverTE = Color.FromArgb(80, 115, 119);
        Color colorNormalTE = Color.FromArgb(59, 102, 107);

        public frmtipoEmpleado()
        {
            InitializeComponent();

            /* Codigo para redondear mi panel */
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            /*Inicio Encabezados*/
            pnlBordeTE.Visible = false;
            lblTituloTipoEmpleado.Visible = true;
            lblMantenimientosTipoEmpleado.Visible = true;
            lblRegistrarTipoEmpleado.Visible = false;
            pnlBordeRegistrar.Visible = false;
            lblModificarTipoEmpleado.Visible = false;
            pnlBordeModificar.Visible = false;
            lblDarBaja.Visible = false;
            pnlBordeDarBaja.Visible = false;
            /*Fin Encabezados*/

            /*Inicio Esconder contenidos de mi form tipoEmpleado */
            pnlIDTipoEmpleado.Visible = false;
            pnlNombreTipoEmpleado.Visible = false;
            pnlEstatusTipoEmpleado.Visible = false;
            pnlBotonGuardarTE.Visible = false;
            pnlModificarTE.Visible = false;

            pnlDarBajaTE.Visible = false;
            pnlActivarTE.Visible = false;
            pnlLlenarCamposTEDB.Visible = false;
            pnlLLenarCamposTE.Visible = false;
            txtBuscarTipoEmpleado.Visible = false;
            pnlBotonBuscarTE.Visible = false;
            dgvTipoEmpleado.Visible = false;
            /*Inicio Esconder contenidos de mi form tipoEmpleado */
        }

        private void frmtipoEmpleado_Load(object sender, EventArgs e)
        {

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

        private void picDepartamento_MouseClick(object sender, MouseEventArgs e)
        {
            frmDepartamento obj = new frmDepartamento();
            obj.Visible = true;
            Visible = false;
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

        private void picIconoUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion obj = new frmUbicacion();
            obj.Visible = true;
            Visible = false;
        }

        private void btnCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverTE;
        }

        private void lblCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverTE;
        }

        private void picIconoCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverTE;
        }

        private void btnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalTE;
        }

        private void lblCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalTE;
        }

        private void picIconoCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalTE;
        }

        private void btnPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverTE;
        }

        private void lblPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverTE;
        }

        private void picPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverTE;
        }

        private void btnPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalTE;
        }

        private void lblPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalTE;
        }

        private void picPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalTE;
        }

        private void btnDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverTE;
        }

        private void lblDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverTE;
        }

        private void picDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverTE;
        }

        private void btnDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalTE;
        }

        private void lblDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalTE;
        }

        private void picDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalTE;
        }

        private void btnUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverTE;
        }

        private void lblUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverTE;
        }

        private void picIconoUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverTE;
        }

        private void btnUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalTE;
        }

        private void lblUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalTE;
        }

        private void picIconoUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalTE;
        }

        private void lblTituloTipoEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void lblMantenimientosTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeTE.Visible = true;
            lblRegistrarTipoEmpleado.Visible = true;
            lblModificarTipoEmpleado.Visible = true;
            lblDarBaja.Visible = true;


        }

        private void btnTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lblRegistrarTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {


            pnlBordeRegistrar.Visible = true;
            pnlBordeModificar.Visible = false;
            pnlBordeDarBaja.Visible = false;

            pnlIDTipoEmpleado.Visible = true;
            pnlNombreTipoEmpleado.Visible = true;
            pnlBotonGuardarTE.Visible = true;
            pnlModificarTE.Visible = false;
            pnlLLenarCamposTE.Visible = true;
            pnlDarBajaTE.Visible = false;
            pnlActivarTE.Visible = false;
            pnlLlenarCamposTEDB.Visible = false;
            txtBuscarTipoEmpleado.Visible = true;
            pnlBotonBuscarTE.Visible = true;
            dgvTipoEmpleado.Visible = true;


            /*Inicio Esconder contenidos de mi form tipoEmpleado */
            pnlIDTipoEmpleado.Enabled = true;
            pnlNombreTipoEmpleado.Enabled = true;
            pnlEstatusTipoEmpleado.Enabled = true;
            pnlModificarTE.Enabled = true;
            pnlLLenarCamposTE.Enabled = true;
            txtBuscarTipoEmpleado.Enabled = true;
            pnlBotonBuscarTE.Enabled = true;
            dgvTipoEmpleado.Enabled = true;
            /*Fin Esconder contenidos de mi form tipoEmpleado */
        }

        private void lblModificarTipoEmpleado_MouseClick(object sender, MouseEventArgs e)
        {

            //pnlLlenarCamposTEDB.Visible = false;
            //pnlLLenarCamposTE.Visible = false;

            pnlBordeModificar.Visible = true;
            pnlBordeRegistrar.Visible = false;
            pnlBordeDarBaja.Visible = false;


            //pnlLlenarCamposTEDB.Visible = true;

            /*Inicio elementos permitidos*/
            pnlIDTipoEmpleado.Visible = true;
            pnlNombreTipoEmpleado.Visible = true;
            pnlBotonGuardarTE.Visible = true;
            pnlModificarTE.Visible = false;
            pnlEstatusTipoEmpleado.Visible = false;
            pnlDarBajaTE.Visible = false;
            pnlActivarTE.Visible = false;
            pnlLlenarCamposTEDB.Visible = false;
            pnlLLenarCamposTE.Visible = true;
            txtBuscarTipoEmpleado.Visible = true;
            pnlBotonBuscarTE.Visible = true;
            dgvTipoEmpleado.Visible = true;

            pnlModificarTE.Visible = true;
            pnlBotonGuardarTE.Visible = false;
            /*fin elementos permitidos*/

            /*Inicio Esconder contenidos de mi form tipoEmpleado */
            pnlIDTipoEmpleado.Enabled = false;
            pnlNombreTipoEmpleado.Enabled = true;
            pnlEstatusTipoEmpleado.Enabled = false;
            pnlModificarTE.Enabled = true;
            pnlLLenarCamposTE.Enabled = true;
            txtBuscarTipoEmpleado.Enabled = true;
            pnlBotonBuscarTE.Enabled = true;
            dgvTipoEmpleado.Enabled = true;
            /*fin Esconder contenidos de mi form tipoEmpleado */
        }

        private void lblDarBaja_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeDarBaja.Visible = true;
            pnlBordeRegistrar.Visible = false;
            pnlBordeModificar.Visible = false;



            /*Inicio elementos permitidos*/
            pnlIDTipoEmpleado.Visible = true;
            pnlNombreTipoEmpleado.Visible = true;
            pnlBotonGuardarTE.Visible = true;
            pnlModificarTE.Visible = true;
            pnlEstatusTipoEmpleado.Visible = true;
            pnlDarBajaTE.Visible = false;
            pnlActivarTE.Visible = false;
            pnlLLenarCamposTE.Visible = false;
            pnlLlenarCamposTEDB.Visible = true;
            txtBuscarTipoEmpleado.Visible = true;
            pnlBotonBuscarTE.Visible = false;

            dgvTipoEmpleado.Visible = true;

            pnlModificarTE.Visible = false;
            pnlBotonGuardarTE.Visible = false;
            /*fin elementos permitidos*/

            /*Inicio Esconder contenidos de mi form tipoEmpleado */
            pnlIDTipoEmpleado.Enabled = false;
            pnlNombreTipoEmpleado.Enabled = false;
            pnlEstatusTipoEmpleado.Enabled = false;
            pnlModificarTE.Enabled = true;
            pnlLLenarCamposTE.Enabled = true;
            txtBuscarTipoEmpleado.Enabled = true;
            pnlBotonBuscarTE.Enabled = true;
            dgvTipoEmpleado.Enabled = true;
            /*fin Esconder contenidos de mi form tipoEmpleado */

        }

        private void pnlEstatusTipoEmpleado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDarBaja_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void frmtipoEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlBotonGuardarTE_MouseClick(object sender, MouseEventArgs e)
        {
            /* Funcion insertar una Ubicacion */
            String estatusTipoEmpleado = "A";
            TipoEmpleado tipoEmpleado = funObtenerTxt(estatusTipoEmpleado);
            tipoEmpleado.funInsertar();
            /* Final de ejecucion de funcion insertar un cliente */

            funCargarTabla(null);
            funVaciarCampos();
        }


        /* Inicio de funcion para evitar el uso de recursivo de tantas variables */
        public TipoEmpleado funObtenerTxt(String estatus)
        {
            /*Inicio obteniedo variables a usar con mi ABC Ubicacion */
            String pCodigoTE = txtIdTipoEmpleado.Text;
            String pNombreTE = txtNombreTipoEmpleado.Text;
            /*Final obteniedo variables a usar con mi ABC Ubicacion */

            /* Inicio creamos un objeto de tipo Ubicacion para poder utilizar el metodo de insertar ubicacion */
            TipoEmpleado tipoEmpleado = new TipoEmpleado(pCodigoTE, pNombreTE, estatus);
            /* Final creamos un objeto de tipo cliente para poder utilizar el metodo de insertar ubicacion */

            return tipoEmpleado; 
        }
        /* Final de funcion para evitar el uso recursivo de tantas variables */


        public void funVaciarCampos()
        {
            txtIdTipoEmpleado.Text = "";
            txtNombreTipoEmpleado.Text = "";
            txtEstatusTipoEmpleado.Text = "";
            txtBuscarTipoEmpleado.Text = "";

        }

        /* Inicio funcion para cargar mi tabla de clientes */
        private void funCargarTabla(string dato)
        {
            List<TipoEmpleado> lista = new List<TipoEmpleado>();
            TipoEmpleado TipoEmpleado = new TipoEmpleado();
            dgvTipoEmpleado.DataSource = TipoEmpleado.consulta(dato);

        }
    }
}
