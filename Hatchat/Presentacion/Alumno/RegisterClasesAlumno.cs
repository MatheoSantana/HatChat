using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class RegisterClasesAlumno : Form
    {
        string error;
        string yaIngresadas;
        string creado;
        Image imagenCruz;
        Image imagenAlumno;

        bool visibles=false;
        public Form login;
        public Form registerAlumno;
        private int xpanel=20;

        List<Logica.ClaseSolicitudClaseAl> claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();
        Logica.Clase claseSeleccionada = new Logica.Clase();
        List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();
        List<Logica.Asignatura> nuevasAsignaturas = new List<Logica.Asignatura>();
        private Logica.Alumno alumno = new Logica.Alumno();


        public RegisterClasesAlumno()
        {
            InitializeComponent();
            Text = "Register clase Alumno";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            if (Login.idioma == "Español")
            {
                error = " comuníquese con el administrador.";
                lblTitulo.Text = "Crea tu cuenta de alumno";
                lblIngresarA.Text = "Ingresar a...";
                lblAnio.Text = "Año:";
                lblClase.Text = "Clase:";
                lblInfoModif.Text = "Si no pertenece a todas las \nasignaturas configurelas\naquí:";
                lblOrientacion.Text = "orientación:";
                btnAgregar.Text = "Agregar";
                btnModificar.Text = "Modificar";
                btnRegistrar.Text = "registrar";

                yaIngresadas = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
                creado = "Se ha creado el alumno correctamente\nVolviendo al Login";

            }
            else
            {
                error = "  Contact an administrator.";
                lblTitulo.Text = "Create your Student account";
                lblIngresarA.Text = "Enter...";
                lblAnio.Text = "Year:";
                lblClase.Text = "Class:";
                lblInfoModif.Text = "If it does not belong to\ncourse configure them here:";
                lblOrientacion.Text = "Orientation:";
                btnAgregar.Text = "Agree";
                btnModificar.Text = "Modify";
                btnRegistrar.Text = "Create Account";

                yaIngresadas = "Application denied, already on request to enter the following subjects: ";
                creado = "The student has been created correctly\nReturning to Login";

            }
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxVolver.Image = Image.FromFile("volver.png");
                imagenCruz=Image.FromFile("cruz negra.png");
                imagenAlumno = Image.FromFile("alumno.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

            }
            pbxVolver.SizeMode = PictureBoxSizeMode.StretchImage;

            cbxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxClases.DropDownStyle = ComboBoxStyle.DropDownList;
            panelAsignaturas.AutoScroll = true;
            panelAgregadas.AutoScroll = true;

            cbxAnio.Items.Clear();
            cbxClases.Items.Clear();
            cbxOrientacion.Items.Clear();
            panelAsignaturas.Controls.Clear();

            cbxAnio.Enabled = false;
            cbxClases.Enabled = false;
            btnAgregar.Enabled = false;
            btnRegistrar.Enabled = false;

            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturasSolicitudClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();
            claseSeleccionada = new Logica.Clase();
            orientaciones = new List<Logica.Orientacion>();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            orientaciones = new Logica.Orientacion().SelectOrientaciones();
            foreach (Logica.Orientacion ori in orientaciones)
            {
                cbxOrientacion.Items.Add(ori.Nombre);
            }

        }
        public Logica.Alumno Alumno
        {
            set { alumno = value; }
        }
        private void RegisterClasesAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }


        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxVolver_Click(object sender, EventArgs e)
        {
            registerAlumno.Show();
            this.Dispose();
        }

        private void cbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibles = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseAl> encontradas = new List<Logica.AsignaturaSolicitudClaseAl>();
                foreach (Logica.AsignaturaSolicitudClaseAl asigSolicita in asignaturasSolicitudClaseAlPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseAl asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseAlPre.Remove(asigEncontrada);
                }
            }

            cbxAnio.Items.Clear();
            cbxClases.Items.Clear();
            panelAsignaturas.Controls.Clear();
            cbxAnio.Enabled = true;
            cbxClases.Enabled = false;
            btnAgregar.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
            asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();
            if (cbxOrientacion.SelectedIndex != -1)
            {
                List<int> anios = new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientaciones[cbxOrientacion.SelectedIndex].Id));


                foreach (int anio in anios)
                {
                    cbxAnio.Items.Add(anio.ToString());
                }
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibles = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseAl> encontradas = new List<Logica.AsignaturaSolicitudClaseAl>();
                foreach (Logica.AsignaturaSolicitudClaseAl asigSolicita in asignaturasSolicitudClaseAlPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseAl asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseAlPre.Remove(asigEncontrada);
                }
            }

            cbxClases.Items.Clear();
            panelAsignaturas.Controls.Clear();
            cbxClases.Enabled = true;
            btnAgregar.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
            asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();

            List<Logica.Clase> clases = new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cbxAnio.SelectedItem.ToString()));
            if (cbxOrientacion.SelectedIndex != -1)
            {
                foreach (Logica.Clase cla in clases)
                {
                    if (cla.Orientacion == orientaciones[cbxOrientacion.SelectedIndex].Id)
                    {
                        cbxClases.Items.Add(cla.Nombre);
                    }
                }
            }
        }
        private void cbxClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibles = false;
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseAl> encontradas = new List<Logica.AsignaturaSolicitudClaseAl>();
                foreach (Logica.AsignaturaSolicitudClaseAl asigSolicita in asignaturasSolicitudClaseAlPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseAl asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseAlPre.Remove(asigEncontrada);
                }

            }
            panelAsignaturas.Controls.Clear();
            btnAgregar.Enabled = true;

            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
            asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();

            nuevasAsignaturas = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cbxClases.SelectedItem.ToString(), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), orientaciones[cbxOrientacion.SelectedIndex].Id);

            claseSeleccionada.Nombre = cbxClases.SelectedItem.ToString();
            claseSeleccionada.Anio = Convert.ToInt32(cbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientaciones[cbxOrientacion.SelectedIndex].Id;
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            
            foreach (Logica.Asignatura asig in nuevasAsignaturas)
            {
                Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl = new Logica.AsignaturaSolicitudClaseAl();
                asignaturaSolicitudClaseAl.IdAsignatura = asig.Id;
                asignaturaSolicitudClaseAl.IdClaseAsig = claseSeleccionada.IdClase;
                asignaturaSolicitudClaseAl.OriClaseAsig = claseSeleccionada.Orientacion;
                asignaturaSolicitudClaseAl.Aceptada = false;
                asignaturasSolicitudClaseAlPre.Add(asignaturaSolicitudClaseAl);
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
                        asignaturasSolicitudClaseAlPre.Add(asignaturaSolicitudClaseAl);
                    }

                }
            }
            else
            {
                Logica.AsignaturaSolicitudClaseAl encontrado = new Logica.AsignaturaSolicitudClaseAl();
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAlPre)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && asignaturaSolicitudClaseAl.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseAl.OriClaseAsig == claseSeleccionada.Orientacion && asignaturaSolicitudClaseAl.IdAsignatura == asig.Id)
                        {
                            encontrado = asignaturaSolicitudClaseAl;
                        }
                    }
                }
                asignaturasSolicitudClaseAlPre.Remove(encontrado);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelAgregadas.AutoScrollPosition = Point.Empty;

            string error = yaIngresadas;
            bool mandable = true;
            foreach (Logica.AsignaturaSolicitudClaseAl asigPend in asignaturasSolicitudClaseAlPre)
            {
                foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                {
                    if (asigPend.OriClaseAsig == asignaturaSolicitudClaseAl.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseAl.IdAsignatura)
                    {
                        Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.IdAsignatura);
                        error += "\n" + asi.Nombre;
                        mandable = false;
                    }
                }
            }
            if (mandable)
            {
                asignaturasSolicitudClaseAl.AddRange(asignaturasSolicitudClaseAlPre);
                Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl(claseSeleccionada.IdClase, orientaciones[cbxOrientacion.SelectedIndex].Id);
                if (!claseSolicitudesClaseAl.Contains(claseSolicitudClaseAl))
                {

                    Label grupo = new Label();
                    grupo.Height = 60;
                    grupo.Width = 100;
                    grupo.Location = new Point(0, 0);
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lblClase" + claseSeleccionada.IdClase;
                    grupo.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre + "  ("+ asignaturasSolicitudClaseAlPre.Count+")" + "\n" + orientaciones[cbxOrientacion.SelectedIndex].Nombre;
                    grupo.Click += new EventHandler(EliminarClase);

                    PictureBox pic = new PictureBox();
                    pic.Image = imagenCruz;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Height = 20;
                    pic.Width = 20;
                    pic.Location = new Point(115, 20);
                    pic.Name = "pbxClase" + claseSeleccionada.IdClase;
                    pic.Click += new EventHandler(EliminarClase);

                    Panel panel = new Panel();
                    panel.Height = 60;
                    panel.Width = 150;
                    panel.Location = new Point(xpanel, 0);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    xpanel += 170;
                    panel.Name = "pnlClase" + claseSeleccionada.IdClase;
                    panel.BackColor = Color.White;
                    panel.Click += new EventHandler(EliminarClase);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(pic);

                    panelAgregadas.Controls.Add(panel);
                    claseSolicitudesClaseAl.Add(claseSolicitudClaseAl);
                    btnRegistrar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(error);
            }
            panelAsignaturas.Controls.Clear();
            cbxAnio.Items.Clear();
            cbxClases.Items.Clear();
            cbxOrientacion.SelectedIndex = -1;

            cbxAnio.Enabled = false;
            cbxClases.Enabled = false;
            btnAgregar.Enabled = false;

            asignaturasSolicitudClaseAlPre = new List<Logica.AsignaturaSolicitudClaseAl>();
            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();

        }
        private void EliminarClase(object sender, EventArgs e)
        {
            List<Logica.AsignaturaSolicitudClaseAl> encontradas = new List<Logica.AsignaturaSolicitudClaseAl>();
            foreach (Logica.AsignaturaSolicitudClaseAl asigSoli in asignaturasSolicitudClaseAl)
            {


                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + asigSoli.IdClaseAsig)
                    {
                        encontradas.Add(asigSoli);
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + asigSoli.IdClaseAsig)
                    {
                        encontradas.Add(asigSoli);
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + asigSoli.IdClaseAsig)
                    {
                        encontradas.Add(asigSoli);
                    }
                }
                
            }
            foreach (Logica.AsignaturaSolicitudClaseAl asigSoli in encontradas)
            {
                asignaturasSolicitudClaseAl.Remove(asigSoli);
            }
            Logica.ClaseSolicitudClaseAl encontrada = new Logica.ClaseSolicitudClaseAl();
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (((Label)sender).Name == "lblClase" + claseSoli.IdClase)
                    {
                        encontrada = claseSoli;
                    }
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    if (((PictureBox)sender).Name == "pbxClase" + claseSoli.IdClase)
                    {
                        encontrada = claseSoli;
                    }
                }
                else
                {
                    if (((Panel)sender).Name == "pnlClase" + claseSoli.IdClase)
                    {
                        encontrada = claseSoli;
                    }
                }
                
                
            }
            claseSolicitudesClaseAl.Remove(encontrada);
            panelAgregadas.Controls.Clear();
            xpanel = 20;
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                Logica.Clase clase = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
                List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoli in asignaturasSolicitudClaseAl)
                {
                    if (asigSoli.IdClaseAsig == clase.IdClase)
                    {
                        asignaturas.Add(new Logica.Asignatura().SelectAsignaturaPorId(asigSoli.IdAsignatura));
                    }
                }

                Label grupo = new Label();
                grupo.Height = 30;
                grupo.Width = 150;
                grupo.Location = new Point(0, 0);
                grupo.Font = new Font("Arial", 12.0f);
                grupo.Name = "lblClase" + clase.IdClase;
                grupo.Text = clase.Anio + "º" + clase.Nombre + "(" + asignaturas.Count + ")" + "\n" + orientacion.Nombre;
                grupo.Click += new EventHandler(EliminarClase);

                PictureBox pic = new PictureBox();
                pic.Image = imagenCruz;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Height = 20;
                pic.Width = 20;
                pic.Location = new Point(150, 20);
                pic.Name = "pbxClase" + clase.IdClase;
                pic.Click += new EventHandler(EliminarClase);

                Panel panel = new Panel();
                panel.Height = 30;
                panel.Width = 200;
                panel.Location = new Point(xpanel, 0);

                xpanel += 170;
                panel.Name = "pnlClase" + clase.IdClase;
                panel.BackColor = Color.White;
                panel.Click += new EventHandler(EliminarClase);
                panel.Controls.Add(grupo);
                panel.Controls.Add(pic);

                panelAgregadas.Controls.Add(panel);

                
            }
            btnRegistrar.Enabled = false;
            if (claseSolicitudesClaseAl.Count > 0)
            {
                btnRegistrar.Enabled = true;
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            alumno.Activo = true;
            alumno.FotoDePerfil = alumno.ImageToByteArray(imagenAlumno);
            alumno.AltaUsuario();
            Logica.SolicitudClaseAl solicitudClaseAl = new Logica.SolicitudClaseAl(DateTime.Now, true, alumno.Ci);
            solicitudClaseAl.EnviarSolicitudClaseAl();
            solicitudClaseAl.IdSolicitudClaseAl= solicitudClaseAl.SelectIdSolicitudClaseAl();
            foreach (Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl in claseSolicitudesClaseAl)
            {
                claseSolicitudClaseAl.IdSolicitudClaseAl = solicitudClaseAl.IdSolicitudClaseAl;
                claseSolicitudClaseAl.EnviarClaseSolicitudClaseAl();
            }
            foreach (Logica.AsignaturaSolicitudClaseAl soliAsig in asignaturasSolicitudClaseAl)
            {
                soliAsig.IdSolicitudClaseAl = solicitudClaseAl.IdSolicitudClaseAl;
                soliAsig.Aceptada = true;
                soliAsig.EnviarAsignaturaSolicitudClaseAl();
            }

            MessageBox.Show(creado);
            login.Show();
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            visibles = !visibles;
            if (visibles)
            {
                int ychbx = 10, xchbx = 10;
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    CheckBox dina = new CheckBox();
                    dina.Checked = false;
                    foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAlPre)
                    {
                        if (asignaturaSolicitudClaseAl.IdAsignatura == asig.Id && asignaturaSolicitudClaseAl.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseAl.OriClaseAsig == claseSeleccionada.Orientacion)
                        {
                            dina.Checked = true;
                        }
                    }
                    dina.Height = 23;
                    dina.Width = 150;
                    dina.Location = new Point(xchbx, ychbx);
                    if (xchbx == 360)
                    {
                        xchbx = -165;
                        ychbx += 25;
                    }
                    xchbx += 175;
                    dina.Name = "chbx" + asig.Id;
                    dina.Text = asig.Nombre;

                    dina.CheckedChanged += new EventHandler(AsignaturaCambiada);
                    panelAsignaturas.Controls.Add(dina);
                }
            }
            else
            {
                panelAsignaturas.Controls.Clear();
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}