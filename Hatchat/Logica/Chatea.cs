using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class Chatea
    {
        protected string ci;
        protected int idChat;
        protected DateTime horaEnvio;
        protected string contenido;
        public Chatea(string ci, int idChat, DateTime horaEnvio, string contenido)
        {
            this.ci = ci;
            this.idChat = idChat;
            this.horaEnvio = horaEnvio;
            this.contenido = contenido;
        }
        public Chatea()
        {

        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public int IdChat
        {
            get { return idChat; }
            set { idChat = value; }
        }
        public DateTime HoraEnvio
        {
            get { return horaEnvio; }
            set { horaEnvio = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        public List<ChateaDo> SelectChateaDosPorIdChatMasFecha(int id, DateTime fecha)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChateaDosPorIdChatMasFecha(id, fecha);
        }
        public List<ChateaAl> SelectChateaAlsPorIdChatMasFecha(int id, DateTime fecha)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChateaAlsPorIdChatMasFecha(id, fecha);
        }
    }

}
