
namespace Hatchat.Presentacion
{
    partial class RegisterAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterAlumno));
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.cbxPreguntas = new System.Windows.Forms.ComboBox();
            this.lblExplicacion = new System.Windows.Forms.Label();
            this.lblPreguntas = new System.Windows.Forms.Label();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblRellene = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRespuesta = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.Control;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 18F);
            this.btnSiguiente.Location = new System.Drawing.Point(832, 438);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(133, 46);
            this.btnSiguiente.TabIndex = 39;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // cbxPreguntas
            // 
            this.cbxPreguntas.Font = new System.Drawing.Font("Arial", 12.25F);
            this.cbxPreguntas.FormattingEnabled = true;
            this.cbxPreguntas.Location = new System.Drawing.Point(564, 212);
            this.cbxPreguntas.Name = "cbxPreguntas";
            this.cbxPreguntas.Size = new System.Drawing.Size(401, 26);
            this.cbxPreguntas.TabIndex = 37;
            // 
            // lblExplicacion
            // 
            this.lblExplicacion.AutoSize = true;
            this.lblExplicacion.Font = new System.Drawing.Font("Arial", 12F);
            this.lblExplicacion.Location = new System.Drawing.Point(561, 155);
            this.lblExplicacion.Name = "lblExplicacion";
            this.lblExplicacion.Size = new System.Drawing.Size(404, 54);
            this.lblExplicacion.TabIndex = 36;
            this.lblExplicacion.Text = "Rellene la casilla de texto con una respuesta que nunca \r\nolvide, para poder toma" +
    "r medidas en caso de perdida de\r\nla cuenta\r\n";
            // 
            // lblPreguntas
            // 
            this.lblPreguntas.AutoSize = true;
            this.lblPreguntas.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblPreguntas.Location = new System.Drawing.Point(561, 117);
            this.lblPreguntas.Name = "lblPreguntas";
            this.lblPreguntas.Size = new System.Drawing.Size(343, 22);
            this.lblPreguntas.TabIndex = 35;
            this.lblPreguntas.Text = "Elija una de las Preguntas de seguridad";
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblConfirmarPassword.Location = new System.Drawing.Point(60, 413);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(191, 22);
            this.lblConfirmarPassword.TabIndex = 34;
            this.lblConfirmarPassword.Text = "Confirmar contraseña";
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtConfirmarPassword.Location = new System.Drawing.Point(60, 438);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new System.Drawing.Size(389, 29);
            this.txtConfirmarPassword.TabIndex = 33;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblPassword.Location = new System.Drawing.Point(60, 355);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(107, 22);
            this.lblPassword.TabIndex = 32;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtPassword.Location = new System.Drawing.Point(60, 380);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(389, 29);
            this.txtPassword.TabIndex = 31;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblSegundoApellido.Location = new System.Drawing.Point(60, 293);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(158, 22);
            this.lblSegundoApellido.TabIndex = 30;
            this.lblSegundoApellido.Text = "Segundo apellido";
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtSegundoApellido.Location = new System.Drawing.Point(60, 315);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(389, 29);
            this.txtSegundoApellido.TabIndex = 29;
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblPrimerApellido.Location = new System.Drawing.Point(60, 235);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(137, 22);
            this.lblPrimerApellido.TabIndex = 28;
            this.lblPrimerApellido.Text = "Primer apellido";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtPrimerApellido.Location = new System.Drawing.Point(60, 257);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(389, 29);
            this.txtPrimerApellido.TabIndex = 27;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblNombre.Location = new System.Drawing.Point(60, 175);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 22);
            this.lblNombre.TabIndex = 26;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtNombre.Location = new System.Drawing.Point(60, 197);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(389, 29);
            this.txtNombre.TabIndex = 25;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblCedula.Location = new System.Drawing.Point(60, 117);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(75, 22);
            this.lblCedula.TabIndex = 24;
            this.lblCedula.Text = "Cedula:";
            // 
            // lblRellene
            // 
            this.lblRellene.AutoSize = true;
            this.lblRellene.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblRellene.Location = new System.Drawing.Point(60, 81);
            this.lblRellene.Name = "lblRellene";
            this.lblRellene.Size = new System.Drawing.Size(340, 22);
            this.lblRellene.TabIndex = 23;
            this.lblRellene.Text = "Rellene las casillas con su informacion:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 48F);
            this.lblTitulo.Location = new System.Drawing.Point(3, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(777, 72);
            this.lblTitulo.TabIndex = 22;
            this.lblTitulo.Text = "Crea tu cuenta de Alumno";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtCedula.Location = new System.Drawing.Point(60, 139);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(389, 29);
            this.txtCedula.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtRespuesta);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.txtCedula);
            this.panel1.Controls.Add(this.btnSiguiente);
            this.panel1.Controls.Add(this.lblRellene);
            this.panel1.Controls.Add(this.lblCedula);
            this.panel1.Controls.Add(this.cbxPreguntas);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblExplicacion);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblPreguntas);
            this.panel1.Controls.Add(this.txtPrimerApellido);
            this.panel1.Controls.Add(this.lblConfirmarPassword);
            this.panel1.Controls.Add(this.lblPrimerApellido);
            this.panel1.Controls.Add(this.txtConfirmarPassword);
            this.panel1.Controls.Add(this.txtSegundoApellido);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.lblSegundoApellido);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Location = new System.Drawing.Point(112, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 563);
            this.panel1.TabIndex = 41;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtRespuesta.Location = new System.Drawing.Point(565, 264);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(400, 96);
            this.txtRespuesta.TabIndex = 41;
            this.txtRespuesta.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel3.Location = new System.Drawing.Point(510, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 300);
            this.panel3.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pbxLogin);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 46);
            this.panel2.TabIndex = 42;
            this.panel2.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // pbxLogin
            // 
            this.pbxLogin.BackColor = System.Drawing.Color.White;
            this.pbxLogin.Location = new System.Drawing.Point(22, 0);
            this.pbxLogin.Name = "pbxLogin";
            this.pbxLogin.Size = new System.Drawing.Size(51, 46);
            this.pbxLogin.TabIndex = 2;
            this.pbxLogin.TabStop = false;
            this.pbxLogin.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1153, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // RegisterAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RegisterAlumno";
            this.Text = "RegisterAlumno";
            this.Load += new System.EventHandler(this.RegisterAlumno_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ComboBox cbxPreguntas;
        private System.Windows.Forms.Label lblExplicacion;
        private System.Windows.Forms.Label lblPreguntas;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblRellene;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbxLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox txtRespuesta;
        private System.Windows.Forms.Timer timerCentrar;
    }
}