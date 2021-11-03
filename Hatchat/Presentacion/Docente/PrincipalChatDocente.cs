using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class PrincipalChatDocente : Form
    {
        public Form login;
        public Form mensajesDocente;
        public Form perfilDocente;
        public Form gruposDocente;
        public Form historialChatsDocente;
        public Form historialMensajesDocente;

        private List<Logica.Chat> chats = new List<Logica.Chat>();
        private List<Logica.SolicitaChat> solicitaChats = new List<Logica.SolicitaChat>();
        private List<Logica.Chatea> mensajs = new List<Logica.Chatea>();
        Logica.Chat abierto = new Logica.Chat();
        private List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();

        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        public PrincipalChatDocente()
        {
            InitializeComponent();

            Text = "Chat"; 
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            ClientSize = new Size(1280, 720);
            panelChat.Visible = false;
            panelChatsAIngresar.Visible = false;
            StartPosition = FormStartPosition.CenterScreen;
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxChatNav.Image = Image.FromFile("chat blanco.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                pcbxBotonEnviar.Image = Image.FromFile("enviar.png");
                pcbxDesplegarSolicitudes.Image= Image.FromFile("flecha blanca desplegar.png");
                pcbxNotificacion.Image = Image.FromFile("circulo gris.png");
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
            pcbxHistorialChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialMensajesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxMaterialDatosClase.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxBotonEnviar.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxDesplegarSolicitudes.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxNotificacion.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PrincipalChatDocente_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxMensajeNav_Click(object sender, EventArgs e)
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
        private void tmrActChats_Tick(object sender, EventArgs e)
        {
            cargarChats();
            foreach (Logica.Chat chat in chats)
            {
                if (chat.Fecha.Day != DateTime.Now.Day || chat.Fecha.Month != DateTime.Now.Month || chat.Fecha.Year != DateTime.Now.Year)
                {
                    chat.CerrarChat();
                }
            }
        }
        private void cargarChats()
        {
            List<Logica.Chat> chats = new Logica.Chat().SelectChatsActivosPorCedulaDocente(Login.encontrado.Ci);
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

                    Label grupo = new Label();
                    grupo.Height = 58;
                    grupo.Width = 150;
                    grupo.Location = new Point(91, 0);
                    grupo.ForeColor = Color.White;
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lblC" + chat.IdChat.ToString();
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + "\n" + "Tema actual:" + chat.Titulo;
                    grupo.Click += new EventHandler(AbrirChat);

                    PictureBox picPhoto = new PictureBox();
                    picPhoto.Image = Image.FromFile("profesor.png");
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Height = 69;
                    picPhoto.Width = 69;
                    picPhoto.Location = new Point(12, 12);
                    picPhoto.Name = "pbxC" + chat.IdChat.ToString();
                    picPhoto.Click += new EventHandler(AbrirChat);

                    PictureBox picflecha = new PictureBox();
                    picflecha.Image = Image.FromFile("flecha blanca entrar.png");
                    picflecha.SizeMode = PictureBoxSizeMode.StretchImage;
                    picflecha.Height = 69;
                    picflecha.Width = 69;
                    picflecha.Location = new Point(249, 12);
                    picflecha.Name = "pbxC" + chat.IdChat.ToString();
                    picflecha.Click += new EventHandler(AbrirChat);

                    Panel panel = new Panel();
                    panel.Height = 83;
                    panel.Width = 319;
                    panel.Location = new Point(0, yPanel);
                    yPanel += 83;
                    panel.Name = "panelC" + chat.IdChat.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += new EventHandler(AbrirChat);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(picPhoto);
                    panel.Controls.Add(picflecha);

                    panelChatsActivos.Controls.Add(panel);
                }
            }
        }
        private void AbrirChat(object sender, EventArgs e)
        {
            panelChat.Visible = true;
            pcbxMaterialDatosClase.Image = null;
            lblMateriaClaseChat.Text = "";
            lblHoras.Text = "";
            panelCharla.Controls.Clear();
            txtMensajeChat.Text = "";

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
            Logica.AsignaturaDictada asignaturaDciatada = new Logica.AsignaturaDictada().SelectAsignaturaDictadaPorAsignaturaYCi(chat.Asignatura, Login.encontrado.Ci);
            List<Logica.Agenda> agendas = new Logica.Agenda().SelectAgendasPorCi(Login.encontrado.Ci);
            foreach (Logica.Agenda ag in agendas)
            {
                if (ag.EnHora(ag))
                {
                    lblHoras.Text += ag.HoraInicio + " " + ag.HoraFin;
                }
            }

            lblMateriaClaseChat.Text = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaDciatada.AsigDictada).Nombre + " " + new Logica.Clase().SelectClasePorId(chat.IdClase).Anio.ToString() + new Logica.Clase().SelectClasePorId(chat.IdClase).Nombre;

            pcbxMaterialDatosClase.Image = Image.FromFile("profesor.png");
            abierto = chat;
            tmrCargChat.Enabled = true;
            mensajs.Clear();

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
            CerrarChat();
        }
        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            panelChatsAIngresar.Visible = !panelChatsAIngresar.Visible;
            if (panelChatsAIngresar.Visible)
            {
                pcbxDesplegarSolicitudes.Image = Image.FromFile("flecha blanca contraer.png");
            }
            else
            {
                pcbxDesplegarSolicitudes.Image = Image.FromFile("flecha blanca desplegar.png");
            }
        }
        
        private void AceptarSolicitud(object sender, EventArgs e)
        {
            
                string id = "";
                for(int x = 4; x < ((Button)sender).Name.Length; x++)
                {
                    if (!(((Button)sender).Name[x] == '-'))
                    {
                        id += ((Button)sender).Name[x];
                    }
                    else
                    {
                        x = ((Button)sender).Name.Length;
                    }
                }
            solicitaChats[Convert.ToInt32(id)].AceptarChat();
            new Logica.Chat().CrearChat(solicitaChats[Convert.ToInt32(id)]);
        }
        private void DenegarSolicitud(object sender, EventArgs e)
        {

            string id = "";
            for (int x = 4; x < ((Button)sender).Name.Length; x++)
            {
                if (!(((Button)sender).Name[x] == '-'))
                {
                    id += ((Button)sender).Name[x];
                }
                else
                {
                    x = ((Button)sender).Name.Length;
                }
            }
            solicitaChats[Convert.ToInt32(id)].DenegarChat();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            new Logica.ChateaDo(Login.encontrado.Ci, abierto.IdChat, DateTime.Now, txtMensajeChat.Text).InsertChateaDo();
            txtMensajeChat.Text = "";
        }

        private void timerSolicitudes_Tick(object sender, EventArgs e)
        {
            List<Logica.SolicitaChat> solicitaChats = new Logica.SolicitaChat().SelectSolicitaChats(Login.encontrado.Ci);
            if (solicitaChats.Count == 0)
            {
                pcbxNotificacion.Image= Image.FromFile("circulo gris.png");
                if (panelChatsAIngresar.Controls.Count == 0)
                {
                    Label dina = new Label();
                    dina.Height = 58;
                    dina.Width = 300;
                    dina.Location = new Point(10, 30);
                    dina.ForeColor = Color.White;
                    dina.Font = new Font("Arial", 12.0f);
                    dina.Name = "lblVacia";
                    dina.Text = "No hay solicitudes pendientes";
                    panelChatsAIngresar.Controls.Add(dina);
                }

            }
            else
            {
                pcbxNotificacion.Image = Image.FromFile("circulo recibido.png");
            }
            bool iguales = true;
            if (this.solicitaChats.Count == solicitaChats.Count)
            {
                for (int x = 0; x < solicitaChats.Count; x++)
                {
                    if (!(solicitaChats[x].CiAlumno == this.solicitaChats[x].CiAlumno && solicitaChats[x].CiDocente == this.solicitaChats[x].CiDocente && solicitaChats[x].FechaHora == this.solicitaChats[x].FechaHora && solicitaChats[x].IdClase == this.solicitaChats[x].IdClase && solicitaChats[x].OriClase == this.solicitaChats[x].OriClase && solicitaChats[x].Asignatura == this.solicitaChats[x].Asignatura))
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
                int yPanel = 0;
                this.solicitaChats = solicitaChats;
                panelChatsAIngresar.Controls.Clear();
                int m = 0;
                foreach (Logica.SolicitaChat solicitaChat in solicitaChats)
                {
                    if (panelChatsAIngresar.Controls.Count != solicitaChats.Count)
                    {
                        Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(solicitaChat.Asignatura);
                        asignaturas.Add(asignatura);
                        Logica.Clase clase = new Logica.Clase().SelectClasePorId(solicitaChat.IdClase);
                        Logica.Orientacion ori = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);

                        PictureBox picPhoto = new PictureBox();
                        picPhoto.Image = Image.FromFile("profesor.png");
                        picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        picPhoto.Height = 40;
                        picPhoto.Width = 40;
                        picPhoto.Location = new Point(6, 5);
                        picPhoto.Name = "pbxS" + m;

                        Label grupo = new Label();
                        grupo.Height = 58;
                        grupo.Width = 150;
                        grupo.Location = new Point(50, 0);
                        grupo.ForeColor = Color.White;
                        grupo.Font = new Font("Arial", 8.0f);
                        grupo.Name = "lblS" + m;
                        grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + "\n" + ori.Nombre;

                        Button button = new Button();
                        button.ForeColor = Color.White;
                        button.Height = 23;
                        button.Width = 100;
                        button.Location = new Point(210, 1);
                        button.Font = new Font("Arial", 8.0f);
                        button.BackColor = Color.FromArgb(125, 116, 110);
                        button.FlatStyle = FlatStyle.Popup;
                        button.Name = "bnAS" + m;
                        button.Text = "Aceptar";
                        button.Click += new EventHandler(AceptarSolicitud);

                        Button button1 = new Button();
                        button1.ForeColor = Color.White;
                        button1.Height = 23;
                        button1.Width = 100;
                        button1.Location = new Point(210, 25);
                        button1.Font = new Font("Arial", 8.0f);
                        button1.BackColor = Color.FromArgb(125, 116, 110);
                        button1.FlatStyle = FlatStyle.Popup;
                        button1.Name = "bnDS" + m;
                        button1.Text = "Denegar";
                        button1.Click += new EventHandler(DenegarSolicitud);

                        Panel panel = new Panel();
                        panel.Height = 50;
                        panel.Width = 319;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 50;
                        panel.Name = "pnlS" + m;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Controls.Add(grupo);
                        panel.Controls.Add(picPhoto);
                        panel.Controls.Add(button);
                        panel.Controls.Add(button1);
                        panelChatsAIngresar.Controls.Add(panel);
                        m++;
                    }
                }
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void CerrarChat()
        {

            if (!(abierto == new Logica.Chat()))
            {
                bool cerrar = true;
                foreach (Logica.Chat chat in chats)
                {
                    if (chat.IdChat == abierto.IdChat)
                    {
                        cerrar = false;
                    }
                }
                if (cerrar)
                {
                    panelChat.Visible = false;
                    tmrCargChat.Enabled = false;
                    MessageBox.Show("Este chat a sido cerrado");
                }
            }
        }
        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            panelParticipantes.Visible = !panelParticipantes.Visible;
            if (panelParticipantes.Visible)
            {
                List<Logica.Usuario> usuarios = new Logica.Usuario().SelectParticipantes(abierto.IdChat);
                lblDocenteParticipantes.Text = "Docente: " + usuarios[1].Nombre + " " + usuarios[1].Primer_apellido;
                lblHostParticipantes.Text = "Host: " + usuarios[0].Nombre + " " + usuarios[0].Primer_apellido;
                int y = 5;
                for (int x = 2; x < usuarios.Count; x++)
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
        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
        }
    }
}

