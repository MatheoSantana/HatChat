using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class SolicitudModif
    {
        private int idSolicitudModif;
        private DateTime fechaHora;
        private string contraNueva;
        private bool pendiente;
        private string usuario;

        public SolicitudModif()
        {

        }
        public SolicitudModif(int idSolicitudModif, DateTime fechaHora, string contraNueva, bool pendiente, string usuario)
        {
            this.idSolicitudModif = idSolicitudModif;
            this.fechaHora = fechaHora;
            this.contraNueva = contraNueva;
            this.pendiente = pendiente;
            this.usuario = usuario;
        }

        public int IdSolicitudModif
        {
            set { idSolicitudModif = value; }
            get { return idSolicitudModif; }
        }
        public DateTime FechaHora
        {
            set { fechaHora = value; }
            get { return fechaHora; }
        }
        public string ContraNueva
        {
            set { contraNueva = value; }
            get { return contraNueva; }
        }
        public bool Pendiente
        {
            set { pendiente = value; }
            get { return pendiente; }
        }
        public string Usuario
        {
            set { usuario = value; }
            get { return usuario; }
        }
    }
}
