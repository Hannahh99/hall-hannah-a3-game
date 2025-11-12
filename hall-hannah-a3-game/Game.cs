
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        //game state control
        public bool titleScreen = false;
        public bool gameRunning = true;
        public bool rulesScreen = false;
        //not in use
        
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
            if(titleScreen == true)
            {

            }
            if (rulesScreen == true)
            {

            }
            if (gameRunning == true)
            {
                BackgroundGeneration();
                Score();
                PlayerCreation();
            }
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
            Character.Update(gameObstacles);
        }

        public void Score()
        {
            // Display Score
            string scoreText = $"{Time.SecondsElapsed*4:00000}";
            Text.Color = Color.Black;
            Text.Draw(scoreText, 10, 5);
            // Change Font & Size
            
        }

    }

}
