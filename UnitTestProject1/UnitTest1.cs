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
            al.Apodo = "";
            al.Nombre = "";
            al.Password = "";
            al.Primer_apellido = "";
            al.Segundo_apellido = ""; ;
            al.Activo = true;
            al.Preguta_seguridad = 0;
            al.Respuesta_seguridad = "";
            bool result = al.AltaUsuario();
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Alumno al = new Alumno();
            al.Ci = "20039409";
            al.Apodo = "Maru";
            al.Nombre = "Maria";
            al.Password = "maria1234";
            al.Primer_apellido = "Vazquez";
            al.Segundo_apellido = "Sosa";
            al.Activo = true;
            al.Preguta_seguridad = 1;
            al.Respuesta_seguridad = "Pezcaito";
            bool result = al.AltaUsuario();
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void TestMethod4()
        {
            Docente doc = new Docente();
            doc.Ci = "";
            doc.Apodo = "";
            doc.Nombre = "";
            doc.Password = "";
            doc.Primer_apellido = "";
            doc.Segundo_apellido = ""; ;
            doc.Activo = true;
            doc.Preguta_seguridad = 0;
            doc.Respuesta_seguridad = "";
            bool result = doc.AltaUsuario();
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void TestMethod5()
        {
            Docente doc = new Docente();
            doc.Ci = "42432764";
            doc.Apodo = "Maru";
            doc.Nombre = "Maria";
            doc.Password = "maria1234";
            doc.Primer_apellido = "Vazquez";
            doc.Segundo_apellido = "Sosa";
            doc.Activo = true;
            doc.Preguta_seguridad = 2;
            doc.Respuesta_seguridad = "Pezcaito";
            Conexion conexion = new Conexion();
            bool result = doc.AltaUsuario();
            Assert.AreEqual(true, result);

        }
        
 
    }
}

