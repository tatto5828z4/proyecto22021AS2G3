using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmUsuarios : Form
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

        Color colorHoverUsuarios = Color.FromArgb(80, 115, 119);
        Color colorNormalUsuarios = Color.FromArgb(59, 102, 107);

        public frmUsuarios()
        {
            InitializeComponent();

            /* Inicio Creando objeto usuario para poder llenar el combobox tipo de permiso*/
            Usuarios usuario = new Usuarios();
            usuario.funLlenarCombo(CboTipoUsuario);
            /* Inicio Creando objeto usuario para poder llenar el combobox tipo de permiso*/

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pnlBordeUsuarios.Visible = false;
            lblRegistrarUsuario.Visible = false;
            pnlBordeRegistrarUsu.Visible = false;
            lblModificarUsuario.Visible = false;
            pnlBordeModificarUsu.Visible = false;
            lblDarBajaUsu.Visible = false;
            pnlBordeDarBajaU.Visible = false;
            pnlContenidoTP.Visible = false;
            pnlCodigoP.Visible = false;
            pnlCodigoU.Visible = false;
            pnlPass.Visible = false;
            pnlNombreU.Visible = false;
            pnlVeriPass.Visible = false;
            pnlEstatusU.Visible = false;
            pnlModificarUS.Visible = false;
            pnlBotonGuardarUS.Visible = false;
            pnlDarBajaUS.Visible = false;
            pnlActivarUS.Visible = false;
            txtBuscarUsuario.Visible = false;
            pnlBotonBuscarUsuario.Visible = false;
            dgvUsuario.Visible = false;
            pnlLlenarCamposUSDB.Visible = false;
            pnlLLenarCamposUS.Visible = false;
            pnlChecks.Visible = false;

            String idUsuario = Login.idUsuario;

            LoginC loginC = new LoginC();

            txtNombreUsu.Text = loginC.funBuscarNormbre(idUsuario);
            txtIdUsu.Text = idUsuario;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal cliente = new frmPrincipal();
            cliente.Visible = true;

            Visible = false;
        }

        private void lblCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal cliente = new frmPrincipal();
            cliente.Visible = true;

            Visible = false;
        }

        private void picIconoCliente_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal cliente = new frmPrincipal();
            cliente.Visible = true;

            Visible = false;
        }

        private void picIconoUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            frmPrincipal cliente = new frmPrincipal();
            cliente.Visible = true;

            Visible = false;
        }

        private void btnUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            frmUsuarios usuario = new frmUsuarios();
            usuario.Visible = true;

            Visible = false;
        }

        private void btnPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos puesto = new frmPuestos();
            puesto.Visible = true;

            Visible = false;
        }

        private void lblPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos puesto = new frmPuestos();
            puesto.Visible = true;

            Visible = false;
        }

        private void picPuesto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPuestos puesto = new frmPuestos();
            puesto.Visible = true;

            Visible = false;
        }

        private void CboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valorCombo = CboTipoUsuario.SelectedValue.ToString();


            if (valorCombo == "1")
            {
                /* Inicio Activando Cheques para mi Administrador */
                chkIngresarU.Checked = true;
                chkModificarU.Checked = true;
                chkDarBajaU.Checked = true;
                chkConsultaU.Checked = true;
                chkIngresarC.Checked = true;
                chkModificarC.Checked = true;
                chkDarBajaC.Checked = true;
                chkConsultarC.Checked = true;
                chkIngresarD.Checked = true;
                chkModificarD.Checked = true;
                chkDarBajaD.Checked = true;
                chkConsultarD.Checked = true;
                chkIngresarPu.Checked = true;
                chkModificarPu.Checked = true;
                chkDarBajaPu.Checked = true;
                chkConsultaPu.Checked = true;
                chkIngresarPi.Checked = true;
                chkModificarPi.Checked = true;
                chkDarBajaPi.Checked = true;
                chkConsultaPi.Checked = true;
                chkIngresarEm.Checked = true;
                chkModificarE.Checked = true;
                chkDarBajaE.Checked = true;
                chkConsultaE.Checked = true;
                chkPaqueteEnc.Checked = true;
                chkModificarEnc.Checked = true;
                chkDarBajaPaEnc.Checked = true;
                chkConsultaPaEc.Checked = true;
                chkIngresarPaDe.Checked = true;
                chkModificarPaDet.Checked = true;
                chkDarBajaPaDet.Checked = true;
                chkConsultaDet.Checked = true;
                chkIngresarUb.Checked = true;
                chkModificarUb.Checked = true;
                chkDarBajaUb.Checked = true;
                chkConsultaUb.Checked = true;
                chkIngresarSub.Checked = true;
                chkModificarSub.Checked = true;
                chkDarBajaSub.Checked = true;
                chkConsultaSub.Checked = true;
                chkIngresarBo.Checked = true;
                chkModificarBo.Checked = true;
                chkDarBajaBo.Checked = true;
                chkConsultarBo.Checked = true;
                chkInventario.Checked = true;
                chkModificarIn.Checked = true;
                chkConsultaIn.Checked = true;
                chkConsultarMovBo.Checked = true;
                chkIngresarTipoT.Checked = true;
                chkModificarTiT.Checked = true;
                chkDarBajaTip.Checked = true;
                chkConsultarTip.Checked = true;
                chkIngresarTra.Checked = true;
                chkModificarTra.Checked = true;
                chkDarBajaTra.Checked = true;
                chkConsultarTra.Checked = true;
                chkIngresarRuta.Checked = true;
                chkModificarRu.Checked = true;
                chkDarBajaRu.Checked = true;
                chkConsultarRu.Checked = true;
                chkIngresarEnvio.Checked = true;
                chkModificarEn.Checked = true;
                chkDarBajaEn.Checked = true;
                chkConsultaEn.Checked = true;
                chkInsertarBitaTrans.Checked = true;
                chkModificarBi.Checked = true;
                chkConsultarBTTras.Checked = true;
                chkBitacoraUsuario.Checked = true;
                chkIngresarCalificacion.Checked = true;
                chkModificarCa.Checked = true;
                chkConsultarCa.Checked = true;
                chkReportes.Checked = true;
                /* Final Activando Cheques para mi Administrador */

                /* Inicio deshabilitando checkbox*/
                chkIngresarU.Enabled = false;
                chkModificarU.Enabled = false;
                chkDarBajaU.Enabled = false;
                chkConsultaU.Enabled = false;
                chkIngresarC.Enabled = false;
                chkModificarC.Enabled = false;
                chkDarBajaC.Enabled = false;
                chkConsultarC.Enabled = false;
                chkIngresarD.Enabled = false;
                chkModificarD.Enabled = false;
                chkDarBajaD.Enabled = false;
                chkConsultarD.Enabled = false;
                chkIngresarPu.Enabled = false;
                chkModificarPu.Enabled = false;
                chkDarBajaPu.Enabled = false;
                chkConsultaPu.Enabled = false;
                chkIngresarPi.Enabled = false;
                chkModificarPi.Enabled = false;
                chkDarBajaPi.Enabled = false;
                chkConsultaPi.Enabled = false;
                chkIngresarEm.Enabled = false;
                chkModificarE.Enabled = false;
                chkDarBajaE.Enabled = false;
                chkConsultaE.Enabled = false;
                chkPaqueteEnc.Enabled = false;
                chkModificarEnc.Enabled = false;
                chkDarBajaPaEnc.Enabled = false;
                chkConsultaPaEc.Enabled = false;
                chkIngresarPaDe.Enabled = false;
                chkModificarPaDet.Enabled = false;
                chkDarBajaPaDet.Enabled = false;
                chkConsultaDet.Enabled = false;
                chkIngresarUb.Enabled = false;
                chkModificarUb.Enabled = false;
                chkDarBajaUb.Enabled = false;
                chkConsultaUb.Enabled = false;
                chkIngresarSub.Enabled = false;
                chkModificarSub.Enabled = false;
                chkDarBajaSub.Enabled = false;
                chkConsultaSub.Enabled = false;
                chkIngresarBo.Enabled = false;
                chkModificarBo.Enabled = false;
                chkDarBajaBo.Enabled = false;
                chkConsultarBo.Enabled = false;
                chkInventario.Enabled = false;
                chkModificarIn.Enabled = false;
                chkConsultaIn.Enabled = false;
                chkConsultarMovBo.Enabled = false;
                chkIngresarTipoT.Enabled = false;
                chkModificarTiT.Enabled = false;
                chkDarBajaTip.Enabled = false;
                chkConsultarTip.Enabled = false;
                chkIngresarTra.Enabled = false;
                chkModificarTra.Enabled = false;
                chkDarBajaTra.Enabled = false;
                chkConsultarTra.Enabled = false;
                chkIngresarRuta.Enabled = false;
                chkModificarRu.Enabled = false;
                chkDarBajaRu.Enabled = false;
                chkConsultarRu.Enabled = false;
                chkIngresarEnvio.Enabled = false;
                chkModificarEn.Enabled = false;
                chkDarBajaEn.Enabled = false;
                chkConsultaEn.Enabled = false;
                chkInsertarBitaTrans.Enabled = false;
                chkModificarBi.Enabled = false;
                chkConsultarBTTras.Enabled = false;
                chkBitacoraUsuario.Enabled = false;
                chkIngresarCalificacion.Enabled = false;
                chkModificarCa.Enabled = false;
                chkConsultarCa.Enabled = false;
                chkReportes.Enabled = false;
                /* Final deshabilitando checkbox*/
            }
            else if (valorCombo == "2")
            {
                /* Inicio Activando Cheques para mi Invitado */
                chkIngresarU.Checked = false;
                chkModificarU.Checked = false;
                chkDarBajaU.Checked = false;
                chkConsultaU.Checked = false;
                chkIngresarC.Checked = false;
                chkModificarC.Checked = false;
                chkDarBajaC.Checked = false;
                chkConsultarC.Checked = false;
                chkIngresarD.Checked = false;
                chkModificarD.Checked = false;
                chkDarBajaD.Checked = false;
                chkConsultarD.Checked = false;
                chkIngresarPu.Checked = false;
                chkModificarPu.Checked = false;
                chkDarBajaPu.Checked = false;
                chkConsultaPu.Checked = false;
                chkIngresarPi.Checked = false;
                chkModificarPi.Checked = false;
                chkDarBajaPi.Checked = false;
                chkConsultaPi.Checked = false;
                chkIngresarEm.Checked = false;
                chkModificarE.Checked = false;
                chkDarBajaE.Checked = false;
                chkConsultaE.Checked = false;
                chkPaqueteEnc.Checked = false;
                chkModificarEnc.Checked = false;
                chkDarBajaPaEnc.Checked = false;
                chkConsultaPaEc.Checked = false;
                chkIngresarPaDe.Checked = false;
                chkModificarPaDet.Checked = false;
                chkDarBajaPaDet.Checked = false;
                chkConsultaDet.Checked = false;
                chkIngresarUb.Checked = false;
                chkModificarUb.Checked = false;
                chkDarBajaUb.Checked = false;
                chkConsultaUb.Checked = false;
                chkIngresarSub.Checked = false;
                chkModificarSub.Checked = false;
                chkDarBajaSub.Checked = false;
                chkConsultaSub.Checked = false;
                chkIngresarBo.Checked = false;
                chkModificarBo.Checked = false;
                chkDarBajaBo.Checked = false;
                chkConsultarBo.Checked = false;
                chkInventario.Checked = false;
                chkModificarIn.Checked = false;
                chkConsultaIn.Checked = false;
                chkConsultarMovBo.Checked = false;
                chkIngresarTipoT.Checked = false;
                chkModificarTiT.Checked = false;
                chkDarBajaTip.Checked = false;
                chkConsultarTip.Checked = false;
                chkIngresarTra.Checked = false;
                chkModificarTra.Checked = false;
                chkDarBajaTra.Checked = false;
                chkConsultarTra.Checked = false;
                chkIngresarRuta.Checked = false;
                chkModificarRu.Checked = false;
                chkDarBajaRu.Checked = false;
                chkConsultarRu.Checked = false;
                chkIngresarEnvio.Checked = false;
                chkModificarEn.Checked = false;
                chkDarBajaEn.Checked = false;
                chkConsultaEn.Checked = true;
                chkInsertarBitaTrans.Checked = false;
                chkModificarBi.Checked = false;
                chkConsultarBTTras.Checked = false;
                chkBitacoraUsuario.Checked = false;
                chkIngresarCalificacion.Checked = true;
                chkModificarCa.Checked = true;
                chkConsultarCa.Checked = true;
                chkReportes.Checked = false;
                /* Final Activando Cheques para mi Invitado */

                /* Inicio deshabilitando checkbox*/
                chkIngresarU.Enabled = false;
                chkModificarU.Enabled = false;
                chkDarBajaU.Enabled = false;
                chkConsultaU.Enabled = false;
                chkIngresarC.Enabled = false;
                chkModificarC.Enabled = false;
                chkDarBajaC.Enabled = false;
                chkConsultarC.Enabled = false;
                chkIngresarD.Enabled = false;
                chkModificarD.Enabled = false;
                chkDarBajaD.Enabled = false;
                chkConsultarD.Enabled = false;
                chkIngresarPu.Enabled = false;
                chkModificarPu.Enabled = false;
                chkDarBajaPu.Enabled = false;
                chkConsultaPu.Enabled = false;
                chkIngresarPi.Enabled = false;
                chkModificarPi.Enabled = false;
                chkDarBajaPi.Enabled = false;
                chkConsultaPi.Enabled = false;
                chkIngresarEm.Enabled = false;
                chkModificarE.Enabled = false;
                chkDarBajaE.Enabled = false;
                chkConsultaE.Enabled = false;
                chkPaqueteEnc.Enabled = false;
                chkModificarEnc.Enabled = false;
                chkDarBajaPaEnc.Enabled = false;
                chkConsultaPaEc.Enabled = false;
                chkIngresarPaDe.Enabled = false;
                chkModificarPaDet.Enabled = false;
                chkDarBajaPaDet.Enabled = false;
                chkConsultaDet.Enabled = false;
                chkIngresarUb.Enabled = false;
                chkModificarUb.Enabled = false;
                chkDarBajaUb.Enabled = false;
                chkConsultaUb.Enabled = false;
                chkIngresarSub.Enabled = false;
                chkModificarSub.Enabled = false;
                chkDarBajaSub.Enabled = false;
                chkConsultaSub.Enabled = false;
                chkIngresarBo.Enabled = false;
                chkModificarBo.Enabled = false;
                chkDarBajaBo.Enabled = false;
                chkConsultarBo.Enabled = false;
                chkInventario.Enabled = false;
                chkModificarIn.Enabled = false;
                chkConsultaIn.Enabled = false;
                chkConsultarMovBo.Enabled = false;
                chkIngresarTipoT.Enabled = false;
                chkModificarTiT.Enabled = false;
                chkDarBajaTip.Enabled = false;
                chkConsultarTip.Enabled = false;
                chkIngresarTra.Enabled = false;
                chkModificarTra.Enabled = false;
                chkDarBajaTra.Enabled = false;
                chkConsultarTra.Enabled = false;
                chkIngresarRuta.Enabled = false;
                chkModificarRu.Enabled = false;
                chkDarBajaRu.Enabled = false;
                chkConsultarRu.Enabled = false;
                chkIngresarEnvio.Enabled = false;
                chkModificarEn.Enabled = false;
                chkDarBajaEn.Enabled = false;
                chkConsultaEn.Enabled = false;
                chkInsertarBitaTrans.Enabled = false;
                chkModificarBi.Enabled = false;
                chkConsultarBTTras.Enabled = false;
                chkBitacoraUsuario.Enabled = false;
                chkIngresarCalificacion.Enabled = false;
                chkModificarCa.Enabled = false;
                chkConsultarCa.Enabled = false;
                chkReportes.Enabled = false;
                /* Final deshabilitando checkbox*/
            }
            else if (valorCombo == "3")
            {
                /* Inicio Activando Cheques para mi Piloto */
                chkIngresarU.Checked = false;
                chkModificarU.Checked = false;
                chkDarBajaU.Checked = false;
                chkConsultaU.Checked = false;
                chkIngresarC.Checked = false;
                chkModificarC.Checked = false;
                chkDarBajaC.Checked = false;
                chkConsultarC.Checked = false;
                chkIngresarD.Checked = false;
                chkModificarD.Checked = false;
                chkDarBajaD.Checked = false;
                chkConsultarD.Checked = false;
                chkIngresarPu.Checked = false;
                chkModificarPu.Checked = false;
                chkDarBajaPu.Checked = false;
                chkConsultaPu.Checked = false;
                chkIngresarPi.Checked = false;
                chkModificarPi.Checked = false;
                chkDarBajaPi.Checked = false;
                chkConsultaPi.Checked = false;
                chkIngresarEm.Checked = false;
                chkModificarE.Checked = false;
                chkDarBajaE.Checked = false;
                chkConsultaE.Checked = false;
                chkPaqueteEnc.Checked = false;
                chkModificarEnc.Checked = false;
                chkDarBajaPaEnc.Checked = false;
                chkConsultaPaEc.Checked = false;
                chkIngresarPaDe.Checked = false;
                chkModificarPaDet.Checked = false;
                chkDarBajaPaDet.Checked = false;
                chkConsultaDet.Checked = false;
                chkIngresarUb.Checked = false;
                chkModificarUb.Checked = false;
                chkDarBajaUb.Checked = false;
                chkConsultaUb.Checked = false;
                chkIngresarSub.Checked = false;
                chkModificarSub.Checked = false;
                chkDarBajaSub.Checked = false;
                chkConsultaSub.Checked = false;
                chkIngresarBo.Checked = false;
                chkModificarBo.Checked = false;
                chkDarBajaBo.Checked = false;
                chkConsultarBo.Checked = false;
                chkInventario.Checked = false;
                chkModificarIn.Checked = false;
                chkConsultaIn.Checked = false;
                chkConsultarMovBo.Checked = false;
                chkIngresarTipoT.Checked = false;
                chkModificarTiT.Checked = false;
                chkDarBajaTip.Checked = false;
                chkConsultarTip.Checked = false;
                chkIngresarTra.Checked = false;
                chkModificarTra.Checked = false;
                chkDarBajaTra.Checked = false;
                chkConsultarTra.Checked = true;
                chkIngresarRuta.Checked = false;
                chkModificarRu.Checked = false;
                chkDarBajaRu.Checked = false;
                chkConsultarRu.Checked = true;
                chkIngresarEnvio.Checked = false;
                chkModificarEn.Checked = true;
                chkDarBajaEn.Checked = false;
                chkConsultaEn.Checked = true;
                chkInsertarBitaTrans.Checked = true;
                chkModificarBi.Checked = true;
                chkConsultarBTTras.Checked = true;
                chkBitacoraUsuario.Checked = false;
                chkIngresarCalificacion.Checked = false;
                chkModificarCa.Checked = false;
                chkConsultarCa.Checked = false;
                chkReportes.Checked = false;
                /* Final Activando Cheques para mi Piloto */

                /* Inicio deshabilitando checkbox*/
                chkIngresarU.Enabled = false;
                chkModificarU.Enabled = false;
                chkDarBajaU.Enabled = false;
                chkConsultaU.Enabled = false;
                chkIngresarC.Enabled = false;
                chkModificarC.Enabled = false;
                chkDarBajaC.Enabled = false;
                chkConsultarC.Enabled = false;
                chkIngresarD.Enabled = false;
                chkModificarD.Enabled = false;
                chkDarBajaD.Enabled = false;
                chkConsultarD.Enabled = false;
                chkIngresarPu.Enabled = false;
                chkModificarPu.Enabled = false;
                chkDarBajaPu.Enabled = false;
                chkConsultaPu.Enabled = false;
                chkIngresarPi.Enabled = false;
                chkModificarPi.Enabled = false;
                chkDarBajaPi.Enabled = false;
                chkConsultaPi.Enabled = false;
                chkIngresarEm.Enabled = false;
                chkModificarE.Enabled = false;
                chkDarBajaE.Enabled = false;
                chkConsultaE.Enabled = false;
                chkPaqueteEnc.Enabled = false;
                chkModificarEnc.Enabled = false;
                chkDarBajaPaEnc.Enabled = false;
                chkConsultaPaEc.Enabled = false;
                chkIngresarPaDe.Enabled = false;
                chkModificarPaDet.Enabled = false;
                chkDarBajaPaDet.Enabled = false;
                chkConsultaDet.Enabled = false;
                chkIngresarUb.Enabled = false;
                chkModificarUb.Enabled = false;
                chkDarBajaUb.Enabled = false;
                chkConsultaUb.Enabled = false;
                chkIngresarSub.Enabled = false;
                chkModificarSub.Enabled = false;
                chkDarBajaSub.Enabled = false;
                chkConsultaSub.Enabled = false;
                chkIngresarBo.Enabled = false;
                chkModificarBo.Enabled = false;
                chkDarBajaBo.Enabled = false;
                chkConsultarBo.Enabled = false;
                chkInventario.Enabled = false;
                chkModificarIn.Enabled = false;
                chkConsultaIn.Enabled = false;
                chkConsultarMovBo.Enabled = false;
                chkIngresarTipoT.Enabled = false;
                chkModificarTiT.Enabled = false;
                chkDarBajaTip.Enabled = false;
                chkConsultarTip.Enabled = false;
                chkIngresarTra.Enabled = false;
                chkModificarTra.Enabled = false;
                chkDarBajaTra.Enabled = false;
                chkConsultarTra.Enabled = false;
                chkIngresarRuta.Enabled = false;
                chkModificarRu.Enabled = false;
                chkDarBajaRu.Enabled = false;
                chkConsultarRu.Enabled = false;
                chkIngresarEnvio.Enabled = false;
                chkModificarEn.Enabled = false;
                chkDarBajaEn.Enabled = false;
                chkConsultaEn.Enabled = false;
                chkInsertarBitaTrans.Enabled = false;
                chkModificarBi.Enabled = false;
                chkConsultarBTTras.Enabled = false;
                chkBitacoraUsuario.Enabled = false;
                chkIngresarCalificacion.Enabled = false;
                chkModificarCa.Enabled = false;
                chkConsultarCa.Enabled = false;
                chkReportes.Enabled = false;
                /* Final deshabilitando checkbox*/
            }
            else if (valorCombo == "4")
            {
                /* Inicio Activando Cheques para tipo usuario especifico */
                chkIngresarU.Checked = false;
                chkModificarU.Checked = false;
                chkDarBajaU.Checked = false;
                chkConsultaU.Checked = false;
                chkIngresarC.Checked = false;
                chkModificarC.Checked = false;
                chkDarBajaC.Checked = false;
                chkConsultarC.Checked = false;
                chkIngresarD.Checked = false;
                chkModificarD.Checked = false;
                chkDarBajaD.Checked = false;
                chkConsultarD.Checked = false;
                chkIngresarPu.Checked = false;
                chkModificarPu.Checked = false;
                chkDarBajaPu.Checked = false;
                chkConsultaPu.Checked = false;
                chkIngresarPi.Checked = false;
                chkModificarPi.Checked = false;
                chkDarBajaPi.Checked = false;
                chkConsultaPi.Checked = false;
                chkIngresarEm.Checked = false;
                chkModificarE.Checked = false;
                chkDarBajaE.Checked = false;
                chkConsultaE.Checked = false;
                chkPaqueteEnc.Checked = false;
                chkModificarEnc.Checked = false;
                chkDarBajaPaEnc.Checked = false;
                chkConsultaPaEc.Checked = false;
                chkIngresarPaDe.Checked = false;
                chkModificarPaDet.Checked = false;
                chkDarBajaPaDet.Checked = false;
                chkConsultaDet.Checked = false;
                chkIngresarUb.Checked = false;
                chkModificarUb.Checked = false;
                chkDarBajaUb.Checked = false;
                chkConsultaUb.Checked = false;
                chkIngresarSub.Checked = false;
                chkModificarSub.Checked = false;
                chkDarBajaSub.Checked = false;
                chkConsultaSub.Checked = false;
                chkIngresarBo.Checked = false;
                chkModificarBo.Checked = false;
                chkDarBajaBo.Checked = false;
                chkConsultarBo.Checked = false;
                chkInventario.Checked = false;
                chkModificarIn.Checked = false;
                chkConsultaIn.Checked = false;
                chkConsultarMovBo.Checked = false;
                chkIngresarTipoT.Checked = false;
                chkModificarTiT.Checked = false;
                chkDarBajaTip.Checked = false;
                chkConsultarTip.Checked = false;
                chkIngresarTra.Checked = false;
                chkModificarTra.Checked = false;
                chkDarBajaTra.Checked = false;
                chkConsultarTra.Checked = false;
                chkIngresarRuta.Checked = false;
                chkModificarRu.Checked = false;
                chkDarBajaRu.Checked = false;
                chkConsultarRu.Checked = false;
                chkIngresarEnvio.Checked = false;
                chkModificarEn.Checked = false;
                chkDarBajaEn.Checked = false;
                chkConsultaEn.Checked = false;
                chkInsertarBitaTrans.Checked = false;
                chkModificarBi.Checked = false;
                chkConsultarBTTras.Checked = false;
                chkBitacoraUsuario.Checked = false;
                chkIngresarCalificacion.Checked = false;
                chkModificarCa.Checked = false;
                chkConsultarCa.Checked = false;
                chkReportes.Checked = false;
                /* Final Activando Cheques para tipo usuario especifico */

                /* Inicio habilitando checkbox*/
                chkIngresarU.Enabled = true;
                chkModificarU.Enabled = true;
                chkDarBajaU.Enabled = true;
                chkConsultaU.Enabled = true;
                chkIngresarC.Enabled = true;
                chkModificarC.Enabled = true;
                chkDarBajaC.Enabled = true;
                chkConsultarC.Enabled = true;
                chkIngresarD.Enabled = true;
                chkModificarD.Enabled = true;
                chkDarBajaD.Enabled = true;
                chkConsultarD.Enabled = true;
                chkIngresarPu.Enabled = true;
                chkModificarPu.Enabled = true;
                chkDarBajaPu.Enabled = true;
                chkConsultaPu.Enabled = true;
                chkIngresarPi.Enabled = true;
                chkModificarPi.Enabled = true;
                chkDarBajaPi.Enabled = true;
                chkConsultaPi.Enabled = true;
                chkIngresarEm.Enabled = true;
                chkModificarE.Enabled = true;
                chkDarBajaE.Enabled = true;
                chkConsultaE.Enabled = true;
                chkPaqueteEnc.Enabled = true;
                chkModificarEnc.Enabled = true;
                chkDarBajaPaEnc.Enabled = true;
                chkConsultaPaEc.Enabled = true;
                chkIngresarPaDe.Enabled = true;
                chkModificarPaDet.Enabled = true;
                chkDarBajaPaDet.Enabled = true;
                chkConsultaDet.Enabled = true;
                chkIngresarUb.Enabled = true;
                chkModificarUb.Enabled = true;
                chkDarBajaUb.Enabled = true;
                chkConsultaUb.Enabled = true;
                chkIngresarSub.Enabled = true;
                chkModificarSub.Enabled = true;
                chkDarBajaSub.Enabled = true;
                chkConsultaSub.Enabled = true;
                chkIngresarBo.Enabled = true;
                chkModificarBo.Enabled = true;
                chkDarBajaBo.Enabled = true;
                chkConsultarBo.Enabled = true;
                chkInventario.Enabled = true;
                chkModificarIn.Enabled = true;
                chkConsultaIn.Enabled = true;
                chkConsultarMovBo.Enabled = true;
                chkIngresarTipoT.Enabled = true;
                chkModificarTiT.Enabled = true;
                chkDarBajaTip.Enabled = true;
                chkConsultarTip.Enabled = true;
                chkIngresarTra.Enabled = true;
                chkModificarTra.Enabled = true;
                chkDarBajaTra.Enabled = true;
                chkConsultarTra.Enabled = true;
                chkIngresarRuta.Enabled = true;
                chkModificarRu.Enabled = true;
                chkDarBajaRu.Enabled = true;
                chkConsultarRu.Enabled = true;
                chkIngresarEnvio.Enabled = true;
                chkModificarEn.Enabled = true;
                chkDarBajaEn.Enabled = true;
                chkConsultaEn.Enabled = true;
                chkInsertarBitaTrans.Enabled = true;
                chkModificarBi.Enabled = true;
                chkConsultarBTTras.Enabled = true;
                chkBitacoraUsuario.Enabled = true;
                chkIngresarCalificacion.Enabled = true;
                chkModificarCa.Enabled = true;
                chkConsultarCa.Enabled = true;
                chkReportes.Enabled = true;
                /* Final habiidatando checkbox*/
            }

        }

        private void pnlBotonGuardarUS_MouseClick(object sender, MouseEventArgs e)
        {
            String idUsuario = txtCodigoUsuario.Text;
            String idTipoOermiso = CboTipoUsuario.SelectedValue.ToString();
            String codigoPermiso = txtCodigoP.Text;
            String nombreUsuario = txtUsuario.Text;
            String passUsuario = txtContraseñaU.Text;
            String confirmarPass = txtConfirmarC.Text;
            String estatusUsuario = "A";

            int ingresarUsuario = funBoolCheck(chkIngresarU);
            int modificarUsuario = funBoolCheck(chkModificarU);
            int dbUsuario = funBoolCheck(chkDarBajaU);
            int consultaUsuario = funBoolCheck(chkConsultaU);
            int ingresarCliente = funBoolCheck(chkIngresarC);
            int modificarCliente = funBoolCheck(chkModificarC);
            int dbCliente = funBoolCheck(chkDarBajaC);
            int consultaCliente = funBoolCheck(chkConsultarC);
            int ingresarDep = funBoolCheck(chkIngresarD);
            int modificarDep = funBoolCheck(chkModificarD);
            int dbDep = funBoolCheck(chkDarBajaD);
            int consultarDep = funBoolCheck(chkConsultarD);
            int ingresarPuesto = funBoolCheck(chkIngresarPu);
            int modificarPuesto = funBoolCheck(chkModificarPu);
            int dbPuesto = funBoolCheck(chkDarBajaPu);
            int consultarPuesto = funBoolCheck(chkConsultaPu);
            int ingresarPiloto = funBoolCheck(chkIngresarPi);
            int modificarPiloto = funBoolCheck(chkModificarPi);
            int dbPiloto = funBoolCheck(chkDarBajaPi);
            int consultaPiloto = funBoolCheck(chkConsultaPi);
            int ingresarEmpleado = funBoolCheck(chkIngresarEm);
            int modificarEmpleado = funBoolCheck(chkModificarE);
            int dbEmpleado = funBoolCheck(chkDarBajaE);
            int consultarEmpleado = funBoolCheck(chkConsultaE);
            int ingresarPaqueteEnc = funBoolCheck(chkPaqueteEnc);
            int modificarPaqueteEnc = funBoolCheck(chkModificarEnc);
            int dbpaqueteEnc = funBoolCheck(chkDarBajaPaEnc);
            int consultaPaqueteEnc = funBoolCheck(chkConsultaPaEc);
            int ingresarPaqueteDet = funBoolCheck(chkIngresarPaDe);
            int modificarPaqueteDet = funBoolCheck(chkModificarPaDet);
            int dbPaqueteDet = funBoolCheck(chkDarBajaPaDet);
            int consultaPaqueteDet = funBoolCheck(chkConsultaDet);
            int ingresarUbicacion = funBoolCheck(chkIngresarUb);
            int modificarUbicacion = funBoolCheck(chkModificarUb);
            int dbUbicacion = funBoolCheck(chkDarBajaUb);
            int consultaUbicacion = funBoolCheck(chkConsultaUb);
            int ingresarSububicacion = funBoolCheck(chkIngresarSub);
            int modificarSububicacion = funBoolCheck(chkModificarSub);
            int dbSububicacion = funBoolCheck(chkDarBajaSub);
            int consultaSububicion = funBoolCheck(chkConsultaSub);
            int ingresarBodega = funBoolCheck(chkIngresarBo);
            int modificarBodega = funBoolCheck(chkModificarBo);
            int dbBodega = funBoolCheck(chkDarBajaBo);
            int consultarBodega = funBoolCheck(chkConsultarBo);
            int ingresarInven = funBoolCheck(chkInventario);
            int modificarInven = funBoolCheck(chkModificarIn);
            int consultarInven = funBoolCheck(chkConsultaIn);
            int consultarMovBo = funBoolCheck(chkConsultarMovBo);
            int ingresarTipoTrans = funBoolCheck(chkIngresarTipoT);
            int modificarTipoTrans = funBoolCheck(chkModificarTiT);
            int dbTipoTrans = funBoolCheck(chkDarBajaTip);
            int consultaTipoTrans = funBoolCheck(chkConsultarTip);
            int ingresarTrans = funBoolCheck(chkIngresarTra);
            int modificarTrans = funBoolCheck(chkModificarTra);
            int dbTrans = funBoolCheck(chkDarBajaTra);
            int consultarTrans = funBoolCheck(chkConsultarTra);
            int ingresarRuta = funBoolCheck(chkIngresarRuta);
            int modificarRuta = funBoolCheck(chkModificarRu);
            int dbRuta = funBoolCheck(chkDarBajaRu);
            int consultaRuta = funBoolCheck(chkConsultarRu);
            int ingresarEnvio = funBoolCheck(chkIngresarEnvio);
            int modificarEnvio = funBoolCheck(chkModificarEn);
            int dbEnvio = funBoolCheck(chkDarBajaEn);
            int consultaEnvio = funBoolCheck(chkConsultaEn);
            int ingresarBitacoraTrans = funBoolCheck(chkInsertarBitaTrans);
            int modificarBitacoraTrans = funBoolCheck(chkModificarBi);
            int consultarBitacoraTrans = funBoolCheck(chkConsultarBTTras);
            int BitacoraUS = funBoolCheck(chkBitacoraUsuario);
            int ingresarCalificacion = funBoolCheck(chkIngresarCalificacion);
            int modificarCalificacion = funBoolCheck(chkModificarCa);
            int consultarCalificacion = funBoolCheck(chkConsultarCa);
            int reportes = funBoolCheck(chkReportes);


            Usuarios usuario = new Usuarios(idUsuario, idTipoOermiso, nombreUsuario, passUsuario, estatusUsuario, codigoPermiso, ingresarUsuario, modificarUsuario, dbUsuario,
            consultaUsuario, ingresarCliente, modificarCliente, dbCliente, consultaCliente, ingresarDep, modificarDep, dbDep, consultarDep, ingresarPuesto,
            modificarPuesto, dbPuesto, consultarPuesto, ingresarPiloto, modificarPiloto, dbPiloto, consultaPiloto, ingresarEmpleado, modificarEmpleado,
            dbEmpleado, consultarEmpleado, ingresarPaqueteEnc, modificarPaqueteEnc, dbpaqueteEnc, consultaPaqueteEnc, ingresarPaqueteDet, modificarPaqueteDet,
            dbPaqueteDet, consultaPaqueteDet, ingresarUbicacion, modificarUbicacion, dbUbicacion, consultaUbicacion, ingresarSububicacion, modificarSububicacion,
            dbSububicacion, consultaSububicion, ingresarBodega, modificarBodega, dbBodega, consultarBodega, ingresarInven, modificarInven, consultarInven,
            consultarMovBo, ingresarTipoTrans, modificarTipoTrans, dbTipoTrans, consultaTipoTrans, ingresarTrans, modificarTrans, dbTrans, consultarTrans,
            ingresarRuta, modificarRuta, dbRuta, consultaRuta, ingresarEnvio, modificarEnvio, dbEnvio, consultaEnvio, ingresarBitacoraTrans, modificarBitacoraTrans,
            consultarBitacoraTrans, BitacoraUS, ingresarCalificacion, modificarCalificacion, consultarCalificacion, reportes);


            

            if(passUsuario == confirmarPass)
            {
                String verificarCP = usuario.funVerificarExistenciaP(codigoPermiso);

                if (idUsuario == "" || codigoPermiso == "" || nombreUsuario == "" || passUsuario == "")
                {
                    MessageBox.Show("Ingrese Datos Correctamente!");
                }
                else
                {
                    if (verificarCP != codigoPermiso)
                    {
                        usuario.funInsertarPermisos();
                        usuario.funInsertarUsuario();

                        funCargarTabla(null);
                        funVaciarCampos();
                    }
                    else
                    {
                        usuario.funInsertarUsuario();

                        funCargarTabla(null);
                        funVaciarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese Contraseñas iguales!");
            }

            
            
            
        }

        public int funBoolCheck(CheckBox check)
        {
            int estadoBolean = 0;

            if(check.Checked == true)
            {
                estadoBolean = 1;
            }
            else if(check.Checked == false)
            {
                estadoBolean = 0;
            }

            return estadoBolean;
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
            btnPaqueteEncabezado.BackColor = colorHoverUsuarios;
        }

        private void lblPaqueteEncabezado_MouseHover(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorHoverUsuarios;
        }

        private void picIconoPaqueteE_MouseHover(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorHoverUsuarios;
        }

        private void btnPaqueteEncabezado_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalUsuarios;
        }

        private void lblPaqueteEncabezado_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalUsuarios;
        }

        private void picIconoPaqueteE_MouseLeave(object sender, EventArgs e)
        {
            btnPaqueteEncabezado.BackColor = colorNormalUsuarios;
        }

        private void pnlEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        /* Inicio funcion para cargar mi tabla de Puesto */
        private void funCargarTabla(string dato)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Usuarios usuario = new Usuarios();

            dgvUsuario.DataSource = usuario.consulta(dato);
        }

        private void lblModificarUsuario_Click(object sender, EventArgs e)
        {

            
        }

        private void pnlLLenarCamposUS_MouseClick(object sender, MouseEventArgs e)
        {
            txtCodigoUsuario.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
            String idCodigoP = dgvUsuario.CurrentRow.Cells[1].Value.ToString();

            Usuarios usuario = new Usuarios();
            int tipoP = usuario.obtenerNombreTP(idCodigoP);

            CboTipoUsuario.SelectedValue = tipoP;

            txtCodigoP.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
            txtContraseñaU.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
            txtEstatusU.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();

            String codigoP = txtCodigoP.Text;

            usuario.funSetearChecks(chkIngresarU, chkModificarU, chkDarBajaU, chkConsultaU, chkIngresarC, chkModificarC, chkDarBajaC, chkConsultarC,
            chkIngresarD, chkModificarD, chkDarBajaD, chkConsultarD, chkIngresarPu, chkModificarPu, chkDarBajaPu, chkConsultaPu, chkIngresarPi, chkModificarPi,
            chkDarBajaPi, chkConsultaPi, chkIngresarEm, chkModificarE, chkDarBajaE, chkConsultaE, chkPaqueteEnc, chkModificarEnc, chkDarBajaPaEnc,
            chkConsultaPaEc, chkIngresarPaDe, chkModificarPaDet, chkDarBajaPaDet, chkConsultaDet, chkIngresarUb, chkModificarUb, chkDarBajaUb, chkConsultaUb,
            chkIngresarSub, chkModificarSub, chkDarBajaSub, chkConsultaSub, chkIngresarBo, chkModificarBo, chkDarBajaBo, chkConsultarBo, chkInventario,
            chkModificarIn, chkConsultaIn, chkConsultarMovBo, chkIngresarTipoT, chkModificarTiT, chkDarBajaTip, chkConsultarTip, chkIngresarTra, chkModificarTra,
            chkDarBajaTra, chkConsultarTra, chkIngresarRuta, chkModificarRu, chkDarBajaRu, chkConsultarRu, chkIngresarEnvio, chkModificarEn, chkDarBajaEn,
            chkConsultaEn, chkInsertarBitaTrans, chkModificarBi, chkConsultarBTTras, chkBitacoraUsuario, chkIngresarCalificacion, chkModificarCa, chkConsultarCa,
            chkReportes,codigoP);

        }

        private void lblRegistrarUsuario_MouseClick(object sender, MouseEventArgs e)
        {

            pnlBordeRegistrarUsu.Visible = true;
            pnlBordeModificarUsu.Visible = false;
            pnlBordeDarBajaU.Visible = false;

            /*Inicio Esconder y mostrando contenidos de mi form puestos */
            pnlContenidoTP.Visible = true;
            pnlCodigoP.Visible = true;
            pnlCodigoU.Visible = true;
            pnlNombreU.Visible = true;
            pnlPass.Visible = true;
            pnlVeriPass.Visible = true;
            pnlEstatusU.Visible = false;
            dgvUsuario.Visible = true;
            txtBuscarUsuario.Visible = true;
            pnlBotonBuscarUsuario.Visible = true;
            pnlBotonGuardarUS.Visible = true;
            pnlModificarUS.Visible = false;
            pnlActivarUS.Visible = false;
            pnlDarBajaUS.Visible = false;
            pnlLlenarCamposUSDB.Visible = false;
            pnlLLenarCamposUS.Visible = true;
            pnlChecks.Visible = true;
            /*Final Esconder y mostrando contenidos de mi form puestos */

            CboTipoUsuario.Enabled = true;
            txtCodigoP.Enabled = true;
            txtCodigoUsuario.Enabled = true;
            txtContraseñaU.Enabled = true;
            txtUsuario.Enabled = true;
            txtConfirmarC.Enabled = true;



            Usuarios usuario = new Usuarios();
            funCargarTabla(null);

            funVaciarCampos();
        }

        public void funVaciarCampos()
        {
            CboTipoUsuario.SelectedValue = 1;
            txtCodigoP.Text = "";
            txtCodigoUsuario.Text = "";
            txtUsuario.Text = "";
            txtContraseñaU.Text = "";
            txtConfirmarC.Text = "";
            txtEstatusU.Text = "";
            txtBuscarUsuario.Text = "";

            /* Inicio Activando Cheques para tipo usuario especifico */
            chkIngresarU.Checked = false;
            chkModificarU.Checked = false;
            chkDarBajaU.Checked = false;
            chkConsultaU.Checked = false;
            chkIngresarC.Checked = false;
            chkModificarC.Checked = false;
            chkDarBajaC.Checked = false;
            chkConsultarC.Checked = false;
            chkIngresarD.Checked = false;
            chkModificarD.Checked = false;
            chkDarBajaD.Checked = false;
            chkConsultarD.Checked = false;
            chkIngresarPu.Checked = false;
            chkModificarPu.Checked = false;
            chkDarBajaPu.Checked = false;
            chkConsultaPu.Checked = false;
            chkIngresarPi.Checked = false;
            chkModificarPi.Checked = false;
            chkDarBajaPi.Checked = false;
            chkConsultaPi.Checked = false;
            chkIngresarEm.Checked = false;
            chkModificarE.Checked = false;
            chkDarBajaE.Checked = false;
            chkConsultaE.Checked = false;
            chkPaqueteEnc.Checked = false;
            chkModificarEnc.Checked = false;
            chkDarBajaPaEnc.Checked = false;
            chkConsultaPaEc.Checked = false;
            chkIngresarPaDe.Checked = false;
            chkModificarPaDet.Checked = false;
            chkDarBajaPaDet.Checked = false;
            chkConsultaDet.Checked = false;
            chkIngresarUb.Checked = false;
            chkModificarUb.Checked = false;
            chkDarBajaUb.Checked = false;
            chkConsultaUb.Checked = false;
            chkIngresarSub.Checked = false;
            chkModificarSub.Checked = false;
            chkDarBajaSub.Checked = false;
            chkConsultaSub.Checked = false;
            chkIngresarBo.Checked = false;
            chkModificarBo.Checked = false;
            chkDarBajaBo.Checked = false;
            chkConsultarBo.Checked = false;
            chkInventario.Checked = false;
            chkModificarIn.Checked = false;
            chkConsultaIn.Checked = false;
            chkConsultarMovBo.Checked = false;
            chkIngresarTipoT.Checked = false;
            chkModificarTiT.Checked = false;
            chkDarBajaTip.Checked = false;
            chkConsultarTip.Checked = false;
            chkIngresarTra.Checked = false;
            chkModificarTra.Checked = false;
            chkDarBajaTra.Checked = false;
            chkConsultarTra.Checked = false;
            chkIngresarRuta.Checked = false;
            chkModificarRu.Checked = false;
            chkDarBajaRu.Checked = false;
            chkConsultarRu.Checked = false;
            chkIngresarEnvio.Checked = false;
            chkModificarEn.Checked = false;
            chkDarBajaEn.Checked = false;
            chkConsultaEn.Checked = false;
            chkInsertarBitaTrans.Checked = false;
            chkModificarBi.Checked = false;
            chkConsultarBTTras.Checked = false;
            chkBitacoraUsuario.Checked = false;
            chkIngresarCalificacion.Checked = false;
            chkModificarCa.Checked = false;
            chkConsultarCa.Checked = false;
            chkReportes.Checked = false;
            /* Final Activando Cheques para tipo usuario especifico */
        }

        private void pnlModificarUS_MouseClick(object sender, MouseEventArgs e)
        {
            String estatusUsuario = "A";
            String idPermisos = txtCodigoP.Text;
            Usuarios usuario = funObtenerTxt(estatusUsuario);

            usuario.funModificarPermisos(idPermisos);
            usuario.funModificarUsuario();

            usuario.funSetearChecks(chkIngresarU, chkModificarU, chkDarBajaU, chkConsultaU, chkIngresarC, chkModificarC, chkDarBajaC, chkConsultarC,
            chkIngresarD, chkModificarD, chkDarBajaD, chkConsultarD, chkIngresarPu, chkModificarPu, chkDarBajaPu, chkConsultaPu, chkIngresarPi, chkModificarPi,
            chkDarBajaPi, chkConsultaPi, chkIngresarEm, chkModificarE, chkDarBajaE, chkConsultaE, chkPaqueteEnc, chkModificarEnc, chkDarBajaPaEnc,
            chkConsultaPaEc, chkIngresarPaDe, chkModificarPaDet, chkDarBajaPaDet, chkConsultaDet, chkIngresarUb, chkModificarUb, chkDarBajaUb, chkConsultaUb,
            chkIngresarSub, chkModificarSub, chkDarBajaSub, chkConsultaSub, chkIngresarBo, chkModificarBo, chkDarBajaBo, chkConsultarBo, chkInventario,
            chkModificarIn, chkConsultaIn, chkConsultarMovBo, chkIngresarTipoT, chkModificarTiT, chkDarBajaTip, chkConsultarTip, chkIngresarTra, chkModificarTra,
            chkDarBajaTra, chkConsultarTra, chkIngresarRuta, chkModificarRu, chkDarBajaRu, chkConsultarRu, chkIngresarEnvio, chkModificarEn, chkDarBajaEn,
            chkConsultaEn, chkInsertarBitaTrans, chkModificarBi, chkConsultarBTTras, chkBitacoraUsuario, chkIngresarCalificacion, chkModificarCa, chkConsultarCa,
            chkReportes, idPermisos);

            funCargarTabla(null);
            //puesto.funBuscarSetearTxt(txtIdPuesto, txtNombrePuesto, txtEstatusPuesto, idPuesto);
        }

        public Usuarios funObtenerTxt(String estatus)
        {
            /*Inicio obteniedo variables a usar con mi ABC Puesto */
            String pTipoP = CboTipoUsuario.SelectedValue.ToString();
            String pCodigoPermiso = txtCodigoP.Text;
            String pCodigoUsuario = txtCodigoUsuario.Text;
            String nombreUsuario = txtUsuario.Text;
            String passUsuario = txtContraseñaU.Text;
            /*Final obteniedo variables a usar con mi ABC Puesto */

            int ingresarUsuario = funBoolCheck(chkIngresarU);
            int modificarUsuario = funBoolCheck(chkModificarU);
            int dbUsuario = funBoolCheck(chkDarBajaU);
            int consultaUsuario = funBoolCheck(chkConsultaU);
            int ingresarCliente = funBoolCheck(chkIngresarC);
            int modificarCliente = funBoolCheck(chkModificarC);
            int dbCliente = funBoolCheck(chkDarBajaC);
            int consultaCliente = funBoolCheck(chkConsultarC);
            int ingresarDep = funBoolCheck(chkIngresarD);
            int modificarDep = funBoolCheck(chkModificarD);
            int dbDep = funBoolCheck(chkDarBajaD);
            int consultarDep = funBoolCheck(chkConsultarD);
            int ingresarPuesto = funBoolCheck(chkIngresarPu);
            int modificarPuesto = funBoolCheck(chkModificarPu);
            int dbPuesto = funBoolCheck(chkDarBajaPu);
            int consultarPuesto = funBoolCheck(chkConsultaPu);
            int ingresarPiloto = funBoolCheck(chkIngresarPi);
            int modificarPiloto = funBoolCheck(chkModificarPi);
            int dbPiloto = funBoolCheck(chkDarBajaPi);
            int consultaPiloto = funBoolCheck(chkConsultaPi);
            int ingresarEmpleado = funBoolCheck(chkIngresarEm);
            int modificarEmpleado = funBoolCheck(chkModificarE);
            int dbEmpleado = funBoolCheck(chkDarBajaE);
            int consultarEmpleado = funBoolCheck(chkConsultaE);
            int ingresarPaqueteEnc = funBoolCheck(chkPaqueteEnc);
            int modificarPaqueteEnc = funBoolCheck(chkModificarEnc);
            int dbpaqueteEnc = funBoolCheck(chkDarBajaPaEnc);
            int consultaPaqueteEnc = funBoolCheck(chkConsultaPaEc);
            int ingresarPaqueteDet = funBoolCheck(chkIngresarPaDe);
            int modificarPaqueteDet = funBoolCheck(chkModificarPaDet);
            int dbPaqueteDet = funBoolCheck(chkDarBajaPaDet);
            int consultaPaqueteDet = funBoolCheck(chkConsultaDet);
            int ingresarUbicacion = funBoolCheck(chkIngresarUb);
            int modificarUbicacion = funBoolCheck(chkModificarUb);
            int dbUbicacion = funBoolCheck(chkDarBajaUb);
            int consultaUbicacion = funBoolCheck(chkConsultaUb);
            int ingresarSububicacion = funBoolCheck(chkIngresarSub);
            int modificarSububicacion = funBoolCheck(chkModificarSub);
            int dbSububicacion = funBoolCheck(chkDarBajaSub);
            int consultaSububicion = funBoolCheck(chkConsultaSub);
            int ingresarBodega = funBoolCheck(chkIngresarBo);
            int modificarBodega = funBoolCheck(chkModificarBo);
            int dbBodega = funBoolCheck(chkDarBajaBo);
            int consultarBodega = funBoolCheck(chkConsultarBo);
            int ingresarInven = funBoolCheck(chkInventario);
            int modificarInven = funBoolCheck(chkModificarIn);
            int consultarInven = funBoolCheck(chkConsultaIn);
            int consultarMovBo = funBoolCheck(chkConsultarMovBo);
            int ingresarTipoTrans = funBoolCheck(chkIngresarTipoT);
            int modificarTipoTrans = funBoolCheck(chkModificarTiT);
            int dbTipoTrans = funBoolCheck(chkDarBajaTip);
            int consultaTipoTrans = funBoolCheck(chkConsultarTip);
            int ingresarTrans = funBoolCheck(chkIngresarTra);
            int modificarTrans = funBoolCheck(chkModificarTra);
            int dbTrans = funBoolCheck(chkDarBajaTra);
            int consultarTrans = funBoolCheck(chkConsultarTra);
            int ingresarRuta = funBoolCheck(chkIngresarRuta);
            int modificarRuta = funBoolCheck(chkModificarRu);
            int dbRuta = funBoolCheck(chkDarBajaRu);
            int consultaRuta = funBoolCheck(chkConsultarRu);
            int ingresarEnvio = funBoolCheck(chkIngresarEnvio);
            int modificarEnvio = funBoolCheck(chkModificarEn);
            int dbEnvio = funBoolCheck(chkDarBajaEn);
            int consultaEnvio = funBoolCheck(chkConsultaEn);
            int ingresarBitacoraTrans = funBoolCheck(chkInsertarBitaTrans);
            int modificarBitacoraTrans = funBoolCheck(chkModificarBi);
            int consultarBitacoraTrans = funBoolCheck(chkConsultarBTTras);
            int BitacoraUS = funBoolCheck(chkBitacoraUsuario);
            int ingresarCalificacion = funBoolCheck(chkIngresarCalificacion);
            int modificarCalificacion = funBoolCheck(chkModificarCa);
            int consultarCalificacion = funBoolCheck(chkConsultarCa);
            int reportes = funBoolCheck(chkReportes);

            /* Inicio creamos un objeto de tipo cliente para poder utilizar el metodo de insertar cliente */
            Usuarios usuario = new Usuarios(pCodigoUsuario, pTipoP, nombreUsuario, passUsuario, estatus, pCodigoPermiso, ingresarUsuario, modificarUsuario, dbUsuario,
            consultaUsuario, ingresarCliente, modificarCliente, dbCliente, consultaCliente, ingresarDep, modificarDep, dbDep, consultarDep, ingresarPuesto,
            modificarPuesto, dbPuesto, consultarPuesto, ingresarPiloto, modificarPiloto, dbPiloto, consultaPiloto, ingresarEmpleado, modificarEmpleado,
            dbEmpleado, consultarEmpleado, ingresarPaqueteEnc, modificarPaqueteEnc, dbpaqueteEnc, consultaPaqueteEnc, ingresarPaqueteDet, modificarPaqueteDet,
            dbPaqueteDet, consultaPaqueteDet, ingresarUbicacion, modificarUbicacion, dbUbicacion, consultaUbicacion, ingresarSububicacion, modificarSububicacion,
            dbSububicacion, consultaSububicion, ingresarBodega, modificarBodega, dbBodega, consultarBodega, ingresarInven, modificarInven, consultarInven,
            consultarMovBo, ingresarTipoTrans, modificarTipoTrans, dbTipoTrans, consultaTipoTrans, ingresarTrans, modificarTrans, dbTrans, consultarTrans,
            ingresarRuta, modificarRuta, dbRuta, consultaRuta, ingresarEnvio, modificarEnvio, dbEnvio, consultaEnvio, ingresarBitacoraTrans, modificarBitacoraTrans,
            consultarBitacoraTrans, BitacoraUS, ingresarCalificacion, modificarCalificacion, consultarCalificacion, reportes);
            /* Final creamos un objeto de tipo cliente para poder utilizar el metodo de insertar cliente */

            return usuario;
        }

        private void lblDarBajaUsu_Click(object sender, EventArgs e)
        {

        }

        private void lblDarBajaUsu_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeRegistrarUsu.Visible = false;
            pnlBordeModificarUsu.Visible = false;
            pnlBordeDarBajaU.Visible = true;

            funCargarTabla(null);

            /*Inicio Esconder y mostrando contenidos de mi form puestos */
            pnlContenidoTP.Visible = true;
            pnlCodigoP.Visible = true;
            pnlCodigoU.Visible = true;
            pnlNombreU.Visible = true;
            pnlPass.Visible = true;
            pnlVeriPass.Visible = false;
            pnlEstatusU.Visible = true;
            dgvUsuario.Visible = true;
            txtBuscarUsuario.Visible = true;
            pnlBotonBuscarUsuario.Visible = true;
            pnlBotonGuardarUS.Visible = false;
            pnlModificarUS.Visible = false;
            pnlActivarUS.Visible = false;
            pnlDarBajaUS.Visible = false;
            pnlLlenarCamposUSDB.Visible = true;
            pnlLLenarCamposUS.Visible = false;
            pnlChecks.Visible = true;
            /*Final Esconder y mostrando contenidos de mi form puestos */

            txtCodigoUsuario.Enabled = false;
            CboTipoUsuario.Enabled = false;
            txtCodigoP.Enabled = false;
            txtContraseñaU.Enabled = false;
            txtConfirmarC.Enabled = false;
            txtUsuario.Enabled = false;
            txtEstatusU.Enabled = false;

            funVaciarCampos();
        }

        private void pnlLlenarCamposUSDB_MouseClick(object sender, MouseEventArgs e)
        {
            txtCodigoUsuario.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
            String idCodigoP = dgvUsuario.CurrentRow.Cells[1].Value.ToString();

            Usuarios usuario = new Usuarios();
            int tipoP = usuario.obtenerNombreTP(idCodigoP);

            CboTipoUsuario.SelectedValue = tipoP;

            txtCodigoP.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
            txtContraseñaU.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
            txtEstatusU.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();

            String codigoP = txtCodigoP.Text;

            usuario.funSetearChecks(chkIngresarU, chkModificarU, chkDarBajaU, chkConsultaU, chkIngresarC, chkModificarC, chkDarBajaC, chkConsultarC,
            chkIngresarD, chkModificarD, chkDarBajaD, chkConsultarD, chkIngresarPu, chkModificarPu, chkDarBajaPu, chkConsultaPu, chkIngresarPi, chkModificarPi,
            chkDarBajaPi, chkConsultaPi, chkIngresarEm, chkModificarE, chkDarBajaE, chkConsultaE, chkPaqueteEnc, chkModificarEnc, chkDarBajaPaEnc,
            chkConsultaPaEc, chkIngresarPaDe, chkModificarPaDet, chkDarBajaPaDet, chkConsultaDet, chkIngresarUb, chkModificarUb, chkDarBajaUb, chkConsultaUb,
            chkIngresarSub, chkModificarSub, chkDarBajaSub, chkConsultaSub, chkIngresarBo, chkModificarBo, chkDarBajaBo, chkConsultarBo, chkInventario,
            chkModificarIn, chkConsultaIn, chkConsultarMovBo, chkIngresarTipoT, chkModificarTiT, chkDarBajaTip, chkConsultarTip, chkIngresarTra, chkModificarTra,
            chkDarBajaTra, chkConsultarTra, chkIngresarRuta, chkModificarRu, chkDarBajaRu, chkConsultarRu, chkIngresarEnvio, chkModificarEn, chkDarBajaEn,
            chkConsultaEn, chkInsertarBitaTrans, chkModificarBi, chkConsultarBTTras, chkBitacoraUsuario, chkIngresarCalificacion, chkModificarCa, chkConsultarCa,
            chkReportes, codigoP);

            String pidUsuario = txtCodigoUsuario.Text;
            String pestatusUsuario = usuario.funBuscarEstatus(pidUsuario);

            Console.WriteLine(pestatusUsuario);

            if (pestatusUsuario == "A")
            {
                pnlActivarUS.Visible = false;
                pnlDarBajaUS.Visible = true;
            }
            else if (pestatusUsuario == "I")
            {
                pnlDarBajaUS.Visible = false;
                pnlActivarUS.Visible = true;
            }

        }

        private void pnlActivarUS_MouseClick(object sender, MouseEventArgs e)
        {
            String estatus = "I";
            String pIdUsuario = txtCodigoUsuario.Text;
            String codigoPermiso = txtCodigoP.Text;
            Usuarios usuario = funObtenerTxt(estatus);

            usuario.funActivarUsuario();
            funCargarTabla(null);

            pnlDarBajaUS.Visible = true;
            pnlActivarUS.Visible = false;

            usuario.funBuscarSetearTxt(txtUsuario, txtContraseñaU, txtEstatusU, CboTipoUsuario, chkIngresarU, chkModificarU, chkDarBajaU, chkConsultaU, chkIngresarC, chkModificarC, chkDarBajaC, chkConsultarC,
            chkIngresarD, chkModificarD, chkDarBajaD, chkConsultarD, chkIngresarPu, chkModificarPu, chkDarBajaPu, chkConsultaPu, chkIngresarPi, chkModificarPi,
            chkDarBajaPi, chkConsultaPi, chkIngresarEm, chkModificarE, chkDarBajaE, chkConsultaE, chkPaqueteEnc, chkModificarEnc, chkDarBajaPaEnc,
            chkConsultaPaEc, chkIngresarPaDe, chkModificarPaDet, chkDarBajaPaDet, chkConsultaDet, chkIngresarUb, chkModificarUb, chkDarBajaUb, chkConsultaUb,
            chkIngresarSub, chkModificarSub, chkDarBajaSub, chkConsultaSub, chkIngresarBo, chkModificarBo, chkDarBajaBo, chkConsultarBo, chkInventario,
            chkModificarIn, chkConsultaIn, chkConsultarMovBo, chkIngresarTipoT, chkModificarTiT, chkDarBajaTip, chkConsultarTip, chkIngresarTra, chkModificarTra,
            chkDarBajaTra, chkConsultarTra, chkIngresarRuta, chkModificarRu, chkDarBajaRu, chkConsultarRu, chkIngresarEnvio, chkModificarEn, chkDarBajaEn,
            chkConsultaEn, chkInsertarBitaTrans, chkModificarBi, chkConsultarBTTras, chkBitacoraUsuario, chkIngresarCalificacion, chkModificarCa, chkConsultarCa,
            chkReportes, pIdUsuario,codigoPermiso);
        }

        private void pnlDarBajaUS_MouseClick(object sender, MouseEventArgs e)
        {
            String estatus = "I";
            String pIdUsuario = txtCodigoUsuario.Text;
            String codigoPermiso = txtCodigoP.Text;
            Usuarios usuario = funObtenerTxt(estatus);

            usuario.funDarBajaUsuario();
            funCargarTabla(null);

            pnlDarBajaUS.Visible = false;
            pnlActivarUS.Visible = true;

            usuario.funBuscarSetearTxt(txtUsuario, txtContraseñaU, txtEstatusU, CboTipoUsuario, chkIngresarU, chkModificarU, chkDarBajaU, chkConsultaU, chkIngresarC, chkModificarC, chkDarBajaC, chkConsultarC,
            chkIngresarD, chkModificarD, chkDarBajaD, chkConsultarD, chkIngresarPu, chkModificarPu, chkDarBajaPu, chkConsultaPu, chkIngresarPi, chkModificarPi,
            chkDarBajaPi, chkConsultaPi, chkIngresarEm, chkModificarE, chkDarBajaE, chkConsultaE, chkPaqueteEnc, chkModificarEnc, chkDarBajaPaEnc,
            chkConsultaPaEc, chkIngresarPaDe, chkModificarPaDet, chkDarBajaPaDet, chkConsultaDet, chkIngresarUb, chkModificarUb, chkDarBajaUb, chkConsultaUb,
            chkIngresarSub, chkModificarSub, chkDarBajaSub, chkConsultaSub, chkIngresarBo, chkModificarBo, chkDarBajaBo, chkConsultarBo, chkInventario,
            chkModificarIn, chkConsultaIn, chkConsultarMovBo, chkIngresarTipoT, chkModificarTiT, chkDarBajaTip, chkConsultarTip, chkIngresarTra, chkModificarTra,
            chkDarBajaTra, chkConsultarTra, chkIngresarRuta, chkModificarRu, chkDarBajaRu, chkConsultarRu, chkIngresarEnvio, chkModificarEn, chkDarBajaEn,
            chkConsultaEn, chkInsertarBitaTrans, chkModificarBi, chkConsultarBTTras, chkBitacoraUsuario, chkIngresarCalificacion, chkModificarCa, chkConsultarCa,
            chkReportes, pIdUsuario, codigoPermiso);
        }

        private void pnlBotonBuscarUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            /* Inicio buscando el dato ingresado por el usuario y llenando mi tabla */
            String buscarUsuario = txtBuscarUsuario.Text;
            funCargarTabla(buscarUsuario);
            /* Final buscando el dato ingresado por el usuario y llenando mi tabla */

            /* Inicio Vaciando los campos */
            funVaciarCampos();
            pnlDarBajaUS.Visible = false;
            pnlActivarUS.Visible = false;
            /* Final Vaciando los campos */
        }

        private void lblAbcUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeUsuarios.Visible = true;
            lblRegistrarUsuario.Visible = true;
            lblModificarUsuario.Visible = true;
            lblDarBajaUsu.Visible = true;
        }

        private void lblModificarUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            pnlBordeRegistrarUsu.Visible = false;
            pnlBordeDarBajaU.Visible = false;
            pnlBordeModificarUsu.Visible = true;


            funCargarTabla(null);

            /*Inicio Esconder y mostrando contenidos de mi form puestos */
            pnlContenidoTP.Visible = true;
            pnlCodigoP.Visible = true;
            pnlCodigoU.Visible = true;
            pnlNombreU.Visible = true;
            pnlPass.Visible = true;
            pnlVeriPass.Visible = false;
            pnlEstatusU.Visible = false;
            dgvUsuario.Visible = true;
            txtBuscarUsuario.Visible = true;
            pnlBotonBuscarUsuario.Visible = true;
            pnlBotonGuardarUS.Visible = false;
            pnlModificarUS.Visible = true;
            pnlActivarUS.Visible = false;
            pnlDarBajaUS.Visible = false;
            pnlLlenarCamposUSDB.Visible = false;
            pnlLLenarCamposUS.Visible = true;
            pnlChecks.Visible = true;
            /*Final Esconder y mostrando contenidos de mi form puestos */

            txtCodigoUsuario.Enabled = false;
            txtCodigoP.Enabled = false;
            CboTipoUsuario.Enabled = true;
            txtCodigoP.Enabled = true;
            txtContraseñaU.Enabled = true;
            txtConfirmarC.Enabled = true;
            txtUsuario.Enabled = true;



            funVaciarCampos();
        }

        private void btnUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverUsuarios;
        }

        private void lblUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverUsuarios;
        }

        private void picIconoUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorHoverUsuarios;
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalUsuarios;
        }

        private void lblUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalUsuarios;
        }

        private void picIconoUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.BackColor = colorNormalUsuarios;
        }

        private void btnCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverUsuarios;
        }

        private void lblCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverUsuarios;
        }

        private void picIconoCliente_MouseHover(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorHoverUsuarios;
        }

        private void btnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalUsuarios;
        }

        private void lblCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalUsuarios;
        }

        private void picIconoCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = colorNormalUsuarios;
        }

        private void btnPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverUsuarios;
        }

        private void lblPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverUsuarios;
        }

        private void picPuesto_MouseHover(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorHoverUsuarios;
        }

        private void btnPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalUsuarios;
        }

        private void lblPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalUsuarios;
        }

        private void picPuesto_MouseLeave(object sender, EventArgs e)
        {
            btnPuesto.BackColor = colorNormalUsuarios;
        }

        private void btnDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverUsuarios;
        }

        private void lblDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverUsuarios;
        }

        private void picDepartamento_MouseHover(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorHoverUsuarios;
        }

        private void btnDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalUsuarios;
        }

        private void lblDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalUsuarios;
        }

        private void picDepartamento_MouseLeave(object sender, EventArgs e)
        {
            btnDepartamento.BackColor = colorNormalUsuarios;
        }

        private void btnUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverUsuarios;
        }

        private void lblUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverUsuarios;
        }

        private void picIconoUbicacion_MouseHover(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorHoverUsuarios;
        }

        private void btnUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalUsuarios;
        }

        private void lblUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalUsuarios;
        }

        private void picIconoUbicacion_MouseLeave(object sender, EventArgs e)
        {
            btnUbicacion.BackColor = colorNormalUsuarios;
        }

        private void btnTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void lblTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void picTipoEmpleado_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void btnTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void lblTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void picTipoEmpleado_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void btnRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverUsuarios;
        }

        private void lblRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverUsuarios;
        }

        private void picRuta_MouseHover(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorHoverUsuarios;
        }

        private void btnRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalUsuarios;
        }

        private void lblRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalUsuarios;
        }

        private void picRuta_MouseLeave(object sender, EventArgs e)
        {
            btnRuta.BackColor = colorNormalUsuarios;
        }

        private void pnlSubUbicacion_MouseHover(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorHoverUsuarios;
        }

        private void lblSubUbicacion_MouseHover(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorHoverUsuarios;
        }

        private void picSubUbicacion_MouseHover(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorHoverUsuarios;
        }

        private void pnlSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalUsuarios;
        }

        private void lblSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalUsuarios;
        }

        private void picSubUbicacion_MouseLeave(object sender, EventArgs e)
        {
            pnlSubUbicacion.BackColor = colorNormalUsuarios;
        }

        private void btnTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void lblTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void picTipoMovimiento_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void btnTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void lblTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void picTipoMovimiento_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverUsuarios;
        }

        private void lblTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverUsuarios;
        }

        private void picIconoTipoTransporte_MouseHover(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorHoverUsuarios;
        }

        private void btnTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalUsuarios;
        }

        private void lblTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalUsuarios;
        }

        private void picIconoTipoTransporte_MouseLeave(object sender, EventArgs e)
        {
            btnTipoTransporte.BackColor = colorNormalUsuarios;
        }

        private void pnlEmpleado_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverUsuarios;
        }

        private void lblEmpleado_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverUsuarios;
        }

        private void picEmple_MouseHover(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorHoverUsuarios;
        }

        private void pnlEmpleado_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalUsuarios;
        }

        private void lblEmpleado_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalUsuarios;
        }

        private void picEmple_MouseLeave(object sender, EventArgs e)
        {
            pnlEmpleado.BackColor = colorNormalUsuarios;
        }

        private void btnDepartamento_MouseClick(object sender, MouseEventArgs e)
        {
            frmDepartamento dep = new frmDepartamento();
            dep.Visible = true;

            Visible = false;
        }

        private void lblDepartamento_MouseClick(object sender, MouseEventArgs e)
        {
            frmDepartamento dep = new frmDepartamento();
            dep.Visible = true;

            Visible = false;
        }

        private void picDepartamento_MouseClick(object sender, MouseEventArgs e)
        {
            frmDepartamento dep = new frmDepartamento();
            dep.Visible = true;

            Visible = false;
        }

        private void btnUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion ubicacion = new frmUbicacion();
            ubicacion.Visible = true;

            Visible = false;
        }

        private void lblUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion ubicacion = new frmUbicacion();
            ubicacion.Visible = true;

            Visible = false;
        }

        private void picIconoUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmUbicacion ubicacion = new frmUbicacion();
            ubicacion.Visible = true;

            Visible = false;
        }

        private void btnRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta ruta = new frmRuta();
            ruta.Visible = true;

            Visible = false;
        }

        private void lblRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta ruta = new frmRuta();
            ruta.Visible = true;

            Visible = false;
        }

        private void picRuta_MouseClick(object sender, MouseEventArgs e)
        {
            frmRuta ruta = new frmRuta();
            ruta.Visible = true;

            Visible = false;
        }

        private void pnlSubUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmSubUbicacion sub = new frmSubUbicacion();
            sub.Visible = true;

            Visible = false;
        }

        private void lblSubUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmSubUbicacion sub = new frmSubUbicacion();
            sub.Visible = true;

            Visible = false;
        }

        private void picSubUbicacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmSubUbicacion sub = new frmSubUbicacion();
            sub.Visible = true;

            Visible = false;
        }

        private void btnTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento tMov = new frmTipoMovimiento();
            tMov.Visible = true;

            Visible = false;
        }

        private void lblTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento tMov = new frmTipoMovimiento();
            tMov.Visible = true;

            Visible = false;
        }

        private void picTipoMovimiento_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoMovimiento tMov = new frmTipoMovimiento();
            tMov.Visible = true;

            Visible = false;
        }

        private void btnTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte tTrans = new frmTipoTransporte();
            tTrans.Visible = true;

            Visible = false;
        }

        private void lblTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte tTrans = new frmTipoTransporte();
            tTrans.Visible = true;

            Visible = false;
        }

        private void picIconoTipoTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            frmTipoTransporte tTrans = new frmTipoTransporte();
            tTrans.Visible = true;

            Visible = false;
        }

        private void lblEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void picEmple_MouseClick(object sender, MouseEventArgs e)
        {
            frmEmpleado obj = new frmEmpleado();

            obj.Visible = true;

            Visible = false;
        }

        private void btnBodega_MouseClick(object sender, MouseEventArgs e)
        {

            frmBodega bodega = new frmBodega();
            bodega.Visible = true;

            Visible = false;
        }

        private void lblBodega_MouseClick(object sender, MouseEventArgs e)
        {

            frmBodega bodega = new frmBodega();
            bodega.Visible = true;

            Visible = false;
        }

        private void picBodega_MouseClick(object sender, MouseEventArgs e)
        {

            frmBodega bodega = new frmBodega();
            bodega.Visible = true;

            Visible = false;
        }

        private void btnBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverUsuarios;
        }

        private void lblBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverUsuarios;
        }

        private void picBodega_MouseHover(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorHoverUsuarios;
        }

        private void btnBodega_MouseLeave(object sender, EventArgs e)
        {

            btnBodega.BackColor = colorNormalUsuarios;
        }

        private void lblBodega_MouseLeave(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorNormalUsuarios;
        }

        private void picBodega_MouseLeave(object sender, EventArgs e)
        {
            btnBodega.BackColor = colorNormalUsuarios;
        }

        private void pnlEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverUsuarios;
        }

        private void pnlEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalUsuarios;
        }

        private void lblEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverUsuarios;
        }

        private void lblEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalUsuarios;
        }

        private void picEnvio_MouseHover(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorHoverUsuarios;
        }

        private void picEnvio_MouseLeave(object sender, EventArgs e)
        {
            pnlEnvio.BackColor = colorNormalUsuarios;
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

        private void pnlTrans_MouseClick(object sender, MouseEventArgs e)
        {
            frmTransporte obj = new frmTransporte();
            obj.Visible = true;
            Visible = false;
        }

        private void pnlMovBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmMovimientoBodega movBo = new frmMovimientoBodega();
            movBo.Visible = true;

            Visible = false;
        }

        private void lblMovimientoBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmMovimientoBodega movBo = new frmMovimientoBodega();
            movBo.Visible = true;

            Visible = false;
        }

        private void picMovBodega_MouseClick(object sender, MouseEventArgs e)
        {
            frmMovimientoBodega movBo = new frmMovimientoBodega();
            movBo.Visible = true;

            Visible = false;
        }

        private void pnlMovBodega_MouseHover(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorHoverUsuarios;
        }

        private void lblMovimientoBodega_MouseHover(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorHoverUsuarios;
        }

        private void picMovBodega_MouseHover(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorHoverUsuarios;
        }

        private void pnlMovBodega_MouseLeave(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorNormalUsuarios;
        }

        private void lblMovimientoBodega_MouseLeave(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorNormalUsuarios;
        }

        private void picMovBodega_MouseLeave(object sender, EventArgs e)
        {
            pnlMovBodega.BackColor = colorNormalUsuarios;
        }

        private void btnCalificacionP_MouseClick(object sender, MouseEventArgs e)
        {
            frmCalificacionPiloto obj = new frmCalificacionPiloto();
            obj.Visible = true;

            Visible = false;
        }

        private void lblCalificacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmCalificacionPiloto obj = new frmCalificacionPiloto();
            obj.Visible = true;

            Visible = false;
        }

        private void picCalificacion_MouseClick(object sender, MouseEventArgs e)
        {
            frmCalificacionPiloto obj = new frmCalificacionPiloto();
            obj.Visible = true;

            Visible = false;
        }

        private void btnCalificacionP_MouseHover(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorHoverUsuarios;
        }

        private void lblCalificacion_MouseHover(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorHoverUsuarios;
        }

        private void picCalificacion_MouseHover(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorHoverUsuarios;
        }

        private void btnCalificacionP_MouseLeave(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorNormalUsuarios;
        }

        private void lblCalificacion_MouseLeave(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorNormalUsuarios;
        }

        private void picCalificacion_MouseLeave(object sender, EventArgs e)
        {
            btnCalificacionP.BackColor = colorNormalUsuarios;
        }

        private void btnPiloto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPiloto obj = new frmPiloto();

            obj.Visible = true;

            Visible = false;
        }

        private void lblPiloto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPiloto obj = new frmPiloto();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoPiloto_MouseClick(object sender, MouseEventArgs e)
        {
            frmPiloto obj = new frmPiloto();

            obj.Visible = true;

            Visible = false;
        }

        private void btnBitaTrans_MouseClick(object sender, MouseEventArgs e)
        {
            frmBitacoraTransporte obj = new frmBitacoraTransporte();

            obj.Visible = true;

            Visible = false;
        }

        private void lblBitaTrans_MouseClick(object sender, MouseEventArgs e)
        {
            frmBitacoraTransporte obj = new frmBitacoraTransporte();

            obj.Visible = true;

            Visible = false;
        }

        private void picIconoBitaTrans_MouseClick(object sender, MouseEventArgs e)
        {
            frmBitacoraTransporte obj = new frmBitacoraTransporte();

            obj.Visible = true;

            Visible = false;
        }

        private void btnPiloto_MouseHover(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorHoverUsuarios;
        }

        private void lblPiloto_MouseHover(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorHoverUsuarios;
        }

        private void picIconoPiloto_MouseHover(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorHoverUsuarios;
        }

        private void btnPiloto_MouseLeave(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorNormalUsuarios;
        }

        private void lblPiloto_MouseLeave(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorNormalUsuarios;
        }

        private void picIconoPiloto_MouseLeave(object sender, EventArgs e)
        {
            btnPiloto.BackColor = colorNormalUsuarios;
        }

        private void btnBitaTrans_MouseHover(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorHoverUsuarios;
        }

        private void lblBitaTrans_MouseHover(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorHoverUsuarios;
        }

        private void picIconoBitaTrans_MouseHover(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorHoverUsuarios;
        }

        private void btnBitaTrans_MouseLeave(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorNormalUsuarios;
        }

        private void lblBitaTrans_MouseLeave(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorNormalUsuarios;
        }

        private void picIconoBitaTrans_MouseLeave(object sender, EventArgs e)
        {
            btnBitaTrans.BackColor = colorNormalUsuarios;
        }

        private void pnlCerrar_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        /* Final de funcion para evitar el uso de recursivo de tantas variables */
    }
}
