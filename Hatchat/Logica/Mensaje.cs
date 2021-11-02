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
            DateTime fh = new DateTime();
            string year = "", month = "", day = "", minute = "", hour = "", second = "";

            if (fechaHora.Length == 19)
            {
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                minute = fechaHora[14].ToString() + fechaHora[15].ToString();
                second = fechaHora[17].ToString() + fechaHora[18].ToString();

            }
            else if (fechaHora.Length == 18)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
            }
            else if (fechaHora.Length == 17)
            {
                if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if (fechaHora[2].ToString() == "/")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();

                }

            }
            else if (fechaHora.Length == 16)
            {
                if (fechaHora[4].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[8].ToString() == " ")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = fechaHora[14].ToString() + fechaHora[15].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 15)
            {
                if (fechaHora[2].ToString() == "/")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = fechaHora[7].ToString() + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[7].ToString() == " ")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 14)
            {
                if (fechaHora[6].ToString() == " ")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = "0" + fechaHora[7].ToString();
                    minute = fechaHora[9].ToString() + fechaHora[10].ToString();
                    second = fechaHora[12].ToString() + fechaHora[13].ToString();
                }
                else if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "00";
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 13)
            {
                if (fechaHora[4].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
                else if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 12)
            {
                if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = fechaHora[7].ToString() + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = "00";
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = "00";

                }
            }
            else if (fechaHora.Length == 11)
            {
                day = "0" + fechaHora[0].ToString();
                month = "0" + fechaHora[2].ToString();
                year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                hour = "0" + fechaHora[7].ToString();
                minute = fechaHora[9].ToString() + fechaHora[10].ToString();
                second = "00";
            }
            else if (fechaHora.Length == 10)
            {
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 9)
            {
                day = "0" + fechaHora[0].ToString();
                month = fechaHora[2].ToString() + fechaHora[3].ToString();
                year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 8)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else
                {
                    day = "05";
                    month = "11";
                    year = "2021";
                    hour = fechaHora[0].ToString() + fechaHora[1].ToString();
                    minute = fechaHora[3].ToString() + fechaHora[4].ToString();
                    second = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                }
            }
            else if (fechaHora.Length == 7)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else
                {
                    day = "05";
                    month = "11";
                    year = "2021";
                    hour = "0" + fechaHora[0].ToString();
                    minute = fechaHora[2].ToString() + fechaHora[3].ToString();
                    second = fechaHora[5].ToString() + fechaHora[6].ToString();
                }
            }
            else if (fechaHora.Length == 6)
            {
                day = "0" + fechaHora[0].ToString();
                month = "0" + fechaHora[2].ToString();
                year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 5)
            {
                day = "05";
                month = "11";
                year = "2021";
                hour = fechaHora[0].ToString() + fechaHora[1].ToString();
                minute = fechaHora[3].ToString() + fechaHora[4].ToString();
                second = "00";
            }
            else
            {
                day = "05";
                month = "11";
                year = "2021";
                hour = "0" + fechaHora[0].ToString();
                minute = fechaHora[2].ToString() + fechaHora[3].ToString();
                second = "00";
            }
            fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
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
