using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class RegisterClasesDocente : Form
    {
        string error;
        string yaIngresadas;
        string creado;

        public Form login;
        public Form registerDocente;
        private int xpanel = 20;

        List<Logica.ClaseSolicitudClaseDo> claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();
        Logica.Clase claseSeleccionada = new Logica.Clase();
        List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>();
        List<Logica.Asignatura> nuevasAsignaturas = new List<Logica.Asignatura>();
        private Logica.Docente docente = new Logica.Docente();

        public RegisterClasesDocente()
        {
            InitializeComponent();
            
            Text = "Register clase Docente";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            if (Login.idioma == "Español")
            {
                error = " comuníquese con el administrador.";
                lblTitulo.Text = "Crea tu cuenta de Docente";
                lblIngresarA.Text = "Ingresar a...";
                lblAnio.Text = "Año:";
                lblClase.Text = "Clase:";
                lblOrientacion.Text = "orientación:";
                btnAgregar.Text = "Agregar";
                btnRegistrar.Text = "registrar";
                lblAsig.Text = "Asignaturas";
                yaIngresadas = "Solicitud denegada, ya a pedido para ingresar a las siguientes asignaturas: ";
                creado = "Se ha creado el docente correctamente\nVolviendo al Login";

            }
            else
            {
                error = "  Contact an administrator.";
                lblTitulo.Text = "Create your Teacher account";
                lblIngresarA.Text = "Enter...";
                lblAnio.Text = "Year:";
                lblClase.Text = "Class:";
                lblOrientacion.Text = "Orientation:";
                btnAgregar.Text = "Agree";
                btnRegistrar.Text = "Create Account";
                lblAsig.Text = "Course:";
                yaIngresadas = "Application denied, already on request to enter the following subjects: ";
                creado = "The teacher has been created correctly\nReturning to Login";

            }
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxVolver.Image = Image.FromFile("volver.png");
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

            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            asignaturasSolicitudClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();
            claseSeleccionada = new Logica.Clase();
            orientaciones = new List<Logica.Orientacion>();
            nuevasAsignaturas = new List<Logica.Asignatura>();

            orientaciones = new Logica.Orientacion().SelectOrientaciones();

            foreach (Logica.Orientacion ori in orientaciones)
            {
                cbxOrientacion.Items.Add(ori.Nombre);
            }
        }

        public Logica.Docente Docente
        {
            set { docente = value; }
        }

        private void RegisterClasesDocente_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }


        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxVolver_Click(object sender, EventArgs e)
        {
            registerDocente.Show();
            this.Dispose();
        }

        private void cbxOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseDo> encontradas = new List<Logica.AsignaturaSolicitudClaseDo>();
                foreach (Logica.AsignaturaSolicitudClaseDo asigSolicita in asignaturasSolicitudClaseDoPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseDo asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseDoPre.Remove(asigEncontrada);
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
            asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();

            orientaciones = new Logica.Orientacion().SelectOrientaciones();
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
            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseDo> encontradas = new List<Logica.AsignaturaSolicitudClaseDo>();
                foreach (Logica.AsignaturaSolicitudClaseDo asigSolicita in asignaturasSolicitudClaseDoPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseDo asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseDoPre.Remove(asigEncontrada);
                }
            }

            cbxClases.Items.Clear();
            panelAsignaturas.Controls.Clear();
            cbxClases.Enabled = true;
            btnAgregar.Enabled = false;

            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
            asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            docente.Activo = true;
            docente.FotoDePerfil = docente.ImageToByteArray(Image.FromFile("docente.png"));
            docente.AltaUsuario();
            Logica.SolicitudClaseDo solicitudClaseDo = new Logica.SolicitudClaseDo(DateTime.Now, true, docente.Ci);
            solicitudClaseDo.EnviarSolicitudClaseDo();
            solicitudClaseDo.IdSolicitudClaseDo = solicitudClaseDo.SelectIdSolicitudClaseDo();
            foreach (Logica.ClaseSolicitudClaseDo claseSolicitudClaseDo in claseSolicitudesClaseDo)
            {
                claseSolicitudClaseDo.IdSolicitudClaseDo = solicitudClaseDo.IdSolicitudClaseDo;
                claseSolicitudClaseDo.EnviarClaseSolicitudClaseDo();
            }
            foreach (Logica.AsignaturaSolicitudClaseDo soliAsig in asignaturasSolicitudClaseDo)
            {
                soliAsig.IdSolicitudClaseDo = solicitudClaseDo.IdSolicitudClaseDo;
                soliAsig.Aceptada = true;
                soliAsig.EnviarAsignaturaSolicitudClaseDo();
            }

            MessageBox.Show(creado);
            login.Show();
            this.Dispose();

            
        }

        private void cbxClases_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (btnAgregar.Enabled)
            {
                List<Logica.AsignaturaSolicitudClaseDo> encontradas = new List<Logica.AsignaturaSolicitudClaseDo>();
                foreach (Logica.AsignaturaSolicitudClaseDo asigSolicita in asignaturasSolicitudClaseDoPre)
                {
                    if (claseSeleccionada.IdClase == asigSolicita.IdClaseAsig && claseSeleccionada.Orientacion == asigSolicita.OriClaseAsig)
                    {
                        encontradas.Add(asigSolicita);
                    }
                }
                foreach (Logica.AsignaturaSolicitudClaseDo asigEncontrada in encontradas)
                {
                    asignaturasSolicitudClaseDoPre.Remove(asigEncontrada);
                }
            }

            panelAsignaturas.Controls.Clear();
            btnAgregar.Enabled = true;

            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
            asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();

            nuevasAsignaturas = new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cbxClases.SelectedItem.ToString(), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), orientaciones[cbxOrientacion.SelectedIndex].Id);

            claseSeleccionada.Nombre = cbxClases.SelectedItem.ToString();
            claseSeleccionada.Anio = Convert.ToInt32(cbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientaciones[cbxOrientacion.SelectedIndex].Id;
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            int ychbx = 10, xchbx = 10;
            foreach (Logica.Asignatura asig in nuevasAsignaturas)
            {
                CheckBox dina = new CheckBox();
                dina.Checked = false;
                foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDoPre)
                {
                    if (asignaturaSolicitudClaseDo.IdAsignatura == asig.Id && asignaturaSolicitudClaseDo.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseDo.OriClaseAsig == claseSeleccionada.Orientacion)
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
                        asignaturasSolicitudClaseDoPre.Add(asignaturaSolicitudClaseDo);
                    }

                }
            }
            else
            {
                Logica.AsignaturaSolicitudClaseDo encontrado = new Logica.AsignaturaSolicitudClaseDo();
                foreach (Logica.Asignatura asig in nuevasAsignaturas)
                {
                    foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDoPre)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && asignaturaSolicitudClaseDo.IdClaseAsig == claseSeleccionada.IdClase && asignaturaSolicitudClaseDo.OriClaseAsig == claseSeleccionada.Orientacion && asignaturaSolicitudClaseDo.IdAsignatura == asig.Id)
                        {
                            encontrado = asignaturaSolicitudClaseDo;
                        }
                    }
                }
                asignaturasSolicitudClaseDoPre.Remove(encontrado);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            panelAgregadas.AutoScrollPosition =Point.Empty;

            string error = yaIngresadas;
            bool mandable = true;
            foreach (Logica.AsignaturaSolicitudClaseDo asigPend in asignaturasSolicitudClaseDoPre)
            {
                foreach (Logica.AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo in asignaturasSolicitudClaseDo)
                {
                    if (asigPend.IdClaseAsig== asignaturaSolicitudClaseDo.IdClaseAsig && asigPend.OriClaseAsig == asignaturaSolicitudClaseDo.OriClaseAsig && asigPend.IdAsignatura == asignaturaSolicitudClaseDo.IdAsignatura)
                    {
                        Logica.Asignatura asi = new Logica.Asignatura().SelectAsignaturaPorId(asigPend.IdAsignatura);
                        Logica.Clase cla = new Logica.Clase().SelectClasePorId(asigPend.IdClaseAsig);
                        Logica.Orientacion ori = new Logica.Orientacion().SelectOrientacioPorId(cla.Orientacion);
                        error += "\n" + asi.Nombre + " " + cla.Anio + cla.Nombre + " " + ori.Nombre;
                        mandable = false;
                    }
                }
            }
            if (mandable)
            {
                asignaturasSolicitudClaseDo.AddRange(asignaturasSolicitudClaseDoPre);
                Logica.ClaseSolicitudClaseDo claseSolicitudClaseDo = new Logica.ClaseSolicitudClaseDo(claseSeleccionada.IdClase, orientaciones[cbxOrientacion.SelectedIndex].Id);
                if (!claseSolicitudesClaseDo.Contains(claseSolicitudClaseDo))
                {

                    Label grupo = new Label();
                    grupo.Height = 60;
                    grupo.Width = 100;
                    grupo.Location = new Point(0, 0);
                    grupo.Font = new Font("Arial", 12.0f);
                    grupo.Name = "lblClase" + claseSeleccionada.IdClase;
                    grupo.Text = claseSeleccionada.Anio + "º" + claseSeleccionada.Nombre + "  (" + asignaturasSolicitudClaseDoPre.Count + ")" + "\n" + orientaciones[cbxOrientacion.SelectedIndex].Nombre;
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
                    panel.Location = new Point(xpanel, 0);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    xpanel += 170;
                    panel.Name = "pnlClase" + claseSeleccionada.IdClase;
                    panel.BackColor = Color.White;
                    panel.Click += new EventHandler(EliminarClase);
                    panel.Controls.Add(grupo);
                    panel.Controls.Add(pic);

                    panelAgregadas.Controls.Add(panel);
                    claseSolicitudesClaseDo.Add(claseSolicitudClaseDo);
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

            asignaturasSolicitudClaseDoPre = new List<Logica.AsignaturaSolicitudClaseDo>();
            claseSeleccionada = new Logica.Clase();
            nuevasAsignaturas = new List<Logica.Asignatura>();
        }
        private void EliminarClase(object sender, EventArgs e)
        {
            List<Logica.AsignaturaSolicitudClaseDo> encontradas = new List<Logica.AsignaturaSolicitudClaseDo>();
            foreach(Logica.AsignaturaSolicitudClaseDo asigSoli in asignaturasSolicitudClaseDo)
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
            foreach(Logica.AsignaturaSolicitudClaseDo asigSoli in encontradas)
            {
                asignaturasSolicitudClaseDo.Remove(asigSoli);
            }
            Logica.ClaseSolicitudClaseDo encontrada = new Logica.ClaseSolicitudClaseDo();
            foreach (Logica.ClaseSolicitudClaseDo claseSoli in claseSolicitudesClaseDo)
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
            claseSolicitudesClaseDo.Remove(encontrada);
            panelAgregadas.Controls.Clear();
            xpanel = 20;
            foreach (Logica.ClaseSolicitudClaseDo claseSoli in claseSolicitudesClaseDo)
            {
                Logica.Clase clase = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                Logica.Orientacion orientacion = new Logica.Orientacion().SelectOrientacioPorId(clase.Orientacion);
                List<Logica.Asignatura> asignaturas = new List<Logica.Asignatura>();
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoli in asignaturasSolicitudClaseDo)
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
                pic.Image = Image.FromFile("profesor.png");
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
            if (claseSolicitudesClaseDo.Count > 0)
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
