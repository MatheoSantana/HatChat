using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class Agenda
    {
        private String nomDia;
        private string horaInicio;
        private string horaFin;
        private string ci;
        private int idAgenda;

        public Agenda()
        {

        }

        public Agenda(int idAgenda, string nomDia, string horaInicio, string horaFin, string ci)
        {
            this.idAgenda = idAgenda;
            this.nomDia = nomDia;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.ci = ci;
        }
        public int IdAgenda
        {
            get { return idAgenda; }
            set { idAgenda = value; }
        }
        public string NomDia
        {
            get { return nomDia; }
            set { nomDia = value; }
        }

        public string HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }
        public string HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
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
        public bool EnHora(Agenda ag)
        {
            bool enHora= false;
            DateTime hoy = DateTime.Now;
            string dia = "";
            if (hoy.DayOfWeek.ToString() == "Monday")
            {
                dia = "Lunes";
            }
            else if (hoy.DayOfWeek.ToString() == "Tuesday")
            {
                dia = "Martes";
            }
            else if (hoy.DayOfWeek.ToString() == "Wednesday")
            {
                dia = "Miercoles";
            }
            else if (hoy.DayOfWeek.ToString() == "Thursday")
            {
                dia = "Jueves";
            }
            else if (hoy.DayOfWeek.ToString() == "Friday")
            {
                dia = "Viernes";
            }
            else if (hoy.DayOfWeek.ToString() == "Saturday")
            {
                dia = "Sabado";
            }
            else if (hoy.DayOfWeek.ToString() == "Sunday")
            {
                dia = "Domingo";
            }
            
            string horaAgInicio = "";
            horaAgInicio += ag.horaInicio[0].ToString() + ag.horaInicio[1].ToString();

            string minutoAgInicio = "";
            minutoAgInicio += ag.horaInicio[3].ToString() + ag.horaInicio[4].ToString();

            string horaAgFin = "";
            horaAgFin += ag.horaFin[0].ToString() + ag.horaFin[1].ToString();

            string minutoAgFin = "";
            minutoAgFin += ag.horaFin[3].ToString() + ag.horaFin[4].ToString();

            DateTime agendaInicio = new DateTime(hoy.Year, hoy.Month, hoy.Day, Convert.ToInt32(horaAgInicio), Convert.ToInt32(minutoAgInicio), 0);
            DateTime agendaFin = new DateTime(hoy.Year, hoy.Month, hoy.Day, Convert.ToInt32(horaAgFin), Convert.ToInt32(horaAgFin), 0);

            if (ag.NomDia == dia && hoy>=agendaInicio && hoy < agendaFin)
            {
                enHora = true;
            }
            return enHora;
        }
        public List<Agenda> SelectAgendasPorCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAgendasPorCi(ci);
        }

        public Agenda SelectAgendaConCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAgendaConCi(ci);
        }
        public Agenda SelectAgendaPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAgendaPorId(id);
        }
        public void EliminarAgendaPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EliminarAgendaPorId(id);
        }
        public void AgregarAgenda()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AgregarAgenda(this);
        }
    }
}
