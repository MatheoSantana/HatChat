use Hatchat;

/*------------------------------------------------------------------------------------------------------------------------------*/
/*---------------------------------------------------Implementación-de-vistas---------------------------------------------------*/
/*------------------------------------------------------------------------------------------------------------------------------*/

/*--------------------------------------------------------Usuario-Administrador--------------------------------------------------------*/

/*-Asignaturas-*/
create view Vasignatura (id, nombre, anio, activo) as
					select *
					from asignatura
                    where activo = true
                    order by anio;
                    
grant select on hatchat.Vasignatura to Administrador;


/*-Orientaciones-*/
create view Vorientacion (id, nombre, activo) as
					select *
					from Orientacion
                    where activo = true;
                    
grant select on hatchat.Vorientacion to Administrador;


/*-Solicitud-Modificar-Contraseña-*/
create view VsolModif (idSolicitudModif, fechaHora, contraNueva, pendiente, aceptada, usuario) as
					select * 
                    from SolicitudModif 
                    where pendiente = false 
                    order by fechaHora;

grant select on hatchat.VsolModif to Administrador;


/*-Solicitud-Clase-Alumno-*/
create view Vsolclaseal (idSolicitudClaseAl, fechaHora, pendiente, alumno) as
					select * 
                    from SolicitudClaseAl 
                    where pendiente = false 
                    order by fechaHora;

grant select on hatchat.Vsolclaseal to Administrador;
				

/*-Solicitud-Clase-Docente-*/
create view Vsolclasedo (idSolicitudClaseDo, fechaHora, pendiente, docente) as
					select * 
                    from SolicitudClaseDo 
                    where pendiente = false 
                    order by fechaHora;

grant select on hatchat.Vsolclasedo to Administrador;
