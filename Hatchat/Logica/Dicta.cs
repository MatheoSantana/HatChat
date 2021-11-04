using System;
using System.Collections.Generic;
using System.Text;

namespace Hatchat.Logica
{
    public class Dicta
    {
        private int idClase;
        private string ciDocente;
        private int orientacion;
        private int anio;

        public Dicta()
        {

        }

        public Dicta(int idClase, string ciDocente, int orientacion, int anio)
        {
            this.orientacion = orientacion;
            this.idClase = idClase;
            this.ciDocente = ciDocente;
            this.anio = anio;
        }
        public int Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
        public string CiDocente
        {
            get { return ciDocente; }
            set { ciDocente = value; }
        }
        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        public int Anio
        {
            set { anio = value; }
            get { return anio; }
        }
        public void InsertDicta()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.InsertDicta(this);
        }
        public bool SelectDictando()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectDictando(this);
        }
    }
}
