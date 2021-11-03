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
            for (int x = 0; x < aConvertir.Length; x++)
            {
                if (aConvertir[x] == '0' || aConvertir[x] == '1' || aConvertir[x] == '2' || aConvertir[x] == '3' || aConvertir[x] == '4' || aConvertir[x] == '5' || aConvertir[x] == '6' || aConvertir[x] == '7' || aConvertir[x] == '8' || aConvertir[x] == '9')
                {
                    preId += aConvertir[x];
                }
            }
            return Convert.ToInt32(preId);
        }

        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = Convert.ToDateTime(fechaHora); 
            return fh;
        }
        public List<Mensaje> SelectCargarMensajesDo(string docente)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectCargarMensajesDo(docente);
        }
        public List<Mensaje> SelectMensajesAl(string alumno)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectMensajesAl(alumno);
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
        public List<Mensaje> SelectMensajesRecibidosAl(string alumno)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectMensajesRecibidosAl(alumno);
        }
        public void AbrirMensaje()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AbrirMensaje(this);
        }
        public List<Mensaje> SelectMensajesContestadosDo(string docente)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectMensajesContestadosDo(docente);
        }
        public List<Mensaje> SelectMensajesContestadosDo(string docente, string nombre, string apellido)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectMensajesContestadosDo(docente, nombre, apellido);
        }
    }
}
