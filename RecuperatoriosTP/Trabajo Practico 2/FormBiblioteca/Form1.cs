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
    public partial class Form1 : Form
    {
        public Libreria miLibreria;
        public float cajero;

        public Form1()
        {
            InitializeComponent();
            this.miLibreria = 3000;

            Autor a = new Autor("Esteban", "Rey");
            Autor b = new Autor("Joe", "Mayo");
            Manual m1 = new Manual("Economia", 25.66f, "Domingo", "Caballo", ETipo.Finanzas);
            Novela n1 = new Novela("Miseria", 63.88f, a, EGenero.Romantica);
            Manual m2 = new Manual("C#", 29.95f, "Kimmel", "Paul", ETipo.Tecnico);
            Novela n2 = new Novela("Fuego y Sangre", 203.00f, b, EGenero.Accion);
            Novela n3 = new Novela("1984", 98.00f, a, EGenero.CienciaFiccion);
            Manual m3 = new Manual("Matematicas", 103.50f, "Ferrari", "Jorge", ETipo.Escolar);

            miLibreria += m1;
            miLibreria += n1;
            miLibreria += m2;
            miLibreria += n2;
            miLibreria += n3;
            miLibreria += m3;

            Actualizar();
        }

        private void Actualizar()
        {
            this.richTextBox1.Text = Libreria.Mostrar(miLibreria);
            this.money.Text = "Cajero: $"+cajero;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.miLibreria.Capacidad!=0)
            {
                Actualizar();
                //this.btnEliminar.Enabled = true;
            }
            else
            {
                //this.btnEliminar.Enabled = false;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bAgregar_Click(object sender, EventArgs e)
        {

            bool ret = true;// miLibreria.Espacio > 0;
            Agregar frm = new Agregar();
            DialogResult value = frm.ShowDialog();

            if (value == DialogResult.OK && frm.titulo.Text != "" && frm.autor.Text != "" && frm.precio.Value!=0)
            {
                ELibro tipo;
                Enum.TryParse(frm.tipo1.SelectedValue.ToString(), out tipo);
                if (ret)
                {
                    switch (tipo)
                    {
                        case ELibro.Manual:
                            ETipo man;
                            Enum.TryParse(frm.tipo2.SelectedValue.ToString(), out man);
                            Manual m = new Manual(frm.titulo.Text, (float)frm.precio.Value, frm.autor.Text, frm.autor.Text, man);
                            this.miLibreria += m;
                            break;
                        case ELibro.Novela:
                            EGenero gen;
                            Enum.TryParse(frm.tipo2.SelectedValue.ToString(), out gen);
                            Novela n = new Novela(frm.titulo.Text, (float)frm.precio.Value, new Autor(frm.autor.Text, frm.autor.Text), gen);
                            this.miLibreria += n;
                            break;

                        default:

                            break;
                    }
                }
                if (ret == true)
                {
                    MessageBox.Show("Se agrego con exito");

                }
                else
                {
                    MessageBox.Show("Espacio insuficiente para el tipo seleccionado o ya se encuentra estacionado un vehiculo con dicha patente");
                }
                Actualizar();
            }
            else
            {
                MessageBox.Show("Falta ingresar datos");
            }

        }

        private void bVender_Click(object sender, EventArgs e)
        {
            Vender frm = new Vender(miLibreria);
            DialogResult value = frm.ShowDialog();
            if (value == DialogResult.OK)
            {
                miLibreria -= frm.id;
                cajero += frm.precio;
            }
            Actualizar();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
