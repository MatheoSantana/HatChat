using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Clase
    {
        private int idClase;
        private int anio;
        private int orientacion;
        private string nombre;
        private bool activo;

        public Clase()
        {

        }
        public Clase(int idClase, int anio, int orientacion, string nombre, bool activo)
        {
            this.idClase = idClase;
            this.anio = anio;
            this.orientacion = orientacion;
            this.nombre = nombre;
            this.activo = activo;
        }

        public int IdClase
        {
            set { idClase = value; }
            get { return idClase; }
        }
        public int Anio
        {
            set { anio = value; }
            get { return anio; }
        }

        public int Orientacion
        {
            set { orientacion = value; }
            get { return orientacion; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        override
        public string ToString()
        {
            return anio + nombre + " - " + orientacion;
        }
    }
}
