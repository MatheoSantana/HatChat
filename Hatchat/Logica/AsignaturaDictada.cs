using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class AsignaturaDictada
    {
        private string ci;
        private int idClase;
        private int orientacion;
        private int anio;
        private string asigDictada;
        private bool dictando;

        public AsignaturaDictada()
        {
        }
        public AsignaturaDictada(string ci, int idClase, int orientacion, int anio, string asigDictada, bool dictando)
        {
            this.ci = ci;
            this.idClase = idClase;
            this.orientacion = orientacion;
            this.anio = anio;
            this.asigDictada = asigDictada;
            this.dictando = dictando;
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
        public string AsigDictada
        {
            get { return asigDictada; }
            set { asigDictada = value; }
        }
        public bool Dictando
        {
            get { return dictando; }
            set { dictando = value; }
        }
    }
}
