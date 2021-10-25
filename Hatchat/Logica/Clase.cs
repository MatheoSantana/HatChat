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

        public void SelectIdClasePorPorNombreAnioYorientacion()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            idClase = conexion.SelectIdClasePorPorNombreAnioYorientacion(nombre, anio, orientacion);
        }
        public int[] selectAnioClasesPorOrientacion(int orientacion)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.selectAnioClasesPorOrientacion(orientacion);
        }

        public string[] SelectNombreClasePorAnioYorientacion(int anio, int orientacion)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectNombreClasePorAnioYorientacion(anio, orientacion);
        }
        public Clase SelectClasePorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectClasePorId(id);
        }
        public void AltaClase()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AltaClase(this);
        }
        public List<Clase> SelectClasesPorAnio(int anio)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectClasesPorAnio(anio);
        }
        public void BajaClase()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.BajaClase(this);
        }

    }
}
