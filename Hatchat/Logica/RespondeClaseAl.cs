using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class RespondeClaseAl
    {
        private int idSolicitudClaseAl;
        private string ci;

        public RespondeClaseAl()
        {

        }
        public RespondeClaseAl(int idSolicitudClaseAl, string ci)
        {
            this.idSolicitudClaseAl = idSolicitudClaseAl;
            this.ci = ci;
        }

        public int IdSolicitudClaseAl
        {
            get { return idSolicitudClaseAl; }
            set { idSolicitudClaseAl = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
    }
}
