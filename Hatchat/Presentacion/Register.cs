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
        public Form login;
        public Form registerDocente;
        public Form registerAlumno;
        public Register()
        {
            InitializeComponent();
            Text = "Register";
            
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            try
            {
                pbxAlumno.Image = Image.FromFile("boton alumno.png");
                pbxDocente.Image = Image.FromFile("boton docente.png");
                pbxLogin.Image = Image.FromFile("volver.png");
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }

            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLogin.SizeMode = PictureBoxSizeMode.StretchImage;

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
    }
}
