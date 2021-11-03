using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class SolicitaChat
    {
        private string ciAlumno;
        private string ciDocente;
        private int idClase;
        private DateTime fechaHora;
        private int oriClase;
        private string asignatura;
        private bool pendiente;

        public SolicitaChat()
        {
        }
        public SolicitaChat(string ciAlumno, string ciDocente, int idClase, DateTime fechaHora, int oriClase, string asignatura, bool pendiente)
        {
            this.ciAlumno = ciAlumno;
            this.ciDocente = ciDocente;
            this.idClase = idClase;
            this.fechaHora = fechaHora;
            this.oriClase = oriClase;
            this.asignatura = asignatura;
        }

        public string CiAlumno
        {
            get { return ciAlumno; }
            set { ciAlumno = value; }
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
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public int OriClase
        {
            get { return oriClase; }
            set { oriClase = value; }
        }
        public string Asignatura
        {
            get { return asignatura; }
            set { asignatura = value; }
        }
        public bool Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }
        public void EnviarSolicitudChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.EnviarSolicitudChat(this);
        }
        public List<SolicitaChat> SelectSolicitaChats(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectSolicitaChats(ci);
        }
        public void AceptarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.AceptarChat(this);
        }
        public void DenegarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.DenegarChat(this);
        }
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = Convert.ToDateTime(fechaHora);
            return fh;
        }
    }
}
