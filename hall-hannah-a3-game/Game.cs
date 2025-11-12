
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player Character = new Player(new Vector2(50, 100), new Vector2(20, 40));

        Obstacles[] gameObstacles =
        {
            new Obstacles(new Vector2(400, 220), new Vector2(10, 20)),
        };

        public void Setup()
        {
            Window.SetTitle("Game"); /// Remember to change the title
            Window.SetSize(400, 400);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            PlayerCreation();
            BackgroundGeneration();
            Score();
        }

        public void BackgroundGeneration()
        {
            Draw.Rectangle(0, 240, 400, 2);

            for(int i = 0; i < gameObstacles.Length; i++)
            {
                gameObstacles[i].Update();
            }

        }
        public void PlayerCreation()
        {
            Character.Update();
        }

        public void Score()
        {
            // Display Score
            string scoreText = $"{Time.SecondsElapsed*4:00000}";
            Text.Color = Color.Black;
            Text.Draw(scoreText, 10, 5);
            // Change Font & Size
            
        }

        public void GameOver()
        {
            // Display Game Over Screen
            Window.ClearBackground(Color.Black);
        }
    }

}
