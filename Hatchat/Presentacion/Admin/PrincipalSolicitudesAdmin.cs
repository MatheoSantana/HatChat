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
    public partial class PrincipalSolicitudesAdmin : Form
    {

        List<Logica.ClaseSolicitudClaseAl> claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
        Logica.SolicitudClaseAl soliAl = new Logica.SolicitudClaseAl();
        List<Logica.AsignaturaSolicitudClaseAl> asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();

        List<Logica.ClaseSolicitudClaseDo> claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
        Logica.SolicitudClaseDo soliDo = new Logica.SolicitudClaseDo();

        Logica.SolicitudModif soliMo = new Logica.SolicitudModif();

        List<Logica.SolicitudClaseAl> solicitudesClaseAl = new List<Logica.SolicitudClaseAl>();
        List<Logica.SolicitudClaseDo> solicitudesClaseDo = new List<Logica.SolicitudClaseDo>();
        List<Logica.SolicitudModif> solicitudesModif = new List<Logica.SolicitudModif>();

        public Form login;
        public Form abmAlumnoAdmin;
        public Form abmDocenteAdmin;
        public Form abmGruposAdmin;
        public Form historialSolicitudesAdmin;

        public PrincipalSolicitudesAdmin()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(1280, 720);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            panelSolicitud.Visible = false;
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxSolicitudesNav.Image = Image.FromFile("solicitudes admin blanco.png");
                pbxABMAlumnoNav.Image = Image.FromFile("abm alumno gris.png");
                pbxABMDocenteNav.Image = Image.FromFile("abm docente gris.png");
                pbxABMGruposNav.Image = Image.FromFile("abm grupos gris.png");
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

            List<Logica.SolicitudClaseAl> solicitudesClaseAl = new Logica.SolicitudClaseAl().SelectSolicitudesClaseAl();
            List<Logica.SolicitudClaseDo> solicitudesClaseDo = new Logica.SolicitudClaseDo().SelectSolicitudesClaseDo();
            List<Logica.SolicitudModif> solicitudesModif = new Logica.SolicitudModif().SelectSolicitudesModif();
            bool iguales = true;
            if (solicitudesClaseAl.Count() == this.solicitudesClaseAl.Count())
            {
                for (int x = 0; x < solicitudesClaseAl.Count(); x++)
                {
                    if (!(solicitudesClaseAl[x].IdSolicitudClaseAl == this.solicitudesClaseAl[x].IdSolicitudClaseAl))
                    {
                        iguales = false;
                    }
                }
            }
            else
            {
                iguales = false;
            }
            if (solicitudesClaseDo.Count() == this.solicitudesClaseDo.Count())
            {
                for (int x = 0; x < solicitudesClaseDo.Count(); x++)
                {
                    if (!(solicitudesClaseDo[x].IdSolicitudClaseDo == this.solicitudesClaseDo[x].IdSolicitudClaseDo))
                    {
                        iguales = false;
                    }
                }
            }
            else
            {
                iguales = false;
            }
            if (solicitudesModif.Count() == this.solicitudesModif.Count())
            {
                for (int x = 0; x < solicitudesModif.Count(); x++)
                {
                    if (!(solicitudesModif[x].IdSolicitudModif == this.solicitudesModif[x].IdSolicitudModif))
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
                this.solicitudesClaseAl = solicitudesClaseAl;
                this.solicitudesClaseDo = solicitudesClaseDo;
                this.solicitudesModif = solicitudesModif;
                ArrayList solicitudesDesordenadas = new ArrayList();

                ArrayList solicitudesOrdenadas = new ArrayList();
                if (solicitudesClaseAl.Count() > 0)
                {
                    solicitudesDesordenadas.AddRange(solicitudesClaseAl);
                    foreach (Logica.SolicitudClaseDo soliDo in solicitudesClaseDo)
                    {
                        for (int x = 0; x < solicitudesDesordenadas.Count; x++)
                        {
                            if (!solicitudesDesordenadas.Contains(soliDo))
                            {
                                if (soliDo.FechaHora > solicitudesClaseAl[x].FechaHora)
                                {
                                    solicitudesDesordenadas.Insert(x, soliDo);
                                }
                            }
                        }
                        if (!solicitudesDesordenadas.Contains(soliDo))
                        {
                            solicitudesDesordenadas.Add(soliDo);
                        }
                    }
                }
                else
                {
                    solicitudesDesordenadas.AddRange(solicitudesClaseDo);
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
                                    solicitudesOrdenadas.Insert(x,soliMo);
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
                                    solicitudesOrdenadas.Insert(x, soliMo);
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
                                    solicitudesOrdenadas.Insert(x, soliMo);
                                }
                            }
                        }
                    }
                    if (!solicitudesOrdenadas.Contains(soliMo))
                    {
                        solicitudesOrdenadas.Add(soliMo);
                    }
                }
                
                int yPanel = 0;
                PanelSolicitudesPendientes.Controls.Clear();

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
                        grupo.Font = new Font("Arial", 10.0f);
                        grupo.Name = "lblSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        grupo.Text = "Desea entrar a un grupo";
                        grupo.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Label alumno = new Label();
                        alumno.Height = 58;
                        alumno.Width = 277;
                        alumno.Location = new Point(91, 30);
                        alumno.ForeColor = Color.White;
                        alumno.Font = new Font("Arial", 10.0f);
                        alumno.Name = "lblASoliAl" + soli.IdSolicitudClaseAl.ToString();
                        alumno.Text = "Alumno:\n" + al.Nombre + " " + al.Primer_apellido;
                        alumno.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Label fecha = new Label();
                        fecha.Height = 24;
                        fecha.Width = 150;
                        fecha.Location = new Point(195, 65);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 8.0f);
                        fecha.Name = "lblFSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudClaseAl);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 302;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliAl" + soli.IdSolicitudClaseAl.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudClaseAl);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(grupo);
                        panel.Controls.Add(alumno);
                        panel.Controls.Add(picPhoto);

                        PanelSolicitudesPendientes.Controls.Add(panel);


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
                        grupo.Font = new Font("Arial", 10.0f);
                        grupo.Name = "lblSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        grupo.Text = "Desea entrar a un grupo";
                        grupo.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Label docente = new Label();
                        docente.Height = 58;
                        docente.Width = 277;
                        docente.Location = new Point(91, 30);
                        docente.ForeColor = Color.White;
                        docente.Font = new Font("Arial", 10.0f);
                        docente.Name = "lblASoliDo" + soli.IdSolicitudClaseDo.ToString();
                        docente.Text = "Docente:\n" + doc.Nombre + " " + doc.Primer_apellido;
                        docente.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Label fecha = new Label();
                        fecha.Height = 24;
                        fecha.Width = 150;
                        fecha.Location = new Point(195, 65);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 8.0f);
                        fecha.Name = "lblFSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudClaseDo);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 302;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliDo" + soli.IdSolicitudClaseDo.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudClaseDo);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(grupo);
                        panel.Controls.Add(docente);
                        panel.Controls.Add(picPhoto);

                        PanelSolicitudesPendientes.Controls.Add(panel);


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
                        perdio.ForeColor = Color.FromArgb(206,82,75);
                        perdio.Font = new Font("Arial", 10.0f);
                        perdio.Text = "Perdio el acceso a su cuenta";
                        perdio.Name = "lblSoliMod" + soli.IdSolicitudModif.ToString();
                        perdio.Click += new EventHandler(AbrirSolicitudModif);

                        Label usuario = new Label();
                        usuario.Height = 58;
                        usuario.Width = 277;
                        usuario.Location = new Point(91, 30);
                        usuario.ForeColor = Color.White;
                        usuario.Font = new Font("Arial", 10.0f);
                        usuario.Name = "lblUSoliMo" + soli.IdSolicitudModif.ToString();
                        usuario.Text = "Usuario:\n" + us.Nombre + " " + us.Primer_apellido;
                        usuario.Click += new EventHandler(AbrirSolicitudModif);

                        Label fecha = new Label();
                        fecha.Height = 24;
                        fecha.Width = 150;
                        fecha.Location = new Point(195, 65);
                        fecha.ForeColor = Color.White;
                        fecha.Font = new Font("Arial", 8.0f);
                        fecha.Name = "lblFSoliMo" + soli.IdSolicitudModif.ToString();
                        fecha.Text = soli.FechaHora.ToString();
                        fecha.Click += new EventHandler(AbrirSolicitudModif);

                        Panel panel = new Panel();
                        panel.Height = 83;
                        panel.Width = 302;
                        panel.Location = new Point(0, yPanel);
                        yPanel += 83;
                        panel.Name = "panelSoliDo" + soli.IdSolicitudModif.ToString();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Click += new EventHandler(AbrirSolicitudModif);

                        panel.Controls.Add(fecha);
                        panel.Controls.Add(perdio);
                        panel.Controls.Add(usuario);
                        panel.Controls.Add(picPhoto);

                        PanelSolicitudesPendientes.Controls.Add(panel);

                    }

                }
            }
        }

        private void AbrirSolicitudClaseAl(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
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
            if (claseSolicitudesClaseAl.Count == 1)
            {
                lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " desea ingresar al siguiente grupo:";
            }
            
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
            int xchbxAsig = 5, xlblClase = 5;
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
                int ychbxAsig = 90;
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAl in asignaturaSolicitudesClaseAl)
                {
                    if (claseSoli.IdClase == asigSoliAl.IdClaseAsig)
                    {
                        CheckBox dina = new CheckBox();
                        dina.Height = 23;
                        dina.Width = 150;
                        dina.Checked = asigSoliAl.Aceptada;
                        dina.ForeColor = Color.White;
                        dina.Font = new Font("Arial", 12.0f);
                        dina.Location = new Point(xchbxAsig, ychbxAsig);
                        ychbxAsig += 25;
                        dina.Name = "chbxAsig" + asigSoliAl.IdAsignatura + "Cl" + asigSoliAl.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliAl.IdAsignatura).Nombre;
                        dina.CheckedChanged += new EventHandler(AsignaturaCambiadaAl);
                        panelContenido.Controls.Add(dina);
                    }
                }
                xchbxAsig += 160;
            }
        }
        private void AsignaturaCambiadaAl(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.AsignaturaSolicitudClaseAl asig in asignaturaSolicitudesClaseAl)
                {

                    if (((CheckBox)sender).Name == "chbxAsig" + asig.IdAsignatura + "Cl" + asig.IdClaseAsig)
                    {
                        asig.Aceptada = true;
                    }

                }
            }
            else
            {

                foreach (Logica.AsignaturaSolicitudClaseAl soliAsi in asignaturaSolicitudesClaseAl)
                {
                    if (((CheckBox)sender).Name == "chbxAsig" + soliAsi.IdAsignatura + "Cl" + soliAsi.IdClaseAsig)
                    {
                        soliAsi.Aceptada = false;
                    }
                }

            }
        }
        private void AbrirSolicitudClaseDo(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();

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
            if (claseSolicitudesClaseAl.Count == 1)
            {
                lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " desea ingresar al siguiente grupo:";
            }

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
            int xchbxAsig = 5, xlblClase = 5;
            foreach (Logica.ClaseSolicitudClaseDo claseSoli in claseSolicitudesClaseDo)
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
                int ychbxAsig = 90;
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoliDo in asignaturaSolicitudesClaseDo)
                {
                    if (claseSoli.IdClase == asigSoliDo.IdClaseAsig)
                    {
                        CheckBox dina = new CheckBox();
                        dina.Height = 23;
                        dina.Width = 150;
                        dina.Checked = asigSoliDo.Aceptada;
                        dina.ForeColor = Color.White;
                        dina.Font = new Font("Arial", 12.0f);
                        dina.Location = new Point(xchbxAsig, ychbxAsig);
                        ychbxAsig += 25;
                        dina.Name = "chbxAsig" + asigSoliDo.IdAsignatura + "Cl" + asigSoliDo.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre;
                        dina.CheckedChanged += new EventHandler(AsignaturaCambiadaAl);
                        panelContenido.Controls.Add(dina);
                    }
                }
                xchbxAsig += 160;
            }

        }
        private void AsignaturaCambiadaDo(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Logica.AsignaturaSolicitudClaseDo asig in asignaturaSolicitudesClaseDo)
                {

                    if (((CheckBox)sender).Name == "chbxAsig" + asig.IdAsignatura + "Cl" + asig.IdClaseAsig)
                    {
                        asig.Aceptada = true; ;
                    }

                }
            }
            else
            {

                foreach (Logica.AsignaturaSolicitudClaseDo soliAsi in asignaturaSolicitudesClaseDo)
                {
                    if (((CheckBox)sender).Name == "chbxAsig" + soliAsi.IdAsignatura + "Cl" + soliAsi.IdClaseAsig)
                    {
                        soliAsi.Aceptada = false;
                    }
                }

            }
        }
        private void AbrirSolicitudModif(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelSolicitud.Visible = true;
            claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
            claseSolicitudesClaseAl = new List<Logica.ClaseSolicitudClaseAl>();
            asignaturaSolicitudesClaseAl = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
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
            lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.";
            panelModif.Controls.Add(lblSolIngre);

        }
        private void tmrSolicitudes_Tick(object sender, EventArgs e)
        {
            CargarSolicitudes();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (soliAl.IdSolicitudClaseAl != 0)
            {
                string fallo = "Las siguientes asignaturas ya estaban registradas:";
                string ingresadas = "Las siguientes asignaturas fueron ingresadas con existo:";
                foreach (Logica.ClaseSolicitudClaseAl claseSolicitudClaseAl in claseSolicitudesClaseAl)
                {
                    bool cursar = false;
                    Logica.Cursa cursa = new Logica.Cursa(claseSolicitudClaseAl.IdClase, soliAl.Alumno, claseSolicitudClaseAl.OriClase, DateTime.Now.Year);
                    foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAcep in asignaturaSolicitudesClaseAl)
                    {
                        if (claseSolicitudClaseAl.IdClase == asigSoliAcep.IdClaseAsig && claseSolicitudClaseAl.OriClase == asigSoliAcep.OriClaseAsig)
                        {
                            cursar = true;
                        }
                    }
                    if (cursar)
                    {
                        if (!cursa.SelectCursando())
                        {
                            cursa.InsertCursa();
                        }
                        foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAcep in asignaturaSolicitudesClaseAl)
                        {
                            if (claseSolicitudClaseAl.IdClase == asigSoliAcep.IdClaseAsig && claseSolicitudClaseAl.OriClase == asigSoliAcep.OriClaseAsig)
                            {
                                if (asigSoliAcep.Aceptada)
                                {
                                    Logica.AsignaturaCursa asigCursa = new Logica.AsignaturaCursa(soliAl.Alumno, asigSoliAcep.IdClaseAsig, asigSoliAcep.OriClaseAsig, DateTime.Now.Year, asigSoliAcep.IdAsignatura, true);
                                    if (asigCursa.SelectCursandoAsignatura())
                                    {
                                        if (asigCursa.SelectCursandoAsignaturaDesactivada())
                                        {
                                            asigCursa.ActivarAsignaturaCursa();
                                            ingresadas += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigCursa.AsignaturaCursada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigCursa.Orientacion).Nombre;
                                        }
                                        else
                                        {
                                            fallo += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigCursa.AsignaturaCursada).Nombre + " "+ new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigCursa.Orientacion).Nombre;
                                        }
                                    }
                                    else
                                    {
                                        asigCursa.InsertAsignaturaCursa();
                                        ingresadas += "\n" + new Logica.Asignatura().SelectAsignaturaPorId(asigCursa.AsignaturaCursada).Nombre + " " + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Anio + new Logica.Clase().SelectClasePorId(asigCursa.IdClase).Nombre + " " + new Logica.Orientacion().SelectOrientacioPorId(asigCursa.Orientacion).Nombre;

                                    }
                                }
                                asigSoliAcep.AceptarAsignaturaSolicitudClaseAl();

                            }

                        }
                    }
                }
                soliAl.AceptarSolicitudClaseAlPorIdYAdmin(soliAl.IdSolicitudClaseAl, Login.encontrado.Ci);
                if(ingresadas!= "Las siguientes asignaturas fueron ingresadas con existo:")
                {
                    MessageBox.Show(ingresadas);
                }
                if(ingresadas != "Las siguientes asignaturas ya estaban registradas:")
                {
                    MessageBox.Show(fallo);
                }
                
            }
            
            asignaturaSolicitudesClaseAl.Clear();
            claseSolicitudesClaseAl.Clear();
            soliAl = new Logica.SolicitudClaseAl();

            if (soliDo.IdSolicitudClaseDo != 0)
            {
                string fallo = "Las siguientes asignaturas ya estaban registradas:";
                string ingresadas = "Las siguientes asignaturas fueron ingresadas con existo:";
                foreach (Logica.ClaseSolicitudClaseDo claseSolicitudClaseDo in claseSolicitudesClaseDo)
                {
                    bool dictar = false;
                    Logica.Dicta dicta = new Logica.Dicta(claseSolicitudClaseDo.IdClase, soliDo.Docente, claseSolicitudClaseDo.OriClase, DateTime.Now.Year);
                    foreach (Logica.AsignaturaSolicitudClaseDo asigSoliAcep in asignaturaSolicitudesClaseDo)
                    {
                        if (claseSolicitudClaseDo.IdClase == asigSoliAcep.IdClaseAsig && claseSolicitudClaseDo.OriClase == asigSoliAcep.OriClaseAsig)
                        {
                            dictar = true;
                        }
                    }
                    if (dictar)
                    {
                        if (!dicta.SelectDictando())
                        {
                            dicta.InsertDicta();
                        }
                        foreach (Logica.AsignaturaSolicitudClaseDo asigSoliAcep in asignaturaSolicitudesClaseDo)
                        {
                            if (claseSolicitudClaseDo.IdClase == asigSoliAcep.IdClaseAsig && claseSolicitudClaseDo.OriClase == asigSoliAcep.OriClaseAsig)
                            {
                                if (asigSoliAcep.Aceptada)
                                {
                                    Logica.AsignaturaDictada asigDicta = new Logica.AsignaturaDictada(soliDo.Docente, asigSoliAcep.IdClaseAsig, asigSoliAcep.OriClaseAsig, DateTime.Now.Year, asigSoliAcep.IdAsignatura, true);
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
                                asigSoliAcep.AceptarAsignaturaSolicitudClaseDo();

                            }

                        }
                    }
                }
                soliDo.AceptarSolicitudClaseDoPorIdYAdmin(soliDo.IdSolicitudClaseDo, Login.encontrado.Ci);
                if (ingresadas != "Las siguientes asignaturas fueron ingresadas con existo:")
                {
                    MessageBox.Show(ingresadas);
                }
                if (ingresadas != "Las siguientes asignaturas ya estaban registradas:")
                {
                    MessageBox.Show(fallo);
                }
            }

            asignaturaSolicitudesClaseDo.Clear();
            claseSolicitudesClaseDo.Clear();
            soliDo = new Logica.SolicitudClaseDo();

            if (soliMo.IdSolicitudModif != 0)
            {
                soliMo.Aceptada = true;
                soliMo.AceptarSolicitudModifPorSoliYAdmin(Login.encontrado.Ci, true);
                MessageBox.Show("Se ha modificado la contraseña correctamente");
            }
            soliMo = new Logica.SolicitudModif();
            panelSolicitud.Visible = false;
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            if (soliAl.IdSolicitudClaseAl != 0)
            {
                soliAl.AceptarSolicitudClaseAlPorIdYAdmin(soliAl.IdSolicitudClaseAl, Login.encontrado.Ci);
            }
            asignaturaSolicitudesClaseAl.Clear();
            claseSolicitudesClaseAl.Clear();
            soliAl = new Logica.SolicitudClaseAl();

            if (soliDo.IdSolicitudClaseDo != 0)
            {
                soliDo.AceptarSolicitudClaseDoPorIdYAdmin(soliDo.IdSolicitudClaseDo, Login.encontrado.Ci);
            }

            asignaturaSolicitudesClaseDo.Clear();
            claseSolicitudesClaseDo.Clear();
            soliDo = new Logica.SolicitudClaseDo();

            if (soliMo.IdSolicitudModif != 0)
            {
                soliMo.Aceptada = false;
                soliMo.AceptarSolicitudModifPorSoliYAdmin(Login.encontrado.Ci, true);
            }
            soliMo = new Logica.SolicitudModif();

            panelSolicitud.Visible = false;
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        
    }


}
