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

        public Agenda SelectAgendaConCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAgendaConCi(ci);
        }
    }
}
