use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------Consultas-SQL-indicadas-por-el-docente,-1ra.-Versión-------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*---------------------------Para-cada-alumno-mostrar-su-nombre-y-cuantas-consultas-asincronicas-tuvo---------------------------*/

select us.nombre, count(*) as 'Cantidad de consultas'
from Alumno al inner join Usuario us on al.ci = us.ci inner join Mensaje me on al.ci = me.alumno
group by al.ci;

/*---------------------------------Para-cada-grupo-mostrar-su-nombre-y-en-cuantos-chat-participo--------------------------------*/

select cl.anio, cl.nombre, count(*) as 'Cantidad de chats'
from Clase cl inner join Chat ch on (cl.idClase = ch.idClase and cl.orientacion = ch.oriClase)
group by cl.idClase,cl.orientacion;

/*------------------------------Mostrar-las-materias-que-fueron-tratados-en-el-chat-más-de-3-veces-----------------------------*/

select asi.nombre
from Asignatura asi inner join Chat ch on asi.id = ch.asignatura
group by asi.id
having count(asi.id) > 3;

/*------------------Mostrar-nombre-y-apellido-de-los-alumnos-y-su-historial-de-consultas-y-chat(fecha-y-tema)-----------------*/

select us.nombre, us.apellido, date(me.fechaHora) as 'Fecha de mensaje', me.asunto
from Alumno al inner join Usuario us on al.ci = us.ci inner join Mensaje me on al.ci = me.alumno; 


select us.nombre, us.apellido, ch.fecha, ch.titulo
from Alumno al inner join Usuario us on al.ci = us.ci inner join ChateaAl cha on al.ci = cha.ci inner join Chat ch on cha.idChat = ch.idChat
group by al.ci,ch.idChat;

/*Mostrar-el-nombre-de-los-docentes-y-la-cantidad-de-chats-en-los-que-participaron-en-los-ultimos-15-días-(utilizar-funciones-de-fecha)*/

select us.nombre, count(doc.ci) as 'Cantidad de chats' 
from Docente doc inner join Usuario us on doc.ci = us.ci inner join ChateaDo chd on doc.ci = chd.ci inner join Chat ch on chd.idChat = ch.idChat
where ch.fecha >= (curdate() - interval '15' day)
group by doc.ci;
