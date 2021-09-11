using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class Agenda
    {
        private String nomDia;
        private int idClase;
        private int orientacion;
        private int asignaturaDictada;
        private DateTime horaInicio;
        private DateTime horaFin;
        private string ci;

        public Agenda()
        {

        }

        public Agenda(string nomDia, int idClase, int orientacion, int asignaturaDictada, DateTime horaInicio, DateTime horaFin, string ci)
        {
            this.nomDia = nomDia;
            this.idClase = idClase;
            this.orientacion = orientacion;
            this.asignaturaDictada = asignaturaDictada;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.ci = ci;
        }
        public string NomDia
        {
            get { return nomDia; }
            set { nomDia = value; }
        }
        public int IdClase
        {
            get { return IdClase; }
            set { IdClase = value; }
        }
        public int Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
        public int AsignaturaDictada
        {
            get { return asignaturaDictada; }
            set { asignaturaDictada = value; }
        }
        public DateTime HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }
        public DateTime HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
    }
}
