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

        private List<Logica.Asignatura> asignaturasAltaOrientacion = new List<Logica.Asignatura>();
        private List<Logica.Contiene> contieneAltaOrientacion = new List<Logica.Contiene>();

        private List<Logica.Orientacion> orientacionesBajaOrientacion = new List<Logica.Orientacion>();

        private List<Logica.Orientacion> orientacionesModificarOrientacion = new List<Logica.Orientacion>();
        private List<Logica.Asignatura> asignaturasModificarOrientacion = new List<Logica.Asignatura>();
        private List<Logica.Contiene> contienesModificarOrientacion = new List<Logica.Contiene>();

        private List<Logica.Asignatura> asignaturasAltaAsignatura = new List<Logica.Asignatura>();

        private List<Logica.Asignatura> asignaturasBajaAsignatura = new List<Logica.Asignatura>();

        private List<Logica.Asignatura> asignaturasModificarAsignatura = new List<Logica.Asignatura>();

        private List<Logica.Orientacion> orientacionesAltaClase = new List<Logica.Orientacion>();

        private List<Logica.Orientacion> orientacionesBajaClase = new List<Logica.Orientacion>();
        private List<Logica.Clase> ClasesBajaClase = new List<Logica.Clase>();

        private List<Logica.Orientacion> orientacionesModificarClase = new List<Logica.Orientacion>();
        private List<Logica.Clase> ClasesModificarClase = new List<Logica.Clase>();
        private List<Logica.Orientacion> NuevasOrientacionesModificarClase = new List<Logica.Orientacion>();
        private List<Logica.Clase> NuevasClasesModificarClase = new List<Logica.Clase>();

        public Form login;
        public Form principalSolicitudesAdmin;
        public Form abmDAlumnoAdmin;
        public Form abmDocenteAdmin;
        public Form historialSolicitudesAdmin;
        public ABMGruposAdmin()
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxSolicitudesNav.Image = Image.FromFile("solicitudes admin gris.png");
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno gris.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente gris.png");
                pbxABMGruposNav.Image = Image.FromFile("abm grupos blanco.png");
                pbxHistorialSolicitudesNav.Image = Image.FromFile("historial gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
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

            cmbxNombreBajaOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxModificarOrientacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioAltaAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioAltaAsignatura.Items.Add(1);
            cmbxAnioAltaAsignatura.Items.Add(2);
            cmbxAnioAltaAsignatura.Items.Add(3);

            cmbxAsignaturaBajaAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioBajaAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioBajaAsignatura.Items.Add(1);
            cmbxAnioBajaAsignatura.Items.Add(2);
            cmbxAnioBajaAsignatura.Items.Add(3);

            cmbxAsignaturaModificarAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioModifcarAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioModifcarAsignatura.Items.Add(1);
            cmbxAnioModifcarAsignatura.Items.Add(2);
            cmbxAnioModifcarAsignatura.Items.Add(3);

            cmbxOrientacionAltaClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioAltaClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioAltaClase.Items.Add(1);
            cmbxAnioAltaClase.Items.Add(2);
            cmbxAnioAltaClase.Items.Add(3);

            cmbxOrientacionBajaClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioBajaClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioBajaClase.Items.Add(1);
            cmbxAnioBajaClase.Items.Add(2);
            cmbxAnioBajaClase.Items.Add(3);
            cmbxNombreBajaClase.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbxAnioModificarClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAnioModificarClase.Items.Add(1);
            cmbxAnioModificarClase.Items.Add(2);
            cmbxAnioModificarClase.Items.Add(3);
            cmbxOrientacionModificarClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxNombreModificarClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxNuevoAnioModificarClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxNuevoAnioModificarClase.Items.Add(1);
            cmbxNuevoAnioModificarClase.Items.Add(2);
            cmbxNuevoAnioModificarClase.Items.Add(3);
            cmbxNuevaOrientacionModificarClase.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void pbxABMDocenteNav_Click(object sender, EventArgs e)
        {
            abmDocenteAdmin.Show();
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

        private void btnOrientacion_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = !panelABMOrientacion.Visible;
            panelABMClase.Visible = false;
            panelABMAsignatura.Visible = false;
        }

        private void btnAltaOrientacion_Click(object sender, EventArgs e)
        {
            int ychbx = 5, xchbx = 5;
            panelABMOrientacion.Visible = false;

            panelAltaOrientacion.Visible = !panelAltaOrientacion.Visible;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;

            asignaturasAltaOrientacion.Clear();
            panelAltaOrientacionAsignaturas.Controls.Clear();
            asignaturasAltaOrientacion.AddRange(new Logica.Asignatura().SelectAsignaturas());
            foreach (Logica.Asignatura asig in asignaturasAltaOrientacion)
            {
                CheckBox dina = new CheckBox();

                dina.Height = 46;
                dina.Width = 150;
                dina.Location = new Point(xchbx, ychbx);
                if (xchbx == 180)
                {
                    xchbx = -170;
                    ychbx += 48;
                }
                xchbx += 175;
                dina.Font = new Font("arial", 12);
                dina.Name = "chbx" + asig.Id;
                dina.Text = asig.Nombre;

                dina.CheckedChanged += new EventHandler(AsignaturaCambiadaAltaOrientacion);
                panelAltaOrientacionAsignaturas.Controls.Add(dina);
            }
        }



        private void AsignaturaCambiadaAltaOrientacion(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.Asignatura asig in asignaturasAltaOrientacion)
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
                foreach (Logica.Asignatura asig in asignaturasAltaOrientacion)
                {
                    foreach (Logica.Contiene contiene in contieneAltaOrientacion)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id)
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
            if (!(new Logica.Orientacion().SelectExisteNombreOrientacion(txtNombreAltaOrientacion.Text)))
            {
                Logica.Orientacion ori = new Logica.Orientacion();
                ori.AltaOrientacion(txtNombreAltaOrientacion.Text);
                ori=ori.SelectOrientacionPorNombre(txtNombreAltaOrientacion.Text);
                foreach (Logica.Contiene contiene in contieneAltaOrientacion)
                {
                    contiene.Orientacion = ori.Id;
                    contiene.AltaContiene();
                }
                MessageBox.Show("Se ha registrado la orientacion correctamente");
                int ychbx = 5, xchbx = 5;
                asignaturasAltaOrientacion.Clear();
                panelAltaOrientacionAsignaturas.Controls.Clear();
                txtNombreAltaOrientacion.Text = "";
                asignaturasAltaOrientacion.AddRange(new Logica.Asignatura().SelectAsignaturas());
                foreach (Logica.Asignatura asig in asignaturasAltaOrientacion)
                {
                    CheckBox dina = new CheckBox();

                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(xchbx, ychbx);
                    if (xchbx == 180)
                    {
                        xchbx = -170;
                        ychbx += 48;
                    }
                    xchbx += 175;
                    dina.Font = new Font("arial", 12);
                    dina.Name = "chbx" + asig.Id;
                    dina.Text = asig.Nombre;

                    dina.CheckedChanged += new EventHandler(AsignaturaCambiadaAltaOrientacion);
                    panelAltaOrientacionAsignaturas.Controls.Add(dina);
                }
            }
            else
            {
                MessageBox.Show("Ese nombre ya existe, pruebe con otro");
            }
        }
        private void btnBajaOrientacion_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = !panelBajaOrientacion.Visible;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;
            orientacionesBajaOrientacion.Clear();
            cmbxNombreBajaOrientacion.Items.Clear();
            orientacionesBajaOrientacion = new Logica.Orientacion().SelectOrientaciones();
            foreach (Logica.Orientacion orientacion in orientacionesBajaOrientacion)
            {
                cmbxNombreBajaOrientacion.Items.Add(orientacion.Nombre);
            }

        }
        private void btnEliminarBajaOrientacion_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea eliminar la orietacion "+ cmbxNombreBajaOrientacion.SelectedItem.ToString() + "?", "Eliminar Orientacion", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                orientacionesBajaOrientacion[cmbxNombreBajaOrientacion.SelectedIndex].BajaOrientacion();
                MessageBox.Show("Se ha eliminado la orientacion correctamente");
                cmbxNombreBajaOrientacion.Items.Clear();
                orientacionesBajaOrientacion = new Logica.Orientacion().SelectOrientaciones();
                foreach (Logica.Orientacion orientacion in orientacionesBajaOrientacion)
                {
                    cmbxNombreBajaOrientacion.Items.Add(orientacion.Nombre);
                }
            }
        }

        private void btnModificarOrientacion_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = !panelModificarOrientacion.Visible;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;

            cmbxModificarOrientacion.Items.Clear();
            contienesModificarOrientacion.Clear();
            orientacionesModificarOrientacion.Clear();
            panelModificarOrientacionAsignaturas.Controls.Clear();
            asignaturasModificarOrientacion.Clear();
            orientacionesModificarOrientacion.AddRange(new Logica.Orientacion().SelectOrientaciones());
            foreach (Logica.Orientacion ori in orientacionesModificarOrientacion)
            {
                cmbxModificarOrientacion.Items.Add(ori.Nombre);
            }

            asignaturasModificarOrientacion.AddRange(new Logica.Asignatura().SelectAsignaturas());
        }
        private void cmbxModificarOrientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ychbx = 5, xchbx = 5;
            contienesModificarOrientacion.Clear();
            panelModificarOrientacionAsignaturas.Controls.Clear();
            contienesModificarOrientacion.AddRange(new Logica.Contiene().SelectContienePorOrientacion(orientacionesModificarOrientacion[cmbxModificarOrientacion.SelectedIndex].Id));
            foreach (Logica.Asignatura asig in asignaturasModificarOrientacion)
            {

                CheckBox dina = new CheckBox();

                dina.Height = 46;
                dina.Width = 150;
                dina.Location = new Point(xchbx, ychbx);
                if (xchbx == 180)
                {
                    xchbx = -170;
                    ychbx += 48;
                }
                xchbx += 175;
                dina.Font = new Font("arial", 12);
                dina.Name = "chbx" + asig.Id;
                dina.Text = asig.Nombre;
                foreach (Logica.Contiene cont in contienesModificarOrientacion)
                {
                    if (asig.Id == cont.Asignatura)
                    {
                        dina.Checked = true;
                    }
                }
                dina.CheckedChanged += new EventHandler(AsignaturaCambiadaModificarOrientacion);

                panelModificarOrientacionAsignaturas.Controls.Add(dina);

            }
        }



        private void AsignaturaCambiadaModificarOrientacion(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.Asignatura asig in asignaturasModificarOrientacion)
                {

                    if (((CheckBox)sender).Name == "chbx" + asig.Id)
                    {
                        Logica.Contiene contiene = new Logica.Contiene();
                        contiene.Asignatura = asig.Id;
                        contienesModificarOrientacion.Add(contiene);
                    }

                }
            }
            else
            {
                Logica.Contiene encontrado = new Logica.Contiene();
                foreach (Logica.Asignatura asig in asignaturasModificarOrientacion)
                {
                    foreach (Logica.Contiene contiene in contienesModificarOrientacion)
                    {
                        if (((CheckBox)sender).Name == "chbx" + asig.Id)
                        {
                            encontrado = contiene;
                        }
                    }

                }
                contieneAltaOrientacion.Remove(encontrado);
            }
        }
        private void btnModificarModificarOrientacion_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea modificar la orietacion?", "Modificar Orientacion", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                if (!(new Logica.Orientacion().SelectExisteNombreOrientacion(txtModificarOrientacionNombre.Text)) || txtModificarOrientacionNombre.Text == cmbxModificarOrientacion.SelectedItem.ToString())
                {
                    Logica.Orientacion ori = orientacionesModificarOrientacion[cmbxModificarOrientacion.SelectedIndex];
                    ori.Nombre = txtModificarOrientacionNombre.Text;
                    ori.ModificarOrientacion(contienesModificarOrientacion);
                    MessageBox.Show("Se ha Modificado la orientacion correctamente");

                    cmbxModificarOrientacion.Items.Clear();
                    contienesModificarOrientacion.Clear();
                    orientacionesModificarOrientacion.Clear();
                    panelModificarOrientacionAsignaturas.Controls.Clear();
                    asignaturasModificarOrientacion.Clear();
                    orientacionesModificarOrientacion.AddRange(new Logica.Orientacion().SelectOrientaciones());
                    foreach (Logica.Orientacion orie in orientacionesModificarOrientacion)
                    {
                        cmbxModificarOrientacion.Items.Add(orie.Nombre);
                    }

                    asignaturasModificarOrientacion.AddRange(new Logica.Asignatura().SelectAsignaturas());
                }
                else
                {
                    MessageBox.Show("Ese nombre ya existe, pruebe con otro");
                }
            }
        }


        private void btnAsignatura_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;
            panelABMAsignatura.Visible = !panelABMAsignatura.Visible;
            panelABMClase.Visible = false;
        }

        private void btnAltaAsignatura_Click(object sender, EventArgs e)
        {
            panelABMAsignatura.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = !panelAltaAsignatura.Visible;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;


            asignaturasAltaAsignatura.Clear();
            asignaturasAltaAsignatura.AddRange(new Logica.Asignatura().SelectAsignaturas());
            dgvAsignaturasAltaAsignatura.DataSource = new Logica.Asignatura().SelectAsignaturasGrilla();
            dgvAsignaturasAltaAsignatura.Columns[0].Width = 93;
            dgvAsignaturasAltaAsignatura.Columns[1].Width = 201;
            dgvAsignaturasAltaAsignatura.Columns[2].Width = 76;
            txtNombreAltaAsignatura.Text = "";
            txtIdAltaAsignatura.Text = "";
        }
        private void btnAgregarAsignaturaAltaAsignatura_Click(object sender, EventArgs e)
        {
            bool hacer = true;
            foreach (Logica.Asignatura asig in asignaturasAltaAsignatura)
            {
                if (asig.Id == txtIdAltaAsignatura.Text)
                {
                    hacer = false;
                }
            }
            if (hacer)
            {
                Logica.Asignatura asig = new Logica.Asignatura(txtIdAltaAsignatura.Text, txtNombreAltaAsignatura.Text, Convert.ToInt32(cmbxAnioAltaAsignatura.SelectedItem), true);
                asig.AltaAsignatura();
                MessageBox.Show("Se ha creado correctamente la asignatura");

                asignaturasAltaAsignatura.Clear();
                asignaturasAltaAsignatura.AddRange(new Logica.Asignatura().SelectAsignaturas());
                dgvAsignaturasAltaAsignatura.DataSource = new Logica.Asignatura().SelectAsignaturasGrilla();
                dgvAsignaturasAltaAsignatura.Columns[0].Width = 93;
                dgvAsignaturasAltaAsignatura.Columns[1].Width = 201;
                dgvAsignaturasAltaAsignatura.Columns[2].Width = 76;
                txtNombreAltaAsignatura.Text = "";
                txtIdAltaAsignatura.Text = "";
            }
            else
            {
                MessageBox.Show("Esa id ya existe");
            }
        }

        private void btnBajaAsignatura_Click(object sender, EventArgs e)
        {
            panelABMAsignatura.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = !panelBajaAsignatura.Visible;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;

            cmbxAsignaturaBajaAsignatura.Items.Clear();
            asignaturasBajaAsignatura.Clear();
            cmbxAnioBajaAsignatura.SelectedIndex = -1;
            cmbxAsignaturaBajaAsignatura.Enabled = false;

        }
        private void cmbxAnioBajaAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxAsignaturaBajaAsignatura.Items.Clear();
            asignaturasBajaAsignatura.Clear();
            cmbxAsignaturaBajaAsignatura.Enabled = true;
            asignaturasBajaAsignatura.AddRange(new Logica.Asignatura().SelectAsignaturas());
            foreach (Logica.Asignatura asig in asignaturasBajaAsignatura)
            {
                if (asig.Anio == Convert.ToInt32(cmbxAnioBajaAsignatura.SelectedItem))
                {
                    cmbxAsignaturaBajaAsignatura.Items.Add(asig.Id + " - " + asig.Nombre);
                }
            }
        }

        private void btnEliminarBajaAsignatura_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea eliminar la asignatura "+ cmbxAsignaturaBajaAsignatura.SelectedItem.ToString() +"? ", "Eliminar Asignatura", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                foreach (Logica.Asignatura asig in asignaturasBajaAsignatura)
                {
                    if (asig.Id + " - " + asig.Nombre == cmbxAsignaturaBajaAsignatura.SelectedItem.ToString())
                    {
                        asig.BajaAsignatura();
                        MessageBox.Show("Se ha eliminado la asignatura correctamente");
                        cmbxAsignaturaBajaAsignatura.Items.Clear();
                        asignaturasBajaAsignatura.Clear();
                        cmbxAnioBajaAsignatura.SelectedIndex = -1;
                        cmbxAsignaturaBajaAsignatura.Enabled = false;
                    }
                }
            }
        }
        private void btnModificarAsignatura_Click(object sender, EventArgs e)
        {
            panelABMAsignatura.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = !panelModificarAsignatura.Visible;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;

            cmbxAsignaturaModificarAsignatura.SelectedIndex = -1;
            cmbxAnioModifcarAsignatura.SelectedIndex = -1;
            cmbxAnioModifcarAsignatura.Enabled = false;
            txtNombreModificarAsignatura.Enabled = false;
            txtNombreModificarAsignatura.Text = "";

            asignaturasModificarAsignatura.Clear();
            cmbxAsignaturaModificarAsignatura.Items.Clear();
            asignaturasModificarAsignatura.AddRange(new Logica.Asignatura().SelectAsignaturas());

            foreach (Logica.Asignatura asig in asignaturasModificarAsignatura)
            {
                cmbxAsignaturaModificarAsignatura.Items.Add(asig.Id + " - " + asig.Nombre + " - " + asig.Anio + "°");
            }
        }
        private void cmbxAsignaturaModificarAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxAnioModifcarAsignatura.Enabled = true;
            txtNombreModificarAsignatura.Enabled = true;
        }

        private void btnAlterarModificarAsignatura_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea modificar la asignatura?", "Modificar Asignatura", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Logica.Asignatura asig = asignaturasModificarAsignatura[cmbxAsignaturaModificarAsignatura.SelectedIndex];
                asig.Anio = Convert.ToInt32(cmbxAnioModifcarAsignatura.SelectedItem);
                asig.Nombre = txtNombreModificarAsignatura.Text;
                asig.ModificarAsignatura();
                MessageBox.Show("Se ha modificado la asignatura correctamente");
                cmbxAnioModifcarAsignatura.SelectedIndex = -1;
                cmbxAnioModifcarAsignatura.Enabled = false;
                txtNombreModificarAsignatura.Text = "";
                txtNombreModificarAsignatura.Enabled = false;
                cmbxAsignaturaModificarAsignatura.Items.Clear();
                asignaturasModificarAsignatura.Clear();
                asignaturasModificarAsignatura.AddRange(new Logica.Asignatura().SelectAsignaturas());
                foreach (Logica.Asignatura asi in asignaturasModificarAsignatura)
                {
                    cmbxAsignaturaModificarAsignatura.Items.Add(asi.Id + " - " + asi.Nombre + " - " + asi.Anio + "°");
                }
                cmbxAsignaturaModificarAsignatura.SelectedIndex = -1;
            }
        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            panelABMOrientacion.Visible = false;
            panelABMAsignatura.Visible = false;
            panelABMClase.Visible = !panelABMClase.Visible;

        }


        private void btnAltaClase_Click(object sender, EventArgs e)
        {
            panelABMClase.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = !panelAltaClase.Visible;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = false;

            cmbxOrientacionAltaClase.Items.Clear();
            orientacionesAltaClase.Clear();
            orientacionesAltaClase.AddRange(new Logica.Orientacion().SelectOrientaciones());
            foreach(Logica.Orientacion ori in orientacionesAltaClase)
            {
                cmbxOrientacionAltaClase.Items.Add(ori.Nombre);
            }
            cmbxOrientacionAltaClase.SelectedIndex = -1;

        }

        private void btnDarAltaClase_Click(object sender, EventArgs e)
        {
            Logica.Clase cla = new Logica.Clase();
            cla.Nombre = txtNombreAltaClase.Text;
            cla.Anio = Convert.ToInt32(cmbxAnioAltaClase.SelectedItem);
            cla.Activo = true;
            cla.Orientacion = orientacionesAltaClase[cmbxOrientacionAltaClase.SelectedIndex].Id;
            cla.AltaClase();
            MessageBox.Show("Se ha creado la Clase perfectamente");
            cmbxAnioAltaClase.SelectedIndex = -1;
            orientacionesAltaClase.Clear();
            orientacionesAltaClase.AddRange(new Logica.Orientacion().SelectOrientaciones());
            cmbxOrientacionAltaClase.Items.Clear();
            foreach(Logica.Orientacion ori in orientacionesAltaClase)
            {
                cmbxOrientacionAltaClase.Items.Add(ori.Nombre);
            }
            cmbxOrientacionAltaClase.SelectedIndex = -1;
        }

        private void btnBajaClase_Click(object sender, EventArgs e)
        {
            panelABMClase.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = !panelBajaClase.Visible;
            panelModificarClase.Visible = false;

            cmbxAnioBajaClase.SelectedIndex = -1;
            cmbxOrientacionBajaClase.Enabled = false;
            cmbxOrientacionBajaClase.Items.Clear();
            cmbxOrientacionBajaClase.SelectedIndex= - 1;
            orientacionesBajaClase.Clear();
            ClasesBajaClase.Clear();
            cmbxNombreBajaClase.Enabled = false;
            cmbxNombreBajaClase.Items.Clear();
            cmbxNombreBajaClase.SelectedIndex = -1;
        }
        private void cmbxAnioBajaClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClasesBajaClase.Clear();
            orientacionesBajaClase.Clear();
            cmbxOrientacionBajaClase.Items.Clear();
            cmbxNombreBajaClase.Items.Clear();
            cmbxNombreBajaClase.Enabled = false;

            ClasesBajaClase.AddRange(new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxAnioBajaClase.SelectedItem)));
            foreach (Logica.Clase cla in ClasesBajaClase)
            {
                Logica.Orientacion ori = new Logica.Orientacion().SelectOrientacioPorId(cla.Orientacion);
                bool encontrado = false;
                foreach(Logica.Orientacion orient in orientacionesBajaClase) 
                {
                    if(orient.Id == cla.Orientacion)
                    {
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    orientacionesBajaClase.Add(ori);
                }
            }
            foreach (Logica.Orientacion ori in orientacionesBajaClase)
            {
                cmbxOrientacionBajaClase.Items.Add(ori.Nombre);
            }
            cmbxOrientacionBajaClase.Enabled = true;
        }

        private void cmbxOrientacionBajaClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxNombreBajaClase.Items.Clear();
            foreach (Logica.Clase cla in ClasesBajaClase)
            {
                if (orientacionesBajaClase[cmbxOrientacionBajaClase.SelectedIndex].Id == cla.Orientacion)
                {
                    cmbxNombreBajaClase.Items.Add(cla.Nombre);
                }
            }
            cmbxNombreBajaClase.Enabled = true;
        }
        private void btnDarBajaClase_Click(object sender, EventArgs e)
        { 
            bool error = true;
            DialogResult cerrarSesion = MessageBox.Show("¿Desea eliminar la clase "+ cmbxAnioBajaClase.SelectedItem.ToString()+cmbxNombreBajaClase.SelectedItem.ToString() + " " + cmbxOrientacionBajaClase.SelectedItem.ToString() + " ?", "Eliminar Clase", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                foreach (Logica.Clase cla in ClasesBajaClase)
                {
                    if (orientacionesBajaClase[cmbxOrientacionBajaClase.SelectedIndex].Id == cla.Orientacion && cla.Nombre == cmbxNombreBajaClase.SelectedItem.ToString() && Convert.ToInt32(cmbxAnioBajaClase.SelectedItem.ToString()) == cla.Anio)
                    {
                        cla.BajaClase();
                        MessageBox.Show("Se ha eliminado la clase correctamente");
                        error = false;

                        cmbxAnioBajaClase.SelectedIndex = -1;
                        cmbxOrientacionBajaClase.Enabled = false;
                        cmbxOrientacionBajaClase.Items.Clear();
                        cmbxOrientacionBajaClase.SelectedIndex = -1;
                        orientacionesBajaClase.Clear();
                        ClasesBajaClase.Clear();
                        cmbxNombreBajaClase.Enabled = false;
                        cmbxNombreBajaClase.Items.Clear();
                        cmbxNombreBajaClase.SelectedIndex = -1;
                    }

                }
                if (error)
                {
                    MessageBox.Show("No se logro eliminar la clase");
                }
            }

        }

        private void btnModificarClase_Click(object sender, EventArgs e)
        { 
            panelABMClase.Visible = false;

            panelAltaOrientacion.Visible = false;
            panelBajaOrientacion.Visible = false;
            panelModificarOrientacion.Visible = false;

            panelAltaAsignatura.Visible = false;
            panelBajaAsignatura.Visible = false;
            panelModificarAsignatura.Visible = false;

            panelAltaClase.Visible = false;
            panelBajaClase.Visible = false;
            panelModificarClase.Visible = !panelModificarClase.Visible;

            cmbxOrientacionModificarClase.Enabled = false;
            cmbxNombreModificarClase.Enabled = false;
            cmbxNuevoAnioModificarClase.Enabled = false;
            cmbxNuevaOrientacionModificarClase.Enabled = false;
            txtNuevoNombreModificarClase.Enabled = false;

            cmbxOrientacionModificarClase.Items.Clear();
            cmbxNombreModificarClase.Items.Clear();
            cmbxNuevaOrientacionModificarClase.Items.Clear();
            txtNuevoNombreModificarClase.Text = "";

            cmbxAnioModificarClase.SelectedIndex = -1;
            cmbxOrientacionModificarClase.SelectedIndex = -1;
            cmbxNombreModificarClase.SelectedIndex = -1;
            cmbxNuevoAnioModificarClase.SelectedIndex = -1;
            cmbxNuevaOrientacionModificarClase.SelectedIndex = -1;

            orientacionesModificarClase.Clear();
            ClasesModificarClase.Clear();
            NuevasOrientacionesModificarClase.Clear();
            NuevasClasesModificarClase.Clear();


        }

        private void cmbxAnioModificarClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClasesModificarClase.Clear();
            orientacionesModificarClase.Clear();
            NuevasClasesModificarClase.Clear();
            NuevasOrientacionesModificarClase.Clear();

            cmbxOrientacionModificarClase.Items.Clear();
            cmbxNombreModificarClase.Items.Clear();
            cmbxNuevaOrientacionModificarClase.Items.Clear();
            txtNuevoNombreModificarClase.Text = "";

            cmbxOrientacionModificarClase.Enabled = false;
            cmbxNombreModificarClase.Enabled = false;
            cmbxNuevoAnioModificarClase.Enabled = false;
            cmbxNuevaOrientacionModificarClase.Enabled = false;
            txtNuevoNombreModificarClase.Enabled = false;

            cmbxNuevoAnioModificarClase.SelectedIndex = -1;
            ClasesModificarClase.AddRange(new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxAnioModificarClase.SelectedItem)));
            foreach (Logica.Clase cla in ClasesModificarClase)
            {
                Logica.Orientacion ori = new Logica.Orientacion().SelectOrientacioPorId(cla.Orientacion);
                bool encontrado = false;
                foreach (Logica.Orientacion orient in orientacionesModificarClase)
                {
                    if (orient.Id == cla.Orientacion)
                    {
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    orientacionesModificarClase.Add(ori);
                }
            }
            foreach (Logica.Orientacion ori in orientacionesModificarClase)
            {
                cmbxOrientacionModificarClase.Items.Add(ori.Nombre);
            }
            cmbxOrientacionModificarClase.Enabled = true;
        }

        private void cmbxOrientacionModificarClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            NuevasClasesModificarClase.Clear();
            NuevasOrientacionesModificarClase.Clear();

            cmbxNombreModificarClase.Items.Clear();
            cmbxNuevaOrientacionModificarClase.Items.Clear();
            txtNuevoNombreModificarClase.Text = "";

            cmbxNuevoAnioModificarClase.Enabled = false;
            cmbxNuevaOrientacionModificarClase.Enabled = false;
            txtNuevoNombreModificarClase.Enabled = false;

            cmbxNuevoAnioModificarClase.SelectedIndex = -1;
            foreach (Logica.Clase cla in ClasesModificarClase)
            {
                if (orientacionesModificarClase[cmbxOrientacionModificarClase.SelectedIndex].Id == cla.Orientacion)
                {
                    cmbxNombreModificarClase.Items.Add(cla.Nombre);
                }
            }
            cmbxNombreModificarClase.Enabled = true; 
        }
        private void cmbxNombreModificarClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            NuevasClasesModificarClase.Clear();
            NuevasOrientacionesModificarClase.Clear();

            cmbxNombreModificarClase.Items.Clear();
            cmbxNuevaOrientacionModificarClase.Items.Clear();
            txtNuevoNombreModificarClase.Text = "";

            cmbxNuevoAnioModificarClase.Enabled = true;
            txtNuevoNombreModificarClase.Enabled = true;

            cmbxNuevoAnioModificarClase.SelectedIndex = -1;
        }

        private void cmbxNuevoAnioModificarClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            NuevasClasesModificarClase.Clear();
            NuevasOrientacionesModificarClase.Clear();
            cmbxNuevaOrientacionModificarClase.Items.Clear();
            txtNuevoNombreModificarClase.Text = "";

            NuevasClasesModificarClase.AddRange(new Logica.Clase().SelectClasesPorAnio(Convert.ToInt32(cmbxNuevoAnioModificarClase.SelectedItem)));
            foreach (Logica.Clase cla in NuevasClasesModificarClase)
            {
                Logica.Orientacion ori = new Logica.Orientacion().SelectOrientacioPorId(cla.Orientacion);
                bool encontrado = false;
                foreach (Logica.Orientacion orient in NuevasOrientacionesModificarClase)
                {
                    if (orient.Id == cla.Orientacion)
                    {
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    NuevasOrientacionesModificarClase.Add(ori);
                }
            }
            foreach (Logica.Orientacion ori in NuevasOrientacionesModificarClase)
            {
                cmbxNuevaOrientacionModificarClase.Items.Add(ori.Nombre);
            }
            cmbxNuevaOrientacionModificarClase.Enabled = true;
        }

        private void btnDarModificacionClase_Click(object sender, EventArgs e)
        { 
            bool error = true;
            DialogResult cerrarSesion = MessageBox.Show("¿Desea modificar la clase?", "Modificar Clase", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                foreach (Logica.Clase cla in ClasesModificarClase)
                {
                    if (orientacionesModificarClase[cmbxOrientacionModificarClase.SelectedIndex].Id == cla.Orientacion && cla.Nombre == cmbxNombreModificarClase.SelectedItem.ToString() && Convert.ToInt32(cmbxAnioModificarClase.SelectedItem.ToString()) == cla.Anio)
                    {
                        cla.Orientacion = NuevasOrientacionesModificarClase[cmbxNuevaOrientacionModificarClase.SelectedIndex].Id;
                        cla.Nombre = txtNuevoNombreModificarClase.Text;
                        cla.Anio = Convert.ToInt32(cmbxNuevoAnioModificarClase.SelectedItem.ToString());
                        cla.ModificarClase();
                        MessageBox.Show("Se ha modificado correctamente la clase");

                        cmbxOrientacionModificarClase.Enabled = false;
                        cmbxNombreModificarClase.Enabled = false;
                        cmbxNuevoAnioModificarClase.Enabled = false;
                        cmbxNuevaOrientacionModificarClase.Enabled = false;
                        txtNuevoNombreModificarClase.Enabled = false;

                        cmbxOrientacionModificarClase.Items.Clear();
                        cmbxNombreModificarClase.Items.Clear();
                        cmbxNuevaOrientacionModificarClase.Items.Clear();
                        txtNuevoNombreModificarClase.Text = "";

                        cmbxAnioModificarClase.SelectedIndex = -1;
                        cmbxOrientacionModificarClase.SelectedIndex = -1;
                        cmbxNombreModificarClase.SelectedIndex = -1;
                        cmbxNuevoAnioModificarClase.SelectedIndex = -1;
                        cmbxNuevaOrientacionModificarClase.SelectedIndex = -1;

                        orientacionesModificarClase.Clear();
                        ClasesModificarClase.Clear();
                        NuevasOrientacionesModificarClase.Clear();
                        NuevasClasesModificarClase.Clear();

                        error = false;
                    }
                    if (error)
                    {
                        MessageBox.Show("No se pudo modificar la clase");
                    }
                }
            }
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
