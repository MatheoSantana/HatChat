using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class ABMDocenteAdmin : Form
    {
        private int ychbx = 50, xchbx = 50, xlbl = 50, ylbl = 50;
        private List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>(new Logica.Orientacion().SelectOrientaciones());
        private Logica.Orientacion orientacionSeleccionada = new Logica.Orientacion();
        private List<Logica.Asignatura> asigs = new List<Logica.Asignatura>();
        private List<Logica.AsignaturaDictada> dictaAsigs = new List<Logica.AsignaturaDictada>();
        private List<Logica.AsignaturaDictada> dictaAsigsConfirmadas = new List<Logica.AsignaturaDictada>();
        private List<Logica.Dicta> dictas = new List<Logica.Dicta>();
        private Logica.Clase claseSeleccionada = new Logica.Clase();

        Logica.Usuario doModif = new Logica.Usuario();

        Logica.Usuario doAgenda = new Logica.Usuario();
        List<Logica.Agenda> agendas = new List<Logica.Agenda>();

        public Form login;
        public Form principalSolicitudesAdmin;
        public Form abmDAlumnoAdmin;
        public Form abmGruposAdmin;
        public Form historialSolicitudesAdmin;
        public ABMDocenteAdmin()
        {
            InitializeComponent();
            foreach (Logica.Orientacion ori in orientaciones)
            {
                cmbxOrientacion.Items.Add(ori.Nombre);
            }

            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxSolicitudesNav.Image = Image.FromFile("solicitudes admin gris.png");
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno gris.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente blanco.png");
                pbxABMGruposNav.Image = Image.FromFile("abm grupos gris.png");
                pbxHistorialSolicitudesNav.Image = Image.FromFile("historial gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("archivo faltante (" + ex.Message + ") comuníquese con el administrador.", "Error");

            }
            pbxFotoPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxSolicitudesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxABMAlumnoNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxABMDocenteNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxABMGruposNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHistorialSolicitudesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;

            pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            cmbxClase.Enabled = false;
            cmbxAnio.Enabled = false;
            cmbxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxPreguntaSeg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxHoraInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxHoraCierre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxMinutoCierre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxMinutoInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cmbxPreguntaSeg.Items.Add(preg.Pregunta);               
                cmbxPregsModif.Items.Add(preg.Pregunta);
                
            }
            cmbxPregsModif.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbxPreguntaSeg.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            for (int x = 0; x < 24; x++) 
            {
                cmbxHoraInicio.Items.Add(x);
                cmbxHoraCierre.Items.Add(x);
            }
            for (int x = 0; x < 60; x++)
            {
                cmbxMinutoCierre.Items.Add(x);
                cmbxMinutoInicio.Items.Add(x);
            }
        }
        private void ABMAlumnoAdmin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }
        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }
        private void pbxSolicitudesNav_Click(object sender, EventArgs e)
        {
            principalSolicitudesAdmin.Show();
            this.Hide();
        }

        private void pbxABMAlumnoNav_Click(object sender, EventArgs e)
        {
            abmDAlumnoAdmin.Show();
            this.Hide();
        }

        private void pbxABMGruposNav_Click(object sender, EventArgs e)
        {
            abmGruposAdmin.Show();
            this.Hide();
        }

        private void pbxHistorialSolicitudesNav_Click(object sender, EventArgs e)
        {
            historialSolicitudesAdmin.Show();
            this.Hide();
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
        private void btnAlta_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = !panelAlta.Visible;
            panelBaja.Visible = false;
            panelModificar.Visible = false;
            panelAgenda.Visible = false;
        }
        private void cmbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelModificarClases.Controls.Clear();
            cmbxClase.Enabled = false;
            ychbx = 50;
            xchbx = 50;
            cmbxAnio.Items.Clear();
            cmbxClase.Items.Clear();
            dictaAsigs.Clear();
            asigs.Clear();
            btnAlterar.Enabled = false;
            orientacionSeleccionada = orientaciones[cmbxOrientacion.SelectedIndex];
            foreach (int anio in new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientacionSeleccionada.Id)))
            {
                cmbxAnio.Items.Add(anio.ToString());
            }
            cmbxAnio.Enabled = true;
        }

        private void cmbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelModificarClases.Controls.Clear();
            ychbx = 50;
            xchbx = 50;
            btnAlterar.Enabled = false;
            cmbxClase.Items.Clear();
            dictaAsigs.Clear();
            asigs.Clear();
            List<string> clase = new List<string>();

            foreach (string cla in new List<string>(new Logica.Clase().SelectNombreClasePorAnioYorientacion(Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientacionSeleccionada.Id)))
            {
                cmbxClase.Items.Add(cla);
            }
            cmbxClase.Enabled = true;
        }
        private void cmbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelModificarClases.Controls.Clear();
            asigs.Clear();
            ychbx = 50;
            xchbx = 50;
            asigs.Clear();
            dictaAsigs.Clear();
            claseSeleccionada = new Logica.Clase();
            asigs.AddRange(new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientacionSeleccionada.Id));
            claseSeleccionada.Anio = Convert.ToInt32(cmbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientacionSeleccionada.Id;
            claseSeleccionada.Nombre = cmbxClase.SelectedItem.ToString();
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();
            foreach (Logica.Asignatura asig in asigs)
            {
                Logica.AsignaturaDictada dictaAsig = new Logica.AsignaturaDictada();
                dictaAsig.AsigDictada = asig.Id;
                dictaAsig.IdClase = claseSeleccionada.IdClase;
                dictaAsig.Orientacion = orientacionSeleccionada.Id;
                dictaAsig.Dictando = true;
                dictaAsig.Anio = DateTime.Now.Year;
                dictaAsigs.Add(dictaAsig);
            }
            
            btnAlterar.Enabled = true;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            panelModificarClases.Visible = !panelModificarClases.Visible;
            if (panelModificarClases.Visible && panelModificarClases.Controls.Count==0)
            {
                foreach (Logica.Asignatura asig in asigs)
                {
                    CheckBox dina = new CheckBox();
                    dina.Checked = false;
                    foreach (Logica.AsignaturaDictada dictaAsig in dictaAsigs)
                    {
                        if(dictaAsig.AsigDictada==asig.Id && dictaAsig.IdClase == claseSeleccionada.IdClase && dictaAsig.Orientacion == orientacionSeleccionada.Id && dictaAsig.AsigDictada == asig.Id)
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
                    panelModificarClases.Controls.Add(dina);
                }
            }
        }
        private void AsignaturaCambiada(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.Asignatura asig in asigs)
                {

                    if (((CheckBox)sender).Name == "chbx" + asig.Id)
                    {
                        Logica.AsignaturaDictada dictaAsig = new Logica.AsignaturaDictada();
                        dictaAsig.AsigDictada = asig.Id;
                        dictaAsig.IdClase = claseSeleccionada.IdClase;
                        dictaAsig.Orientacion = orientacionSeleccionada.Id;
                        dictaAsig.Dictando = true;
                        dictaAsig.Anio = DateTime.Now.Year;
                        dictaAsigs.Add(dictaAsig);
                    }

                }
            }
            else
            {
                Logica.AsignaturaDictada encontrado = new Logica.AsignaturaDictada();
                foreach (Logica.Asignatura asig in asigs)
                {
                    foreach (Logica.AsignaturaDictada dictaAsig in dictaAsigs)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && dictaAsig.IdClase == claseSeleccionada.IdClase && dictaAsig.Orientacion == orientacionSeleccionada.Id && dictaAsig.AsigDictada == asig.Id)
                        {
                            encontrado = dictaAsig;
                        }
                    }
                }
                dictaAsigs.Remove(encontrado);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelClasesAgregadas.AutoScrollPosition = Point.Empty;
            panelModificarClases.AutoScrollPosition = Point.Empty;
            Logica.Dicta dicta = new Logica.Dicta();
            dicta.IdClase = claseSeleccionada.IdClase;
            dicta.Orientacion = orientacionSeleccionada.Id;
            dicta.Anio = DateTime.Now.Year;
            if (!dictas.Contains(dicta))
            {
                Label dina = new Label();
                dina.Height = 46;
                dina.Width = 150;
                dina.Location = new Point(xlbl, ylbl);
                if (xlbl == 100)
                {
                    xlbl = -125;
                    ylbl += 25;
                }
                xlbl += 175;
                dina.Name = "lblClase" + claseSeleccionada.IdClase;
                dina.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre;
                foreach (Logica.AsignaturaDictada dictaAsig in dictaAsigs)
                {
                    dictaAsigsConfirmadas.Add(dictaAsig);
                    dina.Text += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(dictaAsig.AsigDictada).Nombre;
                    dina.Height += 23;
                }
                dina.Text += "\n" + orientacionSeleccionada.Nombre;/* + "\n(click para borrar)";
                dina.Click += new EventHandler(EliminarClase);*/
                panelClasesAgregadas.Controls.Add(dina);
                panelModificarClases.Controls.Clear();
                cmbxOrientacion.SelectedItem = 0;
                cmbxAnio.Items.Clear();
                cmbxClase.Items.Clear();
                dictas.Add(dicta);
                claseSeleccionada = new Logica.Clase();
                orientacionSeleccionada = new Logica.Orientacion();
                cmbxAnio.Enabled = false;
                cmbxClase.Enabled = false;
            }
        }

        

        private void btnAltaDocente_Click(object sender, EventArgs e)
        {
            string error = "Cuidado: ";
            bool aceptable = true;
            Logica.Docente doc = new Logica.Docente();
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuesta.Text == "")
            {
                aceptable = false;
                error += "\nDebe rellenar todos los campos";
            }
            if (txtCedula.Text != "")
            {
                if (!doc.VerficarCedula(txtCedula.Text))
                {
                    aceptable = false;
                    error += "\nLa cedula debe ser real";
                }
            }
            if (txtPassword.Text.Length < 8)
            {
                aceptable = false;
                error += "\nLa contraseña es demaciado corta";
            }
            if (txtConfirmarPassword.Text != txtPassword.Text)
            {
                aceptable = false;
                error += "\nLas contraseñas no son iguales";
            }


            if (new Logica.Usuario().ExisteUsuarioCi(txtCedula.Text))
            {
                aceptable = false;
                error += "\n\nAdvertencia: esa cedula ya esta ingresada";
            }


            if (!aceptable)
            {
                MessageBox.Show(error);
            }
            else
            {
                doc.Ci = txtCedula.Text;
                doc.Nombre = txtNombre.Text;
                doc.Primer_apellido = txtPrimerApellido.Text;
                doc.Segundo_apellido = txtSegundoApellido.Text;
                doc.Password = txtPassword.Text;
                doc.Preguta_seguridad = (cmbxPreguntaSeg.SelectedIndex + 1);
                doc.Respuesta_seguridad = txtRespuesta.Text;
                doc.Apodo = txtNombre.Text;
                doc.FotoDePerfil = doc.ImageToByteArray(Image.FromFile("docente.png"));
                doc.AltaUsuario();
                foreach (Logica.Dicta dicta in dictas)
                {
                    dicta.CiDocente = doc.Ci;
                    dicta.InsertDicta();
                }
                foreach (Logica.AsignaturaDictada asigDicta in dictaAsigsConfirmadas)
                {
                    asigDicta.Ci = doc.Ci;
                    asigDicta.InsertAsignaturaDictada();
                }

                MessageBox.Show("Se ha creado el docente correctamente");
            }
            
        }

        

        private void btnBaja_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = !panelBaja.Visible;
            panelModificar.Visible = false;
            panelAgenda.Visible = false;
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Logica.Usuario doce = new Logica.Usuario().SelectUsuarioCi(txtBajaCi.Text);
            if(doce.Ci!="" && doce.SelectDocente())
            {
                doce.RemoveUsuario();
                MessageBox.Show("Docente eliminado correctamente");
            }
            else
            {
                MessageBox.Show("Docente no encontrado");
            }
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = false;
            panelModificar.Visible = !panelModificar.Visible;
            panelAgenda.Visible = false;
        }

        private void btnBuscarModficar_Click(object sender, EventArgs e)
        {
            if (new Logica.Usuario().SelectDocente(txtCiModif.Text))
            {
                doModif = new Logica.Usuario().SelectUsuarioCi(txtCiModif.Text);
                lblNombreCompleto.Text += doModif.Nombre + " " + doModif.Primer_apellido + " " + doModif.Segundo_apellido;
                lblCedula.Text += doModif.Ci;
                pbxFoto.Image = doModif.ByteArrayToImage(doModif.FotoDePerfil);
                txtApodo.Text = doModif.Apodo;
                txtPassword.Text = doModif.Password;
                txtPasswordConModif.Text = doModif.Password;
                cmbxPregsModif.SelectedIndex = (doModif.SelectPreguntaSeguridad().Id - 1);
                txtRespuesta.Text = doModif.Respuesta_seguridad;

            }
            else
            {
                MessageBox.Show("Docente no encontrado");
            }
        }

        

        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFoto = new OpenFileDialog();
            ofdFoto.Filter = "Imagenes|*.jpeg;*.jpg;*.png;";
            ofdFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdFoto.Title = "Seleccionar imagen";
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFoto.Image = Image.FromFile(ofdFoto.FileName);
            }
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            doModif.Apodo = txtApodo.Text;
            doModif.Password = txtPassword.Text;
            doModif.Respuesta_seguridad = txtRespuesta.Text;
            doModif.Preguta_seguridad = (cmbxPregsModif.SelectedIndex + 1);
            doModif.FotoDePerfil = doModif.ImageToByteArray(pbxFoto.Image);
            doModif.UpdatePerfil();
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = false;
            panelModificar.Visible = false;
            panelAgenda.Visible = !panelAgenda.Visible;
        }

        private void btnBuscarAgenda_Click(object sender, EventArgs e)
        {
            if (new Logica.Usuario().SelectDocente(txtCedulaAgenda.Text))
            {
                doAgenda = new Logica.Usuario().SelectUsuarioCi(txtCedulaAgenda.Text);
                panelDiasYHorarios.Visible = true;
                agendas = new Logica.Agenda().SelectAgendasPorCi(txtCedulaAgenda.Text);
            }
            else
            {
                MessageBox.Show("Docente no encontrado");
            }
        }
        private void btnLunes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.Orange;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor= SystemColors.Control;
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
                    dina.Text = agenda.HoraInicio + " - " + agenda.HoraFin + " (click para eliminar)";
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(EliminarAgenda);
                    panelHorariosPorDia.Controls.Add(dina);
                }
            }
        }

        private void EliminarAgenda(object sender, EventArgs e)
        {
            new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Label)sender).Name));
            MessageBox.Show("Se ha eliminado la agenda");
        }

        private void btnNuevaAgenda_Click(object sender, EventArgs e)
        {
            panelAgregarAgenda.Visible = true;
            panelDiasYHorarios.Visible = false;
        }

        private void btnAgregarNuevaAgenda_Click(object sender, EventArgs e)
        {
            if (!chbxLunes.Checked && !chbxMartes.Checked && !chbxMiercoles.Checked && !chbxJueves.Checked && !chbxViernes.Checked)
            {
                MessageBox.Show("No se ha seleccionado ningun dia");
            }
            else
            {
                if (chbxLunes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Lunes";
                    agenda.AgregarAgenda();
                }
                if (chbxMartes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString()+":"+cmbxMinutoInicio.SelectedItem.ToString()+":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Martes";
                    agenda.AgregarAgenda();
                }
                if (chbxMiercoles.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Miercoles";
                    agenda.AgregarAgenda();
                }
                if (chbxJueves.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Jueves";
                    agenda.AgregarAgenda();
                }
                if (chbxViernes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Viernes";
                    agenda.AgregarAgenda();
                }
                MessageBox.Show("Se ha agendado correctamente");
                panelAgregarAgenda.Visible = false;
                panelDiasYHorarios.Visible = true;
            }
        }
    }
}
