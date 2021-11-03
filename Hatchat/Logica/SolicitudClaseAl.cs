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
            DateTime fh = Convert.ToDateTime(fechaHora);
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
