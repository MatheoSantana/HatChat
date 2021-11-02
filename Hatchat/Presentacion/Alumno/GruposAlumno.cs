﻿using System;
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

        List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();
        List<Logica.Asignatura> nuevasAsignaturas = new List<Logica.Asignatura>();
        Logica.Clase claseSeleccionada = new Logica.Clase();
        Logica.SolicitudClaseAl solicitudClaseAl = new Logica.SolicitudClaseAl();
        Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();

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
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxLogo.Image = Image.FromFile("Logo Completa.png");
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

            if (asignaturasCursadas.Count != 0)
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
                int xpanel = 63, ypanel = 25;
                panelContenedorGrupos.Controls.Clear();

                foreach (Logica.AsignaturaCursa asignaturaCursa in asignaturasCursadas)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaCursa.AsignaturaCursada);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaCursa.IdClase);
                    Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);

                    Label grupo = new Label();
                    grupo.Height = 200;
                    grupo.Width = 150;
                    grupo.Location = new Point(25, 110);
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lbl" + asignaturaCursa.AsignaturaCursada;
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCiActivo(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(asignaturaCursa.AsignaturaCursada, asignaturaCursa.IdClase));
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " + orientacion.Nombre;
                    grupo.Click += new EventHandler(AbrirGrupo);

                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile("profesor.png");
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 80;
                    pic.Width = 80;
                    pic.Location = new Point(60, 20);
                    pic.Name = "pbx" + asignaturaCursa.AsignaturaCursada;
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
                    panel.Name = "pnl" + asignaturaCursa.AsignaturaCursada;
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
            asignaturaCursa = new Logica.AsignaturaCursa();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursandoPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Label)sender).Name), Login.encontrado.Ci);
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursandoPorAsignaturaYCi(new Logica.Asignatura().StringAId(((PictureBox)sender).Name), Login.encontrado.Ci);
            }
            else
            {
                asignaturaCursa = new Logica.AsignaturaCursa().SelectAsignaturaCursandoPorAsignaturaYCi(new Logica.Asignatura().StringAId(((Panel)sender).Name), Login.encontrado.Ci);
            }
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCiActivo(new Logica.AsignaturaDictada().SelectCiPorAsignaturaDictadaYClase(asignaturaCursa.AsignaturaCursada, asignaturaCursa.IdClase));
            Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaCursa.IdClase);
            Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
            Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaCursa.AsignaturaCursada);
            lblNombreProfesor.Text = "Profesor: " + us.Nombre + " " + us.Primer_apellido;
            pcbxProfesor.Image = us.ByteArrayToImage(us.FotoDePerfil);
            lblAsignatura.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " +orientacion.Nombre;
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
            panelEntrarGrupo.Enabled = true;
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
            solicitudClaseAl = new Logica.SolicitudClaseAl();
            claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
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
            solicitudClaseAl = new Logica.SolicitudClaseAl();
            claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
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

            foreach (int anio in new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientaciones[cmbxOrientacion.SelectedIndex].Id)))
            {
                cmbxAnio.Items.Add(anio.ToString());
            }

        }
        private void cmbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            solicitudClaseAl = new Logica.SolicitudClaseAl();
            claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
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
            List<Logica.AsignaturaCursa> asignaturasCursa = new Logica.AsignaturaCursa().SelectAsignaturasCursadasPorCi(Login.encontrado.Ci);
            foreach (Logica.Clase clase in clases)
            {
                if (clase.Orientacion == orientaciones[cmbxOrientacion.SelectedIndex].Id && clase.Anio == Convert.ToInt32(cmbxAnio.SelectedItem.ToString()))
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
                                if (asigCur.Orientacion == clase.Orientacion && asi.Anio == clase.Anio)
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
            solicitudClaseAl = new Logica.SolicitudClaseAl();
            claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
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
            List<Logica.AsignaturaCursa> asignaturasCursa = new Logica.AsignaturaCursa().SelectAsignaturasCursadasPorCi(Login.encontrado.Ci);
            int index = -1;
            int x = 0;
            foreach (Logica.Asignatura asi in nuevasAsignaturas)
            {

                foreach (Logica.AsignaturaCursa asiCur in asignaturasCursa)
                {
                    if (asi.Id == asiCur.AsignaturaCursada)
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
            foreach (Logica.Asignatura asig in nuevasAsignaturas)
            {
                Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl = new Logica.AsignaturaSolicitudClaseAl();
                asignaturaSolicitudClaseAl.IdAsignatura = asig.Id;
                asignaturaSolicitudClaseAl.IdClaseAsig = claseSeleccionada.IdClase;
                asignaturaSolicitudClaseAl.OriClaseAsig = claseSeleccionada.Orientacion;
                asignaturaSolicitudClaseAl.Aceptada = false;
                asignaturasSolicitudClaseAl.Add(asignaturaSolicitudClaseAl);
            }

            


        }
        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            panelAsignaturas.Visible = !panelAsignaturas.Visible;

            if (panelAsignaturas.Visible && panelAsignaturas.Controls.Count == 0)
            {
                int ychbx = 5, xchbx = 5;
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    CheckBox dina = new CheckBox();
                    dina.Checked = false;
                    foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                    {
                        if (asignaturaSolicitudClaseAl.IdAsignatura == asig.Id && asignaturaSolicitudClaseAl.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseAl.OriClaseAsig == claseSeleccionada.Orientacion)
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
                        Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl = new Logica.AsignaturaSolicitudClaseAl();
                        asignaturaSolicitudClaseAl.IdAsignatura = asig.Id;
                        asignaturaSolicitudClaseAl.IdClaseAsig = claseSeleccionada.IdClase;
                        asignaturaSolicitudClaseAl.OriClaseAsig = claseSeleccionada.Orientacion;
                        asignaturaSolicitudClaseAl.Aceptada = true;

                        asignaturasSolicitudClaseAl.Add(asignaturaSolicitudClaseAl);
                    }

                }
            }
            else
            {
                Logica.AsignaturaSolicitudClaseAl encontrado = new Logica.AsignaturaSolicitudClaseAl();
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && asignaturaSolicitudClaseAl.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseAl.OriClaseAsig == claseSeleccionada.Orientacion && asignaturaSolicitudClaseAl.IdAsignatura == asig.Id)
                        {
                            encontrado = asignaturaSolicitudClaseAl;
                        }
                    }
                }
                asignaturasSolicitudClaseAl.Remove(encontrado);
            }
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            List<Logica.AsignaturaSolicitudClaseAl> solicitidesPendientes = new Logica.AsignaturaSolicitudClaseAl().SelectAsignaturasSolicitudesClaseAl(Login.encontrado.Ci);
            string error = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
            bool mandable = true;
            foreach (Logica.AsignaturaSolicitudClaseAl asigPend in solicitidesPendientes)
            {
                foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                {
                    if(asigPend.IdClaseAsig == asignaturaSolicitudClaseAl.IdClaseAsig && asigPend.OriClaseAsig == asignaturaSolicitudClaseAl.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseAl.IdAsignatura)
                    {
                        Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.IdAsignatura);
                        error += "\n" + asi.Nombre;
                        mandable = false;
                    }
                }
            }
            if (mandable)
            {
                solicitudClaseAl.Alumno = Login.encontrado.Ci;
                solicitudClaseAl.FechaHora = DateTime.Now;
                solicitudClaseAl.Pendiente = true;
                solicitudClaseAl.EnviarSolicitudClaseAl();
                solicitudClaseAl.IdSolicitudClaseAl = solicitudClaseAl.SelectIdSolicitudClaseAl();

                claseSolicitudClaseAl.IdSolicitudClaseAl = solicitudClaseAl.IdSolicitudClaseAl;
                claseSolicitudClaseAl.IdClase = claseSeleccionada.IdClase;
                claseSolicitudClaseAl.OriClase = claseSeleccionada.Orientacion;
                claseSolicitudClaseAl.EnviarClaseSolicitudClaseAl();

                foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                {
                    asignaturaSolicitudClaseAl.IdSolicitudClaseAl = solicitudClaseAl.IdSolicitudClaseAl;
                    asignaturaSolicitudClaseAl.EnviarAsignaturaSolicitudClaseAl();
                }
                MessageBox.Show("Se ha enviado la solicitud de ingreso");
            }
            else
            {
                MessageBox.Show(error);
            }
            solicitudClaseAl = new Logica.SolicitudClaseAl();
            claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
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

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
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
