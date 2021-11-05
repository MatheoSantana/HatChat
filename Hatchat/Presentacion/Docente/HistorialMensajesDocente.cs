using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class HistorialMensajesDocente : Form
    {
        string error;
        string filtrarAlumno;
        string filtrarntAlumno;
        string filtrarFecha;
        string filtrarntFecha;
        string hora;
        string fecha;
        string docente;
        string alumno;
        string consulta;
        string msgCerrarSesion;
        string cerrarSesionTitulo;

        Image recibido;
        Image constestado;
        Image realizado;
        List<Logica.Mensaje> mensTemp = new List<Logica.Mensaje>();
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
        private List<Logica.Alumno> alumnos = new List<Logica.Alumno>();

        public Form login;
        public Form perfilDocente;
        public Form principalChatDocente;
        public Form gruposDocente;
        public Form historialChatsDocente;
        public Form mensajesDocente;
        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        bool filtroAlumno = false, filtroFecha = false;
        public HistorialMensajesDocente()
        {

            InitializeComponent();

            Text = "Mensajes";


            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Login.idioma == "Español")
            {
                lblHistrialMensajes.Text = "Historial de Mensajes";
                lblHistrialMensajes.Location = new Point(-1, 0);
                btnFiltrarAlumno.Text = "Filtrar Alumno";
                filtrarAlumno = "Filtrar Alumno";
                filtrarntAlumno = "Dejar de filtrar Alumno";
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
                lblHoraAlumno.Text = hora;
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
                btnFiltrarAlumno.Text = "Filter Student";
                filtrarAlumno = "Filter Student";
                filtrarntAlumno = "Stop filtering Student";
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
                consulta = "Issue: ";
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
                recibido = Image.FromFile("circulo recibido.png");
                constestado = Image.FromFile("circulo contestado.png");
                realizado = Image.FromFile("circulo realizado.png");
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
        private void pcbxMensajesNav_Click(object sender, EventArgs e)
        {
            mensajesDocente.Show();
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
            if (filtroAlumno || filtroFecha)
            {
                CargarMensajesFiltro();
            }
            else
            {
                CargarMensajes();
            }
        }
        private void CargarMensajes()
        {
            bool iguales = true;
            List<Logica.Mensaje> mensajes = new Logica.Mensaje().SelectMensajesContestadosDo(Login.encontrado.Ci);
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
                cmbxAlumnos.Items.Clear();
                alumnos.Clear();
                foreach (Logica.Mensaje men in mensajes)
                {
                    bool agregar = true;
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                    foreach (Logica.Alumno alum in alumnos)
                    {
                        if (alum.Ci == us.Ci)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar)
                    {
                        Logica.Alumno alu = new Logica.Alumno(us.Ci, us.Nombre, us.Primer_apellido, us.Segundo_apellido, us.FotoDePerfil, us.Apodo, us.Activo);
                        alumnos.Add(alu);
                        cmbxAlumnos.Items.Add(alu.Nombre + " " + alu.Primer_apellido);
                    }
                }
                panelNavMensajes.Controls.Clear();
                panelContenedor.Visible = false;
                int yPanel = 0;
                foreach (Logica.Mensaje men in mensajes)
                {

                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                    Logica.Alumno alu = new Logica.Alumno();
                    alu.Ci = usuario.Ci;
                    alu.Nombre = usuario.Nombre;
                    alu.Primer_apellido = usuario.Primer_apellido;
                    alu.FotoDePerfil = usuario.FotoDePerfil;

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = alu.ByteArrayToImage(alu.FotoDePerfil);
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + men.IdMensaje.ToString();
                    picPhoto.Click += new EventHandler(AbrirMensaje);

                    Label alumno = new Label();
                    alumno.Height = 83;
                    alumno.Width = 230;
                    alumno.Location = new Point(80, 0);
                    alumno.ForeColor = Color.White;
                    alumno.Font = new Font("Arial", 15.0f);
                    alumno.Name = "lblDM" + men.IdMensaje.ToString();
                    alumno.Text = alu.Nombre + " " + alu.Primer_apellido;
                    alumno.Click += new EventHandler(AbrirMensaje);

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
                    panel.Controls.Add(alumno);
                    panel.Controls.Add(picCirculito);
                    panel.Controls.Add(hora);
                    panel.Controls.Add(fecha);
                    panelNavMensajes.Controls.Add(panel);
                }
            }
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            filtroFecha = !filtroFecha;
            dtpFiltro.Visible = filtroFecha;
            btnFiltrarFecha.Text =filtrarFecha;
            if (filtroFecha)
            {
                btnFiltrarFecha.Text = filtrarntFecha;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelNavMensajes.Visible = true;
            btnFiltrarFecha.Visible = true;
            cmbxAlumnos.Visible = filtroAlumno;
            dtpFiltro.Visible = filtroFecha;
            btnFiltrarAlumno.Visible = true;
            btnFiltrarFecha.Visible = true;
            btnVolver.Visible = false;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnFiltrarAlumno_Click(object sender, EventArgs e)
        {
            filtroAlumno = !filtroAlumno;
            cmbxAlumnos.Visible = filtroAlumno;
            btnFiltrarAlumno.Text = filtrarAlumno;
            if (filtroAlumno)
            {
                btnFiltrarAlumno.Text = filtrarntAlumno;
            }
        }

        private void CargarMensajesFiltro()
        {
            List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
            List<Logica.Mensaje> mensTemp = new Logica.Mensaje().SelectMensajesContestadosDo(Login.encontrado.Ci);
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
            bool igualestemps = true;
            if (mensTemp.Count == this.mensTemp.Count)
            {
                for (int x = 0; x < mensTemp.Count; x++)
                {
                    if (!(mensTemp[x].IdMensaje == this.mensTemp[x].IdMensaje && mensTemp[x].Estado == this.mensTemp[x].Estado))
                    {
                        igualestemps = false;
                    }
                }
            }
            else
            {
                igualestemps = false;
            }
            if (!igualestemps)
            {
                cmbxAlumnos.Items.Clear();
                alumnos.Clear();
                foreach (Logica.Mensaje men in mensTemp)
                {
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                    Logica.Alumno alu = new Logica.Alumno(us.Ci, us.Nombre, us.Primer_apellido, us.Segundo_apellido, us.FotoDePerfil, us.Apodo, us.Activo);
                    alumnos.Add(alu);
                    cmbxAlumnos.Items.Add(alu.Nombre + " " + alu.Primer_apellido);
                }
                this.mensTemp = mensTemp;
            }

                foreach (Logica.Mensaje men in mensTemp)
            {
                bool agregado = false;
                if (filtroAlumno || filtroFecha)
                {
                    string ci = "";
                    if (cmbxAlumnos.SelectedIndex != -1)
                    {
                        ci = alumnos[cmbxAlumnos.SelectedIndex].Ci;
                    }
                    if (filtroAlumno && filtroFecha)
                    {
                        if ((men.Alumno == ci) && ((men.FechaHoraAlumno.Year == dtpFiltro.Value.Year && men.FechaHoraAlumno.Month == dtpFiltro.Value.Month && men.FechaHoraAlumno.Day == dtpFiltro.Value.Day) || (men.FechaHoraDocente.Year == dtpFiltro.Value.Year && men.FechaHoraDocente.Month == dtpFiltro.Value.Month && men.FechaHoraDocente.Day == dtpFiltro.Value.Day)))
                        {
                            mensajes.Add(men);
                            agregado = true;
                        }
                    }
                    if (filtroAlumno && !agregado &&!filtroFecha)
                    {
                        if (men.Alumno == ci)
                        {
                            mensajes.Add(men);
                            agregado = true;
                        }
                    }
                    if (filtroFecha && !agregado &&!filtroAlumno)
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
                panelNavMensajes.Controls.Clear();
                panelContenedor.Visible = false;
                int yPanel = 0;
                foreach (Logica.Mensaje men in mensajes)
                {
                    Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
                    Logica.Alumno alu = new Logica.Alumno();
                    alu.Ci = usuario.Ci;
                    alu.Nombre = usuario.Nombre;
                    alu.Primer_apellido = usuario.Primer_apellido;
                    alu.FotoDePerfil = usuario.FotoDePerfil;

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = alu.ByteArrayToImage(alu.FotoDePerfil);
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + men.IdMensaje.ToString();
                    picPhoto.Click += new EventHandler(AbrirMensaje);

                    Label alumno = new Label();
                    alumno.Height = 83;
                    alumno.Width = 230;
                    alumno.Location = new Point(80, 0);
                    alumno.ForeColor = Color.White;
                    alumno.Font = new Font("Arial", 15.0f);
                    alumno.Name = "lblDM" + men.IdMensaje.ToString();
                    alumno.Text = alu.Nombre + " " + alu.Primer_apellido;
                    alumno.Click += new EventHandler(AbrirMensaje);

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
                        picCirculito.Image = recibido;
                    }
                    else if (men.Estado == "contestado")
                    {
                        picCirculito.Image = constestado;
                    }
                    else
                    {
                        picCirculito.Image = realizado;

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
                    panel.Controls.Add(alumno);
                    panel.Controls.Add(picCirculito);
                    panel.Controls.Add(hora);
                    panel.Controls.Add(fecha);
                    panelNavMensajes.Controls.Add(panel);
                }
            }
        }
        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelNavMensajes.Visible = false;
            btnFiltrarAlumno.Visible = false;
            btnFiltrarFecha.Visible = false;
            dtpFiltro.Visible = false;
            cmbxAlumnos.Visible = false;
            btnVolver.Visible = true;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            lblNombreDocente.Text = docente;
            lblFechaAlumno.Text = fecha;
            lblHoraAlumno.Text = hora;
            lblConsultaAlumno.Text = consulta;
            lblConsultaDocente.Text = consulta;
            lblNombreAlumno.Text = this.alumno;
            panelMensajeAlumno.Controls.Clear();
            panelMensajeDocente.Controls.Clear();
            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";

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
            
            Logica.Usuario usuario = new Logica.Usuario().SelectUsuarioCi(men.Alumno);
            Logica.Alumno alumno = new Logica.Alumno();

            alumno.Ci = usuario.Ci;
            alumno.Apodo = usuario.Apodo;
            alumno.Nombre = usuario.Nombre;
            alumno.Primer_apellido = usuario.Primer_apellido;
            alumno.Segundo_apellido = usuario.Segundo_apellido;
            
                alumno.FotoDePerfil = usuario.FotoDePerfil;
            
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

            Label menDo = new Label();
            menDo.Height = 139;
            menDo.Width = 605;
            menDo.Location = new Point(0, 0);
            menDo.Font = new Font("Arial", 12.0f);
            menDo.ForeColor = Color.White;
            menDo.Name = "lblMensajeDo";
            menDo.Text = men.MensajeDocente;
            panelMensajeDocente.Controls.Add(menDo);

            pbxAlumno.Image = alumno.ByteArrayToImage(alumno.FotoDePerfil);
            pbxDocente.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);

            lblFechaDocente.Text += "\n" + men.FechaHoraDocente.ToString("dd:MM:yyyy");
            lblHoraDocente.Text += "\n" + men.FechaHoraDocente.ToString("HH:mm");

        }

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
        }
    }
}
