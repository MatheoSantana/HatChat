using System;
using System.Drawing;
using System.Windows.Forms;
namespace Hatchat.Presentacion
{
    public partial class RegisterDocente : Form
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
        public Form registerClasesDocente;
        public Logica.Docente doc = new Logica.Docente();
        
        public RegisterDocente()
        {
            InitializeComponent();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Register Docente";
            if (Login.idioma == "Español")
            {
                lblTitulo.Text = "Crea tu cuenta de Docente";
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
                real = "La cedula debe ser real";
                nombreNumerico = "El nombre no puede tener numeros";
                apellidoNumerico = "El primer apellido no puede tener numeros";
                sApellidoNumerico = "El segundo apellido no peude tener numeros";
                grandes = "Los datos no pueden tener un tamaño mayor a 30 caracteres";


            }
            else
            {
                lblTitulo.Text = "Create your Teacher account";
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
                pbxVolver.Image = Image.FromFile("volver.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + error, "Error");

            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            pbxVolver.Image = Image.FromFile("volver.png");
            pbxVolver.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            cbxPreguntas.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cbxPreguntas.Items.Add(preg.Pregunta);
            }
            cbxPreguntas.SelectedIndex = 0;


            txtPassword.UseSystemPasswordChar=true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            btnSiguiente.BackColor = Color.FromArgb(242, 144, 97);
            btnSiguiente.FlatStyle = FlatStyle.Flat;
            btnSiguiente.FlatAppearance.BorderSize = 0;

        }

        private void RegisterDocente_Load(object sender, EventArgs e)
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
            bool errorn = false;
            bool errora = false;
            bool errore = false;
            for (int x = 0; x < txtNombre.Text.Length; x++)
            {

                if (txtNombre.Text[x].ToString() == "1" || txtNombre.Text[x].ToString() == "2" || txtNombre.Text[x].ToString() == "3" || txtNombre.Text[x].ToString() == "4" || txtNombre.Text[x].ToString() == "5" || txtNombre.Text[x].ToString() == "6" || txtNombre.Text[x].ToString() == "7" || txtNombre.Text[x].ToString() == "8" || txtNombre.Text[x].ToString() == "9" || txtNombre.Text[x].ToString() == "0")
                {
                    errorn = true;
                }

            }
            if (errorn)
            {
                error += "\n" + nombreNumerico;
                aceptable = false;
            }
            for (int x = 0; x < txtPrimerApellido.Text.Length; x++)
            {

                if (txtPrimerApellido.Text[x].ToString() == "1" || txtPrimerApellido.Text[x].ToString() == "2" || txtPrimerApellido.Text[x].ToString() == "3" || txtPrimerApellido.Text[x].ToString() == "4" || txtPrimerApellido.Text[x].ToString() == "5" || txtPrimerApellido.Text[x].ToString() == "6" || txtPrimerApellido.Text[x].ToString() == "7" || txtPrimerApellido.Text[x].ToString() == "8" || txtPrimerApellido.Text[x].ToString() == "9" || txtPrimerApellido.Text[x].ToString() == "0")
                {
                    errora = true;
                }

            }
            if (errora)
            {
                error += "\n" + apellidoNumerico;
                aceptable = false;
            }
            for (int x = 0; x < txtSegundoApellido.Text.Length; x++)
            {

                if (txtSegundoApellido.Text[x].ToString() == "1" || txtSegundoApellido.Text[x].ToString() == "2" || txtSegundoApellido.Text[x].ToString() == "3" || txtSegundoApellido.Text[x].ToString() == "4" || txtSegundoApellido.Text[x].ToString() == "5" || txtSegundoApellido.Text[x].ToString() == "6" || txtSegundoApellido.Text[x].ToString() == "7" || txtSegundoApellido.Text[x].ToString() == "8" || txtSegundoApellido.Text[x].ToString() == "9" || txtSegundoApellido.Text[x].ToString() == "0")
                {
                    errore = true;
                }

            }
            if (errore)
            {
                error += "\n" + sApellidoNumerico;
                aceptable = false;
            }
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuesta.Text == "" || cbxPreguntas.SelectedIndex == -1)
            {

                aceptable = false;
                error += "\n" + rellenar;
            }
            else
            {
                if (!doc.VerficarCedula(txtCedula.Text))
                {
                    aceptable = false;
                    error += "\n" + real;
                }
            }
            if (txtNombre.Text.Length > 31 || txtPrimerApellido.Text.Length > 31 || txtSegundoApellido.Text.Length > 31 || txtPassword.Text.Length > 31 || txtConfirmarPassword.Text.Length > 31 || txtRespuesta.Text.Length > 31)
            {
                aceptable = false;
                error += "\n" + grandes;
            }

            

            if (txtPassword.Text.Length < 8)
            {
                aceptable = false;
                error += "\n" + corta;
            }
            if (txtConfirmarPassword.Text != txtPassword.Text)
            {
                aceptable = false;
                error += "\n" + distintas;
            }


            if (new Logica.Usuario().ExisteUsuarioCi(txtCedula.Text))
            {
                aceptable = false;
                error += "\n\n" + existe;
            }
            if (!aceptable)
            {
                MessageBox.Show(error);
            }
            else
            {
                doc.Ci = txtCedula.Text;
                doc.Nombre = txtNombre.Text;
                doc.Primer_apellido = txtPrimerApellido.Text;
                doc.Segundo_apellido = txtSegundoApellido.Text;
                doc.Password = txtPassword.Text;
                doc.Preguta_seguridad = (cbxPreguntas.SelectedIndex+1);
                doc.Respuesta_seguridad = txtRespuesta.Text;
                RegisterClasesDocente registerClasesDocente = new RegisterClasesDocente();
                this.registerClasesDocente = registerClasesDocente;
                registerClasesDocente.registerDocente = this;
                registerClasesDocente.login = login;
                registerClasesDocente.Docente = doc;
                registerClasesDocente.Show();
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
