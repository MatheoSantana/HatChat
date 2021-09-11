
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pcbxIdioma = new System.Windows.Forms.PictureBox();
            this.cmbxIdioma = new System.Windows.Forms.ComboBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblCambioPassword = new System.Windows.Forms.Label();
            this.lblRegistrarse = new System.Windows.Forms.Label();
            this.lblTextoSinCuenta = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIdioma)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(441, 120);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(382, 56);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio de sesion";
            // 
            // pcbxIdioma
            // 
            this.pcbxIdioma.Location = new System.Drawing.Point(1024, 12);
            this.pcbxIdioma.Name = "pcbxIdioma";
            this.pcbxIdioma.Size = new System.Drawing.Size(48, 27);
            this.pcbxIdioma.TabIndex = 1;
            this.pcbxIdioma.TabStop = false;
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
            this.txtCedula.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(451, 318);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(372, 26);
            this.txtCedula.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(451, 350);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(372, 26);
            this.txtPassword.TabIndex = 4;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(315, 321);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(130, 20);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "Cedula de identidad";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(315, 356);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblCambioPassword
            // 
            this.lblCambioPassword.AutoSize = true;
            this.lblCambioPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioPassword.ForeColor = System.Drawing.Color.Blue;
            this.lblCambioPassword.Location = new System.Drawing.Point(447, 388);
            this.lblCambioPassword.Name = "lblCambioPassword";
            this.lblCambioPassword.Size = new System.Drawing.Size(171, 20);
            this.lblCambioPassword.TabIndex = 7;
            this.lblCambioPassword.Text = "No recuerdo mi contraseña";
            // 
            // lblRegistrarse
            // 
            this.lblRegistrarse.AutoSize = true;
            this.lblRegistrarse.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarse.ForeColor = System.Drawing.Color.Blue;
            this.lblRegistrarse.Location = new System.Drawing.Point(447, 444);
            this.lblRegistrarse.Name = "lblRegistrarse";
            this.lblRegistrarse.Size = new System.Drawing.Size(77, 20);
            this.lblRegistrarse.TabIndex = 8;
            this.lblRegistrarse.Text = "Registrarse";
            this.lblRegistrarse.Click += new System.EventHandler(this.lblRegistrarse_Click);
            // 
            // lblTextoSinCuenta
            // 
            this.lblTextoSinCuenta.AutoSize = true;
            this.lblTextoSinCuenta.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoSinCuenta.Location = new System.Drawing.Point(447, 424);
            this.lblTextoSinCuenta.Name = "lblTextoSinCuenta";
            this.lblTextoSinCuenta.Size = new System.Drawing.Size(130, 20);
            this.lblTextoSinCuenta.TabIndex = 9;
            this.lblTextoSinCuenta.Text = "Cedula de identidad";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.Location = new System.Drawing.Point(633, 385);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(190, 79);
            this.btnIniciarSesion.TabIndex = 10;
            this.btnIniciarSesion.Text = "Iniciar sesion";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblTextoSinCuenta);
            this.Controls.Add(this.lblRegistrarse);
            this.Controls.Add(this.lblCambioPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.cmbxIdioma);
            this.Controls.Add(this.pcbxIdioma);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIdioma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}