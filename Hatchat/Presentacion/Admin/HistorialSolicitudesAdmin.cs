using System;
using System.Collections;
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
    public partial class HistorialSolicitudesAdmin : Form
    {

        List<Logica.ClaseSolicitudClaseAl> claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
        Logica.SolicitudClaseAl soliAl = new Logica.SolicitudClaseAl();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();

        List<Logica.ClaseSolicitudClaseDo> claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
        Logica.SolicitudClaseDo soliDo = new Logica.SolicitudClaseDo();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();

        ArrayList solicitudesOrdenadas = new ArrayList();

        Logica.SolicitudModif soliMo = new Logica.SolicitudModif();

        private bool filtrar = false;

        public Form login;
        public Form abmAlumnoAdmin;
        public Form abmDocenteAdmin;
        public Form abmGruposAdmin;
        public Form principalSolicitudesAdmin;

        public HistorialSolicitudesAdmin()
        {

            InitializeComponent();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            panelSolicitud.Visible = false;
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxSolicitudesNav.Image = Image.FromFile("solicitudes admin gris.png");
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno gris.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente gris.png");
                pbxABMGruposNav.Image = Image.FromFile("abm grupos gris.png");
                pbxHistorialSolicitudesNav.Image = Image.FromFile("historial blanco.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
                pcbxLogo.Image= Image.FromFile("Logo Completa.png");
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
            pcbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbxPrincipalSolicitudesAdminNav_Click(object sender, EventArgs e)
        {
            principalSolicitudesAdmin.Show();
            this.Hide();
        }
        private void pbxABMAlumnoNav_Click(object sender, EventArgs e)
        {
            abmAlumnoAdmin.Show();
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

        private void PrincipalSolicitudesAdmin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }
        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }
        private void CargarSolicitudes()
        {

            List<Logica.SolicitudClaseAl> solicitudesClaseAl = new Logica.SolicitudClaseAl().SelectSolicitudesClaseAlResueltas(Login.encontrado.Ci);
            List<Logica.SolicitudClaseDo> solicitudesClaseDo = new Logica.SolicitudClaseDo().SelectSolicitudesClaseDoResueltas(Login.encontrado.Ci);
            List<Logica.SolicitudModif> solicitudesModif = new Logica.SolicitudModif().SelectSolicitudesModifResueltas(Login.encontrado.Ci);

            ArrayList solicitudesDesordenadas = new ArrayList();
            int y;

            ArrayList solicitudesOrdenadas = new ArrayList();

            if (solicitudesClaseAl.Count() > 0)
            {
                if (filtrar)
                {
                    foreach (Logica.SolicitudClaseAl soli in solicitudesClaseAl)
                    {
                        if (soli.FechaHora.Year == dtpFiltroFecha.Value.Year && soli.FechaHora.Month == dtpFiltroFecha.Value.Month && soli.FechaHora.Day == dtpFiltroFecha.Value.Day)
                        {
                            solicitudesDesordenadas.Add(soli);
                        }
                    }
                }
                else
                {
                    solicitudesDesordenadas.AddRange(solicitudesClaseAl);
                }

                foreach (Logica.SolicitudClaseDo soliDo in solicitudesClaseDo)
                {
                    for (int x = 0; x < solicitudesDesordenadas.Count; x++)
                    {
                        if (!solicitudesDesordenadas.Contains(soliDo))
                        {
                            if (soliDo.FechaHora > solicitudesClaseAl[x].FechaHora)
                            {
                                if (filtrar)
                                {
                                    if (soliDo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliDo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliDo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesDesordenadas.Insert(x, soliDo);
                                    }
                                }
                                else
                                {
                                    solicitudesDesordenadas.Insert(x, soliDo);
                                }
                            }
                        }
                    }
                    if (!solicitudesDesordenadas.Contains(soliDo))
                    {
                        if (filtrar)
                        {
                            if (soliDo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliDo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliDo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                            {
                                solicitudesDesordenadas.Add(soliDo);
                            }
                        }
                        else
                        {
                            solicitudesDesordenadas.Add(soliDo);
                        }
                    }
                }
            }
            else
            {
                if (filtrar)
                {
                    foreach (Logica.SolicitudClaseDo soli in solicitudesClaseDo)
                    {
                        if (soli.FechaHora.Year == dtpFiltroFecha.Value.Year && soli.FechaHora.Month == dtpFiltroFecha.Value.Month && soli.FechaHora.Day == dtpFiltroFecha.Value.Day)
                        {
                            solicitudesDesordenadas.Add(soli);
                        }
                    }
                }
                else
                {
                    solicitudesDesordenadas.AddRange(solicitudesClaseDo);
                }
                
            }
            solicitudesOrdenadas.AddRange(solicitudesDesordenadas);
            foreach (Logica.SolicitudModif soliMo in solicitudesModif)
            {
                for (int x = 0; x < solicitudesOrdenadas.Count; x++)
                {
                    if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
                    {
                        Logica.SolicitudClaseAl soli = (Logica.SolicitudClaseAl)solicitudesOrdenadas[x];
                        if (!solicitudesOrdenadas.Contains(soliMo))
                        {
                            if (soliMo.FechaHora > soli.FechaHora)
                            {
                                if (filtrar)
                                {
                                    if (soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesOrdenadas.Insert(x, soliMo);
                                    }
                                }
                                else
                                {
                                    solicitudesOrdenadas.Insert(x, soliMo);
                                }
                            }
                        }
                    }
                    else if(solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseDo")
                    {
                        Logica.SolicitudClaseDo soli = (Logica.SolicitudClaseDo)solicitudesOrdenadas[x];
                        if (!solicitudesOrdenadas.Contains(soliMo))
                        {
                            if (soliMo.FechaHora > soli.FechaHora)
                            {
                                if (filtrar)
                                {
                                    if (soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesOrdenadas.Insert(x, soliMo);
                                    }
                                }
                                else
                                {
                                    solicitudesOrdenadas.Insert(x, soliMo);
                                }
                            }
                        }
                    }
                    else
                    {
                        Logica.SolicitudModif soli = (Logica.SolicitudModif)solicitudesOrdenadas[x];
                        if (!solicitudesOrdenadas.Contains(soliMo))
                        {
                            if (soliMo.FechaHora > soli.FechaHora)
                            {
                                if (filtrar)
                                {
                                    if (soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesOrdenadas.Insert(x, soliMo);
                                    }
                                }
                                else
                                {
                                    solicitudesOrdenadas.Insert(x, soliMo);
                                }
                            }
                        }
                    }
                }
                if (!solicitudesOrdenadas.Contains(soliMo))
                {
                    if (filtrar)
                    {
                        if (soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                        {
                            solicitudesOrdenadas.Add(soliMo);
                        }
                    }
                    else
                    {
                        solicitudesOrdenadas.Add(soliMo);
                    }
                    
                }
            }
            if (solicitudesOrdenadas.Count == 0)
            {
                lblBienvenido.Visible = false;
                lblLinea.Visible = false;
                pcbxLogo.Visible = false;
            }
            else
            {
                lblBienvenido.Visible = true;
                lblLinea.Visible = true;
                pcbxLogo.Visible = true;
            }
            bool iguales = true;
            if (solicitudesOrdenadas.Count == this.solicitudesOrdenadas.Count)
            {
                for (int x = 0; x < solicitudesOrdenadas.Count; x++)
                {
                    if (solicitudesOrdenadas[x].GetType().Name == "SolicitudModif")
                    {
                        if (this.solicitudesOrdenadas[x].GetType().Name == "SolicitudModif")
                        {
                            if (!(((Logica.SolicitudModif)solicitudesOrdenadas[x]).IdSolicitudModif == ((Logica.SolicitudModif)this.solicitudesOrdenadas[x]).IdSolicitudModif))
                            {
                                iguales = false;
                            }
                        }
                        else
                        {
                            iguales = false;
                        }
                    }
                    if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseDo")
                    {
                        if (this.solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseDo")
                        {
                            if (!(((Logica.SolicitudClaseDo)solicitudesOrdenadas[x]).IdSolicitudClaseDo == ((Logica.SolicitudClaseDo)this.solicitudesOrdenadas[x]).IdSolicitudClaseDo))
                            {
                                iguales = false;
                            }
                        }
                        else
                        {
                            iguales = false;
                        }
                    }
                    if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
                    {
                        if (this.solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
                        {
                            if (!(((Logica.SolicitudClaseAl)solicitudesOrdenadas[x]).IdSolicitudClaseAl == ((Logica.SolicitudClaseAl)this.solicitudesOrdenadas[x]).IdSolicitudClaseAl))
                            {
                                iguales = false;
                            }
                        }
                        else
                        {
                            iguales = false;
                        }
                    }
                }
            }
            else
            {
                iguales = false;
            }
            if (!iguales)
            {
                this.solicitudesOrdenadas = solicitudesOrdenadas;
                int yPanel = 0;
                PanelSolicitudesResueltas.Controls.Clear();

                for (int x = 0; x < solicitudesOrdenadas.Count; x++)
                {
                    if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
                    {
                        Logica.SolicitudClaseAl soli = (Logica.SolicitudClaseAl)solicitudesOrdenadas[x];
                        Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Alumno);
                        Logica.Alumno al = new Logica.Alumno();
                        al.Nombre = us.Nombre;
                        al.Primer_apellido = us.Primer_apellido;
                        al.FotoDePerfil = us.FotoDePerfil;

                        PictureBox picPhoto = new PictureBox();
                        picPhoto.Image = us.ByteArrayToImage(us.FotoDePerfil);
                        picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        picPhoto.Height = 69;
                        picPhoto.Width = 69;
                        picPhoto.Location = new Point(12, 6);
                        picPhoto.Name = "pcbxSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        picPhoto.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Label grupo = new Label();
                        grupo.Height = 30;
                        grupo.Width = 227;
                        grupo.Location = new Point(91, 0);
                        grupo.ForeColor = Color.FromArgb(209, 213, 100);
                        grupo.Font = new Font("Arial", 12.0f);
                        grupo.Name = "lblSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        grupo.Text = "Desea entrar a un grupo";
                        grupo.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Label alumno = new Label();
                        alumno.Height = 58;
                        alumno.Width = 277;
                        alumno.Location = new Point(91, 30);
                        alumno.ForeColor = Color.White;
                        alumno.Font = new Font("Arial", 12.0f);
                        alumno.Name = "lblASoliAl" + soli.IdSolicitudClaseAl.ToString();
                        alumno.Text = "Alumno:\n" + al.Nombre + " " + al.Primer_apellido;
                        alumno.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Label fecha = new Label();
                        fecha.Height = 48;
                        fecha.Width = 100;
                        fecha.Location = new Point(610, 17);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 12.0f);
                        fecha.Name = "lblFSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 720;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudClaseAl);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(grupo);
                        panel.Controls.Add(alumno);
                        panel.Controls.Add(picPhoto);

                        PanelSolicitudesResueltas.Controls.Add(panel);
                    }
                    else if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseDo")
                    {
                        Logica.SolicitudClaseDo soli = (Logica.SolicitudClaseDo)solicitudesOrdenadas[x];
                        Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Docente);
                        Logica.Docente doc = new Logica.Docente();
                        doc.Nombre = us.Nombre;
                        doc.Primer_apellido = us.Primer_apellido;
                        doc.FotoDePerfil = us.FotoDePerfil;

                        PictureBox picPhoto = new PictureBox();
                        picPhoto.Image = us.ByteArrayToImage(us.FotoDePerfil);
                        picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        picPhoto.Height = 69;
                        picPhoto.Width = 69;
                        picPhoto.Location = new Point(12, 6);
                        picPhoto.Name = "pcbxSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        picPhoto.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Label grupo = new Label();
                        grupo.Height = 30;
                        grupo.Width = 227;
                        grupo.Location = new Point(91, 0);
                        grupo.ForeColor = Color.FromArgb(209, 213, 100);
                        grupo.Font = new Font("Arial", 12.0f);
                        grupo.Name = "lblSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        grupo.Text = "Desea entrar a un grupo";
                        grupo.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Label docente = new Label();
                        docente.Height = 58;
                        docente.Width = 277;
                        docente.Location = new Point(91, 30);
                        docente.ForeColor = Color.White;
                        docente.Font = new Font("Arial", 12.0f);
                        docente.Name = "lblASoliDo" + soli.IdSolicitudClaseDo.ToString();
                        docente.Text = "Docente:\n" + doc.Nombre + " " + doc.Primer_apellido;
                        docente.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Label fecha = new Label();
                        fecha.Height = 48;
                        fecha.Width = 100;
                        fecha.Location = new Point(610, 17);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 12.0f);
                        fecha.Name = "lblFSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 720;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudClaseDo);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(grupo);
                        panel.Controls.Add(docente);
                        panel.Controls.Add(picPhoto);
                        PanelSolicitudesResueltas.Controls.Add(panel);
                    }
                    else
                    {
                        Logica.SolicitudModif soli = (Logica.SolicitudModif)solicitudesOrdenadas[x];
                        Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Usuario);

                        PictureBox picPhoto = new PictureBox();
                        picPhoto.Image = us.ByteArrayToImage(us.FotoDePerfil);
                        picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        picPhoto.Height = 69;
                        picPhoto.Width = 69;
                        picPhoto.Location = new Point(12, 6);
                        picPhoto.Name = "pcbxSoliMo" + soli.IdSolicitudModif.ToString();
                        picPhoto.Click += new EventHandler(AbrirSolicitudModif);

                        Label perdio = new Label();
                        perdio.Height = 30;
                        perdio.Width = 227;
                        perdio.Location = new Point(91, 0);
                        perdio.ForeColor = Color.FromArgb(206, 82, 75);
                        perdio.Font = new Font("Arial", 12.0f);
                        perdio.Text = "Perdio el acceso a su cuenta";
                        perdio.Name = "lblSoliMod" + soli.IdSolicitudModif.ToString();
                        perdio.Click += new EventHandler(AbrirSolicitudModif);

                        Label usuario = new Label();
                        usuario.Height = 58;
                        usuario.Width = 277;
                        usuario.Location = new Point(91, 30);
                        usuario.ForeColor = Color.White;
                        usuario.Font = new Font("Arial", 12.0f);
                        usuario.Name = "lblUSoliMo" + soli.IdSolicitudModif.ToString();
                        usuario.Text = "Usuario:\n" + us.Nombre + " " + us.Primer_apellido;
                        usuario.Click += new EventHandler(AbrirSolicitudModif);

                        Label fecha = new Label();
                        fecha.Height = 48;
                        fecha.Width = 100;
                        fecha.Location = new Point(610, 17);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 12.0f);
                        fecha.Name = "lblFSoliMo" + soli.IdSolicitudModif.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudModif);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 720;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliDo" + soli.IdSolicitudModif.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudModif);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(perdio);
                        panel.Controls.Add(usuario);
                        panel.Controls.Add(picPhoto);
                        PanelSolicitudesResueltas.Controls.Add(panel);
                    }

                }
            }
        }

        private void AbrirSolicitudClaseAl(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            panelContenedorResueltas.Visible = false;
            btnFiltrar.Visible = false;
            dtpFiltroFecha.Visible = false;
            btnVolver.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                soliAl = new Logica.SolicitudClaseAl().SelectSolicitudClaseAlPorId(new Logica.SolicitudClaseAl().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                soliAl = new Logica.SolicitudClaseAl().SelectSolicitudClaseAlPorId(new Logica.SolicitudClaseAl().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                soliAl = new Logica.SolicitudClaseAl().SelectSolicitudClaseAlPorId(new Logica.SolicitudClaseAl().StringAId(((Panel)sender).Name));
            }
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliAl.Alumno);
            claseSolicitudesClaseAl = new Logica.ClaseSolicitudClaseAl().SelectClaseSolicitudClaseAl(soliAl.IdSolicitudClaseAl);
            lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " desea ingresar a los siguientes grupos:";
            lblCedula.Text = us.Ci[0].ToString() + "." + us.Ci[1].ToString() + us.Ci[2].ToString() + us.Ci[3].ToString() + "." + us.Ci[4].ToString() + us.Ci[5].ToString() + us.Ci[6].ToString() + "-" + us.Ci[7].ToString();

            panelModif.Visible = false;

            Label lblSolIngre = new Label();
            lblSolIngre.Height = 36;
            lblSolIngre.Width = 400;
            lblSolIngre.Location = new Point(0, 5);
            lblSolIngre.ForeColor = Color.White;
            lblSolIngre.Font = new Font("Arial", 13.0f);
            lblSolIngre.Name = "lblSolIngre";
            lblSolIngre.Text = us.Primer_apellido + " envio solicitud para ingresar a:";
            panelContenido.Controls.Add(lblSolIngre);
            asignaturaSolicitudesClaseAl.AddRange(new Logica.AsignaturaSolicitudClaseAl().SelectAsignaturaSolicitudClaseAl(soliAl.IdSolicitudClaseAl));
            int xlblAsig = 5, xlblClase = 5;
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                Label lblClase = new Label();
                lblClase.Height = 46;
                lblClase.Width = 150;
                lblClase.Location = new Point(xlblClase, 41);
                lblClase.Name = "lblClase" + claseSoli.IdClase;
                lblClase.ForeColor = Color.White;
                lblClase.Font = new Font("Arial", 12.0f);
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblClase.Text = clas.Anio + "°" + clas.Nombre + "\n" + new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                xlblClase += 160;
                int ylblAsig = 90;
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAl in asignaturaSolicitudesClaseAl)
                {
                    if (claseSoli.IdClase == asigSoliAl.IdClaseAsig)
                    {
                        Label dina = new Label();
                        dina.Height = 46;
                        dina.Width = 150;
                        dina.ForeColor = Color.White;
                        dina.Font = new Font("Arial", 8.0f);
                        dina.Location = new Point(xlblAsig, ylblAsig);
                        ylblAsig += 48;
                        dina.Name = "lblAsig" + asigSoliAl.IdAsignatura + "Cl" + asigSoliAl.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliAl.IdAsignatura).Nombre + " (Denegada)";
                        if (asigSoliAl.Aceptada)
                        {
                            dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliAl.IdAsignatura).Nombre + " (Aceptada)";
                        }
                        panelContenido.Controls.Add(dina);
                    }
                }
                xlblAsig += 160;
            }
        }

        private void AbrirSolicitudClaseDo(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            panelContenedorResueltas.Visible = false;
            btnFiltrar.Visible = false;
            dtpFiltroFecha.Visible = false;
            btnVolver.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                soliDo = new Logica.SolicitudClaseDo().SelectSolicitudClaseDoPorId(new Logica.SolicitudClaseDo().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                soliDo = new Logica.SolicitudClaseDo().SelectSolicitudClaseDoPorId(new Logica.SolicitudClaseDo().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                soliDo = new Logica.SolicitudClaseDo().SelectSolicitudClaseDoPorId(new Logica.SolicitudClaseDo().StringAId(((Panel)sender).Name));
            }
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliDo.Docente);
            claseSolicitudesClaseDo = new Logica.ClaseSolicitudClaseDo().SelectClaseSolicitudClaseDo(soliDo.IdSolicitudClaseDo);
            lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " desea ingresar a los siguientes grupos:";
            lblCedula.Text = us.Ci[0].ToString() + "." + us.Ci[1].ToString() + us.Ci[2].ToString() + us.Ci[3].ToString() + "." + us.Ci[4].ToString() + us.Ci[5].ToString() + us.Ci[6].ToString() + "-" + us.Ci[7].ToString();

            panelModif.Visible = false;

            Label lblSolIngre = new Label();
            lblSolIngre.Height = 36;
            lblSolIngre.Width = 400;
            lblSolIngre.Location = new Point(0, 5);
            lblSolIngre.ForeColor = Color.White;
            lblSolIngre.Font = new Font("Arial", 13.0f);
            lblSolIngre.Name = "lblSolIngre";
            lblSolIngre.Text = us.Primer_apellido + " envio solicitud para ingresar a:";
            panelContenido.Controls.Add(lblSolIngre);
            asignaturaSolicitudesClaseDo.AddRange(new Logica.AsignaturaSolicitudClaseDo().SelectAsignaturaSolicitudClaseDo(soliDo.IdSolicitudClaseDo));
            int xlblAsig = 5, xlblClase = 5;
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                Label lblClase = new Label();
                lblClase.Height = 46;
                lblClase.Width = 150;
                lblClase.Location = new Point(xlblClase, 41);
                lblClase.Name = "lblClase" + claseSoli.IdClase;
                lblClase.ForeColor = Color.White;
                lblClase.Font = new Font("Arial", 12.0f);
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblClase.Text = clas.Anio + "°" + clas.Nombre + "\n" + new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                xlblClase += 160;
                int ylblAsig = 90;
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoliDo in asignaturaSolicitudesClaseDo)
                {
                    if (asigSoliDo.IdClaseAsig == claseSoli.IdClase)
                    {
                        Label dina = new Label();
                        dina.Height = 46;
                        dina.Width = 150;
                        dina.ForeColor = Color.White;
                        dina.Font = new Font("Arial", 8.0f);
                        dina.Location = new Point(xlblAsig, ylblAsig);
                        ylblAsig += 48;
                        dina.Name = "lblAsig" + asigSoliDo.IdAsignatura + "Cl" + asigSoliDo.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre + " (Denegada)";
                        if (asigSoliDo.Aceptada)
                        {
                            dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre + " (Aceptada)";
                        }
                        panelContenido.Controls.Add(dina);
                    }
                }
                xlblAsig += 160;
            }
        }

        private void AbrirSolicitudModif(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            panelContenedorResueltas.Visible = false;
            btnFiltrar.Visible = false;
            dtpFiltroFecha.Visible = false;
            btnVolver.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                soliMo = new Logica.SolicitudModif().SelectSolicitudModifPorId(new Logica.SolicitudClaseDo().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                soliMo = new Logica.SolicitudModif().SelectSolicitudModifPorId(new Logica.SolicitudClaseDo().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                soliMo = new Logica.SolicitudModif().SelectSolicitudModifPorId(new Logica.SolicitudClaseDo().StringAId(((Panel)sender).Name));
            }
            panelModif.Visible = true;

            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliMo.Usuario);
            lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " ha perdido\n el acceso a su cuenta";
            lblCedula.Text = us.Ci[0].ToString() + "." + us.Ci[1].ToString() + us.Ci[2].ToString() + us.Ci[3].ToString() + "." + us.Ci[4].ToString() + us.Ci[5].ToString() + us.Ci[6].ToString() + "-" + us.Ci[7].ToString();
            panelModif.Controls.Clear();
            Label lblSolIngre = new Label();
            lblSolIngre.Height = 227;
            lblSolIngre.Width = 657;
            lblSolIngre.ForeColor = Color.White;
            lblSolIngre.Font = new Font("Arial", 18.0f);
            lblSolIngre.Location = new Point(0, 0);
            lblSolIngre.Name = "lblSolMo";
            lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.\nSe ha negado la solicitud";
            if (soliMo.Aceptada)
            {
                lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.\nSe ha aceptado la solicitud";
            }
            panelModif.Controls.Add(lblSolIngre);
            
        }
        private void tmrSolicitudes_Tick(object sender, EventArgs e)
        {
            CargarSolicitudes();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar = !filtrar;
            btnFiltrar.Text = "Filtrar";
            if (filtrar)
            {
                btnFiltrar.Text = "Dejar de filtrar";
            }
            dtpFiltroFecha.Visible = !dtpFiltroFecha.Visible;
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelSolicitud.Visible = false;
            panelContenedorResueltas.Visible = true;
            btnFiltrar.Visible = true;
            dtpFiltroFecha.Visible = filtrar;
            btnFiltrar.Visible = true;
            btnVolver.Visible = false;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }


}
