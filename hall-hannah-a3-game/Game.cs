using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:

        public void Setup()
        {
            Window.SetTitle("Game");
            Window.SetSize(400, 400);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            BackgroundGeneration();
            Score();
        }

        public void BackgroundGeneration()
        {
            // Ground
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 1;
            Draw.Rectangle(0, 240, 400, 2);

            // Obstacles

        }

        public void Score()
        {
            // Display Score
            string scoreText = $"{Time.SecondsElapsed:0.00}";
            Text.Color = Color.Black;
            Text.Draw(scoreText, 10, 10);
        }
    }

}
