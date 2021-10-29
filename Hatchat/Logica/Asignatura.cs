using System;
using System.Collections.Generic;
using System.Data;
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
        public string StringAId(string cadena)
        {
            char[] aConvertir = cadena.ToCharArray();

            string preId = "";
            for (int x = 3; x < aConvertir.Length; x++)
            {
                    preId += aConvertir[x].ToString();
            }
            return preId;

        }

        public List<Asignatura> SelectAsignaturasPorClaseAnioYorientacion(string clase, int anio, int orientacion)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAsignaturasPorClaseAnioYorientacion(clase, anio, orientacion);
        }
        public Asignatura SelectAsignaturaPorId(string id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAsignaturaPorId(id);
        }
        public List<Asignatura> SelectAsignaturasPorCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAsignaturasPorCi(ci);
        }
        public List<Asignatura> SelectAsignaturas()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAsignaturas();
        }
        public DataTable SelectAsignaturasGrilla()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAsignaturasGrilla();
        }
        public void AltaAsignatura()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AltaAsignatura(this);
        }
        public void BajaAsignatura()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.BajaAsignatura(this);
        }
        public void ModificarAsignatura()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.ModificarAsignatura(this);
        }
    }
}
