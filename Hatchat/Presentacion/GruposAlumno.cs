using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class GruposAlumno : Form
    {
        public Form login;
        public Form principalChatAlumno;
        public Form mensajesAlumno;
        public Form perfilAlumno;
        public Form historialChatsAlumno;
        public Form historialMensajesAlumno;
        private bool enHistorial = false, enPanel = false, enHistorialChat, enHistorialMensaje = false;

        Logica.AsignaturaCursa asignaturaCursa = new Logica.AsignaturaCursa();
        List<Logica.AsignaturaCursa> asignaturasCursadas = new List<Logica.AsignaturaCursa>();
        List<Logica.Clase> clasesDisponibles = new List<Logica.Clase>();
        List<Logica.Agenda> agendas = new List<Logica.Agenda>();
        List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
        List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();

        public GruposAlumno()
        {
            InitializeComponent();
            Text = "Grupos";

            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;

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
                pcbxHistorialMensajesNav.Image = Image.FromFile("mensaje gris.png");
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
            pcbxProfesor.SizeMode = PictureBoxSizeMode.StretchImage;

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

        private void timerGrupos_Tick(object sender, EventArgs e)
        {
            List<Logica.AsignaturaCursa> asignaturasCursadas = new Logica.AsignaturaCursa().SelectAsignaturasCursadasPorCi(Login.encontrado.Ci);
            bool iguales = true;
            if (this.asignaturasCursadas.Count == asignaturasCursadas.Count)
            {
                for (int x = 0; x < asignaturasCursadas.Count; x++)
                {
                    if (!(asignaturasCursadas[x].Ci == this.asignaturasCursadas[x].Ci && asignaturasCursadas[x].IdClase == this.asignaturasCursadas[x].IdClase && asignaturasCursadas[x].Orientacion == this.asignaturasCursadas[x].Orientacion && asignaturasCursadas[x].Anio == this.asignaturasCursadas[x].Anio && asignaturasCursadas[x].AsignaturaCursada == this.asignaturasCursadas[x].AsignaturaCursada))
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

                this.asignaturasCursadas = asignaturasCursadas;
                int xpanel = 25, ypanel = 25;
                panelContenedorGrupos.Controls.Clear();

                foreach (Logica.AsignaturaCursa asignaturaCursa in asignaturasCursadas)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaCursa.AsignaturaCursada);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaCursa.IdClase);

                    Label grupo = new Label();
                    grupo.Height = 46;
                    grupo.Width = 150;
                    grupo.Location = new Point(0, 100);
                    grupo.Name = "lbl" + asignaturaCursa.AsignaturaCursada;
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCiActivo(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(asignaturaCursa.AsignaturaCursada, asignaturaCursa.IdClase));
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + "\n" + "Profesor:\n" + us.Nombre + " " + us.Primer_apellido;
                    grupo.BorderStyle = BorderStyle.FixedSingle;
                    grupo.Click += new EventHandler(AbrirGrupo);

                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile("profesor.png");
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 80;
                    pic.Width = 80;
                    pic.Location = new Point(50, 0);
                    pic.Name = "pbx" + asignaturaCursa.AsignaturaCursada;
                    pic.Click += new EventHandler(AbrirGrupo);

                    Panel panel = new Panel();
                    panel.Height = 200;
                    panel.Width = 200;
                    panel.Location = new Point(xpanel, ypanel);
                    if (xpanel == 475)
                    {
                        xpanel += -675;
                        ypanel += 225;
                    }
                    xpanel += 225;
                    panel.Name = "pnl" + asignaturaCursa.AsignaturaCursada;
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
            asignaturaCursa = new Logica.AsignaturaCursa();
            if (sender.GetType().ToString()== "System.Windows.Forms.Label")
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Label)sender).Name), Login.encontrado.Ci);
            }else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((PictureBox)sender).Name), Login.encontrado.Ci);
            }
            else
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursaPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Panel)sender).Name), Login.encontrado.Ci);
            }
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCiActivo(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(asignaturaCursa.AsignaturaCursada, asignaturaCursa.IdClase));
            Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaCursa.IdClase);
            Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaCursa.AsignaturaCursada);
            lblNombreProfesor.Text = "Profesor: " + us.Nombre + " " + us.Primer_apellido;
            pcbxProfesor.Image = us.ByteArrayToImage(us.FotoDePerfil);
            lblAsignatura.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre;
            agendas = new Logica.Agenda().SelectAgendasPorCi(us.Ci);


        }
        private void btnLunes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.Orange;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Lunes");
        }


        private void btnMartes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = Color.Orange;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Martes");
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = Color.Orange;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Miercoles");
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = Color.Orange;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Jueves");
        }

        private void btnViernes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = Color.Orange;
            RecargarAgendaDelDia("Viernes");
        }
        private void RecargarAgendaDelDia(string dia)
        {
            int y = 5;
            panelHorariosPorDia.Controls.Clear();
            foreach (Logica.Agenda agenda in agendas)
            {
                if (agenda.NomDia == dia)
                {
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblAdendaDelDia" + agenda.IdAgenda.ToString();
                    dina.Text = agenda.HoraInicio + " - " + agenda.HoraFin;
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    panelHorariosPorDia.Controls.Add(dina);
                }
            }
        }

        private void btnCerrarInformacion_Click(object sender, EventArgs e)
        {
            panelInformacion.Visible = false;
            panelNav.Enabled = true;
            btnCerrarInformacion.Enabled = true;
            btnEntrarGrupo.Enabled = true;
            panelContenedorGrupos.Enabled = true;

        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            panelParticipantes.Visible = !panelParticipantes.Visible;
            if (panelParticipantes.Visible)
            {
                List<Logica.Usuario> usuarios = new Logica.Usuario().SelectParticipantesGrupo(asignaturaCursa);
                int y = 5;
                for (int x = 0; x < usuarios.Count; x++)
                {
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblParticipante" + x;
                    dina.Text = "- " + usuarios[x].Nombre + " " + usuarios[x].Primer_apellido;
                    panelParticipantesOrdinarios.Controls.Add(dina);
                }
            }
        }

        private void btnSalirGrupo_Click(object sender, EventArgs e)
        {
            DialogResult salirGrupo = MessageBox.Show("¿Desea salir del grupo?", "Salir del grupo", MessageBoxButtons.YesNo);
            if (salirGrupo == DialogResult.Yes)
            {
                asignaturaCursa.BajaGrupo();
                MessageBox.Show("Se ha salido del grupo correctamente");
                panelInformacion.Visible = false;
                panelNav.Enabled = true;
                btnCerrarInformacion.Enabled = true;
                btnEntrarGrupo.Enabled = true;
                panelContenedorGrupos.Enabled = true;
            }
        }

        private void btnEntrarGrupo_Click(object sender, EventArgs e)
        {
            panelEntrarGrupo.Visible = !panelEntrarGrupo.Visible;
            cmbxClase.Items.Clear();
            cmbxAnio.SelectedIndex = -1;
            cmbxClase.Enabled = false;
            cmbxAnio.Enabled = false;
            btnModificarGrupo.Enabled = false;
            btnRealizar.Enabled = false;
            panelAsignaturas.Controls.Clear();

            cmbxOrientacion.Items.Clear();
            orientaciones.Clear();
            orientaciones.AddRange(new Logica.Orientacion().SelectOrientaciones());
            foreach(Logica.Orientacion orientacion in orientaciones)
            {
                cmbxOrientacion.Items.Add(orientacion.Nombre);
            }
        }
        private void cmbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxAnio.Enabled = true;
            cmbxAnio.Items.Clear();
            cmbxClase.Enabled = false;
            cmbxClase.Items.Clear();
            panelAsignaturas.Controls.Clear();
            btnRealizar.Enabled = false;
            btnModificarGrupo.Enabled = false;
            List<Logica.Asignatura> asigs = new List<Logica.Asignatura>();
            List<Logica.Contiene> conts = new Logica.Contiene().SelectContienePorOrientacion(orientaciones[cmbxOrientacion.SelectedIndex].Id);
            foreach(Logica.Contiene cont in conts)
            {
                asigs.Add(new Logica.Asignatura().SelectAsignaturaPorId(cont.Asignatura));
            }
            List<int> anios = new List<int>();
            foreach(Logica.Asignatura asig in asigs)
            {
                bool contenida = false;
                foreach(int x in anios)
                {
                    if (x == asig.Anio)
                    {
                        contenida = true;
                    }
                }
                if (!contenida)
                {
                    anios.Add(asig.Anio);
                    cmbxAnio.Items.Add(asig.Anio);
                }
            }
            

        }
        private void cmbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnModificarGrupo.Enabled = false;
            btnRealizar.Enabled = false;
            panelAsignaturas.Controls.Clear();
            cmbxClase.Items.Clear();
            cmbxClase.Enabled = true;
            List<Logica.Clase> clases = new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxAnio.SelectedItem.ToString()));
            List<Logica.AsignaturaCursa> asignaturasCursa = new Logica.AsignaturaCursa().SelectAsignaturasCursadasPorCi(Login.encontrado.Ci);
            foreach(Logica.Clase clase in clases)
            {
                if(clase.Orientacion==orientaciones[cmbxOrientacion.SelectedIndex].Id && clase.Anio == Convert.ToInt32(cmbxAnio.SelectedItem.ToString()))
                {
                    List<Logica.AsignaturaCursa> asignaturasCursando = new List<Logica.AsignaturaCursa>();
                    foreach (Logica.AsignaturaCursa asigCur in asignaturasCursa)
                    {
                        if (asigCur.IdClase == clase.IdClase)
                        {
                            asignaturasCursando.Add(asigCur);
                        }
                    }
                    List<Logica.Asignatura> asignaturasClase = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(clase.Nombre, clase.Anio, clase.Orientacion);
                    if (asignaturasCursando.Count < asignaturasClase.Count)
                    {
                        if (asignaturasCursando.Count == 0)
                        {
                            bool cursandoAnioOrientacion = false;
                            foreach (Logica.AsignaturaCursa asigCur in asignaturasCursa)
                            {
                                Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigCur.AsignaturaCursada);
                                if (asigCur.Orientacion == clase.Orientacion && asi.Anio==clase.Anio)
                                {
                                    cursandoAnioOrientacion = true;
                                }
                            }
                            if (!cursandoAnioOrientacion)
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
            btnModificarGrupo.Enabled = true;
            btnRealizar.Enabled = true;
            panelAsignaturas.Controls.Clear();
            panelAsignaturas.Enabled = false;
        }
        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            panelAsignaturas.Visible = !panelAsignaturas.Visible;
            if()
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
            DialogResult cerrarSesion = MessageBox.Show("¿Desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Login.encontrado = new Logica.Usuario();
                login.Show();
                this.Dispose();
            }
        }

    }
}
