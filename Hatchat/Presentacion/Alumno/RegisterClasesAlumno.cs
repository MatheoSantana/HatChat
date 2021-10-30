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
        public Form login;
        public Form registerAlumno;
        private int xlbl = 50, ylbl = 50;

        Logica.SolicitudClaseAl solicitudClaseAl = new Logica.SolicitudClaseAl();
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

            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            lblTitulo.Text = "Crea tu cuenta de alumno";
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxVolver.Image = Image.FromFile("volver.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

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

            solicitudClaseAl = new Logica.SolicitudClaseAl();
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
                    asignaturasSolicitudClaseAl.Remove(asigEncontrada);
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

            foreach (int anio in new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientaciones[cbxOrientacion.SelectedIndex].Id)))
            {
                cbxAnio.Items.Add(anio.ToString());
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    asignaturasSolicitudClaseAl.Remove(asigEncontrada);
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

            foreach (Logica.Clase cla in clases)
            {
                cbxClases.Items.Add(cla);
            }
        }
        private void cbxClases_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    asignaturasSolicitudClaseAl.Remove(asigEncontrada);
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

            int ychbx = 50, xchbx = 50;
            foreach (Logica.Asignatura asig in nuevasAsignaturas)
            {
                Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl = new Logica.AsignaturaSolicitudClaseAl();
                asignaturaSolicitudClaseAl.IdAsignatura = asig.Id;
                asignaturaSolicitudClaseAl.IdClaseAsig = claseSeleccionada.IdClase;
                asignaturaSolicitudClaseAl.OriClaseAsig = claseSeleccionada.Orientacion;
                asignaturaSolicitudClaseAl.Aceptada = false;
                asignaturasSolicitudClaseAlPre.Add(asignaturaSolicitudClaseAl);
            }

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

            string error = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
            bool mandable = true;
            foreach (Logica.AsignaturaSolicitudClaseAl asigPend in asignaturasSolicitudClaseAlPre)
            {
                foreach (Logica.AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl in asignaturasSolicitudClaseAl)
                {
                    if (asigPend.IdClaseAsig == asignaturaSolicitudClaseAl.IdClaseAsig && asigPend.OriClaseAsig == asignaturaSolicitudClaseAl.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseAl.IdAsignatura)
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
                    dina.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre + "\n" + orientaciones[cbxOrientacion.SelectedIndex].Nombre;
                    foreach (Logica.Asignatura asig in nuevasAsignaturas)
                    {

                        dina.Text += "\n" + asig.Nombre;
                        dina.Height += 23;

                    }
                    dina.Text += "\n(click para borrar)";
                    dina.Click += new EventHandler(EliminarClase);
                    panelAgregadas.Controls.Add(dina);
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
                if (((Label)sender).Name == "lblClase" + asigSoli.IdClaseAsig)
                {
                    encontradas.Add(asigSoli);
                }
            }
            foreach (Logica.AsignaturaSolicitudClaseAl asigSoli in asignaturasSolicitudClaseAl)
            {
                asignaturasSolicitudClaseAl.Remove(asigSoli);
            }
            Logica.ClaseSolicitudClaseAl encontrada = new Logica.ClaseSolicitudClaseAl();
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                if (((Label)sender).Name == "lblClase" + claseSoli.IdClase)
                {
                    encontrada=claseSoli;
                }
            }
            claseSolicitudesClaseAl.Remove(encontrada);
            panelAgregadas.Controls.Clear();
            xlbl=50;
            ylbl=50;
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
                dina.Name = "lblClase" + clase.IdClase;
                dina.Text = clase.Anio + "º" + clase.Nombre + "\n" + orientacion.Nombre;
                foreach (Logica.Asignatura asig in asignaturas)
                {
                    dina.Text += "\n" + asig.Nombre;
                    dina.Height += 23;
                }
                dina.Text += "\n(click para borrar)";
                dina.Click += new EventHandler(EliminarClase);
                panelAgregadas.Controls.Add(dina);
            }
            btnRegistrar.Enabled = false;
            if (claseSolicitudesClaseAl.Count > 0)
            {
                btnRegistrar.Enabled = true;
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            alumno.FotoDePerfil = alumno.ImageToByteArray(Image.FromFile("alumno.png"));
            alumno.AltaUsuario();
            Logica.SolicitudClaseAl solicitudClaseAl = new Logica.SolicitudClaseAl(DateTime.Now, true, alumno.Ci);
            solicitudClaseAl.EnviarSolicitudClaseAl();
            solicitudClaseAl.SelectIdSolicitudClaseAl();
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

            MessageBox.Show("Se ha creado el alumno correctamente\nVolviendo al Login");
            login.Show();
            this.Dispose();
        }

    }
}