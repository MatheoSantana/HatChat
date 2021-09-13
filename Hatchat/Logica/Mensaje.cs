using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Mensaje
    {
        private int idMensaje;
        private string alumno;
        private string docente;
        private DateTime fechaHoraAlumno;
        private string mensajeAlumno;
        private string estado;
        private string asunto;
        private string mensajeDocente;
        private DateTime fechaHoraDocente;
        public Mensaje()
        {

        }
        public Mensaje(int idMensaje, string alumno, string asunto, DateTime fechaHoraAlumno, string mensajeAlumno, string docente, string estado, string mensajeDocente, DateTime fechaHoraDocente)
        {
            this.idMensaje = idMensaje;
            this.alumno = alumno;
            this.asunto = asunto;
            this.fechaHoraAlumno = fechaHoraAlumno;
            this.mensajeAlumno = mensajeAlumno;
            this.docente = docente;
            this.estado = estado;
            this.mensajeDocente = mensajeDocente;
            this.fechaHoraDocente = fechaHoraDocente;
        }
        public Mensaje(string alumno, string asunto, DateTime fechaHoraAlumno, string mensajeAlumno, string docente, string estado)
        {
            this.alumno = alumno;
            this.asunto = asunto;
            this.fechaHoraAlumno = fechaHoraAlumno;
            this.mensajeAlumno = mensajeAlumno;
            this.docente = docente;
            this.estado = estado;
        }
        public int IdMensaje
        {
            set { idMensaje = value; }
            get { return idMensaje; }
        }
        public string Alumno
        {
            set { alumno = value; }
            get { return alumno; }
        }

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }
        public DateTime FechaHoraAlumno
        {
            set { fechaHoraAlumno = value; }
            get { return fechaHoraAlumno; }
        }
        public string MensajeAlumno
        {
            set { mensajeAlumno = value; }
            get { return mensajeAlumno; }
        }
        public string Docente
        {
            set { docente = value; }
            get { return docente; }
        }
        public string Estado
        {
            set { estado = value; }
            get { return estado; }
        }
        public string MensajeDocente
        {
            set { mensajeDocente = value; }
            get { return mensajeDocente; }
        }
        public DateTime FechaHoraDocente
        {
            set { fechaHoraDocente = value; }
            get { return fechaHoraDocente; }
        }

        public int StringAId(string cadena)
        {
            char[] aConvertir = cadena.ToCharArray();
            
            string preId = "";
            for(int x=0; x < aConvertir.Length; x++)
            {
                if(aConvertir[x] == '0' || aConvertir[x] == '1' || aConvertir[x] == '2' || aConvertir[x] == '3' || aConvertir[x] == '4' || aConvertir[x] == '5' || aConvertir[x] == '6' || aConvertir[x] == '7' || aConvertir[x] == '8' || aConvertir[x] == '9')
                {
                    preId += aConvertir[x];
                }
            }
            return Convert.ToInt32(preId);
        }

        public DateTime StringADateTime(string fechaHora)
        {
            char[] dateTime= fechaHora.ToCharArray();
            string year = "", month = "", day = "", minute = "", hour = "", second = "";
            for(int x = 0; x < dateTime.Length; x++)
            {
                if(x>=0 && x <= 3)
                {
                    year += fechaHora[x];
                }else if(x==5 || x == 6)
                {
                    month += fechaHora[x];
                }
                else if (x == 8 || x == 9)
                {
                    day += fechaHora[x];
                }
                else if (x == 11 || x == 12)
                {
                    hour += fechaHora[x];
                }
                else if (x == 14 || x == 15)
                {
                    minute += fechaHora[x];
                }
                else if (x == 17 || x == 18)
                {
                    second += fechaHora[x];
                }
                
            }
            DateTime fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
            return fh;
        }
        public List<Mensaje> SelectCargarMensajesDo(string docente)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectCargarMensajesDo(docente);
        }
        public List<Mensaje> SelectCargarMensajesAl(string alumno)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectCargarMensajesAl(alumno);
        }
        public Mensaje SelectAbrirMensaje(string idMensaje)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAbrirMensaje(StringAId(idMensaje));
        }
        public void EnviarMensajeAlumno()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarMensajeAlumno(this);
        }
        public void EnviarMensajeDocente()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarMensajeDocente(this);
        }
    }
}
