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
        
        string usuariont;
        string enviado;
        string noIguales;
        string respuestant;
        string error;

        public Form login;
        
        public CambiarContra()
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
                lblCedula.Text = "Ingrese su cedula:";
                lblPregSegur.Text = "Pregunta de Seguridad:";
                cmbxPreguntaSeg.Items.Add("¿Cuál es el nombre de tu primer mascota?");
                cmbxPreguntaSeg.Items.Add("¿En qué calle está ubicado tu primer hogar?");
                cmbxPreguntaSeg.Items.Add("¿Cual es tu sabor de helado favorito?");
                lblRespuesta.Text = "Respuesta:";
                lblPassword.Text = "Nueva Contraseña:";
                lblConfirmarPassword.Text = "Confirmar Contraseña:";
                btnEnviar.Text = "Enviar solicitud";
                usuariont = "No se ha encontrado el usuario";
                enviado = "Se ha enviado la solicitud correctamente";
                noIguales = "Las contraseñas no coinciden";
                respuestant = "La respuesta no es correcta";
                error = " comuníquese con el administrador.";
            }
            else
            {
                lblTitulo.Text = "Contact an administrator:";
                lblCedula.Text = "Enter your ID:";
                lblPregSegur.Text = "Security Question:";
                cmbxPreguntaSeg.Items.Add("What is the name of your first pet?");
                cmbxPreguntaSeg.Items.Add("On what street is your first home located?");
                cmbxPreguntaSeg.Items.Add("What is your favorite ice cream flavor?");
                lblRespuesta.Text = "Answer:";
                lblPassword.Text = "New Password:";
                lblConfirmarPassword.Text = "Confirm Password:";
                btnEnviar.Text = "Send request";
                usuariont = "User not found";
                enviado = "The request has been sent successfully";
                noIguales = "Passwords do not match";
                respuestant = "The answer is not correct";
                error = " Contact the administrator.";
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
            us = new Logica.Usuario().SelectUsuarioCi(txtCedula.Text);

            if (us.Ci != null)
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
                        MessageBox.Show(enviado);

                        txtCedula.Text = "";
                        cmbxPreguntaSeg.SelectedIndex = -1;
                        txtRepuesta.Text = "";
                        txtPassword.Text = "";
                        txtConfirmarPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(noIguales);
                    }
                }
                else
                {
                    MessageBox.Show(respuestant);
                }
            }
            else
            {
                MessageBox.Show(usuariont);

            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length == 8 && new Logica.Usuario().VerficarCedula(txtCedula.Text))
            {
                us = new Logica.Usuario().SelectUsuarioCi(txtCedula.Text);

                if (us.Ci != null)
                {
                    cmbxPreguntaSeg.SelectedIndex = (us.Preguta_seguridad - 1);
                }
                else
                {
                    MessageBox.Show(usuariont);
                }
            }
            else
            {
                cmbxPreguntaSeg.SelectedIndex = -1;
            }
            
        }
    }
}

