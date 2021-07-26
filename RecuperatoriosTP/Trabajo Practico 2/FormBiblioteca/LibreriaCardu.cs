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
    public partial class LibreriaCardu : Form
    {
        public Libreria miLibreria;
        public float cajero;

        public LibreriaCardu()
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
            Actualizar();

        }
        /// <summary>
        /// Boton para agregar libros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAgregar_Click(object sender, EventArgs e)
        {

            bool hayEspacio = miLibreria.Libros.Count()< miLibreria.Capacidad;
            if (hayEspacio)
            {
                Agregar frm = new Agregar();
                DialogResult value = frm.ShowDialog();

                if (value == DialogResult.OK && frm.titulo.Text != "" && frm.autor.Text != "" && frm.precio.Value != 0)
                {
                    ELibro tipo;
                    Autor autor;
                    Enum.TryParse(frm.tipo1.SelectedValue.ToString(), out tipo);
                    if (frm.autor.Text.Contains(','))
                    {
                        string[] splitAutor = frm.autor.Text.Split(',');
                        autor = new Autor(splitAutor[1], splitAutor[0]);
                    }
                    else
                    {
                        autor = new Autor(frm.autor.Text,"");
                    }
                    if (hayEspacio)
                    {
                        switch (tipo)
                        {
                            case ELibro.Manual:
                                ETipo man;
                                Enum.TryParse(frm.tipo2.SelectedValue.ToString(), out man);
                                Manual m = new Manual(frm.titulo.Text, (float)frm.precio.Value, autor, man);
                                this.miLibreria += m;
                                break;
                            case ELibro.Novela:
                                EGenero gen;
                                Enum.TryParse(frm.tipo2.SelectedValue.ToString(), out gen);
                                Novela n = new Novela(frm.titulo.Text, (float)frm.precio.Value, autor, gen);
                                this.miLibreria += n;
                                break;

                            default:

                                break;
                        }
                    }
                    Actualizar();
                    MessageBox.Show("Se agrego con exito");
                }
                else if(value == DialogResult.OK)
                {
                    MessageBox.Show("Falta ingresar datos");
                }
            }
            else
            {
                MessageBox.Show("Espacio insuficiente en la libreria");
            }


        }
        /// <summary>
        /// Boton de Venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
