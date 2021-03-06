using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class GruposDocente : Form
    {
        string error;
        string profesor;
        string horario;
        string horariosLunes;
        string horariosMartes;
        string horariosMiercoles;
        string horariosJueves;
        string horariosViernes;
        string msgSalirDelGrupo;
        string titSalirDelGrupo;
        string salisteDelGrupo;
        string errorSolicitud;
        string soliIngreso;
        string alMenosUna;
        string msgCerrarSesion;
        string cerrarSesionTitulo;
        Image imgProfesor;

        public Form login;
        public Form principalChatDocente;
        public Form mensajesDocente;
        public Form perfilDocente;
        public Form historialChatsDocente;
        public Form historialMensajesDocente;
        private bool enHistorial = false, enPanel = false, enHistorialChat, enHistorialMensaje = false;

        Logica.AsignaturaDictada asignaturaDictada = new Logica.AsignaturaDictada();
        List<Logica.AsignaturaDictada> asignaturaDictadas = new List<Logica.AsignaturaDictada>();
        List<Logica.Clase> clasesDisponibles = new List<Logica.Clase>();
        List<Logica.Agenda> agendas = new List<Logica.Agenda>();

        List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();
        List<Logica.Asignatura> nuevasAsignaturas = new List<Logica.Asignatura>();
        Logica.Clase claseSeleccionada = new Logica.Clase();
        Logica.SolicitudClaseDo solicitudClaseDo = new Logica.SolicitudClaseDo();
        Logica.ClaseSolicitudClaseDo claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();

        public GruposDocente()
        {
            InitializeComponent();
            Text = "Grupos";

            ClientSize = new Size(1280, 720);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            if (Login.idioma == "Español")
            {
                lblGrupos.Text = "Grupos";
                btnEntrarGrupo.Text = "Entrar a un grupo";
                lblOrientacion.Text = "Orientación:";
                lblAnio.Text = "Año:";
                lblClase.Text = "Clase";
                btnModificarGrupo.Text = "Modificar";
                btnRealizar.Text = "Enviar";
                lblDisponibles.Text = "Disponibles:";
                btnLunes.Text = "Lunes";
                btnMartes.Text = "Martes";
                btnMiercoles.Text = "Miercoles";
                btnJueves.Text = "Jueves";
                btnViernes.Text = "Viernes";
                lblSinNada.Text = "Usted no se encuentra en ningun grupo.";
                btnSalirGrupo.Text = "Salir del grupo";
                btnParticipantes.Text = "Participantes";
                lblParticipantes.Text = "Participantes";
                error = " comuníquese con el administrador.";
                profesor = "Profesor: ";
                horariosLunes = "Horarios del dia: Lunes:";
                horariosMartes = "Horarios del dia: Martes:";
                horariosMiercoles = "Horarios del dia: Miercoles:";
                horariosJueves = "Horarios del dia: Jueves:";
                horariosViernes = "Horarios del dia: Viernes:";
                msgSalirDelGrupo = "¿Desea salir del grupo?";
                titSalirDelGrupo = "Salir del grupo";
                salisteDelGrupo = "Se ha salido del grupo correctamente";
                errorSolicitud = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas:";
                soliIngreso = "Se ha enviado la solicitud de ingreso";
                alMenosUna = "Debe ingresar al menos una asignatura para solicitar el ingreso a la clase";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";
                horario = "Horarios del dia: ";
                lblHorariosDelDia.Text = horario;
            }
            else
            {
                lblGrupos.Text = "Groups";
                btnEntrarGrupo.Text = "Join a group";
                lblOrientacion.Text = "Orientation:";
                lblAnio.Text = "Year:";
                lblClase.Text = "Class";
                btnModificarGrupo.Text = "Modify";
                btnRealizar.Text = "Send";
                lblDisponibles.Text = "Available:";
                btnLunes.Text = "Monday";
                btnMartes.Text = "Tuesday";
                btnMiercoles.Text = "Wednesday";
                btnJueves.Text = "Thursday";
                btnViernes.Text = "Friday";
                lblSinNada.Text = "You are not in any group.";
                btnSalirGrupo.Text = "Leave the group";
                btnParticipantes.Text = "Participants";
                lblParticipantes.Text = "Participants";
                error = " Contact an administrator.";
                profesor = "Teacher: ";
                horariosLunes = "Hours of the day: Monday:";
                horariosMartes = "Hours of the day: Tuesday:";
                horariosMiercoles = "Hours of the day: Wednesday:";
                horariosJueves = "Hours of the day: Thursday:";
                horariosViernes = "Hours of the day: Friday:";
                msgSalirDelGrupo = "Do you want to leave the group?";
                titSalirDelGrupo = "Leave the group";
                salisteDelGrupo = "You have successfully left the group";
                errorSolicitud = "Request denied, already on request to enter the following subjects:";
                soliIngreso = "The application for admission has been sent";
                alMenosUna = "You must enter at least one subject to request entry to the class";
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
                horario = "Hours of the day: ";
                lblHorariosDelDia.Text = horario;
            }
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos blanco.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxLogo.Image = Image.FromFile("Logo Completa.png");
                imgProfesor = Image.FromFile("profesor.png");
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
            pcbxProfesor.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

            cmbxAnio.Items.Add(1);
            cmbxAnio.Items.Add(2);
            cmbxAnio.Items.Add(3);
        }

        private void PerfilAlumno_Load(object sender, EventArgs e)
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

        private void timerGrupos_Tick(object sender, EventArgs e)
        {
            List<Logica.AsignaturaDictada> asignaturaDictadas = new Logica.AsignaturaDictada().SelectAsignaturasDictadasPorCi(Login.encontrado.Ci);

            if (asignaturaDictadas.Count != 0)
            {
                lblLinea.Visible = false;
                lblSinNada.Visible = false;
                pcbxLogo.Visible = false;
            }
            else
            {
                lblLinea.Visible = true;
                lblSinNada.Visible = true;
                pcbxLogo.Visible = true;
            }

            bool iguales = true;
            if (this.asignaturaDictadas.Count == asignaturaDictadas.Count)
            {
                for (int x = 0; x < asignaturaDictadas.Count; x++)
                {
                    if (!(asignaturaDictadas[x].Ci == this.asignaturaDictadas[x].Ci && asignaturaDictadas[x].IdClase == this.asignaturaDictadas[x].IdClase && asignaturaDictadas[x].Orientacion == this.asignaturaDictadas[x].Orientacion && asignaturaDictadas[x].Anio == this.asignaturaDictadas[x].Anio && asignaturaDictadas[x].AsigDictada == this.asignaturaDictadas[x].AsigDictada))
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

                this.asignaturaDictadas = asignaturaDictadas;
                int xpanel = 63, ypanel = 25;
                panelContenedorGrupos.Controls.Clear();

                foreach (Logica.AsignaturaDictada asignaturaDictada in asignaturaDictadas)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaDictada.AsigDictada);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaDictada.IdClase);
                    Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);

                    Label grupo = new Label();
                    grupo.Height = 200;
                    grupo.Width = 150;
                    grupo.Location = new Point(25, 110);
                    grupo.Name = "lbl" + asignaturaDictada.AsigDictada;
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " + orientacion.Nombre;
                    grupo.Click += new EventHandler(AbrirGrupo);

                    PictureBox pic = new PictureBox();
                    pic.Image = imgProfesor;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 80;
                    pic.Width = 80;
                    pic.Location = new Point(60, 20);
                    pic.Name = "pbx" + asignaturaDictada.AsigDictada;
                    pic.Click += new EventHandler(AbrirGrupo);

                    Panel panel = new Panel();
                    panel.Height = 200;
                    panel.Width = 200;
                    panel.Location = new Point(xpanel, ypanel);
                    if (xpanel == 631)
                    {
                        xpanel = -221;
                        ypanel += 225;
                    }
                    xpanel += 284;
                    panel.Name = "pnl" + asignaturaDictada.AsigDictada;
                    panel.BackColor = Color.White;
                    panel.Click += new EventHandler(AbrirGrupo);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(pic);

                    panelContenedorGrupos.Controls.Add(panel);
                }
            }
        }
        private void AbrirGrupo(object sender, EventArgs e)
        {
            panelInformacion.Visible = true;
            panelNav.Enabled = false;
            btnEntrarGrupo.Enabled = false;
            panelEntrarGrupo.Enabled = false;
            panelContenedorGrupos.Enabled = false;
            asignaturaDictada = new Logica.AsignaturaDictada();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                asignaturaDictada = new Logica.AsignaturaDictada().SelectAsignaturaDictadaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Label)sender).Name), Login.encontrado.Ci);
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                asignaturaDictada = new Logica.AsignaturaDictada().SelectAsignaturaDictadaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((PictureBox)sender).Name), Login.encontrado.Ci);
            }
            else
            {
                asignaturaDictada = new Logica.AsignaturaDictada().SelectAsignaturaDictadaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Panel)sender).Name), Login.encontrado.Ci);
            }
            Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaDictada.IdClase);
            Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
            Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaDictada.AsigDictada);
            lblNombreProfesor.Text = profesor + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido;
            pcbxProfesor.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            lblAsignatura.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " + orientacion.Nombre;
            agendas = new Logica.Agenda().SelectAgendasPorCi(Login.encontrado.Ci);


        }
        private void btnLunes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(239, 136, 88);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Lunes");
            lblHorariosDelDia.Text = horariosLunes;
        }


        private void btnMartes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(239, 136, 88);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Martes");
            lblHorariosDelDia.Text = horariosMartes;
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(239, 136, 88);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Miercoles");
            lblHorariosDelDia.Text = horariosMiercoles;
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(239, 136, 88);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Jueves");
            lblHorariosDelDia.Text = horariosJueves;
        }

        private void btnViernes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(239, 136, 88);
            RecargarAgendaDelDia("Viernes");
            lblHorariosDelDia.Text = horariosViernes;
        }
        private void RecargarAgendaDelDia(string dia)
        {
            int ypanel = 0;
            panelHorariosPorDia.Controls.Clear();
            foreach (Logica.Agenda agenda in agendas)
            {
                if (agenda.NomDia == dia)
                {

                    Label linea = new Label();
                    linea.Height = 18;
                    linea.Width = 170;
                    linea.Location = new Point(0, 2);
                    linea.Font = new Font("Arial", 12, FontStyle.Bold);
                    linea.ForeColor = Color.White;
                    linea.Name = "lblLineaAgendaDelDia" + agenda.IdAgenda.ToString();
                    linea.Text = "_______________________________________________";

                    Label horario = new Label();
                    horario.Height = 18;
                    horario.Width = 150;
                    horario.Location = new Point(10, 0);
                    horario.Font = new Font("Arial", 12.0f);
                    horario.ForeColor = Color.White;
                    horario.Name = "lblAgendaDelDia" + agenda.IdAgenda.ToString();
                    horario.Text = agenda.HoraInicio + " - " + agenda.HoraFin;



                    Panel panel = new Panel();
                    panel.Height = 20;
                    panel.Width = 288;
                    panel.Location = new Point(0, ypanel);
                    ypanel += 20;
                    panel.Name = "pnl" + agenda.IdAgenda.ToString();
                    panel.BackColor = Color.FromArgb(61, 53, 50);

                    panel.Controls.Add(horario);
                    panel.Controls.Add(linea);

                    panelHorariosPorDia.Controls.Add(panel);

                }
            }
        }

        private void btnCerrarInformacion_Click(object sender, EventArgs e)
        {
            panelInformacion.Visible = false;
            panelParticipantes.Visible = false;
            panelNav.Enabled = true;
            btnCerrarInformacion.Enabled = true;
            btnEntrarGrupo.Enabled = true;
            panelEntrarGrupo.Enabled = true;
            panelContenedorGrupos.Enabled = true;
            panelHorariosPorDia.Controls.Clear();
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            lblHorariosDelDia.Text = horario;

        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            panelParticipantes.Visible = !panelParticipantes.Visible;
            if (panelParticipantes.Visible)
            {
                panelParticipantesOrdinarios.Controls.Clear();
                List<Logica.Usuario> usuarios = new Logica.Usuario().SelectParticipantesGrupo(asignaturaDictada);
                int y = 5;
                for (int x = 0; x < usuarios.Count; x++)
                {
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 310;
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

        private void btnSalirGrupo_Click(object sender, EventArgs e)
        {
            DialogResult salirGrupo = MessageBox.Show(msgSalirDelGrupo, titSalirDelGrupo, MessageBoxButtons.YesNo);
            if (salirGrupo == DialogResult.Yes)
            {
                asignaturaDictada.BajaGrupo();
                MessageBox.Show(salisteDelGrupo);
                panelInformacion.Visible = false;
                panelParticipantes.Visible = false;
                panelNav.Enabled = true;
                btnCerrarInformacion.Enabled = true;
                btnEntrarGrupo.Enabled = true;
                panelContenedorGrupos.Enabled = true;
            }
        }

        private void btnEntrarGrupo_Click(object sender, EventArgs e)
        {
            panelEntrarGrupo.Visible = !panelEntrarGrupo.Visible;
            solicitudClaseDo = new Logica.SolicitudClaseDo();
            claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
            asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            clasesDisponibles = new List<Logica.Clase>();
            claseSeleccionada = new Logica.Clase();
            orientaciones = new List<Logica.Orientacion>();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            cmbxOrientacion.Items.Clear();
            cmbxAnio.Items.Clear();
            cmbxAnio.Enabled = false;
            cmbxClase.Items.Clear();
            cmbxClase.Enabled = false;
            btnModificarGrupo.Enabled = false;
            panelAsignaturas.Controls.Clear();
            panelAsignaturas.Visible = false;
            btnRealizar.Enabled = false;

            cmbxOrientacion.Items.Clear();
            orientaciones.Clear();
            orientaciones.AddRange(new Logica.Orientacion().SelectOrientaciones());
            foreach (Logica.Orientacion orientacion in orientaciones)
            {
                cmbxOrientacion.Items.Add(orientacion.Nombre);
            }
        }
        private void cmbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            solicitudClaseDo = new Logica.SolicitudClaseDo();
            claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
            asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            clasesDisponibles = new List<Logica.Clase>();
            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            cmbxAnio.Items.Clear();
            cmbxAnio.Enabled = true;
            cmbxClase.Items.Clear();
            cmbxClase.Enabled = false;
            btnModificarGrupo.Enabled = false;
            panelAsignaturas.Controls.Clear();
            panelAsignaturas.Visible = false;
            btnRealizar.Enabled = false;

            if (cmbxOrientacion.SelectedIndex != -1)
            {
                List<int> anios = new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientaciones[cmbxOrientacion.SelectedIndex].Id));


                foreach (int anio in anios)
                {
                    cmbxAnio.Items.Add(anio.ToString());
                }
            }

        }
        private void cmbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            solicitudClaseDo = new Logica.SolicitudClaseDo();
            claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
            asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            clasesDisponibles = new List<Logica.Clase>();
            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            cmbxClase.Items.Clear();
            cmbxClase.Enabled = true;
            btnModificarGrupo.Enabled = false;
            panelAsignaturas.Controls.Clear();
            panelAsignaturas.Visible = false;
            btnRealizar.Enabled = false;

            List<Logica.Clase> clases = new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxAnio.SelectedItem.ToString()));
            List<Logica.AsignaturaDictada> asignaturaDictada = new Logica.AsignaturaDictada().SelectAsignaturasDictadasPorCi(Login.encontrado.Ci);
            foreach (Logica.Clase clase in clases)
            {
                if (clase.Orientacion == orientaciones[cmbxOrientacion.SelectedIndex].Id && clase.Anio == Convert.ToInt32(cmbxAnio.SelectedItem.ToString()))
                {
                    List<Logica.AsignaturaDictada> asignaturasDictando = new List<Logica.AsignaturaDictada>();
                    foreach (Logica.AsignaturaDictada asigDic in asignaturaDictada)
                    {
                        if (asigDic.IdClase == clase.IdClase)
                        {
                            asignaturasDictando.Add(asigDic);
                        }
                    }
                    List<Logica.Asignatura> asignaturasClase = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(clase.Nombre, clase.Anio, clase.Orientacion);
                    if (asignaturasDictando.Count < asignaturasClase.Count)
                    {
                        if (asignaturasDictando.Count == 0)
                        {
                            bool dictandoAnioOrientacion = false;
                            foreach (Logica.AsignaturaDictada asigDic in asignaturaDictada)
                            {
                                Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigDic.AsigDictada);
                                if (asigDic.Orientacion == clase.Orientacion && asi.Anio == clase.Anio)
                                {
                                    dictandoAnioOrientacion = true;
                                }
                            }
                            if (!dictandoAnioOrientacion)
                            {
                                clasesDisponibles.Add(clase);
                                cmbxClase.Items.Add(clase.Nombre);
                            }
                        }
                        else
                        {
                            clasesDisponibles.Add(clase);
                            cmbxClase.Items.Add(clase.Nombre);
                        }
                    }

                }
            }
        }

        private void cmbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            solicitudClaseDo = new Logica.SolicitudClaseDo();
            claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
            asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            clasesDisponibles = new List<Logica.Clase>();
            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            btnModificarGrupo.Enabled = true;
            panelAsignaturas.Controls.Clear();
            panelAsignaturas.Visible = false;
            btnRealizar.Enabled = true;

            claseSeleccionada.Nombre = cmbxClase.SelectedItem.ToString();
            claseSeleccionada.Anio = Convert.ToInt32(cmbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientaciones[cmbxOrientacion.SelectedIndex].Id;
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            nuevasAsignaturas = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientaciones[cmbxOrientacion.SelectedIndex].Id);
            List<Logica.AsignaturaDictada> asignaturasdictada = new Logica.AsignaturaDictada().SelectAsignaturasDictadasPorCi(Login.encontrado.Ci);
            int index = -1;
            int x = 0;
            foreach (Logica.Asignatura asi in nuevasAsignaturas)
            {

                foreach (Logica.AsignaturaDictada asiDic in asignaturasdictada)
                {
                    if (asi.Id == asiDic.AsigDictada)
                    {
                        index = x;
                    }

                }
                x++;

            }
            if (index != -1)
            {
                nuevasAsignaturas.RemoveAt(index);
            }
            panelAsignaturas.Visible = !panelAsignaturas.Visible;

            if (panelAsignaturas.Visible && panelAsignaturas.Controls.Count == 0)
            {
                int ychbx = 5, xchbx = 5;
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    CheckBox dina = new CheckBox();
                    dina.Checked = false;
                    foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                    {
                        if (asignaturaSolicitudClaseDo.IdAsignatura == asig.Id && asignaturaSolicitudClaseDo.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseDo.OriClaseAsig == claseSeleccionada.Orientacion)
                        {
                            dina.Checked = true;
                        }
                    }
                    dina.Height = 23;
                    dina.Width = 150;
                    dina.Location = new Point(xchbx, ychbx);
                    if (xchbx == 160)
                    {
                        xchbx += -310;
                        ychbx += 25;
                    }
                    xchbx += 155;
                    dina.Name = "chbx" + asig.Id;
                    dina.Text = asig.Nombre;

                    dina.CheckedChanged += new EventHandler(AsignaturaCambiada);
                    panelAsignaturas.Controls.Add(dina);
                }
            }
        }
        
        private void AsignaturaCambiada(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {

                    if (((CheckBox)sender).Name == "chbx" + asig.Id)
                    {
                        Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo = new Logica.AsignaturaSolicitudClaseDo();
                        asignaturaSolicitudClaseDo.IdAsignatura = asig.Id;
                        asignaturaSolicitudClaseDo.IdClaseAsig = claseSeleccionada.IdClase;
                        asignaturaSolicitudClaseDo.OriClaseAsig = claseSeleccionada.Orientacion;
                        asignaturaSolicitudClaseDo.Aceptada = true;

                        asignaturasSolicitudClaseDo.Add(asignaturaSolicitudClaseDo);
                    }

                }
            }
            else
            {
                Logica.AsignaturaSolicitudClaseDo encontrado = new Logica.AsignaturaSolicitudClaseDo();
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && asignaturaSolicitudClaseDo.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseDo.OriClaseAsig == claseSeleccionada.Orientacion && asignaturaSolicitudClaseDo.IdAsignatura == asig.Id)
                        {
                            encontrado = asignaturaSolicitudClaseDo;
                        }
                    }
                }
                asignaturasSolicitudClaseDo.Remove(encontrado);
            }
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            if (asignaturasSolicitudClaseDo.Count != 0)
            {
                List<Logica.AsignaturaSolicitudClaseDo> solicitidesPendientes = new Logica.AsignaturaSolicitudClaseDo().SelectAsignaturasSolicitudesClaseDo(Login.encontrado.Ci);
                string error = errorSolicitud;
                bool mandable = true;
                foreach (Logica.AsignaturaSolicitudClaseDo asigPend in solicitidesPendientes)
                {
                    foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                    {
                        if (asigPend.IdClaseAsig == asignaturaSolicitudClaseDo.IdClaseAsig && asigPend.OriClaseAsig == asignaturaSolicitudClaseDo.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseDo.IdAsignatura)
                        {
                            Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.IdAsignatura);
                            error += "\n" + asi.Nombre;
                            mandable = false;
                        }
                    }
                }
                if (mandable)
                {
                    solicitudClaseDo.Docente = Login.encontrado.Ci;
                    solicitudClaseDo.FechaHora = DateTime.Now;
                    solicitudClaseDo.Pendiente = true;
                    solicitudClaseDo.EnviarSolicitudClaseDo();
                    solicitudClaseDo.IdSolicitudClaseDo = solicitudClaseDo.SelectIdSolicitudClaseDo();

                    claseSolicitudClaseDo.IdSolicitudClaseDo = solicitudClaseDo.IdSolicitudClaseDo;
                    claseSolicitudClaseDo.IdClase = claseSeleccionada.IdClase;
                    claseSolicitudClaseDo.OriClase = claseSeleccionada.Orientacion;
                    claseSolicitudClaseDo.EnviarClaseSolicitudClaseDo();

                    foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                    {
                        asignaturaSolicitudClaseDo.IdSolicitudClaseDo = solicitudClaseDo.IdSolicitudClaseDo;
                        asignaturaSolicitudClaseDo.EnviarAsignaturaSolicitudClaseDo();
                    }
                    MessageBox.Show(soliIngreso);
                }
                else
                {
                    MessageBox.Show(error);
                }
                solicitudClaseDo = new Logica.SolicitudClaseDo();
                claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo();
                asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
                clasesDisponibles = new List<Logica.Clase>();
                claseSeleccionada = new Logica.Clase();
                orientaciones = new List<Logica.Orientacion>();
                nuevasAsignaturas = new List<Logica.Asignatura>();

                cmbxOrientacion.Items.Clear();
                cmbxAnio.Items.Clear();
                cmbxAnio.Enabled = false;
                cmbxClase.Items.Clear();
                cmbxClase.Enabled = false;
                btnModificarGrupo.Enabled = false;
                panelAsignaturas.Controls.Clear();
                panelAsignaturas.Visible = false;
                btnRealizar.Enabled = false;
                panelEntrarGrupo.Visible = false;

            }
            else
            {
                MessageBox.Show(alMenosUna);
            }
        }

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
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
            DialogResult cerrarSesion = MessageBox.Show(msgCerrarSesion,cerrarSesionTitulo, MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Login.encontrado = new Logica.Usuario();
                login.Show();
                this.Dispose();
            }
        }

    }
}
