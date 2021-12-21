using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//390.215
namespace Kursach
{
    class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<Point> points = new List<Point>();
        public float GravitationX = 0;
        public float GravitationY = 1;
        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                if (particle.Life < 0)
                {
                    // восстанавливаю здоровье
                    particle.Life = 20 + Particle.rand.Next(100);
                    // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = 390;
                    particle.Y = 215;
                    var direction = (double)Particle.rand.Next(180);
                    var speed = 10 + Particle.rand.Next(10);
                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                    particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {
                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500) // пока частиц меньше 500 генерируем новые
                {
                    var particle = new ParticleColorful();
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = 390;
                    particle.Y = 215;
                    particles.Add(particle);
                }
                else
                {
                    break; // а если частиц уже 500 штук, то ничего не генерирую
                }
            }
            foreach (var particle in particles)
            {
                foreach (var point in points)
                {
                    double d = Math.Sqrt(Math.Pow(particle.X - point.Xp, 2) + Math.Pow(particle.Y - point.Yp, 2));
                    if (d <= point.R)
                    {
                        point.count++;
                        particle.Life = 0;
                    }
                }
            }
        }
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach(var point in points)
            {
                point.Draw(g);
            }
        }
    }
}
