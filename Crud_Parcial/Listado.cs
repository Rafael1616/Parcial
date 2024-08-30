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
    public partial class Listado : Form
    {
        PersonaRepository personarepo = new PersonaRepository();
        public Listado()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            var ObtenerTodo = personarepo.ObtenerDatos();
            TablaPersonal.DataSource = ObtenerTodo;
        }

        private void tbRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void TablaPersonal_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = int.Parse(TablaPersonal.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());

                if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Update"))
                {
                    //MessageBox.Show($"Se toco EDITAR con el id: {id} ");
                    MantenimientoPerson mante = new MantenimientoPerson(id);
                    mante.ShowDialog();
                    CargarDatos();
                }
                else if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {

                    int elimindas = personarepo.EleminarPersonal(id);
                    if (elimindas > 0)
                    {
                        MessageBox.Show("Personal Eliminado con Exito", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("El personal no FUE ELIMINADO", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void tbFiltro_TextChanged_1(object sender, EventArgs e)
        {
            var ObtenerTodo = personarepo.ObtenerDatos();

            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            TablaPersonal.DataSource = filtro;
        }
    }
}
