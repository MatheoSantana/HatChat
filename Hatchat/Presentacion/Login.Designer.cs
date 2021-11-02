
namespace Hatchat.Presentacion
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbxIdioma = new System.Windows.Forms.ComboBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblCambioPassword = new System.Windows.Forms.Label();
            this.lblRegistrarse = new System.Windows.Forms.Label();
            this.lblTextoSinCuenta = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExplicacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbxIdioma = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIdioma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 40F);
            this.lblTitulo.Location = new System.Drawing.Point(162, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 61);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio de sesión";
            // 
            // cmbxIdioma
            // 
            this.cmbxIdioma.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxIdioma.FormattingEnabled = true;
            this.cmbxIdioma.Location = new System.Drawing.Point(1078, 12);
            this.cmbxIdioma.Name = "cmbxIdioma";
            this.cmbxIdioma.Size = new System.Drawing.Size(167, 28);
            this.cmbxIdioma.TabIndex = 2;
            this.cmbxIdioma.SelectedIndexChanged += new System.EventHandler(this.cbxIdioma_SelectedIndexChanged);
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Arial Black", 12F);
            this.txtCedula.Location = new System.Drawing.Point(29, 192);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(632, 30);
            this.txtCedula.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial Black", 12F);
            this.txtPassword.Location = new System.Drawing.Point(29, 250);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(632, 30);
            this.txtPassword.TabIndex = 4;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(25, 169);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(130, 20);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "Cedula de identidad";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(25, 227);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblCambioPassword
            // 
            this.lblCambioPassword.AutoSize = true;
            this.lblCambioPassword.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblCambioPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(106)))), ((int)(((byte)(58)))));
            this.lblCambioPassword.Location = new System.Drawing.Point(287, 341);
            this.lblCambioPassword.Name = "lblCambioPassword";
            this.lblCambioPassword.Size = new System.Drawing.Size(180, 16);
            this.lblCambioPassword.TabIndex = 7;
            this.lblCambioPassword.Text = "No recuerdo mi contraseña";
            // 
            // lblRegistrarse
            // 
            this.lblRegistrarse.AutoSize = true;
            this.lblRegistrarse.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(106)))), ((int)(((byte)(58)))));
            this.lblRegistrarse.Location = new System.Drawing.Point(169, 341);
            this.lblRegistrarse.Name = "lblRegistrarse";
            this.lblRegistrarse.Size = new System.Drawing.Size(79, 16);
            this.lblRegistrarse.TabIndex = 8;
            this.lblRegistrarse.Text = "Registrarse";
            this.lblRegistrarse.Click += new System.EventHandler(this.lblRegistrarse_Click);
            // 
            // lblTextoSinCuenta
            // 
            this.lblTextoSinCuenta.AutoSize = true;
            this.lblTextoSinCuenta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoSinCuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(106)))), ((int)(((byte)(58)))));
            this.lblTextoSinCuenta.Location = new System.Drawing.Point(14, 341);
            this.lblTextoSinCuenta.Name = "lblTextoSinCuenta";
            this.lblTextoSinCuenta.Size = new System.Drawing.Size(158, 16);
            this.lblTextoSinCuenta.TabIndex = 9;
            this.lblTextoSinCuenta.Text = "¿No tienes una cuenta?";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(496, 326);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(168, 40);
            this.btnIniciarSesion.TabIndex = 10;
            this.btnIniciarSesion.Text = "Iniciar sesion";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblExplicacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnIniciarSesion);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.lblTextoSinCuenta);
            this.panel1.Controls.Add(this.lblCedula);
            this.panel1.Controls.Add(this.lblRegistrarse);
            this.panel1.Controls.Add(this.txtCedula);
            this.panel1.Controls.Add(this.lblCambioPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Location = new System.Drawing.Point(298, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 422);
            this.panel1.TabIndex = 11;
            // 
            // lblExplicacion
            // 
            this.lblExplicacion.AutoSize = true;
            this.lblExplicacion.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblExplicacion.Location = new System.Drawing.Point(169, 98);
            this.lblExplicacion.Name = "lblExplicacion";
            this.lblExplicacion.Size = new System.Drawing.Size(374, 19);
            this.lblExplicacion.TabIndex = 11;
            this.lblExplicacion.Text = "Introduzca su nombre de usuario y contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(25, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "______________________________________________________________________";
            // 
            // pcbxIdioma
            // 
            this.pcbxIdioma.Location = new System.Drawing.Point(1024, 12);
            this.pcbxIdioma.Name = "pcbxIdioma";
            this.pcbxIdioma.Size = new System.Drawing.Size(48, 27);
            this.pcbxIdioma.TabIndex = 1;
            this.pcbxIdioma.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(546, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.cmbxIdioma);
            this.Controls.Add(this.pcbxIdioma);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIdioma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pcbxIdioma;
        private System.Windows.Forms.ComboBox cmbxIdioma;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCambioPassword;
        private System.Windows.Forms.Label lblRegistrarse;
        private System.Windows.Forms.Label lblTextoSinCuenta;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExplicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerCentrar;
    }
}