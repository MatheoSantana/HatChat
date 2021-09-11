using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class MensajesAlumno : Form
    {
        private List<Logica.Docente> docentes = new List<Logica.Docente>();
        public Form login;
        public Form perfilAlumno;
        public Form principalChatAlumno;
        int y = 50;
        public MensajesAlumno()
        {
            InitializeComponent();
            Text = "Mensajes";

            
            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            panelContenedor.Visible = false;
            panelEnviarMensaje.Visible = false;
            //nav
            pbxFotoPerfilNav.Image = Login.encontrado.FotoDePerfil;
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje blanco.png");
                pbxPerfilNav.Image = Image.FromFile("perfil gris.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }

            pbxFotoPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMensajeNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxGruposNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHistorialNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDocente.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxAlumno.SizeMode = PictureBoxSizeMode.StretchImage;


            cbxDestinatario.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.Cursa cur in Login.cursan)
            {
                foreach (Logica.Dicta dic in Login.dictan)
                {
                    if (cur.CiAlumno == Login.encontrado.Ci && cur.IdClase == dic.IdClase &&  == cur.Asignatura && !docentes.Contains(dic.Docente))
                    {
                        docentes.Add(dic.Docente);
                        cbxDestinatario.Items.Add(dic.Docente.Nombre + " " + dic.Docente.Primer_apellido);

                    }
                }
            }

            CargarMensajes();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Login.mensajes.Add(new Logica.Mensaje(((Logica.Alumno)Login.encontrado), txtAsunto.Text, DateTime.Now, rtbxMensajeAEnviar.Text, docentes[cbxDestinatario.SelectedIndex], "Realizado"));
                MessageBox.Show("Se ha enviado el mensaje correctamente");
                txtAsunto.Text = "";
                rtbxMensajeAEnviar.Text = "";
                cbxDestinatario.Items.Clear();
                docentes.Clear();
                CargarMensajes();
                panelEnviarMensaje.Visible = false;
            }catch(System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Debe ingresar un destinatario");
            }
        }

        private void AbrirMensaje(object sender, EventArgs e)
        {
            panelContenedor.Visible = false;
            panelEnviarMensaje.Visible = false;
            panelContenedor.Visible = true;
            pbxDocente.Image = null;
            pbxAlumno.Image = null;
            lblNombreDocente.Text = "Docente:";
            lblFechaAlumno.Text = "Fecha:";
            lblHoraAlumno.Text = "Hora:";
            lblConsultaAlumno.Text = "Consulta:";
            lblConsultaDocente.Text = "Consulta:";
            lblNombreAlumno.Text = "Alumno:";
            rtbxMensajeEnviado.Text = "";

            lblFechaDocente.Text = "Fecha:";
            lblHoraDocente.Text = "Hora:";
            rtbxRespuestaDocecnte.Text = "";
            foreach (Logica.Mensaje men in Login.mensajes)
            {
                if (men.Alumno == Login.encontrado && ("lbl" + men.FechaHoraAlumno.ToString()) == ((Label)sender).Name && ((Label)sender).Text == men.Docente.Nombre + " " + men.Docente.Primer_apellido + "\n" + men.Asunto)
                {
                    panelContenedor.Visible = true;
                    lblNombreDocente.Text += ("\n" + men.Docente.Nombre + " " + men.Docente.Primer_apellido);
                    lblFechaAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("dd:MM:yyyy");
                    lblHoraAlumno.Text += "\n" + men.FechaHoraAlumno.ToString("HH:mm");
                    lblConsultaAlumno.Text += "\n" + men.Asunto;
                    lblConsultaDocente.Text += "\n" + men.Asunto;
                    lblNombreAlumno.Text += "\n" + men.Alumno.Nombre + " " + men.Alumno.Primer_apellido;
                    rtbxMensajeEnviado.Text = men.MensajeAlumno;
                    pbxAlumno.Image = men.Alumno.FotoDePerfil;
                    pbxDocente.Image = men.Docente.FotoDePerfil;
                    foreach (Logica.Contesta cont in Login.contestan)
                    {
                        if (men.Docente == cont.Docente && cont.Alumno == men.Alumno && cont.FechaHoraAlumno==men.FechaHoraAlumno)
                        {
                            lblFechaDocente.Text += "\n" + cont.FechaHoraDocente.ToString("dd:MM:yyyy");
                            lblHoraDocente.Text += "\n" + cont.FechaHoraDocente.ToString("HH:mm");
                            rtbxRespuestaDocecnte.Text = cont.MensajeDocente;
                            
                        }
                    }



                }
            }
        }
        private void MensajesAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);

        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxChatNav_Click(object sender, EventArgs e)
        {
            principalChatAlumno.Show();
            this.Hide();
        }

        private void pbxPerfilNav_Click(object sender, EventArgs e)
        {
            perfilAlumno.Show();
            this.Hide();
        }

        private void pbxCerrarSesionNav_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show("¿Desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Login.encontrado = null;
                login.Show();
                this.Dispose();
            }
        }

        private void CargarMensajes()
        {

            y = 50;
            panelNavMensajes.Controls.Clear();
            panelEnviarMensaje.Visible = false;
            panelContenedor.Visible = false;
            foreach (Logica.Mensaje men in Login.mensajes)
            {
                if (men.Alumno == Login.encontrado)
                {

                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(50, y);
                    y += 50;
                    dina.Name = "lbl" + men.FechaHoraAlumno.ToString();
                    dina.Text = men.Docente.Nombre + " " + men.Docente.Primer_apellido + "\n" + men.Asunto;

                    dina.Click += new EventHandler(AbrirMensaje);
                    panelNavMensajes.Controls.Add(dina);


                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtAsunto.Text = "";
            rtbxMensajeAEnviar.Text = "";
            cbxDestinatario.Items.Clear();
            docentes.Clear();
            CargarMensajes();
            panelEnviarMensaje.Visible = false;
        }

        private void btnNuevoChat_Click(object sender, EventArgs e)
        {
            foreach (Logica.Cursa cur in Login.cursan)
            {
                foreach (Logica.Dicta dic in Login.dictan)
                {
                    if (cur.Alumno == Login.encontrado && cur.Clase == dic.Clase && dic.Asignatura == cur.Asignatura && !docentes.Contains(dic.Docente))
                    {
                        docentes.Add(dic.Docente);
                        cbxDestinatario.Items.Add(dic.Docente.Nombre + " " + dic.Docente.Primer_apellido);

                    }
                }
            }
            panelEnviarMensaje.Visible = true;
        }
    }
}
