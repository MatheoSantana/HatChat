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
        private int ychbx = 50, xchbx = 50, xlbl = 50, ylbl = 50;
        
        private Logica.Clase claseSeleccionada = new Logica.Clase();
        private List<Logica.ClaseSolicitudClaseAl> solicitudClases = new List<Logica.ClaseSolicitudClaseAl>();
        private List<Logica.Asignatura> asigs = new List<Logica.Asignatura>();
        private List<Logica.AsignaturaSolicitudClaseAl> soliAsigs = new List<Logica.AsignaturaSolicitudClaseAl>();
        private List<Logica.Orientacion> orientaciones = new List<Logica.Orientacion>( new Logica.Orientacion().SelectOrientaciones());
        private Logica.Alumno alumno = new Logica.Alumno();
        private Logica.Orientacion orientacionSeleccionada = new Logica.Orientacion();


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
            panelAsignaturas.Controls.Clear();
            ychbx = 50;
            xchbx = 50;
            cbxAnio.Items.Clear();
            cbxClases.Items.Clear();
            orientacionSeleccionada = orientaciones[cbxOrientacion.SelectedIndex];
            foreach (int anio in new List<int>(new Logica.Clase().selectAnioClasesPorOrientacion(orientacionSeleccionada.Id)))
            {
                cbxAnio.Items.Add(anio.ToString());
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelAsignaturas.Controls.Clear();
            ychbx = 50;
            xchbx = 50;
            cbxClases.Items.Clear();
            List<string> clase = new List<string>();

            foreach (string cla in new List<string>(new Logica.Clase().SelectNombreClasePorAnioYorientacion(Convert.ToInt32(cbxAnio.SelectedItem.ToString()), orientacionSeleccionada.Id)))
            {
                cbxClases.Items.Add(cla);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            alumno.FotoDePerfil = alumno.ImageToByteArray(Image.FromFile("alumno.png"));
            alumno.AltaUsuario();
            Logica.SolicitudClaseAl solicitudClaseAl = new Logica.SolicitudClaseAl(DateTime.Now, true,alumno.Ci);
            solicitudClaseAl.EnviarSolicitudClaseAl();
            solicitudClaseAl.SelectIdSolicitudClaseAl();
            foreach (Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl in solicitudClases)
            {
                claseSolicitudClaseAl.IdSolicitudClaseAl = solicitudClaseAl.IdSolicitudClaseAl;
                claseSolicitudClaseAl.EnviarClaseSolicitudClaseAl();
            }
            foreach (Logica.AsignaturaSolicitudClaseAl soliAsig in soliAsigs)
            {
                soliAsig.IdSolicitudClaseAl=solicitudClaseAl.IdSolicitudClaseAl;
                soliAsig.Aceptada = true;
                soliAsig.EnviarAsignaturaSolicitudClaseAl();
            }
            
            
            MessageBox.Show("Se ha creado el alumno correctamente\nVolviendo al Login");
            login.Show();
            this.Dispose();
        }

        private void cbxClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelAsignaturas.Controls.Clear();
            asigs.Clear();
            ychbx = 50;
            xchbx = 50;

            asigs.AddRange(new Logica.Asignatura().SelectAsignaturasPorClaseAnioYorientacion(cbxClases.SelectedItem.ToString(), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), orientacionSeleccionada.Id));
            claseSeleccionada.Anio = Convert.ToInt32(cbxAnio.SelectedItem.ToString());
            claseSeleccionada.Orientacion = orientacionSeleccionada.Id;
            claseSeleccionada.Nombre = cbxClases.SelectedItem.ToString();
            claseSeleccionada.SelectIdClasePorPorNombreAnioYorientacion();

            foreach (Logica.Asignatura asig in asigs)
            {
                CheckBox dina = new CheckBox();

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
                foreach (Logica.Asignatura asig in asigs)
                {

                    if (((CheckBox)sender).Name == "chbx" + asig.Id)
                    {
                        Logica.AsignaturaSolicitudClaseAl soliAsig = new Logica.AsignaturaSolicitudClaseAl();
                        soliAsig.IdAsignatura = asig.Id;
                        soliAsig.IdClaseAsig =claseSeleccionada.IdClase;
                        soliAsig.OriClaseAsig = orientacionSeleccionada.Id;
                        soliAsigs.Add(soliAsig);
                    }

                }
            }
            else
            {
                Logica.AsignaturaSolicitudClaseAl encontrado = new Logica.AsignaturaSolicitudClaseAl();
                foreach (Logica.Asignatura asig in asigs)
                {
                    foreach (Logica.AsignaturaSolicitudClaseAl soliAsi in soliAsigs)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id && soliAsi.IdClaseAsig == claseSeleccionada.IdClase &&soliAsi.OriClaseAsig==orientacionSeleccionada.Id && soliAsi.IdAsignatura == asig.Id)
                        {
                            encontrado = soliAsi;
                        }
                    }
                }
                soliAsigs.Remove(encontrado);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            panelAgregadas.AutoScrollPosition = Point.Empty;
            panelAsignaturas.AutoScrollPosition = Point.Empty;
            Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl = new Logica.ClaseSolicitudClaseAl(claseSeleccionada.IdClase, orientacionSeleccionada.Id);
            if (!solicitudClases.Contains(claseSolicitudClaseAl))
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
                foreach (Logica.Asignatura asig in asigs)
                {
                    foreach (Logica.AsignaturaSolicitudClaseAl soliAsi in soliAsigs)
                    {
                        if (soliAsi.IdClaseAsig == claseSeleccionada.IdClase && soliAsi.OriClaseAsig == orientacionSeleccionada.Id && soliAsi.IdAsignatura == asig.Id)
                        {
                            dina.Text += "\n" + asig.Nombre;
                            dina.Height += 23;
                        }
                    }
                }
                dina.Text += "\n" + orientacionSeleccionada.Nombre;/* + "\n(click para borrar)";
                dina.Click += new EventHandler(EliminarClase);*/
                panelAgregadas.Controls.Add(dina);
                panelAsignaturas.Controls.Clear();
                cbxOrientacion.SelectedItem = 0;
                cbxAnio.Items.Clear();
                cbxClases.Items.Clear();
                solicitudClases.Add(claseSolicitudClaseAl);
                claseSeleccionada = new Logica.Clase();
                orientacionSeleccionada = new Logica.Orientacion();
            }

        }
        /*private void EliminarClase(object sender, EventArgs e)
        {
            clases.Remove()
        }*/
    }
}