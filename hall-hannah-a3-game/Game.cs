
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        //game state control
        public bool titleScreen = true;
        public bool gameRunning = false;
        public bool rulesScreen = false;
        public bool gameWon = false;
        
        int playerScore = 0;

        Player Character = new Player(new Vector2(50, 100), new Vector2(20, 40));

        Obstacles[] gameObstacles =
        {
            new Obstacles(new Vector2(400, 220), new Vector2(10, 20)),
        };
        Button titleButtonPlay = new Button(new Vector2(150, 200), new Vector2(100, 50), "Play");
        Button titleButtonRules = new Button(new Vector2(150, 260), new Vector2(100, 50), "Rules");
        Button rulesButtonBack = new Button(new Vector2(150, 300), new Vector2(100, 50), "Back");
        public void Setup()
        {
            Window.SetTitle("Block Jump"); /// Remember to change the title
            Window.SetSize(400, 400);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            if(titleScreen == true)
            {
                Text.Size = 40;
                Text.Color = Color.Black;
                Text.Draw("Block Jump", Window.Height / 4, 80);
                titleButtonPlay.Update();
                titleButtonRules.Update();
                
                if(titleButtonPlay.ButtonPressed() == true)
                {
                    titleScreen = false;
                    gameRunning = true;
                    playerScore = 0;
                }
                if (titleButtonRules.ButtonPressed() == true)
                {
                    titleScreen = false;
                    rulesScreen = true;
                }
            }
            if (rulesScreen == true)
            {
                rulesButtonBack.Update();
                if(rulesButtonBack.ButtonPressed() == true)
                {
                    rulesScreen = false;
                    titleScreen = true;
                }
            }
            if (gameRunning == true)
            {
                BackgroundGeneration();
                Score();
                PlayerCreation();
                if (playerScore >= 480)
                {
                
                }
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
            
            playerScore = (int)(Time.SecondsElapsed * 4);
            string scoreText = $"{playerScore:00000}";
            Text.Color = Color.Black;
            Text.Draw(scoreText, 10, 5);
            // Change Font & Size
            
        }

    }

}
