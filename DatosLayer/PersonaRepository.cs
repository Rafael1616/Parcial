using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class PersonaRepository
    {
        public List<Person> ObtenerDatos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectFrom = "";
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

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Person> persona = new List<Person>();

                    while (reader.Read())
                    {
                        var person = LeerDelDataReader(reader);
                        persona.Add(person);
                    }
                    return persona;
                }
            }
        }

        public Person LeerDelDataReader(SqlDataReader reader)
        {
            Person persona = new Person();
            persona.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : (int)reader["SupplierID"];
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

            return persona;
        }

        public int añadirPersonal(Person persona)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String InsertPerson = "";
                InsertPerson = InsertPerson + "INSERT INTO [dbo].[Suppliers] " + "\n";
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

                using (var comando = new SqlCommand(InsertPerson, conexion))
                {
                    int insertados = parametrosPersonal(persona, comando);
                    return insertados;
                }
            }
        }

        public int parametrosPersonal(Person personal, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CompanyName", personal.CompanyName);
            comando.Parameters.AddWithValue("ContactName", personal.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", personal.ContactTitle);
            comando.Parameters.AddWithValue("City", personal.City);
            comando.Parameters.AddWithValue("PostalCode", personal.PostalCode);
            comando.Parameters.AddWithValue("Country", personal.Country);
            comando.Parameters.AddWithValue("Phone", personal.Phone);
            var insertados = comando.ExecuteNonQuery();
            return insertados;
        }

        public int ActualizarPersonal(Person person, int id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String ActualizarPersona = "";
                ActualizarPersona = ActualizarPersona + "UPDATE [dbo].[Suppliers] " + "\n";
                ActualizarPersona = ActualizarPersona + "   SET [CompanyName] = @CompanyName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactName] = @ContactName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactTitle] =@ContactTitle" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[City] =@City" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[PostalCode] =@PostalCode" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Country] =@Country" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Phone] =@Phone" + "\n";
                ActualizarPersona = ActualizarPersona + $" WHERE SupplierID='{id}'";

                using (var comando = new SqlCommand(ActualizarPersona, conexion))
                {
                    int actualizados = parametrosPersonal(person, comando);
                    return actualizados;
                }
            }

        }

        public int EleminarPersonal(int id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String deletePerson = "";
                deletePerson = deletePerson + "DELETE FROM [dbo].[Suppliers] " + "\n";
                deletePerson = deletePerson + $"      WHERE SupplierID='{id}'";
                using (SqlCommand comando = new SqlCommand(deletePerson, conexion))
                {
                    comando.Parameters.AddWithValue("@SupplierID", id);
                    int elimindos = comando.ExecuteNonQuery();
                    return elimindos;
                }
            }
        }
        public Person ObtenerPorId(int id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectFrom = "";
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
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]" + "\n";
                selectFrom = selectFrom + $" Where SupplierID='{id}'";


                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    comando.Parameters.AddWithValue("SupplierID", id);

                    var reader = comando.ExecuteReader();
                    Person personas = null;
                    if (reader.Read())
                    {
                        personas = LeerDelDataReader(reader);
                    }
                    return personas;
                }
            }
        }
    }
}
