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
    public partial class Login : Form
    {
        static Register register;
        static CambiarContra cambiarContra;

        static PrincipalChatDocente principalChatDocente;
        static MensajesDocente mensajesDocente;
        static PerfilDocente perfilDocente;
        static GruposDocente gruposDocente;
        static HistorialChatsDocente historialChatsDocente;
        static HistorialMensajesDocente historialMensajesDocente;

        static RegisterDocente registerDocente;
        

        static PrincipalChatAlumno principalChatAlumno;
        static MensajesAlumno mensajesAlumno;
        static PerfilAlumno perfilAlumno;
        static GruposAlumno gruposAlumno;
        static RegisterAlumno registerAlumno;
        static HistorialMensajesAlumno historialMensajesAlumno;
        static HistorialChatsAlumno historialChatsAlumno;


        static PrincipalSolicitudesAdmin principalSolicitudesAdmin;
        static ABMAlumnoAdmin abmAlumnoAdmin;
        static ABMDocenteAdmin abmDocenteAdmin;
        static ABMGruposAdmin abmGruposAdmin;
        static HistorialSolicitudesAdmin historialSolicitudesAdmin;


        string usuarioNoEncontrado;
        string contraseñaIncorrecta;
        string soloNumeros;

        public static Logica.Usuario encontrado = new Logica.Usuario();

        
        Image fotoIngles;
        Image fotoEspanol;
        public static string idioma="Español";
        string error = " comuníquese con el administrador.";
        public Login()
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Text = "Login";
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                fotoEspanol = Image.FromFile("español chiquito.png");
                fotoIngles = Image.FromFile("ingles chiquito.png");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            txtPassword.UseSystemPasswordChar = true;
            //inicializamos los controles
            //bloqueamos la edicion del combo box idioma
            cmbxIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            

            //agregamos los idiomas
            cmbxIdioma.Items.Add("Español");
            cmbxIdioma.Items.Add("English");

            //seteamos en español el idioma del combo box
            cmbxIdioma.SelectedIndex = 0;

            idioma = cmbxIdioma.SelectedItem.ToString();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cbxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxIdioma.SelectedItem.ToString() == "Español")
            {
                idioma = "Español";
                idioma = cmbxIdioma.SelectedItem.ToString();
                lblTitulo.Text = "Inicio de sesion";
                lblTitulo.Location = new Point(162, 18);
                lblCedula.Text = "Cédula de identidad";
                lblPassword.Text = "Contraseña";
                pcbxIdioma.Image = fotoEspanol;
                btnIniciarSesion.Text = "Iniciar\nSesion";
                lblCambioPassword.Text = "No recuerdo mi contraseña";
                lblCambioPassword.Location = new Point(300, 341);
                lblTextoSinCuenta.Text = "¿No tienes una cuenta?";
                lblRegistrarse.Text = "Registrate";
                lblRegistrarse.Location = new Point(178, 341);
                usuarioNoEncontrado = "Usuario no existente";
                contraseñaIncorrecta = "Contraseña incorrecta";
                lblExplicacion.Text = "Introduzca su cedula de identidad y contraseña";
                lblExplicacion.Location = new Point(156, 98);
                soloNumeros = "La cedula debe tener solo numeros";
                error = " comuníquese con el administrador.";
            }
            else
            {
                idioma = "English";
                idioma = cmbxIdioma.SelectedItem.ToString();
                lblTitulo.Text = "Login";
                lblTitulo.Location = new Point(262, 18);
                lblCedula.Text = "Identity card";
                lblPassword.Text = "Password";
                pcbxIdioma.Image = fotoIngles;
                btnIniciarSesion.Text = "Login";
                lblCambioPassword.Text = "I don't remember my password";
                lblCambioPassword.Location = new Point(290, 341);
                lblTextoSinCuenta.Text = "You don't have an account?";
                lblRegistrarse.Text = "Sign up";
                lblRegistrarse.Location = new Point(194, 341);
                usuarioNoEncontrado = "Non-existent user";
                contraseñaIncorrecta = "Incorrect password";
                lblExplicacion.Text = "Enter your identity card and password";
                lblExplicacion.Location = new Point(196, 98);
                error = " Contact the administrator.";
                soloNumeros = "The ID must have only numbers";
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbxIdioma_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtCedula.Text);
                encontrado = encontrado.SelectUsuarioCiActivo(txtCedula.Text);

                if (encontrado.Ci != null)
                {
                    if (encontrado.Password == txtPassword.Text)
                    {
                        if (encontrado.SelectDocente())
                        {
                            txtCedula.Text = "";
                            txtPassword.Text = "";
                            principalChatDocente = new PrincipalChatDocente();
                            mensajesDocente = new MensajesDocente();
                            perfilDocente = new PerfilDocente();
                            gruposDocente = new GruposDocente();
                            historialChatsDocente = new HistorialChatsDocente();
                            historialMensajesDocente = new HistorialMensajesDocente();

                            principalChatDocente.Show();
                            this.Hide();

                            principalChatDocente.login = this;
                            principalChatDocente.mensajesDocente = mensajesDocente;
                            principalChatDocente.perfilDocente = perfilDocente;
                            principalChatDocente.gruposDocente = gruposDocente;
                            principalChatDocente.historialChatsDocente = historialChatsDocente;
                            principalChatDocente.historialMensajesDocente = historialMensajesDocente;

                            mensajesDocente.login = this;
                            mensajesDocente.principalChatDocente = principalChatDocente;
                            mensajesDocente.perfilDocente = perfilDocente;
                            mensajesDocente.gruposDocente = gruposDocente;
                            mensajesDocente.historialChatsDocente = historialChatsDocente;
                            mensajesDocente.historialMensajesDocente = historialMensajesDocente;

                            perfilDocente.login = this;
                            perfilDocente.principalChatDocente = principalChatDocente;
                            perfilDocente.mensajesDocente = mensajesDocente;
                            perfilDocente.gruposDocente = gruposDocente;
                            perfilDocente.historialChatsDocente = historialChatsDocente;
                            perfilDocente.historialMensajesDocente = historialMensajesDocente;

                            gruposDocente.login = this;
                            gruposDocente.principalChatDocente = principalChatDocente;
                            gruposDocente.mensajesDocente = mensajesDocente;
                            gruposDocente.perfilDocente = perfilDocente;
                            gruposDocente.historialChatsDocente = historialChatsDocente;
                            gruposDocente.historialMensajesDocente = historialMensajesDocente;

                            historialChatsDocente.login = this;
                            historialChatsDocente.principalChatsDocente = principalChatDocente;
                            historialChatsDocente.mensajesDocente = mensajesDocente;
                            historialChatsDocente.perfilDocente = perfilDocente;
                            historialChatsDocente.gruposDocente = gruposDocente;
                            historialChatsDocente.historialMensajesDocente = historialMensajesDocente;



                            historialMensajesDocente.login = this;
                            historialMensajesDocente.principalChatDocente = principalChatDocente;
                            historialMensajesDocente.mensajesDocente = mensajesDocente;
                            historialMensajesDocente.perfilDocente = perfilDocente;
                            historialMensajesDocente.gruposDocente = gruposDocente;
                            historialMensajesDocente.historialChatsDocente = historialChatsDocente;


                        }
                        else if (encontrado.SelectAlumno())
                        {
                            txtCedula.Text = "";
                            txtPassword.Text = "";
                            principalChatAlumno = new PrincipalChatAlumno();
                            mensajesAlumno = new MensajesAlumno();
                            perfilAlumno = new PerfilAlumno();
                            gruposAlumno = new GruposAlumno();
                            historialMensajesAlumno = new HistorialMensajesAlumno();
                            historialChatsAlumno = new HistorialChatsAlumno();


                            principalChatAlumno.Show();
                            this.Hide();

                            principalChatAlumno.login = this;
                            principalChatAlumno.mensajesAlumno = mensajesAlumno;
                            principalChatAlumno.perfilAlumno = perfilAlumno;
                            principalChatAlumno.gruposAlumno = gruposAlumno;
                            principalChatAlumno.historialMensajesAlumno = historialMensajesAlumno;
                            principalChatAlumno.historialChatsAlumno = historialChatsAlumno;

                            mensajesAlumno.login = this;
                            mensajesAlumno.principalChatAlumno = principalChatAlumno;
                            mensajesAlumno.perfilAlumno = perfilAlumno;
                            mensajesAlumno.historialMensajesAlumno = historialMensajesAlumno;
                            mensajesAlumno.gruposAlumno = gruposAlumno;
                            mensajesAlumno.historialChatsAlumno = historialChatsAlumno;

                            perfilAlumno.login = this;
                            perfilAlumno.principalChatAlumno = principalChatAlumno;
                            perfilAlumno.mensajesAlumno = mensajesAlumno;
                            perfilAlumno.historialMensajesAlumno = historialMensajesAlumno;
                            perfilAlumno.gruposAlumno = gruposAlumno;
                            perfilAlumno.historialChatsAlumno = historialChatsAlumno;

                            historialMensajesAlumno.login = this;
                            historialMensajesAlumno.principalChatAlumno = principalChatAlumno;
                            historialMensajesAlumno.mensajesAlumno = mensajesAlumno;
                            historialMensajesAlumno.perfilAlumno = perfilAlumno;
                            historialMensajesAlumno.gruposAlumno = gruposAlumno;
                            historialMensajesAlumno.historialchatsAlumno = historialChatsAlumno;

                            gruposAlumno.login = this;
                            gruposAlumno.principalChatAlumno = principalChatAlumno;
                            gruposAlumno.mensajesAlumno = mensajesAlumno;
                            gruposAlumno.perfilAlumno = perfilAlumno;
                            gruposAlumno.historialMensajesAlumno = historialMensajesAlumno;
                            gruposAlumno.historialChatsAlumno = historialChatsAlumno;

                            historialChatsAlumno.login = this;
                            historialChatsAlumno.principalChatsAlumno = principalChatAlumno;
                            historialChatsAlumno.mensajesAlumno = mensajesAlumno;
                            historialChatsAlumno.perfilAlumno = perfilAlumno;
                            historialChatsAlumno.gruposAlumno = gruposAlumno;
                            historialChatsAlumno.historialMensajesAlumno = historialMensajesAlumno;

                        }
                        else if (encontrado.SelectAdministrador())
                        {
                            txtCedula.Text = "";
                            txtPassword.Text = "";
                            principalSolicitudesAdmin = new PrincipalSolicitudesAdmin();
                            abmAlumnoAdmin = new ABMAlumnoAdmin();
                            abmDocenteAdmin = new ABMDocenteAdmin();
                            abmGruposAdmin = new ABMGruposAdmin();
                            historialSolicitudesAdmin = new HistorialSolicitudesAdmin();

                            principalSolicitudesAdmin.login = this;
                            principalSolicitudesAdmin.abmAlumnoAdmin = abmAlumnoAdmin;
                            principalSolicitudesAdmin.abmDocenteAdmin = abmDocenteAdmin;
                            principalSolicitudesAdmin.abmGruposAdmin = abmGruposAdmin;
                            principalSolicitudesAdmin.historialSolicitudesAdmin = historialSolicitudesAdmin;

                            abmAlumnoAdmin.login = this;
                            abmAlumnoAdmin.principalSolicitudesAdmin = principalSolicitudesAdmin;
                            abmAlumnoAdmin.abmDocenteAdmin = abmDocenteAdmin;
                            abmAlumnoAdmin.abmGruposAdmin = abmGruposAdmin;
                            abmAlumnoAdmin.historialSolicitudesAdmin = historialSolicitudesAdmin;

                            abmDocenteAdmin.login = this;
                            abmDocenteAdmin.principalSolicitudesAdmin = principalSolicitudesAdmin;
                            abmDocenteAdmin.abmDAlumnoAdmin = abmAlumnoAdmin;
                            abmDocenteAdmin.abmGruposAdmin = abmGruposAdmin;
                            abmDocenteAdmin.historialSolicitudesAdmin = historialSolicitudesAdmin;

                            abmGruposAdmin.login = this;
                            abmGruposAdmin.principalSolicitudesAdmin = principalSolicitudesAdmin;
                            abmGruposAdmin.abmDAlumnoAdmin = abmAlumnoAdmin;
                            abmGruposAdmin.abmDocenteAdmin = abmDocenteAdmin;
                            abmGruposAdmin.historialSolicitudesAdmin = historialSolicitudesAdmin;

                            historialSolicitudesAdmin.login = this;
                            historialSolicitudesAdmin.principalSolicitudesAdmin = principalSolicitudesAdmin;
                            historialSolicitudesAdmin.abmAlumnoAdmin = abmAlumnoAdmin;
                            historialSolicitudesAdmin.abmDocenteAdmin = abmDocenteAdmin;
                            historialSolicitudesAdmin.abmGruposAdmin = abmGruposAdmin;





                            principalSolicitudesAdmin.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show(contraseñaIncorrecta);
                    }

                }
                else
                {
                    MessageBox.Show(usuarioNoEncontrado);
                }
            }
            catch
            {
                MessageBox.Show(soloNumeros);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRegistrarse_Click(object sender, EventArgs e)
        {
            register = new Register();
            registerDocente = new RegisterDocente();
            registerAlumno = new RegisterAlumno();

            register.Show();
            this.Hide();

            register.login = this;
            register.registerDocente = registerDocente;
            register.registerAlumno = registerAlumno;

            registerDocente.login = this;
            registerDocente.register = register;
            registerAlumno.login = this;
            registerAlumno.register = register;

        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void lblCambioPassword_Click(object sender, EventArgs e)
        {
            cambiarContra = new CambiarContra();
            cambiarContra.Show();
            this.Hide();
            cambiarContra.login = this;
        }
    }
}
