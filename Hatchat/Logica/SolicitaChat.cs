using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitaChat
    {
        private string ciAlumno;
        private string ciDocente;
        private int idClase;
        private DateTime fechaHora;
        private int oriClase;
        private string asignatura;
        private bool pendiente;

        public SolicitaChat()
        {
        }
        public SolicitaChat(string ciAlumno, string ciDocente, int idClase, DateTime fechaHora, int oriClase, string asignatura, bool pendiente)
        {
            this.ciAlumno = ciAlumno;
            this.ciDocente = ciDocente;
            this.idClase = idClase;
            this.fechaHora = fechaHora;
            this.oriClase = oriClase;
            this.asignatura = asignatura;
        }

        public string CiAlumno
        {
            get { return ciAlumno; }
            set { ciAlumno = value; }
        }
        public string CiDocente
        {
            get { return ciDocente; }
            set { ciDocente = value; }
        }
        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public int OriClase
        {
            get { return oriClase; }
            set { oriClase = value; }
        }
        public string Asignatura
        {
            get { return asignatura; }
            set { asignatura = value; }
        }
        public bool Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }
        public void EnviarSolicitudChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudChat(this);
        }
        public List<SolicitaChat> SelectSolicitaChats(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitaChats(ci);
        }
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = new DateTime();
            List<char> dateTime = new List<char>(fechaHora.ToCharArray());
            string year = "", month = "", day = "", minute = "", hour = "", second = "";

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

            return fh;
        }
    }
}
