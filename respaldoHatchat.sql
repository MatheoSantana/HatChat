-- MySQL dump 10.13  Distrib 5.7.34, for Win64 (x86_64)
--
-- Host: localhost    Database: hatchat
-- ------------------------------------------------------
-- Server version	5.7.34-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrador`
--

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `administrador` (
  `ci` char(8) NOT NULL,
  PRIMARY KEY (`ci`),
  CONSTRAINT `administrador_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `usuario` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
INSERT INTO `administrador` VALUES ('00000000');
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agenda`
--

DROP TABLE IF EXISTS `agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agenda` (
  `idAgenda` int(11) NOT NULL AUTO_INCREMENT,
  `nomDia` enum('Lunes','Martes','Miercoles','Jueves','Viernes','Sabado') NOT NULL,
  `horaInicio` time NOT NULL,
  `horaFin` time NOT NULL,
  `ci` char(8) NOT NULL,
  PRIMARY KEY (`idAgenda`),
  KEY `ci` (`ci`),
  CONSTRAINT `agenda_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `docente` (`ci`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agenda`
--

LOCK TABLES `agenda` WRITE;
/*!40000 ALTER TABLE `agenda` DISABLE KEYS */;
INSERT INTO `agenda` VALUES (1,'Lunes','07:00:00','08:30:00','12314542'),(2,'Martes','07:00:00','07:45:00','12314542'),(3,'Lunes','07:00:00','08:30:00','29993223'),(4,'Martes','07:00:00','07:45:00','29993223'),(5,'Lunes','07:00:00','08:30:00','40111234'),(6,'Martes','07:00:00','07:45:00','40111234');
/*!40000 ALTER TABLE `agenda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alumno` (
  `ci` char(8) NOT NULL,
  PRIMARY KEY (`ci`),
  CONSTRAINT `alumno_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `usuario` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno`
--

LOCK TABLES `alumno` WRITE;
/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES ('51972127'),('52124670'),('52848682');
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignatura`
--

DROP TABLE IF EXISTS `asignatura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignatura` (
  `id` varchar(10) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `anio` int(11) NOT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignatura`
--

LOCK TABLES `asignatura` WRITE;
/*!40000 ALTER TABLE `asignatura` DISABLE KEYS */;
INSERT INTO `asignatura` VALUES ('bdd2','Base de datos II',3,1),('log','Logica',1,1),('mate3','Matematica',3,1),('progds3','Programacion III',3,1),('progdw3','Programacion web',3,1),('progi1','Programacion I',1,1);
/*!40000 ALTER TABLE `asignatura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignaturacursa`
--

DROP TABLE IF EXISTS `asignaturacursa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignaturacursa` (
  `ci` char(8) NOT NULL,
  `idClase` int(11) NOT NULL,
  `orientacion` int(11) NOT NULL,
  `anio` year(4) NOT NULL,
  `asignaturaCursada` varchar(10) NOT NULL,
  `cursando` tinyint(1) NOT NULL,
  PRIMARY KEY (`ci`,`idClase`,`orientacion`,`anio`,`asignaturaCursada`),
  KEY `asignaturaCursada` (`asignaturaCursada`),
  CONSTRAINT `asignaturacursa_ibfk_1` FOREIGN KEY (`ci`, `idClase`, `orientacion`, `anio`) REFERENCES `cursa` (`ci`, `idClase`, `orientacion`, `anio`),
  CONSTRAINT `asignaturacursa_ibfk_2` FOREIGN KEY (`asignaturaCursada`) REFERENCES `contiene` (`idAsig`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignaturacursa`
--

LOCK TABLES `asignaturacursa` WRITE;
/*!40000 ALTER TABLE `asignaturacursa` DISABLE KEYS */;
INSERT INTO `asignaturacursa` VALUES ('51972127',2,2,2021,'bdd2',1),('51972127',2,2,2021,'progdw3',1),('52124670',1,1,2021,'bdd2',1),('52124670',1,1,2021,'progds3',1),('52848682',1,1,2021,'bdd2',1),('52848682',1,1,2021,'progds3',1),('52848682',1,1,2021,'progdw3',1);
/*!40000 ALTER TABLE `asignaturacursa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignaturadictada`
--

DROP TABLE IF EXISTS `asignaturadictada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignaturadictada` (
  `ci` char(8) NOT NULL,
  `idClase` int(11) NOT NULL,
  `orientacion` int(11) NOT NULL,
  `anio` year(4) NOT NULL,
  `asignaturaDictada` varchar(10) NOT NULL,
  `dictando` tinyint(1) NOT NULL,
  PRIMARY KEY (`ci`,`idClase`,`orientacion`,`anio`,`asignaturaDictada`),
  KEY `asignaturaDictada` (`asignaturaDictada`),
  CONSTRAINT `asignaturadictada_ibfk_1` FOREIGN KEY (`ci`, `idClase`, `orientacion`, `anio`) REFERENCES `dicta` (`ci`, `idClase`, `orientacion`, `anio`),
  CONSTRAINT `asignaturadictada_ibfk_2` FOREIGN KEY (`asignaturaDictada`) REFERENCES `contiene` (`idAsig`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignaturadictada`
--

LOCK TABLES `asignaturadictada` WRITE;
/*!40000 ALTER TABLE `asignaturadictada` DISABLE KEYS */;
INSERT INTO `asignaturadictada` VALUES ('12314542',1,1,2021,'progds3',1),('12314542',2,2,2021,'progdw3',1),('29993223',1,1,2021,'progds3',1),('40111234',1,1,2021,'bdd2',1),('40111234',2,2,2021,'bdd2',1);
/*!40000 ALTER TABLE `asignaturadictada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignaturasolicitudclaseal`
--

DROP TABLE IF EXISTS `asignaturasolicitudclaseal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignaturasolicitudclaseal` (
  `idSolicitudClaseAl` int(11) NOT NULL,
  `idClaseAsig` int(11) NOT NULL,
  `oriClaseAsig` int(11) NOT NULL,
  `idAsignatura` varchar(10) NOT NULL,
  `aceptada` tinyint(1) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseAl`,`idClaseAsig`,`oriClaseAsig`,`idAsignatura`),
  KEY `idClaseAsig` (`idClaseAsig`,`oriClaseAsig`),
  KEY `idAsignatura` (`idAsignatura`),
  CONSTRAINT `asignaturasolicitudclaseal_ibfk_1` FOREIGN KEY (`idSolicitudClaseAl`) REFERENCES `solicitudclaseal` (`idSolicitudClaseAl`),
  CONSTRAINT `asignaturasolicitudclaseal_ibfk_2` FOREIGN KEY (`idClaseAsig`, `oriClaseAsig`) REFERENCES `clasesolicitudclaseal` (`idClase`, `oriClase`),
  CONSTRAINT `asignaturasolicitudclaseal_ibfk_3` FOREIGN KEY (`idAsignatura`) REFERENCES `contiene` (`idAsig`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignaturasolicitudclaseal`
--

LOCK TABLES `asignaturasolicitudclaseal` WRITE;
/*!40000 ALTER TABLE `asignaturasolicitudclaseal` DISABLE KEYS */;
INSERT INTO `asignaturasolicitudclaseal` VALUES (1,1,1,'bdd2',1),(1,1,1,'mate3',0),(1,1,1,'progds3',1),(1,1,1,'progdw3',1);
/*!40000 ALTER TABLE `asignaturasolicitudclaseal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignaturasolicitudclasedo`
--

DROP TABLE IF EXISTS `asignaturasolicitudclasedo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignaturasolicitudclasedo` (
  `idSolicitudClaseDo` int(11) NOT NULL,
  `idClaseAsig` int(11) NOT NULL,
  `oriClaseAsig` int(11) NOT NULL,
  `idAsignatura` varchar(10) NOT NULL,
  `aceptada` tinyint(1) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseDo`,`idClaseAsig`,`oriClaseAsig`,`idAsignatura`),
  KEY `idClaseAsig` (`idClaseAsig`,`oriClaseAsig`),
  KEY `idAsignatura` (`idAsignatura`),
  CONSTRAINT `asignaturasolicitudclasedo_ibfk_1` FOREIGN KEY (`idSolicitudClaseDo`) REFERENCES `solicitudclasedo` (`idSolicitudClaseDo`),
  CONSTRAINT `asignaturasolicitudclasedo_ibfk_2` FOREIGN KEY (`idClaseAsig`, `oriClaseAsig`) REFERENCES `clasesolicitudclasedo` (`idClase`, `oriClase`),
  CONSTRAINT `asignaturasolicitudclasedo_ibfk_3` FOREIGN KEY (`idAsignatura`) REFERENCES `contiene` (`idAsig`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignaturasolicitudclasedo`
--

LOCK TABLES `asignaturasolicitudclasedo` WRITE;
/*!40000 ALTER TABLE `asignaturasolicitudclasedo` DISABLE KEYS */;
INSERT INTO `asignaturasolicitudclasedo` VALUES (1,1,1,'bdd2',0),(1,1,1,'mate3',0),(1,1,1,'progds3',1),(1,2,2,'bdd2',0),(1,2,2,'mate3',0),(1,2,2,'progdw3',1);
/*!40000 ALTER TABLE `asignaturasolicitudclasedo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chat`
--

DROP TABLE IF EXISTS `chat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chat` (
  `idChat` int(11) NOT NULL AUTO_INCREMENT,
  `idClase` int(11) NOT NULL,
  `oriClase` int(11) NOT NULL,
  `asignatura` varchar(10) NOT NULL,
  `fecha` date NOT NULL,
  `horaInico` time NOT NULL,
  `horaFin` time DEFAULT NULL,
  `titulo` varchar(60) NOT NULL,
  `activo` tinyint(1) NOT NULL,
  PRIMARY KEY (`idChat`),
  KEY `idClase` (`idClase`),
  KEY `oriClase` (`oriClase`),
  KEY `asignatura` (`asignatura`),
  CONSTRAINT `chat_ibfk_1` FOREIGN KEY (`idClase`) REFERENCES `solicitachat` (`idClase`),
  CONSTRAINT `chat_ibfk_2` FOREIGN KEY (`oriClase`) REFERENCES `clase` (`orientacion`),
  CONSTRAINT `chat_ibfk_3` FOREIGN KEY (`asignatura`) REFERENCES `solicitachat` (`asignatura`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chat`
--

LOCK TABLES `chat` WRITE;
/*!40000 ALTER TABLE `chat` DISABLE KEYS */;
INSERT INTO `chat` VALUES (1,1,1,'bdd2','2021-08-12','11:40:32','12:09:13','Consulta sobre permisos en MySQL',0);
/*!40000 ALTER TABLE `chat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chateaal`
--

DROP TABLE IF EXISTS `chateaal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chateaal` (
  `ci` char(8) NOT NULL,
  `idChat` int(11) NOT NULL,
  `horaEnvioAl` time NOT NULL,
  `contenidoAl` varchar(200) NOT NULL,
  PRIMARY KEY (`ci`,`idChat`,`horaEnvioAl`),
  KEY `idChat` (`idChat`),
  CONSTRAINT `chateaal_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `alumno` (`ci`),
  CONSTRAINT `chateaal_ibfk_2` FOREIGN KEY (`idChat`) REFERENCES `chat` (`idChat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chateaal`
--

LOCK TABLES `chateaal` WRITE;
/*!40000 ALTER TABLE `chateaal` DISABLE KEYS */;
INSERT INTO `chateaal` VALUES ('51972127',1,'11:42:16','¡ Agustin ha ingresado al chat !'),('51972127',1,'11:42:57','jajajajajajaj'),('52124670',1,'11:41:02','¡ Mauro ha ingresado al chat !'),('52124670',1,'11:42:45','Queeeee!! hay escrito de bdd, para cuando es?'),('52124670',1,'11:46:42','Uh la baja'),('52124670',1,'11:48:03','Y having q es? es un comando pero para q sirve'),('52848682',1,'11:05:09','Profe, el chat solo puede ser cerrado por el alumno que lo creo. Digame y yo lo cierro'),('52848682',1,'11:40:32','¡ Palme ha ingresado al chat !'),('52848682',1,'11:41:26','En el pdf de consultas, hay un comando que se llama HAVING, este va para el proximo escrito?'),('52848682',1,'11:49:12','Es como el where pero se usa despues de un group by, y en este se puede funciones. Es una restriccion');
/*!40000 ALTER TABLE `chateaal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chateado`
--

DROP TABLE IF EXISTS `chateado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chateado` (
  `ci` char(8) NOT NULL,
  `idChat` int(11) NOT NULL,
  `horaEnvioDo` time NOT NULL,
  `contenidoDo` varchar(200) NOT NULL,
  PRIMARY KEY (`idChat`,`horaEnvioDo`),
  KEY `ci` (`ci`),
  CONSTRAINT `chateado_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `docente` (`ci`),
  CONSTRAINT `chateado_ibfk_2` FOREIGN KEY (`idChat`) REFERENCES `chat` (`idChat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chateado`
--

LOCK TABLES `chateado` WRITE;
/*!40000 ALTER TABLE `chateado` DISABLE KEYS */;
INSERT INTO `chateado` VALUES ('12314542',1,'11:40:32','¡ Jose ha ingresado al chat !'),('12314542',1,'11:42:10','Si, having va, ya que forma parte de los temas de consultas'),('12314542',1,'11:45:32','El escrito es para el proximo martes, aun tiene una semana para repasar. este mas atento!!'),('12314542',1,'11:50:43','Muy bien matheo!'),('12314542',1,'12:03:58','Chicos voy a cerrar el chat que ya casi es la hora, si alguien tiene alguna otra consulta, este es el momento');
/*!40000 ALTER TABLE `chateado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clase`
--

DROP TABLE IF EXISTS `clase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clase` (
  `idClase` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(4) NOT NULL,
  `anio` int(11) NOT NULL,
  `orientacion` int(11) NOT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idClase`,`orientacion`),
  KEY `orientacion` (`orientacion`),
  CONSTRAINT `clase_ibfk_1` FOREIGN KEY (`orientacion`) REFERENCES `orientacion` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clase`
--

LOCK TABLES `clase` WRITE;
/*!40000 ALTER TABLE `clase` DISABLE KEYS */;
INSERT INTO `clase` VALUES (1,'BA',3,1,NULL),(2,'BB',3,2,NULL);
/*!40000 ALTER TABLE `clase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clasesolicitudclaseal`
--

DROP TABLE IF EXISTS `clasesolicitudclaseal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clasesolicitudclaseal` (
  `idSolicitudClaseAl` int(11) NOT NULL,
  `idClase` int(11) NOT NULL,
  `oriClase` int(11) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseAl`,`idClase`,`oriClase`),
  KEY `idClase` (`idClase`,`oriClase`),
  CONSTRAINT `clasesolicitudclaseal_ibfk_1` FOREIGN KEY (`idSolicitudClaseAl`) REFERENCES `solicitudclaseal` (`idSolicitudClaseAl`),
  CONSTRAINT `clasesolicitudclaseal_ibfk_2` FOREIGN KEY (`idClase`, `oriClase`) REFERENCES `clase` (`idClase`, `orientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clasesolicitudclaseal`
--

LOCK TABLES `clasesolicitudclaseal` WRITE;
/*!40000 ALTER TABLE `clasesolicitudclaseal` DISABLE KEYS */;
INSERT INTO `clasesolicitudclaseal` VALUES (1,1,1);
/*!40000 ALTER TABLE `clasesolicitudclaseal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clasesolicitudclasedo`
--

DROP TABLE IF EXISTS `clasesolicitudclasedo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clasesolicitudclasedo` (
  `idSolicitudClaseDo` int(11) NOT NULL,
  `idClase` int(11) NOT NULL,
  `oriClase` int(11) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseDo`,`idClase`,`oriClase`),
  KEY `idClase` (`idClase`,`oriClase`),
  CONSTRAINT `clasesolicitudclasedo_ibfk_1` FOREIGN KEY (`idSolicitudClaseDo`) REFERENCES `solicitudclasedo` (`idSolicitudClaseDo`),
  CONSTRAINT `clasesolicitudclasedo_ibfk_2` FOREIGN KEY (`idClase`, `oriClase`) REFERENCES `clase` (`idClase`, `orientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clasesolicitudclasedo`
--

LOCK TABLES `clasesolicitudclasedo` WRITE;
/*!40000 ALTER TABLE `clasesolicitudclasedo` DISABLE KEYS */;
INSERT INTO `clasesolicitudclasedo` VALUES (1,1,1),(1,2,2);
/*!40000 ALTER TABLE `clasesolicitudclasedo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contiene`
--

DROP TABLE IF EXISTS `contiene`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contiene` (
  `idAsig` varchar(10) NOT NULL,
  `idOri` int(11) NOT NULL,
  PRIMARY KEY (`idAsig`,`idOri`),
  KEY `idOri` (`idOri`),
  CONSTRAINT `contiene_ibfk_1` FOREIGN KEY (`idAsig`) REFERENCES `asignatura` (`id`),
  CONSTRAINT `contiene_ibfk_2` FOREIGN KEY (`idOri`) REFERENCES `orientacion` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contiene`
--

LOCK TABLES `contiene` WRITE;
/*!40000 ALTER TABLE `contiene` DISABLE KEYS */;
INSERT INTO `contiene` VALUES ('bdd2',1),('mate3',1),('progds3',1),('bdd2',2),('mate3',2),('progdw3',2);
/*!40000 ALTER TABLE `contiene` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursa`
--

DROP TABLE IF EXISTS `cursa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cursa` (
  `ci` char(8) NOT NULL,
  `idClase` int(11) NOT NULL,
  `orientacion` int(11) NOT NULL,
  `anio` year(4) NOT NULL,
  PRIMARY KEY (`ci`,`idClase`,`orientacion`,`anio`),
  KEY `idClase` (`idClase`,`orientacion`),
  CONSTRAINT `cursa_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `alumno` (`ci`),
  CONSTRAINT `cursa_ibfk_2` FOREIGN KEY (`idClase`, `orientacion`) REFERENCES `clase` (`idClase`, `orientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursa`
--

LOCK TABLES `cursa` WRITE;
/*!40000 ALTER TABLE `cursa` DISABLE KEYS */;
INSERT INTO `cursa` VALUES ('52124670',1,1,2021),('52848682',1,1,2021),('51972127',2,2,2021),('52124670',2,2,2021);
/*!40000 ALTER TABLE `cursa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dicta`
--

DROP TABLE IF EXISTS `dicta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dicta` (
  `ci` char(8) NOT NULL,
  `idClase` int(11) NOT NULL,
  `orientacion` int(11) NOT NULL,
  `anio` year(4) NOT NULL,
  PRIMARY KEY (`ci`,`idClase`,`orientacion`,`anio`),
  KEY `idClase` (`idClase`,`orientacion`),
  CONSTRAINT `dicta_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `docente` (`ci`),
  CONSTRAINT `dicta_ibfk_2` FOREIGN KEY (`idClase`, `orientacion`) REFERENCES `clase` (`idClase`, `orientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dicta`
--

LOCK TABLES `dicta` WRITE;
/*!40000 ALTER TABLE `dicta` DISABLE KEYS */;
INSERT INTO `dicta` VALUES ('12314542',1,1,2021),('29993223',1,1,2021),('40111234',1,1,2021),('12314542',2,2,2021),('29993223',2,2,2021),('40111234',2,2,2021);
/*!40000 ALTER TABLE `dicta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docente`
--

DROP TABLE IF EXISTS `docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docente` (
  `ci` char(8) NOT NULL,
  PRIMARY KEY (`ci`),
  CONSTRAINT `docente_ibfk_1` FOREIGN KEY (`ci`) REFERENCES `usuario` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docente`
--

LOCK TABLES `docente` WRITE;
/*!40000 ALTER TABLE `docente` DISABLE KEYS */;
INSERT INTO `docente` VALUES ('12314542'),('29993223'),('40111234');
/*!40000 ALTER TABLE `docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensaje`
--

DROP TABLE IF EXISTS `mensaje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mensaje` (
  `idMensaje` int(11) NOT NULL AUTO_INCREMENT,
  `docente` char(8) NOT NULL,
  `alumno` char(8) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `mensajeAlumno` varchar(500) NOT NULL,
  `estado` enum('realizado','contestado','recibido') NOT NULL,
  `asunto` varchar(60) NOT NULL,
  `mensajeDocente` varchar(500) DEFAULT NULL,
  `fechaHoraDocente` datetime DEFAULT NULL,
  PRIMARY KEY (`idMensaje`),
  KEY `docente` (`docente`),
  CONSTRAINT `mensaje_ibfk_1` FOREIGN KEY (`docente`) REFERENCES `docente` (`ci`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mensaje`
--

LOCK TABLES `mensaje` WRITE;
/*!40000 ALTER TABLE `mensaje` DISABLE KEYS */;
INSERT INTO `mensaje` VALUES (1,'12314542','52848682','2021-06-01 23:34:09','Profe, podria mandar el pdf de metricas?, que me ayudaria un poco mas de material de repaso','contestado','PDF Metricas','Buen dia Matheo, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03 15:12:43');
/*!40000 ALTER TABLE `mensaje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orientacion`
--

DROP TABLE IF EXISTS `orientacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orientacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orientacion`
--

LOCK TABLES `orientacion` WRITE;
/*!40000 ALTER TABLE `orientacion` DISABLE KEYS */;
INSERT INTO `orientacion` VALUES (1,'Desarrollo y soporte',1),(2,'Desarrollo web',1);
/*!40000 ALTER TABLE `orientacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preguntaseguridad`
--

DROP TABLE IF EXISTS `preguntaseguridad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preguntaseguridad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pregSeguridad` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preguntaseguridad`
--

LOCK TABLES `preguntaseguridad` WRITE;
/*!40000 ALTER TABLE `preguntaseguridad` DISABLE KEYS */;
INSERT INTO `preguntaseguridad` VALUES (1,'¿Cuál es el nombre de tu primer mascota?'),(2,'¿En qué calle está ubicado tu primer hogar?'),(3,'¿Cual es tu sabor de helado favorito?');
/*!40000 ALTER TABLE `preguntaseguridad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `responde`
--

DROP TABLE IF EXISTS `responde`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `responde` (
  `idSolicitudModif` int(11) NOT NULL,
  `ci` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudModif`,`ci`),
  KEY `ci` (`ci`),
  CONSTRAINT `responde_ibfk_1` FOREIGN KEY (`idSolicitudModif`) REFERENCES `solicitudmodif` (`idSolicitudModif`),
  CONSTRAINT `responde_ibfk_2` FOREIGN KEY (`ci`) REFERENCES `administrador` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `responde`
--

LOCK TABLES `responde` WRITE;
/*!40000 ALTER TABLE `responde` DISABLE KEYS */;
INSERT INTO `responde` VALUES (1,'00000000');
/*!40000 ALTER TABLE `responde` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respondeclase`
--

DROP TABLE IF EXISTS `respondeclase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `respondeclase` (
  `idSolicitudClaseAl` int(11) NOT NULL,
  `ciAdmin` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseAl`,`ciAdmin`),
  KEY `ciAdmin` (`ciAdmin`),
  CONSTRAINT `respondeclase_ibfk_1` FOREIGN KEY (`idSolicitudClaseAl`) REFERENCES `solicitudclaseal` (`idSolicitudClaseAl`),
  CONSTRAINT `respondeclase_ibfk_2` FOREIGN KEY (`ciAdmin`) REFERENCES `administrador` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respondeclase`
--

LOCK TABLES `respondeclase` WRITE;
/*!40000 ALTER TABLE `respondeclase` DISABLE KEYS */;
INSERT INTO `respondeclase` VALUES (1,'00000000');
/*!40000 ALTER TABLE `respondeclase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respondeclase2`
--

DROP TABLE IF EXISTS `respondeclase2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `respondeclase2` (
  `idSolicitudClaseDo` int(11) NOT NULL,
  `ciAdmin` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseDo`,`ciAdmin`),
  KEY `ciAdmin` (`ciAdmin`),
  CONSTRAINT `respondeclase2_ibfk_1` FOREIGN KEY (`idSolicitudClaseDo`) REFERENCES `solicitudclasedo` (`idSolicitudClaseDo`),
  CONSTRAINT `respondeclase2_ibfk_2` FOREIGN KEY (`ciAdmin`) REFERENCES `administrador` (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respondeclase2`
--

LOCK TABLES `respondeclase2` WRITE;
/*!40000 ALTER TABLE `respondeclase2` DISABLE KEYS */;
INSERT INTO `respondeclase2` VALUES (1,'00000000');
/*!40000 ALTER TABLE `respondeclase2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitachat`
--

DROP TABLE IF EXISTS `solicitachat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `solicitachat` (
  `ciAlumno` char(8) NOT NULL,
  `ciDocente` char(8) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `idClase` int(11) NOT NULL,
  `oriClase` int(11) NOT NULL,
  `asignatura` varchar(10) NOT NULL,
  `pendiente` tinyint(1) NOT NULL,
  PRIMARY KEY (`ciAlumno`,`ciDocente`,`fechaHora`,`idClase`,`oriClase`,`asignatura`),
  KEY `ciDocente` (`ciDocente`),
  KEY `idClase` (`idClase`,`oriClase`),
  KEY `asignatura` (`asignatura`),
  CONSTRAINT `solicitachat_ibfk_1` FOREIGN KEY (`ciAlumno`) REFERENCES `alumno` (`ci`),
  CONSTRAINT `solicitachat_ibfk_2` FOREIGN KEY (`ciDocente`) REFERENCES `docente` (`ci`),
  CONSTRAINT `solicitachat_ibfk_3` FOREIGN KEY (`idClase`, `oriClase`) REFERENCES `clase` (`idClase`, `orientacion`),
  CONSTRAINT `solicitachat_ibfk_4` FOREIGN KEY (`asignatura`) REFERENCES `contiene` (`idAsig`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitachat`
--

LOCK TABLES `solicitachat` WRITE;
/*!40000 ALTER TABLE `solicitachat` DISABLE KEYS */;
INSERT INTO `solicitachat` VALUES ('52848682','12314542','2021-08-12 11:34:09',1,1,'bdd2',0);
/*!40000 ALTER TABLE `solicitachat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudclaseal`
--

DROP TABLE IF EXISTS `solicitudclaseal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `solicitudclaseal` (
  `idSolicitudClaseAl` int(11) NOT NULL AUTO_INCREMENT,
  `fechaHora` datetime NOT NULL,
  `pendiente` tinyint(1) NOT NULL,
  `alumno` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseAl`),
  KEY `alumno` (`alumno`),
  CONSTRAINT `solicitudclaseal_ibfk_1` FOREIGN KEY (`alumno`) REFERENCES `alumno` (`ci`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudclaseal`
--

LOCK TABLES `solicitudclaseal` WRITE;
/*!40000 ALTER TABLE `solicitudclaseal` DISABLE KEYS */;
INSERT INTO `solicitudclaseal` VALUES (1,'2021-03-17 23:34:09',0,'52848682');
/*!40000 ALTER TABLE `solicitudclaseal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudclasedo`
--

DROP TABLE IF EXISTS `solicitudclasedo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `solicitudclasedo` (
  `idSolicitudClaseDo` int(11) NOT NULL AUTO_INCREMENT,
  `fechaHora` datetime NOT NULL,
  `pendiente` tinyint(1) NOT NULL,
  `docente` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudClaseDo`),
  KEY `docente` (`docente`),
  CONSTRAINT `solicitudclasedo_ibfk_1` FOREIGN KEY (`docente`) REFERENCES `docente` (`ci`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudclasedo`
--

LOCK TABLES `solicitudclasedo` WRITE;
/*!40000 ALTER TABLE `solicitudclasedo` DISABLE KEYS */;
INSERT INTO `solicitudclasedo` VALUES (1,'2021-03-16 23:34:09',0,'12314542');
/*!40000 ALTER TABLE `solicitudclasedo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudmodif`
--

DROP TABLE IF EXISTS `solicitudmodif`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `solicitudmodif` (
  `idSolicitudModif` int(11) NOT NULL AUTO_INCREMENT,
  `fechaHora` datetime NOT NULL,
  `contraNueva` varchar(30) NOT NULL,
  `pendiente` tinyint(1) NOT NULL,
  `usuario` char(8) NOT NULL,
  PRIMARY KEY (`idSolicitudModif`,`usuario`),
  KEY `usuario` (`usuario`),
  CONSTRAINT `solicitudmodif_ibfk_1` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`ci`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudmodif`
--

LOCK TABLES `solicitudmodif` WRITE;
/*!40000 ALTER TABLE `solicitudmodif` DISABLE KEYS */;
INSERT INTO `solicitudmodif` VALUES (1,'2021-09-01 23:34:09','AGUSTIN_MIO',0,'52848682'),(2,'2021-09-01 23:34:09','mauro12345',1,'52124670');
/*!40000 ALTER TABLE `solicitudmodif` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `ci` char(8) NOT NULL,
  `apodo` varchar(30) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `contraseña` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `segApellido` varchar(30) DEFAULT NULL,
  `resSeguridad` varchar(30) NOT NULL,
  `foto` mediumblob,
  `activo` tinyint(1) DEFAULT NULL,
  `id` int(11) NOT NULL,
  PRIMARY KEY (`ci`),
  KEY `id` (`id`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`id`) REFERENCES `preguntaseguridad` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('00000000','Administrador','Administrador','L2tpbGwgQG1l','Del','Sistema','Agua granizada',NULL,1,3),('12314542','Jose','Jose','12345678','Alvarez','Gutierrez','coco',NULL,1,3),('29993223','Pepe','Pedro','87654321','Sanachez','Guerra','Trueno',NULL,1,1),('40111234','Alber','Alberto','11111111','Santin','Fierro','Anini',NULL,1,1),('51972127','Agustin','Agustin','agustin1234','Pastorelli','Do Prado','Quichuas',NULL,1,2),('52124670','Mauro','Mauro','mauro1234','Liguori','Arias','Neron',NULL,1,1),('52848682','Palme','Matheo','matheo1234','santana','Honey','Guayabos',NULL,1,2);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-17 15:15:01
