using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitudClaseAl
    {

        private int idSolicitudClase;
        private DateTime fechaHora;
        private bool pendiente;
        private string alumno;
        public SolicitudClaseAl()
        {

        }
        public SolicitudClaseAl(DateTime fechaHora, bool pendiente, string alumno)
        {
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.alumno = alumno;
        }
        public SolicitudClaseAl(int idSolicitudClase, DateTime fechaHora, bool pendiente, string alumno)
        {
            this.idSolicitudClase = idSolicitudClase;
            this.fechaHora = fechaHora;
            this.pendiente = pendiente;
            this.alumno = alumno;
        }

        public int IdSolicitudClaseAl
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
        public string Alumno
        {
            get { return alumno; }
            set { alumno = value; }
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
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                hour = "0" + fechaHora[11].ToString();
                minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                second = fechaHora[16].ToString() + fechaHora[17].ToString();
            }
            else if (fechaHora.Length == 17)
            {
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                second = fechaHora[15].ToString() + fechaHora[16].ToString();
            }
            else if (fechaHora.Length == 16)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
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
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
            }
            else if (fechaHora.Length == 14)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = "0" + fechaHora[7].ToString();
                    minute = fechaHora[9].ToString() + fechaHora[10].ToString();
                    second = fechaHora[12].ToString() + fechaHora[13].ToString();
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 13)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
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
            else if (fechaHora.Length == 8)
            {
                if (fechaHora[2].ToString() == "/")
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
        public void EnviarSolicitudClaseAl()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudClaseAl(this);
        }

        public int SelectIdSolicitudClaseAl()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectIdSolicitudClaseAl(this);
        }
        public List<SolicitudClaseAl> SelectSolicitudesClaseAl()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesClaseAl();
        }
        public SolicitudClaseAl SelectSolicitudClaseAlPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudClaseAlPorId(id);
        }
        public void AceptarSolicitudClaseAlPorIdYAdmin(int id, string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarSolicitudClaseAlPorIdYAdmin(id, ci);
        }
        public List<SolicitudClaseAl> SelectSolicitudesClaseAlResueltas(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesClaseAlResueltas(ci);
        }
    }
}
