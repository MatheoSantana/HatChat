using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatchat.Logica
{
    public class Chat
    {
        private int idChat;
        private int idClase;
        private int oriClase;
        private string asignatura;
        private DateTime fecha;
        private DateTime horaInicio;
        private DateTime horaFin;
        private string titulo;
        private bool activo;

        public Chat()
        {

        }

        public Chat(int idChat, int idClase, int oriClase, string asignatura, DateTime fecha, DateTime horaInicio, DateTime horaFin, string titulo, bool activo)
        {
            this.idChat = idChat;
            this.idClase = idClase;
            this.oriClase = oriClase;
            this.asignatura = asignatura;
            this.fecha = fecha;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.titulo = titulo;
            this.activo = activo;
        }

        public int IdChat
        {
            set { idChat = value; }
            get { return idChat; }
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
        public string Asignatura
        {
            set { asignatura = value; }
            get { return asignatura; }
        }
        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }
        public DateTime HoraInicio
        {
            set { horaInicio = value; }
            get { return horaInicio; }
        }
        public DateTime HoraFin
        {
            set { horaFin = value; }
            get { return horaFin; }
        }
        public string Titulo
        {
            set { titulo = value; }
            get { return titulo; }
        }
        public bool Activo
        {
            set { activo = value; }
            get { return activo; }
        }
        public DateTime StringADateTime(string fechaHora)
        {
            DateTime fh = Convert.ToDateTime(fechaHora);

            //esto es un recordatorio de que hay que leer la documentacion del lenguaje antes de pensar que no funciona...

            /*
            string year = "", month = "", day = "", minute = "", hour = "", second = "";
            
            if (fechaHora.Length == 19)
            {
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                minute = fechaHora[14].ToString() + fechaHora[15].ToString();
                second = fechaHora[17].ToString() + fechaHora[18].ToString();

            }
            else if (fechaHora.Length == 18)
            {
                if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[13].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = "0" + fechaHora[14].ToString();
                    second = fechaHora[16].ToString() + fechaHora[17].ToString();
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = fechaHora[14].ToString() + fechaHora[15].ToString();
                    second = "0" + fechaHora[17].ToString();
                }
            }
            else if (fechaHora.Length == 17)
            {
                if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[13].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = "0" + fechaHora[14].ToString();
                    second = "0" + fechaHora[16].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "0" + fechaHora[16].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();

                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "0" + fechaHora[16].ToString();

                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[15].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "0" + fechaHora[16].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = fechaHora[15].ToString() + fechaHora[16].ToString();
                }

            }
            else if (fechaHora.Length == 16)
            {
                if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = fechaHora[14].ToString() + fechaHora[15].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = "0" + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[14].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = fechaHora[12].ToString() + fechaHora[13].ToString();
                    second = "0" + fechaHora[15].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = fechaHora[14].ToString() + fechaHora[15].ToString();
                }
            }
            else if (fechaHora.Length == 15)
            {
                if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = fechaHora[11].ToString() + fechaHora[12].ToString();
                    minute = "0" + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                    hour = "0" + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = "0" + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = "0" + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[2].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[9].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = "0" + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[12].ToString() == ":")
                {
                    day = "0" +fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = fechaHora[10].ToString() + fechaHora[11].ToString();
                    minute = fechaHora[13].ToString() + fechaHora[14].ToString();
                    second = "00";
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[9].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                    hour = "0" + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = "0" + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[4].ToString() == "/" && fechaHora[7].ToString() == " " && fechaHora[9].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[11].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = fechaHora[9].ToString() + fechaHora[10].ToString();
                    minute = "0" + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[13].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "0" + fechaHora[14].ToString();
                }
                else if (fechaHora[1].ToString() == "/" && fechaHora[3].ToString() == "/" && fechaHora[8].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = "0" + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = fechaHora[7].ToString() + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = fechaHora[13].ToString() + fechaHora[14].ToString();
                }
            }
            else if (fechaHora.Length == 14)
            {
                if (fechaHora[2].ToString() == "/" && fechaHora[5].ToString() == "/" && fechaHora[10].ToString() == " " && fechaHora[10].ToString() == ":" && fechaHora[12].ToString() == ":")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = "0" + fechaHora[7].ToString();
                    minute = fechaHora[9].ToString() + fechaHora[10].ToString();
                    second = fechaHora[12].ToString() + fechaHora[13].ToString();
                }
                else if ()
                {
                    
                }
            }
            else if (fechaHora.Length == 13)
            {
                if (fechaHora[4].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = fechaHora[8].ToString() + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
                else if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
                else
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "0" + fechaHora[9].ToString();
                    minute = fechaHora[11].ToString() + fechaHora[12].ToString();
                    second = "00";
                }
            }
            else if (fechaHora.Length == 12)
            {
                if (fechaHora[3].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                    hour = fechaHora[7].ToString() + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = "00";
                }
                else
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "0" + fechaHora[8].ToString();
                    minute = fechaHora[10].ToString() + fechaHora[11].ToString();
                    second = "00";

                }
            }
            else if (fechaHora.Length == 11)
            {
                day = "0" + fechaHora[0].ToString();
                month = "0" + fechaHora[2].ToString();
                year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                hour = "0" + fechaHora[7].ToString();
                minute = fechaHora[9].ToString() + fechaHora[10].ToString();
                second = "00";
            }
            else if (fechaHora.Length == 10)
            {
                day = fechaHora[0].ToString() + fechaHora[1].ToString();
                month = fechaHora[3].ToString() + fechaHora[4].ToString();
                year = fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString() + fechaHora[9].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 9)
            {
                day = "0" + fechaHora[0].ToString();
                month = fechaHora[2].ToString() + fechaHora[3].ToString();
                year = fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString() + fechaHora[8].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 8)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = "0" + fechaHora[2].ToString();
                    year = fechaHora[4].ToString() + fechaHora[5].ToString() + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else if (fechaHora[2].ToString() == "/")
                {
                    day = fechaHora[0].ToString() + fechaHora[1].ToString();
                    month = fechaHora[3].ToString() + fechaHora[4].ToString();
                    year = "20" + fechaHora[6].ToString() + fechaHora[7].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else
                {
                    day = "05";
                    month = "11";
                    year = "2021";
                    hour = fechaHora[0].ToString() + fechaHora[1].ToString();
                    minute = fechaHora[3].ToString() + fechaHora[4].ToString();
                    second = fechaHora[6].ToString() + fechaHora[7].ToString();
                }
            }
            else if (fechaHora.Length == 7)
            {
                if (fechaHora[1].ToString() == "/")
                {
                    day = "0" + fechaHora[0].ToString();
                    month = fechaHora[2].ToString() + fechaHora[3].ToString();
                    year = "20" + fechaHora[5].ToString() + fechaHora[6].ToString();
                    hour = "00";
                    minute = "00";
                    second = "00";
                }
                else
                {
                    day = "05";
                    month = "11";
                    year = "2021";
                    hour = "0" + fechaHora[0].ToString();
                    minute = fechaHora[2].ToString() + fechaHora[3].ToString();
                    second = fechaHora[5].ToString() + fechaHora[6].ToString();
                }
            }
            else if (fechaHora.Length == 6)
            {
                day = "0" + fechaHora[0].ToString();
                month = "0" + fechaHora[2].ToString();
                year = "20" + fechaHora[4].ToString() + fechaHora[5].ToString();
                hour = "00";
                minute = "00";
                second = "00";
            }
            else if (fechaHora.Length == 5)
            {
                day = "05";
                month = "11";
                year = "2021";
                hour = fechaHora[0].ToString() + fechaHora[1].ToString();
                minute = fechaHora[3].ToString() + fechaHora[4].ToString();
                second = "00";
            }
            else
            {
                day = "05";
                month = "11";
                year = "2021";
                hour = "0" + fechaHora[0].ToString();
                minute = fechaHora[2].ToString() + fechaHora[3].ToString();
                second = "00";
            }
            fh = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
            */
            return fh;
        }
        public List<Chat> SelectChatsActivosPorCedulaDocente(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatsActivosPorCedulaDocente(ci);
        }
        public List<Chat> SelectChatsActivosPorCedulaAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatsActivosPorCedulaAlumno(ci);
        }
        public Chat SelectChatPorId(int id)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatPorId(id);
        }
        public void CrearChat(SolicitaChat soli)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CrearChat(soli);
        }
        public int StringAId(string cadena)
        {
            char[] aConvertir = cadena.ToCharArray();

            string preId = "";
            for (int x = 0; x < aConvertir.Length; x++)
            {
                if (aConvertir[x] == '0' || aConvertir[x] == '1' || aConvertir[x] == '2' || aConvertir[x] == '3' || aConvertir[x] == '4' || aConvertir[x] == '5' || aConvertir[x] == '6' || aConvertir[x] == '7' || aConvertir[x] == '8' || aConvertir[x] == '9')
                {
                    preId += aConvertir[x];
                }
            }
            return Convert.ToInt32(preId);

        }
        public void CerrarChat()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CerrarChat(this);
        }
        public void CambiarTitulo()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.CambiarTitulo(this);
        }
        public List<Chat> SelectChatsAIngresarPorCedulaAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectChatsAIngresarPorCedulaAlumno(ci);
        }
        public List<Chat> SelectHistorialChatsPorCedulaAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectHistorialChatsPorCedulaAlumno(ci);
        }
        public List<Chat> SelectHistorialChatsPorCedulaDocente(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectHistorialChatsPorCedulaDocente(ci);
        }
    }
}
