using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class RespondeClaseDo
    {
        private int idSolicitudClaseDo;
        private string ci;

        public RespondeClaseDo()
        {

        }
        public RespondeClaseDo(int idSolicitudClaseDo, string ci)
        {
            this.idSolicitudClaseDo = idSolicitudClaseDo;
            this.ci = ci;
        }

        public int IdSolicitudClaseDo
        {
            get { return idSolicitudClaseDo; }
            set { idSolicitudClaseDo = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
    }
}
