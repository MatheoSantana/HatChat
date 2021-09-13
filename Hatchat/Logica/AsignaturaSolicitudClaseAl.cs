using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class AsignaturaSolicitudClaseAl
    {
        private int idSolicitudClaseAl;
        private int idClaseAsig;
        private int oriClaseAsig;
        private string idAsignatura;
        private bool aceptada;

        public AsignaturaSolicitudClaseAl()
        {
        }
        public AsignaturaSolicitudClaseAl(int idSolicitudClaseAl, int idClaseAsig, int oriClaseAsig, string idAsignatura, bool aceptada)
        {
            this.idSolicitudClaseAl = idSolicitudClaseAl;
            this.idClaseAsig = idClaseAsig;
            this.oriClaseAsig = oriClaseAsig;
            this.idAsignatura = idAsignatura;
            this.aceptada = aceptada;
        }

        public int IdSolicitudClaseAl
        {
            get { return idSolicitudClaseAl; }
            set { idSolicitudClaseAl = value; }
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

    }
}
