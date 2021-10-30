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
        public Form login;
        public Form mensajesDocente;
        public Form principalChatDocente;
        public Form gruposDocente;
        public Form historialChatsDocente;
        public Form historialMensajesDocente;

        List<Logica.Agenda> agendas = new List<Logica.Agenda>();

        bool enHistorial = false, enPanel = false, enHistorialChat = false, enHistorialMensaje = false;

        public PerfilDocente()
        {
            InitializeComponent();

            Text = "Perfil";
            
            ClientSize = new Size(1280, 720);

            lblCambiarFoto.ForeColor = Color.Blue;
            lblCambiarFoto.Font = new Font("Arial", 9.0f, FontStyle.Underline);

            StartPosition = FormStartPosition.CenterScreen;
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
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

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

            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cbxPregs.Items.Add(preg.Pregunta);
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
            DialogResult cerrarSesion = MessageBox.Show("¿Desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);
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
            panelDiasYHorarios.Visible = true;
            agendas = new Logica.Agenda().SelectAgendasPorCi(Login.encontrado.Ci);
        }


        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFoto = new OpenFileDialog();
            ofdFoto.Filter = "Imagenes|*.jpeg;*.jpg;*.png";
            ofdFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdFoto.Title = "Seleccionar imagen";
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFoto.Image = Image.FromFile(ofdFoto.FileName);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string error = "Cuidado: ";
            bool aceptable = true;

            if (txtPassword.Text == "" || txtPasswordCon.Text == "" || txtRespuesta.Text == "" || txtApodo.Text == "")
            {
                aceptable = false;
                error += "\nDebe rellenar todos los campos";
            }

            if (txtPassword.Text.Length < 8)
            {
                aceptable = false;
                error += "\nLa contraseña es demaciado corta";
            }
            if (txtPasswordCon.Text != txtPassword.Text)
            {
                aceptable = false;
                error += "\nLas contraseñas no son iguales";
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
            btnLunes.BackColor = Color.Orange;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Lunes");
        }


        private void btnMartes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = Color.Orange;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Martes");
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = Color.Orange;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Miercoles");
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = Color.Orange;
            btnViernes.BackColor = SystemColors.Control;
            RecargarAgendaDelDia("Jueves");
        }

        

        private void btnViernes_Click(object sender, EventArgs e)
        {
            btnLunes.BackColor = SystemColors.Control;
            btnMartes.BackColor = SystemColors.Control;
            btnMiercoles.BackColor = SystemColors.Control;
            btnJueves.BackColor = SystemColors.Control;
            btnViernes.BackColor = Color.Orange;
            RecargarAgendaDelDia("Viernes");
        }

        

        private void RecargarAgendaDelDia(string dia)
        {
            int y = 5;
            panelHorariosPorDia.Controls.Clear();
            foreach (Logica.Agenda agenda in agendas)
            {
                if (agenda.NomDia == dia)
                {
                    Label dina = new Label();
                    dina.Height = 46;
                    dina.Width = 150;
                    dina.Location = new Point(25, y);
                    y += 50;
                    dina.Name = "lblAdendaDelDia" + agenda.IdAgenda.ToString();
                    dina.Text = agenda.HoraInicio + " - " + agenda.HoraFin + " (click para eliminar)";
                    dina.BorderStyle = BorderStyle.FixedSingle;
                    dina.Click += new EventHandler(EliminarAgenda);
                    panelHorariosPorDia.Controls.Add(dina);
                }
            }

        }
        private void EliminarAgenda(object sender, EventArgs e)
        {
            new Logica.Agenda().EliminarAgendaPorId(new Logica.Agenda().StringAId(((Label)sender).Name));
            MessageBox.Show("Se ha eliminado la agenda");
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
            if (!chbxLunes.Checked && !chbxMartes.Checked && !chbxMiercoles.Checked && !chbxJueves.Checked && !chbxViernes.Checked)
            {
                MessageBox.Show("No se ha seleccionado ningun dia");
            }
            else
            {
                if (chbxLunes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Lunes";
                    agenda.AgregarAgenda();
                }
                if (chbxMartes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Martes";
                    agenda.AgregarAgenda();
                }
                if (chbxMiercoles.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Miercoles";
                    agenda.AgregarAgenda();
                }
                if (chbxJueves.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Jueves";
                    agenda.AgregarAgenda();
                }
                if (chbxViernes.Checked)
                {
                    Logica.Agenda agenda = new Logica.Agenda();
                    agenda.Ci = Login.encontrado.Ci;
                    agenda.HoraInicio = cmbxHoraInicio.SelectedItem.ToString() + ":" + cmbxMinutoInicio.SelectedItem.ToString() + ":00";
                    agenda.HoraFin = cmbxHoraCierre.SelectedItem.ToString() + ":" + cmbxMinutoCierre.SelectedItem.ToString() + ":00";
                    agenda.NomDia = "Viernes";
                    agenda.AgregarAgenda();
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
