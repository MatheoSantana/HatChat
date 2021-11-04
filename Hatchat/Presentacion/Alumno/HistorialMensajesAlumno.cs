using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class HistorialMensajesAlumno : Form
    {
        string error;
        string filtrarDocente;
        string filtrarntDocente;
        string filtrarFecha;
        string filtrarntFecha;
        string hora;
        string fecha;
        string docente;
        string alumno;
        string consulta;
        string msgCerrarSesion;
        string cerrarSesionTitulo;

        private List<Logica.Docente> docentes = new List<Logica.Docente>();
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();

        public Form login;
        public Form principalChatAlumno;
        public Form mensajesAlumno;
        public Form gruposAlumno;
        public Form perfilAlumno;
        public Form historialchatsAlumno;
        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        bool filtroDocente = false, filtroFecha = false;

        public HistorialMensajesAlumno()
        {
            InitializeComponent();
            Text = "Mensajes";


            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //nav

            if (Login.idioma == "Español")
            {
                lblHistrialMensajes.Text = "Historial de Mensajes";
                lblHistrialMensajes.Location = new Point(-1, 0);
                btnFiltrarDocente.Text = "Filtrar Docente";
                filtrarDocente = "Filtrar Docente";
                filtrarntDocente = "Dejar de filtrar Docente";
                btnFiltrarFecha.Text = "Filtrar Fecha";
                filtrarFecha = "Filtrar Fecha";
                filtrarntFecha = "Dejar de filtrar fecha";
                btnVolver.Text = "Volver";
                alumno = "Alumno: ";
                lblNombreAlumno.Text = alumno;
                consulta = "Consulta: ";
                lblConsultaAlumno.Text = consulta;
                lblConsultaDocente.Text = consulta;
                docente = "Docente: ";
                lblNombreDocente.Text = docente;
                lblBienvenido.Text = "Usted no tiene mensajes archivados";
                hora = "Hora: ";
                lblHoraAlumno.Text=hora;
                lblHoraDocente.Text = hora;
                fecha = "Fecha: ";
                lblFechaAlumno.Text = fecha;
                lblFechaDocente.Text = fecha;
                error = " comuníquese con el administrador.";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";
            }
            else
            {
                
                lblHistrialMensajes.Text = "Message History";
                lblHistrialMensajes.Location = new Point(44, 0);
                btnFiltrarDocente.Text = "Filter Teacher";
                filtrarDocente = "Filter Teacher";
                filtrarntDocente = "Stop filtering Teacher";
                btnFiltrarFecha.Text = "Filter Date";
                filtrarFecha = "Filter Date";
                filtrarntFecha = "Stop filtering date";
                btnVolver.Text = "Return";
                docente = "Teacher: ";
                lblNombreDocente.Text = docente;
                lblBienvenido.Text = "You have no archived messages";
                hora = "Hour: ";
                lblHoraAlumno.Text = hora;
                lblHoraDocente.Text = hora;
                fecha = "Date: ";
                lblFechaAlumno.Text = fecha;
                lblFechaDocente.Text = fecha;
                error = "  Contact an administrator.";
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
                alumno = "Student:";
                lblNombreAlumno.Text = alumno;
                consulta = "Consulta: ";
                lblConsultaAlumno.Text = consulta;
                lblConsultaDocente.Text = consulta;



            }

            try
            {
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje blanco.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxLogo.Image = Image.FromFile("Logo Completa.png");

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
            pcbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;


            cmbxDocentes.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarMensajes();
        }

        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelNavMensajes.Visible = false;
            btnFiltrarDocente.Visible = false;
            btnFiltrarFecha.Visible = false;
            dtpFiltro.Visible = false;
            cmbxDocentes.Visible = false;
            btnVolver.Visible = true;
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
;

            Logica.Mensaje men = new Logica.Mensaje();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                men = men.SelectAbrirMensaje(((Label)sender).Name);
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                men = men.SelectAbrirMensaje(((PictureBox)sender).Name);
            }
            else
            {
                men = men.SelectAbrirMensaje(((Panel)sender).Name);
            }
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
            menDo.Name = "lblMensajeDo";
            menDo.Text = men.MensajeDocente;
            panelMensajeDocente.Controls.Add(menDo);


            pbxAlumno.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            pbxDocente.Image = docente.ByteArrayToImage(docente.FotoDePerfil);
            
                lblFechaDocente.Text += "\n" + men.FechaHoraDocente.ToString("dd/MM/yyyy");
                lblHoraDocente.Text += "\n" + men.FechaHoraDocente.ToString("HH:mm");
            
            

        }

        private void MensajesAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }
        private void pbxChatNav_Click(object sender, EventArgs e)
        {
            principalChatAlumno.Show();
            this.Hide();
        }

        private void pbxMensajeNav_Click(object sender, EventArgs e)
        {
            mensajesAlumno.Show();
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
        private void pcbxHistorialChatNav_Click(object sender, EventArgs e)
        {
            historialchatsAlumno.Show();
            this.Hide();
        }
        private void timerHistorialNav_Tick(object sender, EventArgs e)
        {
            if (!enPanel && !enHistorial && !enHistorialChat && !enHistorialMensaje)
            {
                panelHistorialesNav.Visible = false;
            }
        }
        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
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
        private void CargarMensajes()
        {
            List<Logica.Mensaje> mensajes = new Logica.Mensaje().SelectMensajesRecibidosAl(Login.encontrado.Ci);

            if (mensajes.Count != 0)
            {
                lblLinea.Visible = false;
                lblBienvenido.Visible = false;
                pcbxLogo.Visible = false;
            }
            else
            {
                lblLinea.Visible = true;
                lblBienvenido.Visible = true;
                pcbxLogo.Visible = true;
            }

            bool iguales = true;
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
                cmbxDocentes.Items.Clear();
                docentes.Clear();
                foreach (Logica.Mensaje men in mensajes)
                {
                    bool agregar = true;
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                    foreach (Logica.Docente doce in docentes)
                    {
                        if (doce.Ci == us.Ci)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar)
                    {
                        Logica.Docente doc = new Logica.Docente(us.Ci, us.Nombre, us.Primer_apellido, us.Segundo_apellido, us.FotoDePerfil, us.Apodo, us.Activo);
                        docentes.Add(doc);
                        cmbxDocentes.Items.Add(doc.Nombre + " " + doc.Primer_apellido);
                    }
                }
                this.mensajes = mensajes;
                panelNavMensajes.Controls.Clear();
            panelContenedor.Visible = false;
                int yPanel = 0;
                foreach (Logica.Mensaje men in mensajes)
                {
                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                    Logica.Docente doc = new Logica.Docente();

                    doc.Nombre = usuario.Nombre;
                    doc.Primer_apellido = usuario.Primer_apellido;
                    if (!(doc.FotoDePerfil == null))
                    {
                        doc.FotoDePerfil = usuario.FotoDePerfil;
                    }

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = doc.ByteArrayToImage(doc.FotoDePerfil);
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + men.IdMensaje.ToString();
                    picPhoto.Click += new EventHandler(AbrirMensaje);

                    Label docente = new Label();
                    docente.Height = 83;
                    docente.Width = 230;
                    docente.Location = new Point(80, 0);
                    docente.ForeColor = Color.White;
                    docente.Font = new Font("Arial", 15.0f);
                    docente.Name = "lblDM" + men.IdMensaje.ToString();
                    docente.Text = doc.Nombre + " " + doc.Primer_apellido;
                    docente.Click += new EventHandler(AbrirMensaje);

                    Label mensaje = new Label();
                    mensaje.Height = 83;
                    mensaje.Width = 150;
                    mensaje.Location = new Point(310, 0);
                    mensaje.ForeColor = Color.White;
                    mensaje.Font = new Font("Arial", 12.0f);
                    mensaje.Name = "lblTM" + men.IdMensaje.ToString();
                    mensaje.Text = consulta+"\n" + men.Asunto;
                    mensaje.Click += new EventHandler(AbrirMensaje);

                    Label hora = new Label();
                    hora.Height = 83;
                    hora.Width = 85;
                    hora.Location = new Point(500, 0);
                    hora.ForeColor = Color.White;
                    hora.Font = new Font("Arial", 12.0f);
                    hora.Name = "lblMH" + men.IdMensaje.ToString();
                    hora.Text = this.hora+"\n" + men.FechaHoraDocente.ToString("HH") + ":" + men.FechaHoraDocente.ToString("mm");
                    hora.Click += new EventHandler(AbrirMensaje);

                    Label fecha = new Label();
                    fecha.Height = 83;
                    fecha.Width = 150;
                    fecha.Location = new Point(600, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 12.0f);
                    fecha.Name = "lblCI" + men.IdMensaje.ToString();
                    fecha.Text = this.fecha+"\n" + men.FechaHoraDocente.ToString("dd") + "/" + men.FechaHoraDocente.ToString("MM") + "/" + men.FechaHoraDocente.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirMensaje);

                    PictureBox picCirculito = new PictureBox();
                    if (men.Estado == "recibido")
                    {
                        picCirculito.Image = Image.FromFile("circulo recibido.png");
                    }
                    else if (men.Estado == "contestado")
                    {
                        picCirculito.Image = Image.FromFile("circulo contestado.png");
                    }
                    else
                    {
                        picCirculito.Image = Image.FromFile("circulo realizado.png");

                    }

                    picCirculito.SizeMode = PictureBoxSizeMode.StretchImage;
                    picCirculito.Height = 40;
                    picCirculito.Width = 40;
                    picCirculito.Location = new Point(470, 37);
                    picCirculito.Name = "pbxCircu" + men.IdMensaje.ToString();
                    picCirculito.Click += new EventHandler(AbrirMensaje);

                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 738;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelC" + men.IdMensaje.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirMensaje);

                    panel.Controls.Add(mensaje);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(docente);
                    panel.Controls.Add(picCirculito);
                    panel.Controls.Add(hora);
                    panel.Controls.Add(fecha);
                    panelNavMensajes.Controls.Add(panel);
                }
            }
        }

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelNavMensajes.Visible = true;
            btnFiltrarFecha.Visible = true;
            cmbxDocentes.Visible = filtroDocente;
            dtpFiltro.Visible = filtroFecha;
            btnFiltrarDocente.Visible = true;
            btnFiltrarFecha.Visible = true;
            btnVolver.Visible = false;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void CargarMensajesFiltro()
        {
            List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
            List<Logica.Mensaje> mensTemp = new Logica.Mensaje().SelectMensajesRecibidosAl(Login.encontrado.Ci);

            if (mensTemp.Count != 0)
            {
                lblLinea.Visible = false;
                lblBienvenido.Visible = false;
                pcbxLogo.Visible = false;
            }
            else
            {
                lblLinea.Visible = true;
                lblBienvenido.Visible = true;
                pcbxLogo.Visible = true;
            }

            foreach (Logica.Mensaje men in mensTemp)
            {
                bool agregado = false;
                if (filtroDocente || filtroFecha)
                {
                    string ci = "";
                    if (cmbxDocentes.SelectedIndex != -1)
                    {
                        ci = docentes[cmbxDocentes.SelectedIndex].Ci;
                    }
                    if (filtroDocente && filtroFecha)
                    {
                        if ((men.Docente == ci) && ((men.FechaHoraAlumno.Year == dtpFiltro.Value.Year && men.FechaHoraAlumno.Month == dtpFiltro.Value.Month && men.FechaHoraAlumno.Day == dtpFiltro.Value.Day) || (men.FechaHoraDocente.Year == dtpFiltro.Value.Year && men.FechaHoraDocente.Month == dtpFiltro.Value.Month && men.FechaHoraDocente.Day == dtpFiltro.Value.Day)))
                        {
                            mensajes.Add(men);
                            agregado = true;
                        }
                    }
                    if (filtroDocente && !agregado)
                    {
                        if (men.Docente == ci)
                        {
                            mensajes.Add(men);
                            agregado = true;
                        }
                    }
                    if (filtroFecha && !agregado)
                    {
                        if ((men.FechaHoraAlumno.Year == dtpFiltro.Value.Year && men.FechaHoraAlumno.Month == dtpFiltro.Value.Month && men.FechaHoraAlumno.Day == dtpFiltro.Value.Day) || (men.FechaHoraDocente.Year == dtpFiltro.Value.Year && men.FechaHoraDocente.Month == dtpFiltro.Value.Month && men.FechaHoraDocente.Day == dtpFiltro.Value.Day))
                        {
                            mensajes.Add(men);
                        }
                    }
                }
                else
                {
                    mensajes.Add(men);
                }
            }
            bool iguales = true;
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
                cmbxDocentes.Items.Clear();
                docentes.Clear();
                foreach (Logica.Mensaje men in mensTemp)
                {
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                    Logica.Docente doc = new Logica.Docente(us.Ci, us.Nombre, us.Primer_apellido, us.Segundo_apellido, us.FotoDePerfil, us.Apodo, us.Activo);
                    docentes.Add(doc);
                    cmbxDocentes.Items.Add(doc.Nombre + " " + doc.Primer_apellido);
                }
                this.mensajes = mensajes;
                panelNavMensajes.Controls.Clear();
                panelContenedor.Visible = false;
                int yPanel = 0;
                foreach (Logica.Mensaje men in mensajes)
                {
                    this.mensajes = mensajes;
                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                    Logica.Docente doc = new Logica.Docente();

                    doc.Nombre = usuario.Nombre;
                    doc.Primer_apellido = usuario.Primer_apellido;
                    if (!(usuario.FotoDePerfil == null))
                    {
                        doc.FotoDePerfil = usuario.FotoDePerfil;
                    }

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = doc.ByteArrayToImage(doc.FotoDePerfil) ;
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + men.IdMensaje.ToString();
                    picPhoto.Click += new EventHandler(AbrirMensaje);

                    Label docente = new Label();
                    docente.Height = 83;
                    docente.Width = 230;
                    docente.Location = new Point(80, 0);
                    docente.ForeColor = Color.White;
                    docente.Font = new Font("Arial", 15.0f);
                    docente.Name = "lblDM" + men.IdMensaje.ToString();
                    docente.Text = doc.Nombre + " " + doc.Primer_apellido;
                    docente.Click += new EventHandler(AbrirMensaje);

                    Label mensaje = new Label();
                    mensaje.Height = 83;
                    mensaje.Width = 150;
                    mensaje.Location = new Point(310, 0);
                    mensaje.ForeColor = Color.White;
                    mensaje.Font = new Font("Arial", 12.0f);
                    mensaje.Name = "lblTM" + men.IdMensaje.ToString();
                    mensaje.Text = consulta+"\n" + men.Asunto;
                    mensaje.Click += new EventHandler(AbrirMensaje);

                    Label hora = new Label();
                    hora.Height = 83;
                    hora.Width = 85;
                    hora.Location = new Point(460, 0);
                    hora.ForeColor = Color.White;
                    hora.Font = new Font("Arial", 12.0f);
                    hora.Name = "lblMH" + men.IdMensaje.ToString();
                    hora.Text = this.hora+ "\n" + men.FechaHoraDocente.ToString("HH") + ":" + men.FechaHoraDocente.ToString("mm");
                    hora.Click += new EventHandler(AbrirMensaje);

                    Label fecha = new Label();
                    fecha.Height = 83;
                    fecha.Width = 150;
                    fecha.Location = new Point(630, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 12.0f);
                    fecha.Name = "lblCI" + men.IdMensaje.ToString();
                    fecha.Text = this.fecha+"\n" + men.FechaHoraDocente.ToString("dd") + "/" + men.FechaHoraDocente.ToString("MM") + "/" + men.FechaHoraDocente.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirMensaje);

                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 738;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelC" + men.IdMensaje.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirMensaje);

                    panel.Controls.Add(mensaje);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(docente);
                    panel.Controls.Add(hora);
                    panel.Controls.Add(fecha);
                    panelNavMensajes.Controls.Add(panel);

                }
            }
        }

        private void btnFiltrarDocente_Click(object sender, EventArgs e)
        {
            filtroDocente = !filtroDocente;
            cmbxDocentes.Visible = filtroDocente;
            btnFiltrarDocente.Text = filtrarDocente;
            if (filtroDocente)
            {
                btnFiltrarDocente.Text = filtrarntDocente;
            }
        }


        private void timerHistorialMensajes_Tick(object sender, EventArgs e)
        {
            if (filtroDocente || filtroFecha)
            {
                CargarMensajesFiltro();   
            }
            else
            {
                CargarMensajes();
            }
                
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            filtroFecha = !filtroFecha;
            dtpFiltro.Visible = filtroFecha;
            btnFiltrarFecha.Text = filtrarFecha;
            if (filtroFecha)
            {
                btnFiltrarFecha.Text = filtrarntFecha;
            }
        }


    }
}
