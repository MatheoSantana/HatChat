using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class PreguntaSeg
    {
        private int id;
        private string pregSeguridad;

        public PreguntaSeg()
        {

        }
        public PreguntaSeg(int id, string pregSeguridad)
        {
            this.id = id;
            this.pregSeguridad = pregSeguridad;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Pregunta
        {
            set { pregSeguridad = value; }
            get { return pregSeguridad; }
        }

        public List<PreguntaSeg> SelectPreguntasSeguridad()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectPreguntasSeguridad();
        }
    }
}
