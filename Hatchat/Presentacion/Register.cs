using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class Register : Form
    {
        string error;

        public Form login;
        public Form registerDocente;
        public Form registerAlumno;
        public Register()
        {
            InitializeComponent();
            Text = "Register";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            

            if (Login.idioma == "Español")
            {
                lblTitulo.Text = "Contacte con un administrador:";
                error = " comuníquese con el administrador.";
                try
                {
                    pbxAlumno.Image = Image.FromFile("boton alumno.png");
                    pbxDocente.Image = Image.FromFile("boton docente.png");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message + error, "Error");
                }

            }
            else
            {
                lblTitulo.Text = "Choose your account type:";
                error = " Contact the administrator.";
                try
                {
                    pbxAlumno.Image = Image.FromFile("boton Student account.png");
                    pbxDocente.Image = Image.FromFile("boton teaching account.png");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message + error, "Error");
                }
            }

            try
            {
                pbxLogin.Image = Image.FromFile("volver.png");
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");
            }
            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLogin.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxLogin_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Dispose();
        }

        private void pbxDocente_Click(object sender, EventArgs e)
        {
            registerDocente.Show();
            this.Hide();
        }

        private void pbxAlumno_Click(object sender, EventArgs e)
        {
            registerAlumno.Show();
            this.Hide();
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
