using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Asignatura
    {
        private string id;
        private string nombre;
        private int anio;
        private bool activo;

        public Asignatura()
        {

        }
        public Asignatura(string id, string nombre, int anio, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.anio = anio;
            this.activo = activo;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        override
        public string ToString()
        {
            return nombre +anio +" - " + id;
        }
    }
}
