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
            char[] dateTime = fechaHora.ToCharArray();

            string year = "", month = "", day = "", minute = "", hour = "", second = "";
            for (int x = 0; x < dateTime.Length; x++)
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

            DateTime fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
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
    }
}
