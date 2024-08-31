using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class Person  // Definir una clase pública llamada 'Person'. Esta clase es un modelo de datos que representa a una persona, específicamente un proveedor en este contexto.
    {
        // Define una propiedad pública de tipo entero llamada 'SupplierID' con un método 'get' y 'set'.
        public int SupplierID { get; set; }

        // Definer una propiedad pública de tipo cadena con un método 'get' y 'set' para cada campo.
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

    }
}
