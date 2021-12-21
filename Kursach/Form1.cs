using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form1 : Form
    {
        Emitter emitter = new Emitter();
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            emitter.UpdateState(); // каждый тик обновляем систему
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // добавил очистку
                emitter.Render(g);// рендерим систему
            }
            // обновить picDisplay
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point();
                p.Xp = e.X;
                p.Yp = e.Y;
                emitter.points.Add(p);
            }else if(e.Button == MouseButtons.Right)
            {
                foreach(var point in emitter.points)
                {
                    double d = Math.Sqrt(Math.Pow(e.X - point.Xp, 2) + Math.Pow(e.Y - point.Yp, 2));
                    if (d <= point.R)
                    {
                        point.Xp = -20;
                        point.Yp = -20;
                    }
                }
            }
        }
    }
}
