using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class CambiarContra : Form
    {
        Logica.Usuario us = new Logica.Usuario();

        public Form login;
        
        public CambiarContra()
        {
            InitializeComponent();
            Text = "Register";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            try
            {
                pbxLogin.Image = Image.FromFile("volver.png");
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }
            cmbxPreguntaSeg.DropDownStyle = ComboBoxStyle.DropDownList;
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



        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (us.Respuesta_seguridad == txtRepuesta.Text)
            {
                if (txtPassword.Text == txtConfirmarPassword.Text) 
                {
                    Logica.SolicitudModif soli = new Logica.SolicitudModif();
                    soli.FechaHora = DateTime.Now;
                    soli.ContraNueva = txtPassword.Text;
                    soli.Pendiente = true;
                    soli.Usuario = txtCedula.Text;
                    soli.EnviarSolicitudModif();
                    MessageBox.Show("Se ha enviado la solicitud correctamente");

                    txtCedula.Text = "";
                    cmbxPreguntaSeg.Items.Clear();
                    txtRepuesta.Text = "";
                    txtPassword.Text = "";
                    txtConfirmarPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
            else
            {
                MessageBox.Show("La respuesta no es correcta");
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length == 8)
            {
                us = new Logica.Usuario().SelectUsuarioCi(txtCedula.Text);
                List<Logica.PreguntaSeg> prgs = new Logica.PreguntaSeg().SelectPreguntasSeguridad();
                cmbxPreguntaSeg.Items.Clear();
                cmbxPreguntaSeg.Items.Add(prgs[us.Preguta_seguridad].Pregunta);
            }
        }
    }
}
