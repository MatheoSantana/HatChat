using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class ChateaAl
    {
        private string ci;
        private int idChat;
        private DateTime horaEnvioAl;
        private string contenido;

        public ChateaAl()
        {
        }
        public ChateaAl(string ci, int idChat, DateTime horaEnvioAl, string contenido)
        {
            this.ci = ci;
            this.idChat = idChat;
            this.horaEnvioAl = horaEnvioAl;
            this.contenido = contenido;
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
        public DateTime HoraEnvioAl
        {
            get { return horaEnvioAl; }
            set { horaEnvioAl = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
    }
}
