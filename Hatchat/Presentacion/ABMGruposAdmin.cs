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
    public partial class ABMGruposAdmin : Form
    {
        private int ychbx = 50, xchbx = 50, xlbl = 50, ylbl = 50;
        private List<Logica.Asignatura> AsignaturasAltaOrientacion = new List<Logica.Asignatura>();
        private List<Logica.Contiene> contieneAltaOrientacion = new List<Logica.Contiene>();

        public Form login;
        public Form principalSolicitudesAdmin;
        public Form abmDAlumnoAdmin;
        public Form abmGruposAdmin;
        public Form historialSolicitudes;
        public ABMGruposAdmin()
        {
            InitializeComponent();


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
            historialSolicitudes.Show();
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

        private void btnOrientacion_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = !panelABMOrientacion.Visible;
            panelABMClase.Visible = false;
            panelABMAsignatura.Visible = false;
        }

        private void btnAltaOrientacion_Click(object sender, EventArgs e)
        {
            AsignaturasAltaOrientacion.AddRange(new Logica.Asignatura().SelectAsignaturas());
            foreach (Logica.Asignatura asig in AsignaturasAltaOrientacion)
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
                panelAltaOrientacionAsignaturas.Controls.Add(dina);
            }
        }



        private void AsignaturaCambiada(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.Asignatura asig in AsignaturasAltaOrientacion)
                {

                    if (((CheckBox)sender).Name == "chbx" + asig.Id)
                    {
                        Logica.Contiene contiene = new Logica.Contiene();
                        contiene.Asignatura = asig.Id;
                        contieneAltaOrientacion.Add(contiene);
                    }

                }
            }
            else
            {
                Logica.Contiene encontrado = new Logica.Contiene();
                foreach (Logica.Asignatura asig in AsignaturasAltaOrientacion)
                {
                    foreach (Logica.Contiene contiene in contieneAltaOrientacion)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id )
                        {
                            encontrado = contiene;
                        }
                    }
                }
                contieneAltaOrientacion.Remove(encontrado);
            }
        }
        private void btnDarAltaOrientacion_Click(object sender, EventArgs e)
        {
            if(!(new Logica.Orientacion().SelectExisteNombreOrientacion(txtNombreAltaOrientacion.Text)))
            {
                Logica.Orientacion ori = new Logica.Orientacion();
                ori.AltaOrientacion(txtNombreAltaOrientacion.Text);
                ori.SelectOrientacionPorNombre(txtNombreAltaOrientacion.Text);
                foreach(Logica.Contiene contiene in contieneAltaOrientacion)
                {
                    contiene.Orientacion = ori.Id;
                    contiene.AltaContiene();
                }
                MessageBox.Show("Se ha registrado la orientacion correctamente");
            }
            else
            {
                MessageBox.Show("Ese nombre ya existe, ponga otro");
            }
        }
        private void btnBajaOrientacion_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarOrientacion_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignatura_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;
            panelABMClase.Visible = !panelABMClase.Visible;
            panelABMAsignatura.Visible = false;
        }

        private void btnAltaAsignatura_Click(object sender, EventArgs e)
        {

        }

        private void btnBajaAsignatura_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarAsignatura_Click(object sender, EventArgs e)
        {

        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;
            panelABMClase.Visible = false;
            panelABMAsignatura.Visible = !panelABMAsignatura.Visible;
        }

        private void btnAltaClase_Click(object sender, EventArgs e)
        {

        }

        private void btnBajaClase_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarClase_Click(object sender, EventArgs e)
        {

        }
    }
}
