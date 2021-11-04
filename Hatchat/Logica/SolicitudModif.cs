using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitudModif
    {
        private int idSolicitudModif;
        private DateTime fechaHora;
        private string contraNueva;
        private bool pendiente;
        private bool aceptada;
        private string usuario;

        public SolicitudModif()
        {

        }
        public SolicitudModif(int idSolicitudModif, DateTime fechaHora, string contraNueva, bool pendiente, bool aceptada, string usuario)
        {
            this.idSolicitudModif = idSolicitudModif;
            this.fechaHora = fechaHora;
            this.contraNueva = contraNueva;
            this.pendiente = pendiente;
            this.usuario = usuario;
            this.aceptada = aceptada;
        }

        public int IdSolicitudModif
        {
            set { idSolicitudModif = value; }
            get { return idSolicitudModif; }
        }
        public DateTime FechaHora
        {
            set { fechaHora = value; }
            get { return fechaHora; }
        }
        public string ContraNueva
        {
            set { contraNueva = value; }
            get { return contraNueva; }
        }
        public bool Pendiente
        {
            set { pendiente = value; }
            get { return pendiente; }
        }
        public bool Aceptada
        {
            set { aceptada = value; }
            get { return aceptada; }
        }
        public string Usuario
        {
            set { usuario = value; }
            get { return usuario; }
        }
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = Convert.ToDateTime(fechaHora);
            return fh;
        }
        public List<SolicitudModif> SelectSolicitudesModif()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesModif();
        }
        public SolicitudModif SelectSolicitudModifPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudModifPorId(id);
        }
        public void AceptarSolicitudModifPorSoliYAdmin(string ci, bool aceptar)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarSolicitudModifPorSoliYAdmin(this, ci, aceptar);
        }
        public List<SolicitudModif> SelectSolicitudesModifResueltas(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitudesModifResueltas(ci);
        }
        public void EnviarSolicitudModif()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudModif(this);
        }
    }
}
