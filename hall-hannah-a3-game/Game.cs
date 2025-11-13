
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
            new Obstacles(new Vector2(400,  220), new Vector2(10, 20)),
            new Obstacles(new Vector2(700,  220), new Vector2(10, 20)),
            new Obstacles(new Vector2(1000, 220), new Vector2(40, 20)),
            new Obstacles(new Vector2(1300, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(1600, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(1900, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(2100, 220), new Vector2(40, 20)),
            new Obstacles(new Vector2(2400, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(2900, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(3100, 220), new Vector2(20, 20)),
            new Obstacles(new Vector2(3400, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(3700, 220), new Vector2(10, 20)),
            new Obstacles(new Vector2(4000, 220), new Vector2(20, 20)),
            new Obstacles(new Vector2(4300, 220), new Vector2(40, 20)),
            new Obstacles(new Vector2(4600, 200), new Vector2(20, 40)),
        };
        Button titleButtonPlay = new Button(new Vector2(150, 200), new Vector2(100, 50), "Play");
        Button titleButtonRules = new Button(new Vector2(150, 260), new Vector2(100, 50), "Rules");
        Button rulesButtonBack = new Button(new Vector2(150, 300), new Vector2(100, 50), "Back");
        public void Setup()
        {
            Window.SetTitle("Block Jump");
            Window.SetSize(400, 400);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            if (titleScreen == true)
            {
                Text.Size = 40;
                Text.Color = Color.Black;
                Text.Draw("Block Jump", Window.Height / 4, 80);
                titleButtonPlay.Update();
                titleButtonRules.Update();

                if (titleButtonPlay.ButtonPressed() == true)
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
                if (rulesButtonBack.ButtonPressed() == true)
                {
                    rulesScreen = false;
                    titleScreen = true;
                }

                Text.Size = 15;
                Text.Color = Color.Black;
                Text.Draw("The goal of this game is to dodge all the", Window.Width / 4 - 70, Window.Height / 2 - 70);
                Text.Draw("incoming obstacles.", Window.Width / 4 + 10, Window.Height / 2 - 50);
                Text.Draw("Press SPACEBAR to jump", Window.Width / 4, Window.Height / 2 - 30);

            }
            if (gameRunning == true)
            {
                BackgroundGeneration();
                Score();
                PlayerCreation();
                if (playerScore >= 90)
                {
                    gameWon = true;
                }
            }

            if (gameWon == true)
            {
                gameRunning = false;
                Text.Size = 30;
                Text.Color = Color.Black;
                Text.Draw("You Win!", Window.Width / 4 + 30, Window.Height / 2 - 50);
                Text.Draw($"Score: {playerScore}", Window.Width / 3, Window.Height / 2 - 20);
            }
        }

        public void BackgroundGeneration()
        {
            Draw.Rectangle(0, 240, 400, 2);

            for (int i = 0; i < gameObstacles.Length; i++)
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
        }

    }

}
