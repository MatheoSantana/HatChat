using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class MensajesAlumno : Form
    {
        private List<Logica.Docente> docentes = new List<Logica.Docente>();
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
        public Form login;
        public Form perfilAlumno;
        public Form principalChatAlumno;
        int y = 50;
        
        public MensajesAlumno()
        {
            InitializeComponent();
            Text = "Mensajes";


            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;
            panelEnviarMensaje.Visible = false;
            //nav
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
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


            cbxDestinatario.DropDownStyle = ComboBoxStyle.DropDownList;
            
            

            CargarMensajes();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.Mensaje men = new Logica.Mensaje(Login.encontrado.Ci, txtAsunto.Text, DateTime.Now, rtbxMensajeAEnviar.Text, docentes[cbxDestinatario.SelectedIndex].Ci, "realizado");
                men.EnviarMensajeAlumno();
                MessageBox.Show("Se ha enviado el mensaje correctamente");
                txtAsunto.Text = "";
                rtbxMensajeAEnviar.Text = "";
                cbxDestinatario.Items.Clear();
                docentes.Clear();
                CargarMensajes();
                panelEnviarMensaje.Visible = false;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Debe ingresar un destinatario");
            }
        }

        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelEnviarMensaje.Visible = false;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            lblNombreDocente.Text = "Docente:";
            lblFechaAlumno.Text = "Fecha:";
            lblHoraAlumno.Text = "Hora:";
            lblConsultaAlumno.Text = "Consulta:";
            lblConsultaDocente.Text = "Consulta:";
            lblNombreAlumno.Text = "Alumno:";
            rtbxMensajeEnviado.Text = "";

            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";
            rtbxRespuestaDocecnte.Text = "";

            Logica.Mensaje men = new Logica.Mensaje();
            men = men.SelectAbrirMensaje(((Label)sender).Name);
            Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
            Logica.Docente docente = new Logica.Docente();

            docente.Ci = usuario.Ci;
            docente.Apodo = usuario.Apodo;
            docente.Nombre = usuario.Nombre;
            docente.Primer_apellido = usuario.Primer_apellido;
            docente.Segundo_apellido = usuario.Segundo_apellido;
            if (!(usuario.FotoDePerfil == null))
            {
                docente.FotoDePerfil = usuario.FotoDePerfil;
            }
            docente.Activo = usuario.Activo;

            panelContenedor.Visible = true;
            lblNombreDocente.Text += ("\n" + docente.Nombre + " " + docente.Primer_apellido);
            lblFechaAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("dd:MM:yyyy");
            lblHoraAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("HH:mm");
            lblConsultaAlumno.Text += "\n" + men.Asunto;
            lblConsultaDocente.Text += "\n" + men.Asunto;
            lblNombreAlumno.Text += "\n" + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido;
            rtbxMensajeEnviado.Text = men.MensajeAlumno;
            pbxAlumno.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            pbxDocente.Image = docente.ByteArrayToImage(docente.FotoDePerfil);
            if (!(men.Estado == "realizado"))
            {
                lblFechaDocente.Text += "\n" + men.FechaHoraDocente.ToString("dd:MM:yyyy");
                lblHoraDocente.Text += "\n" + men.FechaHoraDocente.ToString("HH:mm");
            }
            rtbxRespuestaDocecnte.Text = men.MensajeDocente;

        }
        private void MensajesAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);

        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxChatNav_Click(object sender, EventArgs e)
        {
            principalChatAlumno.Show();
            this.Hide();
        }

        private void pbxPerfilNav_Click(object sender, EventArgs e)
        {
            perfilAlumno.Show();
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
            panelEnviarMensaje.Visible = false;
            panelContenedor.Visible = false;
            mensajes = mensajes = new Logica.Mensaje().SelectCargarMensajesAl(Login.encontrado.Ci);
            foreach (Logica.Mensaje men in mensajes)
            {
                
                Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                Logica.Docente docente = new Logica.Docente();

                docente.Ci = usuario.Ci;
                docente.Apodo = usuario.Apodo;
                docente.Nombre = usuario.Nombre;
                docente.Primer_apellido = usuario.Primer_apellido;
                docente.Segundo_apellido = usuario.Segundo_apellido;
                if (!(usuario.FotoDePerfil == null))
                {
                    docente.FotoDePerfil = usuario.FotoDePerfil;
                }
                docente.Activo = usuario.Activo;

                Label dina = new Label();
                dina.Height = 46;
                dina.Width = 150;
                dina.Location = new Point(50, y);
                y += 50;
                dina.Name = "lblM" + men.IdMensaje.ToString();
                dina.Text = docente.Nombre + " " + docente.Primer_apellido + "\n" + men.Asunto;

                dina.Click += new EventHandler(AbrirMensaje);
                panelNavMensajes.Controls.Add(dina);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtAsunto.Text = "";
            rtbxMensajeAEnviar.Text = "";
            cbxDestinatario.Items.Clear();
            docentes.Clear();
            CargarMensajes();
            panelEnviarMensaje.Visible = false;
        }

        private void btnNuevoChat_Click(object sender, EventArgs e)
        {
            docentes = new Logica.Docente().SelectDocentesDictandoAAlumno(Login.encontrado.Ci);
            foreach (Logica.Docente doc in docentes)
            {
                cbxDestinatario.Items.Add(doc.Nombre + " " + doc.Primer_apellido);
            }
            panelEnviarMensaje.Visible = true;
        }
    }
}
