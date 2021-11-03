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

        public Form login;
        public Form perfilDocente;
        public Form principalChatDocente;
        public Form gruposDocente;
        public Form historialChatsDocente;
        public Form historialMensajesDocente;
        Logica.Mensaje mensajeSeleccionado = new Logica.Mensaje();

        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        public MensajesDocente()
        {

            InitializeComponent();

            Text = "Mensajes";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;

            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje blanco.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
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
            pcbxHistorialChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialMensajesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

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
        private void pbxGruposNav_Click(object sender, EventArgs e)
        {
            gruposDocente.Show();
            this.Hide();
        }
        private void pbxHistorialNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorial = true;
            panelHistorialesNav.Visible = true;
        }
        private void panelHistorialesNav_MouseEnter(object sender, EventArgs e)
        {
            enPanel = true;
        }
        private void pcbxHistorialChatNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorialChat = true;
        }
        private void pcbxHistorialMensajesNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorialMensaje = true;
        }
        private void pbxHistorialNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorial = false;
        }

        private void panelHistorialesNav_MouseLeave(object sender, EventArgs e)
        {
            enPanel = false;
        }
        private void pcbxHistorialChatNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorialChat = false;
        }
        private void pcbxHistorialMensajesNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorialMensaje = false;
        }

        private void pcbxHistorialMensajesNav_Click(object sender, EventArgs e)
        {
            historialMensajesDocente.Show();
            this.Hide();
        }
        private void pcbxHistorialChatNav_Click(object sender, EventArgs e)
        {
            historialChatsDocente.Show();
            this.Hide();
        }
        private void timerHistorialNav_Tick(object sender, EventArgs e)
        {
            if (!enPanel && !enHistorial && !enHistorialChat && !enHistorialMensaje)
            {
                panelHistorialesNav.Visible = false;
            }
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
        private void timerMensajes_Tick(object sender, EventArgs e)
        {
            CargarMensajes();
        }
        private void CargarMensajes()
        {
            bool iguales = true;
            List<Logica.Mensaje> mensajes = new Logica.Mensaje().SelectCargarMensajesDo(Login.encontrado.Ci);
            if (mensajes.Count == this.mensajes.Count)
            {
                for (int x = 0; x < mensajes.Count; x++)
                {
                    if (!(mensajes[x].IdMensaje == this.mensajes[x].IdMensaje))
                    {
                        iguales = false;
                    }
                }
            }
            else
            {
                iguales = false;
            }
            if (!iguales)
            {
                this.mensajes = mensajes;
                int yPanel = 0;
                panelNavMensajes.Controls.Clear();
                foreach (Logica.Mensaje men in mensajes)
                {
                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                    Logica.Docente alumno = new Logica.Docente();
                    alumno.Nombre = usuario.Nombre;
                    alumno.Primer_apellido = usuario.Primer_apellido;
                    alumno.FotoDePerfil = usuario.FotoDePerfil;


                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = alumno.ByteArrayToImage(alumno.FotoDePerfil);
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 49;
                    picPhoto.Width = 49;
                    picPhoto.Location = new Point(10, 20);
                    picPhoto.Name = "pbxM" + men.IdMensaje.ToString();
                    picPhoto.Click += new EventHandler(AbrirMensaje);

                    Label grupo = new Label();
                    grupo.Height = 83;
                    grupo.Width = 130;
                    grupo.Location = new Point(71, 0);
                    grupo.ForeColor = Color.White;
                    grupo.Font = new Font("Arial", 9.0f);
                    grupo.Name = "lblM" + men.IdMensaje.ToString();
                    grupo.Text = alumno.Nombre + " " + alumno.Primer_apellido + "\n\n" + men.Asunto;
                    grupo.Click += new EventHandler(AbrirMensaje);

                    Label fecha = new Label();
                    fecha.Height = 40;
                    fecha.Width = 70;
                    fecha.Location = new Point(201, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 8.0f);
                    fecha.Name = "lblMF" + men.IdMensaje.ToString();
                    fecha.Text = "Fecha:\n" + men.FechaHoraAlumno.ToString("dd") + "/" + men.FechaHoraAlumno.ToString("MM") + "/" + men.FechaHoraAlumno.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirMensaje);

                    PictureBox picCirculito = new PictureBox();
                    if (men.Estado == "recibido")
                    {
                        picCirculito.Image = Image.FromFile("circulo realizado.png");
                    }
                    else if (men.Estado == "contestado")
                    {
                        picCirculito.Image = Image.FromFile("circulo contestado.png");
                    }
                    else
                    {
                        picCirculito.Image = Image.FromFile("circulo recibido.png");

                    }

                    picCirculito.SizeMode = PictureBoxSizeMode.StretchImage;
                    picCirculito.Height = 40;
                    picCirculito.Width = 40;
                    picCirculito.Location = new Point(201, 37);
                    picCirculito.Name = "pbxCircu" + men.IdMensaje.ToString();
                    picCirculito.Click += new EventHandler(AbrirMensaje);

                    PictureBox picflecha = new PictureBox();
                    picflecha.Image = Image.FromFile("flecha blanca entrar.png");
                    picflecha.SizeMode = PictureBoxSizeMode.StretchImage;
                    picflecha.Height = 69;
                    picflecha.Width = 69;
                    picflecha.Location = new Point(260, 12);
                    picflecha.Name = "pbxM" + men.IdMensaje.ToString();
                    picflecha.Click += new EventHandler(AbrirMensaje);

                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 319;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelM" + men.IdMensaje.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirMensaje);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(picflecha);
                    panel.Controls.Add(fecha);
                    panel.Controls.Add(picCirculito);

                    panelNavMensajes.Controls.Add(panel);


                }
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
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
            panelMensajeAlumno.Controls.Clear();

            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";
            rtbxRespuesta.Text = "";

            Logica.Mensaje men = new Logica.Mensaje();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                men = new Logica.Mensaje().SelectAbrirMensaje(((Label)sender).Name);
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                men = new Logica.Mensaje().SelectAbrirMensaje(((PictureBox)sender).Name);
            }
            else
            {
                men = new Logica.Mensaje().SelectAbrirMensaje(((Panel)sender).Name);
            }
            mensajeSeleccionado = men;
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

            panelContenedor.Visible = true;
            lblNombreDocente.Text += ("\n" + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido);
            lblFechaAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("dd:MM:yyyy");
            lblHoraAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("HH:mm");
            lblConsultaAlumno.Text += "\n" + men.Asunto;
            lblConsultaDocente.Text += "\n" + men.Asunto;
            lblNombreAlumno.Text += "\n" + alumno.Nombre + " " + alumno.Primer_apellido;

            Label menAl = new Label();
            menAl.Height = 139;
            menAl.Width = 605;
            menAl.Location = new Point(0, 0);
            menAl.Font = new Font("Arial", 12.0f);
            menAl.Name = "lblMensajeAl";
            menAl.ForeColor = Color.White;
            menAl.Text = men.MensajeAlumno;
            panelMensajeAlumno.Controls.Add(menAl);

            pbxAlumno.Image = alumno.ByteArrayToImage(alumno.FotoDePerfil);
            pbxDocente.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
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
                panelContenedor.Visible = false;
            }

        }
        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            try
            {
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            }catch(Exception ex) { }
        }
    }
}
