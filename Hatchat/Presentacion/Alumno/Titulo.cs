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
    public partial class Titulo : Form
    {
        public Form principalChatAlumno;
        bool cerrar;
        public Titulo(bool cerrar)
        {
            InitializeComponent();
            this.cerrar = cerrar;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            PrincipalChatAlumno.abierto.Titulo = txtTema.Text;
            PrincipalChatAlumno.abierto.CambiarTitulo();
            if (cerrar)
            {
                PrincipalChatAlumno.abierto.CerrarChat();
                PrincipalChatAlumno.abierto = new Logica.Chat();
            }
            principalChatAlumno.Enabled = true;
            this.Dispose();
            
        }
    }
}
