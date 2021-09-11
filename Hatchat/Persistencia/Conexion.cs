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
        
        public void AltaUsuario(string table, Usuario usuario)
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost; Port = 3306; Database = Hatchat; Uid = root; Pwd = math2002;");
            conexion.Open();

            MySqlCommand insertUsuario = new MySqlCommand("insert into Usuario values('"+usuario.Ci+"','"+usuario.Apodo+"','"+usuario.Nombre+"','"+usuario.Password+"','"+usuario.Primer_apellido+"','"+usuario.Segundo_apellido+"','"+usuario.Respuesta_seguridad+"',");", conexion);
            
        }
        
        
    }
}
