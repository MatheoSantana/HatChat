using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class MensajesDocente : Form
    {
        public Form login;
        public Form perfilDocente;
        public Form principalChatDocente;
        int y = 50;
        public MensajesDocente()
        {

            InitializeComponent();

            Text = "Mensajes";

            
            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;

            try
            {
                Icon = new Icon(Application.StartupPath + "logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.FotoDePerfil;
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje blanco.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }

            pbxFotoPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMensajeNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxGruposNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHistorialNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;

            CargarMensajes();
        }

        private void MensajesDocente_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxChatNav_Click(object sender, EventArgs e)
        {
            principalChatDocente.Show();
            this.Hide();
        }

        private void pbxPerfilNav_Click(object sender, EventArgs e)
        {
            perfilDocente.Show();
            this.Hide();
        }

        private void pbxCerrarSesionNav_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Login.encontrado = null;
                login.Show();
                this.Dispose();
            }
        }
        private void CargarMensajes()
        {

            y = 50;
            panelNavMensajes.Controls.Clear();
            panelContenedor.Visible = false;
            foreach (Logica.Mensaje men in Login.mensajes)
            {
                if (men.Docente == Login.encontrado)
                {

                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(50, y);
                    y += 50;
                    dina.Name = "lbl" + men.FechaHoraAlumno.ToString();
                    dina.Text = men.Alumno.Nombre + " " + men.Alumno.Primer_apellido + "\n" + men.Asunto;

                    dina.Click += new EventHandler(AbrirMensaje);
                    panelNavMensajes.Controls.Add(dina);


                }
            }
        }
        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            lblNombreDocente.Text = "Docente:";
            lblFechaAlumno.Text = "Fecha:";
            lblHoraAlumno.Text = "Hora:";
            lblConsultaAlumno.Text = "Consulta:";
            lblConsultaDocente.Text = "Consulta:";
            lblNombreAlumno.Text = "Alumno:";
            rtbxMensajeRecibido.Text = "";

            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";
            rtbxRespuesta.Text = "";
            foreach (Logica.Mensaje men in Login.mensajes)
            {
                if (men.Docente == Login.encontrado && ("lbl" + men.FechaHoraAlumno.ToString()) == ((Label)sender).Name && ((Label)sender).Text == men.Alumno.Nombre + " " + men.Alumno.Primer_apellido + "\n" + men.Asunto)
                {
                    panelContenedor.Visible = true;
                    lblNombreDocente.Text += ("\n" + men.Docente.Nombre + " " + men.Docente.Primer_apellido);
                    lblFechaAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("dd:MM:yyyy");
                    lblHoraAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("HH:mm");
                    lblConsultaAlumno.Text += "\n" + men.Asunto;
                    lblConsultaDocente.Text += "\n" + men.Asunto;
                    lblNombreAlumno.Text += "\n" + men.Alumno.Nombre + " " + men.Alumno.Primer_apellido;
                    rtbxMensajeRecibido.Text = men.MensajeAlumno;
                    pbxAlumno.Image = men.Alumno.FotoDePerfil;
                    pbxDocente.Image = men.Docente.FotoDePerfil;
                    foreach (Logica.Contesta cont in Login.contestan)
                    {
                        if (men.Docente == cont.Docente && cont.Alumno == men.Alumno && cont.FechaHoraAlumno == men.FechaHoraAlumno)
                        {
                            lblFechaDocente.Text += "\n" + cont.FechaHoraDocente.ToString("dd:MM:yyyy");
                            lblHoraDocente.Text += "\n" + cont.FechaHoraDocente.ToString("HH:mm");
                            rtbxRespuesta.Text = cont.MensajeDocente;
                            rtbxRespuesta.Enabled = false;
                            btnEnviar.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            foreach (Logica.Mensaje men in Login.mensajes)
            {
                if (men.Docente == Login.encontrado && ("Hora:\n" + men.FechaHoraAlumno.ToString("HH:mm")) == lblHoraAlumno.Text && "Fecha:\n" + men.FechaHoraAlumno.ToString("dd:MM:yyyy") == lblFechaAlumno.Text && lblNombreAlumno.Text == "Alumno:\n" + men.Alumno.Nombre + " " + men.Alumno.Primer_apellido && men.Estado == "Realizado")
                {
                    
                                    Login.contestan.Add(new Logica.Contesta(men.Alumno, ((Logica.Docente)Login.encontrado), men.FechaHoraAlumno, rtbxRespuesta.Text, DateTime.Now));
                                    men.Estado = "Contestado";
                                    MessageBox.Show("Se ha enviado el mensaje correctamente");

                                    CargarMensajes();
                                
                }else if (men.Estado != "Realizado")
                {
                    MessageBox.Show("este mensaje ya ha sido respondido");
                }
            }
        }
    }
}
