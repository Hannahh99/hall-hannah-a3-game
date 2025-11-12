using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    internal class Obstacles
    {
        public Vector2 position;
        public Vector2 size;
        float speed = 5;
        public Obstacles(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        public void Update()
        {
            ObstacleGraphics();
            movement();
        }
        public void ObstacleGraphics()
        {
            Draw.FillColor = Color.Black;
            Draw.Rectangle(position, size);
        }
        public void movement()
        {
            position.X -= speed;
        }
    }
}
