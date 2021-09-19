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
    public partial class PrincipalChatAlumno : Form
    {
        public Form login;
        public Form mensajesAlumno;
        public Form perfilAlumno;
        int y = 200;
        private List<Logica.Chat> chats = new List<Logica.Chat>();
        private List<Logica.Chatea> mensajs = new List<Logica.Chatea>();
        Logica.Chat abierto = new Logica.Chat();
        Logica.Clase seleccionada = new Logica.Clase();
        private List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
        public PrincipalChatAlumno()
        {
            InitializeComponent();
            Text = "Chat";

            ClientSize = new Size(1280, 720);
            panelChat.Visible = false;
            panelIngresarChat.Visible = false;
            panelNuevoChat.Visible = false;
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
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("archivo faltante (" + ex.Message + ") comuníquese con el administrador.", "Error");

            }

            pbxFotoPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMensajeNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxGruposNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHistorialNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxMaterialDatosClase.SizeMode = PictureBoxSizeMode.StretchImage;
            cmbxMateria.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void PrincipalChatAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
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
        }
        private void cargarChats()
        {
            List<Logica.Chat> chats = new Logica.Chat().SelectChatsActivosPorCedulaAlumno(Login.encontrado.Ci);
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
                y = 5;
                panelChatsActivos.Controls.Clear();

                foreach (Logica.Chat chat in chats)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(chat.Asignatura);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(chat.IdClase);
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblC" + chat.IdChat.ToString();
                    dina.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + "\n" + "Tema actual:" + chat.Titulo;
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(AbrirChat);
                    panelChatsActivos.Controls.Add(dina);
                }
            }
        }
        private void AbrirChat(object sender, EventArgs e)
        {
            panelChat.Visible = true;
            panelNuevoChat.Visible = false;
            panelIngresarChat.Visible = false;
            pcbxMaterialDatosClase.Image = null;
            lblMateriaClaseChat.Text = "";
            lblHoras.Text = "";
            panelCharla.Controls.Clear();
            txtMensajeChat.Text = "";

            Logica.Chat chat = new Logica.Chat().SelectChatPorId(new Logica.Chat().StringAId(((Label)sender).Name));
            Logica.Agenda agenda = new Logica.Agenda().SelectAgendaConCi(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(chat.Asignatura, chat.IdClase));
            lblMateriaClaseChat.Text = ((Label)sender).Text;
            lblHoras.Text += agenda.HoraInicio + " " + agenda.HoraFin;

            pcbxMaterialDatosClase.Image = Image.FromFile("profesor.png");
            abierto = chat;
            tmrCargChat.Enabled = true;
            mensajs.Clear();

        }
        public void CargarChat()
        {
            
            int y;
            List<Logica.Chatea> mensajes = new List<Logica.Chatea>();
            List<Logica.ChateaAl> mensajesAl = new Logica.ChateaAl().SelectChateaAlsPorIdChatMasFecha(abierto.IdChat, abierto.Fecha);
            List<Logica.ChateaDo> mensajesDo = new Logica.ChateaDo().SelectChateaDosPorIdChatMasFecha(abierto.IdChat, abierto.Fecha);
            mensajes.AddRange(mensajesAl);
            
            for (int x = 0; x < mensajes.Count; x++)
            {
                for (int c = 0; c < mensajesDo.Count; c++)
                {
                    if (mensajes.Count < mensajesAl.Count + mensajesDo.Count && mensajes.Count == x+1 && !mensajes.Contains(mensajesDo[c]))
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
                    else {
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

        private void btnNuevoChat_Click(object sender, EventArgs e)
        {
            panelNuevoChat.Visible = !panelNuevoChat.Visible;
            panelIngresarChat.Visible = false;
            
            asignaturas = new Logica.Asignatura().SelectAsignaturasPorCi(Login.encontrado.Ci);
            
            foreach (Logica.Asignatura asignatura in asignaturas)
            {
                Logica.AsignaturaCursa asignaturaCursada = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCi(asignatura.Id, Login.encontrado.Ci);
                Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaCursada.IdClase);
                cmbxMateria.Items.Add(asignatura.Nombre + " " + clase.Anio+clase.Nombre);
            }
            
        }

        private void btnIngresarChat_Click(object sender, EventArgs e)
        {
            panelIngresarChat.Visible = !panelIngresarChat.Visible;
            panelNuevoChat.Visible = false;
        }

        private void btnRealizarNuevoChat_Click(object sender, EventArgs e)
        {
            
            if (cmbxMateria.SelectedIndex!=-1)
            {
                Logica.SolicitaChat solicitaChat = new Logica.SolicitaChat();
                solicitaChat.CiAlumno = Login.encontrado.Ci;
                solicitaChat.Asignatura = asignaturas[cmbxMateria.SelectedIndex].Id;
                Logica.AsignaturaCursa asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCi(asignaturas[cmbxMateria.SelectedIndex].Id, Login.encontrado.Ci);
                solicitaChat.IdClase = asignaturaCursa.IdClase;
                solicitaChat.FechaHora = DateTime.Now;
                solicitaChat.Pendiente = true;
                solicitaChat.OriClase = asignaturaCursa.Orientacion;
                solicitaChat.CiDocente =new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(asignaturaCursa.AsignaturaCursada, asignaturaCursa.IdClase);
                solicitaChat.EnviarSolicitudChat();
                MessageBox.Show("Solicitud enviada");
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            new Logica.ChateaAl(Login.encontrado.Ci, abierto.IdChat, DateTime.Now, txtMensajeChat.Text).InsertChateaAl();
            txtMensajeChat.Text = "";
        }

        private void btnCerrarChat_Click(object sender, EventArgs e)
        {

        }
    }
}
