using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billar
{
    public class VSolver
    {
        VPoint p1, p2;
        Vec2 axis, normal, res;
        float dis, dif;
        List<VPoint> pts;
        List<Ball> holesPts;
        public VSolver(List<VPoint> pts, List<Ball> holespts)
        {
            this.pts = pts;
            this.holesPts = holespts;
        }

        public int Update(Graphics g, int Width, int Height, Point mouse, bool isMouseDown)
        {
            int id;

            id = -1;
            for (int s = 0; s < pts.Count; s++)
            {
                for (int h = 0; h < holesPts.Count; h++)
                {
                    p1 = pts[s];
                    if (p1.Radius == 0)
                        continue;
                    CollisionHoles(holesPts[h], p1);
                }
            }

            for (int s = 0; s < pts.Count; s++)
            {
                for (int p = s; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p2 = pts[p];

                    if (p1.Id == p2.Id)// BY ID
                        continue;
                    if (p1.Radius == 0 || p2.Radius == 0)
                        continue;

                    axis = p1.Pos - p2.Pos;//vector de direccion
                    dis = axis.Length(); // magnitud

                    if (dis < (p1.Radius + p2.Radius))//COLLISION DETECTED
                    {
                        dif = (dis - (p1.Radius + p2.Radius)) * .5f;// dividir la fuerza para repatar entre ambas colisiones
                        normal = axis / dis; // normalizar la direccion para tener el vector unitario
                        res = dif * normal;// vector resultante

                        if (!p1.IsPinned)
                            if (p2.IsPinned)
                                p1.Pos -= res * 2;
                            else
                                p1.Pos -= res;

                        if (!p2.IsPinned)
                            if (p1.IsPinned)
                                p2.Pos += res * 2;
                            else
                                p2.Pos += res;
                    }
                }

                if (isMouseDown)// para seleccionar el punto de masa a mover escogiendo su ID 
                    if (Math.Abs((p1.X - mouse.X) * (p1.X - mouse.X) + (p1.Y - mouse.Y) * (p1.Y - mouse.Y)) <= ((p1.Radius) * (p1.Radius)))
                        id = p1.Id;

                p1.Render(g, Width, Height);
            }

            return id;
        }
        public void CollisionHoles(Ball hole, VPoint ball)
        {
            var main = Application.OpenForms.OfType<Billar>().First();
            float distancia = (float)Math.Sqrt(Math.Pow((hole.x - ball.X), 2) + Math.Pow((hole.y - ball.Y), 2));

            if (distancia < (ball.Radius + hole.radio - 15))//ESTO SIGNIFICA COLISIÓN...
            {
                // Actualizamos las velocidades de las pelotas
                ball.Radius = 0;
                Vec2 vel = new Vec2(0f, 0f);
                ball.vel = vel;
                main.score += 1;
            }
        }
    }
}
