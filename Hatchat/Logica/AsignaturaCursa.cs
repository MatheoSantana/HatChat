using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class AsignaturaCursa
    {
        private string ci;
        private int idClase;
        private int orientacion;
        private int anio;
        private string asignaturaCursada;
        private bool cursando;

        public AsignaturaCursa()
        {
        }
        public AsignaturaCursa(string ci, int idClase, int orientacion, int anio, string asignaturaCursada, bool cursando)
        {
            this.ci = ci;
            this.idClase = idClase;
            this.orientacion = orientacion;
            this.anio = anio;
            this.asignaturaCursada = asignaturaCursada;
            this.cursando = cursando;
        }

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        public int Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }
        public string AsignaturaCursada
        {
            get { return asignaturaCursada; }
            set { asignaturaCursada = value; }
        }
        public bool Cursando
        {
            get { return cursando; }
            set { cursando = value; }
        }
    }
}
