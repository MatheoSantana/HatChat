﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class ClaseSolicitudClaseAl
    {
        private int idSolicitudClaseAl;
        private int idClase;
        private int oriClase;

        public ClaseSolicitudClaseAl()
        {
        }

        public ClaseSolicitudClaseAl(int idClase, int oriClase)
        {

            this.idClase = idClase;
            this.oriClase = oriClase;
        }
        public ClaseSolicitudClaseAl(int idSolicitudClaseAl, int idClase, int oriClase)
        {
            this.idSolicitudClaseAl = idSolicitudClaseAl;
            this.idClase = idClase;
            this.oriClase = oriClase;
        }

        public int IdSolicitudClaseAl
        {
            set { idSolicitudClaseAl = value; }
            get { return idSolicitudClaseAl; }
        }

        public int IdClase
        {
            set { idClase = value; }
            get { return idClase; }
        }
        public int OriClase
        {
            set { oriClase = value; }
            get { return oriClase; }
        }

        public void EnviarClaseSolicitudClaseAl()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarClaseSolicitudClaseAl(this);
        }
        public List<ClaseSolicitudClaseAl> SelectClaseSolicitudClaseAl(int idSolicitudClaseAl)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectClaseSolicitudClaseAl(idSolicitudClaseAl);
        }
    }
}
