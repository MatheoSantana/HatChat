using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class PerfilAlumno : Form
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
        public Form principalChatAlumno;
        public Form mensajesAlumno;
        public Form gruposAlumno;
        public Form historialChatsAlumno;
        public Form historialMensajesAlumno;
        private bool enHistorial = false, enPanel = false, enHistorialChat, enHistorialMensaje = false;
        public PerfilAlumno()
        {
            InitializeComponent();
            Text = "Perfil";

            ClientSize = new Size(1280, 720);

            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Login.idioma == "Español")
            {
                lblPerfil.Text = "Perfil";
                lblNombre.Text = "Nombre: ";
                lblCedula.Text = "Cedula: ";
                lblEstudiante.Text = "Estudiante";
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
                cuidado= "Cuidado:" ;
                rellenar = "Debe rellenar todos los campos ";
                corta = "La contraseña es demasiado corta ";
                distintas= "Las contraseñas no son iguales";
                msgModificar = "¿Desea modificar su perfil?";
                titModificar = "Modificar perfil";
                modificado = "Se han modificado sus datos";
                msgBorrar = "¿Desea borrar su perfil?";
                titBorrar= "Borrar Perfil";
                borrado = "Usuario eliminado, cerrando sesion";


            }
            else
            {
                lblPerfil.Text = "Profile";
                lblNombre.Text = "Name: ";
                lblCedula.Text = "ID: ";
                lblEstudiante.Text = "Student";
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

            cbxPregs.SelectedIndex = (Login.encontrado.SelectPreguntaSeguridad().Id-1);
            txtRespuesta.Text = Login.encontrado.Respuesta_seguridad;

        }

        private void PerfilAlumno_Load(object sender, EventArgs e)
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

        private void pbxMensajeNav_Click(object sender, EventArgs e)
        {
            mensajesAlumno.Show();
            this.Hide();
        }
        private void pbxGruposNav_Click(object sender, EventArgs e)
        {
            gruposAlumno.Show();
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
            historialMensajesAlumno.Show();
            this.Hide();
        }
        private void pcbxHistorialChatNav_Click(object sender, EventArgs e)
        {
            historialChatsAlumno.Show();
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
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
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
                DialogResult modificarCuenta = MessageBox.Show(msgModificar, titModificar, MessageBoxButtons.YesNo);
                if (modificarCuenta == DialogResult.Yes)
                {
                    Login.encontrado.Apodo = txtApodo.Text;
                    Login.encontrado.Password = txtPassword.Text;
                    Login.encontrado.Respuesta_seguridad = txtRespuesta.Text;
                    Login.encontrado.Preguta_seguridad = (cbxPregs.SelectedIndex + 1);
                    Login.encontrado.FotoDePerfil = Login.encontrado.ImageToByteArray(pbxFoto.Image);
                    Login.encontrado.UpdatePerfil();
                    MessageBox.Show(modificado);

                    pbxFoto.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                    pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtApodo.Text = Login.encontrado.Apodo;
                    txtPassword.Text = Login.encontrado.Password;
                    txtPasswordCon.Text = Login.encontrado.Password;
                    pbxFotoPerfilNav.Image = Login.encontrado.ByteArrayToImage(Login.encontrado.FotoDePerfil);
                    cbxPregs.SelectedIndex = (Login.encontrado.SelectPreguntaSeguridad().Id - 1);
                    txtRespuesta.Text = Login.encontrado.Respuesta_seguridad;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult borrarCuenta = MessageBox.Show(msgBorrar, titBorrar, MessageBoxButtons.YesNo);
            if (borrarCuenta == DialogResult.Yes)
            {
                Login.encontrado.Activo = false;
                Login.encontrado.RemoveUsuario();
                Login.encontrado = new Logica.Usuario();
                MessageBox.Show(borrado);
                login.Show();
                this.Dispose();
            }
        }
        
    }
}
