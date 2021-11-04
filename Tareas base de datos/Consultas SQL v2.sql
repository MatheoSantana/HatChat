use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------------------------Consultas-SQL-3--------------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*Mostrar el nombre de los docentes de la asignatura "Bases de Datos" que respondieron más consultas en el último mes (30 días anteriores) que algún docente de Programación*/

select u.nombre
from mensaje m inner join usuario u on m.docente = u.ci
where (docente in(select d.ci
				from Docente d inner join asignaturaDictada a on d.ci = a.ci
				where (a.asignaturaDictada = 'bdd2' or a.asignaturaDictada = 'bdd1')
                group by d.ci)) and (date(fechaHoraDocente) >= (curdate() - interval '30' day)) 
group by m.docente
having count(*) > any(select count(*)
						from mensaje
						where(docente in(select d.ci
										from Docente d inner join asignaturaDictada a on d.ci = a.ci
										where (a.asignaturaDictada = 'progds3' or a.asignaturaDictada = 'progdw3' or a.asignaturaDictada = 'progi1' or a.asignaturaDictada = 'progi2')
										group by d.ci)) and (date(fechaHoraDocente) >= (curdate() - interval '30' day))
						group by docente);


/*Mostrar el total de consultas asincrónicas realizadas en los meses de agosto, setiembre y octubre. Deberán aparecer tres líneas, una para cada mes indicando la cantidad de consultas*/

select monthname(fechaHora), count(*)
from mensaje
where month(fechaHora) in(8,9,10)
group by month(fechaHora);


/*Mostrar el nombre de los alumnos que no participaron en chats en el último mes*/

select u.nombre
from chateaAl ch inner join alumno a on ch.ci = a.ci inner join usuario u on a.ci = u.ci inner join chat c on ch.idChat = c.idChat
where c.fecha  >= (curdate() - interval '30' day)
group by a.ci;


/*Mostrar la cantidad de veces que hubo chats para cada asignatura los últimos 30 días. Mostrar únicamente aquellos que hayan tenido más de tres chats*/

select asignatura, count(*)
from chat c
where fecha >= (curdate() - interval '30' day)
group by asignatura
having count(*) > 3;


/*Mostrar los datos de los docentes y los chats donde han participado. En caso de no haber participado, deberán mostrarse de todos modos los datos de esos docentes*/

select *
from docente d inner join usuario u on d.ci = u.ci left join chateaDo cd on d.ci = cd.ci left join chat c on cd.idChat = c.idChat
group by c.idChat, d.ci;


/*Mostrar el o los nombres de los docentes que han respondido más consultas asincrónicas*/

select u.nombre, count(*)
from mensaje m inner join usuario u on m.docente = u.ci
group by m.docente
having count(*) = max((	select count(*)
						from mensaje m inner join usuario u on m.docente = u.ci
						group by m.docente desc limit 1));


/*Crear una vista que muestre los datos de los chats que han participado el grupo 3ºBA en la última semana. Otorgarle al usuario u_prueba permisos para ver esa vista*/

create user u_prueba;

create view Chats3BA (idClase, oriClase, asignatura, fecha, horaInicio, horaFin, titulo, chatActivo, nombre, anio, claseActivo) as
					select ch.idClase, ch.oriClase, ch.asignatura, ch.fecha, ch.horaInicio, ch.horaFin, ch.titulo, ch.activo, c.nombre, c.anio, c.activo
					from chat ch inner join clase c on ch.idClase = c.idClase
                    where c.nombre = 'BA' and c.anio = 3 and ch.fecha >= (curdate() - interval '7' day);
                    
grant select on hatchat.Chats3BA to u_prueba;





