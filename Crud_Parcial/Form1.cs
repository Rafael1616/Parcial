﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Listado link = new Listado();
            link.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MantenimientoPerson persona = new MantenimientoPerson();
            persona.ShowDialog();
        }
    }
}
