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
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
        Logica.Mensaje mensajeSeleccionado = new Logica.Mensaje();
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
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
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
                Login.encontrado = new Logica.Usuario();
                login.Show();
                this.Dispose();
            }
        }
        private void CargarMensajes()
        {

            y = 50;
            panelNavMensajes.Controls.Clear();
            panelContenedor.Visible = false;
            mensajes = new Logica.Mensaje().SelectCargarMensajesDo(Login.encontrado.Ci);
            foreach (Logica.Mensaje men in mensajes)
            {
                Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                Logica.Alumno alumno = new Logica.Alumno();

                alumno.Ci = usuario.Ci;
                alumno.Apodo = usuario.Apodo;
                alumno.Nombre = usuario.Nombre;
                alumno.Primer_apellido = usuario.Primer_apellido;
                alumno.Segundo_apellido = usuario.Segundo_apellido;
                if (!(usuario.FotoDePerfil == null))
                {
                    alumno.FotoDePerfil = usuario.FotoDePerfil;
                }
                alumno.Activo = usuario.Activo;
                Label dina = new Label();
                dina.Height = 46;
                dina.Width = 150;
                dina.Location = new Point(50, y);
                y += 50;
                dina.Name = "lblM" + men.IdMensaje.ToString();
                dina.Text = alumno.Nombre + " " + alumno.Primer_apellido + "\n" + men.Asunto;

                dina.Click += new EventHandler(AbrirMensaje);
                panelNavMensajes.Controls.Add(dina);

            }
        }
        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            mensajeSeleccionado = new Logica.Mensaje();
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

            mensajeSeleccionado = mensajeSeleccionado.SelectAbrirMensaje(((Label)sender).Name);
            Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(mensajeSeleccionado.Docente);
            Logica.Alumno alumno = new Logica.Alumno();

            alumno.Ci = usuario.Ci;
            alumno.Apodo = usuario.Apodo;
            alumno.Nombre = usuario.Nombre;
            alumno.Primer_apellido = usuario.Primer_apellido;
            alumno.Segundo_apellido = usuario.Segundo_apellido;
            if (!(usuario.FotoDePerfil == null))
            {
                alumno.FotoDePerfil = usuario.FotoDePerfil;
            }
            alumno.Activo = usuario.Activo;

            panelContenedor.Visible = true;
            lblNombreDocente.Text += ("\n" + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido);
            lblFechaAlumno.Text += "\n" + mensajeSeleccionado.FechaHoraAlumno.ToString("dd:MM:yyyy");
            lblHoraAlumno.Text += "\n" + mensajeSeleccionado.FechaHoraAlumno.ToString("HH:mm");
            lblConsultaAlumno.Text += "\n" + mensajeSeleccionado.Asunto;
            lblConsultaDocente.Text += "\n" + mensajeSeleccionado.Asunto;
            lblNombreAlumno.Text += "\n" + alumno.Nombre + " " + alumno.Primer_apellido;
            rtbxMensajeRecibido.Text = mensajeSeleccionado.MensajeAlumno;
            pbxAlumno.Image = alumno.ByteArrayToImage(alumno.FotoDePerfil);
            pbxDocente.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            if (!(mensajeSeleccionado.Estado == "realizado"))
            {
                lblFechaDocente.Text += "\n" + mensajeSeleccionado.FechaHoraDocente.ToString("dd:MM:yyyy");
                lblHoraDocente.Text += "\n" + mensajeSeleccionado.FechaHoraDocente.ToString("HH:mm");
            }
            rtbxRespuesta.Text = mensajeSeleccionado.MensajeDocente;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {


            if (mensajeSeleccionado.Estado != "realizado")
            {
                MessageBox.Show("este mensaje ya ha sido respondido");
            }
            else
            {
                mensajeSeleccionado.FechaHoraDocente = DateTime.Now;
                mensajeSeleccionado.MensajeDocente = rtbxRespuesta.Text;
                mensajeSeleccionado.Estado = "contestado";
                mensajeSeleccionado.EnviarMensajeDocente();
                MessageBox.Show("Se ha enviado el mensaje correctamente");
                mensajeSeleccionado = new Logica.Mensaje();
                CargarMensajes();
            }

        }
    }
}
