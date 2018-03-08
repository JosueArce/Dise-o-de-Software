using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Data;

namespace WebApi_Othello.Models
{
    public class LoginManager
    {
        //permite conectar a la base de datos
        private static string cadenaConexion =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Othello_DB;Integrated Security=True;User Id=sa;Password=Josue54321;MultipleActiveResultSets=True";
        SqlConnection connection = new SqlConnection(cadenaConexion);//permite establecer la conexion con la Base de Datos
        string sqlQuery;//almacena la consulta SQL, se utiliza en la mayoria de los metodos
        SqlCommand command;//permite realizar la consulta mediante la cadena conexion y la consulta

        /// <summary>
        /// Método principal encargado de verificar si el usuario existe en el sistema o no
        /// 1. Existe: en caso de que se encuentre dentro del sistema, se obtendrá toda la información relacionada con el jugador
        /// 2. No existe: dado el caso en que sea la primera vez en que el usuario ingrese al sistema, se le creará un espacio en la BD para
        /// que este la puede usar en las próximas veces que inicie sesión en el sistema.
        /// </summary>
        /// <param name="persona"></param>
        public List<Estadisticas_Persona> check_ExtractData(PersonasActivas persona)
        {
            try
            {
                connection.Open();
                sqlQuery = "SELECT count(*) FROM dbo.[Personas Activas] where ID_Facebook = @ID_Facebook ";
                command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@ID_Facebook", persona.ID_Facebook);

                int count = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();

                //setIP(persona); //agrega la dirección IP de la computadora del jugador

                if (count != 0)//Ya existe el usuario
                {
                   return extract_Data(persona); //como el usuario existe entonces se llama esta función para que retorne los datos relevantes al usuario
                }
                
                generate_New_Account(persona); //si el usuario no existe, se le crea un nuevo espacio en la BD             

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Permite obtener los datos del jugador en caso de que exista en el sistema
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public List<Estadisticas_Persona> extract_Data(PersonasActivas persona)
        {
            Estadisticas_Persona registro;
            List<Estadisticas_Persona> list_result = new List<Estadisticas_Persona>();
            try
            {
                connection.Open();
                sqlQuery = "SELECT EP.ID_Facebook, EP.Partidas_Ganadas,EP.Partidas_Empatadas,EP.Partidas_Perdidas FROM dbo.[Estadisticas Persona] as EP where ID_Facebook = @ID_Facebook ";
                command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@ID_Facebook", persona.ID_Facebook);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    registro = new Estadisticas_Persona //Obtiene los datos del jugador
                    {
                        ID_Facebook = reader.GetString(0),
                        partidas_ganadas = reader.GetInt32(1),
                        partidas_empatadas = reader.GetInt32(2),
                        partidas_perdidas = reader.GetInt32(3)
                    };
                    list_result.Add(registro);
                }
                connection.Close();
                return list_result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Si el usuario no existe, se le creará un espacio en la BD para poder almacenar información relevante a su progreso
        /// </summary>
        public void generate_New_Account(PersonasActivas persona)
        {
            try
            {
                connection.Open();
                sqlQuery = "INSERT INTO dbo.[Estadisticas Persona] values (@ID_Facebook,0,0,0) ";
                command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@ID_Facebook", persona.ID_Facebook);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Método que permite guardar la dirección IP del usuario para luego enviar los respectivos paquetes necesarios
        /// También permite localizarlo en caso de tener que interactuar con otros usuarios.
        /// </summary>
        /// <param name="persona"></param>
        public void setIP(PersonasActivas persona)
        {
            try
            {
                connection.Open();
                sqlQuery = "INSERT INTO dbo.[Personas Activas] values (@ID_Facebook,@IP) ";
                command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@ID_Facebook", persona.ID_Facebook);
                command.Parameters.AddWithValue("@IP",persona.IP_Computer);

                int resp = command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Permite quitar la IP del usuario de la BD luego de que este se haya deslogeado del sistema.
        /// Aparte de ser por motivos de privacidad y seguridad es también para no mantener información en la BD
        /// </summary>
        /// <returns></returns>
        public bool remove_IP(PersonasActivas persona)
        {
            try
            {
                connection.Open();
                sqlQuery = "DELETE FROM [Personas Activas] where ID_Facebook = @ID_Facebook";
                command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@ID_Facebook", persona.ID_Facebook);

                int resp = command.ExecuteNonQuery();

                connection.Close();

                if (resp == -1) return false;
                else return true;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}