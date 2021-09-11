using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Hatchat.Logica
{
    public class Usuario
    {
        private string ci;
        private string password;
        private string nombre;
        private string primer_apellido;
        private string segundo_apellido;
        private byte[] fotoDePerfil;
        private string apodo;
        private int pregunta_seguridad;
        private string respuesta_seguridad;
        private bool activo;
        public Usuario()
        {
        }
        public Usuario(string ci, string password, string nombre, string primer_apellido, string segundo_apellido, byte[] fotoDePerfil, string apodo, int pregunta_seguridad, string respuesta_seguridad, bool activo)
        {
            this.ci = ci;
            this.password = password;
            this.nombre = nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.fotoDePerfil = fotoDePerfil;
            this.apodo = apodo;
            this.pregunta_seguridad = pregunta_seguridad;
            this.respuesta_seguridad = respuesta_seguridad;
            this.activo = activo;
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Primer_apellido
        {
            get { return primer_apellido; }
            set { primer_apellido = value; }
        }
        public string Segundo_apellido
        {
            get { return segundo_apellido; }
            set { segundo_apellido = value; }
        }
        public byte[] FotoDePerfil
        {
            get { return fotoDePerfil; }
            set { fotoDePerfil = value; }
        }
        public string Apodo
        {
            get { return apodo; }
            set { apodo = value; }
        }
        public int Preguta_seguridad
        {
            get { return pregunta_seguridad; }
            set { pregunta_seguridad = value; }
        }
        public string Respuesta_seguridad
        {
            get { return respuesta_seguridad; }
            set { respuesta_seguridad = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public bool VerficarCedula(string ci)
        {
            
            int[] nCedula = new int[8];
            int guion = 0;
            int aux = 0;
            int suma = 0;
            for (int x = 0; x < nCedula.Length; x++)
            {
                nCedula[x] = Convert.ToInt32(ci[x]);
                suma += (nCedula[x] * nCedula[x]);
            }
            for (int i = 0; i < 10; i++)
            {
                aux = suma + i;
                if (aux % 10 == 0)
                {
                    guion = aux - suma;
                    i = 10;
                }
            }

            if (nCedula[7] == guion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
