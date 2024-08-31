using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class DataBase  // Define una clase pública llamada 'DataBase'. Esta clase contiene configuraciones y métodos relacionados con la conexión a la base de datos.
    {
        public static int ConnectionTimeout { get; set; }  // Define una propiedad estática pública de tipo entero llamada 'ConnectionTimeout' con métodos 'get' y 'set'. Representa el tiempo de espera de la conexión en segundos.
        public static string ApplicationName { get; set; }  // Define una propiedad estática pública de tipo cadena llamada 'ApplicationName' con métodos 'get' y 'set'. Representa el nombre de la aplicación que se conectará a la base de datos.
        public static string ConnectionString  // Define una propiedad estática pública de solo lectura de tipo cadena llamada 'ConnectionString'.
        {
            get  // Bloque de código que se ejecuta cuando se accede a la propiedad 'ConnectionString'.
            {
                // Obtiene la cadena de conexión desde el archivo de configuración de la aplicación (app.config o web.config) usando la clave "NWConnection".
                string CadenaConexion = ConfigurationManager.ConnectionStrings["NWConnection"].ConnectionString;

                // Crea un objeto 'SqlConnectionStringBuilder' utilizando la cadena de conexión obtenida. Este objeto facilita la manipulación de los valores dentro de la cadena de conexión.
                SqlConnectionStringBuilder conexionBuilder = new SqlConnectionStringBuilder(CadenaConexion);

                // Establece la propiedad 'ApplicationName' del objeto 'conexionBuilder'. Si 'ApplicationName' está definido, lo asigna; de lo contrario, mantiene el valor existente en 'conexionBuilder'.
                conexionBuilder.ApplicationName = ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el valor de 'ConnectTimeout' en 'conexionBuilder'. Si 'ConnectionTimeout' es mayor que 0, usa ese valor; de lo contrario, mantiene el valor existente en 'conexionBuilder'.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : conexionBuilder.ConnectTimeout;
                return conexionBuilder.ToString();  // Convierte el objeto 'conexionBuilder' de nuevo en una cadena de conexión y la retorna.
            }
        }

        public static SqlConnection GetSqlConnection()  // Define un método estático público llamado 'GetSqlConnection' que devuelve un objeto 'SqlConnection'.
        {

            SqlConnection conexion = new SqlConnection(ConnectionString);  // Crea una nueva instancia de 'SqlConnection' utilizando la propiedad 'ConnectionString' que se definió anteriormente.
            conexion.Open();  // Abre la conexión a la base de datos.
            return conexion;  // Retorna el objeto 'SqlConnection' ya abierto.

        }
    }
}
