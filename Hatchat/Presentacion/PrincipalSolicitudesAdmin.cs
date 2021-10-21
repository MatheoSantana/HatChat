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
        List<Logica.AsignaturaSolicitudClaseAl> asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();

        List<Logica.ClaseSolicitudClaseDo> claseSolicitudesClaseDo = new List<Logica.ClaseSolicitudClaseDo>();
        List<Logica.AsignaturaSolicitudClaseDo>asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
        Logica.SolicitudClaseDo soliDo = new Logica.SolicitudClaseDo();
        List<Logica.AsignaturaSolicitudClaseDo> asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();

        Logica.SolicitudModif soliMo = new Logica.SolicitudModif();

        public Form login;
        public Form abmAlumnoAdmin;
        public Form abmDocenteAdmin;
        public Form abmGruposAdmin;
        public Form historialSolicitudes;

        public PrincipalSolicitudesAdmin()
        {
            
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
            ArrayList solicitudesDesordenadas = new ArrayList();
            int y;


            ArrayList solicitudesOrdenadas = new ArrayList();
            if (solicitudesClaseAl.Count() > 0)
            {
                foreach (Logica.SolicitudClaseAl soliAl in solicitudesClaseAl)
                {
                    if (solicitudesClaseDo.Count() > 0)
                    {
                        foreach (Logica.SolicitudClaseDo soliDo in solicitudesClaseDo)
                        {
                            if (!solicitudesDesordenadas.Contains(soliDo))
                            {
                                if (soliDo.FechaHora > soliAl.FechaHora)
                                {
                                    solicitudesDesordenadas.Add(soliDo);
                                }
                                else if (!solicitudesDesordenadas.Contains(soliAl))
                                {
                                    solicitudesDesordenadas.Add(soliAl);
                                }
                            }
                        }
                    }
                    else
                    {
                        solicitudesDesordenadas.Add(soliAl);
                    }
                }
            }
            else
            {
                solicitudesDesordenadas.AddRange(solicitudesClaseDo);
            }

            foreach (Logica.SolicitudModif soliMo in solicitudesModif)
            {
                for (int x = 0; x < solicitudesDesordenadas.Count; x++)
                {
                    if (solicitudesDesordenadas[x].GetType().Name == "SolicitudClaseAl")
                    {
                        Logica.SolicitudClaseAl soli = (Logica.SolicitudClaseAl)solicitudesDesordenadas[x];
                        if (!solicitudesOrdenadas.Contains(soliMo))
                        {
                            if (soliMo.FechaHora > soli.FechaHora)
                            {
                                solicitudesOrdenadas.Add(soliMo);
                            }
                        }
                    }
                    else
                    {
                        Logica.SolicitudClaseDo soli = (Logica.SolicitudClaseDo)solicitudesDesordenadas[x];
                        if (!solicitudesOrdenadas.Contains(soliMo))
                        {
                            if (soliMo.FechaHora > soli.FechaHora)
                            {
                                solicitudesOrdenadas.Add(soliMo);
                            }
                        }
                    }
                }

            }
            foreach (Logica.SolicitudModif soliMo in solicitudesModif)
            {
                if (!solicitudesOrdenadas.Contains(soliMo))
                {
                    solicitudesOrdenadas.Add(soliMo);
                }
            }
            for (int x = 0; x < solicitudesDesordenadas.Count; x++)
            {
                if (solicitudesDesordenadas[x].GetType().Name == "SolicitudClaseAl")
                {
                    Logica.SolicitudClaseAl soli = (Logica.SolicitudClaseAl)solicitudesDesordenadas[x];
                    if (!solicitudesOrdenadas.Contains(soli))
                    {
                        solicitudesOrdenadas.Add(soli);
                    }
                }
                else
                {
                    Logica.SolicitudClaseDo soli = (Logica.SolicitudClaseDo)solicitudesDesordenadas[x];
                    if (!solicitudesOrdenadas.Contains(soli))
                    {
                        solicitudesOrdenadas.Add(soli);
                    }
                }
            }


            y = 5;
            PanelSolicitudesPendientes.Controls.Clear();

            for (int x = 0; x < solicitudesOrdenadas.Count; x++)
            {
                if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
                {
                    Logica.SolicitudClaseAl soli = (Logica.SolicitudClaseAl)solicitudesOrdenadas[x];
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Alumno);
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblSoliAl" + soli.IdSolicitudClaseAl.ToString();
                    dina.Text = us.Nombre + " " + us.Primer_apellido + "\nDesea entrar a un grupo" + "\n" + soli.FechaHora.ToString();
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(AbrirSolicitudClaseAl);
                    PanelSolicitudesPendientes.Controls.Add(dina);
                }
                else if (solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseDo")
                {
                    Logica.SolicitudClaseDo soli = (Logica.SolicitudClaseDo)solicitudesOrdenadas[x];
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Docente);
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblSoliDo" + soli.IdSolicitudClaseDo.ToString();
                    dina.Text = us.Nombre + " " + us.Primer_apellido + "\nDesea entrar a un grupo" + "\n" + soli.FechaHora.ToString();
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(AbrirSolicitudClaseDo);
                    PanelSolicitudesPendientes.Controls.Add(dina);
                }
                else
                {
                    Logica.SolicitudModif soli = (Logica.SolicitudModif)solicitudesOrdenadas[x];
                    Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soli.Usuario);
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblSoliMod" + soli.IdSolicitudModif.ToString();
                    dina.Text = us.Nombre + " " + us.Primer_apellido + "\nPerdio el acceso a su cuenta" + "\n" + soli.FechaHora.ToString();
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(AbrirSolicitudModif);
                    PanelSolicitudesPendientes.Controls.Add(dina);
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
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            soliAl = new Logica.SolicitudClaseAl().SelectSolicitudClaseAlPorId(new Logica.SolicitudClaseAl().StringAId(((Label)sender).Name));
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliAl.Alumno);
            claseSolicitudesClaseAl = new Logica.ClaseSolicitudClaseAl().SelectClaseSolicitudClaseAl(soliAl.IdSolicitudClaseAl);
            lblNombreApellidoSolicitud.Text = us.Nombre+" "+us.Primer_apellido+" desea ingresar a los siguientes grupos:";
            lblCedula.Text = us.Ci;

            Label lblSolIngre = new Label();
            lblSolIngre.Height = 46;
            lblSolIngre.Width = 150;
            lblSolIngre.Location = new Point(25, 10);
            lblSolIngre.Name = "lblSolIngre";
            lblSolIngre.Text = us.Primer_apellido + " envio solicitud para ingresar a:";
            panelContenido.Controls.Add(lblSolIngre);

            int xchbxAsig = 5, ychbxAsig = 100, xlblClase=5;
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                Label lblClase = new Label();
                lblSolIngre.Height = 46;
                lblSolIngre.Width = 150;
                lblSolIngre.Location = new Point(xlblClase, 50);
                lblSolIngre.Name = "lblClase"+claseSoli.IdClase;
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblSolIngre.Text =  clas.Anio+"°"+clas.Nombre+"\n"+new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                asignaturaSolicitudesClaseAl.AddRange(new Logica.AsignaturaSolicitudClaseAl().SelectAsignaturaSolicitudClaseAl(soliAl.IdSolicitudClaseAl));
                xlblClase += 160;
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAl in asignaturaSolicitudesClaseAl)
                {
                    if (claseSoli.IdClase == asigSoliAl.IdClaseAsig)
                    {
                        CheckBox dina = new CheckBox();
                        dina.Height = 23;
                        dina.Width = 150;
                        dina.Location = new Point(xchbxAsig, ychbxAsig);
                        ychbxAsig += 25;
                        dina.Name = "chbxAsig" + asigSoliAl.IdAsignatura;
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

                    if (((CheckBox)sender).Name == "chbxAsig" + asig.IdAsignatura)
                    {
                        asignaturaSolicitudesClaseAlAceptadas.Add(asig);
                    }

                }
            }
            else
            {

                foreach (Logica.AsignaturaSolicitudClaseAl soliAsi in asignaturaSolicitudesClaseAl)
                {
                    if (((CheckBox)sender).Name == "chbxAsig" + soliAsi.IdAsignatura)
                    {
                        asignaturaSolicitudesClaseAlAceptadas.Remove(soliAsi);
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
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            soliDo = new Logica.SolicitudClaseDo().SelectSolicitudClaseDoPorId(new Logica.SolicitudClaseDo().StringAId(((Label)sender).Name));
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliDo.Docente);
            claseSolicitudesClaseDo = new Logica.ClaseSolicitudClaseDo().SelectClaseSolicitudClaseDo(soliDo.IdSolicitudClaseDo);
            lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " desea ingresar a los siguientes grupos:";
            lblCedula.Text = us.Ci;

            Label lblSolIngre = new Label();
            lblSolIngre.Height = 46;
            lblSolIngre.Width = 150;
            lblSolIngre.Location = new Point(25, 10);
            lblSolIngre.Name = "lblSolIngre";
            lblSolIngre.Text = us.Primer_apellido + " envio solicitud para ingresar a:";
            panelContenido.Controls.Add(lblSolIngre);

            int xchbxAsig = 5, ychbxAsig = 100, xlblClase = 5;
            foreach (Logica.ClaseSolicitudClaseDo claseSoli in claseSolicitudesClaseDo)
            {
                Label lblClase = new Label();
                lblSolIngre.Height = 46;
                lblSolIngre.Width = 150;
                lblSolIngre.Location = new Point(xlblClase, 50);
                lblSolIngre.Name = "lblClase" + claseSoli.IdClase;
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblSolIngre.Text = clas.Anio + "°" + clas.Nombre + "\n" + new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                asignaturaSolicitudesClaseDo.AddRange(new Logica.AsignaturaSolicitudClaseDo().SelectAsignaturaSolicitudClaseDo(soliDo.IdSolicitudClaseDo));
                xlblClase += 160;
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoliDo in asignaturaSolicitudesClaseDo)
                {
                    if (claseSoli.IdClase == asigSoliDo.IdClaseAsig)
                    {
                        CheckBox dina = new CheckBox();
                        dina.Height = 23;
                        dina.Width = 150;
                        dina.Location = new Point(xchbxAsig, ychbxAsig);
                        ychbxAsig += 25;
                        dina.Name = "chbxAsig" + asigSoliDo.IdAsignatura;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre;

                        dina.CheckedChanged += new EventHandler(AsignaturaCambiadaDo);
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

                    if (((CheckBox)sender).Name == "chbxAsig" + asig.IdAsignatura)
                    {
                        asignaturaSolicitudesClaseDoAceptadas.Add(asig);
                    }

                }
            }
            else
            {

                foreach (Logica.AsignaturaSolicitudClaseDo soliAsi in asignaturaSolicitudesClaseDo)
                {
                    if (((CheckBox)sender).Name == "chbxAsig" + soliAsi.IdAsignatura)
                    {
                        asignaturaSolicitudesClaseDoAceptadas.Remove(soliAsi);
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
            asignaturaSolicitudesClaseDoAceptadas = new List<Logica.AsignaturaSolicitudClaseDo>();
            asignaturaSolicitudesClaseAlAceptadas = new List<Logica.AsignaturaSolicitudClaseAl>();
            soliAl = new Logica.SolicitudClaseAl();
            soliDo = new Logica.SolicitudClaseDo();
            soliMo = new Logica.SolicitudModif();
            soliMo = new Logica.SolicitudModif().SelectSolicitudModifPorId(new Logica.SolicitudClaseDo().StringAId(((Label)sender).Name));
            Logica.Usuario us = new Logica.Usuario().SelectUsuarioCi(soliMo.Usuario);
            lblNombreApellidoSolicitud.Text = us.Nombre + " " + us.Primer_apellido + " ha perdido\n el acceso a su cuenta";
            lblCedula.Text = us.Ci;

            Label lblSolIngre = new Label();
            lblSolIngre.Height = 46;
            lblSolIngre.Width = 150;
            lblSolIngre.Location = new Point(25, 10);
            lblSolIngre.Name = "lblSolMo";
            lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.";
            panelContenido.Controls.Add(lblSolIngre);
            
        }
        private void tmrSolicitudes_Tick(object sender, EventArgs e)
        {
            CargarSolicitudes();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (soliAl.IdSolicitudClaseAl != 0)
            {
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAcep in asignaturaSolicitudesClaseAlAceptadas)
                {
                    Logica.Cursa cursa = new Logica.Cursa(asigSoliAcep.IdClaseAsig, soliAl.Alumno, asigSoliAcep.OriClaseAsig, DateTime.Now.Year);
                    cursa.InsertCursa();
                    Logica.AsignaturaCursa asigCursa = new Logica.AsignaturaCursa(soliAl.Alumno,asigSoliAcep.IdClaseAsig, asigSoliAcep.OriClaseAsig, DateTime.Now.Year, asigSoliAcep.IdAsignatura, true);
                    asigCursa.InsertAsignaturaCursa();
                    asigSoliAcep.AceptarAsignaturaSolicitudClaseAlPorIdSolicitudYIdAsig(asigSoliAcep.IdSolicitudClaseAl, asigSoliAcep.IdAsignatura);
                }
                soliAl.AceptarSolicitudClaseAlPorIdYAdmin(soliAl.IdSolicitudClaseAl, Login.encontrado.Ci);
            }
            asignaturaSolicitudesClaseAlAceptadas.Clear();
            asignaturaSolicitudesClaseAl.Clear();
            claseSolicitudesClaseAl.Clear();
            soliAl = new Logica.SolicitudClaseAl();

            if (soliDo.IdSolicitudClaseDo != 0)
            {
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoliAcep in asignaturaSolicitudesClaseDoAceptadas)
                {
                    Logica.Dicta dicta = new Logica.Dicta(asigSoliAcep.IdClaseAsig, soliDo.Docente, asigSoliAcep.OriClaseAsig, DateTime.Now.Year);
                    dicta.InsertDicta();
                    Logica.AsignaturaDictada asigDictada = new Logica.AsignaturaDictada(soliDo.Docente, asigSoliAcep.IdClaseAsig, asigSoliAcep.OriClaseAsig, DateTime.Now.Year, asigSoliAcep.IdAsignatura, true);
                    asigDictada.InsertAsignaturaDictada();
                    asigSoliAcep.AceptarAsignaturaSolicitudClaseDoPorIdSolicitudYIdAsig(asigSoliAcep.IdSolicitudClaseDo, asigSoliAcep.IdAsignatura);
                }
                soliDo.AceptarSolicitudClaseDoPorIdYAdmin(soliDo.IdSolicitudClaseDo, Login.encontrado.Ci);
            }
            
            asignaturaSolicitudesClaseDoAceptadas.Clear();
            asignaturaSolicitudesClaseDo.Clear();
            claseSolicitudesClaseDo.Clear();
            soliDo = new Logica.SolicitudClaseDo();

            if (soliMo.IdSolicitudModif != 0)
            {
                soliMo.AceptarSolicitudModifPorSoliYAdmin(Login.encontrado.Ci, true);
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
            asignaturaSolicitudesClaseAlAceptadas.Clear();
            asignaturaSolicitudesClaseAl.Clear();
            claseSolicitudesClaseAl.Clear();
            soliAl = new Logica.SolicitudClaseAl();

            if (soliDo.IdSolicitudClaseDo != 0)
            {
                soliDo.AceptarSolicitudClaseDoPorIdYAdmin(soliDo.IdSolicitudClaseDo, Login.encontrado.Ci);
            }

            asignaturaSolicitudesClaseDoAceptadas.Clear();
            asignaturaSolicitudesClaseDo.Clear();
            claseSolicitudesClaseDo.Clear();
            soliDo = new Logica.SolicitudClaseDo();

            if (soliMo.IdSolicitudModif != 0)
            {
                soliMo.AceptarSolicitudModifPorSoliYAdmin(Login.encontrado.Ci, true);
            }
            soliMo = new Logica.SolicitudModif();

            panelSolicitud.Visible = false;
        }
    }


}
