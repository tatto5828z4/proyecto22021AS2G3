
namespace sistema_reparto
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDes = new System.Windows.Forms.Panel();
            this.lblNoUsuarios = new System.Windows.Forms.Label();
            this.pnlOk = new System.Windows.Forms.Panel();
            this.pnlDes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlLogo.Location = new System.Drawing.Point(405, 81);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(80, 79);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblIdUsuario.ForeColor = System.Drawing.Color.White;
            this.lblIdUsuario.Location = new System.Drawing.Point(357, 220);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(57, 13);
            this.lblIdUsuario.TabIndex = 1;
            this.lblIdUsuario.Text = "ID Usuario";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(92)))), ((int)(((byte)(95)))));
            this.txtID.Location = new System.Drawing.Point(360, 242);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 0, 0, 15);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(169, 18);
            this.txtID.TabIndex = 2;
            this.txtID.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(357, 284);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Contraseña";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(92)))), ((int)(((byte)(95)))));
            this.txtPass.Location = new System.Drawing.Point(360, 301);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 0, 0, 15);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(169, 18);
            this.txtPass.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Location = new System.Drawing.Point(334, 394);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(221, 37);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLogin_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(879, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 20);
            this.panel1.TabIndex = 6;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // pnlDes
            // 
            this.pnlDes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlDes.Controls.Add(this.pnlOk);
            this.pnlDes.Controls.Add(this.lblNoUsuarios);
            this.pnlDes.Location = new System.Drawing.Point(286, 192);
            this.pnlDes.Name = "pnlDes";
            this.pnlDes.Size = new System.Drawing.Size(311, 142);
            this.pnlDes.TabIndex = 7;
            // 
            // lblNoUsuarios
            // 
            this.lblNoUsuarios.AutoSize = true;
            this.lblNoUsuarios.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNoUsuarios.Location = new System.Drawing.Point(7, 14);
            this.lblNoUsuarios.Name = "lblNoUsuarios";
            this.lblNoUsuarios.Size = new System.Drawing.Size(287, 40);
            this.lblNoUsuarios.TabIndex = 0;
            this.lblNoUsuarios.Text = "No se detectaron usuarios, por favor \r\ncree un Usuario Aministrador!\r\n";
            // 
            // pnlOk
            // 
            this.pnlOk.BackColor = System.Drawing.Color.Transparent;
            this.pnlOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOk.BackgroundImage")));
            this.pnlOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOk.Location = new System.Drawing.Point(119, 92);
            this.pnlOk.Name = "pnlOk";
            this.pnlOk.Size = new System.Drawing.Size(77, 26);
            this.pnlOk.TabIndex = 1;
            this.pnlOk.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlOk_MouseClick);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(907, 523);
            this.Controls.Add(this.pnlDes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.pnlLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.pnlDes.ResumeLayout(false);
            this.pnlDes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Panel btnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDes;
        private System.Windows.Forms.Panel pnlOk;
        private System.Windows.Forms.Label lblNoUsuarios;
    }
}