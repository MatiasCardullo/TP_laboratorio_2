using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class ToDepo : Form
    {
        int frame,time,timeCount;
        Image loading;
        string[] imageFile=new string[6] { "Cargo1.png", "Cargo2.png", "Cargo3.png", "Cargo4.png", "Cargo5.png", "Cargo6.png" };

        public ToDepo()
        {
            InitializeComponent();
            frame = 0;
            time = 100;
        }

        private void TruckWindow_Paint(object sender, PaintEventArgs e)
        {
            loading = Image.FromFile(imageFile[frame]);
            e.Graphics.DrawImage(loading, 0,0,new Rectangle(0, 0, 140 , 120), GraphicsUnit.Pixel);
            frame++;
            timeCount++;
            if (frame == 6)
            {
                frame = 0;
            }
            if(timeCount>=time)
            {
                this.Close();
            }
            Thread.Sleep(50);
            this.Refresh();
        }
    }
}
