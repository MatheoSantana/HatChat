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
namespace Hatchat.Persistencia
{
    public class Conexion
    {
        //inserts
        public void AltaUsuario(Usuario usuario)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insertUsuario = new MySqlCommand("insert into Usuario values('" + usuario.Ci + "','" + usuario.Apodo + "','" + usuario.Nombre + "','" + usuario.Password + "','" + usuario.Primer_apellido + "','" + usuario.Segundo_apellido + "','" + usuario.Respuesta_seguridad + "'," + usuario.FotoDePerfil + "," + usuario.Activo + "," + usuario.Preguta_seguridad + ");", conexion);
            MySqlCommand insertHijo = new MySqlCommand("insert into " + usuario.GetType().Name + " values('" + usuario.Ci + "');", conexion);
            insertUsuario.ExecuteNonQuery();
            insertHijo.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarSolicitudClaseAl(SolicitudClaseAl soli)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into solicitudClaseAl (fechaHora,pendiente,alumno) values('" + soli.FechaHora.ToString("YYYY") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "'," + soli.Pendiente + ",'" + soli.Alumno + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarClaseSolicitudClaseAl(ClaseSolicitudClaseAl soliclase)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into claseSolicitudClaseAl (idSolicitudClaseAl,idClase,oriClase) values(" + soliclase.IdSolicitudClaseAl + "," + soliclase.IdClase + "," + soliclase.OriClase + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarAsignaturaSolicitudClaseAl(AsignaturaSolicitudClaseAl soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaSolicitudClaseAl (idSolicitudClaseAl,idClaseAsig,oriClaseAsig,idAsignatura,aceptada) values(" + soliAsig.IdSolicitudClaseAl + "," + soliAsig.IdClaseAsig + "," + soliAsig.OriClaseAsig + ",'" + soliAsig.IdAsignatura + "'," + soliAsig.Aceptada + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarSolicitudClaseDo(SolicitudClaseDo soli)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into SolicitudClaseDo (fechaHora,pendiente,docente) values('" + soli.FechaHora.ToString("YYYY") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "'," + soli.Pendiente + ",'" + soli.Docente + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarClaseSolicitudClaseDo(ClaseSolicitudClaseDo soliclase)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into claseSolicitudClaseDo (idSolicitudClaseDo,idClase,oriClase) values(" + soliclase.IdSolicitudClaseDo + "," + soliclase.IdClase + "," + soliclase.OriClase + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarAsignaturaSolicitudClaseDo(AsignaturaSolicitudClaseDo soliAsig)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand insert = new MySqlCommand("insert into asignaturaSolicitudClaseDo (idSolicitudClaseDo,idClaseAsig,oriClaseAsig,idAsignatura,aceptada) values(" + soliAsig.IdSolicitudClaseDo + "," + soliAsig.IdClaseAsig + "," + soliAsig.OriClaseAsig + ",'" + soliAsig.IdAsignatura + "'," + soliAsig.Aceptada + ");", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarMensajeAlumno(Mensaje mensaje)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            string fechahora = mensaje.FechaHoraAlumno.ToString("YYYY") + "-" + mensaje.FechaHoraAlumno.ToString("MM") + "-" + mensaje.FechaHoraAlumno.ToString("dd") + "T" + mensaje.FechaHoraAlumno.ToString("HH") + ":" + mensaje.FechaHoraAlumno.ToString("mm") + ":" + mensaje.FechaHoraAlumno.ToString("ss");
            MySqlCommand insert = new MySqlCommand("insert into Mensaje (docente,alumno,fechaHora,mensajeAlumno,estado,asunto) values('" + mensaje.Docente + "','" + mensaje.Alumno + "','" + fechahora + "','" + mensaje.MensajeAlumno + "','" + mensaje.Estado + "','" + mensaje.Asunto + "');", conexion);
            insert.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarMensajeDocente(Mensaje mensaje)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            string fechahora = mensaje.FechaHoraAlumno.ToString("YYYY") + "-" + mensaje.FechaHoraAlumno.ToString("MM") + "-" + mensaje.FechaHoraAlumno.ToString("dd") + "T" + mensaje.FechaHoraAlumno.ToString("HH") + ":" + mensaje.FechaHoraAlumno.ToString("mm") + ":" + mensaje.FechaHoraAlumno.ToString("ss");
            string fechaHoraDocente = mensaje.FechaHoraDocente.ToString("YYYY") + "-" + mensaje.FechaHoraDocente.ToString("MM") + "-" + mensaje.FechaHoraDocente.ToString("dd") + "T" + mensaje.FechaHoraDocente.ToString("HH") + ":" + mensaje.FechaHoraDocente.ToString("mm") + ":" + mensaje.FechaHoraDocente.ToString("ss");
            MySqlCommand updateRespuesta = new MySqlCommand("update Mensaje set mensajeDocente ='"+mensaje.MensajeDocente+ "' where alumno='"+mensaje.Alumno+ "' and fechaHora='"+fechahora+"' ;", conexion);
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
            Usuario us = null;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            string query = "select * from Usuario where ci='" + ci + "';";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                us.Ci = reader.GetString("ci");
                us.Apodo = reader.GetString("apodo");
                us.Password = reader.GetString("contraseña");
                us.Primer_apellido = reader.GetString("apellido");
                us.Segundo_apellido = reader.GetString("segApellido");
                us.Respuesta_seguridad = reader.GetString("resSeguridad");
                us.FotoDePerfil = (byte[])reader["foto"];
                us.Activo = (bool)reader["activo"];
                us.Preguta_seguridad = Convert.ToInt32(reader.GetString("id"));
            }
            conexion.Close();
            return us;
        }
        public bool SelectAlumno(string ci)
        {
            bool encontrado = false;
            MySqlDataReader reader = null;
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idSolicitudClaseDo from SolicitudClaseAl where fechaHora='" + soli.FechaHora.ToString("YYYY") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "' and docente='" + soli.Docente + "';", conexion);
            reader = select.ExecuteReader();
            int id;
            id = Convert.ToInt32(reader.GetString("idSolicitudClaseAl"));
            conexion.Close();
            return id;
        }


        //register docente
        //register alumno
        public DataTable SelectSolicitudClaseAl()
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idSolicitudClaseAl from SolicitudClaseAl where fechaHora='" + soli.FechaHora.ToString("YYYY") + "-" + soli.FechaHora.ToString("MM") + "-" + soli.FechaHora.ToString("dd") + "T" + soli.FechaHora.ToString("HH") + ":" + soli.FechaHora.ToString("mm") + ":" + soli.FechaHora.ToString("ss") + "' and alumno='" + soli.Alumno + "';", conexion);
            reader = select.ExecuteReader();
            int id;
            id = Convert.ToInt32(reader.GetString("idSolicitudClaseAl"));
            conexion.Close();
            return id;
        }
        //register alumno

        //Mensaje Alumno

        public List<Logica.Docente> SelectDocentesDictandoAAlumno(string ci)
        {
            List<Logica.Docente> docentes = new List<Docente>();
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            string query = "select Usuario.ci, Usuario.nombre, Usuario.apellido, Usuario.segApellido, Usuario.foto, Usuario.apodo, Usuario.activo from Usuario, Docente, asignaturaDictada, asignaturaCursa, Alumno where Docente.ci=Usuario.ci and Docente.ci=asignaturaDictada.ci and Alumno.ci='" + ci + "' and asignaturaCursa.ci=Alumno.ci and asignaturaDictada.idClase=asignaturaCursa.idClase and asignaturaDictada.asignaturaDictada=asignaturaCursa.asignaturaCursada group by Docente.Ci";
            MySqlCommand select = new MySqlCommand(string.Format(query), conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int x = 0; x < data.Rows.Count; x++)
            {
                docentes.Add(new Docente(data.Rows[x][0].ToString(), data.Rows[x][1].ToString(), data.Rows[x][2].ToString(), data.Rows[x][3].ToString(), (byte[])data.Rows[x][4], data.Rows[x][5].ToString(), (bool)data.Rows[x][6]));
            }

            conexion.Close();
            return docentes;
        }

        public Mensaje SelectAbrirMensaje(int idMensaje)
        {
            Mensaje mensaje = null;
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select * from Mensaje where idMensaje=" + idMensaje + ";", conexion);
            reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                mensaje.IdMensaje = Convert.ToInt32(reader.GetString("idMensaje"));
                mensaje.Docente = reader.GetString("docente");
                mensaje.Alumno = reader.GetString("alumno");
                mensaje.FechaHoraAlumno = mensaje.StringADateTime(reader.GetString("fechaHora"));
                mensaje.MensajeAlumno = reader.GetString("mensajeAlumno");
                mensaje.Estado = reader.GetString("estado");
                mensaje.Asunto = reader.GetString("asunto");
                mensaje.MensajeDocente = reader.GetString("mensajeDocente");
                mensaje.FechaHoraDocente = mensaje.StringADateTime(reader.GetString("fechaHoraDocente"));
            }

            conexion.Close();
            return mensaje;
        }
        public List<Mensaje> SelectCargarMensajesAl(string alumno)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where alumno='" + alumno + "' and (estado='realizado' or estado='contestado')order by fechaHoraDocente desc, fechaHora desc;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mensaje[] mensajs = new Mensaje[data.Rows.Count];
            for (int x = 0; x < data.Rows.Count; x++)
            {
                mensajs[x].IdMensaje = Convert.ToInt32(data.Rows[x][0].ToString());
                mensajs[x].Docente = data.Rows[x][1].ToString();
                mensajs[x].Alumno = data.Rows[x][2].ToString();
                mensajs[x].FechaHoraAlumno = mensajs[x].StringADateTime(data.Rows[x][3].ToString());
                mensajs[x].MensajeAlumno = data.Rows[x][4].ToString();
                mensajs[x].Estado = data.Rows[x][5].ToString();
                mensajs[x].Asunto = data.Rows[x][6].ToString();
                mensajs[x].MensajeDocente = data.Rows[x][7].ToString();
                mensajs[x].FechaHoraDocente = mensajs[x].StringADateTime(data.Rows[x][8].ToString());
            }

            mensajes.AddRange(mensajs);

            conexion.Close();
            return mensajes;
        }


        //Mensaje Alumno

        //Mensaje Docente

        public List<Mensaje> SelectCargarMensajesDo(string docente)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Mensaje where docente='" + docente + "' and estado='realizado' order by fechaHora desc;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mensaje[] mensajs = new Mensaje[data.Rows.Count];
            for (int x = 0; x < data.Rows.Count; x++)
            {
                mensajs[x].IdMensaje = Convert.ToInt32(data.Rows[x][0].ToString());
                mensajs[x].Docente = data.Rows[x][1].ToString();
                mensajs[x].Alumno = data.Rows[x][2].ToString();
                mensajs[x].FechaHoraAlumno = mensajs[x].StringADateTime(data.Rows[x][3].ToString());
                mensajs[x].MensajeAlumno = data.Rows[x][4].ToString();
                mensajs[x].Estado = data.Rows[x][5].ToString();
                mensajs[x].Asunto = data.Rows[x][6].ToString();
                mensajs[x].MensajeDocente = data.Rows[x][7].ToString();
                mensajs[x].FechaHoraDocente = mensajs[x].StringADateTime(data.Rows[x][8].ToString());
            }
            mensajes.AddRange(mensajs);

            conexion.Close();
            return mensajes;
        }

        //Mensaje Docente
        //Register Clases Alumno

        public List<Orientacion> SelectOrientaciones()
        {
            List<Orientacion> orientaciones = new List<Orientacion>();
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select * from Orientacion ;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int x = 0; x < data.Rows.Count; x++)
            {
                orientaciones.Add(new Orientacion(Convert.ToInt32(data.Rows[x][0].ToString()), data.Rows[x][1].ToString(), (bool)data.Rows[x][2]));
            }
            conexion.Close();
            return orientaciones;
        }

        public int[] selectAnioClasesPorOrientacion(int orientacion)
        {
            
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Clase.anio from Clase, Orientacion where Orientacion.id=Clase.orientacion and Orientacion.id="+orientacion+ " group by Clase.anio order by Clase.anio;", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(select);
            DataTable data = new DataTable();
            adapter.Fill(data);
            int[] anios = new int[data.Rows.Count];
            for (int x = 0; x < data.Rows.Count; x++)
            {
                anios[x]=Convert.ToInt32(data.Rows[x][0]);
            }
            conexion.Close();

            return anios;
        }

        public string[] SelectNombreClasePorAnioYorientacion(int anio, int orientacion)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Clase.nombre from Clase, Orientacion where Orientacion.id=Clase.orientacion and Orientacion.id=" + orientacion + " and Clase.anio="+anio+" order by Clase.nombre;", conexion);
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
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand select = new MySqlCommand("select idClase from Clase where nombre='" + nombre+ "' and anio="+anio+ " and Orientacion.id="+orientacion+";", conexion);
            reader = select.ExecuteReader();
            int id;
            id = Convert.ToInt32(reader.GetString("idSolicitudClaseAl"));
            conexion.Close();
            return id;
        }
        public List<Asignatura> SelectAsignaturasPorClaseAnioYorientacion(string clase, int anio, int orientacion)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = x;");
            conexion.Open();
            MySqlCommand select = new MySqlCommand("select Asignatura.id, Asignatura.nombre, Asignatura.anio, Asignatura.activo from Asignatura, Contiene, Orientacion, Clase where Clase.orientacion=Orientacion.id and Orientacion.id=Contiene.idOri and Contiene.idAsig=Asignatura.id and Orientacion.id=" + orientacion+" and Clase.nombre='"+clase+"' and Clase.anio="+anio+";", conexion);
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
    }
}
