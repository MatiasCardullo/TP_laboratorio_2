using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLibreria
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
            autor.Enabled = false;
            precio.Enabled = false;
            this.tipo1.DataSource = Enum.GetNames(typeof(ELibro));
            this.tipo1.Hide();
            this.tipo2.Hide();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        private void titulo_TextChanged(object sender, EventArgs e)
        {
            if (titulo.Text != "")
                autor.Enabled = true;
        }
        private void autor_TextChanged(object sender, EventArgs e)
        {
            if (titulo.Text != "")

                tipo1.Show();
        }

        private void tipo1_Click(object sender, EventArgs e)
        {
            this.tipo2.Show();
            this.precio.Enabled = true;
        }

        private void tipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ELibro tipo;
            Enum.TryParse(tipo1.SelectedValue.ToString(), out tipo);
            switch (tipo)
            {
                case ELibro.Manual:
                    this.tipo2.DataSource = Enum.GetNames(typeof(ETipo));
                    break;
                case ELibro.Novela:
                    this.tipo2.DataSource = Enum.GetNames(typeof(EGenero));
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void precio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
