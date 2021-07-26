using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormLibreria
{
    public partial class Vender : Form
    {
        private Libreria lib;
        private Libro libro;
        public int id;
        public float precio;
        //List<Libro> biblo;
        public Vender(Libreria input)
        {
            //biblo = input.Libros;
            InitializeComponent();
            lib = input;
            comboBox1.DataSource = input.Nombres();
        }

        private void Vender_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //infoLibro.Text = biblo[comboBox1.SelectedIndex].ToString();
            id = comboBox1.SelectedIndex;
            libro= Libreria.GetLibro(lib, id);
            infoLibro.Text = (string)libro;
            precio = libro.Precio;
        }

        private void infoLibro_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
