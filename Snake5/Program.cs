using Snake5;
using System;
using System.IO;
using System.Threading;
using System.Media;
using NAudio.Wave;

namespace Snake3
{
    class program
    {
        

        static void Main(string[] args)
        {

            
            Sound gameOverSound = new Sound(@"C:\Users\opilane\Source\Repos\C-sharp_Snake\Snake5\Gameover.mp3");
            Sound Bgmusic = new Sound(@"C:\Users\opilane\Source\Repos\C-sharp_Snake\Snake5\Snake.mp3");
            Bgmusic.Play();
            
            
            
            
            
            





            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            while (name.Length < 3)
            {
                Console.WriteLine("Name must be at least 3 letters long. Please try again.");
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            }
            Player player = new Player { Name = name, Score = 0 };

            Console.Clear();

            Console.SetWindowSize(79, 25);
            Console.SetBufferSize(79, 25);
            player.Draw(2, 1);
           



            Walls walls = new Walls(79, 25);
            walls.Draw();
            //// list consist a few point                     
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();
            snake.Move();

            FoodCreator foodCreator = new FoodCreator(79, 25, '$');
            Point food = foodCreator.CreatFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    gameOverSound.Play();
                    Bgmusic.Stop();
                    //баллы записываются в копию листа PlayerResult, работает только с указанием полного пути
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\opilane\Source\Repos\C-sharp_Snake\Snake5\PlayResult", true))
                    {
                        writer.WriteLine("Player name: " + player.Name);
                        writer.WriteLine("Score: " + player.Score);
                    }
                    break;
                }

                if (snake.Eat(food))
                {

                    
                    food = foodCreator.CreatFood();
                    
                    food.Draw();
                    
                    player.Score++;
                    
                    player.Draw(2, 1);
                    Sound eatSound = new Sound(@"C:\Users\opilane\Source\Repos\C-sharp_Snake\Snake5\aple.mp3");
                    eatSound.Play();


                }
          

                else
                {
                    snake.Move();
                }
               

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }


        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("Never Back Down", xOffset + 1, yOffset++);
            yOffset += 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("Leaderboard:", xOffset, yOffset++);
            yOffset++;

            // Read the data from the file and display the top 3 results on the console
            string fileName = "C:\\Users\\opilane\\Source\\Repos\\C-sharp_Snake\\Snake5\\PlayResult";
            if (File.Exists(fileName))
            {
                //Выводим на Экран только то количиство строк которое не нарушает работу SetCursorPoition
                string[] lines = File.ReadAllLines(fileName);
                int count = 0;
                foreach (string line in lines)
                {
                    if (count < 7) // display only the first 3 results
                    {
                        WriteText(line, xOffset, yOffset++);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                WriteText("No results found!", xOffset, yOffset++);
            }

        }
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
   

        
}

       
