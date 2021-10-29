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
        List<Logica.AsignaturaSolicitudClaseDo>asignaturaSolicitudesClaseDo = new List<Logica.AsignaturaSolicitudClaseDo>();
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
                                        if (filtrar && soliDo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliDo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliDo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                        {
                                            solicitudesDesordenadas.Add(soliDo);
                                        }
                                        else if (!filtrar)
                                        {
                                            solicitudesDesordenadas.Add(soliDo);
                                        }
                                    }
                                    else if (!solicitudesDesordenadas.Contains(soliAl))
                                    {
                                        if (filtrar && soliDo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliDo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliDo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                        {
                                            solicitudesDesordenadas.Add(soliAl);
                                        }
                                        else if (!filtrar)
                                        {
                                            solicitudesDesordenadas.Add(soliAl);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (filtrar && soliDo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliDo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliDo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                            {
                                solicitudesDesordenadas.Add(soliAl);
                            }
                            else if (!filtrar)
                            {
                                solicitudesDesordenadas.Add(soliAl);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Logica.SolicitudClaseDo soli in solicitudesClaseDo)
                    {
                        if (filtrar && soli.FechaHora.Year == dtpFiltroFecha.Value.Year && soli.FechaHora.Month == dtpFiltroFecha.Value.Month && soli.FechaHora.Day == dtpFiltroFecha.Value.Day)
                        {
                            solicitudesDesordenadas.Add(soli);
                        }
                        else if (!filtrar)
                        {
                            solicitudesDesordenadas.Add(soli);
                        }
                    }
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
                                    if (filtrar && soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesOrdenadas.Add(soliMo);
                                    }
                                    else if (!filtrar)
                                    {
                                        solicitudesOrdenadas.Add(soliMo);
                                    }

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
                                    if (filtrar && soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                                    {
                                        solicitudesOrdenadas.Add(soliMo);
                                    }
                                    else if (!filtrar)
                                    {
                                        solicitudesOrdenadas.Add(soliMo);
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (Logica.SolicitudModif soliMo in solicitudesModif)
                {
                    if (!solicitudesOrdenadas.Contains(soliMo))
                    {
                        if (filtrar && soliMo.FechaHora.Year == dtpFiltroFecha.Value.Year && soliMo.FechaHora.Month == dtpFiltroFecha.Value.Month && soliMo.FechaHora.Day == dtpFiltroFecha.Value.Day)
                        {
                            solicitudesOrdenadas.Add(soliMo);
                        }
                        else if (!filtrar)
                        {
                            solicitudesOrdenadas.Add(soliMo);
                        }
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
                        if(this.solicitudesOrdenadas[x].GetType().Name == "SolicitudClaseAl")
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
                y = 5;
                PanelSolicitudesResueltas.Controls.Clear();

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
                        PanelSolicitudesResueltas.Controls.Add(dina);
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
                        PanelSolicitudesResueltas.Controls.Add(dina);
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
                        PanelSolicitudesResueltas.Controls.Add(dina);
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
            asignaturaSolicitudesClaseAl.AddRange(new Logica.AsignaturaSolicitudClaseAl().SelectAsignaturaSolicitudClaseAl(soliAl.IdSolicitudClaseAl));
            int xlblAsig = 5, ylblAsig = 100, xlblClase=5;
            foreach (Logica.ClaseSolicitudClaseAl claseSoli in claseSolicitudesClaseAl)
            {
                Label lblClase = new Label();
                lblClase.Height = 46;
                lblClase.Width = 150;
                lblClase.Location = new Point(xlblClase, 50);
                lblClase.Name = "lblClase"+claseSoli.IdClase;
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblClase.Text =  clas.Anio+"°"+clas.Nombre+"\n"+new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                xlblClase += 160;
                foreach (Logica.AsignaturaSolicitudClaseAl asigSoliAl in asignaturaSolicitudesClaseAl)
                {
                    if (claseSoli.IdClase == asigSoliAl.IdClaseAsig)
                    {
                        Label dina = new Label();
                        dina.Height = 46;
                        dina.Width = 150;
                        dina.Location = new Point(xlblAsig, ylblAsig);
                        ylblAsig += 25;
                        dina.Name = "lblAsig" + asigSoliAl.IdAsignatura + "Cl" + asigSoliAl.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliAl.IdAsignatura).Nombre +" (Denegada)";
                        if (asigSoliAl.Aceptada)
                        {
                            dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliAl.IdAsignatura).Nombre + " (Aceptada)";
                        }
                        panelContenido.Controls.Add(dina);
                    }
                }
                ylblAsig = 100;
                xlblAsig += 160;
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

            int xlblAsig = 5, ylblAsig = 100, xlblClase = 5;
            asignaturaSolicitudesClaseDo.AddRange(new Logica.AsignaturaSolicitudClaseDo().SelectAsignaturaSolicitudClaseDo(soliDo.IdSolicitudClaseDo));
            foreach (Logica.ClaseSolicitudClaseDo claseSoli in claseSolicitudesClaseDo)
            {
                Label lblClase = new Label();
                lblClase.Height = 46;
                lblClase.Width = 150;
                lblClase.Location = new Point(xlblClase, 55);
                lblClase.Name = "lblClase" + claseSoli.IdClase;
                Logica.Clase clas = new Logica.Clase().SelectClasePorId(claseSoli.IdClase);
                lblClase.Text = clas.Anio + "°" + clas.Nombre + "\n" + new Logica.Orientacion().SelectOrientacioPorId(claseSoli.OriClase).Nombre;
                panelContenido.Controls.Add(lblClase);
                
                xlblClase += 160;
                foreach (Logica.AsignaturaSolicitudClaseDo asigSoliDo in asignaturaSolicitudesClaseDo)
                {
                    if (asigSoliDo.IdClaseAsig == claseSoli.IdClase)
                    {
                        Label dina = new Label();
                        dina.Height = 46;
                        dina.Width = 150;
                        dina.Location = new Point(xlblAsig, ylblAsig);
                        ylblAsig += 25;
                        dina.Name = "lblAsig" + asigSoliDo.IdAsignatura+"Cl"+asigSoliDo.IdClaseAsig;
                        dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre + " (Denegada)";
                        if (asigSoliDo.Aceptada)
                        {
                            dina.Text = new Logica.Asignatura().SelectAsignaturaPorId(asigSoliDo.IdAsignatura).Nombre + " (Aceptada)";
                        }
                        panelContenido.Controls.Add(dina);
                    }
                }
                ylblAsig = 100;
                xlblAsig += 160;
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
            lblSolIngre.Height = 69;
            lblSolIngre.Width = 250;
            lblSolIngre.Location = new Point(25, 50);
            lblSolIngre.Name = "lblSolMo";
            lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.\nSe ha negado la solicitud";
            if (soliMo.Aceptada)
            {
                lblSolIngre.Text = us.Primer_apellido + " ha enviado una soliciutd para\nreestablecer su contraseña.\nSu preguntas de seguridad concuerda.\nSe ha aceptado la solicitud";
            }
            panelContenido.Controls.Add(lblSolIngre);
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
            
        }
    }


}
