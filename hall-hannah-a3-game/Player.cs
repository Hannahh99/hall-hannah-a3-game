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
        Vector2 gravity = new Vector2(0, 700);
        Vector2 velocity;

        bool gameOver = false;
        public Player(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        public void Update(Obstacles[] gameObstacles)
        {
            
            movement();
            SimulateGravity();
            colision(gameObstacles);
            PlayerGraphics();
            if (gameOver == true)
            {
                GameOver();
            }

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
        public void colision(Obstacles[] gameObstacles)
        {
            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;
            float playerLeft = position.X;
            float playerRight = position.X + size.X;
            //collision with obstacles in gameObstacles array
            for (int i = 0; i < gameObstacles.Length; i++)
            {
                Obstacles obstacle = gameObstacles[i];

                float obstacleTop = obstacle.position.Y;
                float obstacleBottom = obstacle.position.Y + obstacle.size.Y;
                float obstacleLeft = obstacle.position.X;
                float obstacleRight = obstacle.position.X + obstacle.size.X;

                bool isColliding = false;
                if (playerRight > obstacleLeft && playerLeft < obstacleRight && playerBottom > obstacleTop && playerTop < obstacleBottom)
                {
                    isColliding = true;
                }

                if (isColliding == true)
                {
                    //effect of collision
                    gameOver = true;
                }

            }
            // Floor collision
            if (playerBottom > 240)
            {
                position.Y = 240 - size.Y;
                velocity.Y = 0;
            }
            // Ceiling collision
            if (playerTop < 145)
            {
                position.Y = 145;
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
        public void GameOver()
        {
            // Display Game Over Screen
            Window.ClearBackground(Color.Black);
            // Game Over Text
            Text.Size = 50;
            Text.Color = Color.Red;
            Text.Draw("Game Over", Window.Width / 4 - 10, Window.Height / 2 - 50);
        }
    }
}
