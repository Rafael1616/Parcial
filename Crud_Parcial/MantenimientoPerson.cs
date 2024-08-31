using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Parcial
{ 
    public partial class MantenimientoPerson : Form  // Define una clase pública parcial llamada 'MantenimientoPerson' que hereda de la clase 'Form'.
    {
        PersonaRepository persona = new PersonaRepository();  // Declara una instancia de la clase 'PersonaRepository' y la asigna a la variable 'persona'.
        int id_ = 0;  // Declara una variable entera llamada 'id_' e inicializa su valor en 0.
        public MantenimientoPerson(int id = 0)  // Define el constructor de la clase 'MantenimientoPerson'. Acepta un parámetro entero opcional 'id' con un valor predeterminado de 0.
        {
            InitializeComponent();  // Llama al método 'InitializeComponent', que inicializa los componentes del formulario, configurando su interfaz gráfica de usuario (GUI) y sus controles.
            id_ = id;  // Asigna el valor del parámetro 'id' a la variable de instancia 'id_'.
            if (id_ > 0)  // Verifica si el valor de 'id_' es mayor que 0. Esto indica que se está editando un registro existente en lugar de agregar uno nuevo.
            {
                this.Text = "Modificar Personal";  // Cambia el texto del título del formulario a "Modificar Personal", indicando que se está en modo de edición.
                AñadorP.Text = "Edicion de Personal";  // Cambia el texto del control 'AñadorP' (presumiblemente un label o título en el formulario) a "Edicion de Personal".
                btnEnviarDatos.Hide();  // Oculta el botón 'btnEnviarDatos', ya que no es necesario en el modo de edición. 
                CargarDatos();  // Llama al método 'CargarDatos' para cargar y mostrar los datos del personal que se está editando en los controles del formulario.
            }
            else
            {
                btnModificar.Hide();  // Si el valor de 'id_' es 0 (indicando que se está agregando un nuevo registro), oculta el botón 'btnModificar' ya que no es relevante en este contexto.
            }
        }

        private Person ObtenerNuevoCliente()  // Define un método privado que devuelve un objeto de tipo 'Person' llamado 'ObtenerNuevoCliente'.
        {

            var nuevoCliente = new Person  // Declara e inicializa una nueva instancia de la clase 'Person' y la asigna a la variable 'nuevoCliente'.
            {
                CompanyName = text1.Text,  // Asigna el texto del control a la propiedad del objeto 'nuevoCliente'
                ContactName = text2.Text,
                ContactTitle = text3.Text,
                City = text4.Text,
                PostalCode = text5.Text,
                Country = text6.Text,
                Phone = textBox7.Text
            };
            return nuevoCliente;  // Retorna el objeto 'nuevoCliente' que contiene los datos ingresados en los controles del formulario.
        }

        public Boolean validarCampoNull(Object objeto)  // Define un método público que retorna un valor booleano llamado 'validarCampoNull'.
        {

            foreach (PropertyInfo property in objeto.GetType().GetProperties())  // Recorre todas las propiedades del tipo del objeto utilizando reflexión.
            {
                object value = property.GetValue(objeto, null);   // Obtiene el valor de la propiedad actual del objeto. 
                if (value == "")  // Verifica si el valor de la propiedad es una cadena vacía
                {
                    return true;  // Si encuentra una propiedad con un valor vacío, retorna 'true' indicando que hay al menos un campo vacío.
                }
            }
            return false;  // Si no se encuentra ninguna propiedad con un valor vacío, retorna 'false' indicando que todos los campos tienen algún valor.
        }

        public void CargarDatos()  // Define un método público llamado 'CargarDatos' que no recibe parámetros y no devuelve valor.
        {
            var perso = persona.ObtenerPorId(id_);  // Llama al método 'ObtenerPorId' del objeto 'persona' (una instancia de la clase 'PersonaRepository'), pasando el identificador 'id_' como parámetro.

            text1.Text = perso.CompanyName;   // Asignamos el valor de la propiedad del objeto 'perso' al texto del control 'text' y 'textbox'.
            text2.Text = perso.ContactName;
            text3.Text = perso.ContactTitle;
            text4.Text = perso.City;
            text5.Text = perso.PostalCode;
            text6.Text = perso.Country;
            textBox7.Text = perso.Phone;
        }

        private void btnEnviarDatos_Click_1(object sender, EventArgs e)  // Define un método privado que maneja el evento 'Click' de un botón llamado 'btnEnviarDatos'.
        {
            var resultado = 0;   // Declara una variable entera llamada 'resultado' y la inicializa en 0.


            var nuevoCliente = ObtenerNuevoCliente();  // Llama al método 'ObtenerNuevoCliente', que devuelve un objeto de tipo 'Person' con los datos del nuevo cliente, y lo asigna a la variable 'nuevoCliente'.

            if (validarCampoNull(nuevoCliente) == false)  // Llama al método 'validarCampoNull', que verifica si alguno de los campos del objeto 'nuevoCliente' está vacío. Si ninguno de los campos está vacío, continúa con la operación.
            {
                resultado = persona.añadirPersonal(nuevoCliente);  // Llama al método 'añadirPersonal' del objeto 'persona' (una instancia de la clase 'PersonaRepository') para agregar el nuevo cliente a la base de datos.

                if (resultado == 1)  // Verifica si el resultado de la operación fue exitoso (es decir, si se agregó exactamente un registro a la base de datos).
                {
                    MessageBox.Show("Personal Agregado con EXITO", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Muestra un mensaje de confirmación si la adición fue exitosa.
                    text1.Text = "";  // Limpiamos el contenido de los controles 'text' y 'textbox'.
                    text2.Text = "";
                    text3.Text = "";
                    text4.Text = "";
                    text5.Text = "";
                    text6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Completa los campos vacios", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Si alguno de los campos está vacío, muestra un mensaje de advertencia pidiendo que se completen los campos vacíos.
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)  // Define un método privado que maneja el evento 'Click' de un botón llamado 'btnModificar'
        {
            var update = ObtenerNuevoCliente();  // Llama a un método llamado 'ObtenerNuevoCliente' que devuelve un objeto de tipo 'Person' con los datos actualizados del cliente y lo asigna a la variable 'update'.
            
            int actulizar = persona.ActualizarPersonal(update, id_);
            // Llama al método 'ActualizarPersonal' del objeto 'persona' (una instancia de la clase 'PersonaRepository'). 
            // Pasa el objeto 'update' y el identificador 'id_' como parámetros. El método devuelve un entero que indica cuántas filas fueron afectadas por la actualización y lo asigna a la variable 'actulizar'.

            if (actulizar > 0)  // Verifica si se actualizó al menos una fila.
            {
                MessageBox.Show($"Se ha actualizado de forma EXITOSA", "Actulizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Muestra un mensaje de éxito si la actualización fue exitosa.
                this.Close();  // Cierra el formulario actual.
            }
            else
            {
                MessageBox.Show($"ERROR", "Actulizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra un mensaje de error si no se actualizó ninguna fila.
            }
        }
    }
}
