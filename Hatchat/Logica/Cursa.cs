using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Cursa
    {
        private int idClase;
        private string ciAlumno;
        private int orientacion;
        private int anio;

        public Cursa()
        {

        }

        public Cursa(int idClase, string ciAlumno, int orientacion, int anio)
        {
            this.idClase = idClase;
            this.ciAlumno = ciAlumno;
            this.orientacion = orientacion;
            this.anio = anio;
        }
        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        public string CiAlumno
        {
            get { return ciAlumno; }
            set { ciAlumno = value; }
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
        public void InsertCursa()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.InsertCursa(this);
        }
        public bool SelectCursando()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectCursando(this);
        }
    }
}
