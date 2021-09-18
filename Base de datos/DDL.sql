

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
contraseña varchar(30) not null,
apellido varchar(30) not null,
segApellido varchar(30),
resSeguridad varchar(30) not null,
foto mediumblob,
activo boolean,
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
activo boolean,
primary key(id));

create table Orientacion(
id int auto_increment not null,
nombre varchar(60) not null,
activo boolean,
primary key(id));

create table Contiene(
idAsig varchar(10) not null,
idOri int not null,
primary key(idAsig,idOri),
foreign key(idAsig) references Asignatura(id),
foreign key(idOri) references Orientacion(id));

create table Clase(
idClase int auto_increment not null,
nombre varchar(4) not null,
anio int not null,
orientacion int not null,
activo boolean,
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
nomDia enum("Lunes","Martes","Miercoles","Jueves","Viernes","Sabado") not null,
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

create table RespondeClase(
idSolicitudClaseAl int not null,
ciAdmin char(8) not null,
primary key(idSolicitudClaseAl,ciAdmin),
foreign key(idSolicitudClaseAl) references SolicitudClaseAl(idSolicitudClaseAl),
foreign key(ciAdmin) references Administrador(ci)); 

create table RespondeClase2(
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
horaInico time not null,
horaFin time,
titulo varchar(60),
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
