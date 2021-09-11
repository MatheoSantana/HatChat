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
        public Mensaje(string alumno, string asunto, DateTime fechaHoraAlumno, string mensajeAlumno, string docente, string estado, string mensajeDocente, DateTime fechaHoraDocente)
        {
            this.alumno = alumno;
            this.asunto = asunto;
            this.fechaHoraAlumno = fechaHoraAlumno;
            this.mensajeAlumno = mensajeAlumno;
            this.docente = docente;
            this.estado = estado;
            this.mensajeDocente = mensajeDocente;
            this.fechaHoraDocente = fechaHoraDocente;
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
    }
}
