using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitudClaseDo
    {

        private int idSolicitudClase;
        private DateTime fechaHora;
        private bool pendiente;
        private string docente;
        public SolicitudClaseDo()
        {

        }
        public SolicitudClaseDo(DateTime fechaHora, bool pendiente, string docente)
        {
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.docente = docente;
        }
        public SolicitudClaseDo(int idSolicitudClase, DateTime fechaHora, bool pendiente, string docente)
        {
            this.idSolicitudClase = idSolicitudClase;
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.docente = docente;
        }

        public int IdSolicitudClaseDo
        {
            get { return idSolicitudClase; }
            set { idSolicitudClase = value; }
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
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = Convert.ToDateTime(fechaHora);
            return fh;
        }
        public int StringAId(string cadena)
        {
            char[] aConvertir = cadena.ToCharArray();

            string preId = "";
            for (int x = 0; x < aConvertir.Length; x++)
            {
                if (aConvertir[x] == '0' || aConvertir[x] == '1' || aConvertir[x] == '2' || aConvertir[x] == '3' || aConvertir[x] == '4' || aConvertir[x] == '5' || aConvertir[x] == '6' || aConvertir[x] == '7' || aConvertir[x] == '8' || aConvertir[x] == '9')
                {
                    preId += aConvertir[x];
                }
            }
            return Convert.ToInt32(preId);

        }
        public void EnviarSolicitudClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudClaseDo(this);
        }

        public int SelectIdSolicitudClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectIdSolicitudClaseDo(this);

        }
        public SolicitudClaseDo SelectSolicitudClaseDoPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudClaseDoPorId(id);
        }
            public List<SolicitudClaseDo> SelectSolicitudesClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesClaseDo();
        }
        public void AceptarSolicitudClaseDoPorIdYAdmin(int id, string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarSolicitudClaseDoPorIdYAdmin(id, ci);
        }
        public List<SolicitudClaseDo> SelectSolicitudesClaseDoResueltas(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesClaseDoResueltas(ci);
        }
    }
}
