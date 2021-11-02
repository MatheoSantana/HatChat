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
                if(fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if(fechaHora[2].ToString() == "/")
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
                else if(fechaHora[3].ToString() == "/")
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
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() +fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }else if (fechaHora[2].ToString() == "/")
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
