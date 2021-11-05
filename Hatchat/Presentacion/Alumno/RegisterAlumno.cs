using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hatchat.Presentacion
{
    public partial class RegisterAlumno : Form
    {
        string error;
        string cuidado;
        string corta;
        string distintas;
        string rellenar;
        string existe;
        string real;
        string nombreNumerico;
        string apellidoNumerico;
        string sApellidoNumerico;
        string grandes;


        public Form login;
        public Form register;
        public Form registerClasesAlumno;
        public Logica.Alumno alu = new Logica.Alumno();
        public RegisterAlumno()
        {
            InitializeComponent();
            Text = "Register Alumno";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            if (Login.idioma == "Español")
            {
                lblTitulo.Text = "Crea tu cuenta de Alumno";
                lblRellene.Text = "Rellene las casillas con su informacion:";
                lblNombre.Text = "Nombre: ";
                lblCedula.Text = "Cedula: ";
                lblPrimerApellido.Text = "Primer Apellido: ";
                lblSegundoApellido.Text = "Segundo Apellido: ";
                lblPassword.Text = "Contraseña: ";
                lblConfirmarPassword.Text = "Confirmar Contraseña: ";
                lblPreguntas.Text = "Pregunta de Seguridad: ";
                lblExplicacion.Text = "Rellene la casilla de texto con una respuesta que nunca \nolvide, para poder tomar medidas en caso de perdida de\nla cuenta";
                error = " comuníquese con el administrador.";
                btnSiguiente.Text = "Siguiente";
                cbxPreguntas.Items.Add("¿Cuál es el nombre de tu primer mascota?");
                cbxPreguntas.Items.Add("¿En qué calle está ubicado tu primer hogar?");
                cbxPreguntas.Items.Add("¿Cual es tu sabor de helado favorito?");
                cuidado = "Cuidado:";
                rellenar = "Debe rellenar todos los campos ";
                corta = "La contraseña es demasiado corta ";
                distintas = "Las contraseñas no son iguales";
                existe = "Esa cedula ya esta ingresada";
                real= "La cedula debe ser real";
                nombreNumerico="El nombre no puede tener numeros";
                apellidoNumerico="El primer apellido no puede tener numeros";
                sApellidoNumerico="El segundo apellido no peude tener numeros";
                grandes = "Los datos no pueden tener un tamaño mayor a 30 caracteres";

            }
            else
            {

                nombreNumerico = "The name cannot have numbers";
                apellidoNumerico = "The first surname cannot have numbers";
                sApellidoNumerico = "The second surname cannot have numbers";
                lblTitulo.Text = "Create your Student account";
                lblRellene.Text = "fill in the boxes with your information:";
                lblNombre.Text = "Name: ";
                lblCedula.Text = "ID: ";
                lblPrimerApellido.Text = "Surname: ";
                lblSegundoApellido.Text = "Second surname: ";
                lblPassword.Text = "Password: ";
                lblConfirmarPassword.Text = "Confirm Password: ";
                lblPreguntas.Text = "Security Question: ";
                lblExplicacion.Text = "Fill in the textbox an answer that you never forget,\nso that you can take actions in the event of account loss";
                error = "  Contact an administrator.";
                cbxPreguntas.Items.Add("What is the name of your first pet?");
                cbxPreguntas.Items.Add("On what street is your first home located?");
                cbxPreguntas.Items.Add("What is your favorite ice cream flavor?");
                cuidado = "Warning:";
                rellenar = "You must complete all the data ";
                corta = "the password is too short ";
                distintas = "Passwords do not match";
                existe = "That ID is already entered";
                real = "The ID must be real";
                nombreNumerico = "The name cannot have numbers";
                apellidoNumerico = "The first surname cannot have numbers";
                sApellidoNumerico = "The second surname cannot have numbers";
                grandes = "Data cannot be larger than 30 characters";
            }

            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                pbxLogin.Image = Image.FromFile("volver.png");

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pbxLogin.SizeMode = PictureBoxSizeMode.StretchImage;

            cbxPreguntas.DropDownStyle = ComboBoxStyle.DropDownList;
            
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            btnSiguiente.BackColor = Color.FromArgb(242, 144, 97);
            btnSiguiente.FlatStyle = FlatStyle.Popup;
            btnSiguiente.FlatAppearance.BorderSize = 0;
        }

        private void RegisterAlumno_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }


        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            string error = cuidado;
            bool aceptable = true;
            
            
            if (alu.NumerosEnStrings(txtNombre.Text))
            {
                error += "\n" + nombreNumerico;
                aceptable = false;
            }
            
            if (alu.NumerosEnStrings(txtPrimerApellido.Text))
            {
                error += "\n" + apellidoNumerico;
                aceptable = false;
            }
            
            if (alu.NumerosEnStrings(txtSegundoApellido.Text))
            {
                error += "\n" + sApellidoNumerico;
                aceptable = false;
            }
            if (alu.campoVacio(txtCedula.Text) || alu.campoVacio(txtNombre.Text) || alu.campoVacio(txtPrimerApellido.Text) || alu.campoVacio(txtSegundoApellido.Text) || alu.campoVacio(txtPassword.Text) || alu.campoVacio(txtConfirmarPassword.Text) || alu.campoVacio(txtRespuesta.Text)  || alu.sinPregunta(cbxPreguntas.SelectedIndex))
            {
                aceptable = false;
                error += "\n"+rellenar;
            }
                if (!alu.VerficarCedula(txtCedula.Text))
                {
                    aceptable = false;
                    error += "\n" + real;
                }
            if (alu.TamañoIncorrecto(txtNombre.Text) || alu.TamañoIncorrecto(txtPrimerApellido.Text) || alu.TamañoIncorrecto(txtSegundoApellido.Text) || alu.TamañoIncorrecto(txtPassword.Text) || alu.TamañoIncorrecto(txtConfirmarPassword.Text) || alu.TamañoIncorrecto(txtRespuesta.Text))
            {
                aceptable = false;
                error += "\n" + grandes;
            }

            if (alu.TamañoMinimoContra(txtPassword.Text))
            {
                aceptable = false;
                error += "\n"+corta;
            }
            if (!(txtConfirmarPassword.Text == txtPassword.Text))
            {
                aceptable = false;
                error += "\n"+distintas;
            }

            if (alu.ExisteUsuarioCi(txtCedula.Text))
            {
                aceptable = false;
                error += "\n\n"+existe;
            }


            if (!aceptable)
            {
                MessageBox.Show(error);
            }
            else
            {
                alu.Ci = txtCedula.Text;
                alu.Nombre = txtNombre.Text;
                alu.Primer_apellido = txtPrimerApellido.Text;
                alu.Segundo_apellido = txtSegundoApellido.Text;
                alu.Password = txtPassword.Text;
                alu.Preguta_seguridad = (cbxPreguntas.SelectedIndex+1);
                alu.Respuesta_seguridad = txtRespuesta.Text;
                RegisterClasesAlumno registerClasesAlumno = new RegisterClasesAlumno();
                this.registerClasesAlumno = registerClasesAlumno;
                registerClasesAlumno.registerAlumno = this;
                registerClasesAlumno.login = login;
                registerClasesAlumno.Alumno = alu;
                registerClasesAlumno.Show();
                this.Hide();
            }
        }

        private void pbxVolver_Click(object sender, EventArgs e)
        {
            register.Show();
            this.Hide();
        }

        private void timerCentrar_Tick(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
