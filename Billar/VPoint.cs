using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billar
{
    public class VPoint
    {
        bool isPinned = false;
        bool fromBody = false;
        public Vec2 pos, old, vel, gravity;
        int id;
        public float Mass;
        float radius, bounce, diameter, m, frict = 0.99f;
        float groundFriction = 0.7f;
        Color c;
        SolidBrush brush;
        public int tableHolesSize;

        public bool FromBody
        {
            get { return fromBody; }
            set { fromBody = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }
        }
        public float X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public float Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }
        public Vec2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vec2 Old
        {
            get { return old; }
            set { old = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }
        public VPoint(int x, int y, int id, int holesSize)
        {
            this.id = id;
            this.tableHolesSize = holesSize;
            Init(x, y, 0, 0);
        }

        private void Init(int x, int y, float vx, float vy)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);
            gravity = new Vec2(0, 0);
            vel = new Vec2(vx, vy);
            radius = 20;
            diameter = radius + radius;
            Mass = 1f;
            bounce = 1f;
            c = Color.OrangeRed;
            brush = new SolidBrush(c);
        }

        public void Update(int width, int height)
        {
            vel = (pos - old) * frict;

            old = pos;
            pos += vel + gravity;
        }

        public void Constraints(int width, int height)
        {
            if (pos.X < radius) {
                pos.X = radius;
                old.X = (pos.X + vel.X);
            }
            if (pos.X > width - radius) {
                pos.X = width - radius;
                old.X = (pos.X + vel.X);
            }
            if (pos.Y < radius) {
                pos.Y = radius;
                old.Y = (pos.Y + vel.Y);
            }
            if (pos.Y > height - radius) {
                pos.Y = height - radius;
                old.Y = (pos.Y + vel.Y);
            }

            if ((pos.X - radius) <= tableHolesSize || (pos.X + radius) >= width - tableHolesSize)
            {
                if (pos.X - radius <= tableHolesSize)
                {
                    pos.X = (tableHolesSize + radius);
                    old.X = (pos.X + vel.X);
                }
                else
                {
                    pos.X = (width - tableHolesSize) - radius;
                    old.X = (pos.X + vel.X);
                }
            }

            if ((pos.Y - radius) <= tableHolesSize || (pos.Y + radius) >= height - tableHolesSize)
            {
                if (pos.Y - radius <= tableHolesSize)
                {
                    pos.Y = (tableHolesSize + radius);
                    old.Y = (pos.Y + vel.Y);
                }
                else
                {
                    pos.Y = (height - tableHolesSize) - radius;
                    old.Y = (pos.Y + vel.Y);
                }
            }
        }

        public void Render(Graphics g, int width, int height)
        {

            Update(width, height);
            Constraints(width, height);

            g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
        }
    }
}
