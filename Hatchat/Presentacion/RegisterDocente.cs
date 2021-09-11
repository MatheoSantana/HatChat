using System;
using System.Drawing;
using System.Windows.Forms;
namespace Hatchat.Presentacion
{
    public partial class RegisterDocente : Form
    {
        public Form login;
        public Form register;
        public Form registerClasesDocente;
        public Logica.Docente doc = new Logica.Docente();
        
        public RegisterDocente()
        {
            InitializeComponent();

            Text = "Register Docente";
            try
            {
                Icon = new Icon(Application.StartupPath + "/logo imagen.ico");
                pbxVolver.Image = Image.FromFile("volver.png");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);

            pbxVolver.Image = Image.FromFile("volver.png");
            pbxVolver.SizeMode = PictureBoxSizeMode.StretchImage;

            lblTitulo.Text = "Crea tu cuenta de docente";

            cbxPreguntas.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in Login.pregs)
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

            string error = "Cuidado: ";
            bool aceptable = true;

            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuesta.Text == "")
            {
                aceptable = false;
                error += "\nDebe rellenar todos los campos";
            }
            if (!doc.VerficarCedula(txtCedula.Text))
            {
                aceptable = false;
                error += "\nLa cedula debe ser real";
            }
            if (txtPassword.Text.Length < 8)
            {
                aceptable = false;
                error += "\nLa contraseña es demaciado corta";
            }
            if (txtConfirmarPassword.Text != txtPassword.Text)
            {
                aceptable = false;
                error += "\nLas contraseñas no son iguales";
            }
            foreach (Logica.Usuario us in Login.usuarios)
            {
                if (us.Ci.ToString() == txtCedula.Text)
                {
                    aceptable = false;
                    error += "\n\nAdvertencia: esa cedula ya esta ingresada";
                }

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
                doc.Preguta_seguridad = Login.pregs[cbxPreguntas.SelectedIndex];
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

    }
}
