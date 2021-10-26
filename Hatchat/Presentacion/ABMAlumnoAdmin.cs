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

            pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            cmbxClase.Enabled = false;
            cmbxAnio.Enabled = false;
            cmbxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxPreguntaSeg.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cmbxPreguntaSeg.Items.Add(preg.Pregunta);               
                cmbxPregsModif.Items.Add(preg.Pregunta);
                
            }
            cmbxPregsModif.DropDownStyle = ComboBoxStyle.DropDownList;

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
            panelModificarClases.Controls.Clear();
            cmbxClase.Enabled = false;
            ychbx = 50;
            xchbx = 50;
            cmbxAnio.Items.Clear();
            cmbxClase.Items.Clear();
            cursaAsigs.Clear();
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
            cursaAsigs.Clear();
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
            cursaAsigs.Clear();
            claseSeleccionada = new Logica.Clase();
            asigs.AddRange(new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientacionSeleccionada.Id));
            claseSeleccionada.Anio = Convert.ToInt32(cmbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientacionSeleccionada.Id;
            claseSeleccionada.Nombre = cmbxClase.SelectedItem.ToString();
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
                    foreach (Logica.AsignaturaCursa cursaAsig in cursaAsigs)
                    {
                        if(cursaAsig.AsignaturaCursada==asig.Id && cursaAsig.IdClase == claseSeleccionada.IdClase/**/ && cursaAsig.Orientacion == orientacionSeleccionada.Id && cursaAsig.AsignaturaCursada == asig.Id)
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
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuesta.Text == "")
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
                alu.Respuesta_seguridad = txtRespuesta.Text;
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
            Logica.Usuario al = new Logica.Usuario().SelectUsuarioCi(txtBajaCi.Text);
            if(al.Ci!="" && al.SelectAlumno())
            {
                al.RemoveUsuario();
                MessageBox.Show("Alumno eliminado correctamente");
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
                alModif = new Logica.Usuario().SelectUsuarioCi(txtCiModif.Text);
                lblNombreCompleto.Text += alModif.Nombre + " " + alModif.Primer_apellido + " " + alModif.Segundo_apellido;
                lblCedula.Text += alModif.Ci;
                pbxFoto.Image = alModif.ByteArrayToImage(alModif.FotoDePerfil);
                txtApodo.Text = alModif.Apodo;
                txtPassword.Text = alModif.Password;
                txtPasswordConModif.Text = alModif.Password;
                cmbxPregsModif.SelectedIndex = (alModif.SelectPreguntaSeguridad().Id - 1);
                txtRespuesta.Text = alModif.Respuesta_seguridad;

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
                pbxFoto.Image = Image.FromFile(ofdFoto.FileName);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            alModif.Apodo = txtApodo.Text;
            alModif.Password = txtPassword.Text;
            alModif.Respuesta_seguridad = txtRespuesta.Text;
            alModif.Preguta_seguridad = (cmbxPregsModif.SelectedIndex + 1);
            alModif.FotoDePerfil = alModif.ImageToByteArray(pbxFoto.Image);
            alModif.UpdatePerfil();
        }

    }
}
