using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class Chat
    {
        private int idChat;
        private int idClase;
        private int oriClase;
        private string asignatura;
        private DateTime fecha;
        private DateTime horaInicio;
        private DateTime horaFin;
        private string titulo;
        private bool activo;

        public Chat()
        {

        }

        public Chat(int idChat, int idClase, int oriClase, string asignatura, DateTime fecha, DateTime horaInicio, DateTime horaFin, string titulo, bool activo)
        {
            this.idChat = idChat;
            this.idClase = idClase;
            this.oriClase = oriClase;
            this.asignatura = asignatura;
            this.fecha = fecha;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.titulo = titulo;
            this.activo = activo;
        }

        public int IdChat
        {
            set { idChat = value; }
            get { return idChat; }
        }
        public int IdClase
        {
            set { idClase = value; }
            get { return idClase; }
        }
        public int OriClase
        {
            set { oriClase = value; }
            get { return oriClase; }
        }
        public string Asignatura
        {
            set { asignatura = value; }
            get { return asignatura; }
        }
        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }
        public DateTime HoraInicio
        {
            set { horaInicio = value; }
            get { return horaInicio; }
        }
        public DateTime HoraFin
        {
            set { horaFin = value; }
            get { return horaFin; }
        }
        public string Titulo
        {
            set { titulo = value; }
            get { return titulo; }
        }
        public bool Activo
        {
            set { activo = value; }
            get { return activo; }
        }
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = new DateTime();
            List<char> dateTime = new List<char>(fechaHora.ToCharArray());
            string year = "", month = "", day = "", minute = "", hour = "", second = "";
            if (fechaHora.Length < 11)
            {
                if (dateTime.Contains(':'))
                {
                    for (int x = 0; x < fechaHora.Length; x++)
                    {
                        if ((x == 0 || x == 1) && (fechaHora[x] != ':'))
                        {
                            hour += fechaHora[x];

                        }
                        else if (x == 3 || x == 4 && (fechaHora[x] != ':'))
                        {
                            minute += fechaHora[x];
                        }
                        else if (x >= 6 && x <= 9 && (fechaHora[x] != ':'))
                        {
                            second += fechaHora[x];
                        }

                    }
                    year = this.fecha.ToString("yyyy");
                    month = this.fecha.ToString("MM");
                    day = this.fecha.ToString("dd");
                    fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
                }
                else
                {
                    for (int x = 0; x < fechaHora.Length; x++)
                    {
                        if ((x == 0 || x == 1) && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                        {
                            day += fechaHora[x];

                        }
                        else if (x == 3 || x == 4 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                        {
                            month += fechaHora[x];
                        }
                        else if (x >= 6 && x <= 9 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                        {
                            year += fechaHora[x];
                        }

                    }
                    fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                }
            }
            else
            {

                for (int x = 0; x < fechaHora.Length; x++)
                {
                    if ((x == 0 || x == 1) && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        day += fechaHora[x];

                    }
                    else if (x == 3 || x == 4 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        month += fechaHora[x];
                    }
                    else if (x >= 6 && x <= 9 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        year += fechaHora[x];
                    }
                    else if (x == 11 || x == 12 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        hour += fechaHora[x];
                    }
                    else if (x == 14 || x == 15 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        minute += fechaHora[x];
                    }
                    else if (x == 17 || x == 18 && (fechaHora[x] != ':' && fechaHora[x] != ' ' && fechaHora[x] != '/'))
                    {
                        second += fechaHora[x];
                    }
                }
                fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
            }
            return fh;
        }
        public List<Chat> SelectChatsActivosPorCedulaDocente(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatsActivosPorCedulaDocente(ci);
        }
        public List<Chat> SelectChatsActivosPorCedulaAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatsActivosPorCedulaAlumno(ci);
        }
        public Chat SelectChatPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatPorId(id);
        }
        public void CrearChat(SolicitaChat soli)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CrearChat(soli);
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
        public void CerrarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CerrarChat(this);
        }
        public void CambiarTitulo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CambiarTitulo(this);
        }
    }
}
