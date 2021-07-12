using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Formularios
{
    public partial class FrmListas : Form
    {
        public FrmListas()
        {
            InitializeComponent();
        }

        public FrmListas(string cadena)
            :this()
        {
            this.textBox1.Text = cadena;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
