using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Hatchat.Logica
{
    public class Orientacion
    {
        private string nombre;
        private int id;
        private bool activo;
        public Orientacion()
        {
        }
        public Orientacion(int id, string nombre, bool activo)
        {
            this.nombre = nombre;
            this.id = id;
            this.activo = activo;
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public List<Orientacion> SelectOrientaciones()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectOrientaciones();
        }
    }
}
