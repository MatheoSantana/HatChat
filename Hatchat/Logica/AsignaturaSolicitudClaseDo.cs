using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class AsignaturaSolicitudClaseDo
    {
        private int idSolicitudClaseDo;
        private int idClaseAsig;
        private int oriClaseAsig;
        private string idAsignatura;
        private bool aceptada;

        public AsignaturaSolicitudClaseDo()
        {
        }
        public AsignaturaSolicitudClaseDo(int idSolicitudClaseDo, int idClaseAsig, int oriClaseAsig, string idAsignatura, bool aceptada)
        {
            this.idSolicitudClaseDo = idSolicitudClaseDo;
            this.idClaseAsig = idClaseAsig;
            this.oriClaseAsig = oriClaseAsig;
            this.idAsignatura = idAsignatura;
            this.aceptada = aceptada;
        }

        public int IdSolicitudClaseDo
        {
            get { return idSolicitudClaseDo; }
            set { idSolicitudClaseDo = value; }
        }
        public int IdClaseAsig
        {
            get { return idClaseAsig; }
            set { idClaseAsig = value; }
        }
        public int OriClaseAsig
        {
            get { return oriClaseAsig; }
            set { oriClaseAsig = value; }
        }
        public string IdAsignatura
        {
            get { return idAsignatura; }
            set { idAsignatura = value; }
        }
        public bool Aceptada
        {
            get { return aceptada; }
            set { aceptada = value; }
        }
        public void EnviarAsignaturaSolicitudClaseDo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarAsignaturaSolicitudClaseDo(this);
        }
    }
}
