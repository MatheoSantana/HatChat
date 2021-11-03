using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Hatchat.Logica
{
    public class Alumno : Usuario
    {

        public Alumno()
        {

        }
        public Alumno(string ci, string nombre, string primer_apellido, string segundo_apellido, byte[] fotoDePerfil, string apodo, bool activo) : base(ci, nombre, primer_apellido, segundo_apellido, fotoDePerfil, apodo, activo)
        {
        }
        public Alumno(string ci, string password, string nombre, string primer_apellido, string segundo_apellido, byte[] fotoDePerfil, string apodo, int pregunta_seguridad, string respuesta_seguridad, bool activo) : base(ci, password, nombre, primer_apellido, segundo_apellido, fotoDePerfil, apodo, pregunta_seguridad, respuesta_seguridad, activo)
        {

        }
        
    }
}
