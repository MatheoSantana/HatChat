using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitudClaseDo
    {
        private int idSolicitudClaseDo;
        private DateTime fechaHora;
        private bool pendiente;
        private string docente;

        public SolicitudClaseDo()
        {

        }
        public SolicitudClaseDo(DateTime fechaHora, bool pendiente, string docente)
        {
            this.idSolicitudClaseDo = idSolicitudClaseDo;
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.docente = docente;
        }
        public SolicitudClaseDo(int idSolicitudClaseDo, DateTime fechaHora, bool pendiente, string docente)
        {
            this.idSolicitudClaseDo = idSolicitudClaseDo;
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.docente = docente;
        }

        public int IdSolicitudClaseDo
        {
            get { return idSolicitudClaseDo; }
            set { idSolicitudClaseDo = value; }
        }
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public bool Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }
        public string Docente
        {
            get { return docente; }
            set { docente = value; }
        }
        public void EnviarSolicitudClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudClaseDo(this);
        }

        public void SelectIdSolicitudClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            idSolicitudClaseDo = conexion.SelectIdSolicitudClaseDo(this);

        }
    }
}
