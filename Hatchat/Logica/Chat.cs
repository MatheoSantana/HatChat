using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class Chat
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
    }
}
