use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*------------------------------------------------------Datos-precargados-------------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*------------------------------------------------------Pregunta-Seguridad------------------------------------------------------*/
insert into PreguntaSeguridad(pregSeguridad)
values('¿Cuál es el nombre de tu primer mascota?');

insert into PreguntaSeguridad(pregSeguridad)
values('¿En qué calle está ubicado tu primer hogar?');

insert into PreguntaSeguridad(pregSeguridad)
values('¿Cual es tu sabor de helado favorito?');

/*------------------------------------------------------Ingreso-Asignaturas-----------------------------------------------------*/
insert into Asignatura
values ('progds3','Programacion III',3,true);

insert into Asignatura
values ('bdd2','Base de datos II',3,true);

insert into Asignatura
values ('progdw3','Programacion web',3,true);

insert into Asignatura
values ('mate3','Matematica',3,true);



insert into Asignatura
values ('progi1','Programacion I',1,true);

insert into Asignatura
values ('log','Logica',1,true);

/*-----------------------------------------------------Ingreso-Orientaciones-----------------------------------------------------*/
insert into Orientacion(nombre, activo)
values ('Desarrollo y soporte', true);

insert into Orientacion(nombre, activo)
values ('Desarrollo web', true);

/*--------------------------------------------------------Ingreso-Contiene-------------------------------------------------------*/
insert into Contiene
values('progds3',1);

insert into Contiene
values('bdd2',1);

insert into Contiene
values('mate3',1);


insert into Contiene
values('bdd2',2);

insert into Contiene
values('progdw3',2);

insert into Contiene
values('mate3',2);

/*---------------------------------------------------------Ingreso-Clase--------------------------------------------------------*/
insert into Clase(nombre,anio,orientacion)
values ('BA',3,1);

insert into Clase(nombre,anio,orientacion)
values ('BB',3,2); 

/*------------------------------------------------------Ingreso-Administrador---------------------------------------------------*/
insert into Usuario
values('00000000','Administrador','Administrador','L2tpbGwgQG1l','Del','Sistema','Agua granizada',null,true,3);

insert into Administrador
values('00000000'); 

/*--------------------------------------------------------Ingreso-Alumnos-------------------------------------------------------*/
/*--Alumno-1--*/
insert into Usuario
values('52848682','Palme','Matheo','matheo1234','santana','Honey','Guayabos',null,true,2);

insert into Alumno
values ('52848682');

insert into Cursa
values('52848682',1,1,2021);

insert into asignaturaCursa
values('52848682',1,1,2021,'progds3',true);

insert into asignaturaCursa
values('52848682',1,1,2021,'bdd2',true);

insert into asignaturaCursa
values('52848682',1,1,2021,'mate3',true);

/*--Alumno-2--*/
insert into Usuario
values('52124670','Mauro','Mauro','mauro1234','Liguori','Arias','Neron',null,true,1);

insert into Alumno
values ('52124670');

insert into Cursa
values('52124670',1,1,2021);

insert into Cursa
values('52124670',2,2,2021);

insert into asignaturaCursa
values('52124670',1,1,2021,'progds3',true);

insert into asignaturaCursa
values('52124670',1,1,2021,'bdd2',true);

/*--Alumno-3--*/
insert into Usuario
values('51972127','Agustin','Agustin','agustin1234','Pastorelli','Do Prado','Quichuas',null,true,2);

insert into Alumno
values ('51972127');

insert into Cursa
values('51972127',2,2,2021);

insert into asignaturaCursa
values('51972127',2,2,2021,'bdd2',true);

insert into asignaturaCursa
values('51972127',2,2,2021,'progdw3',true);

/*----------------------------------------------------Ingreso-Docentes---------------------------------------------------*/
/*--Docente-1--*/
insert into Usuario
values('12314542','Jose','Jose','12345678','Alvarez','Gutierrez','coco',null,true,3);

insert into Docente
values ('12314542');

insert into Dicta
values('12314542',1,1,2021);

insert into Dicta
values('12314542',2,2,2021);

insert into asignaturaDictada
values('12314542',1,1,2021,'progds3',true);

insert into asignaturaDictada
values('12314542',2,2,2021,'progdw3',true);

/*--Docente-2--*/
insert into Usuario
values('29993223','Pepe','Pedro','87654321','Sanachez','Guerra','Trueno',null,true,1);

insert into Docente
values ('29993223');

insert into Dicta
values('29993223',1,1,2021);

insert into Dicta
values('29993223',2,2,2021);

insert into asignaturaDictada
values('29993223',1,1,2021,'progds3',true);

/*--Docente-3--*/
insert into Usuario
values('40111234','Alber','Alberto','11111111','Santin','Fierro','Anini',null,true,1);

insert into Docente
values ('40111234');

insert into Dicta
values('40111234',1,1,2021);

insert into Dicta
values('40111234',2,2,2021);

insert into asignaturaDictada
values('40111234',1,1,2021,'bdd2',true);

insert into asignaturaDictada
values('40111234',2,2,2021,'bdd2',true);

/*----------------------------------------------------Ingreso-Agenda---------------------------------------------------*/
/*--Agenda-de-Docente-1--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','12314542');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','12314542');

/*--Agenda-de-Docente-2--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','29993223');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','29993223');

/*--Agenda-de-Docente-3--*/
insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Lunes','07:00:00','08:30:00','40111234');

insert into agenda(nomDia,horaInicio,horaFin,ci)
values('Martes','07:00:00','07:45:00','40111234');

/*----------------------------------------------------Ingreso-Mensaje---------------------------------------------------*/

insert into Mensaje(docente,alumno,fechaHora,mensajeAlumno,estado,asunto,mensajeDocente,fechaHoraDocente)
values('12314542','52848682','2021-06-01T23:34:09','Profe, podria mandar el pdf de metricas?, que me ayudaria un poco mas de material de repaso','contestado','PDF Metricas','Buen dia Matheo, claro lo subire a crea en la brevedad. Saludos cordiales.','2021-06-03T15:12:43');

/*-------------------------------------------Ingreso-Solicitud-Modificar-Perfil-----------------------------------------*/

insert into SolicitudModif(fechaHora,contraNueva,pendiente,usuario)
values('2021-09-01T23:34:09','AGUSTIN_MIO',false,'52848682');

insert into SolicitudModif(fechaHora,contraNueva,pendiente,usuario)
values('2021-09-01T23:34:09','mauro12345',true,'52124670');

insert into Responde
values(1,'00000000');

/*-------------------------------------------Ingreso-Solicitud-Clase-Alumno-----------------------------------------*/

insert into SolicitudClaseAl(fechaHora,pendiente,alumno)
values('2021-03-17T23:34:09',false,'52848682');

insert into claseSolicitudClaseAl
values(1,1,1);

insert into asignaturaSolicitudClaseAl
values(1,1,1,'progds3',true);

insert into asignaturaSolicitudClaseAl
values(1,1,1,'bdd2',true);

insert into asignaturaSolicitudClaseAl
values(1,1,1,'progdw3',true);

insert into asignaturaSolicitudClaseAl
values(1,1,1,'mate3',false);

insert into RespondeClase
values(1,'00000000');

/*-------------------------------------------Ingreso-Solicitud-Clase-Docente-----------------------------------------*/

insert into SolicitudClaseDo(fechaHora,pendiente,docente)
values('2021-03-16T23:34:09',false,'12314542');

insert into claseSolicitudClaseDo
values(1,1,1);

insert into claseSolicitudClaseDo
values(1,2,2);

insert into asignaturaSolicitudClaseDO
values(1,1,1,'progds3',true);

insert into asignaturaSolicitudClaseDo
values(1,1,1,'bdd2',false);

insert into asignaturaSolicitudClaseDo
values(1,1,1,'mate3',false);

insert into asignaturaSolicitudClaseDo
values(1,2,2,'progdw3',true);

insert into asignaturaSolicitudClaseDo
values(1,2,2,'bdd2',false);

insert into asignaturaSolicitudClaseDo
values(1,2,2,'mate3',false);

insert into RespondeClase2
values(1,'00000000');

/*----------------------------------------------Ingreso-Solicitud-de-Chat---------------------------------------------*/

insert into SolicitaChat
values('52848682','12314542','2021-08-12T11:34:09',1,1,'bdd2',false);

/*----------------------------------------------------Ingreso-Chat----------------------------------------------------*/

insert into Chat(idClase,oriClase,asignatura,fecha,horaInico,horaFin,titulo,activo)
values(1,1,'bdd2','2021-08-12','11:40:32','12:09:13','Consulta sobre permisos en MySQL',false);

insert into ChateaAl
values('52848682',1,'11:40:32','¡ Palme ha ingresado al chat !');

insert into ChateaDo
values('12314542',1,'11:40:33','¡ Jose ha ingresado al chat !');

insert into ChateaAl
values('52124670',1,'11:41:02','¡ Mauro ha ingresado al chat !');

insert into ChateaAl
values('52848682',1,'11:41:26','En el pdf de consultas, hay un comando que se llama HAVING, este va para el proximo escrito?');

insert into ChateaDo
values('12314542',1,'11:42:10','Si, having va, ya que forma parte de los temas de consultas');

insert into ChateaAl
values('51972127',1,'11:42:16','¡ Agustin ha ingresado al chat !');

insert into ChateaAl
values('52124670',1,'11:42:45','Queeeee!! hay escrito de bdd, para cuando es?');

insert into ChateaAl
values('51972127',1,'11:42:57','jajajajajajaj');

insert into ChateaDo
values('12314542',1,'11:45:32','El escrito es para el proximo martes, aun tiene una semana para repasar. este mas atento!!');

insert into ChateaAl
values('52124670',1,'11:46:42','Uh la baja');

insert into ChateaAl
values('52124670',1,'11:48:03','Y having q es? es un comando pero para q sirve');

insert into ChateaAl
values('52848682',1,'11:49:12','Es como el where pero se usa despues de un group by, y en este se puede funciones. Es una restriccion');

insert into ChateaDo
values('12314542',1,'11:50:43','Muy bien matheo!');

insert into ChateaDo
values('12314542',1,'12:03:58','Chicos voy a cerrar el chat que ya casi es la hora, si alguien tiene alguna otra consulta, este es el momento');

insert into ChateaAl
values('52848682',1,'12:05:09','Profe, el chat solo puede ser cerrado por el alumno que lo creo. Digame y yo lo cierro');
