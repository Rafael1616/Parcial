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
    public partial class Form1 : Form  // Define una clase parcial pública llamada 'Form1' que hereda de la clase 'Form'.
    {
        public Form1()  // Constructor de la clase 'Form1'.
        {
            InitializeComponent();  // Llama al método 'InitializeComponent' para inicializar los componentes del formulario.
        }

        private void button1_Click_1(object sender, EventArgs e)  // Define un método privado que maneja el evento 'Click' del botón llamado 'button1'. Este método se ejecuta cuando se hace clic en 'button1'.
        {
            Listado link = new Listado();  // Crea una nueva instancia de la clase 'Listado' y la asigna a la variable 'link'.
            link.ShowDialog();  // Muestra el formulario 'Listado' como un cuadro de diálogo modal, lo que significa que el usuario debe interactuar con él antes de regresar al formulario principal.
        }

        private void button2_Click_1(object sender, EventArgs e)  // Define un método privado que maneja el evento 'Click' del botón llamado 'button2'. Este método se ejecuta cuando se hace clic en 'button2'.
        {
            MantenimientoPerson persona = new MantenimientoPerson();  // Crea una nueva instancia de la clase 'MantenimientoPerson' y la asigna a la variable 'persona'.
            persona.ShowDialog();  // Muestra el formulario 'MantenimientoPerson' como un cuadro de diálogo modal.
        }
    }
}
