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
            try
            {
                Icon = new Icon(Application.StartupPath + "//logo imagen.ico");
                pictureBox1.Image = Image.FromFile("Logo Completa.png");
                pbxLogin.Image = Image.FromFile("volver.png");

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " comuníquese con el administrador.", "Error");

            }
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1280, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pbxLogin.SizeMode = PictureBoxSizeMode.StretchImage;

            lblTitulo.Text = "Crea tu cuenta de alumno";

            cbxPreguntas.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Logica.PreguntaSeg preg in new Logica.PreguntaSeg().SelectPreguntasSeguridad())
            {
                cbxPreguntas.Items.Add(preg.Pregunta);
            }
            cbxPreguntas.SelectedIndex = 0;


            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            btnSiguiente.BackColor = Color.FromArgb(242, 144, 97);
            btnSiguiente.FlatStyle = FlatStyle.Flat;
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

            string error = "Cuidado: ";
            bool aceptable = true;

            if (txtCedula.Text == "" || txtNombre.Text == "" || txtPrimerApellido.Text == "" || txtSegundoApellido.Text == "" || txtPassword.Text == "" || txtConfirmarPassword.Text == "" || txtRespuesta.Text == "")
            {
                aceptable = false;
                error += "\nDebe rellenar todos los campos";
            }
            if (!alu.VerficarCedula(txtCedula.Text))
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


            if (new Logica.Usuario().ExisteUsuarioCi(txtCedula.Text))
            {
                aceptable = false;
                error += "\n\nAdvertencia: esa cedula ya esta ingresada";
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
