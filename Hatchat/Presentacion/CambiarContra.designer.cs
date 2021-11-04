
namespace Hatchat.Presentacion
{
    partial class CambiarContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbxPreguntaSeg = new System.Windows.Forms.ComboBox();
            this.lblPregSegur = new System.Windows.Forms.Label();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.txtRepuesta = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Controls.Add(this.cmbxPreguntaSeg);
            this.panel1.Controls.Add(this.lblPregSegur);
            this.panel1.Controls.Add(this.lblConfirmarPassword);
            this.panel1.Controls.Add(this.txtConfirmarPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblRespuesta);
            this.panel1.Controls.Add(this.txtRepuesta);
            this.panel1.Controls.Add(this.lblCedula);
            this.panel1.Controls.Add(this.txtCedula);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(111, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 557);
            this.panel1.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 40F);
            this.lblTitulo.Location = new System.Drawing.Point(15, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(774, 61);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Contacte con un administrador:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pbxLogin);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 46);
            this.panel2.TabIndex = 18;
            this.panel2.Click += new System.EventHandler(this.pbxLogin_Click);
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // pbxLogin
            // 
            this.pbxLogin.BackColor = System.Drawing.Color.White;
            this.pbxLogin.Location = new System.Drawing.Point(22, 0);
            this.pbxLogin.Name = "pbxLogin";
            this.pbxLogin.Size = new System.Drawing.Size(51, 46);
            this.pbxLogin.TabIndex = 2;
            this.pbxLogin.TabStop = false;
            this.pbxLogin.Click += new System.EventHandler(this.pbxLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1153, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // cmbxPreguntaSeg
            // 
            this.cmbxPreguntaSeg.Enabled = false;
            this.cmbxPreguntaSeg.Font = new System.Drawing.Font("Arial", 14.25F);
            this.cmbxPreguntaSeg.FormattingEnabled = true;
            this.cmbxPreguntaSeg.Location = new System.Drawing.Point(152, 202);
            this.cmbxPreguntaSeg.Name = "cmbxPreguntaSeg";
            this.cmbxPreguntaSeg.Size = new System.Drawing.Size(568, 30);
            this.cmbxPreguntaSeg.TabIndex = 25;
            // 
            // lblPregSegur
            // 
            this.lblPregSegur.AutoSize = true;
            this.lblPregSegur.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblPregSegur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPregSegur.Location = new System.Drawing.Point(152, 170);
            this.lblPregSegur.Name = "lblPregSegur";
            this.lblPregSegur.Size = new System.Drawing.Size(205, 22);
            this.lblPregSegur.TabIndex = 24;
            this.lblPregSegur.Text = "Pregunta de Seguridad";
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfirmarPassword.Location = new System.Drawing.Point(152, 375);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(195, 22);
            this.lblConfirmarPassword.TabIndex = 23;
            this.lblConfirmarPassword.Text = "Confirmar Contraseña";
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarPassword.Location = new System.Drawing.Point(155, 406);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new System.Drawing.Size(565, 29);
            this.txtConfirmarPassword.TabIndex = 22;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPassword.Location = new System.Drawing.Point(152, 315);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(165, 22);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Nueva Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(155, 339);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(565, 29);
            this.txtPassword.TabIndex = 20;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRespuesta.Location = new System.Drawing.Point(152, 248);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(102, 22);
            this.lblRespuesta.TabIndex = 19;
            this.lblRespuesta.Text = "Respuesta";
            // 
            // txtRepuesta
            // 
            this.txtRepuesta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepuesta.Location = new System.Drawing.Point(155, 275);
            this.txtRepuesta.Name = "txtRepuesta";
            this.txtRepuesta.Size = new System.Drawing.Size(565, 29);
            this.txtRepuesta.TabIndex = 18;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCedula.Location = new System.Drawing.Point(152, 110);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(164, 22);
            this.lblCedula.TabIndex = 17;
            this.lblCedula.Text = "ingrese su cedula:";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(155, 138);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(565, 29);
            this.txtCedula.TabIndex = 16;
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviar.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(795, 473);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(168, 40);
            this.btnEnviar.TabIndex = 26;
            this.btnEnviar.Text = "Enviar Solicitud";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // CambiarContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CambiarContra";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timerCentrar;
        private System.Windows.Forms.ComboBox cmbxPreguntaSeg;
        private System.Windows.Forms.Label lblPregSegur;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.TextBox txtRepuesta;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Button btnEnviar;
    }
}