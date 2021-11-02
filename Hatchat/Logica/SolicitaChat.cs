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
        public void AceptarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarChat(this);
        }
        public void DenegarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.DenegarChat(this);
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
    }
}
