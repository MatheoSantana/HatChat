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
    public partial class ABMAlumnoAdmin : Form
    {
        private int ychbx = 50, xchbx = 50, xlbl = 50, ylbl = 50;
        private List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>(new Logica.Orientacion().SelectOrientaciones());
        private Logica.Orientacion orientacionSeleccionada = new Logica.Orientacion();
        private List<Logica.Asignatura> asigs = new List<Logica.Asignatura>();
        private List<Logica.AsignaturaCursa> cursaAsigs = new List<Logica.AsignaturaCursa>();
        private List<Logica.AsignaturaCursa> cursaAsigsConfirmadas = new List<Logica.AsignaturaCursa>();
        private List<Logica.Cursa> cursas = new List<Logica.Cursa>();
        private Logica.Clase claseSeleccionada = new Logica.Clase();
        bool visibles = false;
        Logica.Usuario alModif = new Logica.Usuario();

        public Form login;
        public Form principalSolicitudesAdmin;
        public Form abmDocenteAdmin;
        public Form abmGruposAdmin;
        public Form historialSolicitudesAdmin;
        public ABMAlumnoAdmin()
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
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno blanco.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente gris.png");
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

            pbxFotoModificar.SizeMode = PictureBoxSizeMode.StretchImage;

            cmbxClase.Enabled = false;
            cmbxAnio.Enabled = false;
            cmbxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxPreguntaSeg.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cmbxPreguntaSeg.Items.Add(preg.Pregunta);               
                cbxPregsModificar.Items.Add(preg.Pregunta);
                
            }
            cbxPregsModificar.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbxPreguntaSeg.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;

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

        private void pbxABMDocenteNav_Click(object sender, EventArgs e)
        {
            abmDocenteAdmin.Show();
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
        }
        private void cmbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibles = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaCursa> encontradas = new List<Logica.AsignaturaCursa>();
                foreach (Logica.AsignaturaCursa asigSolicita in cursaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaCursa asigEncontrada in encontradas)
                {
                    cursaAsigs.Remove(asigEncontrada);
                }
            }

            cmbxAnio.Items.Clear();
            cmbxClase.Items.Clear();
            panelModificarClases.Controls.Clear();
            cmbxAnio.Enabled = true;
            cmbxClase.Enabled = false;
            btnAlterar.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            asigs = new List<Logica.Asignatura>();
            cursaAsigs = new List<Logica.AsignaturaCursa>();
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
            visibles = false;
            if(btnAgregar.Enabled)
            {
                List<Logica.AsignaturaCursa> encontradas = new List<Logica.AsignaturaCursa>();
                foreach (Logica.AsignaturaCursa asigSolicita in cursaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaCursa asigEncontrada in encontradas)
                {
                    cursaAsigs.Remove(asigEncontrada);
                }
            }

            cmbxClase.Items.Clear();
            panelModificarClases.Controls.Clear();
            cmbxClase.Enabled = true;
            btnAlterar.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            asigs = new List<Logica.Asignatura>();
            cursaAsigs = new List<Logica.AsignaturaCursa>();

            List<Logica.Clase> clases = new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxAnio.SelectedItem.ToString()));
            if (cmbxOrientacion.SelectedIndex != -1)
            {
                foreach (Logica.Clase cla in clases)
                {
                    if (cla.Orientacion == orientaciones[cmbxOrientacion.SelectedIndex].Id)
                    {
                        cmbxClase.Items.Add(cla.Nombre);
                    }
                }
            }
        }
        private void cmbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibles = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaCursa> encontradas = new List<Logica.AsignaturaCursa>();
                foreach (Logica.AsignaturaCursa asigSolicita in cursaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaCursa asigEncontrada in encontradas)
                {
                    cursaAsigs.Remove(asigEncontrada);
                }
            }
            panelModificarClases.Controls.Clear();
            btnAlterar.Enabled = true;

            claseSeleccionada = new Logica.Clase();
            asigs = new List<Logica.Asignatura>();
            cursaAsigs = new List<Logica.AsignaturaCursa>();

            asigs = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientaciones[cmbxOrientacion.SelectedIndex].Id);

            claseSeleccionada.Nombre = cmbxClase.SelectedItem.ToString();
            claseSeleccionada.Anio = Convert.ToInt32(cmbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientaciones[cmbxOrientacion.SelectedIndex].Id;
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            foreach (Logica.Asignatura asig in asigs)
            {
                Logica.AsignaturaCursa cursaAsig = new Logica.AsignaturaCursa();
                cursaAsig.AsignaturaCursada = asig.Id;
                cursaAsig.IdClase = claseSeleccionada.IdClase;
                cursaAsig.Orientacion = orientacionSeleccionada.Id;
                cursaAsig.Cursando = true;
                cursaAsig.Anio = DateTime.Now.Year;
                cursaAsigs.Add(cursaAsig);
            }


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
                    foreach (Logica.AsignaturaCursa cursaAsig in cursaAsigs)
                    {
                        if(cursaAsig.AsignaturaCursada==asig.Id && cursaAsig.IdClase == claseSeleccionada.IdClase && cursaAsig.Orientacion == orientacionSeleccionada.Id && cursaAsig.AsignaturaCursada == asig.Id)
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
                        Logica.AsignaturaCursa cursaAsig = new Logica.AsignaturaCursa();
                        cursaAsig.AsignaturaCursada = asig.Id;
                        cursaAsig.IdClase = claseSeleccionada.IdClase;
                        cursaAsig.Orientacion = orientacionSeleccionada.Id;
                        cursaAsig.Cursando = true;
                        cursaAsig.Anio = DateTime.Now.Year;
                        cursaAsigs.Add(cursaAsig);
                    }

                }
            }
            else
            {
                Logica.AsignaturaCursa encontrado = new Logica.AsignaturaCursa();
                foreach (Logica.Asignatura asig in asigs)
                {
                    foreach (Logica.AsignaturaCursa cursaAsig in cursaAsigs)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && cursaAsig.IdClase == claseSeleccionada.IdClase && cursaAsig.Orientacion == orientacionSeleccionada.Id && cursaAsig.AsignaturaCursada == asig.Id)
                        {
                            encontrado = cursaAsig;
                        }
                    }
                }
                cursaAsigs.Remove(encontrado);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelClasesAgregadas.AutoScrollPosition = Point.Empty;
            panelModificarClases.AutoScrollPosition = Point.Empty;
            Logica.Cursa cursa = new Logica.Cursa();
            cursa.IdClase = claseSeleccionada.IdClase;
            cursa.Orientacion = orientacionSeleccionada.Id;
            cursa.Anio = DateTime.Now.Year;
            if (!cursas.Contains(cursa))
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
                foreach (Logica.AsignaturaCursa cursaAsig in cursaAsigs)
                {
                    cursaAsigsConfirmadas.Add(cursaAsig);
                    dina.Text += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(cursaAsig.AsignaturaCursada).Nombre;
                    dina.Height += 23;
                }
                dina.Text += "\n" + orientacionSeleccionada.Nombre;/* + "\n(click para borrar)";
                dina.Click += new EventHandler(EliminarClase);*/
                panelClasesAgregadas.Controls.Add(dina);
                panelModificarClases.Controls.Clear();
                cmbxOrientacion.SelectedItem = 0;
                cmbxAnio.Items.Clear();
                cmbxClase.Items.Clear();
                cursas.Add(cursa);
                claseSeleccionada = new Logica.Clase();
                orientacionSeleccionada = new Logica.Orientacion();
            }
        }

        

        private void btnAltaAlumno_Click(object sender, EventArgs e)
        {
            string error = "Cuidado: ";
            bool aceptable = true;
            Logica.Alumno alu = new Logica.Alumno();
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuestaModif.Text == "")
            {
                aceptable = false;
                error += "\nDebe rellenar todos los campos";
            }
            if (txtCedula.Text != "")
            {
                if (!alu.VerficarCedula(txtCedula.Text))
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
                alu.Ci = txtCedula.Text;
                alu.Nombre = txtNombre.Text;
                alu.Primer_apellido = txtPrimerApellido.Text;
                alu.Segundo_apellido = txtSegundoApellido.Text;
                alu.Password = txtPassword.Text;
                alu.Preguta_seguridad = (cmbxPreguntaSeg.SelectedIndex + 1);
                alu.Respuesta_seguridad = txtRespuestaModif.Text;
                alu.Apodo = txtNombre.Text;
                alu.FotoDePerfil = alu.ImageToByteArray(Image.FromFile("alumno.png"));
                alu.AltaUsuario();
                foreach (Logica.Cursa cursa in cursas)
                {
                    cursa.CiAlumno = alu.Ci;
                    cursa.InsertCursa();
                }
                foreach (Logica.AsignaturaCursa asigCursa in cursaAsigsConfirmadas)
                {
                    asigCursa.Ci = alu.Ci;
                    asigCursa.InsertAsignaturaCursa();
                }

                MessageBox.Show("Se ha creado el alumno correctamente");
            }
            
        }

        

        private void btnBaja_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = !panelBaja.Visible;
            panelModificar.Visible = false;
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            Logica.Usuario al = new Logica.Usuario().SelectUsuarioCiActivo(txtBajaCi.Text);
            if(al.Ci!="" && al.SelectAlumno())
            {
                DialogResult eliminarAlumno = MessageBox.Show("¿Desea eliminar a "+al.Nombre+" "+al.Primer_apellido+"?", "Cerrar Sesion", MessageBoxButtons.YesNo);
                if (eliminarAlumno == DialogResult.Yes)
                {
                    al.RemoveUsuario();
                    MessageBox.Show("Alumno eliminado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Alumno no encontrado");
            }
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = false;
            panelModificar.Visible = !panelModificar.Visible;
        }

        private void btnBuscarModficar_Click(object sender, EventArgs e)
        {
            if (new Logica.Usuario().SelectAlumno(txtCiModif.Text))
            {
                alModif = new Logica.Usuario().SelectUsuarioCiActivo(txtCiModif.Text);
                lblNombreModificar.Text += alModif.Nombre + " " + alModif.Primer_apellido + " " + alModif.Segundo_apellido;
                lblCedulaModificar.Text += alModif.Ci;
                pbxFotoModificar.Image = alModif.ByteArrayToImage(alModif.FotoDePerfil);
                txtApodoModificar.Text = alModif.Apodo;
                txtPasswordModificar.Text = alModif.Password;
                txtPasswordConfirmarModificar.Text = alModif.Password;
                cbxPregsModificar.SelectedIndex = (alModif.SelectPreguntaSeguridad().Id - 1);
                txtRespuestaModif.Text = alModif.Respuesta_seguridad;

            }
            else
            {
                MessageBox.Show("Alumno no encontrado");
            }
        }
        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFoto = new OpenFileDialog();
            ofdFoto.Filter = "Imagenes|*.jpeg;*.jpg;*.png";
            ofdFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdFoto.Title = "Seleccionar imagen";
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFotoModificar.Image = Image.FromFile(ofdFoto.FileName);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            alModif.Apodo = txtApodoModificar.Text;
            alModif.Password = txtPasswordModificar.Text;
            alModif.Respuesta_seguridad = txtRespuestaModif.Text;
            alModif.Preguta_seguridad = (cbxPregsModificar.SelectedIndex + 1);
            alModif.FotoDePerfil = alModif.ImageToByteArray(pbxFotoModificar.Image);
            alModif.UpdatePerfil();

            txtApodoModificar.Text = "";
            txtPassword.Text = "";
            txtRespuestaModif.Text = "";
            cbxPregsModificar.SelectedIndex = -1;
            pbxFotoModificar.Image = null;
            txtCiModif.Text = "";
        }

    }
}
