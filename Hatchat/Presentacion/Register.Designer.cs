
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
            this.pbxDocente = new System.Windows.Forms.PictureBox();
            this.pbxAlumno = new System.Windows.Forms.PictureBox();
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDocente
            // 
            this.pbxDocente.Location = new System.Drawing.Point(282, 152);
            this.pbxDocente.Name = "pbxDocente";
            this.pbxDocente.Size = new System.Drawing.Size(761, 136);
            this.pbxDocente.TabIndex = 0;
            this.pbxDocente.TabStop = false;
            this.pbxDocente.Click += new System.EventHandler(this.pbxDocente_Click);
            // 
            // pbxAlumno
            // 
            this.pbxAlumno.Location = new System.Drawing.Point(283, 294);
            this.pbxAlumno.Name = "pbxAlumno";
            this.pbxAlumno.Size = new System.Drawing.Size(760, 136);
            this.pbxAlumno.TabIndex = 1;
            this.pbxAlumno.TabStop = false;
            this.pbxAlumno.Click += new System.EventHandler(this.pbxAlumno_Click);
            // 
            // pbxLogin
            // 
            this.pbxLogin.Location = new System.Drawing.Point(12, 12);
            this.pbxLogin.Name = "pbxLogin";
            this.pbxLogin.Size = new System.Drawing.Size(100, 100);
            this.pbxLogin.TabIndex = 2;
            this.pbxLogin.TabStop = false;
            this.pbxLogin.Click += new System.EventHandler(this.pbxLogin_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pbxLogin);
            this.Controls.Add(this.pbxAlumno);
            this.Controls.Add(this.pbxDocente);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDocente;
        private System.Windows.Forms.PictureBox pbxAlumno;
        private System.Windows.Forms.PictureBox pbxLogin;
    }
}