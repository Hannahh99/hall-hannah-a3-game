using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    internal class Player
    {
        Vector2 position;
        Vector2 size;
        float jumpHeight = 300;
        Vector2 gravity = new Vector2(0, 500);
        Vector2 velocity;
        public Player(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        public void Update()
        {
            
            movement();
            SimulateGravity();
            colision();
            PlayerGraphics();

        }
        public void PlayerGraphics()
        {
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(position, size);
        }
        public void SimulateGravity()
        {
            
            velocity += gravity * Time.DeltaTime;
            position += velocity * Time.DeltaTime;
                
            
        }
        public void colision()
        {
            float playerBottom = position.Y + size.Y;
            if (playerBottom >= 240)
            {
                position.Y = 240 - size.Y;
                velocity.Y = 0;
            }
        }
        public void movement()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity.Y -= jumpHeight;
            }
        }
    }
}
