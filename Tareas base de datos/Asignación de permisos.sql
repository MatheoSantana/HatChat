use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------Estudio-de-los-permisos---------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*--------------------------------------------------------Usuario-Alumno--------------------------------------------------------*/

create user Alumno@'%';

grant insert (fechaHora,contraNueva,pendiente,usuario) on Hatchat.SolicitudModif to Alumno;
grant insert on Hatchat.Responde to Alumno;
grant insert on Hatchat.Usuario to Alumno;
grant insert (fechaHora,pendiente,alumno) on Hatchat.SolicitudClaseAl to Alumno;
grant insert on Hatchat.claseSolicitudClaseAl to Alumno;
grant insert on Hatchat.asignaturaSolicitudClaseAl to Alumno;
grant insert on Hatchat.RespondeClaseAl to Alumno;
grant insert on Hatchat.SolicitaChat to Alumno;
grant insert (docente,alumno,fechaHora,mensajeAlumno,estado,asunto) on Hatchat.Mensaje to Alumno;

grant select on Hatchat.Alumno to Alumno;
grant select on Hatchat.Docente to Alumno;
grant select (ci,apodo,nombre,contrasenia,resSeguridad,foto,activo,id) on Hatchat.Usuario to Alumno;
grant select on Hatchat.PreguntaSeguridad to Alumno;
grant select on Hatchat.Orientacion to Alumno;
grant select on Hatchat.Clase to Alumno;
grant select on Hatchat.Contiene to Alumno;
grant select on Hatchat.asignatura to Alumno;
grant select on Hatchat.asignaturacursa to Alumno;
grant select on Hatchat.asignaturadictada to Alumno;
grant select (idChat,idClase,asignatura,titulo,activo) on Hatchat.chat to Alumno;
grant select on Hatchat.chateaal to Alumno;
grant select on Hatchat.chateado to Alumno;
grant select (nombre,anio) on Hatchat.clase to Alumno;
grant select on Hatchat.agenda to Alumno;
grant select on Hatchat.mensaje to Alumno;
grant select on Hatchat.asignaturadictada to Alumno;
grant select on Hatchat.asignaturacursa to Alumno;

grant update (apodo,contrasenia,resSeguridad,foto,activo,id) on Hatchat.usuario to Alumno;
grant update (estado) on Hatchat.mensaje to Alumno;

/*--------------------------------------------------------Usuario-Docente--------------------------------------------------------*/

create user Docente@'%';

grant delete,select on Hatchat.agenda to Docente;

grant insert (fechaHora,contraNueva,pendiente,usuario) on Hatchat.SolicitudModif to Docente;
grant insert on Hatchat.responde to Docente;
grant insert on Hatchat.usuario to Docente;
grant insert (fechaHora,pendiente,docente) on Hatchat.solicitudclasedo to Docente;
grant insert on Hatchat.clasesolicitudclasedo to Docente;
grant insert on Hatchat.asignaturasolicitudclasedo to Docente;
grant insert on Hatchat.respondeclaseDo to Docente;
grant insert (mensajeDocente,fechaHoraDocente) on Hatchat.mensaje to Docente;
grant insert (nomDia,horaInicio,horaFin,ci) on Hatchat.agenda to Docente;

grant select on Hatchat.docente to Docente;
grant select on Hatchat.alumno to Docente;
grant select (ci,apodo,nombre,contrasenia,apellido,resSeguridad,foto,activo,id) on Hatchat.usuario to Docente;
grant select on Hatchat.preguntaseguridad to Docente;
grant select on Hatchat.orientacion to Docente;
grant select on Hatchat.clase to Docente;
grant select on Hatchat.contiene to Docente;
grant select on Hatchat.asignatura to Docente;
grant select on Hatchat.solicitachat to Docente;
grant select (idChat,idClase,oriClase,asignatura,titulo,activo) on Hatchat.chat to Docente;
grant select on Hatchat.chateaal to Docente;
grant select on Hatchat.chateado to Docente;
grant select on Hatchat.mensaje to Docente;
grant select on Hatchat.agenda to Docente;
grant select on Hatchat.asignaturadictada to Docente;
grant select on Hatchat.asignaturacursa to Docente;

grant update (pendiente) on Hatchat.solicitachat to Docente;
grant update (estado) on Hatchat.mensaje to Docente;
grant update (apodo,contrasenia,resSeguridad,foto,activo,id) on Hatchat.usuario to Docente;
grant update (dictando) on Hatchat.asignaturaDictada to Docente;

/*--------------------------------------------------------Usuario-Administrador--------------------------------------------------------*/

create user Administrador@'%';

grant delete on Hatchat.contiene to Administrador;

grant insert (ci,nombre,contrasenia,apellido,segApellido,resSeguridad,foto,activo,id) on Hatchat.usuario to Administrador;
grant insert on Hatchat.cursa to Administrador;
grant insert on Hatchat.asignaturacursa to Administrador;
grant insert on Hatchat.dicta to Administrador;
grant insert on Hatchat.asignaturadictada to Administrador;
grant insert on Hatchat.alumno to Administrador;
grant insert on Hatchat.docente to Administrador;
grant insert (nomDia,horaInicio,horaFin,ci) on Hatchat.agenda to Administrador;
grant insert on Hatchat.asignatura to Administrador;
grant insert (nombre,activo) on Hatchat.orientacion to Administrador;
grant insert on Hatchat.contiene to Administrador;
grant insert (nombre,anio,orientacion,activo) on Hatchat.clase to Administrador;
grant insert on Hatchat.asignaturasolicitudclaseal to Administrador;
grant insert (aceptada) on Hatchat.solicitudModif to Administrador;

grant select on Hatchat.alumno to Administrador;
grant select on Hatchat.docente to Administrador;
grant select (ci,nombre,apellido,segApellido) on Hatchat.usuario to Administrador;
grant select on Hatchat.preguntaseguridad to Administrador;
grant select on Hatchat.solicitudmodif to Administrador;
grant select on Hatchat.solicitudclaseal to Administrador;
grant select on Hatchat.clasesolicitudclaseal to Administrador;
grant select on Hatchat.asignaturasolicitudclaseal to Administrador;
grant select on Hatchat.solicitudclasedo to Administrador;
grant select on Hatchat.clasesolicitudclasedo to Administrador;
grant select on Hatchat.asignaturasolicitudclasedo to Administrador;
grant select on Hatchat.cursa to Administrador;
grant select on Hatchat.asignaturacursa to Administrador;
grant select on Hatchat.agenda to Administrador;
grant select on Hatchat.contiene to Administrador;
grant select on Hatchat.clase to Administrador;
grant select on Hatchat.respondeclaseAl to Administrador;
grant select on Hatchat.respondeclaseDo to Administrador;
grant select on Hatchat.responde to Administrador;

grant update (apodo,nombre,contrasenia,apellido,segApellido,resSeguridad,foto,activo,id) on Hatchat.usuario to Administrador;
grant update (pendiente) on Hatchat.solicitudclaseal to Administrador;
grant update (aceptada) on Hatchat.asignaturasolicitudclaseal to Administrador;
grant update (pendiente) on Hatchat.solicitudclasedo to Administrador;
grant update (aceptada) on Hatchat.asignaturasolicitudclasedo to Administrador;
grant update (id,nombre,anio,activo) on Hatchat.asignatura to Administrador;
grant update on Hatchat.orientacion to Administrador;
grant update on Hatchat.clase to Administrador;
