
namespace Hatchat.Presentacion
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.pbxDocente = new System.Windows.Forms.PictureBox();
            this.pbxAlumno = new System.Windows.Forms.PictureBox();
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxDocente
            // 
            this.pbxDocente.Location = new System.Drawing.Point(163, 125);
            this.pbxDocente.Name = "pbxDocente";
            this.pbxDocente.Size = new System.Drawing.Size(691, 141);
            this.pbxDocente.TabIndex = 0;
            this.pbxDocente.TabStop = false;
            this.pbxDocente.Click += new System.EventHandler(this.pbxDocente_Click);
            // 
            // pbxAlumno
            // 
            this.pbxAlumno.Location = new System.Drawing.Point(163, 281);
            this.pbxAlumno.Name = "pbxAlumno";
            this.pbxAlumno.Size = new System.Drawing.Size(691, 141);
            this.pbxAlumno.TabIndex = 1;
            this.pbxAlumno.TabStop = false;
            this.pbxAlumno.Click += new System.EventHandler(this.pbxAlumno_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.pbxDocente);
            this.panel1.Controls.Add(this.pbxAlumno);
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
            this.lblTitulo.Size = new System.Drawing.Size(571, 61);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Elija su tipo de cuenta:";
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
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDocente;
        private System.Windows.Forms.PictureBox pbxAlumno;
        private System.Windows.Forms.PictureBox pbxLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}