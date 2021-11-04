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

            bool encontrado = false;
            MySqlDataReader reader = null;
            string query = "select * from Usuario where ci='" + usuario.Ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            MySqlConnection conexion2 = new MySqlConnection(connection);
            conexion2.Open();
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                encontrado = true;
            }
            if (encontrado)
            {
                MySqlCommand updateUsuario = new MySqlCommand("update usuario set activo=true where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set nombre='" + usuario.Nombre + "' where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set contrasenia='" + usuario.Password + "' where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set apellido='" + usuario.Primer_apellido + "' where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set segApellido='" + usuario.Segundo_apellido + "' where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set resSeguridad='" + usuario.Respuesta_seguridad + "' where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
                updateUsuario = new MySqlCommand("update usuario set id=" + usuario.Preguta_seguridad + " where ci='" + usuario.Ci + "';", conexion2);
                updateUsuario.ExecuteNonQuery();
            }
            else
            {
                MySqlCommand insertUsuario = new MySqlCommand("insert into Usuario values('" + usuario.Ci + "','" + usuario.Apodo + "','" + usuario.Nombre + "','" + usuario.Password + "','" + usuario.Primer_apellido + "','" + usuario.Segundo_apellido + "','" + usuario.Respuesta_seguridad + "',@imagen," + true + "," + usuario.Preguta_seguridad + ");", conexion2);
                insertUsuario.Parameters.AddWithValue("imagen", usuario.FotoDePerfil);
                MySqlCommand insertHijo = new MySqlCommand("insert into " + usuario.GetType().Name + " values('" + usuario.Ci + "');", conexion2);
                insertUsuario.ExecuteNonQuery();
                insertHijo.ExecuteNonQuery();
            }
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
        public void EnviarSolicitudModif(SolicitudModif soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into SolicitudModif (fechaHora,contraNueva,pendiente,usuario) values('" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "','"+soli.ContraNueva+"'," + soli.Pendiente + ",'" + soli.Usuario + "');", conexion);
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
            string fechaHoraDocente = mensaje.FechaHoraDocente.ToString("yyyy") + "-" + mensaje.FechaHoraDocente.ToString("MM") + "-" + mensaje.FechaHoraDocente.ToString("dd") + "T" + mensaje.FechaHoraDocente.ToString("HH") + ":" + mensaje.FechaHoraDocente.ToString("mm") + ":" + mensaje.FechaHoraDocente.ToString("ss");
            MySqlCommand updateRespuesta = new MySqlCommand("update Mensaje set mensajeDocente ='" + mensaje.MensajeDocente + "' where idMensaje="+mensaje.IdMensaje+";", conexion);
            MySqlCommand updateFechaDocente = new MySqlCommand("update Mensaje set fechaHoraDocente ='" + fechaHoraDocente + "' where idMensaje=" + mensaje.IdMensaje + ";", conexion);
            MySqlCommand updateEstado = new MySqlCommand("update Mensaje set estado ='" + mensaje.Estado + "' where idMensaje=" + mensaje.IdMensaje + ";", conexion);
            updateRespuesta.ExecuteNonQuery();
            updateFechaDocente.ExecuteNonQuery();
            updateEstado.ExecuteNonQuery();
            conexion.Close();
        }
        public void AbrirMensaje(Mensaje mensaje)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateEstado = new MySqlCommand("update Mensaje set estado ='" + mensaje.Estado + "' where idMensaje=" + mensaje.IdMensaje + ";", conexion);
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
        public Usuario SelectUsuarioCiActivo(string ci)
        {
            Usuario us = new Usuario();
            MySqlDataReader reader;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Usuario where ci='" + ci + "' and activo=true;";
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
            int id = 0;
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
            int id = 0;
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
                    }
                    catch (Exception ex) { }
                }
            }

            conexion.Close();
            return mensaje;
        }
        public List<Mensaje> SelectMensajesAl(string alumno)
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

                mensajes.Add(mensaje);
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
            MySqlCommand select = new MySqlCommand("select * from Orientacion where activo=true;", conexion);
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
            int id = 0;
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
            MySqlCommand select = new MySqlCommand("select Asignatura.* from Asignatura, Clase, contiene where contiene.idOri=clase.orientacion and asignatura.id=contiene.idAsig and clase.anio=asignatura.anio and contiene.activo=true and Clase.orientacion=" + orientacion + " and  Clase.nombre='" + clase + "' and  Clase.anio=" + anio + ";;", conexion);
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
            MySqlCommand updatePassword = new MySqlCommand("update Usuario set contrasenia ='" + us.Password + "' where ci='" + us.Ci + "' ;", conexion);
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
            string query = "select * from Usuario where ci='" + ci + "' and activo=true;";
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

        //chats

        public List<Chat> SelectChatsActivosPorCedulaAlumno(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Chat.* from Chat, chateaAl where chateaAl.idChat=Chat.idChat and Chat.activo=true and chateaAl.ci='" + ci + "' group by chat.idChat; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Chat> chats = new List<Chat>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Chat chat = new Chat();

                chat.IdChat = Convert.ToInt32(data.Rows[x][0].ToString());
                chat.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                chat.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                chat.Asignatura = data.Rows[x][3].ToString();
                chat.Fecha = chat.StringADateTime(data.Rows[x][4].ToString());
                chat.HoraInicio = chat.StringADateTime(data.Rows[x][5].ToString());
                if (!(data.Rows[x][6].ToString() == ""))
                {
                    chat.HoraFin = chat.StringADateTime(data.Rows[x][6].ToString());
                }
                chat.Titulo = data.Rows[x][7].ToString();
                chat.Activo = false;
                if (data.Rows[x][8].ToString() == "True")
                {
                    chat.Activo = true;
                }
                chats.Add(chat);
            }
            conexion.Close();
            return chats;
        }
        public List<Chat> SelectChatsAIngresarPorCedulaAlumno(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Chat.* from Chat, asignaturaCursa where asignaturaCursa.asignaturaCursada=Chat.asignatura and asignaturaCursa.idClase=Chat.idClase and asignaturaCursa.orientacion=Chat.oriClase and Chat.activo=true and asignaturaCursa.cursando=true and asignaturaCursa.ci='"+ci+"' and Chat.idChat not in(select idChat from chateaAl where ci='"+ci+"') group by chat.idChat;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Chat> chats = new List<Chat>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Chat chat = new Chat();

                chat.IdChat = Convert.ToInt32(data.Rows[x][0].ToString());
                chat.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                chat.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                chat.Asignatura = data.Rows[x][3].ToString();
                chat.Fecha = chat.StringADateTime(data.Rows[x][4].ToString());
                chat.HoraInicio = chat.StringADateTime(data.Rows[x][5].ToString());
                if (!(data.Rows[x][6].ToString() == ""))
                {
                    chat.HoraFin = chat.StringADateTime(data.Rows[x][6].ToString());
                }
                chat.Titulo = data.Rows[x][7].ToString();
                chat.Activo = false;
                if (data.Rows[x][8].ToString() == "True")
                {
                    chat.Activo = true;
                }
                chats.Add(chat);
            }
            conexion.Close();
            return chats;
        }
        public List<Chat> SelectHistorialChatsPorCedulaDocente(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Chat.* from Chat, chateaDo where chateaDo.idChat=Chat.idChat and Chat.activo=false and chateaDo.ci='" + ci + "' group by chat.idChat; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Chat> chats = new List<Chat>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Chat chat = new Chat();

                chat.IdChat = Convert.ToInt32(data.Rows[x][0].ToString());
                chat.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                chat.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                chat.Asignatura = data.Rows[x][3].ToString();
                chat.Fecha = chat.StringADateTime(data.Rows[x][4].ToString());
                chat.HoraInicio = chat.StringADateTime(data.Rows[x][5].ToString());
                if (!(data.Rows[x][6].ToString() == ""))
                {
                    chat.HoraFin = chat.StringADateTime(data.Rows[x][6].ToString());
                }
                chat.Titulo = data.Rows[x][7].ToString();
                chat.Activo = false;
                if (data.Rows[x][8].ToString() == "True")
                {
                    chat.Activo = true;
                }
                chats.Add(chat);
            }
            conexion.Close();
            return chats;
        }
        public List<Chat> SelectHistorialChatsPorCedulaAlumno(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Chat.* from Chat, chateaAl where chateaAl.idChat=Chat.idChat and Chat.activo=false and chateaAl.ci='" + ci + "' group by chat.idChat; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Chat> chats = new List<Chat>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Chat chat = new Chat();

                chat.IdChat = Convert.ToInt32(data.Rows[x][0].ToString());
                chat.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                chat.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                chat.Asignatura = data.Rows[x][3].ToString();
                chat.Fecha = chat.StringADateTime(data.Rows[x][4].ToString());
                chat.HoraInicio = chat.StringADateTime(data.Rows[x][5].ToString());
                if (!(data.Rows[x][6].ToString() == ""))
                {
                    chat.HoraFin = chat.StringADateTime(data.Rows[x][6].ToString());
                }
                chat.Titulo = data.Rows[x][7].ToString();
                chat.Activo = false;
                if (data.Rows[x][8].ToString() == "True")
                {
                    chat.Activo = true;
                }
                chats.Add(chat);
            }
            conexion.Close();
            return chats;
        }
        public List<Chat> SelectChatsActivosPorCedulaDocente(string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Chat.* from Chat, chateaDo where chateaDo.idChat=Chat.idChat and Chat.activo=true and chateaDo.ci='" + ci + "' group by chat.idChat;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Chat> chats = new List<Chat>();
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Chat chat = new Chat();

                chat.IdChat = Convert.ToInt32(data.Rows[x][0].ToString());
                chat.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                chat.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                chat.Asignatura = data.Rows[x][3].ToString();
                chat.Fecha = chat.StringADateTime(data.Rows[x][4].ToString());
                chat.HoraInicio = chat.StringADateTime(data.Rows[x][5].ToString());
                if (!(data.Rows[x][6].ToString() == ""))
                {
                    chat.HoraFin = chat.StringADateTime(data.Rows[x][6].ToString());
                }
                chat.Titulo = data.Rows[x][7].ToString();
                chat.Activo = false;
                if (data.Rows[x][8].ToString() == "True")
                {
                    chat.Activo = true;
                }
                chats.Add(chat);
            }
            conexion.Close();
            return chats;
        }
        public Asignatura SelectAsignaturaPorId(string id)
        {
            Asignatura encontrado = new Asignatura();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Asignatura where id='" + id + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    encontrado.Id = reader.GetString("id");
                    encontrado.Nombre = reader.GetString("nombre");
                    encontrado.Anio = Convert.ToInt32(reader.GetString("anio"));
                    encontrado.Activo = false;
                    if (reader.GetString("activo").ToString() == "True")
                    {
                        encontrado.Activo = true;
                    }

                }
            }
            conexion.Close();
            return encontrado;
        }
        public Clase SelectClasePorId(int id)
        {
            Clase encontrado = new Clase();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Clase where idClase=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    encontrado.IdClase = Convert.ToInt32(reader.GetString("idClase"));
                    encontrado.Nombre = reader.GetString("nombre");
                    encontrado.Anio = Convert.ToInt32(reader.GetString("anio"));
                    encontrado.Orientacion = Convert.ToInt32(reader.GetString("orientacion"));
                    encontrado.Activo = false;
                    try
                    {
                        if (reader.GetString("activo").ToString() == "True")
                        {
                            encontrado.Activo = true;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            conexion.Close();
            return encontrado;
        }
        public Chat SelectChatPorId(int id)
        {
            Chat chat = new Chat();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from chat where idChat=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    chat.IdChat = Convert.ToInt32(reader.GetString("idChat"));
                    chat.IdClase = Convert.ToInt32(reader.GetString("idClase"));
                    chat.OriClase = Convert.ToInt32(reader.GetString("oriClase"));
                    chat.Asignatura = reader.GetString("asignatura");
                    chat.Fecha = chat.StringADateTime(reader.GetString("fecha"));
                    chat.HoraInicio = chat.StringADateTime(reader.GetString("horaInicio"));
                    try
                    {
                        chat.Titulo = reader.GetString("titulo");
                    }
                    catch (Exception ex) { }
                    try
                    {
                        chat.HoraFin = chat.StringADateTime(reader.GetString("horaFin"));
                        
                    }
                    catch (Exception ex) { }
                    chat.Activo = false;
                    if (reader.GetString("activo") == "True")
                    {
                        chat.Activo = true;
                    }
                }
            }
            conexion.Close();
            return chat;
        }
        public Agenda SelectAgendaConCi(string ci)
        {
            Agenda agenda = new Agenda();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Agenda where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    agenda.IdAgenda = Convert.ToInt32(reader.GetString("idAgenda"));
                    agenda.NomDia = reader.GetString("nomDia");
                    agenda.HoraInicio = reader.GetString("horaInicio");
                    agenda.HoraFin = reader.GetString("horaFin");
                    agenda.Ci = reader.GetString("ci");
                }
            }
            conexion.Close();
            return agenda;
        }

        public string SelectCiPorAsignaturaDictadaYClase(string asignatura, int clase)
        {

            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select ci from asignaturaDictada where asignaturaDictada='" + asignatura + "' and idClase=" + clase + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            string ci = "";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ci = reader.GetString("ci");
                }
            }
            conexion.Close();
            return ci;
        }

        public List<ChateaAl> SelectChateaAlsPorIdChatMasFecha(int id, DateTime fecha)
        {
            List<ChateaAl> chateaAls = new List<ChateaAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from ChateaAl where idChat=" + id + " order by horaEnvioAl; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                ChateaAl chateaAl = new ChateaAl();

                chateaAl.Ci = data.Rows[x][0].ToString();
                chateaAl.IdChat = Convert.ToInt32(data.Rows[x][1].ToString());
                Chat c = new Chat();
                c.Fecha = fecha;
                chateaAl.HoraEnvio = c.StringADateTime(data.Rows[x][2].ToString());
                chateaAl.Contenido = data.Rows[x][3].ToString();
                chateaAls.Add(chateaAl);
            }
            conexion.Close();
            return chateaAls; ;
        }
        public List<ChateaDo> SelectChateaDosPorIdChatMasFecha(int id, DateTime fecha)
        {
            List<ChateaDo> chateaDos = new List<ChateaDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from ChateaDo where idChat=" + id + " order by horaEnvioDo; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                ChateaDo chateaDo = new ChateaDo();

                chateaDo.Ci = data.Rows[x][0].ToString();
                chateaDo.IdChat = Convert.ToInt32(data.Rows[x][1].ToString());
                Chat c = new Chat();
                c.Fecha = fecha;
                chateaDo.HoraEnvio = c.StringADateTime(data.Rows[x][2].ToString());
                chateaDo.Contenido = data.Rows[x][3].ToString();
                chateaDos.Add(chateaDo);
            }
            conexion.Close();
            return chateaDos; ;
        }

        public List<Asignatura> SelectAsignaturasPorCi(string ci)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Asignatura.id, Asignatura.nombre, Asignatura.anio, Asignatura.activo from asignaturaCursa, Asignatura where asignaturaCursa.ci='" + ci + "' and asignaturaCursa.asignaturaCursada=Asignatura.id and Asignatura.activo=true and asignaturaCursa.cursando = true order by Asignatura.nombre; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Asignatura asig = new Asignatura();

                asig.Id = data.Rows[x][0].ToString();
                asig.Nombre = data.Rows[x][1].ToString();
                asig.Anio = Convert.ToInt32(data.Rows[x][2].ToString());
                asig.Activo = true;
                asignaturas.Add(asig);
            }
            conexion.Close();
            return asignaturas; ;
        }
        public List<AsignaturaCursa> SelectAsignaturasCursadasPorCi(string ci)
        {
            List<AsignaturaCursa> asignaturaCursa = new List<AsignaturaCursa>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from asignaturaCursa where ci='" + ci + "' and asignaturaCursa.cursando = true; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaCursa asigCursa = new AsignaturaCursa();

                asigCursa.Ci = data.Rows[x][0].ToString();
                asigCursa.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                asigCursa.Orientacion = Convert.ToInt32(data.Rows[x][2].ToString());
                asigCursa.Anio = Convert.ToInt32(data.Rows[x][3].ToString());
                asigCursa.AsignaturaCursada = data.Rows[x][4].ToString();
                asigCursa.Cursando = true;
                asignaturaCursa.Add(asigCursa);
            }
            conexion.Close();
            return asignaturaCursa;
        }
        public List<AsignaturaDictada> SelectAsignaturasDictadasPorCi(string ci)
        {
            List<AsignaturaDictada> asignaturaDictadas = new List<AsignaturaDictada>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from AsignaturaDictada where ci='" + ci + "' and AsignaturaDictada.dictando = true; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaDictada asigDicta = new AsignaturaDictada();

                asigDicta.Ci = data.Rows[x][0].ToString();
                asigDicta.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                asigDicta.Orientacion = Convert.ToInt32(data.Rows[x][2].ToString());
                asigDicta.Anio = Convert.ToInt32(data.Rows[x][3].ToString());
                asigDicta.AsigDictada = data.Rows[x][4].ToString();
                asigDicta.Dictando = true;
                asignaturaDictadas.Add(asigDicta);
            }
            conexion.Close();
            return asignaturaDictadas;
        }
        public AsignaturaCursa SelectAsignaturaCursandoPorAsignaturaYCi(string asignatura, string ci)
        {
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from asignaturaCursa where ci='" + ci + "' and cursando= true and asignaturaCursada='" + asignatura + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            AsignaturaCursa asigCursa = new AsignaturaCursa();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    asigCursa.Ci = reader.GetString("ci");
                    asigCursa.IdClase = Convert.ToInt32(reader.GetString("idClase"));
                    asigCursa.Orientacion = Convert.ToInt32(reader.GetString("orientacion"));
                    asigCursa.Anio = Convert.ToInt32(reader.GetString("anio"));
                    asigCursa.AsignaturaCursada = reader.GetString("asignaturaCursada");
                    asigCursa.Cursando = true;
                }
            }
            conexion.Close();
            return asigCursa;
        }

        public AsignaturaDictada SelectAsignaturaDictadaPorAsignaturaYCi(string asignatura, string ci)
        {
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from asignaturaDictada where ci='" + ci + "' and dictando= true and asignaturaDictada='" + asignatura + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            AsignaturaDictada asigDict = new AsignaturaDictada();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    asigDict.Ci = reader.GetString("ci");
                    asigDict.IdClase = Convert.ToInt32(reader.GetString("idClase"));
                    asigDict.Orientacion = Convert.ToInt32(reader.GetString("orientacion"));
                    asigDict.Anio = Convert.ToInt32(reader.GetString("anio"));
                    asigDict.AsigDictada = reader.GetString("asignaturaDictada");
                    asigDict.Dictando = true;
                }
            }
            conexion.Close();
            return asigDict;
        }
        public void EnviarSolicitudChat(SolicitaChat soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into SolicitaChat values('" + soli.CiAlumno + "','" + soli.CiDocente + "','" + soli.FechaHora.ToString("yyyy") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "'," + soli.IdClase + "," + soli.OriClase + ",'" + soli.Asignatura + "',true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public List<SolicitaChat> SelectSolicitaChats(string ci)
        {
            List<SolicitaChat> solicitaChats = new List<SolicitaChat>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from SolicitaChat where ciDocente='" + ci + "' and pendiente = true; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitaChat solicitaChat = new SolicitaChat();

                solicitaChat.CiAlumno = data.Rows[x][0].ToString();
                solicitaChat.CiDocente = data.Rows[x][1].ToString();
                solicitaChat.FechaHora = solicitaChat.StringADateTime(data.Rows[x][2].ToString());
                solicitaChat.IdClase = Convert.ToInt32(data.Rows[x][3].ToString());
                solicitaChat.OriClase = Convert.ToInt32(data.Rows[x][4].ToString());
                solicitaChat.Asignatura = data.Rows[x][5].ToString();
                solicitaChat.Pendiente = true;
                solicitaChats.Add(solicitaChat);
            }
            conexion.Close();
            return solicitaChats;
        }
        public void CrearChat(SolicitaChat soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            DateTime fechaHora = DateTime.Now;
            MySqlCommand insert = new MySqlCommand("insert into Chat (idClase,oriClase,asignatura,fecha,horaInicio,activo) values(" + soli.IdClase + "," + soli.OriClase + ",'" + soli.Asignatura + "','" + fechaHora.ToString("yyyy") + "-" + fechaHora.ToString("MM") + "-" + fechaHora.ToString("dd") + "','" + fechaHora.ToString("HH") + ":" + fechaHora.ToString("mm") + ":" + fechaHora.ToString("ss") + "',true);", conexion);
            insert.ExecuteNonQuery();
            MySqlCommand update = new MySqlCommand("update SolicitaChat set pendiente = false where ciAlumno='" + soli.CiAlumno + "' and ciDocente='" + soli.CiDocente + "' and idClase=" + soli.IdClase + " and oriClase=" + soli.OriClase + " and asignatura='" + soli.Asignatura + "' and fechaHora='" + fechaHora.ToString("yyyy") + "-" + fechaHora.ToString("MM") + "-" + fechaHora.ToString("dd") + "T" + fechaHora.ToString("HH") + ":" + fechaHora.ToString("mm") + ":" + fechaHora.ToString("ss") + "';", conexion);
            update.ExecuteNonQuery();
            int idChat = SelectIdChatPorSolicituaChatYfechaHora(soli, fechaHora);
            string apodoAl = SelectUsuarioCiActivo(soli.CiAlumno).Apodo;
            string apodoDo = SelectUsuarioCiActivo(soli.CiDocente).Apodo;
            InsertChateaAl(new ChateaAl(soli.CiAlumno, idChat, fechaHora, "¡ " + apodoAl + " ha ingresado al chat !"));
            InsertChateaDo(new ChateaDo(soli.CiDocente, idChat, fechaHora.AddSeconds(1), "¡ " + apodoDo + " ha ingresado al chat !"));
            conexion.Close();
        }
        public int SelectIdChatPorSolicituaChatYfechaHora(SolicitaChat soli, DateTime fechaHora)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select idChat from Chat where idClase=" + soli.IdClase + " and oriClase=" + soli.OriClase + " and fecha='" + fechaHora.ToString("yyyy") + "-" + fechaHora.ToString("MM") + "-" + fechaHora.ToString("dd") + "' and horaInicio='" + fechaHora.ToString("HH") + ":" + fechaHora.ToString("mm") + ":" + fechaHora.ToString("ss") + "' and asignatura='" + soli.Asignatura + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            int id = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetString("idChat"));
                }
                //chats
            }
            conexion.Close();
            return id;
        }
        public void InsertChateaAl(ChateaAl chatea)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            bool enviado = true;
            do
            {

                try
                {
                    MySqlCommand insert = new MySqlCommand("insert into ChateaAl values('" + chatea.Ci + "'," + chatea.IdChat + ",'" + DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm") + ":" + DateTime.Now.ToString("ss") + "','" + chatea.Contenido + "');", conexion);
                    insert.ExecuteNonQuery();
                    enviado = false;
                }
                catch (Exception ex) { }
            } while (enviado);
            
            conexion.Close();
        }
        public void InsertChateaDo(ChateaDo chatea)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            bool enviado = true;
            do
            {

                try
                {
                    MySqlCommand insert = new MySqlCommand("insert into ChateaDo values('" + chatea.Ci + "'," + chatea.IdChat + ",'" + DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm") + ":" + DateTime.Now.ToString("ss") + "','" + chatea.Contenido + "');", conexion);
                    insert.ExecuteNonQuery();
                    enviado = false;
                }
                catch (Exception ex) { }
            } while (enviado);
        
        conexion.Close();
        }
        public void CerrarChat(Chat chat)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateEstado = new MySqlCommand("update Chat set activo = false where idChat=" + chat.IdChat + ";", conexion);
            updateEstado.ExecuteNonQuery();
            MySqlCommand updateHoraFin = new MySqlCommand("update Chat set horaFin = '" + chat.HoraFin.ToString("HH") + ":" + chat.HoraFin.ToString("mm") + ":" + chat.HoraFin.ToString("ss") + "' where idChat=" + chat.IdChat + ";", conexion);
            updateHoraFin.ExecuteNonQuery();
            MySqlCommand updateTitulo = new MySqlCommand("update Chat set titulo = '" + chat.Titulo + "' where idChat=" + chat.IdChat + ";", conexion);
            updateTitulo.ExecuteNonQuery();
            conexion.Close();
        }
        public void AceptarChat(SolicitaChat soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateEstado = new MySqlCommand("update SolicitaChat set pendiente = false where ciDocente='" + soli.CiDocente + "' and idClase=" + soli.IdClase + " and oriClase=" + soli.OriClase + " and asignatura='" + soli.Asignatura + "';", conexion);
            updateEstado.ExecuteNonQuery();
            conexion.Close();
        }
        public void DenegarChat(SolicitaChat soli)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateEstado = new MySqlCommand("update SolicitaChat set pendiente = false where ciDocente='" + soli.CiDocente + "' and idClase=" + soli.IdClase + " and oriClase=" + soli.OriClase + " and asignatura='" + soli.Asignatura + "';", conexion);
            updateEstado.ExecuteNonQuery();
            conexion.Close();
        }

        public void CambiarTitulo(Chat chat)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateTitulo = new MySqlCommand("update Chat set titulo ='" + chat.Titulo + "' where idChat=" + chat.IdChat + ";", conexion);
            updateTitulo.ExecuteNonQuery();
            conexion.Close();
        }

        public List<SolicitudClaseAl> SelectSolicitudesClaseAl()
        {
            List<SolicitudClaseAl> solicitudesClaseAl = new List<SolicitudClaseAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from SolicitudClaseAl where pendiente = true order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudClaseAl soolicitudClaseAl = new SolicitudClaseAl();

                soolicitudClaseAl.IdSolicitudClaseAl = Convert.ToInt32(data.Rows[x][0].ToString());
                soolicitudClaseAl.FechaHora = soolicitudClaseAl.StringADateTime(data.Rows[x][1].ToString());
                soolicitudClaseAl.Pendiente = true;
                soolicitudClaseAl.Alumno = data.Rows[x][3].ToString();
                solicitudesClaseAl.Add(soolicitudClaseAl);
            }
            conexion.Close();
            return solicitudesClaseAl;
        }
        public List<SolicitudClaseDo> SelectSolicitudesClaseDo()
        {
            List<SolicitudClaseDo> solicitudesClaseDo = new List<SolicitudClaseDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from SolicitudClaseDo where pendiente = true order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudClaseDo solcitudClaseDo = new SolicitudClaseDo();

                solcitudClaseDo.IdSolicitudClaseDo = Convert.ToInt32(data.Rows[x][0].ToString());
                solcitudClaseDo.FechaHora = solcitudClaseDo.StringADateTime(data.Rows[x][1].ToString());
                solcitudClaseDo.Pendiente = true;
                solcitudClaseDo.Docente = data.Rows[x][3].ToString();
                solicitudesClaseDo.Add(solcitudClaseDo);
            }
            conexion.Close();
            return solicitudesClaseDo;
        }
        public List<SolicitudModif> SelectSolicitudesModif()
        {
            List<SolicitudModif> solicitudesModif = new List<SolicitudModif>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from SolicitudModif where pendiente = true order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudModif solicitudModif = new SolicitudModif();

                solicitudModif.IdSolicitudModif = Convert.ToInt32(data.Rows[x][0].ToString());
                solicitudModif.FechaHora = solicitudModif.StringADateTime(data.Rows[x][1].ToString());
                solicitudModif.ContraNueva = data.Rows[x][2].ToString();
                solicitudModif.Pendiente = true;
                solicitudModif.Usuario = data.Rows[x][5].ToString();
                solicitudesModif.Add(solicitudModif);
            }
            conexion.Close();
            return solicitudesModif;
        }
        public SolicitudClaseAl SelectSolicitudClaseAlPorId(int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from SolicitudClaseAl where idSolicitudClaseAl=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            SolicitudClaseAl soli = new SolicitudClaseAl();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    soli.IdSolicitudClaseAl = Convert.ToInt32(reader.GetString("idSolicitudClaseAl"));
                    soli.FechaHora = soli.StringADateTime(reader.GetString("fechaHora"));
                    soli.Pendiente = false;
                    if (reader.GetString("pendiente") == "True")
                    {
                        soli.Pendiente = true;
                    }
                    soli.Alumno = reader.GetString("alumno");
                }
            }
            conexion.Close();
            return soli;
        }
        public List<ClaseSolicitudClaseAl> SelectClaseSolicitudClaseAl(int idSolicitudClaseAl)
        {
            List<ClaseSolicitudClaseAl> claseSolicitudesClaseAl = new List<ClaseSolicitudClaseAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from claseSolicitudClaseAl where idSolicitudClaseAl = " + idSolicitudClaseAl + "; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                ClaseSolicitudClaseAl claseSolicitudClaseAl = new ClaseSolicitudClaseAl();

                claseSolicitudClaseAl.IdSolicitudClaseAl = Convert.ToInt32(data.Rows[x][0].ToString());
                claseSolicitudClaseAl.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                claseSolicitudClaseAl.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                claseSolicitudesClaseAl.Add(claseSolicitudClaseAl);
            }
            conexion.Close();
            return claseSolicitudesClaseAl;
        }
        public List<AsignaturaSolicitudClaseAl> SelectAsignaturaSolicitudClaseAl(int idSolicitudClaseAl)
        {
            List<AsignaturaSolicitudClaseAl> asignaturaSolicitudesClaseAl = new List<AsignaturaSolicitudClaseAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from asignaturaSolicitudClaseAl where idSolicitudClaseAl = " + idSolicitudClaseAl + "; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaSolicitudClaseAl asignaturaSolicitudClaseAl = new AsignaturaSolicitudClaseAl();

                asignaturaSolicitudClaseAl.IdSolicitudClaseAl = Convert.ToInt32(data.Rows[x][0].ToString());
                asignaturaSolicitudClaseAl.IdClaseAsig = Convert.ToInt32(data.Rows[x][1].ToString());
                asignaturaSolicitudClaseAl.OriClaseAsig = Convert.ToInt32(data.Rows[x][2].ToString());
                asignaturaSolicitudClaseAl.IdAsignatura = data.Rows[x][3].ToString();
                asignaturaSolicitudClaseAl.Aceptada = false;
                if (data.Rows[x][4].ToString() == "True")
                {
                    asignaturaSolicitudClaseAl.Aceptada = true;
                }
                asignaturaSolicitudesClaseAl.Add(asignaturaSolicitudClaseAl);
            }
            conexion.Close();
            return asignaturaSolicitudesClaseAl;
        }
        public void AceptarSolicitudClaseAlPorIdYAdmin(int id, string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updatePendiente = new MySqlCommand("update SolicitudClaseAl set pendiente =false where idSolicitudClaseAl=" + id + ";", conexion);
            updatePendiente.ExecuteNonQuery();
            MySqlCommand insertRespondeClaseAl = new MySqlCommand("insert into RespondeClaseAl values(" + id + ",'" + ci + "');", conexion);
            insertRespondeClaseAl.ExecuteNonQuery();
            conexion.Close();
        }
        public void AceptarAsignaturaSolicitudClaseAl(AsignaturaSolicitudClaseAl soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updateaceptada = new MySqlCommand("update asignaturaSolicitudClaseAl set aceptada ="+soliAsig.Aceptada+" where idSolicitudClaseAl=" + soliAsig.IdSolicitudClaseAl + " and idAsignatura='" + soliAsig.IdAsignatura + "' and idClaseAsig=" + soliAsig.IdClaseAsig + " and oriClaseAsig="+ soliAsig + ";", conexion);
            updateaceptada.ExecuteNonQuery();
            conexion.Close();
        }

        public void InsertAsignaturaCursa(AsignaturaCursa asigCursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaCursa values('" + asigCursa.Ci + "'," + asigCursa.IdClase + "," + asigCursa.Orientacion + "," + asigCursa.Anio + ",'" + asigCursa.AsignaturaCursada + "',true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActivarAsignaturaDicta(AsignaturaDictada asiDicta)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("update asignaturaDictada set dictando=true where ci='" + asiDicta.Ci + "' and idClase=" + asiDicta.IdClase + " and orientacion=" + asiDicta.Orientacion + " and anio=" + asiDicta.Anio + " && asignaturaDictada='" + asiDicta.AsigDictada + "';", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertAsignaturaDictada(AsignaturaDictada asigDicta)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaDictada values('" + asigDicta.Ci + "'," + asigDicta.IdClase + "," + asigDicta.Orientacion + "," + asigDicta.Anio + ",'" + asigDicta.AsigDictada + "',true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void ActivarAsignaturaCursa(AsignaturaCursa asigCursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("update AsignaturaCursa set cursando=true where ci='" + asigCursa.Ci + "' and idClase=" + asigCursa.IdClase + " and orientacion=" + asigCursa.Orientacion + " and anio=" + asigCursa.Anio + " && asignaturaCursada='" + asigCursa.AsignaturaCursada + "';", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectCursando(Cursa cursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from cursa where ci='" + cursa.CiAlumno + "' and idClase=" + cursa.IdClase + " and orientacion=" + cursa.Orientacion + " and anio=" + cursa.Anio + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }
        public bool SelectDictando(Dicta dicta)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from dicta where ci='" + dicta.CiDocente + "' and idClase=" + dicta.IdClase + " and orientacion=" + dicta.Orientacion + " and anio=" + dicta.Anio + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }

        public bool SelectCursandoAsignatura(AsignaturaCursa asignaturaCursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from AsignaturaCursa where ci='" + asignaturaCursa.Ci + "' and idClase=" + asignaturaCursa.IdClase + " and orientacion=" + asignaturaCursa.Orientacion + " and anio=" + asignaturaCursa.Anio + " && asignaturaCursada='" + asignaturaCursa.AsignaturaCursada + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }
        public bool SelectDictandoAsignatura(AsignaturaDictada asignaturaDictando)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from AsignaturaDictada where ci='" + asignaturaDictando.Ci + "' and idClase=" + asignaturaDictando.IdClase + " and orientacion=" + asignaturaDictando.Orientacion + " and anio=" + asignaturaDictando.Anio + " && asignaturaDictada='" + asignaturaDictando.AsigDictada + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }
        public bool SelectDictandoAsignaturaDesactivada(AsignaturaDictada asignaturaDictando)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from AsignaturaDictada where ci='" + asignaturaDictando.Ci + "' and idClase=" + asignaturaDictando.IdClase + " and orientacion=" + asignaturaDictando.Orientacion + " and anio=" + asignaturaDictando.Anio + " && asignaturaDictada='" + asignaturaDictando.AsigDictada + "'&& dictando=false;";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }
        public bool SelectCursandoAsignaturaDesactivada(AsignaturaCursa asignaturaCursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from AsignaturaCursa where ci='" + asignaturaCursa.Ci + "' and idClase=" + asignaturaCursa.IdClase + " and orientacion=" + asignaturaCursa.Orientacion + " and anio=" + asignaturaCursa.Anio + " && asignaturaCursada='" + asignaturaCursa.AsignaturaCursada + "' && cursando=false;";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            bool existe = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }


        public void InsertCursa(Cursa cursa)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Cursa values('" + cursa.CiAlumno + "'," + cursa.IdClase + "," + cursa.Orientacion + "," + cursa.Anio + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public SolicitudClaseDo SelectSolicitudClaseDoPorId(int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from SolicitudClaseDo where idSolicitudClaseDo=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            SolicitudClaseDo soli = new SolicitudClaseDo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    soli.IdSolicitudClaseDo = Convert.ToInt32(reader.GetString("idSolicitudClaseDo"));
                    soli.FechaHora = soli.StringADateTime(reader.GetString("fechaHora"));
                    soli.Pendiente = false;
                    if (reader.GetString("pendiente") == "True")
                    {
                        soli.Pendiente = true;
                    }
                    soli.Docente = reader.GetString("docente");
                }
            }
            conexion.Close();
            return soli;
        }
        public List<ClaseSolicitudClaseDo> SelectClaseSolicitudClaseDo(int idSolicitudClaseDo)
        {
            List<ClaseSolicitudClaseDo> claseSolicitudesClaseDo = new List<ClaseSolicitudClaseDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from claseSolicitudClaseDo where idSolicitudClaseDo = " + idSolicitudClaseDo + "; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                ClaseSolicitudClaseDo claseSolicitudClaseDo = new ClaseSolicitudClaseDo();

                claseSolicitudClaseDo.IdSolicitudClaseDo = Convert.ToInt32(data.Rows[x][0].ToString());
                claseSolicitudClaseDo.IdClase = Convert.ToInt32(data.Rows[x][1].ToString());
                claseSolicitudClaseDo.OriClase = Convert.ToInt32(data.Rows[x][2].ToString());
                claseSolicitudesClaseDo.Add(claseSolicitudClaseDo);
            }
            conexion.Close();
            return claseSolicitudesClaseDo;
        }
        public List<AsignaturaSolicitudClaseDo> SelectAsignaturaSolicitudClaseDo(int idSolicitudClaseDo)
        {
            List<AsignaturaSolicitudClaseDo> asignaturaSolicitudesClaseDo = new List<AsignaturaSolicitudClaseDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from asignaturaSolicitudClaseDo where idSolicitudClaseDo = " + idSolicitudClaseDo + "; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaSolicitudClaseDo asignaturaSolicitudClaseDo = new AsignaturaSolicitudClaseDo();

                asignaturaSolicitudClaseDo.IdSolicitudClaseDo = Convert.ToInt32(data.Rows[x][0].ToString());
                asignaturaSolicitudClaseDo.IdClaseAsig = Convert.ToInt32(data.Rows[x][1].ToString());
                asignaturaSolicitudClaseDo.OriClaseAsig = Convert.ToInt32(data.Rows[x][2].ToString());
                asignaturaSolicitudClaseDo.IdAsignatura = data.Rows[x][3].ToString();
                asignaturaSolicitudClaseDo.Aceptada = false;
                if (data.Rows[x][4].ToString() == "True")
                {
                    asignaturaSolicitudClaseDo.Aceptada = true;
                }
                asignaturaSolicitudesClaseDo.Add(asignaturaSolicitudClaseDo);
            }
            conexion.Close();
            return asignaturaSolicitudesClaseDo;
        }

        public void AceptarSolicitudClaseDoPorIdYAdmin(int id, string ci)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand updatePendiente = new MySqlCommand("update SolicitudClaseDo set pendiente =false where idSolicitudClaseDo=" + id + ";", conexion);
            updatePendiente.ExecuteNonQuery();
            MySqlCommand insertRespondeClaseDo = new MySqlCommand("insert into RespondeClaseDo values(" + id + ",'" + ci + "');", conexion);
            insertRespondeClaseDo.ExecuteNonQuery();
            conexion.Close();
        }
        public void AceptarAsignaturaSolicitudClaseDo(AsignaturaSolicitudClaseDo soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();    
            MySqlCommand updateaceptada = new MySqlCommand("update asignaturaSolicitudClaseDo set aceptada =" + soliAsig.Aceptada + " where idSolicitudClaseDo=" + soliAsig.IdSolicitudClaseDo + " and idAsignatura='" + soliAsig.IdAsignatura + "' and idClaseAsig = " + soliAsig.IdClaseAsig + " and oriClaseAsig = " + soliAsig + "; ", conexion);
            updateaceptada.ExecuteNonQuery();
            conexion.Close();
        }
        
        public void InsertDicta(Dicta dicta)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Dicta values('" + dicta.CiDocente + "'," + dicta.IdClase + "," + dicta.Orientacion + "," + dicta.Anio + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public SolicitudModif SelectSolicitudModifPorId(int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from SolicitudModif where idSolicitudModif=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            SolicitudModif soli = new SolicitudModif();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    soli.IdSolicitudModif = Convert.ToInt32(reader.GetString("idSolicitudModif"));
                    soli.FechaHora = soli.StringADateTime(reader.GetString("fechaHora"));
                    soli.ContraNueva = reader.GetString("contraNueva");
                    soli.Pendiente = false;
                    if (reader.GetString("pendiente") == "True")
                    {
                        soli.Pendiente = true;
                    }
                    try 
                    { 
                        if (reader.GetString("aceptada") == "True")
                        {
                            soli.Aceptada = true;

                        }

                        if (reader.GetString("aceptada") == "False")
                        {
                            soli.Aceptada = false;
                        }
                    }catch(Exception ex) { }
                    soli.Usuario = reader.GetString("usuario");
                }
            }
            conexion.Close();
            return soli;
        }

        public void AceptarSolicitudModifPorSoliYAdmin(SolicitudModif soli, string ci, bool aceptar)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            if (aceptar)
            {
                MySqlCommand updateContra = new MySqlCommand("update Usuario set contrasenia ='" + soli.ContraNueva + "' where ci='" + soli.Usuario + "';", conexion);
                updateContra.ExecuteNonQuery();
            }
            MySqlCommand updatePendiente = new MySqlCommand("update SolicitudModif set pendiente =false where idSolicitudModif=" + soli.IdSolicitudModif + ";", conexion);
            updatePendiente.ExecuteNonQuery();
            MySqlCommand updateAceptado = new MySqlCommand("update SolicitudModif set aceptada ="+soli.Aceptada+" where idSolicitudModif=" + soli.IdSolicitudModif + ";", conexion);
            updateAceptado.ExecuteNonQuery();
            MySqlCommand insertResponde = new MySqlCommand("insert into Responde values(" + soli.IdSolicitudModif + ",'" + ci + "');", conexion);
            insertResponde.ExecuteNonQuery();
            conexion.Close();
        }

        public Orientacion SelectOrientacioPorId(int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlDataReader reader = null;
            string query = "select * from Orientacion where id=" + id + ";";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            Orientacion ori = new Orientacion();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ori.Id = Convert.ToInt32(reader.GetString("id"));
                    ori.Nombre = reader.GetString("nombre");
                    ori.Activo = false;
                    if (reader.GetString("activo") == "True")
                    {
                        ori.Activo = true;
                    }
                }
            }
            conexion.Close();
            return ori;
        }

        public List<Agenda> SelectAgendasPorCi(string ci)
        {
            List<Agenda> agendas = new List<Agenda>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Agenda where ci = '" + ci + "'; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Agenda agenda = new Agenda();

                agenda.IdAgenda = Convert.ToInt32(data.Rows[x][0].ToString());
                agenda.NomDia = data.Rows[x][1].ToString();
                agenda.HoraInicio = data.Rows[x][2].ToString();
                agenda.HoraFin = data.Rows[x][3].ToString();
                agenda.Ci = data.Rows[x][4].ToString();

                agendas.Add(agenda);
            }
            conexion.Close();
            return agendas;
        }
        public Agenda SelectAgendaPorId(int id)
        {
            Agenda agenda = new Agenda();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Agenda where idAgenda='" + id + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    agenda.IdAgenda = Convert.ToInt32(reader.GetString("idAgenda"));
                    agenda.NomDia = reader.GetString("nomDia");
                    agenda.HoraInicio = reader.GetString("horaInicio");
                    agenda.HoraFin = reader.GetString("horaFin");
                    agenda.Ci = reader.GetString("ci");
                }
            }
            conexion.Close();
            return agenda;
        }
        public void EliminarAgendaPorId(int id)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand deleteAgenda = new MySqlCommand("delete from Agenda where idAgenda =" + id + ";", conexion);
            deleteAgenda.ExecuteNonQuery();
            conexion.Close();
        }

        public void AgregarAgenda(Agenda agenda)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Agenda (nomDia,horaInicio,horaFin,ci) values('" + agenda.NomDia + "','" + agenda.HoraInicio + "','" + agenda.HoraFin + "','" + agenda.Ci + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Asignatura> SelectAsignaturas()
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Asignatura where activo=true order by anio;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Asignatura asignatura = new Asignatura();

                asignatura.Id = data.Rows[x][0].ToString();
                asignatura.Nombre = data.Rows[x][1].ToString();
                asignatura.Anio = Convert.ToInt32(data.Rows[x][2].ToString());
                asignatura.Activo = true;
                asignaturas.Add(asignatura);
            }
            conexion.Close();
            return asignaturas;
        }
        public bool SelectExisteNombreOrientacion(string nombre)
        {
            bool existe = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Orientacion where nombre='" + nombre + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    existe = true;
                }
            }
            conexion.Close();
            return existe;
        }
        public void AltaOrientacion(string nombre)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Orientacion (nombre,activo) values('" + nombre + ",'true');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public Orientacion SelectOrientacionPorNombre(string nombre)
        {
            Orientacion ori = new Orientacion();
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Orientacion where nombre='" + nombre + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ori.Id = Convert.ToInt32(reader.GetString("id"));
                    ori.Nombre = reader.GetString("nombre");
                    ori.Activo = false;
                    if(reader.GetString("activo")== "True")
                    {
                        ori.Activo = true;
                    }
                }
            }
            conexion.Close();
            return ori;
        }
        public void AltaContiene(Contiene cont)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Contiene (idAsig,idOri,activo) values('" + cont.Asignatura + ","+cont.Orientacion+",true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void BajaOrientacion(Orientacion ori)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Orientacion set activo =false where id=" + ori.Id + ";", conexion);
            update.ExecuteNonQuery();
            update = new MySqlCommand("update Contiene set activo =false where idOri=" + ori.Id + ";", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public void BajaContiene(Contiene con)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Contiene set activo =false where idOri=" + con.Orientacion + ";", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public List<Contiene> SelectContienePorOrientacion(int id)
        {
            List<Contiene> conts = new List<Contiene>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from contiene where idOri="+id+" and activo=true;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Contiene cont = new Contiene();

                cont.Asignatura = data.Rows[x][0].ToString();
                cont.Orientacion = Convert.ToInt32(data.Rows[x][1].ToString());
                cont.Activo = true;
                conts.Add(cont);
            }
            conexion.Close();
            return conts;
        }
        public void ModificarOrientacion(Orientacion ori, List<Contiene> contienes)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Orientacion set nombre ='"+ori.Nombre+"' where id=" + ori.Id + ";", conexion);
            update.ExecuteNonQuery();
            update = new MySqlCommand("update Contiene set activo =false where idOri=" + ori.Id + ";", conexion);
            update.ExecuteNonQuery();
            foreach (Contiene cont in contienes)
            {
                MySqlDataReader reader = null;
                string query = "select * from Contiene where idOri=" + ori.Id + " and idAsig='"+cont.Asignatura+"';";
                MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
                reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        update = new MySqlCommand("update Contiene set activo =true where idOri=" + ori.Id + ";", conexion);
                        update.ExecuteNonQuery();
                    }
                }
                else
                {
                    MySqlCommand insert = new MySqlCommand("insert into Contiene values('"+cont.Asignatura+"',"+cont.Orientacion+",true);", conexion);
                    insert.ExecuteNonQuery();
                }
                
            }
            conexion.Close();
        }
        public DataTable SelectAsignaturasGrilla()
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select id,nombre,anio from Asignatura where activo=true order by anio;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            conexion.Close();
            return data;
        }

        public void AltaAsignatura(Asignatura asig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Asignatura values('" + asig.Id + "','" + asig.Nombre + "',"+asig.Anio+",true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void BajaAsignatura(Asignatura asig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Asignatura set Activo=false where id='" + asig.Id + "';", conexion);
            update.ExecuteNonQuery();
            update=new MySqlCommand("update Contiene set Activo=false where idAsig='" + asig.Id + "';", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarAsignatura(Asignatura asig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Asignatura set nombre='"+asig.Nombre+"' where id='" + asig.Id + "';", conexion);
            update.ExecuteNonQuery();
            update = new MySqlCommand("update Asignatura set anio="+asig.Anio+ " where id='" + asig.Id + "';", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public void AltaClase(Clase clase)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into Clase(nombre,anio,orientacion,activo) values('" + clase.Nombre + "'," + clase.Anio + "," + clase.Orientacion + ",true);", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public List<Clase> SelectClasesPorAnio(int anio)
        {
            List<Clase> clases = new List<Clase>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Clase where anio=" + anio + " and activo=true;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Clase clase = new Clase();

                clase.IdClase = Convert.ToInt32(data.Rows[x][0].ToString());
                clase.Nombre = data.Rows[x][1].ToString();
                clase.Anio = Convert.ToInt32(data.Rows[x][2].ToString());
                clase.Orientacion = Convert.ToInt32(data.Rows[x][3].ToString());
                clase.Activo = true;
                clases.Add(clase);
            }
            conexion.Close();
            return clases;
        }
        public void BajaClase(Clase cla)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Clase set Activo=false where idClase=" + cla.IdClase + ";", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarClase(Clase cla)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update Clase set nombre='" + cla.Nombre + "' where idClase=" + cla.IdClase + ";", conexion);
            update.ExecuteNonQuery();
            update = new MySqlCommand("update Clase set anio=" + cla.Anio + " where idClase=" + cla.IdClase + ";", conexion);
            update.ExecuteNonQuery();
            update = new MySqlCommand("update Clase set orientacion=" + cla.Orientacion + " where idClase=" + cla.IdClase + ";", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public List<SolicitudClaseAl> SelectSolicitudesClaseAlResueltas(string ci)
        {
            List<SolicitudClaseAl> solicitudesClaseAl = new List<SolicitudClaseAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select SolicitudClaseAl.* from SolicitudClaseAl, RespondeClaseAl where SolicitudClaseAl.idSolicitudClaseAl = RespondeClaseAl.idSolicitudClaseAl and SolicitudClaseAl.pendiente = false and RespondeClaseAl.ciAdmin='" + ci +"' order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudClaseAl soolicitudClaseAl = new SolicitudClaseAl();

                soolicitudClaseAl.IdSolicitudClaseAl = Convert.ToInt32(data.Rows[x][0].ToString());
                soolicitudClaseAl.FechaHora = soolicitudClaseAl.StringADateTime(data.Rows[x][1].ToString());
                soolicitudClaseAl.Pendiente = false;
                soolicitudClaseAl.Alumno = data.Rows[x][3].ToString();
                solicitudesClaseAl.Add(soolicitudClaseAl);
            }
            conexion.Close();
            return solicitudesClaseAl;
        }
        public List<SolicitudClaseDo> SelectSolicitudesClaseDoResueltas(string ci)
        {
            List<SolicitudClaseDo> solicitudesClaseDo = new List<SolicitudClaseDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select SolicitudClaseDo.* from SolicitudClaseDo, RespondeClaseDo where SolicitudClaseDo.idSolicitudClaseDo = RespondeClaseDo.idSolicitudClaseDo and SolicitudClaseDo.pendiente = false and RespondeClaseDo.ciAdmin='" + ci + "' order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudClaseDo solcitudClaseDo = new SolicitudClaseDo();

                solcitudClaseDo.IdSolicitudClaseDo = Convert.ToInt32(data.Rows[x][0].ToString());
                solcitudClaseDo.FechaHora = solcitudClaseDo.StringADateTime(data.Rows[x][1].ToString());
                solcitudClaseDo.Pendiente = false;
                solcitudClaseDo.Docente = data.Rows[x][3].ToString();
                solicitudesClaseDo.Add(solcitudClaseDo);
            }
            conexion.Close();
            return solicitudesClaseDo;
        }
        public List<SolicitudModif> SelectSolicitudesModifResueltas(string ci)
        {
            List<SolicitudModif> solicitudesModif = new List<SolicitudModif>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select SolicitudModif.* from SolicitudModif, Responde where SolicitudModif.idSolicitudModif = Responde.idSolicitudModif and SolicitudModif.pendiente = false and Responde.ci='" + ci + "' order by fechaHora; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                SolicitudModif solicitudModif = new SolicitudModif();

                solicitudModif.IdSolicitudModif = Convert.ToInt32(data.Rows[x][0].ToString());
                solicitudModif.FechaHora = solicitudModif.StringADateTime(data.Rows[x][1].ToString());
                solicitudModif.ContraNueva = data.Rows[x][2].ToString();
                solicitudModif.Pendiente = false;
                solicitudModif.Aceptada = false;
                if (data.Rows[x][4].ToString() == "True")
                {
                    solicitudModif.Aceptada = true;
                }
                solicitudModif.Usuario = data.Rows[x][5].ToString();
                solicitudesModif.Add(solicitudModif);
            }
            conexion.Close();
            return solicitudesModif;
        }
        public List<Mensaje> SelectMensajesRecibidosAl(string alumno)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where alumno='" + alumno + "' and estado='recibido' order by fechaHoraDocente desc, fechaHora desc;", conexion);
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

                mensajes.Add(mensaje);
            }



            conexion.Close();
            return mensajes;
        }
        public List<Mensaje> SelectMensajesContestadosDo(string docente)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where docente='" + docente + "' and estado!='realizado' order by fechaHoraDocente desc, fechaHora desc;", conexion);
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

                mensajes.Add(mensaje);
            }



            conexion.Close();
            return mensajes;
        }
        public List<Mensaje> SelectMensajesContestadosDo(string docente, string nombre, string apellido)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Mensaje.* from Mensaje, Usuario where Usuario.ci=Mensaje.Alumno and docente='"+docente+"' and estado!='realizado' and usuario.nombre like '"+nombre+"%' and usuario.apellido like '"+apellido+"%' order by fechaHoraDocente desc, fechaHora desc;", conexion); ;
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

                mensajes.Add(mensaje);
            }



            conexion.Close();
            return mensajes;
        }


        public bool SelectDocenteDisponible(string asig, string ci, int clase)
        {
            bool disponible = true;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from Chat, ChateaDo where Chat.idChat=ChateaDo.idChat and chat.activo=true and chat.idClase="+clase+ " and chateaDo.ci='"+ci+"' and chat.asignatura='"+asig+"';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    disponible = false;
                }
            }
            conexion.Close();
            return disponible;
        }
        public List<Usuario> SelectParticipantes(int chat)
        {
            List<Usuario> usuarios = new List<Usuario>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Nombre, apellido from Usuario, ChateaAl where Usuario.ci = ChateaAl.ci and ChateaAl.idChat = " + chat + " group by Usuario.ci order by horaEnvioAl; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = data.Rows[x][0].ToString();
                usuario.Primer_apellido = data.Rows[x][1].ToString();
                usuarios.Add(usuario);
            }
            select = new MySqlCommand("select Nombre, apellido from Usuario, ChateaDo where Usuario.ci = ChateaDo.ci and ChateaDo.idChat = " + chat + " group by Usuario.ci order by horaEnvioDo; ", conexion);
            adapter = new MySqlDataAdapter(select);
            data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = data.Rows[x][0].ToString();
                usuario.Primer_apellido = data.Rows[x][1].ToString();
                usuarios.Insert(1, usuario);
            }
            conexion.Close();
            return usuarios;
        }
        public List<Usuario> SelectParticipantesGrupo(AsignaturaCursa asig)
        {
            List<Usuario> usuarios = new List<Usuario>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Nombre, apellido from Usuario, AsignaturaCursa where Usuario.ci = AsignaturaCursa.ci and AsignaturaCursa.idClase="+asig.IdClase+ " and AsignaturaCursa.orientacion="+asig.Orientacion+ " and AsignaturaCursa.anio="+asig.Anio+ " and AsignaturaCursa.asignaturaCursada='"+asig.AsignaturaCursada+ "' and cursando=true order by apellido; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = data.Rows[x][0].ToString();
                usuario.Primer_apellido = data.Rows[x][1].ToString();
                usuarios.Add(usuario);
            }
            conexion.Close();
            return usuarios;
        }
        public List<Usuario> SelectParticipantesGrupo(AsignaturaDictada asig)
        {
            List<Usuario> usuarios = new List<Usuario>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Nombre, apellido from Usuario, AsignaturaCursa where Usuario.ci = AsignaturaCursa.ci and AsignaturaCursa.idClase=" + asig.IdClase + " and AsignaturaCursa.orientacion=" + asig.Orientacion + " and AsignaturaCursa.anio=" + asig.Anio + " and AsignaturaCursa.asignaturaCursada='" + asig.AsigDictada + "' and cursando=true order by apellido; ", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = data.Rows[x][0].ToString();
                usuario.Primer_apellido = data.Rows[x][1].ToString();
                usuarios.Add(usuario);
            }
            conexion.Close();
            return usuarios;
        }
        public void BajaGrupo(AsignaturaCursa asig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update asignaturaCursa set cursando=false where ci ='" + asig.Ci+"' and idClase=" + asig.IdClase + " and orientacion=" + asig.Orientacion + " and anio=" + asig.Anio + " and asignaturaCursada='" + asig.AsignaturaCursada + "';", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public void BajaGrupo(AsignaturaDictada asig)
        {
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand update = new MySqlCommand("update asignaturaDictada set dictando=false where ci ='" + asig.Ci + "' and idClase=" + asig.IdClase + " and orientacion=" + asig.Orientacion + " and anio=" + asig.Anio + " and asignaturaDictada='" + asig.AsigDictada + "';", conexion);
            update.ExecuteNonQuery();
            conexion.Close();
        }
        public List<AsignaturaSolicitudClaseAl> SelectAsignaturasSolicitudesClaseAl(string ci)
        {
            List<AsignaturaSolicitudClaseAl> asigs = new List<AsignaturaSolicitudClaseAl>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select AsignaturaSolicitudClaseAl.* from AsignaturaSolicitudClaseAl, solicitudClaseAl where AsignaturaSolicitudClaseAl.idsolicitudClaseAl=solicitudClaseAl.idsolicitudClaseAl and solicitudClaseAl.pendiente=true and solicitudClaseAl.alumno='"+ci+"';", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaSolicitudClaseAl asig = new AsignaturaSolicitudClaseAl();

                asig.IdSolicitudClaseAl = Convert.ToInt32(data.Rows[x][0].ToString());
                asig.IdClaseAsig = Convert.ToInt32(data.Rows[x][1].ToString());
                asig.OriClaseAsig = Convert.ToInt32(data.Rows[x][2].ToString());
                asig.IdAsignatura = data.Rows[x][3].ToString();
                asig.Aceptada = true;
                if (data.Rows[x][1].ToString() == "False")
                {
                    asig.Aceptada = false;
                }
                asigs.Add(asig);
            }
            conexion.Close();
            return asigs;
        }
        public List<AsignaturaSolicitudClaseDo> SelectAsignaturasSolicitudesClaseDo(string ci)
        {
            List<AsignaturaSolicitudClaseDo> asigs = new List<AsignaturaSolicitudClaseDo>();
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select AsignaturaSolicitudClaseDo.* from AsignaturaSolicitudClaseDo, solicitudClaseDo where AsignaturaSolicitudClaseDo.idSolicitudClaseDo=SolicitudClaseDo.idSolicitudClaseDo and SolicitudClaseDo.pendiente=true and SolicitudClaseDo.docente='" + ci + "';", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                AsignaturaSolicitudClaseDo asig = new AsignaturaSolicitudClaseDo();

                asig.IdSolicitudClaseDo = Convert.ToInt32(data.Rows[x][0].ToString());
                asig.IdClaseAsig = Convert.ToInt32(data.Rows[x][1].ToString());
                asig.OriClaseAsig = Convert.ToInt32(data.Rows[x][2].ToString());
                asig.IdAsignatura = data.Rows[x][3].ToString();
                asig.Aceptada = true;
                if (data.Rows[x][1].ToString() == "False")
                {
                    asig.Aceptada = false;
                }
                asigs.Add(asig);
            }
            conexion.Close();
            return asigs;
        }
        public AsignaturaCursa SelectAsignaturaCursaPorAsignaturaYCiInclusivo(string asignatura, string ci)
        {
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection(connection);
            conexion.Open();
            string query = "select * from asignaturaCursa where ci='" + ci + "' and asignaturaCursada='" + asignatura + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            AsignaturaCursa asigCursa = new AsignaturaCursa();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    asigCursa.Ci = reader.GetString("ci");
                    asigCursa.IdClase = Convert.ToInt32(reader.GetString("idClase"));
                    asigCursa.Orientacion = Convert.ToInt32(reader.GetString("orientacion"));
                    asigCursa.Anio = Convert.ToInt32(reader.GetString("anio"));
                    asigCursa.AsignaturaCursada = reader.GetString("asignaturaCursada");
                    asigCursa.Cursando = false;
                    if (reader.GetString("cursando") == "True")
                    {
                        asigCursa.Cursando = true;
                    }
                }
            }
            conexion.Close();
            return asigCursa;
        }
    }

}

