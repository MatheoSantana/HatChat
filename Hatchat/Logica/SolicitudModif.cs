using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitudModif
    {
        private int idSolicitudModif;
        private DateTime fechaHora;
        private string contraNueva;
        private bool pendiente;
        private bool aceptada;
        private string usuario;

        public SolicitudModif()
        {

        }
        public SolicitudModif(int idSolicitudModif, DateTime fechaHora, string contraNueva, bool pendiente, bool aceptada, string usuario)
        {
            this.idSolicitudModif = idSolicitudModif;
            this.fechaHora = fechaHora;
            this.contraNueva = contraNueva;
            this.pendiente = pendiente;
            this.usuario = usuario;
            this.aceptada = aceptada;
        }

        public int IdSolicitudModif
        {
            set { idSolicitudModif = value; }
            get { return idSolicitudModif; }
        }
        public DateTime FechaHora
        {
            set { fechaHora = value; }
            get { return fechaHora; }
        }
        public string ContraNueva
        {
            set { contraNueva = value; }
            get { return contraNueva; }
        }
        public bool Pendiente
        {
            set { pendiente = value; }
            get { return pendiente; }
        }
        public bool Aceptada
        {
            set { aceptada = value; }
            get { return aceptada; }
        }
        public string Usuario
        {
            set { usuario = value; }
            get { return usuario; }
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
        public List<SolicitudModif> SelectSolicitudesModif()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesModif();
        }
        public SolicitudModif SelectSolicitudModifPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudModifPorId(id);
        }
        public void AceptarSolicitudModifPorSoliYAdmin(string ci, bool aceptar)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarSolicitudModifPorSoliYAdmin(this, ci, aceptar);
        }
        public List<SolicitudModif> SelectSolicitudesModifResueltas(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesModifResueltas(ci);
        }
    }
}
