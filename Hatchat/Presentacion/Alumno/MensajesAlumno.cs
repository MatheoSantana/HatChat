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
        string error;
        string enviado;
        string hora;
        string fecha;
        string docente;
        string alumno;
        string consulta;
        string msgCerrarSesion;
        string cerrarSesionTitulo;
        string noRespondio;
        string destinatariont;
        string asuntoCorto;
        string largo;
        Image recibido;
        Image contestado;
        Image realizado;
        Image flecha;

        private List<Logica.Docente> docentes = new List<Logica.Docente>();
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();

        public Form login;
        public Form principalChatAlumno;
        public Form gruposAlumno;
        public Form perfilAlumno;
        public Form historialChatsAlumno;
        public Form historialMensajesAlumno;
        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        public MensajesAlumno()
        {
            InitializeComponent();
            Text = "Mensajes";


            ClientSize = new Size(1280, 720);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;
            panelEnviarMensaje.Visible = false;
            if (Login.idioma == "Español")
            {
                lblMensajes.Text = "Mensajes";
                btnNuevoMensaje.Text = "Nuevo Mensaje";
                alumno = "Alumno: ";
                lblNombreAlumno.Text = alumno;
                consulta = "Consulta: ";
                lblConsultaAlumno.Text = consulta;
                lblConsultaDocente.Text = consulta;
                docente = "Docente: ";
                lblNombreDocente.Text = docente;
                lblBienvenido.Text = "Bienvenido";
                hora = "Hora: ";
                lblHoraAlumno.Text = hora;
                lblHoraDocente.Text = hora;
                fecha = "Fecha: ";
                lblFechaAlumno.Text = fecha;
                lblFechaDocente.Text = fecha;
                error = " comuníquese con el administrador.";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";
                lblBuevoMensaje.Text = "Nuevo Mensaje";
                lblDestinatario.Text = "Para:";
                lblAsunto.Text = "Asunto";
                lblMensaje.Text = "Mensaje: ";
                btnCancelar.Text = "Cancelar";
                btnEnviar.Text = "Enviar";
                noRespondio="''El mensaje no ha sido respondido''";
                enviado = "Se ha enviado el mensaje correctamente";
                destinatariont = "Debe ingresar un destinatario";
                asuntoCorto = "Debe tener un asunto con un maximo de 60 caracteres";
                largo = "El mensaje es demasiado largo, pruebe con menos de 500 caracteres";
            }
            else
            {
                btnNuevoMensaje.Text = "New Message";
                lblMensajes.Text = "Message";
                docente = "Teacher: ";
                lblNombreDocente.Text = docente;
                lblBienvenido.Text = "Welcome";
                hora = "Hour: ";
                lblHoraAlumno.Text = hora;
                lblHoraDocente.Text = hora;
                fecha = "Date: ";
                lblFechaAlumno.Text = fecha;
                lblFechaDocente.Text = fecha;
                alumno = "Student:";
                lblNombreAlumno.Text = alumno;
                consulta = "Iusse: ";
                lblConsultaAlumno.Text = consulta;
                lblConsultaDocente.Text = consulta;
                error = "  Contact an administrator.";
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
                lblBuevoMensaje.Text = "New Message";
                lblDestinatario.Text = "For: ";
                lblAsunto.Text = "Issue: ";
                lblMensaje.Text = "Message: ";
                btnCancelar.Text = "Cancel";
                btnEnviar.Text = "Send";
                noRespondio = "''The message has not been answered''";
                enviado = "The message has been sent successfully";
                destinatariont = "You must enter a addressee";
                asuntoCorto = "Must have a iusse with a maximum of 60 characters";
                largo = "The message is too long, try less than 500 characters";
            }
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
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                recibido = Image.FromFile("circulo recibido.png");
                contestado = Image.FromFile("circulo contestado.png");
                realizado = Image.FromFile("circulo realizado.png");
                flecha = Image.FromFile("flecha blanca entrar.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

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


            cbxDestinatario.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarMensajes();
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
        private void pbxGruposNav_Click(object sender, EventArgs e)
        {
            gruposAlumno.Show();
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
            historialMensajesAlumno.Show();
            this.Hide();
        }
        private void pcbxHistorialChatNav_Click(object sender, EventArgs e)
        {
            historialChatsAlumno.Show();
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
            DialogResult cerrarSesion = MessageBox.Show(msgCerrarSesion, cerrarSesionTitulo, MessageBoxButtons.YesNo);
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
            List<Logica.Mensaje> mensajes = new Logica.Mensaje().SelectMensajesAl(Login.encontrado.Ci);
            if (mensajes.Count == this.mensajes.Count)
            {
                for (int x = 0; x < mensajes.Count; x++)
                {
                    if (!(mensajes[x].IdMensaje == this.mensajes[x].IdMensaje && mensajes[x].Estado == this.mensajes[x].Estado))
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
                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                    Logica.Docente docente = new Logica.Docente();
                    docente.Ci = usuario.Ci;
                    docente.Nombre = usuario.Nombre;
                    docente.Primer_apellido = usuario.Primer_apellido;
                    docente.FotoDePerfil = usuario.FotoDePerfil;

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = docente.ByteArrayToImage(docente.FotoDePerfil);
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
                    grupo.Text = docente.Nombre + " " + docente.Primer_apellido + "\n\n" + men.Asunto;
                    grupo.Click += new EventHandler(AbrirMensaje);

                    Label fecha = new Label();
                    fecha.Height = 40;
                    fecha.Width = 70;
                    fecha.Location = new Point(201, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 8.0f);
                    fecha.Name = "lblMF" + men.IdMensaje.ToString();
                    fecha.Text = this.fecha+"\n" + men.FechaHoraAlumno.ToString("dd") + "/" + men.FechaHoraAlumno.ToString("MM") + "/" + men.FechaHoraAlumno.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirMensaje);

                    PictureBox picCirculito = new PictureBox();
                    if (men.Estado == "recibido")
                    {
                        picCirculito.Image = recibido;
                    }
                    else if (men.Estado == "contestado")
                    {
                        picCirculito.Image = contestado;
                    }
                    else
                    {
                        picCirculito.Image = realizado;

                    }

                    picCirculito.SizeMode = PictureBoxSizeMode.StretchImage;
                    picCirculito.Height = 40;
                    picCirculito.Width = 40;
                    picCirculito.Location = new Point(201, 37);
                    picCirculito.Name = "pbxCircu" + men.IdMensaje.ToString();
                    picCirculito.Click += new EventHandler(AbrirMensaje);

                    PictureBox picflecha = new PictureBox();
                    picflecha.Image = flecha;
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
        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelEnviarMensaje.Visible = false;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            lblNombreDocente.Text = this.docente;
            lblFechaAlumno.Text = fecha;
            lblHoraAlumno.Text = hora;
            lblConsultaAlumno.Text = consulta;
            lblConsultaDocente.Text = consulta;
            lblNombreAlumno.Text = alumno;
            panelMensajeAlumno.Controls.Clear();
            panelMensajeDocente.Controls.Clear();

            lblFechaDocente.Text = fecha;
            lblHoraDocente.Text = hora;
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
            
            Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
            Logica.Docente docente = new Logica.Docente();

            docente.Ci = usuario.Ci;
            docente.Apodo = usuario.Apodo;
            docente.Nombre = usuario.Nombre;
            docente.Primer_apellido = usuario.Primer_apellido;
            docente.Segundo_apellido = usuario.Segundo_apellido;
            docente.FotoDePerfil = usuario.FotoDePerfil;
            docente.Activo = usuario.Activo;

            panelContenedor.Visible = true;
            lblNombreDocente.Text += ("\n" + docente.Nombre + " " + docente.Primer_apellido);
            lblFechaAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("dd/MM/yyyy");
            lblHoraAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("HH:mm");
            lblConsultaAlumno.Text += "\n" + men.Asunto;
            lblConsultaDocente.Text += "\n" + men.Asunto;
            lblNombreAlumno.Text += "\n" + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido;

            Label menAl = new Label();
            menAl.Height = 139;
            menAl.Width = 605;
            menAl.Location = new Point(0, 0);
            menAl.Font = new Font("Arial", 12.0f);
            menAl.Name = "lblMensajeAl";
            menAl.ForeColor = Color.White;
            menAl.Text = men.MensajeAlumno;
            panelMensajeAlumno.Controls.Add(menAl);

            Label menDo = new Label();
            menDo.Height = 139;
            menDo.Width = 605;
            menDo.Location = new Point(0, 0);
            menDo.Font = new Font("Arial", 12.0f);
            menDo.ForeColor = Color.White;
            menDo.Name = "lblMensajeAl";
            menDo.Text = men.MensajeDocente;
            

            pbxAlumno.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            pbxDocente.Image = docente.ByteArrayToImage(docente.FotoDePerfil);
            menDo.Text = noRespondio;
            if (!(men.Estado == "realizado"))
            {
                menDo.Text = men.MensajeDocente;
                lblFechaDocente.Text += "\n" + men.FechaHoraDocente.ToString("dd/MM/yyyy");
                lblHoraDocente.Text += "\n" + men.FechaHoraDocente.ToString("HH:mm");
                men.Estado = "recibido";
                men.AbrirMensaje();
                mensajes.Clear();
            }
            panelEnviarMensaje.Visible = false;
            panelMensajeDocente.Controls.Add(menDo);
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cbxDestinatario.SelectedIndex != -1)
            {
                if (txtAsunto.Text.Length < 61 && txtAsunto.Text.Length>0)
                {
                    if (rtbxMensajeAEnviar.Text.Length < 501)
                    {
                        Logica.Mensaje men = new Logica.Mensaje(Login.encontrado.Ci, txtAsunto.Text, DateTime.Now, rtbxMensajeAEnviar.Text, docentes[cbxDestinatario.SelectedIndex].Ci, "realizado");
                        men.EnviarMensajeAlumno();
                        MessageBox.Show(enviado);
                        txtAsunto.Text = "";
                        rtbxMensajeAEnviar.Text = "";
                        cbxDestinatario.Items.Clear();
                        docentes.Clear();
                        CargarMensajes();
                        panelEnviarMensaje.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show(largo);
                    }
                }
                else
                {
                    MessageBox.Show(asuntoCorto);
                }
            }
            else
            {
                MessageBox.Show(destinatariont);
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            try
            {
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            }
            catch (Exception ex) { }
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
            panelEnviarMensaje.Visible = !panelEnviarMensaje.Visible;
            panelContenedor.Visible = false;
            docentes = new Logica.Docente().SelectDocentesDictandoAAlumno(Login.encontrado.Ci);
            cbxDestinatario.Items.Clear();
            foreach (Logica.Docente doc in docentes)
            {
                cbxDestinatario.Items.Add(doc.Nombre + " " + doc.Primer_apellido);
            }
        }

        
    }
}
