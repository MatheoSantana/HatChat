using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Contiene
    {
        private int asignatura;
        private int orientacion;

        public Contiene()
        {

        }
        public Contiene(int asignatura, int orientacion)
        {
            this.orientacion = orientacion;
            this.asignatura = asignatura;
        }

        public int Asignatura
        {
            get { return asignatura; }
            set { asignatura = value; }
        }
        public int Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
    
    }

}
