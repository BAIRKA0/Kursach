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
        /*public Color FromColor;
        public Color ToColor;
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }*/
        public virtual void Draw(Graphics g)
        {
            var pen = new Pen(Color.White);
            g.DrawEllipse(pen, Xp - R, Yp - R, R * 2, R * 2);
            /*float k = Math.Min(1f, count / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, Xp - R, Yp - R, R * 2, R * 2);*/
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
