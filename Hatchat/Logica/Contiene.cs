using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Contiene
    {
        private string asignatura;
        private int orientacion;
        private bool activo;

        public Contiene()
        {

        }
        public Contiene(string asignatura, int orientacion, bool activo)
        {
            this.orientacion = orientacion;
            this.asignatura = asignatura;
            this.activo = activo;
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
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public void AltaContiene()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AltaContiene(this);
        }
        public void BajaContiene()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AltaContiene(this);
        }
        public List<Contiene> SelectContienePorOrientacion(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectContienePorOrientacion(id);
        }
    }
}
