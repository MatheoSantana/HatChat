using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hatchat.Presentacion
{
    public partial class HistorialChatsAlumno : Form
    {
        string error;
        string filtrarAsignatura;
        string filtrarntAsignatura;
        string filtrarFecha;
        string filtrarntFecha;
        string horaInicio;
        string horaFin;
        string fecha;
        string docente;
        string msgCerrarSesion;
        string cerrarSesionTitulo;
        Image imagenProfesor;

        public Form login;
        public Form mensajesAlumno;
        public Form gruposAlumno;
        public Form perfilAlumno;
        public Form principalChatsAlumno;
        public Form historialMensajesAlumno;

        private List<Logica.Chat> chats = new List<Logica.Chat>();
        private List<Logica.Chat> chatsTemps = new List<Logica.Chat>();
        private List<Logica.Chatea> mensajs = new List<Logica.Chatea>();
        public static Logica.Chat abierto = new Logica.Chat();
        private List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();

        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        bool filtroAsignatura = false, filtroFecha = false;
        public HistorialChatsAlumno()
        {
            InitializeComponent();
            Text = "Chat";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(1280, 720);
            panelCharla.Visible = false;
            panelDatosClase.Visible = false;

            StartPosition = FormStartPosition.CenterScreen;
            
            if (Login.idioma == "Español")
            {
                lblHistrialChat.Text = "Historial de Chats";
                lblHistrialChat.Location = new Point(-1, 0);
                btnFiltrarAsignatura.Text = "Filtrar Asignatura";
                filtrarAsignatura = "Filtrar Asignatura";
                filtrarntAsignatura = "Dejar de filtrar asignatura";
                btnFiltrarFecha.Text = "Filtrar Fecha";
                filtrarFecha = "Filtrar Fecha";
                filtrarntFecha = "Dejar de filtrar fecha";
                btnVolver.Text = "Volver";
                lblHorario.Text = "Horario de actividad:";
                btnParticipantes.Text = "Participantes";
                docente = "Docente: ";
                lblDocenteParticipantes.Text = docente;
                lblHostParticipantes.Text = "Host: ";
                lblParticipantes.Text = "Participantes: ";
                lblBienvenido.Text = "Usted no tiene chats archivados";
                horaInicio = "Hora inicio: ";
                horaFin = "Hora Fin: ";
                fecha = "Fecha: ";
                error = " comuníquese con el administrador.";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";
            }
            else
            {
                lblHistrialChat.Text = "Chat History";
                lblHistrialChat.Location = new Point(44, 0);
                btnFiltrarAsignatura.Text = "Filter Subject";
                filtrarAsignatura = "Filter Subject";
                filtrarntAsignatura = "Stop filtering subject";
                btnFiltrarFecha.Text = "Filter Date";
                filtrarFecha = "Filter Date";
                filtrarntFecha = "Stop filtering date";
                btnVolver.Text = "Return";
                lblHorario.Text = "Hours of activity:";
                btnParticipantes.Text = "Participants";
                docente = "Teacher: ";
                lblDocenteParticipantes.Text = docente;
                lblHostParticipantes.Text = "Host: ";
                lblParticipantes.Text = "Participants: ";
                lblBienvenido.Text = "You do not have archived chats";
                horaInicio = "Start Time: ";
                horaFin = "End Time: ";
                fecha = "Date: ";
                error = "  Contact an administrator.";
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
            }
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat blanco.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxLogo.Image = Image.FromFile("Logo Completa.png");
                imagenProfesor = Image.FromFile("profesor.png");
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
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialMensajesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxMaterialDatosClase.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void PrincipalChatAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();

        }

        private void pcbxPrincipalChatNav_Click(object sender, EventArgs e)
        {
            principalChatsAlumno.Show();
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

        private void pcbxHistorialMensajesNav_Click(object sender, EventArgs e)
        {
            historialMensajesAlumno.Show();
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

        
        private void cargarChatsFiltro()
        {
            List<Logica.Chat> chats = new List<Logica.Chat>();
            List<Logica.Chat> chatstemps = new Logica.Chat().SelectHistorialChatsPorCedulaAlumno(Login.encontrado.Ci);

            if (chatstemps.Count != 0)
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

            bool igualesTemps = true;
            if (this.chatsTemps.Count == chatstemps.Count)
            {
                for (int x = 0; x < chatstemps.Count; x++)
                {
                    if (!(chatstemps[x].IdChat == this.chatsTemps[x].IdChat))
                    {
                        igualesTemps = false;
                    }
                }
            }
            else
            {
                igualesTemps = false;
            }
            if (!igualesTemps)
            {
                cmbxAsignatura.Items.Clear();
                asignaturas.Clear();
                foreach (Logica.Chat chat in chatstemps)
                {
                    bool agregar = true;
                    Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(chat.Asignatura);
                    foreach (Logica.Asignatura asig in asignaturas)
                    {
                        if (asi.Id == asig.Id)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar)
                    {

                        asignaturas.Add(asi);
                        cmbxAsignatura.Items.Add(asi.Nombre);
                    }
                }
                this.chatsTemps = chatstemps;
            }


            foreach (Logica.Chat chat in chatstemps)
            {
                bool agregado = false;
                if (filtroAsignatura || filtroFecha)
                {
                    string id = "";
                    if (cmbxAsignatura.SelectedIndex != -1)
                    {
                        id = asignaturas[cmbxAsignatura.SelectedIndex].Id;
                    }
                    if (filtroAsignatura && filtroFecha)
                    {
                            if (chat.Asignatura == id && chat.Fecha.Year == dtpFiltro.Value.Year && chat.Fecha.Month == dtpFiltro.Value.Month && chat.Fecha.Day == dtpFiltro.Value.Day)
                            {
                                chats.Add(chat);
                                agregado = true;
                            }
                    }
                    if (filtroAsignatura && !agregado && !filtroFecha)
                    {
                            if (chat.Asignatura == id)
                            {
                                chats.Add(chat);
                                agregado = true;
                            }
                        
                    }
                    if (filtroFecha && !agregado && !filtroAsignatura)
                    {
                        if (chat.Fecha.Year == dtpFiltro.Value.Year && chat.Fecha.Month == dtpFiltro.Value.Month && chat.Fecha.Day == dtpFiltro.Value.Day)
                        {
                            chats.Add(chat);
                        }
                    }
                }
                else
                {
                    chats.Add(chat);
                }
            }
            bool iguales = true;
            if (this.chats.Count == chats.Count)
            {
                for (int x = 0; x < chats.Count; x++)
                {
                    if (!(chats[x].IdChat == this.chats[x].IdChat))
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
                this.chats = chats;
                int yPanel = 0;
                panelChatsActivos.Controls.Clear();

                foreach (Logica.Chat chat in chats)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(chat.Asignatura);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(chat.IdClase);

                    List<Logica.ChateaDo> chateaDos = new Logica.ChateaDo().SelectChateaDosPorIdChatMasFecha(chat.IdChat, chat.Fecha);

                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(chateaDos[0].Ci);
                    Logica.Docente doc = new Logica.Docente();
                    doc.Nombre = us.Nombre;
                    doc.Primer_apellido = us.Primer_apellido;

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = imagenProfesor;
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + chat.IdChat.ToString();
                    picPhoto.Click += new EventHandler(AbrirChat);

                    Label grupo = new Label();
                    grupo.Height = 83;
                    grupo.Width = 230;
                    grupo.Location = new Point(80, 0);
                    grupo.ForeColor = Color.White;
                    grupo.Font = new Font("Arial", 15.0f);
                    grupo.Name = "lblC" + chat.IdChat.ToString();
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre;
                    grupo.Click += new EventHandler(AbrirChat);

                    Label docente = new Label();
                    docente.Height = 83;
                    docente.Width = 150;
                    docente.Location = new Point(310, 0);
                    docente.ForeColor = Color.White;
                    docente.Font = new Font("Arial", 12.0f);
                    docente.Name = "lblCD" + chat.IdChat.ToString();
                    docente.Text = this.docente+"\n" + doc.Nombre + " " + doc.Primer_apellido;
                    docente.Click += new EventHandler(AbrirChat);

                    Label inicio = new Label();
                    inicio.Height = 83;
                    inicio.Width = 85;
                    inicio.Location = new Point(460, 0);
                    inicio.ForeColor = Color.White;
                    inicio.Font = new Font("Arial", 12.0f);
                    inicio.Name = "lblCI" + chat.IdChat.ToString();
                    inicio.Text = horaInicio + "\n" + chat.HoraInicio.ToString("HH") + ":" + chat.HoraInicio.ToString("mm");
                    inicio.Click += new EventHandler(AbrirChat);

                    Label fin = new Label();
                    fin.Height = 83;
                    fin.Width = 85;
                    fin.Location = new Point(545, 0);
                    fin.ForeColor = Color.White;
                    fin.Font = new Font("Arial", 12.0f);
                    fin.Name = "lblCF" + chat.IdChat.ToString();
                    fin.Text = horaFin + "\n" + chat.HoraFin.ToString("HH") + ":" + chat.HoraFin.ToString("mm");
                    fin.Click += new EventHandler(AbrirChat);

                    Label fecha = new Label();
                    fecha.Height = 83;
                    fecha.Width = 150;
                    fecha.Location = new Point(630, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 12.0f);
                    fecha.Name = "lblCI" + chat.IdChat.ToString();
                    fecha.Text =  this.fecha + "\n" + chat.Fecha.ToString("dd") + "/" + chat.Fecha.ToString("MM") + "/" + chat.Fecha.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirChat);

                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 738;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelC" + chat.IdChat.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirChat);

                    panel.Controls.Add(grupo);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(docente);
                    panel.Controls.Add(inicio);
                    panel.Controls.Add(fin);
                    panel.Controls.Add(fecha);
                    panelChatsActivos.Controls.Add(panel);

                }
            }
        }
        private void cargarChats()
        {
            List<Logica.Chat> chats = new Logica.Chat().SelectHistorialChatsPorCedulaAlumno(Login.encontrado.Ci);

            if (chats.Count != 0)
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
            if (this.chats.Count == chats.Count)
            {
                for (int x = 0; x < chats.Count; x++)
                {
                    if (!(chats[x].IdChat == this.chats[x].IdChat))
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
                cmbxAsignatura.Items.Clear();
                asignaturas.Clear();
                foreach (Logica.Chat chat in chats)
                {
                    bool agregar = true;
                    Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(chat.Asignatura);
                    foreach (Logica.Asignatura asig in asignaturas)
                    {
                        if (asi.Id == asig.Id)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar)
                    {

                        asignaturas.Add(asi);
                        cmbxAsignatura.Items.Add(asi.Nombre);
                    }
                }
                this.chats = chats;
                int yPanel=0;
                panelChatsActivos.Controls.Clear();

                foreach (Logica.Chat chat in chats)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(chat.Asignatura);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(chat.IdClase);

                    List<Logica.ChateaDo> chateaDos = new Logica.ChateaDo().SelectChateaDosPorIdChatMasFecha(chat.IdChat, chat.Fecha);

                    Logica.Usuario doc = new Logica.Usuario().SelectUsuarioCi(chateaDos[0].Ci);

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = imagenProfesor;
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(6, 6);
                    picPhoto.Name = "pbxC" + chat.IdChat.ToString();
                    picPhoto.Click += new EventHandler(AbrirChat);

                    Label grupo = new Label();
                    grupo.Height = 83;
                    grupo.Width = 230;
                    grupo.Location = new Point(80, 0);
                    grupo.ForeColor = Color.White;
                    grupo.Font = new Font("Arial", 15.0f);
                    grupo.Name = "lblC" + chat.IdChat.ToString();
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre;
                    grupo.Click += new EventHandler(AbrirChat);
                    
                    Label docente = new Label();
                    docente.Height = 83;
                    docente.Width = 150;
                    docente.Location = new Point(310, 0);
                    docente.ForeColor = Color.White;
                    docente.Font = new Font("Arial", 12.0f);
                    docente.Name = "lblCD" + chat.IdChat.ToString();
                    docente.Text = this.docente + "\n" + doc.Nombre + " " + doc.Primer_apellido;
                    docente.Click += new EventHandler(AbrirChat);
                    
                    Label inicio = new Label();
                    inicio.Height = 83;
                    inicio.Width = 85;
                    inicio.Location = new Point(460, 0);
                    inicio.ForeColor = Color.White;
                    inicio.Font = new Font("Arial", 12.0f);
                    inicio.Name = "lblCI" + chat.IdChat.ToString();
                    inicio.Text = horaInicio + "\n" + chat.HoraInicio.ToString("HH") + ":" + chat.HoraInicio.ToString("mm");
                    inicio.Click += new EventHandler(AbrirChat);

                    Label fin = new Label();
                    fin.Height = 83;
                    fin.Width = 85;
                    fin.Location = new Point(545, 0);
                    fin.ForeColor = Color.White;
                    fin.Font = new Font("Arial", 12.0f);
                    fin.Name = "lblCF" + chat.IdChat.ToString();
                    fin.Text = horaFin + "\n" + chat.HoraFin.ToString("HH") + ":" + chat.HoraFin.ToString("mm");
                    fin.Click += new EventHandler(AbrirChat);

                    Label fecha = new Label();
                    fecha.Height = 83;
                    fecha.Width = 150;
                    fecha.Location = new Point(630, 0);
                    fecha.ForeColor = Color.White;
                    fecha.Font = new Font("Arial", 12.0f);
                    fecha.Name = "lblCI" + chat.IdChat.ToString();
                    fecha.Text = this.fecha + "\n" + chat.Fecha.ToString("dd") +"/"+ chat.Fecha.ToString("MM") + "/" + chat.Fecha.ToString("yyyy");
                    fecha.Click += new EventHandler(AbrirChat);
                    
                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 738;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelC" + chat.IdChat.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirChat);
                    
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(docente);
                    panel.Controls.Add(inicio);
                    panel.Controls.Add(fin);
                    panel.Controls.Add(fecha);
                    panelChatsActivos.Controls.Add(panel);
                }
            }
        }
        private void AbrirChat(object sender, EventArgs e)
        {
            panelCharla.Visible = true;
            panelDatosClase.Visible = true;
            panelParticipantes.Visible = false;
            panelChatsActivos.Visible = false;
            btnFiltrarFecha.Visible = false;
            btnFiltrarAsignatura.Visible = false;
            cmbxAsignatura.Visible = false;
            dtpFiltro.Visible = false;
            btnVolver.Visible = true;

            pcbxMaterialDatosClase.Image = null;
            lblMateriaClaseChat.Text = "";
            lblHoras.Text = "";
            panelCharla.Controls.Clear();

            Logica.Chat chat = new Logica.Chat();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                chat = new Logica.Chat().SelectChatPorId(new Logica.Chat().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                chat = new Logica.Chat().SelectChatPorId(new Logica.Chat().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                chat = new Logica.Chat().SelectChatPorId(new Logica.Chat().StringAId(((Panel)sender).Name));
            }

            Logica.AsignaturaCursa asignaturaCursada = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCiInclusivo(chat.Asignatura, Login.encontrado.Ci);
            Logica.Usuario doc = new Logica.Usuario().SelectUsuarioCi(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(chat.Asignatura, asignaturaCursada.IdClase));

            lblHoras.Text += "\n" + chat.HoraInicio.ToString("HH") + chat.HoraInicio.ToString("mm") + " " + chat.HoraFin.ToString("HH") + chat.HoraFin.ToString("mm");

            lblMateriaClaseChat.Text = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaCursada.AsignaturaCursada).Nombre + " " + new Logica.Clase().SelectClasePorId(chat.IdClase).Anio.ToString() + new Logica.Clase().SelectClasePorId(chat.IdClase).Nombre;
            List<Logica.ChateaAl> mensajesAl = new Logica.ChateaAl().SelectChateaAlsPorIdChatMasFecha(chat.IdChat, chat.Fecha);
            abierto = chat;
            
            pcbxMaterialDatosClase.Image = imagenProfesor;
            tmrCargChat.Enabled = true;
            mensajs.Clear();
        }

        private void btnFiltrarAsignatura_Click(object sender, EventArgs e)
        {
            cmbxAsignatura.Visible = !cmbxAsignatura.Visible;
            filtroAsignatura = !filtroAsignatura;
            btnFiltrarAsignatura.Text = filtrarAsignatura;
            if (filtroAsignatura)
            {
                btnFiltrarAsignatura.Text = filtrarntAsignatura;
            }
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            dtpFiltro.Visible = !dtpFiltro.Visible;
            filtroFecha = !filtroFecha;
            btnFiltrarFecha.Text = filtrarFecha;
            if (filtroFecha)
            {
                btnFiltrarFecha.Text = filtrarntFecha;
            }
        }

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelCharla.Visible = false;
            panelDatosClase.Visible = false;
            panelParticipantes.Visible = false;
            panelChatsActivos.Visible = true;
            btnFiltrarFecha.Visible = true;
            btnFiltrarAsignatura.Visible = true;
            cmbxAsignatura.Visible = filtroAsignatura;
            dtpFiltro.Visible = filtroFecha;
            btnFiltrarAsignatura.Visible = true;
            btnFiltrarFecha.Visible = true;
            btnVolver.Visible = false;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void timerHistorialChats_Tick(object sender, EventArgs e)
        {
            if (filtroAsignatura || filtroFecha)
            {
                cargarChatsFiltro();
            }
            else
            {
                cargarChats();
            }
        }

        public void CargarChat()
        {
            lblTitulo.Text = abierto.Titulo;
            int y;
            List<Logica.Chatea> mensajes = new List<Logica.Chatea>();
            List<Logica.ChateaAl> mensajesAl = new Logica.ChateaAl().SelectChateaAlsPorIdChatMasFecha(abierto.IdChat, abierto.Fecha);
            List<Logica.ChateaDo> mensajesDo = new Logica.ChateaDo().SelectChateaDosPorIdChatMasFecha(abierto.IdChat, abierto.Fecha);
            mensajes.AddRange(mensajesAl);
            for (int x = 0; x < mensajes.Count; x++)
            {
                for (int c = 0; c < mensajesDo.Count; c++)
                {
                    if (mensajes.Count < mensajesAl.Count + mensajesDo.Count && mensajes.Count == x + 1 && !mensajes.Contains(mensajesDo[c]))
                    {
                        try
                        {
                            if (mensajes[x].HoraEnvio > mensajesDo[c].HoraEnvio && !mensajes.Contains(mensajesDo[c]))
                            {
                                mensajes.Insert(x, mensajesDo[c]);
                            }
                            else
                            {
                                mensajes.Add(mensajesDo[c]);
                            }
                        }
                        catch (Exception ex)
                        {
                            mensajes.Add(mensajesDo[c]);
                        }
                    }
                    else
                    {
                        if (mensajes[x].HoraEnvio > mensajesDo[c].HoraEnvio && !mensajes.Contains(mensajesDo[c]))
                        {
                            mensajes.Insert(x, mensajesDo[c]);
                        }
                    }
                }
            }

            if (mensajs.Count < mensajes.Count)
            {
                if ((mensajes.Count - mensajs.Count) > 1)
                {
                    mensajs = mensajes;
                }
                else
                {
                    mensajs.Add(mensajes[mensajs.Count]);
                }
                int xot = 20;
                y = 50;
                int m = 0;
                panelCharla.Controls.Clear();
                foreach (Logica.Chatea cha in mensajs)
                {

                    int xyo = -20;
                    int wyo = 0;
                    int lineas = 2;
                    int ret = (9 * cha.Contenido.Length);
                    if (cha.Contenido.Length > 48)
                    {
                        xyo += -(panelCharla.Size.Width / 3) + (panelCharla.Size.Width * 2 / 3);
                        lineas += cha.Contenido.Length / 48;
                        wyo = (panelCharla.Width * 2 / 3) - 20;
                    }
                    else
                    {

                        if (ret < panelCharla.Width / 6)
                        {
                            ret = panelCharla.Width / 6;
                        }
                        xyo += panelCharla.Width - ret - 20;
                        wyo += ret;
                    }

                    Label dina = new Label();
                    dina.Width = wyo;
                    dina.Height = 20;
                    dina.Location = new Point(xyo, y);
                    dina.ForeColor = Color.Black;
                    dina.BackColor = Color.White;
                    dina.Font = new Font("Arial", 12.0f);

                    if (!(cha.Ci == Login.encontrado.Ci))
                    {
                        dina.Location = new Point(xot, y);
                    }

                    y += 25;

                    for (int i = 0; i < lineas; i++)
                    {
                        y += 20;
                        dina.Height += 20;
                    }
                    dina.Name = "lblMensaje" + m;
                    m++;
                    dina.Text = cha.HoraEnvio.ToString("hh:mm") + " " + new Logica.Usuario().SelectUsuarioCi(cha.Ci).Apodo + "\n";
                    if (cha.Contenido.Length < 48)
                    {
                        for (int l = 0; l < dina.Width / 10; l++)
                        {
                            dina.Text += " -";
                        }
                    }
                    else
                    {
                        for (int l = 0; l < 59; l++)
                        {
                            dina.Text += " -";
                        }
                    }
                    dina.Text += "\n" + cha.Contenido;
                    panelCharla.Controls.Add(dina);
                    panelCharla.VerticalScroll.Value = 0;

                }
                foreach (Logica.Chatea ch in mensajes)
                {
                    panelCharla.VerticalScroll.Value = panelCharla.VerticalScroll.Maximum;
                }
            }

        }



        private void tmrCargChat_Tick(object sender, EventArgs e)
        {
            CargarChat();
        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            panelParticipantes.Visible = !panelParticipantes.Visible;
            if (panelParticipantes.Visible)
            {
                List<Logica.Usuario> usuarios = new Logica.Usuario().SelectParticipantes(abierto.IdChat);
                string docentePart=
                lblDocenteParticipantes.Text = docente + usuarios[1].Nombre + " " + usuarios[1].Primer_apellido;
                lblHostParticipantes.Text = "Host: " + usuarios[0].Nombre + " " + usuarios[0].Primer_apellido;
                int y = 5;
                for(int x=2; x < usuarios.Count; x++)
                {
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    dina.ForeColor = Color.White;
                    dina.Font = new Font("Arial", 12.0f);
                    y += 50;
                    dina.Name = "lblParticipante" + x;
                    dina.Text = "- " + usuarios[x].Nombre + " " + usuarios[x].Primer_apellido;
                    panelParticipantesOrdinarios.Controls.Add(dina);
                }
            }
        }
    }
}
