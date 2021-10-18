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

        static PrincipalChatDocente principalChatDocente;
        static MensajesDocente mensajesDocente;
        static PerfilDocente perfilDocente;
        static RegisterDocente registerDocente;

        static PrincipalChatAlumno principalChatAlumno;
        static MensajesAlumno mensajesAlumno;
        static PerfilAlumno perfilAlumno;
        static RegisterAlumno registerAlumno;

        static PrincipalSolicitudesAdmin PrincipalSolicitudesAdmin;

        string usuarioNoEncontrado;
        string contraseñaIncorrecta;

        public static Logica.Usuario encontrado = new Logica.Usuario();

        public static string idioma;
        Font fuenteLink = new Font("Arial", 9.0f, FontStyle.Underline);
        Image fotoIngles;
        Image fotoEspanol;
        public Login()
        {
            InitializeComponent();

            Text = "Login";
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                fotoEspanol = Image.FromFile("español chiquito.png");
                fotoIngles = Image.FromFile("ingles chiquito.png");
            }
            catch(System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");
                
            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            txtPassword.UseSystemPasswordChar = true;
            //inicializamos los controles
            //bloqueamos la edicion del combo box idioma
            cmbxIdioma.DropDownStyle = ComboBoxStyle.DropDownList;

            //agregamos los idiomas
            cmbxIdioma.Items.Add("Español");
            cmbxIdioma.Items.Add("English");

            //seteamos en español el idioma del combo box
            cmbxIdioma.SelectedIndex = 0;

            lblTitulo.Text = "Inicio de sesion";
            idioma = cmbxIdioma.SelectedItem.ToString();
            lblCambioPassword.Visible = false;
            cmbxIdioma.Visible = false;
            pcbxIdioma.Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cbxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxIdioma.SelectedItem.ToString() == "Español")
            {
                idioma = cmbxIdioma.SelectedItem.ToString();
                lblTitulo.Text = "Inicio de sesion";
                lblCedula.Text = "Cédula de identidad";
                lblPassword.Text = "Contraseña";
                pcbxIdioma.Image = fotoEspanol;
                btnIniciarSesion.Text = "Iniciar\nSesion";
                lblCambioPassword.Text = "No recuerdo mi contraseña";
                lblTextoSinCuenta.Text = "¿No tienes una cuenta?";
                lblRegistrarse.Text = "Registrate";
                usuarioNoEncontrado = "Usuario no existente";
                contraseñaIncorrecta = "Contraseña incorrecta";
            }
            else
            {
                idioma = cmbxIdioma.SelectedItem.ToString();
                lblTitulo.Text = "Login";
                lblCedula.Text = "Identity card";
                lblPassword.Text = "Password";
                pcbxIdioma.Image = fotoIngles;
                btnIniciarSesion.Text = "Login";
                lblCambioPassword.Text = "I don't remember my password";
                lblTextoSinCuenta.Text = "You don't have an account?";
                lblRegistrarse.Text = "Sign up";
                usuarioNoEncontrado = "Non-existent user";
                contraseñaIncorrecta = "Incorrect password";
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

            encontrado = encontrado.SelectUsuarioCi(txtCedula.Text/*"52848682"*/);
            
            if (encontrado.Ci != "")
            {
                if (encontrado.Password == txtPassword.Text/*"matheo1234"*/)
                {
                    if (encontrado.SelectDocente())
                    {
                        txtCedula.Text = "";
                        txtPassword.Text = "";
                        principalChatDocente = new PrincipalChatDocente();
                        mensajesDocente = new MensajesDocente();
                        perfilDocente = new PerfilDocente();


                        principalChatDocente.Show();
                        this.Hide();

                        principalChatDocente.login = this;
                        principalChatDocente.mensajesDocente = mensajesDocente;
                        principalChatDocente.perfilDocente = perfilDocente;

                        mensajesDocente.login = this;
                        mensajesDocente.principalChatDocente = principalChatDocente;
                        mensajesDocente.perfilDocente = perfilDocente;

                        perfilDocente.login = this;
                        perfilDocente.principalChatDocente = principalChatDocente;
                        perfilDocente.mensajesDocente = mensajesDocente;



                    }
                    else if (encontrado.SelectAlumno())
                    {
                        txtCedula.Text = "";
                        txtPassword.Text = "";
                        principalChatAlumno = new PrincipalChatAlumno();
                        mensajesAlumno = new MensajesAlumno();
                        perfilAlumno = new PerfilAlumno();


                        principalChatAlumno.Show();
                        this.Hide();

                        principalChatAlumno.login = this;
                        principalChatAlumno.mensajesAlumno = mensajesAlumno;
                        principalChatAlumno.perfilAlumno = perfilAlumno;

                        mensajesAlumno.login = this;
                        mensajesAlumno.principalChatAlumno = principalChatAlumno;
                        mensajesAlumno.perfilAlumno = perfilAlumno;

                        perfilAlumno.login = this;
                        perfilAlumno.principalChatAlumno = principalChatAlumno;
                        perfilAlumno.mensajesAlumno = mensajesAlumno;
                    }
                    else if(encontrado.SelectAdministrador())
                    {
                        txtCedula.Text = "";
                        txtPassword.Text = "";
                        PrincipalSolicitudesAdmin principalSolicitudesAdmin = new PrincipalSolicitudesAdmin();
                        principalSolicitudesAdmin.login = this;
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


    }
}
