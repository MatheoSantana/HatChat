using System;
using System.Collections;
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
    public partial class PrincipalSolicitudesAdmin : Form
    {
        Form login;
        public PrincipalSolicitudesAdmin()
        {
            InitializeComponent();
        }

        private void pbxSolicitudesNav_Click(object sender, EventArgs e)
        {

        }

        private void pbxABMAlumnoNav_Click(object sender, EventArgs e)
        {

        }

        private void pbxABMDocenteNav_Click(object sender, EventArgs e)
        {

        }

        private void pbxABMGruposNav_Click(object sender, EventArgs e)
        {

        }

        private void pbxHistorialSolicitudesNav_Click(object sender, EventArgs e)
        {

        }

        private void pbxCerrarSesionNav_Click(object sender, EventArgs e)
        {

        }

        private void PrincipalSolicitudesAdmin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);
        }
        private void CerrarForm(object sender, EventArgs e)
        {
            login.Dispose();
        }
        private void CargarSolicitudes()
        {
            List<Logica.SolicitudClaseAl> solicitudesClaseAl = new Logica.SolicitudClaseAl().SelectSolicitudesClaseAl();
            List<Logica.SolicitudClaseDo> solicitudesClaseDo = new Logica.SolicitudClaseDo().SelectSolicitudesClaseDo();
            List<Logica.SolicitudModif> solicitudesModif = new Logica.SolicitudModif().SelectSolicitudesModif();
            ArrayList solicitudesDesordenadas = new ArrayList();
            int y;
            solicitudesDesordenadas.AddRange(solicitudesModif);
            solicitudesDesordenadas.AddRange(solicitudesClaseDo);
            solicitudesDesordenadas.AddRange(solicitudesClaseAl);

            /*
             * crear una nueva array de orden (fechahora, tipo de lista, idsol), en este se ingresan las 3 listas
             * 
             */

            ArrayList solicitudesOrdenadas = new ArrayList();
            foreach (Logica.SolicitudClaseAl soliAl in solicitudesClaseAl)
            {
                int solal = 0;
                foreach(Logica.SolicitudClaseDo soliDo in solicitudesClaseDo)
                {
                    int soldo = 0;
                    foreach(Logica.SolicitudModif soliMo in solicitudesModif)
                    {
                        if(soliMo.FechaHora< soliAl.FechaHora && soliMo.FechaHora < soliDo.FechaHora && !solicitudesOrdenadas.Contains(soliMo))
                        {

                        }
                    }
                }
            }

                if (mensajs.Count < mensajes.Count)
            {
                if ((mensajes.Count - mensajs.Count) > 1)
                {
                    mensajs = mensajes;
                }
                else
                {
                    mensajs.Add(mensajes[mensajs.Count]);
                }
                int xot = 20;
                y = 50;
                int m = 0;
                panelCharla.Controls.Clear();
                foreach (Logica.Chatea cha in mensajs)
                {

                    int xyo = -20;
                    int wyo = 0;
                    int lineas = 2;
                    int ret = (9 * cha.Contenido.Length);
                    if (cha.Contenido.Length > 48)
                    {
                        xyo += -(panelCharla.Size.Width / 3) + (panelCharla.Size.Width * 2 / 3);
                        lineas += cha.Contenido.Length / 48;
                        wyo = (panelCharla.Width * 2 / 3) - 20;
                    }
                    else
                    {

                        if (ret < panelCharla.Width / 6)
                        {
                            ret = panelCharla.Width / 6;
                        }
                        xyo += panelCharla.Width - ret - 20;
                        wyo += ret;
                    }

                    Label dina = new Label();
                    dina.Width = wyo;
                    dina.Height = 20;
                    dina.Location = new Point(xyo, y);
                    dina.ForeColor = Color.Black;
                    dina.BackColor = Color.White;
                    dina.Font = new Font("Arial", 12.0f);

                    if (!(cha.Ci == Login.encontrado.Ci))
                    {
                        dina.Location = new Point(xot, y);
                    }

                    y += 25;

                    for (int i = 0; i < lineas; i++)
                    {
                        y += 20;
                        dina.Height += 20;
                    }
                    dina.Name = "lblMensaje" + m;
                    m++;
                    dina.Text = cha.HoraEnvio.ToString("hh:mm") + " " + new Logica.Usuario().SelectUsuarioCi(cha.Ci).Apodo + "\n";
                    if (cha.Contenido.Length < 48)
                    {
                        for (int l = 0; l < dina.Width / 10; l++)
                        {
                            dina.Text += " -";
                        }
                    }
                    else
                    {
                        for (int l = 0; l < 59; l++)
                        {
                            dina.Text += " -";
                        }
                    }
                    dina.Text += "\n" + cha.Contenido;
                    panelCharla.Controls.Add(dina);
                    panelCharla.VerticalScroll.Value = 0;

                }
                foreach (Logica.Chatea ch in mensajes)
                {
                    panelCharla.VerticalScroll.Value = panelCharla.VerticalScroll.Maximum;
                }
            }
        }

    }
}
