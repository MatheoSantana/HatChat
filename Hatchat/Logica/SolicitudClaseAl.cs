using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class SolicitudClaseAl
    {
        private int idSolicitudClaseAl;
        private DateTime fechaHora;
        private bool pendiente;
        private string alumno;

        public SolicitudClaseAl() { 
        }
        public SolicitudClaseAl(int idSolicitudClaseAl, DateTime fechaHora, bool pendiente, string alumno)
        {
            this.idSolicitudClaseAl = idSolicitudClaseAl;
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.alumno = alumno;
        }

        public int IdSolicitudClaseAl
        {
            set { idSolicitudClaseAl = value; }
            get { return idSolicitudClaseAl; }
        }
        public DateTime FechaHora
        {
            set { fechaHora = value; }
            get { return fechaHora; }
        }
        public bool Pendiente
        {
            set { pendiente = value; }
            get { return pendiente; }
        }
        public string Alumno
        {
            set { alumno = value; }
            get { return alumno; }
        }

    }
}
