using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Parcial
{
    public partial class Listado : Form  // Define una clase parcial pública llamada 'Listado' que hereda de la clase 'Form'.
    {
        PersonaRepository personarepo = new PersonaRepository();  // Declara una variable de instancia llamada 'personarepo' e inicializa una nueva instancia de 'PersonaRepository'.
        public Listado()  // Constructor de la clase 'Listado'.
        {
            InitializeComponent();  // Llama al método 'InitializeComponent' para inicializar los componentes del formulario. Este método configura los controles visuales en el formulario.
            CargarDatos();  // Llama al método 'CargarDatos' inmediatamente después de la inicialización para cargar los datos en el formulario.
        }

        private void CargarDatos()  // Método privado que se encarga de cargar los datos en el formulario.
        {
            var ObtenerTodo = personarepo.ObtenerDatos();  // Llama al método 'ObtenerDatos' de 'PersonaRepository' para obtener una lista de personas y la asigna a la variable 'ObtenerTodo'.
            TablaPersonal.DataSource = ObtenerTodo;  // Asigna la lista de personas obtenida a la propiedad 'DataSource' de 'TablaPersonal', que probablemente es un control de tabla (como un DataGridView) en el formulario.
        }

        private void tbRecargar_Click(object sender, EventArgs e)  // Método privado que maneja el evento 'Click' de un botón llamado 'tbRecargar'.
        {
            CargarDatos();  // Llama al método 'CargarDatos' cuando se hace clic en 'tbRecargar', lo que recarga los datos en la tabla, permitiendo actualizar la vista con cualquier cambio reciente en los datos.
        }

        private void TablaPersonal_CellClick_1(object sender, DataGridViewCellEventArgs e)  // Define un método privado que maneja el evento 'CellClick' de un control de tabla llamado 'TablaPersonal'.
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  // Verifica si el clic fue realizado en una celda válida (no en los encabezados de columna o fila).
            {
                int id = int.Parse(TablaPersonal.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());  // Obtiene el valor del campo 'SupplierID' de la fila seleccionada y lo convierte a un entero.

                if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Update"))  // Verifica si la columna en la que se hizo clic es la columna de actualización ('Update').
                {
                    //MessageBox.Show($"Se toco EDITAR con el id: {id} ");
                    MantenimientoPerson mante = new MantenimientoPerson(id);   // Crea una nueva instancia de la clase 'MantenimientoPerson', pasando el 'id' como parámetro al constructor para editar el registro correspondiente.
                    mante.ShowDialog();  // Muestra el formulario de mantenimiento como un cuadro de diálogo modal para que el usuario edite el registro.
                    CargarDatos();  // Recarga los datos en la tabla para reflejar los cambios realizados.
                }
                else if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Delete"))  // Verifica si la columna en la que se hizo clic es la columna de eliminación ('Delete').
                {

                    int elimindas = personarepo.EleminarPersonal(id);
                    // Llama al método 'EleminarPersonal' del repositorio 'personarepo' para eliminar el registro con el 'id' seleccionado. 
                    // La variable 'elimindas' contiene el número de filas afectadas (debería ser 1 si la eliminación fue exitosa).

                    if (elimindas > 0)  // Verifica si se eliminó al menos un registro.
                    {
                        MessageBox.Show("Personal Eliminado con Exito", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Muestra un mensaje de éxito si el registro fue eliminado correctamente

                        CargarDatos();  // Recarga los datos en la tabla para reflejar la eliminación del registro.
                    }
                    else
                    {
                        MessageBox.Show("El personal no FUE ELIMINADO", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Muestra un mensaje de error si el registro no pudo ser eliminado.
                }
                }
            }

        }

        private void tbFiltro_TextChanged_1(object sender, EventArgs e)  // Define un método privado que maneja el evento 'TextChanged' de un control de texto llamado 'tbFiltro'.
        {
            var ObtenerTodo = personarepo.ObtenerDatos();  // Llama al método 'ObtenerDatos' del repositorio 'personarepo' para obtener una lista de todas las personas y la asigna a la variable 'ObtenerTodo'.

            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            /* Crea una nueva lista 'filtro' que contiene solo aquellos elementos de 'ObtenerTodo' cuyo campo 'CompanyName' comienza con el texto ingresado en 'tbFiltro'. 
            El método 'FindAll' busca todos los elementos que cumplen con la condición especificada (en este caso, que 'CompanyName' comience con el texto de 'tbFiltro'). */

            TablaPersonal.DataSource = filtro;  // Asigna la lista filtrada 'filtro' a la propiedad 'DataSource' de 'TablaPersonal', que es un control de tabla en el formulario.
        }
    }
}
