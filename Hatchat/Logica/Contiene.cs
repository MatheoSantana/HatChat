using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Contiene
    {
        private string asignatura;
        private int orientacion;

        public Contiene()
        {

        }
        public Contiene(string asignatura, int orientacion)
        {
            this.orientacion = orientacion;
            this.asignatura = asignatura;
        }

        public string Asignatura
        {
            get { return asignatura; }
            set { asignatura = value; }
        }
        public int Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
        public void AltaContiene()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AltaContiene(this);
        }
    }

}
