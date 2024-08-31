using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class PersonaRepository  // Definimos una clase
    {
        public List<Person> ObtenerDatos()  // Método que devuelve una lista de objetos de tipo 'Person'.
        {
            using (var conexion = DataBase.GetSqlConnection())  // Crear una conexión a la base de datos usando el método estático 'GetSqlConnection' de la clase 'DataBase'
            {
                String selectFrom = "";  // Se declara e inicializa una variable de tipo cadena llamada 'selectFrom'.
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))  // Se crea un objeto 'SqlCommand' que ejecutará la consulta SQL de la conexion.
                {
                    SqlDataReader reader = comando.ExecuteReader();  // Se ejecuta la consulta y se obtiene un 'SqlDataReader' para leer los datos resultantes de la consulta.
                    List<Person> persona = new List<Person>();  // Se crea una lista vacía de objetos 'Person' llamada 'persona'.

                    while (reader.Read())  // Se itera sobre cada registro que devuelve el 'SqlDataReader'.
                    {
                        var person = LeerDelDataReader(reader);  // Se llama a un método llamado 'LeerDelDataReader' para convertir cada registro en un objeto 'Person'.
                        persona.Add(person);  // Se añade el objeto 'Person' a la lista 'persona'.
                    }
                    return persona;// Se retorna la lista 'persona' que contiene todos los objetos 'Person' obtenidos de la consulta.
                }
            }
        }

        public Person LeerDelDataReader(SqlDataReader reader)  // Definición de un método público llamado 'LeerDelDataReader' que toma un objeto como parámetro y devuelve un objeto.
        {
            Person persona = new Person();  // Se crea una nueva instancia de la clase 'Person' y se asigna a la variable 'persona'.
            persona.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : (int)reader["SupplierID"];  // Se verifica si es nulo y, si es así, se asigna una cadena vacía; si no, se asigna el valor convertido a cadena, y asi continua con los demas columnasde abajo.
            persona.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"];
            persona.ContactName = reader["ContactName"] == DBNull.Value ? "" : (string)reader["ContactName"];
            persona.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (string)reader["ContactTitle"];
            persona.Address = reader["Address"] == DBNull.Value ? "" : (string)reader["Address"];
            persona.City = reader["City"] == DBNull.Value ? "" : (string)reader["City"];
            persona.Region = reader["Region"] == DBNull.Value ? "" : (string)reader["Region"];
            persona.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (string)reader["PostalCode"];
            persona.Country = reader["Country"] == DBNull.Value ? "" : (string)reader["Country"];
            persona.Phone = reader["Phone"] == DBNull.Value ? "" : (string)reader["Phone"];
            persona.Fax = reader["Fax"] == DBNull.Value ? "" : (string)reader["Fax"];
            persona.HomePage = reader["HomePage"] == DBNull.Value ? "" : (string)reader["HomePage"];

            return persona;  // Se devuelve el objeto 'persona' con los valores asignados de las columnas leídas.
        }

        public int añadirPersonal(Person persona)  // Definición de un método público llamado 'añadirPersonal' que toma un objeto 'Person' como parámetro y devuelve un entero.
        {
            using (var conexion = DataBase.GetSqlConnection())  // Establece una conexión a la base de datos utilizando el método 'GetSqlConnection' de la clase 'DataBase'.
            {
                String InsertPerson = "";  // Declara e inicializa una cadena vacía llamada 'InsertPerson'.
                InsertPerson = InsertPerson + "INSERT INTO [dbo].[Suppliers] " + "\n";  // Construye la primera parte de la consulta SQL para insertar datos en la tabla '[dbo].[Suppliers]', y despues se empieza a agregar los campos para insertar en la tabla.
                InsertPerson = InsertPerson + "           ([CompanyName] " + "\n";
                InsertPerson = InsertPerson + "           ,[ContactName] " + "\n";
                InsertPerson = InsertPerson + "           ,[ContactTitle] " + "\n";
                InsertPerson = InsertPerson + "           ,[City] " + "\n";
                InsertPerson = InsertPerson + "           ,[PostalCode] " + "\n";
                InsertPerson = InsertPerson + "           ,[Country] " + "\n";
                InsertPerson = InsertPerson + "           ,[Phone])" + "\n";
                InsertPerson = InsertPerson + "     VALUES " + "\n";
                InsertPerson = InsertPerson + "           (@CompanyName" + "\n";
                InsertPerson = InsertPerson + "           ,@ContactName" + "\n";
                InsertPerson = InsertPerson + "           ,@ContactTitle" + "\n";
                InsertPerson = InsertPerson + "           ,@City" + "\n";
                InsertPerson = InsertPerson + "           ,@PostalCode" + "\n";
                InsertPerson = InsertPerson + "           ,@Country" + "\n";
                InsertPerson = InsertPerson + "           ,@Phone)";
                // La conexión se cierra automáticamente al salir del bloque 'using'.

                using (var comando = new SqlCommand(InsertPerson, conexion))  // Crea un objeto 'SqlCommand' que representa la consulta SQL definida en 'InsertPerson', y lo asocia con la conexión 'conexion'.
                {
                    int insertados = parametrosPersonal(persona, comando);  // Llama al método 'parametrosPersonal', pasando el objeto 'persona' y el comando 'comando'. El método devuelve el número de filas insertadas y lo asigna a 'insertados'.
                    return insertados;  // Devuelve el número de filas insertadas.
                }
            }
        }

        public int parametrosPersonal(Person personal, SqlCommand comando)  // Definición de un método público llamado 'parametrosPersonal' que toma un objeto 'Person' y un objeto 'SqlCommand' como parámetros, y devuelve un entero.
        {
            comando.Parameters.AddWithValue("CompanyName", personal.CompanyName);  // Agrega un parámetro al comando SQL y continua con los demas paramtros de abajo.
            comando.Parameters.AddWithValue("ContactName", personal.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", personal.ContactTitle);
            comando.Parameters.AddWithValue("City", personal.City);
            comando.Parameters.AddWithValue("PostalCode", personal.PostalCode);
            comando.Parameters.AddWithValue("Country", personal.Country);
            comando.Parameters.AddWithValue("Phone", personal.Phone);
            var insertados = comando.ExecuteNonQuery();  // Ejecuta la consulta SQL asociada con el comando, que en este caso es una instrucción de inserción, y almacena el número de filas afectadas en la variable 'insertados'.
            return insertados;  // Devuelve el número de filas insertadas.
        }

        public int ActualizarPersonal(Person person, int id)  // Definición de un método público llamado 'ActualizarPersonal' que toma un objeto 'Person' y un entero 'id' como parámetros, y devuelve un entero.
        {
            using (var conexion = DataBase.GetSqlConnection())  
            {
                String ActualizarPersona = "";//La conexión se cierra automáticamente al salir del bloque 'using'.
                // Ahora especificaremos que la columna  debe actualizarse con el valor del parámetro.
                ActualizarPersona = ActualizarPersona + "UPDATE [dbo].[Suppliers] " + "\n";
                ActualizarPersona = ActualizarPersona + "   SET [CompanyName] = @CompanyName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactName] = @ContactName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactTitle] =@ContactTitle" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[City] =@City" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[PostalCode] =@PostalCode" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Country] =@Country" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Phone] =@Phone" + "\n";
                ActualizarPersona = ActualizarPersona + $" WHERE SupplierID='{id}'";

                using (var comando = new SqlCommand(ActualizarPersona, conexion))  // Crea un objeto 'SqlCommand' que representa la consulta SQL definida en 'ActualizarPersona', y lo asocia con la conexión 'conexion'.
                    {
                    int actualizados = parametrosPersonal(person, comando);  // Llama al método 'parametrosPersonal', pasando el objeto 'person' y el comando 'comando'. El método devuelve el número de filas actualizadas y lo asigna a 'actualizados'.
                    return actualizados;  // Devuelve el número de filas actualizadas.
                }
            }

        }

        public int EleminarPersonal(int id)  // Definición de un método público llamado 'EleminarPersonal' que toma un entero 'id' como parámetro y devuelve un entero.
        {
            using (var conexion = DataBase.GetSqlConnection())  // Establece una conexión a la base de datos utilizando el método 'GetSqlConnection' de la clase 'DataBase'. La conexión se cierra automáticamente al salir del bloque 'using'.
            {
                String deletePerson = "";  // Declara e inicializa una cadena vacía llamada 'deletePerson'.
                deletePerson = deletePerson + "DELETE FROM [dbo].[Suppliers] " + "\n";  // Construye la primera parte de la consulta SQL para eliminar un registro de la tabla '[dbo].[Suppliers]'.
                deletePerson = deletePerson + $"      WHERE SupplierID='{id}'";  // Especifica la condición de la consulta SQL, indicando que solo se debe eliminar el registro donde el 'SupplierID' coincide con el valor de 'id'.
                using (SqlCommand comando = new SqlCommand(deletePerson, conexion))  // Crea un objeto 'SqlCommand' que representa la consulta SQL definida en 'deletePerson', y lo asocia con la conexión 'conexion'.
                {
                    comando.Parameters.AddWithValue("@SupplierID", id);  // Agrega un parámetro llamado '@SupplierID' al comando SQL, con el valor de 'id' proporcionado.
                    int elimindos = comando.ExecuteNonQuery();  // Ejecuta la consulta SQL de eliminación y almacena el número de filas afectadas en la variable 'elimindos'.
                    return elimindos;  // Devuelve el número de filas eliminadas.
                }
            }
        }

        public Person ObtenerPorId(int id)  // Definición de un método público llamado 'ObtenerPorId' que toma un entero 'id' como parámetro y devuelve un objeto 'Person'.
        {
            using (var conexion = DataBase.GetSqlConnection())  // Establece una conexión a la base de datos utilizando el método 'GetSqlConnection' de la clase 'DataBase'. La conexión se cierra automáticamente al salir del bloque 'using'.
            {
                String selectFrom = "";  // Declara e inicializa una cadena vacía llamada 'selectFrom'.
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";  // Construye la primera parte de la consulta SQL para seleccionar el campo 'SupplierID'.
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";  // Añade el campo a la consulta SQL y asisucesivamente las que necesitamos.
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]" + "\n";  // Especifica la tabla '[dbo].[Suppliers]' de la que se va a realizar la selección.
                selectFrom = selectFrom + $" Where SupplierID='{id}'";  // Añade una cláusula WHERE para seleccionar solo el registro cuyo 'SupplierID' coincida con el valor de 'id'.


                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))  // Crea un objeto 'SqlCommand' que representa la consulta SQL definida en 'selectFrom', y lo asocia con la conexión 'conexion'.
                {
                    comando.Parameters.AddWithValue("SupplierID", id);  // Agrega un parámetro llamado 'SupplierID' al comando SQL, con el valor de 'id' proporcionado.

                    var reader = comando.ExecuteReader();  // Ejecuta la consulta SQL y obtiene un objeto 'SqlDataReader' para leer los resultados.
                    Person personas = null;  // Declara e inicializa una variable 'personas' de tipo 'Person' con el valor nulo.
                    if (reader.Read())  // Verifica si el 'reader' ha leído un registro (si hay datos disponibles).
                    {
                        personas = LeerDelDataReader(reader);  // Si hay un registro, llama al método 'LeerDelDataReader' para mapear los datos del 'reader' al objeto 'Person' y lo asigna a 'personas'.
                    }
                    return personas;  // Devuelve el objeto 'Person' resultante. Si no se encontró ningún registro, devuelve 'null'.
                }
            }
        }
    }
}
