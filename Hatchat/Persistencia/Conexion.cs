using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using Hatchat.Logica;

using System.Windows.Forms;

namespace Hatchat.Persistencia
{
    public class Conexion
    {

        static string server = "Server = localhost; ";
        static string port = "Port = 3306; ";
        static string database = "Database = Hatchat; ";
        static string uid = "Uid = root; ";
        static string pwd = "Pwd = math2002;";
        static string connection = server + port + database + uid + pwd;
        //inserts
        public void AltaUsuario(Usuario usuario)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insertUsuario = new MySqlCommand("insert into Usuario values('" + usuario.Ci + "','" + usuario.Apodo + "','" + usuario.Nombre + "','" + usuario.Password + "','" + usuario.Primer_apellido + "','" + usuario.Segundo_apellido + "','" + usuario.Respuesta_seguridad + "',@imagen," + usuario.Activo + "," + usuario.Preguta_seguridad + ");", conexion);
            insertUsuario.Parameters.AddWithValue("imagen", usuario.FotoDePerfil);
            MySqlCommand insertHijo = new MySqlCommand("insert into " + usuario.GetType().Name + " values('" + usuario.Ci + "');", conexion);
            insertUsuario.ExecuteNonQuery();
            insertHijo.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarSolicitudClaseAl(SolicitudClaseAl soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into solicitudClaseAl (fechaHora,pendiente,alumno) values('" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "'," + soli.Pendiente + ",'" + soli.Alumno + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarClaseSolicitudClaseAl(ClaseSolicitudClaseAl soliclase)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into claseSolicitudClaseAl (idSolicitudClaseAl,idClase,oriClase) values(" + soliclase.IdSolicitudClaseAl + "," + soliclase.IdClase + "," + soliclase.OriClase + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarAsignaturaSolicitudClaseAl(AsignaturaSolicitudClaseAl soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaSolicitudClaseAl (idSolicitudClaseAl,idClaseAsig,oriClaseAsig,idAsignatura,aceptada) values(" + soliAsig.IdSolicitudClaseAl + "," + soliAsig.IdClaseAsig + "," + soliAsig.OriClaseAsig + ",'" + soliAsig.IdAsignatura + "'," + soliAsig.Aceptada + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarSolicitudClaseDo(SolicitudClaseDo soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into SolicitudClaseDo (fechaHora,pendiente,docente) values('" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "'," + soli.Pendiente + ",'" + soli.Docente + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarClaseSolicitudClaseDo(ClaseSolicitudClaseDo soliclase)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into claseSolicitudClaseDo (idSolicitudClaseDo,idClase,oriClase) values(" + soliclase.IdSolicitudClaseDo + "," + soliclase.IdClase + "," + soliclase.OriClase + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarAsignaturaSolicitudClaseDo(AsignaturaSolicitudClaseDo soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaSolicitudClaseDo (idSolicitudClaseDo,idClaseAsig,oriClaseAsig,idAsignatura,aceptada) values(" + soliAsig.IdSolicitudClaseDo + "," + soliAsig.IdClaseAsig + "," + soliAsig.OriClaseAsig + ",'" + soliAsig.IdAsignatura + "'," + soliAsig.Aceptada + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarMensajeAlumno(Mensaje mensaje)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string fechahora = mensaje.FechaHoraAlumno.ToString("yyyy") + "-" + mensaje.FechaHoraAlumno.ToString("MM") + "-" + mensaje.FechaHoraAlumno.ToString("dd") + "T" + mensaje.FechaHoraAlumno.ToString("HH") + ":" + mensaje.FechaHoraAlumno.ToString("mm") + ":" + mensaje.FechaHoraAlumno.ToString("ss");
            MySqlCommand insert = new MySqlCommand("insert into Mensaje (docente,alumno,fechaHora,mensajeAlumno,estado,asunto) values('" + mensaje.Docente + "','" + mensaje.Alumno + "','" + fechahora + "','" + mensaje.MensajeAlumno + "','" + mensaje.Estado + "','" + mensaje.Asunto + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarMensajeDocente(Mensaje mensaje)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string fechahora = mensaje.FechaHoraAlumno.ToString("yyyy") + "-" + mensaje.FechaHoraAlumno.ToString("MM") + "-" + mensaje.FechaHoraAlumno.ToString("dd") + "T" + mensaje.FechaHoraAlumno.ToString("HH") + ":" + mensaje.FechaHoraAlumno.ToString("mm") + ":" + mensaje.FechaHoraAlumno.ToString("ss");
            string fechaHoraDocente = mensaje.FechaHoraDocente.ToString("yyyy") + "-" + mensaje.FechaHoraDocente.ToString("MM") + "-" + mensaje.FechaHoraDocente.ToString("dd") + "T" + mensaje.FechaHoraDocente.ToString("HH") + ":" + mensaje.FechaHoraDocente.ToString("mm") + ":" + mensaje.FechaHoraDocente.ToString("ss");
            MySqlCommand updateRespuesta = new MySqlCommand("update Mensaje set mensajeDocente ='" + mensaje.MensajeDocente + "' where alumno='" + mensaje.Alumno + "' and fechaHora='" + fechahora + "' ;", conexion);
            MySqlCommand updateFechaDocente = new MySqlCommand("update Mensaje set fechaHoraDocente ='" + fechaHoraDocente + "' where alumno='" + mensaje.Alumno + "' and fechaHora='" + fechahora + "' ;", conexion);
            MySqlCommand updateEstado = new MySqlCommand("update Mensaje set estado ='" + mensaje.Estado + "' where alumno='" + mensaje.Alumno + "' and fechaHora='" + fechahora + "' ;", conexion);
            updateRespuesta.ExecuteNonQuery();
            updateFechaDocente.ExecuteNonQuery();
            updateEstado.ExecuteNonQuery();
            conexion.Close();
        }


        //selects

        //login
        public Usuario SelectUsuarioCi(string ci)
        {
            Usuario us = new Usuario();
            MySqlDataReader reader;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Usuario where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    us.Ci = reader.GetString("ci");
                    us.Apodo = reader.GetString("apodo");
                    us.Nombre = reader.GetString("nombre");
                    us.Password = reader.GetString(3);
                    us.Primer_apellido = reader.GetString("apellido");
                    us.Segundo_apellido = reader.GetString("segApellido");
                    us.Respuesta_seguridad = reader.GetString("resSeguridad");
                    if (!(reader["foto"].ToString() == ""))
                    {
                        us.FotoDePerfil = (byte[])reader["foto"];
                    }
                    us.Activo = (bool)reader["activo"];
                    us.Preguta_seguridad = Convert.ToInt32(reader.GetString("id"));
                }
            }
            conexion.Close();
            return us;
        }
        public bool SelectAlumno(string ci)
        {
            bool encontrado = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Alumno where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                encontrado = true;
            }
            conexion.Close();
            return encontrado;
        }
        public bool SelectDocente(string ci)
        {
            bool encontrado = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Docente where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                encontrado = true;
            }
            conexion.Close();
            return encontrado;
        }
        public bool SelectAdministrador(string ci)
        {
            bool encontrado = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Administrador where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                encontrado = true;
            }
            conexion.Close();
            return encontrado;
        }
        //login

        //register docente
        public DataTable SelectSolicitudClaseDo()
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            DataTable data = new DataTable();
            string query = "select * from SolicitudClaseDo;";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            adapter.Fill(data);
            conexion.Close();
            return data;
        }
        public int SelectIdSolicitudClaseDo(SolicitudClaseDo soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idSolicitudClaseDo from SolicitudClaseDo where fechaHora='" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "' and docente='" + soli.Docente + "';", conexion);
            reader = select.ExecuteReader();
            int id=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetString("idSolicitudClaseDo"));
                }
            }
            conexion.Close();
            return id;
        }


        //register docente
        //register alumno
        public DataTable SelectSolicitudClaseAl()
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            DataTable data = new DataTable();
            string query = "select * from SolicitudClaseAl;";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            adapter.Fill(data);
            conexion.Close();
            return data;
        }

        public int SelectIdSolicitudClaseAl(SolicitudClaseAl soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idSolicitudClaseAl from SolicitudClaseAl where fechaHora='" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "' and alumno='" + soli.Alumno + "';", conexion);
            reader = select.ExecuteReader();
            int id=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetString("idSolicitudClaseAl"));
                }
            }
            conexion.Close();
            return id;
        }
        //register alumno

        //Mensaje Alumno

        public List<Logica.Docente> SelectDocentesDictandoAAlumno(string ci)
        {
            List<Logica.Docente> docentes = new List<Docente>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select Usuario.ci, Usuario.nombre, Usuario.apellido, Usuario.segApellido, Usuario.foto, Usuario.apodo, Usuario.activo from Usuario, Docente, asignaturaDictada, asignaturaCursa, Alumno where Docente.ci=Usuario.ci and Docente.ci=asignaturaDictada.ci and Alumno.ci='" + ci + "' and asignaturaCursa.ci=Alumno.ci and asignaturaDictada.idClase=asignaturaCursa.idClase and asignaturaDictada.asignaturaDictada=asignaturaCursa.asignaturaCursada group by Docente.Ci";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int x = 0; x < data.Rows.Count; x++)
            {
                Docente doc = new Docente();
                doc.Ci = data.Rows[x][0].ToString();
                doc.Nombre = data.Rows[x][1].ToString();
                doc.Primer_apellido = data.Rows[x][2].ToString();
                doc.Segundo_apellido = data.Rows[x][3].ToString();
                if (!(data.Rows[x][4].ToString() == ""))
                {
                    doc.FotoDePerfil = (byte[])data.Rows[x][4];
                }
                doc.Apodo = data.Rows[x][5].ToString();
                doc.Activo = (bool)data.Rows[x][6];
                docentes.Add(doc);
            }

            conexion.Close();
            return docentes;
        }

        public Mensaje SelectAbrirMensaje(int idMensaje)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select * from Mensaje where idMensaje=" + idMensaje + ";", conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    mensaje.IdMensaje = Convert.ToInt32(reader.GetString("idMensaje"));
                    mensaje.Docente = reader.GetString("docente");
                    mensaje.Alumno = reader.GetString("alumno");
                    mensaje.FechaHoraAlumno = mensaje.StringADateTime(reader.GetString("fechaHora"));
                    mensaje.MensajeAlumno = reader.GetString("mensajeAlumno");
                    mensaje.Estado = reader.GetString("estado");
                    mensaje.Asunto = reader.GetString("asunto");
                    try 
                    {
                        mensaje.MensajeDocente = reader.GetString("mensajeDocente");
                        mensaje.FechaHoraDocente = mensaje.StringADateTime(reader.GetString("fechaHoraDocente"));
                    }catch(Exception ex) { }
                }
            }

            conexion.Close();
            return mensaje;
        }
        public List<Mensaje> SelectCargarMensajesAl(string alumno)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where alumno='" + alumno + "' and (estado='realizado' or estado='contestado')order by fechaHoraDocente desc, fechaHora desc;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);


            for (int x = 0; x < data.Rows.Count; x++)
            {
                Mensaje mensaje = new Mensaje();

                mensaje.IdMensaje = Convert.ToInt32(data.Rows[x][0].ToString());
                mensaje.Docente = data.Rows[x][1].ToString();
                mensaje.Alumno = data.Rows[x][2].ToString();
                mensaje.FechaHoraAlumno = mensaje.StringADateTime(data.Rows[x][3].ToString());
                mensaje.MensajeAlumno = data.Rows[x][4].ToString();
                mensaje.Estado = data.Rows[x][5].ToString();
                mensaje.Asunto = data.Rows[x][6].ToString();
                if (!(data.Rows[x][8].ToString() == ""))
                {
                    mensaje.MensajeDocente = data.Rows[x][7].ToString();
                    mensaje.FechaHoraDocente = mensaje.StringADateTime(data.Rows[x][8].ToString());
                }
                
                mensajes.Insert(0,mensaje);
            }



            conexion.Close();
            return mensajes;
        }


        //Mensaje Alumno

        //Mensaje Docente

        public List<Mensaje> SelectCargarMensajesDo(string docente)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where docente='" + docente + "' and estado='realizado' order by fechaHora desc;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Mensaje mensaje = new Mensaje();
                mensaje.IdMensaje = Convert.ToInt32(data.Rows[x][0].ToString());
                mensaje.Docente = data.Rows[x][1].ToString();
                mensaje.Alumno = data.Rows[x][2].ToString();
                mensaje.FechaHoraAlumno = mensaje.StringADateTime(data.Rows[x][3].ToString());
                mensaje.MensajeAlumno = data.Rows[x][4].ToString();
                mensaje.Estado = data.Rows[x][5].ToString();
                mensaje.Asunto = data.Rows[x][6].ToString();
                mensaje.MensajeDocente = data.Rows[x][7].ToString();
                if (!(data.Rows[x][8].ToString() == ""))
                {
                    mensaje.FechaHoraDocente = mensaje.StringADateTime(data.Rows[x][8].ToString());
                }
                mensajes.Add(mensaje);
            }
            

            conexion.Close();
            return mensajes;
        }

        //Mensaje Docente
        //Register Clases Alumno

        public List<Orientacion> SelectOrientaciones()
        {
            List<Orientacion> orientaciones = new List<Orientacion>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Orientacion ;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {

                if (data.Rows[x][2].ToString() == "True")
                {
                    orientaciones.Add(new Orientacion(Convert.ToInt32(data.Rows[x][0].ToString()), data.Rows[x][1].ToString(), true));
                }
                
            }
            conexion.Close();
            return orientaciones;
        }

        public int[] selectAnioClasesPorOrientacion(int orientacion)
        {

            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Clase.anio from Clase, Orientacion where Orientacion.id=Clase.orientacion and Orientacion.id=" + orientacion + " group by Clase.anio order by Clase.anio;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            int[] anios = new int[data.Rows.Count];
            for (int x = 0; x < data.Rows.Count; x++)
            {
                anios[x] = Convert.ToInt32(data.Rows[x][0]);
            }
            conexion.Close();

            return anios;
        }

        public string[] SelectNombreClasePorAnioYorientacion(int anio, int orientacion)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Clase.nombre from Clase, Orientacion where Orientacion.id=Clase.orientacion and Orientacion.id=" + orientacion + " and Clase.anio=" + anio + " order by Clase.nombre;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            string[] nombres = new string[data.Rows.Count];
            for (int x = 0; x < data.Rows.Count; x++)
            {
                nombres[x] = data.Rows[x][0].ToString();
            }
            conexion.Close();
            return nombres;
        }
        public int SelectIdClasePorPorNombreAnioYorientacion(string nombre, int anio, int orientacion)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idClase from Clase where nombre='" + nombre + "' and anio=" + anio + " and orientacion=" + orientacion + ";", conexion);
            reader = select.ExecuteReader();
            int id=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetString("idClase"));
                }
            }
            conexion.Close();
            return id;
        }
        public List<Asignatura> SelectAsignaturasPorClaseAnioYorientacion(string clase, int anio, int orientacion)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Asignatura.id, Asignatura.nombre, Asignatura.anio, Asignatura.activo from Asignatura, Contiene, Orientacion, Clase where Clase.orientacion=Orientacion.id and Orientacion.id=Contiene.idOri and Contiene.idAsig=Asignatura.id and Orientacion.id=" + orientacion + " and Clase.nombre='" + clase + "' and Clase.anio=" + anio + ";", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Asignatura> asignaturas = new List<Asignatura>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                asignaturas.Add(new Asignatura(data.Rows[x][0].ToString(), data.Rows[x][1].ToString(), Convert.ToInt32(data.Rows[x][2].ToString()), (bool)data.Rows[x][3]));
            }
            conexion.Close();
            return asignaturas;
        }
        //Register Clases Alumno

        //perfil
        public List<PreguntaSeg> SelectPreguntasSeguridad()
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from PreguntaSeguridad order by id;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<PreguntaSeg> preguntaSegs = new List<PreguntaSeg>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                preguntaSegs.Add(new PreguntaSeg(Convert.ToInt32(data.Rows[x][0].ToString()), data.Rows[x][1].ToString()));
            }
            conexion.Close();
            return preguntaSegs;
        }
        public PreguntaSeg SelectPreguntaSeguridad(string ci, int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select PreguntaSeguridad.id, PreguntaSeguridad.pregSeguridad from PreguntaSeguridad, Usuario where Usuario.ci='" + ci + "' and Usuario.id=PreguntaSeguridad.id and Usuario.id=" + id + ";", conexion);
            reader = select.ExecuteReader();
            PreguntaSeg preg = new PreguntaSeg(); ;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    preg = new PreguntaSeg(Convert.ToInt32(reader.GetString("id")), reader.GetString("pregSeguridad"));
                }
            }
            
            conexion.Close();
            return preg;
        }
        public void RemoveUsuario(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();

            MySqlCommand Remove = new MySqlCommand("update Usuario set activo =false where ci='" + ci + "' ;", conexion);
            Remove.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdatePerfil(Usuario us)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateApodo = new MySqlCommand("update Usuario set apodo ='" + us.Apodo + "' where ci='" + us.Ci + "' ;", conexion);
            MySqlCommand updatePassword = new MySqlCommand("update Usuario set contraseña ='" + us.Password + "' where ci='" + us.Ci + "' ;", conexion);
            MySqlCommand updateRespuesta = new MySqlCommand("update Usuario set resSeguridad ='" + us.Respuesta_seguridad + "' where ci='" + us.Ci + "' ;", conexion);
            MySqlCommand updatePregunta = new MySqlCommand("update Usuario set id =" + us.Preguta_seguridad + " where ci='" + us.Ci + "' ;", conexion);
            MySqlCommand updateFoto = new MySqlCommand("update Usuario set foto =@imagen where ci='" + us.Ci + "' ;", conexion);
            updateFoto.Parameters.AddWithValue("imagen", us.FotoDePerfil);
            updateRespuesta.ExecuteNonQuery();
            updateApodo.ExecuteNonQuery();
            updatePassword.ExecuteNonQuery();
            updatePregunta.ExecuteNonQuery();
            updateFoto.ExecuteNonQuery();
            conexion.Close();
        }

        //perfil

        //register

        public bool ExisteUsuarioCi(string ci)
        {
            bool encontrado = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Usuario where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                encontrado = true;
            }
            conexion.Close();
            return encontrado;
        }

        //register
    }
}
