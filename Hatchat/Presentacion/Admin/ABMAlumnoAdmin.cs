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
        string nombreNumerico;
        string apellidoNumerico;
        string sApellidoNumerico;
        string grandes;
        string cuidado;
        string corta;
        string distintas;
        string rellenar;
        string error;
        string existe;
        string real;
        string msgCerrarSesion;
        string cerrarSesionTitulo;
        string seleccionaImagen;
        string modificado;
        string msgBorrar;
        string msgModificar;
        string titBorrar;
        string titModificar;
        string borrado;
        string yaIngresadas;
        string creado;
        string ingresadas;
        string fallo;
        string eliminadont;

        private int yPanel = 0;
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
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            foreach (Logica.Orientacion ori in orientaciones)
            {
                cmbxOrientacion.Items.Add(ori.Nombre);
            }
            
                lblABMAlumno.Text = "ABM Alumno";
                lblAnio.Text = "Año";
                lblApodoModificar.Text = "Apodo";
                lblBienvenido.Text = "Bienvenido";
                lblCambiarFotoModificar.Text = "Cambiar foto de perfil";
                lblCedulaBaja.Text = "Cedula: ";
                lblCedulaModificar.Text = "Cedula: ";
                lblCi.Text = "Cedula";
                lblCiModf.Text = "cedula";
                lblClase.Text = "Clase";
                lblConfirmarPassword.Text = "Confirmar contraseña";
                lblCrearAlmuno.Text = "Crear Alumno";
                lblEliminarAlumno.Text = "Eliminar Alumno";
                lblEstudianteModificar.Text = "Estudiante";
                lblExpliModi.Text = "si no pertenece a todas las asignaturas,\npuede configurarlo aqui";
                lblExpliPregSegur.Text = "Pregunta de seguridad\nRellene el cuadro con una respuesta que nunca olvide\npara poder tomar medidas en caso de perder su cuenta.";
                lblInformacionModificar.Text = "Informacion";
                lblModificar.Text = "Modificar";
                lblNombre.Text = "Nombre";
                lblNombreModificar.Text = "Nombre: ";
                lblOrientacion.Text = "Orientacion: ";
                lblPassword.Text = "Contraseña";
                lblPasswordConfirmarModificar.Text = "Confirmar Contraseña";
                lblPasswordModificar.Text = "Contraseña";
                lblPregSegur.Text = "Pregunta de seguridad";
                lblPregsModificar.Text = "Pregunta de seguridad";
                lblPrimerApellido.Text = "Primer apellido";
                lblRespuestaModificar.Text = "Respuesta";
                lblSegundoApellido.Text = "Segundo Apellido";
                
                btnActualizar.Text = "Modificar Alumno";
                btnAgregar.Text = "Agregar";
                btnAlta.Text = "Alta";
                btnAltaAlumno.Text = "Crear Alumno";
                btnAlterar.Text = "Modificar Alumno";
                btnBaja.Text = "Baja";
                btnEliminar.Text = "Eliminar Alumno";
                btnModificar.Text = "Modificar";

                msgModificar = "¿Desea modificar su perfil?";
                titModificar = "Modificar perfil";
                modificado = "Se han modificado sus datos";
                msgBorrar = "¿Desea eliminar a ";
                titBorrar = "Borrar Perfil";
                borrado = "Usuario eliminado";
                seleccionaImagen = "Seleccionar imagen";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";

                cbxPregsModificar.Items.Add("¿Cuál es el nombre de tu primer mascota?");
                cbxPregsModificar.Items.Add("¿En qué calle está ubicado tu primer hogar?");
                cbxPregsModificar.Items.Add("¿Cual es tu sabor de helado favorito?");
                cmbxPreguntaSeg.Items.Add("¿Cuál es el nombre de tu primer mascota?");
                cmbxPreguntaSeg.Items.Add("¿En qué calle está ubicado tu primer hogar?");
                cmbxPreguntaSeg.Items.Add("¿Cual es tu sabor de helado favorito?");
                error = " comuníquese con el administrador.";
                cuidado = "Cuidado:";
                rellenar = "Debe rellenar todos los campos ";
                corta = "La contraseña es demasiado corta ";
                distintas = "Las contraseñas no son iguales";
                existe = "Esa cedula ya esta ingresada";
                real = "La cedula debe ser real";
                nombreNumerico = "El nombre no puede tener numeros";
                apellidoNumerico = "El primer apellido no puede tener numeros";
                sApellidoNumerico = "El segundo apellido no peude tener numeros";
                grandes = "Los datos no pueden tener un tamaño mayor a 30 caracteres";
                nombreNumerico = "The name cannot have numbers";
                apellidoNumerico = "The first surname cannot have numbers";
                sApellidoNumerico = "The second surname cannot have numbers";
                grandes = "Data cannot be larger than 30 characters";
                ingresadas = "El alumno a ingresado a los grupos correctamente";
                fallo = "EL ALUMNO YA ESTABA CURSANDO LAS SIGUIENTES ASIGNATURAS:\n";
                creado = "Se ha creado el alumno correctamente";
                eliminadont = "Alumno no encontrado";
            /*
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
                cbxPregsModificar.Items.Add("What is the name of your first pet?");
                cbxPregsModificar.Items.Add("On what street is your first home located?");
                cbxPregsModificar.Items.Add("What is your favorite ice cream flavor?");
                cmbxPreguntaSeg.Items.Add("What is the name of your first pet?");
                cmbxPreguntaSeg.Items.Add("On what street is your first home located?");
                cmbxPreguntaSeg.Items.Add("What is your favorite ice cream flavor?");
                seleccionaImagen = "Select image";
                error = "  Contact an administrator.";
                cuidado = "Warning:";
                rellenar = "You must complete all the data ";
                corta = "the password is too short ";
                distintas = "Passwords do not match";
                existe = "That ID is already entered";
                real = "The ID must be real"; 
                msgModificar = "Do you want to eliminate ";
                titModificar = "Modify profile";
                modificado = "Your data has been modified";
                msgBorrar = "Do you want to delete your profile?";
                titBorrar = "Delete profile";
                borrado = "User delete";
            */
            
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxSolicitudesNav.Image = Image.FromFile("solicitudes admin gris.png");
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno blanco.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente gris.png");
                pbxABMGruposNav.Image = Image.FromFile("abm grupos gris.png");
                pbxHistorialSolicitudesNav.Image = Image.FromFile("historial gris.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxBuscarModificar.Image = Image.FromFile("buscar.png");
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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxFotoModificar.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxBuscarModificar.SizeMode = PictureBoxSizeMode.StretchImage;
            cmbxClase.Enabled = false;
            cmbxAnio.Enabled = false;
            cmbxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxPreguntaSeg.DropDownStyle = ComboBoxStyle.DropDownList;
            
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
            DialogResult cerrarSesion = MessageBox.Show(msgCerrarSesion, cerrarSesionTitulo, MessageBoxButtons.YesNo);
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
            panelModificarClases.Visible = false;
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
            panelModificarClases.Visible = false;
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
            panelModificarClases.Visible = false;
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
            btnAgregar.Enabled = true;
            claseSeleccionada = new Logica.Clase();
            cursaAsigs = new List<Logica.AsignaturaCursa>();

            asigs = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientaciones[cmbxOrientacion.SelectedIndex].Id);
            orientacionSeleccionada  = orientaciones[cmbxOrientacion.SelectedIndex];
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
            if (panelModificarClases.Visible)
            {
                int ychbx = 10, xchbx = 10;
                foreach (Logica.Asignatura asig in asigs)
                {
                    CheckBox dina = new CheckBox();
                    dina.Checked = false;
                    foreach (Logica.AsignaturaCursa cursaAsig in cursaAsigs)
                    {
                        if (cursaAsig.AsignaturaCursada == asig.Id && cursaAsig.IdClase == claseSeleccionada.IdClase && cursaAsig.Orientacion == orientacionSeleccionada.Id && cursaAsig.AsignaturaCursada == asig.Id)
                        {
                            dina.Checked = true;
                        }
                    }
                    dina.Height = 50;
                    dina.Width = 150;
                    dina.ForeColor = Color.DimGray;
                    dina.Font = new Font("arial", 10);
                    dina.Location = new Point(xchbx, ychbx);
                    if (xchbx == 185)
                    {
                        xchbx = -165;
                        ychbx += 55;
                    }
                    xchbx += 175;
                    dina.Name = "chbx" + asig.Id;
                    dina.Text = asig.Nombre;

                    dina.CheckedChanged += new EventHandler(AsignaturaCambiada);
                    panelModificarClases.Controls.Add(dina);
                }
            }
            else
            {
                panelModificarClases.Controls.Clear();
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

            string error = yaIngresadas;
            bool mandable = true;
            foreach (Logica.AsignaturaCursa asigPend in cursaAsigs)
            {
                foreach (Logica.AsignaturaCursa asigCursa in cursaAsigsConfirmadas)
                {
                    if (asigPend.Orientacion == asigCursa.Orientacion && asigPend.AsignaturaCursada == asigCursa.AsignaturaCursada)
                    {
                        Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.AsignaturaCursada);
                        error += "\n" + asi.Nombre;
                        mandable = false;
                    }
                }
            }
            if (mandable)
            {
                cursaAsigsConfirmadas.AddRange(cursaAsigs);
                Logica.Cursa cursa = new Logica.Cursa();
                cursa.IdClase = claseSeleccionada.IdClase;
                cursa.Orientacion = orientacionSeleccionada.Id;
                cursa.Anio = DateTime.Now.Year;
                if (!cursas.Contains(cursa))
                {
                    Label grupo = new Label();
                    grupo.Height = 60;
                    grupo.Width = 100;
                    grupo.Location = new Point(0, 0);
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lblClase" + claseSeleccionada.IdClase;
                    grupo.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre + "  (" + cursaAsigs.Count + ")" + "\n" + orientaciones[cmbxOrientacion.SelectedIndex].Nombre;
                    grupo.Click += new EventHandler(EliminarClase);

                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile("cruz negra.png");
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 20;
                    pic.Width = 20;
                    pic.Location = new Point(115, 20);
                    pic.Name = "pbxClase" + claseSeleccionada.IdClase;
                    pic.Click += new EventHandler(EliminarClase);

                    Panel panel = new Panel();
                    panel.Height = 60;
                    panel.Width = 150;
                    panel.Location = new Point(0, yPanel);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    yPanel += 60;
                    panel.Name = "pnlClase" + claseSeleccionada.IdClase;
                    panel.BackColor = Color.White;
                    panel.Click += new EventHandler(EliminarClase);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(pic);

                    panelClasesAgregadas.Controls.Add(panel);
                    cursas.Add(cursa);
                    btnAltaAlumno.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show(error);
            }
            panelModificarClases.Controls.Clear();
            cmbxOrientacion.SelectedIndex = -1;
            cmbxAnio.Items.Clear();
            cmbxClase.Items.Clear();


            cmbxAnio.Enabled = false;
            cmbxClase.Enabled = false;
            btnAgregar.Enabled = false;

            cursaAsigs = new List<Logica.AsignaturaCursa>();
            claseSeleccionada = new Logica.Clase();
            orientacionSeleccionada = new Logica.Orientacion();
        }

        private void EliminarClase(object sender, EventArgs e)
        {
            List<Logica.AsignaturaCursa> encontradas = new List<Logica.AsignaturaCursa>();
            foreach (Logica.AsignaturaCursa asigCursa in cursaAsigsConfirmadas)
            {
                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + asigCursa.IdClase)
                    {
                        encontradas.Add(asigCursa);
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + asigCursa.IdClase)
                    {
                        encontradas.Add(asigCursa);
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + asigCursa.IdClase)
                    {
                        encontradas.Add(asigCursa);
                    }
                }

            }
            foreach (Logica.AsignaturaCursa asigSoli in encontradas)
            {
                cursaAsigsConfirmadas.Remove(asigSoli);
            }
            Logica.Cursa encontrada = new Logica.Cursa();
            foreach (Logica.Cursa cursa in cursas)
            {
                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + cursa.IdClase)
                    {
                        encontrada = cursa;
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + cursa.IdClase)
                    {
                        encontrada = cursa;
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + cursa.IdClase)
                    {
                        encontrada = cursa;
                    }
                }


            }
            cursas.Remove(encontrada);
            panelClasesAgregadas.Controls.Clear();
            yPanel = 0;
            foreach (Logica.Cursa cursa in cursas)
            {
                Logica.Clase clase = new Logica.Clase().SelectClasePorId(cursa.IdClase);
                Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
                List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
                foreach (Logica.AsignaturaCursa asigCursa in cursaAsigs)
                {
                    if (asigCursa.IdClase == clase.IdClase)
                    {
                        asignaturas.Add(new Logica.Asignatura().SelectAsignaturaPorId(asigCursa.AsignaturaCursada));
                    }
                }

                Label grupo = new Label();
                grupo.Height = 60;
                grupo.Width = 100;
                grupo.Location = new Point(0, 0);
                grupo.Font = new Font("Arial", 12.0f);
                grupo.Name = "lblClase" + clase.IdClase;
                grupo.Text = clase.Anio + "º" + clase.Nombre + "  (" + asignaturas.Count + ")" + "\n" + orientacion.Nombre;
                grupo.Click += new EventHandler(EliminarClase);

                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile("cruz negra.png");
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Height = 20;
                pic.Width = 20;
                pic.Location = new Point(115, 20);
                pic.Name = "pbxClase" + clase.IdClase;
                pic.Click += new EventHandler(EliminarClase);

                Panel panel = new Panel();
                panel.Height = 60;
                panel.Width = 150;
                panel.Location = new Point(0, yPanel);
                panel.BorderStyle = BorderStyle.FixedSingle;
                yPanel += 60;
                panel.Name = "pnlClase" + clase.IdClase;
                panel.BackColor = Color.White;
                panel.Click += new EventHandler(EliminarClase);
                panel.Controls.Add(grupo);
                panel.Controls.Add(pic);

                panelClasesAgregadas.Controls.Add(panel);


            }
            btnAltaAlumno.Enabled = false;
            if (cursas.Count > 0)
            {
                btnAltaAlumno.Enabled = true;
            }
        }

        private void btnAltaAlumno_Click(object sender, EventArgs e)
        {
            string error = cuidado;
            bool aceptable = true;
            Logica.Alumno alu = new Logica.Alumno();
            if (alu.NumerosEnStrings(txtNombre.Text))
            {
                error += "\n" + nombreNumerico;
                aceptable = false;
            }

            if (alu.NumerosEnStrings(txtPrimerApellido.Text))
            {
                error += "\n" + apellidoNumerico;
                aceptable = false;
            }

            if (alu.NumerosEnStrings(txtSegundoApellido.Text))
            {
                error += "\n" + sApellidoNumerico;
                aceptable = false;
            }
            if (alu.campoVacio(txtCedula.Text) || alu.campoVacio(txtNombre.Text) || alu.campoVacio(txtPrimerApellido.Text) || alu.campoVacio(txtSegundoApellido.Text) || alu.campoVacio(txtPassword.Text) || alu.campoVacio(txtConfirmarPassword.Text) || alu.campoVacio(txtRespuesta.Text) || alu.sinPregunta(cmbxPreguntaSeg.SelectedIndex))
            {
                aceptable = false;
                error += "\n" + rellenar;
            }
            if (!alu.VerficarCedula(txtCedula.Text))
            {
                aceptable = false;
                error += "\n" + real;
            }
            if (alu.TamañoIncorrecto(txtNombre.Text) || alu.TamañoIncorrecto(txtPrimerApellido.Text) || alu.TamañoIncorrecto(txtSegundoApellido.Text) || alu.TamañoIncorrecto(txtPassword.Text) || alu.TamañoIncorrecto(txtConfirmarPassword.Text) || alu.TamañoIncorrecto(txtRespuesta.Text))
            {
                aceptable = false;
                error += "\n" + grandes;
            }

            if (alu.TamañoMinimoContra(txtPassword.Text))
            {
                aceptable = false;
                error += "\n" + corta;
            }
            if (!(txtConfirmarPassword.Text == txtPassword.Text))
            {
                aceptable = false;
                error += "\n" + distintas;
            }

            if (alu.ExisteUsuarioCi(txtCedula.Text))
            {
                aceptable = false;
                error += "\n\n" + existe;
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
                string fallo = this.fallo;
                bool ingreso = false;
                foreach (Logica.Cursa cursa in cursas)
                {
                    cursa.CiAlumno = alu.Ci;
                    if (!cursa.SelectCursando())
                    {
                        cursa.InsertCursa();
                    }
                }
                foreach (Logica.AsignaturaCursa asigCursa in cursaAsigsConfirmadas)
                {
                    asigCursa.Ci = alu.Ci;
                    if (asigCursa.SelectCursandoAsignatura())
                    {
                        if (asigCursa.SelectCursandoAsignaturaDesactivada())
                        {
                            asigCursa.ActivarAsignaturaCursa();
                            ingreso = true;
                        }
                        else
                        {
                            fallo += "\n- " + new Logica.Asignatura().SelectAsignaturaPorId(asigCursa.AsignaturaCursada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigCursa.Orientacion).Nombre;
                        }
                    }
                    else
                    {
                        asigCursa.InsertAsignaturaCursa();
                        ingreso = true;
                    }
                }
                MessageBox.Show(creado);
                if (ingreso)
                {
                    MessageBox.Show(ingresadas);
                }
                if (fallo != this.fallo)
                {
                    MessageBox.Show(fallo);
                }

                
                txtCedula.Text = "";
                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtPassword.Text = "";
                txtConfirmarPassword.Text = "";
                cmbxPreguntaSeg.SelectedIndex = -1;
                txtRespuesta.Text = "";
                orientaciones = new List<Logica.Orientacion>(new Logica.Orientacion().SelectOrientaciones());
                orientacionSeleccionada = new Logica.Orientacion();
                asigs = new List<Logica.Asignatura>();
                cursaAsigs = new List<Logica.AsignaturaCursa>();
                cursaAsigsConfirmadas = new List<Logica.AsignaturaCursa>();
                cursas = new List<Logica.Cursa>();
                claseSeleccionada = new Logica.Clase();

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
            if (al.Ci != "" && al.SelectAlumno())
            {
                DialogResult eliminarAlumno = MessageBox.Show(msgBorrar + al.Nombre + " " + al.Primer_apellido + "?", titBorrar, MessageBoxButtons.YesNo);
                if (eliminarAlumno == DialogResult.Yes)
                {
                    al.RemoveUsuario();
                    MessageBox.Show(borrado);
                    txtBajaCi.Text = "";
                }
            }
            else
            {
                MessageBox.Show(eliminadont);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            panelAlta.Visible = false;
            panelBaja.Visible = false;
            panelModificar.Visible = !panelModificar.Visible;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
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
                txtRespuesta.Text = alModif.Respuesta_seguridad;
            }
            else
            {
                MessageBox.Show(eliminadont);
            }
        }
        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFoto = new OpenFileDialog();
            ofdFoto.Filter = "Imagenes|*.jpeg;*.jpg;*.png";
            ofdFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdFoto.Title = seleccionaImagen;
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFotoModificar.Image = Image.FromFile(ofdFoto.FileName);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult eliminarAlumno = MessageBox.Show(msgModificar, titModificar, MessageBoxButtons.YesNo);
            if (eliminarAlumno == DialogResult.Yes)
            {
                alModif.Apodo = txtApodoModificar.Text;
                alModif.Password = txtPasswordModificar.Text;
                alModif.Respuesta_seguridad = txtRespuesta.Text;
                alModif.Preguta_seguridad = (cbxPregsModificar.SelectedIndex + 1);
                alModif.FotoDePerfil = alModif.ImageToByteArray(pbxFotoModificar.Image);
                alModif.UpdatePerfil();
                MessageBox.Show(modificado);
                txtApodoModificar.Text = "";
                txtPassword.Text = "";
                txtRespuesta.Text = "";
                cbxPregsModificar.SelectedIndex = -1;
                pbxFotoModificar.Image = null;
                txtCiModif.Text = "";
            }
        }

    }
}
