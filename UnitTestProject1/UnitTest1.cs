using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hatchat.Persistencia;
using Hatchat.Logica;
using System;
using System.Drawing;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Alumno al = new Alumno();
            al.Ci = "";
            al.Apodo="";
            al.Nombre= "";
            al.Password = "";
            al.Primer_apellido = "";
            al.Segundo_apellido = "";;
            al.Activo = true;
            al.Preguta_seguridad = 0;
            al.Respuesta_seguridad = "";
            Conexion conexion = new Conexion();
            bool result = al.AltaUsuario();
            Assert.AreEqual(false, result);
            
        }
        public void TestMethod2()
        {
            Alumno al = new Alumno();
            al.Ci = "48420612";
            al.Apodo = "Maru";
            al.Nombre = "Maria";
            al.Password = "maria1234";
            al.Primer_apellido = "Vazquez";
            al.Segundo_apellido = "Sosa";
            al.Activo = true;
            al.Preguta_seguridad = 0;
            al.Respuesta_seguridad = "Pezcaito";
            Conexion conexion = new Conexion();
            bool result = al.AltaUsuario();
            Assert.AreEqual(true, result);

        }
        public void TestMethod3()
        {
            Alumno al = new Alumno();
            al.Ci = "52848682";
            al.Apodo = "Palme";
            al.Nombre = "Matheo";
            al.Password = "matheo1234";
            al.Primer_apellido = "Santana";
            al.Segundo_apellido = "Honey";
            al.Activo = true;
            al.Preguta_seguridad = 2;
            al.Respuesta_seguridad = "Guayabos";
            Conexion conexion = new Conexion();
            bool result = al.AltaUsuario();
            Assert.AreEqual(false, result);

        }
    }
}

