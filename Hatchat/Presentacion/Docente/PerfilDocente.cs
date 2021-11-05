using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class PerfilDocente : Form
    {
        string error;
        string msgCerrarSesion;
        string cerrarSesionTitulo;
        string seleccionaImagen;
        string cuidado;
        string corta;
        string distintas;
        string modificado;
        string msgBorrar;
        string msgModificar;
        string rellenar;
        string titBorrar;
        string titModificar;
        string borrado;

        public Form login;
        public Form mensajesDocente;
        public Form principalChatDocente;
        public Form gruposDocente;
        public Form historialChatsDocente;
        public Form historialMensajesDocente;

        List<Logica.Agenda> agendas = new List<Logica.Agenda>();

        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;
        bool lu = false, ma = false, mi = false, ju = false, vi = false;

        public PerfilDocente()
        {
            InitializeComponent();

            Text = "Perfil";

            ClientSize = new Size(1280, 720);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            StartPosition = FormStartPosition.CenterScreen;
            if (Login.idioma == "Español")
            {
                lblPerfil.Text = "Perfil";
                lblNombre.Text = "Nombre: ";
                lblCedula.Text = "Cedula: ";
                lblDocente.Text = "Docente";
                lblApodo.Text = "Apodo: ";
                lblPassword.Text = "Contraseña: ";
                lblPasswordCon.Text = "Confirmar Contraseña: ";
                lblPregs.Text = "Pregunta de Seguridad: ";
                lblRespuesta.Text = "Respuesta: ";
                error = " comuníquese con el administrador.";
                msgCerrarSesion = "¿Desea cerrar sesion?";
                cerrarSesionTitulo = "Cerrar Sesion";
                btnEliminar.Text = "Eliminar Cuenta";
                btnModificar.Text = "Modificar";
                cbxPregs.Items.Add("¿Cuál es el nombre de tu primer mascota?");
                cbxPregs.Items.Add("¿En qué calle está ubicado tu primer hogar?");
                cbxPregs.Items.Add("¿Cual es tu sabor de helado favorito?");
                lblCambiarFoto.Text = "Cambiar foto de perfil";
                lblInformacion.Text = "Mi Informacion";
                seleccionaImagen = "Seleccionar imagen";
                cuidado = "Cuidado:";
                rellenar = "Debe rellenar todos los campos ";
                corta = "La contraseña es demasiado corta ";
                distintas = "Las contraseñas no son iguales";
                msgModificar = "¿Desea modificar su perfil?";
                titModificar = "Modificar perfil";
                modificado = "Se han modificado sus datos";
                msgBorrar = "¿Desea borrar su perfil?";
                titBorrar = "Borrar Perfil";
                borrado = "Usuario eliminado, cerrando sesion";


            }
            else
            {
                lblPerfil.Text = "Profile";
                lblNombre.Text = "Name: ";
                lblCedula.Text = "ID: ";
                lblDocente.Text = "Teacher";
                lblApodo.Text = "NickName: ";
                lblPassword.Text = "password: ";
                lblPasswordCon.Text = "confirm Password: ";
                lblPregs.Text = "Security Question: ";
                lblRespuesta.Text = "Answer: ";
                btnEliminar.Text = "Delete Account";
                btnModificar.Text = "Modify";
                lblCambiarFoto.Text = "Change profile picture";
                lblInformacion.Text = "My Information";
                error = "  Contact an administrator.";
                msgCerrarSesion = "Do you want to log out?";
                cerrarSesionTitulo = "Logout";
                cbxPregs.Items.Add("What is the name of your first pet?");
                cbxPregs.Items.Add("On what street is your first home located?");
                cbxPregs.Items.Add("What is your favorite ice cream flavor?");
                seleccionaImagen = "Select image";
                cuidado = "Warning:";
                rellenar = "You must complete all the data ";
                corta = "the password is too short ";
                distintas = "Passwords do not match";
                msgModificar = "Do you want to modify your profile?";
                titModificar = "Modify profile";
                modificado = "Your data has been modified";
                msgBorrar = "Do you want to delete your profile?";
                titBorrar = "Delete profile";
                borrado = "User deleted, session closed";
            }
            try
            {

                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                pbxChatNav.Image = Image.FromFile("chat gris.png");
                pbxMensajeNav.Image = Image.FromFile("mensaje gris.png");
                pbxPerfilNav.Image = Image.FromFile("perfil blanco.png");
                pbxGruposNav.Image = Image.FromFile("grupos gris.png");
                pbxHistorialNav.Image = Image.FromFile("historial gris.png");
                pcbxHistorialChatNav.Image = Image.FromFile("historial chat gris.png");
                pcbxHistorialMensajesNav.Image = Image.FromFile("historial mensaje gris.png");
                pbxCerrarSesionNav.Image = Image.FromFile("cerrar sesion.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

            }

            pbxFotoPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMensajeNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxPerfilNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxGruposNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHistorialNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialChatNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxHistorialMensajesNav.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrarSesionNav.SizeMode = PictureBoxSizeMode.StretchImage;

            txtPassword.UseSystemPasswordChar = true;

            lblNombre.Text += Login.encontrado.Nombre + " " + Login.encontrado.Primer_apellido + " " + Login.encontrado.Segundo_apellido;
            lblCedula.Text += Login.encontrado.Ci;
            pbxFoto.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            txtApodo.Text = Login.encontrado.Apodo;
            txtPassword.Text = Login.encontrado.Password;
            txtPasswordCon.Text = Login.encontrado.Password;
            cbxPregs.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxHoraInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxHoraCierre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxMinutoCierre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxMinutoInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int x = 0; x < 24; x++)
            {
                cmbxHoraInicio.Items.Add(x);
                cmbxHoraCierre.Items.Add(x);
            }
            for (int x = 0; x < 60; x=x+5)
            {
                cmbxMinutoCierre.Items.Add(x);
                cmbxMinutoInicio.Items.Add(x);
            }

            cbxPregs.SelectedIndex = (Login.encontrado.SelectPreguntaSeguridad().Id - 1);
            txtRespuesta.Text = Login.encontrado.Respuesta_seguridad;

        }

        private void PerfilDocente_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void pbxChatNav_Click(object sender, EventArgs e)
        {
            principalChatDocente.Show();
            this.Hide();
        }

        private void pbxMensajeNav_Click(object sender, EventArgs e)
        {
            mensajesDocente.Show();
            this.Hide();
        }
        private void pbxGruposNav_Click(object sender, EventArgs e)
        {
            gruposDocente.Show();
            this.Hide();
        }
        private void pbxHistorialNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorial = true;
            panelHistorialesNav.Visible = true;
        }
        private void panelHistorialesNav_MouseEnter(object sender, EventArgs e)
        {
            enPanel = true;
        }
        private void pcbxHistorialChatNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorialChat = true;
        }
        private void pcbxHistorialMensajesNav_MouseEnter(object sender, EventArgs e)
        {
            enHistorialMensaje = true;
        }
        private void pbxHistorialNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorial = false;
        }

        private void panelHistorialesNav_MouseLeave(object sender, EventArgs e)
        {
            enPanel = false;
        }
        private void pcbxHistorialChatNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorialChat = false;
        }
        private void pcbxHistorialMensajesNav_MouseLeave(object sender, EventArgs e)
        {
            enHistorialMensaje = false;
        }

        private void pcbxHistorialMensajesNav_Click(object sender, EventArgs e)
        {
            historialMensajesDocente.Show();
            this.Hide();
        }
        private void pcbxHistorialChatNav_Click(object sender, EventArgs e)
        {
            historialChatsDocente.Show();
            this.Hide();
        }
        private void timerHistorialNav_Tick(object sender, EventArgs e)
        {
            if (!enPanel && !enHistorial && !enHistorialChat && !enHistorialMensaje)
            {
                panelHistorialesNav.Visible = false;
            }
        }
        private void pbxCerrarSesionNav_Click(object sender, EventArgs e)
        {
            DialogResult cerrarSesion = MessageBox.Show(msgCerrarSesion, cerrarSesionTitulo, MessageBoxButtons.YesNo);
            if (cerrarSesion == DialogResult.Yes)
            {
                Login.encontrado = new Logica.Usuario();
                login.Show();
                this.Dispose();
            }
        }
        private void timerCargarFoto_Tick(object sender, EventArgs e)
        {
            pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
            agendas = new Logica.Agenda().SelectAgendasPorCi(Login.encontrado.Ci);
        }


        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFoto = new OpenFileDialog();
            ofdFoto.Filter = "Imagenes|*.jpeg;*.jpg;*.png";
            ofdFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdFoto.Title = seleccionaImagen;
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFoto.Image = Image.FromFile(ofdFoto.FileName);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string error = cuidado;
            bool aceptable = true;

            if (txtPassword.Text == "" || txtPasswordCon.Text == "" || txtRespuesta.Text == "" || txtApodo.Text == "")
            {
                aceptable = false;
                error += "\n"+rellenar;
            }

            if (txtPassword.Text.Length < 8)
            {
                aceptable = false;
                error += "\n"+corta;
            }
            if (txtPasswordCon.Text != txtPassword.Text)
            {
                aceptable = false;
                error += "\n"+distintas;
            }

            if (!aceptable)
            {
                MessageBox.Show(error);
            }
            else
            {
                DialogResult modificarCuenta = MessageBox.Show("¿Desea modificar su perfil?", "Modificar perfil", MessageBoxButtons.YesNo);
                if (modificarCuenta == DialogResult.Yes)
                {
                    Login.encontrado.Apodo = txtApodo.Text;
                    Login.encontrado.Password = txtPassword.Text;
                    Login.encontrado.Respuesta_seguridad = txtRespuesta.Text;
                    Login.encontrado.Preguta_seguridad = (cbxPregs.SelectedIndex + 1);
                    Login.encontrado.FotoDePerfil = Login.encontrado.ImageToByteArray(pbxFoto.Image);
                    Login.encontrado.UpdatePerfil();
                    MessageBox.Show("Se han modificado sus datos");

                    pbxFoto.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                    pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtApodo.Text = Login.encontrado.Apodo;
                    txtPassword.Text = Login.encontrado.Password;
                    txtPasswordCon.Text = Login.encontrado.Password;
                    pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                    foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
                    {
                        cbxPregs.Items.Add(preg.Pregunta);
                    }
                    cbxPregs.SelectedIndex = (Login.encontrado.SelectPreguntaSeguridad().Id - 1);
                    txtRespuesta.Text = Login.encontrado.Respuesta_seguridad;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult borrarCuenta = MessageBox.Show("¿Desea borrar su perfil?", "Borrar perfil", MessageBoxButtons.YesNo);
            if (borrarCuenta == DialogResult.Yes)
            {
                Login.encontrado.Activo = false;
                Login.encontrado.RemoveUsuario();
                Login.encontrado = new Logica.Usuario();
                login.Show();
                this.Dispose();
            }
        }
        private void btnLunes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(239, 136, 88);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Lunes");
        }


        private void btnMartes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(239, 136, 88);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Martes");
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(239, 136, 88);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Miercoles");
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(239, 136, 88);
            btnViernes.BackColor = Color.FromArgb(61, 53, 50);
            RecargarAgendaDelDia("Jueves");
        }



        private void btnViernes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            btnMartes.BackColor = Color.FromArgb(61, 53, 50);
            btnMiercoles.BackColor = Color.FromArgb(61, 53, 50);
            btnJueves.BackColor = Color.FromArgb(61, 53, 50);
            btnViernes.BackColor = Color.FromArgb(239, 136, 88);
            RecargarAgendaDelDia("Viernes");
        }



        private void RecargarAgendaDelDia(string dia)
        {
            int ypanel = 0;
            panelHorariosPorDia.Controls.Clear();
            foreach (Logica.Agenda agenda in agendas)
            {
                if (agenda.NomDia == dia)
                {

                    Label linea = new Label();
                    linea.Height = 18;
                    linea.Width = 180;
                    linea.Location = new Point(0, 2);
                    linea.Font = new Font("Arial", 12, FontStyle.Bold);
                    linea.ForeColor = Color.White;
                    linea.Name = "lblLineaAgendaDelDia" + agenda.IdAgenda.ToString();
                    linea.Text = "_______________________________________________";

                    Label horario = new Label();
                    horario.Height = 18;
                    horario.Width = 150;
                    horario.Location = new Point(10, 0);
                    horario.Font = new Font("Arial", 12.0f);
                    horario.ForeColor = Color.White;
                    horario.Name = "lblAgendaDelDia" + agenda.IdAgenda.ToString();
                    horario.Text = agenda.HoraInicio + " - " + agenda.HoraFin;

                    PictureBox cruz = new PictureBox();
                    cruz.Height = 20;
                    cruz.Width = 20;
                    cruz.Location = new Point(160, 0);
                    cruz.Image = Image.FromFile("Cruz.png");
                    cruz.ForeColor = Color.White;
                    cruz.Name = "pcbxCruz" + agenda.IdAgenda.ToString();
                    cruz.SizeMode = PictureBoxSizeMode.StretchImage;
                    cruz.Click += new EventHandler(EliminarAgenda);

                    Panel panel = new Panel();
                    panel.Height = 20;
                    panel.Width = 288;
                    panel.Location = new Point(0, ypanel);
                    ypanel += 20;
                    panel.Name = "pnl" + agenda.IdAgenda.ToString();
                    panel.BackColor = Color.FromArgb(61, 53, 50);

                    panel.Controls.Add(horario);
                    panel.Controls.Add(cruz);
                    panel.Controls.Add(linea);

                    panelHorariosPorDia.Controls.Add(panel);

                }
            }

        }
        private void EliminarAgenda(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Label)sender).Name));
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((PictureBox)sender).Name));
            }
            else
            {
                new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Panel)sender).Name));
            }

            
            MessageBox.Show("Se ha eliminado la agenda");
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        private void btnLun_Click(object sender, EventArgs e)
        {
            lu = !lu;
            if (lu)
            {
                btnLu.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnLunes.BackColor = Color.FromArgb(61, 53, 50);
            }
        }


        private void btnMa_Click(object sender, EventArgs e)
        {
            ma = !ma;
            if (ma)
            {
                btnMa.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnMa.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnMi_Click(object sender, EventArgs e)
        {
            mi = !mi;
            if (mi)
            {
                btnMi.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnMi.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnJu_Click(object sender, EventArgs e)
        {
            ju = !ju;
            if (ju)
            {
                btnJu.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnJu.BackColor = Color.FromArgb(61, 53, 50);
            }
        }
        private void btnVi_Click(object sender, EventArgs e)
        {
            vi = !vi;
            if (vi)
            {
                btnVi.BackColor = Color.FromArgb(239, 136, 88);
            }
            else
            {
                btnVi.BackColor = Color.FromArgb(61, 53, 50);
            }
        }


        private void btnNuevaAgenda_Click(object sender, EventArgs e)
        {
            panelAgregarAgenda.Visible = true;
            panel1.Enabled = false;
            panelAgenda.Enabled = false;
            panelPerfil.Enabled = false;
        }
        private void btnCerrarInformacion_Click(object sender, EventArgs e)
        {
            panelAgregarAgenda.Visible = false;
            panel1.Enabled = true;
            panelAgenda.Enabled = true;
            panelPerfil.Enabled = true;

        }
        private void btnAgregarNuevaAgenda_Click(object sender, EventArgs e)
        {
            if (!lu && !ma && !mi && !ju && !vi)
            {
                MessageBox.Show("No se ha seleccionado ningun dia");
            }
            else
            {
                if (lu)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Lunes";
                    agenda.AgregarAgenda();
                    lu = false;
                    btnLu.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (ma)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Martes";
                    agenda.AgregarAgenda();
                    ma = false;
                    btnMa.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (mi)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Miercoles";
                    agenda.AgregarAgenda();
                    mi = false;
                    btnMi.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (ju)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Jueves";
                    agenda.AgregarAgenda();
                    ju = false;
                    btnJu.BackColor = Color.FromArgb(61, 53, 50);
                }
                if (vi)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Viernes";
                    agenda.AgregarAgenda();
                    vi = false;
                    btnVi.BackColor = Color.FromArgb(61, 53, 50);
                }
                MessageBox.Show("Se ha agendado correctamente");
                panelAgregarAgenda.Visible = false;
                panel1.Enabled = true;
                panelAgenda.Enabled = true;
                panelPerfil.Enabled = true;
            }
        }

    }
}
