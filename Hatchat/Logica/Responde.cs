using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class Responde
    {
        private int idSolicitudModif;
        private string ci;

        public Responde()
        {

        }
        public Responde(int idSolicitudModif, string ci)
        {
            this.idSolicitudModif = idSolicitudModif;
            this.ci = ci;
        }

        public int IdSolicitudModif
        {
            get { return idSolicitudModif; }
            set { idSolicitudModif = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
    }
}
