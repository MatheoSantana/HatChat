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
        protected string ci;
        protected string password;
        protected string nombre;
        protected string primer_apellido;
        protected string segundo_apellido;
        protected byte[] fotoDePerfil;
        protected string apodo;
        protected int pregunta_seguridad;
        protected string respuesta_seguridad;
        protected bool activo;
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
        public Usuario(string ci, string nombre, string primer_apellido, string segundo_apellido, byte[] fotoDePerfil, string apodo, bool activo)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.fotoDePerfil = fotoDePerfil;
            this.apodo = apodo;
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

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (!(byteArrayIn == null))
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                return Image.FromStream(ms);
            }
            else
            {
                if (SelectAdministrador())
                {
                    Image nueva = Image.FromFile("Administrador.png");
                    fotoDePerfil = ImageToByteArray(nueva);
                    return nueva;
                }
                else if (SelectAlumno())
                {
                    Image nueva = Image.FromFile("Alumno.png");
                    fotoDePerfil = ImageToByteArray(nueva);
                    return nueva;
                }
                else if (SelectDocente())
                {
                    Image nueva = Image.FromFile("Docente.png");
                    fotoDePerfil = ImageToByteArray(nueva);
                    return nueva;
                }
                else
                {
                    Image nueva = Image.FromFile("Logo Completa.png");
                    fotoDePerfil = ImageToByteArray(nueva);
                    return nueva;
                }
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            ImageFormat imf = imageIn.RawFormat;
            imageIn.Save(ms, imf);
            return ms.ToArray();
        }
        public bool VerficarCedula(string ci)
        {
            if (ci.Length == 8)
            {
                try
                {
                    int[] nCedula = new int[8];
                    int[] numerosVer = { 2, 9, 8, 7, 6, 3, 4 };
                    int guion = 0;
                    int aux = 0;
                    int suma = 0;
                    string pe = "";
                    for (int x = 0; x < 8; x++)
                    {
                        pe = ci[x].ToString();
                        nCedula[x] = Convert.ToInt32(pe);
                        if (x < 7)
                        {
                            suma += (nCedula[x] * numerosVer[x]);
                        }
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
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    
        public bool NumerosEnStrings(string cadena)
        {
            bool hay = false;
            for (int x = 0; x < cadena.Length; x++)
            {
                if (cadena[x].ToString() == "1" || cadena[x].ToString() == "2" || cadena[x].ToString() == "3" || cadena[x].ToString() == "4" || cadena[x].ToString() == "5" || cadena[x].ToString() == "6" || cadena[x].ToString() == "7" || cadena[x].ToString() == "8" || cadena[x].ToString() == "9" || cadena[x].ToString() == "0")
                {
                    hay = true;
                }
            }
            return hay;
        }
        public bool campoVacio(string cadena)
        {
            return cadena == null || cadena == "";
        }
        public bool sinPregunta(int numero)
        {
            return numero == -1;
        }
        public bool TamañoIncorrecto(string cadena)
        {
            return cadena.Length > 31;
        }
        public bool TamañoMinimoContra(string cadena)
        {
            return cadena.Length < 8;
        }
         
        public bool AltaUsuario()
        {
            bool creado = false;
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if(!(VerficarCedula(ci) && 
                NumerosEnStrings(nombre) && NumerosEnStrings(primer_apellido) && NumerosEnStrings(segundo_apellido) && 
                campoVacio(nombre) && campoVacio(ci) && campoVacio(respuesta_seguridad) && campoVacio(primer_apellido) && campoVacio(segundo_apellido) && sinPregunta(pregunta_seguridad) && campoVacio(password) &&
                TamañoIncorrecto(nombre) && TamañoIncorrecto(primer_apellido) && TamañoIncorrecto(segundo_apellido) && TamañoIncorrecto(password) && TamañoIncorrecto(respuesta_seguridad) && TamañoMinimoContra(password) && ExisteUsuarioCi(Ci)))
            {
                Activo = true;
                apodo = nombre;
                creado = conexion.AltaUsuario(this);
            }
            return creado;
        }
        public Usuario SelectUsuarioCiActivo(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectUsuarioCiActivo(ci);
        }
        public bool ExisteUsuarioCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.ExisteUsuarioCi(ci);
        }
        public bool SelectAlumno()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectAlumno(ci);
            }
            else
            {
                return false;
            }
        }
        public bool SelectDocente()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectDocente(ci);
            }
            else
            {
                return false;
            }
        }
        public bool SelectAdministrador()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectAdministrador(ci);
            }
            else
            {
                return false;
            }
        }
        public bool SelectAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectAlumno(ci);
            }
            else
            {
                return false;
            }
        }
        public bool SelectDocente(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectDocente(ci);
            }
            else
            {
                return false;
            }
        }
        public bool SelectAdministrador(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            if (VerficarCedula(ci))
            {
                return conexion.SelectAdministrador(ci);
            }
            else
            {
                return false;
            }
        }
        public PreguntaSeg SelectPreguntaSeguridad()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectPreguntaSeguridad(ci, pregunta_seguridad);
        }
        public void UpdatePerfil()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.UpdatePerfil(this);
        }
        public void RemoveUsuario()
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            conexion.RemoveUsuario(ci);
        }

        public List<Logica.Docente> SelectDocentesDictandoAAlumno(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectDocentesDictandoAAlumno(ci);
        }
        public List<Agenda> SelectAgendasPorCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectAgendasPorCi(ci);
        }
        public bool SelectDocenteDisponible(string asig, string ci, int clase)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectDocenteDisponible(asig, ci, clase);
        }
        public List<Usuario> SelectParticipantes(int chat)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectParticipantes(chat);
        }
        public Usuario SelectUsuarioCi(string ci)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectUsuarioCi(ci);
        }
        public List<Usuario> SelectParticipantesGrupo(AsignaturaCursa asig)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectParticipantesGrupo(asig);
        }
        public List<Usuario> SelectParticipantesGrupo(AsignaturaDictada asig)
        {
            Persistencia.Conexion conexion = new Persistencia.Conexion();
            return conexion.SelectParticipantesGrupo(asig);
        }
    }
}
