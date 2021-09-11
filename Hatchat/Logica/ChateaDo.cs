using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    class ChateaDo
    {
        private string ci;
        private int idChat;
        private DateTime horaEnvioDo;
        private string contenido;

        public ChateaDo()
        {
        }
        public ChateaDo(string ci, int idChat, DateTime horaEnvioDo, string contenido)
        {
            this.ci = ci;
            this.idChat = idChat;
            this.horaEnvioDo = horaEnvioDo;
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
        public DateTime HoraEnvioDo
        {
            get { return horaEnvioDo; }
            set { horaEnvioDo = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
    }
}
