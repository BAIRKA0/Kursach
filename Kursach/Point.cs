using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kursach
{
    public class Point
    {
        public float Xp=0;
        public float Yp=0;
        public int R=30;
        public int count = 0;
        public Point()
        {

        }
        public virtual void Draw(Graphics g)
        {
            var pen = new Pen(Color.White);
            g.DrawEllipse(pen, Xp - R, Yp - R, R * 2, R * 2);
            g.DrawString(
                count.ToString(), // значения счетчика в виде строки
                new Font("Arial", 12), // шрифт
                new SolidBrush(Color.White), // цвет
                Xp-6,Yp-7
            );
            pen.Dispose();
        }
    }
}
