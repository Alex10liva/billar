using Billar.Properties;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Drawing2D;
using System.Media;
using System.Runtime.Intrinsics.X86;

namespace Billar
{
    public partial class Billar : Form
    {
        Graphics g;
        Graphics gTop;
        Bitmap bmp, bmp2;
        int tableHolesSize = 60;
        SolidBrush holeColor = new SolidBrush(Color.FromArgb(0, 0, 0));
        SolidBrush brownBrush = new SolidBrush(Color.FromArgb(60, 13, 1));
        static List<VPoint> balls2;
        static List<Ball> holes;
        public int score = 0;
        static Random rand = new Random();
        static float deltaTime;
        VSolver solver;
        Point mouse, trigger;
        bool isMouseDown, isRightButton;
        int ballId;
        Pen ballPen = new Pen(Color.FromArgb(255, 255, 255), 10);

        public Billar()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            PCT_Canvas1.BackColor = Color.FromArgb(0, 127, 14);
            PCT_Canvas2.Parent = PCT_Canvas1;
            balls2 = new List<VPoint>();
            holes = new List<Ball>();
            solver = new VSolver(balls2, holes);
            deltaTime = 1;

            int x = PCT_Canvas1.Width / 3;
            int y = PCT_Canvas1.Height / 2;
            int radius = 15;
            int xOffset = (int)((int)radius * (float)1.95);
            int yOffset = radius * 2;

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {

                    int xPos = x - (j * xOffset) - (4 - i) * radius * 2;
                    int yPos = y - (4 - i) * yOffset + (j * yOffset);
                    balls2.Add(new VPoint(xPos, yPos, balls2.Count, tableHolesSize));
                }
            }
            balls2.Add

            //for (int i = 0; i < 10; i++)
            //    balls2.Add(new VPoint(rand.Next(tableHolesSize + 20, PCT_Canvas1.Width - tableHolesSize), rand.Next(tableHolesSize + 20, PCT_Canvas1.Height - tableHolesSize), balls2.Count, tableHolesSize));

            holes.Add(new Ball(rand, PCT_Canvas1.Size, 0, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 1, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 2, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 3, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 4, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 5, tableHolesSize, tableHolesSize / 2));

            for(int i = 0; i < holes.Count; i++)
            {
                holes[i].vx = 0;
                holes[i].vy = 0;
            }
        }

        private void Billar_Load(object sender, EventArgs e)
        {
            DrawTable();
        }

        private void Billar_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            isRightButton = (e.Button == MouseButtons.Right);
            if (isRightButton)
                trigger = e.Location;

            mouse = e.Location;
        }

        private void Billar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    mouse = e.Location;
                    if (ballId > -1)
                    {
                        balls2[ballId].Pos.X = e.Location.X;
                        balls2[ballId].Pos.Y = e.Location.Y;

                        balls2[ballId].Old = balls2[ballId].Pos;
                    }
                }
                else
                    trigger = e.Location;
            }
        }

        private void Billar_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId != -1)
            {
                balls2[ballId].Old.X = e.Location.X;
                balls2[ballId].Old.Y = e.Location.Y;
            }

            ballId = -1;
        }

        private void PCT_Canvas2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PCT_Canvas2_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            isRightButton = (e.Button == MouseButtons.Right);
            if (isRightButton)
                trigger = e.Location;

            mouse = e.Location;
        }

        private void PCT_Canvas2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    mouse = e.Location;
                    if (ballId > -1)
                    {
                        balls2[ballId].Pos.X = e.Location.X;
                        balls2[ballId].Pos.Y = e.Location.Y;

                        balls2[ballId].Old = balls2[ballId].Pos;
                    }
                }
                else
                    trigger = e.Location;
            }
        }

        private void PCT_Canvas2_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId != -1)
            {
                balls2[ballId].Old.X = e.Location.X;
                balls2[ballId].Old.Y = e.Location.Y;
            }

            ballId = -1;
        }

        private void panelCenter_SizeChanged(object sender, EventArgs e)
        {
            DrawTable();
        }

        private void DrawTable()
        {
            int ancho = panelCenter.Width;
            int alto = panelCenter.Height;

            bmp = new Bitmap(ancho, alto);
            bmp2 = new Bitmap(ancho, alto);
            g = Graphics.FromImage(bmp);
            gTop = Graphics.FromImage(bmp2);
            PCT_Canvas1.Image = bmp;
            PCT_Canvas2.Image = bmp2;

            //for (int b = 0; b < balls.Count; b++)
            //{
            //    balls[b].space = panelCenter.Size;
            //    balls[b].tableHolesSize = tableHolesSize;
            //}

            Rectangle r = new Rectangle(0, 0, ancho, alto);
            GraphicsPath gp = new GraphicsPath();
            int d = tableHolesSize;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            PCT_Canvas1.Region = new Region(gp);
            PCT_Canvas2.Region = new Region(gp);

            // Draw the lines in the table
            gTop.FillRectangle(brownBrush, new Rectangle(0, 0, ancho, tableHolesSize));
            gTop.FillRectangle(brownBrush, new Rectangle(ancho - tableHolesSize, 0, tableHolesSize, alto));
            gTop.FillRectangle(brownBrush, new Rectangle(0, alto - tableHolesSize, ancho, tableHolesSize));
            gTop.FillRectangle(brownBrush, new Rectangle(0, 0, tableHolesSize, alto));

            // Draw the holes of the table
            // Top left
            holes[0].x = tableHolesSize;
            holes[0].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[0].x - holes[0].radio, holes[0].y - holes[0].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Top middle
            holes[1].x = (ancho / 2);
            holes[1].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[1].x - holes[1].radio, holes[1].y - holes[1].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Top right
            holes[2].x = (ancho - tableHolesSize);
            holes[2].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[2].x - holes[2].radio, holes[2].y - holes[2].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom right
            holes[3].x = (ancho - tableHolesSize);
            holes[3].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[3].x - holes[3].radio, holes[3].y - holes[3].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom middle
            holes[4].x = (ancho / 2);
            holes[4].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[4].x - holes[4].radio, holes[4].y - holes[4].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom left
            holes[5].x = tableHolesSize;
            holes[5].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[5].x - holes[5].radio, holes[5].y - holes[5].radio, holes[0].radio * 2, holes[0].radio * 2);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            scoreLBL.Text = score.ToString();
            g.Clear(Color.FromArgb(0, 127, 14));

            //Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
            //{
            //    Ball P;
            //    balls[b].Update(deltaTime, balls, holes);
            //    P = balls[b];
            //});

            //Ball p;
            //for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            //{
            //    p = balls[b];
            //    if (p.radio != 0)
            //        g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //}

            ballId = solver.Update(g, PCT_Canvas1.Width, PCT_Canvas1.Height, mouse, isMouseDown);

            if (isMouseDown && isRightButton && ballId != -1)
                g.DrawLine(ballPen, balls2[ballId].X, balls2[ballId].Y, trigger.X, trigger.Y);

            PCT_Canvas1.Invalidate();
            PCT_Canvas2.Invalidate();
            deltaTime += .1f;
        }
    }
}