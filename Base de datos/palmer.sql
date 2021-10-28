
/*------------------------------------------------------------------------------------------------------------------------------*/
/*--------------------------------------------------------------DDL-------------------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/
create database Hatchat;
use Hatchat;

/*drop database hatchat;*/

create table PreguntaSeguridad(
id int auto_increment not null,
pregSeguridad varchar(80) not null,
primary key(id));

create table Usuario(
ci char(8) not null,
apodo varchar(30) not null,
nombre varchar(30) not null,
contrasenia varchar(30) not null,
apellido varchar(30) not null,
segApellido varchar(30),
resSeguridad varchar(30) not null,
foto mediumblob,
activo boolean not null,
id int not null,
primary key(ci),
foreign key(id) references PreguntaSeguridad(id));

create table Alumno(
ci char(8) not null,
primary key(ci),
foreign key(ci) references Usuario(ci));

create table Administrador(
ci char(8) not null,
primary key(ci),
foreign key(ci) references Usuario(ci));

create table Docente(
ci char(8) not null,
primary key(ci),
foreign key(ci) references Usuario(ci));

create table Asignatura(
id varchar(10) not null,
nombre varchar(30) not null,
anio int not null,
activo boolean not null,
primary key(id));

create table Orientacion(
id int auto_increment not null,
nombre varchar(60) not null unique,
activo boolean not null,
primary key(id));

create table Contiene(
idAsig varchar(10) not null,
idOri int not null,
activo boolean not null,
primary key(idAsig,idOri),
foreign key(idAsig) references Asignatura(id),
foreign key(idOri) references Orientacion(id));

create table Clase(
idClase int auto_increment not null,
nombre varchar(4) not null,
anio int not null,
orientacion int not null,
activo boolean not null,
primary key(idClase,orientacion),
foreign key(orientacion) references Orientacion(id));

create table Mensaje(
idMensaje int auto_increment not null,
docente char(8) not null,
alumno char(8) not null,
fechaHora datetime not null,
mensajeAlumno varchar(500) not null,
estado enum("realizado","contestado","recibido") not null,
asunto varchar(60) not null,
mensajeDocente varchar(500),
fechaHoraDocente datetime,
primary key(idMensaje),
foreign key(docente) references Docente(ci));

create table SolicitudModif(
idSolicitudModif int auto_increment not null,
fechaHora datetime not null,
contraNueva varchar(30) not null,
pendiente boolean not null,
aceptada boolean,
usuario char(8) not null,
primary key(idSolicitudModif,usuario),
foreign key(usuario) references Usuario(ci));

create table SolicitudClaseAl(
idSolicitudClaseAl int auto_increment not null,
fechaHora datetime not null,
pendiente boolean not null,
alumno char(8) not null,
primary key(idSolicitudClaseAl),
foreign key(alumno) references Alumno(ci));

create table Cursa(
ci char(8) not null,
idClase int not null,
orientacion int not null,
anio year not null,
primary key(ci,idClase,orientacion,anio),
foreign key(ci) references Alumno(ci),
foreign key(idClase,orientacion) references Clase(idClase,orientacion));

create table asignaturaCursa(
ci char(8) not null,
idClase int not null,
orientacion int not null,
anio year not null,
asignaturaCursada varchar(10) not null,
cursando bool not null,
primary key(ci,idClase,orientacion,anio,asignaturaCursada),
foreign key(ci,idClase,orientacion,anio) references Cursa(ci,idClase,orientacion,anio),
foreign key(asignaturaCursada) references Contiene(idAsig));

create table claseSolicitudClaseAl(
idSolicitudClaseAl int not null,
idClase int not null,
oriClase int not null,
primary key(idSolicitudClaseAl,idClase,OriClase),
foreign key(idSolicitudClaseAl) references SolicitudClaseAl(idSolicitudClaseAl),
foreign key(idClase,oriClase) references Clase(idClase,orientacion));

create table asignaturaSolicitudClaseAl(
idSolicitudClaseAl int not null,
idClaseAsig int not null,
oriClaseAsig int not null,
idAsignatura varchar(10) not null,
aceptada boolean not null,
primary key(idSolicitudClaseAl,idClaseAsig,oriClaseAsig,idAsignatura),
foreign key(idSolicitudClaseAl) references SolicitudClaseAl(idSolicitudClaseAl),
foreign key(idClaseAsig,oriClaseAsig) references claseSolicitudClaseAl(idClase,oriClase),
foreign key(idAsignatura) references Contiene(idAsig));

create table SolicitudClaseDo(
idSolicitudClaseDo int auto_increment not null,
fechaHora datetime not null,
pendiente boolean not null,
docente char(8) not null,
primary key(idSolicitudClaseDo),
foreign key(docente) references Docente(ci));

create table Dicta(
ci char(8) not null,
idClase int not null,
orientacion int not null,
anio year not null,
primary key(ci,idClase,orientacion,anio),
foreign key(ci) references Docente(ci),
foreign key(idClase,orientacion) references Clase(idClase,orientacion));

create table asignaturaDictada(
ci char(8) not null,
idClase int not null,
orientacion int not null,
anio year not null,
asignaturaDictada varchar(10) not null,
dictando bool not null,
primary key(ci,idClase,orientacion,anio,asignaturaDictada),
foreign key(ci,idClase,orientacion,anio) references Dicta(ci,idClase,orientacion,anio),
foreign key(asignaturaDictada) references Contiene(idAsig));

create table Agenda(
idAgenda int auto_increment not null,
nomDia enum("Lunes","Martes","Miercoles","Jueves","Viernes") not null,
horaInicio time not null,
horaFin time not null,
ci char(8) not null,
primary key(idAgenda),
foreign key(ci) references Docente(ci));

create table claseSolicitudClaseDo(
idSolicitudClaseDo int not null,
idClase int not null,
oriClase int not null,
primary key(idSolicitudClaseDo,idClase,oriClase),
foreign key(idSolicitudClaseDo) references SolicitudClaseDo(idSolicitudClaseDo),
foreign key(idClase,oriClase) references Clase(idClase,orientacion));

create table asignaturaSolicitudClaseDo(
idSolicitudClaseDo int not null,
idClaseAsig int not null,
oriClaseAsig int not null,
idAsignatura varchar(10) not null,
aceptada boolean not null,
primary key(idSolicitudClaseDo,idClaseAsig,oriClaseAsig,idAsignatura),
foreign key(idSolicitudClaseDo) references SolicitudClaseDo(idSolicitudClaseDo),
foreign key(idClaseAsig,oriClaseAsig) references claseSolicitudClaseDo(idClase,oriClase),
foreign key(idAsignatura) references Contiene(idAsig));

create table SolicitaChat(
ciAlumno char(8) not null,
ciDocente char(8) not null,
fechaHora datetime not null,
idClase int not null,
oriClase int not null,
asignatura varchar(10) not null,
pendiente boolean not null,
primary key(ciAlumno,ciDocente,fechaHora,idClase,oriClase,asignatura),
foreign key(ciAlumno) references Alumno(ci),
foreign key(ciDocente) references Docente(ci),
foreign key(idClase,oriClase) references Clase(idClase,orientacion),
foreign key(asignatura) references Contiene(idAsig));

create table Responde(
idSolicitudModif int not null,
ci char(8) not null,
primary key(idSolicitudModif,ci),
foreign key(idSolicitudModif) references SolicitudModif(idSolicitudModif),
foreign key(ci) references Administrador(ci));

create table RespondeClaseAl(
idSolicitudClaseAl int not null,
ciAdmin char(8) not null,
primary key(idSolicitudClaseAl,ciAdmin),
foreign key(idSolicitudClaseAl) references SolicitudClaseAl(idSolicitudClaseAl),
foreign key(ciAdmin) references Administrador(ci)); 

create table RespondeClaseDo(
idSolicitudClaseDo int not null,
ciAdmin char(8) not null,
primary key(idSolicitudClaseDo,ciAdmin),
foreign key(idSolicitudClaseDo) references SolicitudClaseDo(idSolicitudClaseDo),
foreign key(ciAdmin) references Administrador(ci));

create table Chat(
idChat int auto_increment not null,
idClase int not null,
oriClase int not null,
asignatura varchar(10) not null,
fecha date not null,
horaInicio time not null,
horaFin time,
titulo varchar(60) not null,
activo boolean not null,
primary key(idChat),
foreign key(idClase) references SolicitaChat(idClase),
foreign key(oriClase) references Clase(orientacion),
foreign key(asignatura) references SolicitaChat(asignatura));

create table ChateaAl(
ci char(8) not null,
idChat int not null,
horaEnvioAl time not null,
contenidoAl varchar(200) not null,
primary key(ci,idChat,horaEnvioAl),
foreign key(ci) references Alumno(ci),
foreign key(idChat) references Chat(idChat));

create table ChateaDo(
ci char(8) not null,
idChat int not null,
horaEnvioDo time not null,
contenidoDo varchar(200) not null,
primary key(idChat,horaEnvioDo),
foreign key(ci) references Docente(ci),
foreign key(idChat) references Chat(idChat));

use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------------------------Datos-de-prueba--------------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*------------------------------------------------------Pregunta-Seguridad------------------------------------------------------*/
insert into PreguntaSeguridad(pregSeguridad)
values('¿Cuál es el nombre de tu primer mascota?');

insert into PreguntaSeguridad(pregSeguridad)
values('¿En qué calle está ubicado tu primer hogar?');

insert into PreguntaSeguridad(pregSeguridad)
values('¿Cual es tu sabor de helado favorito?');

/*------------------------------------------------------Ingreso-Asignaturas-----------------------------------------------------*/
/*-----1er-año-----*/
insert into Asignatura
values ('progi1','Programacion I',1,true);

insert into Asignatura
values ('so1','Sistemas Operativos I',1,true);

insert into Asignatura
values ('log','Logica',1,true);

insert into Asignatura
values ('metdis','Metodos discretos',1,true);

insert into Asignatura
values ('labsop','Laboratorio de Soporte',1,true);

insert into Asignatura
values ('geo1','Geometria I',1,true);

insert into Asignatura
values ('tecelec','Lab. de Tecnologias Electricas',1,true);

insert into Asignatura
values ('mate1','Matematica I',1,true);

insert into Asignatura
values ('ing1','Ingles I',1,true);

insert into Asignatura
values ('hist','Historia',1,true);

insert into Asignatura
values ('bio','Biologia',1,true);

insert into Asignatura
values ('apt1','APT I',1,true);

insert into Asignatura
values ('quim','Quimica',1,true);

/*-----2do-año-----*/
insert into Asignatura
values ('progi2','Programacion II',2,true);

insert into Asignatura
values ('so2','Sistemas Operativos II',2,true);

insert into Asignatura
values ('dsweb1','Diseño Web I',2,true);

insert into Asignatura
values ('bdd1','Base de datos I',2,true);

insert into Asignatura
values ('rds1','Lab de Redes de Area Local I',2,true);

insert into Asignatura
values ('geo2','Geometria II',2,true);

insert into Asignatura
values ('elec','Electronica aplicada',2,true);

insert into Asignatura
values ('mate2','Matematica II',2,true);

insert into Asignatura
values ('ing2','Ingles II',2,true);

insert into Asignatura
values ('eco','Economia',2,true);

insert into Asignatura
values ('apt2','APT II',2,true);

insert into Asignatura
values ('fis','Fisica',2,true);

/*-----3ro-año-----*/
/*-comun-*/
insert into Asignatura
values ('so3','Sistemas Operativos III',3,true);

insert into Asignatura
values ('ada','Analisis y diseño',3,true);

insert into Asignatura
values ('bdd2','Base de datos II',3,true);

insert into Asignatura
values ('forme','Formacion Empresarial',3,true);

insert into Asignatura
values ('mate3','Matematica',3,true);

insert into Asignatura
values ('ing3','Ingles III',3,true);

insert into Asignatura
values ('soci','Sociologia',3,true);

insert into Asignatura
values ('filo','Filosofia',3,true);

/*-Desarrollo-Soporte-*/
insert into Asignatura
values ('progds3','Programacion III',3,true);

insert into Asignatura
values ('proyds','Gestion de Proyecto',3,true);

insert into Asignatura
values ('rds2','Lab de Redes de Area Local II',3,true);

/*-Desarrollo-Web-*/
insert into Asignatura
values ('progdw3','Programacion web',3,true);

insert into Asignatura
values ('proydw','Gestion de Proyectos Web',3,true);

insert into Asignatura
values ('dsweb2','Diseño Web II',3,true);

/*-----------------------------------------------------Ingreso-Orientaciones-----------------------------------------------------*/
insert into Orientacion(nombre, activo)
values ('Informatica', true);

insert into Orientacion(nombre, activo)
values ('Desarrollo y soporte', true);

insert into Orientacion(nombre, activo)
values ('Desarrollo web', true);

/*--------------------------------------------------------Ingreso-Contiene-------------------------------------------------------*/
/*--Informatica--*/
insert into Contiene
values('progi1',1,true);

insert into Contiene
values('so1',1,true);

insert into Contiene
values('log',1,true);

insert into Contiene
values('metdis',1,true);

insert into Contiene
values('labsop',1,true);

insert into Contiene
values('geo1',1,true);

insert into Contiene
values('tecelec',1,true);

insert into Contiene
values('mate1',1,true);

insert into Contiene
values('ing1',1,true);

insert into Contiene
values('hist',1,true);

insert into Contiene
values('bio',1,true);

insert into Contiene
values('apt1',1,true);

insert into Contiene
values('quim',1,true);

insert into Contiene
values('progi2',1,true);

insert into Contiene
values('so2',1,true);

insert into Contiene
values('dsweb1',1,true);

insert into Contiene
values('bdd1',1,true);

insert into Contiene
values('rds1',1,true);

insert into Contiene
values('geo2',1,true);

insert into Contiene
values('elec',1,true);

insert into Contiene
values('mate2',1,true);

insert into Contiene
values('ing2',1,true);

insert into Contiene
values('eco',1,true);

insert into Contiene
values('apt2',1,true);

insert into Contiene
values('fis',1,true);

/*--Desarrollo-y-Soporte--*/
insert into Contiene
values('so3',2,true);

insert into Contiene
values('ada',2,true);

insert into Contiene
values('bdd2',2,true);

insert into Contiene
values('forme',2,true);

insert into Contiene
values('mate3',2,true);

insert into Contiene
values('ing3',2,true);

insert into Contiene
values('soci',2,true);

insert into Contiene
values('filo',2,true);

insert into Contiene
values('progds3',2,true);

insert into Contiene
values('proyds',2,true);

insert into Contiene
values('rds2',2,true);

/*--Desarrollo-Web--*/
insert into Contiene
values('so3',3,true);

insert into Contiene
values('ada',3,true);

insert into Contiene
values('bdd2',3,true);

insert into Contiene
values('forme',3,true);

insert into Contiene
values('mate3',3,true);

insert into Contiene
values('ing3',3,true);

insert into Contiene
values('soci',3,true);

insert into Contiene
values('filo',3,true);

insert into Contiene
values('progdw3',3,true);

insert into Contiene
values('proydw',3,true);

insert into Contiene
values('dsweb2',3,true);

/*---------------------------------------------------------Ingreso-Clase--------------------------------------------------------*/
insert into Clase(nombre,anio,orientacion,activo)
values ('BA',1,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BB',1,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BC',1,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BD',1,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BA',2,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BB',2,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BC',2,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BD',2,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BE',2,1,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BF',2,1,true);


insert into Clase(nombre,anio,orientacion,activo)
values ('BA',3,2,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BB',3,2,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BC',3,2,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BD',3,2,true);


insert into Clase(nombre,anio,orientacion,activo)
values ('BA',3,3,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BB',3,3,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BC',3,3,true);

insert into Clase(nombre,anio,orientacion,activo)
values ('BD',3,3,true);

/*------------------------------------------------------Ingreso-Administrador---------------------------------------------------*/
insert into Usuario
values('00000000','Administrador','Administrador','L2tpbGwgQG1l','Del','Sistema','Agua granizada',null,true,3);

insert into Administrador
values('00000000'); 

/*--------------------------------------------------------Ingreso-Alumnos-------------------------------------------------------*/
/*--Alumno-Matheo--*/
insert into Usuario
values('52848682','Palme','Matheo','matheo1234','Santana','Honey','Guayabos',null,true,2);

insert into Alumno
values ('52848682');

insert into Cursa
values('52848682',10,1,2021);

insert into asignaturaCursa
values('52848682',10,1,2021,'geo2',true);

insert into Cursa
values('52848682',11,2,2021);

insert into asignaturaCursa
values('52848682',11,2,2021,'so3',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'ada',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'forme',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'soci',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'filo',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('52848682',11,2,2021,'rds2',true);

/*--Alumno-Mauro--*/
insert into Usuario
values('52124670','Mauro','Mauro','mauro1234','Liguori','Arias','Neron',null,true,1);

insert into Alumno
values ('52124670');

insert into Cursa
values('52124670',10,1,2021);

insert into asignaturaCursa
values('52124670',10,1,2021,'geo2',true);

insert into Cursa
values('52124670',11,2,2021);

insert into asignaturaCursa
values('52124670',11,2,2021,'so3',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'ada',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'forme',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'soci',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'filo',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('52124670',11,2,2021,'rds2',true);

/*--Alumno-Agus--*/
insert into Usuario
values('51972127','Agustin','Agustin','agustin1234','Pastorelli','Do Prado','Quichuas',null,true,2);

insert into Alumno
values ('51972127');

insert into Cursa
values('51972127',10,1,2021);

insert into asignaturaCursa
values('51972127',10,1,2021,'geo2',true);

insert into Cursa
values('51972127',11,2,2021);

insert into asignaturaCursa
values('51972127',11,2,2021,'so3',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'ada',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'forme',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'soci',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'filo',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('51972127',11,2,2021,'rds2',true);

/*--Alumno-3--*/
insert into Usuario
values('50003002','Andres','Andres','Andres1234','Alvarez','','Chocolate',null,true,3);

insert into Alumno
values ('50003002');

insert into Cursa
values('50003002',11,2,2021);

insert into asignaturaCursa
values('50003002',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50003002',11,2,2021,'rds2',true);

/*--Alumno-4--*/
insert into Usuario
values('50004006','Cristiano','Cristiano','Cristiano1234','Andrade','','Chocolate',null,true,3);

insert into Alumno
values ('50004006');

insert into Cursa
values('50004006',11,2,2021);

insert into asignaturaCursa
values('50004006',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50004006',11,2,2021,'rds2',true);

/*--Alumno-5--*/
insert into Usuario
values('50005000','Gerard','Gerard','Gerard1234','Castillo','','Chocolate',null,true,3);

insert into Alumno
values ('50005000');

insert into Cursa
values('50005000',11,2,2021);

insert into asignaturaCursa
values('50005000',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50005000',11,2,2021,'rds2',true);

/*--Alumno-6--*/
insert into Usuario
values('50006004','Isabella','Isabella','Isabella1234','Benítez','','Chocolate',null,true,3);

insert into Alumno
values ('50006004');

insert into Cursa
values('50006004',11,2,2021);

insert into asignaturaCursa
values('50006004',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50006004',11,2,2021,'rds2',true);

/*--Alumno-7--*/
insert into Usuario
values('50007008','Martina','Martina','Martina1234','Castro','','Chocolate',null,true,3);

insert into Alumno
values ('50007008');

insert into Cursa
values('50007008',11,2,2021);

insert into asignaturaCursa
values('50007008',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50007008',11,2,2021,'rds2',true);

/*--Alumno-8--*/
insert into Usuario
values('50008002','Benjamín','Benjamín','Benjamín1234','Contreras','','Chocolate',null,true,3);

insert into Alumno
values ('50008002');

insert into Cursa
values('50008002',11,2,2021);

insert into asignaturaCursa
values('50008002',11,2,2021,'so3',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'ada',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'forme',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'mate3',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'ing3',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'soci',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'filo',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'progds3',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'proyds',true);

insert into asignaturaCursa
values('50008002',11,2,2021,'rds2',true);

/*------BBds------*/
/*--Alumno-9--*/
insert into Usuario
values('50009006','Martina','Martina','Martina1234','De León','','Chocolate',null,true,3);

insert into Alumno
values ('50009006');

insert into Cursa
values('50009006',12,2,2021);

insert into asignaturaCursa
values('50009006',12,2,2021,'so3',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'ada',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'forme',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'mate3',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'ing3',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'soci',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'filo',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'progds3',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'proyds',true);

insert into asignaturaCursa
values('50009006',12,2,2021,'rds2',true);

/*--Alumno-10--*/
insert into Usuario
values('50010003','Bautista','Bautista','Bautista1234','Díaz','','Chocolate',null,true,3);

insert into Alumno
values ('50010003');

insert into Cursa
values('50010003',12,2,2021);

insert into asignaturaCursa
values('50010003',12,2,2021,'so3',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'ada',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'forme',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'mate3',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'ing3',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'soci',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'filo',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'progds3',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'proyds',true);

insert into asignaturaCursa
values('50010003',12,2,2021,'rds2',true);

/*--Alumno-11--*/
insert into Usuario
values('50011007','Catalina','Catalina','Catalina1234','Duarte','','Chocolate',null,true,3);

insert into Alumno
values ('50011007');

insert into Cursa
values('50011007',12,2,2021);

insert into asignaturaCursa
values('50011007',12,2,2021,'so3',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'ada',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'forme',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'mate3',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'ing3',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'soci',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'filo',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'progds3',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'proyds',true);

insert into asignaturaCursa
values('50011007',12,2,2021,'rds2',true);

/*--Alumno-12--*/
insert into Usuario
values('50012001','Felipe','Felipe','Felipe1234','Espinoza','','Chocolate',null,true,3);

insert into Alumno
values ('50012001');

insert into Cursa
values('50012001',12,2,2021);

insert into asignaturaCursa
values('50012001',12,2,2021,'so3',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'ada',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'forme',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'mate3',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'ing3',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'soci',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'filo',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'progds3',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'proyds',true);

insert into asignaturaCursa
values('50012001',12,2,2021,'rds2',true);

/*------BCds------*/
/*--Alumno-13--*/
insert into Usuario
values('50013005','Sofía','Sofía','Sofía1234','Fernández','','Chocolate',null,true,3);

insert into Alumno
values ('50013005');

insert into Cursa
values('50013005',13,2,2021);

insert into asignaturaCursa
values('50013005',13,2,2021,'so3',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'ada',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'forme',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'mate3',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'ing3',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'soci',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'filo',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'progds3',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'proyds',true);

insert into asignaturaCursa
values('50013005',13,2,2021,'rds2',true);

/*--Alumno-13--*/
insert into Usuario
values('50014009','Valentino','Valentino','Valentino1234','Flores','','Chocolate',null,true,3);

insert into Alumno
values ('50014009');

insert into Cursa
values('50014009',13,2,2021);

insert into asignaturaCursa
values('50014009',13,2,2021,'so3',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'ada',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'forme',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'mate3',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'ing3',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'soci',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'filo',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'progds3',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'proyds',true);

insert into asignaturaCursa
values('50014009',13,2,2021,'rds2',true);

/*--Alumno-15--*/
insert into Usuario
values('50015003','Olivia','Olivia','Olivia1234','García','','Chocolate',null,true,3);

insert into Alumno
values ('50015003');

insert into Cursa
values('50015003',13,2,2021);

insert into asignaturaCursa
values('50015003',13,2,2021,'so3',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'ada',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'forme',true);
#
insert into asignaturaCursa
values('50015003',13,2,2021,'mate3',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'ing3',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'soci',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'filo',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'progds3',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'proyds',true);

insert into asignaturaCursa
values('50015003',13,2,2021,'rds2',true);

/*--Alumno-16--*/
insert into Usuario
values('50016007','Benicio','Benicio','Benicio1234','Giménez','','Chocolate',null,true,3);

insert into Alumno
values ('50016007');

insert into Cursa
values('50016007',13,2,2021);

insert into asignaturaCursa
values('50016007',13,2,2021,'so3',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'ada',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'forme',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'mate3',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'ing3',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'soci',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'filo',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'progds3',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'proyds',true);

insert into asignaturaCursa
values('50016007',13,2,2021,'rds2',true);

/*------BDds------*/
/*--Alumno-17--*/
insert into Usuario
values('50017001','Emma','Emma','Emma1234','Gómez','','Chocolate',null,true,3);

insert into Alumno
values ('50017001');

insert into Cursa
values('50017001',14,2,2021);

insert into asignaturaCursa
values('50017001',14,2,2021,'so3',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'ada',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'forme',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'mate3',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'ing3',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'soci',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'filo',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'progds3',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'proyds',true);

insert into asignaturaCursa
values('50017001',14,2,2021,'rds2',true);

/*--Alumno-18--*/
insert into Usuario
values('50018005','Benicio','Benicio','Benicio1234','Gonzales','','Chocolate',null,true,3);

insert into Alumno
values ('50018005');

insert into Cursa
values('50018005',14,2,2021);

insert into asignaturaCursa
values('50018005',14,2,2021,'so3',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'ada',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'forme',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'mate3',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'ing3',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'soci',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'filo',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'progds3',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'proyds',true);

insert into asignaturaCursa
values('50018005',14,2,2021,'rds2',true);

/*--Alumno-19--*/
insert into Usuario
values('50019009','Delfina','Delfina','Delfina1234','González','','Chocolate',null,true,3);

insert into Alumno
values ('50019009');

insert into Cursa
values('50019009',14,2,2021);

insert into asignaturaCursa
values('50019009',14,2,2021,'so3',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'ada',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'forme',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'mate3',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'ing3',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'soci',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'filo',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'progds3',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'proyds',true);

insert into asignaturaCursa
values('50019009',14,2,2021,'rds2',true);

/*--Alumno-20--*/
insert into Usuario
values('50020006','Joaquín','Joaquín','Joaquín1234','Gutiérrez','','Chocolate',null,true,3);

insert into Alumno
values ('50020006');

insert into Cursa
values('50020006',14,2,2021);

insert into asignaturaCursa
values('50020006',14,2,2021,'so3',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'ada',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'bdd2',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'forme',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'mate3',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'ing3',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'soci',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'filo',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'progds3',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'proyds',true);

insert into asignaturaCursa
values('50020006',14,2,2021,'rds2',true);

/*------BAdw------*/
/*--Alumno-21--*/
insert into Usuario
values('50021000','Lorenzo','Lorenzo','Lorenzo1234','Gonzales','','Chocolate',null,true,3);

insert into Alumno
values ('50021000');

insert into Cursa
values('50021000',15,3,2021);

insert into asignaturaCursa
values('50021000',15,3,2021,'so3',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'ada',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'forme',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'mate3',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'ing3',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'soci',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'filo',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'proydw',true);

insert into asignaturaCursa
values('50021000',15,3,2021,'dsweb2',true);

/*--Alumno-22--*/
insert into Usuario
values('50022004','Delfina','Delfina','Delfina1234','Hernández','','Chocolate',null,true,3);

insert into Alumno
values ('50022004');

insert into Cursa
values('50022004',15,3,2021);

insert into asignaturaCursa
values('50022004',15,3,2021,'so3',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'ada',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'forme',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'mate3',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'ing3',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'soci',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'filo',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'proydw',true);

insert into asignaturaCursa
values('50022004',15,3,2021,'dsweb2',true);

/*--Alumno-23--*/
insert into Usuario
values('50023008','Santino','Santino','Santino1234','Jiménez','','Chocolate',null,true,3);

insert into Alumno
values ('50023008');

insert into Cursa
values('50023008',15,3,2021);

insert into asignaturaCursa
values('50023008',15,3,2021,'so3',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'ada',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'forme',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'mate3',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'ing3',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'soci',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'filo',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'proydw',true);

insert into asignaturaCursa
values('50023008',15,3,2021,'dsweb2',true);

/*--Alumno-24--*/
insert into Usuario
values('50024002','Emilia','Emilia','Emilia1234','López','','Chocolate',null,true,3);

insert into Alumno
values ('50024002');

insert into Cursa
values('50024002',15,3,2021);

insert into asignaturaCursa
values('50024002',15,3,2021,'so3',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'ada',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'forme',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'mate3',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'ing3',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'soci',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'filo',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'proydw',true);

insert into asignaturaCursa
values('50024002',15,3,2021,'dsweb2',true);

/*------BBdw------*/
/*--Alumno-25--*/
insert into Usuario
values('50025006','Juan Ignacio','Juan Ignacio','Juan1234','Mamani','','Chocolate',null,true,3);

insert into Alumno
values ('50025006');

insert into Cursa
values('50025006',16,3,2021);

insert into asignaturaCursa
values('50025006',16,3,2021,'so3',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'ada',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'forme',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'mate3',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'ing3',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'soci',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'filo',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'proydw',true);

insert into asignaturaCursa
values('50025006',16,3,2021,'dsweb2',true);

/*--Alumno-26--*/
insert into Usuario
values('50026000','Francesca','Francesca','Francesca1234','Martínez','','Chocolate',null,true,3);

insert into Alumno
values ('50026000');

insert into Cursa
values('50026000',16,3,2021);

insert into asignaturaCursa
values('50026000',16,3,2021,'so3',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'ada',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'forme',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'mate3',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'ing3',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'soci',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'filo',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'proydw',true);

insert into asignaturaCursa
values('50026000',16,3,2021,'dsweb2',true);

/*--Alumno-27--*/
insert into Usuario
values('50027004','Mateo','Mateo','Mateo1234','Mejía','','Chocolate',null,true,3);

insert into Alumno
values ('50027004');

insert into Cursa
values('50027004',16,3,2021);

insert into asignaturaCursa
values('50027004',16,3,2021,'so3',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'ada',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'forme',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'mate3',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'ing3',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'soci',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'filo',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'proydw',true);

insert into asignaturaCursa
values('50027004',16,3,2021,'dsweb2',true);

/*--Alumno-28--*/
insert into Usuario
values('50028008','Valentina','Valentina','Valentina1234','Mora','','Chocolate',null,true,3);

insert into Alumno
values ('50028008');

insert into Cursa
values('50028008',16,3,2021);

insert into asignaturaCursa
values('50028008',16,3,2021,'so3',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'ada',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'forme',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'mate3',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'ing3',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'soci',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'filo',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'proydw',true);

insert into asignaturaCursa
values('50028008',16,3,2021,'dsweb2',true);

/*------BCdw------*/
/*--Alumno-29--*/
insert into Usuario
values('50029002','Francisco','Francisco','Francisco1234','Morales','','Chocolate',null,true,3);

insert into Alumno
values ('50029002');

insert into Cursa
values('50029002',17,3,2021);

insert into asignaturaCursa
values('50029002',17,3,2021,'so3',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'ada',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'forme',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'mate3',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'ing3',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'soci',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'filo',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'proydw',true);

insert into asignaturaCursa
values('50029002',17,3,2021,'dsweb2',true);

/*--Alumno-30--*/
insert into Usuario
values('50030009','Valentina','Valentina','Valentina1234','Moreno','','Chocolate',null,true,3);

insert into Alumno
values ('50030009');

insert into Cursa
values('50030009',17,3,2021);

insert into asignaturaCursa
values('50030009',17,3,2021,'so3',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'ada',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'forme',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'mate3',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'ing3',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'soci',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'filo',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'proydw',true);

insert into asignaturaCursa
values('50030009',17,3,2021,'dsweb2',true);

/*--Alumno-31--*/
insert into Usuario
values('50031003','Thiago','Thiago','Thiago1234','Muñoz','','Chocolate',null,true,3);

insert into Alumno
values ('50031003');

insert into Cursa
values('50031003',17,3,2021);

insert into asignaturaCursa
values('50031003',17,3,2021,'so3',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'ada',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'forme',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'mate3',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'ing3',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'soci',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'filo',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'proydw',true);

insert into asignaturaCursa
values('50031003',17,3,2021,'dsweb2',true);

/*--Alumno-32--*/
insert into Usuario
values('50032007','Benjamín','Benjamín','Benjamín1234','Pereira','','Chocolate',null,true,3);

insert into Alumno
values ('50032007');

insert into Cursa
values('50032007',17,3,2021);

insert into asignaturaCursa
values('50032007',17,3,2021,'so3',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'ada',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'forme',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'mate3',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'ing3',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'soci',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'filo',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'proydw',true);

insert into asignaturaCursa
values('50032007',17,3,2021,'dsweb2',true);

/*------BDdw------*/
/*--Alumno-33--*/
insert into Usuario
values('50033001','Victoria','Victoria','Victoria1234','Pérez','','Chocolate',null,true,3);

insert into Alumno
values ('50033001');

insert into Cursa
values('50033001',18,3,2021);

insert into asignaturaCursa
values('50033001',18,3,2021,'so3',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'ada',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'forme',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'mate3',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'ing3',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'soci',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'filo',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'proydw',true);

insert into asignaturaCursa
values('50033001',18,3,2021,'dsweb2',true);

/*--Alumno-34--*/
insert into Usuario
values('50034005','Santiago','Santiago','Santiago1234','Pineda','','Chocolate',null,true,3);

insert into Alumno
values('50034005');

insert into Cursa
values('50034005',18,3,2021);

insert into asignaturaCursa
values('50034005',18,3,2021,'so3',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'ada',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'forme',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'mate3',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'ing3',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'soci',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'filo',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'proydw',true);

insert into asignaturaCursa
values('50034005',18,3,2021,'dsweb2',true);

/*--Alumno-35--*/
insert into Usuario
values('50034009','Victoria','Victoria','Victoria1234','Portillo','','Chocolate',null,true,3);

insert into Alumno
values ('50034009');

insert into Cursa
values('50034009',18,3,2021);

insert into asignaturaCursa
values('50034009',18,3,2021,'so3',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'ada',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'forme',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'mate3',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'ing3',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'soci',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'filo',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'proydw',true);

insert into asignaturaCursa
values('50034009',18,3,2021,'dsweb2',true);

/*--Alumno-36--*/
insert into Usuario
values('50036003','Agustín','Agustín','Agustín1234','Quispe','','Chocolate',null,true,3);

insert into Alumno
values ('50036003');

insert into Cursa
values('50036003',18,3,2021);

insert into asignaturaCursa
values('50036003',18,3,2021,'so3',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'ada',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'bdd2',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'forme',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'mate3',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'ing3',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'soci',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'filo',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'progdw3',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'proydw',true);

insert into asignaturaCursa
values('50036003',18,3,2021,'dsweb2',true);

/*------BA1i------*/
/*--Alumno-37--*/
insert into Usuario
values('50037007','Tomás','Tomás','Tomás1234','Ramírez','','Chocolate',null,true,3);

insert into Alumno
values('50037007');

insert into Cursa
values('50037007',1,1,2021);

insert into asignaturaCursa
values('50037007',1,1,2021,'progi1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'so1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'log',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'metdis',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'labsop',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'geo1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'mate1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'ing1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'hist',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'bio',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'apt1',true);

insert into asignaturaCursa
values('50037007',1,1,2021,'quim',true);

/*--Alumno-38--*/
insert into Usuario
values('50038001','Alma','Alma','Alma1234','Reyes','','Chocolate',null,true,3);

insert into Alumno
values('50038001');

insert into Cursa
values('50038001',1,1,2021);

insert into asignaturaCursa
values('50038001',1,1,2021,'progi1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'so1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'log',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'metdis',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'labsop',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'geo1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'mate1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'ing1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'hist',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'bio',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'apt1',true);

insert into asignaturaCursa
values('50038001',1,1,2021,'quim',true);

/*--Alumno-39--*/
insert into Usuario
values('50039005','Juana','Juana','Juana1234','Rivas','','Chocolate',null,true,3);

insert into Alumno
values('50039005');

insert into Cursa
values('50039005',1,1,2021);

insert into asignaturaCursa
values('50039005',1,1,2021,'progi1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'so1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'log',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'metdis',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'labsop',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'geo1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'mate1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'ing1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'hist',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'bio',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'apt1',true);

insert into asignaturaCursa
values('50039005',1,1,2021,'quim',true);

/*--Alumno-40--*/
insert into Usuario
values('50040002','Julieta','Julieta','Julieta1234','Rivera','','Chocolate',null,true,3);

insert into Alumno
values('50040002');

insert into Cursa
values('50040002',1,1,2021);

insert into asignaturaCursa
values('50040002',1,1,2021,'progi1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'so1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'log',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'metdis',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'labsop',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'geo1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'mate1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'ing1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'hist',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'bio',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'apt1',true);

insert into asignaturaCursa
values('50040002',1,1,2021,'quim',true);

/*------BB1i------*/
/*--Alumno-41--*/
insert into Usuario
values('50041006','Morena','Morena','Morena1234','Rodríguez','','Chocolate',null,true,3);

insert into Alumno
values('50041006');

insert into Cursa
values('50041006',2,1,2021);

insert into asignaturaCursa
values('50041006',2,1,2021,'progi1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'so1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'log',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'metdis',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'labsop',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'geo1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'mate1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'ing1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'hist',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'bio',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'apt1',true);

insert into asignaturaCursa
values('50041006',2,1,2021,'quim',true);

/*--Alumno-42--*/
insert into Usuario
values('50042000','Josefina','Josefina','Josefina1234','Rojas','','Chocolate',null,true,3);

insert into Alumno
values('50042000');

insert into Cursa
values('50042000',2,1,2021);

insert into asignaturaCursa
values('50042000',2,1,2021,'progi1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'so1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'log',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'metdis',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'labsop',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'geo1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'mate1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'ing1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'hist',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'bio',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'apt1',true);

insert into asignaturaCursa
values('50042000',2,1,2021,'quim',true);

/*--Alumno-43--*/
insert into Usuario
values('50043004','Juan Carlos','Juan Carlos','Juan1234','Salazar','','Chocolate',null,true,3);

insert into Alumno
values('50043004');

insert into Cursa
values('50043004',2,1,2021);

insert into asignaturaCursa
values('50043004',2,1,2021,'progi1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'so1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'log',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'metdis',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'labsop',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'geo1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'mate1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'ing1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'hist',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'bio',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'apt1',true);

insert into asignaturaCursa
values('50043004',2,1,2021,'quim',true);

/*--Alumno-44--*/
insert into Usuario
values('50044008','Martha','Martha','Martha1234','Sánchez','','Chocolate',null,true,3);

insert into Alumno
values('50044008');

insert into Cursa
values('50044008',2,1,2021);

insert into asignaturaCursa
values('50044008',2,1,2021,'progi1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'so1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'log',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'metdis',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'labsop',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'geo1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'mate1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'ing1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'hist',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'bio',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'apt1',true);

insert into asignaturaCursa
values('50044008',2,1,2021,'quim',true);

/*------BC1i------*/
/*--Alumno-45--*/
insert into Usuario
values('50045002','José Luis','José Luis','José1234','Santana','','Chocolate',null,true,3);

insert into Alumno
values('50045002');

insert into Cursa
values('50045002',3,1,2021);

insert into asignaturaCursa
values('50045002',3,1,2021,'progi1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'so1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'log',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'metdis',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'labsop',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'geo1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'mate1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'ing1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'hist',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'bio',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'apt1',true);

insert into asignaturaCursa
values('50045002',3,1,2021,'quim',true);

/*--Alumno-46--*/
insert into Usuario
values('50046006','Roxana','Roxana','Roxana1234','Santos','','Chocolate',null,true,3);

insert into Alumno
values('50046006');

insert into Cursa
values('50046006',3,1,2021);

insert into asignaturaCursa
values('50046006',3,1,2021,'progi1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'so1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'log',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'metdis',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'labsop',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'geo1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'mate1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'ing1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'hist',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'bio',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'apt1',true);

insert into asignaturaCursa
values('50046006',3,1,2021,'quim',true);

/*--Alumno-47--*/
insert into Usuario
values('50047000','Marco','Marco','Marco1234','Silva','','Chocolate',null,true,3);

insert into Alumno
values('50047000');

insert into Cursa
values('50047000',3,1,2021);

insert into asignaturaCursa
values('50047000',3,1,2021,'progi1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'so1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'log',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'metdis',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'labsop',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'geo1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'mate1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'ing1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'hist',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'bio',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'apt1',true);

insert into asignaturaCursa
values('50047000',3,1,2021,'quim',true);

/*--Alumno-48--*/
insert into Usuario
values('50048004','Ana María','Ana María','Ana1234','Sosa','','Chocolate',null,true,3);

insert into Alumno
values('50048004');

insert into Cursa
values('50048004',3,1,2021);

insert into asignaturaCursa
values('50048004',3,1,2021,'progi1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'so1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'log',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'metdis',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'labsop',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'geo1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'mate1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'ing1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'hist',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'bio',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'apt1',true);

insert into asignaturaCursa
values('50048004',3,1,2021,'quim',true);

/*------BD1i------*/
/*--Alumno-49--*/
insert into Usuario
values('50049008','Antonio','Antonio','Antonio1234','Soto','','Chocolate',null,true,3);

insert into Alumno
values('50049008');

insert into Cursa
values('50049008',4,1,2021);

insert into asignaturaCursa
values('50049008',4,1,2021,'progi1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'so1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'log',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'metdis',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'labsop',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'geo1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'mate1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'ing1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'hist',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'bio',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'apt1',true);

insert into asignaturaCursa
values('50049008',4,1,2021,'quim',true);

/*--Alumno-50--*/
insert into Usuario
values('50050005','Elizabeth','Elizabeth','Elizabeth1234','Torres','','Chocolate',null,true,3);

insert into Alumno
values('50050005');

insert into Cursa
values('50050005',4,1,2021);

insert into asignaturaCursa
values('50050005',4,1,2021,'progi1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'so1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'log',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'metdis',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'labsop',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'geo1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'mate1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'ing1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'hist',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'bio',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'apt1',true);

insert into asignaturaCursa
values('50050005',4,1,2021,'quim',true);

/*--Alumno-51--*/
insert into Usuario
values('50051009','Miguel Ángel','Miguel Ángel','Miguel1234','Vargas','','Chocolate',null,true,3);

insert into Alumno
values('50051009');

insert into Cursa
values('50051009',4,1,2021);

insert into asignaturaCursa
values('50051009',4,1,2021,'progi1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'so1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'log',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'metdis',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'labsop',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'geo1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'mate1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'ing1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'hist',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'bio',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'apt1',true);

insert into asignaturaCursa
values('50051009',4,1,2021,'quim',true);

/*--Alumno-52--*/
insert into Usuario
values('50052003','Sonia','Sonia','Sonia1234','Vera','','Chocolate',null,true,3);

insert into Alumno
values('50052003');

insert into Cursa
values('50052003',4,1,2021);

insert into asignaturaCursa
values('50052003',4,1,2021,'progi1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'so1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'log',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'metdis',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'labsop',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'geo1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'tecelec',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'mate1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'ing1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'hist',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'bio',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'apt1',true);

insert into asignaturaCursa
values('50052003',4,1,2021,'quim',true);

/*------BA2i------*/
/*--Alumno-53--*/
insert into Usuario
values('50053007','Juan','Juan','Juan1234','Villalba','','Chocolate',null,true,3);

insert into Alumno
values('50053007');

insert into Cursa
values('50053007',5,1,2021);

insert into asignaturaCursa
values('50053007',5,1,2021,'progi2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'so2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'rds1',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'geo2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'elec',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'mate2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'ing2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'eco',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'apt2',true);

insert into asignaturaCursa
values('50053007',5,1,2021,'fis',true);

/*--Alumno-54--*/
insert into Usuario
values('50054001','Juana','Juana','Juana1234','Zambrano','','Chocolate',null,true,3);

insert into Alumno
values('50054001');

insert into Cursa
values('50054001',5,1,2021);

insert into asignaturaCursa
values('50054001',5,1,2021,'progi2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'so2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'rds1',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'geo2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'elec',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'mate2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'ing2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'eco',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'apt2',true);

insert into asignaturaCursa
values('50054001',5,1,2021,'fis',true);

/*--Alumno-55--*/
insert into Usuario
values('50055005','Mario','Mario','Mario1234','Quispe','','Chocolate',null,true,3);

insert into Alumno
values('50055005');

insert into Cursa
values('50055005',5,1,2021);

insert into asignaturaCursa
values('50055005',5,1,2021,'progi2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'so2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'rds1',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'geo2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'elec',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'mate2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'ing2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'eco',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'apt2',true);

insert into asignaturaCursa
values('50055005',5,1,2021,'fis',true);

/*--Alumno-56--*/
insert into Usuario
values('50056009','Patricia','Patricia','Patricia1234','Vargas','','Chocolate',null,true,3);

insert into Alumno
values('50056009');

insert into Cursa
values('50056009',5,1,2021);

insert into asignaturaCursa
values('50056009',5,1,2021,'progi2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'so2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'rds1',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'geo2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'elec',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'mate2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'ing2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'eco',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'apt2',true);

insert into asignaturaCursa
values('50056009',5,1,2021,'fis',true);

/*------BB2i------*/
/*--Alumno-53--*/
insert into Usuario
values('50057003','Fernando','Fernando','Fernando1234','Fernandez','','Chocolate',null,true,3);

insert into Alumno
values('50057003');

insert into Cursa
values('50057003',6,1,2021);

insert into asignaturaCursa
values('50057003',6,1,2021,'progi2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'so2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'rds1',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'geo2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'elec',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'mate2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'ing2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'eco',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'apt2',true);

insert into asignaturaCursa
values('50057003',6,1,2021,'fis',true);

/*--Alumno-58--*/
insert into Usuario
values('50058007','Lidia','Lidia','Lidia1234','Garcia','','Chocolate',null,true,3);

insert into Alumno
values('50058007');

insert into Cursa
values('50058007',6,1,2021);

insert into asignaturaCursa
values('50058007',6,1,2021,'progi2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'so2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'rds1',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'geo2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'elec',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'mate2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'ing2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'eco',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'apt2',true);

insert into asignaturaCursa
values('50058007',6,1,2021,'fis',true);

/*--Alumno-59--*/
insert into Usuario
values('50059001','Víctor Hugo','Víctor Hugo','Víctor1234','Perez','','Chocolate',null,true,3);

insert into Alumno
values('50059001');

insert into Cursa
values('50059001',6,1,2021);

insert into asignaturaCursa
values('50059001',6,1,2021,'progi2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'so2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'rds1',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'geo2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'elec',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'mate2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'ing2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'eco',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'apt2',true);

insert into asignaturaCursa
values('50059001',6,1,2021,'fis',true);

/*--Alumno-60--*/
insert into Usuario
values('50060008','Rosmery','Rosmery','Rosmery1234','Sanchez','','Chocolate',null,true,3);

insert into Alumno
values('50060008');

insert into Cursa
values('50060008',6,1,2021);

insert into asignaturaCursa
values('50060008',6,1,2021,'progi2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'so2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'rds1',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'geo2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'elec',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'mate2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'ing2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'eco',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'apt2',true);

insert into asignaturaCursa
values('50060008',6,1,2021,'fis',true);

/*------BC2i------*/
/*--Alumno-61--*/
insert into Usuario
values('50061002','Jorge','Jorge','Jorge1234','Chavez','','Chocolate',null,true,3);

insert into Alumno
values('50061002');

insert into Cursa
values('50061002',7,1,2021);

insert into asignaturaCursa
values('50061002',7,1,2021,'progi2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'so2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'rds1',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'geo2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'elec',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'mate2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'ing2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'eco',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'apt2',true);

insert into asignaturaCursa
values('50061002',7,1,2021,'fis',true);

/*--Alumno-62--*/
insert into Usuario
values('50062006','Carmen','Carmen','Carmen1234','Apaza','','Chocolate',null,true,3);

insert into Alumno
values('50062006');

insert into Cursa
values('50062006',7,1,2021);

insert into asignaturaCursa
values('50062006',7,1,2021,'progi2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'so2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'rds1',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'geo2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'elec',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'mate2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'ing2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'eco',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'apt2',true);

insert into asignaturaCursa
values('50062006',7,1,2021,'fis',true);

/*--Alumno-63--*/
insert into Usuario
values('50063000','Hugo','Hugo','Hugo1234','Vaca','','Chocolate',null,true,3);

insert into Alumno
values('50063000');

insert into Cursa
values('50063000',7,1,2021);

insert into asignaturaCursa
values('50063000',7,1,2021,'progi2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'so2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'rds1',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'geo2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'elec',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'mate2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'ing2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'eco',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'apt2',true);

insert into asignaturaCursa
values('50063000',7,1,2021,'fis',true);

/*--Alumno-64--*/
insert into Usuario
values('50064004','Laura','Laura','Laura1234','Guzman','','Chocolate',null,true,3);

insert into Alumno
values('50064004');

insert into Cursa
values('50064004',7,1,2021);

insert into asignaturaCursa
values('50064004',7,1,2021,'progi2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'so2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'rds1',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'geo2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'elec',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'mate2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'ing2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'eco',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'apt2',true);

insert into asignaturaCursa
values('50064004',7,1,2021,'fis',true);

/*------BD2i------*/
/*--Alumno-65--*/
insert into Usuario
values('50065008','Antonio','Antonio','Antonio1234','Aguilar','','Chocolate',null,true,3);

insert into Alumno
values('50065008');

insert into Cursa
values('50065008',8,1,2021);

insert into asignaturaCursa
values('50065008',8,1,2021,'progi2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'so2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'rds1',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'geo2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'elec',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'mate2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'ing2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'eco',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'apt2',true);

insert into asignaturaCursa
values('50065008',8,1,2021,'fis',true);

/*--Alumno-66--*/
insert into Usuario
values('50066002','Ana','Ana','Ana1234','Romero','','Chocolate',null,true,3);

insert into Alumno
values('50066002');

insert into Cursa
values('50066002',8,1,2021);

insert into asignaturaCursa
values('50066002',8,1,2021,'progi2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'so2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'rds1',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'geo2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'elec',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'mate2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'ing2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'eco',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'apt2',true);

insert into asignaturaCursa
values('50066002',8,1,2021,'fis',true);

/*--Alumno-67--*/
insert into Usuario
values('50067006','Pablo','Pablo','Pablo1234','Cuellar','','Chocolate',null,true,3);

insert into Alumno
values('50067006');

insert into Cursa
values('50067006',8,1,2021);

insert into asignaturaCursa
values('50067006',8,1,2021,'progi2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'so2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'rds1',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'geo2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'elec',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'mate2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'ing2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'eco',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'apt2',true);

insert into asignaturaCursa
values('50067006',8,1,2021,'fis',true);

/*--Alumno-68--*/
insert into Usuario
values('50068000','Patricia','Patricia','Patricia1234','Vasquez','','Chocolate',null,true,3);

insert into Alumno
values('50068000');

insert into Cursa
values('50068000',8,1,2021);

insert into asignaturaCursa
values('50068000',8,1,2021,'progi2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'so2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'rds1',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'geo2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'elec',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'mate2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'ing2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'eco',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'apt2',true);

insert into asignaturaCursa
values('50068000',8,1,2021,'fis',true);

/*------BE2i------*/
/*--Alumno-69--*/
insert into Usuario
values('50069004','Wikermanyonaiden','Wikermanyonaiden','Wikermanyonaiden1234','Piernavieja','Nari','Pistacho',null,true,3);

insert into Alumno
values('50069004');

insert into Cursa
values('50069004',9,1,2021);

insert into asignaturaCursa
values('50069004',9,1,2021,'progi2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'so2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'rds1',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'geo2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'elec',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'mate2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'ing2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'eco',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'apt2',true);

insert into asignaturaCursa
values('50069004',9,1,2021,'fis',true);

/*--Alumno-70--*/
insert into Usuario
values('50070001','José','José','José1234','Morales','','Chocolate',null,true,3);

insert into Alumno
values('50070001');

insert into Cursa
values('50070001',9,1,2021);

insert into asignaturaCursa
values('50070001',9,1,2021,'progi2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'so2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'rds1',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'geo2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'elec',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'mate2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'ing2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'eco',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'apt2',true);

insert into asignaturaCursa
values('50070001',9,1,2021,'fis',true);

/*--Alumno-71--*/
insert into Usuario
values('50071005','Manuel','Manuel','Manuel1234','Ortiz','','Chocolate',null,true,3);

insert into Alumno
values('50071005');

insert into Cursa
values('50071005',9,1,2021);

insert into asignaturaCursa
values('50071005',9,1,2021,'progi2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'so2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'rds1',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'geo2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'elec',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'mate2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'ing2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'eco',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'apt2',true);

insert into asignaturaCursa
values('50071005',9,1,2021,'fis',true);

/*--Alumno-72--*/
insert into Usuario
values('50072009','Paula','Paula','Paula1234','Ticona','','Chocolate',null,true,3);

insert into Alumno
values('50072009');

insert into Cursa
values('50072009',9,1,2021);

insert into asignaturaCursa
values('50072009',9,1,2021,'progi2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'so2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'rds1',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'geo2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'elec',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'mate2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'ing2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'eco',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'apt2',true);

insert into asignaturaCursa
values('50072009',9,1,2021,'fis',true);

/*------BF2i------*/
/*--Alumno-73--*/
insert into Usuario
values('50073003','Víctor','Víctor','Víctor1234','Chambi','','Chocolate',null,true,3);

insert into Alumno
values('50073003');

insert into Cursa
values('50073003',10,1,2021);

insert into asignaturaCursa
values('50073003',10,1,2021,'progi2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'so2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'rds1',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'geo2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'elec',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'mate2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'ing2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'eco',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'apt2',true);

insert into asignaturaCursa
values('50073003',10,1,2021,'fis',true);

/*--Alumno-74--*/
insert into Usuario
values('50074007','Santiago','Santiago','Santiago1234','Calle','','Chocolate',null,true,3);

insert into Alumno
values('50074007');

insert into Cursa
values('50074007',10,1,2021);

insert into asignaturaCursa
values('50074007',10,1,2021,'progi2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'so2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'rds1',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'geo2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'elec',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'mate2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'ing2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'eco',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'apt2',true);

insert into asignaturaCursa
values('50074007',10,1,2021,'fis',true);

/*--Alumno-75--*/
insert into Usuario
values('50075001','Luciana','Luciana','Luciana1234','Mendez','','Chocolate',null,true,3);

insert into Alumno
values('50075001');

insert into Cursa
values('50075001',10,1,2021);

insert into asignaturaCursa
values('50075001',10,1,2021,'progi2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'so2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'rds1',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'geo2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'elec',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'mate2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'ing2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'eco',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'apt2',true);

insert into asignaturaCursa
values('50075001',10,1,2021,'fis',true);

/*--Alumno-76--*/
insert into Usuario
values('50076005','Matías','Matías','Matías1234','Nina','','Chocolate',null,true,3);

insert into Alumno
values('50076005');

insert into Cursa
values('50076005',10,1,2021);

insert into asignaturaCursa
values('50076005',10,1,2021,'progi2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'so2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'dsweb1',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'bdd1',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'rds1',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'geo2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'elec',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'mate2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'ing2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'eco',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'apt2',true);

insert into asignaturaCursa
values('50076005',10,1,2021,'fis',true);

/*----------------------------------------------------Ingreso-Docentes---------------------------------------------------*/
/*-Comun-ds-dw-*/
/*--Docente-1--so3--*/
insert into Usuario
values('30001008','Jose','Jose','12345678','Alvarez','Gutierrez','coco',null,true,3);

insert into Docente
values ('30001008');

insert into Dicta
values('30001008',11,2,2021);

insert into asignaturaDictada
values('30001008',11,2,2021,'so3',true);

insert into Dicta
values('30001008',12,2,2021);

insert into asignaturaDictada
values('30001008',12,2,2021,'so3',true);

insert into Dicta
values('30001008',13,2,2021);

insert into asignaturaDictada
values('30001008',13,2,2021,'so3',true);

insert into Dicta
values('30001008',14,2,2021);

insert into asignaturaDictada
values('30001008',14,2,2021,'so3',true);

insert into Dicta
values('30001008',15,3,2021);

insert into asignaturaDictada
values('30001008',15,3,2021,'so3',true);

insert into Dicta
values('30001008',16,3,2021);

insert into asignaturaDictada
values('30001008',16,3,2021,'so3',true);

insert into Dicta
values('30001008',17,3,2021);

insert into asignaturaDictada
values('30001008',17,3,2021,'so3',true);

insert into Dicta
values('30001008',18,3,2021);

insert into asignaturaDictada
values('30001008',18,3,2021,'so3',true);

/*--Docente-2--ada--*/
insert into Usuario
values('30002002','Pepe','Pedro','87654321','Sanchez','Guerra','Trueno',null,true,1);

insert into Docente
values ('30002002');

insert into Dicta
values('30002002',11,2,2021);

insert into asignaturaDictada
values('30002002',11,2,2021,'ada',true);

insert into Dicta
values('30002002',12,2,2021);

insert into asignaturaDictada
values('30002002',12,2,2021,'ada',true);

insert into Dicta
values('30002002',13,2,2021);

insert into asignaturaDictada
values('30002002',13,2,2021,'ada',true);

insert into Dicta
values('30002002',14,2,2021);

insert into asignaturaDictada
values('30002002',14,2,2021,'ada',true);

insert into Dicta
values('30002002',15,3,2021);

insert into asignaturaDictada
values('30002002',15,3,2021,'ada',true);

insert into Dicta
values('30002002',16,3,2021);

insert into asignaturaDictada
values('30002002',16,3,2021,'ada',true);

insert into Dicta
values('30002002',17,3,2021);

insert into asignaturaDictada
values('30002002',17,3,2021,'ada',true);

insert into Dicta
values('30002002',18,3,2021);

insert into asignaturaDictada
values('30002002',18,3,2021,'ada',true);

/*--Docente-3--bdd2--*/
insert into Usuario
values('30003006','Alber','Alberto','11111111','Santin','Fierro','Anini',null,true,1);

insert into Docente
values('30003006');

insert into Dicta
values('30003006',11,2,2021);

insert into asignaturaDictada
values('30003006',11,2,2021,'bdd2',true);

insert into Dicta
values('30003006',12,2,2021);

insert into asignaturaDictada
values('30003006',12,2,2021,'bdd2',true);

insert into Dicta
values('30003006',13,2,2021);

insert into asignaturaDictada
values('30003006',13,2,2021,'bdd2',true);

insert into Dicta
values('30003006',14,2,2021);

insert into asignaturaDictada
values('30003006',14,2,2021,'bdd2',true);

insert into Dicta
values('30003006',15,3,2021);

insert into asignaturaDictada
values('30003006',15,3,2021,'bdd2',true);

insert into Dicta
values('30003006',16,3,2021);

insert into asignaturaDictada
values('30003006',16,3,2021,'bdd2',true);

insert into Dicta
values('30003006',17,3,2021);

insert into asignaturaDictada
values('30003006',17,3,2021,'bdd2',true);

insert into Dicta
values('30003006',18,3,2021);

insert into asignaturaDictada
values('30003006',18,3,2021,'bdd2',true);

/*--Docente-4--forme--*/
insert into Usuario
values('30004000','Gregorio','Gregorio','Gregorio1234','Marino','','Crema',null,true,3);

insert into Docente
values('30004000');

insert into Dicta
values('30004000',11,2,2021);

insert into asignaturaDictada
values('30004000',11,2,2021,'forme',true);

insert into Dicta
values('30004000',12,2,2021);

insert into asignaturaDictada
values('30004000',12,2,2021,'forme',true);

insert into Dicta
values('30004000',13,2,2021);

insert into asignaturaDictada
values('30004000',13,2,2021,'forme',true);

insert into Dicta
values('30004000',14,2,2021);

insert into asignaturaDictada
values('30004000',14,2,2021,'forme',true);

insert into Dicta
values('30004000',15,3,2021);

insert into asignaturaDictada
values('30004000',15,3,2021,'forme',true);

insert into Dicta
values('30004000',16,3,2021);

insert into asignaturaDictada
values('30004000',16,3,2021,'forme',true);

insert into Dicta
values('30004000',17,3,2021);

insert into asignaturaDictada
values('30004000',17,3,2021,'forme',true);

insert into Dicta
values('30004000',18,3,2021);

insert into asignaturaDictada
values('30004000',18,3,2021,'forme',true);

/*--Docente-5--mate3--*/
insert into Usuario
values('30005004','Ezequiel','Ezequiel','Ezequiel1234','Baubeta','','Crema',null,true,3);

insert into Docente
values('30005004');

insert into Dicta
values('30005004',11,2,2021);

insert into asignaturaDictada
values('30005004',11,2,2021,'mate3',true);

insert into Dicta
values('30005004',12,2,2021);

insert into asignaturaDictada
values('30005004',12,2,2021,'mate3',true);

insert into Dicta
values('30005004',13,2,2021);

insert into asignaturaDictada
values('30005004',13,2,2021,'mate3',true);

insert into Dicta
values('30005004',14,2,2021);

insert into asignaturaDictada
values('30005004',14,2,2021,'mate3',true);

insert into Dicta
values('30005004',15,3,2021);

insert into asignaturaDictada
values('30005004',15,3,2021,'mate3',true);

insert into Dicta
values('30005004',16,3,2021);

insert into asignaturaDictada
values('30005004',16,3,2021,'mate3',true);

insert into Dicta
values('30005004',17,3,2021);

insert into asignaturaDictada
values('30005004',17,3,2021,'mate3',true);

insert into Dicta
values('30005004',18,3,2021);

insert into asignaturaDictada
values('30005004',18,3,2021,'mate3',true);

/*--Docente-6--ing3--*/
insert into Usuario
values('30006008','Eugenio','Eugenio','Eugenio1234','Greco','','Crema',null,true,3);

insert into Docente
values('30006008');

insert into Dicta
values('30006008',11,2,2021);

insert into asignaturaDictada
values('30006008',11,2,2021,'ing3',true);

insert into Dicta
values('30006008',12,2,2021);

insert into asignaturaDictada
values('30006008',12,2,2021,'ing3',true);

insert into Dicta
values('30006008',13,2,2021);

insert into asignaturaDictada
values('30006008',13,2,2021,'ing3',true);

insert into Dicta
values('30006008',14,2,2021);

insert into asignaturaDictada
values('30006008',14,2,2021,'ing3',true);

insert into Dicta
values('30006008',15,3,2021);

insert into asignaturaDictada
values('30006008',15,3,2021,'ing3',true);

insert into Dicta
values('30006008',16,3,2021);

insert into asignaturaDictada
values('30006008',16,3,2021,'ing3',true);

insert into Dicta
values('30006008',17,3,2021);

insert into asignaturaDictada
values('30006008',17,3,2021,'ing3',true);

insert into Dicta
values('30006008',18,3,2021);

insert into asignaturaDictada
values('30006008',18,3,2021,'ing3',true);

/*--Docente-7--soci--*/
insert into Usuario
values('30007002','Benito','Benito','Benito1234','Ricci','','Crema',null,true,3);

insert into Docente
values('30007002');

insert into Dicta
values('30007002',11,2,2021);

insert into asignaturaDictada
values('30007002',11,2,2021,'soci',true);

insert into Dicta
values('30007002',12,2,2021);

insert into asignaturaDictada
values('30007002',12,2,2021,'soci',true);

insert into Dicta
values('30007002',13,2,2021);

insert into asignaturaDictada
values('30007002',13,2,2021,'soci',true);

insert into Dicta
values('30007002',14,2,2021);

insert into asignaturaDictada
values('30007002',14,2,2021,'soci',true);

insert into Dicta
values('30007002',15,3,2021);

insert into asignaturaDictada
values('30007002',15,3,2021,'soci',true);

insert into Dicta
values('30007002',16,3,2021);

insert into asignaturaDictada
values('30007002',16,3,2021,'soci',true);

insert into Dicta
values('30007002',17,3,2021);

insert into asignaturaDictada
values('30007002',17,3,2021,'soci',true);

insert into Dicta
values('30007002',18,3,2021);

insert into asignaturaDictada
values('30007002',18,3,2021,'soci',true);

/*--Docente-8--filo--*/
insert into Usuario
values('30008006','Pascual','Pascual','Pascual1234','Colombo','','Crema',null,true,3);

insert into Docente
values('30008006');

insert into Dicta
values('30008006',11,2,2021);

insert into asignaturaDictada
values('30008006',11,2,2021,'filo',true);

insert into Dicta
values('30008006',12,2,2021);

insert into asignaturaDictada
values('30008006',12,2,2021,'filo',true);

insert into Dicta
values('30008006',13,2,2021);

insert into asignaturaDictada
values('30008006',13,2,2021,'filo',true);

insert into Dicta
values('30008006',14,2,2021);

insert into asignaturaDictada
values('30008006',14,2,2021,'filo',true);

insert into Dicta
values('30008006',15,3,2021);

insert into asignaturaDictada
values('30008006',15,3,2021,'filo',true);

insert into Dicta
values('30008006',16,3,2021);

insert into asignaturaDictada
values('30008006',16,3,2021,'filo',true);

insert into Dicta
values('30008006',17,3,2021);

insert into asignaturaDictada
values('30008006',17,3,2021,'filo',true);

insert into Dicta
values('30008006',18,3,2021);

insert into asignaturaDictada
values('30008006',18,3,2021,'filo',true);

/*-Des-Soporte-*/
/*--Docente-9--progds3--*/
insert into Usuario
values('30009000','Bartolomé','Bartolomé','Bartolomé1234','Bianchi','','Crema',null,true,3);

insert into Docente
values('30009000');

insert into Dicta
values('30009000',11,2,2021);

insert into asignaturaDictada
values('30009000',11,2,2021,'progds3',true);

insert into Dicta
values('30009000',12,2,2021);

insert into asignaturaDictada
values('30009000',12,2,2021,'progds3',true);

insert into Dicta
values('30009000',13,2,2021);

insert into asignaturaDictada
values('30009000',13,2,2021,'progds3',true);

insert into Dicta
values('30009000',14,2,2021);

insert into asignaturaDictada
values('30009000',14,2,2021,'progds3',true);

/*--Docente-10--proyds--*/
insert into Usuario
values('30010007','Marcelino','Marcelino','Marcelino1234','Esposito','','Crema',null,true,3);

insert into Docente
values('30010007');

insert into Dicta
values('30010007',11,2,2021);

insert into asignaturaDictada
values('30010007',11,2,2021,'proyds',true);

insert into Dicta
values('30010007',12,2,2021);

insert into asignaturaDictada
values('30010007',12,2,2021,'proyds',true);

insert into Dicta
values('30010007',13,2,2021);

insert into asignaturaDictada
values('30010007',13,2,2021,'proyds',true);

insert into Dicta
values('30010007',14,2,2021);

insert into asignaturaDictada
values('30010007',14,2,2021,'proyds',true);

/*--Docente-11--rds2--*/
insert into Usuario
values('30011001','Aurelio','Aurelio','Aurelio1234','Santin','','Crema',null,true,3);

insert into Docente
values('30011001');

insert into Dicta
values('30011001',11,2,2021);

insert into asignaturaDictada
values('30011001',11,2,2021,'rds2',true);

insert into Dicta
values('30011001',12,2,2021);

insert into asignaturaDictada
values('30011001',12,2,2021,'rds2',true);

insert into Dicta
values('30011001',13,2,2021);

insert into asignaturaDictada
values('30011001',13,2,2021,'rds2',true);

insert into Dicta
values('30011001',14,2,2021);

insert into asignaturaDictada
values('30011001',14,2,2021,'rds2',true);

/*-Des-Web-*/
/*--Docente-12--progdw3--*/
insert into Usuario
values('30012005','Jacinto','Jacinto','Jacinto1234','Ferrari','','Crema',null,true,3);

insert into Docente
values('30012005');

insert into Dicta
values('30012005',15,3,2021);

insert into asignaturaDictada
values('30012005',15,3,2021,'progdw3',true);

insert into Dicta
values('30012005',16,3,2021);

insert into asignaturaDictada
values('30012005',16,3,2021,'progdw3',true);

insert into Dicta
values('30012005',17,3,2021);

insert into asignaturaDictada
values('30012005',17,3,2021,'progdw3',true);

insert into Dicta
values('30012005',18,3,2021);

insert into asignaturaDictada
values('30012005',18,3,2021,'progdw3',true);

/*--Docente-13--proydw--*/
insert into Usuario
values('30013009','Mariano','Mariano','Mariano1234','Rossi','','Crema',null,true,3);

insert into Docente
values('30013009');

insert into Dicta
values('30013009',15,3,2021);

insert into asignaturaDictada
values('30013009',15,3,2021,'proydw',true);

insert into Dicta
values('30013009',16,3,2021);

insert into asignaturaDictada
values('30013009',16,3,2021,'proydw',true);

insert into Dicta
values('30013009',17,3,2021);

insert into asignaturaDictada
values('30013009',17,3,2021,'proydw',true);

insert into Dicta
values('30013009',18,3,2021);

insert into asignaturaDictada
values('30013009',18,3,2021,'proydw',true);

/*--Docente-14--dsweb2--*/
insert into Usuario
values('30014003','José ','José ','José1234','Ramos','','Crema',null,true,3);

insert into Docente
values('30014003');

insert into Dicta
values('30014003',15,3,2021);

insert into asignaturaDictada
values('30014003',15,3,2021,'dsweb2',true);

insert into Dicta
values('30014003',16,3,2021);

insert into asignaturaDictada
values('30014003',16,3,2021,'dsweb2',true);

insert into Dicta
values('30014003',17,3,2021);

insert into asignaturaDictada
values('30014003',17,3,2021,'dsweb2',true);

insert into Dicta
values('30014003',18,3,2021);

insert into asignaturaDictada
values('30014003',18,3,2021,'dsweb2',true);

/*-Informatrica-2-*/
/*--Docente-26--apt1--*/
insert into Usuario
values('30026004','María','María','María1234','Vazquez','','Crema',null,true,3);

insert into Docente
values('30026004');

insert into Dicta
values('30026004',1,1,2021);

insert into asignaturaDictada
values('30026004',1,1,2021,'apt1',true);

insert into Dicta
values('30026004',2,1,2021);

insert into asignaturaDictada
values('30026004',2,1,2021,'apt1',true);

insert into Dicta
values('30026004',3,1,2021);

insert into asignaturaDictada
values('30026004',3,1,2021,'apt1',true);

insert into Dicta
values('30026004',4,1,2021);

insert into asignaturaDictada
values('30026004',4,1,2021,'apt1',true);

/*--Docente-25--bio--*/
insert into Usuario
values('30025000','Manuel','Manuel','Manuel1234','Dominguez','','Crema',null,true,3);

insert into Docente
values('30025000');

insert into Dicta
values('30025000',1,1,2021);

insert into asignaturaDictada
values('30025000',1,1,2021,'bio',true);

insert into Dicta
values('30025000',2,1,2021);

insert into asignaturaDictada
values('30025000',2,1,2021,'bio',true);

insert into Dicta
values('30025000',3,1,2021);

insert into asignaturaDictada
values('30025000',3,1,2021,'bio',true);

insert into Dicta
values('30025000',4,1,2021);

insert into asignaturaDictada
values('30025000',4,1,2021,'bio',true);

/*--Docente-20--geo1--*/
insert into Usuario
values('30020000','Francisco','Francisco','Francisco1234','Torres','','Crema',null,true,3);

insert into Docente
values('30020000');

insert into Dicta
values('30020000',1,1,2021);

insert into asignaturaDictada
values('30020000',1,1,2021,'geo1',true);

insert into Dicta
values('30020000',2,1,2021);

insert into asignaturaDictada
values('30020000',2,1,2021,'geo1',true);

insert into Dicta
values('30020000',3,1,2021);

insert into asignaturaDictada
values('30020000',3,1,2021,'geo1',true);

insert into Dicta
values('30020000',4,1,2021);

insert into asignaturaDictada
values('30020000',4,1,2021,'geo1',true);

/*--Docente-24--hist--*/
insert into Usuario
values('30024006','David','David','David1234','Navarro','','Crema',null,true,3);

insert into Docente
values('30024006');

insert into Dicta
values('30024006',1,1,2021);

insert into asignaturaDictada
values('30024006',1,1,2021,'hist',true);

insert into Dicta
values('30024006',2,1,2021);

insert into asignaturaDictada
values('30024006',2,1,2021,'hist',true);

insert into Dicta
values('30024006',3,1,2021);

insert into asignaturaDictada
values('30024006',3,1,2021,'hist',true);

insert into Dicta
values('30024006',4,1,2021);

insert into asignaturaDictada
values('30024006',4,1,2021,'hist',true);

/*--Docente-23--ing1--*/
insert into Usuario
values('30023002','Angel','Angel','Angel1234','Gutierrez','','Crema',null,true,3);

insert into Docente
values('30023002');

insert into Dicta
values('30023002',1,1,2021);

insert into asignaturaDictada
values('30023002',1,1,2021,'ing1',true);

insert into Dicta
values('30023002',2,1,2021);

insert into asignaturaDictada
values('30023002',2,1,2021,'ing1',true);

insert into Dicta
values('30023002',3,1,2021);

insert into asignaturaDictada
values('30023002',3,1,2021,'ing1',true);

insert into Dicta
values('30023002',4,1,2021);

insert into asignaturaDictada
values('30023002',4,1,2021,'ing1',true);

/*--Docente-19--labsop--*/
insert into Usuario
values('30019003','Francisca','Francisca','Francisca1234','Alonzo','','Crema',null,true,3);

insert into Docente
values('30019003');

insert into Dicta
values('30019003',1,1,2021);

insert into asignaturaDictada
values('30019003',1,1,2021,'labsop',true);

insert into Dicta
values('30019003',2,1,2021);

insert into asignaturaDictada
values('30019003',2,1,2021,'labsop',true);

insert into Dicta
values('30019003',3,1,2021);

insert into asignaturaDictada
values('30019003',3,1,2021,'labsop',true);

insert into Dicta
values('30019003',4,1,2021);

insert into asignaturaDictada
values('30019003',4,1,2021,'labsop',true);

/*--Docente-17--log--*/
insert into Usuario
values('30017005','Antonia','Antonia','Antonia1234','Alonso','','Crema',null,true,3);

insert into Docente
values('30017005');

insert into Dicta
values('30017005',1,1,2021);

insert into asignaturaDictada
values('30017005',1,1,2021,'log',true);

insert into Dicta
values('30017005',2,1,2021);

insert into asignaturaDictada
values('30017005',2,1,2021,'log',true);

insert into Dicta
values('30017005',3,1,2021);

insert into asignaturaDictada
values('30017005',3,1,2021,'log',true);

insert into Dicta
values('30017005',4,1,2021);

insert into asignaturaDictada
values('30017005',4,1,2021,'log',true);

/*--Docente-22--mate1--*/
insert into Usuario
values('30022008','Dolores','Dolores','Dolores1234','Romero','','Crema',null,true,3);

insert into Docente
values('30022008');

insert into Dicta
values('30022008',1,1,2021);

insert into asignaturaDictada
values('30022008',1,1,2021,'mate1',true);

insert into Dicta
values('30022008',2,1,2021);

insert into asignaturaDictada
values('30022008',2,1,2021,'mate1',true);

insert into Dicta
values('30022008',3,1,2021);

insert into asignaturaDictada
values('30022008',3,1,2021,'mate1',true);

insert into Dicta
values('30022008',4,1,2021);

insert into asignaturaDictada
values('30022008',4,1,2021,'mate1',true);

/*--Docente-18--metdis--*/
insert into Usuario
values('30018009','Luisa','Luisa','Luisa1234','Alvarez','','Crema',null,true,3);

insert into Docente
values('30018009');

insert into Dicta
values('30018009',1,1,2021);

insert into asignaturaDictada
values('30018009',1,1,2021,'metdis',true);

insert into Dicta
values('30018009',2,1,2021);

insert into asignaturaDictada
values('30018009',2,1,2021,'metdis',true);

insert into Dicta
values('30018009',3,1,2021);

insert into asignaturaDictada
values('30018009',3,1,2021,'metdis',true);

insert into Dicta
values('30018009',4,1,2021);

insert into asignaturaDictada
values('30018009',4,1,2021,'metdis',true);

/*--Docente-15--progi1--*/
insert into Usuario
values('30015007','Pilar','Pilar','Pilar1234','Muñoz','','Crema',null,true,3);

insert into Docente
values('30015007');

insert into Dicta
values('30015007',1,1,2021);

insert into asignaturaDictada
values('30015007',1,1,2021,'progi1',true);

insert into Dicta
values('30015007',2,1,2021);

insert into asignaturaDictada
values('30015007',2,1,2021,'progi1',true);

insert into Dicta
values('30015007',3,1,2021);

insert into asignaturaDictada
values('30015007',3,1,2021,'progi1',true);

insert into Dicta
values('30015007',4,1,2021);

insert into asignaturaDictada
values('30015007',4,1,2021,'progi1',true);

/*--Docente-27--quim--*/
insert into Usuario
values('30027008','Manuela','Manuela','Manuela1234','Moreno','','Crema',null,true,3);

insert into Docente
values('30027008');

insert into Dicta
values('30027008',1,1,2021);

insert into asignaturaDictada
values('30027008',1,1,2021,'quim',true);

insert into Dicta
values('30027008',2,1,2021);

insert into asignaturaDictada
values('30027008',2,1,2021,'quim',true);

insert into Dicta
values('30027008',3,1,2021);

insert into asignaturaDictada
values('30027008',3,1,2021,'quim',true);

insert into Dicta
values('30027008',4,1,2021);

insert into asignaturaDictada
values('30027008',4,1,2021,'quim',true);

/*--Docente-16--so1--*/
insert into Usuario
values('30016001','Mercedes','Mercedes','Mercedes1234','Diaz','','Crema',null,true,3);

insert into Docente
values('30016001');

insert into Dicta
values('30016001',1,1,2021);

insert into asignaturaDictada
values('30016001',1,1,2021,'so1',true);

insert into Dicta
values('30016001',2,1,2021);

insert into asignaturaDictada
values('30016001',2,1,2021,'so1',true);

insert into Dicta
values('30016001',3,1,2021);

insert into asignaturaDictada
values('30016001',3,1,2021,'so1',true);

insert into Dicta
values('30016001',4,1,2021);

insert into asignaturaDictada
values('30016001',4,1,2021,'so1',true);

/*--Docente-21--tecelec--*/
insert into Usuario
values('30021004','Rosario','Rosario','Rosario1234','Hernandez','','Crema',null,true,3);

insert into Docente
values('30021004');

insert into Dicta
values('30021004',1,1,2021);

insert into asignaturaDictada
values('30021004',1,1,2021,'tecelec',true);

insert into Dicta
values('30021004',2,1,2021);

insert into asignaturaDictada
values('30021004',2,1,2021,'tecelec',true);

insert into Dicta
values('30021004',3,1,2021);

insert into asignaturaDictada
values('30021004',3,1,2021,'tecelec',true);

insert into Dicta
values('30021004',4,1,2021);

insert into asignaturaDictada
values('30021004',4,1,2021,'tecelec',true);

/*-Informatrica-2-*/
/*--Docente-28--apt2--*/
insert into Usuario
values('30028002','Juana','Juana','Juana1234','Ruiz','','Crema',null,true,3);

insert into Docente
values('30028002');

insert into Dicta
values('30028002',5,1,2021);

insert into asignaturaDictada
values('30028002',5,1,2021,'apt2',true);

insert into Dicta
values('30028002',6,1,2021);

insert into asignaturaDictada
values('30028002',6,1,2021,'apt2',true);

insert into Dicta
values('30028002',7,1,2021);

insert into asignaturaDictada
values('30028002',7,1,2021,'apt2',true);

insert into Dicta
values('30028002',8,1,2021);

insert into asignaturaDictada
values('30028002',8,1,2021,'apt2',true);

insert into Dicta
values('30028002',9,1,2021);

insert into asignaturaDictada
values('30028002',9,1,2021,'apt2',true);

insert into Dicta
values('30028002',10,1,2021);

insert into asignaturaDictada
values('30028002',10,1,2021,'apt2',true);

/*--Docente-29--bdd1--*/
insert into Usuario
values('30029006','Teresa','Teresa','Teresa1234','Jimenez','','Crema',null,true,3);

insert into Docente
values('30029006');

insert into Dicta
values('30029006',5,1,2021);

insert into asignaturaDictada
values('30029006',5,1,2021,'bdd1',true);

insert into Dicta
values('30029006',6,1,2021);

insert into asignaturaDictada
values('30029006',6,1,2021,'bdd1',true);

insert into Dicta
values('30029006',7,1,2021);

insert into asignaturaDictada
values('30029006',7,1,2021,'bdd1',true);

insert into Dicta
values('30029006',8,1,2021);

insert into asignaturaDictada
values('30029006',8,1,2021,'bdd1',true);

insert into Dicta
values('30029006',9,1,2021);

insert into asignaturaDictada
values('30029006',9,1,2021,'bdd1',true);

insert into Dicta
values('30029006',10,1,2021);

insert into asignaturaDictada
values('30029006',10,1,2021,'bdd1',true);

/*--Docente-30--dsweb1--*/
insert into Usuario
values('30030003','Rosa','Rosa','Rosa1234','Martin','','Crema',null,true,3);

insert into Docente
values('30030003');

insert into Dicta
values('30030003',5,1,2021);

insert into asignaturaDictada
values('30030003',5,1,2021,'dsweb1',true);

insert into Dicta
values('30030003',6,1,2021);

insert into asignaturaDictada
values('30030003',6,1,2021,'dsweb1',true);

insert into Dicta
values('30030003',7,1,2021);

insert into asignaturaDictada
values('30030003',7,1,2021,'dsweb1',true);

insert into Dicta
values('30030003',8,1,2021);

insert into asignaturaDictada
values('30030003',8,1,2021,'dsweb1',true);

insert into Dicta
values('30030003',9,1,2021);

insert into asignaturaDictada
values('30030003',9,1,2021,'dsweb1',true);

insert into Dicta
values('30030003',10,1,2021);

insert into asignaturaDictada
values('30030003',10,1,2021,'dsweb1',true);

/*--Docente-31--eco--*/
insert into Usuario
values('30031007','Margarita','Margarita','Margarita1234','Gomez','','Crema',null,true,3);

insert into Docente
values('30031007');

insert into Dicta
values('30031007',5,1,2021);

insert into asignaturaDictada
values('30031007',5,1,2021,'eco',true);

insert into Dicta
values('30031007',6,1,2021);

insert into asignaturaDictada
values('30031007',6,1,2021,'eco',true);

insert into Dicta
values('30031007',7,1,2021);

insert into asignaturaDictada
values('30031007',7,1,2021,'eco',true);

insert into Dicta
values('30031007',8,1,2021);

insert into asignaturaDictada
values('30031007',8,1,2021,'eco',true);

insert into Dicta
values('30031007',9,1,2021);

insert into asignaturaDictada
values('30031007',9,1,2021,'eco',true);

insert into Dicta
values('30031007',10,1,2021);

insert into asignaturaDictada
values('30031007',10,1,2021,'eco',true);

/*--Docente-32--elec--*/
insert into Usuario
values('30032001','Amparo','Amparo','Amparo1234','Perez','','Crema',null,true,3);

insert into Docente
values('30032001');

insert into Dicta
values('30032001',5,1,2021);

insert into asignaturaDictada
values('30032001',5,1,2021,'elec',true);

insert into Dicta
values('30032001',6,1,2021);

insert into asignaturaDictada
values('30032001',6,1,2021,'elec',true);

insert into Dicta
values('30032001',7,1,2021);

insert into asignaturaDictada
values('30032001',7,1,2021,'elec',true);

insert into Dicta
values('30032001',8,1,2021);

insert into asignaturaDictada
values('30032001',8,1,2021,'elec',true);

insert into Dicta
values('30032001',9,1,2021);

insert into asignaturaDictada
values('30032001',9,1,2021,'elec',true);

insert into Dicta
values('30032001',10,1,2021);

insert into asignaturaDictada
values('30032001',10,1,2021,'elec',true);

/*--Docente-33--fis--*/
insert into Usuario
values('30033005','Nathalie','Nathalie','Nathalie1234','Sanchez','','Crema',null,true,3);

insert into Docente
values('30033005');

insert into Dicta
values('30033005',5,1,2021);

insert into asignaturaDictada
values('30033005',5,1,2021,'fis',true);

insert into Dicta
values('30033005',6,1,2021);

insert into asignaturaDictada
values('30033005',6,1,2021,'fis',true);

insert into Dicta
values('30033005',7,1,2021);

insert into asignaturaDictada
values('30033005',7,1,2021,'fis',true);

insert into Dicta
values('30033005',8,1,2021);

insert into asignaturaDictada
values('30033005',8,1,2021,'fis',true);

insert into Dicta
values('30033005',9,1,2021);

insert into asignaturaDictada
values('30033005',9,1,2021,'fis',true);

insert into Dicta
values('30033005',10,1,2021);

insert into asignaturaDictada
values('30033005',10,1,2021,'fis',true);

/*--Docente-34--geo2--*/
insert into Usuario
values('30034009','Marco','Marco','Marco1234','Martinez','','Crema',null,true,3);

insert into Docente
values('30034009');

insert into Dicta
values('30034009',5,1,2021);

insert into asignaturaDictada
values('30034009',5,1,2021,'geo2',true);

insert into Dicta
values('30034009',6,1,2021);

insert into asignaturaDictada
values('30034009',6,1,2021,'geo2',true);

insert into Dicta
values('30034009',7,1,2021);

insert into asignaturaDictada
values('30034009',7,1,2021,'geo2',true);

insert into Dicta
values('30034009',8,1,2021);

insert into asignaturaDictada
values('30034009',8,1,2021,'geo2',true);

insert into Dicta
values('30034009',9,1,2021);

insert into asignaturaDictada
values('30034009',9,1,2021,'geo2',true);

insert into Dicta
values('30034009',10,1,2021);

insert into asignaturaDictada
values('30034009',10,1,2021,'geo2',true);

/*--Docente-35--ing2--*/
insert into Usuario
values('30035003','Valentina','Valentina','Valentina1234','Lopez','','Crema',null,true,3);

insert into Docente
values('30035003');

insert into Dicta
values('30035003',5,1,2021);

insert into asignaturaDictada
values('30035003',5,1,2021,'ing2',true);

insert into Dicta
values('30035003',6,1,2021);

insert into asignaturaDictada
values('30035003',6,1,2021,'ing2',true);

insert into Dicta
values('30035003',7,1,2021);

insert into asignaturaDictada
values('30035003',7,1,2021,'ing2',true);

insert into Dicta
values('30035003',8,1,2021);

insert into asignaturaDictada
values('30035003',8,1,2021,'ing2',true);

insert into Dicta
values('30035003',9,1,2021);

insert into asignaturaDictada
values('30035003',9,1,2021,'ing2',true);

insert into Dicta
values('30035003',10,1,2021);

insert into asignaturaDictada
values('30035003',10,1,2021,'ing2',true);

/*--Docente-36--mate2--*/
insert into Usuario
values('30036007','David','David','David1234','Fernandez','','Crema',null,true,3);

insert into Docente
values('30036007');

insert into Dicta
values('30036007',5,1,2021);

insert into asignaturaDictada
values('30036007',5,1,2021,'mate2',true);

insert into Dicta
values('30036007',6,1,2021);

insert into asignaturaDictada
values('30036007',6,1,2021,'mate2',true);

insert into Dicta
values('30036007',7,1,2021);

insert into asignaturaDictada
values('30036007',7,1,2021,'mate2',true);

insert into Dicta
values('30036007',8,1,2021);

insert into asignaturaDictada
values('30036007',8,1,2021,'mate2',true);

insert into Dicta
values('30036007',9,1,2021);

insert into asignaturaDictada
values('30036007',9,1,2021,'mate2',true);

insert into Dicta
values('30036007',10,1,2021);

insert into asignaturaDictada
values('30036007',10,1,2021,'mate2',true);

/*--Docente-37--progi2--*/
insert into Usuario
values('30037001','Susan','Susan','Susan1234','Rodriguez','','Crema',null,true,3);

insert into Docente
values('30037001');

insert into Dicta
values('30037001',5,1,2021);

insert into asignaturaDictada
values('30037001',5,1,2021,'progi2',true);

insert into Dicta
values('30037001',6,1,2021);

insert into asignaturaDictada
values('30037001',6,1,2021,'progi2',true);

insert into Dicta
values('30037001',7,1,2021);

insert into asignaturaDictada
values('30037001',7,1,2021,'progi2',true);

insert into Dicta
values('30037001',8,1,2021);

insert into asignaturaDictada
values('30037001',8,1,2021,'progi2',true);

insert into Dicta
values('30037001',9,1,2021);

insert into asignaturaDictada
values('30037001',9,1,2021,'progi2',true);

insert into Dicta
values('30037001',10,1,2021);

insert into asignaturaDictada
values('30037001',10,1,2021,'progi2',true);

/*--Docente-38--rds1--*/
insert into Usuario
values('30038005','Bautista','Bautista','Bautista1234','Gonzales','','Crema',null,true,3);

insert into Docente
values('30038005');

insert into Dicta
values('30038005',5,1,2021);

insert into asignaturaDictada
values('30038005',5,1,2021,'rds1',true);

insert into Dicta
values('30038005',6,1,2021);

insert into asignaturaDictada
values('30038005',6,1,2021,'rds1',true);

insert into Dicta
values('30038005',7,1,2021);

insert into asignaturaDictada
values('30038005',7,1,2021,'rds1',true);

insert into Dicta
values('30038005',8,1,2021);

insert into asignaturaDictada
values('30038005',8,1,2021,'rds1',true);

insert into Dicta
values('30038005',9,1,2021);

insert into asignaturaDictada
values('30038005',9,1,2021,'rds1',true);

insert into Dicta
values('30038005',10,1,2021);

insert into asignaturaDictada
values('30038005',10,1,2021,'rds1',true);

/*--Docente-39--so2--*/
insert into Usuario
values('30039009','Eleuterio','Eleuterio','Eleuterio1234','Garcia','','Crema',null,true,3);

insert into Docente
values('30039009');

insert into Dicta
values('30039009',5,1,2021);

insert into asignaturaDictada
values('30039009',5,1,2021,'so2',true);

insert into Dicta
values('30039009',6,1,2021);

insert into asignaturaDictada
values('30039009',6,1,2021,'so2',true);

insert into Dicta
values('30039009',7,1,2021);

insert into asignaturaDictada
values('30039009',7,1,2021,'so2',true);

insert into Dicta
values('30039009',8,1,2021);

insert into asignaturaDictada
values('30039009',8,1,2021,'so2',true);

insert into Dicta
values('30039009',9,1,2021);

insert into asignaturaDictada
values('30039009',9,1,2021,'so2',true);

insert into Dicta
values('30039009',10,1,2021);

insert into asignaturaDictada
values('30039009',10,1,2021,'so2',true);

/*----------------------------------------------------Ingreso-Agenda---------------------------------------------------*/
/*--Agenda-de-Docente-1--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','30001008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','30001008');

/*--Agenda-de-Docente-2--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','30002002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','30002002');

/*--Agenda-de-Docente-3--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','30039009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','30039009');

/*--Agenda-de-Docente-4--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30004000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30004000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30004000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30004000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30004000');

/*--Agenda-de-Docente-5--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30005004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30005004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30005004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30005004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30005004');

/*--Agenda-de-Docente-6--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30006008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30006008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30006008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30006008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30006008');

/*--Agenda-de-Docente-7--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30007002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30007002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30007002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30007002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30007002');

/*--Agenda-de-Docente-8--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30008006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30008006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30008006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30008006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30008006');

/*--Agenda-de-Docente-9--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30009000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30009000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30009000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30009000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30009000');

/*--Agenda-de-Docente-10--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30010007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30010007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30010007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30010007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30010007');

/*--Agenda-de-Docente-11--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30011001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30011001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30011001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30011001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30011001');

/*--Agenda-de-Docente-12--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30012005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30012005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30012005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30012005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30012005');

/*--Agenda-de-Docente-13--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30013009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30013009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30013009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30013009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30013009');

/*--Agenda-de-Docente-14--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30014003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30014003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30014003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30014003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30014003');

/*--Agenda-de-Docente-15--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30015007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30015007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30015007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30015007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30015007');

/*--Agenda-de-Docente-16--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30016001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30016001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30016001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30016001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30016001');

/*--Agenda-de-Docente-17--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30017005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30017005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30017005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30017005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30017005');

/*--Agenda-de-Docente-18--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30018009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30018009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30018009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30018009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30018009');

/*--Agenda-de-Docente-19--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30019003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30019003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30019003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30019003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30019003');

/*--Agenda-de-Docente-20--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30020000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30020000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30020000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30020000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30020000');

/*--Agenda-de-Docente-21--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30021004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30021004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30021004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30021004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30021004');

/*--Agenda-de-Docente-22--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30022008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30022008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30022008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30022008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30022008');

/*--Agenda-de-Docente-23--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30023002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30023002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30023002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30023002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30023002');

/*--Agenda-de-Docente-24--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30024006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30024006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30024006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30024006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30024006');

/*--Agenda-de-Docente-25--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30025000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30025000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30025000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30025000');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30025000');

/*--Agenda-de-Docente-26--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30026004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30026004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30026004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30026004');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30026004');

/*--Agenda-de-Docente-27--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30027008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30027008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30027008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30027008');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30027008');

/*--Agenda-de-Docente-28--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30028002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30028002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30028002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30028002');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30028002');

/*--Agenda-de-Docente-29--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30029006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30029006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30029006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30029006');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30029006');

/*--Agenda-de-Docente-30--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30030003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30030003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30030003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30030003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30030003');

/*--Agenda-de-Docente-31--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30031007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30031007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30031007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30031007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30031007');

/*--Agenda-de-Docente-32--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30032001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30032001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30032001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30032001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30032001');

/*--Agenda-de-Docente-33--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30033005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30033005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30033005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30033005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30033005');

/*--Agenda-de-Docente-34--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30034009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30034009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30034009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30034009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30034009');

/*--Agenda-de-Docente-35--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30035003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30035003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30035003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30035003');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30035003');

/*--Agenda-de-Docente-36--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30036007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30036007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30036007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30036007');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30036007');

/*--Agenda-de-Docente-37--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30037001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30037001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30037001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30037001');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30037001');

/*--Agenda-de-Docente-38--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30038005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30038005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30038005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30038005');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30038005');

/*--Agenda-de-Docente-39--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','00:00:00','23:59:00','30039009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','00:00:00','23:59:00','30039009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Miercoles','00:00:00','23:59:00','30039009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Jueves','00:00:00','23:59:00','30039009');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Viernes','00:00:00','23:59:00','30039009');

/*----------------------------------------------------Ingreso-Mensaje---------------------------------------------------*/

/*-ds-*/
insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30005004','52848682','2021-06-01T23:34:09','Profe, podria mandar el pdf de limites?, que me ayudaria un poco mas de material de repaso','contestado','PDF Limites','Buen dia Matheo, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30005004','52848682','2021-06-16T17:24:37','Disculpe, al final no subio el material, se anima a subirlo asi tengo de donde estudiar para el proximo escrito?','realizado','No envió el repartido',null,null);

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30005004','52848682','2021-06-18T17:24:37','Perdon que sea tan molesto, pero podria mandar el material? L necesitamos para antes del escrito!','realizado','Nueva peticion de envio del pdf',null,null);


insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30002002','52124670','2021-06-01T23:34:09','Profe, podria mandar el pdf de metricas?, que me ayudaria un poco mas de material de repaso','contestado','PDF Metricas','Buen dia Mauro, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30002002','52124670','2021-06-18T17:24:37','Profe, estamos en el salon 7 esperando','realizado','Nueva peticion de envio del pdf',null,null);


insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','51972127','2021-06-01T23:34:09','Profe, podria mandar el pdf de permisos?, que me ayudaria un poco mas de material de repaso','contestado','PDF Permisos','Buen dia Agustin, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30002002','52124670','2021-06-18T17:24:37','Hola profe, podria aceptar mi solicitud de chat? Tenesmos una pregunta que hacerle con mis compañeros','realizado','Nueva peticion de envio del pdf',null,null);

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30008006','50003002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30004000','50004006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30006008','50005000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30009000','50006004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-10-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30010007','50007008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30011001','50008002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30001008','50009006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30007002','50010003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50011007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50012001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50013005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50014009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50015003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50016007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50017001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50018005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50019009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50020006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

/*-dw-*/
insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30014003','50021000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50022004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50023008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50024002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50025006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50026000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50027004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50028008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50029002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50030009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50031003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50032007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50033001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50034005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50034009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30013009','50036003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30012005','50036003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-010-06T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30009000','50036003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-010-06T15:12:43');

/*-inf1-*/
insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30026004','50037007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30025000','50038001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30020000','50039005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30024006','50040002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30023002','50041006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30019003','50042000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30017005','50043004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30022008','50044008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30018009','50045002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30015007','50046006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30027008','50047000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30016001','50048004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50049008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50050005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50051009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30021004','50052003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

/*-inf2-*/
insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30028002','50053007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30029006','50054001','2021-010-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-10-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30029006','50054001','2021-010-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-10-04T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30003006','50054001','2021-010-04T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-10-08T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30003006','50054001','2021-010-04T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-10-07T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30030003','50055005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30031007','50056009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30032001','50057003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30033005','50058007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30034009','50059001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30035003','50060008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30036007','50061002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30037001','50062006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30038005','50063000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50064004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50065008','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50066002','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50067006','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50068000','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50069004','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50070001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50071005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50072009','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50073003','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50074007','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50075001','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('30039009','50076005','2021-06-01T23:34:09','Profe, podria mandar el pdf que nombro la clase pasada?, que me ayudaria un poco mas de material de repaso','contestado','PDF Repaso','Buen dia Estimado, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

/*-------------------------------------------Ingreso-Solicitud-Modificar-Perfil-----------------------------------------*/

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-09-01T23:34:09','AGUSTIN_MIO',false,false,'52848682');

insert into Responde
values(1,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-09-16T23:34:09','palme1234',true,false,'52848682');


insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-10-02T23:34:09','mauro1234',false,true,'52124670');

insert into Responde
values(3,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-10-03T23:34:09','agustin1234',false,true,'51972127');

insert into Responde
values(4,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-10-04T23:34:09','alumno51234',false,false,'50005000');

insert into Responde
values(5,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-10-05T23:34:09','alumno61234',false,false,'50006004');

insert into Responde
values(6,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,aceptada,usuario)
values('2021-11-05T23:34:09','alumno71234',false,false,'50007008');

insert into Responde
values(7,'00000000');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,usuario)
values('2021-12-05T23:34:09','alumno91234',true,'50009006');


insert into SolicitudModif(fechaHora,contraNueva,pendiente,usuario)
values('2021-12-06T23:34:09','alumno101234',true,'50010003');


insert into SolicitudModif(fechaHora,contraNueva,pendiente,usuario)
values('2021-12-08T23:34:09','alumno111234',true,'50011007');

/*-------------------------------------------Ingreso-Solicitud-Clase-Alumno-----------------------------------------*/

/*-Sol-Alum-Matheo-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T02:34:09',false,'52848682');

insert into claseSolicitudClaseAl
values(1,10,1);

insert into asignaturaSolicitudClaseAl
values(1,10,1,'geo2',true);

insert into claseSolicitudClaseAl
values(1,11,2);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(1,11,2,'rds2',true);

insert into RespondeClaseAl
values(1,'00000000');

/*-Sol-Alum-Mauro-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T03:34:09',false,'52124670');

insert into claseSolicitudClaseAl
values(2,10,1);

insert into asignaturaSolicitudClaseAl
values(2,10,1,'geo2',true);

insert into claseSolicitudClaseAl
values(2,11,2);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(2,11,2,'rds2',true);

insert into RespondeClaseAl
values(2,'00000000');

/*-Sol-Alum-Agus-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T04:34:09',false,'51972127');

insert into claseSolicitudClaseAl
values(3,10,1);

insert into asignaturaSolicitudClaseAl
values(3,10,1,'geo2',true);

insert into claseSolicitudClaseAl
values(3,11,2);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(3,11,2,'rds2',true);

insert into RespondeClaseAl
values(3,'00000000');

/*-Sol-Alum-3-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T05:34:09',false,'50003002');

insert into claseSolicitudClaseAl
values(4,11,2);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(4,11,2,'rds2',true);

insert into RespondeClaseAl
values(4,'00000000');

/*-Sol-Alum-4-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T06:34:09',false,'50004006');

insert into claseSolicitudClaseAl
values(5,11,2);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(5,11,2,'rds2',true);

insert into RespondeClaseAl
values(5,'00000000');

/*-Sol-Alum-5-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T07:34:09',false,'50005000');

insert into claseSolicitudClaseAl
values(6,11,2);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(6,11,2,'rds2',true);

insert into RespondeClaseAl
values(6,'00000000');

/*-Sol-Alum-6-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T08:34:09',false,'50006004');

insert into claseSolicitudClaseAl
values(7,11,2);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(7,11,2,'rds2',true);

insert into RespondeClaseAl
values(7,'00000000');

/*-Sol-Alum-7-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T09:34:09',false,'50007008');

insert into claseSolicitudClaseAl
values(8,11,2);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(8,11,2,'rds2',true);

insert into RespondeClaseAl
values(8,'00000000');

/*-Sol-Alum-8-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T10:34:09',false,'50008002');

insert into claseSolicitudClaseAl
values(9,11,2);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(9,11,2,'rds2',true);

insert into RespondeClaseAl
values(9,'00000000');

/*-Sol-Alum-10-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T11:34:09',true,'50009006');

insert into claseSolicitudClaseAl
values(10,12,2);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(10,12,2,'rds2',true);

insert into RespondeClaseAl
values(10,'00000000');

/*-Sol-Alum-11-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T13:34:09',true,'50010003');

insert into claseSolicitudClaseAl
values(11,12,2);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(11,12,2,'rds2',true);

insert into RespondeClaseAl
values(11,'00000000');

/*-Sol-Alum-12-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T13:34:09',true,'50011007');

insert into claseSolicitudClaseAl
values(12,12,2);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(12,12,2,'rds2',true);

insert into RespondeClaseAl
values(12,'00000000');

/*-Sol-Alum-13-*/
insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-16T14:34:09',true,'50012001');

insert into claseSolicitudClaseAl
values(13,12,2);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'so3',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'ada',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'forme',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'mate3',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'ing3',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'soci',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'filo',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'proyds',true);

insert into asignaturaSolicitudClaseAl
values(13,12,2,'rds2',true);

insert into RespondeClaseAl
values(13,'00000000');

/*-------------------------------------------Ingreso-Solicitud-Clase-Docente-----------------------------------------*/

/*-Sol-Docen-1-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-16T23:34:09',false,'30001008');

insert into claseSolicitudClaseDo
values(1,11,2);

insert into asignaturaSolicitudClaseDO
values(1,11,2,'so3',true);

insert into claseSolicitudClaseDo
values(1,12,2);

insert into asignaturaSolicitudClaseDo
values(1,12,2,'so3',true);

insert into claseSolicitudClaseDo
values(1,13,2);

insert into asignaturaSolicitudClaseDo
values(1,13,2,'so3',true);

insert into claseSolicitudClaseDo
values(1,14,2);

insert into asignaturaSolicitudClaseDo
values(1,14,2,'so3',true);

insert into claseSolicitudClaseDo
values(1,15,3);

insert into asignaturaSolicitudClaseDo
values(1,15,3,'so3',true);

insert into claseSolicitudClaseDo
values(1,16,3);

insert into asignaturaSolicitudClaseDo
values(1,16,3,'so3',true);

insert into claseSolicitudClaseDo
values(1,17,3);

insert into asignaturaSolicitudClaseDo
values(1,17,3,'so3',true);

insert into claseSolicitudClaseDo
values(1,18,3);

insert into asignaturaSolicitudClaseDo
values(1,18,3,'so3',true);

insert into RespondeClaseDo
values(1,'00000000');

/*-Sol-Docen-2-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-17T23:34:09',false,'30002002');

insert into claseSolicitudClaseDo
values(2,11,2);

insert into asignaturaSolicitudClaseDO
values(2,11,2,'ada',true);

insert into claseSolicitudClaseDo
values(2,12,2);

insert into asignaturaSolicitudClaseDo
values(2,12,2,'ada',true);

insert into claseSolicitudClaseDo
values(2,13,2);

insert into asignaturaSolicitudClaseDo
values(2,13,2,'ada',true);

insert into claseSolicitudClaseDo
values(2,14,2);

insert into asignaturaSolicitudClaseDo
values(2,14,2,'ada',true);

insert into claseSolicitudClaseDo
values(2,15,3);

insert into asignaturaSolicitudClaseDo
values(2,15,3,'ada',true);

insert into claseSolicitudClaseDo
values(2,16,3);

insert into asignaturaSolicitudClaseDo
values(2,16,3,'ada',true);

insert into claseSolicitudClaseDo
values(2,17,3);

insert into asignaturaSolicitudClaseDo
values(2,17,3,'ada',true);

insert into claseSolicitudClaseDo
values(2,18,3);

insert into asignaturaSolicitudClaseDo
values(2,18,3,'ada',true);

insert into RespondeClaseDo
values(2,'00000000');

/*-Sol-Docen-3-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-19T23:34:09',false,'30039009');

insert into claseSolicitudClaseDo
values(3,11,2);

insert into asignaturaSolicitudClaseDO
values(3,11,2,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,12,2);

insert into asignaturaSolicitudClaseDo
values(3,12,2,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,13,2);

insert into asignaturaSolicitudClaseDo
values(3,13,2,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,14,2);

insert into asignaturaSolicitudClaseDo
values(3,14,2,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,15,3);

insert into asignaturaSolicitudClaseDo
values(3,15,3,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,16,3);

insert into asignaturaSolicitudClaseDo
values(3,16,3,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,17,3);

insert into asignaturaSolicitudClaseDo
values(3,17,3,'bdd2',true);

insert into claseSolicitudClaseDo
values(3,18,3);

insert into asignaturaSolicitudClaseDo
values(3,18,3,'bdd2',true);

insert into RespondeClaseDo
values(3,'00000000');

/*-Sol-Docen-4-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-20T23:34:09',false,'30004000');

insert into claseSolicitudClaseDo
values(4,11,2);

insert into asignaturaSolicitudClaseDO
values(4,11,2,'forme',true);

insert into claseSolicitudClaseDo
values(4,12,2);

insert into asignaturaSolicitudClaseDo
values(4,12,2,'forme',true);

insert into claseSolicitudClaseDo
values(4,13,2);

insert into asignaturaSolicitudClaseDo
values(4,13,2,'forme',true);

insert into claseSolicitudClaseDo
values(4,14,2);

insert into asignaturaSolicitudClaseDo
values(4,14,2,'forme',true);

insert into claseSolicitudClaseDo
values(4,15,3);

insert into asignaturaSolicitudClaseDo
values(4,15,3,'forme',true);

insert into claseSolicitudClaseDo
values(4,16,3);

insert into asignaturaSolicitudClaseDo
values(4,16,3,'forme',true);

insert into claseSolicitudClaseDo
values(4,17,3);

insert into asignaturaSolicitudClaseDo
values(4,17,3,'forme',true);

insert into claseSolicitudClaseDo
values(4,18,3);

insert into asignaturaSolicitudClaseDo
values(4,18,3,'forme',true);

insert into RespondeClaseDo
values(4,'00000000');

/*-Sol-Docen-5-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-25T23:34:09',false,'30005004');

insert into claseSolicitudClaseDo
values(5,11,2);

insert into asignaturaSolicitudClaseDO
values(5,11,2,'mate3',true);

insert into claseSolicitudClaseDo
values(5,12,2);

insert into asignaturaSolicitudClaseDo
values(5,12,2,'mate3',true);

insert into claseSolicitudClaseDo
values(5,13,2);

insert into asignaturaSolicitudClaseDo
values(5,13,2,'mate3',true);

insert into claseSolicitudClaseDo
values(5,14,2);

insert into asignaturaSolicitudClaseDo
values(5,14,2,'mate3',true);

insert into claseSolicitudClaseDo
values(5,15,3);

insert into asignaturaSolicitudClaseDo
values(5,15,3,'mate3',true);

insert into claseSolicitudClaseDo
values(5,16,3);

insert into asignaturaSolicitudClaseDo
values(5,16,3,'mate3',true);

insert into claseSolicitudClaseDo
values(5,17,3);

insert into asignaturaSolicitudClaseDo
values(5,17,3,'mate3',true);

insert into claseSolicitudClaseDo
values(5,18,3);

insert into asignaturaSolicitudClaseDo
values(5,18,3,'mate3',true);

insert into RespondeClaseDo
values(5,'00000000');

/*-Sol-Docen-6-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-23T23:34:09',false,'30006008');

insert into claseSolicitudClaseDo
values(6,11,2);

insert into asignaturaSolicitudClaseDO
values(6,11,2,'ing3',true);

insert into claseSolicitudClaseDo
values(6,12,2);

insert into asignaturaSolicitudClaseDo
values(6,12,2,'ing3',true);

insert into claseSolicitudClaseDo
values(6,13,2);

insert into asignaturaSolicitudClaseDo
values(6,13,2,'ing3',true);

insert into claseSolicitudClaseDo
values(6,14,2);

insert into asignaturaSolicitudClaseDo
values(6,14,2,'ing3',true);

insert into claseSolicitudClaseDo
values(6,15,3);

insert into asignaturaSolicitudClaseDo
values(6,15,3,'ing3',true);

insert into claseSolicitudClaseDo
values(6,16,3);

insert into asignaturaSolicitudClaseDo
values(6,16,3,'ing3',true);

insert into claseSolicitudClaseDo
values(6,17,3);

insert into asignaturaSolicitudClaseDo
values(6,17,3,'ing3',true);

insert into claseSolicitudClaseDo
values(6,18,3);

insert into asignaturaSolicitudClaseDo
values(6,18,3,'ing3',true);

insert into RespondeClaseDo
values(6,'00000000');

/*-Sol-Docen-7-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-22T23:34:09',false,'30007002');

insert into claseSolicitudClaseDo
values(7,11,2);

insert into asignaturaSolicitudClaseDO
values(7,11,2,'soci',true);

insert into claseSolicitudClaseDo
values(7,12,2);

insert into asignaturaSolicitudClaseDo
values(7,12,2,'soci',true);

insert into claseSolicitudClaseDo
values(7,13,2);

insert into asignaturaSolicitudClaseDo
values(7,13,2,'soci',true);

insert into claseSolicitudClaseDo
values(7,14,2);

insert into asignaturaSolicitudClaseDo
values(7,14,2,'soci',true);

insert into claseSolicitudClaseDo
values(7,15,3);

insert into asignaturaSolicitudClaseDo
values(7,15,3,'soci',true);

insert into claseSolicitudClaseDo
values(7,16,3);

insert into asignaturaSolicitudClaseDo
values(7,16,3,'soci',true);

insert into claseSolicitudClaseDo
values(7,17,3);

insert into asignaturaSolicitudClaseDo
values(7,17,3,'soci',true);

insert into claseSolicitudClaseDo
values(7,18,3);

insert into asignaturaSolicitudClaseDo
values(7,18,3,'soci',true);

insert into RespondeClaseDo
values(7,'00000000');

/*-Sol-Docen-8-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-21T23:34:09',false,'30008006');

insert into claseSolicitudClaseDo
values(8,11,2);

insert into asignaturaSolicitudClaseDO
values(8,11,2,'filo',true);

insert into claseSolicitudClaseDo
values(8,12,2);

insert into asignaturaSolicitudClaseDo
values(8,12,2,'filo',true);

insert into claseSolicitudClaseDo
values(8,13,2);

insert into asignaturaSolicitudClaseDo
values(8,13,2,'filo',true);

insert into claseSolicitudClaseDo
values(8,14,2);

insert into asignaturaSolicitudClaseDo
values(8,14,2,'filo',true);

insert into claseSolicitudClaseDo
values(8,15,3);

insert into asignaturaSolicitudClaseDo
values(8,15,3,'filo',true);

insert into claseSolicitudClaseDo
values(8,16,3);

insert into asignaturaSolicitudClaseDo
values(8,16,3,'filo',true);

insert into claseSolicitudClaseDo
values(8,17,3);

insert into asignaturaSolicitudClaseDo
values(8,17,3,'filo',true);

insert into claseSolicitudClaseDo
values(8,18,3);

insert into asignaturaSolicitudClaseDo
values(8,18,3,'filo',true);

insert into RespondeClaseDo
values(8,'00000000');

/*-Sol-Docen-9-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-21T23:34:09',true,'30009000');

insert into claseSolicitudClaseDo
values(9,11,2);

insert into asignaturaSolicitudClaseDO
values(9,11,2,'progdw3',true);

insert into claseSolicitudClaseDo
values(9,12,2);

insert into asignaturaSolicitudClaseDo
values(9,12,2,'progdw3',true);

insert into claseSolicitudClaseDo
values(9,13,2);

insert into asignaturaSolicitudClaseDo
values(9,13,2,'progdw3',true);

insert into claseSolicitudClaseDo
values(9,14,2);

insert into asignaturaSolicitudClaseDo
values(9,14,2,'progdw3',true);

insert into RespondeClaseDo
values(9,'00000000');

/*-Sol-Docen-10-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-28T23:34:09',true,'30010007');

insert into claseSolicitudClaseDo
values(10,15,3);

insert into asignaturaSolicitudClaseDO
values(10,15,3,'proydw',true);

insert into claseSolicitudClaseDo
values(10,16,3);

insert into asignaturaSolicitudClaseDo
values(10,16,3,'proydw',true);

insert into claseSolicitudClaseDo
values(10,17,3);

insert into asignaturaSolicitudClaseDo
values(10,17,3,'proydw',true);

insert into claseSolicitudClaseDo
values(10,18,3);

insert into asignaturaSolicitudClaseDo
values(10,18,3,'proydw',true);

insert into RespondeClaseDo
values(10,'00000000');

/*-Sol-Docen-11-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-28T23:35:09',true,'30011001');

insert into claseSolicitudClaseDo
values(11,15,3);

insert into asignaturaSolicitudClaseDO
values(11,15,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(11,16,3);

insert into asignaturaSolicitudClaseDo
values(11,16,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(11,17,3);

insert into asignaturaSolicitudClaseDo
values(11,17,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(11,18,3);

insert into asignaturaSolicitudClaseDo
values(11,18,3,'progdw3',true);

insert into RespondeClaseDo
values(11,'00000000');

/*-Sol-Docen-12-*/
insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-28T23:36:09',true,'30012005');

insert into claseSolicitudClaseDo
values(12,15,3);

insert into asignaturaSolicitudClaseDO
values(12,15,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(12,16,3);

insert into asignaturaSolicitudClaseDo
values(12,16,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(12,17,3);

insert into asignaturaSolicitudClaseDo
values(12,17,3,'progdw3',true);

insert into claseSolicitudClaseDo
values(12,18,3);

insert into asignaturaSolicitudClaseDo
values(12,18,3,'progdw3',true);

insert into RespondeClaseDo
values(12,'00000000');

/*----------------------------------------------Ingreso-Solicitud-de-Chat---------------------------------------------*/

/*-Chat-1-*/
insert into SolicitaChat
values('52848682','30003006','2021-08-12T11:34:09',11,2,'bdd2',false);

/*-Chat-2-*/
insert into SolicitaChat
values('52848682','30001008','2021-08-15T11:34:09',11,2,'so3',false);

/*-Chat-3-*/
insert into SolicitaChat
values('52848682','30004000','2021-08-17T11:34:09',11,2,'forme',false);

/*-Chat-4-*/
insert into SolicitaChat
values('52848682','30005004','2021-08-18T11:34:09',11,2,'mate3',false);

/*----------------------------------------------------Ingreso-Chat----------------------------------------------------*/

/*-Chat-1-*/
insert into Chat(idClase,oriClase,asignatura,fecha,horaInicio,horaFin,titulo,activo)
values(11,2,'bdd2','2021-08-12','11:40:32','12:09:13','Consulta sobre permisos en MySQL',false);

insert into ChateaAl
values('52848682',1,'11:40:32','¡ Palme ha ingresado al chat !');

insert into ChateaDo
values('30039009',1,'11:40:33','¡ Alberto ha ingresado al chat !');

insert into ChateaAl
values('52124670',1,'11:41:02','¡ Mauro ha ingresado al chat !');

insert into ChateaAl
values('52848682',1,'11:41:26','En el pdf de consultas, hay un comando que se llama HAVING, este va para el proximo escrito?');

insert into ChateaDo
values('30039009',1,'11:42:10','Si, having va, ya que forma parte de los temas de consultas');

insert into ChateaAl
values('51972127',1,'11:42:16','¡ Agustin ha ingresado al chat !');

insert into ChateaAl
values('52124670',1,'11:42:45','Queeeee!! hay escrito de bdd, para cuando es?');

insert into ChateaAl
values('51972127',1,'11:42:57','jajajajajajaj');

insert into ChateaDo
values('30039009',1,'11:45:32','El escrito es para el proximo martes, aun tiene una semana para repasar. este mas atento!!');

insert into ChateaAl
values('52124670',1,'11:46:42','Uh la baja');

insert into ChateaAl
values('52124670',1,'11:48:03','Y having q es? es un comando pero para q sirve');

insert into ChateaAl
values('52848682',1,'11:49:12','Es como el where pero se usa despues de un group by, y en este se puede funciones. Es una restriccion');

insert into ChateaDo
values('30039009',1,'11:50:43','Muy bien matheo!');

insert into ChateaDo
values('30039009',1,'12:03:58','Chicos voy a cerrar el chat que ya casi es la hora, si alguien tiene alguna otra consulta, este es el momento');

insert into ChateaAl
values('52848682',1,'12:05:09','Profe, el chat solo puede ser cerrado por el alumno que lo creo. Digame y yo lo cierro');


/*-Chat-2-*/
insert into Chat(idClase,oriClase,asignatura,fecha,horaInicio,horaFin,titulo,activo)
values(11,2,'so3','2021-08-15','11:40:32','12:09:13','Consulta sobre ultimo tema dado',false);

insert into ChateaAl
values('52848682',2,'11:40:32','¡ Palme ha ingresado al chat !');

insert into ChateaDo
values('30001008',2,'11:40:33','¡ Pedro ha ingresado al chat !');

insert into ChateaAl
values('52124670',2,'11:41:02','¡ Mauro ha ingresado al chat !');

insert into ChateaAl
values('52848682',2,'11:41:26','En la clase pasada no entendi tanto, podriamos hacer un mini repaso por el chat?');

insert into ChateaDo
values('30001008',2,'11:42:10','Si, claro!');

insert into ChateaAl
values('51972127',2,'11:42:16','¡ Agustin ha ingresado al chat !');

insert into ChateaDo
values('30001008',2,'11:42:45','Les voy a subir un pdf corto, de 2 paginas por mail');

insert into ChateaAl
values('51972127',2,'11:42:57','ok profe');

insert into ChateaDo
values('30001008',2,'11:45:32','Listo, esta subido, vayan a verlo.');

insert into ChateaAl
values('52124670',2,'11:46:42','Muchas gracias profe, nos vemos la proxima clase');

insert into ChateaAl
values('52848682',2,'11:49:12','Cierro el chat profe, o alguien necesita algo mas?');
 
 insert into ChateaAl
values('51972127',2,'12:05:09','Por mi no, cerra tranqui');

insert into ChateaDo
values('30001008',2,'12:03:58','Cierrenlo chicos, cualquier cosa hacen otra soliciud para un chat');


/*-Chat-3-*/
insert into Chat(idClase,oriClase,asignatura,fecha,horaInicio,horaFin,titulo,activo)
values(11,2,'forme','2021-09-27','11:40:32','12:09:13','Consulta sobre ultimo tema dado',false);

insert into ChateaAl
values('52848682',3,'11:40:32','¡ Palme ha ingresado al chat !');

insert into ChateaDo
values('30004000',3,'11:40:33','¡ Alber ha ingresado al chat !');

insert into ChateaAl
values('52124670',3,'11:41:02','¡ Mauro ha ingresado al chat !');
 
insert into ChateaAl
values('51972127',3,'11:42:16','¡ Agustin ha ingresado al chat !');

insert into ChateaAl
values('50003002',3,'11:42:16','¡ Andres ha ingresado al chat !');

insert into ChateaAl
values('50004006',3,'11:42:16','¡ Cristiano ha ingresado al chat !');

insert into ChateaAl
values('50005000',3,'11:42:16','¡ Gerard ha ingresado al chat !');

insert into ChateaAl
values('50006004',3,'11:42:16','¡ Isabella ha ingresado al chat !');

insert into ChateaAl
values('50007008',3,'11:42:16','¡ Martina ha ingresado al chat !');

insert into ChateaAl
values('50008002',3,'11:42:16','¡ Benjamin ha ingresado al chat !');

insert into ChateaAl
values('52848682',3,'11:41:26','En la clase pasada no entendi tanto, podriamos hacer un mini repaso por el chat?');

insert into ChateaDo
values('30004000',3,'11:42:10','Si, claro!');

insert into ChateaDo
values('30004000',3,'11:42:45','Les voy a subir un pdf corto, de 2 paginas por mail');

insert into ChateaAl
values('51972127',3,'11:42:57','ok profe');

insert into ChateaDo
values('30004000',3,'11:45:32','Listo, esta subido, vayan a verlo.');

insert into ChateaAl
values('52124670',3,'11:46:42','Muchas gracias profe, nos vemos la proxima clase');

insert into ChateaAl
values('52848682',3,'11:49:12','Cierro el chat profe, o alguien necesita algo mas?');
 
 insert into ChateaAl
values('51972127',3,'12:05:09','Por mi no, cerra tranqui');

insert into ChateaDo
values('30004000',3,'12:03:58','Cierrenlo chicos, cualquier cosa hacen otra soliciud para un chat');


/*-Chat-4-*/
insert into Chat(idClase,oriClase,asignatura,fecha,horaInicio,horaFin,titulo,activo)
values(11,2,'mate3','2021-08-18','11:40:32','12:09:13','Limites',true);

insert into ChateaAl
values('52848682',4,'11:40:32','¡ Palme ha ingresado al chat !');

insert into ChateaDo
values('30005004',4,'11:40:33','¡ Ezequiel ha ingresado al chat !');

insert into ChateaAl
values('52124670',4,'11:41:33','¡ Mauro ha ingresado al chat !');