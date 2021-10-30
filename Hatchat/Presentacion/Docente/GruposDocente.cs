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
                int xpanel = 25, ypanel = 25;
                panelContenedorGrupos.Controls.Clear();

                foreach (Logica.AsignaturaDictada asignaturaDictada in asignaturaDictadas)
                {
                    Logica.Asignatura asignatura = new Logica.Asignatura().SelectAsignaturaPorId(asignaturaDictada.AsigDictada);
                    Logica.Clase clase = new Logica.Clase().SelectClasePorId(asignaturaDictada.IdClase);
                    Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);

                    Label grupo = new Label();
                    grupo.Height = 46;
                    grupo.Width = 150;
                    grupo.Location = new Point(0, 100);
                    grupo.Name = "lbl" + asignaturaDictada.AsigDictada;
                    grupo.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " + orientacion.Nombre;
                    grupo.BorderStyle = BorderStyle.FixedSingle;
                    grupo.Click += new EventHandler(AbrirGrupo);

                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile("profesor.png");
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 80;
                    pic.Width = 80;
                    pic.Location = new Point(50, 0);
                    pic.Name = "pbx" + asignaturaDictada.AsigDictada;
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
                    panel.Name = "pnl" + asignaturaDictada.AsigDictada;
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
            lblNombreProfesor.Text = "Profesor: " + Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido;
            pcbxProfesor.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            lblAsignatura.Text = asignatura.Nombre + " " + clase.Anio.ToString() + clase.Nombre + " " + orientacion.Nombre;
            agendas = new Logica.Agenda().SelectAgendasPorCi(Login.encontrado.Ci);


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
                List<Logica.Usuario> usuarios = new Logica.Usuario().SelectParticipantesGrupo(asignaturaDictada);
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
                asignaturaDictada.BajaGrupo();
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

            foreach (int anio in new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientaciones[cmbxOrientacion.SelectedIndex].Id)))
            {
                cmbxAnio.Items.Add(anio.ToString());
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
            foreach (Logica.Asignatura asig in nuevasAsignaturas)
            {
                Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo = new Logica.AsignaturaSolicitudClaseDo();
                asignaturaSolicitudClaseDo.IdAsignatura = asig.Id;
                asignaturaSolicitudClaseDo.IdClaseAsig = claseSeleccionada.IdClase;
                asignaturaSolicitudClaseDo.OriClaseAsig = claseSeleccionada.Orientacion;
                asignaturaSolicitudClaseDo.Aceptada = false;
                asignaturasSolicitudClaseDo.Add(asignaturaSolicitudClaseDo);
            }

            


        }
        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            panelAsignaturas.Visible = !panelAsignaturas.Visible;

            if (panelAsignaturas.Visible && panelAsignaturas.Controls.Count == 0)
            {
                int ychbx = 50, xchbx = 50;
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
                    if (xchbx == 400)
                    {
                        xchbx = -125;
                        ychbx += 25;
                    }
                    xchbx += 175;
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
            List<Logica.AsignaturaSolicitudClaseDo> solicitidesPendientes = new Logica.AsignaturaSolicitudClaseDo().SelectAsignaturasSolicitudesClaseDo(Login.encontrado.Ci);
            string error = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
            bool mandable = true;
            foreach (Logica.AsignaturaSolicitudClaseDo asigPend in solicitidesPendientes)
            {
                foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                {
                    if(asigPend.IdClaseAsig == asignaturaSolicitudClaseDo.IdClaseAsig && asigPend.OriClaseAsig == asignaturaSolicitudClaseDo.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseDo.IdAsignatura)
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
                MessageBox.Show("Se ha enviado la solicitud de ingreso");
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

        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
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

    }
}
