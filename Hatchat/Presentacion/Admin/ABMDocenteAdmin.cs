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
        string nombreNumerico;
        string apellidoNumerico;
        string sApellidoNumerico;
        string grandes;
        string error;
        string cuidado;
        string corta;
        string distintas;
        string rellenar;
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
        private List<Logica.AsignaturaDictada> dictaAsigs = new List<Logica.AsignaturaDictada>();
        private List<Logica.AsignaturaDictada> dictaAsigsConfirmadas = new List<Logica.AsignaturaDictada>();
        private List<Logica.Dicta> dictas = new List<Logica.Dicta>();
        private Logica.Clase claseSeleccionada = new Logica.Clase();
        
        Logica.Usuario doModif = new Logica.Usuario();
        
        Logica.Usuario doAgenda = new Logica.Usuario();
        List<Logica.Agenda> agendas = new List<Logica.Agenda>();
        bool lu = false, ma = false, mi = false, ju = false, vi = false;

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
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            if (Login.idioma == "Español")
            {
                
                msgModificar = "¿Desea modificar su perfil?";
                titModificar = "Modificar perfil";
                modificado = "Se han modificado sus datos";
                msgBorrar = "¿Desea eliminar a ";
                titBorrar = "Borrar Perfil";
                borrado = "Usuario eliminado";
                seleccionaImagen = "Seleccionar imagen";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";

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
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                pcbxBuscarModificar.Image=Image.FromFile("buscar.png");
                pcbxBuscarAgenda.Image = Image.FromFile("buscar.png");
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
            pcbxBuscarAgenda.SizeMode = PictureBoxSizeMode.StretchImage;

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
                cbxPregsModificar.Items.Add(preg.Pregunta);

            }
            cbxPregsModificar.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbxPreguntaSeg.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            for (int x = 0; x < 24; x++)
            {
                cmbxHoraInicio.Items.Add(x);
                cmbxHoraCierre.Items.Add(x);
            }
            for (int x = 0; x < 60; x = x + 5)
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
            panelModificarClases.Visible = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaDictada> encontradas = new List<Logica.AsignaturaDictada>();
                foreach (Logica.AsignaturaDictada asigSolicita in dictaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaDictada asigEncontrada in encontradas)
                {
                    dictaAsigs.Remove(asigEncontrada);
                }
            }

            cmbxAnio.Items.Clear();
            cmbxClase.Items.Clear();
            panelModificarClases.Controls.Clear();
            cmbxAnio.Enabled = true;
            cmbxClase.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            asigs = new List<Logica.Asignatura>();
            dictaAsigs = new List<Logica.AsignaturaDictada>();
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
                List<Logica.AsignaturaDictada> encontradas = new List<Logica.AsignaturaDictada>();
                foreach (Logica.AsignaturaDictada asigSolicita in dictaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaDictada asigEncontrada in encontradas)
                {
                    dictaAsigs.Remove(asigEncontrada);
                }
            }
            cmbxClase.Items.Clear();
            panelModificarClases.Controls.Clear();
            cmbxClase.Enabled = true;

            claseSeleccionada = new Logica.Clase();
            asigs = new List<Logica.Asignatura>();
            dictaAsigs = new List<Logica.AsignaturaDictada>();

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
            panelModificarClases.Visible = true;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaDictada> encontradas = new List<Logica.AsignaturaDictada>();
                foreach (Logica.AsignaturaDictada asigSolicita in dictaAsigs)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClase && claseSeleccionada.Orientacion == asigSolicita.Orientacion)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaDictada asigEncontrada in encontradas)
                {
                    dictaAsigs.Remove(asigEncontrada);
                }
            }
            panelModificarClases.Controls.Clear();
            btnAgregar.Enabled = true;
            claseSeleccionada = new Logica.Clase();
            dictaAsigs = new List<Logica.AsignaturaDictada>();

            asigs = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cmbxClase.SelectedItem.ToString(), Convert.ToInt32(cmbxAnio.SelectedItem.ToString()), orientaciones[cmbxOrientacion.SelectedIndex].Id);
            orientacionSeleccionada = orientaciones[cmbxOrientacion.SelectedIndex];
            claseSeleccionada.Nombre = cmbxClase.SelectedItem.ToString();
            claseSeleccionada.Anio = Convert.ToInt32(cmbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientaciones[cmbxOrientacion.SelectedIndex].Id;
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            int ychbx = 10, xchbx = 10;
            foreach (Logica.Asignatura asig in asigs)
            {
                CheckBox dina = new CheckBox();
                dina.Checked = false;
                foreach (Logica.AsignaturaDictada dictaAsig in dictaAsigs)
                {
                    if (dictaAsig.AsigDictada == asig.Id && dictaAsig.IdClase == claseSeleccionada.IdClase && dictaAsig.Orientacion == orientacionSeleccionada.Id && dictaAsig.AsigDictada == asig.Id)
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

            string error = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
            bool mandable = true;
            foreach (Logica.AsignaturaDictada asigPend in dictaAsigs)
            {
                foreach (Logica.AsignaturaDictada asigDicta in dictaAsigsConfirmadas)
                {
                    if (asigPend.Orientacion == asigDicta.Orientacion && asigPend.AsigDictada == asigDicta.AsigDictada && asigPend.IdClase == asigDicta.IdClase)
                    {
                        Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.AsigDictada);
                        error += "\n" + asi.Nombre;
                        mandable = false;
                    }
                }
            }
            if (mandable)
            {
                dictaAsigsConfirmadas.AddRange(dictaAsigs);
                Logica.Dicta dicta = new Logica.Dicta();
                dicta.IdClase = claseSeleccionada.IdClase;
                dicta.Orientacion = orientacionSeleccionada.Id;
                dicta.Anio = DateTime.Now.Year;
                if (!dictas.Contains(dicta))
                {
                    Label grupo = new Label();
                    grupo.Height = 60;
                    grupo.Width = 100;
                    grupo.Location = new Point(0, 0);
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lblClase" + claseSeleccionada.IdClase;
                    grupo.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre + "  (" + dictaAsigs.Count + ")" + "\n" + orientaciones[cmbxOrientacion.SelectedIndex].Nombre;
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
                    dictas.Add(dicta);
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

            dictaAsigs = new List<Logica.AsignaturaDictada>();
            claseSeleccionada = new Logica.Clase();
            orientacionSeleccionada = new Logica.Orientacion();
        }
        private void EliminarClase(object sender, EventArgs e)
        {
            List<Logica.AsignaturaDictada> encontradas = new List<Logica.AsignaturaDictada>();
            foreach (Logica.AsignaturaDictada asigDicta in dictaAsigsConfirmadas)
            {
                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + asigDicta.IdClase)
                    {
                        encontradas.Add(asigDicta);
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + asigDicta.IdClase)
                    {
                        encontradas.Add(asigDicta);
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + asigDicta.IdClase)
                    {
                        encontradas.Add(asigDicta);
                    }
                }

            }
            foreach (Logica.AsignaturaDictada asigSoli in encontradas)
            {
                dictaAsigsConfirmadas.Remove(asigSoli);
            }
            Logica.Dicta encontrada = new Logica.Dicta();
            foreach (Logica.Dicta dicta in dictas)
            {
                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + dicta.IdClase)
                    {
                        encontrada = dicta;
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + dicta.IdClase)
                    {
                        encontrada = dicta;
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + dicta.IdClase)
                    {
                        encontrada = dicta;
                    }
                }


            }
            dictas.Remove(encontrada);
            panelClasesAgregadas.Controls.Clear();
            yPanel = 0;
            foreach (Logica.Dicta dicta in dictas)
            {
                Logica.Clase clase = new Logica.Clase().SelectClasePorId(dicta.IdClase);
                Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
                List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
                foreach (Logica.AsignaturaDictada asigDicta in dictaAsigs)
                {
                    if (asigDicta.IdClase == clase.IdClase)
                    {
                        asignaturas.Add(new Logica.Asignatura().SelectAsignaturaPorId(asigDicta.AsigDictada));
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
            if (dictas.Count > 0)
            {
                btnAltaAlumno.Enabled = true;
            }
        }


        private void btnAltaDocente_Click(object sender, EventArgs e)
        {
            string error = "Cuidado: ";
            bool aceptable = true;
            Logica.Docente doc = new Logica.Docente();
            if (doc.NumerosEnStrings(txtNombre.Text))
            {
                error += "\n" + nombreNumerico;
                aceptable = false;
            }

            if (doc.NumerosEnStrings(txtPrimerApellido.Text))
            {
                error += "\n" + apellidoNumerico;
                aceptable = false;
            }

            if (doc.NumerosEnStrings(txtSegundoApellido.Text))
            {
                error += "\n" + sApellidoNumerico;
                aceptable = false;
            }
            if (doc.campoVacio(txtCedula.Text) || doc.campoVacio(txtNombre.Text) || doc.campoVacio(txtPrimerApellido.Text) || doc.campoVacio(txtSegundoApellido.Text) || doc.campoVacio(txtPassword.Text) || doc.campoVacio(txtConfirmarPassword.Text) || doc.campoVacio(txtRespuesta.Text) || doc.sinPregunta(cmbxPreguntaSeg.SelectedIndex))
            {
                aceptable = false;
                error += "\n" + rellenar;
            }
            if (!doc.VerficarCedula(txtCedula.Text))
            {
                aceptable = false;
                error += "\n" + real;
            }
            if (doc.TamañoIncorrecto(txtNombre.Text) || doc.TamañoIncorrecto(txtPrimerApellido.Text) || doc.TamañoIncorrecto(txtSegundoApellido.Text) || doc.TamañoIncorrecto(txtPassword.Text) || doc.TamañoIncorrecto(txtConfirmarPassword.Text) || doc.TamañoIncorrecto(txtRespuesta.Text))
            {
                aceptable = false;
                error += "\n" + grandes;
            }

            if (doc.TamañoMinimoContra(txtPassword.Text))
            {
                aceptable = false;
                error += "\n" + corta;
            }
            if (!(txtConfirmarPassword.Text == txtPassword.Text))
            {
                aceptable = false;
                error += "\n" + distintas;
            }

            if (doc.ExisteUsuarioCi(txtCedula.Text))
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

                string fallo = "Las siguientes asignaturas ya estaban registradas:";
                string ingresadas = "Las siguientes asignaturas fueron ingresadas con existo:";
                foreach (Logica.Dicta dicta in dictas)
                {
                    dicta.CiDocente = doc.Ci;
                    if (!dicta.SelectDictando())
                    {
                        dicta.InsertDicta();
                    }
                }
                foreach (Logica.AsignaturaDictada asigDicta in dictaAsigsConfirmadas)
                {
                    asigDicta.Ci = doc.Ci;
                    if (asigDicta.SelectDictandoAsignatura())
                    {
                        if (asigDicta.SelectDictandoAsignaturaDesactivada())
                        {
                            asigDicta.ActivarAsignaturaDicta();
                            ingresadas += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigDicta.AsigDictada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigDicta.Orientacion).Nombre;
                        }
                        else
                        {
                            fallo += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigDicta.AsigDictada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigDicta.Orientacion).Nombre;
                        }
                    }
                    else
                    {
                        asigDicta.InsertAsignaturaDictada();
                        ingresadas += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigDicta.AsigDictada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigDicta.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigDicta.Orientacion).Nombre;

                    }
                }
                MessageBox.Show("Se ha creado el docente correctamente");
                if (ingresadas != "Las siguientes asignaturas fueron ingresadas con existo:")
                {
                    MessageBox.Show(ingresadas);
                }
                if (ingresadas != "Las siguientes asignaturas ya estaban registradas:")
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
                dictaAsigs = new List<Logica.AsignaturaDictada>();
                dictaAsigsConfirmadas = new List<Logica.AsignaturaDictada>();
                dictas = new List<Logica.Dicta>();
                claseSeleccionada = new Logica.Clase();
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
            if (txtBajaCi.Text.Length == 8)
            {
                Logica.Usuario doce = new Logica.Usuario().SelectUsuarioCiActivo(txtBajaCi.Text);
                if (doce.Ci != "" && doce.SelectDocente())
                {
                    DialogResult eliminarAlumno = MessageBox.Show("¿Desea eliminar a " + doce.Nombre + " " + doce.Primer_apellido + "?", "Eliminar", MessageBoxButtons.YesNo);
                    if (eliminarAlumno == DialogResult.Yes)
                    {
                        doce.RemoveUsuario();
                        MessageBox.Show("Docente eliminado correctamente");
                        txtBajaCi.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Docente no encontrado");
                }
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
                doModif = new Logica.Usuario().SelectUsuarioCiActivo(txtCiModif.Text);
                lblNombreModificar.Text ="Nombre"+ doModif.Nombre + " " + doModif.Primer_apellido + " " + doModif.Segundo_apellido;
                lblCedulaModificar.Text ="Cedula"+ doModif.Ci;
                pbxFotoModificar.Image = doModif.ByteArrayToImage(doModif.FotoDePerfil);
                txtApodoModificar.Text = doModif.Apodo;
                txtPasswordModificar.Text = doModif.Password;
                txtPasswordConfirmarModificar.Text = doModif.Password;
                cbxPregsModificar.SelectedIndex = (doModif.SelectPreguntaSeguridad().Id - 1);
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
                pbxFotoModificar.Image = Image.FromFile(ofdFoto.FileName);
            }
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (doModif.Ci != null)
            {
                DialogResult eliminarDocente = MessageBox.Show("¿Desea modificar este perfil?", "Modificar", MessageBoxButtons.YesNo);
                if (eliminarDocente == DialogResult.Yes)
                {
                    doModif.Apodo = txtApodoModificar.Text;
                    doModif.Password = txtPasswordModificar.Text;
                    doModif.Respuesta_seguridad = txtRespuesta.Text;
                    doModif.Preguta_seguridad = (cbxPregsModificar.SelectedIndex + 1);
                    doModif.FotoDePerfil = doModif.ImageToByteArray(pbxFotoModificar.Image);
                    doModif.UpdatePerfil();

                    txtApodoModificar.Text = "";
                    txtPassword.Text = "";
                    txtRespuesta.Text = "";
                    cbxPregsModificar.SelectedIndex = -1;
                    pbxFotoModificar.Image = null;
                    txtCiModif.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe ingresar una usuario");
                }
            }
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
                doAgenda = new Logica.Usuario().SelectUsuarioCiActivo(txtCedulaAgenda.Text);
                panelDiasYHorarios.Visible = true;
                agendas = new Logica.Agenda().SelectAgendasPorCi(txtCedulaAgenda.Text);
                btnNuevaAgenda.Enabled = true;
            }
            else
            {
                MessageBox.Show("Docente no encontrado");
            }
        }
        private void btnLunes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(239, 136, 88);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Lunes");
        }


        private void btnMartes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(239, 136, 88);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Martes");
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(239, 136, 88);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Miercoles");
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(239, 136, 88);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Jueves");
        }



        private void btnViernes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(239, 136, 88);
            RecargarAgendaDelDia("Viernes");
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
                    linea.Width = 180;
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

                    PictureBox cruz = new PictureBox();
                    cruz.Height = 20;
                    cruz.Width = 20;
                    cruz.Location = new Point(160, 0);
                    cruz.Image = Image.FromFile("Cruz.png");
                    cruz.ForeColor = Color.White;
                    cruz.Name = "pcbxCruz" + agenda.IdAgenda.ToString();
                    cruz.SizeMode = PictureBoxSizeMode.StretchImage;
                    cruz.Click += new EventHandler(EliminarAgenda);

                    Panel panel = new Panel();
                    panel.Height = 20;
                    panel.Width = 288;
                    panel.Location = new Point(0, ypanel);
                    ypanel += 20;
                    panel.Name = "pnl" + agenda.IdAgenda.ToString();
                    panel.BackColor = Color.FromArgb(61, 53, 50);

                    panel.Controls.Add(horario);
                    panel.Controls.Add(cruz);
                    panel.Controls.Add(linea);

                    panelHorariosPorDia.Controls.Add(panel);

                }
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();

            List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();
            bool iguales = true;
            if (orientaciones.Count == this.orientaciones.Count)
            {
                for (int x = 0; x < orientaciones.Count; x++)
                {
                    if (!(orientaciones[x].Id == this.orientaciones[x].Id && orientaciones[x].Nombre == this.orientaciones[x].Nombre))
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
                this.orientaciones = orientaciones;
                cmbxOrientacion.Items.Clear();
                foreach (Logica.Orientacion ori in orientaciones)
                {
                    cmbxOrientacion.Items.Add(ori.Nombre);

                }
            }
        }
                private void EliminarAgenda(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Panel)sender).Name));
            }


            MessageBox.Show("Se ha eliminado la agenda");
        }

        private void btnNuevaAgenda_Click(object sender, EventArgs e)
        {
            PanelABM.Enabled = false;
            panelNav.Enabled = false;
            panelAgregarAgenda.Visible = true;
            panelDiasYHorarios.Visible = false;
        }

        private void btnAgregarNuevaAgenda_Click(object sender, EventArgs e)
        {
            if (!lu && !ma && !mi && !ju && !vi)
            {
                MessageBox.Show("No se ha seleccionado ningun dia");
            }
            else
            {
                if (lu)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = doAgenda.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Lunes";
                    agenda.AgregarAgenda();
                    lu = false;
                    btnLu.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (ma)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Martes";
                    agenda.AgregarAgenda();
                    ma = false;
                    btnMa.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (mi)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Miercoles";
                    agenda.AgregarAgenda();
                    mi = false;
                    btnMi.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (ju)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Jueves";
                    agenda.AgregarAgenda();
                    ju = false;
                    btnJu.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (vi)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Viernes";
                    agenda.AgregarAgenda();
                    vi = false;
                    btnVi.BackColor = Color.FromArgb(61, 53, 50);
                }
                MessageBox.Show("Se ha agendado correctamente");

                PanelABM.Enabled = true;
                panelNav.Enabled = true;
                panelAgregarAgenda.Visible = false;
                panelDiasYHorarios.Visible = true;
            }
        }

        private void btnLu_Click(object sender, EventArgs e)
        {
            lu = !lu;
            if (lu)
            {
                btnLu.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnLu.BackColor = Color.FromArgb(61, 53, 50);
            }
        }

        private void btnCerrarInformacion_Click(object sender, EventArgs e)
        {
            PanelABM.Enabled = true;
            panelNav.Enabled = true;
            panelAgregarAgenda.Visible = false;
            panelDiasYHorarios.Visible = true;
        }

        private void btnMa_Click(object sender, EventArgs e)
        {
            ma = !ma;
            if (ma)
            {
                btnMa.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnMa.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnMi_Click(object sender, EventArgs e)
        {
            mi = !mi;
            if (mi)
            {
                btnMi.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnMi.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnJu_Click(object sender, EventArgs e)
        {
            ju = !ju;
            if (ju)
            {
                btnJu.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnJu.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnVi_Click(object sender, EventArgs e)
        {
            vi = !vi;
            if (vi)
            {
                btnVi.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnVi.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
    }
}
