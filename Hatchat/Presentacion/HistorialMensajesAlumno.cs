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
        private List<Logica.Docente> docentes = new List<Logica.Docente>();
        private List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();

        public Form login;
        public Form principalChatAlumno;
        public Form mensajesAlumno;
        public Form gruposAlumno;
        public Form perfilAlumno;
        public Form historialChatsAlumno;
        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;

        int y = 50;
        bool filtroDocente = false;
        bool filtroFecha = false;

        public HistorialMensajesAlumno()
        {
            InitializeComponent();
            Text = "Mensajes";


            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;

            //nav
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("mensaje blanco.png");
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
            pcbxHistorialChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialMensajesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;


            cmbxDocentes.DropDownStyle = ComboBoxStyle.DropDownList;

            lblRespuestaDocente.Size = new Size(541, 107);
            lblMensajeAlumno.Size = new Size(541, 107);
            CargarMensajes();
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
            lblMensajeAlumno.Text = "";

            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";
            lblRespuestaDocente.Text = "";

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
            lblMensajeAlumno.Text = men.MensajeAlumno;
            pbxAlumno.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            pbxDocente.Image = docente.ByteArrayToImage(docente.FotoDePerfil);
            if (!(men.Estado == "realizado"))
            {
                lblFechaDocente.Text += "\n" + men.FechaHoraDocente.ToString("dd:MM:yyyy");
                lblHoraDocente.Text += "\n" + men.FechaHoraDocente.ToString("HH:mm");
            }
            lblRespuestaDocente.Text = men.MensajeDocente;

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
        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
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
            List<Logica.Mensaje> mensajes = new Logica.Mensaje().SelectMensajesRecibidosAl(Login.encontrado.Ci);
            cmbxDocentes.Items.Clear();
            docentes.Clear();
            foreach (Logica.Mensaje men in mensajes)
            {
                bool agregar = true;
                Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                foreach(Logica.Docente doce in docentes)
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
            y = 50;
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
                this.mensajes = mensajes;
                panelNavMensajes.Controls.Clear();
            panelContenedor.Visible = false;
                foreach (Logica.Mensaje men in mensajes)
                {
                    this.mensajes = mensajes;
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
        }
            private void CargarMensajesFiltro()
        {
            List<Logica.Mensaje> mensajes = new List<Logica.Mensaje>();
            List<Logica.Mensaje> mensTemp = new Logica.Mensaje().SelectMensajesRecibidosAl(Login.encontrado.Ci);
            cmbxDocentes.Items.Clear();
            docentes.Clear();
            foreach (Logica.Mensaje men in mensTemp)
            {
                Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(men.Docente);
                Logica.Docente doc = new Logica.Docente(us.Ci, us.Nombre, us.Primer_apellido, us.Segundo_apellido, us.FotoDePerfil, us.Apodo, us.Activo);
                docentes.Add(doc);
                cmbxDocentes.Items.Add(doc.Nombre + " " + doc.Primer_apellido);
            }
            y = 50;


            foreach (Logica.Mensaje men in mensTemp)
            {
                bool agregado = false;
                if (filtroDocente || filtroFecha)
                {
                    if (filtroDocente && filtroFecha)
                    {
                        if ((men.Docente == docentes[cmbxDocentes.SelectedIndex].Ci) && ((men.FechaHoraAlumno.Year == dtpFiltro.Value.Year && men.FechaHoraAlumno.Month == dtpFiltro.Value.Month && men.FechaHoraAlumno.Day == dtpFiltro.Value.Day) || (men.FechaHoraDocente.Year == dtpFiltro.Value.Year && men.FechaHoraDocente.Month == dtpFiltro.Value.Month && men.FechaHoraDocente.Day == dtpFiltro.Value.Day)))
                        {
                            mensajes.Add(men);
                            agregado = true;
                        }
                    }
                    if (filtroDocente && !agregado)
                    {
                        if (men.Docente == docentes[cmbxDocentes.SelectedIndex].Ci)
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
                this.mensajes = mensajes;
                panelNavMensajes.Controls.Clear();
                panelContenedor.Visible = false;
                foreach (Logica.Mensaje men in mensajes)
                {
                    this.mensajes = mensajes;
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
        }

        private void btnFiltrarDocente_Click(object sender, EventArgs e)
        {
            filtroDocente = !filtroDocente;
            btnFiltrarDocente.Text = "Filtrar docente";
            if (filtroDocente)
            {
                btnFiltrarDocente.Text = "Dejar de filtrar docente";
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
            btnFiltrarFecha.Text = "Filtrar fecha";
            if (filtroFecha)
            {
                btnFiltrarFecha.Text = "Dejar de filtrar fecha";
            }
        }


    }
}
